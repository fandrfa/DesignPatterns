namespace FactoryPattern
{
    internal class ChicagoPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(string type)
        {
            if (type == "cheese")
            {
                return new ChicagoStyleCheesePizza();
            }           
            else
            {
                return null;
            }
        }
    }
      
}
