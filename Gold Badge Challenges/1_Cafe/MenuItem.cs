using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Cafe
{
    class MenuItem
    {
        private readonly List<string> _ingredients = new List<string>();

        public int MealNum { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public decimal Price { get; set; }

        public MenuItem(string name, int mealNumber, decimal price, string description, List<string> ingredients)
        {
            Name = name;
            MealNum = mealNumber;
            Price = price;
            Desc = description;
            _ingredients = ingredients;
        }

        public List<string> GetIngredients()
        {
            return new List<string>(_ingredients);
        }
    }
}
