using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Aud.IO;
using Aud.IO.Formats;
using Aud.IO.Algorithms;
using MathNet.Numerics;
using MathNet.Numerics.IntegralTransforms;
using System.Numerics;
using System.IO;

namespace AudioAnalyzer
{
    public partial class FormAnalyzerWindow : Form
    {
        private const int MinWindowSamples = 500;

        //private Point mouseDown;
        /// <summary>
        /// Markørens position da et tryk *blev startet* (onmousedown).
        /// Er null, når det første tryk fandt sted før 0 på x-aksen.
        /// </summary>
        private int? mouseDownPixelX;
        private int selectedRangeIndexStart;
        private int selectedRangeIndexEnd;
        private WaveFile editedWaveFile;
        private double[] amplitudeData;
        private Complex32[] frequencyData;

        public FormAnalyzerWindow()
        {
            InitializeComponent();
        }

        private void FormAnalyzerWindow_Load(object sender, EventArgs e)
        {
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Håndteres i eventlisteneren
            openFileDialogAudioFile.ShowDialog();
        }

        private void LoadAudiofileAndPopulate(string path)
        {
            editedWaveFile = new WaveFile(path);
            amplitudeData = editedWaveFile.GetDemodulatedAudio();
            Text = Path.GetFileName(path);

            PopulateTimeDomainGraph(amplitudeData);
        }

        private void PopulateTimeDomainGraph(double[] analogAmplitude)
        {
            chartTimeDomain.Series[0].Points.Clear();

            //float chartPixelWidth = chartTimeDomain.ChartAreas[0].InnerPlotPosition.Width / 100 * chartTimeDomain.Size.Width;
            //int interval = (int)(amplitudeData.Length / (chartPixelWidth / PixelsPerDisplayPoint));
            int interval = 1;

            for (int i = 0; i < analogAmplitude.Length; i++)
            {
                if (i % interval != 0 && i != analogAmplitude.Length - 1)
                {
                    continue;
                }

                double xValue = (double)i / editedWaveFile.WaveData.Subchunk1.SampleRate;
                chartTimeDomain.Series[0].Points.AddXY(xValue, analogAmplitude[i]);
            }
        }

        private Complex32[] CalculateFFT(int offset, int length)
        {
            Complex32[] frequencies = new Complex32[length];
            for (int i = 0; i < length; i++)
            {
                frequencies[i] = new Complex32((float)amplitudeData[i + offset], 0);
            }

            Fourier.Forward(frequencies);

            return frequencies;
        }

        private void PopulateFrequencyDomainGraph(Complex32[] frequencyBins)
        {
            chartFrequencyDomain.Series[0].Points.Clear();

            float frequencyBinSize = (float)editedWaveFile.WaveData.Subchunk1.SampleRate / frequencyBins.Length;

            for (int i = 0; i < frequencyBins.Length / 2; i++)
            {
                chartFrequencyDomain.Series[0].Points.AddXY(
                    frequencyBinSize * (i + 1),
                    frequencyBins[i].Magnitude
                    );
            }
        }

        private void chartTimeDomain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            Axis ax = chartTimeDomain.ChartAreas[0].AxisX;
            double positionX = ax.PixelPositionToValue(e.Location.X);

            if (positionX < 0)
            {
                mouseDownPixelX = null;
            }
            else
            {
                mouseDownPixelX = e.Location.X;
            }
        }

