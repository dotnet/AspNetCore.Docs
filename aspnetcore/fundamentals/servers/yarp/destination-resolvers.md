# Extensibility: Destination Resolvers

## Introduction

YARP uses a destination resolver to expand the set of configured destination addresses. The destination resolver can be used as an integration point with service discovery systems.

## Structure
[IDestinationResolver](xref:Yarp.ReverseProxy.ServiceDiscovery.IDestinationResolver) has a single method `ResolveDestinationsAsync(IReadOnlyDictionary<string, DestinationConfig> destinations, CancellationToken cancellationToken)` which should return a [ResolvedDestinationCollection](xref:Yarp.ReverseProxy.ServiceDiscovery.ResolvedDestinationCollection) instance. The [ResolvedDestinationCollection](xref:Yarp.ReverseProxy.ServiceDiscovery.ResolvedDestinationCollection) has a collection of [DestinationConfig](xref:Yarp.ReverseProxy.Configuration.DestinationConfig) instances, as well as an `IChangeToken` to notify the proxy when this information is out of date and should be reloaded, which will cause `ResolveDestinationsAsync` to be called again.

### DestinationConfig
`DestinationConfig` has a `Host` property which can be used to specify the default `Host` header value which the proxy should use when communicating with that destination. This allows the `IDestinationResolver` to resolve destinations to a collection of IP addresses, for example, without causing SNI or host-based routing to fail.

## Lifecycle

### Startup
The `IDestinationResolver` should be registered in the DI container as a singleton. At startup, the proxy will resolve this instance and call `ResolveDestinationsAsync(...)` with the configured destinations retrieved from the resolved `IProxyConfigProviders`. On this first call the provider may choose to:
- Throw an exception if the provider cannot produce a valid proxy configuration for any reason. This will prevent the application from starting.
- Asynchronously resolve the destinations. This will stop the application from starting until resolved destinations are available.
- Or, it may choose to return an empty `ResolvedDestinationCollection` instance while it resolves destinations in the background. The provider will need to trigger the `IChangeToken` when the configuration is available.

### Atomicity
The destinations objects and collections supplied to the proxy should be read-only and not modified once they have been handed to the proxy via `GetConfig()`.

### Reload
If the `IChangeToken` supports `ActiveChangeCallbacks`, once the proxy has processed the initial set of destinations it will register a callback with this token. If the provider does not support callbacks then `HasChanged` will be polled alongside `IProxyConfig` change tokens, every 5 minutes.

When the provider wants to provide a new set of destinations to the proxy it should:
- Resolve those destinations in the background.
  - `ResolvedDestinationCollection` is immutable, so new instances have to be created for any new data.
  - Objects for unchanged destinations can be re-used, or new instances can be created.
- Invalidate the `IChangeToken` returned from the previous `ResolveDestinationsAsync` invocation.

Once the new destinations have been applied, the proxy will register a callback with the new `IChangeToken`. Note if there are multiple reloads signaled in close succession, the proxy may skip some and resolve destinations as soon as it's ready.

## DNS Destination Resolver

YARP includes an [IDestinationResolver](xref:Yarp.ReverseProxy.ServiceDiscovery.IDestinationResolver) implementation which expands the set of configured destinations by resolving each host name to one or more IP addresses using DNS, creating a destination for each resolved IP.
The DNS destination resolver can be added to your reverse proxy using the `IReverseProxyBuilder.AddDnsDestinationResolver(Action<DnsDestinationResolverOptions>)` method.
The method accepts an optional delegate to configure the resolver's options, [DnsDestinationResolverOptions](xref:Yarp.ReverseProxy.ServiceDiscovery.DnsDestinationResolverOptions).

### Example

```csharp
// Add the DNS destination resolver, restricting results to IPv4 addresses
reverseProxyBuilder.AddDnsDestinationResolver(o => o.AddressFamily = AddressFamily.InterNetwork);
```

### Configuration

The DNS destination resolver's options, [DnsDestinationResolverOptions](xref:Yarp.ReverseProxy.ServiceDiscovery.DnsDestinationResolverOptions), has the following properties:

#### RefreshPeriod

The period between requesting a refresh of a resolved name. This defaults to 5 minutes.

#### AddressFamily

Optionally, specify an `System.Net.Sockets.AddressFamily` value of `AddressFamily.InterNetwork` or `AddressFamily.InterNetworkV6` to restrict resolved resolution to IPv4 or IPv6 addresses, respectively. The default value, `null`, instructs the resolver to not restrict the address family of the results and to use accept all returned addresses.
