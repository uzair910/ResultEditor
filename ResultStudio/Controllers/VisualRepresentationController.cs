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
        private string m_sActiveAxis = string.Empty; 
        private Chart m_chartXAxis;
        private Chart m_chartYAxis;
        private Chart m_chartZAxis;
        public Chart XAxisChart { set { this.m_chartXAxis = value; } }
        public Chart YAxisChart { set { this.m_chartYAxis = value; } }
        public Chart ZAxisChart { set { this.m_chartZAxis = value; } }

        public string ActiveAxis { get { return this.m_sActiveAxis ; } }
        public VisualRepresentationController()
        {
            dMinX = dMinY = dMinZ = dMaxX = dMaxY = dMaxZ = 0.0;
        }
        ~VisualRepresentationController()
        {
        }

        public void Clear()
        {
            dMinX = dMinY = dMinZ = dMaxX = dMaxY = dMaxZ = 0.0;
            m_chartXAxis = m_chartYAxis = m_chartZAxis =  null;
            m_sChartType = m_sActiveAxis = string.Empty;
            data = null;

        }
        public Dictionary<int, Vector> DataSet
        {
            set { this.data = value; }
        }

        private double m_dUpperToleranceValue;
        private double m_dLowerToleranceValue;
        public double UpperToleranceValue { get { return m_dUpperToleranceValue; }}
        public double LowerToleranceValue { get { return m_dLowerToleranceValue; } }
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
        public void PopulateAxisGraph(string axisType, out string messageLog)
        {
            Chart canvasChart = GetActiveChart(axisType);
            if (canvasChart == null)
            {
                messageLog = Properties.Resources.sChartNotAssigned;
                return;
            }
            messageLog = string.Empty;
            try
            {
                if (data == null)
                {
                    messageLog = Properties.Resources.sErrNoData;
                    return;
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
                canvasChart.Series[0].Color = GetColorForLine(axisType);
                // No need for legends in these charts.
                canvasChart.Legends.Clear();
            }
            catch (Exception e)
            {
                messageLog += "\n ERROR in loading main chart: " + e.ToString();
            }
            messageLog += "\n Axis chart load successful.";

        }

        private Chart GetActiveChart(string axisType)
        {
            switch (axisType)
            {
                case "X":
                    return m_chartXAxis;
                case "Y":
                    return m_chartYAxis;
                case "Z":
                    return m_chartZAxis;
                default:
                    return null;
            }
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
                controlToBeLoaded.ToleranceButtonClicked += ToleranceButtonClicked;

                controlToBeLoaded.LoadControl(out messageLog);
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

            // canvas to be edited:
            double tolerance = ((StatsViewControl)sender).Tolerance;
            if (tolerance == 0)
            {
                // We ignore tolerance calculation if 0 is selected for tolerance.
                return;
            }
            Chart canvasChart = GetActiveChart(stats.Axis);

            // Caclulate tolerance range...
            stats.CalculateToleranceRange(tolerance);
            ((StatsViewControl)sender).SetToleranceValue();
            m_dLowerToleranceValue = stats.MinToleranceValue;
            m_dUpperToleranceValue = stats.MaxToleranceValue;

            // Lets create tolerance series on the chart.
            string serUpperToleranceName = "Upper tolerance limit";
            string serLowerToleranceName = "Lower tolerance limit";

            Series setUpperTolernace = null;
            Series seLowerTolerance = null;
            // check if series havenot been added already
            if (!(canvasChart.Series.IndexOf(serUpperToleranceName) != -1))
            {
                setUpperTolernace = canvasChart.Series.Add(serUpperToleranceName);
                seLowerTolerance = canvasChart.Series.Add(serLowerToleranceName);
            }
            else
            {
                setUpperTolernace = canvasChart.Series.FindByName(serUpperToleranceName);
                setUpperTolernace.Points.Clear();
                seLowerTolerance = canvasChart.Series.FindByName(serLowerToleranceName);
                seLowerTolerance.Points.Clear();
            }

            // check if series havenot been added already
            if (!(canvasChart.Series.IndexOf(serUpperToleranceName) != -1))
            {
                setUpperTolernace = canvasChart.Series.Add(serUpperToleranceName);
            }
            else
            {
                setUpperTolernace = canvasChart.Series.FindByName(serUpperToleranceName);
            }
            
            setUpperTolernace.ChartArea = canvasChart.ChartAreas[0].Name;
            setUpperTolernace.Name = serUpperToleranceName;
            setUpperTolernace.ChartType = SeriesChartType.Line;

            seLowerTolerance.ChartArea = canvasChart.ChartAreas[0].Name;
            seLowerTolerance.Name = serLowerToleranceName;
            seLowerTolerance.ChartType = SeriesChartType.Line;

            for (int index = 1; index <= data.Count; index++)
            {
                setUpperTolernace.Points.AddXY(index, stats.MaxToleranceValue);
                seLowerTolerance.Points.AddXY(index, stats.MinToleranceValue);
            }

            // Max tolerance series will always be at index 1
            canvasChart.Series[1].Color = Color.Red;
            canvasChart.Series[1].BorderWidth = 4;
            // Min tolerance series will always be at index 2
            canvasChart.Series[2].Color = Color.Red;
            canvasChart.Series[2].BorderWidth = 4;

            m_sActiveAxis = stats.Axis;
            // Lets see what values lie outside grid and highlight those...
            OnHighlightGridButtonClicked(e);
        }

        public event EventHandler HighlightGridButtonClicked;
        protected virtual void OnHighlightGridButtonClicked(EventArgs e)
        {
            HighlightGridButtonClicked.Invoke(this, e);
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
