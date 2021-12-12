
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnalyzerWindow));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogAudioFile = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.chartFrequencyDomain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTimeDomain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonInverseFFT = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.discordJoinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.og250ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabelSelectedSamples = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorkerFFT = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialogAudioFile = new System.Windows.Forms.SaveFileDialog();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFrequencyDomain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTimeDomain)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStripMain.SuspendLayout();
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
            this.fileToolStripMenuItem.Text = "Fil";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openToolStripMenuItem.Text = "&Åben lydfil...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.editToolStripMenuItem.Text = "Rediger";
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.selectAllToolStripMenuItem.Text = "Vælg alt";
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
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Controls.Add(this.chartFrequencyDomain, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.chartTimeDomain, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tabControl1, 1, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(800, 396);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // chartFrequencyDomain
            // 
            chartArea1.Name = "ChartArea1";
            this.chartFrequencyDomain.ChartAreas.Add(chartArea1);
            this.chartFrequencyDomain.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartFrequencyDomain.Legends.Add(legend1);
            this.chartFrequencyDomain.Location = new System.Drawing.Point(3, 201);
            this.chartFrequencyDomain.Name = "chartFrequencyDomain";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartFrequencyDomain.Series.Add(series1);
            this.chartFrequencyDomain.Size = new System.Drawing.Size(622, 192);
            this.chartFrequencyDomain.TabIndex = 1;
            // 
            // chartTimeDomain
            // 
            chartArea2.AxisX.Crossing = -1.7976931348623157E+308D;
            chartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisX.IsMarginVisible = false;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisX.MinorTickMark.Enabled = true;
            chartArea2.AxisX.ToolTip = "Tid i lyden";
            chartArea2.Name = "ChartArea1";
            this.chartTimeDomain.ChartAreas.Add(chartArea2);
            this.chartTimeDomain.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chartTimeDomain.Legends.Add(legend2);
            this.chartTimeDomain.Location = new System.Drawing.Point(3, 3);
            this.chartTimeDomain.Name = "chartTimeDomain";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "AudioSamples";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            this.chartTimeDomain.Series.Add(series2);
            this.chartTimeDomain.Size = new System.Drawing.Size(622, 192);
            this.chartTimeDomain.TabIndex = 0;
            this.chartTimeDomain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chartTimeDomain_MouseDown);
            this.chartTimeDomain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartTimeDomain_MouseMove);
            this.chartTimeDomain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chartTimeDomain_MouseUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(631, 3);
            this.tabControl1.Name = "tabControl1";
            this.tableLayoutPanelMain.SetRowSpan(this.tabControl1, 2);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(166, 390);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonInverseFFT);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(158, 361);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonInverseFFT
            // 
            this.buttonInverseFFT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInverseFFT.Location = new System.Drawing.Point(7, 7);
            this.buttonInverseFFT.Name = "buttonInverseFFT";
            this.buttonInverseFFT.Size = new System.Drawing.Size(145, 29);
            this.buttonInverseFFT.TabIndex = 4;
            this.buttonInverseFFT.Text = "FFT til amplitude";
            this.buttonInverseFFT.UseVisualStyleBackColor = true;
            this.buttonInverseFFT.Click += new System.EventHandler(this.buttonInverseFFT_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(158, 361);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // statusStripMain
            // 
            this.statusStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripStatusLabelSelectedSamples});
            this.statusStripMain.Location = new System.Drawing.Point(0, 424);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(800, 26);
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
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(146, 24);
            this.toolStripSplitButton1.Text = "Test - discord join";
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
            this.toolStripStatusLabelSelectedSamples.Size = new System.Drawing.Size(0, 20);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveToolStripMenuItem.Text = "&Gem";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveAsToolStripMenuItem.Text = "Gem s&om...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.closeToolStripMenuItem.Text = "Luk";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // FormAnalyzerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.statusStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormAnalyzerWindow";
            this.Text = "Lyd analyse værktøj";
            this.Load += new System.EventHandler(this.FormAnalyzerWindow_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.tableLayoutPanelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartFrequencyDomain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTimeDomain)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFFT;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSelectedSamples;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem discordJoinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem og250ToolStripMenuItem;
        private System.Windows.Forms.Button buttonInverseFFT;
        private System.Windows.Forms.SaveFileDialog saveFileDialogAudioFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}

