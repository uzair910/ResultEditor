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
        private double m_dMinimum;

        private double m_dMaximum;

        private double m_dAverage;

        private int m_dMax_PartID;

        private int m_dMin_PartID;

        private string sAxis;

        public AxisStatistics(string sAxis, ref Dictionary<int, Vector> dataset)
        {
            this.sAxis = sAxis;
            this.data = dataset;
            SetMinMaxValue();
        }

        public double GetMaximumValue()
        {
            return m_dMaximum;
        }
        public double GetMinimumValue()
        {
            return m_dMinimum;
        }
        public int GetMinPartID()
        {
            return m_dMin_PartID;
        }
        public int GetMaxPartID()
        {
            return m_dMax_PartID;
        }

        private void SetMinMaxValue()
        {
            switch (sAxis)
            {
                case "X":
                    m_dMinimum = data.Aggregate((l, r) => l.Value.X < r.Value.X ? l : r).Value.X;
                    m_dMaximum = data.Aggregate((l, r) => l.Value.X > r.Value.X ? l : r).Value.X;

                    m_dMin_PartID = data.Aggregate((l, r) => l.Value.X < r.Value.X ? l : r).Key;
                    m_dMax_PartID = data.Aggregate((l, r) => l.Value.X > r.Value.X ? l : r).Key;
                    break;
                case "Y":
                    m_dMinimum = data.Aggregate((l, r) => l.Value.Y < r.Value.Y ? l : r).Value.Y;
                    m_dMaximum = data.Aggregate((l, r) => l.Value.Y > r.Value.Y ? l : r).Value.Y;

                    m_dMin_PartID = data.Aggregate((l, r) => l.Value.Y < r.Value.Y ? l : r).Key;
                    m_dMax_PartID = data.Aggregate((l, r) => l.Value.Y > r.Value.Y ? l : r).Key;
                    break;
                case "Z":
                    m_dMinimum = data.Aggregate((l, r) => l.Value.Z < r.Value.Z ? l : r).Value.Z;
                    m_dMaximum = data.Aggregate((l, r) => l.Value.Z > r.Value.Z ? l : r).Value.Z;

                    m_dMin_PartID = data.Aggregate((l, r) => l.Value.Z < r.Value.Z ? l : r).Key;
                    m_dMax_PartID = data.Aggregate((l, r) => l.Value.Z > r.Value.Z ? l : r).Key;
                    break;

            }
        }
    }
}
