using Microsoft.AspNetCore.Mvc;
namespace WebMvcRouting.Controllers
{
#region snippet_1
    public class UrlGeneration3Controller : Controller
    {
        public IActionResult Index()
        {
            var x = Request.Scheme;
            return View("MyLink");
        }
    }
#endregion
}