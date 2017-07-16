---
title: Microsoft.AspNetCore.All metapackage for ASP.NET Core 2.X and later
author: Rick-Anderson
description: Microsoft.AspNetCore.All metapackage includes all supported packages.
keywords: ASP.NET Core, NuGet, package,  Microsoft.AspNetCore.All, metapackage
ms.author: riande
manager: wpickett
ms.date: 07/16/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/metapackage
---

#Microsoft.AspNetCore.All metapackage for ASP.NET Core 2.X

This feature requires ASP.NET Core 2.X.

The `Microsoft.AspNetCore.All` metapackage for ASP.NET Core includes all:

* Supported packages by for ASP.NET Core.
* Supported packages by for  Entity Framework Core. 
* Internal and 3rd-party dependencies used by ASP.NET Core and Entity Framework Core. 

All the features of ASP.NET Core 2.X and Entity Framework Core 2.X are included in the [Microsoft.AspNetCore.All](https://www.nuget.org/packages/Microsoft.AspNetCore.All) package. The default templates use this package.

The version number of the `Microsoft.AspNetCore.All` metapackage represents the ASP.NET Core version and Entity Framework Core version (aligned with the .NET Core version).

Applications that use the `Microsoft.AspNetCore.All` metapackage automatically take advantage of the .NET Core runtime store. The runtime store contains all the runtime assets needed to run ASP.NET Core 2.X applications. When you use the `Microsoft.AspNetCore.All` metapackage, **no** assets from the referenced ASP.NET Core NuGet packages are deployed with the application - the  .NET Core runtime store contains these assets. The assets in the runtime store are precompiled to improve application startup time.

Features you don’t use in your application are removed by package trimming. Unused features are excluded in published application output.

The following *.csproj* file references the `Microsoft.AspNetCore.All` metapackage for ASP.NET Core:

[!code-xml[Main](..\mvc\views\view-compilation\sample\MvcRazorCompileOnPublish2.csproj?highlight=9)]