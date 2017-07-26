namespace DecoratorPattern
{
    internal sealed class DarkRoast : Beverage
    {
        private string description = "Dark Roast";
        private float cost = 0.99f;

        public override string GetDescription()
        {
            return description;
        }

        public override float GetCost()
        {
            return cost;
        }
    }
}
