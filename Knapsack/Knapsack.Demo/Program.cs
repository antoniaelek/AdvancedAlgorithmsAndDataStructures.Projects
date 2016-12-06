using Knapsack;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            var k = new Knapsack.Knapsack(
                new Category("c1", new Element("e11", 5, 5), new Element("e12", 10, 10)),
                new Category("c2", new Element("e21", 5, 5), new Element("e22", 10, 10)));
            k.PrintTable(12);
        }
    }
}
