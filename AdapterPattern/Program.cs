using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IDuck mallardDuck = new MallardDuck();
            mallardDuck.Fly();
            mallardDuck.Quack();

            ITurkey swedenTurkey = new SwedenTurkey();
            swedenTurkey.Fly();
            swedenTurkey.Gobble();

            TurkeyToDuckAdapter turkeyDisquisedAsDuck = new TurkeyToDuckAdapter(swedenTurkey);
            turkeyDisquisedAsDuck.Fly();
            turkeyDisquisedAsDuck.Quack();

            DuckToTurkeyAdapter duckDisquisedAsTurkey = new DuckToTurkeyAdapter(mallardDuck);
            duckDisquisedAsTurkey.Fly();
            duckDisquisedAsTurkey.Gobble();

            Console.ReadLine();
        }
    }
}
