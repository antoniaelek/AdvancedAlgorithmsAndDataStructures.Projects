using System.Collections.Generic;
using System.Linq;
using Knapsack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class KnapsackTests
    {
        [TestMethod]
        public void TestEmpty()
        {
            var k = new Knapsack.Knapsack();
            Assert.IsNotNull(k.Categories);
            Assert.IsNotNull(k.Table);
            Assert.AreEqual(0,k.Categories.Count);
            Assert.AreEqual(0,k.Table.Count);
        }

        [TestMethod]
        public void TestOverloadedConstructorEmpty()
        {
            var k = new Knapsack.Knapsack(new Category("c1"),new Category("c2"));
            Assert.IsNotNull(k.Categories);
            Assert.IsNotNull(k.Table);
            Assert.AreEqual(2, k.Categories.Count);
            Assert.AreEqual(0, k.Table.Count);
        }

        [TestMethod]
        public void TestCostSums()
        {
            var e1 = new Element("e1", 10, 5);
            var e2 = new Element("e2", 10, 6);
            var e3 = new Element("e3", 10, 2);
            var k = new Knapsack.Knapsack(
                new Category("c1", e1, e2),
                new Category("c2", e3));
            Assert.IsTrue(k.Table.Keys.Contains(new KeyValuePair<decimal, Element>(7,e1)));
            Assert.IsTrue(k.Table.Keys.Contains(new KeyValuePair<decimal, Element>(7,e2)));
            Assert.IsTrue(k.Table.Keys.Contains(new KeyValuePair<decimal, Element>(7,e3)));
            Assert.IsTrue(k.Table.Keys.Contains(new KeyValuePair<decimal, Element>(8,e1)));
            Assert.IsTrue(k.Table.Keys.Contains(new KeyValuePair<decimal, Element>(8,e2)));
            Assert.IsTrue(k.Table.Keys.Contains(new KeyValuePair<decimal, Element>(8,e3)));
            Assert.IsTrue(k.Table.Keys.Contains(new KeyValuePair<decimal, Element>(11,e1)));
            Assert.IsTrue(k.Table.Keys.Contains(new KeyValuePair<decimal, Element>(11,e2)));
            Assert.IsTrue(k.Table.Keys.Contains(new KeyValuePair<decimal, Element>(11,e3)));
        }
    }
}
