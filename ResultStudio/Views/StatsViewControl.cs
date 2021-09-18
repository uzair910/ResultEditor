using ResultStudio.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResultStudio.Views
{
    public partial class StatsViewControl : UserControl
    {
        private AxisStatistics axisStats;
        public StatsViewControl()
        {
            InitializeComponent();
            axisStats = null;

        }

        public AxisStatistics AxisStatistics { set { this.axisStats = value; } get { return this.axisStats; } }
        public void AssignTexts(out string message)
        {
            message = string.Empty;
            if (axisStats == null)
            {
                message = "Error: Statistic View Class initialization didnot work correctly. AxisStatistics not initialized";
                return;
            }

            // Set labels: 
            lblMaximum.Text = Properties.Resources.sTextMaximum.Replace("#VALUE#", axisStats.GetMaximumValue().ToString()).Replace("#PARTID#", axisStats.GetMaxPartID().ToString());
            lblMinimum.Text = Properties.Resources.sTextMaximum.Replace("#VALUE#", axisStats.GetMinimumValue().ToString()).Replace("#PARTID#", axisStats.GetMinPartID().ToString());

        }
    }
}
