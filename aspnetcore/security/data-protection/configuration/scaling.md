---
title: Configure ASP.NET Core Data Protection in distributed or load-balanced environments
author: acasey
description: Learn how to configure Data Protection in ASP.NET Core for multi-instance apps.
ms.author: acasey
ms.custom: mvc
ms.date: 7/15/2024
uid: security/data-protection/configuration/scaling
---

# Configure ASP.NET Core Data Protection in distributed or load-balanced environments

:::moniker range=">= aspnetcore-8.0"

ASP.NET Core [Data Protection](xref:security/data-protection/introduction) is a library that provides a cryptographic API to protect data. Data Protection protects anti-forgery tokens, authentication cookies, and other sensitive data. However, in some distributed environments that don't utilize shared storage, when an app scales horizontally by adding more instances:

* It's necessary to explicitly configure Data Protection to establish a shared storage location for Data Protection keys.
* There’s ***NO*** guarantee that the HTTP POST request, used to submit a form, will be routed to the same instance that served the initial page via an HTTP GET request. If the requests are handled by different instances, the antiforgery tokens aren’t synchronized, and an exception occurs.

The following distributed environments provide automatic key storage in a shared location:

* [Azure apps](/aspnet/core/security/data-protection/configuration/default-settings).
* Newly created <!-- what does newly created mean? --> Azure Container Apps built using ASP.NET Core Kestrel <!-- 8.0 and later We don't like to have version information in an article when it's not needed. Given the moniker for this content is 8.0+, we'd normally leave out that redundant info. However, we make exceptions. I can leave 8.0 in if you think it's helpful -->. For more information see [Autoscaling considerations
](/azure/container-apps/dotnet-overview#autoscaling-considerations).
* Azure Apps. For more information see <xref:security/data-protection/configuration/default-settings#key-management>.

The following distributed environments do ***NOT*** provide automatic key storage in a shared location:

* Separate [deployment slots](/azure/app-service/deploy-staging-slots), such as Staging and Production. When the app is swapped between deployment slots, any app using Data Protection won't be able to decrypt stored data using the key ring inside the previous slot. For example, swapping Staging to Production or using A/B testing, Data Protection is not synchronized.
* Asp.net core apps hosted on multiple VMs that don't use [Application Request Routing cookies]/azure/app-service/manage-automatic-scaling?#how-does-arr-affinity-affect-automatic-scaling), known as an ARR Affinity.
* Azure Container Apps built using ASP.NET Core Kestrel 7.0 or earlier. For more information see [Autoscaling considerations
](/azure/container-apps/dotnet-overview#autoscaling-considerations).

:::moniker-end

[!INCLUDE[](~/security/data-protection/configuration/scaling/includes/scaling7.md)]
