---
title: Host and deploy Blazor
author: guardrex
description: Discover how to host and deploy Blazor apps.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 04/15/2019
uid: host-and-deploy/blazor/index
---
# Host and deploy Blazor

By [Luke Latham](https://github.com/guardrex), [Rainer Stropek](https://www.timecockpit.com), and [Daniel Roth](https://github.com/danroth27)

## Publish the app

Apps are published for deployment in Release configuration with the [dotnet publish](/dotnet/core/tools/dotnet-publish) command. An integrated development environment (IDE) may handle executing the `dotnet publish` command automatically using its built-in publishing features, so it might not be necessary to manually execute the command from a command prompt depending on the development tools in use.

```console
dotnet publish -c Release
```

`dotnet publish` triggers a [restore](/dotnet/core/tools/dotnet-restore) of the project's dependencies and [builds](/dotnet/core/tools/dotnet-build) the project before creating the assets for deployment. As part of the build process, unused methods and assemblies are removed to reduce app download size and load times. The deployment is created in the */bin/Release/{TARGET FRAMEWORK}/publish* folder.

The assets in the *publish* folder are deployed to the web server. Deployment might be a manual or automated process depending on the development tools in use.

## Deployment

For deployment guidance, see the following topics:

* <xref:host-and-deploy/blazor/client-side>
* <xref:host-and-deploy/blazor/server-side>
