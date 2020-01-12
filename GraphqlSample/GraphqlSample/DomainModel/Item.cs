using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlSample.DomainModel
{
    public class Item
    {
        public static List<Item> Items = new List<Item>
        {
            new Item { Id = 1, Description = "First item", Value = "X" },
            new Item { Id = 2, Description = "Second item", Value = "Y" },
            new Item { Id = 3, Description = "Third item", Value = "Z" },
        };

        public int Id { get; private set; }
        public string Description { get; set; }
        public string Value { get; set; }
    }
}
