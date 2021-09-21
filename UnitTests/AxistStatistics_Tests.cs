using NUnit.Framework;
using ResultStudio.Common;
using ResultStudio.Controllers;
using System.Collections.Generic;
using System.IO;


namespace UnitTests
{
    public class AxistStatistics_Tests
    {
        private const string sIntialDirectory = "..\\..\\..\\TestData";
        private AxisStatistics statisticsForXAxis;
        private AxisStatistics statisticsForYAxis;
        private AxisStatistics statisticsForZAxis;
        Dictionary<int, Vector> data = new Dictionary<int, Vector>(); 

        [SetUp]
        public void Setup()
        {
            var message = string.Empty;
            string sFullFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, sIntialDirectory, "input_AxisStatisticsTest.txt");
            (new ParserController()).ParseFile(sFullFilePath, out message, out data);
        }

        [Test, Description("Tests if the min, max, variation and average axis values are properly calculated for X axis")]
        public void TestXAxisStatistics()
        {
            statisticsForXAxis = new AxisStatistics("X", ref data);
            Assert.AreEqual(statisticsForXAxis.GetMinimumValue(), 2061.43);
            Assert.AreEqual(statisticsForXAxis.GetMaximumValue(), 2079.14);
            Assert.AreEqual(statisticsForXAxis.GetAverageValue(), 2069.925);
            Assert.AreEqual(statisticsForXAxis.GetMaxPartID(), 20);
            Assert.AreEqual(statisticsForXAxis.GetMinPartID(), 1);
            Assert.AreEqual(statisticsForXAxis.GetVariation(), 17.71); 
        }

        [Test, Description("Tests if the min, max, variation and average axis values are properly calculated for Y axis")]
        public void TestYAxisStatistics()
        {
            statisticsForYAxis = new AxisStatistics("Y", ref data);
            Assert.AreEqual(statisticsForYAxis.GetMinimumValue(), -499.98);
            Assert.AreEqual(statisticsForYAxis.GetMaximumValue(), -419.11);
            Assert.AreEqual(statisticsForYAxis.GetAverageValue(), -463.462);
            Assert.AreEqual(statisticsForYAxis.GetMaxPartID(), 11);
            Assert.AreEqual(statisticsForYAxis.GetMinPartID(), 4);
            Assert.AreEqual(statisticsForYAxis.GetVariation(), 80.87);
        }

        [Test, Description("Tests if the min, max, variation and average axis values are properly calculated for Z axis")]
        public void TestZAxisStatistics()
        {
            statisticsForZAxis = new AxisStatistics("Z", ref data);
            Assert.AreEqual(statisticsForZAxis.GetMinimumValue(), 352.33);
            Assert.AreEqual(statisticsForZAxis.GetMaximumValue(), 378.72);
            Assert.AreEqual(statisticsForZAxis.GetAverageValue(), 365.489);
            Assert.AreEqual(statisticsForZAxis.GetMaxPartID(), 1);
            Assert.AreEqual(statisticsForZAxis.GetMinPartID(), 20);
            Assert.AreEqual(statisticsForZAxis.GetVariation(), 26.39);
        }

        [Test, Description("Testing the decimal validation method in statistics class.")]
        [TestCase("2", "19.7", ExpectedResult = true, Description = "Lets test with a valid decimal value in the text box, and a digit is entered.")]
        [TestCase("\b", "19.7", ExpectedResult = true, Description = "Lets test if backspace is pressed in the text box")]
        [TestCase("w", "19.7", ExpectedResult = false, Description = "Lets test with a valid decimal value in the text box, and a non numeric charactor is added.")]
        public bool Test_IsValidDecimal_Method(char keyChar, string val)
        {
            // It doesn't matter what axis object we instantize and use.
            statisticsForXAxis = new AxisStatistics("X", ref data);
            return statisticsForXAxis.IsValidDecimal(keyChar, val);
        }

    }

}
