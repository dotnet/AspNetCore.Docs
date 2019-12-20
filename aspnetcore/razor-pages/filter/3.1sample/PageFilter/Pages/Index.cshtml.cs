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

        public void OnGet()
        {

        }

        public async override Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        {
            Debug.WriteLine("/IndexModel OnPageHandlerExecutionAsync");

            await Task.CompletedTask;
        }

        public async override Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, 
                                                               PageHandlerExecutionDelegate next)
        {
            var key = _config.GetValue(typeof(string), "UserAgentID");
            context.HttpContext.Request.Headers.TryGetValue("user-agent", out StringValues value);
            ProcessUserAgent.Write(context.ActionDescriptor.DisplayName,
                                   "/IndexModel-OnPageHandlerSelectionAsync",
                                    value, key.ToString());

            await next.Invoke();
        }
        #endregion
    }
}