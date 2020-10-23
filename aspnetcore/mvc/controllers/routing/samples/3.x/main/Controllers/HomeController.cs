// This uses same routes as MyDemoController, so only one can be defined unless order is set
// Test with 

//#define First
//#define Second
//#define Third

#define Forth

using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;

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
            return ControllerContext.MyDisplayRouteInfo();
        }

        [Route("About")]
        public IActionResult About()
        {
            return ControllerContext.MyDisplayRouteInfo();
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
        [Route("Home/Index/{id?}")]
        public IActionResult Index(int? id)
        {
            return ControllerContext.MyDisplayRouteInfo(id);
        }

        [Route("Home/About")]
        [Route("Home/About/{id?}")]
        public IActionResult About(int? id)
        {
            return ControllerContext.MyDisplayRouteInfo(id);
        }
    }
    #endregion
#elif Third
    #region snippet22
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Home")]
        [Route("[controller]/[action]")]
        public IActionResult Index()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }

        [Route("[controller]/[action]")]
        public IActionResult About()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }
    }
    #endregion

#elif Forth
    #region snippet24
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        [Route("~/")]
        [Route("/Home")]
        [Route("~/Home/Index")]
        public IActionResult Index()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }

        public IActionResult About()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }
    }
    #endregion
#endif
}

