---
title: Host and deploy ASP.NET Core Blazor server-side
author: guardrex
description: Learn how to host and deploy a Blazor server-side app using ASP.NET Core.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 06/11/2019
uid: host-and-deploy/blazor/server-side
---
# Host and deploy Blazor server-side

By [Luke Latham](https://github.com/guardrex), [Rainer Stropek](https://www.timecockpit.com), and [Daniel Roth](https://github.com/danroth27)

## Host configuration values

Server-side apps that use the [server-side hosting model](xref:blazor/hosting-models#server-side) can accept [Generic Host configuration values](xref:fundamentals/host/generic-host#host-configuration).

## Deployment

With the [server-side hosting model](xref:blazor/hosting-models#server-side), Blazor is executed on the server from within an ASP.NET Core app. UI updates, event handling, and JavaScript calls are handled over a [SignalR](xref:signalr/introduction) connection.

A web server capable of hosting an ASP.NET Core app is required. Visual Studio includes the **Blazor Server App** project template (`blazorserverside` template when using the [dotnet new](/dotnet/core/tools/dotnet-new) command).

## Scalability

Planning for your deployment will help get the most out of the available infrastructure. It can avoid the perception of a slow or degraded service due to the infrastructure being overwhelmed.

With the [server-side hosting model](xref:blazor/hosting-models#server-side), Blazor is executed on the server from within an ASP.NET Core app. UI updates, event handling, and JavaScript calls are handled over a [SignalR](xref:signalr/introduction) connection. We reocmmend starting with the [fundamentals of Blazor Server app](xref:blazor/hosting-models#Server-side-Blazor-fundamentals)) to better understand how various parameters of your deployment target might affect your Blazor app.

### Selecting your deployment machine

When considering the scalability of a single machine (scale up), the memory available to your application is likely the resource the app is going to run out first. The available memory on the server affects the number of active circuits that a server can support, as well as the UI latency on the client. See <xref:blazor/best-practices> for some best practices for authoring scalable Blazor server apps.

As of writing this document, each circuit uses about 250kb of memory for a simple Hello World app. The size of a circuit depeneds on your application code, and how much state is associated with each component. We recommend measuring, but our baselines can be a starting point to your plan your deployment target. As an example, if you expect your application to support 5000 concurrent users, consider budgeting at least 1.3 GB of memory dedicated to you Blazor application.

### Configuring SignalR

Blazor Server app uses ASP.NET Core SignalR to communicate with the browser. SignalR's [hosting and scaling](xref:signalr/publish-to-azure-web-app) apply to your Blazor application.

Blazor works best when using WebSockets as the SignalR transport due to lower latency, reliability and [security](xref:signalr/security). Long polling is used by SignalR when WebSockets is not available, or when configured otherwise. When deploying to Azure App Service, remember to configure your application to use WebSockets. See Signal's publishing guidelines for detaills on configuring your application.

We highly recommend using [Azure SignalR Service](https://docs.microsoft.com/azure/azure-signalr) for your Blazor Server apps. The service will allow for both scaling up to a large number of concurrent SignalR connections. In addition, the SignalR service's global reach and high-performance data centers and network would significantly help in reducing latency due to geography.
