using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Claim
{
    public enum ClaimType { Car, House, Theft };

    class Claim
    {
        public int Id { get; set; }
        public ClaimType Type { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateOfAccident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan interval = DateOfClaim - DateOfAccident;

                if (interval.Days <= 30)
                    return true;
                else
                    return false;
            }
        }

        public Claim(int id, ClaimType type, string description, decimal amount, DateTime dateOfAccident, DateTime dateOfClaim)
        {
            Id = id;
            Type = type;
            Description = description;
            Amount = amount;
            DateOfAccident = dateOfAccident;
            DateOfClaim = dateOfClaim;
        }

        public string GetTypeAsString()
        {
            if (Type == ClaimType.Car)
                return "Car";
            else if (Type == ClaimType.House)
                return "House";
            else if (Type == ClaimType.Theft)
                return "Theft";
            else
                return null;
        }

        public string GetAmountAsString()
        {
            return string.Format("{0:C}", Amount);
        }

        public void ListClaim()
        {
            Console.WriteLine($"Claim ID: {Id}");
            Console.WriteLine($"Type: {GetTypeAsString()}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Amount: {GetAmountAsString()}");
            Console.WriteLine($"Date of Accident: {DateOfAccident.ToString("d")}");
            Console.WriteLine($"Date of Claim: {DateOfClaim.ToString("d")}");
            Console.WriteLine($"Is Valid: {IsValid}");
        }
    }
}
