using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomConfigurationProvider.Pages;
#region snippet1
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private IConfiguration Configuration;


    public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
    {
        _logger = logger;
        Configuration = configuration;
    }

    public ContentResult OnGet()
    {
        return Content($"Quote 1 : {Configuration["quote1"]} \n" +
                       $"Quote 2: {Configuration["quote2"]} \n" +
                       $"Quote 3: {Configuration["quote3"]}");
    }
}
#endregion
