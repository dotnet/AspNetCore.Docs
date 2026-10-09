using Microsoft.AspNetCore.Mvc;

namespace SpaServicesSampleApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Error() => View();
    }
}