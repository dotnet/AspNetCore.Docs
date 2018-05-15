---
title: Razor view compilation and precompilation in ASP.NET Core
author: rick-anderson
description: Learn how to enable MVC Razor view compilation and precompilation in ASP.NET Core apps.
manager: wpickett
ms.author: riande
ms.date: 12/13/2017
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: mvc/views/view-compilation
---
# Razor file (.cshtml) compilation in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

Razor views are compiled at runtime when the view is invoked. ASP.NET Core 2.1.0 or later compile views at build and publish time using [Razor Sdk](/aspnetcore/mvc/razor-pages/sdk). In ASP.NET Core 1.1, and ASP.NET Core 2.0, views can optionally be compiled at publish and deployed with the app &mdash; using the precompilation tool. 



Precompilation considerations:

* Precompiling views results in a smaller published bundle and faster startup time.
* You can't edit Razor files after you precompile views. The edited views won't be present in the published bundle. 

To deploy precompiled views:

# [ASP.NET Core 2.1](#tab/aspnetcore21/)
Build and publish time compilation of Razor files is enabled by default by the Razor Sdk. Editing Razor files after they are updated is supported at build time. By default, only the compiled *Views.dll* and no cshtml files are deployed with your application. 
    
> [!IMPORTANT]
> The Razor Sdk is only effective when no precompilation specific properties are set in your project file. For instance, setting `MvcRazorCompileOnPublish` in your *.csproj* file will disable the Razor Sdk.

# [ASP.NET Core 2.0](#tab/aspnetcore20/)

If your project targets .NET Framework, include a package reference to [Microsoft.AspNetCore.Mvc.Razor.ViewCompilation](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Razor.ViewCompilation/):

```xml
<PackageReference Include="Microsoft.AspNetCore.Mvc.Razor.ViewCompilation" Version="2.0.0" PrivateAssets="All" />
```

If your project targets .NET Core, no changes are necessary.

The ASP.NET Core 2.x project templates implicitly sets `MvcRazorCompileOnPublish` to `true` by default, which means this node can be safely removed from the *.csproj* file.
    
> [!IMPORTANT]
> Razor view precompilation in not available when performing a [self-contained deployment (SCD)](/dotnet/core/deploying/#self-contained-deployments-scd) in ASP.NET Core 2.0. 

Prepare the app for a [framework-dependent deployment](/dotnet/core/deploying/#framework-dependent-deployments-fdd) with the [.NET Core CLI publish command](/dotnet/core/tools/dotnet-publish). For example, execute the following command at the project root:

```console
dotnet publish -c Release
```

A *<project_name>.PrecompiledViews.dll* file, containing the compiled Razor views, is produced when precompilation succeeds. For example, the screenshot below depicts the contents of *Index.cshtml* inside of *WebApplication1.PrecompiledViews.dll*:

![Razor views inside DLL](view-compilation/_static/razor-views-in-dll.png)

# [ASP.NET Core 1.x](#tab/aspnetcore1x/)

Set `MvcRazorCompileOnPublish` to `true` and include a package reference to `Microsoft.AspNetCore.Mvc.Razor.ViewCompilation`. The following *.csproj* sample highlights these settings:

[!code-xml[](view-compilation/sample/MvcRazorCompileOnPublish.csproj?highlight=5,12)]

---

