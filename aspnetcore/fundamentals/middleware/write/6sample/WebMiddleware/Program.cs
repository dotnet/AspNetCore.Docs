#define FIRST // FIRST
#if NEVER
#elif FIRST
// <snippet_first>
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    var cultureQuery = context.Request.Query["culture"];
    if (!string.IsNullOrWhiteSpace(cultureQuery))
    {
        var culture = new CultureInfo(cultureQuery);

        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;
    }

    // Call the next delegate/middleware in the pipeline
    await next();
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync(
        $"CurrentCulture.DisplayName: {CultureInfo.CurrentCulture.DisplayName}");
});

app.Run();
// </snippet_first>
#endif