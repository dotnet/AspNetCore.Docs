using System.Reflection;
using FiltersSample.Filters;
using FiltersSample.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersSample.Controllers
{
    #region snippet
    public class TestController : Controller
    {
        [SampleActionFilter]
        public IActionResult FilterTest2()
        {
            MyDebug.Write(MethodBase.GetCurrentMethod(), HttpContext.Request.Path);
            return Content(MethodBase.GetCurrentMethod().ToString());
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
#endregion
}