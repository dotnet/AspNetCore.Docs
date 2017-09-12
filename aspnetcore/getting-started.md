---
title: Getting Started with ASP.NET Core 2.0
author: rick-anderson
description: A quick tutorial that creates and runs a simple Hello World app using ASP.NET Core.
keywords: ASP.NET Core,tutorial,get started
ms.author: riande
manager: wpickett
ms.date: 08/30/2017
ms.topic: get-started-article
ms.assetid: 73543e9d-d9d5-47d6-9664-17a9beea6cd3
ms.technology: aspnet
ms.prod: asp.net-core
uid: getting-started
---
# Getting Started with ASP.NET Core

> [!NOTE]
> These instructions are for the latest version of ASP.NET Core. Looking to get started with an earlier version? See [the 1.1 version of this tutorial](xref:getting-started-1.1).

1. Install [.NET Core](https://www.microsoft.com/net/core/).

2. Create a new .NET Core project.

   On macOS and Linux, open a terminal window. On Windows, open a command prompt.

    ```terminal
    dotnet new razor -o aspnetcoreapp
    ```
    
4. Run the app.

    Use the following commands to run the app:

    ```terminal
    cd aspnetcoreapp
    dotnet run
    ```

5. Browse to [http://localhost:5000](http://localhost:5000)

6. Open *Pages/About.cshtml* and modify the page to display the message "Hello, world! The time on the server is @DateTime.Now":

    [!code-html[Main](getting-started/sample/getting-started/about.cshtml?highlight=9&range=1-9)]

7. Browse to [http://localhost:5000/About](http://localhost:5000/About) and verify the changes.

### Next steps

For getting-started tutorials, see [ASP.NET Core Tutorials](tutorials/index.md)

For an introduction to ASP.NET Core concepts and architecture, see [ASP.NET Core Introduction](index.md) and [ASP.NET Core Fundamentals](fundamentals/index.md).

An ASP.NET Core app can use the .NET Core or .NET Framework Base Class Library and runtime. For more information, see [Choosing between .NET Core and .NET Framework](https://docs.microsoft.com/dotnet/articles/standard/choosing-core-framework-server).
