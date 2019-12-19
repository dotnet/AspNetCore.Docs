#region snippet1
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace PageFilter.Filters
{
    public class SampleAsyncPageFilter : IAsyncPageFilter
    {

        public async Task OnPageHandlerSelectionAsync(
                                            PageHandlerSelectedContext context)
        {
            context.HttpContext.Request.Headers.TryGetValue("user-agent", out StringValues value);
            ProcessUserAgent.Write(context.ActionDescriptor.DisplayName,
                                   "SampleAsyncPageFilter.OnPageHandlerSelectionAsync",
                                    value); 

             await Task.CompletedTask;
        }

        public async Task OnPageHandlerExecutionAsync(
                                            PageHandlerExecutingContext context,
                                            PageHandlerExecutionDelegate next)
        {
            // Do post work.
            await next.Invoke();
        }
    } 
}
#endregion
