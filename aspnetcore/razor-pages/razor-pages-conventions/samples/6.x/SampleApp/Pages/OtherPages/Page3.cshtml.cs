using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Docs.Samples;
using SampleApp.Filters;

namespace SampleApp.Pages.OtherPages;

[ReplaceRouteValueFilter]
public class Page3Model : PageModel
{
    private readonly ILogger<Page3Model> _logger;

    public Page3Model(ILogger<Page3Model> logger)
    {
        _logger = logger;
    }
    public string ? Message { get; private set; }
    public string ? RouteDataGlobalTemplateValue { get; private set; }
    public string ? RouteDataOtherPagesTemplateValue { get; private set; }

    public void OnGet()
    {
        Message = "Your application Page3 page.";

        if (RouteData.Values["globalTemplate"] != null)
        {
            RouteDataGlobalTemplateValue = $"Route data for 'globalTemplate' was provided: {RouteData.Values["globalTemplate"]}";
        }

        if (RouteData.Values["otherPagesTemplate"] != null)
        {
            RouteDataOtherPagesTemplateValue = $"Route data for 'otherPagesTemplate' was provided: {RouteData.Values["otherPagesTemplate"]}";
        }
        _logger.LogInformation(PageContext.ToCtxStringP());
    }
}
