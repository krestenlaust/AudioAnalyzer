using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Aud.IO.Formats;
using MathNet.Numerics;

namespace AudioAnalyzer
{
    public partial class FormAnalyzerWindow : Form
    {
        private const int MinWindowSamples = 500;
        private const int SamplecountResolution = 1_000_000;

        private WaveFile editedWaveFile;
        private float[] loadedAmplitudeData;
        private Complex32[] loadedFrequencyData;
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
            pictureBoxDragIcon.Enabled = false;
        }

        private void FormAnalyzerWindow_Load(object sender, EventArgs e)
        {
            timeDomain = new ChartSelectionHelper(chartTimeDomain);
            timeDomain.OnUpdatedSelection += TimeDomain_OnUpdatedSelection;

            frequencyDomain = new ChartSelectionHelper(chartFrequencyDomain);

            selectedFFTAlgorithm = FFTAlgorithms.RobustFFT;
        }

        private void UpdateStatusStrip(string msg)
        {
            toolStripStatusLabelSelectedSamples.Text = msg;
            statusStripMain.Update();
        }

        private async Task LoadAudiofileAndPopulate(string path, bool customStartStatus = false)
        {
            // Fjern nuværende fil data.
            editedWaveFile = null;
            loadedAmplitudeData = null;
            loadedFrequencyData = null;
            ClearPoints(chartTimeDomain);
            ClearPoints(chartFrequencyDomain);
            GC.Collect();

            // Hvis en fil er trukket, skriver metoden selv, hvordan det gik.
            if (!customStartStatus)
            {
                UpdateStatusStrip($"Indlæser lydfil: {path}");
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();
            editedWaveFile = await WaveFile.LoadFileAsync(path);
            loadedAmplitudeData = editedWaveFile.GetDemodulatedAudio();
            Text = Path.GetFileName(path);
            UseWaitCursor = true;
            PopulateTimeDomainGraph(loadedAmplitudeData);
            sw.Stop();
            UseWaitCursor = false;

            UpdateStatusStrip($"Indlæste lydfil på {sw.Elapsed.TotalSeconds:F2} sekunder");
        }

        private void PopulateMetadataTab()
        {
            //labelChannelCount.Text = editedWaveFile.ChannelCount == 2 ? "Stereo" : "Mono";
            //labelSamplerate.Text = editedWaveFile.SampleRate.ToString();
            //labelByterate.Text = editedWaveFile.ByteRate.ToString();
            //labelBitsPerSample.Text = editedWaveFile.BitsPerSample.ToString();
        }

        private async Task SaveFile(string filePath)
        {
            UpdateStatusStrip($"Gemmer lydfil til placeringen: {filePath}");
            await editedWaveFile.WriteAudioFileAsync(filePath);
            this.Text = filePath;
            UpdateStatusStrip($"Lydfil gemt til placeringen: {filePath}");
        }

        private void ClearPoints(Chart chart)
        {
            // Langt hurtigere end at bruge normal clear metode.
            chart.Series.Add(new Series()
            {
                ChartType = chart.Series[0].ChartType,
                XValueType = chart.Series[0].XValueType,
                YValueType = chart.Series[0].YValueType
            });
            chart.Series.RemoveAt(0);
        }

        private void PopulateTimeDomainGraph(float[] analogData)
        {
            ClearPoints(chartTimeDomain);
            timeDomain.Deselect();
            chartTimeDomain.ChartAreas[0].CursorX.Interval = 1 / editedWaveFile.SampleRate;

            int dataSize = Math.Min(analogData.Length, SamplecountResolution);
            float xSpacingModifier = (float)analogData.Length / dataSize;

            float[] xValues = new float[dataSize];
            for (int i = 0; i < dataSize; i++)
            {
                xValues[i] = (i * xSpacingModifier) / editedWaveFile.SampleRate;
            }

            float[] yValues = new float[dataSize];
            for (int i = 0; i < dataSize; i++)
            {
                // TODO: implement LERPing to possibly get a more accurate value
                yValues[i] = analogData[(int)Math.Round(i * xSpacingModifier)];
            }

            // En smule hurtigere end at tilføje dem en ad gangen
            chartTimeDomain.Series[0].Points.DataBindXY(xValues, yValues);
        }

        private void PopulateFrequencyDomainGraph(Complex32[] frequencyBins)
        {
            float frequencyBinSize = (float)editedWaveFile.SampleRate / frequencyBins.Length;

            ClearPoints(chartFrequencyDomain);
            frequencyDomain.Deselect();
            chartFrequencyDomain.ChartAreas[0].CursorX.Interval = frequencyBinSize;
            int dataCount = frequencyBins.Length / 2;

            float[] xValues = new float[dataCount];
            for (int i = 0; i < dataCount; i++)
            {
                xValues[i] = frequencyBinSize * (i + 1);
            }

            float[] yValues = new float[dataCount];
            for (int i = 0; i < dataCount; i++)
            {
                yValues[i] = frequencyBins[i].Magnitude / dataCount;
            }

            chartFrequencyDomain.Series[0].Points.DataBindXY(xValues, yValues);
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
                float[] inputData = new float[windowSize];

                for (int i = 0; i < length; i++)
                {
                    inputData[i] = loadedAmplitudeData[i + offset];
                }

                e.Result = selectedFFTAlgorithm.FFT(inputData);
            }
            else
            {
                Complex32[] inputData = new Complex32[windowSize];

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

            if (e.Result is Complex32[] toFFT)
            {
                loadedFrequencyData = toFFT;
                PopulateFrequencyDomainGraph(loadedFrequencyData);
            }
            else if (e.Result is float[] toAmplitude)
            {
                loadedAmplitudeData = toAmplitude;
                editedWaveFile.SetDemodulatedAudio(loadedAmplitudeData);
                PopulateTimeDomainGraph(loadedAmplitudeData);
            }
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e) => discordJoinToolStripMenuItem_Click(sender, e);

        private async void openFileDialogAudioFile_FileOk(object sender, CancelEventArgs e)
        {
            if (!openFileDialogAudioFile.CheckFileExists)
            {
                return;
            }

            await LoadAudiofileAndPopulate(openFileDialogAudioFile.FileName);
        }

        private async void saveFileDialogAudioFile_FileOk(object sender, CancelEventArgs e)
        {
            lastSavedPath = saveFileDialogAudioFile.FileName;
            await SaveFile(saveFileDialogAudioFile.FileName);
        }

        private async void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lastSavedPath is null)
            {
                saveFileDialogAudioFile.ShowDialog();
                return;
            }

