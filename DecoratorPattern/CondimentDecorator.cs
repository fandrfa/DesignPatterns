namespace DecoratorPattern
{
    internal abstract class CondimentDecorator : Beverage
    {
        private Beverage beverage;
        protected string description = "Undefined condiment";
        protected float cost = 0.0f;

        public CondimentDecorator(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override float GetCost()
        {
            return beverage.GetCost() + cost;
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", " + description;
        }
    }
}
