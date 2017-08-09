using System;

namespace CommandPattern
{
    internal sealed class Light
    {
        private string room;

        public Light(string room)
        {
            this.room = room;
        }

        public void On()
        {
            Console.WriteLine("{0} Light is on!", room);
        }

        public void Off()
        {
            Console.WriteLine("{0} Light is off!", room);
        }
    }
}
