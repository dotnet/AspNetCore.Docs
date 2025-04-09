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

