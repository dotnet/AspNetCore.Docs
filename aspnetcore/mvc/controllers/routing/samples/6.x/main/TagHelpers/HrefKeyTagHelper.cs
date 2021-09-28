using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebMvcRouting.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "href-key")]
    public class HrefKeyTagHelper : TagHelper
    {
        public string HrefKey { get; set; } = String.Empty;

        [ViewContext]
        public ViewContext? ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (HrefKey == null || ViewContext == null)
                return;

            var href = ViewContext.ViewData[HrefKey] as string;

            if (string.IsNullOrWhiteSpace(href))
                return;

            output.Attributes.SetAttribute("href", href);
            output.Content.SetContent(href);
        }
    }
}