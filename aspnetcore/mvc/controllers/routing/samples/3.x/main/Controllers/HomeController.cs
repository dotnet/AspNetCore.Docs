// This uses same routes as MyDemoController, so only one can be defined unless order is set
// Test with 

//#define First
//#define Second
//#define Third
//#define Forth

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
        public IActionResult Index() =>
            ControllerContext.ToActionResult();

        [Route("About")]
        public IActionResult About() =>
            ControllerContext.ToActionResult();
    }
    #endregion
#elif Second
    #region snippet2
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public IActionResult Index() =>
            ControllerContext.ToActionResult();

        [Route("Home/About")]
        public IActionResult About()=>
            ControllerContext.ToActionResult();

        [Route("Home/Contact")]
        public IActionResult Contact()=>
            ControllerContext.ToActionResult();
    }
    #endregion
#elif Third
    #region snippet22
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Home")]
        [Route("[controller]/[action]")]
        public IActionResult Index() =>
            ControllerContext.ToActionResult();

        [Route("[controller]/[action]")]
        public IActionResult About() =>
            ControllerContext.ToActionResult();

        [Route("[controller]/[action]")]
        public IActionResult Contact() =>
            ControllerContext.ToActionResult();
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
        public IActionResult Index() =>
            ControllerContext.ToActionResult();

        public IActionResult About() =>
            ControllerContext.ToActionResult();

        public IActionResult Contact() =>
            ControllerContext.ToActionResult();
    }
    #endregion
#endif
}

