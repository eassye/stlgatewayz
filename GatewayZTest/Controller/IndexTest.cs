using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GatewayZ.Controllers.Web;
using System.Web.Mvc;

namespace GatewayZTest.Controller
{
    [TestClass]
    public class IndexTest
    {
        private AppController _sut;

        [TestInitialize]
        public void Startup()
        {
            _sut = new AppController();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _sut = null;
        }

        //[TestMethod]
        //public void TestingIndexControllerReturnsPartialView()
        //{
        //    //var expected = _sut.Index() as ViewResult;
        //}
    }
}
