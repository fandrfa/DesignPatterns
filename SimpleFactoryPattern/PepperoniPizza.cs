namespace FactoryPattern
{
    internal sealed class StylePepperoniPizza : Pizza
    {
        public StylePepperoniPizza()
        {
            name = "Pepperoni Pizza";
            dough = "No dough";
            sauce = "No sauce";

            toppings.Add("No toppings");
        }
    }
      
}
