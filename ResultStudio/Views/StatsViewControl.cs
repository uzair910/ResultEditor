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
        ToolTip helpToolTip;
        public double Tolerance
        {
            get
            {
                double m_dtolerance = -1;
                double.TryParse(txtTolerace.Text, out m_dtolerance);
                return m_dtolerance;
            }
        }
        public AxisStatistics AxisStatistics { set { this.axisStats = value; } get { return this.axisStats; } }

        public StatsViewControl()
        {
            InitializeComponent();
            axisStats = null;
            helpToolTip = new ToolTip();
        }

        public void LoadControl(out string message)
        {
            txtTolerace.Text = string.Empty;
            lblValToleranceUpperLimit.Text = lblValToleranceLowerLimit.Text = "Not yet defined.";
            message = string.Empty;
            if (axisStats == null)
            {
                message = Properties.Resources.sAxisStatLoadError;
                return;
            }

            // Set labels: 
            SetStatisticsLabelValue();
            // no need to show tolerance varialbe right now. Hide them. 
            ToggleToleranceLabelVisibilty(false);
        }

        // Set label values.
        public void SetStatisticsLabelValue()
        {
            lblValMax.Text = axisStats.GetMaximumValue().ToString();
            lblValMin.Text = axisStats.GetMinimumValue().ToString();
            lblValMean.Text = axisStats.GetAverageValue().ToString();
            lblVariationValue.Text = axisStats.GetVariation().ToString();
        }

        public void SetToleranceValue()
        {
            lblValToleranceLowerLimit.Text = axisStats.MinToleranceValue.ToString();
            lblValToleranceUpperLimit.Text = axisStats.MaxToleranceValue.ToString();
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

        private void ToggleToleranceLabelVisibilty(bool bIsVisible)
        {
            lblToleranceLowerLimit.Visible = lblToleranceUpperLimit.Visible = lblValToleranceLowerLimit.Visible = lblValToleranceUpperLimit.Visible = bIsVisible;
        }

        #region events
        public event EventHandler ToleranceButtonClicked;
        private void txtTolerace_KeyPress(object sender, KeyPressEventArgs e)
        {
            // On enter press, invoke Visulaize Tolerance button event
            if (e.KeyChar == (char)13)
                OnToleranceButtonClicked(e);

            if (!isValidDecimal(e.KeyChar, txtTolerace.Text))
                e.Handled = true;
        }
        protected virtual void OnToleranceButtonClicked(EventArgs e)
        {
            ToggleToleranceLabelVisibilty(true);
            ToleranceButtonClicked.Invoke(this, e);
        }
        // method should be invoked in parent control, so that charts can be updated accordingly.
        private void btnTolerance_Click(object sender, EventArgs e)
        {
            OnToleranceButtonClicked(e);
        }
        private void ToleranceControls_MouseEnter(object sender, EventArgs e)
        {
            lblToleranceExplaination.Text = Properties.Resources.sToleranceExplaination;
        }
        private void ToleranceControls_MouseLeave(object sender, EventArgs e)
        {
            lblToleranceExplaination.Text = string.Empty;
        }
        #endregion
    }
}
