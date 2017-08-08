namespace IteratorPattern
{
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
}

