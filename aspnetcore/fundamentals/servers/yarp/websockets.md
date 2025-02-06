# Proxing WebSockets and SPDY

## Introduction

YARP enables proxying WebSocket and SPDY connections by default. This support works with both the [direct forwarding](direct-forwarding.md) and [full pipeline](getting-started.md) approaches.

[WebSockets](https://www.rfc-editor.org/rfc/rfc6455.html) is a bidirectional streaming protocol built on HTTP/1.1 and later adapted to [HTTP/2](https://datatracker.ietf.org/doc/html/rfc8441).

[SPDY](https://www.chromium.org/spdy/spdy-protocol/) is the precursor to HTTP/2 and is commonly used in Kubernetes environments.

## HTTP/1.1 Upgrades

WebSockets and SPDY are built on top of HTTP/1.1 using a feature called [connection upgrades](https://datatracker.ietf.org/doc/html/rfc7230#section-6.7). YARP proxies the initial request, and if the destination server responds with `101 Switching Protocols`, upgrades the connection to an opaque, bidirectional stream using the new protocol. YARP does not support upgrading to other protocols like HTTP/2 this way.

## HTTP/2

YARP supports [WebSockets over HTTP/2](https://datatracker.ietf.org/doc/html/rfc8441) starting in .NET 7 and YARP 2.0. Kestrel is the only available AspNetCore server that will accept incoming HTTP/2 WebSocket requests and that support is automatically enabled. Browsers can detect this support advertised by the server and automatically switch to HTTP/2.

The incoming and outgoing protocol versions do not need to match. The incoming WebSocket request can be HTTP/1.1 or 2. There is no configuration specific to WebSockets for outgoing requests, YARP will use the [ForwarderRequestConfig](xref:Yarp.ReverseProxy.Forwarder.ForwarderRequestConfig)'s Version and VersionPolicy to determine the outbound version to use. These default to HTTP/2 and RequestVersionOrLower.

WebSockets require different HTTP headers for HTTP/2 so YARP will add and remove these headers as needed when adapting between the different versions.

After the initial handshake WebSockets function the same way over both HTTP versions.

## Timeout

[Http Request Timeouts](https://learn.microsoft.com/aspnet/core/performance/timeouts) (.NET 8+) can apply timeouts to all requests by default or by policy. These timeouts will be disabled after a WebSocket handshake. They will still apply to gRPC requests. For additional configuration see [Timeouts](timeouts.md).
