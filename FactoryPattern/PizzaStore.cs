namespace FactoryPattern
{
    internal abstract class PizzaStore
    {
        public Pizza OrderPizza(string type)
        {            
            Pizza pizza = CreatePizza(type);
            pizza.prepare();
            pizza.bake();
            pizza.cut();
            pizza.box();

            return pizza;
        }

        protected abstract Pizza CreatePizza(string type);
    }
      
}
