#region snippet1
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace PageFilter.Filters
{
    public class SampleAsyncPageFilter : IAsyncPageFilter
    {
        private readonly ILogger _logger;

        public SampleAsyncPageFilter(ILogger logger)
        {
            _logger = logger;
        }

        public async Task OnPageHandlerSelectionAsync(
                                            PageHandlerSelectedContext context)
        {
            _logger.LogDebug("Global OnPageHandlerSelectionAsync called.");
            await Task.CompletedTask;
        }

        public async Task OnPageHandlerExecutionAsync(
                                            PageHandlerExecutingContext context,
                                            PageHandlerExecutionDelegate next)
        {
            _logger.LogDebug("Global OnPageHandlerExecutionAsync called.");
            await next.Invoke();
        }
    }
}
#endregion