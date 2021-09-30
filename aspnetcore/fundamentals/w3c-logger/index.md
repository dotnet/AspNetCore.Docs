---
title: W3CLogger in .NET Core and ASP.NET Core
author: wtgodbe
description: Learn how to create server logs in the W3C standard format.
monikerRange: '>= aspnetcore-6.0'
ms.author: wigodbe
ms.date: 09/29/2021
no-loc: [Home, Privacy, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
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
> W3CLogger can potentially log personally identifiable information (PII). Consider the risk and avoid logging sensitive information. By default, fields that could contain PII are not logged.

## Enabling W3CLogger

W3CLogger is enabled with `UseW3CLogging`, which adds the W3CLogger middleware.

[!code-csharp[](samples/6.x/Startup.cs?name=snippet&highlight=3)]

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

To configure the W3CLogger middleware, call `AddW3CLogging` in `ConfigureServices`.

[!code-csharp[](samples/6.x/Startup.cs?name=configureservices)]

### `LoggingFields`

`W3CLoggerOptions.LoggingFields` is a bit flag enumeration that configures specific parts of the request and response to log, and other information about the connection. `LoggingFields` defaults to include all possible fields except `UserName` and `Cookie`. 

[!code-csharp[](samples/6.x/Startup.cs?name=configureservices&highlight=6)]

| Flag | Description | Value |
| ---- | ----------- | :---: |
| None | No logging. | 0x0 |
| `Date` | The date that the activity occurred. | 0x1 |
| `Time` |  The time that the activity occurred. | 0x2 |
| `ClientIpAddress` |  The IP address of the client that accessed the server. | 0x4 |
| `UserName` |  The name of the authenticated user that accessed the server. | 0x8 |
| `ServerName` |  The name of the server on which the log entry was generated. | 0x10 |
| `ServerIpAddress` |  The IP address of the server on which the log entry was generated. | 0x20 |
| `ServerPort` |  The port number the client is connected to. | 0x40 |
| `Method` |  Request <xref:Microsoft.AspNetCore.Http.HttpRequest.Method>. | 0x80 |
| `UriStem` |  Request Path, which includes both the <xref:Microsoft.AspNetCore.Http.HttpRequest.Path> and <xref:Microsoft.AspNetCore.Http.HttpRequest.PathBase>. | 0x100 |
| `UriQuery` |  Request <xref:Microsoft.AspNetCore.Http.HttpRequest.QueryString>. | 0x200 |
| `ProtocolStatus` |  Response <xref:Microsoft.AspNetCore.Http.HttpResponse.StatusCode>. | 0x400 |
| `TimeTaken` |  The duration of time, in milliseconds, that the action consumed. | 0x800 |
| `ProtocolVersion` |  Request <xref:Microsoft.AspNetCore.Http.HttpRequest.Protocol>. | 0x1000 |
| `Host` |  Request <xref:Microsoft.AspNetCore.Http.Headers.HeaderNames.Host>. | 0x2000 |
| `UserAgent` |  Request <xref:Microsoft.AspNetCore.Http.Headers.HeaderNames.UserAgent>. | 0x4000 |
| `Cookie` |  Request <xref:Microsoft.AspNetCore.Http.Headers.HeaderNames.Cookie>. | 0x8000 |
| `Referer` |  Request <xref:Microsoft.AspNetCore.Http.Headers.HeaderNames.Referer>. | 0x10000 |
| `ConnectionInfoFields` | Flag for logging a collection of properties, about the HTTP Connection, including `ClientIpAddress`, `ServerIpAddress`, and `ServerPort`. | `ClientIpAddress | ServerIpAddress | ServerPort` |
| `RequestHeaders` | Flag for logging a collection of request headers, including `Host`, `Referer`, and `UserAgent`. | `Host | Referer | UserAgent` |
| `Request` | Flag for logging a collection of properties about the request, including `UriStem`, `UriQuery`, `ProtocolVersion`, `Method`, and `RequestHeaders`. | `UriStem | UriQuery | ProtocolVersion | Method | RequestHeaders` |
| `All` | Flag for logging all possible fields. | `Date | Time | ServerName | Method | UriStem | UriQuery | ProtocolStatus | TimeTaken | ProtocolVersion | Host | UserAgent | Referer | ConnectionInfoFields | UserName | Cookie` |

### `FileSizeLimit`

Maximum log file size in bytes. Defaults to 10 MiB.

[!code-csharp[](samples/6.x/Startup.cs?name=configureservices&highlight=8)]

### `RetainedFileCountLimit`

Maximum number of files to keep on disk before rolling, per application. Defaults to 4, capped at 10,000.

[!code-csharp[](samples/6.x/Startup.cs?name=configureservices&highlight=9)]

### `FileName`

Prefix to be used for log file name. The current date plus a file number, in the format `{YYYYMMDD.X}`, will be appended.

[!code-csharp[](samples/6.x/Startup.cs?name=configureservices&highlight=10)]

### `LogDirectory`

Directory where the log file will be written to. Defaults to `./logs/`, relative to the app directory.

[!code-csharp[](samples/6.x/Startup.cs?name=configureservices&highlight=11)]

### `FlushInterval`

The period after which logs will be flushed to the log file. Defaults to 1 second.

[!code-csharp[](samples/6.x/Startup.cs?name=configureservices&highlight=12)]
