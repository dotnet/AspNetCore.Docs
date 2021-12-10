using System.Text;
using System.Text.Json;
using HealthChecksSample.HealthCheckPublishers;
using HealthChecksSample.HealthChecks;
using HealthChecksSample.Services;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthChecksSample.Snippets;

public static class Program
{
    public static void MapHealthChecksComplete(string[] args)
    {
        // <snippet_MapHealthChecksComplete>
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddHealthChecks();

        var app = builder.Build();

        app.MapHealthChecks("/healthz");

        app.Run();
        // </snippet_MapHealthChecksComplete>
    }

    public static void AddHealthChecks(WebApplicationBuilder builder)
    {
        // <snippet_AddHealthChecks>
        builder.Services.AddHealthChecks()
            .AddCheck<SampleHealthCheck>("Sample");
        // </snippet_AddHealthChecks>
    }
    public static void AddHealthChecksExtended(WebApplicationBuilder builder)
    {
        // <snippet_AddHealthChecksExtended>
        builder.Services.AddHealthChecks()
            .AddCheck<SampleHealthCheck>(
                "Sample",
                failureStatus: HealthStatus.Degraded,
                tags: new[] { "sample" });
        // </snippet_AddHealthChecksExtended>
    }

    public static void AddHealthChecksDelegate(WebApplicationBuilder builder)
    {
        // <snippet_AddHealthChecksDelegate>
        builder.Services.AddHealthChecks()
            .AddCheck("Sample", () => HealthCheckResult.Healthy("A healthy result."));
        // </snippet_AddHealthChecksDelegate>
    }

    public static void AddHealthChecksTypeActivated(WebApplicationBuilder builder)
    {
        // <snippet_AddHealthChecksTypeActivated>
        builder.Services.AddHealthChecks()
            .AddTypeActivatedCheck<SampleHealthCheckWithArgs>(
                "Sample",
                failureStatus: HealthStatus.Degraded,
                tags: new[] { "sample" },
                args: new object[] { 1, "Arg" });
        // </snippet_AddHealthChecksTypeActivated>
    }

    public static void MapHealthChecks(WebApplication app)
    {
        // <snippet_MapHealthChecks>
        app.MapHealthChecks("/healthz");
        // </snippet_MapHealthChecks>
    }

    public static void MapHealthChecksRequireHost(WebApplication app)
    {
        // <snippet_MapHealthChecksRequireHost>
        app.MapHealthChecks("/healthz")
            .RequireHost("www.contoso.com:5001");
        // </snippet_MapHealthChecksRequireHost>
    }

    public static void MapHealthChecksRequireHostPort(WebApplication app)
    {
        // <snippet_MapHealthChecksRequireHostPort>
        app.MapHealthChecks("/healthz")
            .RequireHost("*:5001");
        // </snippet_MapHealthChecksRequireHostPort>
    }

    public static void MapHealthChecksRequireAuthorization(WebApplication app)
    {
        // <snippet_MapHealthChecksRequireAuthorization>
        app.MapHealthChecks("/healthz")
            .RequireAuthorization();
        // </snippet_MapHealthChecksRequireAuthorization>
    }

    public static void MapHealthChecksFilterTags(WebApplication app)
    {
        // <snippet_MapHealthChecksFilterTags>
        app.MapHealthChecks("/healthz", new HealthCheckOptions
        {
            Predicate = healthCheck => healthCheck.Tags.Contains("sample")
        });
        // </snippet_MapHealthChecksFilterTags>
    }

