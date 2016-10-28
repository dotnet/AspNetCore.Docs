using Microsoft.AspNetCore.Mvc;
using RazorSample.Models;

namespace RazorSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact(int ? id)
        {
            var viewName = id==null ? "Contact" : "Contact" + id.ToString();

            return View(viewName);
        }

        public IActionResult Login(int? id)
        {
            var viewName = id == null ? "Login" : "Login" + id.ToString();
            return View(viewName, new LoginViewModel { Email = "Rick@Example.com" });
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
