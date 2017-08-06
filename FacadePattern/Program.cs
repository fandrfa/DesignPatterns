using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Projector projector = new Projector();
            BluRayPlayer bluRayPlayer = new BluRayPlayer();

            HomeTheatreFacade homeTheatre = new HomeTheatreFacade(projector, bluRayPlayer);
            homeTheatre.PlayMovie();
            homeTheatre.StopMovie();

            Console.ReadLine();
        }
    }

    internal sealed class Projector
    {
        public void On()
        {
            Console.WriteLine("Projector is on");
        }

        public void Off()
        {
            Console.WriteLine("Projector is off");
        }
    }

    internal sealed class BluRayPlayer
    {
        public void On()
        {
            Console.WriteLine("Blu-Ray player is on");
        }

        public void Off()
        {
            Console.WriteLine("Blu-Ray player is off");
        }
    }

    internal sealed class HomeTheatreFacade
    {
        Projector projector;
        BluRayPlayer bluRayPlayer;

        public HomeTheatreFacade(Projector projector, BluRayPlayer bluRayPlayer)
        {
            this.projector = projector;
            this.bluRayPlayer = bluRayPlayer;
        }

        public void PlayMovie()
        {
            projector.On();
            bluRayPlayer.On();
        }

        public void StopMovie()
        {
            projector.Off();
            bluRayPlayer.Off();
        }
    }
}
