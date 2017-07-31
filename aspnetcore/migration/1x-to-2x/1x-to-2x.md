---
title: Migrating from ASP.NET Core 1.x to 2.0
author: scottaddie
description: This article outlines the prerequisites and most common steps for migrating an ASP.NET Core 1.x project to ASP.NET Core 2.0.
keywords: ASP.NET Core,migrating
ms.author: scaddie
manager: wpickett
ms.date: 07/31/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: migration/1x-to-2x
---
# Migrating from ASP.NET Core 1.x to ASP.NET Core 2.0

By [Scott Addie](https://github.com/scottaddie)

This article outlines the most common steps to migrate an existing ASP.NET Core 1.x project to ASP.NET Core 2.0.

<a name="prerequisites"></a>

## Prerequisites
Install the following prerequisites before migrating to ASP.NET Core 2.0:
- If you're using Visual Studio, install [Visual Studio 2017 version 15.3](https://www.visualstudio.com/vs/) or later
- [.NET Core 2.0](https://github.com/dotnet/core/blob/master/release-notes/download-archives/2.0.0-download.md) or .NET Framework 4.6.1+

For applications hosted on Windows Server with IIS and Kestrel, the [.NET Core Windows Server Hosting bundle](xref:publishing/iis) must be updated.

<a name="tfm"></a>

## Target Framework Moniker (TFM)
Projects targeting .NET Core must use the [TFM](/dotnet/standard/frameworks#referring-to-frameworks) of a version greater than or equal to .NET Core 2.0:

[!code-xml[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App.csproj?range=3)]

Projects targeting .NET Framework must use the TFM of a version greater than or equal to .NET Framework 4.6.1:

[!code-xml[Main](../1x-to-2x/samples/AspNetCoreDotNetFx2.0App/AspNetCoreDotNetFx2.0App/AspNetCoreDotNetFx2.0App.csproj?range=4)]

> [!NOTE]
> .NET Core 2.0 offers a much larger surface area than .NET Core 1.x. If you're targeting .NET Framework solely because of missing APIs in .NET Core 1.x, targeting .NET Core 2.0 is likely to work.

<a name="global-json"></a>

## global.json
If the solution relies upon a [*global.json*](https://docs.microsoft.com/dotnet/core/tools/global-json) file to target a specific .NET Core SDK version, update it to use the 2.0 version installed on the machine:

[!code-json[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/global.json?highlight=3)]

<a name="package-reference"></a>

## Update package references
The *.csproj* file in a 1.x project lists each NuGet package used by the project.

In an ASP.NET Core 2.0 project targeting .NET Core 2.0, a single [metapackage](xref:fundamentals/metapackage) reference in the *.csproj* file replaces the collection of packages:

[!code-xml[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App.csproj?range=9-11)]

All the features of ASP.NET Core 2.0 and Entity Framework Core 2.0 are included in the metapackage.

ASP.NET Core 2.0 projects targeting .NET Framework should continue to reference individual NuGet packages. An upgrade of each package reference to 2.0 is required:

[!code-xml[Main](../1x-to-2x/samples/AspNetCoreDotNetFx2.0App/AspNetCoreDotNetFx2.0App/AspNetCoreDotNetFx2.0App.csproj?range=9-22)]

<a name="dot-net-cli-tool-reference"></a>

## Update .NET Core CLI tools
Update the `Version` attributes of each `<DotNetCliToolReference />` node to the 2.0 version:

[!code-xml[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App.csproj?range=13-17)]

<a name="package-target-fallback"></a>

## Package Target Fallback property
The *.csproj* file of a 1.x project used a `PackageTargetFallback` node and variable:

[!code-xml[Main](../1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App.csproj?range=5)]

Rename both the node and variable to `AssetTargetFallback`:

[!code-xml[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App.csproj?range=5)]

<a name="program-cs"></a>

## Program.cs
In 1.x projects, the `Main` method of *Program.cs* looked like this:

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Program.cs?highlight=8-19)]

If you're starting with a 2.0 project template, notice that the `Main` method of *Program.cs* has changed:

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/Program.cs?highlight=8-11)]

The adoption of this new 2.0 pattern is highly recommended. Product features like [Entity Framework Core Migrations](xref:data/ef-mvc/migrations) **do not** work without it.

<a name="view-compilation"></a>

## Razor View Compilation
[Razor view compilation](xref:mvc/views/view-compilation) is enabled by default in ASP.NET Core 2.0. Setting the `MvcRazorCompileOnPublish` property to true is no longer required. Unless you're disabling view compilation, the property may be removed from the *.csproj* file.

When targeting .NET Framework, you still need to explicitly reference the `Microsoft.AspNetCore.Mvc.Razor.ViewCompilation` NuGet package.

<a name="app-insights"></a>

## Application Insights
ASP.NET Core 1.1 projects created in Visual Studio 2017 added Application Insights by default. If you're not using the Application Insights SDK directly, outside of *Program.cs* and *Startup.cs*, follow these steps:

1. Remove the `Microsoft.ApplicationInsights.AspNetCore` package reference:
    
    [!code-xml[Main](../1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App.csproj?range=10)]

2. Remove the `UseApplicationInsights` extension method invocation from *Program.cs*:

    [!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Program.cs?name=snippet_ProgramCsMain&highlight=8)]

3. Remove the client-side API call from *_Layout.cshtml*:

    [!code-cshtml[Main](../1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Views/Shared/_Layout.cshtml?range=1,19)]

You can rely on the new "light-up" features available in the Visual Studio 2017 tooling.

If you are using the Application Insights SDK directly, continue to do so. The 2.0 metapackage includes the latest version of Application Insights, so a package downgrade error appears if you're referencing an older version.

<a name="publishing"></a>

## Publishing
At publish time, ASP.NET Core 2.0 applications targeting .NET Core 2.0 use a new feature called the .NET Core Runtime Store. The Runtime Store contains all the runtime assets necessary to run ASP.NET Core 2.0 applications. No assets from the referenced ASP.NET Core NuGet packages are deployed with the application. The benefits are a much smaller published bundle size and decreased application startup time.

<a name="auth-and-identity"></a>

## Authentication / Identity
ASP.NET Core 2.0 has a new authentication model and a number of significant changes to ASP.NET Core Identity. See [Migrating Authentication and Identity to ASP.NET Core 2.0](xref:migration/identity-2x).