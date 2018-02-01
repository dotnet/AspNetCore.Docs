---
title: Introduction to ASP.NET Core
author: rick-anderson
description: Provides an introduction to ASP.NET Core.
manager: wpickett
ms.author: riande
ms.date: 12/12/2017
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: index
---
# Introduction to ASP.NET Core

By [Daniel Roth](https://github.com/danroth27), [Rick Anderson](https://twitter.com/RickAndMSFT), and [Shaun Luttin](https://twitter.com/dicshaunary)

ASP.NET Core is a cross-platform, high-performance, [open-source](https://github.com/aspnet/home) framework for building modern, cloud-based, Internet-connected applications. With ASP.NET Core, you can:

* Build web apps and services, [IoT](https://www.microsoft.com/internet-of-things/) apps, and mobile backends.
* Use your favorite development tools on Windows, macOS, and Linux.
* Deploy to the cloud or on-premises.
* Run on [.NET Core or .NET Framework](https://docs.microsoft.com/dotnet/articles/standard/choosing-core-framework-server).

## Why use ASP.NET Core?

Millions of developers have used (and continue to use) [ASP.NET 4.x](https://docs.microsoft.com/aspnet/overview) to create web apps. ASP.NET Core is a redesign of ASP.NET 4.x, with architectural changes that result in a leaner, more modular framework.

ASP.NET Core provides the following benefits:

* A unified story for building web UI and web APIs.
* Integration of [modern, client-side frameworks](xref:client-side/index) and development workflows.
* A cloud-ready, environment-based [configuration system](xref:fundamentals/configuration/index).
* Built-in [dependency injection](xref:fundamentals/dependency-injection).
* A lightweight, [high-performance](https://github.com/aspnet/benchmarks), and modular HTTP request pipeline.
* Ability to host on [IIS](xref:host-and-deploy/iis/index), [Nginx](xref:host-and-deploy/linux-nginx), [Apache](xref:host-and-deploy/linux-apache), [Docker](xref:host-and-deploy/docker/index), or self-host in your own process.
* Side-by-side app versioning when targeting [.NET Core](https://docs.microsoft.com/dotnet/articles/standard/choosing-core-framework-server).
* Tooling that simplifies modern web development.
* Ability to build and run on Windows, macOS, and Linux.
* Open-source and [community-focused](https://live.asp.net/).

ASP.NET Core ships entirely as [NuGet](https://www.nuget.org/) packages. This allows you to optimize your app to include only the necessary NuGet packages. In fact, ASP.NET Core 2.x apps targeting .NET Core only require a [single NuGet package](xref:fundamentals/metapackage). The benefits of a smaller app surface area include tighter security, reduced servicing, and improved performance.

## Build web APIs and web UI using ASP.NET Core MVC

ASP.NET Core MVC provides features to build [web APIs](xref:tutorials/index#build-web-apis) and [web apps](xref:tutorials/index#build-web-apps):

* The [Model-View-Controller (MVC) pattern](xref:mvc/overview) helps make your web APIs and web apps [testable](testing/index.md).
* [Razor Pages](xref:mvc/razor-pages/index) (new in ASP.NET Core 2.0) is a page-based programming model that makes building web UI easier and more productive.
* [Razor markup](xref:mvc/views/razor) provides a productive syntax for [Razor Pages](xref:mvc/razor-pages/index) and [MVC views](xref:mvc/views/overview).
* [Tag Helpers](xref:mvc/views/tag-helpers/intro) enable server-side code to participate in creating and rendering HTML elements in Razor files.
* Built-in support for [multiple data formats and content negotiation](mvc/models/formatting.md) lets your web APIs reach a broad range of clients, including browsers and mobile devices.
* [Model binding](xref:mvc/models/model-binding) automatically maps data from HTTP requests to action method parameters.
* [Model validation](xref:mvc/models/validation) automatically performs client- and server-side validation.

## Client-side development

ASP.NET Core integrates seamlessly with popular client-side frameworks and libraries, including [Angular](xref:spa/angular), [React](xref:spa/react), and [Bootstrap](xref:client-side/bootstrap). See [Client-side development](xref:client-side/index) for more details.

## Next steps

For more information, see the following resources:

* [Get started with Razor Pages](xref:tutorials/razor-pages/razor-pages-start)
* [ASP.NET Core tutorials](xref:tutorials/index)
* [ASP.NET Core fundamentals](xref:fundamentals/index)
* [The weekly ASP.NET community standup](https://live.asp.net/) covers the team's progress and plans. It features new blogs and third-party software.
