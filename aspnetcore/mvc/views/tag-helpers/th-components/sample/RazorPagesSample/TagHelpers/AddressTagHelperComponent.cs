using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace RazorPagesSample.TagHelpers
{
    public class AddressTagHelperComponent : ITagHelperComponent
    {
        string _printableButton = 
            "<button type='button' class='btn btn-info' onclick=\"window.open(" +
            "'https://binged.it/2AXRRYw')\">" +
             "<span class='glyphicon glyphicon-road' aria-hidden='true'></span>" +
             "</button>";

        public int Order => _order;

        private readonly string _markup;
        private readonly int _order;

        public AddressTagHelperComponent(string markup = "", int order = 1)
        {
            _markup = markup;
            _order = order;
        }

        public void Init(TagHelperContext context) { }

        public async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (string.Equals(context.TagName, "address", StringComparison.OrdinalIgnoreCase) && output.Attributes.ContainsName("printable"))
            {
                var content = await output.GetChildContentAsync();
                output.Content.SetHtmlContent($"<div>{content.GetContent()}<br/>{_markup}</div>{_printableButton}");
            }
        }
    }
}
