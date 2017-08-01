namespace AbstractFactoryPattern
{
    internal abstract class PizzaStore
    {
        public Pizza OrderPizza(string type)
        {            
            Pizza pizza = CreatePizza(type);
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            return pizza;
        }

        public abstract Pizza CreatePizza(string type);
    }
      
}
