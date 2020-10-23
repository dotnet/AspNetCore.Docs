using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CustomLogger.Models;
using Microsoft.Docs.Samples;

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
            var routeInfo = ControllerContext.ToCtxString();

            _logger.LogInformation(routeInfo);
            _logger.LogWarning(routeInfo + "Testing LogWarning" );
            _logger.LogError("Not an error. Just to show the custom logger");

            return View();
        }

        public IActionResult Privacy()
        {
            var routeInfo = ControllerContext.ToCtxString();

            _logger.LogInformation(routeInfo);
            _logger.LogWarning(routeInfo + "Testing LogWarning");
            _logger.LogError("Not an error. Just to show the custom logger");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
