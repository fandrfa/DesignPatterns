using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompoundPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            DuckSimulator duckSimulator = new DuckSimulator();
            AbstractDuckFactory duckFactory = new CountingDuckFactory();            
            duckSimulator.Simulate(duckFactory);


            Console.ReadLine();
        }
    }
}
