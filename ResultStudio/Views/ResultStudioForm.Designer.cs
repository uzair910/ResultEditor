namespace ResultStudio
{
    partial class ResultStudioForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnReadFile = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.chartTabControl = new System.Windows.Forms.TabControl();
            this.tabChart = new System.Windows.Forms.TabPage();
            this.chartAxisData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.xAxisStatsPage = new System.Windows.Forms.TabPage();
            this.chartXAxis = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.statsXAxis = new Views.StatsViewControl();
            this.yAxisStatPage = new System.Windows.Forms.TabPage();
            this.statsYAxis = new Views.StatsViewControl();
            this.chartYAxis = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.zAxisStatsPage = new System.Windows.Forms.TabPage();
            this.statsZAxis = new Views.StatsViewControl();
            this.chartZAxis = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpControls = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.chartTabControl.SuspendLayout();
            this.tabChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAxisData)).BeginInit();
            this.xAxisStatsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartXAxis)).BeginInit();
            this.yAxisStatPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartYAxis)).BeginInit();
            this.zAxisStatsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartZAxis)).BeginInit();
            this.grpControls.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(0, 55);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(460, 388);
            this.dgvData.TabIndex = 0;
            // 
            // btnReadFile
            // 
            this.btnReadFile.Location = new System.Drawing.Point(0, 19);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(148, 30);
            this.btnReadFile.TabIndex = 2;
            this.btnReadFile.Text = "Open File..";
            this.btnReadFile.UseVisualStyleBackColor = true;
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(312, 19);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(148, 30);
            this.btnLog.TabIndex = 3;
            this.btnLog.Text = "Check log..";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // chartTabControl
            // 
            this.chartTabControl.Controls.Add(this.tabChart);
            this.chartTabControl.Controls.Add(this.xAxisStatsPage);
            this.chartTabControl.Controls.Add(this.yAxisStatPage);
            this.chartTabControl.Controls.Add(this.zAxisStatsPage);
            this.chartTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTabControl.Location = new System.Drawing.Point(480, 3);
            this.chartTabControl.Name = "chartTabControl";
            this.chartTabControl.SelectedIndex = 0;
            this.chartTabControl.Size = new System.Drawing.Size(678, 608);
            this.chartTabControl.TabIndex = 4;
            // 
            // tabChart
            // 
            this.tabChart.Controls.Add(this.chartAxisData);
            this.tabChart.Location = new System.Drawing.Point(4, 22);
            this.tabChart.Name = "tabChart";
            this.tabChart.Padding = new System.Windows.Forms.Padding(3);
            this.tabChart.Size = new System.Drawing.Size(670, 582);
            this.tabChart.TabIndex = 0;
            this.tabChart.Text = "Chart";
            this.tabChart.UseVisualStyleBackColor = true;
            // 
            // chartAxisData
            // 
            chartArea6.Name = "ChartArea1";
            this.chartAxisData.ChartAreas.Add(chartArea6);
            this.chartAxisData.Dock = System.Windows.Forms.DockStyle.Fill;
            legend6.Name = "Legend1";
            this.chartAxisData.Legends.Add(legend6);
            this.chartAxisData.Location = new System.Drawing.Point(3, 3);
            this.chartAxisData.Name = "chartAxisData";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.Legend = "Legend1";
            series8.Name = "X Axis";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series9.Legend = "Legend1";
            series9.Name = "Y Axis";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series10.Legend = "Legend1";
            series10.Name = "Z Axis";
            this.chartAxisData.Series.Add(series8);
            this.chartAxisData.Series.Add(series9);
            this.chartAxisData.Series.Add(series10);
            this.chartAxisData.Size = new System.Drawing.Size(664, 576);
            this.chartAxisData.TabIndex = 0;
            this.chartAxisData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartAxisData_MouseMove);
            // 
            // xAxisStatsPage
            // 
            this.xAxisStatsPage.Controls.Add(this.chartXAxis);
            this.xAxisStatsPage.Controls.Add(this.statsXAxis);
            this.xAxisStatsPage.Location = new System.Drawing.Point(4, 22);
            this.xAxisStatsPage.Name = "xAxisStatsPage";
            this.xAxisStatsPage.Padding = new System.Windows.Forms.Padding(3);
            this.xAxisStatsPage.Size = new System.Drawing.Size(670, 582);
            this.xAxisStatsPage.TabIndex = 1;
            this.xAxisStatsPage.Text = "X Axis Stats";
            this.xAxisStatsPage.UseVisualStyleBackColor = true;
            // 
            // chartXAxis
            // 
            chartArea7.Name = "ChartArea1";
            this.chartXAxis.ChartAreas.Add(chartArea7);
            this.chartXAxis.Dock = System.Windows.Forms.DockStyle.Fill;
            legend7.Name = "Legend1";
            this.chartXAxis.Legends.Add(legend7);
            this.chartXAxis.Location = new System.Drawing.Point(3, 3);
            this.chartXAxis.Name = "chartXAxis";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series11.Legend = "Legend1";
            series11.MarkerBorderWidth = 2;
            series11.Name = "X Axis Values";
            series11.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series11.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartXAxis.Series.Add(series11);
            this.chartXAxis.Size = new System.Drawing.Size(664, 392);
            this.chartXAxis.TabIndex = 0;
            this.chartXAxis.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartAxisData_MouseMove);
            // 
            // statsXAxis
            // 
            this.statsXAxis.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statsXAxis.Location = new System.Drawing.Point(3, 395);
            this.statsXAxis.Name = "statsXAxis";
            this.statsXAxis.Size = new System.Drawing.Size(664, 184);
            this.statsXAxis.TabIndex = 1;
            // 
            // yAxisStatPage
            // 
            this.yAxisStatPage.Controls.Add(this.chartYAxis);
            this.yAxisStatPage.Controls.Add(this.statsYAxis);
            this.yAxisStatPage.Location = new System.Drawing.Point(4, 22);
            this.yAxisStatPage.Name = "yAxisStatPage";
            this.yAxisStatPage.Padding = new System.Windows.Forms.Padding(3);
            this.yAxisStatPage.Size = new System.Drawing.Size(670, 582);
            this.yAxisStatPage.TabIndex = 2;
            this.yAxisStatPage.Text = "Y Axis Stats";
            this.yAxisStatPage.UseVisualStyleBackColor = true;
            // 
            // statsYAxis
            // 
            this.statsYAxis.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statsYAxis.Location = new System.Drawing.Point(3, 412);
            this.statsYAxis.Name = "statsYAxis";
            this.statsYAxis.Size = new System.Drawing.Size(664, 167);
            this.statsYAxis.TabIndex = 2;
            // 
            // chartYAxis
            // 
            chartArea5.Name = "ChartArea1";
            this.chartYAxis.ChartAreas.Add(chartArea5);
            this.chartYAxis.Dock = System.Windows.Forms.DockStyle.Fill;
            legend5.Name = "Legend1";
            this.chartYAxis.Legends.Add(legend5);
            this.chartYAxis.Location = new System.Drawing.Point(3, 3);
            this.chartYAxis.Name = "chartYAxis";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Legend = "Legend1";
            series7.MarkerBorderWidth = 2;
            series7.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            series7.Name = "Y Axis Values";
            this.chartYAxis.Series.Add(series7);
            this.chartYAxis.Size = new System.Drawing.Size(664, 409);
            this.chartYAxis.TabIndex = 1;
            // 
            // zAxisStatsPage
            // 
            this.zAxisStatsPage.Controls.Add(this.chartZAxis);
            this.zAxisStatsPage.Controls.Add(this.statsZAxis);
            this.zAxisStatsPage.Location = new System.Drawing.Point(4, 22);
            this.zAxisStatsPage.Name = "zAxisStatsPage";
            this.zAxisStatsPage.Padding = new System.Windows.Forms.Padding(3);
            this.zAxisStatsPage.Size = new System.Drawing.Size(670, 582);
            this.zAxisStatsPage.TabIndex = 3;
            this.zAxisStatsPage.Text = "Z Axis Stats";
            this.zAxisStatsPage.UseVisualStyleBackColor = true;
            // 
            // statsZAxis
            // 
            this.statsZAxis.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statsZAxis.Location = new System.Drawing.Point(3, 395);
            this.statsZAxis.Name = "statsZAxis";
            this.statsZAxis.Size = new System.Drawing.Size(664, 184);
            this.statsZAxis.TabIndex = 2;
            // 
            // chartZAxis
            // 
            chartArea8.Name = "ChartArea1";
            this.chartZAxis.ChartAreas.Add(chartArea8);
            this.chartZAxis.Dock = System.Windows.Forms.DockStyle.Fill;
            legend8.Name = "Legend1";
            this.chartZAxis.Legends.Add(legend8);
            this.chartZAxis.Location = new System.Drawing.Point(3, 3);
            this.chartZAxis.Name = "chartZAxis";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series12.Legend = "Legend1";
            series12.Name = "Z Axis Values";
            this.chartZAxis.Series.Add(series12);
            this.chartZAxis.Size = new System.Drawing.Size(664, 392);
            this.chartZAxis.TabIndex = 1;
            // 
            // grpControls
            // 
            this.grpControls.Controls.Add(this.btnClear);
            this.grpControls.Controls.Add(this.btnReadFile);
            this.grpControls.Controls.Add(this.dgvData);
            this.grpControls.Controls.Add(this.btnLog);
            this.grpControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpControls.Location = new System.Drawing.Point(3, 3);
            this.grpControls.Name = "grpControls";
            this.grpControls.Size = new System.Drawing.Size(471, 608);
            this.grpControls.TabIndex = 5;
            this.grpControls.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(312, 450);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(148, 30);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear Everything";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 477F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grpControls, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartTabControl, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1161, 614);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // ResultStudioForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 614);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ResultStudioForm";
            this.Text = "Result Studio";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.chartTabControl.ResumeLayout(false);
            this.tabChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartAxisData)).EndInit();
            this.xAxisStatsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartXAxis)).EndInit();
            this.yAxisStatPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartYAxis)).EndInit();
            this.zAxisStatsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartZAxis)).EndInit();
            this.grpControls.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnReadFile;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.TabControl chartTabControl;
        private System.Windows.Forms.TabPage tabChart;
        private System.Windows.Forms.TabPage xAxisStatsPage;
        private System.Windows.Forms.TabPage yAxisStatPage;
        private System.Windows.Forms.TabPage zAxisStatsPage;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartXAxis;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAxisData;
        private System.Windows.Forms.GroupBox grpControls;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartYAxis;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartZAxis;
        private Views.StatsViewControl statsXAxis;
        private Views.StatsViewControl statsYAxis;
        private Views.StatsViewControl statsZAxis;
    }
}

