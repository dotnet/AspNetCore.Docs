---
uid: signalr/overview/security/persistent-connection-authorization
title: "Authentication and Authorization for SignalR Persistent Connections | Microsoft Docs"
author: pfletcher
description: "This topic describes how to enforce authorization on a persistent connection. For general information about integrating security into a SignalR application,..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 06/10/2014
ms.topic: article
ms.assetid: e264677b-9c01-47ec-94f9-3cd8f08f94af
ms.technology: dotnet-signalr
ms.prod: .net-framework
msc.legacyurl: /signalr/overview/security/persistent-connection-authorization
msc.type: authoredcontent
---
Authentication and Authorization for SignalR Persistent Connections
====================
by [Patrick Fletcher](https://github.com/pfletcher), [Tom FitzMacken](https://github.com/tfitzmac)

> This topic describes how to enforce authorization on a persistent connection. For general information about integrating security into a SignalR application, see [Introduction to Security](introduction-to-security.md). 
> 
> ## Software versions used in this topic
> 
> 
> - [Visual Studio 2013](https://www.microsoft.com/visualstudio/eng/2013-downloads)
> - .NET 4.5
> - SignalR version 2
>   
> 
> 
> ## Previous versions of this topic
> 
> For information about earlier versions of SignalR, see [SignalR Older Versions](../older-versions/index.md).
> 
> ## Questions and comments
> 
> Please leave feedback on how you liked this tutorial and what we could improve in the comments at the bottom of the page. If you have questions that are not directly related to the tutorial, you can post them to the [ASP.NET SignalR forum](https://forums.asp.net/1254.aspx/1?ASP+NET+SignalR) or [StackOverflow.com](http://stackoverflow.com/).


## Enforce authorization

To enforce authorization rules when using a [PersistentConnection](https://msdn.microsoft.com/en-us/library/microsoft.aspnet.signalr.persistentconnection(v=vs.111).aspx) you must override the `AuthorizeRequest` method. You cannot use the `Authorize` attribute with persistent connections. The `AuthorizeRequest` method is called by the SignalR Framework before every request to verify that the user is authorized to perform the requested action. The `AuthorizeRequest` method is not called from the client; instead, you authenticate the user through your application's standard authentication mechanism.

The example below shows how to limit requests to authenticated users.

[!code-csharp[Main](persistent-connection-authorization/samples/sample1.cs)]

You can add any customized authorization logic in the AuthorizeRequest method; such as, checking whether a user belongs to a particular role.