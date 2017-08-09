using System;

namespace CommandPattern
{
    internal sealed class Stereo
    {
        private string room;
        private float volume;

        public Stereo(string room)
        {
            this.room = room;
        }

        public void On()
        {
            Console.WriteLine("{0} Stereo is on", room);
        }

        public void Off()
        {
            Console.WriteLine("{0} Stereo is off", room);
        }

        public void SetCD()
        {
            Console.WriteLine("{0} The mode is set on CD", room);
        }

        public void SetRadio()
        {
            Console.WriteLine("0} The mode is set on Radio", room);
        }

        public void SetDVD()
        {
            Console.WriteLine("0} The mode is set on DVD", room);
        }

        public void SetVolume(float volume)
        {
            this.volume = volume;            
        }
    }
}
