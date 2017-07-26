namespace DecoratorPattern
{
    internal sealed class HouseBlend : Beverage
    {
        private string description = "House Blend";
        private float cost = 0.89f;

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
