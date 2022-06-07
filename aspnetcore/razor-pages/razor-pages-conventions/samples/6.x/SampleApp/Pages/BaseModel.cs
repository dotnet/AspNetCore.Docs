using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Docs.Samples;

namespace SampleApp.Pages
{
    public class BaseModel : PageModel
    {

        public readonly ILogger<BaseModel> _logger;

        public BaseModel(ILogger<BaseModel> logger)
        {
            _logger = logger;
        }

        public string? Message { get; set; }
        public string? RouteDataGlobalTemplateValue { get;  set; }
        public string? RouteDataOtherPagesTemplateValue { get;  set; }

        #region snippet1
        public void SetTemplateData(string className)
        {
            Message = $"Your application {className} page.";
            if (RouteData.Values["globalTemplate"] != null)
            {
                RouteDataGlobalTemplateValue =
                    $"Route data for 'globalTemplate' was provided:" +
                    $" {RouteData.Values["globalTemplate"]}";
            }

            if (RouteData.Values["otherPagesTemplate"] != null)
            {
                RouteDataOtherPagesTemplateValue =
                    $"Route data for 'otherPagesTemplate' was provided:" +
                    $" {RouteData.Values["otherPagesTemplate"]}";
            }
            _logger.LogInformation(PageContext.ToCtxStringP());
        }
        #endregion
    }
}
