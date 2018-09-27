---
title: ASP.NET vs. ASP.NET Core
author: rick-anderson
description: Explains ASP.NET Core vs. ASP.NET and how to choose between them.
ms.author: riande
ms.date: 09/11/2018
uid: fundamentals/choose-between-aspnet-and-aspnetcore
---
# Choose between ASP.NET and ASP.NET Core

ASP.NET supports creating web apps for a wide variety of applications, including:

* Web apps targeting the cloud.
* Enterprise web apps targeting Windows Server.
* Small microservices targeting Linux containers.
* Rest applications and web APIs.

## ASP.NET Core

ASP.NET Core is an open-source, cross-platform framework for building modern, cloud-based web apps on Windows, macOS, or Linux.

## ASP.NET

ASP.NET is a mature framework that provides all the services needed to build enterprise-grade, server-based web apps on Windows.

## Framework selection

Review the table below to determine which framework is most appropriate for your needs.

| ASP.NET Core | ASP.NET |
|---|---|
|Build for Windows, macOS, or Linux|Build for Windows|
|[Razor Pages](xref:razor-pages/index) is the recommended approach to create a Web UI as of ASP.NET Core 2.x. See also [MVC](xref:mvc/overview), [Web API](xref:tutorials/first-web-api), and [SignalR](xref:signalr/introduction).|Use [Web Forms](/aspnet/web-forms), [SignalR](/aspnet/signalr), [MVC](/aspnet/mvc), [Web API](/aspnet/web-api/), [WebHooks](/aspnet/webhooks/), or [Web Pages](/aspnet/web-pages)|
|Multiple versions per machine|One version per machine|
|Develop with Visual Studio, [Visual Studio for Mac](https://www.visualstudio.com/vs/visual-studio-mac/), or [Visual Studio Code](https://code.visualstudio.com/) using C# or F#|Develop with Visual Studio using C#, VB, or F#|
|Higher performance than ASP.NET|Good performance|
|[Choose .NET Framework or .NET Core runtime](/dotnet/articles/standard/choosing-core-framework-server)|Use .NET Framework runtime|

## ASP.NET Core scenarios

* [Razor Pages](xref:razor-pages/index) is the recommended approach to create a Web UI as of ASP.NET Core 2.x.
* [Websites](xref:tutorials/first-mvc-app/index)
* [APIs](xref:tutorials/first-web-api)
* [Real-time](xref:signalr/index)
* [Deploy an ASP.NET Core app to Azure](/azure/app-service/app-service-web-get-started-dotnet)

## ASP.NET scenarios

* [Websites](/aspnet/mvc)
* [APIs](/aspnet/web-api)
* [Real-time](/aspnet/signalr)
* [Create an ASP.NET Framework web app in Azure](/azure/app-service/app-service-web-get-started-dotnet-framework)

## Resources

* [Introduction to ASP.NET](/aspnet/overview)
* [Introduction to ASP.NET Core](xref:index)
* <xref:aspnet/core/host-and-deploy/azure-apps>
