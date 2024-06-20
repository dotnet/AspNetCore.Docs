---
title: Redis backplane for ASP.NET Core SignalR scale-out
author: bradygaster
description: Learn how to set up a Redis backplane to enable scale-out for an ASP.NET Core SignalR app.
monikerRange: '>= aspnetcore-2.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 02/06/2024
uid: signalr/redis-backplane
---

# Set up a Redis backplane for ASP.NET Core SignalR scale-out

By [Andrew Stanton-Nurse](https://twitter.com/anurse), [Brady Gaster](https://twitter.com/bradygaster), and [Tom Dykstra](https://github.com/tdykstra).

:::moniker range=">= aspnetcore-8.0"

This article explains SignalR-specific aspects of setting up a [Redis](https://redis.io/) server to use for scaling out an ASP.NET Core SignalR app.

## Set up a Redis backplane

* Deploy a Redis server.

  > [!IMPORTANT]
  > For production use, a Redis backplane is recommended only when it runs in the same data center as the SignalR app. Otherwise, network latency degrades performance. If your SignalR app is running in the Azure cloud, we recommend Azure SignalR Service instead of a Redis backplane.

  For more information, see the following resources:

  * <xref:signalr/scale>
  * [Redis documentation](https://redis.io/)
  * [Azure Redis Cache documentation](/azure/redis-cache/)

* In the SignalR app, install the following NuGet package:

  * `Microsoft.AspNetCore.SignalR.StackExchangeRedis`
  
* Call <xref:Microsoft.Extensions.DependencyInjection.StackExchangeRedisDependencyInjectionExtensions.AddStackExchangeRedis*> by adding the following line before the line that calls `builder.Build()`) in the `Program.cs` file.

  ```csharp
  builder.Services.AddSignalR().AddStackExchangeRedis("<your_Redis_connection_string>");
  ```
  
* Configure options as needed:

  Most options can be set in the connection string or in the [`ConfigurationOptions`](https://stackexchange.github.io/StackExchange.Redis/Configuration#configuration-options) object. Options specified in `ConfigurationOptions` override the ones set in the connection string.

  The following example shows how to set options in the `ConfigurationOptions` object. This example adds a channel prefix so that multiple apps can share the same Redis instance, as explained in the following step.

  ```csharp
  builder.Services.AddSignalR()
    .AddStackExchangeRedis(connectionString, options => {
        options.Configuration.ChannelPrefix = RedisChannel.Literal("MyApp");
    });
  ```

  In the preceding code, `options.Configuration` is initialized with whatever was specified in the connection string.

  For information about Redis options, see the [StackExchange Redis documentation](https://stackexchange.github.io/StackExchange.Redis/Configuration.html).

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

## Redis Cluster

[Redis Cluster](https://redis.io/topics/cluster-spec) utilizes multiple simultaneously active Redis servers to achieve high availability. When Redis Cluster is used as the backplane for SignalR, messages are delivered to all of the nodes of the cluster without code modifications to the app.

There's a tradeoff between the number of nodes in the cluster and the throughput of the backplane. Increasing the number of nodes increases the availability of the cluster but decreases the throughput because messages must be transmitted to all of the nodes in the cluster.

In the SignalR app, include all of the possible Redis nodes using either of the following approaches:

* List the nodes in the connection string delimited with commas.
* If using custom behavior for connection failures, add the nodes to [`ConfigurationOptions.Endpoints`](https://stackexchange.github.io/StackExchange.Redis/Configuration#configuration-options).

## Next steps

For more information, see the following resources:

* <xref:signalr/scale>
* [Redis documentation](https://redis.io/documentation)
* [StackExchange Redis documentation](https://stackexchange.github.io/StackExchange.Redis/)
* [Azure Redis Cache documentation](/azure/redis-cache/)

:::moniker-end

[!INCLUDE[](~/signalr/redis-backplane/includes/redis-backplane7.md)]

[!INCLUDE[](~/signalr/redis-backplane/includes/redis-backplane6.md)]

[!INCLUDE[](~/signalr/redis-backplane/includes/redis-backplane5.md)]

[!INCLUDE[](~/signalr/redis-backplane/includes/redis-backplane3.md)]

[!INCLUDE[](~/signalr/redis-backplane/includes/redis-backplane2.2.md)]

[!INCLUDE[](~/signalr/redis-backplane/includes/redis-backplane2.1.md)]
