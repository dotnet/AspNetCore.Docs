---
title: Getting Started with ASP.NET Core | Microsoft Docs
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 73543e9d-d9d5-47d6-9664-17a9beea6cd3
ms.technology: aspnet
ms.prod: aspnet-core
uid: getting-started
---
# Getting Started with ASP.NET Core

1.  Install [.NET Core](https://microsoft.com/net/core)

2.  Create a new .NET Core project:

    ```console
    mkdir aspnetcoreapp
    cd aspnetcoreapp
    dotnet new web
    ```
    Note: This command requires `.NET Core SDK 1.0.0 - RC4` or later.

3.  Restore the packages:

    ```console
    dotnet restore
    ```

4.  Run the app  (the `dotnet run` command will build the app when it's out of date):

    ```console
    dotnet run
    ```

5.  Browse to `http://localhost:5000`

## Next steps

For more getting-started tutorials, see [ASP.NET Core Tutorials](tutorials/index.md)

For an introduction to ASP.NET Core concepts and architecture, see [ASP.NET Core Introduction](index.md) and [ASP.NET Core Fundamentals](fundamentals/index.md).

An ASP.NET Core app can use the .NET Core or .NET Framework runtime. For more information, see [Choosing between .NET Core and .NET Framework](https://docs.microsoft.com/dotnet/articles/standard/choosing-core-framework-server).
