using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace PageFilter.Pages
{
    [BindProperty]
    public class Index2Model : PageModel
    {
        private readonly ILogger _logger;

        public Index2Model(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public string Message { get; set; }
        [Required]
        public string Query { get; set; }

        public void OnGet()
        {
            _logger.LogDebug("IndexModel/OnGet");
        }

        public void OnHead()
        {
            _logger.LogDebug("IndexModel/OnHead");
        }

        public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            _logger.LogDebug("IndexModel/OnPageHandlerSelected");

            if (context.RouteData.Values.Keys.Contains("id"))
            {
                //    context.HttpContext.Request.Method = Microsoft.AspNetCore.Http.HttpMethods.Head;

                context.HandlerMethod = new Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.HandlerMethodDescriptor();
                context.HandlerMethod.HttpMethod = "Head";
                //context.HttpContext.Response.Redirect("/About");
                _logger.LogDebug("IndexModel/OnPageHandlerSelected redirect to About");

                if (context.HandlerMethod.HttpMethod != null)
                {
                    var ht = context.HandlerMethod.HttpMethod;
                    _logger.LogDebug("IndexModel/OnPageHandlerSelected/HttpMethod :"
                        + ht);

                }
            }
        }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            Message = "Message set in handler executing";
            _logger.LogDebug("IndexModel/OnPageHandlerExecuting");
        }


        public override void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            _logger.LogDebug("IndexModel/OnPageHandlerExecuted");
        }
    }
}