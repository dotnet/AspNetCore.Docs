#define THIRD // FIRST SECOND THIRD FORTH
#if NEVER
#elif FIRST
// <snippet_Addservices>
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.ResponseHeaders.Add("MyResponseHeader");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
    logging.CombineLogs = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseHttpLogging();

app.Use(async (context, next) =>
{
    context.Response.Headers["MyResponseHeader"] =
        new string[] { "My Response Header Value" };

    await next();
});

app.MapGet("/", () => "Hello World!");

app.Run();
// </snippet_Addservices>
#elif SECOND
// <snippet2>
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(o => { });

var app = builder.Build();

app.UseHttpLogging();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.MapGet("/", () => "Hello World!");

app.Run();
// </snippet2>
#elif FORTH
using Microsoft.Extensions.Http.Diagnostics;
using Microsoft.AspNetCore.Diagnostics.Logging;
using Microsoft.Extensions.Compliance.Classification;
using HttpLoggingSample;
using Microsoft.Net.Http.Headers;

// <snippet_redactionOptions>
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(o => { });
builder.Services.AddRedaction();

builder.Services.AddHttpLoggingRedaction(op =>
{
    op.RequestPathParameterRedactionMode = HttpRouteParameterRedactionMode.None;
    op.RequestPathLoggingMode = IncomingPathLoggingMode.Formatted;
    op.RequestHeadersDataClasses.Add(HeaderNames.Accept, MyTaxonomyClassifications.Public);
    op.ResponseHeadersDataClasses.Add(HeaderNames.ContentType, MyTaxonomyClassifications.Private);
    op.RouteParameterDataClasses = new Dictionary<string, DataClassification>
    {
        { "one", MyTaxonomyClassifications.Personal },
    };
    // Add the paths that should be filtered, with a leading '/'.
    op.ExcludePathStartsWith.Add("/home");
    op.IncludeUnmatchedRoutes = true;
});

var app = builder.Build();

app.UseHttpLogging();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.MapGet("/", () => "Logged!");
app.MapGet("/home", () => "Not logged!");

app.Run();
// </snippet_redactionOptions>
#elif THIRD
// <snippet3>
using HttpLoggingSample;
using Microsoft.AspNetCore.HttpLogging;
// <snippet7>
// <snippet4>
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.Duration;
});
builder.Services.AddHttpLoggingInterceptor<SampleHttpLoggingInterceptor>();
// </snippet4>
builder.Services.AddRedaction();
builder.Services.AddHttpLoggingRedaction(op => { });
// </snippet7>
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseHttpLogging();

app.Use(async (context, next) =>
{
    context.Response.Headers["MyResponseHeader"] =
        new string[] { "My Response Header Value" };

    await next();
});

app.MapGet("/", () => "Hello World!");

// <snippet5>
app.MapGet("/duration", [HttpLogging(loggingFields: HttpLoggingFields.Duration)]
    () => "Hello World! (logging duration)");
// </snippet5>

// <snippet6>
app.MapGet("/response", () => "Hello World! (logging response)")
    .WithHttpLogging(HttpLoggingFields.ResponsePropertiesAndHeaders);
// </snippet6>

app.Run();
// </snippet3>
#endif