    public static void MapHealthChecksResultStatusCodes(WebApplication app)
    {
        // <snippet_MapHealthChecksResultStatusCodes>
        app.MapHealthChecks("/healthz", new HealthCheckOptions
        {
            ResultStatusCodes =
            {
                [HealthStatus.Healthy] = StatusCodes.Status200OK,
                [HealthStatus.Degraded] = StatusCodes.Status200OK,
                [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
            }
        });
        // </snippet_MapHealthChecksResultStatusCodes>
    }

    public static void MapHealthChecksAllowCachingResponses(WebApplication app)
    {
        // <snippet_MapHealthChecksAllowCachingResponses>
        app.MapHealthChecks("/healthz", new HealthCheckOptions
        {
            AllowCachingResponses = false
        });
        // </snippet_MapHealthChecksAllowCachingResponses>
    }

    public static void MapHealthChecksResponseWriter(WebApplication app)
    {
        // <snippet_MapHealthChecksResponseWriter>
        app.MapHealthChecks("/healthz", new HealthCheckOptions
        {
            ResponseWriter = WriteResponse
        });
        // </snippet_MapHealthChecksResponseWriter>
    }

    public static void AddHealthChecksSqlServer(WebApplicationBuilder builder)
    {
        // <snippet_AddHealthChecksSqlServer>
        builder.Services.AddHealthChecks()
            .AddSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection"));
        // </snippet_AddHealthChecksSqlServer>
    }

    public static void AddHealthChecksDbContext(WebApplicationBuilder builder)
    {
        // <snippet_AddHealthChecksDbContext>
        builder.Services.AddDbContext<SampleDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddHealthChecks()
            .AddDbContextCheck<SampleDbContext>();
        // </snippet_AddHealthChecksDbContext>
    }

    public static void AddHealthChecksReadinessLiveness(WebApplicationBuilder builder)
    {
        // <snippet_AddHealthChecksReadinessLiveness>
        builder.Services.AddHostedService<StartupBackgroundService>();
        builder.Services.AddSingleton<StartupHealthCheck>();

        builder.Services.AddHealthChecks()
            .AddCheck<StartupHealthCheck>(
                "Startup",
                tags: new[] { "ready" });
        // </snippet_AddHealthChecksReadinessLiveness>
    }

    public static void MapHealthChecksReadinessLiveness(WebApplication app)
    {
        // <snippet_MapHealthChecksReadinessLiveness>
        app.MapHealthChecks("/healthz/ready", new HealthCheckOptions
        {
            Predicate = healthCheck => healthCheck.Tags.Contains("ready")
        });

        app.MapHealthChecks("/healthz/live", new HealthCheckOptions
        {
            Predicate = _ => false
        });
        // </snippet_MapHealthChecksReadinessLiveness>
    }

    public static void HealthCheckPublisherOptionsService(WebApplicationBuilder builder)
    {
        // <snippet_HealthCheckPublisherOptionsService>
        builder.Services.Configure<HealthCheckPublisherOptions>(options =>
        {
            options.Delay = TimeSpan.FromSeconds(2);
            options.Predicate = healthCheck => healthCheck.Tags.Contains("sample");
        });

        builder.Services.AddSingleton<IHealthCheckPublisher, SampleHealthCheckPublisher>();
        // </snippet_HealthCheckPublisherOptionsService>
    }

    // <snippet_WriteResponse>
    private static Task WriteResponse(HttpContext context, HealthReport healthReport)
    {
        context.Response.ContentType = "application/json; charset=utf-8";

        var options = new JsonWriterOptions { Indented = true };

        using var memoryStream = new MemoryStream();
        using (var jsonWriter = new Utf8JsonWriter(memoryStream, options))
        {
            jsonWriter.WriteStartObject();
            jsonWriter.WriteString("status", healthReport.Status.ToString());
            jsonWriter.WriteStartObject("results");

            foreach (var healthReportEntry in healthReport.Entries)
            {
                jsonWriter.WriteStartObject(healthReportEntry.Key);
                jsonWriter.WriteString("status",
                    healthReportEntry.Value.Status.ToString());
                jsonWriter.WriteString("description",
                    healthReportEntry.Value.Description);
                jsonWriter.WriteStartObject("data");

                foreach (var item in healthReportEntry.Value.Data)
                {
                    jsonWriter.WritePropertyName(item.Key);

                    JsonSerializer.Serialize(jsonWriter, item.Value,
                        item.Value?.GetType() ?? typeof(object));
                }

                jsonWriter.WriteEndObject();
                jsonWriter.WriteEndObject();
            }

            jsonWriter.WriteEndObject();
            jsonWriter.WriteEndObject();
        }

        return context.Response.WriteAsync(
            Encoding.UTF8.GetString(memoryStream.ToArray()));
    }
    // </snippet_WriteResponse>
}
