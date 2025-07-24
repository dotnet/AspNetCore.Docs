using ConfigSample.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConfigSample.Pages;

// <snippet>
public class Test33Model : PageModel
{
    private readonly IConfiguration Configuration;

    public Test33Model(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public ContentResult OnGet()
    {
        var nameTitleOptions = new NameTitleOptions(22);
        Configuration.GetSection(NameTitleOptions.NameTitle).Bind(nameTitleOptions);

        return Content($"Title: {nameTitleOptions.Title} \n" +
                       $"Name: {nameTitleOptions.Name}  \n" +
                       $"Age: {nameTitleOptions.Age}"
                       );
    }
}
// </snippet>
