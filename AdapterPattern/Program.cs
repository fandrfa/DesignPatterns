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

    internal interface IDuck
    {
        void Quack();
        void Fly();
    }

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

    internal interface ITurkey
    {
        void Gobble();
        void Fly();
    }

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

    internal sealed class TurkeyToDuckAdapter : IDuck
    {
        private ITurkey turkey;

        public TurkeyToDuckAdapter(ITurkey turkey)
        {
            this.turkey = turkey;
        }

        public void Fly()
        {
            for (int i = 0; i < 5; i++)
            {
                turkey.Fly();
            }
        }

        public void Quack()
        {
            turkey.Gobble();
        }
    }

    internal sealed class DuckToTurkeyAdapter : ITurkey
    {
        private IDuck duck;

        public DuckToTurkeyAdapter(IDuck duck)
        {
            this.duck = duck;
        }

        public void Fly()
        {
            duck.Fly();
        }

        public void Gobble()
        {
            duck.Quack();
        }
    }
}
