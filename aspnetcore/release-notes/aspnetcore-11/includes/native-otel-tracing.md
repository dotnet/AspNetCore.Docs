### Native OpenTelemetry tracing for ASP.NET Core

ASP.NET Core now natively adds OpenTelemetry semantic convention attributes to the HTTP server activity, aligning with the [OpenTelemetry HTTP server span specification](https://opentelemetry.io/docs/specs/semconv/http/http-spans/#http-server-span). All required attributes are included by default, matching the metadata previously only available through the `OpenTelemetry.Instrumentation.AspNetCore` library.

To collect the built-in tracing data, subscribe to the `Microsoft.AspNetCore` activity source in your OpenTelemetry configuration:

```csharp
builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing
        .AddSource("Microsoft.AspNetCore")
        .AddConsoleExporter());
```

No additional instrumentation library (such as `OpenTelemetry.Instrumentation.AspNetCore`) is needed. The framework now directly populates semantic convention attributes on the request activity, such as `http.request.method`, `url.path`, `http.response.status_code`, and `server.address`.

If you don't want OpenTelemetry attributes added to the activity, you can turn it off by setting the `Microsoft.AspNetCore.Hosting.SuppressActivityOpenTelemetryData` AppContext switch to `true`.
