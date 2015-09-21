using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using System.Threading.Tasks;

namespace AuthoringTagHelpers.TagHelpers3
{
    public class EmailTagHelper : TagHelper
    {
        private const string EmailDomain = "contoso.com";
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";    // Replaces <email> with <a> tag
            var content = await context.GetChildContentAsync();
            var target = content.GetContent() + "@" + EmailDomain;
            output.Attributes["href"] = "mailto:" + target;
            output.Content.SetContent(target);
        }
    }
}