using System;

namespace CompoundPattern
{
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

            Quackologist quackologist = new Quackologist();
            flockOfDucks.RegisterObserver(quackologist);

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
}
