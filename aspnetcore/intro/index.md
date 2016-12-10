---
title: Introduction to ASP.NET Core | Microsoft Docs
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 1837c35d-2c24-493f-acf4-a07bf7db9bd9
ms.technology: aspnet
ms.prod: aspnet-core
uid: intro
---
# Introduction to ASP.NET Core

By [Daniel Roth](https://github.com/danroth27), [Rick Anderson](https://twitter.com/RickAndMSFT) and [Shaun Luttin](https://twitter.com/dicshaunary)

ASP.NET Core is a significant redesign of ASP.NET. This topic introduces the new concepts in ASP.NET Core and explains how they help you develop modern web apps.

## What is ASP.NET Core?

ASP.NET Core is a new open-source and cross-platform framework for building modern cloud based internet connected applications, such as web apps, IoT apps and mobile backends. ASP.NET Core apps can run on [.NET Core](https://www.microsoft.com/net/core/platform) or on the full .NET Framework. It was architected to provide an optimized development framework for apps that are deployed to the cloud or run on-premises. It consists of modular components with minimal overhead, so you retain flexibility while constructing your solutions. You can develop and run your ASP.NET Core apps cross-platform on Windows, Mac and Linux. ASP.NET Core is open source at [GitHub](https://github.com/aspnet/home).

## Why build ASP.NET Core?

The first preview release of ASP.NET came out almost 15 years ago as part of the .NET Framework.  Since then millions of developers have used it to build and run great web apps, and over the years we have added and evolved many capabilities to it.

ASP.NET Core has a number of architectural changes that result in a much leaner and modular framework.  ASP.NET Core is no longer based on *System.Web.dll*. It is based on a set of granular and well factored [NuGet](http://www.nuget.org/) packages. This allows you to optimize your app to include just the NuGet packages you need. The benefits of a smaller app surface area include tighter security, reduced servicing, improved performance, and decreased costs in a pay-for-what-you-use model.

With ASP.NET Core you gain the following foundational improvements:

* A unified story for building web UI and web APIs

* Integration of [modern client-side frameworks](../client-side/index.md) and development workflows

* A cloud-ready environment-based [configuration system](../fundamentals/configuration.md)

* Built-in [dependency injection](../fundamentals/dependency-injection.md)

* New light-weight and modular HTTP request pipeline

* Ability to host on IIS or self-host in your own process

* Built on [.NET Core](https://microsoft.com/net/core), which supports true side-by-side app versioning

* Ships entirely as [NuGet](https://nuget.org)  packages

* New tooling that simplifies modern web development

* Build and run cross-platform ASP.NET apps on Windows, Mac and Linux

* Open source and community focused

## Build web UI and web APIs using ASP.NET Core MVC

* You can create well-factored and testable web apps that follow the Model-View-Controller (MVC) pattern. See [MVC](../mvc/index.md) and [Testing](../testing/index.md).

* You can build HTTP services that support multiple formats and have full support for content negotiation. See [Formatting Response Data](../mvc/models/formatting.md)

* [Razor](http://www.asp.net/web-pages/overview/getting-started/introducing-razor-syntax-c) provides a productive language to create [Views](../mvc/views/index.md)

* [Tag Helpers](../mvc/views/tag-helpers/intro.md) enable server-side code to participate in creating and rendering HTML elements in Razor files

* You can create HTTP services with full support for content negotiation using custom or built-in formatters (JSON, XML)

* [Model Binding](../mvc/models/model-binding.md) automatically maps data from HTTP requests to action method parameters

* [Model Validation](../mvc/models/validation.md) automatically performs client and server side validation

## Client-side development

ASP.NET Core is designed to integrate seamlessly with a variety of client-side frameworks, including [AngularJS](../client-side/angular.md), [KnockoutJS](../client-side/knockout.md) and [Bootstrap](../client-side/bootstrap.md). See [Client-Side Development](../client-side/index.md) for more details.

## Next steps

* [Building your first ASP.NET Core MVC app with Visual Studio](../tutorials/first-mvc-app/index.md)

* [Your First ASP.NET Core Application on a Mac Using Visual Studio Code](../tutorials/your-first-mac-aspnet.md)

* [Building Your First Web API with ASP.NET Core MVC and Visual Studio](../tutorials/first-web-api.md)

* [Fundamentals](../fundamentals/index.md)
