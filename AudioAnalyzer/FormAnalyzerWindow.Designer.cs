
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
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.filToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogAudioFile = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.chartFrequencyDomain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTimeDomain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.backgroundWorkerFFT = new System.ComponentModel.BackgroundWorker();
            this.menuStripMain.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFrequencyDomain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTimeDomain)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(800, 30);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // filToolStripMenuItem
            // 
            this.filToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.filToolStripMenuItem.Name = "filToolStripMenuItem";
            this.filToolStripMenuItem.Size = new System.Drawing.Size(38, 26);
            this.filToolStripMenuItem.Text = "Fil";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.openToolStripMenuItem.Text = "Åben lydfil";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openFileDialogAudioFile
            // 
            this.openFileDialogAudioFile.FileName = "openFileDialog";
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
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(800, 398);
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
            this.chartFrequencyDomain.Location = new System.Drawing.Point(3, 202);
            this.chartFrequencyDomain.Name = "chartFrequencyDomain";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartFrequencyDomain.Series.Add(series1);
            this.chartFrequencyDomain.Size = new System.Drawing.Size(622, 193);
            this.chartFrequencyDomain.TabIndex = 3;
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
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "AudioSamples";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            this.chartTimeDomain.Series.Add(series2);
            this.chartTimeDomain.Size = new System.Drawing.Size(622, 193);
            this.chartTimeDomain.TabIndex = 0;
            this.chartTimeDomain.Text = "chart1";
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
            this.tabControl1.Size = new System.Drawing.Size(166, 392);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(158, 363);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(158, 363);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // FormAnalyzerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.statusStrip1);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem filToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogAudioFile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTimeDomain;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFrequencyDomain;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFFT;
    }
}

