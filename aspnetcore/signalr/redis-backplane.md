---
title: Redis backplane for ASP.NET Core SignalR scale-out
author: tdykstra
description: Learn how to set up a Redis backplane to enable scale-out for an ASP.NET Core SignalR app.
monikerRange: '>= aspnetcore-2.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 11/12/2018
uid: signalr/redis-backplane
---

# Set up a Redis backplane for ASP.NET Core SignalR scale-out

By [Andrew Stanton-Nurse](https://twitter.com/anurse), [Brady Gaster](https://twitter.com/bradygaster), and [Tom Dykstra](https://github.com/tdykstra),

This article explains SignalR-specific aspects of setting up a Redis server to use for scaling out an ASP.NET Core SignalR app.

## Set up a Redis backplane

1. Deploy a Redis server.

   A Redis backplane is recommended only for on-premises infrastructure. That's why these instructions assume you'll set up a Redis server rather than use Azure Redis Cache. To minimize latency, the Redis server should be in the same data center as the SignalR app. If your SignalR app is running in the Azure cloud, we recommend Azure SignalR Service instead of a Redis backplane. For more information, see <xref:signalr/scale>.

2. In the SignalR app, install the appropriate NuGet package for the version of ASP.NET Core that your project targets:

   * 2.1: `Microsoft.AspNetCore.SignalR.Redis`
   * 2.2: `Microsoft.AspNetCore.SignalR.StackExchangeRedis`
 
3. In the `ConfigureServices` method, call `AddRedis` or `AddStackExchangeRedis` after `AddSignalR`:

   ```csharp
   services.AddSignalR().AddStackExchangeRedis(yourRedisConnectionString);
   ```

4. Configure options as needed:
 
   Most options can be set in the connection string or in the [ConfigurationOptions](https://stackexchange.github.io/StackExchange.Redis/Configuration#configuration-options) object. Options specified in `ConfigurationOptions` override the ones set in the connection string. 

  The following example shows how to set options in the `ConfigurationOptions` object. This example adds a channel prefix so that multiple apps can share the same Redis instance, as explained in the following step.

   ```csharp
   services.AddSignalR()
     .AddRedis(connectionString, options => {
         // NOTE: "options.Configuration" has been preloaded with 
         // whatever was specified in the connection string.
      
         options.Configuration.ChannelPrefix = "MyApp";
     });
   ```

   For information about Redis options, see the [Redis documentation](https://redis.io/documentation).

5. If you're using one Redis server for multiple SignalR apps, use a different channel prefix for each SignalR app.

   Setting a channel prefix isolates one SignalR app from others that use different channel prefixes. If you don't assign different prefixes, a message sent from one app to all clients will go to all clients of all apps that the Redis server suupports.

6. Configure your server farm load balancing software for sticky sessions. Here are some examples of documentation on how to do that:

   * [HAProxy](https://www.haproxy.com/blog/load-balancing-affinity-persistence-sticky-sessions-what-you-need-to-know/)
   * [Nginx](https://docs.nginx.com/nginx/admin-guide/load-balancer/http-load-balancer/#sticky)
   * [pfSense](https://www.netgate.com/docs/pfsense/loadbalancing/inbound-load-balancing.html#sticky-connections)

## Redis server errors

When a Redis server goes down, SignalR logs a warning that messages won't be delivered. The log message is "Failed writing message." SignalR doesn't buffer messages to send them when the server comes back up. Any messages sent while the Redis server is down are lost. SignalR automatically reconnects when the Redis server is available again.

Here is an example that shows how to handle a Redis connection failure: 

```csharp
services.AddSignalR()
        .AddMessagePackProtocol()
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

## Clustering

Clustering is a method for using multiple Redis servers to support one app. We don't officially support clustering. It might work, but we haven't tested it.

## Next steps

For more information, see the following resources:

* <xref:signalr/scale>
* [Redis documentation](https://redis.io/documentation)
