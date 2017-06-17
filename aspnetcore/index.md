---
title: Introduction to ASP.NET Core | Microsoft Docs
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 06/15/2017
ms.topic: article
ms.assetid: 1c501638-114a-4cd3-ad39-0a5790b4e764
ms.technology: aspnet
ms.prod: asp.net-core
uid: index
---
# Introduction to ASP.NET Core

By [Daniel Roth](https://github.com/danroth27), [Rick Anderson](https://twitter.com/RickAndMSFT), and [Shaun Luttin](https://twitter.com/dicshaunary)

ASP.NET Core is a new [open-source](https://github.com/aspnet/home) and cross-platform framework for building modern cloud-based Internet-connected applications, such as web apps, IoT apps and mobile backends. It was architected to provide an optimized development framework for apps that are deployed to the cloud or run on-premises. It consists of modular components with minimal overhead, so you retain flexibility while constructing your solutions. You can develop and run ASP.NET Core apps on Windows, Mac and Linux. ASP.NET Core apps can [run on .NET Core or on the .NET Framework](https://docs.microsoft.com/dotnet/articles/standard/choosing-core-framework-server).

## Why use ASP.NET Core?

ASP.NET was released over 15 years ago. Millions of developers have used ASP.NET (and continue to use it) to create web apps. ASP.NET Core is a significant redesign of ASP.NET, with architectural changes that result in a leaner and modular framework.

ASP.NET Core is not based on *System.Web.dll*. It is based on a set of granular and well-factored [NuGet](http://www.nuget.org/) packages. This allows you to optimize your app to include just the NuGet packages you need. The benefits of a smaller app surface area include tighter security, reduced servicing, improved performance, and decreased costs in a *pay for what you use* model.

ASP.NET Core provides the following improvements compared to ASP.NET:

* A unified story for building web UI and web APIs.
* Integration of [modern client-side frameworks](client-side/index.md) and development workflows.
* A cloud-ready environment-based [configuration system](fundamentals/configuration.md).
* Built-in [dependency injection](fundamentals/dependency-injection.md).
* A light-weight and modular HTTP request pipeline.
* Ability to host on IIS or self-host in your own process.
* Built on [.NET Core](https://microsoft.com/net/core), which supports true side-by-side app versioning.
* Ships entirely as [NuGet](https://nuget.org)  packages.
* New tooling that simplifies modern web development.
* Build and run cross-platform ASP.NET Core apps on Windows, Mac, and Linux.
* Open-source and community-focused.

## Build web APIs and web UI using ASP.NET Core MVC

* Build HTTP services that reach a broad range of clients, including browsers and mobile devices. Support for [multiple data formats and content negotiation](mvc/models/formatting.md) is built-in. ASP.NET Core is an ideal platform for building web APIs and RESTful apps on .NET Core. See [Building web APIs](tutorials/index.md#building-web-apis).
* Create well-factored and testable web apps that follow the Model-View-Controller (MVC) pattern. See [MVC](mvc/index.md) and [Testing](testing/index.md).
* [Razor](http://www.asp.net/web-pages/overview/getting-started/introducing-razor-syntax-c) provides a productive language to create [Views](mvc/views/index.md).
* [Tag Helpers](mvc/views/tag-helpers/intro.md) enable server-side code to participate in creating and rendering HTML elements in Razor files.
* [Model Binding](mvc/models/model-binding.md) automatically maps data from HTTP requests to action method parameters.
* [Model Validation](mvc/models/validation.md) automatically performs client and server side validation.

## Client-side development

ASP.NET Core is designed to integrate seamlessly with a variety of client-side frameworks, including [AngularJS](client-side/angular.md), <!-- KO is no longer featured --> [KnockoutJS](client-side/knockout.md) and [Bootstrap](client-side/bootstrap.md). See [Client-Side Development](client-side/index.md) for more details.

## Next steps

For more information, see the following resources:

* [ASP.NET Core tutorials](tutorials/index.md)
* [ASP.NET Core fundamentals](fundamentals/index.md)
* [The weekly ASP.NET community standup](https://live.asp.net/) covers the team's progress and plans and features new blogs and third-party software.
