---
title: Use the Single Page Application templates with ASP.NET Core
author: SteveSandersonMS
description: Learn how to install and get started with the ASP.NET Core Single Page Application (SPA) project templates.
monikerRange: '>= aspnetcore-2.0'
ms.author: scaddie
ms.custom: mvc
ms.date: 02/21/2018
uid: spa/index
---
# Use the Single Page Application templates with ASP.NET Core

::: moniker range="= aspnetcore-2.0"

> [!NOTE]
> The released .NET Core 2.0.x SDK includes older project templates for Angular, React, and React with Redux. This documentation isn't about those older project templates. This documentation is for the latest Angular, React, and React with Redux templates, which can be installed manually into ASP.NET Core 2.0. The templates are included by default with ASP.NET Core 2.1.

::: moniker-end

## Prerequisites

* [!INCLUDE [](~/includes/net-core-sdk-download-link.md)]
* [Node.js](https://nodejs.org), version 6 or later

## Installation

::: moniker range=">= aspnetcore-2.1"

The templates are already installed with ASP.NET Core 2.1.

::: moniker-end

::: moniker range="= aspnetcore-2.0"

If you have ASP.NET Core 2.0, run the following command to install the updated ASP.NET Core templates for Angular, React, and React with Redux:

```console
dotnet new --install Microsoft.DotNet.Web.Spa.ProjectTemplates::2.0.0
```

::: moniker-end

## Use the templates

* [Use the Angular project template](xref:spa/angular)
* [Use the React project template](xref:spa/react)
* [Use the React with Redux project template](xref:spa/react-with-redux)
