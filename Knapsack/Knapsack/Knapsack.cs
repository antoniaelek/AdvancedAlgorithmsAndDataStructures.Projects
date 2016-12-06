using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Knapsack
{
    public class Knapsack
    {
        public List<Category> Categories { get; set; }
        public Dictionary<KeyValuePair<decimal,Element>,decimal> Table { get; set; }
        public IEnumerable<decimal> Costs { get; set; }

        public Knapsack()
        {
            Categories = new List<Category>();
            Table = new Dictionary<KeyValuePair<decimal, Element>, decimal>();
            Costs = new List<decimal>();
        }

        public Knapsack(params Category[] categories) : this()
        {
            foreach (var c in categories)
            {
                Categories.Add(c);
            }
            CalculateBest();
        }

        public void Refresh()
        {
            CalculateBest();
        }

        public void PrintTable(int pad)
        {
            // Print categories header
            Console.Write("category|".PadLeft(pad));
            foreach (var category in Categories)
            {
                int n = category.Elements.Count * pad + category.Elements.Count - Categories.Count;
                Console.Write(" " + category.Name.PadLeft(n) + "|");
            }
            PrintLineSeparator(pad);

            // Print elements header
            Console.Write("element|".PadLeft(pad));
            foreach (var category in Categories)
            {
                foreach (var element in category.Elements)
                {
                    Console.Write(element.Name.PadLeft(pad) + "|");
                }
            }
            PrintLineSeparator(pad);

            // Print calculated values
            foreach (var cost in Costs)
            {
                var costStr = cost.ToString(CultureInfo.InvariantCulture) + "|";
                Console.Write(costStr.PadLeft(pad));
                foreach (var category in Categories)
                {
                    foreach (var element in category.Elements)
                    {
                        var kvp = new KeyValuePair<decimal, Element>(cost, element);
                        var dictEntry = Table.FirstOrDefault(e => e.Key.Equals(kvp));
                        Console.Write(dictEntry.Value.ToString(CultureInfo.InvariantCulture).PadLeft(pad) + "|");
                    }
                }
                Console.WriteLine();
            }
        }

        private void CalculateBest()
        {
            Table.Clear();

            var costsInit = (from category in Categories
                         from element in category.Elements
                         select element.Cost).ToList();
            Costs = GetAllSums(costsInit);

            // Set empty table keys
            foreach (var cost in Costs)
            {
                foreach (var category in Categories)
                {
                    foreach (var element in category.Elements)
                    {
                        var kvp = new KeyValuePair<decimal,Element>(cost,element);
                        Table.Add(kvp,0);
                    }
                }
            }


        }

        private IEnumerable<decimal> GetAllSums(IEnumerable<decimal> numbers)
        {
            var enumerable = numbers as decimal[] ?? numbers.ToArray();
            if (enumerable.Length <= 1) return enumerable;
            List<decimal> sums = (from n1 in enumerable
                                  from n2 in enumerable
                                  select n1 + n2).ToList();
            sums.AddRange(enumerable);
            return sums.OrderBy(s => s).Distinct();
        }

        private void PrintLineSeparator(int pad)
        {
            Console.WriteLine();
            Console.Write("+".PadLeft(pad, '-'));
            foreach (var category in Categories)
            {
                // ReSharper disable once UnusedVariable
                foreach (var element in category.Elements)
                {
                    Console.Write("+".PadLeft(pad + 1, '-'));
                }
            }
            Console.WriteLine();
        }
    }
}
