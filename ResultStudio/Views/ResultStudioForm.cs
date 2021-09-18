
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
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;

namespace ResultStudio
{
    public partial class ResultStudioForm : Form
    {
        #region Private Variables
        private ResultEditorController resultEditorController;
        private VisualRepresentationController visualRepController;
        private StringBuilder logBuilder;
        #endregion

        public ResultStudioForm()
        {
            InitializeComponent();
            chartTabControl.Visible = false;
            resultEditorController = new ResultEditorController();
            visualRepController = new VisualRepresentationController();
            // Just to keep log
            logBuilder = new StringBuilder();
            // Zoom would be useful for chart showing all three axis altogether. 
            chartAxisData.MouseWheel += chart_MouseWheel;
            // Populate DropDown with filtered Chart types.
            BindSeriesTypesToCombo(typeof(FilteredSeriesChartType), cmbSeriesCol);
        }

        #region Helper methods
        private void ClearGrid()
        {
            dgvData.Rows.Clear();
            dgvData.Refresh();
            chartTabControl.Visible = false;
        }

        private void ClearCharts()
        {
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

        private void PopulateChart()
        {
            string message = string.Empty; ;
            // Main chart showing all three axis together.
            visualRepController.PopulatePointDistributionGraph(chartAxisData, out message);
            cmbSeriesCol.SelectedIndex = cmbSeriesCol.FindStringExact("Spline");
            logBuilder.AppendLine(message);

            // load individual statistics page
            PopulateAxisPage(Properties.Resources.sAxisX);
            PopulateAxisPage(Properties.Resources.sAxisY);
            PopulateAxisPage(Properties.Resources.sAxisZ);

            // If message contains error text, maybe we can prompt that.
            if (message.Contains("Error")) { }

            // Grids are loaded, better make it visible. 
            chartTabControl.Visible = true;
        }

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
                    visualRepController.XAxisChart = chartXAxis;
                    break;
                case "Y":
                    chartToBeLoaded = chartYAxis;
                    controlToBeLoaded = statsYAxis;
                    visualRepController.YAxisChart = chartYAxis;
                    break;
                case "Z":
                    chartToBeLoaded = chartZAxis;
                    controlToBeLoaded = statsZAxis;
                    visualRepController.ZAxisChart = chartZAxis;
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
            }
            else
            {
                logBuilder.AppendLine("Loading chart for axis " + sAxis);
                visualRepController.PopulateAxisGraph(sAxis, out message);
                // Lets just add mouse wheel zoom to these charts aswell. 
                chartToBeLoaded.MouseWheel += chart_MouseWheel;
            }
            logBuilder.AppendLine(message);

            // Populate stats control for the axis
            if (controlToBeLoaded == null)
            {
                message = "Error: Failed to find related statistic control from ID that was passed from ResultsStudioForm.PopulateAxisPage";
            }
            else
            {
                logBuilder.AppendLine("Loading statistics for axis " + sAxis);
                visualRepController.PopulateStatisticsControl(controlToBeLoaded, sAxis, out message);
            }
            logBuilder.AppendLine(message);
        }

        private void LoadDataGrid()
        {
            BindingSource dataSet = new BindingSource();
            dgvData.DataSource = dataSet;

            if (resultEditorController.DataSet == null)
                return;

            // Need to convert dictionary into a table/array form. Using Linq
            var _priceDataArray = (from entry in resultEditorController.DataSet
                                   orderby entry.Key
                                   select new { entry.Key, entry.Value.X, entry.Value.Y, entry.Value.Z }).ToList();
            dataSet.DataSource = _priceDataArray;
            // give meaning full name to part id column.. Key doesnt seem suitable.
            dgvData.Columns["Key"].HeaderText = Properties.Resources.sPartID;
        }
        #endregion

        #region dataBinding
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
                    String message;
                    resultEditorController.ReadFile(fbd.FileName, out message);
                    logBuilder.AppendLine(message);
                    LoadDataGrid();
                    visualRepController.DataSet =  resultEditorController.DataSet;
                    PopulateChart();
                }
            }
        }

        public void BindSeriesTypesToCombo(Type EnumType, ComboBox comboSeries)
        {
            String[] Names = Enum.GetNames(EnumType);
            comboSeries.DataSource = Names.Select((Key, Value) =>
                                        new { Key, Value }).ToDictionary(X => X.Key, X => X.Value + 1).OrderBy(i => i.Key).ToList(); ;

            comboSeries.DisplayMember = "Key";
        }
        private void chart_MouseWheel(object sender, MouseEventArgs e)
        {
            // Code snippet taken from reference: https://stackoverflow.com/questions/13584061/how-to-enable-zooming-in-microsoft-chart-control-by-using-mouse-wheel
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
        private void btnLog_Click(object sender, EventArgs e)
        {
            using (var logDialog = new LogForm(logBuilder))
            {
                logDialog.StartPosition = FormStartPosition.CenterParent;
                DialogResult result = logDialog.ShowDialog();
            }
        }

        private Point? prevPosition = null;
        private ToolTip tooltip = new ToolTip();
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
                        tooltip.Show(result.Series.Name + " Value =" + prop.YValues[0], ((Chart)sender), pos.X, pos.Y - 15);
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearCharts();
            ClearGrid();
        }

        private void cmbSeriesCol_SelectedIndexChanged(object sender, EventArgs e)
        {
            visualRepController.SetChartType(chartAxisData, ((KeyValuePair<string, int>)cmbSeriesCol.SelectedItem).Key);
        }

        #endregion
    

    }
}
