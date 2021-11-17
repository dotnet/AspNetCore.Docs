using System.Diagnostics;
using RoutingSample.Routing;

namespace RoutingSample.Snippets;

public class Program
{
    public static void RegexMap(WebApplication app)
    {
        // <snippet_RegexMapGet>
        app.MapGet("{message:regex(^\\d{{3}}-\\d{{2}}-\\d{{4}}$)}",
            () => "Inline Regex Constraint Matched");
        // </snippet_RegexMapGet>

        // <snippet_RegExMapControllerRoute>
        app.MapControllerRoute(
            name: "people",
            pattern: "people/{ssn}",
            constraints: new { ssn = "^\\d{3}-\\d{2}-\\d{4}$", },
            defaults: new { controller = "People", action = "List" });
        // </snippet_RegExMapControllerRoute>
    }

    public static void AddRoutingConstraintMap(WebApplicationBuilder builder)
    {
        // <snippet_AddRoutingConstraintMap>
        builder.Services.AddRouting(options =>
            options.ConstraintMap.Add("noZeroes", typeof(NoZeroesRouteConstraint)));
        // </snippet_AddRoutingConstraintMap>
    }

    public static void MapControllerRoute(WebApplication app)
    {
        // <snippet_MapControllerRoute>
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller:slugify=Home}/{action:slugify=Index}/{id?}");
        // </snippet_MapControllerRoute>
    }

    public static void RequireHost(WebApplication app)
    {
        // <snippet_RequireHost>
        app.MapGet("/", () => "Contoso").RequireHost("contoso.com");
        app.MapGet("/", () => "AdventureWorks").RequireHost("adventure-works.com");

        app.MapHealthChecks("/healthz").RequireHost("*:8080");
        // </snippet_RequireHost>
    }

    public static void StopwatchMiddleware(WebApplication app)
    {
        // <snippet_StopwatchMiddleware>
        var logger = app.Services.GetRequiredService<ILogger<Program>>();

        app.Use(async (context, next) =>
        {
            var stopwatch = Stopwatch.StartNew();
            await next(context);
            stopwatch.Stop();

            logger.LogInformation("Time 1: {ElapsedMilliseconds}ms", stopwatch.ElapsedMilliseconds);
        });

        app.UseRouting();

        app.Use(async (context, next) =>
        {
            var stopwatch = Stopwatch.StartNew();
            await next(context);
            stopwatch.Stop();

            logger.LogInformation("Time 2: {ElapsedMilliseconds}ms", stopwatch.ElapsedMilliseconds);
        });

        app.UseAuthorization();

        app.Use(async (context, next) =>
        {
            var stopwatch = Stopwatch.StartNew();
            await next(context);
            stopwatch.Stop();

            logger.LogInformation("Time 3: {ElapsedMilliseconds}ms", stopwatch.ElapsedMilliseconds);
        });

        app.MapGet("/", () => "Timing Test.");
        // </snippet_StopwatchMiddleware>
    }

    public static void StopwatchMiddlewareAuto(WebApplication app)
    {
        // <snippet_StopwatchMiddlewareAuto>
        var logger = app.Services.GetRequiredService<ILogger<Program>>();
        var timerCount = 0;

        app.Use(async (context, next) =>
        {
            using (new AutoStopwatch(logger, $"Time {++timerCount}"))
            {
                await next(context);
            }
        });

        app.UseRouting();

        app.Use(async (context, next) =>
        {
            using (new AutoStopwatch(logger, $"Time {++timerCount}"))
            {
                await next(context);
            }
        });

        app.UseAuthorization();

        app.Use(async (context, next) =>
        {
            using (new AutoStopwatch(logger, $"Time {++timerCount}"))
            {
                await next(context);
            }
        });

        app.MapGet("/", () => "Timing Test.");
        // </snippet_StopwatchMiddlewareAuto>
    }
}
