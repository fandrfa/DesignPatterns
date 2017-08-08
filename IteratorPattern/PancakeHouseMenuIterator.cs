using System.Collections;

namespace IteratorPattern
{
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
}

