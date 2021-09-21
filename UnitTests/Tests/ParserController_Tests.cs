using NUnit.Framework;
using ResultStudio.Common;
using ResultStudio.Controllers;
using System.Collections.Generic;
using System.IO;

namespace UnitTests
{
    public class ParserController_Tests
    {
        private ParserController parserController;
        private const string sIntialDirectory = "..\\..\\TestData";

        [SetUp]
        public void Setup()
        {
            parserController = new ParserController();
        }
    
        [TestCase("Input_Data1.txt", Description = "Test reading and parsing method with a valid file.")]
        public void Test_FileRead(string sFileName)
        {
            var message = string.Empty;
            string sFullFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, sIntialDirectory, sFileName);
            Dictionary<int, Vector> data;
            parserController.ParseFile(sFullFilePath, out message, out data);

            Assert.IsNotNull(data);
            Assert.That(data.Count > 0);
            Assert.IsFalse(message.ToUpper().Contains("ERROR"));
        }

        [TestCase("Input_File_Doesnt_Exist.txt", Description = "Test reading and parsing method with a file that doesnot exist in the directory.")]
        public void Test_FileRead_InvalidCases(string sFileName)
        {
            var message = string.Empty;
            string sFullFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, sIntialDirectory, sFileName);
            Dictionary<int, Vector> data;
            parserController.ParseFile(sFullFilePath, out message, out data);

            Assert.IsNotNull(data);
            Assert.That(data.Count == 0);
            Assert.IsTrue(message.ToUpper().Contains("ERROR"));
        }
    }
}
