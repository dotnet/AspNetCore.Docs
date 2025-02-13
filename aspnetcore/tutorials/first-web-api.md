---
title: "Tutorial: Create a web API with ASP.NET Core"
author: wadepickett
description: Learn how to build a web API with ASP.NET Core.
ms.author: wpickett
ms.custom: mvc, engagement-fy24
ms.date: 02/13/2025
uid: tutorials/first-web-api
---

# Tutorial: Create a web API with ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Kirk Larkin](https://twitter.com/serpent5)

:::moniker range=">= aspnetcore-9.0"

This tutorial teaches the basics of building a controller-based web API that uses a database. Another approach to creating APIs in ASP.NET Core is to create *minimal APIs*. For help with choosing between minimal APIs and controller-based APIs, see <xref:fundamentals/apis>. For a tutorial on creating a minimal API, see <xref:tutorials/min-web-api>.

## Overview

This tutorial creates the following API:

|API | Description | Request body | Response body |
|--- | ---- | ---- | ---- |
|`GET /api/todoitems` | Get all to-do items | None | Array of to-do items|
|`GET /api/todoitems/{id}` | Get an item by ID | None | To-do item|
|`POST /api/todoitems` | Add a new item | To-do item | To-do item |
|`PUT /api/todoitems/{id}` | Update an existing item &nbsp; | To-do item | None |
|`DELETE /api/todoitems/{id}` &nbsp; &nbsp; | Delete an item &nbsp; &nbsp; | None | None|

The following diagram shows the design of the app.

![The client is represented by a box on the left. It submits a request and receives a response from the application, a box drawn on the right. Within the application box, three boxes represent the controller, the model, and the data access layer. The request comes into the application's controller, and read/write operations occur between the controller and the data access layer. The model is serialized and returned to the client in the response.](~/tutorials/first-web-api/_static/architecture.png)

## Prerequisites

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-prereqs-vs-9.0.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-prereqs-vsc-9.0.md)]

---

## Create a Web API project

# [Visual Studio](#tab/visual-studio)

* From the **File** menu, select **New** > **Project**.
* Enter *Web API* in the search box.
* Select the **ASP.NET Core Web API** template and select **Next**.
* In the **Configure your new project dialog**, name the project *TodoApi* and select **Next**.
* In the **Additional information** dialog:
  * Confirm the **Framework** is **.NET 9.0 (Standard Term Support)**.
  * Confirm the checkbox for **Enable OpenAPI support** is checked.
  * Confirm the checkbox for **Use controllers** is checked.
  * Select **Create**.

## Add NuGet packages

This tutorial uses the following additional NuGet packages:
    * `Microsoft.EntityFrameworkCore.InMemory`: Enables Entity Framework Core to work with an in-memory database rather than an external one, simplifying this tutorial.
    * `Swashbuckle.AspNetCore.SwaggerUI`: Provides a user interface for exploring and testing API endpoints interactively through Swagger.

Add the following NuGet packages used in this tutorial.

* From the **Tools** menu, select **NuGet Package Manager > Manage NuGet Packages for Solution**.
* Select the **Browse** tab.
* Enter **Microsoft.EntityFrameworkCore.InMemory** in the search box, and then select `Microsoft.EntityFrameworkCore.InMemory`.
* Select the **Project** checkbox in the right pane and then select **Install**.
* Enter **Swashbuckle.AspNetCore.SwaggerUI** in the search box, and then select `Swashbuckle.AspNetCore.SwaggerUI`.
* Select the **Project** checkbox in the right pane and then select **Install**.

# [Visual Studio Code](#tab/visual-studio-code)

