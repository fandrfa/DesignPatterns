namespace DecoratorPattern
{
    internal class WhipDecorator : CondimentDecorator
    {
        public WhipDecorator(Beverage beverage) : base(beverage)
        {
            description = "Whip";
            cost = 0.10f;
        }
    }
}
