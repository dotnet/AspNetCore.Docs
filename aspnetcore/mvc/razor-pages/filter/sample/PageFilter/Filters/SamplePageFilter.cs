#region snippet1
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace PageFilter.Filters
{
    public class SamplePageFilter : IPageFilter
    {
        private readonly ILogger _logger;

        public SamplePageFilter(ILogger logger)
        {
            _logger = logger;
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            _logger.LogDebug("Do something during page handler selection.");
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            _logger.LogDebug("Do something after handler selection,"
                + "but before a handler method executes."); 
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            _logger.LogDebug(" Do something after a handler method executes.");
        }
    }
}
#endregion