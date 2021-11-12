using System.Reflection;
using FiltersSample.Filters;
using FiltersSample.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Docs.Samples;

namespace FiltersSample.Controllers
{
    // <snippet>
    public class TestController : Controller
    {
        [SampleActionFilter(Order = int.MinValue)]
        public IActionResult FilterTest2()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Do something before the action executes.
            MyDebug.Write(MethodBase.GetCurrentMethod(), HttpContext.Request.Path);
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
            MyDebug.Write(MethodBase.GetCurrentMethod(), HttpContext.Request.Path);
            base.OnActionExecuted(context);
        }
    }
    // </snippet>
}