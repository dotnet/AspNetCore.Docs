using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;

namespace MVCareas.Areas.Products.Controllers
{
    [Area("Products")]
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