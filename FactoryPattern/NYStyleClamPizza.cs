namespace FactoryPattern
{
    internal sealed class NYStyleClamPizza : Pizza
    {
        public NYStyleClamPizza()
        {
            name = "NY Style Clam Pizza";
            dough = "No dough";
            sauce = "No sauce";

            toppings.Add("No toppings");
        }
    }
      
}
