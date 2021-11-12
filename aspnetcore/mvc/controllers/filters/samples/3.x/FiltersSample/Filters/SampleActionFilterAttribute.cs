using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace FiltersSample.Filters
{
    // <snippet_TypeFilterAttribute>
    public class SampleActionFilterAttribute : TypeFilterAttribute
    {
        public SampleActionFilterAttribute()
                             :base(typeof(SampleActionFilterImpl))
        { 
        }

        private class SampleActionFilterImpl : IActionFilter
        {
            private readonly ILogger _logger;
            public SampleActionFilterImpl(ILoggerFactory loggerFactory)
            {
                _logger = loggerFactory.CreateLogger<SampleActionFilterAttribute>();
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
               _logger.LogInformation("SampleActionFilterAttribute.OnActionExecuting");
            }

            public void OnActionExecuted(ActionExecutedContext context)
            {
                _logger.LogInformation("SampleActionFilterAttribute.OnActionExecuted");
            }
        }
    }
    // </snippet_TypeFilterAttribute>
}