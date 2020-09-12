---
title: Configure the Trimmer for ASP.NET Core Blazor
author: guardrex
description: Learn how to control the Intermediate Language (IL) Trimmer when building a Blazor app.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/19/2020
no-loc: ["ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/host-and-deploy/configure-trimmer
---
# Configure the Trimmer for ASP.NET Core Blazor

By [Luke Latham](https://github.com/guardrex)

Blazor WebAssembly performs [Intermediate Language (IL)](/dotnet/standard/managed-code#intermediate-language--execution) trimming during to reduce the size of the published output.  

Trimming an app optimizes for size but may have detrimental effects. Apps that use reflection or related dynamic features may break when trimmed because the trimmer doesn't know about this dynamic behavior and can't determine in general which types are required for reflection at runtime. To trim such apps, the trimmer must be informed about any types required by reflection in the code and in packages or frameworks that the app depends on. 

To ensure the trimmed app works correctly once deployed, it's important to test your published output frequently while developing.

Trimming for .NET apps can be disabled by configuring the `PublishTrimmed` MSBuild property:

```xml
<PropertyGroup>
  <!-- This disables trimming of the app resulting in a much larger app size -->
  <PublishTrimmed>false</PublishTrimmed>
</PropertyGroup>

For more details on how the trimmer works and additional options to configure it, see <xref:dotnet/core/deploying/trim-self-contained />