using Microsoft.AspNet.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace FiltersSample.Filters
{
    /// <summary>
    /// https://github.com/aspnet/Mvc/blob/master/test/WebSites/FiltersWebSite/Filters/AddHeaderAttribute.cs
    /// </summary>
    public class AddHeaderFilterWithDi : IResultFilter
    {
        private ILogger _logger;
        public AddHeaderFilterWithDi(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<AddHeaderFilterWithDi>();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var headerName = "OnResultExecuting";
            context.HttpContext.Response.Headers.Add(
                headerName, new string[] { "ResultExecutingSuccessfully" });
            _logger.LogInformation($"Header added: {headerName}");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            var headerName = "OnResultExecuted";
            context.HttpContext.Response.Headers.Add(
                headerName, new string[] { "ResultExecutedSuccessfully" });
            _logger.LogInformation($"Header added: {headerName}");

        }
    }
}