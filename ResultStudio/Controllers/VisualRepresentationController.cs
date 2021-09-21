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
        private Dictionary<int, Vector> _data;
        private double _dMinX, _dMinY, _dMinZ, _dMaxX, _dMaxY, _dMaxZ;
        private string _sChartType = string.Empty;
        private string _sActiveAxis = string.Empty;
        private Chart _chartXAxis;
        private Chart _chartYAxis;
        private Chart _chartZAxis;
        private double _dUpperToleranceValue;
        private double _dLowerToleranceValue;

        public Chart XAxisChart { set { this._chartXAxis = value; } }
        public Chart YAxisChart { set { this._chartYAxis = value; } }
        public Chart ZAxisChart { set { this._chartZAxis = value; } }
        public string ActiveAxis { get { return this._sActiveAxis; } }
        public Dictionary<int, Vector> DataSet
        {
            set { this._data = value; }
        }
        public double UpperToleranceValue { get { return _dUpperToleranceValue; } }
        public double LowerToleranceValue { get { return _dLowerToleranceValue; } }

        // Out of tolerance range part and value string. 
        private StringBuilder _sbOutOfBoundPart;

        public VisualRepresentationController()
        {
            _dMinX = _dMinY = _dMinZ = _dMaxX = _dMaxY = _dMaxZ = 0.0;
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
            _dMinX = _dMinY = _dMinZ = _dMaxX = _dMaxY = _dMaxZ = 0.0;
            _chartXAxis = _chartYAxis = _chartZAxis = null;
            _sChartType = _sActiveAxis = string.Empty;
            _data = null;
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
                if (_data == null)
                {
                    messageLog = Properties.Resources.sErrNoData;
                    return;
                }

                foreach (KeyValuePair<int, Vector> part in _data)
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
                _sChartType = canvasChart.Series[0].ChartType.ToString();
            }
            catch (Exception e)
            {
                messageLog += "\nERROR in loading main chart: " + e.ToString();
            }
            finally
            {
                messageLog = "Main chart loaded successfully.";
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
                if (_data == null)
                {
                    messageLog = Properties.Resources.sErrNoData;
                }

                controlToBeLoaded.AxisStatistics = new AxisStatistics(sAxisType, ref _data);
                controlToBeLoaded.ToleranceButtonClicked += ToleranceButtonClicked;
                controlToBeLoaded.LoadControl(out messageLog);
            }
            catch (Exception e)
            {
                messageLog += "\nERROR in populating statistics: " + e.ToString();
            }
            messageLog += "Axis statistics load successful.";
        }

        /// <summary>
        /// This method is used to place parts and axis values in the textbox where all axis are outside tolerance range.
        /// This method doesn't have the best implementation. I had to compromise with either
        ///     1. iterating throug grid items and seeing if all X Y and Z are pink, then add it to text.
        ///     2. create new object containing Parts and points that lie outside tolerance and then compare results.
        /// </summary>
        /// <param name="outputControl">Reference of control where we want our data to be placed.</param>
        /// /// <param name="dgvData">The data grid from the UI. If all the X,Y and Z columns are pink, that means the whole part is outlier.</param>
        /// <param name="messageLog">To keep track of progress, that will be updated to the log view.</param>
        public void PopulateOutliersText(ref RichTextBox outputControl, DataGridView dgvData, out string messageLog)
        {
            outputControl.Text = string.Empty;
            messageLog = string.Empty;
            if (_data == null)
                return;
            try
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    var xVal = row.Cells[Properties.Resources.sAxisX].Value.ToString();
                    var yVal = row.Cells[Properties.Resources.sAxisY].Value.ToString();
                    var zVal = row.Cells[Properties.Resources.sAxisZ].Value.ToString();

                    if (row.Cells[Properties.Resources.sAxisX].Style.BackColor == Color.Pink &&
                        row.Cells[Properties.Resources.sAxisY].Style.BackColor == Color.Pink &&
                        row.Cells[Properties.Resources.sAxisZ].Style.BackColor == Color.Pink)
                    {
                        outputControl.AppendText(row.Cells["Key"].Value.ToString() + "\t(" + xVal + "," + yVal + "," + zVal + ")\n");
                        row.DefaultCellStyle.BackColor = Color.Firebrick;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
                if (string.IsNullOrEmpty(outputControl.Text))
                    outputControl.Text += Properties.Resources.sNoOutliersFoundText;
            }
            catch (Exception e)
            {
                messageLog = "Error in highlighting grid:\n" + e.ToString();
                return;
            }
        }

        /// <summary>
        /// method to show trends in axis.
        /// </summary>
        /// <param name="outputControl">Control which will show data.</param>
        /// <param name="messageLog">This text will be updated in the log.</param>
        public void PopulateTrendsText(ref RichTextBox outputControl, out string messageLog)
        {
            messageLog = string.Empty;
            outputControl.Text = string.Empty;
            try
            {
                outputControl.Text += GetTrendPattern(Properties.Resources.sAxisX);
                outputControl.Text += GetTrendPattern(Properties.Resources.sAxisY);
                outputControl.Text += GetTrendPattern(Properties.Resources.sAxisZ);

                // if no trends are found, load default message:
                if (string.IsNullOrEmpty(outputControl.Text))
                    outputControl.Text += Properties.Resources.sNoTrendsNotedText;
            }
            catch (Exception e)
            {
                messageLog = "Error in determing pattern:\n" + e.ToString();
            }
            messageLog += "Trends loaded successfully.";
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
                if (_data == null)
                {
                    messageLog = Properties.Resources.sErrNoData;
                    return;
                }

                double value = 0;
                foreach (KeyValuePair<int, Vector> part in _data)
                {
                    value = GetAxisValue(part, sAxisType);
                    canvasChart.Series[0].Points.AddXY(part.Key, value);
                }
                SetChartStyles(canvasChart);
                var dMinimum = 0.0;
                var dMaximum = 0.0;
                GetMinMaxValue(ref dMinimum, ref dMaximum, sAxisType);
                canvasChart.ChartAreas[0].AxisY.Minimum = dMinimum;
                canvasChart.ChartAreas[0].AxisY.Maximum = dMaximum;
                canvasChart.Series[0].Color = GetColorForLine(sAxisType);
                // No need for legends in these charts.
                canvasChart.Legends.Clear();
            }
            catch (Exception e)
            {
                messageLog += "\nERROR in loading main chart: " + e.ToString();
            }
            messageLog += "Axis chart load successful.";

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
                    return _chartXAxis;
                case "Y":
                    return _chartYAxis;
                case "Z":
                    return _chartZAxis;
                default:
                    return null;
            }
        }

        /// <summary>
        /// This method is used to highlight columns that lie outside the tolerance range.
        /// </summary>
        /// <param name="dgvData">The data grid with all the rows. Passed as reference from the UI layer.</param>
        /// <param name="messageLog"> To keep track of progress, that will be updated to the log view.</param>
        public void HighlightDataGrid(ref DataGridView dgvData, out string messageLog)
        {
            messageLog = string.Empty;
            if (_data == null)
                return;
            try
            {
                _sbOutOfBoundPart = new StringBuilder();
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
                                _sbOutOfBoundPart.AppendLine(row.Cells["Key"].Value.ToString() + ",\tValue: " + row.Cells[Properties.Resources.sAxisX].Value.ToString());
                            }
                            else
                                row.Cells[Properties.Resources.sAxisX].Style.BackColor = Color.White;
                            break;
                        case "Y":
                            if (yVal < LowerToleranceValue || yVal > UpperToleranceValue)
                            {
                                row.Cells[Properties.Resources.sAxisY].Style.BackColor = Color.Pink;
                                _sbOutOfBoundPart.AppendLine(row.Cells["Key"].Value.ToString() + ",\tValue: " + row.Cells[Properties.Resources.sAxisY].Value.ToString());
                            }
                            else
                                row.Cells[Properties.Resources.sAxisY].Style.BackColor = Color.White;
                            break;
                        case "Z":
                            if (zVal < LowerToleranceValue || zVal > UpperToleranceValue)
                            {
                                row.Cells[Properties.Resources.sAxisZ].Style.BackColor = Color.Pink;
                                _sbOutOfBoundPart.AppendLine(row.Cells["Key"].Value.ToString() + ",\tValue: " + row.Cells[Properties.Resources.sAxisZ].Value.ToString());
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
        /// Generic method to fetch trend pattern text for the axis that is passed to it
        /// </summary>
        /// <param name="sActiveAxis">The identifier to tell which axis's value is needed.</param>
        /// <returns></returns>
        private string GetTrendPattern(string sActiveAxis)
        {
            StringBuilder sbTrend = new StringBuilder();
            // TODO
            bool isAscending, isDecending = false;
            CheckAxisValuesOrder(sActiveAxis, out isAscending, out isDecending);
            if (isAscending)
                sbTrend.AppendLine(Properties.Resources.sTextAscendingPatterObserved + " " + sActiveAxis);
            if (isDecending)
                sbTrend.AppendLine(Properties.Resources.sTextDescendingPatterObserved + " " + sActiveAxis);
            return sbTrend.ToString();
        }

        /// <summary>
        /// This Method checks if the axis values show any trend over a period of time (as parts progress..)
        /// </summary>
        /// <param name="sActiveAxis">The identifier to tell which axis's value is needed.</param>
        /// <param name="isAscending">A boolean to show if ascending order pattern is observed</param>
        /// <param name="isDecending">A boolean to show if descending order pattern is observed</param>
        private void CheckAxisValuesOrder(string sActiveAxis, out bool isAscending, out bool isDecending)
        {
            isAscending = isDecending = false;
            // Min value will actually contain max value from the series
            double dMinVal = 0;
            // Max value will actually contain max value from the series
            double dMaxVal = 0;
            GetMinMaxValue(ref dMaxVal, ref dMinVal, sActiveAxis);

            foreach (KeyValuePair<int, Vector> part in _data)
            {
                double val = GetAxisValue(part, sActiveAxis);
                // Ascending order check..
                if (val >= dMaxVal)
                {
                    isAscending = true;
                    dMaxVal = val;
                }
                else
                    isAscending = false;
            }
            if (isAscending)
                return;

            // Ascending pattern is not observed, lets try to see if there is a decending pattern:
            foreach (KeyValuePair<int, Vector> part in _data)
            {
                double val = GetAxisValue(part, sActiveAxis);
                // decending order check
                if (val <= dMinVal)
                {
                    isDecending = true;
                    dMinVal = val;
                }
                else
                    isDecending = false;
            }
        }

        /// <summary>
        /// Show values and parts lying outside the tolerance of the axis.
        /// </summary>
        /// <param name="sActiveAxis">The identifier to tell which axis's value is needed.</param>
        private void GetOutOfBoundPointsForAxis(string sActiveAxis)
        {
            _sbOutOfBoundPart = new StringBuilder();
            foreach (KeyValuePair<int, Vector> part in _data)
            {
                double val = GetAxisValue(part, sActiveAxis);
                if (!TestRange(val, _dLowerToleranceValue, _dUpperToleranceValue))
                    _sbOutOfBoundPart.AppendLine(part.Key.ToString() + ",\t Value:" + val);
            }
        }

        /// <summary>
        /// Method to check if the value lies withing a range
        /// </summary>
        /// <param name="numberToCheck">Which number to comapre.</param>
        /// <param name="lowerLimit">Lower limit value</param>
        /// <param name="upperLimit">Upper limit value</param>
        /// <returns>Boolean if true, will indicate if the number lies within range. It will be false if the number lies outside the range.</returns>
        private bool TestRange(double numberToCheck, double lowerLimit, double upperLimit)
        {
            return (numberToCheck >= lowerLimit && numberToCheck <= upperLimit);
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
                    dMinimum = _dMinX;
                    dMaximum = _dMaxX;
                    break;
                case "Y":
                    dMinimum = _dMinY;
                    dMaximum = _dMaxY;
                    break;
                case "Z":
                    dMinimum = _dMinZ;
                    dMaximum = _dMaxZ;
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
            _dMinX = _data.Aggregate((l, r) => l.Value.X < r.Value.X ? l : r).Value.X;
            _dMinY = _data.Aggregate((l, r) => l.Value.Y < r.Value.Y ? l : r).Value.Y;
            _dMinZ = _data.Aggregate((l, r) => l.Value.Z < r.Value.Z ? l : r).Value.Z;
            _dMaxX = _data.Aggregate((l, r) => l.Value.X > r.Value.X ? l : r).Value.X;
            _dMaxY = _data.Aggregate((l, r) => l.Value.Y > r.Value.Y ? l : r).Value.Y;
            _dMaxZ = _data.Aggregate((l, r) => l.Value.Z > r.Value.Z ? l : r).Value.Z;
        }

        /// <summary>
        /// The tolerance calculation called from main form. 
        /// This is general button and it uses same tolerance value from UI to calculate tolerance for all the axis.
        /// </summary>
        /// <param name="stats">Statistic page to be updated</param>
        /// <param name="toleranceValue">Tolerance value from UI</param>
        /// <param name="messageLogText">Message log text place holder</param>
        /// <returns></returns>
        public StringBuilder CalculateToleranceWithGeneralValue(AxisStatistics stats, double toleranceValue, out string messageLogText)
        {
            messageLogText = string.Empty;
            try
            {
                CalculateTolerance(stats, toleranceValue);
            }
            catch (Exception e)
            {
                messageLogText = "ERROR in calculating tolerance for the axis.\n" + e.ToString();
            }
            return _sbOutOfBoundPart;
        }

        #region Data Bindings.

        /// <summary>
        /// Tolerance button clicked from the individual stats page.
        /// </summary>
        public void ToleranceButtonClicked(object sender, EventArgs e)
        {
            AxisStatistics stats = ((StatsViewControl)sender).AxisStatistics;
            double tolerance = ((StatsViewControl)sender).Tolerance;

            CalculateTolerance(stats, tolerance);
            ((StatsViewControl)sender).SetToleranceValue();
            OnHighlightGridButtonClicked(e);
            ((StatsViewControl)sender).PartsOutOfToleranceRange = _sbOutOfBoundPart;
        }

        private void CalculateTolerance(AxisStatistics stats, double tolerance)
        {
            // canvas to be edited:
            if (tolerance == 0)
            {
                // We ignore tolerance calculation if 0 is selected for tolerance.
                return;
            }
            Chart canvasChart = GetActiveChart(stats.Axis);

            // Caclulate tolerance range...
            stats.CalculateToleranceRange(tolerance);
            //((StatsViewControl)sender).SetToleranceValue();
            _dLowerToleranceValue = stats.MinToleranceValue;
            _dUpperToleranceValue = stats.MaxToleranceValue;

            // Lets create tolerance series on the chart.
            var serUpperToleranceName = "Upper tolerance limit";
            var serLowerToleranceName = "Lower tolerance limit";

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

            for (int index = 1; index <= _data.Count; index++)
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

            _sActiveAxis = stats.Axis;

            // Need to update text in StatsView ..
            GetOutOfBoundPointsForAxis(_sActiveAxis);
        }

        public event EventHandler HighlightGridButtonClicked;
        protected virtual void OnHighlightGridButtonClicked(EventArgs e)
        {
            HighlightGridButtonClicked.Invoke(this, e);
        }
        #endregion
    }
}
