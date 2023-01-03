
namespace AudioAnalyzer
{
    partial class FormAnalyzerWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnalyzerWindow));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogAudioFile = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.chartFrequencyDomain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTimeDomain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControlGraphInfo = new System.Windows.Forms.TabControl();
            this.tabPageMainControls = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonFFT = new System.Windows.Forms.Button();
            this.buttonInverseFFT = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAudioStop = new System.Windows.Forms.Button();
            this.buttonAudioPlay = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonAlgorithmRobust = new System.Windows.Forms.RadioButton();
            this.radioButtonAlgorithmHomemade = new System.Windows.Forms.RadioButton();
            this.tabPageMetadata = new System.Windows.Forms.TabPage();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.discordJoinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.og250ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabelSelectedSamples = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorkerFFT = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialogAudioFile = new System.Windows.Forms.SaveFileDialog();
            this.pictureBoxDragIcon = new System.Windows.Forms.PictureBox();
            this.menuStripMain.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFrequencyDomain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTimeDomain)).BeginInit();
            this.tabControlGraphInfo.SuspendLayout();
            this.tabPageMainControls.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDragIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStripMain.Size = new System.Drawing.Size(600, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStripMain";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.openToolStripMenuItem.Text = "&Open audiofile...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(158, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.saveAsToolStripMenuItem.Text = "Save &as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(158, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.toolStripSeparator3,
            this.deleteSelectionToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.selectAllToolStripMenuItem.Text = "Select all (Not implemented)";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(222, 6);
            // 
            // deleteSelectionToolStripMenuItem
            // 
            this.deleteSelectionToolStripMenuItem.Name = "deleteSelectionToolStripMenuItem";
            this.deleteSelectionToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteSelectionToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.deleteSelectionToolStripMenuItem.Text = "Remove selection";
            this.deleteSelectionToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectionToolStripMenuItem_Click);
            // 
            // openFileDialogAudioFile
            // 
            this.openFileDialogAudioFile.Filter = "Wave files (*.wav)|*.wav|All files (*.*)|*.*";
            this.openFileDialogAudioFile.SupportMultiDottedExtensions = true;
            this.openFileDialogAudioFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogAudioFile_FileOk);
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tableLayoutPanelMain.Controls.Add(this.chartFrequencyDomain, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.chartTimeDomain, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tabControlGraphInfo, 2, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(600, 320);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // chartFrequencyDomain
            // 
            chartArea7.CursorX.IsUserEnabled = true;
            chartArea7.CursorX.IsUserSelectionEnabled = true;
            chartArea7.Name = "ChartArea1";
            this.chartFrequencyDomain.ChartAreas.Add(chartArea7);
            this.chartFrequencyDomain.Dock = System.Windows.Forms.DockStyle.Fill;
            legend7.Enabled = false;
            legend7.Name = "Legend1";
            this.chartFrequencyDomain.Legends.Add(legend7);
            this.chartFrequencyDomain.Location = new System.Drawing.Point(2, 162);
            this.chartFrequencyDomain.Margin = new System.Windows.Forms.Padding(2);
            this.chartFrequencyDomain.Name = "chartFrequencyDomain";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chartFrequencyDomain.Series.Add(series7);
            this.chartFrequencyDomain.Size = new System.Drawing.Size(437, 156);
            this.chartFrequencyDomain.TabIndex = 1;
            this.chartFrequencyDomain.KeyUp += new System.Windows.Forms.KeyEventHandler(this.chartFrequencyDomain_KeyUp);
            // 
            // chartTimeDomain
            // 
            chartArea8.AxisX.Crossing = -1.7976931348623157E+308D;
            chartArea8.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea8.AxisX.IsMarginVisible = false;
            chartArea8.AxisX.Minimum = 0D;
            chartArea8.AxisX.MinorTickMark.Enabled = true;
            chartArea8.AxisX.ToolTip = "Tid i lyden";
            chartArea8.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea8.CursorX.IsUserEnabled = true;
            chartArea8.CursorX.IsUserSelectionEnabled = true;
            chartArea8.Name = "ChartArea1";
            this.chartTimeDomain.ChartAreas.Add(chartArea8);
            this.chartTimeDomain.Dock = System.Windows.Forms.DockStyle.Fill;
            legend8.Enabled = false;
            legend8.Name = "Legend1";
            this.chartTimeDomain.Legends.Add(legend8);
            this.chartTimeDomain.Location = new System.Drawing.Point(2, 2);
            this.chartTimeDomain.Margin = new System.Windows.Forms.Padding(2);
            this.chartTimeDomain.Name = "chartTimeDomain";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series8.IsVisibleInLegend = false;
            series8.Legend = "Legend1";
            series8.Name = "AudioSamples";
            series8.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            this.chartTimeDomain.Series.Add(series8);
            this.chartTimeDomain.Size = new System.Drawing.Size(437, 156);
            this.chartTimeDomain.TabIndex = 0;
            this.chartTimeDomain.KeyUp += new System.Windows.Forms.KeyEventHandler(this.chartTimeDomain_KeyUp);
            // 
            // tabControlGraphInfo
            // 
            this.tabControlGraphInfo.Controls.Add(this.tabPageMainControls);
            this.tabControlGraphInfo.Controls.Add(this.tabPageMetadata);
            this.tabControlGraphInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlGraphInfo.Location = new System.Drawing.Point(443, 2);
            this.tabControlGraphInfo.Margin = new System.Windows.Forms.Padding(2);
            this.tabControlGraphInfo.Multiline = true;
            this.tabControlGraphInfo.Name = "tabControlGraphInfo";
            this.tableLayoutPanelMain.SetRowSpan(this.tabControlGraphInfo, 2);
            this.tabControlGraphInfo.SelectedIndex = 0;
            this.tabControlGraphInfo.Size = new System.Drawing.Size(155, 316);
            this.tabControlGraphInfo.TabIndex = 8;
            // 
            // tabPageMainControls
            // 
            this.tabPageMainControls.Controls.Add(this.flowLayoutPanel1);
            this.tabPageMainControls.Location = new System.Drawing.Point(4, 22);
            this.tabPageMainControls.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageMainControls.Name = "tabPageMainControls";
            this.tabPageMainControls.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageMainControls.Size = new System.Drawing.Size(147, 290);
            this.tabPageMainControls.TabIndex = 0;
            this.tabPageMainControls.Text = "Transform";
            this.tabPageMainControls.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox3);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(143, 286);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonFFT);
            this.groupBox3.Controls.Add(this.buttonInverseFFT);
            this.groupBox3.Location = new System.Drawing.Point(2, 2);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(138, 65);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Graph transformation";
            // 
            // buttonFFT
            // 
            this.buttonFFT.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonFFT.Location = new System.Drawing.Point(2, 15);
            this.buttonFFT.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFFT.Name = "buttonFFT";
            this.buttonFFT.Size = new System.Drawing.Size(134, 24);
            this.buttonFFT.TabIndex = 5;
            this.buttonFFT.Text = "Amplitude to frequency ↓";
            this.buttonFFT.UseVisualStyleBackColor = true;
            this.buttonFFT.Click += new System.EventHandler(this.buttonFFT_Click);
            // 
            // buttonInverseFFT
            // 
            this.buttonInverseFFT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonInverseFFT.Location = new System.Drawing.Point(2, 39);
            this.buttonInverseFFT.Margin = new System.Windows.Forms.Padding(2);
            this.buttonInverseFFT.Name = "buttonInverseFFT";
            this.buttonInverseFFT.Size = new System.Drawing.Size(134, 24);
            this.buttonInverseFFT.TabIndex = 4;
            this.buttonInverseFFT.Text = "Frequency to amplitude ↑";
            this.buttonInverseFFT.UseVisualStyleBackColor = true;
            this.buttonInverseFFT.Click += new System.EventHandler(this.buttonInverseFFT_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonAudioStop);
            this.groupBox1.Controls.Add(this.buttonAudioPlay);
            this.groupBox1.Location = new System.Drawing.Point(2, 71);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(136, 65);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Audio playback";
            // 
            // buttonAudioStop
            // 
            this.buttonAudioStop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonAudioStop.Location = new System.Drawing.Point(2, 40);
            this.buttonAudioStop.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAudioStop.Name = "buttonAudioStop";
            this.buttonAudioStop.Size = new System.Drawing.Size(132, 23);
            this.buttonAudioStop.TabIndex = 1;
            this.buttonAudioStop.Text = "Stop";
            this.buttonAudioStop.UseVisualStyleBackColor = true;
            this.buttonAudioStop.Click += new System.EventHandler(this.buttonAudioStop_Click);
            // 
            // buttonAudioPlay
            // 
            this.buttonAudioPlay.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAudioPlay.Location = new System.Drawing.Point(2, 15);
            this.buttonAudioPlay.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAudioPlay.Name = "buttonAudioPlay";
            this.buttonAudioPlay.Size = new System.Drawing.Size(132, 24);
            this.buttonAudioPlay.TabIndex = 0;
            this.buttonAudioPlay.Text = "Play";
            this.buttonAudioPlay.UseVisualStyleBackColor = true;
            this.buttonAudioPlay.Click += new System.EventHandler(this.buttonAudioPlay_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.radioButtonAlgorithmRobust);
            this.groupBox2.Controls.Add(this.radioButtonAlgorithmHomemade);
            this.groupBox2.Location = new System.Drawing.Point(2, 140);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(136, 65);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FFT-Algorithm";
            // 
            // radioButtonAlgorithmRobust
            // 
            this.radioButtonAlgorithmRobust.AutoSize = true;
            this.radioButtonAlgorithmRobust.Checked = true;
            this.radioButtonAlgorithmRobust.Location = new System.Drawing.Point(5, 39);
            this.radioButtonAlgorithmRobust.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonAlgorithmRobust.Name = "radioButtonAlgorithmRobust";
            this.radioButtonAlgorithmRobust.Size = new System.Drawing.Size(66, 17);
            this.radioButtonAlgorithmRobust.TabIndex = 1;
            this.radioButtonAlgorithmRobust.TabStop = true;
            this.radioButtonAlgorithmRobust.Text = "MathNet";
            this.radioButtonAlgorithmRobust.UseVisualStyleBackColor = true;
            // 
            // radioButtonAlgorithmHomemade
            // 
            this.radioButtonAlgorithmHomemade.AutoSize = true;
            this.radioButtonAlgorithmHomemade.Location = new System.Drawing.Point(5, 17);
            this.radioButtonAlgorithmHomemade.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonAlgorithmHomemade.Name = "radioButtonAlgorithmHomemade";
            this.radioButtonAlgorithmHomemade.Size = new System.Drawing.Size(79, 17);
            this.radioButtonAlgorithmHomemade.TabIndex = 0;
            this.radioButtonAlgorithmHomemade.Text = "Homemade";
            this.radioButtonAlgorithmHomemade.UseVisualStyleBackColor = true;
            this.radioButtonAlgorithmHomemade.CheckedChanged += new System.EventHandler(this.radioButtonAlgorithmHomemade_CheckedChanged);
            // 
            // tabPageMetadata
            // 
            this.tabPageMetadata.Location = new System.Drawing.Point(4, 22);
            this.tabPageMetadata.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageMetadata.Name = "tabPageMetadata";
            this.tabPageMetadata.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageMetadata.Size = new System.Drawing.Size(147, 290);
            this.tabPageMetadata.TabIndex = 1;
            this.tabPageMetadata.Text = "Metadata";
            this.tabPageMetadata.UseVisualStyleBackColor = true;
            // 
            // statusStripMain
            // 
            this.statusStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripStatusLabelSelectedSamples});
            this.statusStripMain.Location = new System.Drawing.Point(0, 344);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStripMain.Size = new System.Drawing.Size(600, 22);
            this.statusStripMain.TabIndex = 2;
            this.statusStripMain.Text = "statusStripMain";
            // 
            // toolStripStatusLabelSelectedSamples
            // 
            this.toolStripStatusLabelSelectedSamples.Name = "toolStripStatusLabelSelectedSamples";
            this.toolStripStatusLabelSelectedSamples.Size = new System.Drawing.Size(0, 17);
            // 
            // backgroundWorkerFFT
            // 
            this.backgroundWorkerFFT.WorkerSupportsCancellation = true;
            this.backgroundWorkerFFT.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFFT_DoWork);
            this.backgroundWorkerFFT.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerFFT_ProgressChanged);
            this.backgroundWorkerFFT.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFFT_RunWorkerCompleted);
            // 
            // saveFileDialogAudioFile
            // 
            this.saveFileDialogAudioFile.DefaultExt = "wav";
            this.saveFileDialogAudioFile.Filter = "Wave files|*.wav";
            this.saveFileDialogAudioFile.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialogAudioFile_FileOk);
            // 
            // pictureBoxDragIcon
            // 
            this.pictureBoxDragIcon.Image = global::AudioAnalyzer.Properties.Resources.DropFile;
            this.pictureBoxDragIcon.Location = new System.Drawing.Point(0, 341);
            this.pictureBoxDragIcon.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxDragIcon.Name = "pictureBoxDragIcon";
            this.pictureBoxDragIcon.Size = new System.Drawing.Size(78, 75);
            this.pictureBoxDragIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxDragIcon.TabIndex = 8;
            this.pictureBoxDragIcon.TabStop = false;
            this.pictureBoxDragIcon.Visible = false;
            // 
            // FormAnalyzerWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.pictureBoxDragIcon);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormAnalyzerWindow";
            this.Text = "Audio analysis tool";
            this.Load += new System.EventHandler(this.FormAnalyzerWindow_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormAnalyzerWindow_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormAnalyzerWindow_DragEnter);
            this.DragLeave += new System.EventHandler(this.FormAnalyzerWindow_DragLeave);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormAnalyzerWindow_KeyUp);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.tableLayoutPanelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartFrequencyDomain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTimeDomain)).EndInit();
            this.tabControlGraphInfo.ResumeLayout(false);
            this.tabPageMainControls.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDragIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogAudioFile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTimeDomain;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFrequencyDomain;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFFT;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSelectedSamples;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem discordJoinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem og250ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogAudioFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button buttonInverseFFT;
        private System.Windows.Forms.Button buttonFFT;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonAudioStop;
        private System.Windows.Forms.Button buttonAudioPlay;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectionToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxDragIcon;
        private System.Windows.Forms.TabControl tabControlGraphInfo;
        private System.Windows.Forms.TabPage tabPageMainControls;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonAlgorithmRobust;
        private System.Windows.Forms.RadioButton radioButtonAlgorithmHomemade;
        private System.Windows.Forms.TabPage tabPageMetadata;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

