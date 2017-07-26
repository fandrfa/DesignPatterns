namespace DecoratorPattern
{
    internal class MochaDecorator : CondimentDecorator
    {
        public MochaDecorator(Beverage beverage) : base(beverage)
        {
            description = "Mocha";
            cost = 0.20f;
        }
    }
}
