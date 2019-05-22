using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersSample.Filters
{
    #region snippet
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var result = context.Result;
            // Do something with Result.
            if (context.Canceled == true)
            {
                // Action execution was short-circuited by another filter.
            }

            base.OnActionExecuted(context);
        }
    }
    #endregion
}
