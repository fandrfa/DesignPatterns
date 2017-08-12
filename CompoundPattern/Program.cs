using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompoundPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            DuckSimulator duckSimulator = new DuckSimulator();
            AbstractDuckFactory duckFactory = new CountingDuckFactory();            
            duckSimulator.Simulate(duckFactory);

            Console.ReadLine();
        }
    }

    internal interface IQuackable
    {
        void Quack();
    }

    internal sealed class MallardDuck : IQuackable
    {
        public void Quack()
        {
            Console.WriteLine("Quack!");
        }
    }

    internal sealed class RedheadDuck : IQuackable
    {
        public void Quack()
        {
            Console.WriteLine("Quack!");
        }
    }

    internal sealed class DuckCall : IQuackable
    {
        public void Quack()
        {
            Console.WriteLine("Kwak!");
        }
    }

    internal sealed class RubberDuck : IQuackable
    {
        public void Quack()
        {
            Console.WriteLine("Squeak!");
        }
    }

    internal sealed class DuckSimulator
    {
        public void Simulate(AbstractDuckFactory duckFactory)
        {
            IQuackable mallardDuck = duckFactory.CreateMallardDuck();
            IQuackable redheadDuck = duckFactory.CreateRedheadDuck();
            IQuackable duckCall = duckFactory.CreateDuckCall();
            IQuackable rubberDuck = duckFactory.CreateRubberDuck();
            IQuackable quackingGoose = new GooseAdapter(new Goose());

            Flock flockOfDucks = new Flock();
            flockOfDucks.Add(mallardDuck);
            flockOfDucks.Add(redheadDuck);
            flockOfDucks.Add(duckCall);
            flockOfDucks.Add(rubberDuck);
            
            Console.WriteLine("Separate Duck Simulation");
            Simulate(mallardDuck);
            Simulate(redheadDuck);
            Simulate(duckCall);
            Simulate(rubberDuck);
            Simulate(quackingGoose);
            Console.WriteLine("Flock of Ducks simulation");
            Simulate(flockOfDucks);

            Console.WriteLine("Quack counter : {0}", QuackCounter.QuackCount);
            Console.ReadLine();
        }
        public void Simulate(IQuackable duck)
        {
            duck.Quack();
        }
    }

    internal sealed class Goose
    {
        public void Honk()
        {
            Console.WriteLine("Honk!");
        }
    }

    internal sealed class GooseAdapter : IQuackable
    {
        Goose goose;

        public GooseAdapter(Goose goose)
        {
            this.goose = goose;
        }
        public void Quack()
        {
            goose.Honk();
        }
    }

    internal sealed class QuackCounter : IQuackable
    {
        public static int QuackCount { get; set; }
        private IQuackable duck;
        public QuackCounter(IQuackable duck)
        {
            this.duck = duck;
        }
        public void Quack()
        {
            QuackCount++;
            duck.Quack();
        }
    }

    internal abstract class AbstractDuckFactory
    {
        public abstract IQuackable CreateMallardDuck();
        public abstract IQuackable CreateRedheadDuck();
        public abstract IQuackable CreateDuckCall();
        public abstract IQuackable CreateRubberDuck();
    }

    internal sealed class DuckFactory : AbstractDuckFactory
    {
        public override IQuackable CreateDuckCall()
        {
            return new DuckCall();
        }        

        public override IQuackable CreateMallardDuck()
        {
            return new MallardDuck();
        }

        public override IQuackable CreateRedheadDuck()
        {
            return new RedheadDuck();
        }

        public override IQuackable CreateRubberDuck()
        {
            return new RubberDuck();
        }
    }

    internal sealed class CountingDuckFactory : AbstractDuckFactory
    {
        public override IQuackable CreateDuckCall()
        {
            return new QuackCounter(new DuckCall());
        }        

        public override IQuackable CreateMallardDuck()
        {
            return new QuackCounter(new MallardDuck());
        }

        public override IQuackable CreateRedheadDuck()
        {
            return new QuackCounter(new RedheadDuck());
        }

        public override IQuackable CreateRubberDuck()
        {
            return new QuackCounter(new RubberDuck());
        }
    }

    internal sealed class Flock : IQuackable
    {
        List<IQuackable> quackers = new List<IQuackable>();

        public void Add(IQuackable quacker)
        {
            quackers.Add(quacker);
        }

        public void Quack()
        {
            foreach (var quacker in quackers)
            {
                quacker.Quack();
            }
        }
    }
}
