using Microsoft.AspNetCore.Mvc;

namespace ResponseCacheSample.Controllers
{
    #region snippet_controller
    [ResponseCache(Duration = 30)]
    public class HomeController : Controller
    {
        [ResponseCache(CacheProfileName = "Default")]
        public IActionResult Index()
        {
            return View();
        }
        #endregion
        #region snippet_about
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        #endregion
        #region snippet_duration
        [ResponseCache(Duration = 60)]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        #endregion
        #region snippet1
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
        #endregion
        #region snippet_VaryByHeader
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        public IActionResult About2()
        {
            #endregion

            ViewData["Message"] = "About2 VaryByHeader ";

            return View("About");
        }
    }
}
