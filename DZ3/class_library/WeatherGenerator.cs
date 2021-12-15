using System;
using System.Collections.Generic;
using System.Text;

namespace class_library
{
    public class WeatherGenerator
    {
        private double minTemperature;
        private double maxTemperature;
        private double minHumidity;
        private double maxHumidity;
        private double minWindSpeed;
        private double maxWindSpeed;
        private IRandomGenerator generator;

        public WeatherGenerator(double minTemperature, double maxTemperature,
                                double minHumidity, double maxHumidity,
                                double minWindSpeed, double maxWindSpeed,
                                IRandomGenerator generator)
        {
            this.minTemperature = minTemperature;
            this.maxTemperature = maxTemperature;
            this.minHumidity = minHumidity;
            this.maxHumidity = maxHumidity;
            this.minWindSpeed = minWindSpeed;
            this.maxWindSpeed = maxWindSpeed;
            this.generator = generator;
        }

        public void SetGenerator(IRandomGenerator randomGenerator)
        {
            this.generator = randomGenerator;
        }

        public Weather Generate()
        {
            return generator.Generate(minTemperature, maxTemperature,
                                      minHumidity, maxHumidity,
                                      minWindSpeed, maxWindSpeed);
        }
    }
}
