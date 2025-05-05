---
title: Host and deploy ASP.NET Core standalone Blazor WebAssembly with Azure Static Web Apps
author: guardrex
description: Learn how to host and deploy standalone Blazor WebAssembly with Microsoft Azure Static Web Apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 03/31/2025
uid: blazor/host-and-deploy/webassembly/azure-static-web-apps
---
# Host and deploy ASP.NET Core standalone Blazor WebAssembly with Azure Static Web Apps

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to host and deploy standalone Blazor WebAssembly with [Microsoft Azure Static Web Apps](https://azure.microsoft.com/products/app-service/static).

## Deploy from Visual Studio

To deploy from Visual Studio, create a publish profile for Azure Static Web Apps:

1. Save any unsaved work in the project, as a Visual Studio restart might be required during the process.

1. In Visual Studio's **Publish** UI, select **Target** > **Azure** > **Specific Target** > **Azure Static Web Apps** to create a [publish profile](xref:host-and-deploy/visual-studio-publish-profiles).

1. If the **Azure WebJobs Tools** component for Visual Studio isn't installed, a prompt appears to install the **ASP.NET and web development** component. Follow the prompts to install the tools using the Visual Studio Installer. Visual Studio closes and reopens automatically while installing the tools. After the tools are installed, start over at the first step to create the publish profile.

1. In the publish profile configuration, provide the **Subscription name**. Select an existing instance, or select **Create a new instance**. When creating a new instance in the Azure portal's **Create Static Web App** UI, set the **Deployment details** > **Source** to **Other**. Wait for the deployment to complete in the Azure portal before proceeding.

1. In the publish profile configuration, select the Azure Static Web Apps instance from the instance's resource group. Select **Finish** to create the publish profile. If Visual Studio prompts to install the Static Web Apps (SWA) CLI, install the CLI by following the prompts. The SWA CLI requires [NPM/Node.js (Visual Studio documentation)](/visualstudio/javascript/npm-package-management).

After the publish profile is created, deploy the app to the Azure Static Web Apps instance using the publish profile by selecting the **Publish** button.

## Deploy from Visual Studio Code

To deploy from Visual Studio Code, see [Quickstart: Build your first static site with Azure Static Web Apps](/azure/static-web-apps/getting-started?tabs=blazor).

## Deploy from GitHub

To deploy from a GitHub repository, see [Tutorial: Building a static web app with Blazor in Azure Static Web Apps](/azure/static-web-apps/deploy-blazor).
