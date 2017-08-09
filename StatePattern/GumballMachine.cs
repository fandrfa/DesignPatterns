using System;

namespace StatePattern
{
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
