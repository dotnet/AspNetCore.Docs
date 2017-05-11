---
title: Create a Web API with ASP.NET Core MVC and Visual Studio for Mac | Microsoft Docs
author: rick-anderson
description: Create a Web API with ASP.NET Core MVC and Visual Studio for Mac
keywords: ASP.NET Core, WebAPI, Web API, REST, mac, macOS
ms.author: riande
manager: wpickett
ms.date: 05/14/2017
ms.topic: article
ms.assetid: 830b4af5-ed14-1638-7734-764a6f13a8f6
ms.technology: aspnet
ms.prod: asp.net-core
uid: tutorials/first-web-api-mac
---
<!-- WARNING: The code AND images in this doc are used by uid: tutorials/web-api-vsc. If you change any code/images in this tutorial, update uid: tutorials/web-api-vsc -->

# Create a Web API with ASP.NET Core MVC and Visual Studio for Mac

By [Mike Wasson](https://github.com/mikewasson) and [Rick Anderson](https://twitter.com/RickAndMSFT)

This tutorial will teach you the basics of building an ASP.NET Core MVC Web API using [Visual Studio for Mac](https://www.visualstudio.com/vs/visual-studio-mac/).

HTTP is not just for serving up web pages. It’s also a powerful platform for building APIs that expose services and data. HTTP is simple, flexible, and ubiquitous. Almost any platform that you can think of has an HTTP library, so HTTP services can reach a broad range of clients, including browsers, mobile devices, and traditional desktop apps.

In this tutorial, you’ll build a simple web API for managing a list of "to-do" items. You won’t build any UI in this tutorial.

ASP.NET Core has built-in support for MVC building Web APIs.

Note: If you are porting an existing Web API app to ASP.NET Core, see [Migrating from ASP.NET Web API](xref:migration/webapi)

See [Create a Web API app on Mac or Linux with Visual Studio Code](xref:tutorials/web-api-vsc) for the  cross-platform platform version of this tutorial.

## Overview

Here is the API that you’ll create:


|API | Description    | Request body    | Response body   |
|--- | ---- | ---- | ---- |
|GET /api/todo  | Get all to-do items | None | Array of to-do items|
|GET /api/todo/{id}  | Get an item by ID | None | To-do item|
|POST /api/todo | Add a new item | To-do item  | To-do item |
|PUT /api/todo/{id} | Update an existing item &nbsp;  | To-do item |  None |
|DELETE /api/todo/{id}  &nbsp;  &nbsp; | Delete an item &nbsp;  &nbsp;  | None  | None|

<br>

The following diagram shows the basic design of the app.

![The client is represented by a box on the left and submits a request and receives a response from the application, a box drawn on the right. Within the application box, three boxes represent the controller, the model, and the data access layer. The request comes into the application's controller, and read/write operations occur between the controller and the data access layer. The model is serialized and returned to the client in the response.](first-web-api/_static/architecture.png)

* The client is whatever consumes the web API (browser, mobile app, and so forth). We aren’t writing a client in this tutorial. We'll use [Postman](https://www.getpostman.com/) to test the app.

* A *model* is an object that represents the data in your application. In this case, the only model is a to-do item. Models are represented as simple C# classes, also know as Plain Old C# Object (POCOs).

* A *controller* is an object that handles HTTP requests and creates the HTTP response. This app will have a single controller.

* To keep the tutorial simple, the app doesn’t use a persistent database. Instead, it stores to-do items in an in-memory database. See [Introduction to ASP.NET Core MVC on Mac or Linux](xref:tutorials/first-mvc-app-xplat/index) for an example that uses a database.

### Create the project

From Visual Studio, select **.NET Core App >  ASP.NET Core Web API > Next**.

![macOS New project dialog](first-web-api-mac/_static/1.png)

Enter **TodoApi** for the **Project Name**, and then select Create.

![config dialog](first-web-api-mac/_static/2.png)

### Add support for Entity Framework Core

Install the [Entity Framework Core InMemory](https://docs.microsoft.com/en-us/ef/core/providers/in-memory/) database provider. This database provider allows Entity Framework Core to be used with an in-memory database.

* From the **Project** menu, select **Add NuGet Packages**. 

  *  Alternately, you can right-click **Dependencies**, and then select **Add Packages**.

* Enter `EntityFrameworkCore.InMemory` in the search box.
* Select `Microsoft.EntityFrameworkCore.InMemory`, and then select **Add Package**.

### Add a model class

A model is an object that represents the data in your application. In this case, the only model is a to-do item.

Add a folder named *Models*. In Solution Explorer, right-click the project. Select **Add** > **New Folder**. Name the folder *Models*.

![new folder](first-web-api-mac/_static/folder.png)

Note: You can put model classes anywhere in your project, but the *Models* folder is used by convention.

Add a `TodoItem` class. Right-click the *Models* folder and select **Add > New File > General > Empty Class**. Name the class `TodoItem`, and then select **New**.

Replace the generated code with:

[!code-csharp[Main](first-web-api/sample/TodoApi/Models/TodoItem.cs)]

* The `[Key]` data annotation denotes the property, `Key`, is a unique identifier.
* `[DatabaseGenerated` specifies the database will generate the key (rather than the application).
* `DatabaseGeneratedOption.Identity` specifies the database should generate integer keys when a row is inserted.

### Create the database context

The *database context* is the main class that coordinates Entity Framework functionality for a given data model. You create this class by deriving from the `Microsoft.EntityFrameworkCore.DbContext` class.

Add a `TodoContext` class to the *Models* folder.

[!code-csharp[Main](first-web-api/sample/TodoApi/Models/TodoContext.cs)]

## Add a repository class

A *repository* is an object that encapsulates the data layer. The *repository* contains logic for retrieving and mapping data to an entity model. Create the repository code in the *Models* folder.

Define a repository interface named `ITodoRepository`. 

[!code-csharp[Main](first-web-api/sample/TodoApi/Models/ITodoRepository.cs)]

This interface defines basic CRUD operations.

Add a `TodoRepository` class that implements `ITodoRepository`:

[!code-csharp[Main](first-web-api/sample/TodoApi/Models/TodoRepository.cs)]

Build the app to verify you don't have any compiler errors.

## Register the repository

By defining a repository interface, we can decouple the repository class from the MVC controller that uses it. Instead of instantiating a `TodoRepository` inside the controller we will inject an `ITodoRepository` using the built-in support in ASP.NET Core for [dependency injection](xref:fundamentals/dependency-injection).

This approach makes it easier to unit test your controllers. Unit tests should inject a mock or stub version of `ITodoRepository`. That way, the test narrowly targets the controller logic and not the data access layer.

In order to inject the repository into the controller, we need to register it with the DI container. Open the *Startup.cs* file. The code below also registers the in-memory database.

In the `ConfigureServices` method, add the highlighted code:

[!code-csharp[Main](first-web-api/sample/TodoApi/Startup.cs?name=snippet_AddSingleton&highlight=1,2,5,9)]

## Add a controller

In Solution Explorer, in the *Controllers* folder, add the class `TodoController`.

Replace the generated code with the following (and add closing braces):

[!code-csharp[Main](first-web-api/sample/TodoApi/Controllers/TodoController.cs?name=snippet_todo1)]

This defines an empty controller class. In the next sections, we'll add methods to implement the API.

## Getting to-do items

To get to-do items, add the following methods to the `TodoController` class.

[!code-csharp[Main](first-web-api/sample/TodoApi/Controllers/TodoController.cs?name=snippet_GetAll)]

These methods implement the two GET methods:

* `GET /api/todo`
* `GET /api/todo/{id}`

Here is an example HTTP response for the `GetAll` method:

```
HTTP/1.1 200 OK
   Content-Type: application/json; charset=utf-8
   Server: Microsoft-IIS/10.0
   Date: Thu, 18 Jun 2015 20:51:10 GMT
   Content-Length: 82

   [{"Key":"1","Name":"Item1","IsComplete":false}]
   ```

Later in the tutorial I'll show how you can view the HTTP response using [Postman](https://www.getpostman.com/).

### Routing and URL paths

The `[HttpGet]` attribute specifies an HTTP GET method. The URL path for each method is constructed as follows:

* Take the template string in the controller’s route attribute,  `[Route("api/[controller]")]`
* Replace "[Controller]" with the name of the controller, which is the controller class name minus the "Controller" suffix. For this sample, the controller class name is **Todo**Controller and the root name is "todo". ASP.NET Core [routing](xref:mvc/controllers/routing) is not case sensitive.
* If the `[HttpGet]` attribute has a route template (such as `[HttpGet("/products")]`, append that to the path. This sample doesn't use a template. See [Attribute routing with Http[Verb] attributes](xref:mvc/controllers/routing#attribute-routing-with-httpverb-attributes) for more information.

In the `GetById` method:

```csharp
[HttpGet("{id}", Name = "GetTodo")]
public IActionResult GetById(long id)
```

`"{id}"` is a placeholder variable for the ID of the `todo` item. When `GetById` is invoked, it assigns the value of "{id}" in the URL to the method's `id` parameter.

`Name = "GetTodo"` creates a named route and allows you to link to this route in an HTTP Response. I'll explain it with an example later. See [Routing to Controller Actions](xref:mvc/controllers/routing) for detailed information.

### Return values

The `GetAll` method returns an `IEnumerable`. MVC automatically serializes the object to [JSON](http://www.json.org/) and writes the JSON into the body of the response message. The response code for this method is 200, assuming there are no unhandled exceptions. (Unhandled exceptions are translated into 5xx errors.)

In contrast, the `GetById` method returns the more general `IActionResult` type, which represents a wide range of return types. `GetById` has two different return types:

* If no item matches the requested ID, the method returns a 404 error.  This is done by returning `NotFound`.

* Otherwise, the method returns 200 with a JSON response body. This is done by returning an `ObjectResult`


### Launch the app

In Visual Studio, select **Run > Start With Debugging** to launch the app. Visual Studio launches a browser and navigates to `http://localhost:port`, where *port* is a randomly chosen port number. You get an HTTP 404 (Not Found) error.  Change the URL to `http://localhost:port/api/values`. The `ValuesController` data will be displayed:

```
["value1","value2"]
```

Navigate to the `Todo` controller at`http://localhost:port/api/todo`:

```
[{"key":1,"name":"Item1","isComplete":false}]
```

<!-- review: why do they need to close the browser? -->
Stop the debugger. From the menu,  **Run > Stop**. Close the brower window.

## Implement the other CRUD operations

We'll add `Create`, `Update`, and `Delete` methods to the controller. These are variations on a theme, so I'll just show the code and highlight the main differences. Build the project after adding or changing code.

### Create

[!code-csharp[Main](first-web-api/sample/TodoApi/Controllers/TodoController.cs?name=snippet_Create)]

This is an HTTP POST method, indicated by the [`[HttpPost]`](https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNetCore/Mvc/HttpPostAttribute/index.html) attribute. The [`[FromBody]`](https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNetCore/Mvc/FromBodyAttribute/index.html) attribute tells MVC to get the value of the to-do item from the body of the HTTP request.

The `CreatedAtRoute` method returns a 201 response, which is the standard response for an HTTP POST method that creates a new resource on the server. `CreatedAtRoute` also adds a Location header to the response. The Location header specifies the URI of the newly created to-do item. See [10.2.2 201 Created](http://www.w3.org/Protocols/rfc2616/rfc2616-sec10.html).

### Use Postman to send a Create request

* Start the app (**Run > Start With Debugging**).
* Start Postman.

![Postman console](first-web-api/_static/pmc.png)

* Set the HTTP method to `POST`
* Select the **Body** radio button
* Select the **raw** radio button
* Set the type to JSON
* In the key-value editor, enter a Todo item such as

```json
{
	"name":"walk dog",
	"isComplete":true
}
```

* Select **Send**

* Select the Headers tab in the lower pane and copy the **Location** header:

![Headers tab of the Postman console](first-web-api/_static/pmget.png)

You can use the Location header URI to access the resource you just created. Recall the `GetById` method created the `"GetTodo"` named route:

```csharp
[HttpGet("{id}", Name = "GetTodo")]
public IActionResult GetById(string id)
```

### Update

[!code-csharp[Main](first-web-api/sample/TodoApi/Controllers/TodoController.cs?name=snippet_Update)]

`Update` is similar to `Create`, but uses HTTP PUT. The response is [204 (No Content)](http://www.w3.org/Protocols/rfc2616/rfc2616-sec9.html). According to the HTTP spec, a PUT request requires the client to send the entire updated entity, not just the deltas. To support partial updates, use HTTP PATCH.

```json
{
  "key": 1,
  "name": "walk dog",
  "isComplete": true
}
```

![Postman console showing 204 (No Content) response](first-web-api/_static/pmcput.png)

### Delete

[!code-csharp[Main](first-web-api/sample/TodoApi/Controllers/TodoController.cs?name=snippet_Delete)]

The response is [204 (No Content)](http://www.w3.org/Protocols/rfc2616/rfc2616-sec9.html).

![Postman console showing 204 (No Content) response](first-web-api/_static/pmd.png)

## Next steps

* [Routing to Controller Actions](xref:mvc/controllers/routing)
* For information about deploying your API, see [Publishing and Deployment](../publishing/index.md).
* [View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/tutorials/first-web-api/sample)
* [Postman](https://www.getpostman.com/)
* [Fiddler](http://www.fiddler2.com/fiddler2/)
