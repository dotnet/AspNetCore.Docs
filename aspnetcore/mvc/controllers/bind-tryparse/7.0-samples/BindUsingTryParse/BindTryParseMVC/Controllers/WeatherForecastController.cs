using BindTryParseMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BindTryParseMVC.Controllers
{
    public class WeatherForecastController : Controller
    {
        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        // <snippet_1>
        // GET /en-GB/WeatherForecast
        public IActionResult Index([FromRoute] Locale locale)
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

            return View(weatherForecasts);
        }
        // </snippet_1>

        // <snippet_2>
        // GET /WeatherForecast/ByRange?range=7/24/2022,07/26/2022
        public IActionResult ByRange([FromQuery] DateRange range)
        {
            if (!ModelState.IsValid)
                return View("Error", ModelState.Values.SelectMany(v => v.Errors));

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

            return View("Index", weatherForecasts);
        }
        // </snippet_2>

        // <snippet_3>
        // GET /af-ZA/WeatherForecast/RangeByLocale&range=2022-07-24,2022-07-29
        public IActionResult RangeByLocale([FromRoute] Locale locale, [FromQuery] string range)
        {
            if (!ModelState.IsValid)
                return View("Error", ModelState.Values.SelectMany(v => v.Errors));

            if (!DateRange.TryParse(range, locale, out DateRange rangeResult))
            {
                ModelState.TryAddModelError(nameof(range),
                    $"Invalid date range: {range} for locale {locale.DisplayName}");

                return View("Error", ModelState.Values.SelectMany(v => v.Errors));
            }

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
                    TemperatureF = 32 + (int) (wf.TemperatureC / 0.5556),
                    Summary = wf.Summary
                });

            return View("Index", weatherForecasts);
        }
        // </snippet_3>
    }
}
