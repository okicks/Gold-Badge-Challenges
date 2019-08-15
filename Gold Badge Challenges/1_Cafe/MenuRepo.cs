using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Cafe
{
    class MenuRepo
    {
        private List<MenuItem> _items = new List<MenuItem>();

        public List<MenuItem> GetMenuItems()
        {
            return _items;
        }

        public void SetMenuItems(List<MenuItem> items)
        {
            _items = items;
        }

        public bool AddMenuItem(MenuItem item)
        {
            int i = _items.Count;

            _items.Add(item);

            if (i < _items.Count)
                return true;

            return false;
        }

        public bool DelMenuItem(MenuItem item)
        {
            int i = _items.Count;

            _items.Remove(item);

            if (i > _items.Count)
                return true;

            return false;
        }

        public void ListMenuItemsShort()
        {
            int i = 1;

            foreach (var item in _items)
            {
                Console.WriteLine($"{i}) Name: {item.Name}\tMeal number: {item.MealNum}");
                i++;
            }
        }

        public void ListMenuItemsLong()
        {
            int i;

            foreach (var item in _items)
            {
                Console.Write($"Name: {item.Name}");
                Console.Write($"\tMeal number: {item.MealNum}");
                Console.Write($"\tPrice: ${item.Price}");
                Console.WriteLine($"\t {item.Desc}");

                i = 1;
                foreach (var ingre in item.GetIngredients())
                {
                    Console.WriteLine($"\t\t{i}) {ingre}");
                    i++;
                }

                Console.WriteLine();
            }
        }
    }
}
