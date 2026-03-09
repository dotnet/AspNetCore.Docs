#pragma warning disable EXTEXP0013

using System.Text.Json;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogEnricher<CustomHttpLogEnricher>();
builder.Services.AddRedaction();

builder.Logging.AddJsonConsole(op =>
{
    op.JsonWriterOptions = new JsonWriterOptions
    {
        Indented = true
    };
});

WebApplication app = builder.Build();

app.UseHttpLogging();

app.MapGet("/", () => "Hello, World!");

await app.RunAsync();
