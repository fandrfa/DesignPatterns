namespace FactoryPattern
{
    internal sealed class StyleClamPizza : Pizza
    {
        public StyleClamPizza()
        {
            name = "Clam Pizza";
            dough = "No dough";
            sauce = "No sauce";

            toppings.Add("No toppings");
        }
    }
      
}
