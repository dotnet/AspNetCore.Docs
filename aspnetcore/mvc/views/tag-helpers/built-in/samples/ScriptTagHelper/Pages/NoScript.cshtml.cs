using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ScriptTagHelper.Pages;

public class NoScriptModel : PageModel
{
    private readonly ILogger<NoScriptModel> _logger;

    public NoScriptModel(ILogger<NoScriptModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}
