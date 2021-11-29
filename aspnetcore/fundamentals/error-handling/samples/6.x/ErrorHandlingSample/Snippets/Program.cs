using Microsoft.AspNetCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace ErrorHandlingSample.Snippets;

public static class Program
{
    public static void UseExceptionHandlerInline(WebApplicationBuilder builder)
    {
        // <snippet_UseExceptionHandlerInline>
        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler(exceptionHandlerApp =>
            {
                exceptionHandlerApp.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                    // using static System.Net.Mime.MediaTypeNames;
                    context.Response.ContentType = Text.Plain;

                    await context.Response.WriteAsync("An exception was thrown.");

                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();

                    if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
                    {
                        await context.Response.WriteAsync(" The file was not found.");
                    }

                    if (exceptionHandlerPathFeature?.Path == "/")
                    {
                        await context.Response.WriteAsync(" Page: Home.");
                    }
                });
            });

            app.UseHsts();
        }
        // </snippet_UseExceptionHandlerInline>
    }

    public static void UseStatusCodePages(WebApplicationBuilder builder)
    {
        // <snippet_UseStatusCodePages>
        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseStatusCodePages();
        // </snippet_UseStatusCodePages>
    }

    public static void UseStatusCodePagesContent(WebApplicationBuilder builder)
    {
        // <snippet_UseStatusCodePagesContent>
        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        // using static System.Net.Mime.MediaTypeNames;
        app.UseStatusCodePages(Text.Plain, "Status Code Page: {0}");
        // </snippet_UseStatusCodePagesContent>
    }

    public static void UseStatusCodePagesInline(WebApplicationBuilder builder)
    {
        // <snippet_UseStatusCodePagesInline>
        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseStatusCodePages(async statusCodeContext =>
        {
            // using static System.Net.Mime.MediaTypeNames;
            statusCodeContext.HttpContext.Response.ContentType = Text.Plain;

            await statusCodeContext.HttpContext.Response.WriteAsync(
                $"Status Code Page: {statusCodeContext.HttpContext.Response.StatusCode}");
        });
        // </snippet_UseStatusCodePagesInline>
    }

    public static void UseStatusCodePagesRedirect(WebApplicationBuilder builder)
    {
        // <snippet_UseStatusCodePagesRedirect>
        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseStatusCodePagesWithRedirects("/StatusCode/{0}");
        // </snippet_UseStatusCodePagesRedirect>
    }

    public static void UseStatusCodePagesReExecute(WebApplicationBuilder builder)
    {
        // <snippet_UseStatusCodePagesReExecute>
        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");
        // </snippet_UseStatusCodePagesReExecute>
    }

    public static void UseStatusCodePagesReExecuteQueryString(WebApplicationBuilder builder)
    {
        // <snippet_UseStatusCodePagesReExecuteQueryString>
        app.UseStatusCodePagesWithReExecute("/StatusCode", "?statusCode={0}");
        // </snippet_UseStatusCodePagesReExecuteQueryString>
    }
}
