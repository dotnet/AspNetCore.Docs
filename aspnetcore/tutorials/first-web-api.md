---
title: Create a Web API with ASP.NET Core and Visual Studio
author: rick-anderson
description: Build a web API with ASP.NET Core MVC and Visual Studio
ms.author: riande
monikerRange: '>= aspnetcore-2.1'
ms.custom: mvc
ms.date: 11/17/2018
uid: tutorials/first-web-api
---
# Tutorial: Create a Web API with ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Mike Wasson](https://github.com/mikewasson)

This tutorial teaches the basics of building a web API app. The app manages a list of "to-do" items. A user interface (UI) isn't created. You learn how to:

> [!div class="checklist"]
> * Create a web API project.
> * Add a controller.
> * Add code to get "to-do" items.
> * Create other CRUD operations.
> * Call the Web API with jQuery.

At the end, you have a an app that can manage  "to-do" items.

[!INCLUDE[intro to web API](../includes/webApi/intro.md)]

## Prerequisites

[!INCLUDE[](~/includes/net-core-prereqs-windows-all-2.2.md)]

## Create a web project

# [Visual Studio](#tab/visual-studio)

* From the **File** menu, select **New** > **Project**.
* Select the **ASP.NET Core Web Application** template. Name the project *TodoApi* and click **OK**.
* In the **New ASP.NET Core Web Application - TodoApi** dialog, choose the ASP.NET Core version. Select the **API** template and click **OK**. Do **not** select **Enable Docker Support**.

![VS new project dialog](first-web-api/_static/vs.png)

# [Visual Studio Code](#tab/visual-studio-code)

In the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal), run the following command:

   ```console
   dotnet new webapi -o TodoApi
   ```

# [Visual Studio for Mac](#tab/visual-studio-mac)

From Visual Studio, select **File** > **New Solution**.

![macOS New solution](first-web-api-mac/_static/sln.png)

Select **.NET Core App** > **ASP.NET Core Web API** > **Next**.

![macOS New project dialog](first-web-api-mac/_static/1.png)

Enter *TodoApi* for the **Project Name** > **Create**.

![config dialog](first-web-api-mac/_static/2.png)

---

### Launch the app

# [Visual Studio](#tab/visual-studio)

Press CTRL+F5 to launch the app. Visual Studio launches a browser and navigates to `http://localhost:<port>/api/values`, where `<port>` is a randomly chosen port number. Chrome, Microsoft Edge, and Firefox display the following output:

```json
["value1","value2"]
```

Internet Explorer, prompts you to save a *values.json* file.

# [Visual Studio Code](#tab/visual-studio-code)

Press CTRL+F5 to launch the app.

# [Visual Studio for Mac](#tab/visual-studio-mac)

Select **Run** > **Start With Debugging** to launch the app. Visual Studio for Mac  launches a browser and navigates to `http://localhost:<port>`, where `<port>` is a randomly chosen port number. An HTTP 404 (Not Found) error is returned. Change the URL to `http://localhost:<port>/api/values`. The `ValuesController` data is displayed:

```json
["value1","value2"]
```

---

Navigate to the `Todo` controller at `http://localhost:<port>/api/todo`. The following JSON is returned:

```json
[{"key":1,"name":"Item1","isComplete":false}]
```

### Add a model class

A model is an object representing the data in the app. In this case, the only model is a to-do item.

# [Visual Studio](#tab/visual-studio)

In Solution Explorer, right-click the project. Select **Add** > **New Folder**. Name the folder *Models*.

Model classes can go anywhere in the project, but the *Models* folder is used by convention.

In Solution Explorer, right-click the *Models* folder and select **Add** > **Class**. Name the class *TodoItem* and click **Add**.

Update the `TodoItem` class with the following code:

# [Visual Studio Code](#tab/visual-studio-code)

Add a folder named *Models* for the model classes.  Model classes can go anywhere in the project, but the *Models* folder is used by convention.

Add a `TodoItem` class with the following code:

# [Visual Studio for Mac](#tab/visual-studio-mac)

In Solution Explorer, right-click the project. Select **Add** > **New Folder**. Name the folder *Models*.

![new folder](first-web-api-mac/_static/folder.png)

Model classes can go anywhere in the project, but the *Models* folder is used by convention.

Right-click the *Models* folder, and select **Add** > **New File** > **General** > **Empty Class**. Name the class *TodoItem*, and then click **New**.

Update the `TodoItem` class with the following code:

---

[!code-csharp[](first-web-api/samples/2.2/TodoApi/Models/TodoItem.cs)]

The database generates the `Id` when a `TodoItem` is created.

### Create the database context

The *database context* is the main class that coordinates Entity Framework functionality for a given data model. This class is created by deriving from the `Microsoft.EntityFrameworkCore.DbContext` class.

# [Visual Studio](#tab/visual-studio)

Right-click the *Models* folder and select **Add** > **Class**. Name the class *TodoContext* and click **Add**.

