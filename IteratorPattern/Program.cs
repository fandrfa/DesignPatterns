using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            PancakeHouseMenu pancakeHouseMenu = new PancakeHouseMenu();
            DinnerMenu dinnerMenu = new DinnerMenu();

            Waitress waitress = new Waitress(pancakeHouseMenu, dinnerMenu);
            waitress.PrintMenu();
            //waitress.PrintBreakfastMenu();
            //waitress.PrintLunchMenu();
            //waitress.PrintVegetarianMenu();

            Console.ReadLine();
        }
    }

    internal sealed class MenuItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsVegetarian { get; set; }
        public double Price { get; set; }

        public MenuItem(string name, string description, bool isVegetarian, double price)
        {
            Name = name;
            Description = description;
            IsVegetarian = isVegetarian;
            Price = price;
        }
    }

    internal sealed class PancakeHouseMenu
    {
        private ArrayList menuItems;

        public PancakeHouseMenu()
        {
            menuItems = new ArrayList();
            AddItem("K & B’s Pancake Breakfast", "Pancakes with scrambled eggs, and toast", true, 2.99);
            AddItem("Regular Pancake Breakfast", "Pancakes with fried eggs, sausage", false, 2.99);
            AddItem("Blueberry Pancakes", "Pancakes made with fresh blueberries", true, 3.49);
            AddItem("Waffles", "Waffles, with your choice of blueberries or strawberries", true, 3.59);
        }
        public void AddItem(string name, string description, bool vegetarian, double price)
        {
            MenuItem menuItem = new MenuItem(name, description, vegetarian, price);
            menuItems.Add(menuItem);
        }
        
        public PancakeHouseMenuIterator CreateIterator()
        {
            return new PancakeHouseMenuIterator(menuItems);
        }
    }

    internal sealed class DinnerMenu
    {
        private int MAX_ITEMS = 6;
        public int NumberOfItems { get; set; }

        private MenuItem[] menuItems;

        public DinnerMenu()
        {
            MAX_ITEMS = 6;
            menuItems = new MenuItem[MAX_ITEMS];
            AddItem("Vegetarian BLT", "(Fakin’) Bacon with lettuce & tomato on whole wheat", true, 2.99);
            AddItem("BLT", "Bacon with lettuce & tomato on whole wheat", false, 2.99);
            AddItem("Soup of the day", "Soup of the day, with a side of potato salad", false, 3.29);
            AddItem("Hotdog", "A hot dog, with saurkraut, relish, onions, topped with cheese", false, 3.05);
        }

        public void AddItem(string name, string description, bool vegetarian, double price)
        {
            MenuItem menuItem = new MenuItem(name, description, vegetarian, price);

            if (NumberOfItems >= MAX_ITEMS)
            {
                Console.WriteLine("Sorry, menu is full! Can’t add item to menu");
            }
            else
            {
                menuItems[NumberOfItems] = menuItem;
                NumberOfItems = NumberOfItems + 1;
            }
        }

        public DinnerMenuIterator CreateIterator()
        {
            return new DinnerMenuIterator(menuItems);
        }
    }

    internal interface IITerator
    {
        bool HasNext();
        MenuItem Next();
    }

    internal sealed class DinnerMenuIterator : IITerator
    {
        private MenuItem[] items;
        private int position = 0;

        public DinnerMenuIterator(MenuItem[] items)
        {
            this.items = items;
        }
        public bool HasNext()
        {
            if (position >= items.Length || items[position] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public MenuItem Next()
        {
            MenuItem menuItem = items[position];
            position++;
            return menuItem;
        }
    }

    internal sealed class PancakeHouseMenuIterator : IITerator
    {
        private ArrayList items;
        private int position;

        public PancakeHouseMenuIterator(ArrayList items)
        {
            this.items = items;
        }

        public bool HasNext()
        {
            if (position >= items.Count || items[position] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public MenuItem Next()
        {
            MenuItem menuItem = (MenuItem)items[position];
            position++;
            return menuItem;
        }
    }

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

        //public void PrintBreakfastMenu()
        //{
        //    Console.WriteLine("Breakfast Menu:");
        //    PancakeHouseMenuIterator pancakeHouseMenuIterator = pancakeHouseMenu.CreateIterator();
        //    while (pancakeHouseMenuIterator.HasNext())
        //    {
        //        MenuItem menuItem = pancakeHouseMenuIterator.Next();
        //        PrintMenuItem(menuItem);
        //    }
        //}

        //public void PrintLunchMenu()
        //{
        //    Console.WriteLine("Dinner Menu:");

        //    DinnerMenuIterator dinnerMenuIterator = dinnerMenu.CreateIterator();
        //    while (dinnerMenuIterator.HasNext())
        //    {
        //        MenuItem menuItem = dinnerMenuIterator.Next();
        //        PrintMenuItem(menuItem);
        //    }
        //}

        //public void PrintMenu()
        //{
        //    PrintBreakfastMenu();

        //    PrintLunchMenu();
        //}

        //public void PrintVegetarianMenu()
        //{
        //    Console.WriteLine("Vegetarian Menu:");
        //    PancakeHouseMenuIterator pancakeHouseMenuIterator = pancakeHouseMenu.CreateIterator();
        //    while (pancakeHouseMenuIterator.HasNext())
        //    {
        //        MenuItem menuItem = pancakeHouseMenuIterator.Next();
        //        if (menuItem.IsVegetarian)
        //        {
        //            PrintMenuItem(menuItem);
        //        }                
        //    }

        //    DinnerMenuIterator dinnerMenuIterator = dinnerMenu.CreateIterator();
        //    while (dinnerMenuIterator.HasNext())
        //    {
        //        MenuItem menuItem = dinnerMenuIterator.Next();
        //        if (menuItem.IsVegetarian)
        //        {
        //            PrintMenuItem(menuItem);
        //        }
        //    }
        //}

        private void PrintMenuItem(MenuItem menuItem)
        {
            Console.Write("  " + menuItem.Name + " ");
            Console.WriteLine(menuItem.Price + " ");
            Console.WriteLine("    " + menuItem.Description);
        }
    }
}

