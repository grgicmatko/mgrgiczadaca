using System;
using System.Collections.Generic;
using System.Text;

namespace class_library
{
    public interface IRandomGenerator
    {
        public Weather Generate(double minTemperature,double maxTemperature,
                                double minHumidity,double maxHumidity,
                                double minWindSpeed,double maxWindSpeed);
    }
}
