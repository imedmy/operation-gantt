using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geo1;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var result = GeoCodeCalc.CalcDistance(-37.7833, 144.9667, 52.519, 13.406);
            Assert.AreEqual(result, 9917.2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var result = GeoCodeCalc.CalcDistance(53.3428, -6.2661, 53.655, -6.686);
            Assert.AreEqual(result, 27.61);
        }
    }
}
