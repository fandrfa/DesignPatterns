namespace CommandPattern
{
    internal sealed class CeilingFanOnCommand : ICommand
    {
        private CeilingFan ceilingFan;
        public CeilingFanOnCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan;
        }

        public void Execute()
        {
            ceilingFan.On();
        }

        public void Undo()
        {
            ceilingFan.Off();
        }
    }
}
