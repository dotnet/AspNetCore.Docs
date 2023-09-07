---
title: ASP.NET Core metrics
description: Metrics for ASP.NET Core apps
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-8.0'
ms.date: 6/30/2023
ms.topic: article
ms.prod: aspnet-core
uid: log-mon/metrics/metrics
---

# ASP.NET Core metrics

Metrics are numerical measurements reported over time. They're typically used to monitor the health of an app and generate alerts. For example, a web service might track how many:

* Requests it received per second.
* Milliseconds it took to respond.
* Responses sent an error.

These metrics can be reported to a monitoring system at regular intervals. Dashboards can be setup to view metrics and alerts created to notify people of problems. If the web service is intended to respond to requests within 400 ms and starts responding in 600 ms, the monitoring system can notify the operations staff that the app response is slower than normal.

See [ASP.NET Core metrics](https://github.com/dotnet/aspnetcore/issues/47536) for ASP.NET Core specific metrics. See [.NET metrics](/dotnet/core/diagnostics/metrics) for .NET metrics.

## Using metrics

There are two parts to using metrics in a .NET app:

* **Instrumentation:** Code in .NET libraries takes measurements and associates these measurements with a metric name. .NET and ASP.NET Core include many built-in metrics.
* **Collection:** A .NET app configures named metrics to be transmitted from the app for external storage and analysis. Some tools may perform configuration outside the app using configuration files or a UI tool.

Instrumented code can record numeric measurements, but the measurements need to be aggregated, transmitted, and stored to create useful metrics for monitoring. The process of aggregating, transmitting, and storing data is called collection. This tutorial shows several examples of collecting metrics:

* Populating metrics in [Grafana](https://grafana.com/) with [OpenTelemetry](https://opentelemetry.io/) and [Prometheus](https://prometheus.io/).
* Viewing metrics in real time with [`dotnet-counters`](/dotnet/core/diagnostics/dotnet-counters)

Measurements can also be associated with key-value pairs called tags that allow data to be categorized for analysis. For more information, see [Multi-dimensional metrics](/dotnet/core/diagnostics/metrics-instrumentation#multi-dimensional-metrics).

## Create the starter app

Create a new ASP.NET Core app with the following command:

```dotnetcli
dotnet new web -o WebMetric
cd WebMetric
dotnet add package OpenTelemetry.Exporter.Prometheus.AspNetCore --prerelease
dotnet add package OpenTelemetry.Extensions.Hosting
```

Replace the contents of `Program.cs` with the following code:

:::code language="csharp" source="~/log-mon/metrics/metrics/samples/Program.cs":::

<!-- Review TODO: Add link to available meters -->

## View metrics with dotnet-counters

[dotnet-counters](/dotnet/core/diagnostics/dotnet-counters) is a command-line tool that can view live metrics for .NET Core apps on demand. It doesn't require setup, making it useful for ad-hoc investigations or verifying that metric instrumentation is working. It works with both <xref:System.Diagnostics.Metrics?displayProperty=nameWithType> based APIs and [EventCounters](/dotnet/core/diagnostics/event-counters).

If the [dotnet-counters](/dotnet/core/diagnostics/dotnet-counters) tool isn't installed, run the following command:

```dotnetcli
dotnet tool update -g dotnet-counters
```

While the test app is running, launch [dotnet-counters](/dotnet/core/diagnostics/dotnet-counters). The following command shows an example of `dotnet-counters` monitoring all metrics from the `Microsoft.AspNetCore.Hosting` meter.

```dotnetcli
dotnet-counters monitor -n WebMetric --counters Microsoft.AspNetCore.Hosting
```

Output similar to the following is displayed:

```dotnetcli
Press p to pause, r to resume, q to quit.
    Status: Running

[Microsoft.AspNetCore.Hosting]
    http-server-current-requests
        host=localhost,method=GET,port=5045,scheme=http                    0
    http-server-request-duration (s)
        host=localhost,method=GET,port=5045,protocol=HTTP/1.1,ro           0.001
        host=localhost,method=GET,port=5045,protocol=HTTP/1.1,ro           0.001
        host=localhost,method=GET,port=5045,protocol=HTTP/1.1,ro           0.001
        host=localhost,method=GET,port=5045,protocol=HTTP/1.1,ro           0
        host=localhost,method=GET,port=5045,protocol=HTTP/1.1,ro           0
        host=localhost,method=GET,port=5045,protocol=HTTP/1.1,ro           0                                            12
```

For more information, see [dotnet-counters](/dotnet/core/diagnostics/dotnet-counters).

## Enrich the ASP.NET Core request metric

ASP.NET Core has many built-in metrics. The `http.server.request.duration` metric:
* Records the duration of HTTP requests on the server.
* Captures request information in tags, such as the matched route and response status code.

The `http.server.request.duration` metric supports tag enrichment using <xref:Microsoft.AspNetCore.Http.Features.IHttpMetricsTagsFeature>. Enrichment is when a library or app adds its own tags to a metric. This is useful if an app wants to add a custom categorization to dashboards or alerts built with metrics.

```cs
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Use(async (context, next) =>
{
    var tagsFeature = context.Features.Get<IHttpMetricsTagsFeature>();
    if (tagsFeature != null)
    {
        var source = context.Request.Query["utm_medium"].ToString() switch
        {
            "" => "none",
            "social" => "social",
            "email" => "email",
            "organic" => "organic",
            _ => "other"
        };
        tagsFeature.Tags.Add(new KeyValuePair<string, object?>("mkt_medium", source));
    }

    await next.Invoke();
});

app.MapGet("/", () => "Hello World!");

app.Run();
```

The proceeding example:

* Adds middleware to enrich the ASP.NET Core request metric.
* Gets the <xref:Microsoft.AspNetCore.Http.Features.IHttpMetricsTagsFeature> from the `HttpContext`. The feature is only present on the context if someone is listening to the metric. Verify `IHttpMetricsTagsFeature` is not `null` before using it.
* Adds a custom tag containing the request's marketing source to the `http.server.request.duration` metric.
  * The tag has the name `mkt_medium` and a value based on the [utm_medium](https://wikipedia.org/wiki/UTM_parameters) query string value. The `utm_medium` value is resolved to a known range of values.
  * The tag allows requests to be categorized by marketing medium type, which could be useful when analyzing web app traffic.

> [!NOTE]
> Follow the [multi-dimensional metrics](/dotnet/core/diagnostics/metrics-instrumentation#multi-dimensional-metrics) best practices when enriching with custom tags. Too many tags, or tags with an unbound range cause a large combination of tags. Collection tools have a limit on how many combinations they support for a counter and may start filtering results out to avoid excessive memory usage.

## Create custom metrics

Metrics are created using APIs in the <xref:System.Diagnostics.Metrics> namespace. See [Create custom metrics](/dotnet/core/diagnostics/metrics-instrumentation#create-a-custom-metric) for information on creating custom metrics.

### Creating metrics in ASP.NET Core apps with `IMeterFactory`

We recommended creating `Meter` instances in ASP.NET Core apps with <xref:System.Diagnostics.Metrics.IMeterFactory>.

ASP.NET Core registers <xref:System.Diagnostics.Metrics.IMeterFactory> in dependency injection (DI) by default. The meter factory integrates metrics with DI, making isolating and collecting metrics easy. `IMeterFactory` is especially useful for testing. It allows for multiple tests to run side-by-side and only collecting metrics values that are recorded in a test.

To use `IMeterFactory` in an app, create a type that uses `IMeterFactory` to create the app's custom metrics:

```cs
public class ContosoMetrics
{
    private readonly Counter<int> _productSoldCounter;

    public ContosoMetrics(IMeterFactory meterFactory)
    {
        var meter = meterFactory.CreateMeter("Contoso.Web");
        _productSoldCounter = meter.CreateCounter<int>("contoso.product.sold");
    }

    public void ProductSold(string productName, int quantity)
    {
        _productSoldCounter.Add(quantity,
            new KeyValuePair<string, object?>("contoso.product.name", productName));
    }
}
```

Register the metrics type with DI in `Program.cs`:

```cs
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ContosoMetrics>();
```

Inject the metrics type and record values where needed. Because the metrics type is registered in DI it can be use with MVC controllers, minimal APIs, or any other type that is created by DI:

```cs
app.MapPost("/complete-sale", ([FromBody] SaleModel model, ContosoMetrics metrics) =>
{
    // ... business logic such as saving the sale to a database ...

    metrics.ProductSold(model.QuantitySold, model.ProductName);
});
```

## View metrics in Grafana with OpenTelemetry and Prometheus

### Overview

[OpenTelemetry](https://opentelemetry.io/):

* Is a vendor-neutral open-source project supported by the [Cloud Native Computing Foundation](https://www.cncf.io/).
* Standardizes generating and collecting telemetry for cloud-native software.
* Works with .NET using the .NET metric APIs.
* Is endorsed by [Azure Monitor](/azure/azure-monitor/app/opentelemetry-overview) and many APM vendors.

This tutorial shows one of the integrations available for OpenTelemetry metrics using the OSS [Prometheus](https://prometheus.io/) and [Grafana](https://grafana.com/) projects. The metrics data flow:

1. The ASP.NET Core metric APIs record measurements from the example app.
1. The OpenTelemetry .NET library running in the app aggregates the measurements.
1. The Prometheus exporter library makes the aggregated data available via an HTTP metrics endpoint. 'Exporter' is what OpenTelemetry calls the libraries that transmit telemetry to vendor-specific backends.
1. A Prometheus server:

   * Polls the metrics endpoint
   * Reads the data
   * Stores the data in a database for long-term persistence. Prometheus refers to reading and storing data as *scraping* an endpoint.
   * Can run on a different machine

1. The Grafana server:

   * Queries the data stored in Prometheus and displays it on a web-based monitoring dashboard.
   * Can run on a different machine.

### View metrics from sample app

Navigate to the sample app. The browser displays `Hello OpenTelemetry! ticks:<3digits>` where `3digits` are the last 3 digits of the current [DateTime.Ticks](/dotnet/api/system.datetime.ticks).

Append `/metrics` to the URL to view the metrics endpoint. The browser displays the metrics being collected:

![metrics 2](~/log-mon/metrics/metrics/static/metrics.png)

### Set up and configure Prometheus

Follow the [Prometheus first steps](https://prometheus.io/docs/introduction/first_steps/) to set up a Prometheus server and confirm it's working.

Modify the *prometheus.yml* configuration file so that Prometheus scrapes the metrics endpoint that the example app is exposing. Add the following highlighted text in the `scrape_configs` section:

:::code language="yaml" source="~/log-mon/metrics/metrics/samples/prometheus.yml" highlight="31-99":::

In the preceding highlighted YAML, replace `5045` with the port number that the example app is running on.

#### Start Prometheus

1. Reload the configuration or restart the Prometheus server.
1. Confirm that OpenTelemetryTest is in the UP state in the **Status** > **Targets** page of the Prometheus web portal.

![Prometheus status](~/log-mon/metrics/metrics/static/prometheus_status.png)

Select the **Open metric explorer** icon to see available metrics:

![Prometheus open_metric_exp](~/log-mon/metrics/metrics/static/open_metric_exp.png)

Enter counter category such as `http_` in the **Expression** input box to see the available  metrics:

![available metrics](~/log-mon/metrics/metrics/static/metrics2.png)

Alternatively, enter counter category such as `kestrel` in the **Expression** input box to see the available  metrics:

![Prometheus kestrel](~/log-mon/metrics/metrics/static/kestrel.png)

### Show metrics on a Grafana dashboard

1. Follow the [installation instructions](https://prometheus.io/docs/visualization/grafana/#creating-a-prometheus-graph) to install Grafana and connect it to a Prometheus data source.

1. Follow [Creating a Prometheus graph](https://prometheus.io/docs/visualization/grafana/#creating-a-prometheus-graph). Alternatively, download a JSON file from [aspnetcore-grafana dashboards](https://github.com/JamesNK/aspnetcore-grafana/tree/main/dashboards) to configure Grafana.

![dashboard-screenshot2](~/log-mon/metrics/metrics/static/dashboard-screenshot.png)

## Test metrics in ASP.NET Core apps

It's possible to test metrics in ASP.NET Core apps. One way to do that is collect and assert metrics values in [ASP.NET Core integration tests](xref:test/integration-tests) using <xref:Microsoft.Extensions.Telemetry.Testing.Metering.MetricCollector%601>.

```cs
public class BasicTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public BasicTests(WebApplicationFactory<Program> factory) => _factory = factory;

    [Fact]
    public async Task Get_RequestCounterIncreased()
    {
        // Arrange
        var client = _factory.CreateClient();
        var meterFactory = _factory.Services.GetRequiredService<IMeterFactory>();
        var collector = new MetricCollector<double>(meterFactory,
            "Microsoft.AspNetCore.Hosting", "http.server.request.duration");

        // Act
        var response = await client.GetAsync("/");

        // Assert
        Assert.Equal("Hello World!", await response.Content.ReadAsStringAsync());

        await collector.WaitForMeasurementsAsync(minCount: 1).WaitAsync(TimeSpan.FromSeconds(5));
        Assert.Collection(collector.GetMeasurementSnapshot(),
            measurement =>
            {
                Assert.Equal("http", measurement.Tags["url.scheme"]);
                Assert.Equal("GET", measurement.Tags["http.request.method"]);
                Assert.Equal("/", measurement.Tags["http.route"]);
            });
    }
}
```

The proceeding test:

* Bootstraps a web app in memory with <xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory%601>. `Program` in the factory's generic argument specifies the web app.
* Collects metrics values with <xref:Microsoft.Extensions.Telemetry.Testing.Metering.MetricCollector%601>.
  * Requires a package reference to `Microsoft.Extensions.Telemetry.Testing`.
  * The `MetricCollector<T>` is created using the web app's <xref:System.Diagnostics.Metrics.IMeterFactory>. This allows the collector to only report metrics values recorded by test.
  * Includes the meter name, `Microsoft.AspNetCore.Hosting`, and counter name, `http.server.request.duration` to collect.
* Makes an HTTP request to the web app.
* Asserts the test using results from the metrics collector.

## ASP.NET Core meters and counters

* [HostingMetrics](https://source.dot.net/#Microsoft.AspNetCore.Hosting/Internal/HostingMetrics.cs,0e3eae9d5e50ff0d)
* [KestrelMetrics](https://source.dot.net/#Microsoft.AspNetCore.Server.Kestrel.Core/Internal/Infrastructure/KestrelMetrics.cs,8d505625d99068a6)
* SignalR [HttpConnectionsMetrics](https://source.dot.net/#Microsoft.AspNetCore.Http.Connections/Internal/HttpConnectionsMetrics.cs,2d63d88d7202e42d,references)
