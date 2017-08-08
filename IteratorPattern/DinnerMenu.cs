using System;

namespace IteratorPattern
{
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
}

