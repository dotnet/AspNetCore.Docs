using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomConfigurationProvider.Pages;
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
        var quote1 = Configuration["quote1"];
        var quote2 = Configuration["quote2"];
        var quote3 = Configuration["quote3"];


        return Content($"Quote 1 : {quote1} \n" +
                       $"Quote 2: {quote2} \n" +
                       $"Quote 3: {quote3}");
    }
}
