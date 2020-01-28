//#define MYDEMO

using Microsoft.AspNetCore.Mvc;

// This uses same routes as HomeController, so only one can be defined
// Test with                     webBuilder.UseStartup<StartupDefaultMVC>();
// or with StartupMap
namespace RoutingSample.Controllers
{
#if MYDEMO
    #region snippet
    public class MyDemoController : Controller
    {
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public IActionResult MyIndex()
        {
            return Content("MyIndex");
        }
        [Route("Home/About")]
        public IActionResult MyAbout()
        {
            return Content("MyAbout");
        }
        [Route("Home/Contact")]
        public IActionResult MyContact()
        {
            return Content("MyContact");
        }
    }
    #endregion
#endif
}

