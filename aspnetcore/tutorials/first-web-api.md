---
title: Create a Web API with ASP.NET Core and Visual Studio
author: rick-anderson
description: Build a web API with ASP.NET Core MVC and Visual Studio on  Windows
ms.author: riande
ms.custom: mvc
ms.date: 05/17/2018
uid: tutorials/first-web-api
---
# Create a Web API with ASP.NET Core and Visual Studio

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Mike Wasson](https://github.com/mikewasson)

This tutorial builds a web API for managing a list of "to-do" items. A user interface (UI) isn't created.

There are three versions of this tutorial:

* Windows: Web API with Visual Studio on Windows (This tutorial)
* macOS: [Web API with Visual Studio for Mac](xref:tutorials/first-web-api-mac)
* macOS, Linux, Windows: [Web API with Visual Studio Code](xref:tutorials/web-api-vsc)

<!-- WARNING: The code AND images in this doc are used by uid: tutorials/web-api-vsc, tutorials/first-web-api-mac and tutorials/first-web-api. If you change any code/images in this tutorial, update uid: tutorials/web-api-vsc -->

[!INCLUDE[intro to web API](../includes/webApi/intro.md)]

## Prerequisites

[!INCLUDE[](~/includes/net-core-prereqs-windows.md)]

## Create the project

Follow these steps in Visual Studio:

* From the **File** menu, select **New** > **Project**.
* Select the **ASP.NET Core Web Application** template. Name the project *TodoApi* and click **OK**.
* In the **New ASP.NET Core Web Application - TodoApi** dialog, choose the ASP.NET Core version. Select the **API** template and click **OK**. Do **not** select **Enable Docker Support**.

### Launch the app

In Visual Studio, press CTRL+F5 to launch the app. Visual Studio launches a browser and navigates to `http://localhost:<port>/api/values`, where `<port>` is a randomly chosen port number. Chrome, Microsoft Edge, and Firefox display the following output:

```json
["value1","value2"]
```

If using Internet Explorer, you'll be prompted to save a *values.json* file.

### Add a model class

A model is an object representing the data in the app. In this case, the only model is a to-do item.

In Solution Explorer, right-click the project. Select **Add** > **New Folder**. Name the folder *Models*.

> [!NOTE]
> The model classes can go anywhere in the project. The *Models* folder is used by convention for model classes.

In Solution Explorer, right-click the *Models* folder and select **Add** > **Class**. Name the class *TodoItem* and click **Add**.

Update the `TodoItem` class with the following code:

[!code-csharp[](first-web-api/samples/2.0/TodoApi/Models/TodoItem.cs)]

The database generates the `Id` when a `TodoItem` is created.

### Create the database context

The *database context* is the main class that coordinates Entity Framework functionality for a given data model. This class is created by deriving from the `Microsoft.EntityFrameworkCore.DbContext` class.

In Solution Explorer, right-click the *Models* folder and select **Add** > **Class**. Name the class *TodoContext* and click **Add**.

Replace the class with the following code:

[!code-csharp[](first-web-api/samples/2.0/TodoApi/Models/TodoContext.cs)]

[!INCLUDE[Register the database context](../includes/webApi/register_dbContext.md)]

### Add a controller

In Solution Explorer, right-click the *Controllers* folder. Select **Add** > **New Item**. In the **Add New Item** dialog, select the **API Controller Class** template. Name the class *TodoController*, and click **Add**.

![Add new Item dialog with controller in search box and web API controller selected](first-web-api/_static/new_controller.png)

Replace the class with the following code:

[!INCLUDE[code and get todo items](../includes/webApi/getTodoItems.md)]

### Launch the app

In Visual Studio, press CTRL+F5 to launch the app. Visual Studio launches a browser and navigates to `http://localhost:<port>/api/values`, where `<port>` is a randomly chosen port number. Navigate to the `Todo` controller at `http://localhost:<port>/api/todo`.

[!INCLUDE[last part of web API](../includes/webApi/end.md)]

[!INCLUDE[jQuery](../includes/webApi/add-jquery.md)]

[!INCLUDE[next steps](../includes/webApi/next.md)]
