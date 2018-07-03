---
title: Create a Web API with ASP.NET Core and Visual Studio for Windows
author: rick-anderson
description: Build a web API with ASP.NET Core MVC and Visual Studio for Windows
ms.author: riande
ms.custom: mvc
ms.date: 05/17/2018
uid: tutorials/first-web-api2
---

<!--
WHen Azure table storage is used, generate a new GUID for the PK. This tutorial previously used ConcurrentDictionary<Guid.NewGuid().ToString();, TodoItem>(); 

I switched to EF in-memory so I could get int's as PK. It's much easier to enter 1 than a GUID when reading/updating/deleting an item.  For Try .NET, they'll have to copy/paste the GUID PK.
-->

## Overview

This tutorial tests a Web API controller with the following API:

|API | Description | Request body | Response body |
|--- | ---- | ---- | ---- |
|GET /api/todo | Get all to-do items | None | Array of to-do items|
|GET /api/todo/{id} | Get an item by ID | None | To-do item|
|POST /api/todo | Add a new item | To-do item | To-do item |
|PUT /api/todo/{id} | Update an existing item &nbsp; | To-do item | None |
|DELETE /api/todo/{id} &nbsp; &nbsp; | Delete an item &nbsp; &nbsp; | None | None|

The following diagram shows the basic design of the app.

![The client is represented .](first-web-api/_static/architecture.png)

* The client is whatever consumes the web API (mobile app, browser, etc.). This tutorial provides a client to test the web API in the browser.

* A *model* is an object that represents the data in the app. In this case, the only model is a to-do item. Models are represented as C# classes, also known as **P**lain **O**ld **C**LR **O**bject (POCOs).

* A *controller* is an object that handles HTTP requests and creates the HTTP response. This app uses the `TodoController` .

* To keep the tutorial simple, the app doesn't use a persistent database. The sample app stores to-do items in an in-memory database.

### The model

The Web API app uses the following model to create, read, update, and delete (CRUD) data:

[!code-csharp[](first-web-api/samples/2.0/TodoApi/Models/TodoItem.cs)]

The model is an object representing the data in the app. 

When you create a new `TodoItem` item, you provide the name and completion status, the database generates the `Id`.

### The Web API controller

The following code shows the `TodoController` Web API controller:

[!code-csharp[](first-web-api2/samples/2.0/TodoApi/Controllers/TodoController.cs?name=TodoController2)]

The following code shows the `TodoController` class declaration and constructor:

[!code-csharp[](first-web-api2/samples/2.0/TodoApi/Controllers/TodoController.cs?name=TodoController)]

The preceding code shows:

* The declaration of the web api controller.
* The `[ApiController]` attribute to enable some convenient features. For information on features enabled by the attribute, see [Annotate class with ApiControllerAttribute](xref:web-api/index#annotate-class-with-apicontrollerattribute).

The controller's constructor uses [Dependency Injection](xref:fundamentals/dependency-injection) to inject the database context (`TodoContext`) into the controller. The database context is used in each of the [CRUD](https://wikipedia.org/wiki/Create,_read,_update_and_delete) methods in the controller. The constructor adds an item to the in-memory database if one doesn't exist.

## Get to-do items

The following code gets to-do items:

[!code-csharp[](first-web-api/samples/2.1/TodoApi/Controllers/TodoController.cs?name=snippet_GetAll)]

The preceding code implements the two GET endpoints:

* `GET /api/todo`
* `GET /api/todo/{id}`

Select **Run** with the relative URI of `/api/todo` to return all the to-do items:

![replace this with TRY .NET code .](first-web-api/_static/run1.png)
