---
title: Get started with ASP.NET Core
author: tdykstra
description: A short tutorial using the .NET CLI to create and run a basic Hello World app using ASP.NET Core.
monikerRange: ">= aspnetcore-3.1"
ms.author: tdykstra
ms.custom: mvc
ms.date: 05/31/2024
uid: getting-started
---
# Tutorial: Get started with ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

This tutorial shows how to create and run an ASP.NET Core web app using the .NET CLI.

You'll learn how to:

> [!div class="checklist"]
> * Create a web app project.
> * Run the app.
> * Edit a Razor page.

At the end, you'll have a working web app running on your local machine.

:::image source="_static/home-page.png" alt-text="Web app home page":::

## Prerequisites

:::moniker range=">= aspnetcore-8.0"
[!INCLUDE[](~/includes/8.0-SDK.md)]
:::moniker-end
:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"
[!INCLUDE[](~/includes/7.0-SDK.md)]
:::moniker-end
:::moniker range="<= aspnetcore-6.0"
[!INCLUDE[](~/includes/6.0-SDK.md)]
:::moniker-end

## Create a web app project

Open a command shell, and enter the following command:

```dotnetcli
dotnet new webapp --output aspnetcoreapp --no-https
```

The preceding command creates a new web app project in a directory named `aspnetcoreapp`. The project doesn't use HTTPS.

## Run the app

Run the following commands:

```dotnetcli
cd aspnetcoreapp
dotnet run
```

The `run` command produces output like the following example:

```output
Building...
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5109
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\aspnetcoreapp
```

Open a browser and go to the URL shown in the output. In this example, the URL is `http://localhost:5109`.

The browser shows the home page.

:::image source="_static/home-page.png" alt-text="Web app home page":::

## Edit a Razor page

Change the home page:

* In the command shell, press Ctrl+C (Cmd+C in macOS) to exit the program.
* Open `Pages/Index.cshtml` in a text editor.
* Replace the line that begins with "Learn about" with the following highlighted markup and code:

  :::code language="cshtml" source="sample/index.cshtml" highlight="9":::

* Save your changes.
* In the command shell run the `dotnet run` command again.
* In the browser, refresh the page and verify the changes are displayed.

  :::image source="_static/home-page-changed.png" alt-text="Web app home page showing the change that was made.":::

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
> * Create a web app project.
> * Run the project.
> * Make a change.

To learn more about ASP.NET Core, see the following:

> [!div class="nextstepaction"]
> <xref:index#recommended-learning-path>
