using System;

namespace AdapterPattern
{
    internal sealed class MallardDuck : IDuck
    {
        public void Fly()
        {
            Console.WriteLine("I can fly");
        }

        public void Quack()
        {
            Console.WriteLine("Quack, quack");
        }
    }
}
