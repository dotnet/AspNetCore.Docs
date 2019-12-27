using FiltersSample.Helper;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace FiltersSample.Filters
{
    public class TestActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            MyDebug.Write(MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);
            base.OnActionExecuted(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            MyDebug.Write(MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);
            base.OnActionExecuting(context);
        }
    }
}
