---
uid: runtimes
title: Supported Runtimes
---

# YARP Supported Runtimes

YARP 2.0+ supports ASP.NET Core 6.0 and newer. You can download the .NET SDK from https://dotnet.microsoft.com/download/dotnet/. See [Releases](https://github.com/microsoft/reverse-proxy/releases) for specific version support.

YARP is taking advantage of new .NET features and optimizations as they become available. This does mean that some features may not be available if you're running on the previous versions of ASP.NET.

## Related 6.0 Runtime Improvements

- [HTTP/3](http3.md) - support for inbound and outbound connections (preview).
- [Distributed Tracing](distributed-tracing.md) - .NET 6.0 has built-in configurable support that YARP takes advantage of to enable more scenarios out-of-the-box.
- [Http.sys Delegation](httpsys-delegation.md) - a kernel-level ASP.NET Core 6 feature that allows a request to be transferred to a different process.
- [UseHttpLogging](diagnosing-yarp-issues.md#using-aspnet-request-logging) - includes an additional middleware component that can be used to provide more details about the request and response.
- [Dynamic HTTP/2 window scaling](https://github.com/dotnet/runtime/pull/54755) - improves HTTP/2 download speed on high-latency connections.
- [NonValidated headers](https://github.com/microsoft/reverse-proxy/pull/1507) - improves perfomance by using non-validated HttpClient headers.


## Related 7.0 Runtime Improvements

- [HTTP/3](http3.md) - support for inbound and outbound connections (stable).
- [Zero-byte reads on HttpClient's response streams](https://github.com/dotnet/runtime/pull/61913) - reduces memory usage.
- [Header allocation reductions](https://github.com/dotnet/runtime/pull/62981) - reduces memory usage.
- [Kestrel Http/2 perf improvements](https://github.com/dotnet/aspnetcore/pull/40925) - Improve contention and throughput for multiple requests on one connection.
