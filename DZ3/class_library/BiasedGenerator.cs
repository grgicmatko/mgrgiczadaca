using System;
using System.Collections.Generic;
using System.Text;

namespace class_library
{
    public class BiasedGenerator:IRandomGenerator
    {
        Random generator;

        public BiasedGenerator(Random generator)
        {
            this.generator = generator;
        }



        public Weather Generate(double minTemperature, double maxTemperature,
                                double minHumidity, double maxHumidity,
                                double minWindSpeed, double maxWindSpeed)
        {   
            double temp,hum,wind;
            int[] vs = new int[3] { 1, 1, 2 };
            Random random = new Random();
            if(vs[random.Next(0,3)]==2)
            {
                do
                {
                    temp = random.NextDouble() * (maxTemperature - minTemperature) + minTemperature;
                } while (temp > (maxTemperature + minTemperature) / 2.0);
                do
                {
                    hum = random.NextDouble() * (maxHumidity - minHumidity) + minHumidity;
                } while (hum > (maxHumidity + minHumidity) / 2.0);
                do
                {
                    wind = random.NextDouble() * (maxWindSpeed - minWindSpeed) + minWindSpeed;
                } while (wind > (maxWindSpeed + minWindSpeed) / 2.0);
            }



            else
            {
                do
                {
                    temp = random.NextDouble() * (maxTemperature - minTemperature) + minTemperature;
                } while (temp < (maxTemperature + minTemperature) / 2.0);
                do
                {
                    hum = random.NextDouble() * (maxHumidity - minHumidity) + minHumidity;
                } while (hum < (maxHumidity + minHumidity) / 2.0);
                do
                {
                    wind = random.NextDouble() * (maxWindSpeed - minWindSpeed) + minWindSpeed;
                } while (wind < (maxWindSpeed + minWindSpeed) / 2.0);
            }


            return new Weather(temp,hum,wind);
        }
    }
}
