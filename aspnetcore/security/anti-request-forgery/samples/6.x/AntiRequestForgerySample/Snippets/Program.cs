using Microsoft.AspNetCore.Mvc;

namespace AntiRequestForgerySample.Snippets;

public static class Program
{
    public static void AddAntiforgeryOptions(WebApplicationBuilder builder)
    {
        // <snippet_AddAntiforgeryOptions>
        builder.Services.AddAntiforgery(options =>
        {
            // Set Cookie properties using CookieBuilder properties†.
            options.FormFieldName = "AntiforgeryFieldname";
            options.HeaderName = "X-CSRF-TOKEN-HEADERNAME";
            options.SuppressXFrameOptionsHeader = false;
        });
        // </snippet_AddAntiforgeryOptions>
    }

    public static void AddControllersWithViewsAutoValidateAntiforgeryTokenAttribute(WebApplicationBuilder builder)
    {
        // <snippet_AddControllersWithViewsAutoValidateAntiforgeryTokenAttribute>
        builder.Services.AddControllersWithViews(options =>
        {
            options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
        });
        // </snippet_AddControllersWithViewsAutoValidateAntiforgeryTokenAttribute>
    }

    public static void AddAntiforgeryOptionsJavaScript(WebApplicationBuilder builder)
    {
        // <snippet_AddAntiforgeryOptionsJavaScript>
        builder.Services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");
        // </snippet_AddAntiforgeryOptionsJavaScript>
    }

    public static void AddAntiforgeryEndpoint(WebApplication app)
    {
// <snippet_AddAntiforgeryEndpoint>
        app.UseAuthorization();
        app.MapGet("antiforgery/token", (IAntiforgery forgeryService, HttpContext context) =>
        {
            var tokens = forgeryService.GetAndStoreTokens(context);
            context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken!,
                    new CookieOptions { HttpOnly = false });

            return Results.Ok();
        }).RequireAuthorization();
// </snippet_AddAntiforgeryEndpoint>
    }
}
