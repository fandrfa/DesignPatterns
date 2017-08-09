using System;
using System.Text;

namespace CommandPattern
{
    internal sealed class RemoteControl
    {
        private int numberOfSlots = 7;
        private ICommand[] onCommands;
        private ICommand[] offCommands;
        private ICommand undoCommand;

        public RemoteControl()
        {
            onCommands = new ICommand[numberOfSlots];
            offCommands = new ICommand[numberOfSlots];
            NoCommand noCommand = new NoCommand();

            for (int i = 0; i < numberOfSlots; i++)
            {
                onCommands[i] = noCommand;
                offCommands[i] = noCommand;
            }

            undoCommand = noCommand;
        }

        public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;
        }

        public void OnButtonWasPushed(int slot)
        {
            onCommands[slot].Execute();
            undoCommand = onCommands[slot];
        }

        public void OffButtonWasPushed(int slot)
        {
            offCommands[slot].Execute();
            undoCommand = offCommands[slot];
        }

        public void UndoButtonWasPushed()
        {            
            undoCommand.Undo();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < numberOfSlots; i++)
            {
                sb.Append("Slot # " + i + ": On = " + onCommands[i].GetType().ToString() + ", Off = " + offCommands[i].GetType().ToString() + Environment.NewLine);
            }

            sb.Append("Undo command = " + undoCommand.GetType().ToString());

            return sb.ToString();
        }
    }
}
