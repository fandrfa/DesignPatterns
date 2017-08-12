namespace CompoundPattern
{
    internal sealed class QuackCounter : IQuackable
    {
        public static int QuackCount { get; set; }
        private IQuackable duck;

        private IQuackObservable observable;       

        public QuackCounter(IQuackable duck)
        {
            this.duck = duck;
            observable = new Observable(this);
        }
        
        public void Quack()
        {
            QuackCount++;
            duck.Quack();
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
            return duck.ToString();
        }
    }
}
