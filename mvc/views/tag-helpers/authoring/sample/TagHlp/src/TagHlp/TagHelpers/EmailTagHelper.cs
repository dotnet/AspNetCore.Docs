using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using System.Threading.Tasks;

namespace TagHlp.TagHelpers
{
    [TargetElement("email")]
    public class EmailTagHelper : TagHelper
    {
        public static string EmailDomain = "example.com";
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";    // Replaces <email> with <a> tag
            var content = await context.GetChildContentAsync();
            output.Attributes["href"] = "mailto:" + content.GetContent() + "@" + EmailDomain;
            output.Content.SetContent(content.GetContent() + "@" + EmailDomain);
        }
    }
}

