using ResultStudio.Views;

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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnReadFile = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.chartTabControl = new System.Windows.Forms.TabControl();
            this.tabChart = new System.Windows.Forms.TabPage();
            this.lblComboText = new System.Windows.Forms.Label();
            this.cmbSeriesCol = new System.Windows.Forms.ComboBox();
            this.chartAxisData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.xAxisStatsPage = new System.Windows.Forms.TabPage();
            this.chartXAxis = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.statsXAxis = new StatsViewControl();
            this.yAxisStatPage = new System.Windows.Forms.TabPage();
            this.chartYAxis = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.statsYAxis = new StatsViewControl();
            this.zAxisStatsPage = new System.Windows.Forms.TabPage();
            this.chartZAxis = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.statsZAxis = new StatsViewControl();
            this.grpControls = new System.Windows.Forms.GroupBox();
            this.lblStatusBar = new System.Windows.Forms.Label();
            this.lblTolerance = new System.Windows.Forms.Label();
            this.txtTolerace = new System.Windows.Forms.TextBox();
            this.btnTolerance = new System.Windows.Forms.Button();
            this.txtTrendValue = new System.Windows.Forms.RichTextBox();
            this.lblTrends = new System.Windows.Forms.Label();
            this.lblPartOutlier = new System.Windows.Forms.Label();
            this.listOutOfBoundParts = new System.Windows.Forms.RichTextBox();
            this.lblOutliers = new System.Windows.Forms.Label();
            this.lblOutOfBoundMessage = new System.Windows.Forms.Label();
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
            this.btnReadFile.TabIndex = 1;
            this.btnReadFile.Text = "Open File..";
            this.btnReadFile.UseVisualStyleBackColor = true;
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(312, 19);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(148, 30);
            this.btnLog.TabIndex = 2;
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
            this.chartTabControl.Location = new System.Drawing.Point(522, 3);
            this.chartTabControl.Name = "chartTabControl";
            this.chartTabControl.SelectedIndex = 0;
            this.chartTabControl.Size = new System.Drawing.Size(724, 769);
            this.chartTabControl.TabIndex = 10;
            // 
            // tabChart
            // 
            this.tabChart.Controls.Add(this.lblComboText);
            this.tabChart.Controls.Add(this.cmbSeriesCol);
            this.tabChart.Controls.Add(this.chartAxisData);
            this.tabChart.Location = new System.Drawing.Point(4, 22);
            this.tabChart.Name = "tabChart";
            this.tabChart.Padding = new System.Windows.Forms.Padding(3);
            this.tabChart.Size = new System.Drawing.Size(716, 743);
            this.tabChart.TabIndex = 0;
            this.tabChart.Text = "Chart";
            this.tabChart.UseVisualStyleBackColor = true;
            // 
            // lblComboText
            // 
            this.lblComboText.AutoSize = true;
            this.lblComboText.Location = new System.Drawing.Point(69, 538);
            this.lblComboText.Name = "lblComboText";
            this.lblComboText.Size = new System.Drawing.Size(100, 13);
            this.lblComboText.TabIndex = 2;
            this.lblComboText.Text = "Change graph type:";
            // 
            // cmbSeriesCol
            // 
            this.cmbSeriesCol.FormattingEnabled = true;
            this.cmbSeriesCol.Location = new System.Drawing.Point(175, 535);
            this.cmbSeriesCol.Name = "cmbSeriesCol";
            this.cmbSeriesCol.Size = new System.Drawing.Size(190, 21);
            this.cmbSeriesCol.TabIndex = 1;
            this.cmbSeriesCol.SelectedIndexChanged += new System.EventHandler(this.cmbSeriesCol_SelectedIndexChanged);
            // 
            // chartAxisData
            // 
            chartArea1.Name = "ChartArea1";
            this.chartAxisData.ChartAreas.Add(chartArea1);
            this.chartAxisData.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.chartAxisData.Legends.Add(legend1);
            this.chartAxisData.Location = new System.Drawing.Point(3, 3);
            this.chartAxisData.Name = "chartAxisData";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "X Axis";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Y Axis";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "Z Axis";
            this.chartAxisData.Series.Add(series1);
            this.chartAxisData.Series.Add(series2);
            this.chartAxisData.Series.Add(series3);
            this.chartAxisData.Size = new System.Drawing.Size(710, 546);
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
            this.xAxisStatsPage.Size = new System.Drawing.Size(716, 743);
            this.xAxisStatsPage.TabIndex = 1;
            this.xAxisStatsPage.Text = "X Axis Stats";
            this.xAxisStatsPage.UseVisualStyleBackColor = true;
            // 
            // chartXAxis
            // 
            chartArea2.Name = "ChartArea1";
            this.chartXAxis.ChartAreas.Add(chartArea2);
            this.chartXAxis.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartXAxis.Legends.Add(legend2);
            this.chartXAxis.Location = new System.Drawing.Point(3, 3);
            this.chartXAxis.Name = "chartXAxis";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Legend = "Legend1";
            series4.MarkerBorderWidth = 2;
            series4.Name = "X Axis Values";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartXAxis.Series.Add(series4);
            this.chartXAxis.Size = new System.Drawing.Size(710, 553);
            this.chartXAxis.TabIndex = 0;
            this.chartXAxis.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartAxisData_MouseMove);
            // 
            // statsXAxis
            // 
            this.statsXAxis.AxisStatistics = null;
            this.statsXAxis.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statsXAxis.Location = new System.Drawing.Point(3, 556);
            this.statsXAxis.Name = "statsXAxis";
            this.statsXAxis.Size = new System.Drawing.Size(710, 184);
            this.statsXAxis.TabIndex = 1;
            // 
            // yAxisStatPage
            // 
            this.yAxisStatPage.Controls.Add(this.chartYAxis);
            this.yAxisStatPage.Controls.Add(this.statsYAxis);
            this.yAxisStatPage.Location = new System.Drawing.Point(4, 22);
            this.yAxisStatPage.Name = "yAxisStatPage";
            this.yAxisStatPage.Padding = new System.Windows.Forms.Padding(3);
            this.yAxisStatPage.Size = new System.Drawing.Size(716, 743);
            this.yAxisStatPage.TabIndex = 2;
            this.yAxisStatPage.Text = "Y Axis Stats";
            this.yAxisStatPage.UseVisualStyleBackColor = true;
            // 
            // chartYAxis
            // 
            chartArea3.Name = "ChartArea1";
            this.chartYAxis.ChartAreas.Add(chartArea3);
            this.chartYAxis.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chartYAxis.Legends.Add(legend3);
            this.chartYAxis.Location = new System.Drawing.Point(3, 3);
            this.chartYAxis.Name = "chartYAxis";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series5.Legend = "Legend1";
            series5.MarkerBorderWidth = 2;
            series5.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            series5.Name = "Y Axis Values";
            this.chartYAxis.Series.Add(series5);
            this.chartYAxis.Size = new System.Drawing.Size(710, 553);
            this.chartYAxis.TabIndex = 1;
            // 
            // statsYAxis
            // 
            this.statsYAxis.AxisStatistics = null;
            this.statsYAxis.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statsYAxis.Location = new System.Drawing.Point(3, 556);
            this.statsYAxis.Name = "statsYAxis";
            this.statsYAxis.Size = new System.Drawing.Size(710, 184);
            this.statsYAxis.TabIndex = 2;
            // 
            // zAxisStatsPage
            // 
            this.zAxisStatsPage.Controls.Add(this.chartZAxis);
            this.zAxisStatsPage.Controls.Add(this.statsZAxis);
            this.zAxisStatsPage.Location = new System.Drawing.Point(4, 22);
            this.zAxisStatsPage.Name = "zAxisStatsPage";
            this.zAxisStatsPage.Padding = new System.Windows.Forms.Padding(3);
            this.zAxisStatsPage.Size = new System.Drawing.Size(716, 743);
            this.zAxisStatsPage.TabIndex = 3;
            this.zAxisStatsPage.Text = "Z Axis Stats";
            this.zAxisStatsPage.UseVisualStyleBackColor = true;
            // 
            // chartZAxis
            // 
            chartArea4.Name = "ChartArea1";
            this.chartZAxis.ChartAreas.Add(chartArea4);
            this.chartZAxis.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.chartZAxis.Legends.Add(legend4);
            this.chartZAxis.Location = new System.Drawing.Point(3, 3);
            this.chartZAxis.Name = "chartZAxis";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Legend = "Legend1";
            series6.Name = "Z Axis Values";
            this.chartZAxis.Series.Add(series6);
            this.chartZAxis.Size = new System.Drawing.Size(710, 553);
            this.chartZAxis.TabIndex = 1;
            // 
            // statsZAxis
            // 
            this.statsZAxis.AxisStatistics = null;
            this.statsZAxis.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statsZAxis.Location = new System.Drawing.Point(3, 556);
            this.statsZAxis.Name = "statsZAxis";
            this.statsZAxis.Size = new System.Drawing.Size(710, 184);
            this.statsZAxis.TabIndex = 2;
            // 
            // grpControls
            // 
            this.grpControls.Controls.Add(this.lblStatusBar);
            this.grpControls.Controls.Add(this.lblTolerance);
            this.grpControls.Controls.Add(this.txtTolerace);
            this.grpControls.Controls.Add(this.btnTolerance);
            this.grpControls.Controls.Add(this.txtTrendValue);
            this.grpControls.Controls.Add(this.lblTrends);
            this.grpControls.Controls.Add(this.lblPartOutlier);
            this.grpControls.Controls.Add(this.listOutOfBoundParts);
            this.grpControls.Controls.Add(this.lblOutliers);
            this.grpControls.Controls.Add(this.lblOutOfBoundMessage);
            this.grpControls.Controls.Add(this.btnClear);
            this.grpControls.Controls.Add(this.btnReadFile);
            this.grpControls.Controls.Add(this.dgvData);
            this.grpControls.Controls.Add(this.btnLog);
            this.grpControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpControls.Location = new System.Drawing.Point(3, 3);
            this.grpControls.Name = "grpControls";
            this.grpControls.Size = new System.Drawing.Size(513, 769);
            this.grpControls.TabIndex = 5;
            this.grpControls.TabStop = false;
            // 
            // lblStatusBar
            // 
            this.lblStatusBar.AutoSize = true;
            this.lblStatusBar.Location = new System.Drawing.Point(-3, 743);
            this.lblStatusBar.Name = "lblStatusBar";
            this.lblStatusBar.Size = new System.Drawing.Size(0, 13);
            this.lblStatusBar.TabIndex = 6;
            // 
            // lblTolerance
            // 
            this.lblTolerance.AutoSize = true;
            this.lblTolerance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTolerance.Location = new System.Drawing.Point(244, 512);
            this.lblTolerance.Name = "lblTolerance";
            this.lblTolerance.Size = new System.Drawing.Size(93, 13);
            this.lblTolerance.TabIndex = 26;
            this.lblTolerance.Text = "Tolerance (%): ";
            this.lblTolerance.Visible = false;
            // 
            // txtTolerace
            // 
            this.txtTolerace.Location = new System.Drawing.Point(343, 509);
            this.txtTolerace.MaxLength = 11;
            this.txtTolerace.Name = "txtTolerace";
            this.txtTolerace.Size = new System.Drawing.Size(121, 20);
            this.txtTolerace.TabIndex = 3;
            this.txtTolerace.Visible = false;
            this.txtTolerace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTolerace_KeyPress);
            // 
            // btnTolerance
            // 
            this.btnTolerance.Location = new System.Drawing.Point(343, 534);
            this.btnTolerance.Name = "btnTolerance";
            this.btnTolerance.Size = new System.Drawing.Size(121, 39);
            this.btnTolerance.TabIndex = 4;
            this.btnTolerance.Text = "Calculate Tolerance for each axis";
            this.btnTolerance.UseVisualStyleBackColor = true;
            this.btnTolerance.Visible = false;
            this.btnTolerance.Click += new System.EventHandler(this.btnTolerance_Click);
            // 
            // txtTrendValue
            // 
            this.txtTrendValue.Location = new System.Drawing.Point(0, 507);
            this.txtTrendValue.Name = "txtTrendValue";
            this.txtTrendValue.ReadOnly = true;
            this.txtTrendValue.Size = new System.Drawing.Size(238, 73);
            this.txtTrendValue.TabIndex = 23;
            this.txtTrendValue.Text = "";
            // 
            // lblTrends
            // 
            this.lblTrends.AutoSize = true;
            this.lblTrends.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrends.Location = new System.Drawing.Point(-3, 491);
            this.lblTrends.Name = "lblTrends";
            this.lblTrends.Size = new System.Drawing.Size(59, 13);
            this.lblTrends.TabIndex = 22;
            this.lblTrends.Text = "lblTrends";
            // 
            // lblPartOutlier
            // 
            this.lblPartOutlier.AutoSize = true;
            this.lblPartOutlier.BackColor = System.Drawing.SystemColors.Control;
            this.lblPartOutlier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartOutlier.Location = new System.Drawing.Point(-3, 469);
            this.lblPartOutlier.Name = "lblPartOutlier";
            this.lblPartOutlier.Size = new System.Drawing.Size(71, 13);
            this.lblPartOutlier.TabIndex = 21;
            this.lblPartOutlier.Text = "lblPartOutliers";
            this.lblPartOutlier.Visible = false;
            // 
            // listOutOfBoundParts
            // 
            this.listOutOfBoundParts.Location = new System.Drawing.Point(0, 607);
            this.listOutOfBoundParts.Name = "listOutOfBoundParts";
            this.listOutOfBoundParts.ReadOnly = true;
            this.listOutOfBoundParts.Size = new System.Drawing.Size(238, 97);
            this.listOutOfBoundParts.TabIndex = 20;
            this.listOutOfBoundParts.Text = "";
            // 
            // lblOutliers
            // 
            this.lblOutliers.AutoSize = true;
            this.lblOutliers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutliers.Location = new System.Drawing.Point(-3, 591);
            this.lblOutliers.Name = "lblOutliers";
            this.lblOutliers.Size = new System.Drawing.Size(63, 13);
            this.lblOutliers.TabIndex = 7;
            this.lblOutliers.Text = "lblOutliers";
            // 
            // lblOutOfBoundMessage
            // 
            this.lblOutOfBoundMessage.AutoSize = true;
            this.lblOutOfBoundMessage.BackColor = System.Drawing.SystemColors.Control;
            this.lblOutOfBoundMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutOfBoundMessage.Location = new System.Drawing.Point(-3, 451);
            this.lblOutOfBoundMessage.Name = "lblOutOfBoundMessage";
            this.lblOutOfBoundMessage.Size = new System.Drawing.Size(76, 13);
            this.lblOutOfBoundMessage.TabIndex = 5;
            this.lblOutOfBoundMessage.Text = "lblOutOfBound";
            this.lblOutOfBoundMessage.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(0, 710);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(148, 30);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear Everything";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 519F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grpControls, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartTabControl, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1249, 775);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // ResultStudioForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 775);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ResultStudioForm";
            this.Text = "Result Studio";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.chartTabControl.ResumeLayout(false);
            this.tabChart.ResumeLayout(false);
            this.tabChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAxisData)).EndInit();
            this.xAxisStatsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartXAxis)).EndInit();
            this.yAxisStatPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartYAxis)).EndInit();
            this.zAxisStatsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartZAxis)).EndInit();
            this.grpControls.ResumeLayout(false);
            this.grpControls.PerformLayout();
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
        private StatsViewControl statsXAxis;
        private StatsViewControl statsYAxis;
        private StatsViewControl statsZAxis;
        private System.Windows.Forms.ComboBox cmbSeriesCol;
        private System.Windows.Forms.Label lblComboText;
        private System.Windows.Forms.Label lblOutOfBoundMessage;
        private System.Windows.Forms.Label lblStatusBar;
        private System.Windows.Forms.Label lblOutliers;
        private System.Windows.Forms.RichTextBox listOutOfBoundParts;
        private System.Windows.Forms.Label lblPartOutlier;
        private System.Windows.Forms.Label lblTrends;
        private System.Windows.Forms.RichTextBox txtTrendValue;
        private System.Windows.Forms.Label lblTolerance;
        private System.Windows.Forms.TextBox txtTolerace;
        private System.Windows.Forms.Button btnTolerance;
    }
}

