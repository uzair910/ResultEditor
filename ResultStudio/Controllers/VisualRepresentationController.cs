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
        #region Variable declarations and Constructor/Destructor
        private Dictionary<int, Vector> data;
        private double dMinX, dMinY, dMinZ, dMaxX, dMaxY, dMaxZ;
        private string sChartType = string.Empty;
        private string sActiveAxis = string.Empty;
        private Chart chartXAxis;
        private Chart chartYAxis;
        private Chart chartZAxis;
        private double m_dUpperToleranceValue;
        private double m_dLowerToleranceValue;

        public Chart XAxisChart { set { this.chartXAxis = value; } }
        public Chart YAxisChart { set { this.chartYAxis = value; } }
        public Chart ZAxisChart { set { this.chartZAxis = value; } }
        public string ActiveAxis { get { return this.sActiveAxis; } }
        public Dictionary<int, Vector> DataSet
        {
            set { this.data = value; }
        }
        public double UpperToleranceValue { get { return m_dUpperToleranceValue; } }
        public double LowerToleranceValue { get { return m_dLowerToleranceValue; } }

        // Out of tolerance range part and value string. 
        private StringBuilder sbOutOfBoundPart;

        public VisualRepresentationController()
        {
            dMinX = dMinY = dMinZ = dMaxX = dMaxY = dMaxZ = 0.0;
        }
        ~VisualRepresentationController()
        {
        }
        #endregion

        /// <summary>
        /// Clear local variables.
        /// </summary>
        public void Clear()
        {
            dMinX = dMinY = dMinZ = dMaxX = dMaxY = dMaxZ = 0.0;
            chartXAxis = chartYAxis = chartZAxis = null;
            sChartType = sActiveAxis = string.Empty;
            data = null;
        }

        /// <summary>
        /// This method populates the main chart with all the axis.
        /// </summary>
        /// <param name="canvasChart">Chart to be populated.</param>
        /// <param name="messageLog"> to keep track of progress, that will be updated to the log view.</param>
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
                AssignMinMaxFromData();
                sChartType = canvasChart.Series[0].ChartType.ToString();
            }
            catch (Exception e)
            {
                messageLog += "\n ERROR in loading main chart: " + e.ToString();
            }
        }

        /// <summary>
        /// This method is to populate the chart specific to one axis.
        /// </summary>
        /// <param name="sAxisType">To identify which chart needs to be populated (X,Y or Z).</param>
        /// <param name="messageLog"> to keep track of progress, that will be updated to the log view.</param>
        public void PopulateAxisGraph(string sAxisType, out string messageLog)
        {
            Chart canvasChart = GetActiveChart(sAxisType);
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
                    value = GetAxisValue(part, sAxisType);
                    canvasChart.Series[0].Points.AddXY(part.Key, value);
                }
                SetChartStyles(canvasChart);

                double dMinimum = 0;
                double dMaximum = 0;
                GetMinMaxValue(ref dMinimum, ref dMaximum, sAxisType);
                canvasChart.ChartAreas[0].AxisY.Minimum = dMinimum;
                canvasChart.ChartAreas[0].AxisY.Maximum = dMaximum;
                canvasChart.Series[0].Color = GetColorForLine(sAxisType);
                // No need for legends in these charts.
                canvasChart.Legends.Clear();
            }
            catch (Exception e)
            {
                messageLog += "\n ERROR in loading main chart: " + e.ToString();
            }
            messageLog += "\n Axis chart load successful.";

        }

        /// <summary>
        /// This method returns the chart, based on what axis (X,Y or Z) is passed by the UI layer.
        /// </summary>
        /// <param name="sAxisType">To identify which chart needs to be populated (X,Y or Z).</param>
        /// <returns></returns>
        private Chart GetActiveChart(string sAxisType)
        {
            switch (sAxisType)
            {
                case "X":
                    return chartXAxis;
                case "Y":
                    return chartYAxis;
                case "Z":
                    return chartZAxis;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Populate the statistics for the axis specific charts.
        /// </summary>
        /// <param name="controlToBeLoaded"> The statistic control that is to be loaded.</param>
        /// <param name="sAxisType">To identify which chart needs to be populated (X,Y or Z).</param>
        /// <param name="messageLog"> to keep track of progress, that will be updated to the log view.</param>
        public void PopulateStatisticsControl(StatsViewControl controlToBeLoaded, string sAxisType, out string messageLog)
        {
            messageLog = string.Empty;
            try
            {
                if (data == null)
                {
                    messageLog = Properties.Resources.sErrNoData;
                }

                controlToBeLoaded.AxisStatistics = new AxisStatistics(sAxisType, ref data);
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
       
        /// <summary>
        /// This method is used to highlight columns that lie outside the tolerance range.
        /// </summary>
        /// <param name="dgvData">The data grid with all the rows. Passed as reference from the UI layer.</param>
        /// <param name="messageLog"> to keep track of progress, that will be updated to the log view.</param>
        public void HighlightDataGrid(ref DataGridView dgvData, out string messageLog)
        {
            messageLog = string.Empty;
            if (data == null)
                return;
            try
            {
                sbOutOfBoundPart = new StringBuilder();
                foreach (DataGridViewRow row in dgvData.Rows)
                {

                    double xVal = double.Parse(row.Cells[Properties.Resources.sAxisX].Value.ToString());
                    double yVal = double.Parse(row.Cells[Properties.Resources.sAxisY].Value.ToString());
                    double zVal = double.Parse(row.Cells[Properties.Resources.sAxisZ].Value.ToString());

                    switch (ActiveAxis)
                    {
                        case "X":
                            if (xVal < LowerToleranceValue || xVal > UpperToleranceValue)
                            {
                                row.Cells[Properties.Resources.sAxisX].Style.BackColor = Color.Pink;
                                sbOutOfBoundPart.AppendLine(row.Cells["Key"].Value.ToString() + ",\tValue: " + row.Cells[Properties.Resources.sAxisX].Value.ToString());
                            }
                            else
                                row.Cells[Properties.Resources.sAxisX].Style.BackColor = Color.White;
                            break;
                        case "Y":
                            if (yVal < LowerToleranceValue || yVal > UpperToleranceValue)
                            {
                                row.Cells[Properties.Resources.sAxisY].Style.BackColor = Color.Pink;
                                sbOutOfBoundPart.AppendLine(row.Cells["Key"].Value.ToString() + ",\tValue: " + row.Cells[Properties.Resources.sAxisY].Value.ToString());
                            }
                            else
                                row.Cells[Properties.Resources.sAxisY].Style.BackColor = Color.White;
                            break;
                        case "Z":
                            if (zVal < LowerToleranceValue || zVal > UpperToleranceValue)
                            {
                                row.Cells[Properties.Resources.sAxisZ].Style.BackColor = Color.Pink;
                                sbOutOfBoundPart.AppendLine(row.Cells["Key"].Value.ToString() + ",\tValue: " + row.Cells[Properties.Resources.sAxisZ].Value.ToString());
                            }
                            else
                                row.Cells[Properties.Resources.sAxisZ].Style.BackColor = Color.White;
                            break;
                        default:
                            break;
                    }
                }
                // Need to show the out of bound parts in the Statistic control tab:

            }
            catch (Exception e)
            {
                messageLog = "Error in highlighting grid:\n" + e.ToString();
                return;
            }
        }

        /// <summary>
        /// Set the chart series type (visual representation of data)
        /// </summary>
        /// <param name="canvasChart">Chart to be editted.</param>
        /// <param name="sChartSeries">The type of chart series</param>
        public void SetChartType(Chart canvasChart, string sChartSeries)
        {
            canvasChart.Series[0].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), sChartSeries);
            canvasChart.Series[1].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), sChartSeries);
            canvasChart.Series[2].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), sChartSeries);
        }

        /// <summary>
        /// Get the grid line color for the axis.
        /// </summary>
        /// <param name="sAxisType">The identifier to tell which axis's value is needed.</param>
        /// <returns></returns>
        private Color GetColorForLine(string sAxisType)
        {
            switch (sAxisType)
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

        /// <summary>
        /// Get Minimum and Maximum value for the axis.
        /// </summary>
        /// <param name="dMinimum">Reference to minimum value.</param>
        /// <param name="dMaximum">Reference to maximum value.</param>
        /// <param name="sAxisType">The identifier to tell which axis's value is needed.</param>
        private void GetMinMaxValue(ref double dMinimum, ref double dMaximum, string sAxisType)
        {
            switch (sAxisType)
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

        /// <summary>
        /// This method returns the axis value for a specific part from the data set.
        /// </summary>
        /// <param name="part">Part, whose axis value is needed.</param>
        /// <param name="sAxisType">The identifier to tell which axis's value is needed.</param>
        /// <returns>The point value.</returns>
        private double GetAxisValue(KeyValuePair<int, Vector> part, string sAxisType)
        {
            switch (sAxisType)
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

        /// <summary>
        /// Set the styles of the chart.
        /// </summary>
        /// <param name="canvasChart">Chart to be editted.</param>
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

        /// <summary>
        /// Set the min and max values for each  Axis from the data set.
        /// </summary>
        private void AssignMinMaxFromData()
        {
            dMinX = data.Aggregate((l, r) => l.Value.X < r.Value.X ? l : r).Value.X;
            dMinY = data.Aggregate((l, r) => l.Value.Y < r.Value.Y ? l : r).Value.Y;
            dMinZ = data.Aggregate((l, r) => l.Value.Z < r.Value.Z ? l : r).Value.Z;
            dMaxX = data.Aggregate((l, r) => l.Value.X > r.Value.X ? l : r).Value.X;
            dMaxY = data.Aggregate((l, r) => l.Value.Y > r.Value.Y ? l : r).Value.Y;
            dMaxZ = data.Aggregate((l, r) => l.Value.Z > r.Value.Z ? l : r).Value.Z;
        }

        #region Data Bindings.
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

            sActiveAxis = stats.Axis;
            // Lets see what values lie outside grid and highlight those...
            OnHighlightGridButtonClicked(e);
            ((StatsViewControl)sender).PartsOutOfToleranceRange = sbOutOfBoundPart;
        }

        public event EventHandler HighlightGridButtonClicked;
        protected virtual void OnHighlightGridButtonClicked(EventArgs e)
        {
            HighlightGridButtonClicked.Invoke(this, e);
        }
        #endregion

    }
}
