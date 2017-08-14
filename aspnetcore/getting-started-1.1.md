---
title: Getting Started with ASP.NET Core 1.1
author: rick-anderson
description: A quick tutorial that creates and runs a simple Hello World app using ASP.NET Core 1.1.
keywords: ASP.NET Core,tutorial,get started
ms.author: riande
manager: wpickett
ms.date: 08/07/2017
ms.topic: get-started-article
ms.assetid: 73543e9d-d9d5-47d6-9664-17a9beea6cd3
ms.technology: aspnet
ms.prod: asp.net-core
uid: getting-started-1.1
---
# Getting Started with ASP.NET Core 1.1

> [!NOTE]
> These instructions are for ASP.NET Core 1.1. Looking for the latest version? See [the current version of this tutorial](xref:getting-started).

1. Install the .NET Core **SDK Installer** for SDK 1.0.4 from the [.NET Core 1.0.5 & 1.1.2 SDK 1.0.4 downloads page](https://github.com/dotnet/core/blob/master/release-notes/download-archives/1.0.5-download.md).

2. Create a folder for a new .NET Core project.

   On macOS and Linux, open a terminal window. On Windows, open a command prompt.

   ```terminal
   mkdir aspnetcoreapp
   cd aspnetcoreapp
   ```

2. If you have installed a later SDK version on your machine, create a *global.json* file to select the 1.0.4 SDK.

   ```json
   {
     "sdk": { "version": "1.0.4" }
   }
   ```

2. Create a new .NET Core project.

   ```terminal
   dotnet new web
   ```
   
3.  Restore the packages.

    ```terminal
    dotnet restore
    ```

4. Run the app.

   The `dotnet run` command builds the app first if needed.

   ```terminal
   dotnet run
   ```

5. Browse to `http://localhost:5000`

<!-- H3 to avoid a single-entry internal TOC -->
### Next steps

For getting-started tutorials, see [ASP.NET Core Tutorials](tutorials/index.md)

For an introduction to ASP.NET Core concepts and architecture, see [ASP.NET Core Introduction](index.md) and [ASP.NET Core Fundamentals](fundamentals/index.md).

An ASP.NET Core app can use the .NET Core or .NET Framework Base Class Library and runtime. For more information, see [Choosing between .NET Core and .NET Framework](https://docs.microsoft.com/dotnet/articles/standard/choosing-core-framework-server).
