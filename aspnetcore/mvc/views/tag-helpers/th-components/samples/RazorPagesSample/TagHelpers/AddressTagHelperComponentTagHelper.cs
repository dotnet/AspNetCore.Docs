namespace RazorPagesSample.TagHelpers
{
    #region snippet_AddressTagHelperComponentTagHelperClass
    using System.ComponentModel;
    using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using Microsoft.Extensions.Logging;

    [HtmlTargetElement("address")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AddressTagHelperComponentTagHelper : TagHelperComponentTagHelper
    {
        public AddressTagHelperComponentTagHelper(
            ITagHelperComponentManager componentManager, 
            ILoggerFactory loggerFactory) : base(componentManager, loggerFactory)
        {
        }
    }
    #endregion
}
