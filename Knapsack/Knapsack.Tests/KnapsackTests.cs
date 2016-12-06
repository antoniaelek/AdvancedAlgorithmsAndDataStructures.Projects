using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Knapsack.Tests
{
    [TestClass]
    public class KnapsackTests
    {
        [TestMethod]
        public void TestEmpty()
        {
            var k = new Knapsack();
            Assert.IsNotNull(k.Categories);
            Assert.IsNotNull(k.Table);
            Assert.AreEqual(0,k.Categories.Count);
            Assert.AreEqual(0,k.Table.Count);
        }

        [TestMethod]
        public void TestOverloadedConstructorEmpty()
        {
            var k = new Knapsack(new Category("c1"),new Category("c2"));
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
            var k = new Knapsack(
                new Category("c1", e1, e2),
                new Category("c2", e3));
            k.Run();
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

        [TestMethod]
        public void TestAlgorithm()
        {
            var e1 = new Element("jabuka", 3, 2);
            var e2 = new Element("kruska", 7, 5);
            var e3 = new Element("krumpir", 3, 3);
            var e4 = new Element("kupus", 4, 4);
            var e5 = new Element("jogurt", 10, 6);
            var e6 = new Element("kefir", 6, 5);
            var e7 = new Element("mlijeko", 5, 4);
            var k = new Knapsack(
                new Category("voce", e1, e2),
                new Category("povrce", e3, e4),
                new Category("mlijecni", e5, e6, e7));
            k.Run(10);
            Assert.IsTrue(k.Table.Keys.Contains(new KeyValuePair<decimal, Element>(10, e5)));
            decimal val;
            Assert.IsTrue(k.Table.TryGetValue(new KeyValuePair<decimal, Element>(10, e5),out val));
            Assert.AreEqual(14,val);
        }
    }
}
