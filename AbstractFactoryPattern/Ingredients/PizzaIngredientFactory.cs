namespace AbstractFactoryPattern
{
    public interface IPizzaIngredientFactory
    {
        Dough CreateDough();
        Sauce CreateSauce();
        Cheese CreateCheese();        
        Pepperoni CreatePepperoni();
        Clams CreateClam();
    }
}
