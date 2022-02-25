// When [assembly: ApiController] is used in Program.cs, the app throws
// InvalidOperationException: Action 'WebApiSample.Controllers.WeatherForecast2Controller.Get
// (WebApiSample)' does not have an attribute route. Action methods on controllers annotated with
// ApiControllerAttribute must be attribute routed.
// #define TEST_assembly
#if TEST_assembly
using Microsoft.AspNetCore.Mvc;

namespace WebApiSample.Controllers;

public class WeatherForecast2Controller : Controller
{
    private static readonly string[] Summaries = new[]
    {
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecast2Controller(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
#endif