---
title: Razor view compilation and precompilation
author: rick-anderson
description: View compilation and precompilation in ASP.NET Core
keywords: ASP.NET Core,Razor view compilation, Razor pre-compilation, Razor precompilation
ms.author: riande
manager: wpickett
ms.date: 5/24/2017
ms.topic: article
ms.assetid: ab4705b7-1638-1638-bc97-ea7f292fe92a
ms.technology: aspnet
ms.prod: asp.net-core
uid: mvc/views/view-compilation
---
# Razor view compilation and precompilation in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

Razor views are compiled at runtime when the view is invoked. ASP.NET Core 1.1.0 and higher can optionally compile Razor views and deploy them with the app (precompilation). To deploy precompiled views, set `MvcRazorCompileOnPublish` to true and include a package reference to `Microsoft.AspNetCore.Mvc.Razor.ViewCompilation`. The following *.csproj* sample highlights these settings:

[!code-html[Main](view-compilation\sample\MvcRazorCompileOnPublish.csproj?highlight=5,12)]
