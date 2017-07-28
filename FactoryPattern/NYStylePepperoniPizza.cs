namespace FactoryPattern
{
    internal sealed class NYStylePepperoniPizza : Pizza
    {
        public NYStylePepperoniPizza()
        {
            name = "NY Style Pepperoni Pizza";
            dough = "No dough";
            sauce = "No sauce";

            toppings.Add("No toppings");
        }
    }
      
}
