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

An app with multiple instances may occasionally see an error like `System.Security.Cryptography.CryptographicException: The key {A6EF5BC2-FDCC-4C0C-A3A5-CDA9A1733D70} was not found in the key ring.`.  This can happen when instances get out of sync and data protected on one instance (e.g. an anti-forgery token) is unprotected on another instance (e.g. because a form was served from the former and posted to the latter) that doesn't yet know about that key.  When this happens, an app user may have to resubmit a form or re-authenticate (if it was an authentication token that couldn't be unprotected).

One common reason app instances end up with different sets of keys is that, in the absence of a usable key (e.g. due to expiration, lack of access to the backing repository, etc), an instance will generate a new key of its own.  Until that key has propagated to all other instances (which can take up to two days), there's a risk that data protected with that new key will sent to an instance that doesn't know how to unprotect it.

Generally, app instances don't know about each other, so coordinating the generation and distribution of new keys (e.g. when they are periodically rotating) requires explicit configuration.  One way to avoid having instances generate and use keys that are unknown to other instances is to prevent them from generating keys at all.  The details of how to accomplish this vary slightly from app to app, but the general approach is straightforward.

First, app instances [disable key generation](xref:security/data-protection/configuration/overview#disableautomatickeygeneration).  Next, a new component is introduced that connects to the same key repository and performs a dummy protect operation once a day or so.

For example, with Azure blob storage as the key repository, the key manager could be a simple console app run on a schedule.

```csharp
using Azure.Identity;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var hostBuilder = new HostApplicationBuilder();

hostBuilder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

var blobStorageUri = hostBuilder.Configuration["AzureURIs:BlobStorage"]!;
var keyVaultURI = hostBuilder.Configuration["AzureURIs:KeyVault"]!;

// Use the same persistence and protection mechanisms as your app
hostBuilder.Services
    .AddDataProtection()
    .PersistKeysToAzureBlobStorage(new Uri(blobStorageUri), new DefaultAzureCredential())
    .ProtectKeysWithAzureKeyVault(new Uri(keyVaultURI), new DefaultAzureCredential());

using var host = hostBuilder.Build();

// Perform a dummy operation to force key creation or rotation, if needed
var dataProtector = host.Services.GetDataProtector("Default");
dataProtector.Protect([]);
```

```json
{
  "AzureURIs": {
    "BlobStorage": "https://<storage-account-name>.blob.core.windows.net/<container-name>/keys.xml",
    "KeyVault": "https://<key-vault-name>.vault.azure.net/keys/<key-name>/"
  }
}
```

Note that app instances will throw exceptions if they need to perform any `Protect` or `Unprotect` operations before the key manager has run for the first time, so it is preferable to execute it before creating app instances.

:::moniker-end

[!INCLUDE[](~/security/data-protection/configuration/scaling/includes/scaling7.md)]
