namespace FactoryPattern
{
    internal sealed class PizzaStore
    {
        SimplePizzaFactory pizzaFactory;

        public PizzaStore(SimplePizzaFactory pizzaFactory)
        {
            this.pizzaFactory = pizzaFactory;
        }
        public Pizza OrderPizza(string type)
        {
            Pizza pizza;

            pizza = pizzaFactory.CreatePizza(type);

            pizza.prepare();
            pizza.bake();
            pizza.cut();
            pizza.box();

            return pizza;
        }
    }      
}
