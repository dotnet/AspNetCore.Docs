using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebRateLimitAuth.Models;

namespace WebRateLimitAuth.Controllers
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

        public async Task<IActionResult> Privacy()
        {
            await Task.Delay(100);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
