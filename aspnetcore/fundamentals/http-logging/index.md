---
title: HTTP logging in .NET Core and ASP.NET Core
author: tdykstra
description: Learn how to log HTTP requests and responses.
monikerRange: '>= aspnetcore-6.0'
ms.author: tdykstra
ms.custom: mvc
$104/25/2025
uid: fundamentals/http-logging/index
---
# HTTP logging in ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-8.0"

HTTP logging is a middleware that logs information about incoming HTTP requests and HTTP responses. HTTP logging provides logs of:

* HTTP request information
* Common properties
* Headers
* Body
* HTTP response information

HTTP logging can:

* Log all requests and responses or only requests and responses that meet certain criteria.
* Select which parts of the request and response are logged.
* Allow you to redact sensitive information from the logs.

HTTP logging ***can reduce the performance of an app***, especially when logging the request and response bodies. Consider the performance impact when selecting fields to log. Test the performance impact of the selected logging properties.

> [!WARNING]
> HTTP logging can potentially log personally identifiable information (PII). Consider the risk and avoid logging sensitive information.
> For more information about redaction, check [redacting sensitive data](#redacting-sensitive-data)

## Enable HTTP logging

HTTP logging is enabled by calling <xref:Microsoft.Extensions.DependencyInjection.HttpLoggingServicesExtensions.AddHttpLogging%2A> and <xref:Microsoft.AspNetCore.Builder.HttpLoggingBuilderExtensions.UseHttpLogging%2A>, as shown in the following example:

[!code-csharp[](~/fundamentals/http-logging/samples/8.x/Program.cs?name=snippet2&highlight=3,7)]

The empty lambda in the preceding example of calling `AddHttpLogging` adds the middleware with the default configuration. By default, HTTP logging logs common properties such as path, status-code, and headers for requests and responses.

Add the following line to the `appsettings.Development.json` file at the `"LogLevel": {` level so the HTTP logs are displayed:

```json
"Microsoft.AspNetCore.HttpLogging.HttpLoggingMiddleware": "Information"
```

With the default configuration, a request and response is logged as a pair of messages similar to the following example:

```output
info: Microsoft.AspNetCore.HttpLogging.HttpLoggingMiddleware[1]
      Request:
      Protocol: HTTP/2
      Method: GET
      Scheme: https
      PathBase:
      Path: /
      Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7
      Host: localhost:52941
      User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/118.0.0.0 Safari/537.36 Edg/118.0.2088.61
      Accept-Encoding: gzip, deflate, br
      Accept-Language: en-US,en;q=0.9
      Upgrade-Insecure-Requests: [Redacted]
      sec-ch-ua: [Redacted]
      sec-ch-ua-mobile: [Redacted]
      sec-ch-ua-platform: [Redacted]
      sec-fetch-site: [Redacted]
      sec-fetch-mode: [Redacted]
      sec-fetch-user: [Redacted]
      sec-fetch-dest: [Redacted]
info: Microsoft.AspNetCore.HttpLogging.HttpLoggingMiddleware[2]
      Response:
      StatusCode: 200
      Content-Type: text/plain; charset=utf-8
      Date: Tue, 24 Oct 2023 02:03:53 GMT
      Server: Kestrel
```

## HTTP logging options

To configure global options for the HTTP logging middleware, call <xref:Microsoft.Extensions.DependencyInjection.HttpLoggingServicesExtensions.AddHttpLogging%2A> in `Program.cs`, using the lambda to configure <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions>.

[!code-csharp[](~/fundamentals/http-logging/samples/8.x/Program.cs?name=snippet_Addservices)]

> [!NOTE]
> In the preceding sample and following samples, `UseHttpLogging` is called after `UseStaticFiles`, so HTTP logging isn't enabled for static files. To enable static file HTTP logging, call `UseHttpLogging` before `UseStaticFiles`.

### `LoggingFields`

[`HttpLoggingOptions.LoggingFields`](xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions.LoggingFields) is an enum flag that configures specific parts of the request and response to log. `LoggingFields` defaults to <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestPropertiesAndHeaders> | <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponsePropertiesAndHeaders>.

### `RequestHeaders` and `ResponseHeaders`

<xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions.RequestHeaders> and <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions.ResponseHeaders> are sets of HTTP headers that are logged. Header values are only logged for header names that are in these collections. The following code adds `sec-ch-ua` to the <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions.RequestHeaders>, so the value of the `sec-ch-ua` header is logged. And it adds `MyResponseHeader` to the <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions.ResponseHeaders>, so the value of the `MyResponseHeader` header is logged. If these lines are removed, the values of these headers are `[Redacted]`.

[!code-csharp[](~/fundamentals/http-logging/samples/8.x/Program.cs?name=snippet_Addservices&highlight=8,9)]

### `MediaTypeOptions`

<xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions.MediaTypeOptions> provides configuration for selecting which encoding to use for a specific media type.

[!code-csharp[](~/fundamentals/http-logging/samples/8.x/Program.cs?name=snippet_Addservices&highlight=10)]

This approach can also be used to enable logging for data that isn't logged by default (for example, form data, which might have a media type such as `application/x-www-form-urlencoded` or `multipart/form-data`).

#### `MediaTypeOptions` methods

* <xref:Microsoft.AspNetCore.HttpLogging.MediaTypeOptions.AddText%2A>
* <xref:Microsoft.AspNetCore.HttpLogging.MediaTypeOptions.AddBinary%2A>
* <xref:Microsoft.AspNetCore.HttpLogging.MediaTypeOptions.Clear%2A>

### `RequestBodyLogLimit` and `ResponseBodyLogLimit`

* <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions.RequestBodyLogLimit>
* <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions.ResponseBodyLogLimit>

[!code-csharp[](~/fundamentals/http-logging/samples/8.x/Program.cs?name=snippet_Addservices&highlight=11-12)]

### `CombineLogs`

Setting <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions.CombineLogs> to `true` configures the middleware to consolidate all of its enabled logs for a request and response into one log at the end. This includes the request, request body, response, response body, and duration.

[!code-csharp[](~/fundamentals/http-logging/samples/8.x/Program.cs?name=snippet_Addservices&highlight=13)]

## Endpoint-specific configuration

For endpoint-specific configuration in minimal API apps, a <xref:Microsoft.AspNetCore.Builder.HttpLoggingEndpointConventionBuilderExtensions.WithHttpLogging%2A> extension method is available. The following example shows how to configure HTTP logging for one endpoint:

[!code-csharp[](~/fundamentals/http-logging/samples/8.x/Program.cs?name=snippet6)]

For endpoint-specific configuration in apps that use controllers, the [`[HttpLogging]` attribute](xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingAttribute) is available. The attribute can also be used in minimal API apps, as shown in the following example:

[!code-csharp[](~/fundamentals/http-logging/samples/8.x/Program.cs?name=snippet5)]

## `IHttpLoggingInterceptor`

<xref:Microsoft.AspNetCore.HttpLogging.IHttpLoggingInterceptor> is the interface for a service that can be implemented to handle per-request and per-response callbacks for customizing what details get logged. Any endpoint-specific log settings are applied first and can then be overridden in these callbacks. An implementation can:

* Inspect a request or response.
* Enable or disable any <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingFields>.
* Adjust how much of the request or response body is logged.
* Add custom fields to the logs.

Register an <xref:Microsoft.AspNetCore.HttpLogging.IHttpLoggingInterceptor> implementation by calling <xref:Microsoft.Extensions.DependencyInjection.HttpLoggingServicesExtensions.AddHttpLoggingInterceptor%2A> in `Program.cs`. If multiple <xref:Microsoft.AspNetCore.HttpLogging.IHttpLoggingInterceptor> instances are registered, they're run in the order registered.

The following example shows how to register an <xref:Microsoft.AspNetCore.HttpLogging.IHttpLoggingInterceptor> implementation:

[!code-csharp[](~/fundamentals/http-logging/samples/8.x/Program.cs?name=snippet4&highlight=7)]

The following example is an <xref:Microsoft.AspNetCore.HttpLogging.IHttpLoggingInterceptor> implementation that:

* Inspects the request method and disables logging for POST requests.
* For non-POST requests:
  * Redacts request path, request headers, and response headers.
  * Adds custom fields and field values to the request and response logs.

[!code-csharp[](~/fundamentals/http-logging/samples/8.x/SampleHttpLoggingInterceptor.cs)]

With this interceptor, a POST request doesn't generate any logs even if HTTP logging is configured to log [`HttpLoggingFields.All`](xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingFields). A GET request generates logs similar to the following example:

```output
info: Microsoft.AspNetCore.HttpLogging.HttpLoggingMiddleware[1]
      Request:
      Path: RedactedPath
      Accept: RedactedHeader
      Host: RedactedHeader
      User-Agent: RedactedHeader
      Accept-Encoding: RedactedHeader
      Accept-Language: RedactedHeader
      Upgrade-Insecure-Requests: RedactedHeader
      sec-ch-ua: RedactedHeader
      sec-ch-ua-mobile: RedactedHeader
      sec-ch-ua-platform: RedactedHeader
      sec-fetch-site: RedactedHeader
      sec-fetch-mode: RedactedHeader
      sec-fetch-user: RedactedHeader
      sec-fetch-dest: RedactedHeader
      RequestEnrichment: Stuff
      Protocol: HTTP/2
      Method: GET
      Scheme: https
info: Microsoft.AspNetCore.HttpLogging.HttpLoggingMiddleware[2]
      Response:
      Content-Type: RedactedHeader
      MyResponseHeader: RedactedHeader
      ResponseEnrichment: Stuff
      StatusCode: 200
info: Microsoft.AspNetCore.HttpLogging.HttpLoggingMiddleware[4]
      ResponseBody: Hello World!
info: Microsoft.AspNetCore.HttpLogging.HttpLoggingMiddleware[8]
      Duration: 2.2778ms
```

## Logging configuration order of precedence

The following list shows the order of precedence for logging configuration:

1. Global configuration from <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions>, set by calling <xref:Microsoft.Extensions.DependencyInjection.HttpLoggingServicesExtensions.AddHttpLogging%2A>.
1. Endpoint-specific configuration from the [`[HttpLogging]` attribute](xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingAttribute) or the <xref:Microsoft.AspNetCore.Builder.HttpLoggingEndpointConventionBuilderExtensions.WithHttpLogging%2A> extension method overrides global configuration.
1. [`IHttpLoggingInterceptor`](#ihttplogginginterceptor) is called with the results and can further modify the configuration per request.

:::moniker-end

[!INCLUDE[](~/fundamentals/http-logging/includes/index-6-7.md)]

:::moniker range=">= aspnetcore-9.0"

## Redacting sensitive data

Http logging with redaction can be enabled by calling <xref:Microsoft.Extensions.DependencyInjection.HttpLoggingServiceCollectionExtensions.AddHttpLoggingRedaction%2A>:

[!code-csharp[](~/fundamentals/http-logging/samples/9.x/Program.cs?name=snippet7&highlight=9)]

For more information about .NET's data redaction library, see [Data redaction in .NET](/dotnet/core/extensions/data-redaction).

## Logging redaction options

To configure options for logging with redaction, call <xref:Microsoft.Extensions.DependencyInjection.HttpLoggingServiceCollectionExtensions.AddHttpLoggingRedaction%2A> in `Program.cs` using the lambda to configure <xref:Microsoft.AspNetCore.Diagnostics.Logging.LoggingRedactionOptions>:

[!code-csharp[](~/fundamentals/http-logging/samples/9.x/MyTaxonomyClassifications.cs)]

[!code-csharp[](~/fundamentals/http-logging/samples/9.x/Program.cs?name=snippet_redactionOptions&highlight=6)]

With the previous redaction configuration, the output is similar to the following:

```output
info: Microsoft.AspNetCore.HttpLogging.HttpLoggingMiddleware[9]
      Request and Response:
      server.address: localhost:61361
      Path: /
      http.request.header.accept:
      Protocol: HTTP/2
      Method: GET
      Scheme: https
      http.response.header.content-type:
      StatusCode: 200
      Duration: 8.4684
info: Microsoft.AspNetCore.Hosting.Diagnostics[2]
      Request finished HTTP/2 GET https://localhost:61361/ - 200 - text/plain;+charset=utf-8 105.5334ms
```

> [!NOTE]
> Request path `/home` isn't logged because it's included in the [`ExcludePathStartsWith` property](#excludepathstartswith). `http.request.header.accept` and `http.response.header.content-type` were redacted by <xref:Microsoft.Extensions.Compliance.Redaction.ErasingRedactor?displayProperty=nameWithType>.

### `RequestPathLoggingMode`

<xref:Microsoft.AspNetCore.Diagnostics.Logging.LoggingRedactionOptions.RequestPathLoggingMode%2A> determines how the request path is logged, whether `Formatted` or `Structured`, set by <xref:Microsoft.AspNetCore.Diagnostics.Logging.IncomingPathLoggingMode>:

* `Formatted`: Logs the request path without parameters.
* `Structured`: Logs the request path with parameters included.

[!code-csharp[](~/fundamentals/http-logging/samples/9.x/Program.cs?name=snippet_redactionOptions&highlight=9)]

### `RequestPathParameterRedactionMode`

<xref:Microsoft.AspNetCore.Diagnostics.Logging.LoggingRedactionOptions.RequestPathParameterRedactionMode%2A>
specifies how route parameters in the request path should be redacted, whether `Strict`, `Loose`, or `None`, set by <xref:Microsoft.Extensions.Http.Diagnostics.HttpRouteParameterRedactionMode>:

* `Strict`: Request route parameters are considered sensitive, require explicit annotation with a data classification, and are redacted by default.
* `Loose`: All parameters are considered as non-sensitive and included as-is by default.
* `None`: Route parameters aren't redacted regardless of the presence of data classification annotations.

[!code-csharp[](~/fundamentals/http-logging/samples/9.x/Program.cs?name=snippet_redactionOptions&highlight=8)]

### `RequestHeadersDataClasses`

<xref:Microsoft.AspNetCore.Diagnostics.Logging.LoggingRedactionOptions.RequestHeadersDataClasses%2A> maps request headers to their data classification, which determines how they are redacted:

[!code-csharp[](~/fundamentals/http-logging/samples/9.x/Program.cs?name=snippet_redactionOptions&highlight=10)]

### `ResponseHeadersDataClasses`

<xref:Microsoft.AspNetCore.Diagnostics.Logging.LoggingRedactionOptions.ResponseHeadersDataClasses%2A>, similar to <xref:Microsoft.AspNetCore.Diagnostics.Logging.LoggingRedactionOptions.RequestHeadersDataClasses%2A>`, but for response headers:

[!code-csharp[](~/fundamentals/http-logging/samples/9.x/Program.cs?name=snippet_redactionOptions&highlight=11)]

### `RouteParameterDataClasses`

<xref:Microsoft.AspNetCore.Diagnostics.Logging.LoggingRedactionOptions.RouteParameterDataClasses%2A> maps route parameters to their data classification:

[!code-csharp[](~/fundamentals/http-logging/samples/9.x/Program.cs?name=snippet_redactionOptions&highlight=12,13,14,15)]

### `ExcludePathStartsWith`

<xref:Microsoft.AspNetCore.Diagnostics.Logging.LoggingRedactionOptions.ExcludePathStartsWith%2A> specifies paths that should be excluded from logging entirely:

[!code-csharp[](~/fundamentals/http-logging/samples/9.x/Program.cs?name=snippet_redactionOptions&highlight=16,17)]

### `IncludeUnmatchedRoutes`

<xref:Microsoft.AspNetCore.Diagnostics.Logging.LoggingRedactionOptions.IncludeUnmatchedRoutes%2A> allows reporting unmatched routes. If set to `true`, logs whole path of routes not identified by [Routing](xref:fundamentals/routing) instead of logging `Unknown` value for path attribute:

[!code-csharp[](~/fundamentals/http-logging/samples/9.x/Program.cs?name=snippet_redactionOptions&highlight=18)]

:::moniker-end
