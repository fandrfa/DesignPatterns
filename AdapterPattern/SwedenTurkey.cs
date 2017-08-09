using System;

namespace AdapterPattern
{
    internal sealed class SwedenTurkey : ITurkey
    {
        public void Fly()
        {
            Console.WriteLine("I'm flying on a short distance");
        }

        public void Gobble()
        {
            Console.WriteLine("Gobble, gobble");
        }
    }
}
