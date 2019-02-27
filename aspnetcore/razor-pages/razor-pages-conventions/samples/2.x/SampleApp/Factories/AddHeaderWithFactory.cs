using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SampleApp.Factories
{
    #region snippet1
    public class AddHeaderWithFactory : IFilterFactory
    {
        // Implement IFilterFactory
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return new AddHeaderFilter();
        }

        private class AddHeaderFilter : IResultFilter
        {
            public void OnResultExecuting(ResultExecutingContext context)
            {
                context.HttpContext.Response.Headers.Add(
                    "FilterFactoryHeader", 
                    new string[] 
                    { 
                        "Filter Factory Header Value 1",
                        "Filter Factory Header Value 2"
                    });
            }

            public void OnResultExecuted(ResultExecutedContext context)
            {
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
    #endregion
}
