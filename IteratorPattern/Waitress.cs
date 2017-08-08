using System;

namespace IteratorPattern
{
    internal sealed class Waitress
    {
        private PancakeHouseMenu pancakeHouseMenu;
        private DinnerMenu dinerMenu;

        public Waitress(PancakeHouseMenu pancakeHouseMenu, DinnerMenu dinnerMenu)
        {
            this.pancakeHouseMenu = pancakeHouseMenu;
            this.dinerMenu = dinnerMenu;
        }

        public bool IsItemVegetarian(string name)
        {
            throw new NotImplementedException();
        }

        public void PrintMenu()
        {
            IITerator pancakeHouseMenuIterator = pancakeHouseMenu.CreateIterator();
            Console.WriteLine("BREAKFAST");
            PrintMenu(pancakeHouseMenuIterator);
            IITerator dinerMenuIterator = dinerMenu.CreateIterator();
            Console.WriteLine("LUNCH");
            PrintMenu(dinerMenuIterator);
        }

        public void PrintMenu(IITerator iterator)
        {
            while (iterator.HasNext())
            {
                MenuItem menuItem = iterator.Next();
                PrintMenuItem(menuItem);
            }
        }        

        private void PrintMenuItem(MenuItem menuItem)
        {
            Console.Write("  " + menuItem.Name + " ");
            Console.WriteLine(menuItem.Price + " ");
            Console.WriteLine("    " + menuItem.Description);
        }
    }
}

