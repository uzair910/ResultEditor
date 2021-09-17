
using ResultStudio.Common;
using ResultStudio.Controllers;
using ResultStudio.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ResultStudio
{
    public partial class ResultStudioForm : Form
    {
        //private const string sIntialDirectoryPath = "..\\Library\\Input";
        private ResultEditorController resultEditorController;
        private VisualRepresentationController visualRepController;

        private StringBuilder logBuilder;
        // change into a meaningful name
        private Dictionary<int, Vector> data;
        // Data source
        BindingSource dataSet;
        public ResultStudioForm()
        {
            InitializeComponent();
            chartTabControl.Visible = false;
            resultEditorController = new ResultEditorController();
            visualRepController = new VisualRepresentationController();
            logBuilder = new StringBuilder();
            chartAxisData.MouseWheel += chart_MouseWheel;
            chartXAxis.MouseWheel += chart_MouseWheel;

        }

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
                    data = resultEditorController.ReadFile(fbd.FileName, out message);
                    logBuilder.AppendLine(message);
                    LoadDataGrid();
                    visualRepController.DataSource = dataSet;
                    visualRepController.Dictionary = data;
                    PopulateChart();
                }
            }
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
        }


        #region Helper methods

        // reference: https://stackoverflow.com/questions/13584061/how-to-enable-zooming-in-microsoft-chart-control-by-using-mouse-wheel
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
        private void PopulateChart()
        {
            String message = string.Empty; ;
            visualRepController.PopulatePointDistributionGraph(ref chartAxisData, out message);
            logBuilder.AppendLine(message);

            // If message contains error text, maybe we can prompt that.


            chartTabControl.Visible = true;
        }

        private void LoadDataGrid()
        {
            dataSet = new BindingSource();
            dataGridView.DataSource = dataSet;

            if (data == null)
                return;

            // Need to convert dictionary into a table/array form. Using Linq
            var _priceDataArray = (from entry in data
                                   orderby entry.Key
                                   select new { entry.Key, entry.Value.X, entry.Value.Y, entry.Value.Z }).ToList();
            dataSet.DataSource = _priceDataArray;
            // give meaning full name to part id column.. Key doesnt seem suitable.
            dataGridView.Columns["Key"].HeaderText = Properties.Resources.sPartID;
        }
        #endregion

        private void btnLog_Click(object sender, EventArgs e)
        {
            using (var logDialog = new LogForm(logBuilder))
            {
                logDialog.StartPosition = FormStartPosition.CenterParent;
                DialogResult result = logDialog.ShowDialog();
            }
        }

        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
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
        }
    }
}
