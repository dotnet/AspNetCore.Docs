---
title: Microsoft.AspNetCore.All metapackage for ASP.NET Core 2.0
author: Rick-Anderson
description: The Microsoft.AspNetCore.All metapackage is not recommended for ASP.NET Core 2.1 and later.
monikerRange: '>= aspnetcore-2.0'
ms.author: riande
ms.custom: mvc
ms.date: 10/25/2018
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: fundamentals/metapackage
---
# Microsoft.AspNetCore.All metapackage for ASP.NET Core 2.0

:::moniker range=">= aspnetcore-3.0"

The `Microsoft.AspNetCore.All` metapackage isn't included in ASP.NET Core 3.0 and later. For more information, see [this GitHub issue](https://github.com/aspnet/Announcements/issues/314).

:::moniker-end

> [!NOTE]
> We recommend applications targeting ASP.NET Core 2.1 and later use the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app) rather than this package. See [Migrating from Microsoft.AspNetCore.All to Microsoft.AspNetCore.App](#migrate) in this article.

This feature requires ASP.NET Core 2.x targeting .NET Core 2.x.

[Microsoft.AspNetCore.All](https://www.nuget.org/packages/Microsoft.AspNetCore.All) is a metapackage that refers to a shared framework. A *shared framework* is a set of assemblies (*.dll* files) that are not in the app's folders. The shared framework must be installed on the machine to run the app. For more information, see [The shared framework](https://natemcmaster.com/blog/2018/08/29/netcore-primitives-2/).

The shared framework that `Microsoft.AspNetCore.All` refers to includes:

* All supported packages by the ASP.NET Core team.
* All supported packages by the Entity Framework Core.
* Internal and 3rd-party dependencies used by ASP.NET Core and Entity Framework Core.

All the features of ASP.NET Core 2.x and Entity Framework Core 2.x are included in the `Microsoft.AspNetCore.All` package. The default project templates targeting ASP.NET Core 2.0 use this package.

The version number of the `Microsoft.AspNetCore.All` metapackage represents the minimum ASP.NET Core version and Entity Framework Core version.

The following `.csproj` file references the `Microsoft.AspNetCore.All` metapackage for ASP.NET Core:

[!code-xml[](metapackage/samples/Metapackage.All.Example.csproj?highlight=8)]

:::moniker range=">= aspnetcore-2.1"

## Implicit versioning

In ASP.NET Core 2.1 or later, you can specify the `Microsoft.AspNetCore.All` package reference without a version. When the version isn't specified, an implicit version is specified by the SDK (`Microsoft.NET.Sdk.Web`). We recommend relying on the implicit version specified by the SDK and not explicitly setting the version number on the package reference. If you have questions about this approach, leave a GitHub comment at the [Discussion for the Microsoft.AspNetCore.App implicit version](https://github.com/dotnet/AspNetCore.Docs/issues/6430).

The implicit version is set to `major.minor.0` for portable apps. The shared framework roll-forward mechanism runs the app on the latest compatible version among the installed shared frameworks. To guarantee the same version is used in development, test, and production, ensure the same version of the shared framework is installed in all environments. For self-contained apps, the implicit version number is set to the `major.minor.patch` of the shared framework bundled in the installed SDK.

Specifying a version number on the `Microsoft.AspNetCore.All` package reference does **not** guarantee that version of the shared framework is chosen. For example, suppose version "2.1.1" is specified, but "2.1.3" is installed. In that case, the app will use "2.1.3". Although not recommended, you can disable roll forward (patch and/or minor). For more information regarding dotnet host roll-forward and how to configure its behavior, see [dotnet host roll forward](https://github.com/dotnet/core-setup/blob/master/Documentation/design-docs/roll-forward-on-no-candidate-fx.md).

The project's SDK must be set to `Microsoft.NET.Sdk.Web` in the project file to use the implicit version of `Microsoft.AspNetCore.All`. When the `Microsoft.NET.Sdk` SDK is specified (`<Project Sdk="Microsoft.NET.Sdk">` at the top of the project file), the following warning is generated:

*Warning NU1604: Project dependency Microsoft.AspNetCore.All does not contain an inclusive lower bound. Include a lower bound in the dependency version to ensure consistent restore results.*

This is a known issue with the .NET Core 2.1 SDK and will be fixed in the .NET Core 2.2 SDK.

:::moniker-end

<a name="migrate"></a>

## Migrating from Microsoft.AspNetCore.All to Microsoft.AspNetCore.App

The following packages are included in `Microsoft.AspNetCore.All` but not the `Microsoft.AspNetCore.App` package.

* `Microsoft.AspNetCore.ApplicationInsights.HostingStartup`
* `Microsoft.AspNetCore.AzureAppServices.HostingStartup`
* `Microsoft.AspNetCore.AzureAppServicesIntegration`
* `Microsoft.AspNetCore.DataProtection.AzureKeyVault`
* `Microsoft.AspNetCore.DataProtection.AzureStorage`
* `Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv`
* `Microsoft.AspNetCore.SignalR.Redis`
* `Microsoft.Data.Sqlite`
* `Microsoft.Data.Sqlite.Core`
* `Microsoft.EntityFrameworkCore.Sqlite`
* `Microsoft.EntityFrameworkCore.Sqlite.Core`
* `Microsoft.Extensions.Caching.Redis`
* `Microsoft.Extensions.Configuration.AzureKeyVault`
* `Microsoft.Extensions.Logging.AzureAppServices`
* `Microsoft.VisualStudio.Web.BrowserLink`

To move from `Microsoft.AspNetCore.All` to `Microsoft.AspNetCore.App`, if your app uses any APIs from the above packages, or packages brought in by those packages, add references to those packages in your project.

Any dependencies of the preceding packages that otherwise aren't dependencies of `Microsoft.AspNetCore.App` are not included implicitly. For example:

* `StackExchange.Redis` as a dependency of `Microsoft.Extensions.Caching.Redis`
* `Microsoft.ApplicationInsights` as a dependency of `Microsoft.AspNetCore.ApplicationInsights.HostingStartup`

## Update ASP.NET Core 2.1

We recommend migrating to the `Microsoft.AspNetCore.App` metapackage for 2.1 and later. To keep using the `Microsoft.AspNetCore.All` metapackage and ensure the latest patch version is deployed:

* On development machines and build servers: Install the latest [.NET Core SDK](https://dotnet.microsoft.com/download).
* On deployment servers: Install the latest [.NET Core runtime](https://dotnet.microsoft.com/download).
 Your app will roll forward to the latest installed version on an application restart.
