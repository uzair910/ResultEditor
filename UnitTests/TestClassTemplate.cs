
using Moq;
using NUnit.Framework;
using ResultStudio.Common;
using ResultStudio.Controllers;
using System.Collections.Generic;
using System.IO;
using System;

namespace UnitTests
{
    public class TestClassTemplate
    {
        private ParserController parserController;
        private const string sIntialDirectory = "..\\..\\..\\TestData";
        [SetUp]
        public void Setup()
        {
            parserController = new ParserController();
        }

        [Test]
        public void Test()
        {
        }

   
    }
}
