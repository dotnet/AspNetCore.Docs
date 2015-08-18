using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace TagHlp.TagHelpers
{
    [TargetElement("div")]
    [TargetElement("style")]
    [TargetElement("p")]
    public class ConditionTagHelper : TagHelper
    {
        public bool? Condition { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // If a condition is set and evaluates to false, don't render the tag.
            if (Condition.HasValue && !Condition.Value)
            {
                output.SuppressOutput();
            }
        }
    }
}