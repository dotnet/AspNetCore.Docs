#define MYDEMO

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

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
            return GetRteData(ControllerContext.ActionDescriptor);
        }
        [Route("Home/About")]
        public IActionResult MyAbout()
        {
            return GetRteData(ControllerContext.ActionDescriptor);
        }
        [Route("Home/Contact")]
        public IActionResult MyContact()
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

