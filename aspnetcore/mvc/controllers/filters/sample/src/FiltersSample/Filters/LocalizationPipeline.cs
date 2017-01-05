using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;


namespace FiltersSample.Filters
{
    #region snippet_MiddlewareFilter
    public class LocalizationPipeline
    {
        public void Configure(IApplicationBuilder applicationBuilder)
        {
            var supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("fr")
            };

            var options = new RequestLocalizationOptions
            {

                DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };
            options.RequestCultureProviders = new[] 
                { new RouteDataRequestCultureProvider() { Options = options } };

            applicationBuilder.UseRequestLocalization(options);
        }
    }
    #endregion
}
