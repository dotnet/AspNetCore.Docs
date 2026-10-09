using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System.Diagnostics;

namespace PageFilter.Filters
{
    #region snippet1
    public class SamplePageFilter : IPageFilter
    {
        private readonly IConfiguration _config;

        public SamplePageFilter(IConfiguration config)
        {
            _config = config;
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            var key = _config["UserAgentID"];
            context.HttpContext.Request.Headers.TryGetValue("user-agent", out StringValues value);
            ProcessUserAgent.Write(context.ActionDescriptor.DisplayName,
                                   "SamplePageFilter.OnPageHandlerSelected",
                                   value, key.ToString());
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            Debug.WriteLine("Global sync OnPageHandlerExecuting called.");
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            Debug.WriteLine("Global sync OnPageHandlerExecuted called.");
        }
    }
    #endregion
}
