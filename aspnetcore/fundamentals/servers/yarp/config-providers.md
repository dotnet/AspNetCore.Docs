# Extensibility: Configuration Providers

## Introduction
The [Basic Yarp Sample](https://github.com/microsoft/reverse-proxy/tree/main/samples/BasicYarpSample) show proxy configuration being loaded from appsettings.json. Instead proxy configuration can be loaded programmatically from the source of your choosing. You do this by providing a couple of classes implementing [IProxyConfigProvider](xref:Yarp.ReverseProxy.Configuration.IProxyConfigProvider) and [IProxyConfig](xref:Yarp.ReverseProxy.Configuration.IProxyConfig).

See [ReverseProxy.Code.Sample](https://github.com/microsoft/reverse-proxy/tree/main/samples/ReverseProxy.Code.Sample) for an example of a custom configuration provider.

Configuration can be modified during the load sequence using [Configuration Filters](config-filters.md).

## Structure
[IProxyConfigProvider](xref:Yarp.ReverseProxy.Configuration.IProxyConfigProvider) has a single method `GetConfig()` that should return an [IProxyConfig](xref:Yarp.ReverseProxy.Configuration.IProxyConfig) instance. The IProxyConfig has lists of the current routes and clusters, as well as an `IChangeToken` to notify the proxy when this information is out of date and should be reloaded, which will cause `GetConfig()` to be called again.

### Routes
The routes section is an unordered collection of named routes. A route contains matches and their associated configuration. A route requires at least the following fields:
- RouteId - a unique name
- ClusterId - refers to the name of an entry in the clusters section.
- Match - contains either a Hosts array or a Path pattern string. Path is an ASP.NET Core route template that can be defined as [explained here](https://docs.microsoft.com/aspnet/core/fundamentals/routing#route-templates).

[Headers](header-routing.md), [Authorization](authn-authz.md), [CORS](cors.md), and other route based policies can be configured on each route entry. For additional fields see [RouteConfig](xref:Yarp.ReverseProxy.Configuration.RouteConfig).

The proxy will apply the given matching criteria and policies, and then pass off the request to the specified cluster.

### Clusters
The clusters section is an unordered collection of named clusters. A cluster primarily contains a collection of named destinations and their addresses, any of which is considered capable of handling requests for a given route. The proxy will process the request according to the route and cluster configuration to select a destination.

For additional fields see [ClusterConfig](xref:Yarp.ReverseProxy.Configuration.ClusterConfig).

## In Memory Config

The `InMemoryConfigProvider` implements `IProxyConfigProvider` and enables specifying routes and clusters directly in code by calling `LoadFromMemory`.

```
services.AddReverseProxy().LoadFromMemory(routes, clusters);
```

To update the config later, resolve the `InMemoryConfigProvider` from the services container and call `Update` with the new lists of routes and clusters.

```
httpContext.RequestServices.GetRequiredService<InMemoryConfigProvider>().Update(routes, clusters);
```

## Lifecycle

### Startup
The `IProxyConfigProvider` should be registered in the DI container as a singleton. At startup, the proxy will resolve this instance and call `GetConfig()`. On this first call the provider may choose to:
- Throw an exception if the provider cannot produce a valid proxy configuration for any reason. This will prevent the application from starting.
- Synchronously block while it loads the configuration. This will block the application from starting until valid route data is available.
- Or, it may choose to return an empty `IProxyConfig` instance while it loads the configuration in the background. The provider will need to trigger the `IChangeToken` when the configuration is available.

The proxy will validate the given configuration and if it's invalid, an exception will be thrown that prevents the application from starting. The provider can avoid this by using the [IConfigValidator](xref:Yarp.ReverseProxy.Configuration.IConfigValidator) to pre-validate routes and clusters and take whatever action it deems appropriate such as excluding invalid entries.

### Atomicity
The configuration objects and collections supplied to the proxy should be read-only and not modified once they have been handed to the proxy via `GetConfig()`. 

### Reload
If the `IChangeToken` supports `ActiveChangeCallbacks`, once the proxy has processed the initial set of configurations it will register a callback with this token. If the provider does not support callbacks then `HasChanged` will be polled every 5 minutes.

When the provider wants to provide a new configuration to the proxy it should:
- load that configuration in the background. 
  - Route and cluster objects are immutable, so new instances have to be created for any new data.
  - Objects for unchanged routes and clusters can be re-used, or new instances can be created - changes will be detected by diffing them.
- optionally validate the configuration using the [IConfigValidator](xref:Yarp.ReverseProxy.Configuration.IConfigValidator), and only then signal the `IChangeToken` from the prior `IProxyConfig` instance that new data is available. The proxy will call `GetConfig()` again to retrieve the new data.

There are important differences when reloading configuration vs the first configuration load.
- The new configuration will be diffed against the current one and only modified routes or clusters will be updated. The update will be applied atomically and will only affect new requests, not requests currently in progress.
- Any errors in the reload process will be logged and suppressed. The application will continue using the last known good configuration.
- If `GetConfig()` throws the proxy will be unable to listen for future changes because `IChangeToken`s are single-use.

Once the new configuration has been validated and applied, the proxy will register a callback with the new `IChangeToken`. Note if there are multiple reloads signaled in close succession, the proxy may skip some and load the next available configuration as soon as it's ready. Each `IProxyConfig` contains the full configuration state so nothing will be lost.

## Multiple Configuration Sources
As of 1.1, YARP supports loading the proxy configuration from multiple sources. Multiple `IProxyConfigProvider`'s can be registered as singleton services and all will be resolved and combined. The sources may be the same or different types such as IConfiguration or InMemory. Routes can reference clusters from other sources. Note merging partial config from different sources for a given route or cluster is not supported.

```
    services.AddReverseProxy()
        .LoadFromConfig(Configuration.GetSection("ReverseProxy1"))
        .LoadFromConfig(Configuration.GetSection("ReverseProxy2"));
```
or
```
    services.AddReverseProxy()
        .LoadFromMemory(routes, clusters)
        .LoadFromConfig(Configuration.GetSection("ReverseProxy"));
```

## Example
The [InMemoryConfigProvider](https://github.com/microsoft/reverse-proxy/blob/main/src/ReverseProxy/Configuration/InMemoryConfigProvider.cs) gives an example of an `IProxyConfigProvider` that has routes and clusters manually loaded into it.
