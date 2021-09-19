
namespace ResultStudio.Views
{
    partial class StatsViewControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpStats = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMinimum = new System.Windows.Forms.Label();
            this.lblMaximum = new System.Windows.Forms.Label();
            this.lblAverage = new System.Windows.Forms.Label();
            this.lblVariationText = new System.Windows.Forms.Label();
            this.lblVariationValue = new System.Windows.Forms.Label();
            this.lblTolerance = new System.Windows.Forms.Label();
            this.txtTolerace = new System.Windows.Forms.TextBox();
            this.btnTolerance = new System.Windows.Forms.Button();
            this.lblToleranceExplaination = new System.Windows.Forms.Label();
            this.lblValToleranceUpperLimit = new System.Windows.Forms.Label();
            this.lblToleranceUpperLimit = new System.Windows.Forms.Label();
            this.lblToleranceLowerLimit = new System.Windows.Forms.Label();
            this.lblValToleranceLowerLimit = new System.Windows.Forms.Label();
            this.lblValMin = new System.Windows.Forms.Label();
            this.lblValMax = new System.Windows.Forms.Label();
            this.lblValMean = new System.Windows.Forms.Label();
            this.grpStats.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpStats
            // 
            this.grpStats.Controls.Add(this.tableLayoutPanel1);
            this.grpStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStats.Location = new System.Drawing.Point(0, 0);
            this.grpStats.Name = "grpStats";
            this.grpStats.Size = new System.Drawing.Size(673, 200);
            this.grpStats.TabIndex = 0;
            this.grpStats.TabStop = false;
            this.grpStats.Text = "Stats";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.34645F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.57791F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.lblValMean, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblValMax, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMinimum, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMaximum, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAverage, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblVariationText, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblVariationValue, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTolerance, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTolerace, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnTolerance, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblToleranceExplaination, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblToleranceUpperLimit, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblToleranceLowerLimit, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblValToleranceLowerLimit, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblValToleranceUpperLimit, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblValMin, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(661, 181);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblMinimum
            // 
            this.lblMinimum.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblMinimum.AutoSize = true;
            this.lblMinimum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinimum.Location = new System.Drawing.Point(9, 7);
            this.lblMinimum.Name = "lblMinimum";
            this.lblMinimum.Size = new System.Drawing.Size(63, 13);
            this.lblMinimum.TabIndex = 3;
            this.lblMinimum.Text = "Minimum: ";
            // 
            // lblMaximum
            // 
            this.lblMaximum.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblMaximum.AutoSize = true;
            this.lblMaximum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaximum.Location = new System.Drawing.Point(6, 35);
            this.lblMaximum.Name = "lblMaximum";
            this.lblMaximum.Size = new System.Drawing.Size(66, 13);
            this.lblMaximum.TabIndex = 4;
            this.lblMaximum.Text = "Maximum: ";
            // 
            // lblAverage
            // 
            this.lblAverage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAverage.AutoSize = true;
            this.lblAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverage.Location = new System.Drawing.Point(26, 63);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(46, 13);
            this.lblAverage.TabIndex = 5;
            this.lblAverage.Text = "Mean: ";
            // 
            // lblVariationText
            // 
            this.lblVariationText.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblVariationText.AutoSize = true;
            this.lblVariationText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVariationText.Location = new System.Drawing.Point(431, 7);
            this.lblVariationText.Name = "lblVariationText";
            this.lblVariationText.Size = new System.Drawing.Size(61, 13);
            this.lblVariationText.TabIndex = 6;
            this.lblVariationText.Text = "Variation:";
            // 
            // lblVariationValue
            // 
            this.lblVariationValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVariationValue.AutoSize = true;
            this.lblVariationValue.Location = new System.Drawing.Point(498, 7);
            this.lblVariationValue.Name = "lblVariationValue";
            this.lblVariationValue.Size = new System.Drawing.Size(22, 13);
            this.lblVariationValue.TabIndex = 7;
            this.lblVariationValue.Text = "0,0";
            // 
            // lblTolerance
            // 
            this.lblTolerance.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTolerance.AutoSize = true;
            this.lblTolerance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTolerance.Location = new System.Drawing.Point(399, 35);
            this.lblTolerance.Name = "lblTolerance";
            this.lblTolerance.Size = new System.Drawing.Size(93, 13);
            this.lblTolerance.TabIndex = 8;
            this.lblTolerance.Text = "Tolerance (%): ";
            this.lblTolerance.MouseEnter += new System.EventHandler(this.ToleranceControls_MouseEnter);
            this.lblTolerance.MouseLeave += new System.EventHandler(this.ToleranceControls_MouseLeave);
            // 
            // txtTolerace
            // 
            this.txtTolerace.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTolerace.Location = new System.Drawing.Point(498, 32);
            this.txtTolerace.MaxLength = 11;
            this.txtTolerace.Name = "txtTolerace";
            this.txtTolerace.Size = new System.Drawing.Size(130, 20);
            this.txtTolerace.TabIndex = 1;
            this.txtTolerace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.txtTolerace.MouseEnter += new System.EventHandler(this.ToleranceControls_MouseEnter);
            this.txtTolerace.MouseLeave += new System.EventHandler(this.ToleranceControls_MouseLeave);
            // 
            // btnTolerance
            // 
            this.btnTolerance.Location = new System.Drawing.Point(498, 59);
            this.btnTolerance.Name = "btnTolerance";
            this.btnTolerance.Size = new System.Drawing.Size(130, 21);
            this.btnTolerance.TabIndex = 2;
            this.btnTolerance.Text = "Visualize Tolerance";
            this.btnTolerance.UseVisualStyleBackColor = true;
            this.btnTolerance.Click += new System.EventHandler(this.btnTolerance_Click);
            // 
            // lblToleranceExplaination
            // 
            this.lblToleranceExplaination.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblToleranceExplaination.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblToleranceExplaination, 4);
            this.lblToleranceExplaination.Location = new System.Drawing.Point(3, 154);
            this.lblToleranceExplaination.Name = "lblToleranceExplaination";
            this.tableLayoutPanel1.SetRowSpan(this.lblToleranceExplaination, 2);
            this.lblToleranceExplaination.Size = new System.Drawing.Size(0, 13);
            this.lblToleranceExplaination.TabIndex = 10;
            // 
            // lblValToleranceUpperLimit
            // 
            this.lblValToleranceUpperLimit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValToleranceUpperLimit.AutoSize = true;
            this.lblValToleranceUpperLimit.Location = new System.Drawing.Point(498, 91);
            this.lblValToleranceUpperLimit.Name = "lblValToleranceUpperLimit";
            this.lblValToleranceUpperLimit.Size = new System.Drawing.Size(82, 13);
            this.lblValToleranceUpperLimit.TabIndex = 13;
            this.lblValToleranceUpperLimit.Text = "Not yet defined.";
            // 
            // lblToleranceUpperLimit
            // 
            this.lblToleranceUpperLimit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblToleranceUpperLimit.AutoSize = true;
            this.lblToleranceUpperLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToleranceUpperLimit.Location = new System.Drawing.Point(356, 91);
            this.lblToleranceUpperLimit.Name = "lblToleranceUpperLimit";
            this.lblToleranceUpperLimit.Size = new System.Drawing.Size(136, 13);
            this.lblToleranceUpperLimit.TabIndex = 11;
            this.lblToleranceUpperLimit.Text = "Tolerance Upper Limit:";
            // 
            // lblToleranceLowerLimit
            // 
            this.lblToleranceLowerLimit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblToleranceLowerLimit.AutoSize = true;
            this.lblToleranceLowerLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToleranceLowerLimit.Location = new System.Drawing.Point(360, 119);
            this.lblToleranceLowerLimit.Name = "lblToleranceLowerLimit";
            this.lblToleranceLowerLimit.Size = new System.Drawing.Size(132, 13);
            this.lblToleranceLowerLimit.TabIndex = 12;
            this.lblToleranceLowerLimit.Text = "Tolerance lower Limit:";
            // 
            // lblValToleranceLowerLimit
            // 
            this.lblValToleranceLowerLimit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValToleranceLowerLimit.AutoSize = true;
            this.lblValToleranceLowerLimit.Location = new System.Drawing.Point(498, 119);
            this.lblValToleranceLowerLimit.Name = "lblValToleranceLowerLimit";
            this.lblValToleranceLowerLimit.Size = new System.Drawing.Size(82, 13);
            this.lblValToleranceLowerLimit.TabIndex = 14;
            this.lblValToleranceLowerLimit.Text = "Not yet defined.";
            // 
            // lblValMin
            // 
            this.lblValMin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValMin.AutoSize = true;
            this.lblValMin.Location = new System.Drawing.Point(78, 7);
            this.lblValMin.Name = "lblValMin";
            this.lblValMin.Size = new System.Drawing.Size(0, 13);
            this.lblValMin.TabIndex = 15;
            // 
            // lblValMax
            // 
            this.lblValMax.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValMax.AutoSize = true;
            this.lblValMax.Location = new System.Drawing.Point(78, 35);
            this.lblValMax.Name = "lblValMax";
            this.lblValMax.Size = new System.Drawing.Size(0, 13);
            this.lblValMax.TabIndex = 16;
            // 
            // lblValMean
            // 
            this.lblValMean.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValMean.AutoSize = true;
            this.lblValMean.Location = new System.Drawing.Point(78, 63);
            this.lblValMean.Name = "lblValMean";
            this.lblValMean.Size = new System.Drawing.Size(0, 13);
            this.lblValMean.TabIndex = 17;
            // 
            // StatsViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpStats);
            this.Name = "StatsViewControl";
            this.Size = new System.Drawing.Size(673, 200);
            this.grpStats.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpStats;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblMinimum;
        private System.Windows.Forms.Label lblMaximum;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.Label lblVariationText;
        private System.Windows.Forms.Label lblVariationValue;
        private System.Windows.Forms.Label lblTolerance;
        private System.Windows.Forms.TextBox txtTolerace;
        private System.Windows.Forms.Button btnTolerance;
        private System.Windows.Forms.Label lblToleranceExplaination;
        private System.Windows.Forms.Label lblToleranceUpperLimit;
        private System.Windows.Forms.Label lblToleranceLowerLimit;
        private System.Windows.Forms.Label lblValToleranceUpperLimit;
        private System.Windows.Forms.Label lblValToleranceLowerLimit;
        private System.Windows.Forms.Label lblValMean;
        private System.Windows.Forms.Label lblValMax;
        private System.Windows.Forms.Label lblValMin;
    }
}
