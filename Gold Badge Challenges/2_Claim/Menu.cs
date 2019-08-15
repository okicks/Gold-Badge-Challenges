using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Claim
{
    class Menu
    {
        private readonly Repo _repo = new Repo();

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

            Console.WriteLine("Choose a menu item:");
            Console.WriteLine("1) See all claims");
            Console.WriteLine("2) Take care of next claim");
            Console.WriteLine("3) Enter a new claim");
            Console.WriteLine("4) Exit\n");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    ListClaims();
                    break;

                case "2":
                    Console.Clear();
                    DealWithClaim();
                    break;

                case "3":
                    Console.Clear();
                    AddClaim();
                    break;

                case "4":
                    return false;

                default:
                    Console.WriteLine("Please enter a number between 1 and 4");
                    break;
            }

            return true;
        }

        private void ListClaims()
        {
            _repo.ListClaims();
        }

        private void DealWithClaim()
        {
            Console.WriteLine("Here are the details for the next claim to be handled:\n");

            _repo.GetClaims().ElementAt(0).ListClaim();

            Console.WriteLine("\nDo you want to deal with this claim now? (Y/N)");
            string input;

            while (true)
            {
                input = Console.ReadLine().ToLower();

                if (input == "y" || input == "yes")
                {
                    if (_repo.PopClaim())
                        Console.WriteLine("\nThe claim was dealt with");
                    else
                        Console.WriteLine("\nThe claim was not dealt with");
                    break;

                }
                else if (input == "n" || input == "no")
                {
                    Console.WriteLine("\nThe claim was not dealt with");
                    break;
                }
                else
                    Console.WriteLine("\nPlease enter a \"Y\" or a \"N\"");
            }
        }

        private void AddClaim()
        {
            Console.Write("Enter the claim ID: ");

            string input;
            int id;

            while (true)
            {
                input = Console.ReadLine();

                if (Int32.TryParse(input, out int b))
                {
                    id = Int32.Parse(input);
                    break;
                }
                else
                    Console.WriteLine("\nPlease enter an integer");
            }

            Console.Write("Enter the claim type (Car/House/Theft): ");

            ClaimType type;

            while (true)
            {
                input = Console.ReadLine().ToLower();

                if (input == "car")
                {
                    type = ClaimType.Car;
                    break;
                }
                else if (input == "house")
                {
                    type = ClaimType.House;
                    break;
                }
                else if (input == "theft")
                {
                    type = ClaimType.Theft;
                    break;
                }
                else
                    Console.WriteLine("\nPlease enter \"Car\", \"House\", or \"Theft\"");
            }

            Console.Write("Enter a claim description: ");
            string desc = Console.ReadLine();

            Console.Write("Amount of damage: ");

            decimal amount;

            while (true)
            {
                input = Console.ReadLine();

                if (input.StartsWith("$"))
                    input = input.Substring(1);

                if (Decimal.TryParse(input, out decimal b))
                {
                    amount = Decimal.Parse(input);
                    break;
                }
                else
                    Console.WriteLine("\nPlease enter a number");
            }

            Console.Write("Date of accident: ");

            DateTime dOA;

            while (true)
            {
                input = Console.ReadLine();

                if (DateTime.TryParse(input, out DateTime b))
                {
                    dOA = DateTime.Parse(input);
                    break;
                }
                else
                    Console.WriteLine("\nPlease enter a date in the form mm/dd/yy");
            }

            Console.Write("Date of claim: ");

            DateTime dOC;

            while (true)
            {
                input = Console.ReadLine();

                if (DateTime.TryParse(input, out DateTime b))
                {
                    dOC = DateTime.Parse(input);
                    break;
                }
                else
                    Console.WriteLine("\nPlease enter a date in the form mm/dd/yy");
            }

            if (_repo.AddClaim(new Claim(id, type, desc, amount, dOA, dOC)))
                Console.WriteLine("This claim is valid");
            else
                Console.WriteLine("This claim is not valid");
        }

        private void ToContinue()
        {
            Console.WriteLine("\n\nPress enter to continue...");
            Console.ReadLine();
        }

        private void Populate()
        {
            var queue = new Queue<Claim>();

            queue.Enqueue(new Claim(1, ClaimType.Car, "aaa", 20000m, new DateTime(2019, 6, 25), new DateTime(2019, 7, 2)));
            queue.Enqueue(new Claim(2, ClaimType.House, "aaa", 50000m, new DateTime(2019, 7, 25), new DateTime(2019, 8, 30)));
            queue.Enqueue(new Claim(3, ClaimType.Theft, "aaa", 5000m, new DateTime(2019, 6, 25), new DateTime(2019, 7, 25)));

            _repo.SetClaims(queue);
        }
    }
}
