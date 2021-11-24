using Microsoft.AspNetCore.Mvc.RazorPages;
using SessionSample.Middleware;

namespace SessionSample.Pages
{
    #region snippet
    public class Index2Model : PageModel
    {
        private readonly ILogger<Index2Model> _logger;

        public Index2Model(ILogger<Index2Model> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            HttpContext.Items
                .TryGetValue(HttpContextItemsMiddleware.HttpContextItemsMiddlewareKey,
                    out var middlewareSetValue);

            _logger.LogInformation("Middleware value {MV}",
                middlewareSetValue?.ToString() ?? "Middleware value not set!");
        }
    }
    #endregion
}
