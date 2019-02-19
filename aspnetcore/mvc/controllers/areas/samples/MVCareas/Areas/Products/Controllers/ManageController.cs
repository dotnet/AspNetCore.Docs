using Microsoft.AspNetCore.Mvc;

namespace MVCareas.Areas.Products.Controllers
{
    [Area("Products")]
    public class ManageController : Controller
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