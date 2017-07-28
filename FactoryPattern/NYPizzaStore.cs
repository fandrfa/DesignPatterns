namespace FactoryPattern
{
    internal class NYPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(string type)
        {
            if (type == "cheese")
            {
                return new NYStyleCheesePizza();
            }
            else if (type == "clam")
            {
                return new NYStyleClamPizza();
            }
            else if (type == "veggie")
            {
                return new NYStyleVeggiePizza();
            }
            else if (type == "pepperoni")
            {
                return new NYStylePepperoniPizza();
            }
            else
            {
                return null;
            }
        }
    }
      
}
