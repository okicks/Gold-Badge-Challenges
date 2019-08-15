using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Claim
{
    class Repo
    {
        private Queue<Claim> _claims = new Queue<Claim>();

        public Queue<Claim> GetClaims()
        {
            return new Queue<Claim>(_claims);
        }

        public void SetClaims(Queue<Claim> claims)
        {
            _claims = claims;
        }

        public bool AddClaim(Claim claim)
        {
            var size = _claims.Count;

            _claims.Enqueue(claim);

            if (size < _claims.Count)
                return true;

            return false;
        }

        public bool PopClaim()
        {
            var size = _claims.Count;

            _claims.Dequeue();

            if (size > _claims.Count)
                return true;

            return false;
        }

        public void ListClaims()
        {
            Console.WriteLine("Claim ID\tType\tDescription\tAmount\t\tDate of Accident\tDate of Claim\tIs Valid");

            foreach (Claim claim in _claims)
                Console.WriteLine($"{claim.Id}\t\t{claim.GetTypeAsString()}\t\t{claim.Description}\t{claim.GetAmountAsString()}\t{claim.DateOfAccident.ToString("d")}\t\t{claim.DateOfClaim.ToString("d")}\t{claim.IsValid}");
        }
    }
}
