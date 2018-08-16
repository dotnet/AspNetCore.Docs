---
title: Host in ASP.NET Core
author: guardrex
description: Learn about the ASP.NET Core Web Host and .NET Generic Host, which are responsible for app startup and lifetime management.
ms.author: riande
ms.custom: mvc
ms.date: 05/16/2018
uid: fundamentals/host/index
---
# Host in ASP.NET Core

.NET apps configure and launch a *host*. The host is responsible for app startup and lifetime management. Two host APIs are available for use:

* [Web Host](xref:fundamentals/host/web-host) &ndash; Suitable for hosting web apps.
* [Generic Host](xref:fundamentals/host/generic-host) (ASP.NET Core 2.1 or later) &ndash; Suitable for hosting non-web apps (for example, apps that run background tasks). In a future release, the Generic Host will be suitable for hosting any kind of app, including web apps. The Generic Host will eventually replace the Web Host.

For hosting ASP.NET Core *web apps*, developers should use the Web Host based on [IWebHostBuilder](/dotnet/api/microsoft.aspnetcore.hosting.iwebhostbuilder). For hosting *non-web apps*, developers should use the Generic Host based on [HostBuilder](/dotnet/api/microsoft.extensions.hosting.hostbuilder).
