---
title: Configure the Trimmer for ASP.NET Core Blazor
author: guardrex
description: Learn how to control the Intermediate Language (IL) Trimmer when building a Blazor app.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/host-and-deploy/configure-trimmer
---
# Configure the Trimmer for ASP.NET Core Blazor

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to control the Intermediate Language (IL) Trimmer when building a Blazor app.

Blazor WebAssembly performs [Intermediate Language (IL)](/dotnet/standard/glossary#il) trimming to reduce the size of the published output. By default, trimming occurs when publishing an app.

Trimming may have detrimental effects. In apps that use [reflection](/dotnet/csharp/advanced-topics/reflection-and-attributes/), the Trimmer often can't determine the required types for reflection at runtime. To trim apps that use reflection, the Trimmer must be informed about required types for reflection in both the app's code and in the packages or frameworks that the app depends on. The Trimmer is also unable to react to an app's dynamic behavior at runtime. To ensure the trimmed app works correctly once deployed, test published output frequently while developing.

To configure the Trimmer, see the [Trimming options](/dotnet/core/deploying/trimming/trimming-options) article in the .NET Fundamentals documentation, which includes guidance on the following subjects:

* Disable trimming for the entire app with the `<PublishTrimmed>` property in the project file.
* Control how aggressively unused IL is discarded by the Trimmer.
* Stop the Trimmer from trimming specific assemblies.
* "Root" assemblies for trimming.
* Surface warnings for reflected types by setting the `<SuppressTrimAnalysisWarnings>` property to `false` in the project file.
* Control symbol trimming and debugger support.
* Set Trimmer features for trimming framework library features.

## Additional resources

* [Trim self-contained deployments and executables](/dotnet/core/deploying/trimming/trim-self-contained)
* <xref:blazor/performance#intermediate-language-il-trimming>
