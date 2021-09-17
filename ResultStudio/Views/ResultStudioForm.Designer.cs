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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.dgcPartID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAxisX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAxisY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcAxisZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnReadFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcPartID,
            this.dgcAxisX,
            this.dgcAxisY,
            this.dgcAxisZ});
            this.dataGridView.Location = new System.Drawing.Point(12, 126);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(461, 464);
            this.dataGridView.TabIndex = 0;
            // 
            // dgcPartID
            // 
            this.dgcPartID.HeaderText = global::ResultStudio.Properties.Resources.sPartID;
            this.dgcPartID.Name = "dgcPartID";
            this.dgcPartID.ReadOnly = true;
            // 
            // dgcAxisX
            // 
            this.dgcAxisX.HeaderText = global::ResultStudio.Properties.Resources.sAxisX;
            this.dgcAxisX.Name = "dgcAxisX";
            this.dgcAxisX.ReadOnly = true;
            // 
            // dgcAxisY
            // 
            this.dgcAxisY.HeaderText = global::ResultStudio.Properties.Resources.sAxisY;
            this.dgcAxisY.Name = "dgcAxisY";
            this.dgcAxisY.ReadOnly = true;
            // 
            // dgcAxisZ
            // 
            this.dgcAxisZ.HeaderText = global::ResultStudio.Properties.Resources.sAxisZ;
            this.dgcAxisZ.Name = "dgcAxisZ";
            this.dgcAxisZ.ReadOnly = true;
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Location = new System.Drawing.Point(479, 13);
            this.chart.Name = "chart";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series";
            this.chart.Series.Add(series1);
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
            // ResultStudioForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 621);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcPartID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAxisX;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAxisY;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcAxisZ;
    }
}

