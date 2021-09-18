using ResultStudio.Common;
using ResultStudio.Views;
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
        private string m_sChartType = string.Empty;
        public VisualRepresentationController()
        {
            dMinX = dMinY = dMinZ = dMaxX = dMaxY = dMaxZ = 0.0;
        }
        ~VisualRepresentationController()
        {
        }

        public Dictionary<int, Vector> DataSet
        {
            set { this.data = value; }
        }

        public void PopulatePointDistributionGraph(Chart canvasChart, out string messageLog)
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
                SetChartStyles(canvasChart);
                canvasChart.Series[0].Color = Color.Blue; ;
                canvasChart.Series[1].Color = Color.Green; ;
                canvasChart.Series[2].Color = Color.OrangeRed;
                GetMinMaxFromData();
                m_sChartType = canvasChart.Series[0].ChartType.ToString();
            }
            catch (Exception e)
            {
                messageLog += "\n ERROR in loading main chart: " + e.ToString();
            }
        }
        public void PopulateAxisGraph(Chart canvasChart, string axisType, out string messageLog)
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
                SetChartStyles(canvasChart);

                double dMinimum = 0;
                double dMaximum = 0;
                GetMinMaxValue(ref dMinimum, ref dMaximum, axisType);
                canvasChart.ChartAreas[0].AxisY.Minimum = dMinimum;
                canvasChart.ChartAreas[0].AxisY.Maximum = dMaximum;
                // No need for legends in these charts.
                canvasChart.Series[0].Color = GetColorForLine(axisType);
                canvasChart.Legends.Clear();
            }
            catch (Exception e)
            {
                messageLog += "\n ERROR in loading main chart: " + e.ToString();
            }
            messageLog += "\n Axis chart load successful.";

        }

        public void PopulateStatisticsControl(StatsViewControl controlToBeLoaded, string sAxis, out string messageLog)
        {
            messageLog = string.Empty;
            try
            {
                if (data == null)
                {
                    messageLog = Properties.Resources.sErrNoData;
                }

                controlToBeLoaded.AxisStatistics = new AxisStatistics(sAxis, ref data);
                // need to 
                controlToBeLoaded.ToleranceButtonClicked += ToleranceButtonClicked;

                controlToBeLoaded.LoadControl(out messageLog) ;
                List<Vector> vectorList = new List<Vector>();
                foreach (KeyValuePair<int, Vector> part in data)
                {
                    //value = GetAxisValue(part, sAxis);
                }

               

            }
            catch (Exception e)
            {
                messageLog += "\n ERROR in populating statistics: " + e.ToString();
            }
            messageLog += "\n Axis statistics load successful.";
        }

        public void SetChartType(Chart canvasChart, string chartType)
        {
            canvasChart.Series[0].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), chartType);
            canvasChart.Series[1].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), chartType);
            canvasChart.Series[2].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), chartType);
        }
        public string GetChartType()
        {
            return m_sChartType;
        }

        //Close the form when you received the notification
        private void ToleranceButtonClicked(object sender, EventArgs e)
        {
            AxisStatistics stats = ((StatsViewControl)sender).AxisStatistics;
        }

        private Color GetColorForLine(string axisType)
        {
            switch (axisType)
            {
                case "X":
                    return Color.Blue;
                case "Y":
                    return Color.Green;
                case "Z":
                    return Color.OrangeRed;
                default:
                    return Color.Black;
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
                    break;
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

        private void GetMinMaxFromData()
        {
            dMinX = data.Aggregate((l, r) => l.Value.X < r.Value.X ? l : r).Value.X;
            dMinY = data.Aggregate((l, r) => l.Value.Y < r.Value.Y ? l : r).Value.Y;
            dMinZ = data.Aggregate((l, r) => l.Value.Z < r.Value.Z ? l : r).Value.Z;

            dMaxX = data.Aggregate((l, r) => l.Value.X > r.Value.X ? l : r).Value.X;
            dMaxY = data.Aggregate((l, r) => l.Value.Y > r.Value.Y ? l : r).Value.Y;
            dMaxZ = data.Aggregate((l, r) => l.Value.Z > r.Value.Z ? l : r).Value.Z;
        }

        private void SetChartStyles(Chart canvasChart)
        {
            // Could be moved to designer class for ResultStudio
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
