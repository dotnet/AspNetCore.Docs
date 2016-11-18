---
title: Getting Started | Microsoft Docs
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
# Getting Started

1.  Install [.NET Core](https://microsoft.com/net/core)

2.  Create a new .NET Core project:

    ```console
    mkdir aspnetcoreapp
    cd aspnetcoreapp
    dotnet new -t web
    ```

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

* [Building your first ASP.NET Core MVC app with Visual Studio](tutorials/first-mvc-app/index.md)
* [Your First ASP.NET Core Application on a Mac Using Visual Studio Code](tutorials/your-first-mac-aspnet.md)
* [Building Your First Web API with ASP.NET Core MVC and Visual Studio](tutorials/first-web-api.md)
