using System;

namespace Strategy
{
    internal sealed class FlyWithJetPack : IFlyBehaviour
    {
        public void Fly()
        {
            Console.WriteLine("I'm flying with a jetpack!");
        }
    }
}
