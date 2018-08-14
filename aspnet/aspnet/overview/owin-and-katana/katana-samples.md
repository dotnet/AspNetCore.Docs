---
uid: aspnet/overview/owin-and-katana/katana-samples
title: "Katana Samples | Microsoft Docs"
author: microsoft
description: ""
ms.author: riande
ms.date: 01/17/2014
ms.assetid: bec04f5d-2638-4417-b288-97c58c8d6379
msc.legacyurl: /aspnet/overview/owin-and-katana/katana-samples
msc.type: authoredcontent
---
Katana Samples
====================
by [Microsoft](https://github.com/microsoft)

## Katana Samples

**ASP.NET Routes Sample** | [Source Code](https://github.com/aspnet/samples/tree/master/samples/aspnet/Katana/AspNetRoutes)  
In some applications you will want to hook up OWIN components in the Asp.Net route table side by side with non-OWIN components. This sample shows how to use the RouteCollection extension methods MapOwinPath and MapOwinRoute provided by Microsoft.Owin.Host.SystemWeb.

**Branching Pipelines Sample** | [Source Code](https://github.com/aspnet/samples/tree/master/samples/aspnet/Katana/BranchingPipelines)  
OWIN request processing pipelines do not need to be linear, they can be branched to process requests in different ways. This sample shows how to construct a branching pipeline based on request paths or other request data such as headers. These components are available in the Microsoft.Owin.Mapping nuget package.

**Custom Server Sample** | [Source Code](https://github.com/aspnet/samples/tree/master/samples/aspnet/Katana/CustomServer)   
Shows how to use a custom OWIN server when self-hosting OWIN.

**Embedded Sample** | [Source Code](https://github.com/aspnet/samples/tree/master/samples/aspnet/Katana/Embedded)  
Some OWIN servers can be run inside of your own process (&quot;self-hosted&quot;). This sample shows how to start an OWIN application using the tools provided by the Microsoft.Owin.Hosting nuget package.

**HelloWorld Sample** | [Source Code](https://github.com/aspnet/samples/tree/master/samples/aspnet/Katana/HelloWorld)  
OWIN is a HTTP server API abstraction that enables application portability across various servers. This sample demonstrates how to write a Hello World application using some **simple wrappers** around the raw OWIN abstraction and run it on a web server like ASP.NET.

**Hello World Raw OWIN Sample** | [Source Code](https://github.com/aspnet/samples/tree/master/samples/aspnet/Katana/HelloWorldRawOwin)  
This sample demonstrates how to write a Hello World application using the **raw** OWIN abstraction and run it on a web server like Asp.Net.

**SignalR Sample** | [Source Code](https://github.com/aspnet/samples/tree/master/samples/aspnet/Katana/SignalR)  
Shows how to self-host SignalR using OWIN / Katana. For more info about self-hosting SignalR, see [Tutorial: SignalR Self-Host](../../../signalr/overview/deployment/tutorial-signalr-self-host.md).

**Static Files Sample** | [Source Code](https://github.com/aspnet/samples/tree/master/samples/aspnet/Katana/StaticFilesSample)   
Shows how to support HTTP requests for static files using OWIN / Katana.

**Web API** | [Source Code](https://github.com/aspnet/samples/tree/master/samples/aspnet/Katana/WebApi)   
This sample shows how to host OWIN in IIS and add Web API to the OWIN pipeline.

**Web Socket Sample** | [Source Code](https://github.com/aspnet/samples/tree/master/samples/aspnet/Katana/WebSocketSample)   
Shows how to support Web Sockets in OWIN by using the [System.Net.WebSockets.WebSocket](https://msdn.microsoft.com/library/system.net.websockets.websocket(v=vs.110).aspx) class.
