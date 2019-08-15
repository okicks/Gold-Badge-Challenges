using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Badge
{
    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void MyTestMethod()
        {
            var menu = new Menu();

            menu.Populate();
            ListAll(menu.GetBadges());
        }

        private void ListAll(Dictionary<int, List<string>> badges)
        {
            Console.WriteLine("Badge #\t\tDoor Access");

            int i;

            foreach (var badge in badges)
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
    }
}
