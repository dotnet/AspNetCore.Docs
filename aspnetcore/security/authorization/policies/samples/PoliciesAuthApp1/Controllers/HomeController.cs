using Microsoft.AspNetCore.Mvc;

namespace PoliciesAuthApp1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Error() => View();
    }
}
