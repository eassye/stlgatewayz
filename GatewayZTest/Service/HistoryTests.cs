using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GatewayZ.Services;

namespace GatewayZTest.Service
{
    [TestClass]
    public class HistoryTests
    {
        HistoryServices _sut;

        [TestInitialize]
        public void Setup()
        {
            _sut = new HistoryServices();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _sut = null;
        }

        [TestMethod]
        public void countFiles_ReturnCorrectNumberOfFilesInFolder()
        {
            var filePath = _sut.CountFiles(@"C:\github\GatewayZ\GatewayZTest\Images");

            int expected = 2;

            Assert.AreEqual(expected, filePath);
        }
    }
}
