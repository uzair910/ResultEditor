using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResultStudio.Common
{
    public class AxisStatistics
    {
        private Dictionary<int, Vector> data;
        private string sAxis;

        private double m_dMinimum;
        private double m_dMaximum;
        private double m_dAverage;
        private int m_iMax_PartID;
        private int m_iMin_PartID;

        // Variables related to tolerance
        private double m_dTolerancePercentage;
        // Tolerance range min and max
        private double m_dToleranceMin;
        private double m_dToleranceMax;

        public AxisStatistics()
        {
        }

        public AxisStatistics(string sAxis, ref Dictionary<int, Vector> dataset)
        {
            this.sAxis = sAxis;
            this.data = dataset;
            SetMinMaxValue();
        }

        public string Axis { get { return sAxis; } }


        public double GetMaximumValue()
        {
            return Math.Round(m_dMaximum, 3);
        }
        public double GetMinimumValue()
        {
            return Math.Round(m_dMinimum, 3);
        }
        public int GetMinPartID()
        {
            return m_iMin_PartID;
        }
        public int GetMaxPartID()
        {
            return m_iMax_PartID;
        }
        public double GetAverageValue()
        {
            return Math.Round(m_dAverage, 3);
        }
        public double GetVariation()
        {
            return Math.Round((Math.Abs(m_dMaximum - m_dMinimum)), 3);
        }
        private void SetMinMaxValue()
        {
            switch (sAxis)
            {
                case "X":
                    m_dMinimum = data.Aggregate((l, r) => l.Value.X < r.Value.X ? l : r).Value.X;
                    m_dMaximum = data.Aggregate((l, r) => l.Value.X > r.Value.X ? l : r).Value.X;
                    m_dAverage = data.Sum(x => x.Value.X) / data.Count();
                    m_iMin_PartID = data.Aggregate((l, r) => l.Value.X < r.Value.X ? l : r).Key;
                    m_iMax_PartID = data.Aggregate((l, r) => l.Value.X > r.Value.X ? l : r).Key;
                    break;
                case "Y":
                    m_dMinimum = data.Aggregate((l, r) => l.Value.Y < r.Value.Y ? l : r).Value.Y;
                    m_dMaximum = data.Aggregate((l, r) => l.Value.Y > r.Value.Y ? l : r).Value.Y;
                    m_dAverage = data.Sum(x => x.Value.Y) / data.Count();
                    m_iMin_PartID = data.Aggregate((l, r) => l.Value.Y < r.Value.Y ? l : r).Key;
                    m_iMax_PartID = data.Aggregate((l, r) => l.Value.Y > r.Value.Y ? l : r).Key;
                    break;
                case "Z":
                    m_dMinimum = data.Aggregate((l, r) => l.Value.Z < r.Value.Z ? l : r).Value.Z;
                    m_dMaximum = data.Aggregate((l, r) => l.Value.Z > r.Value.Z ? l : r).Value.Z;
                    m_dAverage = data.Sum(x => x.Value.Z) / data.Count();
                    m_iMin_PartID = data.Aggregate((l, r) => l.Value.Z < r.Value.Z ? l : r).Key;
                    m_iMax_PartID = data.Aggregate((l, r) => l.Value.Z > r.Value.Z ? l : r).Key;
                    break;

            }
        }

        /// <summary>
        /// Validate that the value in tolerance textbox is a valid decimal value.
        /// </summary>
        /// <param name="keyChar">The id of the key pressed.</param>
        /// <param name="val">The value in the textbox.</param>
        /// <returns></returns>
        public bool IsValidDecimal(char keyChar, string val)
        {
            bool res = true;
            char decimalChar = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            //check if it´s a decimal separator and if doesn´t already have one in the text string
            if (keyChar == decimalChar && val.IndexOf(decimalChar) != -1)
            {
                res = false;
                return res;
            }

            //check if it´s a digit, decimal separator and backspace
            if (!Char.IsDigit(keyChar) && keyChar != decimalChar && keyChar != (char)Keys.Back)
                res = false;

            return res;
        }
        #region Tolerance related operation
        public double TolerancePercentage
        {
            get
            {
                return m_dTolerancePercentage;
            }
        }
        public double MaxToleranceValue
        {
            get
            {
                return m_dToleranceMax;
            }
        }
        public double MinToleranceValue
        {
            get
            {
                return m_dToleranceMin;
            }
        }
        public void CalculateToleranceRange(double tolerancePercentage)
        {
            m_dTolerancePercentage = tolerancePercentage;
            // To calulate min and max range, lets calculate the tolerance from variation. 
            double toleranceValue = GetVariation() * (tolerancePercentage / 100);

            // Min and Max tolernace = mean +/- toleranceValue
            m_dToleranceMin = Math.Round(m_dAverage - toleranceValue, 3);
            m_dToleranceMax = Math.Round(m_dAverage + toleranceValue, 3);

        }


        #endregion
    }
}
