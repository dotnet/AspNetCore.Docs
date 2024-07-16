---
title: Configure ASP.NET Core Data Protection in distributed or load-balanced environments
author: acasey
description: Learn how to configure Data Protection in ASP.NET Core for multi-instance apps.
monikerRange: '>= aspnetcore-6.0'
ms.author: acasey
ms.custom: mvc
ms.date: 7/15/2024
uid: security/data-protection/configuration/scaling
---

# Configure ASP.NET Core Data Protection in distributed or load-balanced environments


ASP.NET Core [Data Protection](xref:security/data-protection/introduction) is a library that provides a cryptographic API to protect data. It is used by ASP.NET Core to protect anti-forgery tokens, authentication cookies, and other sensitive data. Data Protection is designed to be easy to use and secure by default. However, when an app scales horizontally by adding more instances, it becomes necessary to explicitly configure Data Protection to establish a shared storage location for Data Protection keys. Otherwise, instances won't recognize each other's keys. As a result, they will fail to decrypt anti-forgery tokens encrypted by other instances. For example, a form fetched by GET in one instance but POSTed to another instance will fail.

There are a variety of ways to make Data Protection work with multiple app instances. The most general to is explicitly establish a shared location for Data Protection keys. See <xref:host-and-deploy/scaling-aspnet-apps/scaling-aspnet-apps>, which shows how to configure a shared location for Data Protection keys using Azure Blob Storage.

Newly created Azure Container Apps built using ASP.NET Core Kestrel 8.0 and later also benefit from automatic configuration. For more information see [Autoscaling considerations
](/azure/container-apps/dotnet-overview#autoscaling-considerations).

Azure Apps also support automatic key sharing.  For more information see <xref:security/data-protection/configuration/default-settings#key-management>.

## Custom key management for Data Protection on multiple instances

The `ReadOnlyDataProtectionKeyDirectory` environment variable can be used to specify a shared location for Data Protection keys when implementing a custom key management solution. Setting the `ReadOnlyDataProtectionKeyDirectory` environment variable disables generation of new keys so write access to the directory is not required.
