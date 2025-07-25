---
title: Overview of ASP.NET Core
author: tdykstra
description: Get an overview of ASP.NET Core, a cross-platform, high-performance, open-source framework for building modern, cloud-enabled, Internet-connected apps.
ms.author: tdykstra
ms.custom: mvc
ms.date: 07/25/2025
uid: index
---
# Overview of ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

ASP.NET Core is a cross-platform, high-performance, open-source framework for building modern web apps. The framework is built for large-scale app development and can handle any size workload, making it a robust choice for enterprise-level apps.

[!INCLUDE[](~/includes/key-features.md)]

## Why choose ASP.NET Core? (OPTION 1: COLLAPSED BULLET LIST)

* **Unified framework**: ASP.NET Core is a complete and fully integrated web framework with built-in production-ready components to handle all of your web development needs.
* **Full stack productivity**: Build more apps faster by enabling your team to work full stack, from the frontend to the backend, using a single development framework.
* **Secure by design**: ASP.NET Core is built with security as a top concern and includes built-in support for authentication, authorization, and data protection.
* **Cloud-ready**: Whether you're deploying to your own data centers or to the cloud, ASP.NET Core simplifies deployment, monitoring, and configuration.
* **Performance & scalability**: Handle the most demanding workloads with ASP.NET Core's industry leading performance.
* **Trusted and mature**: ASP.NET Core is used and proven at hyperscale by some of the largest services in the world, including Bing, Xbox, Microsoft 365, and Azure.

## Why choose ASP.NET Core? (OPTION 2: SPACED BULLET LIST)

* **Unified framework**: ASP.NET Core is a complete and fully integrated web framework with built-in production-ready components to handle all of your web development needs.

* **Full stack productivity**: Build more apps faster by enabling your team to work full stack, from the frontend to the backend, using a single development framework.

* **Secure by design**: ASP.NET Core is built with security as a top concern and includes built-in support for authentication, authorization, and data protection.

* **Cloud-ready**: Whether you're deploying to your own data centers or to the cloud, ASP.NET Core simplifies deployment, monitoring, and configuration.

* **Performance & scalability**: Handle the most demanding workloads with ASP.NET Core's industry leading performance.

* **Trusted and mature**: ASP.NET Core is used and proven at hyperscale by some of the largest services in the world, including Bing, Xbox, Microsoft 365, and Azure.

## Why choose ASP.NET Core? (OPTION 3: UNBULLETED LIST WITH ADDL SPACING)

**Unified framework**

ASP.NET Core is a complete and fully integrated web framework with built-in production-ready components to handle all of your web development needs.

**Full stack productivity**

Build more apps faster by enabling your team to work full stack, from the frontend to the backend, using a single development framework.

**Secure by design**

ASP.NET Core is built with security as a top concern and includes built-in support for authentication, authorization, and data protection.

**Cloud-ready**

Whether you're deploying to your own data centers or to the cloud, ASP.NET Core simplifies deployment, monitoring, and configuration.

**Performance & scalability**

Handle the most demanding workloads with ASP.NET Core's industry leading performance.

**Trusted and mature**

ASP.NET Core is used and proven at hyperscale by some of the largest services in the world, including Bing, Xbox, Microsoft 365, and Azure.

## Tutorials to get started

Our tutorial for new developers and developers new to .NET is <xref:get-started>.

Once you've completed the *Get started* tutorial, we recommend reading the [ASP.NET Core fundamentals](xref:fundamentals/index) article, which covers the basics of ASP.NET Core.

Next, experience ASP.NET Core in action with our other tutorials. You can use each tutorial in the order shown, or you can select a specific tutorial if you know in advance the type of app that you plan to build.

:::moniker range=">= aspnetcore-6.0"

App type | Scenario | Tutorial
-------- | -------- | --------
Web app | New server and client web development with Blazor &ndash; ***Recommended*** | [Build your first web app with ASP.NET Core using Blazor (Interactive Online Learn Module)](https://dotnet.microsoft.com/learn/aspnet/blazor-tutorial/intro) or [Build your first web app with Blazor (Visual Studio or Visual Studio Code)](/training/modules/build-your-first-blazor-web-app/)
Web API | Server-based data processing with Minimal APIs &ndash; ***Recommended*** | <xref:tutorials/min-web-api> and [Build a web API with minimal API, ASP.NET Core, and .NET (.NET SDK)](/training/modules/build-web-api-minimal-api/)
Remote Procedure Call (RPC) app | Contract-first services using Protocol Buffers | <xref:tutorials/grpc/grpc-start>
Real-time app | Server/client bidirectional communication | <xref:tutorials/signalr>

:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-6.0"

App type | Scenario | Tutorial
-------- | -------- | --------
Web app | New server and client web development with Blazor - ***Recommended*** | [Build your first web app with ASP.NET Core using Blazor (Interactive Online Learn Module)](https://dotnet.microsoft.com/learn/aspnet/blazor-tutorial/intro) or [Build your first web app with Blazor (Visual Studio or Visual Studio Code)](/training/modules/build-your-first-blazor-web-app/)
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

:::moniker range=">= aspnetcore-3.0"

To learn about data access concepts, see <xref:blazor/tutorials/movie-database-app/index>.

:::moniker-end

:::moniker range="< aspnetcore-3.0"

The tutorials in the following table teach data access concepts.

Scenario | Tutorial
-------- | --------
New development with Razor Pages | <xref:data/ef-rp/intro>
New development with MVC | <xref:data/ef-mvc/intro>

:::moniker-end

## Additional resources

* [Download .NET](https://dotnet.microsoft.com/download)
* [Visual Studio](https://visualstudio.microsoft.com/)
* [Visual Studio Code](https://code.visualstudio.com/)
* [.NET Developer Community](https://dotnet.microsoft.com/platform/community)
* [.NET Live TV](https://live.dot.net)
