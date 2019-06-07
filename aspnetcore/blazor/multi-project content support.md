---
title: Create a razor class library with static assets
author: javiercn
description: Learn how to create a razor class library (RCL) with static assets.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 06/26/2019
uid: blazor/multi-project-content-support.md
---

# Create a razor class library with static assets

Razor Class Libaries (RCL) frequently require companion static assets that can be to be referenced by the consuming app of the RCL. ASP.NET Core allows creating RCLs that include static assets that are available from a consuming app.

To include companion assets as part of a razor class library, create a *wwwroot* folder in the class library and include any required files in that folder.

When packing a razor class library, all companion assets in the *wwwroot* folder are included in the package automatically and are made available to apps referencing the package.

## Consume content from a referenced razor class library

The files included under the *wwwroot* folder of the razor class library are exposed on the consuming app under the prefix `_content/{LIBRARY NAME}/`. The consuming app can reference these assets within script, style, img, etc. tags.

## Multi-project development flow

When the app runs:

* The assets stay in their original folders.
* Any change within the class library *wwwroot* folder is reflected on the app without rebuilding.

At build time, a manifest is produced with all the static web asset locations. The manifest is read at runtime and allows the app to consume the assets from referenced projects and packages.

## Publish

When the app is published, the companion assets from all referenced projects and packages get copied into the *wwwroot* folder of the published app under `_content/{LIBRARY NAME}/`.
