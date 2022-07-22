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
        //GET /WeatherForecast
        public IActionResult Index()
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
                    Date = wf.Date.ToString("d"),
                    TemperatureC = wf.TemperatureC,
                    TemperatureF = wf.TemperatureF,
                    Summary = wf.Summary
                });

            return View("Index", weatherForecasts);
        }
        // </snippet_1>

        // <snippet_2>
        // GET /en-GB/WeatherForecast/RangeWithCulture?range=07/12/2022-07/14/2022
        public IActionResult RangeWithCulture(string culture, string range)
        {
            if (!DateRange.TryParse(range, new CultureInfo(culture), out var dateRange))
               return View("Error", $"Invalid date range {range} for culture {culture}");

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
                    Date = wf.Date.ToString(new CultureInfo(culture)),
                    TemperatureC = wf.TemperatureC,
                    TemperatureF = wf.TemperatureF,
                    Summary = wf.Summary
                });

            return View("Index", weatherForecasts);
        }
        // </snippet_2>
    }
}
