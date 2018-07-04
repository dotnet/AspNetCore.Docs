using Microsoft.AspNetCore.Mvc;

namespace TagHelpersBuiltIn.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int? number)
        {
            ViewData["id"] = number?.ToString();

            return View();
        }

        public IActionResult About() => View();

        public IActionResult Error() => View();
    }
}
