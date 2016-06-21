using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GatewayZ;
using GatewayZ.Models;

namespace GatewayZTest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            User user = new User();
            user.displayName = "erick";

            var expected = "erick";

            Assert.AreEqual(user.displayName, expected);
        }
    }
}
