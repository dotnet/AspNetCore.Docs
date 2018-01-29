using Microsoft.AspNetCore.Mvc;

namespace TagHelpersBuiltInAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int? number)
        {
            ViewData["id"] = number?.ToString();

            return View();
        }

        public IActionResult Error() => View();

        public IActionResult AboutBlog() => View();
    }
}
