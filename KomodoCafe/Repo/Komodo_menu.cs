using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepository
{
    public class Menu
    {
        public int ItemNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Price { get; set; }

        public Menu() { }

        public Menu(int itemNumber, string name, string description, string ingredients, string price)
        {
            ItemNumber = itemNumber;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }

    }
}