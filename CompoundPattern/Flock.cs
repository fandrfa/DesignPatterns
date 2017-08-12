using System.Collections.Generic;

namespace CompoundPattern
{
    internal sealed class Flock : IQuackable
    {
        private List<IQuackable> quackers = new List<IQuackable>();
        private IQuackObservable observable;

        public Flock()
        {
            observable = new Observable(this);
        }

        public void Add(IQuackable quacker)
        {
            quackers.Add(quacker);
        }

        public void Quack()
        {
            foreach (var quacker in quackers)
            {
                quacker.Quack();
            }
        }

        public void NotifyObservers()
        {
            observable.NotifyObservers();
        }

        public void RegisterObserver(IObserver observer)
        {
            foreach (var quacker in quackers)
            {
                quacker.RegisterObserver(observer);
            }
        }        
    }
}
