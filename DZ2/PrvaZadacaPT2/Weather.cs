using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_library
{
    public class Weather
    {
        private double temperature;
        private double humidity;
        private double windSpeed;
        private const double c1 = -8.78469475556;
        private const double c2 = 1.61139411;
        private const double c3 = 2.33854883889;
        private const double c4 = -0.14611605;
        private const double c5 = -0.012308094;
        private const double c6 = -0.0164248277778;
        private const double c7 = 0.002211732;
        private const double c8 = 0.00072546;
        private const double c9 = -0.000003582;


        //SETTING
        public void SetTemperature(double temperature)
        {
            this.temperature = temperature;
        }

        public void SetWindSpeed(double windSpeed)
        {
            this.windSpeed = windSpeed;
        }

        public void SetHumidity(double humidity)
        {
            this.humidity = humidity;
        }

        //GETTING
        public double GetTemperature()
        {
            return this.temperature;
        }

        public double GetHumidity()
        {
            return this.humidity;
        }

        public double GetWindSpeed()
        {
            return this.windSpeed;
        }


        //Constructors
        public Weather()
        {
            this.temperature = 0.0;
            this.humidity = 0.0;
            this.windSpeed = 0.0;
        }

        public Weather(double temperature, double humidity, double windSpeed)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.windSpeed = windSpeed;
        }


        //Calculations

        public double CalculateWindChill()
        {
            double Twc;
            // Twc= 13.12 + 0.6215Ta - 11.37v ^0.16 +0.3965Ta*v^0.16
            //where Twc is the wind chill index, based on the Celsius temperature scale; 
            //Ta is the air temperature in degrees Celsius;
            //and v is the wind speed at 10 m (33 ft) standard anemometer height, in kilometres per hour.

            Twc = 13.12 + 0.6215 * this.temperature - 11.37 * Math.Pow(this.windSpeed, 0.16) + 0.3965 * this.temperature * Math.Pow(this.windSpeed, 0.16);
            if (this.temperature <= 10 && this.windSpeed > 4.8)
                return Twc;
            else return 0;
        }

        public double CalculateHeatIndex()
        {
            double Hi;

            double hum = this.humidity * 100;

            Hi = c1 + c2 * this.temperature + c3 * this.humidity + c4 * this.temperature * this.humidity + c5 * Math.Pow(this.temperature, 2);
            Hi += (c6 * Math.Pow(this.humidity, 2) + c7 * Math.Pow(this.temperature, 2) * this.humidity + c8 * this.temperature * Math.Pow(this.humidity, 2));
            Hi += (c9 * Math.Pow(this.temperature, 2) * Math.Pow(this.humidity, 2));

            if (this.temperature >= 21 && this.temperature <= 46 && this.humidity > 0.0 && this.humidity < 0.8)
                return Hi;
            else return 0;
        }

        public double CalculateFeelsLikeTemperature()
        {

            double Hi, Twc;

            Twc = CalculateWindChill();
            Hi = CalculateHeatIndex();

            if (this.temperature < 10.0 && this.windSpeed > 4.8)
                return Twc;
            if (this.temperature >= 21 && this.temperature <= 46 && this.humidity > 0.0 && this.humidity < 0.8)
                return Hi;
            else return this.temperature;

        }

        public string GetAsString() {

            return $"T={this.temperature}°C, w={this.windSpeed}km/h, h={this.humidity}%";
        }

        public static bool operator <=(Weather lhs, Weather rhs)
        {
            bool status = false;

            if (lhs.GetTemperature()<=rhs.GetTemperature())
            {
                status = true;
            }
            return status;
        }
        public static bool operator >=(Weather lhs, Weather rhs)
        {
            bool status = false;

            if (lhs.GetTemperature()>=rhs.GetTemperature())
            {

                status = true;
            }
            return status;
        }


    }
    
}
