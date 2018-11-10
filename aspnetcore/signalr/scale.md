---
title: ASP.NET Core SignalR production hosting and scaling
author: tdykstra
description: Learn how to set up ASP.NET Core SignalR in production to avoid performance and scaling problems.
monikerRange: '>= aspnetcore-2.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 11/12/2018
uid: signalr/scale
---

# ASP.NET Core SignalR hosting and scaling

By [Andrew Stanton-Nurse](https://twitter.com/anurse), [Brady Gaster](https://twitter.com/bradygaster), and [Tom Dykstra](https://github.com/tdykstra),

This article explains hosting and scaling considerations for high-traffic apps that use ASP.NET Core SignalR.

## TCP connection resources

The number of concurrent TCP connections that a web server can support is limited. Web apps use these limited resources efficiently, opening and closing a connection for every request and response. To support real-time functionality, SignalR keeps connections open. In a high-traffic app that serves many clients, this use of persistent connections can cause a server to reach its maximum number of connections much more quickly than a web app without SignalR. Persistent connections can cause high memory usage as well, since SignalR uses memory to track each connection.

The use of connection-related resources by SignalR affects other web apps that are hosted on the same server. When SignalR opens and holds the last available TCP connections, other web apps on the same server also have no more connections available to them. To keep SignalR connection usage from causing errors in web apps, we recommend that you run SignalR and web apps on separate servers.

When an app runs out of connections, an indication of that will be random socket errors and connection reset errors, for example:

```
An attempt was made to access a socket in a way forbidden by its access permissions...
```

The best way to solve the problem is to limit the number of connections a server has to handle by scaling out. 

## Scale out

Unlike a traditional stateless web app, you can't scale out a SignalR app simply by increasing the number of servers to handle increased traffic. The reason is the persistent connections that SignalR establishes between client and server.  When you add a server, it starts to get new SignalR connections, but SignalR on server A knows nothing about the connections on server B. When server A sends a message to all clients, it sends to clients connected to server A and misses the clients connected on server B. The following diagram illustrates this scenario.

![Scaling SignalR without a backplane](scale/_static/scale-no-backplane.png)

There are two recommended solutions to this problem: 

* Azure SignalR Service
* Redis backplane

There are no plans to implement a SQL Server backplane in ASP.NET Core SignalR. A SQL Server backplane is supported in ASP.NET SignalR, but SQL Server isn’t designed to handle the kind of real-time notifications SignalR needs, so it consumes a lot of resources on the database server.

## Azure SignalR Service

The Azure SignalR Service is a proxy rather than a backplane. Each time a client initiates a connection to the server, the client is redirected to connect to the service:

![Establishing a connection to the Azure SignalR Service](scale/_static/azure-signalr-service-one-connection.png)

The result is that the service manages all of the client connections, while each server needs only a small fixed number of connections to the service:

![Clients connected to the service, servers connected to the service](scale/_static/azure-signalr-service-multiple-connections.png)

This approach to scale-out has several advantages:

* The SignalR app can scale out without requiring sticky sessions, because clients are immediately redirected to the Azure service when they connect. Sticky sessions are required when a backplane such as the [Redis backplane](#redis-backplane) is used for scale-out.
* The SignalR app can scale out based on the number of messages sent, while the Azure service automatically scales to handle any number of connections. For example, there could be thousands of clients, but if only a few messages per second are sent, the SignalR app won't need to scale out to multiple servers.
* The SignalR app won't use up all of the available connections on a server, as the [TCP connection resources](#tcp-connection-resources) section explains could otherwise happen.

For these reasons, we recommend the Azure SignalR Service for all ASP.NET Core SignalR apps that run on Azure, including App Service, VMs, and containers.

For more information see the [Azure SignalR Service documentation](https://docs.microsoft.com/en-us/azure/azure-signalr/signalr-overview).

## Redis backplane

Redis is an in-memory key-value store. It also supports a messaging system with a publish/subscribe model. The SignalR Redis backplane uses the pub/sub feature to forward messages to other servers. In effect, when a client makes a connection, the connection information is passed to the backplane. Then when a server wants to send a message to all clients, it sends to the backplane. The backplane knows all connected clients and which servers they're on.  It sends the message to all clients via their respective servers. This process is illustrated in the following diagram:

![Redis backplane, message sent from one server to all clients](scale/_static/redis-backplane.png)

We recommend the Redis backplane as the scale-out approach for apps that run on on-premises infrastructure.  Azure SignalR Service is not practical for on-premises apps due to latency of a connection outside the data center.

Scale-out with the Redis backplane requires sticky sessions. Once a connection is initiated on a server, the connection has to stay on that server.

## Next steps

For more information, see the following resources:

* [Azure SignalR Service documentation](/azure/azure-signalr/signalr-overview)
* [Set up a Redis backplane](xref:signalr/redis-backplane)
