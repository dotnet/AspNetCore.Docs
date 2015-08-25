/*
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace TagHlp.TagHelpers
{

 // [TargetElement(Attributes = nameof(Condition))]
    [TargetElement(Attributes = "condition")]

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


*/