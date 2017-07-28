namespace FactoryPattern
{
    internal sealed class VeggiePizza : Pizza
    {
        public VeggiePizza()
        {
            name = "Veggie Pizza";
            dough = "No dough";
            sauce = "No sauce";

            toppings.Add("No toppings");
        }
    }
      
}
