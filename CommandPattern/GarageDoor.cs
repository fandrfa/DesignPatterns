using System;

namespace CommandPattern
{
    internal sealed class GarageDoor
    {
        public void Up()
        {
            Console.WriteLine("The door is opened");
        }

        public void Down()
        {
            Console.WriteLine("The door is closed");
        }

        public void Stop()
        {
            Console.WriteLine("The door is stopped");
        }

        public void LightOn()
        {
            Console.WriteLine("The light is on");
        }

        public void LightOff()
        {
            Console.WriteLine("The light is off");
        }
    }
}
