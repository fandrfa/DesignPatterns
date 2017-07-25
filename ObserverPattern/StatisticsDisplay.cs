using System;

namespace Observer
{
    public sealed class StatisticsDisplay : IObserver, IDisplayElement
    {
        private float minTemperature = 0.0f;
        private float sumTemperature = 0.0f;
        private float maxTemperature = 0.0f;
        private int numberOfRecords = 0;
        
        private ISubject weatherData;

        public StatisticsDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        public void DisplayElement()
        {
            Console.WriteLine("Statistics Display data:");
            Console.WriteLine("     Min Temperature = {0}", minTemperature);
            Console.WriteLine("     Max Temperature = {0}", maxTemperature);
            Console.WriteLine("     Avg Temperature = {0}", numberOfRecords == 0 ? 0 : sumTemperature / numberOfRecords);
            Console.WriteLine();
        }

        public void Update(float temperature, float humidity, float pressure)
        {
            numberOfRecords++;
            sumTemperature += temperature;

            if (minTemperature > temperature)
            {
                minTemperature = temperature;
            }

            if (maxTemperature < temperature)
            {
                maxTemperature = temperature;
            }
            DisplayElement();
        }
    }

}
