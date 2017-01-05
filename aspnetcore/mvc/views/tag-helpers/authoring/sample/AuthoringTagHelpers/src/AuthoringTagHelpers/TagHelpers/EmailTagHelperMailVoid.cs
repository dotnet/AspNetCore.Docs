using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace AuthoringTagHelpers.TagHelpers21
{
    [HtmlTargetElement("email", TagStructure = TagStructure.WithoutEndTag)] 
    public class EmailVoidTagHelper : TagHelper
    {
        private const string EmailDomain = "contoso.com";
        // Code removed for brevity

        // Can be passed via <email mail-to="..." />. 
        // Pascal case gets translated into lower-kebab-case.
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

            return View("ContactSelfClose");
        }
*/
