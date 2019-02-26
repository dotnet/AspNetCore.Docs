using Microsoft.AspNetCore.Mvc;

namespace MVCareas.Areas.Services.Controllers
{
    [Area("Services")]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}