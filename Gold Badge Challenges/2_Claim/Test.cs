using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Claim
{
    [TestClass]
    public class MyTestClass
    {
        private readonly Repo _repo = new Repo();

        [TestMethod]
        public void MyTestMethod()
        {
            Populate();

            _repo.ListClaims();

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
