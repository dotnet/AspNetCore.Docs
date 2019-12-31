using FiltersSample.Filters;
using FiltersSample.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace FiltersSample.Controllers
{
    #region snippetAll
    #region snippet
    [SampleActionFilter(Order = int.MinValue)]
    #endregion
    public class Test3Controller : Controller
    {
        public IActionResult FilterTest2()
        {
            var m = MethodBase.GetCurrentMethod();
            MyDebug.Write(m, HttpContext.Request.Path);
            return Content(m.ReflectedType.Name + "." + m.Name);
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