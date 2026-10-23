using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;

namespace MVCareas.Areas.Services.Controllers
{
    [Area("Services")]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["routeInfo"] = ControllerContext.MyDisplayRouteInfo();
            return View();
        }

        public IActionResult About()
        {
            ViewData["routeInfo"] = ControllerContext.MyDisplayRouteInfo();
            return View();
        }
    }
}