using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SingletonRegistryEditor registryEditor = SingletonRegistryEditor.GetInstance();
            SingletonRegistryEditor registryEditor2 = SingletonRegistryEditor.GetInstance();

            Console.ReadLine();
        }
    }

    internal class SingletonRegistryEditor
    {
        private static SingletonRegistryEditor instance;

        private SingletonRegistryEditor()
        {            
        }

        public static SingletonRegistryEditor GetInstance()
        {
            if (instance == null)
            {
                Console.WriteLine("Let's return the new one");
                instance = new SingletonRegistryEditor();
            }
            else
            {
                Console.WriteLine("Let's return the existing one");
            }
            return instance;
        }
    }

    public class ChocolateBoiler
    {
        private static ChocolateBoiler instance;
        private bool empty;
        private bool boiled;
        private ChocolateBoiler()
        {
            empty = true;
            boiled = false;
        }

        public static ChocolateBoiler GetChocolateBoiler()
        {
            if (instance == null)
            {
                instance = new ChocolateBoiler();
            }
            return instance;
        }


        public void fill()
        {
            if (isEmpty())
            {
                empty = false;
                boiled = false;
                // fill the boiler with a milk/chocolate mixture
            }
        }
        public void drain()
        {
            if (!isEmpty() && isBoiled())
            {
                // drain the boiled milk and chocolate
                empty = true;
            }
        }
        public void boil()
        {
            if (!isEmpty() && !isBoiled())
            {
                // bring the contents to a boil
                boiled = true;
            }
        }
        public bool isEmpty()
        {
            return empty;
        }
        public bool isBoiled()
        {
            return boiled;
        }
    }
}
