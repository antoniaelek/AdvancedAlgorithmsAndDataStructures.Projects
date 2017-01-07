using System;
using System.Collections.Generic;

namespace BellmanFord
{
    public class Program
    {
        
        static void Main()
        {
            var from = "a";
            var to = "d";
            var graph = TestCase1();

            graph.BellmanFord(from);
            var shortest = graph.ShortestPath(from, to);
            Console.WriteLine(graph.ToString(shortest));
         }

        private static Graph TestCase1()
        {
            var a = new Vertex("a");
            var b = new Vertex("b");
            var c = new Vertex("c");
            var d = new Vertex("d");

            var ab = new Edge(a, b, 5);
            var ac = new Edge(a, c, 4);
            var bc = new Edge(b, c, -2);
            var bd = new Edge(b, d, 3);
            var cd = new Edge(c, d, 4);

            return new Graph(new List<Edge> { ab, ac, bc, bd, cd });
        }

        private static Graph TestCase2()
        {
            var a = new Vertex("a");
            var b = new Vertex("b");
            var c = new Vertex("c");
            var d = new Vertex("d");
            var e = new Vertex("e");
            var f = new Vertex("f");
            var g = new Vertex("g");
            var h = new Vertex("h");
            var i = new Vertex("i");
            var j = new Vertex("j");
            var k = new Vertex("k");
            var l = new Vertex("l");
            var m = new Vertex("m");
            var n = new Vertex("n");
            var o = new Vertex("o");
            var p = new Vertex("p");
            var r = new Vertex("r");
            var s = new Vertex("s");

            var edges = new List<Edge>
            {
                new Edge(a, b, 2),
                new Edge(a, c, 6),
                new Edge(a, d, 12),

                new Edge(b, c, 3),
                new Edge(b, e, 9),

                new Edge(c, f, 1),

                new Edge(d, h, -2),

                new Edge(e, g, -1),

                new Edge(f, h, 4),

                new Edge(g, i, 2),

                new Edge(h, i, 3),
                new Edge(h, k, 1),
                new Edge(h, l, -3),
                new Edge(h, m, -2),

                new Edge(i, j, -1),

                new Edge(j, n, 5),

                new Edge(k, j, 1),
                new Edge(k, o, -9),

                new Edge(l, p, 7),

                new Edge(m, l, 2),

                new Edge(n, o, 1),
                new Edge(n, s, -9),

                new Edge(o, s, 11),

                new Edge(p, s, -6),

                new Edge(r, s, 3),
            };

            return new Graph(edges);
        }
    }
}
