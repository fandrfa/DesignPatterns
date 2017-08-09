namespace AdapterPattern
{
    internal sealed class DuckToTurkeyAdapter : ITurkey
    {
        private IDuck duck;

        public DuckToTurkeyAdapter(IDuck duck)
        {
            this.duck = duck;
        }

        public void Fly()
        {
            duck.Fly();
        }

        public void Gobble()
        {
            duck.Quack();
        }
    }
}
