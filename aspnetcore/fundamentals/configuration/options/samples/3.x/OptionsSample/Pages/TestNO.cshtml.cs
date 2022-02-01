using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using SampleApp.Models;

// Requires StartupNO in Main

namespace SampleApp.Pages
{
    // <snippet>
    public class TestNOModel : PageModel
    {
        private readonly TopItemSettings _monthTopItem;
        private readonly TopItemSettings _yearTopItem;

        public TestNOModel(IOptionsSnapshot<TopItemSettings> namedOptionsAccessor)
        {
            _monthTopItem = namedOptionsAccessor.Get(TopItemSettings.Month);
            _yearTopItem = namedOptionsAccessor.Get(TopItemSettings.Year);
        }

        public ContentResult OnGet()
        {
            return Content($"Month:Name {_monthTopItem.Name} \n" +
                           $"Month:Model {_monthTopItem.Model} \n\n" +
                           $"Year:Name {_yearTopItem.Name} \n" +
                           $"Year:Model {_yearTopItem.Model} \n"   );
        }
    }
    // </snippet>
}
