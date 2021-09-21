using ResultStudio.Common;
using ResultStudio.Controllers;
using NUnit.Framework;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using ResultStudio.Views;

namespace UnitTests
{
    public class VisualRepresentationControllerTests
    {
        private const string _sIntialDirectory = "..\\..\\..\\TestData";
        private const string _sDefaultFileName = "input_data_XAscending.txt";
        private VisualRepresentationController _visualRepresentationAxis;
        private AxisStatistics _visualRepresentationForYAxis;
        private AxisStatistics _visualRepresentationForZAxis;
        private Dictionary<int, Vector> _data = new Dictionary<int, Vector>();

        [SetUp]
        public void Setup()
        {
            var message = string.Empty;

        }

        [Test, Description("Lets see if the main chart is populated properly.")]
        public void Test_MainChartPopulation()
        {
            ReadFile(_sDefaultFileName);
            var message = string.Empty;
            Chart mainChart = GetTemplate_MainChart();
            _visualRepresentationAxis = new VisualRepresentationController();
            _visualRepresentationAxis.DataSet = _data;
            _visualRepresentationAxis.PopulatePointDistributionGraph(mainChart, out message);

            // If chart is populated successfully, the message will contain a success message.
            Assert.IsNotEmpty(message);
            Assert.IsTrue(message.ToUpper().Contains("SUCCESS"));
        }

        [Test, Description("Test loading axis specific charts.")]
        [TestCase("X", Description = "Test loading X Axis specific charts")]
        [TestCase("Y", Description = "Test loading Y Axis specific charts")]
        [TestCase("Z", Description = "Test loading Z Axis specific charts")]
        public void Test_AxisSpecificPopulation(string sAxisType)
        {
            ReadFile(_sDefaultFileName);
            var message = string.Empty;
            Chart axisChart = GetTemplateForAxisChart();
            _visualRepresentationAxis = new VisualRepresentationController();
            _visualRepresentationAxis.DataSet = _data;
            switch (sAxisType)
            {
                case "X":
                    _visualRepresentationAxis.XAxisChart = axisChart;
                    break;
                case "Y":
                    _visualRepresentationAxis.YAxisChart = axisChart;
                    break;
                case "Z":
                    _visualRepresentationAxis.ZAxisChart = axisChart;
                    break;
                default:
                    break;
            }
            _visualRepresentationAxis.PopulateAxisGraph(sAxisType, out message);

            // If chart is populated successfully, the message will contain a success message.
            Assert.IsNotEmpty(message);
            Assert.IsTrue(message.ToUpper().Contains("SUCCESS"));

        }

        /// <summary>
        /// Test if trends in data are properly calculated.
        /// </summary>
        /// <param name="sFileName">file to test</param>
        /// <param name="bTestForAscending">If true, test ascending pattern, if false, then test for decending pattern</param>
        [Test, Description("Test if trends in data are properly calculated.")]
        [TestCase("TestData_Asc.txt",true, Description = "This file contains all the axis data in ascending order")]
        [TestCase("TestData_Desc.txt", false, Description = "This file contains all the axis data in descending order")]
        public void Test_AxisTrends(string sFileName, bool bTestForAscending)
        {
            RichTextBox output = new RichTextBox();
            ReadFile(sFileName);
            var message = string.Empty;
            Chart mainChart = GetTemplate_MainChart();
            
            // create dummy axis charts
            Chart xAxisChart = GetTemplateForAxisChart();
            Chart YAxisChart = GetTemplateForAxisChart();
            Chart ZAxisChart = GetTemplateForAxisChart();
            StatsViewControl xStats = GetStatsViewTemplate();
            StatsViewControl yStats = GetStatsViewTemplate();
            StatsViewControl zStats = GetStatsViewTemplate();

            _visualRepresentationAxis = new VisualRepresentationController();
            _visualRepresentationAxis.DataSet = _data;
            _visualRepresentationAxis.XAxisChart = xAxisChart;
            _visualRepresentationAxis.YAxisChart = YAxisChart;
            _visualRepresentationAxis.ZAxisChart = ZAxisChart;

            _visualRepresentationAxis.PopulatePointDistributionGraph(mainChart, out message);
            Assert.IsNotEmpty(message);
            Assert.IsTrue(message.ToUpper().Contains("SUCCESS"));

            // got to test trends for each acces
            _visualRepresentationAxis.PopulateAxisGraph("X", out message);
            Assert.IsNotEmpty(message);
            Assert.IsTrue(message.ToUpper().Contains("SUCCESS"));

            _visualRepresentationAxis.PopulateAxisGraph("Y", out message);
            Assert.IsNotEmpty(message);
            Assert.IsTrue(message.ToUpper().Contains("SUCCESS"));

            _visualRepresentationAxis.PopulateAxisGraph("Z", out message);
            Assert.IsNotEmpty(message);
            Assert.IsTrue(message.ToUpper().Contains("SUCCESS"));

            _visualRepresentationAxis.PopulateTrendsText(ref output, out message);

            Assert.IsTrue(output.Text.ToUpper().Contains((bTestForAscending ? "ASCENDING ORDER OBSERVED FOR AXIS:  X" : "DESCENDING ORDER OBSERVED FOR AXIS: X")));
            Assert.IsTrue(output.Text.ToUpper().Contains((bTestForAscending ? "ASCENDING ORDER OBSERVED FOR AXIS:  Y" : "DESCENDING ORDER OBSERVED FOR AXIS: Y")));
            Assert.IsTrue(output.Text.ToUpper().Contains((bTestForAscending ? "ASCENDING ORDER OBSERVED FOR AXIS:  Z" : "DESCENDING ORDER OBSERVED FOR AXIS: Z")));
            Assert.IsTrue(message.ToUpper().Contains("SUCCESS"));

        }

        #region Helper method
        /// <summary>
        /// Read file and populate data object.
        /// </summary>
        /// <param name="fileName">Parameter to read file?</param>
        private void ReadFile(string fileName)
        {
            var message = string.Empty;
            var sFullFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, _sIntialDirectory, fileName);
            (new ParserController()).ParseFile(sFullFilePath, out message, out _data);
        }
        private Chart GetTemplateForAxisChart()
        {
            Chart chart = new Chart();
            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);
            Series series1 = new Series();
            series1.ChartArea = chartArea.Name;
            series1.ChartType = SeriesChartType.Spline;
            series1.XValueType = ChartValueType.Int32;
            series1.YValueType = ChartValueType.Double;
            chart.Series.Add(series1);
            return chart;
        }
        private StatsViewControl GetStatsViewTemplate()
        {
            StatsViewControl stats = new StatsViewControl();
            stats.AxisStatistics = null;
            return stats;
        }
        /// <summary>
        /// Helpper method to populate a dummy chart reflecting the main chart in the UI.
        /// </summary>
        /// <returns>Chart variable.</returns>
        private Chart GetTemplate_MainChart()
        {
            Chart mainChart = new Chart();
            ChartArea chartArea = new ChartArea();
            Series series1 = new Series();
            Series series2 = new Series();
            Series series3 = new Series();

            chartArea.Name = "ChartArea1";
            mainChart.ChartAreas.Add(chartArea);
            series1.ChartArea = "ChartArea1";
            series1.ChartType = SeriesChartType.Spline;
            series1.Name = "X Axis";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = SeriesChartType.Spline;
            series2.Name = "Y Axis";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = SeriesChartType.Spline;
            series3.Name = "Z Axis";
            mainChart.Series.Add(series1);
            mainChart.Series.Add(series2);
            mainChart.Series.Add(series3);

            return mainChart;
        }

        #endregion
    }
}
