using System;
using Weather_API.Models;

namespace WeatherAPI.Models
{
    public class WeatherInfo
    {
        public WeatherMain Main { get; set; }
        public WindInfo Wind { get; set; }
        public Weather[] Weather { get; set; }
        public WeatherClouds Clouds { get; set; }
        public DateTime dt_txt { get; set; }
    }
}
