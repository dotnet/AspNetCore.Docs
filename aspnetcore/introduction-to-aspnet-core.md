---
title: Overview of ASP.NET Core
author: tdykstra
description: Get an overview of ASP.NET Core, a cross-platform, high-performance, open-source framework for building modern, cloud-enabled, Internet-connected apps.
ms.author: tdykstra
ms.custom: mvc
ms.date: 07/23/2025
uid: index
---
# Overview of ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

ASP.NET Core is a cross-platform, high-performance, open-source framework for building modern web apps. It is built for large-scale app development and can handle any size workload, making it a robust choice for enterprise-level apps.

[!INCLUDE[](~/includes/benefits.md)]

## Build web apps and web APIs

Use ASP.NET Core to build web apps with:

:::moniker range=">= aspnetcore-6.0"

* [Blazor](xref:blazor/index), a component-based web UI framework based on C# that supports both server-side rendering via the .NET runtime and client-side rendering via WebAssembly.
* [Minimal APIs](xref:fundamentals/minimal-apis), a simplified approach for building fast web APIs with minimal code and configuration by fluently declaring API routes and actions.

:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-6.0"

* [Blazor](xref:blazor/index), a component-based web UI framework based on C# that supports both server-side rendering via the .NET runtime and client-side rendering via WebAssembly.
* [Razor Pages](xref:razor-pages/index), a page-based programming model that makes building web UI easier and more productive.
* [Model-View-Controller (MVC)](xref:mvc/overview), a traditional framework for building web apps and web APIs using the [Model-View-Controller design pattern](https://developer.mozilla.org/docs/Glossary/MVC).

:::moniker-end

:::moniker range="< aspnetcore-3.0"

* [Razor Pages](xref:razor-pages/index), a page-based programming model that makes building web UI easier and more productive.
* [Model-View-Controller (MVC)](xref:mvc/overview), a traditional framework for building web apps and web APIs using the [Model-View-Controller design pattern](https://developer.mozilla.org/docs/Glossary/MVC).

:::moniker-end

## ASP.NET Core target frameworks

ASP.NET Core 3.x or later can only target .NET.

There are several advantages to targeting .NET, and these advantages increase with each release. Some advantages of .NET over .NET Framework include:

* Cross-platform on Windows, macOS, and Linux
* Improved performance
* [Side-by-side versioning](/dotnet/standard/choosing-core-framework-server#side-by-side-net-versions-per-application-level)
* New APIs
* Open source

ASP.NET Core 2.x can target .NET Core or .NET Framework. ASP.NET Core apps targeting .NET Framework aren't cross-platform and only run on Windows. Generally, ASP.NET Core 2.x is made up of [.NET Standard](/dotnet/standard/net-standard) libraries. Libraries written with .NET Standard 2.0 run on any [.NET platform that implements .NET Standard 2.0](/dotnet/standard/net-standard#net-implementation-support).

ASP.NET Core 2.x is supported on .NET Framework versions that implement .NET Standard 2.0:

* .NET Framework latest version is recommended.
* .NET Framework 4.6.1 or later.

To help close the API gap from .NET Framework to .NET Core 2.x, the [Windows Compatibility Pack](/dotnet/core/porting/windows-compat-pack) made thousands of Windows-only APIs available. These APIs weren't available in .NET Core 1.x.

## Recommended learning path

We recommend the following sequence of tutorials for an introduction to developing ASP.NET Core apps, or select the appropriate tutorial for the type of app that you know you want to develop.

Our tutorial for new developers and developers new to .NET is <xref:getting-started>.

:::moniker range=">= aspnetcore-6.0"

App type | Scenario | Tutorial
-------- | -------- | --------
Web app | New server and client web development with Blazor - ***Recommended*** | [Build your first web app with ASP.NET Core using Blazor (Interactive Online Learn Module)](https://dotnet.microsoft.com/learn/aspnet/blazor-tutorial/intro) or [Build your first web app with Blazor (Visual Studio or Visual Studio Code)](/training/modules/build-your-first-blazor-web-app/)
Web app | New server-side web development with Razor Pages | <xref:tutorials/razor-pages/razor-pages-start>
Web app | New server-side web development with MVC | <xref:tutorials/first-mvc-app/start-mvc>
Web API | Server-based data processing with Minimal APIs - ***Recommended*** | <xref:tutorials/min-web-api> and [Build a web API with minimal API, ASP.NET Core, and .NET (.NET SDK)](/training/modules/build-web-api-minimal-api/)
Remote Procedure Call (RPC) app | Contract-first services using Protocol Buffers | <xref:tutorials/grpc/grpc-start>
Real-time app | Server/client bidirectional communication | <xref:tutorials/signalr>

:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-6.0"

App type | Scenario | Tutorial
-------- | -------- | --------
Web app | New server and client web development with Blazor - ***Recommended*** | [Build your first web app with ASP.NET Core using Blazor (Interactive Online Learn Module)](https://dotnet.microsoft.com/learn/aspnet/blazor-tutorial/intro) or [Build your first web app with Blazor (Visual Studio or Visual Studio Code)](/training/modules/build-your-first-blazor-web-app/)
Web app | New server-side web development with Razor Pages | <xref:tutorials/razor-pages/razor-pages-start>
Web app | New server-side web development with MVC | <xref:tutorials/first-mvc-app/start-mvc>
Web API | Server-based data processing | <xref:tutorials/first-web-api> and [Create a web API with ASP.NET Core controllers (.NET SDK)](/training/modules/build-web-api-aspnet-core/)
Remote Procedure Call (RPC) app | Contract-first services using Protocol Buffers | <xref:tutorials/grpc/grpc-start>
Real-time app | Server/client bidirectional communication | <xref:tutorials/signalr>

:::moniker-end

:::moniker range="< aspnetcore-3.0"

App type | Scenario | Tutorial
-------- | -------- | --------
Web app | New web development | <xref:tutorials/razor-pages/razor-pages-start>
Web app | New server-side web development with MVC | <xref:tutorials/first-mvc-app/start-mvc>
Web API | Server-based data processing | <xref:tutorials/first-web-api> and [Create a web API with ASP.NET Core controllers (.NET SDK)](/training/modules/build-web-api-aspnet-core/)
Real-time app | Server/client bidirectional communication | <xref:tutorials/signalr>

:::moniker-end

The tutorials in the following table teach data access concepts.

:::moniker range=">= aspnetcore-3.0"

Scenario | Tutorial
-------- | --------
New development with Blazor | <xref:blazor/tutorials/movie-database-app/index>
New development with Razor Pages | <xref:data/ef-rp/intro>
New development with MVC | <xref:data/ef-mvc/intro>

:::moniker-end

:::moniker range="< aspnetcore-3.0"

Scenario | Tutorial
-------- | --------
New development with Razor Pages | <xref:data/ef-rp/intro>
New development with MVC | <xref:data/ef-mvc/intro>

:::moniker-end

See the [ASP.NET Core fundamentals articles](xref:fundamentals/index), which apply to all app types.

Browse the table of contents for other topics of interest.

## Migrate from .NET Framework

For a reference guide on migrating ASP.NET 4.x apps to ASP.NET Core, see <xref:migration/fx-to-core/index>.

## Breaking changes and security advisories

[!INCLUDE[](~/includes/announcements.md)]

## .NET Live TV

[.NET Live TV](https://dotnet.microsoft.com/live) covers the .NET team's progress and plans. It features new blogs and third-party software.
