// This uses same routes as MyDemoController, so only one can be defined unless order is set
// Test with 

//#define First
//#define Second
//#define Third
#define Forth

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

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
            return new CCAD().GetADinfo(ControllerContext);
        }

        [Route("About")]
        public IActionResult About()
        {
            return new CCAD().GetADinfo(ControllerContext);
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
            return new CCAD().GetADinfo(ControllerContext);
        }

        [Route("Home/About")]
        public IActionResult About()
        {
            return new CCAD().GetADinfo(ControllerContext);
        }

        [Route("Home/Contact")]
        public IActionResult Contact()
        {
            return new CCAD().GetADinfo(ControllerContext);
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
            return new CCAD().GetADinfo(ControllerContext);
        }

        [Route("[controller]/[action]")]
        public IActionResult About()
        {
            return new CCAD().GetADinfo(ControllerContext);
        }

        [Route("[controller]/[action]")]
        public IActionResult Contact()
        {
            return new CCAD().GetADinfo(ControllerContext);
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
            return new CCAD().GetADinfo(ControllerContext);
        }

        public IActionResult About()
        {
            return new CCAD().GetADinfo(ControllerContext);
        }

        public IActionResult Contact()
        {
            return new CCAD().GetADinfo(ControllerContext);
        }
    }
    #endregion
#endif
}

