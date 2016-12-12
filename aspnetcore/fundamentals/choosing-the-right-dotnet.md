---
title: Choosing the Right .NET For You on the Server | Microsoft Docs
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 7227b82f-9275-4006-85bc-be55f5e4d39e
ms.technology: aspnet
ms.prod: aspnet-core
uid: fundamentals/choosing-the-right-dotnet
---
# Choosing the Right .NET For You on the Server

By [Daniel Roth](https://github.com/danroth27)

ASP.NET Core is based on the [.NET Core](https://microsoft.com/net/core) project model, which supports building applications that can run cross-platform on Windows, Mac and Linux. When building a .NET Core project you also have a choice of which .NET flavor to target your application at: .NET Framework (CLR), .NET Core (CoreCLR) or [Mono](http://mono-project.com). Which .NET flavor should you choose? Let's look at the pros and cons of each one.

## .NET Framework

The .NET Framework is the most well known and mature of the three options. The .NET Framework is a mature and fully featured framework that ships with Windows. The .NET Framework ecosystem is well established and has been around for well over a decade. The .NET Framework is production ready today and provides the highest level of compatibility for your existing applications and libraries.

The .NET Framework runs on Windows only. It is also a monolithic component with a large API surface area and a slower release cycle. While the code for the .NET Framework is [available for reference](http://referencesource.microsoft.com/) it is not an active open source project.

## .NET Core

.NET Core is a modular runtime and library implementation that includes a subset of the .NET Framework. .NET Core is supported on Windows, Mac and Linux. .NET Core consists of a set of libraries, called "CoreFX", and a small, optimized runtime, called "CoreCLR". .NET Core is open-source, so you can follow progress on the project and contribute to it on [GitHub](https://github.com/dotnet).

The CoreCLR runtime (Microsoft.CoreCLR) and CoreFX libraries are distributed via [NuGet](https://nuget.org). Because .NET Core has been built as a componentized set of libraries you can limit the API surface area your application uses to just the pieces you need. You can also run .NET Core based applications on much more constrained environments (ex. [ASP.NET Core on Nano Server](../tutorials/nano-server.md)).

The API factoring in .NET Core was updated to enable better componentization. This means that existing libraries built for the .NET Framework generally need to be recompiled to run on .NET Core. The .NET Core ecosystem is relatively new, but it is rapidly growing with the support of popular .NET packages like JSON.NET, AutoFac, xUnit.net and many others.

Developing on .NET Core allows you to target a single consistent platform that can run on multiple platforms.
