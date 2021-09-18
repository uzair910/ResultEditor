using ResultStudio.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public void LoadControl(out string message)
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
            lblAverage.Text = Properties.Resources.sTextAverage.Replace("#VALUE#", axisStats.GetAverageValue().ToString());
            lblVariationValue.Text = axisStats.GetVariation().ToString();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isValidDecimal(e.KeyChar, txtTolerace.Text))
                e.Handled = true;

        }

        private bool isValidDecimal(char keyChar, string text)
        {
            bool res = true;
            char decimalChar = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            //check if it´s a decimal separator and if doesn´t already have one in the text string
            if (keyChar == decimalChar && text.IndexOf(decimalChar) != -1)
            {
                res = false;
                return res;
            }

            //check if it´s a digit, decimal separator and backspace
            if (!Char.IsDigit(keyChar) && keyChar != decimalChar && keyChar != (char)Keys.Back)
                res = false;

            return res;
        }

        public event EventHandler ToleranceButtonClicked;
        protected virtual void OnToleranceButtonClicked(EventArgs e)
        {
            ToleranceButtonClicked.Invoke(this, e);
        }
        // method should be invoked in parent control, so that charts can be updated accordingly.
        private void btnTolerance_Click(object sender, EventArgs e)
        {
            OnToleranceButtonClicked(e);
        }

        public double Tolerance { 
            get {
                double m_dtolerance = -1;
                double.TryParse(txtTolerace.Text, out m_dtolerance);
                return m_dtolerance; 
            } 
        }
    }
}
