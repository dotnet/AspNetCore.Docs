using Microsoft.AspNetCore.Mvc;

namespace AngularSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }

        public IActionResult Directives()
        {
            return View();
        }

        public IActionResult Databinding()
        {
            return View();
        }

        public IActionResult Templates()
        {
            return View();
        }

        public IActionResult Expressions()
        {
            return View();
        }
        public IActionResult Repeaters()
        {
            return View();
        }

        public IActionResult Repeaters2()
        {
            return View();
        }

        public IActionResult Scope()
        {
            return View();
        }

        public IActionResult Controllers()
        {
            return View();
        }

        public IActionResult Components()
        {
            return View();
        }

        public IActionResult PersonComponent()
        {
            return View();
        }
    }
}