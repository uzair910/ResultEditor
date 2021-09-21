using NUnit.Framework;
using ResultStudio.Common;
using ResultStudio.Controllers;
using System.Collections.Generic;
using System.IO;

namespace UnitTests
{
    public class AxistStatistics_Tests
    {
        private const string _sIntialDirectory = "..\\..\\..\\TestData";
        private AxisStatistics _statisticsForXAxis;
        private AxisStatistics _statisticsForYAxis;
        private AxisStatistics _statisticsForZAxis;
        private Dictionary<int, Vector> _data = new Dictionary<int, Vector>();

        [SetUp]
        public void Setup()
        {
            var message = string.Empty;
            string sFullFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, _sIntialDirectory, "input_AxisStatisticsTest.txt");
            (new ParserController()).ParseFile(sFullFilePath, out message, out _data);
        }

        [Test, Description("Tests if the min, max, variation and average axis values are properly calculated for X axis")]
        public void Test_XAxisStatistics()
        {
            _statisticsForXAxis = new AxisStatistics("X", ref _data);
            Assert.AreEqual(_statisticsForXAxis.GetMinimumValue(), 2061.43);
            Assert.AreEqual(_statisticsForXAxis.GetMaximumValue(), 2079.14);
            Assert.AreEqual(_statisticsForXAxis.GetAverageValue(), 2069.925);
            Assert.AreEqual(_statisticsForXAxis.GetMaxPartID(), 20);
            Assert.AreEqual(_statisticsForXAxis.GetMinPartID(), 1);
            Assert.AreEqual(_statisticsForXAxis.GetVariation(), 17.71);
        }

        [Test, Description("Tests if the min, max, variation and average axis values are properly calculated for Y axis")]
        public void Test_YAxisStatistics()
        {
            _statisticsForYAxis = new AxisStatistics("Y", ref _data);
            Assert.AreEqual(_statisticsForYAxis.GetMinimumValue(), -499.98);
            Assert.AreEqual(_statisticsForYAxis.GetMaximumValue(), -419.11);
            Assert.AreEqual(_statisticsForYAxis.GetAverageValue(), -463.462);
            Assert.AreEqual(_statisticsForYAxis.GetMaxPartID(), 11);
            Assert.AreEqual(_statisticsForYAxis.GetMinPartID(), 4);
            Assert.AreEqual(_statisticsForYAxis.GetVariation(), 80.87);
        }

        [Test, Description("Tests if the min, max, variation and average axis values are properly calculated for Z axis")]
        public void Test_ZAxisStatistics()
        {
            _statisticsForZAxis = new AxisStatistics("Z", ref _data);
            Assert.AreEqual(_statisticsForZAxis.GetMinimumValue(), 352.33);
            Assert.AreEqual(_statisticsForZAxis.GetMaximumValue(), 378.72);
            Assert.AreEqual(_statisticsForZAxis.GetAverageValue(), 365.489);
            Assert.AreEqual(_statisticsForZAxis.GetMaxPartID(), 1);
            Assert.AreEqual(_statisticsForZAxis.GetMinPartID(), 20);
            Assert.AreEqual(_statisticsForZAxis.GetVariation(), 26.39);
        }

        [Test, Description("Testing the decimal validation method in statistics class.")]
        [TestCase("2", "19.7", ExpectedResult = true, Description = "Lets test with a valid decimal value in the text box, and a digit is entered.")]
        [TestCase("\b", "19.7", ExpectedResult = true, Description = "Lets test if backspace is pressed in the text box")]
        [TestCase("w", "19.7", ExpectedResult = false, Description = "Lets test with a valid decimal value in the text box, and a non numeric charactor is added.")]
        public bool Test_IsValidDecimal_Method(char keyChar, string val)
        {
            // It doesn't matter what axis object we instantize and use.
            _statisticsForXAxis = new AxisStatistics("X", ref _data);
            return _statisticsForXAxis.IsValidDecimal(keyChar, val);
        }
    }
}
