using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AvlTree.Tests
{
    [TestClass]
    public class DeleteUnitTests
    {
        [TestMethod]
        public void NonExistentInEmptyTree()
        {
            var tree = new AvlTree();

            tree.Delete(5);

            Assert.AreEqual(null, tree.Root);
        }

        [TestMethod]
        public void Root()
        {
            var tree = new AvlTree();
            tree.Insert(5);

            tree.Delete(5);
            
            Assert.IsNull(tree.Root);
        }

        [TestMethod]
        public void Leaf()
        {
            var tree = new AvlTree();
            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);

            tree.Delete(3);

            #region Root

            Assert.IsNotNull(tree.Root);
            Assert.AreEqual(2, tree.Root.Key);
            Assert.AreEqual(-1, tree.Root.Balance);

            #endregion

            #region 1. level

            Assert.IsNotNull(tree.Root.Left);
            Assert.AreEqual(1, tree.Root.Left.Key);
            Assert.AreEqual(0, tree.Root.Left.Balance);

            Assert.IsNull(tree.Root.Right);

            #endregion
        }

        [TestMethod]
        public void LeftLeft()
        {
            var tree = new AvlTree();
            tree.Insert(6);
            tree.Insert(4);
            tree.Insert(7);
            tree.Insert(2);
            tree.Insert(5);
            tree.Insert(8);
            tree.Insert(1);
            tree.Insert(3);

            tree.Delete(8);

            #region Root

            Assert.IsNotNull(tree.Root);
            Assert.AreEqual(4, tree.Root.Key);
            Assert.AreEqual(0, tree.Root.Balance);

            #endregion

            #region 1. level

            Assert.IsNotNull(tree.Root.Left);
            Assert.AreEqual(2, tree.Root.Left.Key);
            Assert.AreEqual(0, tree.Root.Left.Balance);

            Assert.IsNotNull(tree.Root.Right);
            Assert.AreEqual(6, tree.Root.Right.Key);
            Assert.AreEqual(0, tree.Root.Right.Balance);

            #endregion

            #region 2. level

            Assert.IsNotNull(tree.Root.Left.Left);
            Assert.AreEqual(1, tree.Root.Left.Left.Key);
            Assert.AreEqual(0, tree.Root.Left.Left.Balance);

            Assert.IsNotNull(tree.Root.Left.Right);
            Assert.AreEqual(3, tree.Root.Left.Right.Key);
            Assert.AreEqual(0, tree.Root.Left.Right.Balance);

            Assert.IsNotNull(tree.Root.Right.Left);
            Assert.AreEqual(5, tree.Root.Right.Left.Key);
            Assert.AreEqual(0, tree.Root.Right.Left.Balance);

            Assert.IsNotNull(tree.Root.Right.Right);
            Assert.AreEqual(7, tree.Root.Right.Right.Key);
            Assert.AreEqual(0, tree.Root.Right.Right.Balance);

            #endregion

        }

        [TestMethod]
        public void LeftRight()
        {
            var tree = new AvlTree();
            tree.Insert(8);
            tree.Insert(3);
            tree.Insert(9);
            tree.Insert(1);
            tree.Insert(5);
            tree.Insert(10);
            tree.Insert(4);
            tree.Insert(7);

            tree.Delete(10);

            #region Root

            Assert.IsNotNull(tree.Root);
            Assert.AreEqual(5, tree.Root.Key);
            Assert.AreEqual(0, tree.Root.Balance);

            #endregion

            #region 1. level

            Assert.IsNotNull(tree.Root.Left);
            Assert.AreEqual(3, tree.Root.Left.Key);
            Assert.AreEqual(0, tree.Root.Left.Balance);

            Assert.IsNotNull(tree.Root.Right);
            Assert.AreEqual(8, tree.Root.Right.Key);
            Assert.AreEqual(0, tree.Root.Right.Balance);

            #endregion

            #region 2. level

            Assert.IsNotNull(tree.Root.Left.Left);
            Assert.AreEqual(1, tree.Root.Left.Left.Key);
            Assert.AreEqual(0, tree.Root.Left.Left.Balance);

            Assert.IsNotNull(tree.Root.Left.Right);
            Assert.AreEqual(4, tree.Root.Left.Right.Key);
            Assert.AreEqual(0, tree.Root.Left.Right.Balance);

            Assert.IsNotNull(tree.Root.Right.Left);
            Assert.AreEqual(7, tree.Root.Right.Left.Key);
            Assert.AreEqual(0, tree.Root.Right.Left.Balance);

            Assert.IsNotNull(tree.Root.Right.Right);
            Assert.AreEqual(9, tree.Root.Right.Right.Key);
            Assert.AreEqual(0, tree.Root.Right.Right.Balance);

            #endregion

        }

        [TestMethod]
        public void RightRight()
        {
            var tree = new AvlTree();
            tree.Insert(2);
            tree.Insert(1);
            tree.Insert(4);
            tree.Insert(0);
            tree.Insert(3);
            tree.Insert(6);
            tree.Insert(5);
            tree.Insert(8);

            tree.Delete(0);

            #region Root

            Assert.IsNotNull(tree.Root);
            Assert.AreEqual(4, tree.Root.Key);
            Assert.AreEqual(0, tree.Root.Balance);

            #endregion

            #region 1. level

            Assert.IsNotNull(tree.Root.Left);
            Assert.AreEqual(2, tree.Root.Left.Key);
            Assert.AreEqual(0, tree.Root.Left.Balance);

            Assert.IsNotNull(tree.Root.Right);
            Assert.AreEqual(6, tree.Root.Right.Key);
            Assert.AreEqual(0, tree.Root.Right.Balance);

            #endregion

            #region 2. level

            Assert.IsNotNull(tree.Root.Left.Left);
            Assert.AreEqual(1, tree.Root.Left.Left.Key);
            Assert.AreEqual(0, tree.Root.Left.Left.Balance);

            Assert.IsNotNull(tree.Root.Left.Right);
            Assert.AreEqual(3, tree.Root.Left.Right.Key);
            Assert.AreEqual(0, tree.Root.Left.Right.Balance);

            Assert.IsNotNull(tree.Root.Right.Left);
            Assert.AreEqual(5, tree.Root.Right.Left.Key);
            Assert.AreEqual(0, tree.Root.Right.Left.Balance);

            Assert.IsNotNull(tree.Root.Right.Right);
            Assert.AreEqual(8, tree.Root.Right.Right.Key);
            Assert.AreEqual(0, tree.Root.Right.Right.Balance);

            #endregion

        }

        [TestMethod]
        public void RightLeft()
        {
            var tree = new AvlTree();
            tree.Insert(2);
            tree.Insert(1);
            tree.Insert(10);
            tree.Insert(0);
            tree.Insert(8);
            tree.Insert(12);
            tree.Insert(6);
            tree.Insert(9);

            tree.Delete(0);

            #region Root

            Assert.IsNotNull(tree.Root);
            Assert.AreEqual(8, tree.Root.Key);
            Assert.AreEqual(0, tree.Root.Balance);

            #endregion

            #region 1. level

            Assert.IsNotNull(tree.Root.Left);
            Assert.AreEqual(2, tree.Root.Left.Key);
            Assert.AreEqual(0, tree.Root.Left.Balance);

            Assert.IsNotNull(tree.Root.Right);
            Assert.AreEqual(10, tree.Root.Right.Key);
            Assert.AreEqual(0, tree.Root.Right.Balance);

            #endregion

            #region 2. level

            Assert.IsNotNull(tree.Root.Left.Left);
            Assert.AreEqual(1, tree.Root.Left.Left.Key);
            Assert.AreEqual(0, tree.Root.Left.Left.Balance);

            Assert.IsNotNull(tree.Root.Left.Right);
            Assert.AreEqual(6, tree.Root.Left.Right.Key);
            Assert.AreEqual(0, tree.Root.Left.Right.Balance);

            Assert.IsNotNull(tree.Root.Right.Left);
            Assert.AreEqual(9, tree.Root.Right.Left.Key);
            Assert.AreEqual(0, tree.Root.Right.Left.Balance);

            Assert.IsNotNull(tree.Root.Right.Right);
            Assert.AreEqual(12, tree.Root.Right.Right.Key);
            Assert.AreEqual(0, tree.Root.Right.Right.Balance);

            #endregion

        }
    }
}
