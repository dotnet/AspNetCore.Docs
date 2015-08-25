using System;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using TagHlp.Models;

namespace TagHlp.TagHelpers.Copy
{
    public class WebsiteInformationTagHelper : TagHelper
    {
        public WebsiteContext Info { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "section";
            output.Content.SetContent(string.Format(
                "<ul><li><strong>Version:</strong> {0}</li>" + Environment.NewLine +
                "<li><strong>Copyright Year:</strong> {1}</li>" + Environment.NewLine +
                "<li><strong>Approved:</strong> {2}</li>" + Environment.NewLine +
                "<li><strong>Number of tags to show:</strong> {3}</li></ul>" + Environment.NewLine,
                Info.Version.ToString(),
                Info.CopyrightYear.ToString(),
                Info.Approved.ToString(),
                Info.TagsToShow.ToString()));
            output.SelfClosing = false;
        }
    }
}