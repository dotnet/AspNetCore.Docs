---
title: Host and deploy Blazor server-side
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

A web server capable of hosting an ASP.NET Core app is required. Visual Studio includes the **Blazor (server-side)** project template (`blazorserverside` template when using the [dotnet new](/dotnet/core/tools/dotnet-new) command).

## Connection scale out

Blazor server-side apps require one active SignalR connection for each user. A production Blazor server-side deployment requires a solution for supporting as many concurrent connections as required by the app. The [Azure SignalR Service](/azure/azure-signalr/) handles the scaling of connections and is recommended as a scaling solution for Blazor server-side apps. For more information, see <xref:signalr/publish-to-azure-web-app>.

## SignalR configuration

SignalR is configured by ASP.NET Core for the most common Blazor server-side scenarios. For custom and advanced scenarios, consult the SignalR articles in the [Additional resources](#additional-resources) section.

## Additional resources

* <xref:signalr/introduction>
* [Azure SignalR Service Documentation](/azure/azure-signalr/)
* [Quickstart: Create a chat room by using SignalR Service](/azure/azure-signalr/signalr-quickstart-dotnet-core)
* <xref:host-and-deploy/index>
* <xref:tutorials/publish-to-azure-webapp-using-vs>
* [Deploy ASP.NET Core preview release to Azure App Service](xref:host-and-deploy/azure-apps/index#deploy-aspnet-core-preview-release-to-azure-app-service)
