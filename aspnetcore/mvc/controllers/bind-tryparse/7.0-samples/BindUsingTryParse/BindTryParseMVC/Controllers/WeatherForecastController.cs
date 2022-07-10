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

        public IActionResult Index([FromQuery] Culture? culture)
        {
            var weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray()
                .Select(w => new WeatherForecastViewModel
                {
                    Date = w.Date.ToString(new CultureInfo(culture?.DisplayName ?? "en-US")),
                    TemperatureC = w.TemperatureC,
                    TemperatureF = w.TemperatureF,
                    Summary = w.Summary
                });

            return View(weatherForecasts);
        }
    }

    public class Culture
    {
        public string? DisplayName { get; }

        public Culture(string displayName)
        {
            
            if(string.IsNullOrEmpty(displayName))
                throw new ArgumentNullException(nameof(displayName));

            DisplayName = displayName;
        }

        public static bool TryParse(string? value, out Culture result)
        {
            if (value is null)
            {
                result = default;
                return false;
            }

            result = new Culture(value);
            return true;
        }
    }
}
