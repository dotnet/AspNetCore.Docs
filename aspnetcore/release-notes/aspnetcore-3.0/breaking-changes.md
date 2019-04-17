---
title: Breaking changes in ASP.NET Core 3.0
author: natemcmaster
description: Learn about breaking changes in ASP.NET Core 3.0.
ms.author: natemcmaster
ms.date: 12/18/2018
uid: aspnetcore-3.0-breaking-changes
---

# Breaking changes in ASP.NET Core 3.0

The following API and behavior changes have the potential to break applications developed for ASP Core 2.2 when upgrading them to 3.0. Breaks in new features introduced from one 3.0 preview to another 3.0 preview aren't documented here.

## ASP.NET Core 3.0 will only run on .NET Core

As announced on the [.NET Blog][dotnet-blog] and [GitHub](https://github.com/aspnet/Announcements/issues/324), .NET Framework will get fewer of the newer platform and language features that come to .NET Core moving forward, due to the in-place update nature of .NET Framework and the desire to limit changes there that might break existing applications. To ensure ASP.NET Core can fully leverage the improvements coming to .NET Core moving forward, ASP.NET Core will only run on .NET Core starting from 3.0. Moving forward, you can simply think of ASP.NET Core as being part of .NET Core.

Customers utilizing ASP.NET Core on .NET Framework today can continue to do so in a fully supported fashion using the [2.1 LTS release][2.1-lts]. Support and servicing for 2.1 will continue indefinitely [to match the current support policy for the other package-based ASP.NET frameworks](https://www.asp.net/support), e.g. MVC 5.x, Web API 2.x, SignalR 2.x.

For more information about porting from .NET Framework to .NET Core, see our documentation on [Porting to .NET Core.](https://docs.microsoft.com/en-us/dotnet/core/porting/)

**Note** that this does not affect the following:
 
 * **Microsoft.Extensions** packages (such as logging, dependency injection, and config) will continue to support .NET Standard
 * **Entity Framework Core** will continue to support .NET Standard

See [this blog post][aspnet-blog] for more details on the motivation for this change.

[2.1-lts]: https://www.microsoft.com/net/download/dotnet-core/2.1
[dotnet-blog]: https://blogs.msdn.microsoft.com/dotnet/2018/10/04/update-on-net-core-3-0-and-net-framework-4-8/
[aspnet-blog]: https://blogs.msdn.microsoft.com/webdev/2018/10/29/a-first-look-at-changes-coming-in-asp-net-core-3-0

## Breaking changes to Microsoft.AspNetCore.App

Starting in 3.0, the ASP.NET Core shared framework (`Microsoft.AspNetCore.App`) will only contain first-party assemblies that are fully developed, supported, and serviceable by Microsoft. You can think of this as constituting the ASP.NET Core “platform.” It will be fully [source buildable by anybody via GitHub](https://github.com/dotnet/source-build) and will continue to bring all the existing benefits of .NET Core shared frameworks to your applications moving forward (smaller deployment size, centralized patching, faster startup time, etc.). 

As part of this change, some notable breaking changes will be made in Microsoft.AspNetCore.App 3.0.

### Removal of some sub-components, such as Newtonsoft.Json, Entity Framework Core, and Roslyn

As part of this change, some notable sub-components will be removed from the ASP.NET Core shared framework in 3.0: 

* Json.NET (Newtonsoft.Json)
* Entity Framework Core (Microsoft.EntityFrameworkCore.\*) 
* Microsoft.CodeAnalysis (Roslyn)

Entity Framework Core will ship as “pure” NuGet packages in 3.0. This makes its shipping model the same as all other data access libraries on .NET, and allows it the simplest path to continue innovation while providing support for all the various .NET platforms customers enjoy it on today. Note, Entity Framework Core moving out of the shared framework has no impact on its status as a Microsoft developed, supported, and serviceable library, and it will continue to be covered by the [.NET Core support policy.](https://www.microsoft.com/net/platform/support-policy)

Json.NET or Entity Framework Core will continue to work with ASP.NET Core, but they will not be "in the box" with the shared framework.

See ["The future of JSON in .NET Core 3.0"](https://github.com/dotnet/announcements/issues/90) for details on our plans to remove the dependency from ASP.NET Core to Json.NET and replace it with high-performance JSON APIs.

We have separately posted [a complete list of exact binaries](https://github.com/aspnet/AspNetCore/issues/3755) that are being removed. This list may fluctuate as we continue to work on ASP.NET Core 3.0.

### Removal of the PackageReference to Microsoft.AspNetCore.App from project files

Issue [aspnet/AspNetCore#3612](https://github.com/aspnet/AspNetCore/issues/3612)

References to Microsoft.AspNetCore.App will no longer be a `<PackageReference>` element in the project file. The .NET Core SDK will support a new item called
`<FrameworkReference>` which will replace the use of PackageReference. 

```xml
<ItemGroup>
   <FrameworkReference Include="Microsoft.AspNetCore.App" />
</ItemGroup>
```

### Reducing the duplication between NuGet packages and shared frameworks

As result these changes, it will not be necessary for projects to consume assemblies in Microsoft.AspNetCore.App as NuGet packages. To simplify the way in which consumers target and use the ASP.NET Core shared framework, we will stop producing many of the NuGet packages that we have been shipping since ASP.NET Core 1.0. The API those packages provide are still available to apps by using a `<FrameworkReference>` to Microsoft.AspNetCore.App. This includes commonly referenced API, such as Kestrel, Mvc, Razor, and others.

This will not apply to all binaries that are pulled in via Microsoft.AspNetCore.App in 2.x. Notable exceptions include:

* Microsoft.Extensions libraries which continue to target .NET Standard will be available as NuGet packages (see https://github.com/aspnet/Extensions)
* API produced by the ASP.NET Core team which is not part of Microsoft.AspNetCore.App. For example, Entity Framework Core, API which provides 3rd party integration, experimental features, or API which has dependencies that could not [satisy the requirements to be in the shared framework](https://github.com/aspnet/AspNetCore/blob/4e44e5bcbedd961cc0d4f6b846699c7c494f5597/docs/SharedFramework.md) will ship as NuGet packages and not in the shared framework.
* Extensions to MVC that maintain support for Json.NET. We intend to provide API as a NuGet package to support using Json.NET and MVC.
* The SignalR .NET client will continue to support .NET Standard and ship as NuGet package because it is intended for use on many .NET runtimes, like Xamarin and UWP.

For more details, see the [complete list of packages that will only be obsolete in favor of `<FrameworkReference>`.](https://github.com/aspnet/AspNetCore/issues/3756) This list may fluctuate as we continue to work on ASP.NET Core 3.0.

## Deprecation of Microsoft.AspNetCore.All package

Issue [aspnet/AspNetCore#3418](https://github.com/aspnet/AspNetCore/issues/3418)

The Microsoft.AspNetCore.All meta-package will not be produced for ASP.NET Core 3.0 and future versions. This package was created in ASP.NET Core 2.x and will continue to be updated throughout the 2.x lifecycle.
The recommended replacement is a framework reference to Microsoft.AspNetCore.App. This may require adding package references for API that is still available in 3.0, but not included in Microsoft.AspNetCore.App.

## Removal of APIs previously marked as obsolete

Issue [aspnet/AspNetCore#3654](https://github.com/aspnet/AspNetCore/issues/3654)

In ASP.NET Core 2, we began to mark APIs as obsolete and recommending replacements. In ASP.NET Core 3.0, we have removed all APIs that were marked as obsolete in previous versions of ASP.NET Core.