using System;

namespace AbstractFactoryPattern
{
    internal class PepperoniPizza : Pizza
    {
        IPizzaIngredientFactory pizzaIngredientFactory;

        public PepperoniPizza(IPizzaIngredientFactory pizzaIngredientFactory)
        {
            this.pizzaIngredientFactory = pizzaIngredientFactory;

        }
        public override void Prepare()
        {
            Console.WriteLine("Preparing {0}", name);
            dough = pizzaIngredientFactory.CreateDough();
            sauce = pizzaIngredientFactory.CreateSauce();            
            pepperoni = pizzaIngredientFactory.CreatePepperoni();
        }
    }
}
