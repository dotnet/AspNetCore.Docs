---
title: Get Started with ASP.NET Core
author: rick-anderson
description: A quick tutorial that creates and runs a simple Hello World app using ASP.NET Core.
manager: wpickett
ms.author: riande
ms.date: 10/18/2017
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: get-started-article
uid: getting-started
---

# Get Started with ASP.NET Core

::: moniker range=">= aspnetcore-2.0"

1. Install the [!INCLUDE [](~/includes/net-core-sdk-download-link.md)].

2. Create a new .NET Core project.

   On macOS and Linux, open a terminal window. On Windows, open a command prompt. Enter the following command:

    ```terminal
    dotnet new razor -o aspnetcoreapp
    ```
    
3. Run the app.

    Use the following commands to run the app:

    ```terminal
    cd aspnetcoreapp
    dotnet run
    ```

4. Browse to [http://localhost:5000](http://localhost:5000)

5. Open <em>Pages/About.cshtml</em> and modify the page to display the message "Hello, world! The time on the server is @DateTime.Now ":

    [!code-html[](getting-started/sample/getting-started/about.cshtml?highlight=9&range=1-9)]

6. Browse to [http://localhost:5000/About](http://localhost:5000/About) and verify the changes.

### Next steps

For getting-started tutorials, see [ASP.NET Core Tutorials](tutorials/index.md)

For an introduction to ASP.NET Core concepts and architecture, see [ASP.NET Core Introduction](index.md) and [ASP.NET Core Fundamentals](fundamentals/index.md).

An ASP.NET Core app can use the .NET Core or .NET Framework Base Class Library and runtime. For more information, see [Choosing between .NET Core and .NET Framework](https://docs.microsoft.com/dotnet/articles/standard/choosing-core-framework-server).

::: moniker-end

::: moniker range=">= aspnetcore-1.0"

1. Install the .NET Core **SDK Installer** for SDK 1.0.4 from the [.NET Core All Downloads page](https://www.microsoft.com/net/download/all).

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

   The [dotnet run](/dotnet/core/tools/dotnet-run) command builds the app first if needed.

   ```terminal
   dotnet run
   ```

5. Browse to `http://localhost:5000`

<!-- H3 to avoid a single-entry internal TOC -->
### Next steps

For getting-started tutorials, see [ASP.NET Core Tutorials](tutorials/index.md)

For an introduction to ASP.NET Core concepts and architecture, see [ASP.NET Core Introduction](index.md) and [ASP.NET Core Fundamentals](fundamentals/index.md).

An ASP.NET Core app can use the .NET Core or .NET Framework Base Class Library and runtime. For more information, see [Choosing between .NET Core and .NET Framework](https://docs.microsoft.com/dotnet/articles/standard/choosing-core-framework-server).


::: moniker-end