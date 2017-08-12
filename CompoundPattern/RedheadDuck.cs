using System;

namespace CompoundPattern
{
    internal sealed class RedheadDuck : IQuackable
    {
        private IQuackObservable observable;

        public RedheadDuck()
        {
            observable = new Observable(this);
        }

        public void Quack()
        {
            Console.WriteLine("Quack!");
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
            return "Redhead Duck";
        }
    }
}
