---
title: Host and deploy ASP.NET Core standalone Blazor WebAssembly with Azure Static Web Apps
author: guardrex
description: Learn how to host and deploy standalone Blazor WebAssembly with Microsoft Azure Static Web Apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 11/11/2025
uid: blazor/host-and-deploy/webassembly/azure-static-web-apps
---
# Host and deploy ASP.NET Core standalone Blazor WebAssembly with Azure Static Web Apps

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to host and deploy standalone Blazor WebAssembly with [Microsoft Azure Static Web Apps](https://azure.microsoft.com/products/app-service/static).

## App configuration

To ensure that requests for any path return `index.html`, set a navigation fallback route.

Create a file named `staticwebapp.config.json` in the project's root folder with the following content:

```json
{
  "navigationFallback": {
    "rewrite": "/index.html"
  }
}
```

## Deploy from Visual Studio

To deploy a standalone Blazor WebAssembly app from Visual Studio:

* Save any unsaved work in the project, as a Visual Studio restart might be required during the process.
* Follow the guidance at [Deploy a Blazor app on Azure Static Web Apps: Deploy from Visual Studio (Azure Static Web Apps documentation)](/azure/static-web-apps/deploy-blazor#deploy-from-visual-studio).

## GitHub deployment scenarios

* Visual Studio Code: [Quickstart: Build your first static site with Azure Static Web Apps](/azure/static-web-apps/getting-started?tabs=blazor)
* .NET CLI: [Deploy Blazor websites to the cloud with Azure Static Web Apps (Video)](/shows/deploy-websites-to-the-cloud-with-azure-static-web-apps/deploy-blazor-websites-to-the-cloud-with-azure-static-web-apps)
* Deploy from GitHub: [Tutorial: Building a static web app with Blazor in Azure Static Web Apps](/azure/static-web-apps/deploy-blazor)
