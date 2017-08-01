using System;

namespace AbstractFactoryPattern
{
    public class ThinCrustDough : Dough
    {
        public ThinCrustDough()
        {
            Console.WriteLine("  Using Thin Crust Dough");
        }        
    }
}
