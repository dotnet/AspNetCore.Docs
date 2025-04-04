---
title: Configure ASP.NET Core Data Protection in distributed or load-balanced environments
author: acasey
description: Learn how to configure Data Protection in ASP.NET Core for multi-instance apps.
ms.author: acasey
ms.date: 7/18/2024
content_well_notification: AI-contribution
uid: security/data-protection/configuration/scaling
---

# Configure ASP.NET Core Data Protection in distributed or load-balanced environments

:::moniker range=">= aspnetcore-8.0"

ASP.NET Core [Data Protection](xref:security/data-protection/introduction) is a library that provides a cryptographic API to protect data. Data Protection protects anti-forgery tokens, authentication cookies, and other sensitive data. However, in some distributed environments that don't put data protection keys in shared storage, when an app scales horizontally by adding more instances:

* It's necessary to explicitly configure Data Protection to establish a shared storage location for Data Protection keys.
* There’s ***NO*** guarantee that the HTTP POST request, used to submit a form, will be routed to the same instance that served the initial page via an HTTP GET request. If the requests are handled by different instances, the anti-forgery tokens aren’t synchronized, and an exception occurs. Sticky sessions via [ARR Affinity](/azure/app-service/manage-automatic-scaling?#how-does-arr-affinity-affect-automatic-scaling) routes user requests to the same node. However, ARR can reduce the scalability of a web farm.

The following distributed environments provide automatic key storage in a shared location:

* [Azure apps](/aspnet/core/security/data-protection/configuration/default-settings).  For more information see <xref:security/data-protection/configuration/default-settings#key-management>.
* Newly created Azure Container Apps built using ASP.NET Core. For more information see [Autoscaling considerations
](/azure/container-apps/dotnet-overview#autoscaling-considerations).

The following scenarios do ***NOT*** provide automatic key storage in a shared location:

* Separate [deployment slots](/azure/app-service/deploy-staging-slots), such as Staging and Production.
* Azure Container Apps built using ASP.NET Core Kestrel 7.0 or earlier. For more information see [Autoscaling considerations
](/azure/container-apps/dotnet-overview#autoscaling-considerations).
* Distributed apps that don't have a shared storage location or synchronization mechanism for Data Protection keys.

## Managing Data Protection keys outside the app

An app with multiple instances might encounter a [System.Security.Cryptography.CryptographicException](/dotnet/api/system.security.cryptography.cryptographicexception) with the message `The key {A6EF5BC2-FDCC-4C0C-A3A5-CDA9A1733D70}` `was not found in the key ring.` This error occurs when instances become out of sync, causing data protected on one instance, such as an anti-forgery token, to fail when unprotected on another instance. This can happen, for example, if a form is served by one instance but posted to another that has not yet updated its key ring. When this issue arises, users may need to resubmit a form or re-authenticate if the issue involves an authentication token.

One common reason app instances end up with different sets of keys is that, in the absence of a usable key (e.g. due to expiration, lack of access to the backing repository, etc), an instance will generate a new key of its own.  Until that key has propagated to all other instances (which can take up to two days), there's a risk that data protected with that new key will sent to an instance that doesn't know how to unprotect it.

Generally, app instances don't know about each other, so coordinating the generation and distribution of new keys (e.g. when they are periodically rotating) requires explicit configuration.  One way to avoid having instances generate and use keys that are unknown to other instances is to prevent them from generating keys at all.  The details of how to accomplish this vary slightly from app to app, but the general approach is straightforward.

First, app instances [disable key generation](xref:security/data-protection/configuration/overview#disableautomatickeygeneration).  Next, a new component is introduced that connects to the same key repository and performs a dummy protect operation once a day or so.

For example, with Azure blob storage as the key repository, the key manager could be a basic console app run on a schedule:

:::code language="csharp" source="~/security/data-protection/configuration/scaling/samples/AzBlobKey/Program.cs":::

The `appsettings.json` file contains the URIs for the key repository and key vault:

:::code language="json" source="~/security/data-protection/configuration/scaling/samples/AzBlobKey/appsettings.json" highlight="2-5":::

Note that app instances throw exceptions if they perform any `Protect` or `Unprotect` operations before the key manager has run for the first time. To prevent exceptions, start the key manager so it before creating app instances. In most scenarios, Azure Key Vault starts the key manager before the app instances.

:::moniker-end

[!INCLUDE[](~/security/data-protection/configuration/scaling/includes/scaling7.md)]
