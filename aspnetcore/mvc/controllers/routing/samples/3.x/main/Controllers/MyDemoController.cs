using Microsoft.AspNetCore.Mvc;

// Test with                     webBuilder.UseStartup<StartupMVC>();
// or with StartupMap
namespace RoutingSample.Controllers
{
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
}
