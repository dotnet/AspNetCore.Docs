using BindTryParseAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BindTryParseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        // <snippet_1>
        // GET /en-gb/WeatherForecast
        [HttpGet]
        [Route("/{locale}/[controller]")]
        public IActionResult Get([FromRoute] Locale locale)
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
                    Date = wf.Date.ToString("d", locale),
                    TemperatureC = wf.TemperatureC,
                    TemperatureF = 32 + (int)(wf.TemperatureC / 0.5556),
                    Summary = wf.Summary
                });

            return Ok(weatherForecasts);
        }
        // </snippet_1>

        // <snippet_2>
        // GET /WeatherForecast/ByRange?range=07/12/2022,07/14/2022
        [HttpGet]
        [Route("ByRange")]
        public IActionResult GetByRange([FromQuery] DateRange range)
        {
            var weatherForecasts = Enumerable
                .Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .Where(wf => DateOnly.FromDateTime(wf.Date) >= range.From
                             && DateOnly.FromDateTime(wf.Date) <= range.To)
                .Select(wf => new WeatherForecastViewModel
                {
                    Date = wf.Date.ToString("d"),
                    TemperatureC = wf.TemperatureC,
                    TemperatureF = 32 + (int)(wf.TemperatureC / 0.5556),
                    Summary = wf.Summary
                });

            return Ok(weatherForecasts);
        }
        // </snippet_2>

        // <snippet_3>
        // GET /af-ZA/WeatherForecast/ByLocaleRange?range=2022-07-24,2022-07-29
        [HttpGet]
        [Route("/{locale}/[controller]/ByLocaleRange")]
        public IActionResult GetByLocaleRange([FromRoute] Locale locale, [FromQuery] string range)
        {
            if (!DateRange.TryParse(range, locale, out DateRange rangeResult))
                return ValidationProblem($"Invalid date range: {range} for locale {locale.DisplayName}");

            var weatherForecasts = Enumerable
                .Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .Where(wf => DateOnly.FromDateTime(wf.Date) >= rangeResult.From
                             && DateOnly.FromDateTime(wf.Date) <= rangeResult.To)
                .Select(wf => new WeatherForecastViewModel
                {
                    Date = wf.Date.ToString("d", locale),
                    TemperatureC = wf.TemperatureC,
                    TemperatureF = 32 + (int)(wf.TemperatureC / 0.5556),
                    Summary = wf.Summary
                });

            return Ok(weatherForecasts);
        }
        // </snippet_3>
    }
}
