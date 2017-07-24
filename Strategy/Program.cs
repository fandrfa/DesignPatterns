using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    internal sealed class Program
    {
        static void Main(string[] args)
        {
            Duck normalDuck = new NormalDuck();
            Console.WriteLine("Hi! I'm a normal duck. I can quack and fly. Look:");
            normalDuck.Quack();
            normalDuck.Fly();
            Console.WriteLine();

            Duck phoenixDuck = new PhoenixDuck();
            Console.WriteLine("And I'm a glorious phoenix duck! I'm designed for battles. Look what I can do:");
            phoenixDuck.Fly();
            phoenixDuck.Quack();
            Console.WriteLine();
            
            phoenixDuck.SetFlyBehaviour(new FlyWithWings());
            phoenixDuck.SetQuackBehaviour(new NormalQuack());
            Console.WriteLine("Oh, now, the phoenix duck was demoted to a normal duck! Look how its flying and quacking methods were changed:");
            phoenixDuck.Fly();
            phoenixDuck.Quack();

            Console.ReadLine();
        }
    }
}
