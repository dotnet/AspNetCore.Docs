using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CustomLogger.Models;

namespace CustomLogger.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Start Index action in the HomeController");
            _logger.LogWarning("The Index action was just started");
            _logger.LogError("Not really an error. Just to show the custom logger");            
            _logger.LogDebug("End Index action in the HomeController");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Start Privacy action in the HomeController");
            _logger.LogWarning("The Privacy action was just started");
            _logger.LogError("Not really an error. Just to show the custom logger");
            _logger.LogDebug("End Privacy action in the HomeController");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
