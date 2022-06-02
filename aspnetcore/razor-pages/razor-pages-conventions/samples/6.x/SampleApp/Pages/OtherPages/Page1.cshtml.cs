using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Docs.Samples;

namespace SampleApp.Pages.OtherPages;

public class Page1Model : PageModel
{
    private readonly ILogger<Page1Model> _logger;

    public Page1Model(ILogger<Page1Model> logger)
    {
        _logger = logger;
    }

    public string ? Message { get; private set; }
    public string ? RouteDataGlobalTemplateValue { get; private set; }
    public string ? RouteDataOtherPagesTemplateValue { get; private set; }

    #region snippet1
    public void OnGet()
    {
        Message = "Your application Page1 page.";

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
