using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace AuthoringTagHelpers.TagHelpers
{
    /// <summary>
    ///     The minified-partial tag helper loads
    ///     minified partials depending on the value
    ///     of ASPNETCORE_ENVIRONMENT.
    /// </summary>
    #region snippet
    public class MinifiedVersionPartialTagHelper : PartialTagHelper
        {
            public MinifiedVersionPartialTagHelper(ICompositeViewEngine viewEngine, 
                                    IViewBufferScope viewBufferScope)
                                   : base(viewEngine, viewBufferScope)
            {

            }

            public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
            {
                // Append ".min" to load the minified partial view.
                if (!IsDevelopment())
                {
                    Name += ".min";
                }

                return base.ProcessAsync(context, output);
            }

            private bool IsDevelopment()
            {
                return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") 
                                                     == EnvironmentName.Development;
            }
        }
    #endregion
}