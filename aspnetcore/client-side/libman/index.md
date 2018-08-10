---
title: Client-side library acquisition in ASP.NET Core with Library Manager (LibMan)
author: scottaddie
description: Learn how to install client-side library assets in an ASP.NET Core project using Library Manager (LibMan).
ms.author: scaddie
ms.custom: mvc
ms.date: 08/10/2018
uid: client-side/libman/index
---
# Client-side library acquisition in ASP.NET Core with LibMan

By [Scott Addie](https://twitter.com/Scott_Addie)

Library Manager (LibMan) is a lightweight, client-side library acquisition tool. It downloads popular libraries and frameworks from the file system or from a [content delivery network](https://wikipedia.org/wiki/Content_delivery_network) (CDN). The supported CDNs include [CDNJS](https://cdnjs.com/) and [unpkg](https://unpkg.com/#/). The selected library files are fetched and placed in the appropriate location within the ASP.NET Core project.

## LibMan use cases

LibMan offers the following benefits:

* Only the library files you need are downloaded.
* Additional tooling, such as [Node.js](https://nodejs.org), [npm](https://www.npmjs.com), and [WebPack](https://webpack.js.org), is unnecessary to acquire a subset of files in a library.
* Files can be placed in a specific location, without resorting to build tasks or manual file copying.

For more information about LibMan's benefits, watch [this clip about the initial prototype](https://channel9.msdn.com/Events/Build/2017/B8073#time=43m34s).

LibMan isn't a package management system. If you're happily using a package manager, such as npm or [yarn](https://yarnpkg.com), continue doing so. LibMan wasn't developed to replace those tools.

## Additional resources

* <xref:client-side/libman/libman-vs>
* [LibMan GitHub repository](https://github.com/aspnet/LibraryManager)
