using System;

namespace StatePattern
{
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
}
