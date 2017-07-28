namespace FactoryPattern
{
    internal sealed class NYStyleVeggiePizza : Pizza
    {
        public NYStyleVeggiePizza()
        {
            name = "NY Style Veggie Pizza";
            dough = "No dough";
            sauce = "No sauce";

            toppings.Add("No toppings");
        }
    }
      
}
