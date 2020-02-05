// This uses same routes as MyDemoController, so only one can be defined unless order is set
// Test with 

#define First
//#define Second

using Microsoft.AspNetCore.Mvc;


namespace WebMvcRouting.Controllers
{
#if First

    #region snippet
    #region snippet3
    [Route("Home")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Index")]
        [Route("/")]
        public IActionResult Index()
        {
            var url = Url.Action("Index", "Home");

            var template = ControllerContext.ActionDescriptor.AttributeRouteInfo.Template;
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;

            return Content($"Url: {url} template:{template} " +
                $" controller:{controllerName}  action name: {actionName}");
        }
        #endregion

        [Route("About")]
        public IActionResult About()
        {
            var template = ControllerContext.ActionDescriptor.AttributeRouteInfo.Template;
            var actionName = ControllerContext.ActionDescriptor.ActionName;
            var controllerName = ControllerContext.ActionDescriptor.ControllerName;

            return Content($"template:{template} " +
                $" controller:{controllerName}  action name: {actionName}");
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

