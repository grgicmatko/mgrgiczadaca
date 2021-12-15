using System;
using System.Collections.Generic;
using System.Text;

namespace class_library
{
    public class UniformGenerator : IRandomGenerator
    {
        Random generator;

        public UniformGenerator(Random generator)
        {
            this.generator = generator;
        }

        public Weather Generate(double minTemperature, double maxTemperature,
                                double minHumidity, double maxHumidity,
                                double minWindSpeed, double maxWindSpeed)
        {
            return new Weather(generator.NextDouble()*(maxTemperature-minTemperature)+minTemperature,
                               generator.NextDouble()*(maxHumidity-minHumidity)+minHumidity,
                               generator.NextDouble()*(maxWindSpeed-minWindSpeed)+minWindSpeed);
        }
    }
}