# [Visual Studio Code](#tab/visual-studio-code)

Add a `TodoContext` class to the *Models* folder.

# [Visual Studio for Mac](#tab/visual-studio-mac)

Add a `TodoContext` class in the *Models* folder:

---

Replace the class with the following code:

[!code-csharp[](first-web-api/samples/2.2/TodoApi/Models/TodoContext.cs)]

## Register the database context

In this step, the database context is registered with the [dependency injection](xref:fundamentals/dependency-injection) container. Services (such as the DB context) that are registered with the dependency injection (DI) container are available to the controllers.

Register the DB context with the service container using the built-in support for [dependency injection](xref:fundamentals/dependency-injection). Update *Startup.cs* with the following highlighted code:

::: moniker range="= aspnetcore-2.1"

[!code-csharp[](first-web-api/samples/2.2/TodoApi/Startup.cs?highlight=3,5,13-14)]

::: moniker-end

::: moniker range="= aspnetcore-2.2"

[!code-csharp[](first-web-api/samples/2.2/TodoApi/Startup.cs?highlight=5,8,25,26)]

::: moniker-end  

The preceding code:

* Removes unused `using` declarations.
* Specifies an in-memory database is injected into the service container.

### Add a controller

# [Visual Studio](#tab/visual-studio)

* Right-click the *Controllers* folder.
* Select **Add** > **New Item**.
* In the **Add New Item** dialog, select the **API Controller Class** template.
* Name the class *TodoController*, and click **Add**.

![Add new Item dialog with controller in search box and web API controller selected](first-web-api/_static/new_controller.png)

# [Visual Studio Code](#tab/visual-studio-code)

In the *Controllers* folder, create a class named `TodoController`.

# [Visual Studio for Mac](#tab/visual-studio-mac)

In Solution Explorer, in the *Controllers* folder, add the class `TodoController`.

---

Replace the `TodoController` class with the following code:

[!code-csharp[](first-web-api/samples/2.2/TodoApi/Controllers/TodoController2.cs?name=snippet_todo1)]

The preceding code:

* Defines an API controller class without methods.
* Creates a new Todo item when `TodoItems` is empty. You won't be able to delete all the Todo items because the constructor creates a new one if `TodoItems` is empty.

In the next sections, methods are added to implement the API. The class is annotated with an [`[ApiController]`](/dotnet/api/microsoft.aspnetcore.mvc.apicontrollerattribute) attribute to:

* Mark the class is used to serve HTTP API responses.
* Enable the class to target conventions, filters, and other behaviors.

