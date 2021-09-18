
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.lblMinimum, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMaximum, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAverage, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
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
            this.tableLayoutPanel1.SetColumnSpan(this.lblAverage, 3);
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
            this.tableLayoutPanel1.SetColumnSpan(this.lblMaximum, 3);
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
            this.tableLayoutPanel1.SetColumnSpan(this.lblMinimum, 3);
            this.lblMinimum.Location = new System.Drawing.Point(3, 10);
            this.lblMinimum.Name = "lblMinimum";
            this.lblMinimum.Size = new System.Drawing.Size(48, 13);
            this.lblMinimum.TabIndex = 3;
            this.lblMinimum.Text = "Minimum";
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
    }
}
