using Microsoft.AspNetCore.Mvc;

namespace MVCareas.Areas.Products.Controllers
{
    [Area("Products")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["url"] = Url.Action("About", "Manage");

            return View();
        }
    }
}