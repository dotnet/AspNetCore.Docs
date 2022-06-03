using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Docs.Samples;

namespace SampleApp.Pages;

public class ContactModel : PageModel
{
    private readonly ILogger<ContactModel> _logger;

    public ContactModel(ILogger<ContactModel> logger)
    {
        _logger = logger;
    }

    public string? Message { get; private set; }
    public string? RouteDataTextTemplateValue { get; private set; }

    public void OnGet()
    {
        Message = "Your contact page.";

        if (RouteData.Values["text"] != null)
        {
            RouteDataTextTemplateValue = $"Route data for 'text' was provided: {RouteData.Values["text"]}";
        }
        _logger.LogInformation(PageContext.ToCtxStringP());
    }
}
