namespace BellmanFord
{
    public class Edge
    {
        public Vertex Source { get; set; }
        public Vertex Destination { get; set; }
        public int Weight { get; set; }

        public Edge(Vertex source, Vertex destination, int weight)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
        }
    }
}
