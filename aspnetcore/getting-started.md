---
title: Getting Started with ASP.NET Core 2.0
author: rick-anderson
description: A quick tutorial that creates and runs a simple Hello World app using ASP.NET Core.
keywords: ASP.NET Core,tutorial,get started
ms.author: riande
manager: wpickett
ms.date: 08/07/2017
ms.topic: get-started-article
ms.assetid: 73543e9d-d9d5-47d6-9664-17a9beea6cd3
ms.technology: aspnet
ms.prod: asp.net-core
uid: getting-started
---
# Getting Started with ASP.NET Core 2.0

> [!NOTE]
> These instructions are for ASP.NET Core 2.0 Preview. The Preview release is not recommended for installation on a production machine. Looking to get started with the latest stable release? See [the 1.1 version of this tutorial](xref:getting-started-1.1).

1. Install [.NET Core 2.0 Preview](https://microsoft.com/net/core/preview).

<!-- after RTW uncomment this section
   If you're on Windows, select the **Command line / other** environment. 
   ![Select Command line environment for Windows](getting-started/_static/win-install-cmd-line.png)
-->

2. Create a new .NET Core project.

   On macOS and Linux, open a terminal window. On Windows, open a command prompt.

   ```terminal
   mkdir aspnetcoreapp
   cd aspnetcoreapp
   dotnet new web
   ```
    
<!-- after RTW uncomment this section
   Note: Earlier versions of .NET Core required a `t` parameter, that is, `dotnet new -t web`. If you get an error running `dotnet new web`, install the latest [.NET Core](https://microsoft.com/net/core).  `dotnet --info` displays the .NET Core version. You should have version 2.0.0 or later.
-->

4. Run the app.

   The `dotnet run` command builds the app first if needed.

   ```terminal
   dotnet run
   ```

5. Browse to `http://localhost:5000`

### Next steps

For getting-started tutorials, see [ASP.NET Core Tutorials](tutorials/index.md)

For an introduction to ASP.NET Core concepts and architecture, see [ASP.NET Core Introduction](index.md) and [ASP.NET Core Fundamentals](fundamentals/index.md).

An ASP.NET Core app can use the .NET Core or .NET Framework Base Class Library and runtime. For more information, see [Choosing between .NET Core and .NET Framework](https://docs.microsoft.com/dotnet/articles/standard/choosing-core-framework-server).
