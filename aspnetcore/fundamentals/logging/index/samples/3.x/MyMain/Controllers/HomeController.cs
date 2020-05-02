using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;
using Microsoft.Extensions.Logging;
using MyMain.Models;

namespace MyMain.Controllers
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
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            ViewData["Message"] = $"ASPNETCORE_ENVIRONMENT = {env}";
            return View();
        }

        public IActionResult Privacy()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            ViewData["Message"] = $"ASPNETCORE_ENVIRONMENT = {env}";
            var routeInfo = ControllerContext.ToCtxString();
            _logger.LogWarning(2000,"Test  {x}", routeInfo);
            _logger.LogInformation(1100, "Test  {x}", routeInfo);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
