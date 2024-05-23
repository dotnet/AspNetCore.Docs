#define DOCUMENTtransformerInOut //DOCUMENTtransformerInOut DOCUMENTtransformerUse 
// DOCUMENTtransformerUse999

#if DEFAULT
// <snippet_default>
using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
// </snippet_default>
#endif

#if DOCUMENTtransformer1
// <snippet_documenttransformer1>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder();

builder.Services.AddOpenApi(options =>
{
    options.UseTransformer((document, context, cancellationToken) =>
    {
        document.Info = new()
        {
            Title = "Checkout API",
            Version = "v1",
            Description = "API for processing checkouts from cart."
        };
        return Task.CompletedTask;
    });
});

var app = builder.Build();

app.MapOpenApi();

app.MapGet("/", () => "Hello world!");

app.Run();
// </snippet_documenttransformer1>
#endif

#if DOCUMENTtransformer2
// <snippet_documenttransformer2>
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder();

builder.Services.AddAuthentication().AddJwtBearer();

builder.Services.AddOpenApi(options =>
{
    options.UseTransformer<BearerSecuritySchemeTransformer>();
});

var app = builder.Build();

app.MapOpenApi();

app.MapGet("/", () => "Hello world!");

app.Run();

internal sealed class BearerSecuritySchemeTransformer(IAuthenticationSchemeProvider authenticationSchemeProvider) : IOpenApiDocumentTransformer
{
    public async Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
    {
        var authenticationSchemes = await authenticationSchemeProvider.GetAllSchemesAsync();
        if (authenticationSchemes.Any(authScheme => authScheme.Name == "Bearer"))
        {
            var requirements = new Dictionary<string, OpenApiSecurityScheme>
            {
                ["Bearer"] = new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // "bearer" refers to the header name here
                    In = ParameterLocation.Header,
                    BearerFormat = "Json Web Token"
                }
            };
            document.Components ??= new OpenApiComponents();
            document.Components.SecuritySchemes = requirements;
        }
    }
}
// </snippet_documenttransformer2>
#endif

#if OPERATIONtransformer1
// <snippet_operationtransformer1>
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder();

builder.Services.AddAuthentication().AddJwtBearer();

builder.Services.AddOpenApi(options =>
{
    options.UseOperationTransformer((operation, context, cancellationToken) =>
    {
        operation.Responses.Add("500", new OpenApiResponse { Description = "Internal server error" });
        return Task.CompletedTask;
    });
});

var app = builder.Build();

app.MapOpenApi();

app.MapGet("/", () => "Hello world!");

app.Run();
// </snippet_operationtransformer1>
#endif

#if MULTIDOC_OPERATIONtransformer1
// <snippet_multidoc_operationtransformer1>
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder();

builder.Services.AddAuthentication().AddJwtBearer();

builder.Services.AddOpenApi("internal", options =>
{
    options.UseTransformer<BearerSecuritySchemeTransformer>();
});
builder.Services.AddOpenApi("public");

var app = builder.Build();

app.MapOpenApi();

app.MapGet("/world", () => "Hello world!")
    .WithGroupName("internal");
app.MapGet("/", () => "Hello universe!")
    .WithGroupName("public");

app.Run();

internal sealed class BearerSecuritySchemeTransformer(IAuthenticationSchemeProvider authenticationSchemeProvider) : IOpenApiDocumentTransformer
{
    public async Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
    {
        var authenticationSchemes = await authenticationSchemeProvider.GetAllSchemesAsync();
        if (authenticationSchemes.Any(authScheme => authScheme.Name == "Bearer"))
        {
            // Add the security scheme at the document level
            var requirements = new Dictionary<string, OpenApiSecurityScheme>
            {
                ["Bearer"] = new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // "bearer" refers to the header name here
                    In = ParameterLocation.Header,
                    BearerFormat = "Json Web Token"
                }
            };
            document.Components ??= new OpenApiComponents();
            document.Components.SecuritySchemes = requirements;

            // Apply it as a requirement for all operations
            foreach (var operation in document.Paths.Values.SelectMany(path => path.Operations))
            {
                operation.Value.Security.Add(new OpenApiSecurityRequirement
                {
                    [new OpenApiSecurityScheme { Reference = new OpenApiReference { Id = "Bearer", Type = ReferenceType.SecurityScheme } }] = Array.Empty<string>()
                });
            }
        }
    }
}
// </snippet_multidoc_operationtransformer1>
#endif

#if SWAGGERUI
// <snippet_swaggerui>
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });

}

app.MapGet("/", () => "Hello world!");

app.Run();
// </snippet_swaggerui>
#endif

#if MAPOPENAPIWITHAUTH
// <snippet_mapopenapiwithauth>
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder();

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("ApiTesterPolicy", b => b.RequireRole("tester"));
});
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi()
    .RequireAuthorization("ApiTesterPolicy");

app.MapGet("/", () => "Hello world!");

app.Run();
// </snippet_mapopenapiwithauth>
#endif

#if MAPOPENAPIWITHCACHING
// <snippet_mapopenapiwithcaching>
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder();

builder.Services.AddOutputCache(options =>
{
    options.AddBasePolicy(policy => policy.Expire(TimeSpan.FromMinutes(10)));
});
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseOutputCache();

app.MapOpenApi()
    .CacheOutput();

app.MapGet("/", () => "Hello world!");

app.Run();
// </snippet_mapopenapiwithcaching>
#endif

#if OPENAPIWITHSCALAR
// <snippet_openapiwithscalar>
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
}

app.MapGet("/", () => "Hello world!");

app.Run();
// </snippet_openapiwithscalar>
#endif

#if FIRST
// <snippet_first>
var builder = WebApplication.CreateBuilder();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();

app.MapGet("/", () => "Hello world!");

app.Run();
// </snippet_first>
#endif

#if DOCUMENTtransformerUse999
// <snippet_transUse>
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder();

builder.Services.AddOpenApi(options =>
{
    options.UseTransformer((document, context, cancellationToken) 
                             => Task.CompletedTask);
    options.UseTransformer(new MyDocumentTransformer());
    options.UseTransformer<MyDocumentTransformer>();
    options.UseOperationTransformer((operation, context, cancellationToken)
                            => Task.CompletedTask);
});

var app = builder.Build();

app.MapOpenApi();

app.MapGet("/", () => "Hello world!");

app.Run();
// </snippet_transUse>

internal class MyDocumentTransformer : IOpenApiDocumentTransformer
{
    public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
    {
        // Simple transformation logic (e.g., adding a comment to the document)
        document.Info.Description = "Transformed OpenAPI document";

        return Task.CompletedTask;
    }
}

#endif

#if DOCUMENTtransformerInOut
// <snippet_transInOut>
var builder = WebApplication.CreateBuilder();

builder.Services.AddOpenApi(options =>
{
    options.UseOperationTransformer((operation, context, cancellationToken)
                                     => Task.CompletedTask);
    options.UseTransformer((document, context, cancellationToken)
                                     => Task.CompletedTask);
});

var app = builder.Build();

app.MapOpenApi();

app.MapGet("/", () => "Hello world!");

app.Run();
// </snippet_transInOut>

#endif
