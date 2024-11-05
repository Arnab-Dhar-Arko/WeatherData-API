using System;
using System.Collections.Generic;

namespace WeatherApps
{
    internal class WeatherInfo
    {
        public class Current
        {
            public string time { get; set; }
            public double temperature_2m { get; set; }
            public double wind_speed_10m { get; set; }
        }

        public class Hourly
        {
            public List<string> time { get; set; }
            public List<double> wind_speed_10m { get; set; }
            public List<double> temperature_2m { get; set; }
            public List<double> relative_humidity_2m { get; set; }
        }

        public class Root
        {
            public Current current { get; set; }
            public Hourly hourly { get; set; }
        }
    }
}