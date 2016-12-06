using Knapsack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class CategoryTests
    {
        [TestMethod]
        public void TestEmptyCategory()
        {
            var c = new Category("empty");
            Assert.IsNotNull(c);
            Assert.IsNotNull(c.Elements);
            Assert.AreEqual(0,c.Elements.Count);
        }

        [TestMethod]
        public void TestNonEmptyCategory()
        {
            var c = new Category("nonempty", 
                new Element("e1", 10, 5),
                new Element("e2", 10, 6),
                new Element("e2", 10, 2));
            Assert.AreEqual(3, c.Elements.Count);
        }
    }
}
