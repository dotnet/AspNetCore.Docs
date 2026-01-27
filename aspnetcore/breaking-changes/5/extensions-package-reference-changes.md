---
title: "Breaking change: Extensions: Package reference changes affecting some NuGet packages"
description: "Learn about the breaking change in ASP.NET Core 5.0 titled Extensions: Package reference changes affecting some NuGet packages"
ms.author: scaddie
ms.date: 10/01/2020
ms.custom: https://github.com/aspnet/Announcements/issues/411
---
# Extensions: Package reference changes affecting some NuGet packages

With the migration of some `Microsoft.Extensions.*` NuGet packages from the [dotnet/extensions](https://github.com/dotnet/extensions) repository to [dotnet/runtime](https://github.com/dotnet/runtime), as described in [aspnet/Announcements#411](https://github.com/aspnet/Announcements/issues/411), packaging changes are being applied to some of the migrated packages. For discussion on this issue, see [dotnet/aspnetcore#21033](https://github.com/dotnet/aspnetcore/issues/21033).

## Version introduced

5.0 Preview 4

## Old behavior

Some `Microsoft.Extensions.*` packages included package references for APIs on which your app relied.

## New behavior

Your app may have to add `Microsoft.Extensions.*` package dependencies.

## Reason for change

Packaging policies were updated to better align with the *dotnet/runtime* repository. Under the new policy, unused package references are removed from *.nupkg* files during packaging.

## Recommended action

Consumers of the affected packages should add a direct dependency on the removed package dependency in their project if APIs from removed package dependency are used. The following table lists the affected packages and the corresponding changes.

|Package name|Change description|
|------------|------------------|
|[Microsoft.Extensions.Configuration.Binder](https://nuget.org/packages/Microsoft.Extensions.Configuration.Binder)|Removed reference to `Microsoft.Extensions.Configuration`|
|[Microsoft.Extensions.Configuration.Json](https://nuget.org/packages/Microsoft.Extensions.Configuration.Json)    |Removed reference to `System.Threading.Tasks.Extensions`|
|[Microsoft.Extensions.Hosting.Abstractions](https://nuget.org/packages/Microsoft.Extensions.Hosting.Abstractions)|Removed reference to `Microsoft.Extensions.Logging.Abstractions`|
|[Microsoft.Extensions.Logging](https://nuget.org/packages/Microsoft.Extensions.Logging)                          |Removed reference to `Microsoft.Extensions.Configuration.Binder`|
|[Microsoft.Extensions.Logging.Console](https://nuget.org/packages/Microsoft.Extensions.Logging.Console)          |Removed reference to `Microsoft.Extensions.Configuration.Abstractions`|
|[Microsoft.Extensions.Logging.EventLog](https://nuget.org/packages/Microsoft.Extensions.Logging.EventLog)        |Removed reference to `System.Diagnostics.EventLog` for the .NET Framework 4.6.1 target framework moniker|
|[Microsoft.Extensions.Logging.EventSource](https://nuget.org/packages/Microsoft.Extensions.Logging.EventSource)  |Removed reference to `System.Threading.Tasks.Extensions`|
|[Microsoft.Extensions.Options](https://nuget.org/packages/Microsoft.Extensions.Options)                          |Removed reference to `System.ComponentModel.Annotations`|

For example, the package reference to `Microsoft.Extensions.Configuration` was removed from `Microsoft.Extensions.Configuration.Binder`. No API from the dependency was used in the package. Users of `Microsoft.Extensions.Configuration.Binder` who depend on APIs from `Microsoft.Extensions.Configuration` should add a direct reference to it in their project.

## Affected APIs

None

<!--

### Category

ASP.NET Core

### Affected APIs

Not detectable via API analysis

-->
