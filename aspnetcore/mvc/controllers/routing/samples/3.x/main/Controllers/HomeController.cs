// This controller must be commented out to test MyDemo controller
///#define First

using Microsoft.AspNetCore.Mvc;


namespace WebMvcRouting.Controllers
{
#if First

    #region snippet
    [Route("Home")]
    public class HomeController : Controller
    {
        [Route("")]      // Combines to define the route template "Home"
        [Route("Index")] // Combines to define the route template "Home/Index"
        [Route("/")]     // Does not combine, defines the route template ""
        public IActionResult Index()
        {
            ViewData["Message"] = "Home index";
            var url = Url.Action("Index", "Home");
            ViewData["Message"] = "Home index" + "var url = Url.Action; =  " + url;
            return View();
        }

        [Route("About")] // Combines to define the route template "Home/About"
        public IActionResult About()
        {
            return View();
        }
    }
    #endregion
#elif Second
    // Test with webBuilder.UseStartup<StartupMap>();

    #region snippet2
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public IActionResult Index()
        {
            return Content("Index");
        }
        [Route("Home/About")]
        public IActionResult About()
        {
            return Content("About");
        }
        [Route("Home/Contact")]
        public IActionResult Contact()
        {
            return Content("Contact");
        }
    }
    #endregion
#endif
}

