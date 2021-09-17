using ResultStudio.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ResultStudio.Controllers
{
    public class VisualRepresentationController
    {
        private Dictionary<int, Vector> data;
        private double dMinX, dMinY, dMinZ, dMaxX, dMaxY, dMaxZ;
        public VisualRepresentationController()
        {
            dMinX = dMinY = dMinZ = dMaxX = dMaxY = dMaxZ = 0.0;
        }


        public Dictionary<int, Vector> DataSet
        {
            set { this.data = value; }
        }

        public void PopulateAxisGraph(ref Chart canvasChart, string axisType, out string messageLog)
        {
            messageLog = string.Empty;
            try
            {
                if (data == null)
                {
                    messageLog = Properties.Resources.sErrNoData;
                }

                double value = 0;
                foreach (KeyValuePair<int, Vector> part in data)
                {
                    value = GetAxisValue(part, axisType);
                    canvasChart.Series[0].Points.AddXY(part.Key, value);
                }
                SetChartStyle(ref canvasChart);

                double dMinimum = 0;
                double dMaximum = 0;
                GetMinMaxValue(ref dMinimum, ref dMaximum, axisType);
                canvasChart.ChartAreas[0].AxisY.Minimum = dMinimum;
                canvasChart.ChartAreas[0].AxisY.Maximum = dMaximum;
                // Can have smaller intervals for individual graphs
            }
            catch (Exception e)
            {
                messageLog += "\n ERROR in loading main chart: " + e.ToString();
            }

        }

        private void GetMinMaxValue(ref double dMinimum, ref double dMaximum, string axisType)
        {
            switch (axisType)
            {
                case "X":
                    dMinimum = dMinX;
                    dMaximum = dMaxX;
                    break;
                case "Y":
                    dMinimum = dMinY;
                    dMaximum = dMaxY;
                    break;
                case "Z":
                    dMinimum = dMinZ;
                    dMaximum = dMaxZ;
                    break;
                default:
                    break ;
            }
        }

        private double GetAxisValue(KeyValuePair<int, Vector> part, string axisType)
        {
            switch (axisType)
            {
                case "X":
                    return part.Value.X;
                case "Y":
                    return part.Value.Y;
                case "Z":
                    return part.Value.Z;
                default:
                    return 0;
            }
        }

        public void PopulatePointDistributionGraph(ref Chart canvasChart, out string messageLog)
        {
            messageLog = string.Empty;
            try
            {
                if (data == null)
                {
                    messageLog = Properties.Resources.sErrNoData;
                }

                foreach (KeyValuePair<int, Vector> part in data)
                {
                    canvasChart.Series[0].Points.AddXY(part.Key, part.Value.X);
                    canvasChart.Series[1].Points.AddXY(part.Key, part.Value.Y);
                    canvasChart.Series[2].Points.AddXY(part.Key, part.Value.Z);
                }
                SetChartStyle(ref canvasChart);
                GetMinMaxFromData();
            }
            catch (Exception e)
            {
                messageLog += "\n ERROR in loading main chart: " + e.ToString();
            }
        }

        private void GetMinMaxFromData()
        {
            dMinX = data.Aggregate((l, r) => l.Value.X < r.Value.X ? l : r).Value.X;
            dMinY = data.Aggregate((l, r) => l.Value.Y < r.Value.Y ? l : r).Value.Y;
            dMinZ = data.Aggregate((l, r) => l.Value.Z < r.Value.Z ? l : r).Value.Z;

            dMaxX = data.Aggregate((l, r) => l.Value.X > r.Value.X ? l : r).Value.X;
            dMaxY = data.Aggregate((l, r) => l.Value.Y > r.Value.Y ? l : r).Value.Y;
            dMaxZ = data.Aggregate((l, r) => l.Value.Z > r.Value.Z ? l : r).Value.Z;
        }

        private void SetChartStyle(ref Chart canvasChart)
        {
            canvasChart.ChartAreas[0].CursorX.IsUserEnabled = true;
            canvasChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            canvasChart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            canvasChart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            canvasChart.ChartAreas[0].CursorY.IsUserEnabled = true;
            canvasChart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            canvasChart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            canvasChart.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;
            canvasChart.ChartAreas[0].CursorX.Interval = 0.01;

            canvasChart.ChartAreas[0].AxisX.Minimum = 1;
            canvasChart.ChartAreas[0].AxisX.Maximum = 20;

        }


    }
}
