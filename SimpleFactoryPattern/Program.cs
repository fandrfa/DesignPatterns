using System;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SimplePizzaFactory pizzaFactory = new SimplePizzaFactory();
            PizzaStore pizzaStore = new PizzaStore(pizzaFactory);
            
            Pizza pizza = pizzaStore.OrderPizza("cheese");
            Console.WriteLine("A customer ordered a {0}", pizza.GetName());
            Console.WriteLine("");            

            Console.ReadLine();
        }
    }
      
}
