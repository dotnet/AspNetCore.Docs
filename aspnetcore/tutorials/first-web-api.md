---
title: "Tutorial: Create a controller-based web API with ASP.NET Core"
author: wadepickett
description: Learn how to build a controller-based web API with ASP.NET Core.
ms.author: wpickett
ms.custom: mvc, engagement-fy24
ms.date: 02/17/2025
uid: tutorials/first-web-api
---

# Tutorial: Create a controller-based web API with ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

By [Tim Deschryver](https://timdeschryver.dev/) and [Rick Anderson](https://twitter.com/RickAndMSFT)

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
  * Confirm the checkbox for **Use controllers (uncheck to use minimal APIs)** is checked.
  * Select **Create**.

## Add a NuGet package

A NuGet package must be added to support the database used in this tutorial.

* From the **Tools** menu, select **NuGet Package Manager > Manage NuGet Packages for Solution**.
* Select the **Browse** tab.
* Enter **Microsoft.EntityFrameworkCore.InMemory** in the search box, and then select `Microsoft.EntityFrameworkCore.InMemory`.
* Select the **Project** checkbox in the right pane and then select **Install**.

# [Visual Studio Code](#tab/visual-studio-code)

* Open the [integrated terminal](https://code.visualstudio.com/docs/terminal/basics).
* Change directories (`cd`) to the folder that will contain the project folder.
* Run the following commands:

   ```dotnetcli
   dotnet new webapi --use-controllers -o TodoApi
   cd TodoApi
   dotnet add package Microsoft.EntityFrameworkCore.InMemory
   code -r .
   ```

  These commands:

  * Create a new web API project and open it in Visual Studio Code.
  * Add a NuGet package that is needed for the next section.
  * Open the *TodoApi* folder in the current instance of Visual Studio Code.

[!INCLUDE[](~/includes/vscode-trust-authors-add-assets.md)]

---

[!INCLUDE[](~/includes/package-reference.md)]

### Run the project

The project template creates a `WeatherForecast` API with support for [OpenAPI](xref:fundamentals/openapi/overview).

# [Visual Studio](#tab/visual-studio)

Press Ctrl+F5 to run without the debugger.

[!INCLUDE[](~/includes/trustCertVS.md)]

Visual Studio launches a terminal window and displays the URL of the running app. The API is hosted at `https://localhost:<port>`, where `<port>` is a randomly chosen port number set at the project creation. 

   ```output
   ...
   info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7260
   info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:7261
   info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
   ...
   ```

<kbd>Ctrl</kbd>+*click* the HTTPS URL in the output to test the web app in a browser. There's no endpoint at `https://localhost:<port>`, so the browser returns [HTTP 404 Not Found](https://developer.mozilla.org/docs/Web/HTTP/Status/404).

Append `/weatherforecast` to the URL to test the WeatherForecast API. 
The browser displays JSON similar to the following example:

```json
[
    {
        "date": "2025-07-16",
        "temperatureC": 52,
        "temperatureF": 125,
        "summary": "Mild"
    },
    {
        "date": "2025-07-17",
        "temperatureC": 36,
        "temperatureF": 96,
        "summary": "Warm"
    },
    {
        "date": "2025-07-18",
        "temperatureC": 39,
        "temperatureF": 102,
        "summary": "Cool"
    },
    {
        "date": "2025-07-19",
        "temperatureC": 10,
        "temperatureF": 49,
        "summary": "Bracing"
    },
    {
        "date": "2025-07-20",
        "temperatureC": -1,
        "temperatureF": 31,
        "summary": "Chilly"
    }
]
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
         Now listening on: https://localhost:{port}
   ...
   ```

* <kbd>Ctrl</kbd>+*click* the HTTPS URL in the output to test the web app in a browser.

* The default browser is launched to `https://localhost:<port>`, where `<port>` is the randomly chosen port number displayed in the output. There's no endpoint at `https://localhost:<port>`, so the browser returns [HTTP 404 Not Found](https://developer.mozilla.org/docs/Web/HTTP/Status/404).

* Append `/weatherforecast` to the URL to test the WeatherForecast API. The browser displays JSON similar to the following example:
    
```json
[
    {
        "date": "2025-07-16",
        "temperatureC": 52,
        "temperatureF": 125,
        "summary": "Mild"
    },
    {
        "date": "2025-07-17",
        "temperatureC": 36,
        "temperatureF": 96,
        "summary": "Warm"
    },
    {
        "date": "2025-07-18",
        "temperatureC": 39,
        "temperatureF": 102,
        "summary": "Cool"
    },
    {
        "date": "2025-07-19",
        "temperatureC": 10,
        "temperatureF": 49,
        "summary": "Bracing"
    },
    {
        "date": "2025-07-20",
        "temperatureC": -1,
        "temperatureF": 31,
        "summary": "Chilly"
    }
]
```
    
* After testing the web app using the following instruction, press <kbd>Ctrl</kbd>+<kbd>C</kbd> in the integrated terminal to close it.

---

### Test the project

# [Visual Studio](#tab/visual-studio)

This tutorial uses [Endpoints Explorer and .http files](xref:test/http-files#use-endpoints-explorer) to test the API.

# [Visual Studio Code](#tab/visual-studio-code) 

## Create API testing UI with Swagger

There are many available web API testing tools to choose from, and you can follow this tutorial's introductory API test steps with your preferred tool.

This tutorial utilizes the .NET package [NSwag.AspNetCore](https://www.nuget.org/packages/NSwag.AspNetCore/), which integrates Swagger tools for generating a testing UI adhering to the OpenAPI specification:

* NSwag: A .NET library that integrates Swagger directly into ASP.NET Core applications, providing middleware and configuration.
* Swagger: A set of open-source tools such as OpenAPIGenerator and SwaggerUI that generate API testing pages that follow the OpenAPI specification.
* OpenAPI specification: A document that describes the capabilities of the API, based on the XML and attribute annotations within the controllers and models.

For more information on using OpenAPI and NSwag with ASP.NET, see <xref:tutorials/web-api-help-pages-using-swagger>.

### Install Swagger tooling

* Run the following command:

  ```dotnetcli
  dotnet add package NSwag.AspNetCore
  ```

The previous command adds the [NSwag.AspNetCore](https://www.nuget.org/packages/NSwag.AspNetCore/) package, which contains tools to generate Swagger documents and UI.
Because our project is using OpenAPI, we only use the NSwag package to generate the Swagger UI.

### Configure Swagger middleware

* In `Program.cs`, add the following highlighted code:

:::code language="csharp" source="~/tutorials/first-web-api/samples/9.0/TodoApi_SwaggerVersion/Program.cs" id="snippet_UseSwagger" highlight="6-9":::

The previous code enables the Swagger middleware for serving the generated JSON document using the Swagger UI. Swagger is only enabled in a development environment. Enabling Swagger in a production environment could expose potentially sensitive details about the API's structure and implementation.

The app uses the OpenAPI document generated by OpenApi, located at `/openapi/v1.json`, to generate the UI.
View the generated OpenAPI specification for the `WeatherForecast` API while the project is running by navigating to `https://localhost:<port>/openapi/v1.json` in your browser.

The OpenAPI specification is a document in JSON format that describes the structure and capabilities of your API, including endpoints, request/response formats, parameters, and more. It's essentially a blueprint of your API that can be used by various tools to understand and interact with your API.

---

## Add a model class

A *model* is a set of classes that represent the data that the app manages. The model for this app is the `TodoItem` class.

# [Visual Studio](#tab/visual-studio)

* In **Solution Explorer**, right-click the project. Select **Add** > **New Folder**. Name the folder `Models`.
* Right-click the `Models` folder and select **Add** > **Class**. Name the class *TodoItem* and select **Add**.
* Replace the template code with the following:

:::code language="csharp" source="~/tutorials/first-web-api/samples/9.0/TodoApi/Models/TodoItem.cs":::

# [Visual Studio Code](#tab/visual-studio-code)

* Add a folder named `Models`.
* Add a `TodoItem.cs` file to the `Models` folder with the following code:

:::code language="csharp" source="~/tutorials/first-web-api/samples/9.0/TodoApi_SwaggerVersion/Models/TodoItem.cs":::

---

The `Id` property functions as the unique key in a relational database.

Model classes can go anywhere in the project, but the `Models` folder is used by convention.

## Add a database context

The *database context* is the main class that coordinates Entity Framework functionality for a data model. This class is created by deriving from the <xref:Microsoft.EntityFrameworkCore.DbContext?displayProperty=fullName> class.

# [Visual Studio](#tab/visual-studio)

* Right-click the `Models` folder and select **Add** > **Class**. Name the class *TodoContext* and click **Add**.
* Enter the following code:

  :::code language="csharp" source="~/tutorials/first-web-api/samples/9.0/TodoApi/Models/TodoContext.cs":::

# [Visual Studio Code](#tab/visual-studio-code)

* Add a `TodoContext.cs` file to the `Models` folder.
* Enter the following code:

  :::code language="csharp" source="~/tutorials/first-web-api/samples/9.0/TodoApi_SwaggerVersion/Models/TodoContext.cs":::

---

## Register the database context

In ASP.NET Core, services such as the DB context must be registered with the [dependency injection (DI)](xref:fundamentals/dependency-injection) container. The container provides the service to controllers.

Update `Program.cs` with the following highlighted code:

:::code language="csharp" source="~/tutorials/first-web-api/samples/9.0/TodoApi/Program.cs" highlight="1-2,8-9":::

The preceding code:

* Adds `using` directives.
* Adds the database context to the DI container.
* Specifies that the database context will use an in-memory database.

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

This step adds the `Microsoft.VisualStudio.Web.CodeGeneration.Design` and `Microsoft.EntityFrameworkCore.Tools` NuGet packages to the project. 
These packages are required for scaffolding.

# [Visual Studio Code](#tab/visual-studio-code)

Make sure that all of your changes so far are saved.

* Right-click (or Command-click on macOS) the **TodoAPI** project and select **Open in Terminal**.  The terminal opens at the `TodoAPI` project folder.
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

Update the return statement in the `PostTodoItem` to use the [nameof](/dotnet/csharp/language-reference/operators/nameof) operator:

:::code language="csharp" source="~/tutorials/first-web-api/samples/9.0/TodoApi/Controllers/TodoItemsController.cs" id="snippet_Create":::

The preceding code is an `HTTP POST` method, as indicated by the [`[HttpPost]`](xref:Microsoft.AspNetCore.Mvc.HttpPostAttribute) attribute. The method gets the value of the `TodoItem` from the body of the HTTP request.

For more information, see [Attribute routing with Http[Verb] attributes](xref:mvc/controllers/routing#verb).

The <xref:Microsoft.AspNetCore.Mvc.ControllerBase.CreatedAtAction%2A> method:

* Returns an [HTTP 201 status code](https://developer.mozilla.org/docs/Web/HTTP/Status/201) if successful. `HTTP 201` is the standard response for an `HTTP POST` method that creates a new resource on the server.
* Adds a [Location](https://developer.mozilla.org/docs/Web/HTTP/Headers/Location) header to the response. The `Location` header specifies the [URI](https://developer.mozilla.org/docs/Glossary/URI) of the newly created to-do item. For more information, see [10.2.2 201 Created](https://www.rfc-editor.org/rfc/rfc9110.html#section-10.2.2).
* References the `GetTodoItem` action to create the `Location` header's URI. The C# `nameof` keyword is used to avoid hard-coding the action name in the `CreatedAtAction` call.

<a name="post7"></a>

### Test PostTodoItem

# [Visual Studio](#tab/visual-studio)

* Select **View** > **Other Windows** > **Endpoints Explorer**.
* Right-click the **POST** endpoint and select **Generate request**.

  ![Endpoints Explorer context menu highlighting Generate Request menu item.](~/tutorials/first-web-api/_static/9/generate-request-vs17.13.0.png)

  A new file is created in the project folder named `TodoApi.http`, with contents similar to the following example:

  ```
  @TodoApi_HostAddress = https://localhost:49738
    
  POST {{TodoApi_HostAddress}}/api/todoitems
  Content-Type: application/json
  
  {
    //TodoItem
  }
  
  ###
  ```

  * The first line creates a variable that is used for all of the endpoints.
  * The next line defines a POST request.
  * The lines after the POST request line defines the headers, and a placeholder for the request body.
  * The triple hashtag (`###`) line is a request delimiter: what comes after it is for a different request.

* The POST request expects a `TodoItem`. To define the todo, replace the `//TodoItem` comment with the following JSON:

  ```json
  {
    "name": "walk dog",
    "isComplete": true
  }
  ```
  
  The TodoApi.http file should now look like the following example, but with your port number:
  
  ```
  @TodoApi_HostAddress = https://localhost:7260
  
  Post {{TodoApi_HostAddress}}/api/todoitems
  Content-Type: application/json
  
  {
    "name": "walk dog",
    "isComplete": true
  }
  
  ###
  ```

* Run the app.

* Select the **Send request** link that is above the `POST` request line.

  ![.http file window with run link highlighted.](~/tutorials/first-web-api/_static/9/http-file-run-button-vs17.13.0.png)

  The POST request is sent to the app and the response is displayed in the **Response** pane.

  ![.http file window with response from the POST request.](~/tutorials/first-web-api/_static/9/http-file-window-with-response-vs17.13.0.png)

# [Visual Studio Code](#tab/visual-studio-code)

* With the app still running, in the browser, navigate to `https://localhost:<port>/swagger` to display the API testing page generated by Swagger. Click on **TodoItems** to expand the operations.

  ![Swagger generated API testing page](~/tutorials/first-web-api/_static/9/swagger.png)

* On the Swagger API testing page, select **Post /api/todoitems** > **Try it out**.
* Note that the **Request body** field contains a generated example format reflecting the parameters for the API.
* In the request body enter JSON for a to-do item, without specifying the optional `id`:

  ```json
  {
    "name": "walk dog",
    "isComplete": true
  }
  ```

* Select **Execute**.

  ![Swagger with Post request](~/tutorials/first-web-api/_static/9/swagger-post.png)

* Swagger provides a **Responses** pane below the **Execute** button. 

  ![Swagger with Post response](~/tutorials/first-web-api/_static/9/swagger-post-response.png)

Note a few of the useful details:

* cURL: Swagger provides an example cURL command in Unix/Linux syntax, which can be run at the command line with any bash shell that uses Unix/Linux syntax, including Git Bash from [Git for Windows](https://git-scm.com/downloads).
* Request URL: A simplified representation of the HTTP request made by Swagger UI's JavaScript code for the API call. Actual requests can include details such as headers and query parameters and a request body.
* Server response: Includes the response body and headers. The response body shows the `id` was set to `1`.
* Response Code: A 201 `HTTP` status code was returned, indicating that the request was successfully processed and resulted in the creation of a new resource.

---

### Test the location header URI

# [Visual Studio](#tab/visual-studio)

Test the app by calling the `GET` endpoints from a browser or by using **Endpoints Explorer**. The following steps are for **Endpoints Explorer**.

* In **Endpoints Explorer**, right-click the first **GET** endpoint, and select **Generate request**.

  The following content is added to the `TodoApi.http` file:

  ```
  GET {{TodoApi_HostAddress}}/api/todoitems
  
  ###
  ```

* Select the **Send request** link that is above the new `GET` request line.

  The GET request is sent to the app and the response is displayed in the **Response** pane.

* The response body is similar to the following JSON:

  ```json
  [
    {
      "id": 1,
      "name": "walk dog",
      "isComplete": true
    }
  ]
  ```

* In **Endpoints Explorer**, right-click the `/api/todoitems/{id}` **GET** endpoint and select **Generate request**.
  The following content is added to the `TodoApi.http` file:

  ```
  @id=0
  GET {{TodoApi_HostAddress}}/api/todoitems/{{id}}

  ###
  ```

* Assign `{@id}` to `1` (instead of `0`).

* Select the **Send request** link that is above the new GET request line.

  The GET request is sent to the app and the response is displayed in the **Response** pane.

* The response body is similar to the following JSON:

  ```json
  {
    "id": 1,
    "name": "walk dog",
    "isComplete": true
  }
  ```
  
# [Visual Studio Code](#tab/visual-studio-code)

Test the app by calling the endpoints from a browser or Swagger.

* In Swagger select **GET /api/todoitems** > **Try it out** > **Execute**.

* Alternatively, call **GET /api/todoitems** from a browser by entering the URI `https://localhost:<port>/api/todoitems`. For example, `https://localhost:7260/api/todoitems`

The call to `GET /api/todoitems` produces a response similar to the following:

```json
[
  {
    "id": 1,
    "name": "walk dog",
    "isComplete": true
  }
]
```

* Call **GET /api/todoitems/{id}** in Swagger to return data from a specific id:
  * Select **GET /api/todoitems** > **Try it out**.
  * Set the **id** field to `1` and select **Execute**.

* Alternatively, call **GET /api/todoitems** from a browser by entering the URI `https://localhost:<port>/api/todoitems/1`. For example, `https://localhost:7260/api/todoitems/1`

* The response is similar to the following:

  ```json
  {
    "id": 1,
    "name": "walk dog",
    "isComplete": true
  }
  ```

---

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

  :::code language="csharp" source="~/tutorials/first-web-api/samples/9.0/TodoApi/Controllers/TodoItemsController.cs" id="snippet_Route" highlight="1":::

* Replace `[controller]` with the name of the controller, which by convention is the controller class name minus the "Controller" suffix. For this sample, the controller class name is **TodoItems**Controller, so the controller name is "TodoItems". ASP.NET Core [routing](xref:mvc/controllers/routing) is case insensitive.
* If the `[HttpGet]` attribute has a route template (for example, `[HttpGet("products")]`), append that to the path. This sample doesn't use a template. For more information, see [Attribute routing with Http[Verb] attributes](xref:mvc/controllers/routing#verb).

In the following `GetTodoItem` method, `"{id}"` is a placeholder variable for the unique identifier of the to-do item. When `GetTodoItem` is invoked, the value of `"{id}"` in the URL is provided to the method in its `id` parameter.

:::code language="csharp" source="~/tutorials/first-web-api/samples/9.0/TodoApi/Controllers/TodoItemsController.cs" id="snippet_GetByID" highlight="1-2":::

## Return values

The return type of the `GetTodoItems` and `GetTodoItem` methods is [ActionResult\<T> type](xref:web-api/action-return-types#actionresultt-type). ASP.NET Core automatically serializes the object to [JSON](https://www.json.org/) and writes the JSON into the body of the response message. The response code for this return type is [200 OK](https://developer.mozilla.org/docs/Web/HTTP/Status/200), assuming there are no unhandled exceptions. Unhandled exceptions are translated into 5xx errors.

`ActionResult` return types can represent a wide range of HTTP status codes. For example, `GetTodoItem` can return two different status values:

* If no item matches the requested ID, the method returns a [404 status](https://developer.mozilla.org/docs/Web/HTTP/Status/404) <xref:Microsoft.AspNetCore.Mvc.ControllerBase.NotFound%2A> error code.
* Otherwise, the method returns 200 with a JSON response body. Returning `item` results in an `HTTP 200` response.

## The PutTodoItem method

Examine the `PutTodoItem` method:

:::code language="csharp" source="~/tutorials/first-web-api/samples/9.0/TodoApi/Controllers/TodoItemsController.cs" id="snippet_Update" :::

`PutTodoItem` is similar to `PostTodoItem`, except it uses `HTTP PUT`. The response is [204 (No Content)](https://www.rfc-editor.org/rfc/rfc9110#status.204). According to the HTTP specification, a `PUT` request requires the client to send the entire updated entity, not just the changes. To support partial updates, use [HTTP PATCH](xref:Microsoft.AspNetCore.Mvc.HttpPatchAttribute).

### Test the PutTodoItem method

This sample uses an in-memory database that must be initialized each time the app is started. There must be an item in the database before you make a PUT call. Call GET to ensure there's an item in the database before making a PUT call.

Use the `PUT` method to update the `TodoItem` that has Id = 1 and set its name to `"feed fish"`. Note the response is [`HTTP 204 No Content`](https://developer.mozilla.org/docs/Web/HTTP/Status/204).

# [Visual Studio](#tab/visual-studio)

* In **Endpoints Explorer**, right-click the **PUT** endpoint, and select **Generate request**.

  The following content is added to the `TodoApi.http` file:

  ```
  PUT {{TodoApi_HostAddress}}/api/todoitems/{{id}}
  Content-Type: application/json
  
  {
    //TodoItem
  }
  
  ###
  ```

* In the PUT request line, replace `{{id}}` with `1`.

* Replace the `//TodoItem` placeholder with the following lines:

  ```
  PUT {{TodoApi_HostAddress}}/api/todoitems/1
  Content-Type: application/json

  {
    "id": 1,
    "name": "feed fish",
    "isComplete": false
  }
  ```

* Select the **Send request** link that is above the new PUT request line.

  The PUT request is sent to the app and the response is displayed in the **Response** pane. The response body is empty, and the status code is 204.
  
# [Visual Studio Code](#tab/visual-studio-code)

Use Swagger to send a PUT request:

* Select **Put /api/todoitems/{id}** > **Try it out**.

* Set the **id** field to `1`.

* Set the request body to the following JSON:

  ```json
  {
    "id": 1,
    "name": "feed fish",
    "isComplete": false
  }
  ```

* Select **Execute**.

---

## The DeleteTodoItem method

Examine the `DeleteTodoItem` method:

:::code language="csharp" source="~/tutorials/first-web-api/samples/9.0/TodoApi/Controllers/TodoItemsController.cs" id="snippet_Delete" :::

### Test the DeleteTodoItem method

Use the `DELETE` method to delete the `TodoItem` that has Id = 1. Note the response is [`HTTP 204 No Content`](https://developer.mozilla.org/docs/Web/HTTP/Status/204).

# [Visual Studio](#tab/visual-studio)

* In **Endpoints Explorer**, right-click the **DELETE** endpoint and select **Generate request**.

  A DELETE request is added to `TodoApi.http`.

* Replace `{{id}}` in the DELETE request line with `1`. The DELETE request should look like the following example:

  ```
  DELETE {{TodoApi_HostAddress}}/api/todoitems/{{id}}
  
  ###
  ```

* Select the **Send request** link for the DELETE request.

  The DELETE request is sent to the app and the response is displayed in the **Response** pane. The response body is empty, and the status code is 204.
  
# [Visual Studio Code](#tab/visual-studio-code)

Use Swagger to send a DELETE request:

* Select **DELETE /api/todoitems/{id}** > **Try it out**.
* Set the **ID** field to `1` and select **Execute**.

  The DELETE request is sent to the app and the response is displayed in the **Responses** pane. The response body is empty, and the **Server response** status code is 204.

---

## Test with other tools

There are many other tools that can be used to test web APIs, for example:

* [http-repl](xref:web-api/http-repl)
* [curl](https://terminalcheatsheet.com/guides/curl-rest-api). Swagger uses `curl` and shows the `curl` commands it submits.
* [Fiddler](https://www.telerik.com/fiddler)


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

:::code language="csharp" source="~/tutorials/first-web-api/samples/9.0/TodoApiDTO/Models/TodoItem.cs" highlight="8" :::

The secret field needs to be hidden from this app, but an administrative app could choose to expose it.

Verify you can post and get the secret field.

Create a DTO model in a **Models/TodoItemsDTO.cs** file:

:::code language="csharp" source="~/tutorials/first-web-api/samples/9.0/TodoApiDTO/Models/TodoItemDTO.cs" :::

Update the `TodoItemsController` to use `TodoItemDTO`:

:::code language="csharp" source="~/tutorials/first-web-api/samples/9.0/TodoApiDTO/Controllers/TodoItemsController.cs" :::

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

[View or download sample code for this tutorial](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/first-web-api/samples). See [how to download](xref:fundamentals/index#how-to-download-a-sample).

For more information, see the following resources:

* <xref:web-api/index>
* <xref:tutorials/min-web-api>
* <xref:fundamentals/openapi/using-openapi-documents>
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
