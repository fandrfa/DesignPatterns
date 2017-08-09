using System;

namespace CommandPattern
{
    internal sealed class GarageDoorStopCommand : ICommand
    {
        GarageDoor garageDoor;
        public GarageDoorStopCommand(GarageDoor garageDoor)
        {
            this.garageDoor = garageDoor;
        }

        public void Execute()
        {
            garageDoor.Up();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
