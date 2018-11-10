---
title: Introduction to ASP.NET Core
author: rick-anderson
description: Get an introduction to ASP.NET Core, a cross-platform, high-performance, open-source framework for building modern, cloud-based, Internet-connected applications.
ms.author: riande
ms.custom: mvc
ms.date: 11/10/2018
uid: index
---
# Introduction to ASP.NET Core

By [Daniel Roth](https://github.com/danroth27), [Rick Anderson](https://twitter.com/RickAndMSFT), and [Shaun Luttin](https://twitter.com/dicshaunary)

ASP.NET Core is a cross-platform, high-performance, [open-source](https://github.com/aspnet/home) framework for building modern, cloud-based, Internet-connected applications. With ASP.NET Core, you can:

* Build web apps and services, [IoT](https://www.microsoft.com/internet-of-things/) apps, and mobile backends.
* Use your favorite development tools on Windows, macOS, and Linux.
* Deploy to the cloud or on-premises.
* Run on [.NET Core or .NET Framework](/dotnet/articles/standard/choosing-core-framework-server).

## Why use ASP.NET Core?

Millions of developers have used (and continue to use) [ASP.NET 4.x](/aspnet/overview) to create web apps. ASP.NET Core is a redesign of ASP.NET 4.x, with architectural changes that result in a leaner, more modular framework.

[!INCLUDE[](~/includes/benefits.md)]

## Build web APIs and web UI using ASP.NET Core MVC

ASP.NET Core MVC provides features to build [web APIs](xref:tutorials/first-web-api) and [web apps](xref:tutorials/razor-pages/index):

* The [Model-View-Controller (MVC) pattern](xref:mvc/overview) helps make your web APIs and web apps testable.
* [Razor Pages](xref:razor-pages/index) (new in ASP.NET Core 2.0) is a page-based programming model that makes building web UI easier and more productive.
* [Razor markup](xref:mvc/views/razor) provides a productive syntax for [Razor Pages](xref:razor-pages/index) and [MVC views](xref:mvc/views/overview).
* [Tag Helpers](xref:mvc/views/tag-helpers/intro) enable server-side code to participate in creating and rendering HTML elements in Razor files.
* Built-in support for [multiple data formats and content negotiation](xref:web-api/advanced/formatting) lets your web APIs reach a broad range of clients, including browsers and mobile devices.
* [Model binding](xref:mvc/models/model-binding) automatically maps data from HTTP requests to action method parameters.
* [Model validation](xref:mvc/models/validation) automatically performs client-side and server-side validation.

## Client-side development

ASP.NET Core integrates seamlessly with popular client-side frameworks and libraries, including [Angular](xref:spa/angular), [React](xref:spa/react), and [Bootstrap](https://getbootstrap.com/). For more information, see [Client-side development](xref:client-side/index).

<a name="target-framework"></a>

## ASP.NET Core targeting .NET Framework

ASP.NET Core 2.x can target .NET Core or .NET Framework. ASP.NET Core apps targeting .NET Framework aren't cross-platform&mdash;they run on Windows only. Generally, ASP.NET Core 2.x is made up of [.NET Standard](/dotnet/standard/net-standard) libraries. Apps written with .NET Standard 2.0 run anywhere that .NET Standard 2.0 is supported.

ASP.NET Core 2.x is supported on .NET Framework versions compatible with .NET Standard 2.0:

* .NET Framework 4.7.1 and later is strongly recommended.
* .NET Framework 4.6.1 and later.

ASP.NET Core 3.0 and later will only run on .NET Core. For more details regarding this change, see [A first look at changes coming in ASP.NET Core 3.0](https://blogs.msdn.microsoft.com/webdev/2018/10/29/a-first-look-at-changes-coming-in-asp-net-core-3-0/).

There are several advantages to targeting .NET Core, and these advantages increase with each release. Some advantages of .NET Core over .NET Framework include:

* Cross-platform. Runs on macOS, Linux, and Windows.
* Improved performance
* Side-by-side versioning
* New APIs
* Open source

We're working hard to close the API gap from .NET Framework to .NET Core. The [Windows Compatibility Pack](/dotnet/core/porting/windows-compat-pack) made thousands of Windows-only APIs available in .NET Core. These APIs weren't available in .NET Core 1.x.

## How to download a sample

Many of the articles and tutorials include links to sample code.

1. [Download the ASP.NET repository zip file](https://codeload.github.com/aspnet/Docs/zip/master).
1. Unzip the *Docs-master.zip* file.
1. Use the URL in the sample link to help you navigate to the sample directory.

To demonstrate multiple scenarios, sample apps make use of the [&num;define] and [&num;if-&num;else/&num;elif-&num;end-if](/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-if) C&num; statements to selectively compile and run different sections of sample code. For those samples that make use of this approach, set the `#define` statement at the top of the C&num; files to the symbol associated with the scenario that you want to run. A sample may require you to set the symbol at the top of multiple files in order to run a scenario.

For example, the following `#define` symbol list indicates that four scenarios are available (one scenario per symbol). The current sample configuration runs the `TemplateCode` scenario:

```csharp
#define TemplateCode // or LogFromMain or ExpandDefault or FilterInCode
```

To change the sample to run the `ExpandDefault` scenario, define the `ExpandDefault` symbol and leave the remaining symbols commented-out:

```csharp
#define ExpandDefault // TemplateCode or LogFromMain or FilterInCode
```

For more information on using [C&num; preprocessor directives](/dotnet/csharp/language-reference/preprocessor-directives/) to selectively compile sections of code, see [&num;define (C&num; Reference)](/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-define) and [&num;if (C&num; Reference)](/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-if).

## Next steps

For more information, see the following resources:

* [Get started with Razor Pages](xref:tutorials/razor-pages/razor-pages-start)
* <xref:tutorials/publish-to-azure-webapp-using-vs>
* [ASP.NET Core fundamentals](xref:fundamentals/index)
* [The weekly ASP.NET community standup](https://live.asp.net/) covers the team's progress and plans. It features new blogs and third-party software.
