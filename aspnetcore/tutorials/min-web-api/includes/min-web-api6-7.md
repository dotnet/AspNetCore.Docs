:::moniker range="= aspnetcore-7.0"

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

[!INCLUDE[](~/includes/net-prereqs-vs-7.0.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-prereqs-vsc-7.0.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

[!INCLUDE[](~/includes/net-prereqs-mac-7.0.md)]

---

## Create an API project

# [Visual Studio](#tab/visual-studio)

* Start Visual Studio 2022 and select **Create a new project**.
* In the **Create a new project** dialog:
  * Enter `Empty` in the **Search for templates** search box.
  * Select the **ASP.NET Core Empty** template and select **Next**.

  ![Visual Studio Create a new project](~/tutorials/min-web-api/_static/empty.png)

* Name the project *TodoApi* and select **Next**.
* In the **Additional information** dialog:
  * Select **.NET 7.0**
  * Uncheck **Do not use top-level statements**
  * Select **Create**

  ![Additional information](~/tutorials/min-web-api/_static/add-info7.png)

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
  * **Target framework:** .NET 7.0 (or later)
  * **Configure for HTTPS**: Check
  * **Do not use top-level statements**: Uncheck
  * Select **Continue**.

  ![Additional information](~/tutorials/min-web-api/_static/add-info7-vsmac-2022.png)

* Enter the following:
  * **Project name:** TodoApi
  * **Solution name:** TodoApi
  * Select **Create**.

---

### Examine the code

The `Program.cs` file contains the following code:

:::code language="csharp" source="~/tutorials/min-web-api/samples/7.x/todo/Program.cs" id="snippet_min":::

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
* Enter **Microsoft.EntityFrameworkCore.InMemory** in the search box, and then select `Microsoft.EntityFrameworkCore.InMemory`.
* Select the **Project** checkbox in the right pane and then select **Install**.
* Follow the preceding instructions to add the `Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore` package.

# [Visual Studio Code](#tab/visual-studio-code)

* Run the following commands:

   ```dotnetcli
   dotnet add package Microsoft.EntityFrameworkCore.InMemory
   dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
     ```

# [Visual Studio for Mac](#tab/visual-studio-mac)

* In the Visual Studio for Mac 2022 toolbar, select **Project** > **Manage NuGet Packages...**.
* In the search box, enter **Microsoft.EntityFrameworkCore.InMemory**.
* In the results window, check `Microsoft.EntityFrameworkCore.InMemory`.
* Select **Add Package**.
* In the **Select Projects** window, select **Ok**.
* In the **License Agreement** window, select **Agree**.
* Follow the preceding instructions to add the `Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore` package.

---

## The model and database context classes

In the project folder, create a file named `Todo.cs` with the following code:

:::code language="csharp" source="~/tutorials/min-web-api/samples/7.x/todoGroup/Todo.cs":::

The preceding code creates the model for this app. A *model* is a class that represents data that the app manages. 

Create a file named `TodoDb.cs` with the following code:

:::code language="csharp" source="~/tutorials/min-web-api/samples/7.x/todoGroup/TodoDb.cs":::

The preceding code defines the *database context*, which is the main class that coordinates [Entity Framework](/ef/core/) functionality for a data model. This class derives from the <xref:Microsoft.EntityFrameworkCore.DbContext?displayProperty=fullName> class.

## Add the API code

Replace the contents of the `Program.cs` file with the following code:

[!code-csharp[](~/tutorials/min-web-api/samples/7.x/todo/Program.cs?name=snippet_all)]

The following highlighted code adds the database context to the [dependency injection (DI)](xref:fundamentals/dependency-injection) container and enables displaying database-related exceptions:

[!code-csharp[](~/tutorials/min-web-api/samples/7.x/todo/Program.cs?name=snippet_DI&highlight=2-3)]

The DI container provides access to the database context and other services.

## Install Postman to test the app

This tutorial uses Postman to test the API.

* Install [Postman](https://www.getpostman.com/downloads/)
* Start the web app.
* Start Postman.
* Select **Workspaces** > **Create Workspace** and then select **Next**.
* Name the workspace *TodoApi* and select **Create**.
* Select the settings gear icon > **Settings** (**General** tab) and disable **SSL certificate verification**.
    > [!WARNING]
    > Re-enable SSL certificate verification after testing the sample app.

<a name="post"></a>

### Test posting data

The following code in `Program.cs` creates an HTTP POST endpoint `/todoitems` that adds data to the in-memory database:

[!code-csharp[](~/tutorials/min-web-api/samples/7.x/todo/Program.cs?name=snippet_post)]

Run the app. The browser displays a 404 error because there is no longer a `/` endpoint.

Use the POST endpoint to add data to the app:

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

## Examine the GET endpoints

The sample app implements several GET endpoints by calling `MapGet`:

|API | Description | Request body | Response body |
|--- | ---- | ---- | ---- |
|`GET /todoitems` | Get all to-do items | None | Array of to-do items|
|`GET /todoitems/complete` | Get all completed to-do items | None | Array of to-do items|
|`GET /todoitems/{id}` | Get an item by ID | None | To-do item|

[!code-csharp[](~/tutorials/min-web-api/samples/7.x/todo/Program.cs?name=snippet_get)]

## Test the GET endpoints

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

This app uses an in-memory database. If the app is restarted, the GET request doesn't return any data. If no data is returned, [POST](#post) data to the app and try the GET request again.

## Return values

ASP.NET Core automatically serializes the object to [JSON](https://www.json.org) and writes the JSON into the body of the response message. The response code for this return type is [200 OK](https://developer.mozilla.org/docs/Web/HTTP/Status/200), assuming there are no unhandled exceptions. Unhandled exceptions are translated into 5xx errors.

The return types can represent a wide range of HTTP status codes. For example, `GET /todoitems/{id}` can return two different status values:

* If no item matches the requested ID, the method returns a [404 status](https://developer.mozilla.org/docs/Web/HTTP/Status/404) <xref:Microsoft.AspNetCore.Mvc.ControllerBase.NotFound%2A> error code.
* Otherwise, the method returns 200 with a JSON response body. Returning `item` results in an HTTP 200 response.

## Examine the PUT endpoint

The sample app implements a single PUT endpoint using `MapPut`:

[!code-csharp[](~/tutorials/min-web-api/samples/7.x/todo/Program.cs?name=snippet_put)]

This method is similar to the `MapPost` method, except it uses HTTP PUT. A successful response returns [204 (No Content)](https://www.rfc-editor.org/rfc/rfc9110#status.204). According to the HTTP specification, a PUT request requires the client to send the entire updated entity, not just the changes. To support partial updates, use [HTTP PATCH](xref:Microsoft.AspNetCore.Mvc.HttpPatchAttribute).

## Test the PUT endpoint

This sample uses an in-memory database that must be initialized each time the app is started. There must be an item in the database before you make a PUT call. Call GET to ensure there's an item in the database before making a PUT call.

Update the to-do item that has Id = 1 and set its name to `"feed fish"`:

```json
{
  "id": 1,
  "name": "feed fish",
  "isComplete": false
}
```

<!--
The following image shows the Postman update:
 
`![Postman console showing 204 (No Content) response](~/tutorials/min-web-api/_static/3/pmcput.png)`
-->

## Examine and test the DELETE endpoint

The sample app implements a single DELETE endpoint using `MapDelete`:

[!code-csharp[](~/tutorials/min-web-api/samples/7.x/todo/Program.cs?name=snippet_delete)]

Use Postman to delete a to-do item:

* Set the method to `DELETE`.
* Set the URI of the object to delete (for example `https://localhost:5001/todoitems/1`).
* Select **Send**.

## Use the MapGroup API

The sample app code repeats the `todoitems` URL prefix each time it sets up an endpoint. APIs often have groups of endpoints with a common URL prefix, and the <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapGroup%2A> method is available to help organize such groups. It reduces repetitive code and allows for customizing entire groups of endpoints with a single call to methods like <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A> and <xref:Microsoft.AspNetCore.Builder.RoutingEndpointConventionBuilderExtensions.WithMetadata%2A>.

Replace the contents of `Program.cs` with the following code:

:::code language="csharp" source="~/tutorials/min-web-api/samples/7.x/todoGroup/Program.cs" id="snippet_all":::

The preceding code has the following changes:

* Adds `var todoItems = app.MapGroup("/todoitems");` to set up the group using the URL prefix `/todoitems`.
* Changes all the `app.Map<HttpVerb>` methods to `todoItems.Map<HttpVerb>`.
* Removes the URL prefix `/todoitems` from the `Map<HttpVerb>` method calls.

Test the endpoints to verify that they work the same.

## Use the TypedResults API

Returning <xref:Microsoft.AspNetCore.Http.TypedResults> rather than <xref:Microsoft.AspNetCore.Http.Results> has several advantages, including testability and automatically returning the response type metadata for OpenAPI to describe the endpoint. For more information, see [TypedResults vs Results](/aspnet/core/fundamentals/minimal-apis/responses#typedresults-vs-results).

The `Map<HttpVerb>` methods can call route handler methods instead of using lambdas. To see an example, update *Program.cs* with the following code:

:::code language="csharp" source="~/tutorials/min-web-api/samples/7.x/todoTypedResults/Program.cs" id="snippet_all":::

The `Map<HttpVerb>` code now calls methods instead of lambdas:

:::code language="csharp" source="~/tutorials/min-web-api/samples/7.x/todoTypedResults/Program.cs" id="snippet_group":::

These methods return objects that implement <xref:Microsoft.AspNetCore.Http.IResult> and are defined by <xref:Microsoft.AspNetCore.Http.TypedResults>:

:::code language="csharp" source="~/tutorials/min-web-api/samples/7.x/todoTypedResults/Program.cs" id="snippet_handlers":::

Unit tests can call these methods and test that they return the correct type. For example, if the method is `GetAllTodos`:

:::code language="csharp" source="~/tutorials/min-web-api/samples/7.x/todoTypedResults/Program.cs" id="snippet_getalltodos":::

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

:::code language="csharp" source="~/tutorials/min-web-api/samples/7.x/todoDTO/Todo.cs":::

The secret field needs to be hidden from this app, but an administrative app could choose to expose it.

Verify you can post and get the secret field.

Create a file named `TodoItemDTO.cs` with the following code:

:::code language="csharp" source="~/tutorials/min-web-api/samples/7.x/todoDTO/TodoItemDTO.cs":::

Update the code in `Program.cs` to use this DTO model:

:::code language="csharp" source="~/tutorials/min-web-api/samples/7.x/todoDTO/Program.cs" id="snippet_all":::

Verify you can post and get all fields except the secret field.

<a name="diff-v7"></a>

## Troubleshooting with the completed sample

If you run into a problem you can't resolve, compare your code to the completed project. [View or download completed project](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/min-web-api/samples) ([how to download](xref:index#how-to-download-a-sample)).

## Next steps

### Configure JSON serialization options

For information on how to configure JSON serialization in your Minimal API apps, see [Configure JSON serialization options](xref:fundamentals/minimal-apis/responses#configure-json-serialization-options).

### Handle errors and exceptions

The [developer exception page](xref:web-api/handle-errors#developer-exception-page) is enabled by default in the development environment for minimal API apps. For information about how to handle errors and exceptions, see [Handle errors in ASP.NET Core APIs](xref:web-api/handle-errors).

### Test minimal API apps

For an example of testing a minimal API app, see [this GitHub sample](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/fundamentals/minimal-apis/samples/MinApiTestsSample).

### Use OpenAPI (Swagger)

For information on how to use OpenAPI with minimal API apps, see [OpenAPI support in minimal APIs](xref:fundamentals/minimal-apis/openapi).

### Publish to Azure

For information on how to deploy to Azure, see [Quickstart: Deploy an ASP.NET web app](/azure/app-service/quickstart-dotnetcore).

### Learn more

For more information about minimal API apps, see <xref:fundamentals/minimal-apis>.

:::moniker-end

:::moniker range="= aspnetcore-6.0"

Minimal APIs are architected to create HTTP APIs with minimal dependencies. They are ideal for microservices and apps that want to include only the minimum files, features, and dependencies in ASP.NET Core.

This tutorial teaches the basics of building a minimal API with ASP.NET Core. For a tutorial on creating an API project based on [controllers](xref:web-api/index) that contains more features, see [Create a web API](xref:tutorials/first-web-api). For a comparison, see [Differences between minimal APIs and APIs with controllers](#diff-v6) in this document.

## Overview

This tutorial creates the following API:

|API | Description | Request body | Response body |
|--- | ---- | ---- | ---- |
|`GET /` | Browser test, "Hello World" | None | Hello World!|
|`GET /todoitems` | Get all to-do items | None | Array of to-do items|
|`GET /todoitems/complete` | Get completed to-do items | None | Array of to-do items|
|`GET /todoitems/{id}` | Get an item by ID | None | To-do item|
|`POST /todoitems` | Add a new item | To-do item | To-do item |
|`PUT /todoitems/{id}` | Update an existing item &nbsp; | To-do item | None |
|`DELETE /todoitems/{id}` &nbsp; &nbsp; | Delete an item &nbsp; &nbsp; | None | None|

## Prerequisites

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-prereqs-vs-6.0.md)]

![VS22 installer workloads](~/tutorials/min-web-api/_static/asp-net-web-dev.png)

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-prereqs-vsc-6.0.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

[!INCLUDE[](~/includes/net-prereqs-mac-6.0.md)]

---

## Create a API project

# [Visual Studio](#tab/visual-studio)

* Start Visual Studio 2022 and select **Create a new project**.
* In the **Create a new project** dialog:
  * Enter `API` in the **Search for templates** search box.
  * Select the **ASP.NET Core Web API** template and select **Next**.
  ![Visual Studio Create a new project](~/tutorials/min-web-api/_static/create-web-api.png)
* Name the project *TodoApi* and select **Next**.
* In the **Additional information** dialog:

  * Select **.NET 6.0 (Long-term support)**
  * Remove **Use controllers (uncheck to use minimal APIs)**
  * Select **Create**

 ![Additional information](~/tutorials/min-web-api/_static/add-info2.png)

<!-- 
![VS new project dialog](~/tutorials/min-web-api/_static/5/vs.png)
-->

<!-- Move this later since we don't need it now -->
# [Visual Studio Code](#tab/visual-studio-code)

* Open the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).
* Change directories (`cd`) to the folder that will contain the project folder.
* Run the following commands:

   ```dotnetcli
   dotnet new webapi -minimal -o TodoApi
   cd TodoApi
   code -r ../TodoApi
   ```

* When a dialog box asks if you want to trust the authors, select **Yes**.
* When a dialog box asks if you want to add required assets to the project, select **Yes**.

  The preceding command creates a new web minimal API project and opens it in Visual Studio Code.

# [Visual Studio for Mac](#tab/visual-studio-mac)

* Select **File** > **New Project...**.

![macOS New solution](~/tutorials/first-web-api-mac/_static/6/sln.png)

* In Visual Studio for Mac 2022, select **Web and Console** > **App** > **API** > **Next**.

![macOS API template selection](~/tutorials/first-web-api-mac/_static/6/api_template.png)

In the **Configure your new API** dialog, make the following selections:
- **Target framework:** .NET 6.x (or more recent). 
- **Configure for HTTPS**: Check
- **Use Controllers (uncheck to use minimal APIs)**: Uncheck
- **Enable OpenAPI Support**: Check

Select **Next**.

![Configure Your New API Window 1](~/tutorials/first-web-api-mac/_static/6/configure_your_new_api.png)

* In the **Configure our new API** window, enter the following:
- **Project name:** TodoApi
- **Solution name:** TodoApi

Select **Create**.

![Configure Your New API Window 2](~/tutorials/first-web-api-mac/_static/6/configure_your_new_api2.png)

[!INCLUDE[](~/includes/mac-terminal-access.md)]

---

### Examine the code

The `Program.cs` file contains the following code:

[!code-csharp[](~/tutorials/min-web-api/samples/6.x/todo/Program.cs?name=snippet_default)]

The project template creates a `WeatherForecast` API with support for [Swagger](xref:tutorials/web-api-help-pages-using-swagger). Swagger is used to generate useful documentation and help pages for APIs.

The following highlighted code adds support for Swagger:

[!code-csharp[](~/tutorials/min-web-api/samples/6.x/todo/Program.cs?name=snippet_swagger&highlight=5-6,13-14)]

### Run the app

# [Visual Studio](#tab/visual-studio)

<!-- replace all of this with an include -->

Press Ctrl+F5 to run without the debugger.

[!INCLUDE[](~/includes/trustCertVS22.md)]

Visual Studio launches the [Kestrel web server](xref:fundamentals/servers/kestrel).

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/trustCertVSC.md)]

Press Ctrl+F5 to run the app. A browser window is opened. Append `/swagger` to the URL in the browser, for example `https://localhost:7122/swagger`.

# [Visual Studio for Mac](#tab/visual-studio-mac)

Select **Debug** > **Start Debugging** to launch the app. Visual Studio for Mac launches a browser and navigates to `https://localhost:<port>`, where `<port>` is a randomly chosen port number. 


---

The Swagger page `/swagger/index.html` is displayed. Select **`GET > Try it out> Execute`**. The page displays:

* The [Curl](https://curl.haxx.se/) command to test the WeatherForecast API.
* The URL to test the WeatherForecast API.
* The response code, body, and headers.
* A drop down list box with media types and the example value and schema.

Copy and paste the **Request URL** in the browser: `https://localhost:<port>/WeatherForecast`. JSON similar to the following is returned:

```json
[
  {
    "date": "2021-10-19T14:12:50.3079024-10:00",
    "temperatureC": 13,
    "summary": "Bracing",
    "temperatureF": 55
  },
  {
    "date": "2021-10-20T14:12:50.3080559-10:00",
    "temperatureC": -8,
    "summary": "Bracing",
    "temperatureF": 18
  },
  {
    "date": "2021-10-21T14:12:50.3080601-10:00",
    "temperatureC": 12,
    "summary": "Hot",
    "temperatureF": 53
  },
  {
    "date": "2021-10-22T14:12:50.3080603-10:00",
    "temperatureC": 10,
    "summary": "Sweltering",
    "temperatureF": 49
  },
  {
    "date": "2021-10-23T14:12:50.3080604-10:00",
    "temperatureC": 36,
    "summary": "Warm",
    "temperatureF": 96
  }
]
```

## Update the generated code

This tutorial focuses on creating an API, so we'll delete the Swagger code and the `WeatherForecast` code. Replace the contents of the `Program.cs` file with the following:

[!code-csharp[](~/tutorials/min-web-api/samples/6.x/todo/Program.cs?name=snippet_min)]

The following highlighted code creates a <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> and a <xref:Microsoft.AspNetCore.Builder.WebApplication> with preconfigured defaults:

[!code-csharp[](~/tutorials/min-web-api/samples/6.x/todo/Program.cs?name=snippet_min&highlight=1-2)]

The following code creates an HTTP GET endpoint `/` which returns `Hello World!`:

```csharp
app.MapGet("/", () => "Hello World!");
```

`app.Run();` runs the app.

Remove the two `"launchUrl": "swagger",` lines from the `Properties/launchSettings.json` file. When the `launchUrl` isn't specified, the web browser requests the `/` endpoint.

Run the app. `Hello World!` is displayed. The updated `Program.cs` file contains a minimal but complete app.

## Add NuGet packages

NuGet packages must be added to support the database and diagnostics used in this tutorial.

# [Visual Studio](#tab/visual-studio)

* From the **Tools** menu, select **NuGet Package Manager > Manage NuGet Packages for Solution**.
* Enter **Microsoft.EntityFrameworkCore.InMemory** in the search box, and then select `Microsoft.EntityFrameworkCore.InMemory`.
* Select the **Project** checkbox in the right pane and then select **Install**.
* Follow the preceding instructions to add the `Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore` package.

# [Visual Studio Code](#tab/visual-studio-code)

* Run the following commands:

   ```dotnetcli
   dotnet add package Microsoft.EntityFrameworkCore.InMemory
   dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
     ```

# [Visual Studio for Mac](#tab/visual-studio-mac)

* In the Visual Studio for Mac 2022 toolbar, select **Project** > **Manage NuGet Packages...**
* In the search box, enter **Microsoft.EntityFrameworkCore.InMemory** 
* In the results window, check `Microsoft.EntityFrameworkCore.InMemory`.
* Select **Add Package**
* In the **Select Projects** window, select **Ok**
* In the **License Agreement** window, select **Agree**

---

## Add the API code

Replace the contents of the `Program.cs` file with the following code:

[!code-csharp[](~/tutorials/min-web-api/samples/6.x/todo/Program.cs?name=snippet_all)]

## The model and database context classes

The sample app contains the following model:

[!code-csharp[](~/tutorials/min-web-api/samples/6.x/todo/Program.cs?name=snippet_model)]

A *model* is a class that represents data that the app manages. The model for this app is the `Todo` class.

The sample app contains the following database context class:

[!code-csharp[](~/tutorials/min-web-api/samples/6.x/todo/Program.cs?name=snippet_cntx)]

The *database context* is the main class that coordinates [Entity Framework](/ef/core/) functionality for a data model. This class is created by deriving from the <xref:Microsoft.EntityFrameworkCore.DbContext?displayProperty=fullName> class.

The following highlighted code adds the database context to the [dependency injection (DI)](xref:fundamentals/dependency-injection) container and enables displaying database-related exceptions:

[!code-csharp[](~/tutorials/min-web-api/samples/6.x/todo/Program.cs?name=snippet_DI&highlight=2-3)]

The DI container provides access to the database context and other services.

The following code creates an HTTP POST endpoint `/todoitems` to add data to the in-memory database:

[!code-csharp[](~/tutorials/min-web-api/samples/6.x/todo/Program.cs?name=snippet_post)]

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

### Test posting data

The following instructions post data to the app:

  * Create a new HTTP request.
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

## Examine the GET endpoints

The sample app implements several GET endpoints using calls to `MapGet`:

|API | Description | Request body | Response body |
|--- | ---- | ---- | ---- |
|`GET /` | Browser test, "Hello World" | None | `Hello World!`|
|`GET /todoitems` | Get all to-do items | None | Array of to-do items|
|`GET /todoitems/complete` | Get all completed to-do items | None | Array of to-do items|
|`GET /todoitems/{id}` | Get an item by ID | None | To-do item|

[!code-csharp[](~/tutorials/min-web-api/samples/6.x/todo/Program.cs?name=snippet_get)]

## Test the GET endpoints

Test the app by calling the two endpoints from a browser or Postman. For example:

* `GET https://localhost:5001/todoitems`
* `GET https://localhost:5001/todoitems/1`

The call to `GET /todoitems` produces a response similar to the following:

```json
[
  {
    "id": 1,
    "name": "Item1",
    "isComplete": false
  }
]
```

### Test the GET endpoints with Postman

* Create a new HTTP request.
* Set the HTTP method to **GET**.
* Set the request URI to `https://localhost:<port>/todoitems`. For example, `https://localhost:5001/todoitems`.
* Select **Send**.

This app uses an in-memory database. If the app is restarted, the GET request doesn't return any data. If no data is returned, first [POST](#post) data to the app.

## Return values

ASP.NET Core automatically serializes the object to [JSON](https://www.json.org) and writes the JSON into the body of the response message. The response code for this return type is [200 OK](https://developer.mozilla.org/docs/Web/HTTP/Status/200), assuming there are no unhandled exceptions. Unhandled exceptions are translated into 5xx errors.

The return types can represent a wide range of HTTP status codes. For example, `GET /todoitems/{id}` can return two different status values:

* If no item matches the requested ID, the method returns a [404 status](https://developer.mozilla.org/docs/Web/HTTP/Status/404) <xref:Microsoft.AspNetCore.Mvc.ControllerBase.NotFound%2A> error code.
* Otherwise, the method returns 200 with a JSON response body. Returning `item` results in an HTTP 200 response.

## Examine the PUT endpoint

The sample app implements a single PUT endpoint using `MapPut`:

[!code-csharp[](~/tutorials/min-web-api/samples/6.x/todo/Program.cs?name=snippet_put)]

This method is similar to the `MapPost` method, except it uses HTTP PUT. A successful response returns [204 (No Content)](https://www.rfc-editor.org/rfc/rfc9110#status.204). According to the HTTP specification, a PUT request requires the client to send the entire updated entity, not just the changes. To support partial updates, use [HTTP PATCH](xref:Microsoft.AspNetCore.Mvc.HttpPatchAttribute).

### Test the PUT endpoint

This sample uses an in-memory database that must be initialized each time the app is started. There must be an item in the database before you make a PUT call. Call GET to ensure there's an item in the database before making a PUT call.

Update the to-do item that has Id = 1 and set its name to `"feed fish"`:

```json
{
  "id": 1,
  "name": "feed fish",
  "isComplete": false
}
```

<!--
The following image shows the Postman update:
 
`![Postman console showing 204 (No Content) response](~/tutorials/min-web-api/_static/3/pmcput.png)`
-->

## Examine the DELETE endpoint

The sample app implements a single DELETE endpoint using `MapDelete`:

[!code-csharp[](~/tutorials/min-web-api/samples/6.x/todo/Program.cs?name=snippet_delete)]

Use Postman to delete a to-do item:

* Set the method to `DELETE`.
* Set the URI of the object to delete (for example `https://localhost:5001/todoitems/1`).
* Select **Send**.

<a name="over-post-v6"></a>

## Prevent over-posting

Currently the sample app exposes the entire `Todo` object. Production apps typically limit the data that's input and returned using a subset of the model. There are multiple reasons behind this and security is a major one. The subset of a model is usually referred to as a Data Transfer Object (DTO), input model, or view model. **DTO** is used in this article.

A DTO may be used to:

* Prevent over-posting.
* Hide properties that clients are not supposed to view.
* Omit some properties in order to reduce payload size.
* Flatten object graphs that contain nested objects. Flattened object graphs can be more convenient for clients.

To demonstrate the DTO approach, update the `Todo` class to include a secret field:

[!code-csharp[](~/tutorials/min-web-api/samples/6.x/todoDTO/Program.cs?name=snippet_secret&highlight=6)]

The secret field needs to be hidden from this app, but an administrative app could choose to expose it.

Verify you can post and get the secret field.

Create a DTO model:

[!code-csharp[](~/tutorials/min-web-api/samples/6.x/todoDTO/Program.cs?name=snippet_DTO)]

Update the code to use `TodoItemDTO`:

[!code-csharp[](~/tutorials/min-web-api/samples/6.x/todoDTO/Program.cs?name=snippet_all)]

Verify you can't post or get the secret field.

<a name="diff-v6"></a>

## Differences between minimal APIs and APIs with controllers

- No support for filters: For example, no support for  <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter>, <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter>, <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter>, <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter>,  and <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncResourceFilter>.
- No support for model binding, i.e. <xref:Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderProvider>, <xref:Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder>. Support can be added with a custom binding shim.
  - No support for binding from forms. This includes binding <xref:Microsoft.AspNetCore.Http.IFormFile>. We plan to add support for `IFormFile` in the future.
- No built-in support for validation, i.e. <xref:Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidator>
- No support for [application parts](xref:mvc/extensibility/app-parts) or the [application model](xref:mvc/controllers/application-model). There's no way to apply or build your own conventions.
- No built-in view rendering support. We recommend using [Razor Pages](xref:tutorials/razor-pages/razor-pages-start) for rendering views.
- No support for [JsonPatch](https://www.nuget.org/packages/Microsoft.AspNetCore.JsonPatch/)
- No support for [OData](https://www.nuget.org/packages/Microsoft.AspNetCore.OData/)
- No support for [ApiVersioning](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Versioning/). See [this issue](https://github.com/dotnet/aspnet-api-versioning/issues/751) for more details.

## Use JsonOptions

The following code uses <xref:Microsoft.AspNetCore.Http.Json.JsonOptions>:

[!code-csharp[](~/tutorials/min-web-api/samples/6.x/WebMinJson/Program.cs?name=snippet_1)]

The following code uses <xref:System.Text.Json.JsonSerializerOptions>:

[!code-csharp[](~/tutorials/min-web-api/samples/6.x/WebMinJson/Program.cs?name=snippet_2)]

The preceding code uses [web defaults](/dotnet/standard/serialization/system-text-json-configure-options#web-defaults-for-jsonserializeroptions), which converts property names to camel case.

## Troubleshooting with the completed sample

If you run into a problem you can't resolve, compare your code to the completed project. [View or download completed project](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/min-web-api/samples) ([how to download](xref:index#how-to-download-a-sample)).

## Test minimal API

For an example of testing a minimal API app, see [this GitHub sample](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/fundamentals/minimal-apis/samples/MinApiTestsSample).

## Publish to Azure

For information on deploying to Azure, see [Quickstart: Deploy an ASP.NET web app](/azure/app-service/quickstart-dotnetcore).

## Additional resources

* <xref:fundamentals/minimal-apis>

:::moniker-end
