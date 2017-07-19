---
title: Migrating from ASP.NET Core 1.x to 2.x
author: scottaddie
description: Upgrading an ASP.NET Core 1.x application to ASP.NET Core 2.x
keywords: ASP.NET Core
ms.author: scaddie
manager: wpickett
ms.date: 07/18/2017
ms.topic: article
ms.assetid: 8468d859-ff32-4a92-9e62-08c4a9e36594
ms.technology: aspnet
ms.prod: asp.net-core
uid: migration/1x-to-2x
---
# Migrating From ASP.NET Core 1.x to 2.x

By [Scott Addie](https://github.com/scottaddie)

## Prerequisites
Install the following prerequisites before migrating to ASP.NET Core 2.x:
- Visual Studio 2017 Preview version 15.3 or later, Visual Studio Code, or Visual Studio for Mac
- .NET Core 2.x or .NET Framework 4.6.1+

> [!NOTE]
> Thanks to .NET Standard 2.0, .NET Core 2.0 offers a much larger surface area than .NET Core 1.x. If you're targeting .NET Framework solely because of missing APIs in .NET Core 1.x, targeting .NET Core 2.0 is likely to work for you now.

## Target Framework Moniker (TFM)
Applications targeting .NET Core must use the `netcoreapp2.0` TFM:

[!code-xml[Main](../migration/1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App.csproj?range=4)]

Applications targeting .NET Framework must use the TFM of a version greater than or equal to .NET Framework 4.6.1:

```xml
<TargetFramework>net461</TargetFramework>
```

## global.json
If your solution relies upon a *global.json* file to target a specific .NET Core SDK version, update it to use the desired version on your machine:

[!code-json[Main](../migration/1x-to-2x/samples/AspNetCoreDotNetCore2.0App/global.json?highlight=3)]

## PackageReference
In a 1.x .csproj file, an assortment of NuGet packages is needed:

[!code-xml[Main](../migration/1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App.csproj?range=9-26)]

In an ASP.NET Core 2.x application targeting .NET Core 2.x, a single meta-package reference in the .csproj file replaces the aforementioned collection of packages:

[!code-xml[Main](../migration/1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App.csproj?range=9-11)]

All the features of ASP.NET Core 2.x and Entity Framework Core 2.x are included in the meta-package.

The meta-package is incompatible with ASP.NET Core 2.x applications targeting .NET Framework. For applications targeting .NET Framework, upgrade each NuGet package reference to 2.x.

## DotNetCliToolReference
Update the `Version` attributes of each `<DotNetCliToolReference />` node to the desired 2.x version:

[!code-xml[Main](../migration/1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App.csproj?range=13-17)]

## PackageTargetFallback
The .csproj file of a 1.x application used a `PackageTargetFallback` node:

[!code-xml[Main](../migration/1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App.csproj?range=5)]

This node has been renamed:

[!code-xml[Main](../migration/1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App.csproj?range=5)]

## Authentication / Identity
The old 1.x authentication stack is obsolete and must be migrated to the 2.0 stack. What follows are changes required to get the application running.

### IAuthenticationManager (HttpContext.Authentication) is obsolete
The `IAuthenticationManager` interface was the main entry point into the 1.x authentication system. It has been replaced with a new set of `HttpContext` extension methods in the `Microsoft.AspNetCore.Authentication` namespace.

For example, 1.x applications reference an `Authentication` property:

[!code-csharp[Main](../migration/1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Controllers/AccountController.cs?name=snippet_AuthenticationProperty)]

In 2.x applications, import the `Microsoft.AspNetCore.Authentication` namespace, and delete the `Authentication` property references:

[!code-csharp[Main](../migration/1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/Controllers/AccountController.cs?name=snippet_AuthenticationProperty)]

### Authentication Middleware
The `UseIdentity` extension method, which typically appeared in the `Configure` method of *Startup.cs* in 1.x applications, is obsolete:

[!code-csharp[Main](../migration/1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Startup.cs?range=76)]

Feature parity is maintained when this method call is removed in 2.x applications.

### IdentityCookieOptions Instances
A side effect of the 2.0 changes is the switch to using named options instead of cookie options instances. The ability to customize the Identity cookie scheme names is removed.

For example, 1.x applications use constructor injection to pass an `IdentityCookieOptions` parameter into *AccountController.cs*. The external cookie authentication scheme is accessed from the provided instance:

[!code-csharp[Main](../migration/1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Controllers/AccountController.cs?name=snippet_AccountControllerConstructor&highlight=4,11)]

In 2.x applications, this changes to:

[!code-csharp[Main](../migration/1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/Controllers/AccountController.cs?name=snippet_AccountControllerConstructor&highlight=10)]

### IdentityUser POCO Navigation Properties
The Entity Framework Core navigation properties of the base `IdentityUser` POCO (Plain Old CLR Object) have been removed. If your 1.x application used these properties, manually add them back to the 2.x application:

```csharp
/// <summary>
/// Navigation property for the roles this user belongs to.
/// </summary>
public virtual ICollection<TUserRole> Roles { get; } = new List<TUserRole>();

/// <summary>
/// Navigation property for the claims this user possesses.
/// </summary>
public virtual ICollection<TUserClaim> Claims { get; } = new List<TUserClaim>();

/// <summary>
/// Navigation property for this users login accounts.
/// </summary>
public virtual ICollection<TUserLogin> Logins { get; } = new List<TUserLogin>();
```

### Removal of GetExternalAuthenticationSchemes
This synchronous method `GetExternalAuthenticationSchemes` was removed in favor of an asynchronous version. 1.x applications have the following code in *ManageController.cs*:

[!code-csharp[Main](../migration/1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Controllers/ManageController.cs?name=snippet_ManageLogins&highlight=16)]

In 2.x applications, this changes to:

[!code-csharp[Main](../migration/1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/Controllers/ManageController.cs?name=snippet_ManageLogins&highlight=16-17)]

### ManageLoginsViewModel Property Change
A `ManageLoginsViewModel` object is used in the `ManageLogins` action of *ManageController.cs*. In 1.x applications, the object's `OtherLogins` property return type is `IList<AuthenticationDescription>`. This return type requires an import of `Microsoft.AspNetCore.Http.Authentication`:

[!code-csharp[Main](../migration/1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Models/ManageViewModels/ManageLoginsViewModel.cs?name=snippet_ManageLoginsViewModel&highlight=2,11)]

In 2.x applications, the return type changes to `IList<AuthenticationScheme>`. This new return type requires replacing the `Microsoft.AspNetCore.Http.Authentication` import  with a `Microsoft.AspNetCore.Authentication` import.

[!code-csharp[Main](../migration/1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/Models/ManageViewModels/ManageLoginsViewModel.cs?name=snippet_ManageLoginsViewModel&highlight=2,11)]

## Application Insights
ASP.NET Core 1.1 applications created in Visual Studio 2017 added Application Insights by default. This was accomplished via a three-step process:
1. Add the supporting NuGet package:

    [!code-xml[Main](../migration/1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App.csproj?range=10)]

2. Invoke the `UseApplicationInsights` extension method in *Program.cs*:

    [!code-csharp[Main](../migration/1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Program.cs?name=snippet_MainMethod&highlight=8)]

3. Add the client-side API call in *_Layout.cshtml*:

    [!code-csharp[Main](../migration/1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/Views/Shared/_Layout.cshtml?range=1,19)]

In 2.x, Application Insights isn't added by default. The application won't compile once you add the ASP.NET Core meta-package.

<!-- FIGURE OUT HOW TO ADD APP INSIGHTS IN 2.x -->

## Razor View Compilation
[Razor view compilation](xref:mvc/views/view-compilation) is enabled by default in ASP.NET Core 2.0. The *Views* folder and its Razor files are no longer present in the published bundle. Consequently, the published bundle is smaller and startup performance is noticeably improved.

In 1.x applications, view compilation is enabled by adding a reference to the `Microsoft.AspNetCore.Mvc.Razor.ViewCompilation` NuGet package and by manually adding and enabling the `MvcRazorCompileOnPublish` property:

[!code-xml[Main](../migration/1x-to-2x/samples/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App/AspNetCoreDotNetCore1.1App.csproj?highlight=4,16)]

The 2.x project templates add and enable the `MvcRazorCompileOnPublish` property by default. The meta-package reference imports the rest of the necessary view compilation bits.

[!code-xml[Main](../migration/1x-to-2x/samples/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App/AspNetCoreDotNetCore2.0App.csproj?highlight=4)]

## Publishing