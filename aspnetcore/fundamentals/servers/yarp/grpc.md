# Proxing gRPC

## Introduction

[gRPC](https://grpc.io/) is a language agnostic, high-performance Remote Procedure Call (RPC) framework. It's built on top of HTTP/2 and can be proxied through YARP. While YARP doesn't need to be aware of the gRPC messages, you do need to make sure the right HTTP protocol is enabled. gRPC requires HTTP/2 and gRPC calls will fail if YARP isn't correctly configured to send and receive HTTP/2 requests.

## Configure YARP's Incoming Protocols

gRPC requires HTTP/2 for most scenarios. HTTP/1.1 and HTTP/2 are enabled by default on ASP.NET Core servers (YARP's front end) but they require https (TLS) for HTTP/2 so YARP needs to be listening on a `https://` URL.

HTTP/2 over http (non-TLS) is only supported on Kestrel and requires specific settings.  For details see [here](https://docs.microsoft.com/aspnet/core/grpc/aspnetcore#server-options).

This shows configuring Kestrel to use HTTP/2 over http (non-TLS):
```json
{
  "Kestrel": {
    "Endpoints": {
      "http": {
        "Url": "http://localhost:5000",
        "Protocols": "Http2"
      }
    }
  }
}
```

## Configure YARP's Outgoing Protocols

YARP automatically negotiates HTTP/1.1 or HTTP/2 for outgoing proxy requests, but only for https (TLS). HTTP/2 over http (non-TLS) requires additional settings. Note outgoing protocols are independent of incoming ones. E.g. https can be used for the incoming connection and http for the outgoing one, this is called TLS termination. See [here](http-client-config.md#httprequest) for configuration details.

This shows configuring the outgoing proxy request to use HTTP/2 over http.
```json
"cluster1": {
  "HttpRequest": {
    "Version": "2",
    "VersionPolicy": "RequestVersionExact"
  },
  "Destinations": {
    "cluster1/destination1": {
      "Address": "http://localhost:6000/"
    }
  }
},
```

## gRPC-Web

[gRPC-Web](https://grpc.io/docs/platforms/web/basics/) is an alternative wire-format for gRPC that's compatible with HTTP/1.1.

* [`application/grpc`](https://github.com/grpc/grpc/blob/master/doc/PROTOCOL-HTTP2.md) - gRPC over HTTP/2 is how gRPC is typically used.
* [`application/grpc-web`](https://github.com/grpc/grpc/blob/master/doc/PROTOCOL-WEB.md) - gRPC-Web modifies the gRPC protocol to be compatible with HTTP/1.1. gRPC-Web can be used in more places. gRPC-Web can be used by browser apps and in networks without complete support for HTTP/2. Two advanced gRPC features are not supported: client streaming and bidirectional streaming.

gRPC-Web can be proxied by YARP's default configuration without any special considerations.
