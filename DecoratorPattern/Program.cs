using System;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Beverage darkRoast = new DarkRoast();
            MochaDecorator darkRoastMocha = new MochaDecorator(darkRoast);
            WhipDecorator darkRoastMochaWhip = new WhipDecorator(darkRoastMocha);
            Console.WriteLine("Beverage = {0}. Cost = {1}", darkRoastMochaWhip.GetDescription(), darkRoastMochaWhip.GetCost());

            Beverage houseBlend = new HouseBlend();
            MochaDecorator houseBlendMocha = new MochaDecorator(houseBlend);
            MochaDecorator houseBlendDoubleMocha = new MochaDecorator(houseBlendMocha);
            SoyDecorator houseBlendDoubleMochaSoy = new SoyDecorator(houseBlendDoubleMocha);
            WhipDecorator houseBlendDoubleMochaSoyWhip = new WhipDecorator(houseBlendDoubleMochaSoy);
            Console.WriteLine("Beverage = {0}. Cost = {1}", houseBlendDoubleMochaSoyWhip.GetDescription(), houseBlendDoubleMochaSoyWhip.GetCost());
            
            Console.ReadLine();
        }
    }
}
