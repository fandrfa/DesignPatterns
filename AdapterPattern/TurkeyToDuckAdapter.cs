namespace AdapterPattern
{
    internal sealed class TurkeyToDuckAdapter : IDuck
    {
        private ITurkey turkey;

        public TurkeyToDuckAdapter(ITurkey turkey)
        {
            this.turkey = turkey;
        }

        public void Fly()
        {
            for (int i = 0; i < 5; i++)
            {
                turkey.Fly();
            }
        }

        public void Quack()
        {
            turkey.Gobble();
        }
    }
}
