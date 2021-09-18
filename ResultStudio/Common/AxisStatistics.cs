using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public AxisStatistics(string sAxis, ref Dictionary<int, Vector> dataset)
        {
            this.sAxis = sAxis;
            this.data = dataset;
            SetMinMaxValue();
        }

        public string Axis { get { return sAxis; } }

        public double GetMaximumValue()
        {
            return Math.Round(m_dMaximum,3);
        }
        public double GetMinimumValue()
        {
            return Math.Round(m_dMinimum,3);
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
            return Math.Round(m_dAverage,3);
        }
        public double GetVariation()
        {
            return Math.Round((Math.Abs(m_dMaximum - m_dMinimum)),3);
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
    }
}
