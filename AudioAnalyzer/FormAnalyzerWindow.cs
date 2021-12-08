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

namespace AudioAnalyzer
{
    public partial class FormAnalyzerWindow : Form
    {
        private const int MinSamplesForFourier = 500;
        private const double SampleDisplayCount = 800;

        //private Point mouseDown;
        private int mouseDownX;
        private List<DataPoint> selectedPoints = new List<DataPoint>();
        private WaveFile editedWaveFile;
        private double[] amplitudeData;

        public FormAnalyzerWindow()
        {
            InitializeComponent();
        }

        private void FormAnalyzerWindow_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogAudioFile.Filter = "Wave filer (*.wav)|*.wav|Alle filer (*.*)|*.*";
            DialogResult res = openFileDialogAudioFile.ShowDialog();

            if (res != DialogResult.OK)
            {
                return;
            }

            if (!openFileDialogAudioFile.CheckFileExists)
            {
                return;
            }

            editedWaveFile = new WaveFile(openFileDialogAudioFile.FileName);
            amplitudeData = editedWaveFile.GetDemodulatedAudio();

            DrawTimeDomainGraph();
        }

        private void DrawTimeDomainGraph()
        {
            selectedPoints.Clear();
            chartTimeDomain.Series[0].Points.Clear();

            int interval = (int)((double)amplitudeData.Length / SampleDisplayCount);

            for (int i = 0; i < amplitudeData.Length; i++)
            {
                if (i % interval != 0 && i != amplitudeData.Length - 1)
                {
                    continue;
                }

                double xValue = (double)i / editedWaveFile.WaveData.Subchunk1.SampleRate;
                chartTimeDomain.Series[0].Points.AddXY(xValue, amplitudeData[i]);
            }
        }

        private void chartTimeDomain_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownX = e.Location.X;
            selectedPoints.Clear();
        }

        private void chartTimeDomain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            chartTimeDomain.Refresh();
            using (Graphics g = chartTimeDomain.CreateGraphics())
                g.DrawLine(Pens.Red, mouseDownX, 0, mouseDownX, chartTimeDomain.Height);

            using (Graphics g = chartTimeDomain.CreateGraphics())
                g.DrawLine(Pens.Red, e.Location.X, 0, e.Location.X, chartTimeDomain.Height);
        }

        private void chartTimeDomain_MouseUp(object sender, MouseEventArgs e)
        {
            Axis ax = chartTimeDomain.ChartAreas[0].AxisX;

            double rangeStartX = ax.PixelPositionToValue(Math.Min(mouseDownX, e.Location.X));
            double rangeEndX = ax.PixelPositionToValue(Math.Max(mouseDownX, e.Location.X));

            foreach (DataPoint dp in chartTimeDomain.Series[0].Points)
            {
                //int x = (int)ax.ValueToPixelPosition(dp.XValue);
                //int y = (int)ay.ValueToPixelPosition(dp.YValues[0]);

                //int rangeStartX = Math.Min(mouseDownX, e.Location.X);
                //int rangeEndX = Math.Max(mouseDownX, e.Location.X);

                if (dp.XValue < rangeStartX)
                {
                    continue;
                }

                if (dp.XValue > rangeEndX)
                {
                    continue;
                }

                selectedPoints.Add(dp);
            }

            // optionally color the found datapoints:
            foreach (DataPoint dp in chartTimeDomain.Series[0].Points)
                dp.Color = selectedPoints.Contains(dp) ? Color.Red : Color.Blue;
        }
    }
}
