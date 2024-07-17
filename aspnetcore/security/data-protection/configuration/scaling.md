---
title: Configure ASP.NET Core Data Protection in distributed or load-balanced environments
author: acasey
description: Learn how to configure Data Protection in ASP.NET Core for multi-instance apps.
ms.author: acasey
ms.date: 7/18/2024
content_well_notification: AI-contribution
ms.prod: aspnet-core
uid: security/data-protection/configuration/scaling
---

# Configure ASP.NET Core Data Protection in distributed or load-balanced environments

:::moniker range=">= aspnetcore-8.0"

ASP.NET Core [Data Protection](xref:security/data-protection/introduction) is a library that provides a cryptographic API to protect data. Data Protection protects anti-forgery tokens, authentication cookies, and other sensitive data. However, in some distributed environments that don't put data protection keys in shared storage, when an app scales horizontally by adding more instances:

* It's necessary to explicitly configure Data Protection to establish a shared storage location for Data Protection keys.
* There’s ***NO*** guarantee that the HTTP POST request, used to submit a form, will be routed to the same instance that served the initial page via an HTTP GET request. If the requests are handled by different instances, the antiforgery tokens aren’t synchronized, and an exception occurs. Sticky sessions via [ARR Affinity](/azure/app-service/manage-automatic-scaling?#how-does-arr-affinity-affect-automatic-scaling) routes user requests to the same node, however, ARR can reduce the scalability of a web farm.

The following distributed environments provide automatic key storage in a shared location:

* [Azure apps](/aspnet/core/security/data-protection/configuration/default-settings).  For more information see <xref:security/data-protection/configuration/default-settings#key-management>.
* Newly created Azure Container Apps built using ASP.NET Core Kestrel. For more information see [Autoscaling considerations
](/azure/container-apps/dotnet-overview#autoscaling-considerations).

The following distributed environments do ***NOT*** provide automatic key storage in a shared location:

* Separate [deployment slots](/azure/app-service/deploy-staging-slots), such as Staging and Production.
* Azure Container Apps built using ASP.NET Core Kestrel 7.0 or earlier. For more information see [Autoscaling considerations
](/azure/container-apps/dotnet-overview#autoscaling-considerations).
* Asp.net core apps hosted on multiple non-Azure VMs that don't use server affinity.

:::moniker-end

[!INCLUDE[](~/security/data-protection/configuration/scaling/includes/scaling7.md)]
