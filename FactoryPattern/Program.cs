using System;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            PizzaStore nyPizzaStore = new NYPizzaStore();
            PizzaStore chicagoPizzaStore = new ChicagoPizzaStore();

            Pizza pizza = nyPizzaStore.OrderPizza("cheese");
            Console.WriteLine("Ethan ordered a {0}", pizza.GetName());
            Console.WriteLine("");

            pizza = chicagoPizzaStore.OrderPizza("cheese");
            Console.WriteLine("Joel ordered a {0}", pizza.GetName());
            Console.WriteLine("");

            Console.ReadLine();
        }
    }
      
}
