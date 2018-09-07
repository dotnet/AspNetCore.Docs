namespace RazorPagesSample.TagHelpers
{
    #region snippet_StyleTagHelperComponentClass
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    public class StyleTagHelperComponent : ITagHelperComponent
    {
        private string style = "<style>" +
            "address[printable] { display: flex;" +
            "justify-content: space-between;" +
            "width: 350px;" +
            "background: whitesmoke;" +
            "height: 100px;" +
            "align-items: center;" +
            "padding: 0 10px;" +
            "border-radius: 5px; }" +
            "</style>";

        public int Order => 1;

        public void Init(TagHelperContext context) { }

        public Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (string.Equals(context.TagName, "head", 
                              StringComparison.OrdinalIgnoreCase))
            {
                output.PostContent.AppendHtml(style);
            }

            return Task.CompletedTask;
        }
    }
    #endregion
}
