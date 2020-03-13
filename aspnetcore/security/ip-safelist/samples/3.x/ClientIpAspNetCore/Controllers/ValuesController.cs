using System;
using System.Collections.Generic;
using System.Linq;
using ClientIpAspNetCore.Models;
using ClientIpSafelistComponents.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClientIpAspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        #region snippet_ActionFilter
        [ServiceFilter(typeof(ClientIpCheckActionFilter))]
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        #endregion snippet_ActionFilter
        {
            _logger.LogDebug("successful HTTP GET");

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
            })
            .ToArray();
        }

        [HttpPost]
        public void Post(string value)
        {
        }
    }
}
