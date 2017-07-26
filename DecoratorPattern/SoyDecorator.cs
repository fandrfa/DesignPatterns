namespace DecoratorPattern
{
    internal class SoyDecorator : CondimentDecorator
    {
        public SoyDecorator(Beverage beverage) : base(beverage)
        {
            description = "Soy";
            cost = 0.15f;
        }
    }
}
