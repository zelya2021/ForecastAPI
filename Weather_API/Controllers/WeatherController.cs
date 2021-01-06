using Microsoft.AspNetCore.Mvc;
using Weather_API.Exceptions;
using Weather_API.IServices;

namespace Weather_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        IWeatherService _weatherService;
        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("{cityName}/currentWeather", Name = "GetCurrentWeather")]
        public IActionResult GetCurrentWeather(string cityName)
        {
            try
            {
                return Ok(_weatherService.GetCurrentWeatherByCity(cityName));
            }
            catch (HttpException ex)
            {
                Response.StatusCode = (int)ex._statusCode;
                return new JsonResult(ex._badResult);
            }
        }

        [HttpGet("{cityName}/forecast", Name = "GetForecast")]
        public IActionResult GetForecast(string cityName)
        {
            try
            {
                return Ok(_weatherService.GetForecastByCity(cityName));
            }
            catch (HttpException ex)
            {
                Response.StatusCode = (int)ex._statusCode;
                return new JsonResult(ex._badResult);
            }
        }
    }
}
