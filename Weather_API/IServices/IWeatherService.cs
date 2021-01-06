using System.Collections.Generic;
using Weather_API.Models;
using WeatherAPI.Models;

namespace Weather_API.IServices
{
    public interface IWeatherService
    {
        WeatherInfo GetCurrentWeatherByCity(string sityName);
        WeatherInfo[] GetForecastByCity(string sityName);
    }
}
