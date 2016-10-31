using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AvlTree.Tests
{
    [TestClass]
    public class DeleteUnitTests
    {
        [TestMethod]
        public void DeleteNonExistentInEmptyTree()
        {
            var tree = new AvlTree();

            tree.Delete(5);

            Assert.AreEqual(null, tree.Root);
        }

        [TestMethod]
        public void DeleteRoot()
        {
            var tree = new AvlTree();
            tree.Insert(5);

            tree.Delete(5);
            
            Assert.IsNull(tree.Root);
        }

        [TestMethod]
        public void DeleteLeaf()
        {
            var tree = new AvlTree();
            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);

            tree.Delete(3);

            Assert.IsNotNull(tree.Root);
            Assert.AreEqual(2, tree.Root.Key);
            Assert.AreEqual(-1, tree.Root.Balance);

            Assert.IsNotNull(tree.Root.Left);
            Assert.AreEqual(1, tree.Root.Left.Key);
            Assert.AreEqual(0, tree.Root.Left.Balance);

            Assert.IsNull(tree.Root.Right);
        }

        [TestMethod]
        public void DeleteInside()
        {
            var tree = new AvlTree();
            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);
            tree.Insert(4);
            tree.Insert(5);

            tree.Delete(4);

            Assert.IsNotNull(tree.Root);
            Assert.AreEqual(2, tree.Root.Key);
            //Assert.AreEqual(1, tree.Root.Balance);

            Assert.IsNotNull(tree.Root.Left);
            Assert.AreEqual(1, tree.Root.Left.Key);
            //Assert.AreEqual(0, tree.Root.Left.Balance);

            Assert.IsNotNull(tree.Root.Right);
            Assert.AreEqual(5, tree.Root.Right.Key);
            //Assert.AreEqual(1, tree.Root.Right.Balance);

            Assert.IsNotNull(tree.Root.Right.Left);
            Assert.AreEqual(3, tree.Root.Right.Left.Key);

            Assert.IsNull(tree.Root.Right.Right);
           //Assert.AreEqual(0, tree.Root.Right.Right.Balance);
        }
    }
}
