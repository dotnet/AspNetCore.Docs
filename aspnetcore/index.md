---
title: Introduction to ASP.NET Core
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 08/03/2017
ms.topic: article
ms.assetid: 1c501638-114a-4cd3-ad39-0a5790b4e764
ms.technology: aspnet
ms.prod: asp.net-core
uid: index
---
# Introduction to ASP.NET Core

By [Daniel Roth](https://github.com/danroth27), [Rick Anderson](https://twitter.com/RickAndMSFT), and [Shaun Luttin](https://twitter.com/dicshaunary)

ASP.NET Core is a cross-platform, high-performance, [open-source](https://github.com/aspnet/home) framework for building modern, cloud-based, Internet-connected applications. With ASP.NET Core, you can:

* Build web apps and services, IoT apps, and mobile backends.
* Use your favorite development tools on Windows, Mac, and Linux.
* Deploy to the cloud or on-premises
* Run on [.NET Core or the .NET Framework](https://docs.microsoft.com/dotnet/articles/standard/choosing-core-framework-server).

## Why use ASP.NET Core?

ASP.NET was released over 15 years ago. Millions of developers have used ASP.NET (and continue to use it) to create web apps. ASP.NET Core is a redesign of ASP.NET, with architectural changes that result in a leaner and modular framework.

ASP.NET Core provides the following improvements compared to ASP.NET:

* A unified story for building web UI and web APIs.
* Integration of [modern client-side frameworks](client-side/index.md) and development workflows.
* A cloud-ready environment-based [configuration system](fundamentals/configuration.md).
* Built-in [dependency injection](fundamentals/dependency-injection.md).
* A lightweight, high-performance, and modular HTTP request pipeline.
* Ability to host on IIS or self-host in your own process.
* Can run on [.NET Core](https://docs.microsoft.com/dotnet/articles/standard/choosing-core-framework-server), which supports true side-by-side app versioning.
* Tooling that simplifies modern web development.
* Ability to build and run on Windows, Mac, and Linux.
* Open-source and community-focused.

ASP.NET Core ships entirely as [NuGet](https://nuget.org) packages. This allows you to optimize your app to include just the NuGet packages you need. The benefits of a smaller app surface area include tighter security, reduced servicing, improved performance.

## Build web APIs and web UI using ASP.NET Core MVC

ASP.NET Core MVC provides features that help you build [web APIs](xref:tutorials/index#building-web-apis) and [web apps](xref:tutorials/index#building-web-applications):

* Built-in support for [multiple data formats and content negotiation](mvc/models/formatting.md) lets your web APIs reach a broad range of clients, including browsers and mobile devices.
* The [Model-View-Controller (MVC) pattern](xref:mvc/overview) helps make your apps [testable](testing/index.md).
* [Razor Pages](xref:mvc/razor-pages/index) is a new feature in ASP.NET 2.0 that makes building web page UI easier and more productive.
* [Razor syntax](xref:mvc/views/razor) provides a productive language for Razor pages and [MVC Views](xref:mvc/views/index).
* [Tag Helpers](xref:mvc/views/tag-helpers/intro) enable server-side code to participate in creating and rendering HTML elements in Razor files.
* [Model Binding](xref:mvc/models/model-binding) automatically maps data from HTTP requests to action method parameters.
* [Model Validation](xref:mvc/models/validation) automatically performs client and server-side validation.

## Client-side development

ASP.NET Core is designed to integrate seamlessly with a variety of client-side frameworks, including [AngularJS](xref:client-side/angular), [KnockoutJS](xref:client-side/knockout), and [Bootstrap](xref:client-side/bootstrap). See [Client-side development](xref:client-side/index) for more details.

## Next steps

For more information, see the following resources:

* [ASP.NET Core tutorials](xref:tutorials/index)
* [ASP.NET Core fundamentals](xref:fundamentals/index)
* [The weekly ASP.NET community standup](https://live.asp.net/) covers the team's progress and plans and features new blogs and third-party software.
