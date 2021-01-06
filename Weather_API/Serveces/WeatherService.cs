using Newtonsoft.Json;
using System;
using System.Net.Http;
using Weather_API.Exceptions;
using Weather_API.IServices;
using Weather_API.Models;
using WeatherAPI.Models;

namespace Weather_API.Serveces
{
    public class WeatherService : IWeatherService
    {
        public WeatherInfo GetCurrentWeatherByCity(string sityName)
        {
            const string AppKey = "1744b57dc4b9ab7983cb1e8344e412a7";
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(new Uri($"http://api.openweathermap.org/data/2.5/weather?q={sityName}&appid={AppKey}")).GetAwaiter().GetResult();
            string jsonResult = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var weather= JsonConvert.DeserializeObject<WeatherInfo>(jsonResult);

            if (response.Headers.Date.HasValue)
            {
                weather.dt_txt = response.Headers.Date.Value.DateTime;
            }

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var exception = JsonConvert.DeserializeObject<BadResult>(jsonResult);
                throw new HttpException(response.StatusCode, exception);
            }

            weather.Main.temp_max = weather.Main.temp_max - (decimal)273.15;
            weather.Main.temp_min = weather.Main.temp_min - (decimal)273.15;

            return weather;
        }
        public WeatherInfo[] GetForecastByCity(string sityName)
        {
            const string AppKey = "1744b57dc4b9ab7983cb1e8344e412a7";
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(new Uri($"http://api.openweathermap.org/data/2.5/forecast?q={sityName}&appid={AppKey}")).GetAwaiter().GetResult();
            string jsonResult = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var exception = JsonConvert.DeserializeObject<BadResult>(jsonResult);
                throw new HttpException(response.StatusCode, exception);
            }
            return JsonConvert.DeserializeObject<WeatherList>(jsonResult).list;
        }
    }
}
