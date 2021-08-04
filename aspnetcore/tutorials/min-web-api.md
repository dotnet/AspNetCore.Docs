---
title: "Tutorial: Create a minimal web API with ASP.NET Core"
author: rick-anderson
description: Learn how to build a minimal web API with ASP.NET Core.
ms.author: riande
ms.date: 8/24/2021
monikerRange: '>= aspnetcore-6.0'
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR, Models]
uid: tutorials/min-web-api
---

<!-- test with windows sandbox -->
# Tutorial: Create a web minimal API with ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

Minimal APIs are architected to create REST APIs with the minimal dependencies. They are ideal for microservice and app that don't want to include only the minimum files, features, and dependencies in ASP.NET Core.

This tutorial teaches the basics of building a miminal web API with ASP.NET Core. For a tutorial on creating a web API project that contains more features, see [Create a web API](xref:tutorials/first-web-api)

## Overview

This tutorial creates the following API:

|API | Description | Request body | Response body |
|--- | ---- | ---- | ---- |
|`GET /TodoItems` | Get all to-do items | None | Array of to-do items|
|`GET /TodoItems/{id}` | Get an item by ID | None | To-do item|
|`POST /TodoItems` | Add a new item | To-do item | To-do item |
|`PUT /TodoItems/{id}` | Update an existing item &nbsp; | To-do item | None |
|`DELETE /TodoItems/{id}` &nbsp; &nbsp; | Delete an item &nbsp; &nbsp; | None | None|
|`GET /api` | Browser test, "Hello World" | None | "Hello World"|

## Prerequisites

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-prereqs-vs-6.0.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-prereqs-vsc-6.0.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

[!INCLUDE[](~/includes/net-prereqs-mac-6.0.md)]

---

## Create an empty web project

# [Visual Studio](#tab/visual-studio)

* From the **File** menu, select **New** > **Project**.
* Select the **ASP.NET Core Empty** template and select **Next**.
* Name the project *TodoApi* and select **Next**.
* In the **Additional information** dialog, select **.NET 6.0 (Preview)** and select **Create**.
 
<!-- 
![VS new project dialog](min-web-api/_static/5/vs.png)
-->

<!-- Move this later since we don't need it now -->
### Add NuGet packages

* From the **Tools** menu, select **NuGet Package Manager > Manage NuGet Packages for Solution**.
* Select the **Browse** tab, and then enter `Microsoft.EntityFrameworkCore.InMemory` in the search box. Verify **Incluee prerelease** is checked.
* Select `Microsoft.EntityFrameworkCore.InMemory` in the left pane.
* Select the **Project** checkbox in the right pane and then select **Install**.
* Follow the preceding instructions to add the following packages:
  * `Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore`
  * `MinimalValidation`

# [Visual Studio Code](#tab/visual-studio-code)

* Open the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).
* Change directories (`cd`) to the folder that will contain the project folder.
* Run the following commands:

   ```dotnetcli
   dotnet new webapi -o TodoApi
   cd TodoApi
   dotnet add package Microsoft.EntityFrameworkCore.InMemory
   code -r ../TodoApi
   ```

* When a dialog box asks if you want to add required assets to the project, select **Yes**.

  The preceding commands:

  * Creates a new web API project and opens it in Visual Studio Code.
  * Adds the NuGet packages which are required in the next section.

# [Visual Studio for Mac](#tab/visual-studio-mac)

* Select **File** > **New Solution**.

`  ![macOS New solution](first-web-api-mac/_static/sln.png)`

* In Visual Studio for Mac earlier than version 8.6, select **.NET Core** > **App** > **API** > **Next**. In version 8.6 or later, select **Web and Console** > **App** > **API** > **Next**.

`  ![macOS API template selection](first-web-api-mac/_static/api_template.png)`

* In the **Configure the new ASP.NET Core Web API** dialog, select the latest .NET Core 5.x **Target Framework**. Select **Next**.

* Enter *TodoApi* for the **Project Name** and then select **Create**.

 ` ![config dialog](first-web-api-mac/_static/2.png)`

[!INCLUDE[](~/includes/mac-terminal-access.md)]

