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
        // Out of tolerance range part(s) and their corresponding axis value
        private StringBuilder sb_OutOfBoundParts;

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
            // can be moved to designer. 
            this.lblTitleOutOfRangeParts.Text = Properties.Resources.sHeaderOutOfToleranceParts;
            sb_OutOfBoundParts = new StringBuilder();
        }

        /// <summary>
        /// Sets the text box with a list of all the parts that are outside tolerance range.
        /// </summary>
        public StringBuilder PartsOutOfToleranceRange
        {
            set
            {
                sb_OutOfBoundParts = value;
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    listOutOfBoundParts.Text = Properties.Resources.sNoneText;
                    ToggleToleranceLabelVisibilty(false);
                }
                else
                {
                    listOutOfBoundParts.Text = sb_OutOfBoundParts.ToString();
                    ToggleToleranceLabelVisibilty(true);
                }
            }
        }

        /// <summary>
        /// Loads the control.
        /// </summary>
        /// <param name="message">The message for the logging purposes</param>
        public void LoadControl(out string message)
        {
            txtTolerace.Text = string.Empty;
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
        /// <summary>
        /// Set Statistics Label values (mix, max, mean and varuation)
        /// </summary>
        public void SetStatisticsLabelValue()
        {
            lblValMax.Text = axisStats.GetMaximumValue().ToString();
            lblValMin.Text = axisStats.GetMinimumValue().ToString();
            lblValMean.Text = axisStats.GetAverageValue().ToString();
            lblVariationValue.Text = axisStats.GetVariation().ToString();
        }

        /// <summary>
        /// Set Tolerance value.. 
        /// </summary>
        public void SetToleranceValue()
        {
            lblValToleranceLowerLimit.Text = axisStats.MinToleranceValue.ToString();
            lblValToleranceUpperLimit.Text = axisStats.MaxToleranceValue.ToString();
        }



        /// <summary>
        /// Trigers the visibility of Tolerance related controls.
        /// </summary>
        /// <param name="bIsVisible"> Boolean value to determine the visibility of the controls.</param>
        private void ToggleToleranceLabelVisibilty(bool bIsVisible)
        {
            lblToleranceLowerLimit.Visible = lblToleranceUpperLimit.Visible = lblValToleranceLowerLimit.Visible = lblValToleranceUpperLimit.Visible = bIsVisible;
            lblTitleOutOfRangeParts.Visible = listOutOfBoundParts.Visible = bIsVisible;
        }

        #region events
        public event EventHandler ToleranceButtonClicked;
        private void txtTolerace_KeyPress(object sender, KeyPressEventArgs e)
        {
            // On enter press, invoke Visulaize Tolerance button event
            if (e.KeyChar == (char)13)
                OnToleranceButtonClicked(e);

            if (!axisStats.IsValidDecimal(e.KeyChar, txtTolerace.Text))
                e.Handled = true;
        }
        protected virtual void OnToleranceButtonClicked(EventArgs e)
        {
            // Incase there is no value in textbox, show a tool tip prompting user to enter a value
            if (string.IsNullOrEmpty(txtTolerace.Text))
            {
                new ToolTip().Show(Properties.Resources.sEnterValueText, txtTolerace, 5000);
                return;
            }
            ToggleToleranceLabelVisibilty(true);
            ToleranceButtonClicked.Invoke(this, e);
        }
        private void btnTolerance_Click(object sender, EventArgs e)
        {
            OnToleranceButtonClicked(e);
        }

        // Can just use MouseOver... replace it.. TBD
        /// <summary>
        /// Show text explaining how tolerance works in this project , when mouse hovers over tolerace controls (textbox and label)
        /// </summary>
        private void ToleranceControls_MouseEnter(object sender, EventArgs e)
        {
            lblToleranceExplaination.Text = Properties.Resources.sToleranceExplaination;
        }

        /// <summary>
        /// Hide text explaining how tolerance works in this project , when mouse leaves tolerace controls (textbox and label)
        /// </summary>
        private void ToleranceControls_MouseLeave(object sender, EventArgs e)
        {
            lblToleranceExplaination.Text = string.Empty;
        }

        public void SetToleranceTextField(double toleranceValue)
        {
            txtTolerace.Text = toleranceValue.ToString();
        }
        #endregion
    }
}
