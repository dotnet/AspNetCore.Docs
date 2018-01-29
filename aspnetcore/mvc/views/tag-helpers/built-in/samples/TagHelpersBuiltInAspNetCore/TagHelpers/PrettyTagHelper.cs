using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Net;
using System.Threading.Tasks;

namespace TagHelpersBuiltInAspNetCore.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("Pretty")]
    public class PrettyTagHelper : TagHelper
    {
        protected IHtmlGenerator Generator { get; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        [HtmlAttributeName("replacement-text")]
        public string RepacementText { get; set; }

        public PrettyTagHelper(IHtmlGenerator generator)
        {
            Generator = generator;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var innerHtml = childContent.GetContent();

            var str = innerHtml;
            var strEncoded = WebUtility.HtmlEncode(str);

            var finalStr = str.Replace(RepacementText, strEncoded);
            output.Content.SetHtmlContent(finalStr);  // www version
        }
    }
}
