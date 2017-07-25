using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();

            CurrentConditionalsDisplay currenConditionalsDisplay = new CurrentConditionalsDisplay(weatherData);
            StatisticsDisplay statisticsDisplay = new StatisticsDisplay(weatherData);            

            weatherData.SetMeasurments(30.0f, 5.0f, 200.0f);
            weatherData.SetMeasurments(10.0f, 6.0f, 300.0f);
            weatherData.SetMeasurments(-20.0f, 2.0f, 100.0f);

            Console.ReadLine();
        }
    }

}
