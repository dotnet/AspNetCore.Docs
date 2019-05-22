using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersSample.Filters
{
    #region snippet_ActionFilter
    public class MySampleActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do something before the action executes.
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var result = context.Result;
            // Do something after the action executes.
        }
    }
    #endregion
}