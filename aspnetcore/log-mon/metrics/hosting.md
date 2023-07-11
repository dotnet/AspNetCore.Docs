---
title: ASP.NET Core built-in metrics
description: Hosting metrics for ASP.NET Core apps
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-8.0'
ms.date: 7/11/2023
ms.topic: article
ms.prod: aspnet-core
uid: log-mon/metrics/built-in
---

# ASP.NET Core built-in metrics

This article describes the built-in [metrics](xref:log-mon/metrics/metrics) emitted by ASP.NET Core hosting components.

The HTTP counters and tags follow OTel's lead: https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/metrics/semantic_conventions/http-metrics.md#http-server

## Microsoft.AspNetCore.Hosting

The HTTP counters and tags here follow [OpenTelemetry's semantic conventions](https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/metrics/semantic_conventions/http-metrics.md#http-server).

The ASP.NET Core `Microsoft.AspNetCore.Hosting` metrics [source code](https://github.com/dotnet/aspnetcore/blob/main/src/Hosting/Hosting/src/Internal/HostingMetrics.cs) on GitHub.

### `http-server-current-requests`

| Name     | Instrument Type | Unit | Description    |
| -------- | --------------- | ----------- | -------------- |
| `http-server-current-requests` | UpDownCounter | `{request}` | Number of HTTP requests that are currently active on the server. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `method` | string | HTTP request method. | `GET`; `POST`; `HEAD` | Always |
| `scheme` | string | The URI scheme identifying the used protocol. | `http`; `https` | Always |
| `host` | string | Name of the local HTTP server that received the request. | `localhost` | Always |
| `port` | int | Port of the local HTTP server that received the request. | `8080` | Added if not default (80 for http or 443 for https) |

#### `http-server-request-duration`

| Name     | Instrument Type | Unit | Description    |
| -------- | --------------- | ----------- | -------------- |
| `http-server-request-duration` | Histogram | `s` | The duration of HTTP requests on the server. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `scheme` | string | The URI scheme identifying the used protocol. | `http`; `https` | Always |
| `method` | string | HTTP request method. | `GET`; `POST`; `HEAD` | Always |
| `status-code` | int | [HTTP response status code](https://tools.ietf.org/html/rfc7231#section-6). | `200` | Always |
| `protocol` | string | HTTP request protocol. | `HTTP/1.1`; `HTTP/2`; `HTTP/3` | Always |
| `host` | string | Name of the local HTTP server that received the request. | `localhost` | Always |
| `port` | int | Port of the local HTTP server that received the request. | `8080` | Added if not default (80 for http or 443 for https) |
| `route` | string | The matched route | `{controller}/{action}/{id?}` | Added if route endpoint set |
| `exception-name` | string | Name of the .NET exception thrown during the request. Report exception is either unhandled from middleware or handled by `ExceptionHandlerMiddleware` or `DeveloperExceptionPageMiddleware`. | `System.OperationCanceledException` | If unhandled exception |
| Custom tags | n/a | Custom tags added from `IHttpMetricsTagsFeature`. | `organization`=`contoso` | n/a |

## Additional resources

* 
