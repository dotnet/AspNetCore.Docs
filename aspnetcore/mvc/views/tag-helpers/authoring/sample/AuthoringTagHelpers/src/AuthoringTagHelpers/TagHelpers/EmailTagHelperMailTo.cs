using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace AuthoringTagHelpers.TagHelpers2
{
    public class EmailTagHelper : TagHelper
    {
        private const string EmailDomain = "contoso.com";

        // Can be passed via <email mail-to="..." />. 
        // PascalCase gets translated into kebab-case.
        public string MailTo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";    // Replaces <email> with <a> tag

            var address = MailTo + "@" + EmailDomain;
            output.Attributes.SetAttribute("href", "mailto:" + address);
            output.Content.SetContent(address);
        }
    }
}

/* Update home controller to test this change

public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View("ContactCopy");
        }
*/
