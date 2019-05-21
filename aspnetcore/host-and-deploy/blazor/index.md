---
title: Host and deploy Blazor
author: guardrex
description: Discover how to host and deploy Blazor apps.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/21/2019
uid: host-and-deploy/blazor/index
---
# Host and deploy Blazor

By [Luke Latham](https://github.com/guardrex), [Rainer Stropek](https://www.timecockpit.com), and [Daniel Roth](https://github.com/danroth27)

## Publish the app

Apps are published for deployment in Release configuration.

# [Visual Studio](#tab/visual-studio)

1. Select **Build** > **Publish {APPLICATION}** from the navigation bar.
1. Select the *publish target*. To publish locally, select **Folder**.
1. Accept the default location in the **Choose a folder** field or specify a different location. Select the **Publish** button.

# [Visual Studio Code / .NET Core CLI](#tab/visual-studio-code+netcore-cli)

Use the [dotnet publish](/dotnet/core/tools/dotnet-publish) command to publish the app with a Release configuration:

```console
dotnet publish -c Release
```

---

Publishing the app triggers a [restore](/dotnet/core/tools/dotnet-restore) of the project's dependencies and [builds](/dotnet/core/tools/dotnet-build) the project before creating the assets for deployment. As part of the build process, unused methods and assemblies are removed to reduce app download size and load times.

A Blazor client-side app is published to the */bin/Release/{TARGET FRAMEWORK}/publish/{ASSEMBLY NAME}/dist* folder. A Blazor server-side app is published to the */bin/Release/{TARGET FRAMEWORK}/publish* folder.

The assets in the folder are deployed to the web server. Deployment might be a manual or automated process depending on the development tools in use.

## Deployment

For deployment guidance, see the following topics:

* <xref:host-and-deploy/blazor/client-side>
* <xref:host-and-deploy/blazor/server-side>
