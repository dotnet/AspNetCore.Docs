using ConfigSample.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace ConfigSample.Pages
{
    public class Test25Model : PageModel
    {
        private readonly PositionOptions _options;
        private readonly ColorOptions _color_options;


        public Test25Model(IOptions<PositionOptions> options,
                           IOptions<ColorOptions> colorOptions)
        {
            _options = options.Value;
            _color_options = colorOptions.Value;
        }

        public ContentResult OnGet()
        {
            return Content($"Title: {_options.Title} \n" +
                           $"Name: {_options.Name} \n" +
                           $"Foreground: {_color_options.Foreground} \n" +
                           $"Background: {_color_options.Background}");
        }
    }
}
