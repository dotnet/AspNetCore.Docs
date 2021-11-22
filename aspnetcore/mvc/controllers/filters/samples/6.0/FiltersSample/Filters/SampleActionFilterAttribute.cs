using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersSample.Filters;

public class SampleActionFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine(
            $"- {nameof(SampleActionFilterAttribute)}.{nameof(OnActionExecuting)}");

        base.OnActionExecuting(context);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine(
            $"- {nameof(SampleActionFilterAttribute)}.{nameof(OnActionExecuted)}");

        base.OnActionExecuted(context);
    }
}
