---
title: Choose between ASP.NET 4.x and ASP.NET Core
author: rick-anderson
description: Explains ASP.NET Core vs. ASP.NET 4.x and how to choose between them.
ms.author: riande
ms.custom: "mvc, seodec18"
ms.date: 02/12/2020
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: fundamentals/choose-between-aspnet-and-aspnetcore
---
# Choose between ASP.NET 4.x and ASP.NET Core

ASP.NET Core is a redesign of ASP.NET 4.x. This article lists the differences between them.

## ASP.NET Core

ASP.NET Core is an open-source, cross-platform framework for building modern, cloud-based web apps on Windows, macOS, or Linux.

[!INCLUDE[](~/includes/benefits.md)]

## ASP.NET 4.x

ASP.NET 4.x is a mature framework that provides the services needed to build enterprise-grade, server-based web apps on Windows.

## Framework selection

The following table compares ASP.NET Core to ASP.NET 4.x.

| ASP.NET Core | ASP.NET 4.x |
|---|---|
|Build for Windows, macOS, or Linux|Build for Windows|
|[Razor Pages](xref:razor-pages/index) is the recommended approach to create a Web UI as of ASP.NET Core 2.x. See also [MVC](xref:mvc/overview), [Web API](xref:tutorials/first-web-api), and [SignalR](xref:signalr/introduction).|Use [Web Forms](/aspnet/web-forms), [SignalR](/aspnet/signalr), [MVC](/aspnet/mvc), [Web API](/aspnet/web-api/), [WebHooks](/aspnet/webhooks/), or [Web Pages](/aspnet/web-pages)|
|Multiple versions per machine|One version per machine|
|Develop with [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/), or [Visual Studio Code](https://code.visualstudio.com/) using C# or F#|Develop with [Visual Studio](https://visualstudio.microsoft.com/vs/) using C#, VB, or F#|
|Higher performance than ASP.NET 4.x|Good performance|
|[Use .NET Core runtime](/dotnet/standard/choosing-core-framework-server)|Use .NET Framework runtime|

See [ASP.NET Core targeting .NET Framework](xref:index#target-framework) for information on ASP.NET Core 2.x support on .NET Framework.

## ASP.NET Core scenarios

* [Websites](xref:tutorials/first-mvc-app/start-mvc)
* [APIs](xref:tutorials/first-web-api)
* [Real-time](xref:signalr/introduction)
* [Deploy an ASP.NET Core app to Azure](/azure/app-service/app-service-web-get-started-dotnet)

## ASP.NET 4.x scenarios

* [Websites](/aspnet/mvc)
* [APIs](/aspnet/web-api)
* [Real-time](/aspnet/signalr)
* [Create an ASP.NET 4.x web app in Azure](/azure/app-service/app-service-web-get-started-dotnet-framework)

## Additional resources

* [Introduction to ASP.NET](/aspnet/overview)
* [Introduction to ASP.NET Core](xref:index)
* <xref:host-and-deploy/azure-apps/index>
