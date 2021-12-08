using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersSample.Filters;

// <snippet_Class>
public class ResponseHeaderFilterFactory : Attribute, IFilterFactory
{
    public bool IsReusable => false;

    public IFilterMetadata CreateInstance(IServiceProvider serviceProvider) =>
        new InternalResponseHeaderFilter();

    private class InternalResponseHeaderFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context) =>
            context.HttpContext.Response.Headers.Add(
                nameof(OnActionExecuting), nameof(InternalResponseHeaderFilter));

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
    // </snippet_Class>
}
