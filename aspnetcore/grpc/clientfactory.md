---
title: gRPC client factory integration in .NET
author: jamesnk
description: Learn how to create gRPC clients using the client factory.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 02/25/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/clientfactory
---
# gRPC client factory integration in .NET

By [James Newton-King](https://twitter.com/jamesnk)

:::moniker range=">= aspnetcore-6.0"
gRPC integration with `HttpClientFactory` offers a centralized way to create gRPC clients. It can be used as an alternative to [configuring stand-alone gRPC client instances](xref:grpc/client). Factory integration is available in the [Grpc.Net.ClientFactory](https://www.nuget.org/packages/Grpc.Net.ClientFactory) NuGet package.

The factory offers the following benefits:

* Provides a central location for configuring logical gRPC client instances.
* Manages the lifetime of the underlying `HttpClientMessageHandler`.
* Automatic propagation of deadline and cancellation in an ASP.NET Core gRPC service.

## Register gRPC clients

To register a gRPC client, the generic `AddGrpcClient` extension method can be used within an instance of <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> at the app's entry point in `Program.cs`, specifying the gRPC typed client class and service address:

```csharp
builder.Services.AddGrpcClient<Greeter.GreeterClient>(o =>
{
    o.Address = new Uri("https://localhost:5001");
});
```

The gRPC client type is registered as transient with dependency injection (DI). The client can now be injected and consumed directly in types created by DI. ASP.NET Core MVC controllers, SignalR hubs and gRPC services are places where gRPC clients can automatically be injected:

```csharp
public class AggregatorService : Aggregator.AggregatorBase
{
    private readonly Greeter.GreeterClient _client;

    public AggregatorService(Greeter.GreeterClient client)
    {
        _client = client;
    }

    public override async Task SayHellos(HelloRequest request,
        IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
    {
        // Forward the call on to the greeter service
        using (var call = _client.SayHellos(request))
        {
            await foreach (var response in call.ResponseStream.ReadAllAsync())
            {
                await responseStream.WriteAsync(response);
            }
        }
    }
}
```

## Configure HttpHandler

`HttpClientFactory` creates the `HttpMessageHandler` used by the gRPC client. Standard `HttpClientFactory` methods can be used to add outgoing request middleware or to configure the underlying `HttpClientHandler` of the `HttpClient`:

```csharp
builder.Services
    .AddGrpcClient<Greeter.GreeterClient>(o =>
    {
        o.Address = new Uri("https://localhost:5001");
    })
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        var handler = new HttpClientHandler();
        handler.ClientCertificates.Add(LoadCertificate());
        return handler;
    });
```

For more information, see [Make HTTP requests using IHttpClientFactory](xref:fundamentals/http-requests).

## Configure Interceptors

gRPC interceptors can be added to clients using the `AddInterceptor` method.

```csharp
builder.Services
    .AddGrpcClient<Greeter.GreeterClient>(o =>
    {
        o.Address = new Uri("https://localhost:5001");
    })
    .AddInterceptor<LoggingInterceptor>();
```

The preceding code:
* Registers the `GreeterClient` type.
* Configures a `LoggingInterceptor` for this client. `LoggingInterceptor` is created once and shared between `GreeterClient` instances.

By default, an interceptor is created once and shared between clients. This behavior can be overriden by specifying a scope when registering an intercepter. The client factory can be configured to create a new interceptor for each client by specifying `InterceptorScope.Client`.

```csharp
builder.Services
    .AddGrpcClient<Greeter.GreeterClient>(o =>
    {
        o.Address = new Uri("https://localhost:5001");
    })
    .AddInterceptor<LoggingInterceptor>(InterceptorScope.Client);
```

Creating client scoped interceptors is useful when an interceptor requires [scoped or transient scoped services from DI](/dotnet/core/extensions/dependency-injection#service-lifetimes).

A gRPC interceptor or channel credentials can be used to send `Authorization` metadata with each request. For more information about configuring authentication, see [Send a bearer token with gRPC client factory](xref:grpc/authn-and-authz#bearer-token-with-grpc-client-factory).

## Configure Channel

Additional configuration can be applied to a channel using the `ConfigureChannel` method:

```csharp
builder.Services
    .AddGrpcClient<Greeter.GreeterClient>(o =>
    {
        o.Address = new Uri("https://localhost:5001");
    })
    .ConfigureChannel(o =>
    {
        o.Credentials = new CustomCredentials();
    });
```

`ConfigureChannel` is passed a `GrpcChannelOptions` instance. For more information, see [configure client options](xref:grpc/configuration#configure-client-options).

> [!NOTE]
> Some properties are set on `GrpcChannelOptions` before the `ConfigureChannel` callback is run:
> * `HttpHandler` is set to the result from <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.ConfigurePrimaryHttpMessageHandler%2A>.
> * `LoggerFactory` is set to the <xref:Microsoft.Extensions.Logging.ILoggerFactory> resolved from DI.
> 
> These values can be overriden by `ConfigureChannel`.

## Call credentials

An authentication header can be added to gRPC calls using the `AddCallCredentials` method:

```csharp
builder.Services
    .AddGrpcClient<Greeter.GreeterClient>(o =>
    {
        o.Address = new Uri("https://localhost:5001");
    })
    .AddCallCredentials((context, metadata) =>
    {
        if (!string.IsNullOrEmpty(_token))
        {
            metadata.Add("Authorization", $"Bearer {_token}");
        }
        return Task.CompletedTask;
    });
```

For more information about configuring call credentials, see [Bearer token with gRPC client factory](xref:grpc/authn-and-authz#bearer-token-with-grpc-client-factory).

## Deadline and cancellation propagation

gRPC clients created by the factory in a gRPC service can be configured with `EnableCallContextPropagation()` to automatically propagate the deadline and cancellation token to child calls. The `EnableCallContextPropagation()` extension method is available in the [Grpc.AspNetCore.Server.ClientFactory](https://www.nuget.org/packages/Grpc.AspNetCore.Server.ClientFactory) NuGet package.

Call context propagation works by reading the deadline and cancellation token from the current gRPC request context and automatically propagating them to outgoing calls made by the gRPC client. Call context propagation is an excellent way of ensuring that complex, nested gRPC scenarios always propagate the deadline and cancellation.

```csharp
builder.Services
    .AddGrpcClient<Greeter.GreeterClient>(o =>
    {
        o.Address = new Uri("https://localhost:5001");
    })
    .EnableCallContextPropagation();
```

By default, `EnableCallContextPropagation` raises an error if the client is used outside the context of a gRPC call. The error is designed to alert you that there isn't a call context to propagate. If you want to use the client outside of a call context, suppress the error when the client is configured with `SuppressContextNotFoundErrors`:

```csharp
builder.Services
    .AddGrpcClient<Greeter.GreeterClient>(o =>
    {
        o.Address = new Uri("https://localhost:5001");
    })
    .EnableCallContextPropagation(o => o.SuppressContextNotFoundErrors = true);
```

For more information about deadlines and RPC cancellation, see <xref:grpc/deadlines-cancellation>.

## Named clients

Typically, a gRPC client type is registered once and then injected directly into a type's constructor by DI. However, there are scenarios where it's useful to have multiple configurations for one client. For example, a client that makes gRPC calls with and without authentication.

Multiple clients with the same type can be registered by giving each client a name. Each named client can have its own configuration. The generic `AddGrpcClient` extension method has an overload that includes a name parameter:

```csharp
builder.Services
    .AddGrpcClient<Greeter.GreeterClient>("Greeter", o =>
    {
        o.Address = new Uri("https://localhost:5001");
    });
    
builder.Services
    .AddGrpcClient<Greeter.GreeterClient>("GreeterAuthenticated", o =>
    {
        o.Address = new Uri("https://localhost:5001");
    })
    .ConfigureChannel(o =>
    {
        o.Credentials = new CustomCredentials();
    });
```

The preceding code:
* Registers the `GreeterClient` type twice, specifying a unique name for each.
* Configures different settings for each named client. The `GreeterAuthenticated` registration adds credentials to the channel so that gRPC calls made with it are authenticated.

A named gRPC client is created in app code using `GrpcClientFactory`. The type and name of the desired client is specified using the generic `GrpcClientFactory.CreateClient` method:

```csharp
public class AggregatorService : Aggregator.AggregatorBase
{
    private readonly Greeter.GreeterClient _client;

    public AggregatorService(GrpcClientFactory grpcClientFactory)
    {
        _client = grpcClientFactory.CreateClient<Greeter.GreeterClient>("GreeterAuthenticated");
    }
}
```

## Additional resources

* <xref:grpc/client>
* <xref:grpc/deadlines-cancellation>
* <xref:fundamentals/http-requests>
:::moniker-end

:::moniker range="< aspnetcore-6.0"
gRPC integration with `HttpClientFactory` offers a centralized way to create gRPC clients. It can be used as an alternative to [configuring stand-alone gRPC client instances](xref:grpc/client). Factory integration is available in the [Grpc.Net.ClientFactory](https://www.nuget.org/packages/Grpc.Net.ClientFactory) NuGet package.

The factory offers the following benefits:

* Provides a central location for configuring logical gRPC client instances
* Manages the lifetime of the underlying `HttpClientMessageHandler`
* Automatic propagation of deadline and cancellation in an ASP.NET Core gRPC service

## Register gRPC clients

To register a gRPC client, the generic `AddGrpcClient` extension method can be used within `Startup.ConfigureServices`, specifying the gRPC typed client class and service address:

```csharp
services.AddGrpcClient<Greeter.GreeterClient>(o =>
{
    o.Address = new Uri("https://localhost:5001");
});
```

The gRPC client type is registered as transient with dependency injection (DI). The client can now be injected and consumed directly in types created by DI. ASP.NET Core MVC controllers, SignalR hubs and gRPC services are places where gRPC clients can automatically be injected:

```csharp
public class AggregatorService : Aggregator.AggregatorBase
{
    private readonly Greeter.GreeterClient _client;

    public AggregatorService(Greeter.GreeterClient client)
    {
        _client = client;
    }

    public override async Task SayHellos(HelloRequest request,
        IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
    {
        // Forward the call on to the greeter service
        using (var call = _client.SayHellos(request))
        {
            await foreach (var response in call.ResponseStream.ReadAllAsync())
            {
                await responseStream.WriteAsync(response);
            }
        }
    }
}
```

## Configure HttpHandler

`HttpClientFactory` creates the `HttpMessageHandler` used by the gRPC client. Standard `HttpClientFactory` methods can be used to add outgoing request middleware or to configure the underlying `HttpClientHandler` of the `HttpClient`:

```csharp
services
    .AddGrpcClient<Greeter.GreeterClient>(o =>
    {
        o.Address = new Uri("https://localhost:5001");
    })
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        var handler = new HttpClientHandler();
        handler.ClientCertificates.Add(LoadCertificate());
        return handler;
    });
```

For more information, see [Make HTTP requests using IHttpClientFactory](xref:fundamentals/http-requests).

## Configure Interceptors

gRPC interceptors can be added to clients using the `AddInterceptor` method.

```csharp
services
    .AddGrpcClient<Greeter.GreeterClient>(o =>
    {
        o.Address = new Uri("https://localhost:5001");
    })
    .AddInterceptor<LoggingInterceptor>();
```

The preceding code:
* Registers the `GreeterClient` type.
* Configures a `LoggingInterceptor` for this client. `LoggingInterceptor` is created once and shared between `GreeterClient` instances.

By default, an interceptor is created once and shared between clients. This behavior can be overriden by specifying a scope when registering an intercepter. The client factory can be configured to create a new interceptor for each client by specifying `InterceptorScope.Client`.

```csharp
services
    .AddGrpcClient<Greeter.GreeterClient>(o =>
    {
        o.Address = new Uri("https://localhost:5001");
    })
    .AddInterceptor<LoggingInterceptor>(InterceptorScope.Client);
```

Creating client scoped interceptors is useful when an interceptor requires [scoped or transient scoped services from DI](/dotnet/core/extensions/dependency-injection#service-lifetimes).

A gRPC interceptor or channel credentials can be used to send `Authorization` metadata with each request. For more information about configuring authentication, see [Send a bearer token with gRPC client factory](xref:grpc/authn-and-authz#bearer-token-with-grpc-client-factory).

## Configure Channel

Additional configuration can be applied to a channel using the `ConfigureChannel` method:

```csharp
services
    .AddGrpcClient<Greeter.GreeterClient>(o =>
    {
        o.Address = new Uri("https://localhost:5001");
    })
    .ConfigureChannel(o =>
    {
        o.Credentials = new CustomCredentials();
    });
```

`ConfigureChannel` is passed a `GrpcChannelOptions` instance. For more information, see [configure client options](xref:grpc/configuration#configure-client-options).

> [!NOTE]
> Some properties are set on `GrpcChannelOptions` before the `ConfigureChannel` callback is run:
> * `HttpHandler` is set to the result from <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.ConfigurePrimaryHttpMessageHandler%2A>.
> * `LoggerFactory` is set to the <xref:Microsoft.Extensions.Logging.ILoggerFactory> resolved from DI.
> 
> These values can be overriden by `ConfigureChannel`.

## Deadline and cancellation propagation

gRPC clients created by the factory in a gRPC service can be configured with `EnableCallContextPropagation()` to automatically propagate the deadline and cancellation token to child calls. The `EnableCallContextPropagation()` extension method is available in the [Grpc.AspNetCore.Server.ClientFactory](https://www.nuget.org/packages/Grpc.AspNetCore.Server.ClientFactory) NuGet package.

Call context propagation works by reading the deadline and cancellation token from the current gRPC request context and automatically propagating them to outgoing calls made by the gRPC client. Call context propagation is an excellent way of ensuring that complex, nested gRPC scenarios always propagate the deadline and cancellation.

```csharp
services
    .AddGrpcClient<Greeter.GreeterClient>(o =>
    {
        o.Address = new Uri("https://localhost:5001");
    })
    .EnableCallContextPropagation();
```

By default, `EnableCallContextPropagation` raises an error if the client is used outside the context of a gRPC call. The error is designed to alert you that there isn't a call context to propagate. If you want to use the client outside of a call context, suppress the error when the client is configured with `SuppressContextNotFoundErrors`:

```csharp
services
    .AddGrpcClient<Greeter.GreeterClient>(o =>
    {
        o.Address = new Uri("https://localhost:5001");
    })
    .EnableCallContextPropagation(o => o.SuppressContextNotFoundErrors = true);
```

For more information about deadlines and RPC cancellation, see <xref:grpc/deadlines-cancellation>.

## Named clients

Typically, a gRPC client type is registered once and then injected directly into a type's constructor by DI. However, there are scenarios where it is useful to have multiple configurations for one client. For example, a client that makes gRPC calls with and without authentication.

Multiple clients with the same type can be registered by giving each client a name. Each named client can have its own configuration. The generic `AddGrpcClient` extension method has an overload that includes a name parameter:

```csharp
services
    .AddGrpcClient<Greeter.GreeterClient>("Greeter", o =>
    {
        o.Address = new Uri("https://localhost:5001");
    });
    
services
    .AddGrpcClient<Greeter.GreeterClient>("GreeterAuthenticated", o =>
    {
        o.Address = new Uri("https://localhost:5001");
    })
    .ConfigureChannel(o =>
    {
        o.Credentials = new CustomCredentials();
    });
```

The preceding code:
* Registers the `GreeterClient` type twice, specifying a unique name for each.
* Configures different settings for each named client. The `GreeterAuthenticated` registration adds credentials to the channel so that gRPC calls made with it are authenticated.

A named gRPC client is created in app code using `GrpcClientFactory`. The type and name of the desired client is specified using the generic `GrpcClientFactory.CreateClient` method:

```csharp
public class AggregatorService : Aggregator.AggregatorBase
{
    private readonly Greeter.GreeterClient _client;

    public AggregatorService(GrpcClientFactory grpcClientFactory)
    {
        _client = grpcClientFactory.CreateClient<Greeter.GreeterClient>("GreeterAuthenticated");
    }
}
```

## Additional resources

* <xref:grpc/client>
* <xref:grpc/deadlines-cancellation>
* <xref:fundamentals/http-requests>
:::moniker-end
