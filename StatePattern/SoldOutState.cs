using System;

namespace StatePattern
{
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
}