* Open the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).
* Change directories (`cd`) to the folder that will contain the project folder.
* Run the following commands:

   ```dotnetcli
   dotnet new webapi --use-controllers -o TodoApi
   cd TodoApi
   dotnet add package Microsoft.EntityFrameworkCore.InMemory
   dotnet add package Swashbuckle.AspNetCore.SwaggerUI
   code -r ../TodoApi
   ```

  These commands:

  * Create a new web API project and open it in Visual Studio Code.
  * Adds NuGet packages that are used in this tutorial:
    * `Microsoft.EntityFrameworkCore.InMemory`: Enables Entity Framework Core to work with an in-memory database so a real database won't be required for this tutorial.
    * `Swashbuckle.AspNetCore.SwaggerUI`: Provides a user interface for exploring and testing API endpoints interactively through Swagger.
  * Open the *TodoApi* folder in the current instance of Visual Studio Code.

[!INCLUDE[](~/includes/vscode-trust-authors-add-assets.md)]

---

[!INCLUDE[](~/includes/package-reference.md)]

### Test the Project  

The project template:

* Creates a `WeatherForecast` API using controllers.
* Adds the `Microsoft.AspNetCore.OpenApi` package for OpenAPI support as a reference in the project file **TodoApi.csproj**.
* Adds OpenAPI services in **Project.cs** to automatically generate OpenAPI JSON documentation for the `WeatherForecast` API.

You can access the OpenAPI JSON documentation for the `WeatherForecast` API while the project is running by navigating your browser to `https://localhost:<port>/openapi/v1.json`, where `<port>` is a randomly chosen port number set during project creation.  

#### Configure the Swagger UI endpoint for the OpenAPI documentation

To configure [Swagger](xref:tutorials/web-api-help-pages-using-swagger) UI for testing the API, add the following highlighted code to the `Program.cs` file in the **TodoAPI** project:  

[!code-csharp[](~/tutorials/first-web-api/samples/9.0/TodoApi/Program.cs?name=snippet_First_Add_SwaggerUI&highlight=16-19)]

The previously highlighted code:

* Adds the Swagger UI as a service to the app with `app.UseSwaggerUI()`.
* Sets the `SwaggerEndpoint()` option to the location of the OpenAPI documentation for this project.  
* Ensures the Swagger UI is only available in the app development environment to limit information disclosure and security vulnerability.

# [Visual Studio](#tab/visual-studio)

Press Ctrl+F5 to run without the debugger.

[!INCLUDE[](~/includes/trustCertVS.md)]

 Visual Studio output pane shows messages similar to the following, indicating that the app is running and awaiting requests:

   ```output
   Microsoft.Hosting.Lifetime: Information: Now listening on: https://localhost:{port number}
   Microsoft.Hosting.Lifetime: Information: Now listening on: http://localhost:5071{port number}
   ```

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/trustCertVSC.md)]

Run the app:

* Run the following command to start the app on the `https` profile:

  ```dotnetcli
  dotnet run --launch-profile https
  ```

 The output shows messages similar to the following, indicating that the app is running and awaiting requests:

   ```output
   ...
   info: Microsoft.Hosting.Lifetime[14]
         Now listening on: https://localhost:{port number}
   ...
   ```

* <kbd>Ctrl</kbd>+*click* the HTTPS URL in the output to test the web app in a browser.

After testing the web app in the following instruction, press <kbd>Ctrl</kbd>+<kbd>C</kbd> in the integrated terminal to shut it down.

---

#### View the Swagger UI

* Navigate a browser to `https://localhost:<port>/swagger/index.html`, where `<port>` is a randomly chosen port number set in **Properties/launchSettings.json** and displayed in the output.

The Swagger page `/swagger/index.html` is displayed. 

* Select **GET** > **Try it out** > **Execute**. 

The page displays:

