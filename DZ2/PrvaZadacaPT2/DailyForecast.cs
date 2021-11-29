using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace class_library
{
    public class DailyForecast
    {
        
        private DateTime date;
        private Weather weather;

        public DailyForecast()
        {
            this.Date = new DateTime();
            this.Weather = new Weather();

        }
        public DailyForecast(DateTime date, Weather weather)
        {
            this.Date = date;
            this.Weather = weather;
        }

        public DateTime Date { get => date; set => date = value; }
        public Weather Weather { get => weather; set => weather = value; }

   

        public string GetAsString()
        {
            
            return $"{Date.ToString()}: {Weather.GetAsString()}";
        }
    }
}
