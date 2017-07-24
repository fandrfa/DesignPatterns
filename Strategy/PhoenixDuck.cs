using System;

namespace Strategy
{
    internal sealed class PhoenixDuck : Duck
    {
        internal PhoenixDuck()
        {
            flyBehaviour = new FlyWithJetPack();
            quackBehaviour = new BattleQuack();
        }

        internal override void Display()
        {
            Console.WriteLine("Have you ever seen a real Phoenix Duck? Well, you see it now!");
        }
    }
}
