using System;

namespace AVLTree
{
    public class Tree
    {
        public sealed class Node
        {
            public int Key { get; }
            public Node Left { get; internal set; }
            public Node Right { get; internal set; }
            public int Height { get; internal set; }

            public int Balance
            {
                get
                {
                    var lh = Left?.Height ?? 0;
                    var rh = Right?.Height ?? 0;
                    return rh - lh;
                }
            }

            public Node(int key)
            {
                Key = key;
                Height = 1;
            }
        }

        public Node Root { get; set; }

        public Node Insert(int key, Node node = null)
        {
            if (node == null) return new Node(key);
            if (key < node.Key) node.Left = Insert(key, node.Left);
            else node.Right = Insert(key, node.Right);

            var lh = node.Left?.Height ?? 0;
            var rh = node.Right?.Height ?? 0;

            node.Height = 1 + (lh > rh ? lh : rh);

            SetBalance(ref node);

            return node;
        }

        public void Delete(Node node)
        {
            
        }

        private void SetBalance(ref Node node)
        {

        }

        private Node RightRotate(Node p)
        {
            throw new NotImplementedException();
        }

        private Node LeftRotate(Node p)
        {
            throw new NotImplementedException();
        }
    }
}
