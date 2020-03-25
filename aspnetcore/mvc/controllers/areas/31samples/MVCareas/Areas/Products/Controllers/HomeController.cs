using Microsoft.AspNetCore.Mvc;

namespace MVCareas.Areas.Products.Controllers
{
    [Area("Products")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["routeInfo"] = ControllerContext.ToCtxString();
            return View();
        }

        public IActionResult About()
        {
            ViewData["routeInfo"] = ControllerContext.ToCtxString();
            return View();
        }
    }
}