using System;

namespace AbstractFactoryPattern
{
    internal class ClamPizza : Pizza
    {
        IPizzaIngredientFactory pizzaIngredientFactory;

        public ClamPizza(IPizzaIngredientFactory pizzaIngredientFactory)
        {
            this.pizzaIngredientFactory = pizzaIngredientFactory;

        }
        public override void Prepare()
        {
            Console.WriteLine("Preparing {0}", name);
            dough = pizzaIngredientFactory.CreateDough();
            sauce = pizzaIngredientFactory.CreateSauce();            
            clam = pizzaIngredientFactory.CreateClam();
        }
    }
}
