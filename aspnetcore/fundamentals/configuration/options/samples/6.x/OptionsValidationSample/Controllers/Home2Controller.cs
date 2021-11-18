using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OptionsValidationSample.Configuration;
using OptionsValidationSample.Models;
using System.Diagnostics;

namespace OptionsValidationSample.Controllers
{
    public class Home2Controller : Controller
    {
        private readonly ILogger<Home2Controller> _logger;
        private readonly IOptions<MyConfigOptions> _config;

        public Home2Controller(IOptions<MyConfigOptions> config, ILogger<Home2Controller> logger)
        {
            _logger = logger;
            _config = config;
        }

        public ContentResult Index()
        {
            string? msg =null;
            try
            {
                var config = _config.Value;
                 msg = $"Key1: {config.Key1} \n" +
                       $"Key2: {config.Key2} \n" +
                       $"Key3: {config.Key3}";
            }
            catch (OptionsValidationException optValEx)
            {
                foreach (var failure in optValEx.Failures)
                {
                    msg += failure + "\n";
                }
                return Content(optValEx.Message);
            }
            return Content(msg);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {
                        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
