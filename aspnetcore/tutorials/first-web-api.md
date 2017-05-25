---
title: Create a Web API with ASP.NET Core and Visual Studio for Windows
author: rick-anderson
description: Build a web API with ASP.NET Core MVC and Visual Studio for Windows
keywords: ASP.NET Core, WebAPI, Web API, REST, HTTP, Service, HTTP Service
ms.author: riande
manager: wpickett
ms.date: 5/24/2017
ms.topic: article
ms.assetid: 830b4af5-ed14-423e-9f59-764a6f13a8f6
ms.technology: aspnet
ms.prod: asp.net-core
uid: tutorials/first-web-api
---

#Create a web API with ASP.NET Core MVC and Visual Studio for Windows

<!-- WARNING: The code AND images in this doc are used by uid: tutorials/web-api-vsc, tutorials/first-web-api-mac and tutorials/first-web-api. If you change any code/images in this tutorial, update uid: tutorials/web-api-vsc -->

[!INCLUDE[intro to web API](../includes/webApi/intro.md)]

## Create the project

From Visual Studio, select **File** menu, > **New** > **Project**.

Select the **ASP.NET Core Web Application (.NET Core)** project template. Name the project `TodoApi` and select **OK**.

![New project dialog](first-web-api/_static/new-project.png)

In the **New ASP.NET Core Web Application (.NET Core) - TodoApi** dialog, select the **Web API** template. Select **OK**. Do **not** select **Enable Docker Support**.

![New ASP.NET Web Application dialog with Web API project template selected from ASP.NET Core Templates](first-web-api/_static/web-api-project.png)

### Launch the app

In Visual Studio, press CTRL+F5 to launch the app. Visual Studio launches a browser and navigates to `http://localhost:port/api/values`, where *port* is a randomly chosen port number. If you're using Chrome, Edge or Firefox, the `ValuesController` data will be displayed:

```
["value1","value2"]
``` 

If you're using IE, you are prompted to open or save the *values.json* file.

### Add support for Entity Framework Core

Install the [Entity Framework Core InMemory](https://docs.microsoft.com/en-us/ef/core/providers/in-memory/) database provider. This database provider allows Entity Framework Core to be used with an in-memory database.

Edit the *TodoApi.csproj* file. In Solution Explorer, right-click the project. Select **Edit TodoApi.csproj**. In the `ItemGroup` element, add "Microsoft.EntityFrameworkCore.InMemory":

[!code-xml[Main](first-web-api/sample/TodoApi/TodoApi.csproj?highlight=15)]

### Add a model class

A model is an object that represents the data in your application. In this case, the only model is a to-do item.

Add a folder named "Models". In Solution Explorer, right-click the project. Select **Add** > **New Folder**. Name the folder *Models*.

Note: You can put model classes anywhere in your project, but the *Models* folder is used by convention.

Add a `TodoItem` class. Right-click the *Models* folder and select **Add** > **Class**. Name the class `TodoItem` and select **Add**.

Replace the generated code with:

[!code-csharp[Main](first-web-api/sample/TodoApi/Models/TodoItem.cs)]

### Create the database context

The *database context* is the main class that coordinates Entity Framework functionality for a given data model. You create this class by deriving from the `Microsoft.EntityFrameworkCore.DbContext` class.

Add a `TodoContext` class. Right-click the *Models* folder and select **Add** > **Class**. Name the class `TodoContext` and select **Add**.

[!code-csharp[Main](first-web-api/sample/TodoApi/Models/TodoContext.cs)]

[!INCLUDE[Register the database context](../includes/webApi/register_dbContext.md)]

## Add a controller

In Solution Explorer, right-click the *Controllers* folder. Select **Add** > **New Item**. In the **Add New Item** dialog, select the **Web  API Controller Class** template. Name the class `TodoController`.

![Add new Item dialog with controller in search box and web API controller selected](first-web-api/_static/new_controller.png)

Replace the generated code with the following:

[!INCLUDE[code and get todo items](../includes/webApi/getTodoItems.md)]
  
### Launch the app

In Visual Studio, press CTRL+F5 to launch the app. Visual Studio launches a browser and navigates to `http://localhost:port/api/values`, where *port* is a randomly chosen port number. If you're using Chrome, Edge or Firefox, the data will be displayed. If you're using IE, IE will prompt to you open or save the *values.json* file. Navigate to the `Todo` controller we just created `http://localhost:port/api/todo`.

[!INCLUDE[last part of web API](../includes/webApi/end.md)]

[!INCLUDE[next steps](../includes/webApi/next.md)]

