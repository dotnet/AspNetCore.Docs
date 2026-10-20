using Microsoft.AspNetCore.Mvc;
using MVCareas.Models;
using System.Diagnostics;
using Microsoft.Docs.Samples;

namespace MVCareas.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["routeInfo"] = ControllerContext.MyDisplayRouteInfo();
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["routeInfo"] = ControllerContext.MyDisplayRouteInfo();
            return View();
        }

        public IActionResult About()
        {
            ViewData["routeInfo"] = ControllerContext.MyDisplayRouteInfo();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
