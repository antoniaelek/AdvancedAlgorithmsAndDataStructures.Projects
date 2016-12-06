namespace Knapsack.Demo
{
    class Program
    {
        static void Main()
        {
            //var k = new Knapsack(
            //    new Category("c1", new Element("e11", 5, 5), new Element("e12", 10, 10)),
            //    new Category("c2", new Element("e21", 5, 5), new Element("e22", 10, 10)));

            var k = new Knapsack(
                new Category("voce", new Element("jabuka", 3, 2), new Element("kruska", 7, 5)),
                new Category("povrce", new Element("krumpir", 3, 3), new Element("kupus", 4, 4)),
                new Category("mlijecni", new Element("jogurt", 10, 6), new Element("kefir", 6, 5),
                                         new Element("mlijeko", 5, 4)));
            k.Run(10);
            k.PrintTable(12);
        }
    }
}
