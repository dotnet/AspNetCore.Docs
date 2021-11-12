using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace FiltersSample.Filters
{
    /// <summary>
    /// https://github.com/aspnet/Mvc/blob/master/test/WebSites/FiltersWebSite/Filters/AddHeaderAttribute.cs
    /// </summary>
    // <snippet_ResultFilter>
    public class AddHeaderResultServiceFilter : IResultFilter
    {
        private ILogger _logger;
        public AddHeaderResultServiceFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<AddHeaderResultServiceFilter>();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var headerName = "OnResultExecuting";
            context.HttpContext.Response.Headers.Add(
                headerName, new string[] { "ResultExecutingSuccessfully" });
            _logger.LogInformation("Header added: {HeaderName}", headerName);
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // Can't add to headers here because response has started.
            _logger.LogInformation("AddHeaderResultServiceFilter.OnResultExecuted");
        }
    }
    // </snippet_ResultFilter>
}