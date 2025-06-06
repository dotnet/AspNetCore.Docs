---
title: Host and deploy ASP.NET Core standalone Blazor WebAssembly with Azure Storage
author: guardrex
description: Learn how to host and deploy standalone Blazor WebAssembly using Microsoft Azure Storage.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 03/31/2025
uid: blazor/host-and-deploy/webassembly/azure-storage
---
# Host and deploy ASP.NET Core standalone Blazor WebAssembly with Azure Storage

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to host and deploy standalone Blazor WebAssembly using [Microsoft Azure Storage](/azure/storage/common/storage-introduction).

Azure Storage static file hosting allows serverless Blazor app hosting. Custom domain names, the Azure Content Delivery Network (CDN), and HTTPS are supported.

When the blob service is enabled for static website hosting on a storage account:

* Set the **Index document name** to `index.html`.
* Set the **Error document path** to `index.html`. Razor components and other non-file endpoints don't reside at physical paths in the static content stored by the blob service. When a request for one of these resources is received that the Blazor router should handle, the *404 - Not Found* error generated by the blob service routes the request to the **Error document path**. The `index.html` blob is returned, and the Blazor router loads and processes the path.

If files aren't loaded at runtime due to inappropriate MIME types in the files' `Content-Type` headers, take either of the following actions:

* Configure your tooling to set the correct MIME types (`Content-Type` headers) when the files are deployed.
* Change the MIME types (`Content-Type` headers) for the files after the app is deployed.

  In Storage Explorer (Azure portal) for each file:
  
  1. Right-click the file and select **Properties**.
  1. Set the **ContentType** and select the **Save** button.

For more information, see [Static website hosting in Azure Storage](/azure/storage/blobs/storage-blob-static-website).
