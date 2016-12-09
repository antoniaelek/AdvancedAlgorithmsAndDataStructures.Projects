using System;
using System.Linq;

namespace Knapsack.Demo
{
    class Program
    {
        static void Main()
        {
            var k = new Knapsack(
                new Category("Albums", new Element("Rattle And Hum", 3, 30)
                                     , new Element("A Hard Day's Night", 7, 60)),
                new Category("Books", new Element("1984", 4, 50)
                                    , new Element("Anna Karenina", 3, 50)
                                    , new Element("The Bourne Identity", 5, 40)));

            //var k = new Knapsack(
            //    new Category("voce", new Element("jabuka", 3, 2), new Element("kruska", 7, 5)),
            //    new Category("povrce", new Element("krumpir", 3, 3), new Element("kupus", 4, 4)),
            //    new Category("mlijecni", new Element("jogurt", 10, 6), new Element("kefir", 6, 5),
            //                             new Element("mlijeko", 5, 4)));

            k.Run(90);
            k.PrintTable(18);
            Console.WriteLine();
            Console.WriteLine("Max value that can be achieved: " + k.GetMaxValue());
            var opt = k.GetOptimaElements();
            if (opt != null)
            {
                Console.WriteLine("Optimal items: " + string.Join(", ", opt.Select(itm => itm.Name).ToList()));
            }
        }
    }
}
