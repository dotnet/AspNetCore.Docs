// This uses same routes as MyDemoController, so only one can be defined
// Test with StartupDefaultMVC

#define First
//#define Second

using Microsoft.AspNetCore.Mvc;


namespace WebMvcRouting.Controllers
{
#if First

    #region snippet
     [Route("Home")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Index")]
        [Route("/")]
        public IActionResult Index()
        {
            var url = Url.Action("Index", "Home");
            ViewData["Message"] = $"Home index:  Url.Action =  {url}";

            return View();
        }

        [Route("About")]
        public IActionResult About()
        {
            return View();
        }
    }
    #endregion
#elif Second
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
#elif Third
   
#endif
}

