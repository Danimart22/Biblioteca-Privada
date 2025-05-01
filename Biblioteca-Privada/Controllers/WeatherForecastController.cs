using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Biblioteca_Privada.Controllers
{
    [ApiController]
    [Route("api")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static List<WeatherForecast> ListWeatherForecasts = new List<WeatherForecast>();

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            if (ListWeatherForecasts == null || !ListWeatherForecasts.Any())
            {
                ListWeatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToList();
            }
        }

        [HttpGet]
        [Route("Get/list")]
        [Route("Get/WeatherForecast2")]
        public IEnumerable<WeatherForecast> Get()
        {
            return ListWeatherForecasts;
        }

        [HttpPost]
        [Route("new")]
        public IActionResult Post(WeatherForecast weatherForecast)
        {
            ListWeatherForecasts.Add(weatherForecast);
            Console.WriteLine(" insertado ");
            return Ok();

        }

        [HttpDelete]
        public IActionResult Delete(int index)
        {
            ListWeatherForecasts.RemoveAt(index);
            Console.WriteLine(" Borrado ");
            return Ok();
        }

        [HttpPut]
        [Route("[action]")] //utiliza el nombre del método para la url
        public IActionResult actualizar(int index)
        {
            Console.WriteLine(" actualizado ");
            return Ok();
        }

    }
}
