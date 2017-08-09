namespace CommandPattern
{
    internal sealed class CeilingFanHighCommand : ICommand
    {
        private CeilingFan ceilingFan;
        private int previousSpeed;

        public CeilingFanHighCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan;
        }

        public void Execute()
        {
            previousSpeed = ceilingFan.GetSpeed();
            ceilingFan.High();
        }

        public void Undo()
        {
            if (previousSpeed == CeilingFan.HIGH)
            {
                ceilingFan.High();
            }
            if (previousSpeed == CeilingFan.MEDIUM)
            {
                ceilingFan.Medium();
            }
            if (previousSpeed == CeilingFan.LOW)
            {
                ceilingFan.Low();
            }
            if (previousSpeed == CeilingFan.OFF)
            {
                ceilingFan.Off();
            }
        }
    }
}
