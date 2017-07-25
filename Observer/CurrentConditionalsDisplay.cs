using System;

namespace Observer
{
    public sealed class CurrentConditionalsDisplay : IObserver, IDisplayElement
    {
        private float temperature;
        private float humidity;
        private ISubject weatherData;

        public CurrentConditionalsDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        public void DisplayElement()
        {
            Console.WriteLine("Current Conditionals Display data:");
            Console.WriteLine("     Current temperature = {0}", temperature);
            Console.WriteLine("     Current humidity = {0}", humidity);
            Console.WriteLine();
        }       

        public void Update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            DisplayElement();
        }
    }

}
