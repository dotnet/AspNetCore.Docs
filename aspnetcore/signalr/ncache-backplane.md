---
title: NCache backplane for ASP.NET Core SignalR scaleout
author: Obaid-Rehman
description: Learn how to set up an NCache backplane to enable scaleout for an ASP.NET Core SignalR app.
monikerRange: '>= aspnetcore-2.2'
ms.author: Brad Rehman
ms.custom: mvc
ms.date: 02/11/2020
no-loc: [SignalR]
uid: signalr/ncache-backplane
---

# Set up an NCache backplane for ASP.NET Core SignalR scaleout

By [Brad Rehman](https://github.com/Obaid-Rehman),

This article explains how you can set up an [NCache](https://www.alachisoft.com/ncache/) clustered cache made up of multiple servers, also referred to as nodes, as a backplane for scaling out ASP.NET Core SignalR in your app.

## Set up an NCache backplane

* Setup an NCach distributed cache.

  > [!IMPORTANT] 
  > For production use, an NCache backplane is recommended only when it runs in the same data center as the SignalR app. 

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

You can introduce NCache as a backplane in the SignalR app by taking the following steps:

* In the SignalR app, install the `AspNetCore.SignalR.NCache` NuGet package.
* To utilize the extension, include the following namespaces in your app in `Startup.cs`:
  * `Alachisoft.NCache.AspNetCore.SignalR`
  * `Microsoft.AspNetCore.SignalR` (version 1.1.0)
   
* In the `Startup.ConfigureServices` method, call `AddNCache` after `AddSignalR`:

  ```csharp
  services.AddSignalR().AddNCache(ncacheOptions => 
  {
	ncacheOptions.CacheName = "your-cache-id";
        ncacheOptions.ApplicationID = "your-application-id";

     // In case of enabled cache security specify the security credentials
	ncacheOptions.UserID = "your-user-id";
	ncacheOptions.Password = "your-user-password";

  }
  ```
  
* Configure options:
 
  The parameters for configuring the NCache client handle that the SignalR app uses to connect with the NCache backplane are done via the NCache client configuration file [**client.ncconf**](https://www.alachisoft.com/resources/docs/ncache-pro/admin-guide/client-config.html) that **must** be included in the final build. 
  
  The file contains parameters such as the id of the cache that will be used as the backplane, the IP addresses and ports of the server(s) constituting the backplane as well as client connection parameters that determine how the NCache client communicates with the cache servers.

* If you're using one NCache distributed cache for multiple SignalR apps, use a different `ApplicationID` value of the `NCacheConfiguration` class for each SignalR app. 

  Setting an `ApplicationID` secures one SignalR app from other SignalR apps that use different values for `ApplicationID` when sharing the same NCache backplane. If you don't assign different values, a message sent from one SignalR app to all of its own clients will go to all the clients of all the apps that use the same NCache distributed cache as a backplane.

* It is necessary to configure your web server farm load balancer to use sticky sessions as per the persistant connection needs of ASP.NET Core SignalR. Consult your load balancer documentation on how to achieve that.

## NCache backplane reliability

All NCache cluster [topologies](https://www.alachisoft.com/resources/docs/ncache/admin-guide/cache-topologies.html), except for the *Partitioned Cache* topology, ensure that messages are safe through replication in the event of a node failure. However, this is possible only if the cluster is made up of 2 or more servers.

## NCache backplane logging

Logging is an important aspect of any enterprise application. For that reason, NCache Backplane for SignalR utilizes the ASP.NET Core logging capabilities and provides the logging infrastructure packaged and ready for use. 

As such, you are free to use pre-shipped as well as 3rd-party logging providers such as [Serilog](https://github.com/serilog/serilog-aspnetcore) in your ASP.NET Core SignalR app to log the SignalR backplane operations at whatever log level e.g. debug, error, trace, and output the logs to multiple sinks including the console screen, file systems, databases etc. 

Some of the more frequent logs of interest include the connection and disconnection states, as well as message delivery failures.

## Next steps

For more information, see the following resources:

* <xref:signalr/scale>
* [NCache documentation](https://www.alachisoft.com/resources/docs/)
* [NCache ASP.NET Core SignalR backplane](https://www.alachisoft.com/resources/docs/ncache/prog-guide/asp-net-core-signalr.html)