* The [Curl](https://curl.haxx.se/) command to test the WeatherForecast API.
* The URL to test the WeatherForecast API.
* The response code, body, and headers.
* A drop-down list box with media types and the example value and schema.

If the Swagger page doesn't appear, see [this GitHub issue](https://github.com/dotnet/AspNetCore.Docs/issues/21647).

Copy and paste the **Request URL** in the browser:  `https://localhost:<port>/weatherforecast`

JSON similar to the following example is returned:

```json
[
    {
        "date": "2019-07-16T19:04:05.7257911-06:00",
        "temperatureC": 52,
        "temperatureF": 125,
        "summary": "Mild"
    },
    {
        "date": "2019-07-17T19:04:05.7258461-06:00",
        "temperatureC": 36,
        "temperatureF": 96,
        "summary": "Warm"
    },
    {
        "date": "2019-07-18T19:04:05.7258467-06:00",
        "temperatureC": 39,
        "temperatureF": 102,
        "summary": "Cool"
    },
    {
        "date": "2019-07-19T19:04:05.7258471-06:00",
        "temperatureC": 10,
        "temperatureF": 49,
        "summary": "Bracing"
    },
    {
        "date": "2019-07-20T19:04:05.7258474-06:00",
        "temperatureC": -1,
        "temperatureF": 31,
        "summary": "Chilly"
    }
]
```

## Add a model class

A *model* is a set of classes that represent the data that the app manages. The model for this app is the `TodoItem` class.

# [Visual Studio](#tab/visual-studio)

* In **Solution Explorer**, right-click the project. Select **Add** > **New Folder**. Name the folder `Models`.
* Right-click the `Models` folder and select **Add** > **Class**. Name the class *TodoItem* and select **Add**.
* Replace the template code with the following:

# [Visual Studio Code](#tab/visual-studio-code)

* Add a folder named `Models`.
* Add a `TodoItem.cs` file to the `Models` folder with the following code:

---

  [!code-csharp[](~/tutorials/first-web-api/samples/9.0/TodoApi/Models/TodoItem.cs)]

The `Id` property functions as the unique key in a relational database.

Model classes can go anywhere in the project, but the `Models` folder is used by convention.

## Add a database context

The *database context* is the main class that coordinates Entity Framework functionality for a data model. This class is created by deriving from the <xref:Microsoft.EntityFrameworkCore.DbContext?displayProperty=fullName> class.

# [Visual Studio](#tab/visual-studio)

* Right-click the `Models` folder and select **Add** > **Class**. Name the class *TodoContext* and click **Add**.

# [Visual Studio Code](#tab/visual-studio-code)

* Add a `TodoContext.cs` file to the `Models` folder.

---

* Enter the following code:

  [!code-csharp[](~/tutorials/first-web-api/samples/9.0/TodoApi/Models/TodoContext.cs)]

## Register the database context

In ASP.NET Core, services such as the DB context must be registered with the [dependency injection (DI)](xref:fundamentals/dependency-injection) container. The container provides the service to controllers.

Update `Program.cs` with the following highlighted code:

[!code-csharp[](~/tutorials/first-web-api/samples/9.0/TodoApi/Program.cs?nameFinal_Add_DBContext=&highlight=1-2,9-10)]

The preceding code:

* Adds `using` directives.
* Adds the database context to the DI container.
* Specifies that the database context uses an in-memory database.

## Scaffold a controller

# [Visual Studio](#tab/visual-studio)

* Right-click the `Controllers` folder.
* Select **Add** > **:::no-loc text="New Scaffolded Item":::**.
* Select **API Controller with actions, using Entity Framework**, and then select **Add**.
* In the **Add API Controller with actions, using Entity Framework** dialog:

  * Select **TodoItem (TodoApi.Models)** in the **Model class**.
  * Select **TodoContext (TodoApi.Models)** in the **Data context class**.
  * Select **Add**.

  If the scaffolding operation fails, select **Add** to try scaffolding a second time.

# [Visual Studio Code](#tab/visual-studio-code)

Make sure that all of your changes so far are saved.

* Control-click the **TodoAPI** project and select **Open in Terminal**.  The terminal opens at the `TodoAPI` project folder.
Run the following commands:

```dotnetcli
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet tool uninstall -g dotnet-aspnet-codegenerator
dotnet tool install -g dotnet-aspnet-codegenerator
dotnet tool update -g dotnet-aspnet-codegenerator
```

The preceding commands:

* Add NuGet packages required for scaffolding.
* Install the scaffolding engine (`dotnet-aspnet-codegenerator`) after uninstalling any possible previous version.

For Linux, add the .NET tools directory to the system path with the following command:

```Bash
echo 'export PATH=$HOME/.dotnet/tools:$PATH' >> ~/.bashrc
source ~/.bashrc
```

[!INCLUDE[](~/includes/dotnet-tool-install-arch-options.md)]

Build the project.

Run the following command:

  ```dotnetcli
  dotnet aspnet-codegenerator controller -name TodoItemsController -async -api -m TodoItem -dc TodoContext -outDir Controllers
  ```

The preceding command scaffolds the `TodoItemsController`.

---

The generated code:

* Marks the class with the [`[ApiController]`](xref:Microsoft.AspNetCore.Mvc.ApiControllerAttribute) attribute. This attribute indicates that the controller responds to web API requests. For information about specific behaviors that the attribute enables, see <xref:web-api/index>.
* Uses DI to inject the database context (`TodoContext`) into the controller. The database context is used in each of the [CRUD](https://wikipedia.org/wiki/Create,_read,_update_and_delete) methods in the controller.

The ASP.NET Core templates for:

* Controllers with views include `[action]` in the route template.
* API controllers don't include `[action]` in the route template.

When the `[action]` token isn't in the route template, the [action](xref:mvc/controllers/routing#action) name (method name) isn't included in the endpoint. That is, the action's associated method name isn't used in the matching route.

## Update the PostTodoItem create method

In **Controllers/TodoItemsController.cs** update the return statement in the `PostTodoItem` to use the [nameof](/dotnet/csharp/language-reference/operators/nameof) operator:

[!code-csharp[](~/tutorials/first-web-api/samples/9.0/TodoApi/Controllers/TodoItemsController.cs?name=snippet_Create)]

The preceding code is an `HTTP POST` method, as indicated by the [`[HttpPost]`](xref:Microsoft.AspNetCore.Mvc.HttpPostAttribute) attribute. The method gets the value of the `TodoItem` from the body of the HTTP request.

For more information, see [Attribute routing with Http[Verb] attributes](xref:mvc/controllers/routing#verb).

The <xref:Microsoft.AspNetCore.Mvc.ControllerBase.CreatedAtAction%2A> method:

* Returns an [HTTP 201 status code](https://developer.mozilla.org/docs/Web/HTTP/Status/201) if successful. `HTTP 201` is the standard response for an `HTTP POST` method that creates a new resource on the server.
* Adds a [Location](https://developer.mozilla.org/docs/Web/HTTP/Headers/Location) header to the response. The `Location` header specifies the [URI](https://developer.mozilla.org/docs/Glossary/URI) of the newly created to-do item. For more information, see [10.2.2 201 Created](https://www.rfc-editor.org/rfc/rfc9110.html#section-10.2.2).
* References the `GetTodoItem` action to create the `Location` header's URI. The C# `nameof` keyword is used to avoid hard-coding the action name in the `CreatedAtAction` call.

<a name="post7"></a>

### Test PostTodoItem

* Press Ctrl+F5 to run the app.
* In the Swagger browser window, select **POST /api/TodoItems**, and then select **Try it out**.
* In the **Request body** input window, update the JSON. For example,
  
  ```JSON
  {
    "name": "walk dog",
    "isComplete": true
  }
  ```

* Select **Execute**

  ![Swagger POST](~/tutorials/first-web-api/_static/9/post.png)

### Test the location header URI

In the preceding POST, the Swagger UI shows the [location header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Location) under **Response headers**. For example, `location: https://localhost:7260/api/TodoItems/1`. The location header shows the URI to the created resource.

To test the location header:

* In the Swagger browser window, select **GET /api/TodoItems/{id}**, and then select **Try it out**.
* Enter `1` in the `id` input box, and then select **Execute**.

  ![Swagger GET](~/tutorials/first-web-api/_static/7/get.png)

## Examine the GET methods

Two GET endpoints are implemented:

* `GET /api/todoitems`
* `GET /api/todoitems/{id}`

The previous section showed an example of the `/api/todoitems/{id}` route.

Follow the [POST](#post7) instructions to add another todo item, and then test the `/api/todoitems` route using Swagger.

This app uses an in-memory database. If the app is stopped and started, the preceding GET request doesn't return any data. If no data is returned, [POST](#post7) data to the app.

## Routing and URL paths

The [`[HttpGet]`](xref:Microsoft.AspNetCore.Mvc.HttpGetAttribute) attribute denotes a method that responds to an `HTTP GET` request. The URL path for each method is constructed as follows:

* Start with the template string in the controller's `Route` attribute:

  [!code-csharp[](~/tutorials/first-web-api/samples/9.0/TodoApi/Controllers/TodoItemsController.cs?name=snippet_Route&highlight=1)]

* Replace `[controller]` with the name of the controller, which by convention is the controller class name minus the "Controller" suffix. For this sample, the controller class name is **TodoItems**Controller, so the controller name is "TodoItems". ASP.NET Core [routing](xref:mvc/controllers/routing) is case insensitive.

This sample doesn't use a route template with the [HttpGet] attribute. However in applications where an `[HttpGet]` attribute has a route template (for example, `[HttpGet("products")]`), append that to the path. For more information, see [Attribute routing with Http[Verb] attributes](xref:mvc/controllers/routing#verb).

In the following `GetTodoItem` method, `"{id}"` is a placeholder variable for the unique identifier of the to-do item. When `GetTodoItem` is invoked, the value of `"{id}"` in the URL is provided to the method in its `id` parameter.

[!code-csharp[](~/tutorials/first-web-api/samples/9.0/TodoApi/Controllers/TodoItemsController.cs?name=snippet_GetByID&highlight=1-2)]

## Return values

The return type of the `GetTodoItems` and `GetTodoItem` methods is [ActionResult\<T> type](xref:web-api/action-return-types#actionresultt-type). ASP.NET Core automatically serializes the object to [JSON](https://www.json.org/) and writes the JSON into the body of the response message. The response code for this return type is [200 OK](https://developer.mozilla.org/docs/Web/HTTP/Status/200), assuming there are no unhandled exceptions. Unhandled exceptions are translated into 5xx errors.

`ActionResult` return types can represent a wide range of HTTP status codes. For example, `GetTodoItem` can return two different status values:

* If no item matches the requested ID, the method returns a [404 status](https://developer.mozilla.org/docs/Web/HTTP/Status/404) <xref:Microsoft.AspNetCore.Mvc.ControllerBase.NotFound%2A> error code.
* Otherwise, the method returns 200 with a JSON response body. Returning `item` results in an `HTTP 200` response.

## The PutTodoItem method

Examine the `PutTodoItem` method:

[!code-csharp[](~/tutorials/first-web-api/samples/9.0/TodoApi/Controllers/TodoItemsController.cs?name=snippet_PutTodoItem)]

`PutTodoItem` is similar to `PostTodoItem`, except it uses `HTTP PUT`. The response is [204 (No Content)](https://www.rfc-editor.org/rfc/rfc9110#status.204). According to the HTTP specification, a `PUT` request requires the client to send the entire updated entity, not just the changes. To support partial updates, use [HTTP PATCH](xref:Microsoft.AspNetCore.Mvc.HttpPatchAttribute).

### Test the PutTodoItem method

This sample uses an in-memory database that must be initialized each time the app is started. There must be an item in the database before you make a PUT call. Call GET to ensure there's an item in the database before making a PUT call.

Using the Swagger UI, use the PUT button to update the `TodoItem` that has Id = 1 and set its name to `"feed fish"`. Note the response is [`HTTP 204 No Content`](https://developer.mozilla.org/docs/Web/HTTP/Status/204).

## The DeleteTodoItem method

Examine the `DeleteTodoItem` method:

[!code-csharp[](~/tutorials/first-web-api/samples/6.0/TodoApi/Controllers/TodoItemsController.cs?name=snippet_Delete)]

### Test the DeleteTodoItem method

Use the Swagger UI to delete the `TodoItem` that has Id = 1. Note the response is [`HTTP 204 No Content`](https://developer.mozilla.org/docs/Web/HTTP/Status/204).

## Test with other tools

There are many other tools that can be used to test web APIs, for example:

* [Visual Studio Endpoints Explorer and .http files](xref:test/http-files)
* [http-repl](xref:web-api/http-repl)
* [curl](https://terminalcheatsheet.com/guides/curl-rest-api). Swagger uses `curl` and shows the `curl` commands it submits.
* [Fiddler](https://www.telerik.com/fiddler)

For more information, see:

* [Minimal API tutorial: test with .http files and Endpoints Explorer](xref:tutorials/min-web-api)
* [Install and test APIs with `http-repl`](xref:tutorials/first-web-api?view=aspnetcore-6.0&preserve-view=true#ihr6)

<!-- Verify https://go.microsoft.com/fwlink/?linkid=2123754 goes to this H2. Verify the latest released version is on top so this anchor works -->
<a name="over-post"></a>

## Prevent over-posting

Currently the sample app exposes the entire `TodoItem` object. Production apps typically limit the data that's input and returned using a subset of the model. There are multiple reasons behind this, and security is a major one. The subset of a model is usually referred to as a Data Transfer Object (DTO), input model, or view model. **DTO** is used in this tutorial.

A DTO may be used to:

* Prevent over-posting.
* Hide properties that clients are not supposed to view.
* Omit some properties in order to reduce payload size.
* Flatten object graphs that contain nested objects. Flattened object graphs can be more convenient for clients.

To demonstrate the DTO approach, update the `TodoItem` class to include a secret field:

[!code-csharp[](~/tutorials/first-web-api/samples/9.0/TodoApiDTO/Models/TodoItem.cs?highlight=8)]

The secret field needs to be hidden from this app, but an administrative app could choose to expose it.

Verify you can post and get the secret field.

Create a DTO model in a **Models/TodoItemsDTO.cs** file:

[!code-csharp[](~/tutorials/first-web-api/samples/9.0/TodoApiDTO/Models/TodoItemDTO.cs)]

Update the `TodoItemsController` to use `TodoItemDTO`:

[!code-csharp[](~/tutorials/first-web-api/samples/9.0/TodoApiDTO/Controllers/TodoItemsController.cs?highlight=25,28,34,43,49,51,62,63,89,93,94,100,124-130)]

Verify you can't post or get the secret field.

## Call the web API with JavaScript

See [Tutorial: Call an ASP.NET Core web API with JavaScript](xref:tutorials/web-api-javascript).

## Web API video series

See [Video: Beginner's Series to: Web APIs](/shows/beginners-series-to-web-apis/).

[!INCLUDE[](~/includes/reliableWAP_H2.md)]

<a name="auth"></a>

## Add authentication support to a web API

[!INCLUDE[](~/includes/DuendeIdentityServer.md)]

## Publish to Azure

For information on deploying to Azure, see [Quickstart: Deploy an ASP.NET web app](/azure/app-service/quickstart-dotnetcore).

## Additional resources

[View or download sample code for this tutorial](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/first-web-api/samples). See [how to download](xref:index#how-to-download-a-sample).

For more information, see the following resources:

* <xref:web-api/index>
* <xref:tutorials/min-web-api>
( <xref:fundamentals/openapi/using-openapi-documents>
* <xref:tutorials/web-api-help-pages-using-swagger>
* <xref:data/ef-rp/intro>
* <xref:mvc/controllers/routing>
* <xref:web-api/action-return-types>
* <xref:host-and-deploy/azure-apps/index>
* <xref:host-and-deploy/index>
* [Create a web API with ASP.NET Core](/training/modules/build-web-api-aspnet-core/)

:::moniker-end

[!INCLUDE[](~/tutorials/first-web-api/includes/first-web-api7.md)]

[!INCLUDE[](~/tutorials/first-web-api/includes/first-web-api8.md)]