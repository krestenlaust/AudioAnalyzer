
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.menuStripMain.Size = new System.Drawing.Size(800, 28);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 24);
            this.fileToolStripMenuItem.Text = "&Fil";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.openToolStripMenuItem.Text = "&Åben lydfil...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.saveToolStripMenuItem.Text = "&Gem";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.saveAsToolStripMenuItem.Text = "Gem s&om...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(170, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.closeToolStripMenuItem.Text = "Luk";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.toolStripSeparator3,
            this.deleteSelectionToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.editToolStripMenuItem.Text = "R&ediger";
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.selectAllToolStripMenuItem.Text = "Vælg alt (Virker ikke)";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(225, 6);
            // 
            // deleteSelectionToolStripMenuItem
            // 
            this.deleteSelectionToolStripMenuItem.Name = "deleteSelectionToolStripMenuItem";
            this.deleteSelectionToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteSelectionToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.deleteSelectionToolStripMenuItem.Text = "Slet markering";
            this.deleteSelectionToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectionToolStripMenuItem_Click);
            // 
            // openFileDialogAudioFile
            // 
            this.openFileDialogAudioFile.Filter = "Wave filer (*.wav)|*.wav|Alle filer (*.*)|*.*";
            this.openFileDialogAudioFile.SupportMultiDottedExtensions = true;
            this.openFileDialogAudioFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogAudioFile_FileOk);
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanelMain.Controls.Add(this.chartFrequencyDomain, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.chartTimeDomain, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tabControlGraphInfo, 2, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(800, 400);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // chartFrequencyDomain
            // 
            chartArea3.CursorX.IsUserEnabled = true;
            chartArea3.CursorX.IsUserSelectionEnabled = true;
            chartArea3.Name = "ChartArea1";
            this.chartFrequencyDomain.ChartAreas.Add(chartArea3);
            this.chartFrequencyDomain.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            this.chartFrequencyDomain.Legends.Add(legend3);
            this.chartFrequencyDomain.Location = new System.Drawing.Point(3, 203);
            this.chartFrequencyDomain.Name = "chartFrequencyDomain";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartFrequencyDomain.Series.Add(series3);
            this.chartFrequencyDomain.Size = new System.Drawing.Size(594, 194);
            this.chartFrequencyDomain.TabIndex = 1;
            this.chartFrequencyDomain.KeyUp += new System.Windows.Forms.KeyEventHandler(this.chartFrequencyDomain_KeyUp);
            // 
            // chartTimeDomain
            // 
            chartArea4.AxisX.Crossing = -1.7976931348623157E+308D;
            chartArea4.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea4.AxisX.IsMarginVisible = false;
            chartArea4.AxisX.Minimum = 0D;
            chartArea4.AxisX.MinorTickMark.Enabled = true;
            chartArea4.AxisX.ToolTip = "Tid i lyden";
            chartArea4.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea4.CursorX.IsUserEnabled = true;
            chartArea4.CursorX.IsUserSelectionEnabled = true;
            chartArea4.Name = "ChartArea1";
            this.chartTimeDomain.ChartAreas.Add(chartArea4);
            this.chartTimeDomain.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Enabled = false;
            legend4.Name = "Legend1";
            this.chartTimeDomain.Legends.Add(legend4);
            this.chartTimeDomain.Location = new System.Drawing.Point(3, 3);
            this.chartTimeDomain.Name = "chartTimeDomain";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series4.IsVisibleInLegend = false;
            series4.Legend = "Legend1";
            series4.Name = "AudioSamples";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            this.chartTimeDomain.Series.Add(series4);
            this.chartTimeDomain.Size = new System.Drawing.Size(594, 194);
            this.chartTimeDomain.TabIndex = 0;
            this.chartTimeDomain.KeyUp += new System.Windows.Forms.KeyEventHandler(this.chartTimeDomain_KeyUp);
            // 
            // tabControlGraphInfo
            // 
            this.tabControlGraphInfo.Controls.Add(this.tabPageMainControls);
            this.tabControlGraphInfo.Controls.Add(this.tabPageMetadata);
            this.tabControlGraphInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlGraphInfo.Location = new System.Drawing.Point(603, 3);
            this.tabControlGraphInfo.Multiline = true;
            this.tabControlGraphInfo.Name = "tabControlGraphInfo";
            this.tableLayoutPanelMain.SetRowSpan(this.tabControlGraphInfo, 2);
            this.tabControlGraphInfo.SelectedIndex = 0;
            this.tabControlGraphInfo.Size = new System.Drawing.Size(194, 394);
            this.tabControlGraphInfo.TabIndex = 8;
            // 
            // tabPageMainControls
            // 
            this.tabPageMainControls.Controls.Add(this.flowLayoutPanel1);
            this.tabPageMainControls.Location = new System.Drawing.Point(4, 25);
            this.tabPageMainControls.Name = "tabPageMainControls";
            this.tabPageMainControls.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMainControls.Size = new System.Drawing.Size(186, 365);
            this.tabPageMainControls.TabIndex = 0;
            this.tabPageMainControls.Text = "Styring";
            this.tabPageMainControls.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox3);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(180, 359);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonFFT);
            this.groupBox3.Controls.Add(this.buttonInverseFFT);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(174, 80);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Graf transformering";
            // 
            // buttonFFT
            // 
            this.buttonFFT.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonFFT.Location = new System.Drawing.Point(3, 18);
            this.buttonFFT.Name = "buttonFFT";
            this.buttonFFT.Size = new System.Drawing.Size(168, 29);
            this.buttonFFT.TabIndex = 5;
            this.buttonFFT.Text = "Lyd til frekvens ↓";
            this.buttonFFT.UseVisualStyleBackColor = true;
            this.buttonFFT.Click += new System.EventHandler(this.buttonFFT_Click);
            // 
            // buttonInverseFFT
            // 
            this.buttonInverseFFT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonInverseFFT.Location = new System.Drawing.Point(3, 48);
            this.buttonInverseFFT.Name = "buttonInverseFFT";
            this.buttonInverseFFT.Size = new System.Drawing.Size(168, 29);
            this.buttonInverseFFT.TabIndex = 4;
            this.buttonInverseFFT.Text = "Frekvens til lyd ↑";
            this.buttonInverseFFT.UseVisualStyleBackColor = true;
            this.buttonInverseFFT.Click += new System.EventHandler(this.buttonInverseFFT_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonAudioStop);
            this.groupBox1.Controls.Add(this.buttonAudioPlay);
            this.groupBox1.Location = new System.Drawing.Point(3, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(174, 80);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lydstyring";
            // 
            // buttonAudioStop
            // 
            this.buttonAudioStop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonAudioStop.Location = new System.Drawing.Point(3, 49);
            this.buttonAudioStop.Name = "buttonAudioStop";
            this.buttonAudioStop.Size = new System.Drawing.Size(168, 28);
            this.buttonAudioStop.TabIndex = 1;
            this.buttonAudioStop.Text = "Stop";
            this.buttonAudioStop.UseVisualStyleBackColor = true;
            this.buttonAudioStop.Click += new System.EventHandler(this.buttonAudioStop_Click);
            // 
            // buttonAudioPlay
            // 
            this.buttonAudioPlay.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAudioPlay.Location = new System.Drawing.Point(3, 18);
            this.buttonAudioPlay.Name = "buttonAudioPlay";
            this.buttonAudioPlay.Size = new System.Drawing.Size(168, 29);
            this.buttonAudioPlay.TabIndex = 0;
            this.buttonAudioPlay.Text = "Afspil";
            this.buttonAudioPlay.UseVisualStyleBackColor = true;
            this.buttonAudioPlay.Click += new System.EventHandler(this.buttonAudioPlay_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.radioButtonAlgorithmRobust);
            this.groupBox2.Controls.Add(this.radioButtonAlgorithmHomemade);
            this.groupBox2.Location = new System.Drawing.Point(3, 175);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(174, 80);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Algoritme";
            // 
            // radioButtonAlgorithmRobust
            // 
            this.radioButtonAlgorithmRobust.AutoSize = true;
            this.radioButtonAlgorithmRobust.Checked = true;
            this.radioButtonAlgorithmRobust.Location = new System.Drawing.Point(7, 48);
            this.radioButtonAlgorithmRobust.Name = "radioButtonAlgorithmRobust";
            this.radioButtonAlgorithmRobust.Size = new System.Drawing.Size(74, 21);
            this.radioButtonAlgorithmRobust.TabIndex = 1;
            this.radioButtonAlgorithmRobust.TabStop = true;
            this.radioButtonAlgorithmRobust.Text = "Rubust";
            this.radioButtonAlgorithmRobust.UseVisualStyleBackColor = true;
            // 
            // radioButtonAlgorithmHomemade
            // 
            this.radioButtonAlgorithmHomemade.AutoSize = true;
            this.radioButtonAlgorithmHomemade.Location = new System.Drawing.Point(7, 21);
            this.radioButtonAlgorithmHomemade.Name = "radioButtonAlgorithmHomemade";
            this.radioButtonAlgorithmHomemade.Size = new System.Drawing.Size(110, 21);
            this.radioButtonAlgorithmHomemade.TabIndex = 0;
            this.radioButtonAlgorithmHomemade.Text = "Hjemmelavet";
            this.radioButtonAlgorithmHomemade.UseVisualStyleBackColor = true;
            this.radioButtonAlgorithmHomemade.CheckedChanged += new System.EventHandler(this.radioButtonAlgorithmHomemade_CheckedChanged);
            // 
            // tabPageMetadata
            // 
            this.tabPageMetadata.Location = new System.Drawing.Point(4, 46);
            this.tabPageMetadata.Name = "tabPageMetadata";
            this.tabPageMetadata.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMetadata.Size = new System.Drawing.Size(186, 344);
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
            this.statusStripMain.Location = new System.Drawing.Point(0, 428);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(800, 22);
            this.statusStripMain.TabIndex = 2;
            this.statusStripMain.Text = "statusStripMain";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.discordJoinToolStripMenuItem,
            this.toolStripMenuItem2,
            this.og250ToolStripMenuItem});
            this.toolStripSplitButton1.Enabled = false;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(146, 24);
            this.toolStripSplitButton1.Text = "Test - discord join";
            this.toolStripSplitButton1.Visible = false;
            this.toolStripSplitButton1.ButtonClick += new System.EventHandler(this.toolStripSplitButton1_ButtonClick);
            // 
            // discordJoinToolStripMenuItem
            // 
            this.discordJoinToolStripMenuItem.Name = "discordJoinToolStripMenuItem";
            this.discordJoinToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.discordJoinToolStripMenuItem.Text = "discord join";
            this.discordJoinToolStripMenuItem.Click += new System.EventHandler(this.discordJoinToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(170, 26);
            this.toolStripMenuItem2.Text = "440";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // og250ToolStripMenuItem
            // 
            this.og250ToolStripMenuItem.Name = "og250ToolStripMenuItem";
            this.og250ToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.og250ToolStripMenuItem.Text = "440 og 250";
            this.og250ToolStripMenuItem.Click += new System.EventHandler(this.og250ToolStripMenuItem_Click);
            // 
            // toolStripStatusLabelSelectedSamples
            // 
            this.toolStripStatusLabelSelectedSamples.Name = "toolStripStatusLabelSelectedSamples";
            this.toolStripStatusLabelSelectedSamples.Size = new System.Drawing.Size(0, 16);
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
            this.saveFileDialogAudioFile.Filter = "Wave filer|*.wav";
            this.saveFileDialogAudioFile.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialogAudioFile_FileOk);
            // 
            // pictureBoxDragIcon
            // 
            this.pictureBoxDragIcon.Image = global::AudioAnalyzer.Properties.Resources.DropFile;
            this.pictureBoxDragIcon.Location = new System.Drawing.Point(0, 420);
            this.pictureBoxDragIcon.Name = "pictureBoxDragIcon";
            this.pictureBoxDragIcon.Size = new System.Drawing.Size(104, 92);
            this.pictureBoxDragIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxDragIcon.TabIndex = 8;
            this.pictureBoxDragIcon.TabStop = false;
            this.pictureBoxDragIcon.Visible = false;
            // 
            // FormAnalyzerWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBoxDragIcon);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormAnalyzerWindow";
            this.Text = "Lyd analyse værktøj";
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

