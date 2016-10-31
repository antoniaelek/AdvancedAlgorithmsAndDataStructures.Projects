using System;
using System.Collections.Generic;

namespace AvlTree
{
    public class AvlTree
    {
        public sealed class Node
        {
            public int? Key { get; set; }
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

            public Node(int? key)
            {
                Key = key;
                Height = 1;
            }
        }

        public Node Root { get; set; }

        public void Print()
        {
            var counts = new HashSet<int>() { -1 };
            PrintTree(Root, null, 0, "", ref counts);
            Console.WriteLine();
        }

        public void Insert(int key)
        {
            Root = InsertInto(key, Root);
        }

        public void Delete(int? key)
        {
            Root = DeleteNode(Root, key);
        }

        private Node smallestInSubtree(Node node)
        {
            var current = node;
            while (current.Left != null)
                current = current.Left;
            return current;
        }

        public Node DeleteNode(Node root, int? key)
        {
            root = DeleteByMerging(root, key);

            // If the tree had only one node then return
            if (root == null)
                return null;

            root.Height = Max((root.Left), (root.Right)) + 1;
            var balance = root.Balance;

            //// If this node becomes unbalanced, then there are 4 cases
            //// Left Left Case
            if (balance > 1 && root.Left.Balance >= 0)
            {
                return LeftRotate(root);
            }

            // Left Right Case
            if (balance > 1 && (root.Left.Balance) < 0)
            {
                root.Left = LeftRotate(root.Left);
                return RightRotate(root);
            }

            // Right Right Case
            if (balance < -1 && (root.Right).Balance <= 0)
            {
                return LeftRotate(root);
            }

            // Right Left Case
            if (balance < -1 && (root.Right).Balance > 0)
            {
                root.Right = RightRotate(root.Right);
                return LeftRotate(root);
            }

            return root;
        }

        private Node DeleteByMerging(Node root, int? key)
        {
            if (root == null) return null;

            if (key < root.Key)
                root.Left = DeleteNode(root.Left, key);
            else if (key > root.Key)
                root.Right = DeleteNode(root.Right, key);
            else
            {
                if ((root.Left == null) || (root.Right == null))
                {
                    var temp = root.Left ?? root.Right;
                    root = temp;
                }
                else
                {
                    var temp = smallestInSubtree(root.Right);
                    root.Key = temp.Key;
                    root.Right = DeleteNode(root.Right, temp.Key);
                }
            }
            return root;
        }

        private void PrintTree(Node node, Node parent, int counter, string msg, ref HashSet<int> openCounts)
        {
            if (node == null) return;
            if (counter > 0) openCounts.Add(counter);
            
            var str0 = "";
            
            for (int i = 0; i < counter; i++)
            {
                if (openCounts.Contains(i))
                    str0 += "|   ";
                else str0 += "    ";
            }
            var str = parent != null ? str0 + "|   " : "   ";
            if (parent != null) Console.WriteLine(str);

            str = str0 + (parent != null ? "|___" : "    ") + node.Key + " ";
            Console.Write(str);

            if (!string.IsNullOrEmpty(msg))
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(msg + "(" + parent?.Key + "),");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" B=" + node.Balance + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            
                

            if (msg == "R") openCounts.RemoveWhere(el => el == counter);

            PrintTree(node.Left, node, counter+1, "L", ref openCounts);
            PrintTree(node.Right, node, counter+1, "R", ref openCounts);
        }

        private static Node InsertInto(int? key, Node node)
        {
            if (node == null) return new Node(key);
            if (key < node.Key) node.Left = InsertInto(key, node.Left);
            else node.Right = InsertInto(key, node.Right);

            node.Height = 1 + Max(node.Left, node.Right);

            return BalanceTree(key, node);
        }

        private static Node BalanceTree(int? key, Node node)
        {
            var balance = node.Balance;

            if (balance == -2 && key < node.Left.Key)
                return RightRotate(node);

            if (balance == 2 && key > node.Right.Key)
                return LeftRotate(node);

            if (balance == -2 && key > node.Left.Key)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            if (balance == 2 && key < node.Right.Key)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }

        private static Node RightRotate(Node p)
        {
            var q = p.Left;
            var qr = q.Right;

            q.Right = p;
            p.Left = qr;

            p.Height = Max(p.Left, p.Right) + 1;
            q.Height = Max(q.Left, q.Right) + 1;

            return q;
        }

        private static Node LeftRotate(Node p)
        {
            var q = p.Right;
            var ql = q.Left;

            q.Left = p;
            p.Right = ql;
            
            p.Height = Max(p.Left, p.Right) + 1;
            q.Height = Max(q.Left, q.Right) + 1;

            return q;
        }

        private static int Max(Node n1, Node n2)
        {
            if (n1 == null && n2 == null) return 0;
            if (n1 == null) return n2.Height;
            if (n2 == null) return n1.Height;
            return (n1.Height > n2.Height ? n1.Height : n2.Height);
        }
    }
}
