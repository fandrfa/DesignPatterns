using System;

namespace Strategy
{
    internal sealed class NormalQuack : IQuackBehaviour
    {
        public void Quack()
        {
            Console.WriteLine("Quack!");
        }
    }
}
