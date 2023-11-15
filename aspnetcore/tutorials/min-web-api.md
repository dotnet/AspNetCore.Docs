---
title: "Tutorial: Create a minimal API with ASP.NET Core"
author: wadepickett
description: Learn how to build a minimal API with ASP.NET Core.
ms.author: wpickett
ms.date: 11/09/2023
ms.custom: engagement-fy24
monikerRange: '>= aspnetcore-6.0'
uid: tutorials/min-web-api
---

# Tutorial: Create a minimal API with ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

<!-- TODO: Remove aspnetcore\tutorials\min-web-api\samples\6.x -->
By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Tom Dykstra](https://github.com/tdykstra)

:::moniker range=">= aspnetcore-8.0"

Minimal APIs are architected to create HTTP APIs with minimal dependencies. They are ideal for microservices and apps that want to include only the minimum files, features, and dependencies in ASP.NET Core.

This tutorial teaches the basics of building a minimal API with ASP.NET Core. Another approach to creating APIs in ASP.NET Core is to use controllers. For help in choosing between minimal APIs and controller-based APIs, see <xref:fundamentals/apis>. For a tutorial on creating an API project based on [controllers](xref:web-api/index) that contains more features, see [Create a web API](xref:tutorials/first-web-api).

## Overview

This tutorial creates the following API:

| API                                    | Description                    | Request body | Response body        |
|----------------------------------------|--------------------------------|--------------|----------------------|
| `GET /todoitems`                       | Get all to-do items            | None         | Array of to-do items |
| `GET /todoitems/complete`              | Get completed to-do items      | None         | Array of to-do items |
| `GET /todoitems/{id}`                  | Get an item by ID              | None         | To-do item           |
| `POST /todoitems`                      | Add a new item                 | To-do item   | To-do item           |
| `PUT /todoitems/{id}`                  | Update an existing item &nbsp; | To-do item   | None                 |
| `DELETE /todoitems/{id}` &nbsp; &nbsp; | Delete an item &nbsp; &nbsp;   | None         | None                 |

## Prerequisites

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-prereqs-vs-8.0.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-prereqs-vsc-8.0.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

[!INCLUDE[](~/includes/net-prereqs-mac-8.0.md)]

---

## Create an API project

# [Visual Studio](#tab/visual-studio)

* Start Visual Studio 2022 Preview and select **Create a new project**.
* In the **Create a new project** dialog:
  * Enter `Empty` in the **Search for templates** search box.
  * Select the **ASP.NET Core Empty** template and select **Next**.

  ![Visual Studio Create a new project](~/tutorials/min-web-api/_static/8.x/create-new-project-empty-vs17.8.0.png)

* Name the project *TodoApi* and select **Next**.
* In the **Additional information** dialog:
  * Select **.NET 8.0 (Long Term Support)**
  * Uncheck **Do not use top-level statements**
  * Select **Create**

  ![Additional information](~/tutorials/min-web-api/_static/8.x/add-info-vs17.9.0.png)

# [Visual Studio Code](#tab/visual-studio-code)

* Open the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).
* Change directories (`cd`) to the folder that will contain the project folder.
* Run the following commands:

  ```dotnetcli
  dotnet new web -o TodoApi
  cd TodoApi
  code -r ../TodoApi
  ```

* When a dialog box asks if you want to trust the authors, select **Yes**.
* When a dialog box asks if you want to add required assets to the project, select **Yes**.

  The preceding commands create a new web minimal API project and open it in Visual Studio Code.

# [Visual Studio for Mac](#tab/visual-studio-mac)

* In Visual Studio for Mac 2022, select **File** > **New Project...**.

* In the **Choose a template for your new project** dialog:
  * Select **Web and Console** > **App** > **Empty**.
  * Select **Continue**.

  ![Visual Studio for Mac Create a new project](~/tutorials/min-web-api/_static/empty-vsmac-2022.png)

