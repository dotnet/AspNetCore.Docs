using FiltersSample.Helper;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace FiltersSample.Filters
{
    // <snippet>
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        private readonly PositionOptions _settings;

        public MyActionFilterAttribute(IOptions<PositionOptions> options)
        {
            _settings = options.Value;
            Order = 1;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add(_settings.Title, 
                                                     new string[] { _settings.Name });
            base.OnResultExecuting(context);
        }
    }
    // </snippet>
}

//            MyDebug.Write(MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);
