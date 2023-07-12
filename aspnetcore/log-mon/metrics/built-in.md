---
title: ASP.NET Core built-in metrics
description: Hosting metrics for ASP.NET Core apps
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-8.0'
ms.date: 7/13/2023
ms.topic: article
ms.prod: aspnet-core
uid: log-mon/metrics/built-in
---

# ASP.NET Core built-in metrics

This article describes the built-in [metrics](xref:log-mon/metrics/metrics) emitted by ASP.NET Core hosting components.

## Microsoft.AspNetCore.Hosting

The HTTP counters and tags follow [OpenTelemetry's semantic conventions](https://github.com/open-telemetry/semantic-conventions/blob/main/docs/http/http-metrics.md#http-server).

[`Microsoft.AspNetCore.Hosting` metrics source code](https://github.com/dotnet/aspnetcore/blob/main/src/Hosting/Hosting/src/Internal/HostingMetrics.cs).

### Metric: `http-server-current-requests`

| Name     | Instrument Type | Unit | Description    |
| -------- | --------------- | ----------- | -------------- |
| `http-server-current-requests` | UpDownCounter | `{request}` | Number of HTTP requests that are currently active on the server. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `method` | string | HTTP request method. | `GET`; `POST`; `HEAD` | Always |
| `scheme` | string | The URI scheme identifying the used protocol. | `http`; `https` | Always |
| `host` | string | Name of the local HTTP server that received the request. | `localhost` | Always |
| `port` | int | Port of the local HTTP server that received the request. | `8080` | Added if not default (80 for HTTP or 443 for HTTPS) |

### Metric: `http-server-request-duration`

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
| `port` | int | Port of the local HTTP server that received the request. | `8080` | Added if not default (80 for HTTP or 443 for HTTPS) |
| `route` | string | The matched route | `{controller}/{action}/{id?}` | Added if route endpoint set |
| `exception-name` | string | Name of the .NET exception thrown during the request. Report exception is either unhandled from middleware or handled by [`ExceptionHandlerMiddleware`](/dotnet/api/microsoft.aspnetcore.diagnostics.exceptionhandlermiddleware) or [`DeveloperExceptionPageMiddleware`](/dotnet/api/microsoft.aspnetcore.diagnostics.developerexceptionpagemiddleware). | <xref:System.OperationCanceledException> | If unhandled exception |
| Custom tags | n/a | Custom tags added from <xref:Microsoft.AspNetCore.Http.Features.IHttpMetricsTagsFeature>. | `organization`=`contoso` | n/a |

### Metric: `http-server-unhandled-requests`

| Name     | Instrument Type | Unit | Description    |
| -------- | --------------- | ----------- | -------------- |
| `http-server-unhandled-requests` | Counter | `{count}` | Number of HTTP requests that reached the end of the middleware pipeline without being handled by application code. |

## Microsoft.AspNetCore.Server.Kestrel

All Kestrel counters include the endpoint as a tag.

[`Microsoft.AspNetCore.Server.Kestrel` metrics source code](https://github.com/dotnet/aspnetcore/blob/main/src/Servers/Kestrel/Core/src/Internal/Infrastructure/KestrelMetrics.cs).

### Metric: `kestrel-current-connections`

| Name     | Instrument Type | Unit | Description    |
| -------- | --------------- | ----------- | -------------- |
| `kestrel-current-connections` | UpDownCounter | `{connection}` | Number of connections that are currently active on the server. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `endpoint` | string | Name of the local endpoint that received the connection. | `localhost:8080` | Always |

### Metric: `kestrel-connection-duration`

| Name     | Instrument Type | Unit | Description    |
| -------- | --------------- | ----------- | -------------- |
| `kestrel-connection-duration` | Histogram | `s` | The duration of connections on the server. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `endpoint` | string | Name of the local endpoint that received the connection. | `localhost:8080` | Always |
| `exception-name` | string | Name of the .NET exception thrown during the connect. Report exception is unhandled | If unhandled exception |
| Custom tags | n/a | Custom tags added from `IConnectionMetricsTagsFeature`. | `organization`=`contoso` | n/a |

### Metric: `kestrel-rejected-connections`

| Name     | Instrument Type | Unit | Description    |
| -------- | --------------- | ----------- | -------------- |
| `kestrel-rejected-connections` | Counter | `{connection}` | Number of connections rejected by the server. Connections are rejected when the currently active count exceeds the value configured with MaxConcurrentConnections. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `endpoint` | string | Name of the local endpoint that received the connection. | `localhost:8080` | Always |

### Metric: `kestrel-queued-connections`

| Name     | Instrument Type | Unit | Description    |
| -------- | --------------- | ----------- | -------------- |
| `kestrel-queued-connections` | UpDownCounter | `{connection}` | Number of connections that are currently queued and are waiting to start. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `endpoint` | string | Name of the local endpoint that received the connection. | `localhost:8080` | Always |

### Metric: `kestrel-queued-requests`

| Name     | Instrument Type | Unit | Description    |
| -------- | --------------- | ----------- | -------------- |
| `kestrel-queued-requests` | UpDownCounter | `{request}` | Number of HTTP requests on multiplexed connections (HTTP/2 and HTTP/3) that are currently queued and are waiting to start. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `endpoint` | string | Name of the local endpoint that received the connection. | `localhost:8080` | Always |

### Metric: `kestrel-current-upgraded-connections`

| Name     | Instrument Type | Unit | Description    |
| -------- | --------------- | ----------- | -------------- |
| `kestrel-current-upgraded-connections` | UpDownCounter | `{request}` | Number of HTTP connections that are currently upgraded (WebSockets). The number only tracks HTTP/1.1 connections. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `endpoint` | string | Name of the local endpoint that received the connection. | `localhost:8080` | Always |

### Metric: `kestrel-tls-handshake-duration`

| Name     | Instrument Type | Unit | Description    |
| -------- | --------------- | ----------- | -------------- |
| `kestrel-tls-handshake-duration` | Histogram | `{s}` | The duration of TLS handshakes on the server. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `endpoint` | string | Name of the local endpoint that received the connection. | `localhost:8080` | Always |
| `protocol` | string | Security protocol used to authenticate the connection. | `Tls10`; `Tls11`; `Tls12`; `Tls13` | Always |
| `exception-name` | string | Name of the .NET exception thrown on TLS handshake failure. | `System.OperationCanceledException` | If TLS handshake fails |

### Metric: `kestrel-current-tls-handshakes`

| Name     | Instrument Type | Unit | Description    |
| -------- | --------------- | ----------- | -------------- |
| `kestrel-current-tls-handshakes` | UpDownCounter | `{handshake}` | Number of TLS handshakes that are currently in progress on the server. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `endpoint` | string | Name of the local endpoint that received the connection. | `localhost:8080` | Always |

## SignalR Microsoft.AspNetCore.Http.Connections

[Microsoft.AspNetCore.Http.Connections metrics source code](https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/common/Http.Connections/src/Internal/HttpConnectionsMetrics.cs).

### Metric: `signalr-http-transport-current-connections`

| Name     | Instrument Type | Unit | Description    |
| -------- | --------------- | ----------- | -------------- |
| `signalr-http-transport-current-connections` | UpDownCounter | `{connection}` | Number of connections that are currently active on the server. |

<!--
**Update: REMOVED**
### Metric: `signalr-http-transport-current-transports`

| Name     | Instrument Type | Unit | Description    |
| -------- | --------------- | ----------- | -------------- |
| `signalr-http-transport-current-transports` | UpDownCounter | `{transport}` | Number of connection transports that are currently active on the server. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `transport` | string | The connection transport | `None`; `WebSockets`; `ServerSentEvents`; `LongPolling` | Always |
-->

### Metric: `signalr-http-transport-connection-duration`

| Name     | Instrument Type | Unit | Description    |
| -------- | --------------- | ----------- | -------------- |
| `signalr-http-transport-connection-duration` | Histogram | `s` | The duration of connections on the server. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `status` | string | The connection end status | `NormalClosure`; `Timeout`; `AppShutdown` | Always |
| `transport` | string | The connection transport | `None`; `WebSockets`; `ServerSentEvents`; `LongPolling` | Always |

## Microsoft.AspNetCore.Routing

[Microsoft.AspNetCore.Routing source code](https://github.com/dotnet/aspnetcore/blob/main/src/Http/Routing/src/RoutingMetrics.cs).

### Metric: `routing-match-success`

| Name     | Instrument Type | Unit | Description    |
| -------- | --------------- | ----------- | -------------- |
| `routing-match-success` | Counter | `{count}` | Number of requests successfully matched to an endpoint by routing. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `route` | string | The matched route | `{controller}/{action}/{id?}` | Required |
| `fallback` | bool | A flag indicating whether the matched route is a fallback route | `true` | Required |

### Metric: `routing-match-failure`

| Name     | Instrument Type | Unit | Description    |
| -------- | --------------- | ----------- | -------------- |
| `routing-match-failure` | Counter | `{count}` | Number of requests that failed to match to an endpoint by routing. |

## Microsoft.AspNetCore.Diagnostic

[Microsoft.AspNetCore.Diagnostic source code](https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/Diagnostics/src/DiagnosticsMetrics.cs)

### Metric: `diagnostics-handler-exception`

| Name     | Instrument Type | Unit | Description    |
| -------- | --------------- | ----------- | -------------- |
| `diagnostics-handler-exception` | Counter | `{count}` | Number of request exceptions caught by exception handling middleware. |

| Attribute  | Type | Description  | Examples  | Presence |
|---|---|---|---|---|
| `exception-name` | string | Name of the .NET exception thrown during the request. | Required |
| `result` | string | The result of exception handler. | Skipped, Handled, Unhandled, Aborted | Required |
| `handler` | string | The name of the .NET type that handled the exception. | MyNamespace.MyCustomExceptionHandler | Present if exception handled by `IExceptionHandler` or `IProblemDetailsService`. |
