using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpersBuiltInAspNetCore
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("PrettyTagHelper")]
    public class PrettyTagHelperTagHelper : TagHelper
    {
        protected IHtmlGenerator Generator { get; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        [HtmlAttributeName("replacement-text")]
        public string RepacementText { get; set; }

        public PrettyTagHelperTagHelper(IHtmlGenerator generator)
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

        //public override void Process(TagHelperContext context, TagHelperOutput output)
        //{
        //    var innerHtml = output.Content.GetContent();
        //    output.Content.SetHtmlContent("---" + innerHtml + "---");  // www version
        //}

        //    public override void Process(TagHelperContext context, TagHelperOutput output)
        //    {
        //        var content = output.Content.GetContent();

        //        //var tagBuilder = Generator.GenerateActionLink(
        //        //    ViewContext,
        //        //    "LinkText",
        //        //    "About",
        //        //    "Home",
        //        //    null,
        //        //    null,
        //        //    null, 
        //        //    null,
        //        //    null);


        //        output.Content.SetHtmlContent("abcd");


        //        //var builder = new TagBuilder("a");

        //        //output.Attributes.Add("data-controller", Controller);
        //        //output.Attributes.Add("data-action", Action);

        //        //if (!string.IsNullOrEmpty(Text))
        //        //{
        //        //    builder.InnerHtml.Append(Text); // INNER HTML IS HERE!!! 
        //        //}
        //        //builder.AddCssClass("btn btn-link");
        //        //output.Content.SetContent(builder);
        //        //base.Process(context, output);

        //    }


    }
}
