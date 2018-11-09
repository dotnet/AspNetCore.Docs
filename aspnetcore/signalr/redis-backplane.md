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

   A Redis backplane is the recommended approach for scaling out a SignalR app that uses on-premises infrastructure. To minimize latency, the Redis server should be in the same data center as the SignalR app. That's why these instructions assume you'll set up a Redis server for production rather than use Azure Redis Cache. If your SignalR app is running in the Azure cloud, we recommend Azure SignalR Service instead of a Redis backplane. For more information, see <xref:signalr/scale>.

2. In the SignalR app, install NuGet package `Microsoft.AspNetCore.SignalR.Redis` (for ASP.NET Core 2.1) or `Microsoft.AspNetCore.SignalR.StackExchangeRedis` (for ASP.NET Core 2.2).
 
3. In the `ConfigureServices` method, call `AddRedis` after `AddSignalR`:

   ```csharp
   services.AddSignalR().AddRedis(yourRedisConnectionString);
   ```

4. Configure options.
 
   Most options can be set in the connection string or in the `ConfigurationOptions` object. Options specified in `ConfigurationOptions` override the ones set in the connection string. For information about Redis options, see the [Redis documentation](https://redis.io/documentation).

5. If using one Redis server for multiple SignalR apps, use a different channel prefix for each SignalR app.

## High availability (HA) considerations

When a Redis server goes down, SignalR logs a warning that messages won't be delivered. SignalR doesn't buffer messages to send them when the server comes back up. Any messages sent while the Redis server is down are lost. SignalR automatically reconnects when the Redis server is available again.

You can write code to handle a Redis failure: 


Clustering is a method for using multiple Redis servers to support one app. We don't officially support clustering. It might work, but we haven't tested it.

## Next steps

For more information, see the following resources:

* <xref:signalr/scale>
* [Redis documentation](https://redis.io/documentation)
