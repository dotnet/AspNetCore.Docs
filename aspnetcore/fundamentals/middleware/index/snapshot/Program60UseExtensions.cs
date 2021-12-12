using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/* next is type of Func<Task> */

#region snippet1
app.Use(async (context, next) =>
{
    var cultureQuery = context.Request.Query["culture"];
    if (!string.IsNullOrWhiteSpace(cultureQuery))
    {
        var culture = new CultureInfo(cultureQuery);

        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;
    }

    await next();
});
#endregion

/* 
    1. next is type of RequestDelegate which requires passing the HttpContext
    2. Use this for performance benefits
    3. Saves two per request allocations over the previous Use extension
*/

#region snippet2
app.Use(async (context, next) =>
{
    var cultureQuery = context.Request.Query["culture"];
    if (!string.IsNullOrWhiteSpace(cultureQuery))
    {
        var culture = new CultureInfo(cultureQuery);

        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;
    }

    await next(context);
});
#endregion

/*
    1. next is not used i.e. it is a terminal middleware
    2. Every other middleware after a terminal middleware is skipped
    1. Use should be replaced with Run or it will throw a compile time error (CS0121: ambiguous)

    app.Use(async (context, next) => {
        await context.Response.WriteAsync(
            $"Hello {CultureInfo.CurrentCulture.DisplayName}");
    });
*/

#region snippet3
app.Run(async (context) =>
{
    await context.Response.WriteAsync(
        $"Hello {CultureInfo.CurrentCulture.DisplayName}");
});
#endregion
