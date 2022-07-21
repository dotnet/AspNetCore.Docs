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
        // GET /WeatherForecast
        [HttpGet]
        public IActionResult Get()
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
                    Date = wf.Date.ToString("d"),
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
                .Where(wf => DateOnly.FromDateTime(wf.Date) >= (range?.From ?? DateOnly.MinValue) 
                          && DateOnly.FromDateTime(wf.Date) <= (range?.To ?? DateOnly.MaxValue))
                .Select(wf => new WeatherForecastViewModel
                {
                    Date = wf.Date.ToString("d"),
                    TemperatureC = wf.TemperatureC,
                    TemperatureF = wf.TemperatureF,
                    Summary = wf.Summary
                });

            return Ok(weatherForecasts);
        }
        // </snippet>

        // GET /en-gb/WeatherForecast/GetByRangeWithCulture?range=21/07/2022-23/07/2022
        [HttpGet]
        [Route("/{culture}/[controller]/GetByRangeWithCulture")]
        public IActionResult GetByRangeWithCulture([FromRoute] string culture, [FromQuery] string range)
        {
            if (!DateRange.TryParse(range, new CultureInfo(culture ?? "en-US"), out var dateRange))
                return ValidationProblem($"Invalid date range {range} for culture {culture}");
            
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
                    Date = wf.Date.ToString(new CultureInfo(culture ?? "en-US")),
                    TemperatureC = wf.TemperatureC,
                    TemperatureF = wf.TemperatureF,
                    Summary = wf.Summary
                });

            return Ok(weatherForecasts);
        }
    }
}
