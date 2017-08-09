using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            GumballMachine gumballMachine = new GumballMachine(5);

            Console.WriteLine(gumballMachine);
            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();

            Console.WriteLine(gumballMachine);

            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();

            Console.WriteLine(gumballMachine);

            Console.ReadLine();
        }
    }

    internal interface IState
    {
        void InsertQuarter();
        void EjectQuarter();
        void TurnCrank();
        void Dispense();
    }

    internal sealed class SoldState : IState
    {
        private GumballMachine gumballMachine;

        public SoldState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void Dispense()
        {
            gumballMachine.ReleaseBall();
            if (gumballMachine.Count > 0)
            {
                gumballMachine.State = gumballMachine.NoQuarterState;
            }
            else
            {
                Console.WriteLine("Oops, out of gumballs!");
                gumballMachine.State = gumballMachine.SoldOutState;
            }
        }

        public void EjectQuarter()
        {
            Console.WriteLine("Sorry, you already turned the crank");
        }

        public void InsertQuarter()
        {
            Console.WriteLine("Please wait, we are already giving you a gumball");
        }

        public void TurnCrank()
        {
            Console.WriteLine("Turning twice doesn't get you another gumball!");
        }
    }

    internal sealed class SoldOutState : IState
    {
        private GumballMachine gumballMachine;

        public SoldOutState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void Dispense()
        {
            Console.WriteLine("Sorry, we're out of gumballs");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("You can't eject, you haven't inserted your quarter yet");            
        }

        public void InsertQuarter()
        {
            Console.WriteLine("Sorry, we're out of gumballs");
        }

        public void TurnCrank()
        {
            Console.WriteLine("Sorry, we're out of gumballs");
        }
    }

    internal sealed class NoQuarterState : IState
    {
        private GumballMachine gumballMachine;

        public NoQuarterState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void Dispense()
        {
            Console.WriteLine("You need to pay first");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("You haven't inserted a quarter");
        }

        public void InsertQuarter()
        {
            Console.WriteLine("You inserted a quarter");
            gumballMachine.State = gumballMachine.HasQuarterState;
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned, but there's no quarter");
        }
    }

    internal sealed class HasQuarterState : IState
    {
        private Random random = new Random(System.DateTime.Now.Millisecond);
        private GumballMachine gumballMachine;

        public HasQuarterState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void Dispense()
        {
            Console.WriteLine("No gumball dispensed");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("Quarter returned");
            gumballMachine.State = gumballMachine.NoQuarterState;
        }

        public void InsertQuarter()
        {
            Console.WriteLine("You can't insert another quarter");
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned ...");
            int winner = random.Next(10);
            if (winner == 0 && gumballMachine.Count > 1)
            {
                gumballMachine.State = gumballMachine.WinnerState;
            }
            else
            {
                gumballMachine.State = gumballMachine.SoldState;
            }            
        }
    }

    internal sealed class WinnerState : IState
    {
        private GumballMachine gumballMachine;

        public WinnerState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void Dispense()
        {
            Console.WriteLine("You are a winner! You get two gumballs for your quarter!");
            gumballMachine.ReleaseBall();
            if (gumballMachine.Count == 0)
            {
                gumballMachine.State = gumballMachine.SoldOutState;
            }
            else
            {
                gumballMachine.ReleaseBall();
                if (gumballMachine.Count > 0)
                {
                    gumballMachine.State = gumballMachine.NoQuarterState;
                }
                else
                {
                    Console.WriteLine("Oops, are out of gumballs!");
                    gumballMachine.State = gumballMachine.SoldOutState;
                }
            }
        }

        public void EjectQuarter()
        {
            Console.WriteLine("Sorry, you already turned the crank");
        }

        public void InsertQuarter()
        {
            Console.WriteLine("Please wait, we are already giving you a gumball");
        }

        public void TurnCrank()
        {
            Console.WriteLine("Turning twice doesn't get you another gumball!");
        }        
    }

    internal sealed class GumballMachine
    {
        public IState SoldOutState { get; set; }
        public IState NoQuarterState { get; set; }
        public IState HasQuarterState { get; set; }
        public IState SoldState { get; set; }
        public IState WinnerState { get; set; }
        public int Count { get; set; }

        public IState State { get; set; }

        public GumballMachine(int numberGumballs)
        {
            SoldOutState = new SoldOutState(this);
            NoQuarterState = new NoQuarterState(this);
            HasQuarterState = new HasQuarterState(this);
            SoldState = new SoldState(this);
            WinnerState = new WinnerState(this);
            Count = numberGumballs;
            if (numberGumballs > 0)
            {
                State = NoQuarterState;
            }
        }

        public void InsertQuarter()
        {
            State.InsertQuarter();
        }

        public void EjectQuarter()
        {
            State.EjectQuarter();
        }

        public void TurnCrank()
        {
            State.TurnCrank();
            State.Dispense();
        }

        public void ReleaseBall()
        {
            Console.WriteLine("A gumball comes rolling out the slot ...");
            if (Count != 0)
            {
                Count--;
            }
        }

        public override string ToString()
        {
            string result = "";
            if (State == SoldOutState) result = "State = Sold Out";
            else if (State == NoQuarterState) result = "State = No Quarter";
            else if (State == HasQuarterState) result = "State = Has Quarter";
            else if (State == SoldState) result = "State = Sold";
            else if (State == WinnerState) result = "State = Winner";
            else result = "Error";
            return result;
        }

        public void Refill(int count)
        {
            Count = count;
            State = NoQuarterState;
        }
    }
}
