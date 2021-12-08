using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using StaticFilesSample.Models;

namespace StaticFilesSample.Controllers
{
    public class Home2Controller : Controller
    {
        private readonly ILogger<Home2Controller> _logger;

        public Home2Controller(ILogger<Home2Controller> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MyStaticFilesRR()
        {
            // Only returns image when calling 
            /*
             app.UseStaticFiles(new StaticFileOptions
            {
            FileProvider = new PhysicalFileProvider(
            Path.Combine(builder.Environment.ContentRootPath, "MyStaticFiles")),
            RequestPath = "/StaticFiles"
            });
            */
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}