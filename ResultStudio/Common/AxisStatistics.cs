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
        private Dictionary<int, Vector> _data;
        private string _sAxis;

        private double _dMinimum;
        private double _dMaximum;
        private double _dAverage;
        private int _iMax_PartID;
        private int _iMin_PartID;

        // Variables related to tolerance
        private double _dTolerancePercentage;
        // Tolerance range min and max
        private double _dToleranceMin;
        private double _dToleranceMax;

        public string Axis { get { return _sAxis; } }
        
        public AxisStatistics()
        {
        }

        public AxisStatistics(string sAxis, ref Dictionary<int, Vector> dataset)
        {
            this._sAxis = sAxis;
            this._data = dataset;
            SetMinMaxValue();
        }

        public double GetMaximumValue()
        {
            return Math.Round(_dMaximum, 3);
        }
        public double GetMinimumValue()
        {
            return Math.Round(_dMinimum, 3);
        }
        public int GetMinPartID()
        {
            return _iMin_PartID;
        }
        public int GetMaxPartID()
        {
            return _iMax_PartID;
        }
        public double GetAverageValue()
        {
            return Math.Round(_dAverage, 3);
        }
        public double GetVariation()
        {
            return Math.Round((Math.Abs(_dMaximum - _dMinimum)), 3);
        }
        private void SetMinMaxValue()
        {
            switch (_sAxis)
            {
                case "X":
                    _dMinimum = _data.Aggregate((l, r) => l.Value.X < r.Value.X ? l : r).Value.X;
                    _dMaximum = _data.Aggregate((l, r) => l.Value.X > r.Value.X ? l : r).Value.X;
                    _dAverage = Math.Round(_data.Sum(x => x.Value.X) / _data.Count(), 3);
                    _iMin_PartID = _data.Aggregate((l, r) => l.Value.X < r.Value.X ? l : r).Key;
                    _iMax_PartID = _data.Aggregate((l, r) => l.Value.X > r.Value.X ? l : r).Key;
                    break;
                case "Y":
                    _dMinimum = _data.Aggregate((l, r) => l.Value.Y < r.Value.Y ? l : r).Value.Y;
                    _dMaximum = _data.Aggregate((l, r) => l.Value.Y > r.Value.Y ? l : r).Value.Y;
                    _dAverage = Math.Round(_data.Sum(x => x.Value.Y) / _data.Count(),3);
                    _iMin_PartID = _data.Aggregate((l, r) => l.Value.Y < r.Value.Y ? l : r).Key;
                    _iMax_PartID = _data.Aggregate((l, r) => l.Value.Y > r.Value.Y ? l : r).Key;
                    break;
                case "Z":
                    _dMinimum = _data.Aggregate((l, r) => l.Value.Z < r.Value.Z ? l : r).Value.Z;
                    _dMaximum = _data.Aggregate((l, r) => l.Value.Z > r.Value.Z ? l : r).Value.Z;
                    _dAverage = Math.Round(_data.Sum(x => x.Value.Z) / _data.Count(),3);
                    _iMin_PartID = _data.Aggregate((l, r) => l.Value.Z < r.Value.Z ? l : r).Key;
                    _iMax_PartID = _data.Aggregate((l, r) => l.Value.Z > r.Value.Z ? l : r).Key;
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

        #region Tolerance related operations and varaibles
        public double TolerancePercentage
        {
            get
            {
                return _dTolerancePercentage;
            }
        }
        public double MaxToleranceValue
        {
            get
            {
                return _dToleranceMax;
            }
        }
        public double MinToleranceValue
        {
            get
            {
                return _dToleranceMin;
            }
        }

        public void CalculateToleranceRange(double tolerancePercentage)
        {
            _dTolerancePercentage = tolerancePercentage;
            // To calulate min and max range, lets calculate the tolerance from variation. 
            double toleranceValue = GetVariation() * (tolerancePercentage / 100);

            // Min and Max tolernace = mean +/- toleranceValue
            _dToleranceMin = Math.Round(_dAverage - toleranceValue, 3);
            _dToleranceMax = Math.Round(_dAverage + toleranceValue, 3);

        }


        #endregion
    }
}
