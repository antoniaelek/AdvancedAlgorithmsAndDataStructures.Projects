using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Knapsack;

namespace UnitTests
{
    [TestClass]
    public class ElementTests
    {
        [TestMethod]
        public void TestProperties()
        {
            var e = new Element("e",10,10);
            Assert.AreEqual(10,e.Cost);
            Assert.AreEqual(10,e.Value);
        }

        [TestMethod]
        public void TestPropertiesNegativeInput()
        {
            var e = new Element("e",-10, -10);
            Assert.AreEqual(0, e.Cost);
            Assert.AreEqual(0, e.Value);
        }
    }
}
