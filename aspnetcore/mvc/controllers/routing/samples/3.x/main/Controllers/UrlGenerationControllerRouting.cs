#define First
#if First

// TODO Add name in content output
using Microsoft.AspNetCore.Mvc;
namespace WebMvcRouting.Controllers
{
    #region snippet_1
    public class UrlGeneration2Controller : Controller
    {
        [HttpGet("")]
        public IActionResult Source()
        {
            // Generates /custom/url/to/destination
            var url = Url.RouteUrl("Destination_Route");
            return Content($"See {url}, it's really great.");
        }

        [HttpGet("custom/url/to/destination", Name = "Destination_Route")]
        public IActionResult Destination()
        {
            return View();
        }
    }
    #endregion
#endif
}