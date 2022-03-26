---
title: Redis backplane for ASP.NET Core SignalR scale-out
author: bradygaster
description: Learn how to set up a Redis backplane to enable scale-out for an ASP.NET Core SignalR app.
monikerRange: '>= aspnetcore-2.1'
ms.author: bradyg
ms.custom: mvc
ms.date: 11/12/2019
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: signalr/redis-backplane
---

# Set up a Redis backplane for ASP.NET Core SignalR scale-out

By [Andrew Stanton-Nurse](https://twitter.com/anurse), [Brady Gaster](https://twitter.com/bradygaster), and [Tom Dykstra](https://github.com/tdykstra),

This article explains SignalR-specific aspects of setting up a [Redis](https://redis.io/) server to use for scaling out an ASP.NET Core SignalR app.

## Set up a Redis backplane

* Deploy a Redis server.

  > [!IMPORTANT] 
  > For production use, a Redis backplane is recommended only when it runs in the same data center as the SignalR app. Otherwise, network latency degrades performance. If your SignalR app is running in the Azure cloud, we recommend Azure SignalR Service instead of a Redis backplane. 

  For more information, see the following resources:

  * <xref:signalr/scale>
  * [Redis documentation](https://redis.io/)
  * [Azure Redis Cache documentation](/azure/redis-cache/)

:::moniker range="= aspnetcore-2.1"

* In the SignalR app, install the `Microsoft.AspNetCore.SignalR.Redis` NuGet package.
* In the `Startup.ConfigureServices` method, call `AddRedis` after `AddSignalR`:

  ```csharp
  services.AddSignalR().AddRedis("<your_Redis_connection_string>");
  ```

* Configure options as needed:
 
  Most options can be set in the connection string or in the [ConfigurationOptions](https://stackexchange.github.io/StackExchange.Redis/Configuration#configuration-options) object. Options specified in `ConfigurationOptions` override the ones set in the connection string.

  The following example shows how to set options in the `ConfigurationOptions` object. This example adds a channel prefix so that multiple apps can share the same Redis instance, as explained in the following step.

  ```csharp
  services.AddSignalR()
    .AddRedis(connectionString, options => {
        options.Configuration.ChannelPrefix = "MyApp";
    });
  ```

  In the preceding code, `options.Configuration` is initialized with whatever was specified in the connection string.

:::moniker-end

:::moniker range="= aspnetcore-2.2"

* In the SignalR app, install one of the following NuGet packages:

  * `Microsoft.AspNetCore.SignalR.StackExchangeRedis` - Depends on StackExchange.Redis 2.X.X. This is the recommended package for ASP.NET Core 2.2 and later.
  * `Microsoft.AspNetCore.SignalR.Redis` - Depends on StackExchange.Redis 1.X.X. This package isn't included in ASP.NET Core 3.0 and later.

* In the `Startup.ConfigureServices` method, call <xref:Microsoft.Extensions.DependencyInjection.StackExchangeRedisDependencyInjectionExtensions.AddStackExchangeRedis*>:

  ```csharp
  services.AddSignalR().AddStackExchangeRedis("<your_Redis_connection_string>");
  ```

 When using `Microsoft.AspNetCore.SignalR.Redis`, call <xref:Microsoft.Extensions.DependencyInjection.RedisDependencyInjectionExtensions.AddRedis*>.

* Configure options as needed:
 
  Most options can be set in the connection string or in the [ConfigurationOptions](https://stackexchange.github.io/StackExchange.Redis/Configuration#configuration-options) object. Options specified in `ConfigurationOptions` override the ones set in the connection string.

  The following example shows how to set options in the `ConfigurationOptions` object. This example adds a channel prefix so that multiple apps can share the same Redis instance, as explained in the following step.

  ```csharp
  services.AddSignalR()
    .AddStackExchangeRedis(connectionString, options => {
        options.Configuration.ChannelPrefix = "MyApp";
    });
  ```

 When using `Microsoft.AspNetCore.SignalR.Redis`, call <xref:Microsoft.Extensions.DependencyInjection.RedisDependencyInjectionExtensions.AddRedis*>.

  In the preceding code, `options.Configuration` is initialized with whatever was specified in the connection string.

  For information about Redis options, see the [StackExchange Redis documentation](https://stackexchange.github.io/StackExchange.Redis/Configuration.html).

:::moniker-end

:::moniker range=">= aspnetcore-3.0"

* In the SignalR app, install the following NuGet package:

  * `Microsoft.AspNetCore.SignalR.StackExchangeRedis`
  
* In the `Startup.ConfigureServices` method, call <xref:Microsoft.Extensions.DependencyInjection.StackExchangeRedisDependencyInjectionExtensions.AddStackExchangeRedis*>:

  ```csharp
  services.AddSignalR().AddStackExchangeRedis("<your_Redis_connection_string>");
  ```
  
* Configure options as needed:
 
  Most options can be set in the connection string or in the [ConfigurationOptions](https://stackexchange.github.io/StackExchange.Redis/Configuration#configuration-options) object. Options specified in `ConfigurationOptions` override the ones set in the connection string.

  The following example shows how to set options in the `ConfigurationOptions` object. This example adds a channel prefix so that multiple apps can share the same Redis instance, as explained in the following step.

  ```csharp
  services.AddSignalR()
    .AddStackExchangeRedis(connectionString, options => {
        options.Configuration.ChannelPrefix = "MyApp";
    });
  ```

  In the preceding code, `options.Configuration` is initialized with whatever was specified in the connection string.

  For information about Redis options, see the [StackExchange Redis documentation](https://stackexchange.github.io/StackExchange.Redis/Configuration.html).

:::moniker-end

* If you're using one Redis server for multiple SignalR apps, use a different channel prefix for each SignalR app.

  Setting a channel prefix isolates one SignalR app from others that use different channel prefixes. If you don't assign different prefixes, a message sent from one app to all of its own clients will go to all clients of all apps that use the Redis server as a backplane.

* Configure your server farm load balancing software for sticky sessions. Here are some examples of documentation on how to do that:

  * [IIS](/iis/extensions/configuring-application-request-routing-arr/http-load-balancing-using-application-request-routing)
  * [HAProxy](https://www.haproxy.com/blog/load-balancing-affinity-persistence-sticky-sessions-what-you-need-to-know/)
  * [Nginx](https://docs.nginx.com/nginx/admin-guide/load-balancer/http-load-balancer/#sticky)

## Redis server errors

When a Redis server goes down, SignalR throws exceptions that indicate messages won't be delivered. Some typical exception messages:

* *Failed writing message*
* *Failed to invoke hub method 'MethodName'*
* *Connection to Redis failed*

SignalR doesn't buffer messages to send them when the server comes back up. Any messages sent while the Redis server is down are lost.

SignalR automatically reconnects when the Redis server is available again.

### Custom behavior for connection failures

Here's an example that shows how to handle Redis connection failure events.

:::moniker range="= aspnetcore-2.1"

```csharp
services.AddSignalR()
        .AddRedis(o =>
        {
            o.ConnectionFactory = async writer =>
            {
                var config = new ConfigurationOptions
                {
                    AbortOnConnectFail = false
                };
                config.EndPoints.Add(IPAddress.Loopback, 0);
                config.SetDefaultPorts();
                var connection = await ConnectionMultiplexer.ConnectAsync(config, writer);
                connection.ConnectionFailed += (_, e) =>
                {
                    Console.WriteLine("Connection to Redis failed.");
                };

                if (!connection.IsConnected)
                {
                    Console.WriteLine("Did not connect to Redis.");
                }

                return connection;
            };
        });
```

:::moniker-end

:::moniker range="> aspnetcore-2.1"

```csharp
services.AddSignalR()
        .AddMessagePackProtocol()
        .AddStackExchangeRedis(o =>
        {
            o.ConnectionFactory = async writer =>
            {
                var config = new ConfigurationOptions
                {
                    AbortOnConnectFail = false
                };
                config.EndPoints.Add(IPAddress.Loopback, 0);
                config.SetDefaultPorts();
                var connection = await ConnectionMultiplexer.ConnectAsync(config, writer);
                connection.ConnectionFailed += (_, e) =>
                {
                    Console.WriteLine("Connection to Redis failed.");
                };

                if (!connection.IsConnected)
                {
                    Console.WriteLine("Did not connect to Redis.");
                }

                return connection;
            };
        });
```

:::moniker-end

## Redis Clustering

[Redis Clustering](https://redis.io/topics/cluster-spec) is a method for achieving high availability by using multiple Redis servers. Clustering isn't officially supported, but it might work.

## Next steps

For more information, see the following resources:

* <xref:signalr/scale>
* [Redis documentation](https://redis.io/documentation)
* [StackExchange Redis documentation](https://stackexchange.github.io/StackExchange.Redis/)
* [Azure Redis Cache documentation](/azure/redis-cache/)
