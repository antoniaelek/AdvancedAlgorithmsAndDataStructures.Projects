namespace BellmanFord
{
    public class Vertex
    {
        public string Name { get; set; }
        public int? Distance { get; set; }

        public Vertex(string name)
        {
            Name = name;
        }
    }
}
