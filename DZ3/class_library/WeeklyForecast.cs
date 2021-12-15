using System;
using System.Collections.Generic;
using System.Text;

namespace class_library
{
    public class WeeklyForecast
    {
        DailyForecast[] dailyForecast = new DailyForecast[7];

        public WeeklyForecast(DailyForecast[] daily)
        {
            for (int i = 0; i < daily.Length; i++)
            {
                dailyForecast[i] = new DailyForecast();
                dailyForecast[i].Date = daily[i].Date;
                dailyForecast[i].Weather = daily[i].Weather;



            }
        }

        public string GetAsString()
        {

            for (int i = 0; i < dailyForecast.Length; i++)
            {
                Console.WriteLine($"{dailyForecast[i].GetAsString()}");
            }

            return "";
        }



        public double GetMaxTemperature()
        {
            Weather maxTemp = new Weather();
            maxTemp.SetTemperature(dailyForecast[0].Weather.GetTemperature());
            for (int i = 0; i < dailyForecast.Length; i++)
                if (dailyForecast[i].Weather >= maxTemp)
                {
                    maxTemp.SetTemperature(dailyForecast[i].Weather.GetTemperature());
                }

            return maxTemp.GetTemperature();
        }
        public DailyForecast this[int i]
        {
            get { return dailyForecast[i]; }

        }



    }
}