            await SaveFile(lastSavedPath);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialogAudioFile.ShowDialog();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task PlayAudio()
        {
            if (editedWaveFile is null)
            {
                UpdateStatusStrip("Ingen lyd at afspille");
                return;
            }

            // Write current audio represented in editedWaveFile.
            string tempFile = Path.GetTempFileName();
            await editedWaveFile.WriteAudioFileAsync(tempFile);

            // Load temporary file into memory to delete it afterwards.
            MemoryStream waveFile = new MemoryStream(File.ReadAllBytes(tempFile));
            File.Delete(tempFile);

            // Play the audio file from memory.
            soundPlayer = new SoundPlayer(waveFile);
            soundPlayer.Play();
        }

        private async void FormAnalyzerWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    await PlayAudio();
                    break;
                case Keys.S when e.Control && !(editedWaveFile is null):
                    if (lastSavedPath is null)
                    {
                        saveFileDialogAudioFile.ShowDialog();
                        return;
                    }

                    await SaveFile(lastSavedPath);
                    break;
                default:
                    break;
            }
        }

        private async void buttonAudioPlay_Click(object sender, EventArgs e)
        {
            this.Focus();

            await PlayAudio();
        }

        private void buttonAudioStop_Click(object sender, EventArgs e)
        {
            this.Focus();

            soundPlayer?.Stop();
        }

        private void DeleteFromFrequencyDomain(int index, int length)
        {
            int N = loadedFrequencyData.Length;
            for (int i = index; i < N / 2; i++)
            {
                // Er nået slutningen af området.
                if (i > index + length)
                {
                    break;
                }

                loadedFrequencyData[i] = Complex32.Zero;
            }

            // Modificer det spejlvendte område også
            for (int i = (N - index) - length; i < N; i++)
            {
                // Er nået slutningen af det spejlvendte område.
                if (i > N - index)
                {
                    break;
                }

                loadedFrequencyData[i] = Complex32.Zero;
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

        private async void chartTimeDomain_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete when timeDomain.Selected:

                    break;
                case Keys.Space:
                    await PlayAudio();
                    break;
                default:
                    break;
            }
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

        private void deleteSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private async void og250ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await LoadAudiofileAndPopulate(@"C:\Users\kress\Documents\SOP\440 og 250 frekvens 441 samplerate.wav");
        }

        private async void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            await LoadAudiofileAndPopulate(@"C:\Users\kress\Documents\SOP\440 frekvens 441 samplerate sinus ny.wav");
        }

        private void ToggleDropTargetImage(bool shown)
        {
            pictureBoxDragIcon.Visible = shown;
            pictureBoxDragIcon.Dock = shown ? DockStyle.Fill : DockStyle.None;
        }

        private void FormAnalyzerWindow_DragEnter(object sender, DragEventArgs e)
        {
            ToggleDropTargetImage(true);
            e.Effect = DragDropEffects.Copy;
        }

        private async void FormAnalyzerWindow_DragDrop(object sender, DragEventArgs e)
        {
            var filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            ToggleDropTargetImage(false);

            if (filePaths.Length == 0)
            {
                return;
            }

            string targetFile = filePaths[0];

            if (filePaths.Length > 1)
            {
                UpdateStatusStrip($"Flere filer trukket indlæser (første) fil fra placering: {targetFile}");
                await LoadAudiofileAndPopulate(targetFile, true);

            }
            else
            {
                await LoadAudiofileAndPopulate(targetFile, false);
            }
        }

        private void FormAnalyzerWindow_DragLeave(object sender, EventArgs e)
        {
            ToggleDropTargetImage(false);
        }

        private async void discordJoinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await LoadAudiofileAndPopulate(@"C:\Users\kress\Downloads\discord join.wav");
        }
    }
}
