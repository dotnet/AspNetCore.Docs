---
title: "Breaking change: HTTP: HttpClient instances created by IHttpClientFactory log integer status codes"
description: "Learn about the breaking change in ASP.NET Core 5.0 titled HTTP: HttpClient instances created by IHttpClientFactory log integer status codes"
ms.author: scaddie
ms.date: 10/01/2020
ms.custom: https://github.com/aspnet/Announcements/issues/396
---
# HTTP: HttpClient instances created by IHttpClientFactory log integer status codes

<xref:System.Net.Http.HttpClient> instances created by <xref:System.Net.Http.IHttpClientFactory> log HTTP status codes as integers instead of with status code names.

## Version introduced

5.0 Preview 1

## Old behavior

Logging uses the textual descriptions of HTTP status codes. Consider the following log messages:

```output
Received HTTP response after 56.0044ms - OK
End processing HTTP request after 70.0862ms - OK
```

## New behavior

Logging uses the integer values of HTTP status codes. Consider the following log messages:

```output
Received HTTP response after 56.0044ms - 200
End processing HTTP request after 70.0862ms - 200
```

## Reason for change

The original behavior of this logging is inconsistent with other parts of ASP.NET Core that have always used integer values. The inconsistency makes logs difficult to query via structured logging systems such as [Elasticsearch](https://www.elastic.co/elasticsearch/). For more context, see [dotnet/extensions#1549](https://github.com/dotnet/extensions/issues/1549).

Using integer values is more flexible than text because it allows queries on ranges of values.

Adding another log value to capture the integer status code was considered. Unfortunately, doing so would introduce another inconsistency with the rest of ASP.NET Core. HttpClient logging and HTTP server/hosting logging use the same `StatusCode` key name already.

## Recommended action

The best option is to update logging queries to use the integer values of status codes. This option may cause some difficulty writing queries across multiple ASP.NET Core versions. However, using integers for this purpose is much more flexible for querying logs.

If you need to force compatibility with the old behavior and use textual status codes, replace the `IHttpClientFactory` logging with your own:

1. Copy the .NET Core 3.1 versions of the following classes into your project:

    * [LoggingHttpMessageHandlerBuilderFilter](https://github.com/dotnet/extensions/blob/release/3.1/src/HttpClientFactory/Http/src/Logging/LoggingHttpMessageHandlerBuilderFilter.cs)
    * [LoggingHttpMessageHandler](https://github.com/dotnet/extensions/blob/release/3.1/src/HttpClientFactory/Http/src/Logging/LoggingHttpMessageHandler.cs)
    * [LoggingScopeHttpMessageHandler](https://github.com/dotnet/extensions/blob/release/3.1/src/HttpClientFactory/Http/src/Logging/LoggingScopeHttpMessageHandler.cs)
    * [HttpHeadersLogValue](https://github.com/dotnet/extensions/blob/release/3.1/src/HttpClientFactory/Http/src/Logging/HttpHeadersLogValue.cs)

1. Rename the classes to avoid conflicts with public types in the [Microsoft.Extensions.Http](https://www.nuget.org/packages/Microsoft.Extensions.Http) NuGet package.

1. Replace the built-in implementation of `LoggingHttpMessageHandlerBuilderFilter` with your own in the project's `Startup.ConfigureServices` method. For example:

    ```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        // Other service registrations go first. Code omitted for brevity.

        // Place the following after all AddHttpClient registrations.
        services.RemoveAll<IHttpMessageHandlerBuilderFilter>();

        services.AddSingleton<IHttpMessageHandlerBuilderFilter,
                              MyLoggingHttpMessageHandlerBuilderFilter>();
    }
    ```

## Affected APIs

<xref:System.Net.Http.HttpClient?displayProperty=nameWithType>

<!--

### Category

ASP.NET Core

### Affected APIs

`T:System.Net.Http.HttpClient`

-->
