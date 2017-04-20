---
uid: signalr/overview/older-versions/mapping-users-to-connections
title: "Mapping SignalR Users to Connections in SignalR 1.x | Microsoft Docs"
author: pfletcher
description: "This topic shows how to retain information about users and their connections."
ms.author: aspnetcontent
manager: wpickett
ms.date: 10/17/2013
ms.topic: article
ms.assetid: ebbc93a8-e6c4-4122-8e0d-3aa42293c747
ms.technology: dotnet-signalr
ms.prod: .net-framework
msc.legacyurl: /signalr/overview/older-versions/mapping-users-to-connections
msc.type: authoredcontent
---
Mapping SignalR Users to Connections in SignalR 1.x
====================
by [Patrick Fletcher](https://github.com/pfletcher), [Tom FitzMacken](https://github.com/tfitzmac)

> This topic shows how to retain information about users and their connections.


## Introduction

Each client connecting to a hub passes a unique connection id. You can retrieve this value in the `Context.ConnectionId` property of the hub context. If your application needs to map a user to the connection id and persist that mapping, you can use one of the following:

- [In-memory storage](#inmemory), such as a dictionary
- [SignalR group for each user](#groups)
- [Permanent, external storage](#database), such as a database table or Azure table storage

Each of these implementations is shown in this topic. You use the `OnConnected`, `OnDisconnected`, and `OnReconnected` methods of the `Hub` class to track the user connection status.

The best approach for your application depends on:

- The number of web servers hosting your application.
- Whether you need to get a list of the currently connected users.
- Whether you need to persist group and user information when the application or server restarts.
- Whether the latency of calling an external server is an issue.

The following table shows which approach works for these considerations.

|  | More than one server | Get list of currently connected users | Persist information after restarts | Optimal performance |
| --- | --- | --- | --- | --- |
| In-memory |  | ![](mapping-users-to-connections/_static/image1.png) |  | ![](mapping-users-to-connections/_static/image2.png) |
| Single-user groups | ![](mapping-users-to-connections/_static/image3.png) |  |  | ![](mapping-users-to-connections/_static/image4.png) |
| Permanent, external | ![](mapping-users-to-connections/_static/image5.png) | ![](mapping-users-to-connections/_static/image6.png) | ![](mapping-users-to-connections/_static/image7.png) |  |

<a id="inmemory"></a>

## In-memory storage

The following examples show how to retain connection and user information in a dictionary that is stored in memory. The dictionary uses a `HashSet` to store the connection id. At any time a user could have more than one connection to the SignalR application. For example, a user who is connected through multiple devices or more than one browser tab would have more than one connection id.

If the application shuts down, all of the information is lost, but it will be re-populated as the users re-establish their connections. In-memory storage does not work if your environment includes more than one web server because each server would have a separate collection of connections.

The first example shows a class that manages the mapping of users to connections. The key for the HashSet will be the user's name.

[!code-csharp[Main](mapping-users-to-connections/samples/sample1.cs)]

The next example shows how to use the connection mapping class from a hub. The instance of the class is stored in a variable name `_connections`.

[!code-csharp[Main](mapping-users-to-connections/samples/sample2.cs)]

<a id="groups"></a>

## Single-user groups

You can create a group for each user, and then send a message to that group when you want to reach only that user. The name of each group is the name of the user. If a user has more than one connection, each connection id is added to the user's group.

You should not manually remove the user from the group when the user disconnects. This action is automatically performed by the SignalR framework.

The following example shows how to implement single-user groups.

[!code-csharp[Main](mapping-users-to-connections/samples/sample3.cs)]

<a id="database"></a>

## Permanent, external storage

This topic shows how to use either a database or Azure table storage for storing connection information. This approach works when you have multiple web servers because each web server can interact with the same data repository. If your web servers stop working or the application restarts, the `OnDisconnected` method is not called. Therefore, it is possible that your data repository will have records for connection ids that are no longer valid. To clean up these orphaned records, you may wish to invalidate any connection that was created outside of a timeframe that is relevant to your application. The examples in this section include a value for tracking when the connection was created, but do not show how to clean up old records because you may want to do that as background process.

### Database

The following examples show how to retain connection and user information in a database. You can use any data access technology; however, the example below shows how to define models using Entity Framework. These entity models correspond to database tables and fields. Your data structure could vary considerably depending on the requirements of your application.

The first example shows how to define a user entity that can be associated with many connection entities.

[!code-csharp[Main](mapping-users-to-connections/samples/sample4.cs)]

Then, from the hub, you can track the state of each connection with the code shown below.

[!code-csharp[Main](mapping-users-to-connections/samples/sample5.cs)]

### Azure table storage

The following Azure table storage example is similar to the database example. It does not include all of the information that you would need to get started with Azure Table Storage Service. For information, see [How to use Table storage from .NET](https://azure.microsoft.com/en-us/documentation/articles/storage-dotnet-how-to-use-tables/).

The following example shows a table entity for storing connection information. It partitions the data by user name, and identifies each entity by the connection id, so a user can have multiple connections at any time.

[!code-csharp[Main](mapping-users-to-connections/samples/sample6.cs)]

In the hub, you track the status of each user's connection.

[!code-csharp[Main](mapping-users-to-connections/samples/sample7.cs)]