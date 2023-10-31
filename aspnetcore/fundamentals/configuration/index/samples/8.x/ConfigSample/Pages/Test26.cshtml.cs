using ConfigSample.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection.ConfigSample.Options;
using Microsoft.Extensions.Options;

namespace ConfigSample.Pages
{
    public class Test26Model : PageModel
    {
        private readonly PositionOptions _options;
        private readonly ColorOptions _color_options;
        private readonly IMyDependency _myDependency;

        public Test26Model(IOptions<PositionOptions> options,
                           IMyDependency myDependency,
                           IOptions<ColorOptions> colorOptions)
        {
            _options = options.Value;
            _color_options = colorOptions.Value;
            _myDependency = myDependency;
        }

        public ContentResult OnGet()
        {
            _myDependency.WriteMessage("Test26Model created this message.");
            return Content($"Title: {_options.Title} \n" +
                           $"Name: {_options.Name} \n" +
                           $"Foreground: {_color_options.Foreground} \n" +
                           $"Background: {_color_options.Background}");
        }
    }
}
