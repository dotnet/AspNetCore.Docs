---
title: Migrating from ASP.NET Core 1.x to 2.x
author: scottaddie
description: This article outlines the prerequisites and most common steps for migrating an ASP.NET Core 1.x project to ASP.NET Core 2.x.
keywords: ASP.NET Core,migrating
ms.author: scaddie
manager: wpickett
ms.date: 07/27/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: migration/1x-to-2x
---
# Migrating from ASP.NET Core 1.x to ASP.NET Core 2.x

By [Scott Addie](https://github.com/scottaddie)

This article outlines the most common steps to migrate an existing ASP.NET Core 1.x project to ASP.NET Core 2.x. Non-breaking changes are outside of the article's scope.

<a name="prerequisites"></a>

## Prerequisites
Install the following prerequisites before migrating to ASP.NET Core 2.x:
- If you're using Visual Studio, install [Visual Studio 2017 Preview version 15.3](https://www.visualstudio.com/vs/preview/) or later
- [.NET Core 2.x](https://www.microsoft.com/net/core/preview) or .NET Framework 4.6.1+

For applications hosted on Windows Server with IIS and Kestrel, the [.NET Core Windows Server Hosting bundle](xref:publishing/iis) must be updated.

<a name="tfm"></a>

## Target Framework Moniker (TFM)
Projects targeting .NET Core must use the [TFM](/dotnet/standard/frameworks#referring-to-frameworks) of a version greater than or equal to .NET Core 2.0:

[!code-xml[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App.csproj?range=3)]

Projects targeting .NET Framework must use the TFM of a version greater than or equal to .NET Framework 4.6.1:

```xml
<TargetFramework>net461</TargetFramework>
```

> [!NOTE]
> .NET Core 2.0 offers a much larger surface area than .NET Core 1.x. If you're targeting .NET Framework solely because of missing APIs in .NET Core 1.x, targeting .NET Core 2.0 is likely to work.

<a name="global-json"></a>

## global.json
If the solution relies upon a [*global.json*](https://docs.microsoft.com/dotnet/core/tools/global-json) file to target a specific .NET Core SDK version, update it to use the 2.x version installed on the machine:

[!code-json[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/global.json?highlight=3)]

<a name="package-reference"></a>

## PackageReference
The *.csproj* file in a 1.x project lists each NuGet package used by the project:

[!code-xml[Main](../1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App.csproj?range=9-26)]

In an ASP.NET Core 2.x project targeting .NET Core 2.x, a single [meta-package](xref:fundamentals/metapackage) reference in the *.csproj* file replaces the collection of packages:

[!code-xml[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App.csproj?range=9-11)]

All the features of ASP.NET Core 2.x and Entity Framework Core 2.x are included in the meta-package.

ASP.NET Core 2.x projects targeting .NET Framework cannot use this meta-package. An upgrade of each NuGet package reference to 2.x is required.

<a name="dot-net-cli-tool-reference"></a>

## DotNetCliToolReference
Update the `Version` attributes of each `<DotNetCliToolReference />` node to the 2.x version:

[!code-xml[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App.csproj?range=13-17)]

<a name="package-target-fallback"></a>

## PackageTargetFallback
The *.csproj* file of a 1.x project used a `PackageTargetFallback` node and variable:

[!code-xml[Main](../1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App.csproj?range=5)]

Both the node and variable have been renamed:

[!code-xml[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App.csproj?range=5)]

<a name="app-insights"></a>

## Application Insights
ASP.NET Core 1.1 projects created in Visual Studio 2017 added Application Insights by default. This was accomplished via a three-step process:

1. Add the supporting NuGet package:

    [!code-xml[Main](../1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App.csproj?range=10)]

2. Invoke the `UseApplicationInsights` extension method in *Program.cs*:

    [!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Program.cs?highlight=15)]

3. Add the client-side API call in *_Layout.cshtml*:

    [!code-cshtml[Main](../1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Views/Shared/_Layout.cshtml?range=1,19)]

In the 2.x project templates, Application Insights isn't added by default.

If you're not using the Application Insights SDK directly, outside of *Program.cs* and *Startup.cs*, omit its explicit package reference and the code referenced in steps 2 and 3 above. You can rely on the new "light-up" features available in the Visual Studio 2017 tooling.

If you are using the Application Insights SDK directly, continue to do so. Since the 2.x meta-package includes the latest version of Application Insights, a package downgrade error appears if you're referencing an older version.

<a name="program-cs"></a>

## Program.cs
In 1.x projects, the `Main` method of *Program.cs* looked like this:

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Program.cs)]

If you're starting with a 2.x project template, notice that the `Main` method of *Program.cs* has changed:

[!code-csharp[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/Program.cs)]

The adoption of this new 2.x pattern is highly recommended. Product features like [Entity Framework Core Migrations](xref:data/ef-mvc/migrations) **do not** work without it.

<a name="view-compilation"></a>

## Razor View Compilation
[Razor view compilation](xref:mvc/views/view-compilation) is enabled by default in ASP.NET Core 2.0. The *Views* folder and its Razor files are no longer present in the published bundle. Consequently, the published bundle is smaller and startup performance is noticeably improved.

In 1.x projects, view compilation is enabled by adding a reference to the `Microsoft.AspNetCore.Mvc.Razor.ViewCompilation` NuGet package and by manually adding and enabling the `MvcRazorCompileOnPublish` property:

[!code-xml[Main](../1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App.csproj?highlight=4,16)]

The 2.x project templates add and enable the `MvcRazorCompileOnPublish` property by default. The meta-package reference imports the rest of the necessary view compilation bits.

[!code-xml[Main](../1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App.csproj?highlight=4)]

<a name="publishing"></a>

## Publishing
At publish time, ASP.NET Core 2.x applications targeting .NET Core 2.x use a new feature called the .NET Core Runtime Store. The Runtime Store contains all the runtime assets necessary to run ASP.NET Core 2.x applications. No assets from the referenced ASP.NET Core NuGet packages are deployed with the application. The benefits are a much smaller published bundle size and decreased application startup time.

<a name="auth-and-identity"></a>

## Authentication / Identity
See [Migrating Authentication and Identity to ASP.NET Core 2.x](identity-2x.md).