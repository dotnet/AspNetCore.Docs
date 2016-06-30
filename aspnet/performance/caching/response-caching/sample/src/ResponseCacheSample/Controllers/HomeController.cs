using Microsoft.AspNetCore.Mvc;

namespace ResponseCacheSample.Controllers
{
    [ResponseCache(Duration = 30)]
    public class HomeController : Controller
    {
        [ResponseCache(CacheProfileName = "Default")]
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [ResponseCache(Duration = 60)]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
