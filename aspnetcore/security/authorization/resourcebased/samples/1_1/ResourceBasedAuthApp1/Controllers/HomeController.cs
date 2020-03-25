using Microsoft.AspNetCore.Mvc;

namespace ResourceBasedAuthApp1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Error()
        {
            return View();
        }
    }
}
