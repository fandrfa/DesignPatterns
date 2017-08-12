using System;

namespace CompoundPattern
{
    internal sealed class RubberDuck : IQuackable
    {
        private IQuackObservable observable;

        public RubberDuck()
        {
            observable = new Observable(this);
        }

        public void Quack()
        {
            Console.WriteLine("Squeak!");
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
            return "Rubber Duck";
        }
    }
}
