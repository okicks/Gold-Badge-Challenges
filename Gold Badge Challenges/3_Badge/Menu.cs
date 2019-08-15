using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Badge
{
    class Menu
    {
        private readonly Dictionary<int, List<string>> _badges = new Dictionary<int, List<string>>();

        public void Run()
        {
            Populate();

            while (MainMenu())
                ToContinue();
        }

        private bool MainMenu()
        {
            Console.Clear();

            Console.WriteLine("Hello Security Admin, what would you like to do?");
            Console.WriteLine("1) Add a badge");
            Console.WriteLine("2) Edit a badge");
            Console.WriteLine("3) List all badges");
            Console.WriteLine("4) Exit\n");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Add();
                    break;

                case "2":
                    Console.Clear();
                    Edit();
                    break;

                case "3":
                    Console.Clear();
                    ListAll();
                    break;

                case "4":
                    return false;

                default:
                    Console.WriteLine("\nPlease enter a \"1\", \"2\", \"3\", or \"4\"\n");
                    break;
            }

            return true;
        }

        private void Add()
        {
            Console.Write("What's the number on the badge: ");

            string input;
            int badge;

            while (true)
            {
                input = Console.ReadLine();

                if (Int32.TryParse(input, out int b))
                {
                    badge = Int32.Parse(input);
                    break;
                }
                else
                    Console.WriteLine("\nPlease enter an integer\n");
            }

            var doors = new List<string>();

            while (true)
            {
                Console.Write("List a door the badge needs access to: ");
                doors.Add(Console.ReadLine());

                Console.Write("Any other doors (Y/N)? ");
                input = Console.ReadLine().ToLower();

                if (input == "n" || input == "no")
                    break;
                else if (input != "y" || input != "yes")
                    Console.WriteLine("\nAssumed yes\n");
            }

            int cnt = _badges.Count;

            _badges.Add(badge, doors);

            if (cnt < _badges.Count)
                Console.WriteLine("\nAdded successfully");
            else
                Console.WriteLine("\nDid not add successfully");
        }

        private void Edit()
        {
            Console.Write("What's the number on the badge: ");

            string input;
            int badge;

            while (true)
            {
                input = Console.ReadLine();

                if (Int32.TryParse(input, out int b))
                {
                    badge = Int32.Parse(input);
                    break;
                }
                else
                    Console.WriteLine("\nPlease enter an integer\n");
            }

            if (_badges.ContainsKey(badge))
            {
                Console.Write($"{badge} has access to: ");

                int i = 1;

                foreach (var door in _badges[badge])
                {
                    if (i == _badges[badge].Count)
                        Console.WriteLine(door);
                    else
                        Console.Write($"{door}, ");

                    i++;
                }

                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1) Add a door");
                Console.WriteLine("2) Remove a door\n");

                while (true)
                {
                    input = Console.ReadLine();

                    if (input == "1")
                    {
                        AddDoor(_badges[badge]);
                        break;
                    }
                    else if (input == "2")
                    {
                        RemoveDoor(_badges[badge]);
                        break;
                    }
                    else
                        Console.WriteLine("\nPlease enter a \"1\" or a \"2\"\n");
                }
            }
            else
                Console.WriteLine("\nBadge does not exist");
        }

        private void AddDoor(List<string> doors)
        {
            Console.Write("Which door would you like to add? ");

            int cnt = doors.Count;

            doors.Add(Console.ReadLine());

            if (cnt < doors.Count)
                Console.WriteLine("\nDoor was added successfully");
            else
                Console.WriteLine("\nDoor was not added successfully");
        }

        private void RemoveDoor(List<string> doors)
        {
            Console.Write("Which door would you like to remove? ");

            string input;
            int cnt = doors.Count;

            while (true)
            {
                input = Console.ReadLine();

                if (doors.Contains(input))
                {
                    doors.Remove(input);
                    break;
                }
                else
                    Console.WriteLine("\nThe door doesn't exist. Plase enter a door from above\n");
            }

            if (cnt > doors.Count)
                Console.WriteLine("\nDoor was removed successfully");
            else
                Console.WriteLine("\nDoor was not removed successfully");
        }

        private void ListAll()
        {
            Console.WriteLine("Badge #\t\tDoor Access");

            int i;

            foreach (var badge in _badges)
            {
                Console.Write($"{badge.Key}\t\t");

                i = 1;

                foreach (var door in badge.Value)
                {
                    if (i == badge.Value.Count)
                        Console.WriteLine(door);
                    else
                        Console.Write($"{door}, ");

                    i++;
                }
            }
        }

        private void ToContinue()
        {
            Console.WriteLine("\n\nPress enter to continue...");
            Console.ReadLine();
        }

        public void Populate()
        {
            _badges.Add(123, new List<string>() { "A1", "A2", "A3" });
            _badges.Add(456, new List<string>() { "A4", "A5", "A6" });
            _badges.Add(789, new List<string>() { "A7", "A8", "A9" });
        }

        public Dictionary<int, List<string>> GetBadges()
        {
            return new Dictionary<int, List<string>>(_badges);
        }
    }
}
