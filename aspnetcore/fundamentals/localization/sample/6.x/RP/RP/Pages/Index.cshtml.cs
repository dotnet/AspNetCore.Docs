using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace RP.Pages;
public class IndexModel : PageModel
{
    private readonly IStringLocalizer<SharedResources> _sharedLocalizer;

    public IndexModel(IStringLocalizer<SharedResources> sharedLocalizer, IStringLocalizer<IndexModel> indexPageLocalizer)
    {
        _sharedLocalizer = sharedLocalizer;
    }

    public LocalizedString Message { get; private set; }
    public LocalizedString AnotherMessage { get; private set; }

    public void OnGet()
    {
        Message = _sharedLocalizer["Good morning"];
        AnotherMessage = _sharedLocalizer["I am not in the resx"];
    }
}
