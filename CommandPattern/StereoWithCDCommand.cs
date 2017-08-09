namespace CommandPattern
{
    internal class StereoWithCDCommand : ICommand
    {
        private Stereo stereo;

        public StereoWithCDCommand(Stereo stereo)
        {
            this.stereo = stereo;
        }
        public void Execute()
        {
            stereo.On();
            stereo.SetCD();
            stereo.SetVolume(11);
        }

        public void Undo()
        {
            stereo.Off();
        }
    }
}
