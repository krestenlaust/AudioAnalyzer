using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Media;
using System.Numerics;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MathNet.Numerics;
using MathNet.Numerics.IntegralTransforms;
using Aud.IO.Algorithms;
using Aud.IO.Formats;

namespace AudioAnalyzer
{
    public partial class FormAnalyzerWindow : Form
    {
        private const int MinWindowSamples = 500;

        private WaveFile editedWaveFile;
        private double[] loadedAmplitudeData;
        private Complex[] loadedFrequencyData;
        private ChartSelectionHelper timeDomain, frequencyDomain;
        /// <summary>
        /// Gemmer den sti der blev gemt til senest,
        /// er null når filen ikke er gemt før.
        /// </summary>
        private string lastSavedPath = null;
        private SoundPlayer soundPlayer;

        public FormAnalyzerWindow()
        {
            InitializeComponent();
        }

        private void FormAnalyzerWindow_Load(object sender, EventArgs e)
        {
            timeDomain = new ChartSelectionHelper(chartTimeDomain);
            timeDomain.OnUpdatedSelection += TimeDomain_OnUpdatedSelection;

            frequencyDomain = new ChartSelectionHelper(chartFrequencyDomain);
        }

        private void UpdateStatusStrip(string msg)
        {
            toolStripStatusLabelSelectedSamples.Text = msg;
            statusStripMain.Update();
        }

        private void TimeDomain_OnUpdatedSelection()
        {
            int rangeLength = (int)(timeDomain.SelectionLength * editedWaveFile.SampleRate);
            if (rangeLength >= MinWindowSamples)
            {
                UpdateStatusStrip($"Du har markeret {rangeLength} datapunkter");
            }
            else
            {
                UpdateStatusStrip($"Du har markeret {rangeLength}/{MinWindowSamples} datapunkter");
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Håndteres i eventlisteneren
            openFileDialogAudioFile.ShowDialog();
        }

        private void LoadAudiofileAndPopulate(string path)
        {
            editedWaveFile = new WaveFile(path);
            loadedAmplitudeData = editedWaveFile.GetDemodulatedAudio();
            Text = Path.GetFileName(path);
            UpdateStatusStrip($"Loadede lydfil på længde: {editedWaveFile.AudioDuration:F2} sekunder");

            PopulateTimeDomainGraph(loadedAmplitudeData);
        }

        private void PopulateTimeDomainGraph(double[] analogAmplitude)
        {
            chartTimeDomain.Series[0].Points.Clear();
            timeDomain.Deselect();

            int interval = 1;

            for (int i = 0; i < analogAmplitude.Length; i++)
            {
                if (i % interval != 0 && i != analogAmplitude.Length - 1)
                {
                    continue;
                }

                double xValue = (double)i / editedWaveFile.SampleRate;
                chartTimeDomain.Series[0].Points.AddXY(xValue, analogAmplitude[i]);
            }
        }

        private Complex[] CalculateFFTLibrary(int offset, int length)
        {
            Complex32[] frequencies = new Complex32[length];
            for (int i = 0; i < length; i++)
            {
                frequencies[i] = new Complex32((float)loadedAmplitudeData[i + offset], 0);
            }

            Fourier.Forward(frequencies);

            // Omdan til Complex array i stedet for Complex32
            Complex[] frequencies2 = new Complex[length];
            for (int i = 0; i < length; i++)
            {
                frequencies2[i] = new Complex(frequencies[i].Real, frequencies[i].Imaginary);
            }

            return frequencies2;
        }

        private void PopulateFrequencyDomainGraph(Complex[] frequencyBins)
        {
            chartFrequencyDomain.Series[0].Points.Clear();

            float frequencyBinSize = (float)editedWaveFile.SampleRate / frequencyBins.Length;

            for (int i = 0; i < frequencyBins.Length / 2; i++)
            {
                chartFrequencyDomain.Series[0].Points.AddXY(
                    frequencyBinSize * (i + 1),
                    frequencyBins[i].Magnitude
                    );
            }
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
                // der er sket en fejl
                throw e.Error;
            }
            else if (e.Cancelled)
            {
                return;
            }

            loadedFrequencyData = (Complex[])e.Result;
            PopulateFrequencyDomainGraph(loadedFrequencyData);
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
                inputData[i] = loadedAmplitudeData[i + offset];
            }

            Complex[] outputData = CooleyTukey.Forward(inputData);

            e.Result = outputData;
            //e.Result = CalculateFFT(offset, length);
        }

        private void buttonInverseFFT_Click(object sender, EventArgs e)
        {
            if (loadedFrequencyData is null)
            {
                UpdateStatusStrip("Ingen FFT graf at konvertere");
                return;
            }

            Fourier.Inverse(loadedFrequencyData);
            loadedAmplitudeData = new double[loadedFrequencyData.Length];

            for (int i = 0; i < loadedFrequencyData.Length; i++)
            {
                loadedAmplitudeData[i] = loadedFrequencyData[i].Real;
            }

            editedWaveFile.SetDemodulatedAudio(loadedAmplitudeData);
            PopulateTimeDomainGraph(loadedAmplitudeData);
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

        private void SaveFile(string filePath)
        {
            editedWaveFile.WriteAudioFile(filePath);
            this.Text = filePath;
        }

        private void saveFileDialogAudioFile_FileOk(object sender, CancelEventArgs e)
        {
            SaveFile(saveFileDialogAudioFile.FileName);
            lastSavedPath = saveFileDialogAudioFile.FileName;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lastSavedPath is null)
            {
                saveAsToolStripMenuItem_Click(sender, e);
                return;
            }

            SaveFile(lastSavedPath);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialogAudioFile.ShowDialog();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PlayAudio()
        {
            // Write current audio represented in editedWaveFile.
            string tempFile = Path.GetTempFileName();
            editedWaveFile.WriteAudioFile(tempFile);

            // Load temporary file into memory to delete it afterwards.
            MemoryStream waveFile = new MemoryStream(File.ReadAllBytes(tempFile));
            File.Delete(tempFile);

            // Play the audio file from memory.
            soundPlayer = new SoundPlayer(waveFile);
            soundPlayer.Play();
        }

        private void FormAnalyzerWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    PlayAudio();
                    break;
                case Keys.S when e.Control:
                    saveToolStripMenuItem_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void buttonFFT_Click(object sender, EventArgs e)
        {
            if (!timeDomain.Selected)
            {
                UpdateStatusStrip("Ingen data markeret");
                return;
            }

            int selectionStartIndex = (int)(timeDomain.SelectionStart * editedWaveFile.SampleRate);
            int selectionLengthIndex = (int)(timeDomain.SelectionLength * editedWaveFile.SampleRate);

            if (selectionLengthIndex < MinWindowSamples)
            {
                UpdateStatusStrip($"Ikke nok data markeret, markér mindst {MinWindowSamples} datapunkter");
                return;
            }

            backgroundWorkerFFT.CancelAsync();
            backgroundWorkerFFT.RunWorkerAsync((selectionStartIndex, selectionLengthIndex));
        }

        private void buttonAudioPlay_Click(object sender, EventArgs e)
        {
            PlayAudio();
        }

        private void buttonAudioStop_Click(object sender, EventArgs e)
        {
            soundPlayer?.Stop();
        }

        private void chartFrequencyDomain_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete when frequencyDomain.Selected:
                    break;
                default:
                    break;
            }
        }

        private void chartTimeDomain_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete when timeDomain.Selected:
                    
                    break;
                case Keys.Space:
                    PlayAudio();
                    break;
                default:
                    break;
            }
        }
    }
}
