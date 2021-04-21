---
title: HTTP Logging in .NET Core and ASP.NET Core
author: jkotalik
description: Learn how to log HTTP Requests and Response.
monikerRange: '>= aspnetcore-6.0'
ms.author: jukotali
ms.custom: mvc
ms.date: 04/20/2021
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: fundamentals/http-logging/index
---

# HTTP Logging in ASP.NET Core

HTTP Logging is a middleware that logs information about HTTP requests and HTTP responses. HTTP logging logs HTTP request information, common properties, headers, body, and HTTP response information. HTTP Logging is valuable in several scenarios to:

* Record information about incoming requests and responses.
* Filter which parts of the request and response are logged.
* Filtering which headers to log.

HTTP Logging ***can reduce the performance of an app***, especially when logging the request and response bodies. Consider performance when choosing the fields to log.

> [!WARNING]
> HTTP Logging can potentially log personally identifiable information (PII). Consider this risk to avoid logging sensitive information.

## Enabling HTTP Logging

HTTP Logging is enabled with `UseHttpLogging`, which add HTTP logging middleware.

[!code-csharp[](samples/6.x/Startup.cs?name=snippet)]

By default, HTTP Logging will log common properties (path, query, status-code) and headers for requests and responses. These logs will be logged as a single message at `LogLevel.Information`.

![Sample request output](_static/requestlog.png)

## HTTP Logging Options

To configure the HTTP logging middleware, call `AddHttpLogging()` as part of the `ConfigureServices`.

[!code-csharp[](samples/6.x/Startup.cs?name=configureservices)]

### LoggingFields

`HttpLoggingOptions.LoggingFields` is an enum flag which configures which part of the request and response to log. LoggingFields defaults to `RequestPropertiesAndHeaders | ResponsePropertiesAndHeaders`.

[!code-csharp[](samples/6.x/Startup.cs?name=configureservices&highlight=6)]

| Flag | Description | Value |
| ---- | ----------- | :---: |
| None | No logging. | 0x0 |
| RequestPath | Flag for logging the HTTP Request Path, which includes both the <see cref="HttpRequest.Path"/> and <see cref="HttpRequest.PathBase"/>. | 0x1 |
| RequestQuery | Flag for logging the HTTP Request <see cref="HttpRequest.QueryString"/>. | 0x2 |
| RequestProtocol | Flag for logging the HTTP Request <see cref="HttpRequest.Protocol"/>. | 0x4 |
| RequestMethod | Flag for logging the HTTP Request <see cref="HttpRequest.Method"/>. | 0x8 |
| RequestScheme | Flag for logging the HTTP Request <see cref="HttpRequest.Scheme"/>. | 0x10 |
| ResponseStatusCode | Flag for logging the HTTP Response <see cref="HttpResponse.StatusCode"/>. | 0x20 |
| RequestHeaders | Flag for logging the HTTP Request <see cref="HttpRequest.Headers"/>. Request Headers are logged as soon as the middleware is invoked. Headers are redacted by default with the character '[Redacted]' unless specified in the <see cref="HttpLoggingOptions.RequestHeaders"/>. | 0x40 |
| ResponseHeaders | Flag for logging the HTTP Response <see cref="HttpResponse.Headers"/>. Response Headers are logged when the <see cref="HttpResponse.Body"/> is written to or when <see cref="IHttpResponseBodyFeature.StartAsync(System.Threading.CancellationToken)"/> is called. Headers are redacted by default with the character '[Redacted]' unless specified in the <see cref="HttpLoggingOptions.ResponseHeaders"/>. | 0x80 |
| RequestTrailers | Flag for logging the HTTP Request <see cref="IHttpRequestTrailersFeature.Trailers"/>. Request Trailers are currently not logged. | 0x100 |
| ResponseTrailers | Flag for logging the HTTP Response <see cref="IHttpResponseTrailersFeature.Trailers"/>. Response Trailers are currently not logged. | 0x200 |
| RequestBody | Flag for logging the HTTP Request <see cref="HttpRequest.Body"/>.Logging the request body has performance implications, as it requires buffering the entire request body up to <see cref="HttpLoggingOptions.RequestBodyLogLimit"/>. | 0x400 |
| ResponseBody | Flag for logging the HTTP Response <see cref="HttpResponse.Body"/>. Logging the response body has performance implications, as it requires buffering the entire response body up to <see cref="HttpLoggingOptions.ResponseBodyLogLimit"/>. | 0x800 |
| RequestProperties | Flag for logging a collection of HTTP Request properties,including <see cref="RequestPath"/>, <see cref="RequestQuery"/>, <see cref="RequestProtocol"/>, <see cref="RequestMethod"/>, and <see cref="RequestScheme"/>. | `RequestPath | RequestQuery | RequestProtocol | RequestMethod | RequestScheme` |
| RequestPropertiesAndHeaders | Flag for logging HTTP Request properties and headers. Includes <see cref="RequestProperties"/> and <see cref="RequestHeaders"/>. | `RequestProperties | RequestHeaders` |
| ResponsePropertiesAndHeaders | Flag for logging HTTP Response properties and headers. Includes <see cref="ResponseStatusCode"/> and <see cref="ResponseHeaders"/>. | `ResponseStatusCode | ResponseHeaders` |
| Request | Flag for logging the entire HTTP Request. Includes <see cref="RequestPropertiesAndHeaders"/> and <see cref="RequestBody"/>. Logging the request body has performance implications, as it requires buffering the entire request body up to <see cref="HttpLoggingOptions.RequestBodyLogLimit"/>. | `RequestPropertiesAndHeaders | RequestBody` |
| Response | Flag for logging the entire HTTP Response. Includes <see cref="ResponsePropertiesAndHeaders"/> and <see cref="ResponseBody"/>. Logging the response body has performance implications, as it requires buffering the entire response body up to <see cref="HttpLoggingOptions.ResponseBodyLogLimit"/>. | `ResponseStatusCode | ResponseHeaders | ResponseBody` |
| All | Flag for logging both the HTTP Request and Response. Includes <see cref="Request"/> and <see cref="Response"/>. Logging the request and response body has performance implications, as it requires buffering the entire request and response body up to the <see cref="HttpLoggingOptions.RequestBodyLogLimit"/> and <see cref="HttpLoggingOptions.ResponseBodyLogLimit"/>. | `Request | Response` |

### RequestHeaders

RequestHeaders are a set of HTTP Request Headers that are allowed to be logged. Header values will only be logged for header names that are in this collection.

[!code-csharp[](samples/6.x/Startup.cs?name=configureservices&highlight=7)]

### ResponseHeaders

ResponseHeaders are a set of HTTP Request Headers that are allowed to be logged. Header values will only be logged for header names that are in this collection.

[!code-csharp[](samples/6.x/Startup.cs?name=configureservices&highlight=8)]

### MediaTypeOptions

MediaTypeOptions provides configuration for selecting which encoding to use for a specific media type. 

[!code-csharp[](samples/6.x/Startup.cs?name=configureservices&highlight=9)]

### RequestBodyLogLimit

Maximum request body size to log (in bytes). Defaults to 32 KB.

[!code-csharp[](samples/6.x/Startup.cs?name=configureservices&highlight=10)]

### ResponseBodyLogLimit

Maximum response body size to log (in bytes). Defaults to 32 KB.

[!code-csharp[](samples/6.x/Startup.cs?name=configureservices&highlight=11)]
