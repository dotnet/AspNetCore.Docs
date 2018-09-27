#region snippet_AddressTagHelperComponentClass
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RazorPagesSample.TagHelpers
{
    public class AddressTagHelperComponent : TagHelperComponent
    {
        private readonly string _printableButton =
            "<button type='button' class='btn btn-info' onclick=\"window.open(" +
            "'https://binged.it/2AXRRYw')\">" +
            "<span class='glyphicon glyphicon-road' aria-hidden='true'></span>" +
            "</button>";

        #region snippet_Constructor
        private readonly string _markup;

        public override int Order { get; }

        public AddressTagHelperComponent(string markup = "", int order = 1)
        {
            _markup = markup;
            Order = order;
        }
        #endregion

        #region snippet_ProcessAsync
        public override async Task ProcessAsync(TagHelperContext context,
                                                TagHelperOutput output)
        {
            if (string.Equals(context.TagName, "address",
                    StringComparison.OrdinalIgnoreCase) &&
                output.Attributes.ContainsName("printable"))
            {
                TagHelperContent childContent = await output.GetChildContentAsync();
                string content = childContent.GetContent();
                output.Content.SetHtmlContent(
                    $"<div>{content}<br>{_markup}</div>{_printableButton}");
            }
        }
        #endregion
    }
}
#endregion
