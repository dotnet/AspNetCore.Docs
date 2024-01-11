---
title: Configure the Trimmer for ASP.NET Core Blazor
author: guardrex
description: Learn how to control the Intermediate Language (IL) Trimmer when building a Blazor app.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/host-and-deploy/configure-trimmer
---
# Configure the Trimmer for ASP.NET Core Blazor

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to control the Intermediate Language (IL) Trimmer when building a Blazor app.

Blazor WebAssembly performs [Intermediate Language (IL)](/dotnet/standard/glossary#il) trimming to reduce the size of the published output. By default, trimming occurs when publishing an app.

Trimming may have detrimental effects for the published app. In apps that use [reflection](/dotnet/csharp/advanced-topics/reflection-and-attributes/), the IL Trimmer often can't determine the required types for runtime reflection and trim them away. For example, complex framework types for JS interop, such as <xref:System.Collections.Generic.KeyValuePair>, might be trimmed by default and not available at runtime for JS interop calls. In these cases, we recommend creating your own custom types instead. The IL Trimmer is also unable to react to an app's dynamic behavior at runtime. To ensure the trimmed app works correctly once deployed, test published output frequently while developing.

To configure the IL Trimmer, see the [Trimming options](/dotnet/core/deploying/trimming/trimming-options) article in the .NET Fundamentals documentation, which includes guidance on the following subjects:

* Disable trimming for the entire app with the `<PublishTrimmed>` property in the project file.
* Control how aggressively unused IL is discarded by the IL Trimmer.
* Stop the IL Trimmer from trimming specific assemblies.
* "Root" assemblies for trimming.
* Surface warnings for reflected types by setting the `<SuppressTrimAnalysisWarnings>` property to `false` in the project file.
* Control symbol trimming and debugger support.
* Set IL Trimmer features for trimming framework library features.

## Additional resources

* [Trim self-contained deployments and executables](/dotnet/core/deploying/trimming/trim-self-contained)
* <xref:blazor/performance#intermediate-language-il-trimming>