For information, see [Annotation with ApiControllerAttribute](xref:web-api/index#annotation-with-apicontrollerattribute).

The controller's constructor uses [Dependency Injection](xref:fundamentals/dependency-injection) to inject the database context (`TodoContext`) into the controller. The database context is used in each of the [CRUD](https://wikipedia.org/wiki/Create,_read,_update_and_delete) methods in the controller. The constructor adds an item to the in-memory database if one doesn't exist.

## Get to-do items

To get to-do items, add the following methods to the `TodoController` class:

[!code-csharp[](first-web-api/samples/2.2/TodoApi/Controllers/TodoController.cs?name=snippet_GetAll)]

These methods implement the two GET endpoints:

* `GET /api/todo`
* `GET /api/todo/{id}`

Test the app by calling the two endpoints from a browser. For example:

* `https://localhost:5001/api/todo`
* `https://localhost:5001/api/todo/1`

The following HTTP response is produced with the preceding call to `GetAll`:

```json
[
  {
    "id": 1,
    "name": "Item1",
    "isComplete": false
  }
]
```

Later in the tutorial, instructions are provided to view the HTTP response with [Postman](https://www.getpostman.com/) or [curl](https://curl.haxx.se/docs/manpage.html).

### Routing and URL paths

The [`[HttpGet]`](/dotnet/api/microsoft.aspnetcore.mvc.httpgetattribute) attribute denotes a method that responds to an HTTP GET request. The URL path for each method is constructed as follows:

* Take the template string in the controller's `Route` attribute:

[!code-csharp[](first-web-api/samples/2.2/TodoApi/Controllers/TodoController.cs?name=TodoController&highlight=3)]

* Replace `[controller]` with the name of the controller, which is the controller class name minus the "Controller" suffix. For this sample, the controller class name is **Todo**Controller and the root name is "todo". ASP.NET Core [routing](xref:mvc/controllers/routing) is case insensitive.
* If the `[HttpGet]` attribute has a route template (such as `[HttpGet("/products")]`, append that to the path. This sample doesn't use a template. For more information, see [Attribute routing with Http[Verb] attributes](xref:mvc/controllers/routing#attribute-routing-with-httpverb-attributes).

In the following `GetById` method, `"{id}"` is a placeholder variable for the unique identifier of the to-do item. When `GetById` is invoked, it assigns the value of `"{id}"` in the URL to the method's `id` parameter.

[!code-csharp[](first-web-api/samples/2.2/TodoApi/Controllers/TodoController.cs?name=snippet_GetByID&highlight=1-2)]

`Name = "GetTodo"` creates a named route. Named routes:

* Enable the app to create an HTTP link using the route name.
* Are explained later in the tutorial.

### Return values

The `GetAll` method returns a collection of `TodoItem` objects. MVC automatically serializes the object to [JSON](https://www.json.org/) and writes the JSON into the body of the response message. The response code for this method is 200, assuming there are no unhandled exceptions. Unhandled exceptions are translated into 5xx errors.

In contrast, the `GetById` method returns the [ActionResult\<T> type](xref:web-api/action-return-types#actionresultt-type), which represents a wide range of return types. `GetById` has two different return types:

* If no item matches the requested ID, the method returns a 404 error. Returning [NotFound](/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.notfound) returns an HTTP 404 response.
* Otherwise, the method returns 200 with a JSON response body. Returning `item` results in an HTTP 200 response.

## Work with Postman

This tutorial uses Postman to test the web api app.

* Install [Postman](https://www.getpostman.com/apps)
* Start the web app.
* Start Postman.
* Disable **SSL certificate verification**
  
  * From  **File > Settings** (**General* tab), disable **SSL certificate verification**.
  * > [!WARNING]
    > Re-enable SSL certificate verification after testing the controller.

![Postman console](first-web-api/_static/pmc.png)

* Create a new request.
* Set the HTTP method to **GET**.
* Set the URI to `http://localhost:<port>/api/values`. For example, `http://localhost:5001/api/todo`.
* Set **Two pan view** in Postman.
* Select **Send**.

![Postman with above request](first-web-api/_static/2pv.png)

## Create CRUD methods

In the following sections, `Create`, `Update`, and `Delete` methods are added to the controller.

### Create

Add the following `Create` method:

[!code-csharp[](first-web-api/samples/2.2/TodoApi/Controllers/TodoController.cs?name=snippet_Create)]

The preceding code is an HTTP POST method, as indicated by the [[HttpPost]](/dotnet/api/microsoft.aspnetcore.mvc.httppostattribute) attribute. MVC gets the value of the to-do item from the body of the HTTP request.

The `CreatedAtRoute` method:

* Returns a 201 response. HTTP 201 is the standard response for an HTTP POST method that creates a new resource on the server.
* Adds a Location header to the response. The Location header specifies the URI of the newly created to-do item. For more information, see [10.2.2 201 Created](https://www.w3.org/Protocols/rfc2616/rfc2616-sec10.html).
* Uses the "GetTodo" named route to create the URL. The "GetTodo" named route is defined in `GetById`:

[!code-csharp[](first-web-api/samples/2.2/TodoApi/Controllers/TodoController.cs?name=snippet_GetByID&highlight=1-2)]

### Use Postman to send a Create request

* Set the HTTP method to `POST`.
* Select the **Body** tab.
* Select the **raw** radio button.
* Set the type to *JSON (application/json)*.
* Enter a request body with a to-do item:

    ```json
    {
      "name":"walk dog",
      "isComplete":true
    }
    ```

* Select **Send**.

![Postman with above request](first-web-api/_static/create.png)

* Select the **Headers** tab in the **Response** pane.
* Copy the **Location** header value:

![Headers tab of the Postman console](first-web-api/_static/pmc2.png)

Test the location header URI:

* Set the method to GET.
* Paste the URI (for example, `https://localhost:5001/api/Todo/2`)
* Select **Send**.

### Update

Add the following `Update` method:

[!code-csharp[](first-web-api/samples/2.2/TodoApi/Controllers/TodoController.cs?name=snippet_Update)]

`Update` is similar to `Create`, except it uses HTTP PUT. The response is [204 (No Content)](https://www.w3.org/Protocols/rfc2616/rfc2616-sec9.html). According to the HTTP specification, a PUT request requires the client to send the entire updated entity, not just the deltas. To support partial updates, use HTTP PATCH.

Update the to-do item's name to "feed fish":

   ```json
    {
      "name":"feed fish",
      "isComplete":true
    }
    ```

![Postman console showing 204 (No Content) response](first-web-api/_static/pmcput.png)

### Delete

Add the following `Delete` method:

[!code-csharp[](first-web-api/samples/2.0/TodoApi/Controllers/TodoController.cs?name=snippet_Delete)]

The `Delete` response is [204 (No Content)](https://www.w3.org/Protocols/rfc2616/rfc2616-sec9.html).

Use Postman to delete the to-do item:

* Set the method to `DELETE`.
* Set the URI of the object to delete, for example `https://localhost:5001/api/todo/1`
* Select **Send**

The sample app doesn't allow you to delete all the items. When there are no items, a new one is created.

[!INCLUDE[jQuery](../includes/webApi/add-jquery.md)]

[!INCLUDE[next steps](../includes/webApi/next.md)]
