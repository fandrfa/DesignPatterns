using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            PizzaStore nyPizzaStore = new NYPizzaStore();
            nyPizzaStore.OrderPizza("cheese");
            nyPizzaStore.OrderPizza("clam");
            nyPizzaStore.OrderPizza("pepperoni");

            Console.ReadLine();
        }
    }
}
