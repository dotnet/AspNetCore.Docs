---
title: W3CLogger in .NET Core and ASP.NET Core
author: wtgodbe
description: Learn how to create server logs in the W3C standard format.
monikerRange: '>= aspnetcore-6.0'
ms.author: wigodbe
ms.date: 01/21/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: fundamentals/w3c-logger/index
---

# W3CLogger in ASP.NET Core

W3CLogger is a middleware that writes log files in the [W3C standard format](https://www.w3.org/TR/WD-logfile.html). The logs contain information about HTTP requests and HTTP responses. W3CLogger provides logs of:

* HTTP request information
* Common properties
* Headers
* HTTP response information
* Metadata about the request/response pair (date/time started, time taken)

W3CLogger is valuable in several scenarios to:

* Record information about incoming requests and responses.
* Filter which parts of the request and response are logged.
* Filter which headers to log.

W3CLogger ***can reduce the performance of an app***. Consider the performance impact when selecting fields to log - the performance reduction will increase as you log more properties. Test the performance impact of the selected logging properties.

> [!WARNING]
> W3CLogger can potentially log personally identifiable information (PII). Consider the risk and avoid logging sensitive information. By default, fields that could contain PII aren't logged.

## Enable W3CLogger

Enable W3CLogger with <xref:Microsoft.AspNetCore.Builder.HttpLoggingBuilderExtensions.UseW3CLogging%2A>, which adds the W3CLogger middleware:

:::code language="csharp" source="samples/6.x/Program.cs" id="snippet_UseW3CLogging" highlight="3":::

By default, W3CLogger logs common properties such as path, status-code, date, time, and protocol. All information about a single request/response pair is written to the same line.

```
#Version: 1.0
#Start-Date: 2021-09-29 22:18:28
#Fields: date time c-ip s-computername s-ip s-port cs-method cs-uri-stem cs-uri-query sc-status time-taken cs-version cs-host cs(User-Agent) cs(Referer)
2021-09-29 22:18:28 ::1 DESKTOP-LH3TLTA ::1 5000 GET / - 200 59.9171 HTTP/1.1 localhost:5000 Mozilla/5.0+(Windows+NT+10.0;+WOW64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/93.0.4577.82+Safari/537.36 -
2021-09-29 22:18:28 ::1 DESKTOP-LH3TLTA ::1 5000 GET / - 200 0.1802 HTTP/1.1 localhost:5000 Mozilla/5.0+(Windows+NT+10.0;+WOW64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/93.0.4577.82+Safari/537.36 -
2021-09-29 22:18:30 ::1 DESKTOP-LH3TLTA ::1 5000 GET / - 200 0.0966 HTTP/1.1 localhost:5000 Mozilla/5.0+(Windows+NT+10.0;+WOW64)+AppleWebKit/537.36+(KHTML,+like+Gecko)+Chrome/93.0.4577.82+Safari/537.36 -
```

## W3CLogger options

To configure the W3CLogger middleware, call <xref:Microsoft.Extensions.DependencyInjection.HttpLoggingServicesExtensions.AddW3CLogging%2A> in `Program.cs`:

:::code language="csharp" source="samples/6.x/Program.cs" id="snippet_AddW3CLogging" highlight="3":::

### `LoggingFields`

<xref:Microsoft.AspNetCore.HttpLogging.W3CLoggerOptions.LoggingFields%2A?displayProperty=nameWithType> is a bit flag enumeration that configures specific parts of the request and response to log, and other information about the connection. `LoggingFields` defaults to include all possible fields except `UserName` and `Cookie`. For a complete list of available fields, see <xref:Microsoft.AspNetCore.HttpLogging.W3CLoggingFields>.
