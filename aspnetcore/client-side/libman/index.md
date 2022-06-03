---
title: Client-side library acquisition in ASP.NET Core with LibMan
author: rick-anderson
description: Learn how to install client-side library assets in an ASP.NET Core project using Library Manager (LibMan).
ms.author: scaddie
ms.custom: mvc
ms.date: 08/14/2018
uid: client-side/libman/index
---
# Client-side library acquisition in ASP.NET Core with LibMan

By [Scott Addie](https://twitter.com/Scott_Addie)

Library Manager (LibMan) is a lightweight, client-side library acquisition tool. LibMan downloads popular libraries and frameworks from the file system or from a [content delivery network (CDN)](https://wikipedia.org/wiki/Content_delivery_network). The supported CDNs include [CDNJS](https://cdnjs.com/), [jsDelivr](https://www.jsdelivr.com/), and [unpkg](https://unpkg.com/#/). The selected library files are fetched and placed in the appropriate location within the ASP.NET Core project.

## LibMan use cases

LibMan offers the following benefits:

* Only the library files you need are downloaded.
* Additional tooling, such as [Node.js](https://nodejs.org), [npm](https://www.npmjs.com), and [WebPack](https://webpack.js.org), isn't necessary to acquire a subset of files in a library.
* Files can be placed in a specific location without resorting to build tasks or manual file copying.

LibMan isn't a package management system. If you're already using a package manager, such as npm or [yarn](https://yarnpkg.com), continue doing so. LibMan wasn't developed to replace those tools.

## Additional resources

* <xref:client-side/libman/libman-vs>
* <xref:client-side/libman/libman-cli>
* [LibMan GitHub repository](https://github.com/aspnet/LibraryManager)