        private void chartTimeDomain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || editedWaveFile is null)
            {
                return;
            }

            Axis ax = chartTimeDomain.ChartAreas[0].AxisX;

            if (mouseDownPixelX is null)
            {
                double positionX = ax.PixelPositionToValue(e.Location.X);

                if (positionX < 0)
                {
                    return;
                }

                mouseDownPixelX = e.Location.X;
            }

            if (e.Location.X < 0)
            {
                return;
            }
            
            double rangeStartX = ax.PixelPositionToValue(Math.Min(mouseDownPixelX.Value, e.Location.X));
            double rangeEndX = ax.PixelPositionToValue(Math.Max(mouseDownPixelX.Value, e.Location.X));

            selectedRangeIndexStart = (int)(rangeStartX * editedWaveFile.WaveData.Subchunk1.SampleRate);
            selectedRangeIndexEnd = (int)(rangeEndX * editedWaveFile.WaveData.Subchunk1.SampleRate);

            int rangeLength = selectedRangeIndexEnd - selectedRangeIndexStart;
            if (rangeLength >= MinWindowSamples)
            {
                toolStripStatusLabelSelectedSamples.Text = $"Du har markeret {rangeLength} datapunkter";
            }
            else
            {
                toolStripStatusLabelSelectedSamples.Text = $"Du har markeret {rangeLength}/{MinWindowSamples} datapunkter";
            }

            chartTimeDomain.Refresh();

            using (Graphics g = chartTimeDomain.CreateGraphics())
                g.DrawLine(Pens.Black, mouseDownPixelX.Value, 0, mouseDownPixelX.Value, chartTimeDomain.Height);

            using (Graphics g = chartTimeDomain.CreateGraphics())
                g.DrawLine(Pens.Black, e.Location.X, 0, e.Location.X, chartTimeDomain.Height);
        }

        private void chartTimeDomain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || editedWaveFile is null)
            {
                return;
            }

            Axis ax = chartTimeDomain.ChartAreas[0].AxisX;

            double rangeStartX = ax.PixelPositionToValue(Math.Min(mouseDownPixelX.Value, e.Location.X));
            double rangeEndX = ax.PixelPositionToValue(Math.Max(mouseDownPixelX.Value, e.Location.X));

            foreach (DataPoint dp in chartTimeDomain.Series[0].Points)
            {
                if (dp.XValue < rangeStartX)
                {
                    continue;
                }

                if (dp.XValue > rangeEndX)
                {
                    continue;
                }
            }

            foreach (var datapoint in chartTimeDomain.Series[0].Points)
            {
                datapoint.Color = datapoint.XValue >= rangeStartX && datapoint.XValue < rangeEndX
                    ? Color.Red : Color.Blue;
            }

            int rangeLength = selectedRangeIndexEnd - selectedRangeIndexStart;
            if (rangeLength >= MinWindowSamples)
            {
                backgroundWorkerFFT.CancelAsync();
                backgroundWorkerFFT.RunWorkerAsync((selectedRangeIndexStart, rangeLength));
            }

            toolStripStatusLabelSelectedSamples.Text = $"Du markede {rangeLength} datapunkter";
            statusStripMain.Update();
        }

        private void og250ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadAudiofileAndPopulate(@"C:\Users\kress\Documents\SOP\440 og 250 frekvens 441 samplerate.wav");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            LoadAudiofileAndPopulate(@"C:\Users\kress\Documents\SOP\440 frekvens 441 samplerate sinus ny.wav");
        }

        private void discordJoinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadAudiofileAndPopulate(@"C:\Users\kress\Downloads\discord join.wav");
        }

        private void backgroundWorkerFFT_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statusStripMain.Update();
        }

        private void backgroundWorkerFFT_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!(e.Error is null))
            {
                // throw
            }
            else if (e.Cancelled)
            {
                return;
            }

            frequencyData = (Complex32[])e.Result;
            PopulateFrequencyDomainGraph(frequencyData);
        }

        public static int FloorPower2(int x)
        {
            if (x < 1)
            {
                return 1;
            }
            return (int)Math.Pow(2, (int)Math.Log(x, 2));
        }

        private void backgroundWorkerFFT_DoWork(object sender, DoWorkEventArgs e)
        {
            (int offset, int length) = ((int, int))e.Argument;

            int windowLength = FloorPower2(length);
            double[] inputData = new double[windowLength];
            for (int i = 0; i < windowLength; i++)
            {
                inputData[i] = amplitudeData[i + offset];
            }

            Complex[] outputData = CooleyTukey.Forward(inputData);

            Complex32[] frequencies = new Complex32[length];
            for (int i = 0; i < outputData.Length; i++)
            {
                frequencies[i] = new Complex32((float)outputData[i].Real, (float)outputData[i].Imaginary);
            }

            e.Result = frequencies;

            //e.Result = CalculateFFT(offset, length);
        }

        private void buttonInverseFFT_Click(object sender, EventArgs e)
        {
            Fourier.Inverse(frequencyData);
            amplitudeData = new double[frequencyData.Length];

            for (int i = 0; i < frequencyData.Length; i++)
            {
                amplitudeData[i] = frequencyData[i].Real;
            }

            PopulateTimeDomainGraph(amplitudeData);
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e) => discordJoinToolStripMenuItem_Click(sender, e);

        private void openFileDialogAudioFile_FileOk(object sender, CancelEventArgs e)
        {
            if (!openFileDialogAudioFile.CheckFileExists)
            {
                return;
            }

            LoadAudiofileAndPopulate(openFileDialogAudioFile.FileName);
        }

        private void saveFileDialogAudioFile_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
