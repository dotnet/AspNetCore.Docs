using Microsoft.AspNetCore.Mvc;

namespace TagHelpersBuiltInAspNetCore.Controllers
{
    public class BuiltInTag : Controller
    {
        public IActionResult Index() => View();

        public IActionResult AnchorTagHelper() => View();
    }
}
