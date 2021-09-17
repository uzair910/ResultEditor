﻿namespace ResultStudio
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnReadFile = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.chartTabControl = new System.Windows.Forms.TabControl();
            this.tabChart = new System.Windows.Forms.TabPage();
            this.chartAxisData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.xAxisStatsPage = new System.Windows.Forms.TabPage();
            this.chartXAxis = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.yAxisStatPage = new System.Windows.Forms.TabPage();
            this.zAxisStatsPage = new System.Windows.Forms.TabPage();
            this.grpControls = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClear = new System.Windows.Forms.Button();
            this.chartYAxis = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartZAxis = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.chartTabControl.SuspendLayout();
            this.tabChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAxisData)).BeginInit();
            this.xAxisStatsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartXAxis)).BeginInit();
            this.yAxisStatPage.SuspendLayout();
            this.zAxisStatsPage.SuspendLayout();
            this.grpControls.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartYAxis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartZAxis)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 55);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(460, 388);
            this.dataGridView.TabIndex = 0;
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
            this.chartTabControl.Size = new System.Drawing.Size(547, 503);
            this.chartTabControl.TabIndex = 4;
            // 
            // tabChart
            // 
            this.tabChart.Controls.Add(this.chartAxisData);
            this.tabChart.Location = new System.Drawing.Point(4, 22);
            this.tabChart.Name = "tabChart";
            this.tabChart.Padding = new System.Windows.Forms.Padding(3);
            this.tabChart.Size = new System.Drawing.Size(539, 477);
            this.tabChart.TabIndex = 0;
            this.tabChart.Text = "Chart";
            this.tabChart.UseVisualStyleBackColor = true;
            // 
            // chartAxisData
            // 
            chartArea1.Name = "ChartArea1";
            this.chartAxisData.ChartAreas.Add(chartArea1);
            this.chartAxisData.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.chartAxisData.Size = new System.Drawing.Size(533, 471);
            this.chartAxisData.TabIndex = 0;
            this.chartAxisData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartAxisData_MouseMove);
            // 
            // xAxisStatsPage
            // 
            this.xAxisStatsPage.Controls.Add(this.chartXAxis);
            this.xAxisStatsPage.Location = new System.Drawing.Point(4, 22);
            this.xAxisStatsPage.Name = "xAxisStatsPage";
            this.xAxisStatsPage.Padding = new System.Windows.Forms.Padding(3);
            this.xAxisStatsPage.Size = new System.Drawing.Size(539, 477);
            this.xAxisStatsPage.TabIndex = 1;
            this.xAxisStatsPage.Text = "X Axis Stats";
            this.xAxisStatsPage.UseVisualStyleBackColor = true;
            // 
            // chartXAxis
            // 
            chartArea2.Name = "ChartArea1";
            this.chartXAxis.ChartAreas.Add(chartArea2);
            this.chartXAxis.Dock = System.Windows.Forms.DockStyle.Top;
            legend2.Name = "Legend1";
            this.chartXAxis.Legends.Add(legend2);
            this.chartXAxis.Location = new System.Drawing.Point(3, 3);
            this.chartXAxis.Name = "chartXAxis";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Legend = "Legend1";
            series4.Name = "X Axis Values";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartXAxis.Series.Add(series4);
            this.chartXAxis.Size = new System.Drawing.Size(533, 386);
            this.chartXAxis.TabIndex = 0;
            // 
            // yAxisStatPage
            // 
            this.yAxisStatPage.Controls.Add(this.chartYAxis);
            this.yAxisStatPage.Location = new System.Drawing.Point(4, 22);
            this.yAxisStatPage.Name = "yAxisStatPage";
            this.yAxisStatPage.Padding = new System.Windows.Forms.Padding(3);
            this.yAxisStatPage.Size = new System.Drawing.Size(539, 477);
            this.yAxisStatPage.TabIndex = 2;
            this.yAxisStatPage.Text = "Y Axis Stats";
            this.yAxisStatPage.UseVisualStyleBackColor = true;
            // 
            // zAxisStatsPage
            // 
            this.zAxisStatsPage.Controls.Add(this.chartZAxis);
            this.zAxisStatsPage.Location = new System.Drawing.Point(4, 22);
            this.zAxisStatsPage.Name = "zAxisStatsPage";
            this.zAxisStatsPage.Padding = new System.Windows.Forms.Padding(3);
            this.zAxisStatsPage.Size = new System.Drawing.Size(539, 477);
            this.zAxisStatsPage.TabIndex = 3;
            this.zAxisStatsPage.Text = "Z Axis Stats";
            this.zAxisStatsPage.UseVisualStyleBackColor = true;
            // 
            // grpControls
            // 
            this.grpControls.Controls.Add(this.btnClear);
            this.grpControls.Controls.Add(this.btnReadFile);
            this.grpControls.Controls.Add(this.dataGridView);
            this.grpControls.Controls.Add(this.btnLog);
            this.grpControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpControls.Location = new System.Drawing.Point(3, 3);
            this.grpControls.Name = "grpControls";
            this.grpControls.Size = new System.Drawing.Size(471, 503);
            this.grpControls.TabIndex = 5;
            this.grpControls.TabStop = false;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1030, 509);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(312, 450);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(148, 30);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear Charts";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chartYAxis
            // 
            chartArea3.Name = "ChartArea1";
            this.chartYAxis.ChartAreas.Add(chartArea3);
            this.chartYAxis.Dock = System.Windows.Forms.DockStyle.Top;
            legend3.Name = "Legend1";
            this.chartYAxis.Legends.Add(legend3);
            this.chartYAxis.Location = new System.Drawing.Point(3, 3);
            this.chartYAxis.Name = "chartYAxis";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chartYAxis.Series.Add(series5);
            this.chartYAxis.Size = new System.Drawing.Size(533, 386);
            this.chartYAxis.TabIndex = 1;
            // 
            // chartZAxis
            // 
            chartArea4.Name = "ChartArea1";
            this.chartZAxis.ChartAreas.Add(chartArea4);
            this.chartZAxis.Dock = System.Windows.Forms.DockStyle.Top;
            legend4.Name = "Legend1";
            this.chartZAxis.Legends.Add(legend4);
            this.chartZAxis.Location = new System.Drawing.Point(3, 3);
            this.chartZAxis.Name = "chartZAxis";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Legend = "Legend1";
            series6.Name = "Z Axis Values";
            this.chartZAxis.Series.Add(series6);
            this.chartZAxis.Size = new System.Drawing.Size(533, 386);
            this.chartZAxis.TabIndex = 1;
            // 
            // ResultStudioForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 509);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ResultStudioForm";
            this.Text = "Result Studio";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.chartTabControl.ResumeLayout(false);
            this.tabChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartAxisData)).EndInit();
            this.xAxisStatsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartXAxis)).EndInit();
            this.yAxisStatPage.ResumeLayout(false);
            this.zAxisStatsPage.ResumeLayout(false);
            this.grpControls.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartYAxis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartZAxis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
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
    }
}

