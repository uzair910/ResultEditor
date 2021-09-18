
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
            this.lblAverage = new System.Windows.Forms.Label();
            this.lblMaximum = new System.Windows.Forms.Label();
            this.lblMinimum = new System.Windows.Forms.Label();
            this.lblVariationText = new System.Windows.Forms.Label();
            this.lblVariationValue = new System.Windows.Forms.Label();
            this.lblTolerance = new System.Windows.Forms.Label();
            this.txtTolerace = new System.Windows.Forms.TextBox();
            this.btnTolerance = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.27231F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.03177F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.58245F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.lblMinimum, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMaximum, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAverage, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblVariationText, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblVariationValue, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTolerance, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTolerace, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnTolerance, 3, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.18605F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.34884F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(661, 172);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblAverage
            // 
            this.lblAverage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAverage.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblAverage, 2);
            this.lblAverage.Location = new System.Drawing.Point(3, 78);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(34, 13);
            this.lblAverage.TabIndex = 5;
            this.lblAverage.Text = "Mean";
            // 
            // lblMaximum
            // 
            this.lblMaximum.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMaximum.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblMaximum, 2);
            this.lblMaximum.Location = new System.Drawing.Point(3, 44);
            this.lblMaximum.Name = "lblMaximum";
            this.lblMaximum.Size = new System.Drawing.Size(51, 13);
            this.lblMaximum.TabIndex = 4;
            this.lblMaximum.Text = "Maximum";
            // 
            // lblMinimum
            // 
            this.lblMinimum.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMinimum.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblMinimum, 2);
            this.lblMinimum.Location = new System.Drawing.Point(3, 10);
            this.lblMinimum.Name = "lblMinimum";
            this.lblMinimum.Size = new System.Drawing.Size(48, 13);
            this.lblMinimum.TabIndex = 3;
            this.lblMinimum.Text = "Minimum";
            // 
            // lblVariationText
            // 
            this.lblVariationText.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblVariationText.AutoSize = true;
            this.lblVariationText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVariationText.Location = new System.Drawing.Point(431, 10);
            this.lblVariationText.Name = "lblVariationText";
            this.lblVariationText.Size = new System.Drawing.Size(61, 13);
            this.lblVariationText.TabIndex = 6;
            this.lblVariationText.Text = "Variation:";
            // 
            // lblVariationValue
            // 
            this.lblVariationValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVariationValue.AutoSize = true;
            this.lblVariationValue.Location = new System.Drawing.Point(498, 10);
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
            this.lblTolerance.Location = new System.Drawing.Point(420, 44);
            this.lblTolerance.Name = "lblTolerance";
            this.lblTolerance.Size = new System.Drawing.Size(72, 13);
            this.lblTolerance.TabIndex = 8;
            this.lblTolerance.Text = "Tolerance: ";
            // 
            // txtTolerace
            // 
            this.txtTolerace.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTolerace.Location = new System.Drawing.Point(498, 40);
            this.txtTolerace.MaxLength = 11;
            this.txtTolerace.Name = "txtTolerace";
            this.txtTolerace.Size = new System.Drawing.Size(75, 20);
            this.txtTolerace.TabIndex = 1;
            this.txtTolerace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // btnTolerance
            // 
            this.btnTolerance.Location = new System.Drawing.Point(498, 71);
            this.btnTolerance.Name = "btnTolerance";
            this.btnTolerance.Size = new System.Drawing.Size(75, 23);
            this.btnTolerance.TabIndex = 2;
            this.btnTolerance.Text = "Visualize Tolerance";
            this.btnTolerance.UseVisualStyleBackColor = true;
            this.btnTolerance.Click += new System.EventHandler(this.btnTolerance_Click);
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
    }
}
