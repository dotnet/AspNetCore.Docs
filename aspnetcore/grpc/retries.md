---
title: Transient fault handling with gRPC retries
author: jamesnk
description: Learn how to make resilient, fault tolerant gRPC calls with retries in .NET.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 03/18/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/retries
---
# Transient fault handling with gRPC retries

By [James Newton-King](https://twitter.com/jamesnk)

gRPC retries is a feature that allows gRPC clients to automatically retry failed calls. This article discusses how to configure a retry policy to make resilient, fault tolerant gRPC apps in .NET.

gRPC retries requires [Grpc.Net.Client](https://www.nuget.org/packages/Grpc.Net.Client) version 2.36.0 or later.

## Transient fault handling

gRPC calls can be interrupted by transient faults. Transient faults include:

* Momentary loss of network connectivity.
* Temporary unavailability of a service.
* Timeouts due to server load.

When a gRPC call is interrupted, the client throws an `RpcException` with details about the error. The client app must catch the exception and choose how to handle the error.

```csharp
var client = new Greeter.GreeterClient(channel);
try
{
    var response = await client.SayHelloAsync(
        new HelloRequest { Name = ".NET" });

    Console.WriteLine("From server: " + response.Message);
}
catch (RpcException ex)
{
    // Write logic to inspect the error and retry
    // if the error is from a transient fault.
}
```

Duplicating retry logic throughout an app is verbose and error prone. Fortunately the .NET gRPC client has a built-in support for automatic retries.

## Configure a gRPC retry policy

A retry policy is configured once when a gRPC channel is created:

```csharp
var defaultMethodConfig = new MethodConfig
{
    Names = { MethodName.Default },
    RetryPolicy = new RetryPolicy
    {
        MaxAttempts = 5,
        InitialBackoff = TimeSpan.FromSeconds(1),
        MaxBackoff = TimeSpan.FromSeconds(5),
        BackoffMultiplier = 1.5,
        RetryableStatusCodes = { StatusCode.Unavailable }
    }
};

var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions
{
    ServiceConfig = new ServiceConfig { MethodConfigs = { defaultMethodConfig } }
});
```

The preceding code:

* Creates a `MethodConfig`. Retry policies can be configured per-method and methods are matched using the `Names` property. This method is configured with `MethodName.Default`, so it's applied to all gRPC methods called by this channel.
* Configures a retry policy. This policy instructs clients to automatically retry gRPC calls that fail with the status code `Unavailable`.
* Configures the created channel to use the retry policy by setting `GrpcChannelOptions.ServiceConfig`.

gRPC clients created with the channel will automatically retry failed calls:

```csharp
var client = new Greeter.GreeterClient(channel);
var response = await client.SayHelloAsync(
    new HelloRequest { Name = ".NET" });

Console.WriteLine("From server: " + response.Message);
```

### When retries are valid

Calls are retried when:

* The failing status code matches a value in `RetryableStatusCodes`.
* The previous number of attempts is less than `MaxAttempts`.
* The call hasn't been commited.
* The deadline hasn't been exceeded.

A gRPC call becomes committed in two scenarios:

* The client receives response headers. Response headers are sent by the server when `ServerCallContext.WriteResponseHeadersAsync` is called, or when the first message is written to the server response stream.
* The client's outgoing message (or messages if streaming) has exceeded the client's maximum buffer size. `MaxRetryBufferSize` and `MaxRetryBufferPerCallSize` are [configured on the channel](xref:grpc/configuration#configure-client-options).

Committed calls won't retry, regardless of the status code or the previous number of attempts.

### Streaming calls

Streaming calls can be used with gRPC retries, but there are important considerations when they are used together:

* **Server streaming**, **bidirectional streaming**: Streaming RPCs that return multiple messages from the server won't retry after the first message has been received. Apps must add additional logic to manually re-establish server and bidirectional streaming calls.
* **Client streaming**, **bidirectional streaming**: Streaming RPCs that send multiple messages to the server won't retry if the outgoing messages have exceeded the client's maximum buffer size. The maximum buffer size can be increased with configuration.

For more information, see [When retries are valid](#when-retries-are-valid).

### Retry backoff delay

The backoff delay between retry attempts is configured with `InitialBackoff`, `MaxBackoff`, and `BackoffMultiplier`. More information about each option is available in the [gRPC retry options section](#grpc-retry-options).

The actual delay between retry attempts is randomized. A randomized delay between 0 and the current backoff determines when the next retry attempt is made. Consider that even with exponential backoff configured, increasing the current backoff between attempts, the actual delay between attempts isn't always larger. The delay is randomized to prevent retries from multiple calls from clustering together and potentially overloading the server.

### gRPC retry options

The following table describes options for configuring gRPC retry policies:

| Option | Description |
| ------ | ----------- |
| `MaxAttempts` | The maximum number of call attempts, including the original attempt. This value is limited by `GrpcChannelOptions.MaxRetryAttempts` which defaults to 5. A value is required and must be greater than 1. |
| `InitialBackoff` | The initial backoff delay between retry attempts. A randomized delay between 0 and the current backoff determines when the next retry attempt is made. After each attempt, the current backoff is multiplied by `BackoffMultiplier`. A value is required and must be greater than zero. |
| `MaxBackoff` | The maximum backoff places an upper limit on exponential backoff growth. A value is required and must be greater than zero. |
| `BackoffMultiplier` | The backoff will be multiplied by this value after each retry attempt and will increase exponentially when the multiplier is greater than 1. A value is required and must be greater than zero. |
| `RetryableStatusCodes` | A collection of status codes. A gRPC call that fails with a matching status will be automatically retried. For more information about status codes, see [Status codes and their use in gRPC](https://grpc.github.io/grpc/core/md_doc_statuscodes.html). At least one retryable status code is required. |

## Hedging

Hedging is an alternative retry strategy. Hedging enables aggressively sending multiple copies of a single gRPC call without waiting for a response. Hedged gRPC calls may be executed multiple times on the server and the first successful result is used. It's important that hedging is only enabled for methods that are safe to execute multiple times without adverse effect.

Hedging has pros and cons when compared to retries: 

* An advantage to hedging is it might return a successful result faster. It allows for multiple simultaneously gRPC calls and will complete when the first successful result is available. 
* A disadvantage to hedging is it can be wasteful. Multiple calls could be made and all succeed. Only the first result is used and the rest are discarded.

## Configure a gRPC hedging policy

A hedging policy is configured like a retry policy. Note that a hedging policy can't be combined with a retry policy.

```csharp
var defaultMethodConfig = new MethodConfig
{
    Names = { MethodName.Default },
    HedgingPolicy = new HedgingPolicy
    {
        MaxAttempts = 5,
        NonFatalStatusCodes = { StatusCode.Unavailable }
    }
};

var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions
{
    ServiceConfig = new ServiceConfig { MethodConfigs = { defaultMethodConfig } }
});
```

### gRPC hedging options

The following table describes options for configuring gRPC hedging policies:

| Option | Description |
| ------ | ----------- |
| `MaxAttempts` | The hedging policy will send up to this number of calls. `MaxAttempts` represents the total number of all attempts, including the original attempt. This value is limited by `GrpcChannelOptions.MaxRetryAttempts` which defaults to 5. A value is required and must be 2 or greater. |
| `HedgingDelay` | The first call is sent immediately, subsequent hedging calls are delayed by this value. When the delay is set to zero or `null`, all hedged calls are sent immediately. `HedgingDelay` is optional and defaults to zero. A value must be zero or greater. |
| `NonFatalStatusCodes` | A collection of status codes which indicate other hedge calls may still succeed. If a non-fatal status code is returned by the server, hedged calls will continue. Otherwise, outstanding requests will be canceled and the error returned to the app. For more information about status codes, see [Status codes and their use in gRPC](https://grpc.github.io/grpc/core/md_doc_statuscodes.html). |

## Additional resources

* <xref:grpc/client>
* [Retry general guidance - Best practices for cloud applications](/azure/architecture/best-practices/transient-faults)
