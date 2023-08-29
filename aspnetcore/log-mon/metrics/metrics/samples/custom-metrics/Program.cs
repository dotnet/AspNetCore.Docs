using OpenTelemetry.Metrics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenTelemetry()
    .WithMetrics(builder =>
    {
        builder.AddPrometheusExporter();

        builder.AddMeter("Microsoft.AspNetCore.Hosting",
                         "Microsoft.AspNetCore.Server.Kestrel");
        builder.AddView("http-server-request-duration",
            new ExplicitBucketHistogramConfiguration
            {
                Boundaries = new double[] { 0, 0.005, 0.01, 0.025, 0.05,
                       0.075, 0.1, 0.25, 0.5, 0.75, 1, 2.5, 5, 7.5, 10 }
            });
    });
// <snippet_RegisterMetric>
builder.Services.AddSingleton<ContosoMetrics>();
// </snippet_RegisterMetric>

var app = builder.Build();

app.MapPrometheusScrapingEndpoint();

app.MapGet("/", () => "Hello OpenTelemetry! ticks:"
                     + DateTime.Now.Ticks.ToString()[^3..]);

// <snippet_InjectAndUseMetrics>
app.MapPost("/complete-sale", (SaleModel model, ContosoMetrics metrics) =>
{
    // ... business logic such as saving the sale to a database ...

    metrics.ProductSold(model.ProductName, model.QuantitySold);
});
// </snippet_InjectAndUseMetrics>

app.Run();
