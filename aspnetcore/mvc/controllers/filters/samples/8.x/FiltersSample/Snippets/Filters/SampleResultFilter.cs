using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersSample.Snippets.Filters;

// <snippet_Class>
public class SampleResultFilter : IResultFilter
{
    public void OnResultExecuting(ResultExecutingContext context)
    {
        // Do something before the result executes.
    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
        // Do something after the result executes.
    }
}
// </snippet_Class>
