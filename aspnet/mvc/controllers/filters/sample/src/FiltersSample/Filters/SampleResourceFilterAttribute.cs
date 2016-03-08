using System;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc.Filters;

namespace FiltersSample.Filters
{
    public class SampleResourceFilterAttribute : Attribute,
            IResourceFilter
    {
        public string Name { get; }

        public SampleResourceFilterAttribute(string name)
        {
            Name = name;
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Response.Headers.Append("filters", Name + " - OnResourceExecuting");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            context.HttpContext.Response.Headers.Append("filters", Name + " - OnResourceExecuted");
        }
    }
}
