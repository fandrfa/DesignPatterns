namespace CommandPattern
{
    internal sealed class CeilingFanOffCommand : ICommand
    {
        private CeilingFan ceilingFan;
        private int previousSpeed;

        public CeilingFanOffCommand(CeilingFan ceilingFan)
        {            
            this.ceilingFan = ceilingFan;
        }

        public void Execute()
        {
            previousSpeed = ceilingFan.GetSpeed();
            ceilingFan.Off();
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
