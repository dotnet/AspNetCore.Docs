---
title: Get started with ASP.NET Core
author: rick-anderson
description: A quick tutorial that creates and runs a simple Hello World app using ASP.NET Core.
manager: wpickett
ms.author: riande
ms.custom: mvc
ms.date: 05/10/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: get-started-article
uid: getting-started
---
# Get started with ASP.NET Core

::: moniker range=">= aspnetcore-2.0"

1. Install the [!INCLUDE[](~/includes/net-core-sdk-download-link.md)].

2. Create a new .NET Core project.

   On macOS and Linux, open a terminal window. On Windows, open a command prompt. Enter the following command:

    ```terminal
    dotnet new razor -o aspnetcoreapp
    ```

3. Run the app with the following commands:

    ```terminal
    cd aspnetcoreapp
    dotnet run
    ```

4. Browse to [http://localhost:5000](http://localhost:5000).

5. Open *Pages/About.cshtml* and modify the page to display the message "Hello, world! The time on the server is @DateTime.Now":

    [!code-cshtml[](getting-started/sample/getting-started/about.cshtml?highlight=9&range=1-9)]

6. Browse to [http://localhost:5000/About](http://localhost:5000/About) and verify the changes.

[!INCLUDE[next steps](~/includes/getting-started/next-steps.md)]
::: moniker-end

::: moniker range="<= aspnetcore-1.1"

1. Install the .NET Core **SDK Installer** for SDK 1.0.4 from the [.NET Core All Downloads page](https://www.microsoft.com/net/download/all).

2. Create a folder for a new .NET Core project.

   On macOS and Linux, open a terminal window. On Windows, open a command prompt.

   ```terminal
   mkdir aspnetcoreapp
   cd aspnetcoreapp
   ```

3. If you have installed a later SDK version on your machine, create a *global.json* file to select the 1.0.4 SDK.

   ```json
   {
     "sdk": { "version": "1.0.4" }
   }
   ```

4. Create a new .NET Core project.

   ```terminal
   dotnet new web
   ```

5. Restore the packages.

    ```terminal
    dotnet restore
    ```

6. Run the app.

   ```terminal
   dotnet run
   ```

   The [dotnet run](/dotnet/core/tools/dotnet-run) command builds the app first, if needed.

7. Browse to `http://localhost:5000`.

[!INCLUDE[next steps](~/includes/getting-started/next-steps.md)]
::: moniker-end