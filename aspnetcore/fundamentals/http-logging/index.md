---
title: HTTP Logging in .NET Core and ASP.NET Core
author: jkotalik
description: Learn how to log HTTP Requests and Response.
monikerRange: '>= aspnetcore-6.0'
ms.author: jukotali
ms.custom: mvc
ms.date: 04/20/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: fundamentals/http-logging/index
---

# HTTP Logging in ASP.NET Core

:::moniker range=">= aspnetcore-6.0"

HTTP Logging is a middleware that logs information about HTTP requests and HTTP responses. HTTP logging provides logs of:

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

HTTP Logging is enabled with <xref:Microsoft.AspNetCore.Builder.HttpLoggingBuilderExtensions.UseHttpLogging%2A>, which adds HTTP logging middleware.

[!code-csharp[](samples/6.x/Program.cs?name=snippet2&highlight=5)]

By default, HTTP Logging logs common properties such as path, status-code, and headers for requests and responses. Add the following line to the `appsettings.Development.json` file at the `"LogLevel": {` level so the HTTP logs are displayed:

```xml
 "Microsoft.AspNetCore.HttpLogging.HttpLoggingMiddleware": "Information"
 ```

The output is logged as a single message at `LogLevel.Information`.

![Sample request output](_static/requestlog.png)

## HTTP Logging options

To configure the HTTP logging middleware, call <xref:Microsoft.Extensions.DependencyInjection.HttpLoggingServicesExtensions.AddHttpLogging%2A> in `Program.cs`.

[!code-csharp[](samples/6.x/Program.cs?name=snippet_Addservices)]

### `LoggingFields`

[`HttpLoggingOptions.LoggingFields`](xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions.LoggingFields) is an enum flag that configures specific parts of the request and response to log. ``HttpLoggingOptions.LoggingFields`` defaults to <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestPropertiesAndHeaders> | <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponsePropertiesAndHeaders>.

### `RequestHeaders`

<xref:Microsoft.AspNetCore.Http.HttpRequest.Headers> are a set of HTTP Request Headers that are allowed to be logged. Header values are only logged for header names that are in this collection. The following code logs the request header `"sec-ch-ua"`. If `logging.RequestHeaders.Add("sec-ch-ua");` is removed, the value of rhe request header `"sec-ch-ua"` is redacted. The following highlighted code calls [`HttpLoggingOptions.RequestHeaders`](xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions.RequestHeaders) and [`HttpLoggingOptions.ResponseHeaders`](xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions.ResponseHeaders) :

[!code-csharp[](samples/6.x/Program.cs?name=snippet_Addservices&highlight=8,9)]

### `MediaTypeOptions`

<xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions.MediaTypeOptions> provides configuration for selecting which encoding to use for a specific media type.

[!code-csharp[](samples/6.x/Program.cs?name=snippet_Addservices&highlight=10)]

#### `MediaTypeOptions` methods

* <xref:Microsoft.AspNetCore.HttpLogging.MediaTypeOptions.AddText%2A>
* <xref:Microsoft.AspNetCore.HttpLogging.MediaTypeOptions.AddBinary%2A>
* <xref:Microsoft.AspNetCore.HttpLogging.MediaTypeOptions.Clear%2A>

### `RequestBodyLogLimit` and `ResponseBodyLogLimit`

* <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions.RequestBodyLogLimit>
* <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions.ResponseBodyLogLimit>

[!code-csharp[](samples/6.x/Program.cs?name=snippet_Addservices&highlight=11-12)]

:::moniker-end
