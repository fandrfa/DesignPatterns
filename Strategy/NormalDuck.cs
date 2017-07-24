using System;

namespace Strategy
{
    internal sealed class NormalDuck : Duck
    {
        public NormalDuck()
        {
            flyBehaviour = new FlyWithWings();
            quackBehaviour = new NormalQuack();
        }

        internal override void Display()
        {
            Console.WriteLine("I look like a normal duck - nothing to see here!");
        }
    }
}
