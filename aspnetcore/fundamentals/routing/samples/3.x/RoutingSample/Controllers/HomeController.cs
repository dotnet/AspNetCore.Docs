using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace RoutingSample.Controllers
{
    #region snippet
    [Host("contoso.com", "adventure-works.com")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Host("example.com:8080")]
        public IActionResult Privacy()
        {
            return View();
        }

    }
    #endregion
}
