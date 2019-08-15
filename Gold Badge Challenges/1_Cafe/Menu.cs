using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Cafe
{
    class Menu
    {
        private readonly MenuRepo _repo = new MenuRepo();

        public void Run()
        {
            Populate();

            while (MainMenu())
            {
                ToContinue();
            }
        }

        private bool MainMenu()
        {
            Console.Clear();

            Console.WriteLine("Please select an option:\n");
            Console.WriteLine("1) Add a menu item");
            Console.WriteLine("2) Delete a menu item");
            Console.WriteLine("3) List all menu items");
            Console.WriteLine("4) Exit");
            Console.WriteLine();

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    AddItem();
                    break;

                case "2":
                    Console.Clear();
                    DelItem();
                    break;

                case "3":
                    Console.Clear();
                    ListItems();
                    break;

                case "4":
                    return false;

                default:
                    Console.WriteLine("Not a vaild input...\nPlease select one of the numbers above");
                    break;
            }


            return true;
        }

        private void AddItem()
        {
            Console.WriteLine("What's the name of the item you'd like to add?");
            string name = Console.ReadLine();

            Console.WriteLine("\nWhat's the item number for the item?");

            string input;
            int num;

            while (true)
            {
                input = Console.ReadLine();

                if (Int32.TryParse(input, out int b))
                {
                    num = Int32.Parse(input);
                    break;
                }
                else
                    Console.WriteLine("\nPlease enter a number");
            }

            Console.WriteLine("\nWhat's the price of the item?");

            decimal price;

            while (true)
            {
                input = Console.ReadLine();

                if (Decimal.TryParse(input, out decimal b))
                {
                    price = Decimal.Parse(input);
                    break;
                }
                else
                    Console.WriteLine("\nPlease enter a number");
            }

            Console.WriteLine("\nWhat's the description for the item?");
            string desc = Console.ReadLine();

            Console.WriteLine("\nPlease add an ingredient:");
            List<string> ingreds = new List<string>();

            while (true)
            {
                ingreds.Add(Console.ReadLine());

                Console.WriteLine("\nAdd another ingredient? (Y/N)");
                input = Console.ReadLine().ToLower();

                if (input == "n" || input == "no")
                    break;

                Console.WriteLine("\nWhat's the next ingredient?");
            }

            if (_repo.AddMenuItem(new MenuItem(name, num, price, desc, ingreds)))
                Console.WriteLine("\nAdded successfully");
            else
                Console.WriteLine("\nDid not add successfully");
        }

        private void DelItem()
        {
            _repo.ListMenuItemsShort();

            Console.WriteLine("\nSelect the number you want to delete:");

            string input;
            int num;

            while (true)
            {
                input = Console.ReadLine();

                if (Int32.TryParse(input, out int b))
                {
                    num = Int32.Parse(input);

                    if (num < 1 || num > _repo.GetMenuItems().Count)
                        Console.WriteLine($"\nThe number needs to be between 1 and {_repo.GetMenuItems().Count}");
                    else
                        break;
                }
                else
                    Console.WriteLine("\nInput was not vaild. Please enter a number");
            }

            num--;

            if (_repo.DelMenuItem(_repo.GetMenuItems().ElementAt(num)))
                Console.WriteLine("\nDeleted successfully");
            else
                Console.WriteLine("\nDeletion failed");
        }

        private void ListItems()
        {
            _repo.ListMenuItemsLong();
        }

        private void ToContinue()
        {
            Console.WriteLine("\n\nPress enter to continue...");
            Console.ReadLine();
        }

        private void Populate()
        {
            var items = new List<MenuItem>();

            items.Add(new MenuItem("Item 1", 1, 2.50m, "A food", new List<string>() { "Ingredient #1", "Ingredient #2", "Ingredient #3" }));
            items.Add(new MenuItem("Item 2", 2, 1.50m, "A food", new List<string>() { "Ingredient #1", "Ingredient #2", "Ingredient #3" }));
            items.Add(new MenuItem("Item 3", 3, 3.50m, "A food", new List<string>() { "Ingredient #1", "Ingredient #2", "Ingredient #3" }));

            _repo.SetMenuItems(items);
        }
    }
}