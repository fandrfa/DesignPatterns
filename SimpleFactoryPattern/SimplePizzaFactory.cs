namespace FactoryPattern
{
    internal sealed class SimplePizzaFactory
    {
        public Pizza CreatePizza(string type)
        {
            Pizza pizza = null;
            if (type == "cheese")
            {
                return new StyleCheesePizza();
            }
            else if (type == "clam")
            {
                return new StyleClamPizza();
            }
            else if (type == "veggie")
            {
                return new VeggiePizza();
            }
            else if (type == "pepperoni")
            {
                return new StylePepperoniPizza();
            }
            return pizza;
        }

    }
      
}
