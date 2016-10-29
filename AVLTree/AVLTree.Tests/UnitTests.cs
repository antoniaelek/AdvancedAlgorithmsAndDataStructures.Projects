using Microsoft.VisualStudio.TestTools.UnitTesting;
using AVLTree;

namespace AvlTree.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void EmptyTree()
        {
            var tree = new Tree();
            Assert.AreEqual(null, tree.Root);
        }

        [TestMethod]
        public void RootOnly()
        {
            var tree = new Tree();
            tree.Root = tree.Insert(5);

            Assert.IsNotNull(tree.Root);
            Assert.AreEqual(5, tree.Root.Key);
            Assert.AreEqual(1, tree.Root.Height);
            Assert.AreEqual(0, tree.Root.Balance);

            Assert.IsNull(tree.Root.Left);

            Assert.IsNull(tree.Root.Right);
        }

        [TestMethod]
        public void RootWithLeft()
        {
            var tree = new Tree();
            tree.Root = tree.Insert(5);
            tree.Root = tree.Insert(4, tree.Root);

            Assert.IsNotNull(tree.Root);
            Assert.AreEqual(5, tree.Root.Key);
            Assert.AreEqual(2, tree.Root.Height);
            Assert.AreEqual(-1, tree.Root.Balance);

            Assert.IsNotNull(tree.Root.Left);
            Assert.AreEqual(4, tree.Root.Left.Key);
            Assert.AreEqual(1, tree.Root.Left.Height);
            Assert.AreEqual(0, tree.Root.Left.Balance);

            Assert.IsNull(tree.Root.Right);
        }

        [TestMethod]
        public void RootWithRight()
        {
            var tree = new Tree();
            tree.Root = tree.Insert(5);
            tree.Root = tree.Insert(6, tree.Root);

            Assert.IsNotNull(tree.Root);
            Assert.AreEqual(5, tree.Root.Key);
            Assert.AreEqual(2, tree.Root.Height);
            Assert.AreEqual(1, tree.Root.Balance);

            Assert.IsNull(tree.Root.Left);

            Assert.IsNotNull(tree.Root.Right);
            Assert.AreEqual(6, tree.Root.Right.Key);
            Assert.AreEqual(1, tree.Root.Right.Height);
            Assert.AreEqual(0, tree.Root.Right.Balance);
        }

        [TestMethod]
        public void RootWithLeftAndRight()
        {
            var tree = new Tree();
            tree.Root = tree.Insert(5);
            tree.Root = tree.Insert(6, tree.Root);
            tree.Root = tree.Insert(4, tree.Root);

            Assert.IsNotNull(tree.Root);
            Assert.AreEqual(5, tree.Root.Key);
            Assert.AreEqual(2, tree.Root.Height);
            Assert.AreEqual(0, tree.Root.Balance);

            Assert.IsNotNull(tree.Root.Left);
            Assert.AreEqual(4, tree.Root.Left.Key);
            Assert.AreEqual(1, tree.Root.Left.Height);
            Assert.AreEqual(0, tree.Root.Left.Balance);

            Assert.IsNotNull(tree.Root.Right);
            Assert.AreEqual(6, tree.Root.Right.Key);
            Assert.AreEqual(1, tree.Root.Right.Height);
            Assert.AreEqual(0, tree.Root.Right.Balance);
        }
    }
}
