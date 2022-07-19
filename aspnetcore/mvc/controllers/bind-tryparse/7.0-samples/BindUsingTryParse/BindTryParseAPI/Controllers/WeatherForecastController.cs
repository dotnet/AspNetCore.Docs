using System.Globalization;
using BindTryParseAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BindTryParseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // <snippet2>
        // GET /WeatherForecast?culture=en-GB
        [HttpGet]
        public IActionResult Get([FromQuery] Culture? culture)
        {
            var weatherForecasts = Enumerable
                .Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .Select(wf => new WeatherForecastViewModel
                {
                    Date = wf.Date.ToString(new CultureInfo(culture?.DisplayName ?? "en-US")),
                    TemperatureC = wf.TemperatureC,
                    TemperatureF = wf.TemperatureF,
                    Summary = wf.Summary
                });

            return Ok(weatherForecasts);
        }
        // </snippet2>

        // <snippet>
        // GET /WeatherForecast/GetByRange?range=07/12/2022-07/14/2022
        [HttpGet]
        [Route("GetByRange")]
        public IActionResult GetByRange([FromQuery] DateRange range)
        {
            var weatherForecasts = Enumerable
                .Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .Where(wf => DateOnly.FromDateTime(wf.Date) >= (range?.From ?? DateOnly.MinValue) && DateOnly.FromDateTime(wf.Date) <= (range?.To ?? DateOnly.MaxValue))
                .Select(wf => new WeatherForecastViewModel
                {
                    Date = wf.Date.ToString(),
                    TemperatureC = wf.TemperatureC,
                    TemperatureF = wf.TemperatureF,
                    Summary = wf.Summary
                });

            return Ok(weatherForecasts);
        }
        // </snippet>

        // GET /WeatherForecast/GetByRangeWithCulture?culture=en-GB&range=07/12/2022-07/14/2022
        [HttpGet]
        [Route("GetByRangeWithCulture")]
        public IActionResult GetByRangeWithCulture([FromQuery] Culture culture, [FromQuery] string range)
        {
            if (!DateRange.TryParse(range, new CultureInfo(culture?.DisplayName ?? "en-US"), out var dateRange))
                return ValidationProblem($"Invalid date range {range} for culture {culture?.DisplayName}");
            
            var weatherForecasts = Enumerable
                .Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .Where(wf => DateOnly.FromDateTime(wf.Date) >= (dateRange?.From ?? DateOnly.MinValue) 
                          && DateOnly.FromDateTime(wf.Date) <= (dateRange?.To ?? DateOnly.MaxValue))
                .Select(wf => new WeatherForecastViewModel
                {
                    Date = wf.Date.ToString(new CultureInfo(culture?.DisplayName ?? "en-US")),
                    TemperatureC = wf.TemperatureC,
                    TemperatureF = wf.TemperatureF,
                    Summary = wf.Summary
                });

            return Ok(weatherForecasts);
        }
    }
}
