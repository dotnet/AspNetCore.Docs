using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersSample.Filters
{
    // <snippet2>
    // <snippet>
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext 
                                               context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(
                                                    context.ModelState);
            }
        }
        // </snippet>


        public override void OnActionExecuted(ActionExecutedContext 
                                              context)
        {
            var result = context.Result;
            // Do something with Result.
            if (context.Canceled == true)
            {
                // Action execution was short-circuited by another filter.
            }

            if(context.Exception != null)
            {
                // Exception thrown by action or action filter.
                // Set to null to handle the exception.
                context.Exception = null;
            }
            base.OnActionExecuted(context);
        }
    }
    // </snippet2>
}
