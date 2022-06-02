using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Docs.Samples;

namespace SampleApp.Pages.OtherPages;

public class Page2Model : PageModel
{
    private readonly ILogger<Page2Model> _logger;

    public Page2Model(ILogger<Page2Model> logger)
    {
        _logger = logger;
    }

    public string ? Message { get; private set; }

    public string ? RouteDataGlobalTemplateValue { get; private set; }

    public string ? RouteDataOtherPagesTemplateValue { get; private set; }

    public void OnGet()
    {
        Message = "Your application Page2 page.";

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
