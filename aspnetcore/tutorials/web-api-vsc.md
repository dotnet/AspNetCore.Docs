---
title: Create a Web API with ASP.NET Core and Visual Studio Code
author: rick-anderson
description: Build a web API on macOS, Linux, or Windows with ASP.NET Core MVC and Visual Studio Code
ms.author: riande
ms.custom: mvc
ms.date: 07/30/2018
uid: tutorials/web-api-vsc
---
# Create a Web API with ASP.NET Core and Visual Studio Code

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Mike Wasson](https://github.com/mikewasson)

In this tutorial, build a web API for managing a list of "to-do" items. A UI isn't constructed.

There are three versions of this tutorial:

* macOS, Linux, Windows: Web API with Visual Studio Code (This tutorial)
* macOS: [Web API with Visual Studio for Mac](xref:tutorials/first-web-api-mac)
* Windows: [Web API with Visual Studio for Windows](xref:tutorials/first-web-api)

<!-- WARNING: The code AND images in this doc are used by uid: tutorials/web-api-vsc, tutorials/first-web-api-mac and tutorials/first-web-api. If you change any code/images in this tutorial, update uid: tutorials/web-api-vsc -->

[!INCLUDE[template files](../includes/webApi/intro.md)]

## Prerequisites

[!INCLUDE[prerequisites](~/includes/net-core-prereqs-vscode.md)]

## Create the project

From a console, run the following commands:

```console
dotnet new webapi -o TodoApi
code TodoApi
```

The *TodoApi* folder opens in Visual Studio Code (VS Code). Select the *Startup.cs* file.

* Select **Yes** to the **Warn** message "Required assets to build and debug are missing from 'TodoApi'. Add them?"
* Select **Restore** to the **Info** message "There are unresolved dependencies".

<!-- uid: tutorials/first-mvc-app-xplat/start-mvc uses the pic below. If you change it, make sure it's consistent -->

![VS Code with Warn Required assets to build and debug are missing from 'TodoApi'. Add them? Don't ask Again, Not Now, Yes](web-api-vsc/_static/vsc_restore.png)

Press **Debug** (F5) to build and run the program. In a browser, navigate to http://localhost:5000/api/values. The following output is displayed:

```json
["value1","value2"]
```

See [Visual Studio Code help](#visual-studio-code-help) for tips on using VS Code.

## Add support for Entity Framework Core

:::moniker range=">= aspnetcore-2.1"

Creating a new project in ASP.NET Core 2.1 or later adds the [Microsoft.AspNetCore.App](https://www.nuget.org/packages/Microsoft.AspNetCore.App) package reference to the *TodoApi.csproj* file. Add the `Version` attribute, if not already specified.

[!code-xml[](first-web-api/samples/2.1/TodoApi/TodoApi.csproj?name=snippet_Metapackage&highlight=2)]

:::moniker-end

:::moniker range="<= aspnetcore-2.0"

Creating a new project in ASP.NET Core 2.0 adds the [Microsoft.AspNetCore.All](https://www.nuget.org/packages/Microsoft.AspNetCore.All) package reference to the *TodoApi.csproj* file:

[!code-xml[](first-web-api/samples/2.0/TodoApi/TodoApi.csproj?name=snippet_Metapackage&highlight=2)]

:::moniker-end

There's no need to install the [Entity Framework Core InMemory](/ef/core/providers/in-memory/) database provider separately. This database provider allows Entity Framework Core to be used with an in-memory database.

## Add a model class

A model is an object representing the data in your app. In this case, the only model is a to-do item.

Add a folder named *Models*. You can put model classes anywhere in your project, but the *Models* folder is used by convention.

Add a `TodoItem` class with the following code:

[!code-csharp[](first-web-api/samples/2.0/TodoApi/Models/TodoItem.cs)]

The database generates the `Id` when a `TodoItem` is created.

## Create the database context

The *database context* is the main class that coordinates Entity Framework functionality for a given data model. You create this class by deriving from the `Microsoft.EntityFrameworkCore.DbContext` class.

Add a `TodoContext` class in the *Models* folder:

[!code-csharp[](first-web-api/samples/2.0/TodoApi/Models/TodoContext.cs)]

[!INCLUDE[Register the database context](../includes/webApi/register_dbContext.md)]

## Add a controller

In the *Controllers* folder, create a class named `TodoController`. Replace its contents with the following code:

[!INCLUDE[code and get todo items](../includes/webApi/getTodoItems.md)]

### Launch the app

In VS Code, press F5 to launch the app. Navigate to http://localhost:5000/api/todo (the `Todo` controller we created).

[!INCLUDE[jQuery](../includes/webApi/add-jquery.md)]

[!INCLUDE[last part of web API](../includes/webApi/end.md)]

## Visual Studio Code help

* [Getting started](https://code.visualstudio.com/docs)
* [Debugging](https://code.visualstudio.com/docs/editor/debugging)
* [Integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal)
* [Keyboard shortcuts](https://code.visualstudio.com/docs/getstarted/keybindings#_keyboard-shortcuts-reference)

  * [macOS keyboard shortcuts](https://code.visualstudio.com/shortcuts/keyboard-shortcuts-macos.pdf)
  * [Linux keyboard shortcuts](https://code.visualstudio.com/shortcuts/keyboard-shortcuts-linux.pdf)
  * [Windows keyboard shortcuts](https://code.visualstudio.com/shortcuts/keyboard-shortcuts-windows.pdf)

[!INCLUDE[next steps](../includes/webApi/next.md)]
