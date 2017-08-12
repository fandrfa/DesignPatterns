namespace CompoundPattern
{
    internal sealed class GooseAdapter : IQuackable
    {
        private IQuackObservable observable;
        private Goose goose;

        public GooseAdapter(Goose goose)
        {
            this.goose = goose;
            observable = new Observable(this);
        }

        public void Quack()
        {
            goose.Honk();
            NotifyObservers();
        }

        public void NotifyObservers()
        {
            observable.NotifyObservers();
        }

        public void RegisterObserver(IObserver observer)
        {
            observable.RegisterObserver(observer);
        }

        public override string ToString()
        {
            return "Goose";
        }
    }
}
