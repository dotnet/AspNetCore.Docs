using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ScriptTagHelper.Pages;

public class CollocatedScriptModel : PageModel
{
    private readonly ILogger<CollocatedScriptModel> _logger;

    public CollocatedScriptModel(ILogger<CollocatedScriptModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}
