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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnReadFile = new System.Windows.Forms.Button();
            this.dgcMeasurementID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAxis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcMeasurementID,
            this.dgcAxis,
            this.dgcValue});
            this.dataGridView.Location = new System.Drawing.Point(12, 126);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(461, 464);
            this.dataGridView.TabIndex = 0;
            // 
            // chart
            // 
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            this.chart.Location = new System.Drawing.Point(479, 13);
            this.chart.Name = "chart";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "Series";
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(517, 577);
            this.chart.TabIndex = 1;
            // 
            // btnReadFile
            // 
            this.btnReadFile.Location = new System.Drawing.Point(12, 13);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(148, 23);
            this.btnReadFile.TabIndex = 2;
            this.btnReadFile.Text = "Open File..";
            this.btnReadFile.UseVisualStyleBackColor = true;
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // dgcMeasurementID
            // 
            this.dgcMeasurementID.HeaderText = Properties.Resources.sMeasurementText;
            this.dgcMeasurementID.Name = "dgcMeasurementID";
            this.dgcMeasurementID.ReadOnly = true;
            // 
            // dgcAxis
            // 
            this.dgcAxis.HeaderText = Properties.Resources.sAxisText;
            this.dgcAxis.Name = "dgcAxis";
            this.dgcAxis.ReadOnly = true;
            // 
            // dgcValue
            // 
            this.dgcValue.HeaderText = Properties.Resources.sValueText;
            this.dgcValue.Name = "dgcValue";
            this.dgcValue.ReadOnly = true;
            // 
            // ResultStudioForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 602);
            this.Controls.Add(this.btnReadFile);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.dataGridView);
            this.Name = "ResultStudioForm";
            this.Text = "Result Studio";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Button btnReadFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcMeasurementID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAxis;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcValue;
    }
}

