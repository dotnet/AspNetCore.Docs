using Microsoft.AspNetCore.Mvc;

namespace TagHelpersBuiltInAspNetCore.Controllers
{
    public class BuiltInTagController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult AnchorTagHelper() => View();
    }
}
