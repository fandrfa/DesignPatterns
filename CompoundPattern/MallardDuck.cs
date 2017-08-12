using System;

namespace CompoundPattern
{
    internal sealed class MallardDuck : IQuackable
    {
        private IQuackObservable observable;

        public MallardDuck()
        {
            observable = new Observable(this);
        }

        public void NotifyObservers()
        {
            observable.NotifyObservers();
        }
       
        public void RegisterObserver(IObserver observer)
        {
            observable.RegisterObserver(observer);
        }

        public void Quack()
        {
            Console.WriteLine("Quack!");
            NotifyObservers();
        }

        public override string ToString()
        {
            return "Mallard Duck";
        }

    }
}
