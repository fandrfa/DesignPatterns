namespace FactoryPattern
{
    internal sealed class StyleCheesePizza : Pizza
    {
        public StyleCheesePizza()
        {
            name = "Cheese Pizza";
            dough = "Thin Crust Dough";
            sauce = "Marinara Sauce";

            toppings.Add("Grated Reggiano Cheese");      
        }
    }
      
}
