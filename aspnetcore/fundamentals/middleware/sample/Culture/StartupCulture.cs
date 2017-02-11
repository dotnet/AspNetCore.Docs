//#define Culture
#if Culture
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace Culture
{
#region snippet1
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Use((context, next) =>
            {
                var cultureQuery = context.Request.Query["culture"];
                if (!string.IsNullOrWhiteSpace(cultureQuery))
                {
                    var culture = new CultureInfo(cultureQuery);

                    CultureInfo.CurrentCulture = culture;
                    CultureInfo.CurrentUICulture = culture;
                }

                // Call the next delegate/middleware in the pipeline
                return next();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(
                    $"Hello {CultureInfo.CurrentCulture.DisplayName}");
            });

        }
    }
#endregion
}
#endif