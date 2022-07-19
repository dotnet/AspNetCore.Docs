using System.Globalization;
using BindTryParseMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BindTryParseMVC.Controllers
{
    public class WeatherForecastController : Controller
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        // <snippet>
        //GET /WeatherForecast?culture=en-GB
        public IActionResult Index(Culture? culture)
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

            return View(weatherForecasts);
        }
        // </snippet>

        // GET /WeatherForecast/Range?range=07/12/2022-07/14/2022
        // <snippet_1>
        public IActionResult Range(DateRange range)
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
                    Date = wf.Date.ToString(CultureInfo.InvariantCulture),
                    TemperatureC = wf.TemperatureC,
                    TemperatureF = wf.TemperatureF,
                    Summary = wf.Summary
                });

            return View("Index", weatherForecasts);
        }
        // </snippet_1>

        // GET /WeatherForecast/RangeWithCulture?culture=en-GB&range=07/12/2022-07/14/2022
        public IActionResult RangeWithCulture(Culture culture, string range)
        {
            if (!DateRange.TryParse(range, new CultureInfo(culture?.DisplayName ?? "en-US"), out var dateRange))
               return View("Error", $"Invalid date range {range} for culture {culture?.DisplayName}");

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

            return View("Index", weatherForecasts);
        }
        // </snippet_2>
    }
}
