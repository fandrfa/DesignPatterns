using System;
using System.Collections.Generic;

namespace AbstractFactoryPattern
{
    internal abstract class Pizza
    {
        protected string name;
        protected Dough dough;
        protected Sauce sauce;        
        protected Cheese cheese;
        protected Pepperoni pepperoni;
        protected Clams clam;

        public abstract void Prepare();

        public void Bake()
        {
            Console.WriteLine("Bake for 25 minutes at 350");
        }

        public void Cut()
        {
            Console.WriteLine("Cutting the pizza into diagonal slices");
        }

        public void Box()
        {
            Console.WriteLine("Place pizza in the official PizzaStore box");
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return "My Pizza";
        }
    }
}
