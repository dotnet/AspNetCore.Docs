using System.Diagnostics;
using RoutingSample.Routing;

namespace RoutingSample.Snippets;

public class Program
{
    public static void UseRouting(WebApplication app)
    {
        // <snippet_UseRouting>
        app.Use(async (context, next) =>
        {
            // ...
            await next(context);
        });

        app.UseRouting();

        app.MapGet("/", () => "Hello World!");
        // </snippet_UseRouting>
    }

    public static void RouteTemplate(WebApplication app)
    {
        // <snippet_RouteTemplate>
        app.MapGet("/hello/{name:alpha}", (string name) => $"Hello {name}!");
        // </snippet_RouteTemplate>
    }

    public static void HealthChecksAuthz(WebApplication app)
    {
        // <snippet_HealthChecksAuthz>
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapHealthChecks("/healthz").RequireAuthorization();
        app.MapGet("/", () => "Hello World!");
        // </snippet_HealthChecksAuthz>
    }

    public static void CurrentEndpointMiddleware(WebApplication app)
    {
        // <snippet_InspectEndpointMiddleware>
        app.Use(async (context, next) =>
        {
            var currentEndpoint = context.GetEndpoint();

            if (currentEndpoint is null)
            {
                await next(context);
                return;
            }

            Console.WriteLine($"Endpoint: {currentEndpoint.DisplayName}");

            if (currentEndpoint is RouteEndpoint routeEndpoint)
            {
                Console.WriteLine($"  - Route Pattern: {routeEndpoint.RoutePattern}");
            }

            foreach (var endpointMetadata in currentEndpoint.Metadata)
            {
                Console.WriteLine($"  - Metadata: {endpointMetadata}");
            }

            await next(context);
        });

        app.MapGet("/", () => "Inspect Endpoint.");
        // </snippet_InspectEndpointMiddleware>
    }

    public static void CurrentEndpointMiddlewareOrder(WebApplication app)
    {
        // <snippet_CurrentEndpointMiddlewareOrder>
        // Location 1: before routing runs, endpoint is always null here.
        app.Use(async (context, next) =>
        {
            Console.WriteLine($"1. Endpoint: {context.GetEndpoint()?.DisplayName ?? "(null)"}");
            await next(context);
        });

        app.UseRouting();

        // Location 2: after routing runs, endpoint will be non-null if routing found a match.
        app.Use(async (context, next) =>
        {
            Console.WriteLine($"2. Endpoint: {context.GetEndpoint()?.DisplayName ?? "(null)"}");
            await next(context);
        });

        // Location 3: runs when this endpoint matches
        app.MapGet("/", (HttpContext context) =>
        {
            Console.WriteLine($"3. Endpoint: {context.GetEndpoint()?.DisplayName ?? "(null)"}");
            return "Hello World!";
        }).WithDisplayName("Hello");

        app.UseEndpoints(_ => { });

        // Location 4: runs after UseEndpoints - will only run if there was no match.
        app.Use(async (context, next) =>
        {
            Console.WriteLine($"4. Endpoint: {context.GetEndpoint()?.DisplayName ?? "(null)"}");
            await next(context);
        });
        // </snippet_CurrentEndpointMiddlewareOrder>
    }

    public static void RequiresAudit(WebApplication app)
    {
        // <snippet_RequiresAudit>
        app.UseHttpMethodOverride();
        app.UseRouting();

        app.Use(async (context, next) =>
        {
            if (context.GetEndpoint()?.Metadata.GetMetadata<RequiresAuditAttribute>() is not null)
            {
                Console.WriteLine($"ACCESS TO SENSITIVE DATA AT: {DateTime.UtcNow}");
            }

            await next(context);
        });

        app.MapGet("/", () => "Audit isn't required.");
        app.MapGet("/sensitive", () => "Audit required for sensitive data.")
            .WithMetadata(new RequiresAuditAttribute());
        // </snippet_RequiresAudit>
    }

    public static void CompareTerminalMiddlewareRouting(WebApplication app)
    {
        // <snippet_CompareTerminalMiddlewareRouting>
        // Approach 1: Terminal Middleware.
        app.Use(async (context, next) =>
        {
            if (context.Request.Path == "/")
            {
                await context.Response.WriteAsync("Terminal Middleware.");
                return;
            }

            await next(context);
        });

        app.UseRouting();

        // Approach 2: Routing.
        app.MapGet("/Routing", () => "Routing.");
        // </snippet_CompareTerminalMiddlewareRouting>
    }

    public static void MapHealthChecks(WebApplication app)
    {
        // <snippet_MapHealthChecks>
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapHealthChecks("/healthz").RequireAuthorization();
        // </snippet_MapHealthChecks>
    }

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

    public static void AddRouting(WebApplicationBuilder builder)
    {
        // <snippet_AddRouting>
        builder.Services.AddRouting(options =>
            options.ConstraintMap["slugify"] = typeof(SlugifyParameterTransformer));
        // </snippet_AddRouting>
    }

    public static void MapControllerRoute(WebApplication app)
    {
        // <snippet_MapControllerRoute>
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller:slugify=Home}/{action:slugify=Index}/{id?}");
        // </snippet_MapControllerRoute>
    }

    public static void RouteValueInvalidation(WebApplication app)
    {
        // <snippet_RouteValueInvalidation>
        app.MapControllerRoute(
            "default",
            "{culture}/{controller=Home}/{action=Index}/{id?}");

        app.MapControllerRoute(
            "blog",
            "{culture}/{**slug}",
            new { controller = "Blog", action = "ReadPost" });
        // </snippet_RouteValueInvalidation>
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
