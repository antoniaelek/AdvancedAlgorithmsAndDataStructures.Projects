namespace Knapsack
{
    public class Element
    {
        private readonly decimal _value;
        private readonly decimal _cost;
        private readonly string _name;

        public decimal Value
        {
            get { return _value; }
        }

        public decimal Cost
        {
            get { return _cost; }
        }

        public string Name
        {
            get { return _name; }
        }

        public Element(string name, decimal value, decimal cost)
        {
            _value = value < 0 ? 0 : value;
            _cost = cost < 0 ? 0 : cost;
            _name = name;
        }
    }
}
