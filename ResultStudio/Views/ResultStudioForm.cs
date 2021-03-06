
using ResultStudio.Common;
using ResultStudio.Controllers;
using ResultStudio.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ResultStudio
{
    public partial class ResultStudioForm : Form
    {
        #region Private Variables
        private ResultEditorController _resultEditorController;
        private VisualRepresentationController _visualRepController;
        private StringBuilder _logBuilder;
        #endregion

        public ResultStudioForm()
        {
            InitializeComponent();
            chartTabControl.Visible = false;
            _resultEditorController = new ResultEditorController();
            _visualRepController = new VisualRepresentationController();
            // Just to keep log
            _logBuilder = new StringBuilder();
            // Zoom would be useful for chart showing all three axis altogether. 
            chartAxisData.MouseWheel += chart_MouseWheel;
            // Populate DropDown with filtered Chart types.
            BindSeriesTypesToCombo();
            lblOutOfBoundMessage.Text = Properties.Resources.sTextTolerenceHighlightMessage;
            lblOutliers.Text = Properties.Resources.sTextOutlierPart;
            lblPartOutlier.Text = Properties.Resources.sLabelTextOutlierParts;
            lblTrends.Text = Properties.Resources.sLabelTextTrends;
            ToggleToleranceControlersVisibility(false);
            ToggleTrendVisibility(false);
            ToggleButtonVisibility(false);
        }

        #region Helper methods

        /// <summary>
        /// Toggle visibility of contorls that we would require after the trends are loaded
        /// </summary>
        /// <param name="bIsVisible"> boolean value to identify if the controls should be shown or not.</param>
        private void ToggleTrendVisibility(bool isVisible)
        {
            lblTrends.Visible = txtTrendValue.Visible = isVisible;
            lblTolerance.Visible = btnTolerance.Visible = txtTolerace.Visible = isVisible;

        }

        /// <summary>
        /// Toggle visibility of contorls that we would require after the tolerance is calculated.
        /// </summary>
        /// <param name="bIsVisible"> boolean value to identify if the controls should be shown or not.</param>
        private void ToggleToleranceControlersVisibility(bool bIsVisible)
        {
            lblOutOfBoundMessage.Visible = lblOutliers.Visible = listOutOfBoundParts.Visible = lblPartOutlier.Visible = bIsVisible;
        }

        /// <summary>
        /// Toggle visibility of button contorls.
        /// </summary>
        /// <param name="bIsVisible"> boolean value to identify if the controls should be shown or not.</param>
        private void ToggleButtonVisibility(bool bIsVisible)
        {
            btnClear.Visible = btnLog.Visible = bIsVisible;
        }

        /// <summary>
        /// the method clears the grid data.
        /// </summary>
        private void ClearGrid()
        {
            dgvData.Rows.Clear();
            dgvData.Refresh();
            chartTabControl.Visible = false;

            txtTolerace.Text = string.Empty;
        }

        /// <summary>
        /// The method clears all the charts.
        /// </summary>
        private void ClearCharts()
        {
            ToggleToleranceControlersVisibility(false);
            ToggleTrendVisibility(false);
            // Normal axis chart.
            foreach (var series in chartAxisData.Series)
            {
                series.Points.Clear();
            }
            //X Axis chart
            foreach (var series in chartXAxis.Series)
            {
                series.Points.Clear();
            }
            //Y Axis chart
            foreach (var series in chartYAxis.Series)
            {
                series.Points.Clear();
            }
            //Z Axis chart
            foreach (var series in chartZAxis.Series)
            {
                series.Points.Clear();
            }

            // No point seeing empty charts, let hide the grids..
            chartTabControl.Visible = false;
        }

        /// <summary>
        /// Populate the main chart grid that shows all the axis values.
        /// </summary>
        private void PopulateChart()
        {
            string message = string.Empty; ;
            // Main chart showing all three axis together.
            _visualRepController.PopulatePointDistributionGraph(chartAxisData, out message);
            cmbSeriesCol.SelectedIndex = cmbSeriesCol.FindStringExact("Spline");
            _logBuilder.AppendLine(message);

            // load individual statistics page
            PopulateAxisPage(Properties.Resources.sAxisX);
            PopulateAxisPage(Properties.Resources.sAxisY);
            PopulateAxisPage(Properties.Resources.sAxisZ);

            // If message contains error text, maybe we can prompt that.


            // Grids are loaded, better make it visible. 
            chartTabControl.Visible = true;
            _visualRepController.HighlightGridButtonClicked += HighlightDataGrid;

            // Update the Outliers Parts:
            _visualRepController.PopulateTrendsText(ref txtTrendValue, out message);
            _logBuilder.AppendLine(message);

            ToggleTrendVisibility(true);
            // Update status bar after every process, incase there was error, it needs to be shown.
            UpdateStatus(message);
        }

        /// <summary>
        /// Update status in the bottom to indicate user to check log because an error has occured.
        /// </summary>
        /// <param name="message">Message to check error from.</param>
        private void UpdateStatus(string message)
        {
            if (message.ToUpper().Contains("ERROR"))
            {
                lblStatusBar.ForeColor = Color.Red;
                lblStatusBar.Text = message + ", " + Properties.Resources.sCheckLog;
                lblStatusBar.Visible = true;
            }
            else
            {
                lblStatusBar.Text = string.Empty;
            }
            ToggleButtonVisibility(true);
        }

        /// <summary>
        /// The method is used to populate charts specific to each axis (X,Y,Z)
        /// </summary>
        /// <param name="sAxis"> The value to identify what axis chart to populate. </param>
        private void PopulateAxisPage(string sAxis)
        {
            string message = string.Empty;
            Chart chartToBeLoaded;
            Views.StatsViewControl controlToBeLoaded;
            switch (sAxis)
            {
                case "X":
                    chartToBeLoaded = chartXAxis;
                    controlToBeLoaded = statsXAxis;
                    _visualRepController.XAxisChart = chartXAxis;
                    break;
                case "Y":
                    chartToBeLoaded = chartYAxis;
                    controlToBeLoaded = statsYAxis;
                    _visualRepController.YAxisChart = chartYAxis;
                    break;
                case "Z":
                    chartToBeLoaded = chartZAxis;
                    controlToBeLoaded = statsZAxis;
                    _visualRepController.ZAxisChart = chartZAxis;
                    break;
                default:
                    chartToBeLoaded = null;
                    controlToBeLoaded = null;
                    break;
            }

            //Populate individual Axis Grid
            if (chartToBeLoaded == null)
            {
                message = "Error: Wrong chart parameter passed to ResultsStudioForm.PopulateAxisPage";
                return;
            }
            else
            {
                _logBuilder.AppendLine("Loading chart for axis " + sAxis);
                _visualRepController.PopulateAxisGraph(sAxis, out message);
                // Lets just add mouse wheel zoom to these charts aswell. 
                chartToBeLoaded.MouseWheel += chart_MouseWheel;
            }
            _logBuilder.AppendLine(message);

            // Populate stats control for the axis
            if (controlToBeLoaded == null)
            {
                message = "Error: Failed to find related statistic control from ID that was passed from ResultsStudioForm.PopulateAxisPage";
                return;
            }
            else
            {
                _logBuilder.AppendLine("Loading statistics for axis " + sAxis);
                _visualRepController.PopulateStatisticsControl(controlToBeLoaded, sAxis, out message);
            }
            _logBuilder.AppendLine(message);

            // Update status bar after every process, incase there was error, it needs to be shown.
            UpdateStatus(message);
        }

        /// <summary>
        /// Method will be load data grid with the input read from the file.. 
        /// </summary
        private void LoadDataGrid()
        {
            BindingSource dataSet = new BindingSource();
            dgvData.DataSource = dataSet;

            if (_resultEditorController.DataSet == null)
                return;

            // Need to convert dictionary into a table/array form. Using Linq
            dataSet.DataSource = _resultEditorController.GetResultsList(); ;
            // give meaning full name to part id column.. Key doesnt seem suitable.
            dgvData.Columns["Key"].HeaderText = Properties.Resources.sPartID;
        }

        /// <summary>
        /// Method will be invoked when StatsViewController's Tolerance button will be clicked. 
        /// The method highlights axis column that are out of the tolernace range.
        /// </summary>
        private void HighlightDataGrid(object sender, EventArgs e)
        {
            string message = String.Empty;
            _visualRepController.HighlightDataGrid(ref dgvData, out message);
            _logBuilder.AppendLine(message);

            // Update the Outliers control in the UI:
            _visualRepController.PopulateOutliersText(ref listOutOfBoundParts, dgvData, out message);

            ToggleToleranceControlersVisibility(true);
            // Update status bar after every process, incase there was error, it needs to be shown.
            UpdateStatus(message);
        }

        /// <summary>
        /// Helper method to calculate tolerance for each axis.
        /// </summary>
        /// <param name="statisticControl">Active control that needs to be set.</param>
        /// <param name="dtolerance">Tolerance value</param>
        private void CalculateTolerance(StatsViewControl statisticControl, double dtolerance)
        {
            string message = string.Empty;
            if (_visualRepController.IsDataEmpty())
            {
                UpdateStatus(Properties.Resources.sErrNoData);
                return;
            }

            statisticControl.SetToleranceTextField(dtolerance);
            statisticControl.PartsOutOfToleranceRange = _visualRepController.CalculateToleranceWithGeneralValue(statisticControl.AxisStatistics, dtolerance, out message);
            statisticControl.SetToleranceValue();
            _logBuilder.AppendLine(message);
            UpdateStatus(message);
        }
        #endregion

        #region dataBinding
        private void txtTolerace_KeyPress(object sender, KeyPressEventArgs e)
        {
            // On enter press, invoke Visulaize Tolerance button event
            if (e.KeyChar == (char)13)
                btnTolerance_Click(sender, e);

            if (!(new AxisStatistics()).IsValidDecimal(e.KeyChar, txtTolerace.Text))
                e.Handled = true;
        }

        /// <summary>
        /// Calculate tolerance for all the axis.
        /// </summary>
        private void btnTolerance_Click(object sender, EventArgs e)
        {
            if (_visualRepController == null)
                return;

            var dtolerance = -1.0;
            double.TryParse(txtTolerace.Text, out dtolerance);
            if (dtolerance == 0)
            {
                (new ToolTip()).Show((Properties.Resources.sEnterValueText), txtTolerace, 3000);
                txtTolerace.Focus();
                return;
            }

            CalculateTolerance(statsXAxis, dtolerance);
            HighlightDataGrid(sender, e);

            CalculateTolerance(statsYAxis, dtolerance);
            HighlightDataGrid(sender, e);

            CalculateTolerance(statsZAxis, dtolerance);
            HighlightDataGrid(sender, e);
        }

        /// <summary>
        /// Used to read the data from file. Binded to the Open File button
        /// </summary>
        private void btnReadFile_Click(object sender, EventArgs e)
        {

            using (var fbd = new OpenFileDialog())
            {
                fbd.InitialDirectory = Path.Combine(Path.GetDirectoryName(Directory.GetCurrentDirectory()), Properties.Resources.sIntialDirectoryPath);
                fbd.Filter = "txt files (*.txt)|*.txt";

                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.FileName))
                {
                    ClearCharts();
                    ClearGrid();

                    ProcessFile(fbd.FileName);

                    //_resultEditorController.ReadFile(fbd.FileName, out message);
                    //_logBuilder.AppendLine(message);
                    //LoadDataGrid();
                    //if (_resultEditorController.DataSet == null || _resultEditorController.DataSet.Count == 0)
                    //{
                    //    UpdateStatus(Properties.Resources.sErrNoData);
                    //    return;
                    //}
                    //_visualRepController.DataSet = _resultEditorController.DataSet;
                    //PopulateChart();
                }
            }
        }

        private async void ProcessFile(string sFilePath)
        {
            
            ParserController _parser = new ParserController();
            _parser.FilePath = sFilePath;
            Task<string> parsingTask = new Task<string>(_parser.ParsingTask);
            parsingTask.Start();
            ClearCharts();
            ClearGrid();
            string logText = await parsingTask;
            _logBuilder.AppendLine(logText);
            UpdateStatus(Properties.Resources.sProcessingFileComplete);
            if (_parser.DataSet == null || _parser.DataSet.Count == 0)
            {
                UpdateStatus(Properties.Resources.sErrNoData);
                return;
            }

            _visualRepController.DataSet = _resultEditorController.DataSet = _parser.DataSet; // Should change in future to use just parser's dataset
            LoadDataGrid();
            PopulateChart();
        }

        /// <summary>
        /// The method binds all the applicable chart types to the combobox. 
        /// User can use the combobox to change the representation type of the data.
        /// </summary>
        public void BindSeriesTypesToCombo()
        {
            String[] Names = Enum.GetNames(typeof(FilteredSeriesChartType));
            cmbSeriesCol.DataSource = Names.Select((Key, Value) =>
                                        new { Key, Value }).ToDictionary(X => X.Key, X => X.Value + 1).OrderBy(i => i.Key).ToList(); ;
            cmbSeriesCol.DisplayMember = "Key";
        }

        /// <summary>
        /// Method to add zoom to the charts if mouse wheel is moved.
        /// Method implementation credits to the link: https://stackoverflow.com/questions/13584061/how-to-enable-zooming-in-microsoft-chart-control-by-using-mouse-wheel
        /// </summary>
        private void chart_MouseWheel(object sender, MouseEventArgs e)
        {
            var chart = (Chart)sender;
            var xAxis = chart.ChartAreas[0].AxisX;
            var yAxis = chart.ChartAreas[0].AxisY;
            try
            {
                if (e.Delta < 0) // Scrolled down.
                {
                    xAxis.ScaleView.ZoomReset();
                    yAxis.ScaleView.ZoomReset();
                }
                else if (e.Delta > 0) // Scrolled up.
                {
                    var xMin = xAxis.ScaleView.ViewMinimum;
                    var xMax = xAxis.ScaleView.ViewMaximum;
                    var yMin = yAxis.ScaleView.ViewMinimum;
                    var yMax = yAxis.ScaleView.ViewMaximum;

                    var posXStart = xAxis.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                    var posXFinish = xAxis.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
                    var posYStart = yAxis.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
                    var posYFinish = yAxis.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

                    xAxis.ScaleView.Zoom(posXStart, posXFinish);
                    yAxis.ScaleView.Zoom(posYStart, posYFinish);
                }
            }
            catch { }
        }

        /// <summary>
        /// Button binding to open log dialog box
        /// </summary>
        private void btnLog_Click(object sender, EventArgs e)
        {
            using (var logDialog = new LogForm(_logBuilder))
            {
                logDialog.StartPosition = FormStartPosition.CenterParent;
                DialogResult result = logDialog.ShowDialog();
            }
        }

        private Point? prevPosition = null;
        private ToolTip tooltip = new ToolTip();

        /// <summary>
        /// On mouse over the axis points, this method adds a tool tip that shows the value.
        /// </summary>
        private void chartAxisData_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = ((Chart)sender).HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var prop = result.Object as DataPoint;
                    if (prop != null)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);
                        tooltip.Show(result.Series.Name + " Value =" + prop.YValues[0], ((Chart)sender), pos.X, pos.Y - 15, 3000);
                    }
                }
            }
        }

        /// <summary>
        /// Method that is linked to clear button.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            lblOutOfBoundMessage.Visible = false;
            ClearCharts();
            ClearGrid();
            _visualRepController.Clear();
            _resultEditorController.Clear();
            _logBuilder.Append("View Cleared.");
        }

        /// <summary>
        /// This methods updates graph's representation when the combo value is changed.
        /// </summary>
        private void cmbSeriesCol_SelectedIndexChanged(object sender, EventArgs e)
        {
            _visualRepController.SetChartType(chartAxisData, ((KeyValuePair<string, int>)cmbSeriesCol.SelectedItem).Key);
        }

        #endregion

        #region Threading methods

        #endregion
    }
}
