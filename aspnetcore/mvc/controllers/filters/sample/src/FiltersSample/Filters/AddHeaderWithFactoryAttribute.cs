using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersSample.Filters
{
    #region snippet_IFilterFactory
    public class AddHeaderWithFactoryAttribute : Attribute, IFilterFactory
    {
        // Implement IFilterFactory
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return new InternalAddHeaderFilter();
        }

        private class InternalAddHeaderFilter : IResultFilter
        {
            public void OnResultExecuting(ResultExecutingContext context)
            {
                context.HttpContext.Response.Headers.Add(
                    "Internal", new string[] { "Header Added" });
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