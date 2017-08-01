using System;

namespace AbstractFactoryPattern
{
    internal class SlicedPepperoni : Pepperoni
    {
        public SlicedPepperoni()
        {
            Console.WriteLine("  Adding Sliced Pepperoni");
        }
    }
}
