---
title: NCache backplane for ASP.NET Core SignalR scale-out
author: Brad Rehman
description: Learn how to set up an NCache backplane to enable scale-out for an ASP.NET Core SignalR app.
monikerRange: '>= aspnetcore-2.2'
ms.author: Brad Rehman
ms.custom: mvc
ms.date: 01/24/2020
no-loc: [SignalR]
uid: signalr/redis-backplane
---

# Set up an NCache backplane for ASP.NET Core SignalR scale-out

By [Brad Rehman](https://twitter.com/anurse),

This article explains SignalR-specific aspects of setting up an [NCache](https://redis.io/) clustered cache as a backplane to use for scaling out an ASP.NET Core SignalR app.

## Set up an NCache backplane

* Setup an NCach distributed cache.

  > [!IMPORTANT] 
  > For production use, an NCache backplane is recommended only when it runs in the same data center as the SignalR app. Otherwise, network latency degrades performance. If your SignalR app is running in the Azure cloud, we recommend Azure SignalR Service instead of a Redis backplane. You can use NCache for development and test environments.

  For more information, see the following resources:

  * <xref:signalr/scale>
  * [NCache documentation](https://www.alachisoft.com/resources/docs/)

::: moniker range="= aspnetcore-2.2"

NCache extends the [ISignalRServerBuilder](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.signalr.isignalrserverbuilder?view=aspnetcore-2.2) interface with its `AddNCache` method which requires just the cache name, event key and user credentials for the item added. This acts as the registration point for the clients against the ASP.NET Core SignalR implementation. 

::: moniker-end

::: moniker range="= aspnetcore-3.0"

NCache extends the [ISignalRServerBuilder](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.signalr.isignalrserverbuilder?view=aspnetcore-3.0) interface with its `AddNCache` method which requires just the cache name, event key and user credentials for the item added. This acts as the registration point for the clients against the ASP.NET Core SignalR implementation. 

::: moniker-end

::: moniker range="= aspnetcore-3.1"

NCache extends the [ISignalRServerBuilder](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.signalr.isignalrserverbuilder?view=aspnetcore-3.1) interface with its `AddNCache` method which requires just the cache name, event key and user credentials for the item added. This acts as the registration point for the clients against the ASP.NET Core SignalR implementation. 

::: moniker-end

Following are the steps to introduce NCache as a backplane in the SignalR app:

* In the SignalR app, install the `AspNetCore.SignalR.NCache` NuGet package.
* To utilize the extension, include the following namespaces in your application in Startup.cs:
  * `Alachisoft.NCache.AspNetCore.SignalR`
  * version 1.1.0 of `Microsoft.AspNetCore.SignalR`
* Add the following configurations in your `appsettings.json` file. You have to specify the cache name and the application ID along with the user credentials in `NCacheConfiguration`:

   ```csharp
   "NCacheConfiguration": {
       "CacheName": "demoClusteredCache",
       "ApplicationID": "chatApplication",
       "UserID": "your-username",
       "Password": "your-password"
   }
   ```
   
* In the `Startup.ConfigureServices` method, call `AddNCache` after `AddSignalR`:

  ```csharp
  services.AddSignalR().AddNCache(ncacheOptions => 
  {
        ncacheOptions.CacheName = Configuration["NCacheConfiguration:CacheName"];
        ncacheOptions.ApplicationID = Configuration["NCacheConfiguration:ApplicationID"];

        // In case of enabled cache security specify the security credentials
        ncacheOptions.UserID = Configuration["NCacheConfiguration:UserID"];
        ncacheOptions.Password = Configuration["NCacheConfiguration:Password"];
  }
  ```
  
* Configure options as needed:
 
  The parameters for configuring the NCache handle the SignalR app uses to connect with the NCache backplane are done via the [client.ncconf](https://www.alachisoft.com/resources/docs/ncache-pro/admin-guide/client-config.html) file that should be included in the final build. The relevant access parameters to include are the IP addresses and ports of the server(s) making up the distributed NCache backplane as well as configuration information such as connection retry interval, maximum number of connection attemps to make in case of disconnection etc. 

* If you're using one NCache distributed cache for multiple SignalR apps, use a different `ApplicationID` value of `NCacheConfiguration`for each SignalR app. Setting an `ApplicationID` isolates one SignalR app from others that use different values for `ApplicationID`. If you don't assign different values, a message sent from one app to all of its own clients will go to all clients of all apps that use the same NCache distributed cache as a backplane.

* Configure your server farm load balancing software for sticky sessions. Here are some examples of documentation on how to do that:

  * [IIS](/iis/extensions/configuring-application-request-routing-arr/http-load-balancing-using-application-request-routing)
  * [HAProxy](https://www.haproxy.com/blog/load-balancing-affinity-persistence-sticky-sessions-what-you-need-to-know/)
  * [Nginx](https://docs.nginx.com/nginx/admin-guide/load-balancer/http-load-balancer/#sticky)
  * [pfSense](https://www.netgate.com/docs/pfsense/loadbalancing/inbound-load-balancing.html#sticky-connections)

## NCache server errors

When a Redis server goes down, SignalR throws exceptions that indicate messages won't be delivered. Some typical exception messages:

* *Failed writing message*
* *Failed to invoke hub method 'MethodName'*
* *Connection to Redis failed*

SignalR doesn't buffer messages to send them when the server comes back up. Any messages sent while the Redis server is down are lost.

SignalR automatically reconnects when the Redis server is available again.

## Next steps

For more information, see the following resources:

* <xref:signalr/scale>
* [NCache documentation](https://www.alachisoft.com/resources/docs/)
* [NCache ASP.NET Core SignalR backplane](https://www.alachisoft.com/resources/docs/ncache/prog-guide/asp-net-core-signalr.html)
