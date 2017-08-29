---
title: Razor view compilation and precompilation
author: rick-anderson
description: A reference document explaining how to enable MVC Razor view compilation and precompilation in ASP.NET Core applications.
keywords: ASP.NET Core,Razor view compilation,Razor pre-compilation,Razor precompilation
ms.author: riande
manager: wpickett
ms.date: 08/16/2017
ms.topic: article
ms.assetid: ab4705b7-1638-1638-bc97-ea7f292fe92a
ms.technology: aspnet
ms.prod: asp.net-core
uid: mvc/views/view-compilation
---
# Razor view compilation and precompilation in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

Razor views are compiled at runtime when the view is invoked. ASP.NET Core 1.1.0 and higher can optionally compile Razor views and deploy them with the app &mdash; a process known as precompilation. The ASP.NET Core 2.x project templates enable precompilation by default.

> [!NOTE]
> Razor view precompilation is unavailable when doing a [Self-Contained Deployment](https://docs.microsoft.com/dotnet/core/deploying/#self-contained-deployments-scd) in ASP.NET Core versions 2.0.0 and earlier.

Precompilation considerations:

* Precompiling views results in a smaller published bundle and faster startup time.
* You can't edit Razor files after you precompile views. The edited views won't be present in the published bundle. 

To deploy precompiled views:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

If your project targets .NET Framework, include a package reference to `Microsoft.AspNetCore.Mvc.Razor.ViewCompilation`:

```xml
<PackageReference Include="Microsoft.AspNetCore.Mvc.Razor.ViewCompilation" Version="2.0.0" PrivateAssets="All" />
```

If your project targets .NET Core, no changes are necessary.

The ASP.NET Core 2.x project templates implicitly set `MvcRazorCompileOnPublish` to `true` by default, which means this node can be safely removed from the *.csproj* file. If you prefer to be explicit, there's no harm in setting the `MvcRazorCompileOnPublish` property to `true`. The following *.csproj* sample highlights this setting:

[!code-xml[Main](view-compilation\sample\MvcRazorCompileOnPublish2.csproj?highlight=5)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

Set `MvcRazorCompileOnPublish` to `true`, and include a package reference to `Microsoft.AspNetCore.Mvc.Razor.ViewCompilation`. The following *.csproj* sample highlights these settings:

[!code-xml[Main](view-compilation\sample\MvcRazorCompileOnPublish.csproj?highlight=5,12)]

---