---
title: gRPC client-side load balancing
author: jamesnk
description: Learn how to make scalable, high-performance gRPC apps with client-side load balancing in .NET.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 05/18/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/loadbalancing
---
# gRPC client-side load balancing

By [James Newton-King](https://twitter.com/jamesnk)

Client-side load balancing is a feature that allows gRPC clients to distribute load optimally across available servers. This article discusses how to configure a client-side load balancing to create scalable, high-performance gRPC apps in .NET.

Client-side load balancing requires [Grpc.Net.Client](https://www.nuget.org/packages/Grpc.Net.Client) version XXXX or later.

## Configure gRPC client-side load balancing

Client-side load balancing is configured when a channel is created. The two components to consider when using load balancing:

* The resolver, which resolves the addresses that gRPC calls can be routed to.
* The load balancer, which creates connections and picks the address that a gRPC call will use.

Built-in implementations of resolvers and load balancers are included in [Grpc.Net.Client](https://www.nuget.org/packages/Grpc.Net.Client).

## Configure resolver

The resolver is configured using the scheme of the address URI for the channel. For example, `dns:///my-example-host`.

| Scheme   | Type             | Description |
| -------- | ---------------- | ----------- |
| `dns`    | `DnsResolver`    | Resolves addresses by querying the hostname for [DNS service records](https://en.wikipedia.org/wiki/SRV_record). |
| `static` | `StaticResolver` | Resolves addresses from a static collection that is specified by the app. Recommended if an app already knows the addresses it needs to call. |

#### DnsResolver

The `DnsResolver` is designed to get addresses from an external source. DNS resolution is commonly used to load balance over pod instances that have a [Kubernetes headless services](https://kubernetes.io/docs/concepts/services-networking/service/#headless-services).

```csharp
var channel = GrpcChannel.ForAddress(
    "dns:///my-example-host",
    new GrpcChannelOptions { ChannelCredentials = ChannelCredentials.Insecure });
var client = new Greet.GreeterClient(channel);

var response = await client.SayHelloAsync(new HelloRequest { Name = "world" });
```

The preceding code:

* Configures the created channel with the address `dns:///my-example-host`. The `dns` schema maps to `DnsResolver`.
* Doesn't specify a load balancer. The channel defaults to `PickFirstLoadBalancer`.
* Starts the gRPC call `SayHello`.
  * `DnsResolver` resolves addresses for the hostname `my-example-host`. The result is cached and refreshed when needed.
  * `PickFirstLoadBalancer` attempts to connect to one of the resolved addresses.
  * The call is sent to the first address the channel successfully connects to.

#### StaticResolver

Another resolver available to use with load balancing is `StaticResolver`. This resolver doesn't call an external service. Instead, the client app configures the addresses it resolves. `StaticResolver` is designed for situations where an app already knows the addresses it needs to call.

```csharp
var factory = new StaticResolverFactory(addr => new[]
{
    new DnsEndPoint("localhost", 80),
    new DnsEndPoint("localhost", 81)
});

var services = new ServiceCollection();
services.AddSingleton<ResolverFactory>(factory);

var channel = GrpcChannel.ForAddress(
    "static:///my-example-host",
    new GrpcChannelOptions
    {
        ChannelCredentials = ChannelCredentials.Insecure,
        ServiceProvider = services.BuildServiceProvider()
    });
var client = new Greet.GreeterClient(channel);
```

The preceding code:

* Creates a `StaticResolverFactory`. This factory knows about two addresses: `localhost:80` and `localhost:81`.
* Registers the factory with a dependency injection (DI).
* Configures the created channel with:
  * The address `static:///my-example-host`. The `static` schema maps to `StaticResolver`.
  * Sets `GrpcChannelOptions.ServiceProvider` with the DI service provider.

This example creates a new `ServiceCollection` for DI. If an app already has DI setup, like an ASP.NET Core website, then types should be registered there. `GrpcChannelOptions.ServiceProvider` can be configured by getting an `IServiceProvider` from DI.

## Configure load balancer

A load balancer is specified in a service config using the `ServiceConfig.LoadBalancingConfigs` collection. The load balancer config name maps to implementations:

| Name          | Type                     | Description |
| ------------- | ------------------------ | ----------- |
| `pick_first`  | `PickFirstLoadBalancer`  | Attempts to connect to addresses until a connection is successfully made. gRPC calls are all made to the same address. |
| `round_robin` | `RoundRobinLoadBalancer` | Attempts to connect to all addresses. gRPC calls are distributed across all connections using round-robin logic. |

A channel can get its service config from a couple of different sources:

* An app can specify a service config when a channel is created using `GrpcChannelOptions.ServiceConfig`.
* A resolver can optionally resolve a service config for a channel. This feature allows an external service to specify how its callers should perform load balancing. Whether a resolver supports resolving a service config is dependent on the resolver implementation. Disable this feature with `GrpcChannelOptions.DisableResolverServiceConfig`.
* If no service config is provided, or the service config doesn't have a load balancer configured, the channel defaults to `PickFirstLoadBalancer`.

```csharp
var channel = GrpcChannel.ForAddress(
    "dns:///my-example-host",
    new GrpcChannelOptions
    {
        ChannelCredentials = ChannelCredentials.Insecure,
        ServiceConfig = new ServiceConfig { LoadBalancingConfigs = { new RoundRobinConfig() } }
    });
var client = new Greet.GreeterClient(channel);

var response = await client.SayHelloAsync(new HelloRequest { Name = "world" });
```

The preceding code:

* Specifies a `RoundRobinLoadBalancer` in the service config.
* Starts the gRPC call `SayHello`.
  * `RoundRobinLoadBalancer` attempts to connect to all resolved addresses.
  * gRPC calls are distributed evenly using [round-robin](https://www.nginx.com/resources/glossary/round-robin-load-balancing/) logic.

## Write custom resolvers and load balancers

Client-side load balancing is extensible. It is possible to create custom resolvers and load balancers by implementing `Resolver` and `LoadBalancer`.

### Create a custom resolver

A resolver is responsible for resolving the addresses a load balancer will use. It can also optionally provide a service config. A resolver implements `Resolver` and is created by a `ResolverFactory`. Create a custom resolver by implementing these types.

```csharp
public class FileResolverFactory : ResolverFactory
{
    public override string Name => "file";

    public override Resolver Create(Uri address, ResolverOptions options)
    {
        return new FileResolver(address);
    }
}

public class FileResolver : Resolver
{
    private readonly Uri _address;

    public ExampleResolver(Uri address)
    {
        _address = address;
    }

    public override async Task RefreshAsync(CancellationToken cancellationToken)
    {
        // Load JSON from a file on disk and deserialize into endpoints.
        var jsonString = await File.ReadAllTextAsync(_address.LocalPath);
        var results = JsonSerializer.Deserialize<string[]>(jsonString);
        var addresses = results.Select(r => new DnsEndPoint(r, 80));

        // Pass the results back to the channel.
        _listener(ResolverResult.ForResult(addresses, serviceConfig: null));
    }

    public override void Start(Action<ResolverResult> listener)
    {
        _listener = listener;
    }
}
```

The preceding code:

* `FileResolverFactory` implements `ResolverFactory`. It maps to the `file` scheme and creates `FileResolver` instances.
* `FileResolver` implements `Resolver`. The file URI, for example `file:///c:/data/addresses.json`, is converted to a local path and used to load a JSON file from disk.

### Create a custom load balancer

A load balancer implements `LoadBalancer` and is created by a `LoadBalancerFactory`. A load balancer is given addresses from a resolver and creates `Subchannel` instances. It tracks state about the connection, and creates a `SubchannelPicker` that the channel will use to pick an address to send gRPC calls to.

`SubchannelsLoadBalancer` is:

* An abstract base class that manages creating `Subchannel` instances.
* Makes it easy to implement a custom picking policy over a collection of subchannels.

```csharp
public class RandomBalancer : SubchannelsLoadBalancer
{
    public RandomBalancer(IChannelControlHelper controller, ILoggerFactory loggerFactory)
        : base(controller, loggerFactory)
    {
    }

    protected override SubchannelPicker CreatePicker(List<Subchannel> readySubchannels)
    {
        return new RandomPicker(readySubchannels);
    }

    private class RandomPicker : SubchannelPicker
    {
        private readonly List<Subchannel> _subchannels;

        public RandomPicker(List<Subchannel> subchannels)
        {
            _subchannels = readySubchannels;
        }

        public override PickResult Pick(PickContext context)
        {
            // Pick a random subchannel.
            return _subchannels[Random.Shared.Next(0, _subchannels.Count)];
        }
    }
}

public class RandomBalancerFactory : LoadBalancerFactory
{
    private readonly ILoggerFactory _loggerFactory;

    public override string Name { get; } = "random";

    public RandomBalancerFactory(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
    }

    public override LoadBalancer Create(IChannelControlHelper controller, IDictionary<string, object> options)
    {
        return new RandomBalancer(controller, _loggerFactory);
    }
}
```

The preceding code:

* `RandomBalancerFactory` implements `LoadBalancerFactory`. It maps to the `random` policy name and creates `RandomBalancer` instances.
* `RandomBalancer` implements `SubchannelsLoadBalancer`. It creates a `RandomPicker` that randomly picks a subchannel.

## Configure custom resolvers and load balancers

Custom resolvers and load balancers need to be registered with dependency injection (DI). There are a couple of options:

* If an app is already using DI, such as an ASP.NET Core website, then they can be registered with existing DI configuration. `IServiceProvider` can then be resolved from DI and passed to the channel using `GrpcChannelOptions.ServiceProvider`.
* If an app isn't using DI then a `ServiceCollection` can be created, types registered with it, then create a service provider using `IServiceCollection.BuildServiceProvider()`.

```csharp
var services = new ServiceCollection();
services.AddSingleton<ResolverFactory, FileResolverFactory>();
services.AddSingleton<LoadBalancerFactory, RandomLoadBalancerFactory>();

var channel = GrpcChannel.ForAddress(
    "file:///c:/data/addresses.json",
    new GrpcChannelOptions
    {
        ChannelCredentials = ChannelCredentials.Insecure,
        ServiceConfig = new ServiceConfig { LoadBalancingConfigs = { new LoadBalancingConfig("random") } },
        ServiceProvider = services.BuildServiceProvider()
    });
var client = new Greet.GreeterClient(channel);
```

The preceding code:

* Creates a `ServiceCollection` and registers new resolver and load balancer implementations.
* Creates a channel configured to use the new implementations:
  * `ServiceCollection` is built into an `IServiceProvider` and set to `GrpcChannelOptions.ServiceProvider`.
  * Channel address is `file:///c:/data/addresses.json`. The `file` scheme maps to `FileResolverFactory`.
  * Service config load balancer name is `random`. Maps to `RandomLoadBalancerFactory`.

## Why load balancing is important

HTTP/2 multiplexes multiple calls on a single TCP connection. If gRPC and HTTP/2 are used with a network load balancer (NLB), the connection is forwarded to a server, and all gRPC calls are sent to that one server. The other server instances on the NLB are idle.

Network load balancers are a common solution for load balancing because they are fast and lightweight. For example, Kubernetes by default uses a network load balancer to balance connections between pod instances. However, network load balancers are not effective at distributing load when used with gRPC and HTTP/2.

### Proxy or client-side load balancing?

gRPC and HTTP/2 can be effectively load balanced using either an application load balancer proxy or client-side load balancing. Both of these options allow individual gRPC calls to be distributed across available servers. Deciding between proxy and client-side load balancing is an architectural choice. There are pros and cons for each.

* **Proxy** - gRPC calls are sent to the proxy, the proxy makes a load balancing decision, and the gRPC call is sent on to the final endpoint. The proxy is responsible for knowing about endpoints. Using a proxy adds:

  * An additional network hop to gRPC calls.
  * Latency and consumes additional resources.
  * Proxy server must be setup and configured correctly.

* **Client-side load balancing** - The gRPC client makes a load balancing decision when a gRPC call is started. The gRPC call is sent directly to the final endpoint. When using client-side load balancing:

  * Client is responsible for knowing about available endpoints and making load balancing decisions.
  * Additional client configuration required.
  * High-performance, load balanced gRPC calls that eliminate the need for a proxy.

## Additional resources

* <xref:grpc/client>
