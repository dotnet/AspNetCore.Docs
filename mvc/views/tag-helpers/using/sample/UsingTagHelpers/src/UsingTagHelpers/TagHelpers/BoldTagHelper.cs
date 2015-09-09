using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace UsingTagHelpers.TagHelpers
{
   //public class BoldTagHelper : TagHelper
   public class Bold: TagHelper
   {
      public override void Process(TagHelperContext context, TagHelperOutput output)
      {
         output.Attributes.RemoveAll("bold");
         output.PreContent.SetContent("<strong>");
         output.PostContent.SetContent("</strong>");
      }
   }
}