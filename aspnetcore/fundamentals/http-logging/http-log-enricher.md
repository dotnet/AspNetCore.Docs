---
title: HTTP log enricher for incoming requests
description: Learn how to use the HTTP log enricher for incoming HTTP requests in ASP.NET Core.
ai-usage: ai-assisted
author: mariamaziz
monikerRange: '>= aspnetcore-8.0'
ms.author: mariamaziz
ms.custom: mvc
ms.date: 03/09/2026
uid: fundamentals/http-logging/http-log-enricher
---

# HTTP log enricher

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-8.0"

You can create a custom HTTP log enricher by creating a class that implements the <xref:Microsoft.AspNetCore.Diagnostics.Logging.IHttpLogEnricher> interface. Unlike general-purpose log enrichers that enrich all logs in your application, HTTP log enrichers specifically target incoming HTTP request logs in ASP.NET Core, allowing you to add contextual information based on the `HttpContext` of each request.

After the class is created, you register it with <xref:Microsoft.Extensions.DependencyInjection.HttpLoggingServiceCollectionExtensions.AddHttpLogEnricher``1(Microsoft.Extensions.DependencyInjection.IServiceCollection)>. Once registered, the logging infrastructure automatically calls the `Enrich()` method on every registered enricher for each incoming HTTP request processed by the ASP.NET Core pipeline.

> [!IMPORTANT]
> The `IHttpLogEnricher` interface is experimental and requires the `EXTEXP0013` diagnostic ID suppression. For more information, see [Experimental features in .NET Extensions](https://aka.ms/dotnet-extensions-warnings/EXTEXP0013).

## Install the package

To get started, install the [📦 Microsoft.AspNetCore.Diagnostics.Middleware](https://www.nuget.org/packages/Microsoft.AspNetCore.Diagnostics.Middleware) NuGet package:

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.AspNetCore.Diagnostics.Middleware
```

Or, if you're using .NET 10+ SDK:

```dotnetcli
dotnet package add Microsoft.AspNetCore.Diagnostics.Middleware
```

### [PackageReference](#tab/package-reference)

```xml
<PackageReference Include="Microsoft.AspNetCore.Diagnostics.Middleware"
                  Version="*" /> <!-- Adjust version -->
```

---

## IHttpLogEnricher implementation

Your custom HTTP log enricher needs to implement a single <xref:Microsoft.AspNetCore.Diagnostics.Logging.IHttpLogEnricher.Enrich(Microsoft.Extensions.Diagnostics.Enrichment.IEnrichmentTagCollector,Microsoft.AspNetCore.Http.HttpContext)> method. During enrichment, this method is called and given an <xref:Microsoft.Extensions.Diagnostics.Enrichment.IEnrichmentTagCollector> instance along with the <xref:Microsoft.AspNetCore.Http.HttpContext> for the incoming request. The enricher then calls one of the overloads of the <xref:Microsoft.Extensions.Diagnostics.Enrichment.IEnrichmentTagCollector.Add(System.String,System.Object)> method to record any properties it wants.

> [!NOTE]
> If your custom HTTP log enricher calls <xref:Microsoft.Extensions.Diagnostics.Enrichment.IEnrichmentTagCollector.Add(System.String,System.Object)>,
> it's acceptable to send any type of argument to the `value` parameter as-is, because it's parsed into the actual type and serialized internally
> to be sent further down the logging pipeline.

:::code language="csharp" source="~/fundamentals/http-logging/samples/httplogenricher/CustomHttpLogEnricher.cs" :::

And you register it as shown in the following code using <xref:Microsoft.Extensions.DependencyInjection.HttpLoggingServiceCollectionExtensions.AddHttpLogEnricher``1(Microsoft.Extensions.DependencyInjection.IServiceCollection)>:

:::code language="csharp" source="~/fundamentals/http-logging/samples/httplogenricher/Program.cs" :::

## Key differences from general log enrichers

HTTP log enrichers differ from general-purpose log enrichers (<xref:Microsoft.Extensions.Diagnostics.Enrichment.ILogEnricher>) in several important ways:

- **Scope**: HTTP log enrichers only enrich logs produced by incoming ASP.NET Core HTTP requests, while general log enrichers enrich all logs in the application.
- **Context**: HTTP log enrichers have access to the full `HttpContext`, including the request, response, user, connection, and any other context data associated with the incoming request.
- **Package**: HTTP log enrichers require the `Microsoft.AspNetCore.Diagnostics.Middleware` package, while general log enrichers use the `Microsoft.Extensions.Telemetry.Abstractions` package.
- **Direction**: HTTP log enrichers target **incoming** server-side requests, while <xref:Microsoft.Extensions.Http.Logging.IHttpClientLogEnricher> targets **outgoing** client-side HTTP requests.

## Remarks

- The `Enrich` method is called during the HTTP response phase of the request/response lifecycle, after the response has been processed.
- The `httpContext` parameter is always provided and will never be `null`.
- Multiple enrichers can be registered and will be executed in the order they were registered.
- If an enricher throws an exception, it's logged and execution continues with the remaining enrichers.
- The `IHttpLogEnricher` interface is marked as experimental with diagnostic ID `EXTEXP0013` and requires .NET 8 or later.
- Calling `AddHttpLogEnricher<T>()` automatically sets up the required HTTP logging redaction infrastructure by internally calling `AddHttpLoggingRedaction()`.
- You must still add the `UseHttpLogging()` middleware in the application pipeline for HTTP logs to be emitted.

## See also

- [HTTP logging in ASP.NET Core](~/fundamentals/http-logging/index.md)
