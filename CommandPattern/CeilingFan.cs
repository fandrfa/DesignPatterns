using System;

namespace CommandPattern
{
    internal sealed class CeilingFan
    {
        public static int HIGH = 3;
        public static int MEDIUM = 2;
        public static int LOW = 1;
        public static int OFF = 0;

        private int speed;
        private string room;

        public CeilingFan(string room)
        {
            this.room = room;
            speed = OFF;
        }

        public void On()
        {
            Console.WriteLine("{0} Ceiling Fan is on, speed = {1}", room, speed);
        }

        public void Off()
        {
            speed = OFF;
            Console.WriteLine("{0} Ceiling Fan is off!", room);
        }

        public void High()
        {
            speed = HIGH;
            Console.WriteLine("{0} Ceiling Fan is on, speed = {1}", room, speed);            
        }

        public void Medium()
        {
            speed = MEDIUM;
            Console.WriteLine("{0} Ceiling Fan is on, speed = {1}", room, speed);            
        }

        public void Low()
        {            
            speed = LOW;
            Console.WriteLine("{0} Ceiling Fan is on, speed = {1}", room, speed);
        }

        public int GetSpeed()
        {
            return speed;
        }
    }
}
