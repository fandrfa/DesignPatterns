namespace AbstractFactoryPattern
{
    internal class NYPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(string type)
        {
            Pizza pizza = null;
            IPizzaIngredientFactory pizzaIngredientFactory = new NYPizzaIngredientFactory();

            if (type == "cheese")
            {
                pizza = new CheesePizza(pizzaIngredientFactory);
                pizza.SetName("New York Style Cheese Pizza");
            }
            else if (type == "clam")
            {
                pizza = new ClamPizza(pizzaIngredientFactory);
                pizza.SetName("New York Style Clam Pizza");
            }
            else if (type == "pepperoni")
            {
                pizza = new PepperoniPizza(pizzaIngredientFactory);
                pizza.SetName("New York Style Pepperoni Pizza");
            }
            else
            {
                return null;
            }
            return pizza;                
        }
    }
      
}
