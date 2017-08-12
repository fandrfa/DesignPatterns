using System;

namespace CompoundPattern
{
    internal sealed class Quackologist : IObserver
    {
        public void Update(IQuackObservable duck)
        {
            Console.WriteLine("Quackologist: " + duck + " just quacked.");
        }
    }
}
