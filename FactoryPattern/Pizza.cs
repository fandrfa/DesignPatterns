using System;
using System.Collections.Generic;

namespace FactoryPattern
{
    internal abstract class Pizza
    {
        protected string name;
        protected string dough;
        protected string sauce;
        protected List<string> toppings = new List<string>();

        public virtual void prepare()
        {
            Console.WriteLine("Preparing {0}", name);
            Console.WriteLine("Tossing dough");
            Console.WriteLine("Adding sauce");
            Console.WriteLine("Adding toppings :");
            foreach (var topping in toppings)
            {
                Console.WriteLine("  " + topping);
            }
        }

        public virtual void bake()
        {
            Console.WriteLine("Bake for 25 minutes at 350");
        }

        public virtual void cut()
        {
            Console.WriteLine("Cutting the pizza into diagonal slices");
        }

        public virtual void box()
        {
            Console.WriteLine("Place pizza in the official PizzaStore box");
        }

        public string GetName()
        {
            return name;
        }
    }
      
}
