using System;
using System.Collections.Generic;
using System.Linq;

namespace BellmanFord
{
    public class Graph
    {
        public ICollection<Edge> Edges { get; set; }

        public Graph(ICollection<Edge> edges)
        {
            Edges = edges;
        }

        public override string ToString()
        {
            string ret = "digraph G {\n";

            ret = SetVerticlesLabels(ret);

            foreach (var e in Edges)
            {
                ret += "  ";
                ret += e.Source.Name + " -> " + e.Destination.Name;
                ret += " [ label=\" " + e.Weight + " \" ];\n";
            }
            ret += "}";
            return ret;
        }

        public string ToString(ICollection<Vertex> shortest, string colour = "red")
        {
            string col = " color=\"" + colour + "\"";
            string ret = "digraph G {\n";
            
            ret = SetVerticlesLabels(ret);

            foreach (var e in Edges)
            {
                ret += "  ";
                ret += e.Source.Name;
                ret += " -> ";
                ret += e.Destination.Name;
                ret += " [";
                ret += " label=\" " + e.Weight + "\"";
                if (isOnPath(e, shortest)) ret += col;
                ret += " ];\n";
            }
            ret += "}";
            return ret;
        }

        public void BellmanFord(string sourceName)
        {
            var s = Edges.FirstOrDefault(e => e.Source.Name == sourceName)?.Source;
            if (s != null) s.Distance = 0;
            else throw new Exception("Unable to find source vertex.");

            var vs = GetVertices();
            var vertices = vs as IList<Vertex> ?? vs.ToList();

            for (int i = 1; i <= vertices.Count - 1; ++i)
            {
                foreach (var edge in Edges)
                {
                    if (edge.Source.Distance != null &&
                        (edge.Destination.Distance == null ||
                         edge.Source.Distance + edge.Weight < edge.Destination.Distance))
                    {

                        edge.Destination.Distance = edge.Source.Distance + edge.Weight;

                    }
                }
            }
        }

        public LinkedList<Vertex> ShortestPath(string startVertex, string destVertex)
        {
            var vs = GetVertices();
            var enumerable = vs as IList<Vertex> ?? vs.ToList();
            var start = enumerable.FirstOrDefault(v => v.Name == startVertex);
            var dest = enumerable.FirstOrDefault(v => v.Name == destVertex);

            if (start == default(Vertex) || dest == default(Vertex)) return new LinkedList<Vertex>();

            var lst = new LinkedList<LinkedList<Vertex>>();
            var linkedList = AllPaths(start, dest, new HashSet<Vertex>(), new Stack<Vertex>(), ref lst);
            var list = linkedList.Where(l => l.Count > 0).ToList();
            foreach (var l in list)
            {
                var sum = 0;
                for (int i = 0; i < l.Count - 1; i++)
                {
                    var prev = l.ElementAtOrDefault(i);
                    var next = l.ElementAtOrDefault(i + 1);
                    if (next?.Distance != null && prev?.Distance != null)
                    {
                        var edge = Edges.FirstOrDefault(e => e.Destination == prev && e.Source == next);
                        if (edge != null) sum +=edge.Weight;
                        else break;
                        //sum += prev.Distance.Value - next.Distance.Value;
                    }
                }
                if (sum == l.First.Value.Distance) return l;
            }
            return null;
        }

        private string SetVerticlesLabels(string ret)
        {
            foreach (var v in GetVertices())
            {
                ret += "  ";
                ret += v.Name;
                ret += "[label=<<B>";
                ret += v.Name;
                ret += "</B><BR /><FONT POINT-SIZE=\"10\">";
                ret += v.Distance == null ? "?" : v.Distance.ToString();
                ret += "</FONT>>];\n";
            }
            return ret;
        }

        private bool isOnPath(Edge e, ICollection<Vertex> path)
        {
            for (int i = 0; i < path.Count - 1; i++)
            {
                var prev = path.ElementAtOrDefault(i);
                var next = path.ElementAtOrDefault(i + 1);
                if (prev?.Name == e.Destination.Name && next?.Name == e.Source.Name) return true;
            }
            return false;
        }

        private IEnumerable<Vertex> GetVertices()
        {
            var vs = Edges.Select(e => e.Source);
            var vd = Edges.Select(e => e.Destination);
            var vertices = new HashSet<Vertex>();

            foreach (var v in vs)
                vertices.Add(v);

            foreach (var v in vd)
                vertices.Add(v);

            return vertices;
        }

        private LinkedList<LinkedList<Vertex>> AllPaths(Vertex from, Vertex to,
            HashSet<Vertex> visited, Stack<Vertex> path, ref LinkedList<LinkedList<Vertex>> paths)
        {
            // Mark the current node as visited and store in path
            visited.Add(from);
            path.Push(from);

            // If current vertex is same as destination, print current path
            if (from == to)
            {
                foreach (var vertex in path)
                {
                    if (paths.Last == null)
                    {
                        var linkedList = new LinkedList<Vertex>();
                        paths.AddLast(linkedList);
                    }
                    paths.Last.Value.AddLast(vertex);
                }
            }
            else
            {
                // If current vertex is not destinationr recur for all the vertices adjacent to this vertex
                foreach (var v in Edges.Where(e => e.Source == from).Select(e => e.Destination))
                {
                    if (!visited.Contains(v)) AllPaths(v, to, visited, path, ref paths);
                }
            }

            if (paths.Last.Value.Any()) paths.AddLast(new LinkedList<Vertex>());
            path.Pop();
            visited.Remove(from);
            return paths;
        }
    }
}
