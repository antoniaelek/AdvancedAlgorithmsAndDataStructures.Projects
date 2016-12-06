using System.Collections.Generic;

namespace Knapsack
{
    public class Category
    {
        public List<Element> Elements { get; set; }
        public string Name { get; set; }

        public Category(string name, params Element[] elements)
        {
            Name = name;
            Elements = new List<Element>();
            foreach (var e in elements)
            {
                Elements.Add(e);
            }
        }
    }
}
