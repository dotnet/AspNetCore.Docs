using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PageFilter
{
    #region snippet
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;

        public IndexModel(IConfiguration config)
        {
            _config = config;
        }

        public override Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        {
            Debug.WriteLine("/IndexModel OnPageHandlerSelectionAsync");
            return Task.CompletedTask;
        }

        public async override Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, 
                                                               PageHandlerExecutionDelegate next)
        {
            var key = _config["UserAgentID"];
            context.HttpContext.Request.Headers.TryGetValue("user-agent", out StringValues value);
            ProcessUserAgent.Write(context.ActionDescriptor.DisplayName,
                                   "/IndexModel-OnPageHandlerExecutionAsync",
                                    value, key.ToString());

            await next.Invoke();
        }
    }
    #endregion
}