* Make the following selections:
  * **Target framework:** .NET 8.0
  * **Configure for HTTPS**: Check
  * **Do not use top-level statements**: Uncheck
  * Select **Continue**.

  ![Additional information](~/tutorials/min-web-api/_static/add-info8-vsmac-2022.png)

* Enter the following:
  * **Project name:** TodoApi
  * **Solution name:** TodoApi
  * Select **Create**.

---

### Examine the code

The `Program.cs` file contains the following code:

:::code language="csharp" source="~/tutorials/min-web-api/samples/8.x/todo/Program.cs" id="snippet_min":::

The preceding code:

* Creates a <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> and a <xref:Microsoft.AspNetCore.Builder.WebApplication> with preconfigured defaults.
* Creates an HTTP GET endpoint `/` that returns `Hello World!`:

### Run the app

# [Visual Studio](#tab/visual-studio)

<!-- replace all of this with an include -->

Press Ctrl+F5 to run without the debugger.

[!INCLUDE[](~/includes/trustCertVS22.md)]

Visual Studio launches the [Kestrel web server](xref:fundamentals/servers/kestrel) and opens a browser window.

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/trustCertVSC.md)]

Press Ctrl+F5 to run the app. A browser window is opened.

# [Visual Studio for Mac](#tab/visual-studio-mac)

Select **Debug** > **Start Debugging** to launch the app. Visual Studio for Mac launches a browser and navigates to `https://localhost:<port>`, where `<port>` is a randomly chosen port number.

---

`Hello World!` is displayed in the browser. The `Program.cs` file contains a minimal but complete app.

## Add NuGet packages

NuGet packages must be added to support the database and diagnostics used in this tutorial.

# [Visual Studio](#tab/visual-studio)

* From the **Tools** menu, select **NuGet Package Manager > Manage NuGet Packages for Solution**.
* Select the **Browse** tab.
* Select **Include prerelease**.  <!--todo: remove this when .NET 8 is released. -->
* Enter **Microsoft.EntityFrameworkCore.InMemory** in the search box, and then select `Microsoft.EntityFrameworkCore.InMemory`.
* Select the **Project** checkbox in the right pane and then select **Install**.
* Follow the preceding instructions to add the `Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore` package.

# [Visual Studio Code](#tab/visual-studio-code)

* Run the following commands:

  ```dotnetcli
  dotnet add package Microsoft.EntityFrameworkCore.InMemory --prerelease
  dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore --prerelease
  ```

# [Visual Studio for Mac](#tab/visual-studio-mac)

* In the Visual Studio for Mac 2022 toolbar, select **Project** > **Manage NuGet Packages...**.
* Select **Include prerelease**.  <!--todo: remove this when .NET 8 is released. -->
* In the search box, enter **Microsoft.EntityFrameworkCore.InMemory**.
* In the results window, check `Microsoft.EntityFrameworkCore.InMemory`.
* Select **Add Package**.
* In the **Select Projects** window, select **Ok**.
* In the **License Agreement** window, select **Agree**.
* Follow the preceding instructions to add the `Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore` package.

---

## The model and database context classes

In the project folder, create a file named `Todo.cs` with the following code:

:::code language="csharp" source="~/tutorials/min-web-api/samples/8.x/todoGroup/Todo.cs":::

The preceding code creates the model for this app. A *model* is a class that represents data that the app manages.

Create a file named `TodoDb.cs` with the following code:

:::code language="csharp" source="~/tutorials/min-web-api/samples/8.x/todoGroup/TodoDb.cs":::

The preceding code defines the *database context*, which is the main class that coordinates [Entity Framework](/ef/core/) functionality for a data model. This class derives from the <xref:Microsoft.EntityFrameworkCore.DbContext?displayProperty=fullName> class.

## Add the API code

Replace the contents of the `Program.cs` file with the following code:

[!code-csharp[](~/tutorials/min-web-api/samples/8.x/todo/Program.cs?name=snippet_all)]

The following highlighted code adds the database context to the [dependency injection (DI)](xref:fundamentals/dependency-injection) container and enables displaying database-related exceptions:

