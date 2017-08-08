using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            PancakeHouseMenu pancakeHouseMenu = new PancakeHouseMenu();
            DinnerMenu dinnerMenu = new DinnerMenu();

            Waitress waitress = new Waitress(pancakeHouseMenu, dinnerMenu);
            waitress.PrintMenu();            

            Console.ReadLine();
        }
    }
}

