using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

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
            wind = Double.Parse(comp[2], CultureInfo.InvariantCulture);
            hum = Double.Parse(comp[3], CultureInfo.InvariantCulture);

            return new DailyForecast(DateTime.Parse(comp[0]), new Weather(temp, hum, wind));
        }

        private static void RunDemoForHW1()
        {
            Weather current = new Weather();
            current.SetTemperature(24.12);
            current.SetWindSpeed(3.5);
            current.SetHumidity(0.56);

            Console.WriteLine("Weather info:\n"
                + "\ttemperature: " + current.GetTemperature() + "\n"
                + "\thumidity: " + current.GetHumidity() + "\n"
                + "\twind speed: " + current.GetWindSpeed() + "\n");
            Console.WriteLine("Feels like: " + current.CalculateFeelsLikeTemperature());

            Console.WriteLine("Finding weather info with largest windchill!");
            const int Count = 5;
            double[] temperatures = new double[Count] { 8.33, -1.45, 5.00, 12.37, 7.67 };
            double[] humidities = new double[Count] { 0.3790, 0.4555, 0.743, 0.3750, 0.6612 };
            double[] windSpeeds = new double[Count] { 4.81, 1.5, 5.7, 4.9, 1.2 };

            Weather[] weathers = new Weather[Count];
            for (int i = 0; i < weathers.Length; i++)
            {
                weathers[i] = new Weather(temperatures[i], humidities[i], windSpeeds[i]);
                Console.WriteLine("Windchill for weathers[" + i + "] is: " + weathers[i].CalculateWindChill());
            }

            Weather largestWindchill = FindWeatherWithLargestWindchill(weathers);
            Console.WriteLine(
                "Weather info:" + largestWindchill.GetTemperature() + ", " +
                largestWindchill.GetHumidity() + ", " + largestWindchill.GetWindSpeed()
            );

        }

        private static void RunDemoForHW2()
      {
          Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR");
          DateTime monday = new DateTime(2021, 11, 8);
          Weather mondayWeather = new Weather(6.17, 56.13, 4.9);
          DailyForecast mondayForecast = new DailyForecast(monday, mondayWeather);
          Console.WriteLine(monday.ToString());
          Console.WriteLine(mondayWeather.ToString());
          Console.WriteLine(mondayForecast.GetAsString());

          // Assume a valid input file (correct format).
          // Assume that the number of rows in the text file is always 7. 
          string fileName = "weatherforecast.txt";
          if (File.Exists(fileName) == false)
          {
              Console.WriteLine("The required file does not exist. Please create it, or change the path.");
              return;
          }

          string[] dailyWeatherInputs = File.ReadAllLines(fileName);
          DailyForecast[] dailyForecasts = new DailyForecast[dailyWeatherInputs.Length];

          for (int i = 0; i < dailyForecasts.Length; i++)
          {

              dailyForecasts[i] = ForecastUtilities.Parse(dailyWeatherInputs[i]);
          }

          WeeklyForecast weeklyForecast = new WeeklyForecast(dailyForecasts);
          Console.WriteLine(weeklyForecast.GetAsString());

          Console.WriteLine("Maximal weekly temperature:");
          Console.WriteLine(weeklyForecast.GetMaxTemperature());
          Console.WriteLine(weeklyForecast[0].GetAsString());


      }
      
        public static Weather FindWeatherWithLargestWindchill(Weather[] weathers)
        {
            int i, index = 0;
            double largestWindchill = weathers[0].CalculateWindChill();

            for (i = 0; i < weathers.Length; i++)
                if (weathers[i].CalculateWindChill() > largestWindchill)
                {
                    largestWindchill = weathers[i].CalculateWindChill();
                    index = i;
                }
            return new Weather(weathers[index].GetTemperature(), weathers[index].GetHumidity(), weathers[index].GetWindSpeed());
        }

        public static void PrintWeathers(IPrinter[] printers, Weather[] weathers)
        {
            printers[0].Print(weathers);
            printers[1].Print(weathers);
        }
    }
}
