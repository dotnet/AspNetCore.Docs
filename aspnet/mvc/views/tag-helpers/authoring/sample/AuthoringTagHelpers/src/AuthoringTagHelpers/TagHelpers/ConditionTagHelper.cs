using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace AuthoringTagHelpers.TagHelpers
{
    [TargetElement(Attributes = nameof(Condition))]
    public class ConditionTagHelper : TagHelper
    {
        public bool Condition { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!Condition)
            {
                output.SuppressOutput();
            }
        }
    }
}
