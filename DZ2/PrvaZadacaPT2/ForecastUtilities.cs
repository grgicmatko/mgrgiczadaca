using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace class_library
{
    public class ForecastUtilities
    {

        public static DailyForecast Parse(string dailyWeatherInputs)
        {
            double temp;
            double wind;
            double hum;
            string[] comp = dailyWeatherInputs.Split(',');
            temp = Double.Parse(comp[1], CultureInfo.InvariantCulture);
            wind =  Double.Parse(comp[2], CultureInfo.InvariantCulture);
            hum = Double.Parse(comp[3], CultureInfo.InvariantCulture);
           
            return new DailyForecast(DateTime.Parse(comp[0]),new Weather(temp, hum, wind));
        }

    }
}
