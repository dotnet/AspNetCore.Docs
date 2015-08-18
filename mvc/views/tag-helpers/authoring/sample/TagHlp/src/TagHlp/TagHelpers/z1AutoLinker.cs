/*
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TagHlp.TagHelpers
{
    [TargetElement("p")]
    public class AutoLinkerHttpTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await context.GetChildContentAsync();


            // Find Urls in the content and replace them with their anchor tag equivalent.
            output.Content.SetContent(Regex.Replace(
                 childContent.GetContent(),
                 @"\b(?:https?://)(\S+)\b",
                  "<strong><a target=\"_blank\" href=\"$0\">$0</a></strong>"));  // http link version}
        }
    }

    [TargetElement("p")]
    public class AutoLinkerWWWTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {

            var childContent = await context.GetChildContentAsync();
            // Find Urls in the content and replace them with their anchor tag equivalent.
            output.Content.SetContent(Regex.Replace(
                childContent.GetContent(),
                 @"\b(www\.)(\S+)\b",
                 "<strong><a target=\"_blank\" href=\"http://$0\">$0</a></strong>"));  // www version
        }
    }
}

*/