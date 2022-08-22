---
title: Scaling ASP.NET Core Apps on Azure
author: alexwolfmsft
description: Learn how to horizontally scale ASP.NET Core apps on Azure and address common architectural challenges
monikerRange: '>= aspnetcore-2.1'
ms.author: alexwolf
ms.custom: mvc
ms.date: 07/28/2020
uid: host-and-deploy/visual-studio-publish-profiles
---
# Deploying and scaling an ASP.NET Core on Azure

Applications deployed to Azure must be able to scale in order to fully leverage cloud benefits. Properly architected apps should be able to dynamically scale horizontally across any number of instances without producing errors. ASP.NET Core apps are able to meet these requirements, but developers must implement certain configurations and architectural patterns to ensure success. This tutorial will demonstrate how to deploy a scalable Razor Pages app to Azure container apps by completing the following tasks:

1. Create a containerized ASP.NET Core app
1. Create the required Azure services for scaling
1. Perform code configurations to integrate with Azure services
1. Deploy the app to Azure Container Apps
1. Scale and configure the deployed app

In some cases, simple ASP.NET Core apps are able to scale without special considerations. However, apps that utilize certain framework features or architectural patterns require additional configurations, including the following:

* **Secure form submissions**: Razor Pages, MVC and Web API apps often rely on form submissions. By default these apps use cross site forgery tokens and internal data protection services to secure requests. When deployed to the cloud, these apps must be configured to use a managed data protection service concerns in a secure, centralized location.

* **SignalR circuits**: Blazor Server applications require the use of a centralized Azure SignalR service in order to scale properly and securely. These services also utilize the data protection services mentioned previously.

* **Centralized caching or state management services**: Scalable applications may use Azure Cache for Redis to provide distributed caching. Azure storage may be needed to store state for frameworks such as Orleans, which can assist in writing apps that manage state across many different app instances.

The steps ahead demonstrate how to properly address these concerns by deploying a scalable app to Azure Container Apps. Most of the concepts in this tutorial also apply when scaling Azure App Service instances.

## 1) Create a containerized ASP.NET Core app

This tutorial uses a Razor Pages app to demonstrate the concepts ahead. However, the same steps and concepts also apply to MVC and Web API projects.

1. On the main navigation menu in Visual Studio, select **File > New > Project...**.

1. In the **Create a new project** dialog, search for and select the  **ASP.NET Core Web App** template, and then choose **Next**.

1. For the **Project name**, enter *ScalableRazor* and choose a location for the project. Leave the rest of the settings at their default and select **Next**.

1. On the **Additional Information** dialog, make sure **.NET 6.0** is selected. Leave the default values for the other fields, and then choose **Create**.

Visual Studio will generate a new Razor Pages project for you.

## 2) Create the Azure Services

To host and scale a .NET app you'll need to create one or more services in Azure. These services will handle common concerns such as application hosting, storage, caching, secrets and more. For this tutorial you'll need to create the following services:

* **Azure Container App**: This service will host your containerized app and scale to multiple instances as needed.
* **Azure Storage Account**: The storage service will handle storing data for the Data Protection Services of your app. This provides a centralized location to store key data as the app scales. Storage accounts can also be used to hold documents, queue data, file shares, and almost any type of blob data.
* **Azure KeyVault**: This service will be used to store secrets for your application, and be used to help manage encryption concerns for the Data Protection Services.

### Create the Container App service

1. In the Azure portal search bar, enter *Container Apps* and select the matching result.
1. On the Container Apps listing page, select **+ Create**.
1. On the **Basics** tab, enter the following values:
    * **Subscription**: Select the subscription you'd like to use.
    * **Resource Group**: Choose **Create New** and name the new resource group *msdocs-scalable-razor*.
    * **Container app name**: Enter a value of *scalablerazor*.
    * **Region**: Select a region close to your location.
    * **Container Apps Environment**: Choose **Create new** and name the environment **scalablerazorenv**. Leave the rest of the settings at their default and select **Create**.
1. Azure will take a moment to provision the new services. When the task completes, click **Go to resource** to view your new container app.

### Create the Storage Account service

1. In the Azure Portal search bar, enter *Storage account* and select the matching result.
1. On the storage accounts listing page, select **+ Create**.
1. On the **Basics** tab, enter the following values:
    * **Subscription**: Select the same subscription that chose for you Container App.
    * **Resource Group**: Select the *msdocs-scalable-razor* resource group you created previously.
    * **Storage account name**: Name the account scalablerazorXXXX where the X's are random numbers of your choosing. This name must be unique across all of Azure.
    * **Region**: Select a region that is close to you.
1. Leave the rest of the values at their default and select **Review**. After Azure validates your inputs, select **Create**.
1. Azure will take a moment to provision the new storage account. When it completes, click **Go to resource** to view the new service.


### Create the Key Vault service