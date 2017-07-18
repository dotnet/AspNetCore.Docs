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

Razor views are compiled at runtime when the view is invoked. ASP.NET Core 1.1.0 and higher can optionally compile Razor views and deploy them with the app (precompilation). The ASP.NET Core 2.x project templates enable precompilation.

Precompilation considerations:

* Precompiling views results in  a smaller published bundle and faster startup time.
* You can't edit Razor files after you precompile views. The edited views won't be present in the published bundle. 

To deploy precompiled views:

# [ASP.NET Core 1.x](#tab/aspnet1x)

Set `MvcRazorCompileOnPublish` to true and include a package reference to `Microsoft.AspNetCore.Mvc.Razor.ViewCompilation`. The following *.csproj* sample highlights these settings:

[!code-xml[Main](view-compilation\sample\MvcRazorCompileOnPublish.csproj?highlight=5,12)]

# [ASP.NET Core 2.0](#tab/aspnet20)

Set `MvcRazorCompileOnPublish` to true. The following *.csproj* sample highlights this setting:

[!code-xml[Main](view-compilation\sample\MvcRazorCompileOnPublish2.csproj?highlight=5)]

All the ASP.NET Core 2.x project templates set `MvcRazorCompileOnPublish` to true.

---
