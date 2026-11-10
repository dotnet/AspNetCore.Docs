---
ms.date: 09/25/2024
---

:::moniker range=">= aspnetcore-6.0 <= aspnetcore-7.0"

HTTP Logging is a middleware that logs information about incoming HTTP requests and HTTP responses. HTTP logging provides logs of:

* HTTP request information
* Common properties
* Headers
* Body
* HTTP response information

HTTP Logging is valuable in several scenarios to:

* Record information about incoming requests and responses.
* Filter which parts of the request and response are logged.
* Filtering which headers to log.

HTTP Logging ***can reduce the performance of an app***, especially when logging the request and response bodies. Consider the performance impact when selecting fields to log. Test the performance impact of the selected logging properties.

> [!WARNING]
> HTTP Logging can potentially log personally identifiable information (PII). Consider the risk and avoid logging sensitive information.

## Enabling HTTP logging

HTTP Logging is enabled with <xref:Microsoft.AspNetCore.Builder.HttpLoggingBuilderExtensions.UseHttpLogging*>, which adds HTTP logging middleware.

[!code-csharp[](~/fundamentals/http-logging/samples/6.x/Program.cs?name=snippet2&highlight=5)]

By default, HTTP logging logs request properties, such as the path, and request headers. It also logs the response status code and response headers. The request path isn't repeated in separate response or body log entries.

Add the following line to the `appsettings.Development.json` file at the `"LogLevel": {` level so the HTTP logs are displayed:

```json
 "Microsoft.AspNetCore.HttpLogging.HttpLoggingMiddleware": "Information"
 ```

Request and response details are logged as separate messages at `LogLevel.Information`. The following example shows the request message:

![Sample request output](~/fundamentals/http-logging/_static/requestlog.png)

To correlate separate log messages from the same request, enable [log scopes](../../logging/index.md#log-scopes) on a logging provider that supports scopes.

## HTTP Logging options

To configure the HTTP logging middleware, call <xref:Microsoft.Extensions.DependencyInjection.HttpLoggingServicesExtensions.AddHttpLogging*> in `Program.cs`.

[!code-csharp[](~/fundamentals/http-logging/samples/6.x/Program.cs?name=snippet_Addservices)]

> [!NOTE]
> In the preceding sample and following samples, `UseHttpLogging` is called after `UseStaticFiles`, so HTTP logging is not enabled for static file. To enable static file HTTP logging, call `UseHttpLogging` before `UseStaticFiles`.

### `LoggingFields`

[`HttpLoggingOptions.LoggingFields`](xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions.LoggingFields) is an enum flag that configures specific parts of the request and response to log. ``HttpLoggingOptions.LoggingFields`` defaults to <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestPropertiesAndHeaders> | <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponsePropertiesAndHeaders>.

### `RequestHeaders`

<xref:Microsoft.AspNetCore.Http.HttpRequest.Headers> are a set of HTTP Request Headers that are allowed to be logged. Header values are only logged for header names that are in this collection. The following code logs the request header `"sec-ch-ua"`. If `logging.RequestHeaders.Add("sec-ch-ua");` is removed, the value of the request header `"sec-ch-ua"` is redacted. The following highlighted code calls [`HttpLoggingOptions.RequestHeaders`](xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions.RequestHeaders) and [`HttpLoggingOptions.ResponseHeaders`](xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions.ResponseHeaders) :

[!code-csharp[](~/fundamentals/http-logging/samples/6.x/Program.cs?name=snippet_Addservices&highlight=8,9)]

### `MediaTypeOptions`

<xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions.MediaTypeOptions> provides configuration for selecting which encoding to use for a specific media type.

[!code-csharp[](~/fundamentals/http-logging/samples/6.x/Program.cs?name=snippet_Addservices&highlight=10)]

This approach can also be used to enable logging for data that is not logged by default. For example, form data, which might have a media type such as `application/x-www-form-urlencoded` or `multipart/form-data`.

#### `MediaTypeOptions` methods

* <xref:Microsoft.AspNetCore.HttpLogging.MediaTypeOptions.AddText*>
* <xref:Microsoft.AspNetCore.HttpLogging.MediaTypeOptions.AddBinary*>
* <xref:Microsoft.AspNetCore.HttpLogging.MediaTypeOptions.Clear*>

### `RequestBodyLogLimit` and `ResponseBodyLogLimit`

* <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions.RequestBodyLogLimit>
* <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions.ResponseBodyLogLimit>

[!code-csharp[](~/fundamentals/http-logging/samples/6.x/Program.cs?name=snippet_Addservices&highlight=11-12)]

:::moniker-end
