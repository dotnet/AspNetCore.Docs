#define Never
#if Never

using Microsoft.AspNetCore.Mvc;
namespace WebMvcRouting.Controllers
{
    #region snippet_1

    public class UrlGenerationController : Controller
    {
        public IActionResult Source()
        {
            // Generates /UrlGeneration/Destination
            var url = Url.Action("Destination");
            return Content($"Go check out {url}, it's really great.");
        }

        public IActionResult Destination()
        {
            return View();
        }
    }
    #endregion
#endif
}