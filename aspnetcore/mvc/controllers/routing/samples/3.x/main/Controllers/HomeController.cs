// This uses same routes as MyDemoController, so only one can be defined unless order is set
// Test with 

//#define First
//#define Second
//#define Third
//#define Forth
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
            return GetADinfo(ControllerContext.ActionDescriptor);
        }

        [Route("About")]
        public IActionResult About()
        {
            return GetADinfo(ControllerContext.ActionDescriptor);
        }

        private ContentResult GetADinfo(ControllerActionDescriptor actionDesc)
        {
            var template = actionDesc.AttributeRouteInfo.Template;
            var actionName = actionDesc.ActionName;
            var controllerName = actionDesc.ControllerName;

            return Content($" template:{template} {controllerName}.{actionName}");
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
            return GetRteData(ControllerContext.ActionDescriptor);
        }
        [Route("Home/About")]
        public IActionResult About()
        {
            return GetRteData(ControllerContext.ActionDescriptor);
        }
        [Route("Home/Contact")]
        public IActionResult Contact()
        {
            return GetRteData(ControllerContext.ActionDescriptor);
        }

        private ContentResult GetRteData(ControllerActionDescriptor actionDesc)
        {
            var template = actionDesc.AttributeRouteInfo.Template;
            var actionName = actionDesc.ActionName;
            var controllerName = actionDesc.ControllerName;

            return Content($" template:{template} " +
                $" controller:{controllerName}  action name: {actionName}");
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
            return GetRteData(ControllerContext.ActionDescriptor);
        }

        [Route("[controller]/[action]")]
        public IActionResult About()
        {
            return GetRteData(ControllerContext.ActionDescriptor);
        }

        [Route("[controller]/[action]")]
        public IActionResult Contact()
        {
            return GetRteData(ControllerContext.ActionDescriptor);
        }
#endregion

        private ContentResult GetRteData(ControllerActionDescriptor actionDesc)
        {
            var template = actionDesc.AttributeRouteInfo.Template;
            var actionName = actionDesc.ActionName;
            var controllerName = actionDesc.ControllerName;

            return Content($" template:{template} " +
                $" controller:{controllerName}  action name: {actionName}");
        }
    }
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
            return GetRteData(ControllerContext.ActionDescriptor);
        }

        public IActionResult About()
        {
            return GetRteData(ControllerContext.ActionDescriptor);
        }

        public IActionResult Contact()
        {
            return GetRteData(ControllerContext.ActionDescriptor);
        }
#endregion

        private ContentResult GetRteData(ControllerActionDescriptor actionDesc)
        {
            var template = actionDesc.AttributeRouteInfo.Template;
            var actionName = actionDesc.ActionName;
            var controllerName = actionDesc.ControllerName;

            return Content($" template:{template} " +
                $" controller:{controllerName}  action name: {actionName}");
        }
    }
#endif
}

