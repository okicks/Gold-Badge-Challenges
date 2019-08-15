using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Cafe
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void MyTestMethod()
        {
            var repo = new MenuRepo();
            repo.SetMenuItems(Populate());

            repo.ListMenuItemsLong();
        }

        private List<MenuItem> Populate()
        {
            var items = new List<MenuItem>();

            items.Add(new MenuItem("Item 1", 1, 2.50m, "A food", new List<string>() { "Ingredient #1", "Ingredient #2", "Ingredient #3" }));
            items.Add(new MenuItem("Item 2", 2, 1.50m, "A food", new List<string>() { "Ingredient #1", "Ingredient #2", "Ingredient #3" }));
            items.Add(new MenuItem("Item 3", 3, 3.50m, "A food", new List<string>() { "Ingredient #1", "Ingredient #2", "Ingredient #3" }));

            return items;
        }
    }
}
