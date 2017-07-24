using System;

namespace Strategy
{
    internal sealed class BattleQuack : IQuackBehaviour
    {
        public void Quack()
        {
            Console.WriteLine("Phoenix Duck Battle Quack # 5 - Flame Roar!");
        }
    }
}
