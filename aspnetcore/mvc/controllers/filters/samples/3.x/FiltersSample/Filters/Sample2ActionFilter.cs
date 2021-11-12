using FiltersSample.Helper;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace FiltersSample.Filters
{
    // <snippet2>
    public class MyAction2FilterAttribute : ActionFilterAttribute
    {
        public MyAction2FilterAttribute(int Order=0)
        {
            this.Order = Order;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            MyDebug.Write(MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            MyDebug.Write(MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);

            base.OnActionExecuted(context);
        }
    }
    // </snippet2>
}
