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

        /// <summary>
        /// /WeatherForecast?culture=en-GB
        /// </summary>
        /// <param name="culture"></param>
        /// <returns></returns>
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

        /// <summary>
        /// /WeatherForecast/Range?range=07/12/2022-07/14/2022
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public IActionResult Range(DateRange? range)
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
                    Date = wf.Date.ToString(CultureInfo.InvariantCulture),
                    TemperatureC = wf.TemperatureC,
                    TemperatureF = wf.TemperatureF,
                    Summary = wf.Summary
                });

            return View("Index", weatherForecasts);
        }
    }
}
