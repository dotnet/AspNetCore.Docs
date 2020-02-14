#define MYDEMO

using Microsoft.AspNetCore.Mvc;

// This uses same routes as HomeController, and MyDemo3Controller so only one can be defined
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
        public IActionResult MyIndex() =>
            ControllerContext.ToActionResult();

        [Route("Home/About")]
        public IActionResult MyAbout() =>
            ControllerContext.ToActionResult();

        [Route("Home/Contact")]
        public IActionResult MyContact() =>
            ControllerContext.ToActionResult();
    }
    #endregion
#endif
}

