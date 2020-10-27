---
title: Configure the Trimmer for ASP.NET Core Blazor
author: guardrex
description: Learn how to control the Intermediate Language (IL) Linker (Trimmer) when building a Blazor app.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 09/14/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/host-and-deploy/configure-trimmer
---
# Configure the Trimmer for ASP.NET Core Blazor

By [Pranav Krishnamoorthy](https://github.com/pranavkm)

Blazor WebAssembly performs [Intermediate Language (IL)](/dotnet/standard/managed-code#intermediate-language--execution) trimming to reduce the size of the published output.

Trimming an app optimizes for size but may have detrimental effects. Apps that use reflection or related dynamic features may break when trimmed because the trimmer doesn't know about dynamic behavior and can't determine in general which types are required for reflection at runtime. To trim such apps, the trimmer must be informed about any types required by reflection in the code and in packages or frameworks that the app depends on.

To ensure the trimmed app works correctly once deployed, it's important to test published output frequently while developing.

Trimming for .NET apps can be disabled by setting the `PublishTrimmed` MSBuild property to `false` in the app's project file:

```xml
<PropertyGroup>
  <PublishTrimmed>false</PublishTrimmed>
</PropertyGroup>
```
Additional options to configure the trimmer can be found at [Trimming options](/dotnet/core/deploying/trimming-options).

## Additional resources

* [Trim self-contained deployments and executables](/dotnet/core/deploying/trim-self-contained)
* <xref:blazor/webassembly-performance-best-practices#intermediate-language-il-trimming>
