using ConfigSample.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConfigSample.Pages;

// <snippet>
public class Test21Model : PageModel
{
    private readonly IConfiguration Configuration;
    public PositionOptions? positionOptions { get; private set; }

    public Test21Model(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public ContentResult OnGet()
    {
        positionOptions = Configuration.GetSection(PositionOptions.Position)
                                                     .Get<PositionOptions>();

        if (positionOptions == null)
        {
            throw new ArgumentNullException(nameof(positionOptions));
        }

        return Content($"Title: {positionOptions.Title} \n" +
                       $"Name: {positionOptions.Name}");
    }
}
// </snippet>
