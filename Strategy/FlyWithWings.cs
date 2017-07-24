using System;

namespace Strategy
{
    internal sealed class FlyWithWings : IFlyBehaviour
    {
        public void Fly()
        {
            Console.WriteLine("I'm flying with wings!");
        }
    }
}
