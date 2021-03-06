﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Knapsack
{
    public class Knapsack
    {
        private readonly Dictionary<KeyValuePair<decimal, Element>, decimal> _table;
        public List<Category> Categories { get; set; }

        public Dictionary<KeyValuePair<decimal, Element>, decimal> Table
        {
            get { return _table; }
        }

        public Dictionary<KeyValuePair<decimal, Element>, bool> DecisionTable { get; }

        public IEnumerable<decimal> Costs { get; private set; }

        public Knapsack()
        {
            Categories = new List<Category>();
            _table = new Dictionary<KeyValuePair<decimal, Element>, decimal>();
            DecisionTable = new Dictionary<KeyValuePair<decimal, Element>, bool>();
            Costs = new List<decimal>();
        }

        public Knapsack(params Category[] categories) : this()
        {
            foreach (var c in categories)
            {
                Categories.Add(c);
            }
        }

        public decimal? GetMaxValue()
        {
            if (AlgorithmNotRun)
            {
                return 0;
            }

            // max cost == last row in table
            var maxCost = Costs.OrderByDescending(c => c).FirstOrDefault();

            // last category
            var lastCategory = Categories.Last();

            //max value in last category
            var max = Table.Where(e => lastCategory.Elements.Contains(e.Key.Value))
                .OrderByDescending(e=>e.Value).FirstOrDefault();
            return max.Value;
        }

        public List<Element> GetOptimaElements()
        {
            if (AlgorithmNotRun)
            {
                return null;
            }

            var list = new List<Element>();

           var maxCost = GetMaxValue();

            for (int i = Categories.Count - 1; i >= 0; i--)
            {
                var category = Categories[i];
                var max = Table
                    .Where(e => category.Elements.Contains(e.Key.Value))
                    .OrderByDescending(e => e.Value);
                var max2 = max.FirstOrDefault(e => e.Value <= maxCost);
                bool maxChosen = false;
                if (!DecisionTable.TryGetValue(max2.Key, out maxChosen)) continue;;
                if (maxChosen == false) continue;
                ;
                list.Add(max2.Key.Value);
                var remainingMax = max2.Value - max2.Key.Value.Value;
                maxCost = remainingMax;
                if (maxCost == 0) break;
            }


            return list;
        }

        private bool AlgorithmNotRun
        {
            get { return !Table.Any(); }
        }

        public void Run()
        {
            CalculateBest();
        }

        public void Run(decimal maxCost)
        {
            CalculateBest(maxCost);
        }

        public void PrintTable(int pad)
        {
            // Print categories header
            Console.Write("category|".PadLeft(pad));
            foreach (var category in Categories)
            {
                int n = category.Elements.Count * pad + category.Elements.Count - 1;
                Console.Write("" + category.Name.PadLeft(n) + "|");
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
            Console.WriteLine();
            Console.Write("|".PadLeft(pad));
            foreach (var category in Categories)
            {
                foreach (var element in category.Elements)
                {
                    var str = "C:" + element.Cost + " V:" + element.Value;
                    Console.Write(str.PadLeft(pad) + "|");
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

        private void CalculateBest(decimal? maxCost = null)
        {
            Table.Clear();

            // Run all possible costs
            var costsInit = (from category in Categories
                         from element in category.Elements
                         select element.Cost).ToList();
            Costs = GetAllSums(costsInit);

            if (maxCost != null)
            {
                Costs = Costs.Where(c => c <= maxCost.Value);
            }

            // Set table keys
            KnapsackAlgorithm();
        }

        private void KnapsackAlgorithm()
        {
            foreach (var cost in Costs)
            {
                int categoryIndex = 0;
                foreach (var category in Categories)
                {
                    foreach (var element in category.Elements)
                    {
                        var kvp = new KeyValuePair<decimal, Element>(cost, element);

                        decimal param1 = 0;
                        if (categoryIndex != 0)
                        {
                            var previous = Categories.ElementAtOrDefault(categoryIndex - 1);
                            param1 = MaxValueInCategory(previous, cost);
                        }

                        decimal param2 = 0;
                        if (cost - element.Cost >= 0)
                        {
                            if (cost - element.Cost > 0 && categoryIndex != 0)
                            {
                                var previous = Categories.ElementAtOrDefault(categoryIndex - 1);
                                param2 = MaxValueInCategory(previous, cost - element.Cost);
                            }
                            param2 += element.Value;
                        }

                        var max = param1 >= param2 ? param1 : param2;
                        var chosen = param1 <= param2;
                        Table.Add(kvp, max);
                        DecisionTable.Add(kvp,chosen);
                    }
                    categoryIndex++;
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

        private decimal MaxValueInCategory(Category category, decimal currentCost)
        {
            if (category == null) return 0;
            var elements = Table.Where(e => category.Elements.Contains(e.Key.Value));
            var filteredElements = elements.Where(e => e.Key.Key == currentCost);
            var enumerable = filteredElements as IList<KeyValuePair<KeyValuePair<decimal, Element>, decimal>> ?? filteredElements.ToList();
            if (!enumerable.Any()) return 0;
            return enumerable.Max(e => e.Value);
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
