#define Culture
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
            app.UseRequestCulture();

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