namespace CommandPattern
{
    internal sealed class SimpleRemoteControl
    {
        private ICommand slot;
        public SimpleRemoteControl()
        {

        }
        public void SetCommand(ICommand command)
        {
            slot = command;
        }
        public void ButtonWasPressed()
        {
            slot.Execute();
        }
    }
}
