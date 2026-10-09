using Microsoft.AspNetCore.Mvc;

namespace PartialViewsSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Discovery() => View();

        public IActionResult Error() => View();
    }
}
