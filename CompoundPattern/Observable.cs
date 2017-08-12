using System.Collections.Generic;

namespace CompoundPattern
{
    internal sealed class Observable : IQuackObservable
    {
        private List<IObserver> observers = new List<IObserver>();
        private IQuackObservable duck;

        public Observable(IQuackObservable duck)
        {
            this.duck = duck;
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(duck);
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }
    }
}