[!code-csharp[](~/tutorials/min-web-api/samples/8.x/todo/Program.cs?name=snippet_DI&highlight=2-3)]

The DI container provides access to the database context and other services.

# [Visual Studio](#tab/visual-studio)

This tutorial uses [Endpoints Explorer and .http files](xref:test/http-files#use-endpoints-explorer) to test the API.

# [Visual Studio Code / Visual Studio for Mac](#tab/visual-studio-code+visual-studio-mac)

This tutorial uses Postman to test the API.

## Install Postman to test the app

* Install [Postman](https://www.getpostman.com/downloads/)
* Start the web app.
* Start Postman.
* Select **Workspaces** > **Create Workspace** and then select **Next**.
* Name the workspace *TodoApi* and select **Create**.
* Select the settings gear icon > **Settings** (**General** tab) and disable **SSL certificate verification**.
    > [!WARNING]
    > Re-enable SSL certificate verification after testing the sample app.

<a name="post"></a>

---

## Test posting data

The following code in `Program.cs` creates an HTTP POST endpoint `/todoitems` that adds data to the in-memory database:

[!code-csharp[](~/tutorials/min-web-api/samples/8.x/todo/Program.cs?name=snippet_post)]

Run the app. The browser displays a 404 error because there is no longer a `/` endpoint.

Use the POST endpoint to add data to the app.

# [Visual Studio](#tab/visual-studio)

* Select **View** > **Other Windows** > **Endpoints Explorer**.
* Right-click the **POST** endpoint and select **Generate request**.

  ![Endpoints Explorer context menu highlighting Generate Request menu item.](~/tutorials/min-web-api/_static/8.x/generate-request-vs17.8.0.png)

  A new file is created in the project folder named `TodoApi.http`, with contents similar to the following example:

  ```
  @TodoApi_HostAddress = https://localhost:7031

  Post {{TodoApi_HostAddress}}/todoitems

  ###
  ```

  * The first line creates a variable that will be used for all of the endpoints.
  * The next line defines a POST request.
  * The triple hashtag (`###`) line is a request delimiter: what comes after it will be for a different request.

* The POST request needs headers and a body. To define those parts of the request, add the following lines immediately after the POST request line:

  ```
  Content-Type: application/json
  
  {
    "name":"walk dog",
    "isComplete":true
  }
  ```
  
  The preceding code adds a Content-Type header and a JSON request body. The TodoApi.http file should now look like the following example, but with your port number:
  
  ```
  @TodoApi_HostAddress = https://localhost:7057
  
  Post {{TodoApi_HostAddress}}/todoitems
  Content-Type: application/json
  
  {
    "name":"walk dog",
    "isComplete":true
  }
  
  ###
  ```

* Run the app.

* Select the **Send request** link that is above the `POST` request line.

  ![.http file window with run link highlighted.](~/tutorials/min-web-api/_static/8.x/http-file-run-button-vs17.8.0.png)

  The POST request is sent to the app and the response is displayed in the **Response** pane.

  ![.http file window with response from the POST request.](~/tutorials/min-web-api/_static/8.x/http-file-window-with-response-vs17.8.0.png)

# [Visual Studio Code / Visual Studio for Mac](#tab/visual-studio-code+visual-studio-mac)

* In Postman, create a new HTTP request by selecting **New** > **HTTP**.
* Set the HTTP method to `POST`.
* Set the URI to `https://localhost:<port>/todoitems`. For example: `https://localhost:5001/todoitems`
* Select the **Body** tab.
* Select **raw**.
* Set the type to **JSON**.
* In the request body enter JSON for a to-do item:

  ```json
  {
    "name":"walk dog",
    "isComplete":true
  }
  ```

* Select **Send**.

  ![Postman with Post request details](~/tutorials/min-web-api/_static/post2.png)

---

## Examine the GET endpoints

The sample app implements several GET endpoints by calling `MapGet`:

|API | Description | Request body | Response body |
|--- | ---- | ---- | ---- |
|`GET /todoitems` | Get all to-do items | None | Array of to-do items|
|`GET /todoitems/complete` | Get all completed to-do items | None | Array of to-do items|
|`GET /todoitems/{id}` | Get an item by ID | None | To-do item|

[!code-csharp[](~/tutorials/min-web-api/samples/8.x/todo/Program.cs?name=snippet_get)]

## Test the GET endpoints

# [Visual Studio](#tab/visual-studio)

Test the app by calling the `GET` endpoints from a browser or by using **Endpoints Explorer**. The following steps are for **Endpoints Explorer**.

* In **Endpoints Explorer**, right-click the first **GET** endpoint, and select **Generate request**.

  The following content is added to the `TodoApi.http` file:

  ```
  Get {{TodoApi_HostAddress}}/todoitems

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
      "isComplete": false
    }
  ]
  ```

* In **Endpoints Explorer**, right-click the third **GET** endpoint and select **Generate request**.
  The following content is added to the `TodoApi.http` file:

  ```
  GET {{TodoApi_HostAddress}}/todoitems/{id}

  ###
  ```

* Replace `{id}` with `1`.

* Select the **Send request** link that is above the new GET request line.

  The GET request is sent to the app and the response is displayed in the **Response** pane.

* The response body is similar to the following JSON:

  ```json
  {
    "id": 1,
    "name": "walk dog",
    "isComplete": false
  }
  ```
  
# [Visual Studio Code / Visual Studio for Mac](#tab/visual-studio-code+visual-studio-mac)

Test the app by calling the endpoints from a browser or Postman. The following steps are for Postman.

* Create a new HTTP request.
* Set the HTTP method to **GET**.
* Set the request URI to `https://localhost:<port>/todoitems`. For example, `https://localhost:5001/todoitems`.
* Select **Send**.

The call to `GET /todoitems` produces a response similar to the following:

```json
[
  {
    "id": 1,
    "name": "walk dog",
    "isComplete": false
  }
]
```

* Set the request URI to `https://localhost:<port>/todoitems/1`. For example, `https://localhost:5001/todoitems/1`.
* Select **Send**.
* The response is similar to the following:

  ```json
  {
    "id": 1,
    "name": "walk dog",
    "isComplete": false
  }
  ```

---

This app uses an in-memory database. If the app is restarted, the GET request doesn't return any data. If no data is returned, [POST](#post) data to the app and try the GET request again.

## Return values

ASP.NET Core automatically serializes the object to [JSON](https://www.json.org) and writes the JSON into the body of the response message. The response code for this return type is [200 OK](https://developer.mozilla.org/docs/Web/HTTP/Status/200), assuming there are no unhandled exceptions. Unhandled exceptions are translated into 5xx errors.

The return types can represent a wide range of HTTP status codes. For example, `GET /todoitems/{id}` can return two different status values:

* If no item matches the requested ID, the method returns a [404 status](https://developer.mozilla.org/docs/Web/HTTP/Status/404) <xref:Microsoft.AspNetCore.Mvc.ControllerBase.NotFound%2A> error code.
* Otherwise, the method returns 200 with a JSON response body. Returning `item` results in an HTTP 200 response.

## Examine the PUT endpoint

The sample app implements a single PUT endpoint using `MapPut`:

[!code-csharp[](~/tutorials/min-web-api/samples/8.x/todo/Program.cs?name=snippet_put)]

This method is similar to the `MapPost` method, except it uses HTTP PUT. A successful response returns [204 (No Content)](https://www.rfc-editor.org/rfc/rfc9110#status.204). According to the HTTP specification, a PUT request requires the client to send the entire updated entity, not just the changes. To support partial updates, use [HTTP PATCH](xref:Microsoft.AspNetCore.Mvc.HttpPatchAttribute).

## Test the PUT endpoint

This sample uses an in-memory database that must be initialized each time the app is started. There must be an item in the database before you make a PUT call. Call GET to ensure there's an item in the database before making a PUT call.

Update the to-do item that has Id = 1 and set its name to `"feed fish"`.

# [Visual Studio](#tab/visual-studio)

* In **Endpoints Explorer**, right-click the **PUT** endpoint, and select **Generate request**.

  The following content is added to the `TodoApi.http` file:

  ```
  Put {{TodoApi_HostAddress}}/todoitems/{id}

  ###
  ```

* In the PUT request line, replace `{id}` with `1`.

* Add the following lines immediately after the PUT request line:

  ```
  Content-Type: application/json

  {
    "id": 1,
    "name": "feed fish",
    "isComplete": false
  }
  ```

  The preceding code adds a Content-Type header and a JSON request body.

* Select the **Send request** link that is above the new GET request line.

  The PUT request is sent to the app and the response is displayed in the **Response** pane. The response body is empty, and the status code is 204.
  
# [Visual Studio Code / Visual Studio for Mac](#tab/visual-studio-code+visual-studio-mac)

Use Postman to send a PUT request:

* Set the method to PUT.
* Set the URI of the object to update (for example `https://localhost:5001/todoitems/1`).
* Set the body to the following JSON:

  ```json
  {
    "id": 1,
    "name": "feed fish",
    "isComplete": false
  }
  ```

* Select **Send**.

---

## Examine and test the DELETE endpoint

The sample app implements a single DELETE endpoint using `MapDelete`:

[!code-csharp[](~/tutorials/min-web-api/samples/8.x/todo/Program.cs?name=snippet_delete)]

# [Visual Studio](#tab/visual-studio)

* In **Endpoints Explorer**, right-click the **DELETE** endpoint and select **Generate request**.

  A DELETE request is added to `TodoApi.http`.

* Replace `{id}` in the DELETE request line with `1`. The DELETE request should look like the following example:

  ```
  DELETE {{TodoApi_HostAddress}}/todoitems/1

  ###
  ```

* Select the **Send request** link for the DELETE request.

  The DELETE request is sent to the app and the response is displayed in the **Response** pane. The response body is empty, and the status code is 204.
  
# [Visual Studio Code / Visual Studio for Mac](#tab/visual-studio-code+visual-studio-mac)

Use Postman to delete a to-do item:

* Set the method to `DELETE`.
* Set the URI of the object to delete (for example `https://localhost:5001/todoitems/1`).
* Select **Send**.

---

## Use the MapGroup API

The sample app code repeats the `todoitems` URL prefix each time it sets up an endpoint. APIs often have groups of endpoints with a common URL prefix, and the <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapGroup%2A> method is available to help organize such groups. It reduces repetitive code and allows for customizing entire groups of endpoints with a single call to methods like <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A> and <xref:Microsoft.AspNetCore.Builder.RoutingEndpointConventionBuilderExtensions.WithMetadata%2A>.

Replace the contents of `Program.cs` with the following code:

:::code language="csharp" source="~/tutorials/min-web-api/samples/8.x/todoGroup/Program.cs" id="snippet_all":::

The preceding code has the following changes:

* Adds `var todoItems = app.MapGroup("/todoitems");` to set up the group using the URL prefix `/todoitems`.
* Changes all the `app.Map<HttpVerb>` methods to `todoItems.Map<HttpVerb>`.
* Removes the URL prefix `/todoitems` from the `Map<HttpVerb>` method calls.

Test the endpoints to verify that they work the same.

## Use the TypedResults API

Returning <xref:Microsoft.AspNetCore.Http.TypedResults> rather than <xref:Microsoft.AspNetCore.Http.Results> has several advantages, including testability and automatically returning the response type metadata for OpenAPI to describe the endpoint. For more information, see [TypedResults vs Results](/aspnet/core/fundamentals/minimal-apis/responses#typedresults-vs-results).

The `Map<HttpVerb>` methods can call route handler methods instead of using lambdas. To see an example, update *Program.cs* with the following code:

:::code language="csharp" source="~/tutorials/min-web-api/samples/8.x/todoTypedResults/Program.cs" id="snippet_all":::

The `Map<HttpVerb>` code now calls methods instead of lambdas:

:::code language="csharp" source="~/tutorials/min-web-api/samples/8.x/todoTypedResults/Program.cs" id="snippet_group":::

These methods return objects that implement <xref:Microsoft.AspNetCore.Http.IResult> and are defined by <xref:Microsoft.AspNetCore.Http.TypedResults>:

:::code language="csharp" source="~/tutorials/min-web-api/samples/8.x/todoTypedResults/Program.cs" id="snippet_handlers":::

Unit tests can call these methods and test that they return the correct type. For example, if the method is `GetAllTodos`:

:::code language="csharp" source="~/tutorials/min-web-api/samples/8.x/todoTypedResults/Program.cs" id="snippet_getalltodos":::

Unit test code can verify that an object of type [Ok\<Todo[]>](xref:Microsoft.AspNetCore.Http.HttpResults.Ok%601.Value) is returned from the handler method. For example:

```csharp
public async Task GetAllTodos_ReturnsOkOfTodosResult()
{
    // Arrange
    var db = CreateDbContext();

    // Act
    var result = await TodosApi.GetAllTodos(db);

    // Assert: Check for the correct returned type
    Assert.IsType<Ok<Todo[]>>(result);
}
```

<a name="over-post-v7"></a>

## Prevent over-posting

Currently the sample app exposes the entire `Todo` object. Production apps typically limit the data that's input and returned using a subset of the model. There are multiple reasons behind this and security is a major one. The subset of a model is usually referred to as a Data Transfer Object (DTO), input model, or view model. **DTO** is used in this article.

A DTO may be used to:

* Prevent over-posting.
* Hide properties that clients are not supposed to view.
* Omit some properties in order to reduce payload size.
* Flatten object graphs that contain nested objects. Flattened object graphs can be more convenient for clients.

To demonstrate the DTO approach, update the `Todo` class to include a secret field:

:::code language="csharp" source="~/tutorials/min-web-api/samples/8.x/todoDTO/Todo.cs":::

The secret field needs to be hidden from this app, but an administrative app could choose to expose it.

Verify you can post and get the secret field.

Create a file named `TodoItemDTO.cs` with the following code:

:::code language="csharp" source="~/tutorials/min-web-api/samples/8.x/todoDTO/TodoItemDTO.cs":::

Update the code in `Program.cs` to use this DTO model:

:::code language="csharp" source="~/tutorials/min-web-api/samples/8.x/todoDTO/Program.cs" id="snippet_all":::

Verify you can post and get all fields except the secret field.

<a name="diff-v7"></a>

## Troubleshooting with the completed sample

If you run into a problem you can't resolve, compare your code to the completed project. [View or download completed project](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/min-web-api/samples) ([how to download](xref:index#how-to-download-a-sample)).

## Next steps

* [Configure JSON serialization options](xref:fundamentals/minimal-apis/responses#configure-json-serialization-options).
* Handle errors and exceptions: The [developer exception page](xref:web-api/handle-errors#developer-exception-page) is enabled by default in the development environment for minimal API apps. For information about how to handle errors and exceptions, see [Handle errors in ASP.NET Core APIs](xref:web-api/handle-errors).
* For an example of testing a minimal API app, see [this GitHub sample](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/fundamentals/minimal-apis/samples/MinApiTestsSample).
* [OpenAPI support in minimal APIs](xref:fundamentals/minimal-apis/openapi).
* [Quickstart: Publish to Azure](/azure/app-service/quickstart-dotnetcore).
* [Organizing ASP.NET Core Minimal APIs](https://www.tessferrandez.com/blog/2023/10/31/organizing-minimal-apis.html)

### Learn more

See <xref:fundamentals/minimal-apis>

:::moniker-end

[!INCLUDE[](~/tutorials/min-web-api/includes/min-web-api6-7.md)]
