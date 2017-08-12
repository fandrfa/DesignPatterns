using System;

namespace CompoundPattern
{
    internal sealed class DuckCall : IQuackable
    {
        private IQuackObservable observable;

        public DuckCall()
        {
            observable = new Observable(this);
        }

        public void Quack()
        {
            Console.WriteLine("Kwak!");
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
            return "Duck Call";
        }
    }
}
