#define NoOrd

using FiltersSample.Filters;
using FiltersSample.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Docs.Samples;
using System.Reflection;

namespace FiltersSample.Controllers
{
#if NoOrd

    // <snippet>
    [MyAction2Filter]
    public class Test2Controller : Controller
    {
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
#else
    // <snippet2>
    [MyAction2Filter(int.MinValue)]
    public class Test2Controller : Controller
    {
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
    // </snippet2>
#endif
}