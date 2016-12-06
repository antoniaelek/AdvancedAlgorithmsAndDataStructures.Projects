namespace Knapsack
{
    public class Element
    {
        public decimal Value { get; }
        public decimal Cost { get; }
        public string Name { get; }

        public Element(string name, decimal value, decimal cost)
        {
            Value = value < 0 ? 0 : value;
            Cost = cost < 0 ? 0 : cost;
            Name = name;
        }
    }
}
