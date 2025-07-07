---
title: ASP.NET Core built-in metrics
description: Learn about built-in metrics for ASP.NET Core apps.
author: guardrex
ms.author: wpickett
ms.date: 7/7/2025
ms.topic: reference
uid: log-mon/metrics/built-in
---
# ASP.NET Core built-in metrics

This article describes the built-in metrics for ASP.NET Core produced using the
<xref:System.Diagnostics.Metrics?displayProperty=nameWithType> API. For a listing of metrics based on the older [EventCounters](/dotnet/core/diagnostics/event-counters) API, see [Available counters](/dotnet/core/diagnostics/available-counters).

For information on how to collect, report, enrich, and test with ASP.NET Core metrics, see <xref:log-mon/metrics/metrics>.

:::moniker range=">= aspnetcore-10.0"

## `Microsoft.AspNetCore.Components`

The `Microsoft.AspNetCore.Components` metrics report information on Razor component route changes and browser events:

* [`aspnetcore.components.navigation`](#metric-aspnetcorecomponentsnavigation)
* [`aspnetcore.components.event_handler`](#metric-aspnetcorecomponentsevent_handler)

### Metric: `aspnetcore.components.navigation`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.components.navigation`<!--](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-http-metrics/#metric-aspnetcorecomponentsnavigation)--> | Counter | `{route}` | Tracks the total number of route changes in the app.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.components.type` | string | Component navigated to. | `TestComponent` | Always
`aspnetcore.components.route` | string | The component's route. | `/test-route` | Always
`error.type` | string | The full name of exception type. | `System.InvalidOperationException`; `Contoso.MyException` | If an exception is thrown.

Usage: How many different Blazor pages users visited?

### Metric: `aspnetcore.components.event_handler`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.components.event_handler`<!--](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-http-metrics/#metric-aspnetcorecomponentsevent_handler)--> | Histogram | `s` | Measures the duration of processing browser events, including business logic of the component but not affected child components.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.components.type` | string | Component type handling the event. | `TestComponent` | Always
`aspnetcore.components.method` | string | C# method handling the event. | `OnClick` | Always
`aspnetcore.components.attribute.name` | string | Component attribute name handling the event. | `onclick` | Always
`error.type` | string | The full name of exception type. | `System.InvalidOperationException`; `Contoso.MyException` | If an exception is thrown.

Usage:

* Click to which component is slow?
* Which buttons are selected often?

## `Microsoft.AspNetCore.Components.Lifecycle`

The `Microsoft.AspNetCore.Components.Lifecycle` metrics report information on Razor component lifecycle events:

* [`aspnetcore.components.update_parameters`](#metric-aspnetcorecomponentsupdate_parameters)
* [`aspnetcore.components.render_diff`](#metric-aspnetcorecomponentsrender_diff)

### Metric: `aspnetcore.components.update_parameters`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.components.update_parameters`<!--](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-http-metrics/#metric-aspnetcorecomponentsupdate_parameters)--> | Histogram | `s` | Measures the duration of processing component parameters, including business logic.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.components.type` | string | Component type handling the event. | `TestComponent` | Always
`error.type` | string | The full name of exception type. | `System.InvalidOperationException`; `Contoso.MyException` | If an exception is thrown.

Usage:

* Which components are slow to update?
* Which components are updated often?

### Metric: `aspnetcore.components.render_diff`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.components.render_diff`<!--](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-http-metrics/#metric-aspnetcorecomponentsrender_diff)--> | Histogram | `s` | Tracks the duration of rendering batches.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.components.diff.length` | int | The length of the render diff/size of the batch (bucketed). | 50 | Always
`error.type` | string | The full name of exception type. | `System.InvalidOperationException`; `Contoso.MyException` | If an exception is thrown.

Usage:

* Is server rendering slow?
* Do I render diffs that are too large? (network bandwidth, DOM update)

## `Microsoft.AspNetCore.Components.Server.Circuits`

The `Microsoft.AspNetCore.Components.Server.Circuits` metrics report information on server-side Blazor circuits in Blazor Server and Blazor Web Apps:

* [`aspnetcore.components.circuit.active`](#metric-aspnetcorecomponentscircuitactive)
* [`aspnetcore.components.circuit.connected`](#metric-aspnetcorecomponentscircuitconnected)
* [`aspnetcore.components.circuit.duration`](#metric-aspnetcorecomponentscircuitduration)

### Metric: `aspnetcore.components.circuit.active`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.components.circuit.active`<!--](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-http-metrics/#metric-aspnetcorecomponentscircuitactive)--> | UpDownCounter | `{circuit}` | Shows the number of active circuits currently in memory.

Usage: How much memory does the session state hold?

### Metric: `aspnetcore.components.circuit.connected`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.components.circuit.connected`<!--](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-http-metrics/#metric-aspnetcorecomponentscircuitconnected)--> | UpDownCounter | `{circuit}` | Tracks the number of circuits connected to clients.

Usage: How many SignalR connections are open?

### Metric: `aspnetcore.components.circuit.duration`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.components.circuit.duration`<!--](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-http-metrics/#metric-aspnetcorecomponentscircuitduration)--> | Histogram | `s` | Measures circuit lifetime duration and provides total circuit count.

Usage:

* How many sessions processed?
* How long do users keep the session/tab open?

## `Microsoft.AspNetCore.Hosting`

The `Microsoft.AspNetCore.Hosting` metrics report high-level information about HTTP requests received by ASP.NET Core:

* [`http.server.request.duration`](#metric-httpserverrequestduration)
* [`http.server.active_requests`](#metric-httpserveractive_requests)

:::moniker-end

### Metric: `http.server.request.duration`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
[`http.server.request.duration`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-http-metrics/#metric-httpclientrequestduration) | Histogram | `s` | Measures the duration of inbound HTTP requests.

Attribute | Type | Description | Examples | Presence
--- |--- | --- | --- | ---
`http.route` | string | The matched route. | `{controller}/{action}/`<br>`{id?}`| If it's available.
`error.type` | string | Describes a class of error the operation ended with. | `timeout`; `name_resolution_error`; `500` | If request has ended with an error.
`http.request.method` | string | HTTP request method. | `GET`; `POST`; `HEAD` | Always
`http.response.status_code` | int | [HTTP response status code](https://tools.ietf.org/html/rfc7231#section-6). | `200` | If one was sent.
`network.protocol.version` | string | Version of the protocol specified in `network.protocol.name`. | `3.1.1` | Always
`url.scheme` | string | The [URI scheme](https://www.rfc-editor.org/rfc/rfc3986#section-3.1) component identifying the used protocol. | `http`; `https` | Always
`aspnetcore.request.is_unhandled` | Boolean | True when the request wasn't handled by the application pipeline. | `true` | If the request was unhandled.

The time used to handle an inbound HTTP request as measured at the hosting layer of ASP.NET Core. The time measurement starts once the underlying web host has:

* Sufficiently parsed the HTTP request headers on the inbound network stream to identify the new request.
* Initialized the context data structures such as the <xref:Microsoft.AspNetCore.Http.HttpContext>.

The time ends when:

* The ASP.NET Core handler pipeline is finished executing.
* All response data has been sent.
* The context data structures for the request are being disposed.

When using OpenTelemetry, the default buckets for this metric are set to [ 0.005, 0.01, 0.025, 0.05, 0.075, 0.1, 0.25, 0.5, 0.75, 1, 2.5, 5, 7.5, 10 ].

### Metric: `http.server.active_requests`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
[`http.server.active_requests`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-http-metrics/#metric-httpclientactive_requests) | UpDownCounter | `{request}` | Measures the number of concurrent HTTP requests that are currently in-flight.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`http.request.method` | string | HTTP request method. [1] | `GET`; `POST`; `HEAD` | Always
`url.scheme`| string | The [URI scheme](https://www.rfc-editor.org/rfc/rfc3986#section-3.1) component identifying the used protocol. | `http`; `https` | Always

## `Microsoft.AspNetCore.Routing`

The `Microsoft.AspNetCore.Routing` metrics report information about [routing HTTP requests](/aspnet/core/fundamentals/routing) to ASP.NET Core endpoints:

* [`aspnetcore.routing.match_attempts`](#metric-aspnetcoreroutingmatch_attempts)

### Metric: `aspnetcore.routing.match_attempts`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
[`aspnetcore.routing.match_attempts`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-aspnetcore-metrics/#metric-aspnetcoreroutingmatch_attempts) | Counter | `{match_attempt}` | Number of requests that were attempted to be matched to an endpoint.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.routing.match_status` | string | Match result | `success`; `failure` | Always
`aspnetcore.routing.is_fallback_route` | boolean | A value that indicates whether the matched route is a fallback route. | `True` | If a route was successfully matched.
`http.route` | string | The matched route | `{controller}/{action}/`<br>`{id?}` | If a route was successfully matched.

## `Microsoft.AspNetCore.Diagnostics`

The `Microsoft.AspNetCore.Diagnostics` metrics report diagnostics information from [ASP.NET Core error handling middleware](/aspnet/core/fundamentals/error-handling):

* [`aspnetcore.diagnostics.exceptions`](#metric-aspnetcorediagnosticsexceptions)

### Metric: `aspnetcore.diagnostics.exceptions`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
[`aspnetcore.diagnostics.exceptions`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-aspnetcore-metrics/#metric-aspnetcorediagnosticsexceptions) | Counter | `{exception}` | Number of exceptions caught by exception handling middleware.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.diagnostics.exception.result` | string | ASP.NET Core exception middleware handling result | `handled`; `unhandled` | Always
`aspnetcore.diagnostics.handler.type` | string | Full type name of the [`IExceptionHandler`](/dotnet/api/microsoft.aspnetcore.diagnostics.iexceptionhandler) implementation that handled the exception. | `Contoso.MyHandler` | If the exception was handled by this handler.
`exception.type` | string | The full name of exception type. | `System.OperationCanceledException`; `Contoso.MyException` | Always

## `Microsoft.AspNetCore.RateLimiting`

The `Microsoft.AspNetCore.RateLimiting` metrics report rate limiting information from [ASP.NET Core rate-limiting middleware](/aspnet/core/performance/rate-limit):

* [`aspnetcore.rate_limiting.active_request_leases`](#metric-aspnetcorerate_limitingactive_request_leases)
* [`aspnetcore.rate_limiting.request_lease.duration`](#metric-aspnetcorerate_limitingrequest_leaseduration)
* [`aspnetcore.rate_limiting.queued_requests`](#metric-aspnetcorerate_limitingqueued_requests)
* [`aspnetcore.rate_limiting.request.time_in_queue`](#metric-aspnetcorerate_limitingrequesttime_in_queue)
* [`aspnetcore.rate_limiting.requests`](#metric-aspnetcorerate_limitingrequests)

### Metric: `aspnetcore.rate_limiting.active_request_leases`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
| [`aspnetcore.rate_limiting.active_request_leases`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-aspnetcore-metrics/#metric-aspnetcorerate_limitingactive_request_leases) | UpDownCounter | `{request}` | Number of requests that are currently active on the server that hold a rate limiting lease. |

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.rate_limiting.policy` | string | Rate limiting policy name. | `fixed`; `sliding`; `token` | If the matched endpoint for the request had a rate-limiting policy.

### Metric: `aspnetcore.rate_limiting.request_lease.duration`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
[`aspnetcore.rate_limiting.request_lease.duration`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-aspnetcore-metrics/#metric-aspnetcorerate_limitingrequest_leaseduration) | Histogram | `s` | The duration of the rate limiting lease held by requests on the server.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.rate_limiting.policy` | string | Rate limiting policy name. | `fixed`; `sliding`; `token` | If the matched endpoint for the request had a rate-limiting policy.

### Metric: `aspnetcore.rate_limiting.queued_requests`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
[`aspnetcore.rate_limiting.queued_requests`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-aspnetcore-metrics/#metric-aspnetcorerate_limitingqueued_requests) | UpDownCounter | `{request}` | Number of requests that are currently queued waiting to acquire a rate limiting lease.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.rate_limiting.policy` | string | Rate limiting policy name. | `fixed`; `sliding`; `token` | If the matched endpoint for the request had a rate-limiting policy.

### Metric: `aspnetcore.rate_limiting.request.time_in_queue`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
[`aspnetcore.rate_limiting.request.time_in_queue`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-aspnetcore-metrics/#metric-aspnetcorerate_limitingrequesttime_in_queue) | Histogram | `s` | The time a request spent in a queue waiting to acquire a rate limiting lease.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.rate_limiting.policy` | string | Rate limiting policy name. | `fixed`; `sliding`; `token` | If the matched endpoint for the request had a rate-limiting policy.
`aspnetcore.rate_limiting.result` | string | The rate limiting result shows whether lease was acquired or contains a rejection reason. | `acquired`; `request_canceled` | Always

### Metric: `aspnetcore.rate_limiting.requests`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
[`aspnetcore.rate_limiting.requests`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-aspnetcore-metrics/#metric-aspnetcorerate_limitingrequests) | Counter | `{request}` | Number of requests that tried to acquire a rate limiting lease.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.rate_limiting.policy` | string | Rate limiting policy name. | `fixed`; `sliding`; `token` | If the matched endpoint for the request had a rate-limiting policy.
`aspnetcore.rate_limiting.result` | string | The rate limiting result shows whether lease was acquired or contains a rejection reason. | `acquired`; `request_canceled` | Always

## `Microsoft.AspNetCore.HeaderParsing`

The `Microsoft.AspNetCore.HeaderParsing` metrics report information about [ASP.NET Core header parsing](https://www.nuget.org/packages/Microsoft.AspNetCore.HeaderParsing):

* [`aspnetcore.header_parsing.parse_errors`](#metric-aspnetcoreheader_parsingparse_errors)
* [`aspnetcore.header_parsing.cache_accesses`](#metric-aspnetcoreheader_parsingcache_accesses)

### Metric: `aspnetcore.header_parsing.parse_errors`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.header_parsing.parse_errors` | Counter | `{parse_error}` | Number of errors that occurred when parsing HTTP request headers.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.header_parsing.header.name` | string | The header name. | `Content-Type` | Always
`error.type` | string | The error message. | `Unable to parse media type value.` | Always

### Metric: `aspnetcore.header_parsing.cache_accesses`

The metric is emitted only for HTTP request header parsers that support caching.

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.header_parsing.cache_accesses` | Counter | `{cache_access}` | Number of times a cache storing parsed header values was accessed.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.header_parsing.header.name` | string | The header name. | `Content-Type` | Always
`aspnetcore.header_parsing.cache_access.type` | string | A value indicating whether the header's value was found in the cache or not. | `Hit`; `Miss` | Always

## `Microsoft.AspNetCore.Server.Kestrel`

The `Microsoft.AspNetCore.Server.Kestrel` metrics report HTTP connection information from [ASP.NET Core Kestrel web server](/aspnet/core/fundamentals/servers/kestrel):

* [`kestrel.active_connections`](#metric-kestrelactive_connections)
* [`kestrel.connection.duration`](#metric-kestrelconnectionduration)
* [`kestrel.rejected_connections`](#metric-kestrelrejected_connections)
* [`kestrel.queued_connections`](#metric-kestrelqueued_connections)
* [`kestrel.queued_requests`](#metric-kestrelqueued_requests)
* [`kestrel.upgraded_connections`](#metric-kestrelupgraded_connections)
* [`kestrel.tls_handshake.duration`](#metric-kestreltls_handshakeduration)
* [`kestrel.active_tls_handshakes`](#metric-kestrelactive_tls_handshakes)

### Metric: `kestrel.active_connections`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
[`kestrel.active_connections`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-kestrel-metrics/#metric-kestrelactive_connections) | UpDownCounter | `{connection}` | Number of connections that are currently active on the server.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`network.transport` | string | [OSI transport layer](https://www.geeksforgeeks.org/transport-layer-in-osi-model/) or [inter-process communication method](https://en.wikipedia.org/wiki/Inter-process_communication). | `tcp`; `unix` | Always
`network.type`| string | [OSI network layer](https://www.geeksforgeeks.org/network-layer-in-osi-model/) or non-OSI equivalent. | `ipv4`; `ipv6` | If the transport is `tcp` or `udp`.
`server.address` | string | Server address domain name if available without reverse DNS lookup;  otherwise, IP address or Unix domain socket name. | `example.com` | Always
`server.port`| int | Server port number | `80`; `8080`; `443` | If the transport is `tcp` or `udp`.

### Metric: `kestrel.connection.duration`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
[`kestrel.connection.duration`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-kestrel-metrics/#metric-kestrelconnectionduration) | Histogram | `s` | The duration of connections on the server.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`error.type` | string | Describes a type of error the connection ended with, or the unhandled exception type thrown during the connection pipeline. Known connection errors can be found at [Semantic Conventions for Kestrel web server metrics](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-kestrel-metrics/). | `connection_reset`; `invalid_request_headers`; `System.OperationCanceledException` | If the connection ended with a known error or an exception was thrown.
`network.protocol.name` | string | [OSI application layer](https://www.geeksforgeeks.org/application-layer-in-osi-model/) or non-OSI equivalent. | `http`; `web_sockets` | Always
`network.protocol.version` | string | Version of the protocol specified in `network.protocol.name`. | `1.1`; `2` | Always
`network.transport` | string | [OSI transport layer](https://www.geeksforgeeks.org/transport-layer-in-osi-model/) or [inter-process communication method](https://en.wikipedia.org/wiki/Inter-process_communication). | `tcp`; `unix` | Always
`network.type` | string | [OSI network layer](https://www.geeksforgeeks.org/network-layer-in-osi-model/) or non-OSI equivalent. | `ipv4`; `ipv6` | If the transport is `tcp` or `udp`.
`server.address` | string | Server address domain name if available without reverse DNS lookup;  otherwise, IP address or Unix domain socket name. | `example.com` | Always
`server.port` | int | Server port number | `80`; `8080`; `443` | If the transport is `tcp` or `udp`.
`tls.protocol.version` | string | TLS protocol version. | `1.2`; `1.3` | If the connection is secured with TLS.

As this metric is tracking the connection duration, and ideally http connections are used for multiple requests, the buckets should be longer than those used for request durations. For example, using [ 0.01, 0.02, 0.05, 0.1, 0.2, 0.5, 1, 2, 5, 10, 30, 60, 120, 300] provides an upper bucket of 5 mins.

:::moniker range="= aspnetcore-9.0"

When a connection ends with a known error, the `error.type` attribute value is set to the known error type. Known connection errors can be found at [Semantic Conventions for Kestrel web server metrics](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-kestrel-metrics/).

:::moniker-end

### Metric: `kestrel.rejected_connections`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
[`kestrel.rejected_connections`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-kestrel-metrics/#metric-kestrelrejected_connections) | Counter | `{connection}` | Number of connections rejected by the server.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`network.transport`| string | [OSI transport layer](https://www.geeksforgeeks.org/transport-layer-in-osi-model/) or [inter-process communication method](https://en.wikipedia.org/wiki/Inter-process_communication). | `tcp`; `unix` | Always
`network.type` | string | [OSI network layer](https://www.geeksforgeeks.org/network-layer-in-osi-model/) or non-OSI equivalent. | `ipv4`; `ipv6` | If the transport is `tcp` or `udp`.
`server.address`| string | Server address domain name if available without reverse DNS lookup;  otherwise, IP address or Unix domain socket name. | `example.com` | Always
`server.port` | int | Server port number | `80`; `8080`; `443` | If the transport is `tcp` or `udp`.

Connections are rejected when the currently active count exceeds the value configured with `MaxConcurrentConnections`.

### Metric: `kestrel.queued_connections`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
[`kestrel.queued_connections`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-kestrel-metrics/#metric-kestrelqueued_connections) | UpDownCounter | `{connection}` | Number of connections that are currently queued and are waiting to start.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`network.transport` | string | [OSI transport layer](https://www.geeksforgeeks.org/transport-layer-in-osi-model/) or [inter-process communication method](https://en.wikipedia.org/wiki/Inter-process_communication). | `tcp`; `unix` | Always
`network.type` | string | [OSI network layer](https://www.geeksforgeeks.org/network-layer-in-osi-model/) or non-OSI equivalent. | `ipv4`; `ipv6` | If the transport is `tcp` or `udp`.
`server.address` | string | Server address domain name if available without reverse DNS lookup;  otherwise, IP address or Unix domain socket name. | `example.com` | Always
`server.port` | int | Server port number | `80`; `8080`; `443` | If the transport is `tcp` or `udp`.

### Metric: `kestrel.queued_requests`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
[`kestrel.queued_requests`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-kestrel-metrics/#metric-kestrelqueued_requests) | UpDownCounter | `{request}` | Number of HTTP requests on multiplexed connections (HTTP/2 and HTTP/3) that are currently queued and are waiting to start.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`network.protocol.name` | string | [OSI application layer](https://www.geeksforgeeks.org/application-layer-in-osi-model/) or non-OSI equivalent. | `http`; `web_sockets` | Always
`network.protocol.version` | string | Version of the protocol specified in `network.protocol.name`. | `1.1`; `2` | Always
`network.transport` | string | [OSI transport layer](https://www.geeksforgeeks.org/transport-layer-in-osi-model/) or [inter-process communication method](https://en.wikipedia.org/wiki/Inter-process_communication). | `tcp`; `unix` | Always
`network.type` | string | [OSI network layer](https://www.geeksforgeeks.org/network-layer-in-osi-model/) or non-OSI equivalent. | `ipv4`; `ipv6` | If the transport is `tcp` or `udp`.
`server.address` | string | Server address domain name if available without reverse DNS lookup;  otherwise, IP address or Unix domain socket name. | `example.com` | Always
`server.port` | int | Server port number | `80`; `8080`; `443` | If the transport is `tcp` or `udp`.

### Metric: `kestrel.upgraded_connections`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
[`kestrel.upgraded_connections`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-kestrel-metrics/#metric-kestrelupgraded_connections) | UpDownCounter | `{connection}` | Number of connections that are currently upgraded (WebSockets).

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`network.transport` | string | [OSI transport layer](https://www.geeksforgeeks.org/transport-layer-in-osi-model/) or [inter-process communication method](https://en.wikipedia.org/wiki/Inter-process_communication). | `tcp`; `unix` | Always
`network.type` | string | [OSI network layer](https://www.geeksforgeeks.org/network-layer-in-osi-model/) or non-OSI equivalent. | `ipv4`; `ipv6` | If the transport is `tcp` or `udp`.
`server.address` | string | Server address domain name if available without reverse DNS lookup;  otherwise, IP address or Unix domain socket name. | `example.com` | Always
`server.port` | int | Server port number | `80`; `8080`; `443` | If the transport is `tcp` or `udp`.

The counter only tracks HTTP/1.1 connections.

### Metric: `kestrel.tls_handshake.duration`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
[`kestrel.tls_handshake.duration`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-kestrel-metrics/#metric-kestreltls_handshakeduration) | Histogram | `s` | The duration of TLS handshakes on the server.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`error.type` | string | The full name of exception type. | `System.OperationCanceledException`; `Contoso.MyException` | If an exception was thrown.
`network.transport` | string | [OSI transport layer](https://www.geeksforgeeks.org/transport-layer-in-osi-model/) or [inter-process communication method](https://en.wikipedia.org/wiki/Inter-process_communication). | `tcp`; `unix` | Always
`network.type` | string | [OSI network layer](https://www.geeksforgeeks.org/network-layer-in-osi-model/) or non-OSI equivalent. | `ipv4`; `ipv6` | If the transport is `tcp` or `udp`.
`server.address` | string | Server address domain name if available without reverse DNS lookup;  otherwise, IP address or Unix domain socket name. | `example.com` | Always
`server.port` | int | Server port number | `80`; `8080`; `443` | If the transport is `tcp` or `udp`.
`tls.protocol.version` | string | TLS protocol version. | `1.2`; `1.3` | If the connection is secured with TLS.

When using OpenTelemetry, the default buckets for this metic are set to [ 0.005, 0.01, 0.025, 0.05, 0.075, 0.1, 0.25, 0.5, 0.75, 1, 2.5, 5, 7.5, 10 ].

### Metric: `kestrel.active_tls_handshakes`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
[`kestrel.active_tls_handshakes`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-kestrel-metrics/#metric-kestrelactive_tls_handshakes) | UpDownCounter | `{handshake}` | Number of TLS handshakes that are currently in progress on the server.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`network.transport` | string | [OSI transport layer](https://www.geeksforgeeks.org/transport-layer-in-osi-model/) or [inter-process communication method](https://en.wikipedia.org/wiki/Inter-process_communication). | `tcp`; `unix` | Always
`network.type` | string | [OSI network layer](https://www.geeksforgeeks.org/network-layer-in-osi-model/) or non-OSI equivalent. | `ipv4`; `ipv6` | If the transport is `tcp` or `udp`.
`server.address` | string | Server address domain name if available without reverse DNS lookup;  otherwise, IP address or Unix domain socket name. | `example.com` | Always
`server.port` | int | Server port number | `80`; `8080`; `443` | If the transport is `tcp` or `udp`.

## `Microsoft.AspNetCore.Http.Connections`

The `Microsoft.AspNetCore.Http.Connections` metrics report connection information from [ASP.NET Core SignalR](/aspnet/core/signalr/introduction):

* [`signalr.server.connection.duration`](#metric-signalrserverconnectionduration)
* [`signalr.server.active_connections`](#metric-signalrserveractive_connections)

### Metric: `signalr.server.connection.duration`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
[`signalr.server.connection.duration`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-signalr-metrics/#metric-signalrserverconnectionduration) | Histogram | `s` | The duration of connections on the server.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`signalr.connection.status` | string | SignalR HTTP connection closure status. | `app_shutdown`; `timeout` | Always
`signalr.transport` | string | [SignalR transport type](https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/docs/specs/TransportProtocols.md) | `web_sockets`; `long_polling` | Always

Value | Description
--- | ---
`normal_closure` | The connection was closed normally.
`timeout` | The connection was closed due to a timeout.
`app_shutdown` | The connection was closed because the app is shutting down.

`signalr.transport` is one of the following:

Value | Description
--- | ---
`server_sent_events` | [server-sent events](https://developer.mozilla.org/docs/Web/API/Server-sent_events/Using_server-sent_events) 
`long_polling` | [Long Polling](/archive/msdn-magazine/2012/april/cutting-edge-long-polling-and-signalr)
`web_sockets` | [WebSocket](https://datatracker.ietf.org/doc/html/rfc6455)

As this metric is tracking the connection duration, and ideally SignalR connections are durable, the buckets should be longer than those used for request durations. For example, using [0, 0.01, 0.02, 0.05, 0.1, 0.2, 0.5, 1, 2, 5, 10, 30, 60, 120, 300] provides an upper bucket of 5 mins.

### Metric: `signalr.server.active_connections`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
[`signalr.server.active_connections`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-signalr-metrics/#metric-signalrserveractive_connections) | UpDownCounter | `{connection}` | Number of connections that are currently active on the server.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`signalr.connection.status` | string | SignalR HTTP connection closure status. | `app_shutdown`; `timeout` | Always
`signalr.transport` | string | [SignalR transport type](https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/docs/specs/TransportProtocols.md) | `web_sockets`; `long_polling` | Always

:::moniker range=">= aspnetcore-10.0"

## `Microsoft.AspNetCore.Authorization`

The `Microsoft.AspNetCore.Authorization` metrics report information about [Authorization attempts](xref:security/authorization/introduction) in ASP.NET Core apps:

### Metric: `aspnetcore.authorization.attempts`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.authorization.attempts` | Counter | `{request}` | The total number of requests for which authorization was attempted.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`user.is_authenticated` | boolean | Whether the request came from an authenticated user | `true` | `Required`
`aspnetcore.authorization.policy` | string | The name of the authorization policy. | `AtLeast21`; `EmployeeOnly` | `Conditionally required` if an authorization policy is used.
`aspnetcore.authorization.result` | string | Whether the authorization succeeded or failed. | `success`; `failure` | `Conditionally Required` if an exception is not thrown during authorization.
`error.type` | string | The full name of the exception type. | `System.InvalidOperationException`; `Contoso.MyException` | `Conditionally Required` if the request has ended with an error.

## `Microsoft.AspNetCore.Authentication`

The `Microsoft.AspNetCore.Authentication` metrics report information about [Authentication](xref:security/authentication/index) in ASP.NET Core apps:

* [`aspnetcore.authentication.authenticate.duration`](#metric-aspnetcoreauthenticationauthenticateduration)
* [`aspnetcore.authentication.challenges`](#metric-aspnetcoreauthenticationchallenges)
* [`aspnetcore.authentication.forbids`](#metric-aspnetcoreauthenticationforbids)
* [`aspnetcore.authentication.sign_ins`](#metric-aspnetcoreauthenticationsign_ins)
* [`aspnetcore.authentication.sign_outs`](#metric-aspnetcoreauthenticationsign_outs)

### Metric: `aspnetcore.authentication.authenticate.duration`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.authentication.authenticate.duration` | Histogram | `s` | The authentication duration for a request.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.authentication.result` | string | The authentication result. | `success`; `failure`; `none`; `_OTHER` | `Conditionally Required` if the request did not end with an error.
`aspnetcore.authentication.scheme` | string | The name of the authentication scheme. | `Bearer`; `Cookies` | `Conditionally Required` if the request did not end with an error.
`error.type` | string | The full name of the exception type. | `System.InvalidOperationException`; `Contoso.MyException` | `Conditionally Required` if authentication failed or the request. has ended with an error.

### Metric: `aspnetcore.authentication.challenges`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.authentication.challenges` | Counter | `{request}` | The total number of times a scheme is challenged.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.authentication.scheme` | string | The name of the authentication scheme. | `Bearer`; `Cookies` | `Conditionally Required` if the request did not end with an error.
`error.type` | string | The full name of the exception type. | `System.InvalidOperationException`; `Contoso.MyException` | `Conditionally Required` if the request has ended with an error.

### Metric: `aspnetcore.authentication.forbids`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.authentication.forbids` | Counter | `{request}` | The total number of times an authenticated user attempts to access a resource they aren't permitted to access.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.authentication.scheme` | string | The name of the authentication scheme. | `Bearer`; `Cookies` | `Conditionally Required` if the request did not end with an error.
`error.type` | string | The full name of the exception type. | `System.InvalidOperationException`; `Contoso.MyException` | `Conditionally Required` if the request has ended with an error.

### Metric: `aspnetcore.authentication.sign_ins`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.authentication.sign_ins` | Counter | `{request}` | The total number of times a principal is signed in with a scheme.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.authentication.scheme` | string | The name of the authentication scheme. | `Bearer`; `Cookies` | `Conditionally Required` if the request did not end with an error.
`error.type` | string | The full name of the exception type. | `System.InvalidOperationException`; `Contoso.MyException` | `Conditionally Required` if the request has ended with an error.

### Metric: `aspnetcore.authentication.sign_outs`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.authentication.sign_outs` | Counter | `{request}` | The total number of times a principal is signed out with a scheme.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.authentication.scheme` | string | The name of the authentication scheme. | `Bearer`; `Cookies` | `Conditionally Required` if the request did not end with an error.
`error.type` | string | The full name of the exception type. | `System.InvalidOperationException`; `Contoso.MyException` | `Conditionally Required` if the request has ended with an error.

:::moniker-end