Open a command terminal in the project folder and run the following command:

   ```dotnetcli
   dotnet add package Microsoft.EntityFrameworkCore.InMemory
   ```
---

### Examine the code

The *Program.cs* file contains the following code:

[!code-csharp[](min-web-api/samples/6.x/Program.cs)]

The following code create a `WebApplicationBuilder` with preconfigured defaults, and builds the web app:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  var app = builder.Build();
  ```

`app.MapGet("/", () => "Hello World!");`  maps the `/` endpoint to a method that returns `Hello World!`.

`app.Run();` runs the app.

The preceding code is a complete web app with one endpoint.

### Run the app

# [Visual Studio](#tab/visual-studio)

Press Ctrl+F5 to run without the debugger.

[!INCLUDE[](~/includes/trustCertVS.md)]

  Visual Studio launches:

* The IIS Express web server.
* The default browser and navigates to `https://localhost:<port>/swagger/index.html`, where `<port>` is a randomly chosen port number.

In a browser, navigate to `/`, for example, `https://localhost:5001/`. `Hello World!` is returned.

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/trustCertVSC.md)]

Press Ctrl+F5 to run the app. In a browser, go to following URL: [https://localhost:5001/swagger](https://localhost:5001/swagger)

# [Visual Studio for Mac](#tab/visual-studio-mac)

Select **Run** > **Start Debugging** to launch the app. Visual Studio for Mac launches a browser and navigates to `https://localhost:<port>`, where `<port>` is a randomly chosen port number. 

---

`Hello World!` is displayed in the browser.

## Add NuGet packages

# [Visual Studio](#tab/visual-studio)

* From the **Tools** menu, select **NuGet Package Manager > Manage NuGet Packages for Solution**.
* Select the **Browse** tab, and then enter `Microsoft.EntityFrameworkCore.InMemory` in the search box. Verify **Incluee prerelease** is checked.
* Select `Microsoft.EntityFrameworkCore.InMemory` in the left pane.
* Select the **Project** checkbox in the right pane and then select **Install**.
* Follow the preceding instructions to add the following packages:
  * `Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore`
  * `MinimalValidation`

# [Visual Studio Code](#tab/visual-studio-code)

* Run the following commands:

   ```dotnetcli
   dotnet add package Microsoft.EntityFrameworkCore.InMemory
     ```

# [Visual Studio for Mac](#tab/visual-studio-mac)

Open a command terminal in the project folder and run the following command:

   ```dotnetcli
   dotnet add package Microsoft.EntityFrameworkCore.InMemory
   ```
---

## Add the API code

Replace the contents of the *program.cs* file with the following code:

[!code-csharp[](min-web-api/samples/6.x/todo/Program.cs?name=snippet_all)]

## Install Postman to test the app

This tutorial uses Postman to test the API.

* Install [Postman](https://www.getpostman.com/downloads/)
* Start the web app.
* Start Postman.
* Disable **SSL certificate verification**
  * From **File** > **Settings** (**General** tab), disable **SSL certificate verification**.
    > [!WARNING]
    > Re-enable SSL certificate verification after testing the controller.

<a name="post"></a>

### Test PostTodoItem with Postman

* Create a new request.
* Set the HTTP method to `POST`.
* Set the URI to `https://localhost:<port>/TodoItems`. For example, `https://localhost:5001/TodoItems`.
* Select the **Body** tab.
* Select the **raw** radio button.
* Set the type to **JSON (application/json)**.
* In the request body enter JSON for a to-do item:

    ```json
    {
      "name":"walk dog",
      "isComplete":true
    }
    ```

* Select **Send**.

  `![Postman with create request](min-web-api/_static/3/create.png)`

## Examine the GET methods

Two GET endpoints are implemented:

* `GET /TodoItems`
* `GET /TodoItems/{id}`

Test the app by calling the two endpoints from a browser or Postman. For example:

* `https://localhost:5001/TodoItems`
* `https://localhost:5001/TodoItems/1`

A response similar to the following is produced by the call to `GetTodoItems`:

```json
[
  {
    "id": 1,
    "name": "Item1",
    "isComplete": false
  }
]
```

### Test Get with Postman

* Create a new request.
* Set the HTTP method to **GET**.
* Set the request URI to `https://localhost:<port>/TodoItems`. For example, `https://localhost:5001/TodoItems`.
* Set **Two pane view** in Postman.
* Select **Send**.

This app uses an in-memory database. If the app is stopped and started, the preceding GET request will not return any data. If no data is returned, [POST](#post) data to the app.

## Return values

The return type of the `GetTodoItems` and `GetTodoItem` methods is `MinimalActionEndpointConventionBuilder`. ASP.NET Core automatically serializes the object to [JSON](https://www.json.org/) and writes the JSON into the body of the response message. The response code for this return type is [200 OK](https://developer.mozilla.org/docs/Web/HTTP/Status/200), assuming there are no unhandled exceptions. Unhandled exceptions are translated into 5xx errors.

The return types can represent a wide range of HTTP status codes. For example, `GetTodoItem/{id}` can return two different status values:

* If no item matches the requested ID, the method returns a [404 status](https://developer.mozilla.org/docs/Web/HTTP/Status/404) <xref:Microsoft.AspNetCore.Mvc.ControllerBase.NotFound%2A> error code.
* Otherwise, the method returns 200 with a JSON response body. Returning `item` results in an HTTP 200 response.

## Put methods

Examine the `app.MapPut("/TodoItems/{id}", ...` method:

[!code-csharp[](min-web-api/samples/6.x/todo/Program.cs?name=snippet_put)]

This method is similar to the `MapPost`, except it uses HTTP PUT. The response is [204 (No Content)](https://www.w3.org/Protocols/rfc2616/rfc2616-sec9.html). According to the HTTP specification, a PUT request requires the client to send the entire updated entity, not just the changes. To support partial updates, use [HTTP PATCH](xref:Microsoft.AspNetCore.Mvc.HttpPatchAttribute).

### Test MapPut

This sample uses an in-memory database that must be initialized each time the app is started. There must be an item in the database before you make a PUT call. Call GET to ensure there's an item in the database before making a PUT call.

Update the to-do item that has Id = 1 and set its name to `"feed fish"`:

```json
  {
    "Id":1,
    "name":"feed fish",
    "isComplete":false
  }
```

The following image shows the Postman update:
<!-- 
`![Postman console showing 204 (No Content) response](min-web-api/_static/3/pmcput.png)`

## The DeleteTodoItem method

Examine the `DeleteTodoItem` method:

[!code-csharp[](min-web-api/samples/5.x/TodoApi/Controllers/TodoItemsController.cs?name=snippet_Delete)]

### Test the DeleteTodoItem method

Use Postman to delete a to-do item:

* Set the method to `DELETE`.
* Set the URI of the object to delete (for example `https://localhost:5001/TodoItems/1`).
* Select **Send**.

<a name="over-post-v5"></a>

## Prevent over-posting

Currently the sample app exposes the entire `TodoItem` object. Production apps typically limit the data that's input and returned using a subset of the model. There are multiple reasons behind this and security is a major one. The subset of a model is usually referred to as a Data Transfer Object (DTO), input model, or view model. **DTO** is used in this article.

A DTO may be used to:

* Prevent over-posting.
* Hide properties that clients are not supposed to view.
* Omit some properties in order to reduce payload size.
* Flatten object graphs that contain nested objects. Flattened object graphs can be more convenient for clients.

To demonstrate the DTO approach, update the `TodoItem` class to include a secret field:

[!code-csharp[](min-web-api/samples/5.x/TodoApiDTO/Models/TodoItem.cs?name=snippet&highlight=8)]

The secret field needs to be hidden from this app, but an administrative app could choose to expose it.

Verify you can post and get the secret field.

Create a DTO model:

[!code-csharp[](min-web-api/samples/5.x/TodoApiDTO/Models/TodoItemDTO.cs?name=snippet)]

Update the `TodoItemsController` to use `TodoItemDTO`:

[!code-csharp[](min-web-api/samples/5.x/TodoApiDTO/Controllers/TodoItemsController.cs?name=snippet)]

Verify you can't post or get the secret field.

## Call the web API with JavaScript

See [Tutorial: Call an ASP.NET Core web API with JavaScript](xref:tutorials/web-api-javascript).

-->