using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Media;
using System.Numerics;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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
        private IAlgorithmFFT selectedFFTAlgorithm;

        public FormAnalyzerWindow()
        {
            InitializeComponent();
        }

        private void FormAnalyzerWindow_Load(object sender, EventArgs e)
        {
            timeDomain = new ChartSelectionHelper(chartTimeDomain);
            timeDomain.OnUpdatedSelection += TimeDomain_OnUpdatedSelection;

            frequencyDomain = new ChartSelectionHelper(chartFrequencyDomain);

            selectedFFTAlgorithm = FFTAlgorithms.HomemadeFFT;
        }

        private void UpdateStatusStrip(string msg)
        {
            toolStripStatusLabelSelectedSamples.Text = msg;
            statusStripMain.Update();
        }

        private void LoadAudiofileAndPopulate(string path)
        {
            editedWaveFile = new WaveFile(path);
            loadedAmplitudeData = editedWaveFile.GetDemodulatedAudio();
            Text = Path.GetFileName(path);
            UpdateStatusStrip($"Indlæste lydfil på længde: {editedWaveFile.AudioDuration:F2} sekunder");

            PopulateTimeDomainGraph(loadedAmplitudeData);
        }

        private void SaveFile(string filePath)
        {
            editedWaveFile.WriteAudioFile(filePath);
            this.Text = filePath;
        }

        private void ClearPoints(Chart chart)
        {
            chart.Series.Add(new Series()
            {
                ChartType = chart.Series[0].ChartType,
                XValueType = chart.Series[0].XValueType,
                YValueType = chart.Series[0].YValueType
            });
            chart.Series.RemoveAt(0);
        }


        private void PopulateTimeDomainGraph(double[] analogAmplitude)
        {
            ClearPoints(chartTimeDomain);
            timeDomain.Deselect();
            chartTimeDomain.ChartAreas[0].CursorX.Interval = 1 / editedWaveFile.SampleRate;

            for (int i = 0; i < analogAmplitude.Length; i++)
            {
                double xValue = (double)i / editedWaveFile.SampleRate;
                chartTimeDomain.Series[0].Points.AddXY(xValue, analogAmplitude[i]);
            }
        }

        private void PopulateFrequencyDomainGraph(Complex[] frequencyBins)
        {
            ClearPoints(chartFrequencyDomain);

            float frequencyBinSize = (float)editedWaveFile.SampleRate / frequencyBins.Length;

            for (int i = 0; i < frequencyBins.Length / 2; i++)
            {
                chartFrequencyDomain.Series[0].Points.AddXY(
                    frequencyBinSize * (i + 1),
                    frequencyBins[i].Magnitude
                    );
            }
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

        private void backgroundWorkerFFT_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statusStripMain.Update();
        }

        private void backgroundWorkerFFT_DoWork(object sender, DoWorkEventArgs e)
        {
            (int offset, int length, bool toFFT) = ((int, int, bool))e.Argument;

            // Cooley-Tukey er begrænset til input størrelser som går op i 2^n
            // Rund op til nærmeste.
            int windowSize = selectedFFTAlgorithm.AdjustWindowSize(length);

            if (toFFT)
            {
                double[] inputData = new double[windowSize];

                for (int i = 0; i < length; i++)
                {
                    inputData[i] = loadedAmplitudeData[i + offset];
                }

                e.Result = selectedFFTAlgorithm.FFT(inputData);
            }
            else
            {
                Complex[] inputData = new Complex[windowSize];

                for (int i = 0; i < length; i++)
                {
                    inputData[i] = loadedFrequencyData[i + offset];
                }

                e.Result = selectedFFTAlgorithm.IFFT(inputData);
            }
        }

        private void StartFFTBackgroundWorker(ChartSelectionHelper chartSelection, bool toFFT)
        {
            float samplingInterval;
            if (toFFT)
            {
                samplingInterval = editedWaveFile.SampleRate;
            }
            else
            {
                samplingInterval = (float)editedWaveFile.SampleRate / loadedFrequencyData.Length;
            }

            int selectionStartIndex = (int)(chartSelection.SelectionStart * samplingInterval);
            int selectionLengthIndex = (int)(chartSelection.SelectionLength * samplingInterval);

            // Cut-off, så man ikke får værdier undenfor de datapunkter man har.
            if (selectionLengthIndex + selectionStartIndex >= editedWaveFile.Samples)
            {
                selectionLengthIndex = editedWaveFile.Samples - selectionStartIndex;
            }

            if (!chartSelection.Selected)
            {
                selectionStartIndex = 0;
                selectionLengthIndex = toFFT ? loadedAmplitudeData.Length : loadedFrequencyData.Length;
            }

            if (selectionLengthIndex < MinWindowSamples)
            {
                UpdateStatusStrip($"Ikke nok data markeret, markér mindst {MinWindowSamples} datapunkter");
                return;
            }

            backgroundWorkerFFT.CancelAsync();
            backgroundWorkerFFT.RunWorkerAsync((selectionStartIndex, selectionLengthIndex, toFFT));
        }

        private void buttonFFT_Click(object sender, EventArgs e)
        {
            if (loadedAmplitudeData is null)
            {
                UpdateStatusStrip("Ingen lyd at konvertere");
                return;
            }

            StartFFTBackgroundWorker(timeDomain, true);

            this.Focus();
        }

        private void buttonInverseFFT_Click(object sender, EventArgs e)
        {
            if (loadedFrequencyData is null)
            {
                UpdateStatusStrip("Ingen FFT graf at konvertere");
                return;
            }

            StartFFTBackgroundWorker(frequencyDomain, false);

            this.Focus();
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

            if (e.Result is Complex[] toFFT)
            {
                loadedFrequencyData = toFFT;
                PopulateFrequencyDomainGraph(loadedFrequencyData);
            }
            else if (e.Result is double[] toAmplitude)
            {
                loadedAmplitudeData = toAmplitude;
                editedWaveFile.SetDemodulatedAudio(loadedAmplitudeData);
                PopulateTimeDomainGraph(loadedAmplitudeData);
            }
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
            if (editedWaveFile is null)
            {
                UpdateStatusStrip("Ingen lyd at afspille");
                return;
            }

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
                case Keys.S when e.Control && !(editedWaveFile is null):
                    saveToolStripMenuItem_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void buttonAudioPlay_Click(object sender, EventArgs e)
        {
            this.Focus();
            
            PlayAudio();
        }

        private void buttonAudioStop_Click(object sender, EventArgs e)
        {
            this.Focus();
            
            soundPlayer?.Stop();
        }

        private void DeleteFromFrequencyDomain(int index, int length)
        {
            int N = loadedFrequencyData.Length;
            for (int i = index; i < N/2; i++)
            {
                // Er nået slutningen af området.
                if (i > index + length)
                {
                    break;
                }
                
                loadedFrequencyData[i] = Complex.Zero;
            }

            // Modificer det spejlvendte område også
            for (int i = (N - index) - length; i < N; i++)
            {
                // Er nået slutningen af det spejlvendte område.
                if (i > N - index)
                {
                    break;
                }

                loadedFrequencyData[i] = Complex.Zero;
            }
        }

        private void chartFrequencyDomain_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete when frequencyDomain.Selected:
                    float frequencyBinSize = (float)editedWaveFile.SampleRate / loadedFrequencyData.Length;

                    DeleteFromFrequencyDomain(
                        (int)(frequencyDomain.SelectionStart / frequencyBinSize),
                        (int)(frequencyDomain.SelectionLength / frequencyBinSize));

                    PopulateFrequencyDomainGraph(loadedFrequencyData);

                    frequencyDomain.Deselect();
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

        private void deleteSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void og250ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadAudiofileAndPopulate(@"C:\Users\kress\Documents\SOP\440 og 250 frekvens 441 samplerate.wav");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            LoadAudiofileAndPopulate(@"C:\Users\kress\Documents\SOP\440 frekvens 441 samplerate sinus ny.wav");
        }

        private void radioButtonAlgorithmHomemade_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAlgorithmHomemade.Checked)
            {
                selectedFFTAlgorithm = FFTAlgorithms.HomemadeFFT;
            }
            else
            {
                selectedFFTAlgorithm = FFTAlgorithms.RobustFFT;
            }
        }

        private void discordJoinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadAudiofileAndPopulate(@"C:\Users\kress\Downloads\discord join.wav");
        }
    }
}
