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

---

### Examine the code

The `Program.cs` file contains the following code:

:::code language="csharp" source="~/tutorials/min-web-api/samples/7.x/todo/Program.cs" id="snippet_min":::

The preceding code:

* Creates a <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> and a <xref:Microsoft.AspNetCore.Builder.WebApplication> with preconfigured defaults.
* Creates an HTTP GET endpoint `/` that returns `Hello World!`:

### Run the app

# [Visual Studio](#tab/visual-studio)

Press Ctrl+F5 to run without the debugger.

[!INCLUDE[](~/includes/trustCertVS22.md)]

Visual Studio launches the [Kestrel web server](xref:fundamentals/servers/kestrel) and opens a browser window.

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/trustCertVSC.md)]

Press Ctrl+F5 to run the app. A browser window is opened.

---

`Hello World!` is displayed in the browser. The `Program.cs` file contains a minimal but complete app.

## Add NuGet packages

NuGet packages must be added to support the database and diagnostics used in this tutorial.

# [Visual Studio](#tab/visual-studio)

* From the **Tools** menu, select **NuGet Package Manager > Manage NuGet Packages for Solution**.
* Select the **Browse** tab.
* Enter **Microsoft.EntityFrameworkCore.InMemory** in the search box, and then select `Microsoft.EntityFrameworkCore.InMemory`.
* Select the **Project** checkbox in the right pane.
* In the **Version** drop down select the latest version 7 available, for example `7.0.17`, and then select **Install**. 
* Follow the preceding instructions to add the `Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore` package with the latest version 7 available.

# [Visual Studio Code](#tab/visual-studio-code)

* Run the following commands:

   ```dotnetcli
   dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 7.0.17
   dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore --version 7.0.17
   ```

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

## Create API testing UI with Swagger

There are many available web API testing tools to choose from, and you can follow this tutorial's introductory API test steps with your own preferred tool.

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

### Configure Swagger middleware

* Add the following highlighted code before `app` is defined in line `var app = builder.Build();`

  [!code-csharp[](~/tutorials/min-web-api/samples/7.x/todo_SwaggerVersion/Program.cs?name=snippet_swagger_add_service&highlight=7-13)]

In the previous code:

  * `builder.Services.AddEndpointsApiExplorer();`: Enables the API Explorer, which is a service that provides metadata about the HTTP API. The API Explorer is used by Swagger to generate the Swagger document.
  * `builder.Services.AddOpenApiDocument(config => {...});`: Adds the Swagger OpenAPI document generator to the application services and configures it to provide more information about the API, such as its title and version. For information on providing more robust API details, see <xref:tutorials/get-started-with-nswag#customize-api-documentation>

* Add the following highlighted code to the next line after `app` is defined in line `var app = builder.Build();`

  [!code-csharp[](~/tutorials/min-web-api/samples/7.x/todo_SwaggerVersion/Program.cs?name=snippet_swagger_enable_middleware&highlight=2-12)]

  The previous code enables the Swagger middleware for serving the generated JSON document and the Swagger UI. Swagger is only enabled in a development environment. Enabling Swagger in a production environment could expose potentially sensitive details about the API's structure and implementation.

<a name="post"></a>

## Test posting data

The following code in `Program.cs` creates an HTTP POST endpoint `/todoitems` that adds data to the in-memory database:

[!code-csharp[](~/tutorials/min-web-api/samples/7.x/todo/Program.cs?name=snippet_post)]

Run the app. The browser displays a 404 error because there's no longer a `/` endpoint.

The POST endpoint will be used to add data to the app.

* With the app still running, in the browser, navigate to `https://localhost:<port>/swagger` to display the API testing page generated by Swagger.

  ![Swagger generated API testing page](~/tutorials/min-web-api/_static/8.x/swagger.png)

* On the Swagger API testing page, select **Post /todoitems** > **Try it out**.
* Note that the **Request body** field contains a generated example format reflecting the parameters for the API.
* In the request body enter JSON for a to-do item, without specifying the optional `id`:

  ```json
  {
    "name":"walk dog",
    "isComplete":true
  }
  ```

* Select **Execute**.

  ![Swagger with Post](~/tutorials/min-web-api/_static/8.x/swagger-post-1.png)

Swagger provides a **Responses** pane below the **Execute** button. 

  ![Swagger with Post response](~/tutorials/min-web-api/_static/8.x/swagger-post-responses.png)

Note a few of the useful details:

* cURL: Swagger provides an example cURL command in Unix/Linux syntax, which can be run at the command line with any bash shell that uses Unix/Linux syntax, including Git Bash from [Git for Windows](https://git-scm.com/downloads).
* Request URL: A simplified representation of the HTTP request made by Swagger UI's JavaScript code for the API call. Actual requests can include details such as headers and query parameters and a request body.
* Server response: Includes the response body and headers. The response body shows the `id` was set to `1`.
* Response Code: A 201 `HTTP` status code was returned, indicating that the request was successfully processed and resulted in the creation of a new resource.
---

## Examine the GET endpoints

The sample app implements several GET endpoints by calling `MapGet`:

|API | Description | Request body | Response body |
|--- | ---- | ---- | ---- |
|`GET /todoitems` | Get all to-do items | None | Array of to-do items|
|`GET /todoitems/complete` | Get all completed to-do items | None | Array of to-do items|
|`GET /todoitems/{id}` | Get an item by ID | None | To-do item|

[!code-csharp[](~/tutorials/min-web-api/samples/7.x/todo/Program.cs?name=snippet_get)]

## Test the GET endpoints

Test the app by calling the endpoints from a browser or Swagger.

* In Swagger select **GET /todoitems** > **Try it out** > **Execute**.

* Alternatively, call **GET /todoitems** from a browser by entering the URI `http://localhost:<port>/todoitems`. For example, `http://localhost:5001/todoitems`

The call to `GET /todoitems` produces a response similar to the following:

```json
[
  {
    "id": 1,
    "name": "walk dog",
    "isComplete": true
  }
]
```

* Call **GET /todoitems/{id}** in Swagger to return data from a specific id:
  * Select **GET /todoitems** > **Try it out**.
  * Set the **id** field to `1` and select **Execute**.

* Alternatively, call **GET /todoitems** from a browser by entering the URI `https://localhost:<port>/todoitems/1`. For example, `https://localhost:5001/todoitems/1`

* The response is similar to the following:

  ```json
  {
    "id": 1,
    "name": "walk dog",
    "isComplete": true
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

Update the to-do item that has `Id = 1` and set its name to `"feed fish"`.

Use Swagger to send a PUT request:

* Select **Put /todoitems/{id}** > **Try it out**.

* Set the **id** field to `1`.

* Set the request body to the following JSON:

  ```json
  {
    "name": "feed fish",
    "isComplete": false
  }
  ```

* Select **Execute**.

## Examine and test the DELETE endpoint

The sample app implements a single DELETE endpoint using `MapDelete`:

[!code-csharp[](~/tutorials/min-web-api/samples/7.x/todo/Program.cs?name=snippet_delete)]

Use Swagger to send a DELETE request:

* Select **DELETE /todoitems/{id}** > **Try it out**.
* Set the **ID** field to `1` and select **Execute**.

  The DELETE request is sent to the app and the response is displayed in the **Responses** pane. The response body is empty, and the **Server response** status code is 204.

## Use the MapGroup API

The sample app code repeats the `todoitems` URL prefix each time it sets up an endpoint. APIs often have groups of endpoints with a common URL prefix, and the <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapGroup%2A> method is available to help organize such groups. It reduces repetitive code and allows for customizing entire groups of endpoints with a single call to methods like <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A> and <xref:Microsoft.AspNetCore.Builder.RoutingEndpointConventionBuilderExtensions.WithMetadata%2A>.

Replace the contents of `Program.cs` with the following code:

:::code language="csharp" source="~/tutorials/min-web-api/samples/7.x/todoGroup_SwaggerVersion/Program.cs" id="snippet_all":::

The preceding code has the following changes:

* Adds `var todoItems = app.MapGroup("/todoitems");` to set up the group using the URL prefix `/todoitems`.
* Changes all the `app.Map<HttpVerb>` methods to `todoItems.Map<HttpVerb>`.
* Removes the URL prefix `/todoitems` from the `Map<HttpVerb>` method calls.

Test the endpoints to verify that they work the same.

## Use the TypedResults API

Returning <xref:Microsoft.AspNetCore.Http.TypedResults> rather than <xref:Microsoft.AspNetCore.Http.Results> has several advantages, including testability and automatically returning the response type metadata for OpenAPI to describe the endpoint. For more information, see [TypedResults vs Results](/aspnet/core/fundamentals/minimal-apis/responses#typedresults-vs-results).

The `Map<HttpVerb>` methods can call route handler methods instead of using lambdas. To see an example, update *Program.cs* with the following code:

# [Visual Studio](#tab/visual-studio)

:::code language="csharp" source="~/tutorials/min-web-api/samples/7.x/todoTypedResults/Program.cs" id="snippet_all":::

# [Visual Studio Code](#tab/visual-studio-code)

:::code language="csharp" source="~/tutorials/min-web-api/samples/7.x/todoTypedResults_SwaggerVersion/Program.cs" id="snippet_all":::

---

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

Currently the sample app exposes the entire `Todo` object. Production apps In production applications, a subset of the model is often used to restrict the data that can be input and returned. There are multiple reasons behind this and security is a major one. The subset of a model is usually referred to as a Data Transfer Object (DTO), input model, or view model. **DTO** is used in this article.

A DTO can be used to:

* Prevent over-posting.
* Hide properties that clients aren't supposed to view.
* Omit some properties to reduce payload size.
* Flatten object graphs that contain nested objects. Flattened object graphs can be more convenient for clients.

To demonstrate the DTO approach, update the `Todo` class to include a secret field:

:::code language="csharp" source="~/tutorials/min-web-api/samples/7.x/todoDTO/Todo.cs":::

The secret field needs to be hidden from this app, but an administrative app could choose to expose it.

Verify you can post and get the secret field.

Create a file named `TodoItemDTO.cs` with the following code:

:::code language="csharp" source="~/tutorials/min-web-api/samples/7.x/todoDTO/TodoItemDTO.cs":::

Replace the contents of the `Program.cs` file with the following code to use this DTO model:

# [Visual Studio](#tab/visual-studio)

:::code language="csharp" source="~/tutorials/min-web-api/samples/6.x/todoDTO/Program.cs" id="snippet_all":::

# [Visual Studio Code](#tab/visual-studio-code)

:::code language="csharp" source="~/tutorials/min-web-api/samples/6.x/todoDTO_SwaggerVersion/Program.cs" id="snippet_all":::

---

Verify you can post and get all fields except the secret field.

<a name="diff-v7"></a>

## Troubleshooting with the completed sample

If you run into a problem you can't resolve, compare your code to the completed project. [View or download completed project](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/min-web-api/samples) ([how to download](xref:index#how-to-download-a-sample)).

## Next steps

* [Configure JSON serialization options](xref:fundamentals/minimal-apis/responses#configure-json-serialization-options).
* Handle errors and exceptions: The [developer exception page](xref:web-api/handle-errors#developer-exception-page) is enabled by default in the development environment for minimal API apps. For information about how to handle errors and exceptions, see [Handle errors in ASP.NET Core APIs](xref:web-api/handle-errors).
* For an example of testing a minimal API app, see [this GitHub sample](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/fundamentals/minimal-apis/samples/MinApiTestsSample).
* [OpenAPI support in minimal APIs](xref:fundamentals/openapi/aspnetcore-openapi).
* [Quickstart: Publish to Azure](/azure/app-service/quickstart-dotnetcore).
* [Organizing ASP.NET Core Minimal APIs](https://www.tessferrandez.com/blog/2023/10/31/organizing-minimal-apis.html).

### Learn more

See <xref:fundamentals/minimal-apis>

:::moniker-end

:::moniker range="= aspnetcore-6.0"

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

[!INCLUDE[](~/includes/net-prereqs-vs-6.0.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-prereqs-vsc-6.0.md)]

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
  * Select **.NET 6.0**
  * Uncheck **Do not use top-level statements**
  * Select **Create**

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

---

### Examine the code

The `Program.cs` file contains the following code:

:::code language="csharp" source="~/tutorials/min-web-api/samples/6.x/todo/Program.cs" id="snippet_min":::

The preceding code:

* Creates a <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> and a <xref:Microsoft.AspNetCore.Builder.WebApplication> with preconfigured defaults.
* Creates an HTTP GET endpoint `/` that returns `Hello World!`:

### Run the app

# [Visual Studio](#tab/visual-studio)

Press Ctrl+F5 to run without the debugger.

[!INCLUDE[](~/includes/trustCertVS22.md)]

Visual Studio launches the [Kestrel web server](xref:fundamentals/servers/kestrel) and opens a browser window.

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/trustCertVSC.md)]

Press Ctrl+F5 to run the app. A browser window is opened.

---

`Hello World!` is displayed in the browser. The `Program.cs` file contains a minimal but complete app.

## Add NuGet packages

NuGet packages must be added to support the database and diagnostics used in this tutorial.

# [Visual Studio](#tab/visual-studio)

* From the **Tools** menu, select **NuGet Package Manager > Manage NuGet Packages for Solution**.
* Select the **Browse** tab.
* Enter **Microsoft.EntityFrameworkCore.InMemory** in the search box, and then select `Microsoft.EntityFrameworkCore.InMemory`.
* Select the **Project** checkbox in the right pane.
* In the **Version** drop down select the latest version 7 available, for example `6.0.28`, and then select **Install**. 
* Follow the preceding instructions to add the `Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore` package with the latest version 7 available.

# [Visual Studio Code](#tab/visual-studio-code)

* Run the following commands:

   ```dotnetcli
   dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 6.0.28
   dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore --version 6.0.28
   ```

---

## The model and database context classes

In the project folder, create a file named `Todo.cs` with the following code:

:::code language="csharp" source="~/tutorials/min-web-api/samples/6.x/todo/Todo.cs":::

The preceding code creates the model for this app. A *model* is a class that represents data that the app manages. 

Create a file named `TodoDb.cs` with the following code:

:::code language="csharp" source="~/tutorials/min-web-api/samples/6.x/todo/TodoDb.cs":::

The preceding code defines the *database context*, which is the main class that coordinates [Entity Framework](/ef/core/) functionality for a data model. This class derives from the <xref:Microsoft.EntityFrameworkCore.DbContext?displayProperty=fullName> class.

## Add the API code

Replace the contents of the `Program.cs` file with the following code:

[!code-csharp[](~/tutorials/min-web-api/samples/6.x/todo/Program.cs?name=snippet_all)]

The following highlighted code adds the database context to the [dependency injection (DI)](xref:fundamentals/dependency-injection) container and enables displaying database-related exceptions:

[!code-csharp[](~/tutorials/min-web-api/samples/6.x/todo/Program.cs?name=snippet_DI&highlight=2-3)]

The DI container provides access to the database context and other services.

## Create API testing UI with Swagger

There are many available web API testing tools to choose from, and you can follow this tutorial's introductory API test steps with your own preferred tool.

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

### Configure Swagger middleware

* In Program.cs add the following `using` statements at the top:

  [!code-csharp[](~/tutorials/min-web-api/samples/6.x/todo_SwaggerVersion/Program.cs?name=snippet_swagger_using_statements)]

* Add the following highlighted code before `app` is defined in line `var app = builder.Build();`

  [!code-csharp[](~/tutorials/min-web-api/samples/6.x/todo_SwaggerVersion/Program.cs?name=snippet_swagger_add_service&highlight=8-14)]

In the previous code:

  * `builder.Services.AddEndpointsApiExplorer();`: Enables the API Explorer, which is a service that provides metadata about the HTTP API. The API Explorer is used by Swagger to generate the Swagger document.
  * `builder.Services.AddOpenApiDocument(config => {...});`: Adds the Swagger OpenAPI document generator to the application services and configures it to provide more information about the API, such as its title and version. For information on providing more robust API details, see <xref:tutorials/get-started-with-nswag#customize-api-documentation>

* Add the following highlighted code to the next line after `app` is defined in line `var app = builder.Build();`

  [!code-csharp[](~/tutorials/min-web-api/samples/6.x/todo_SwaggerVersion/Program.cs?name=snippet_swagger_enable_middleware&highlight=4-14)]

  The previous code enables the Swagger middleware for serving the generated JSON document and the Swagger UI. Swagger is only enabled in a development environment. Enabling Swagger in a production environment could expose potentially sensitive details about the API's structure and implementation.

<a name="post"></a>

## Test posting data

The following code in `Program.cs` creates an HTTP POST endpoint `/todoitems` that adds data to the in-memory database:

[!code-csharp[](~/tutorials/min-web-api/samples/6.x/todo/Program.cs?name=snippet_post)]

Run the app. The browser displays a 404 error because there's no longer a `/` endpoint.

The POST endpoint will be used to add data to the app.

* With the app still running, in the browser, navigate to `https://localhost:<port>/swagger` to display the API testing page generated by Swagger.

  ![Swagger generated API testing page](~/tutorials/min-web-api/_static/8.x/swagger.png)

* On the Swagger API testing page, select **Post /todoitems** > **Try it out**.
* Note that the **Request body** field contains a generated example format reflecting the parameters for the API.
* In the request body enter JSON for a to-do item, without specifying the optional `id`:

  ```json
  {
    "name":"walk dog",
    "isComplete":true
  }
  ```

* Select **Execute**.

  ![Swagger with Post data](~/tutorials/min-web-api/_static/8.x/swagger-post-1.png)

Swagger provides a **Responses** pane below the **Execute** button. 

  ![Swagger with Post resonse pane](~/tutorials/min-web-api/_static/8.x/swagger-post-responses.png)

Note a few of the useful details:

* cURL: Swagger provides an example cURL command in Unix/Linux syntax, which can be run at the command line with any bash shell that uses Unix/Linux syntax, including Git Bash from [Git for Windows](https://git-scm.com/downloads).
* Request URL: A simplified representation of the HTTP request made by Swagger UI's JavaScript code for the API call. Actual requests can include details such as headers and query parameters and a request body.
* Server response: Includes the response body and headers. The response body shows the `id` was set to `1`.
* Response Code: A 201 `HTTP` status code was returned, indicating that the request was successfully processed and resulted in the creation of a new resource.
---

## Examine the GET endpoints

The sample app implements several GET endpoints by calling `MapGet`:

|API | Description | Request body | Response body |
|--- | ---- | ---- | ---- |
|`GET /todoitems` | Get all to-do items | None | Array of to-do items|
|`GET /todoitems/complete` | Get all completed to-do items | None | Array of to-do items|
|`GET /todoitems/{id}` | Get an item by ID | None | To-do item|

[!code-csharp[](~/tutorials/min-web-api/samples/6.x/todo/Program.cs?name=snippet_get)]

## Test the GET endpoints

Test the app by calling the endpoints from a browser or Swagger.

* In Swagger select **GET /todoitems** > **Try it out** > **Execute**.

* Alternatively, call **GET /todoitems** from a browser by entering the URI `http://localhost:<port>/todoitems`. For example, `http://localhost:5001/todoitems`

The call to `GET /todoitems` produces a response similar to the following:

```json
[
  {
    "id": 1,
    "name": "walk dog",
    "isComplete": true
  }
]
```

* Call **GET /todoitems/{id}** in Swagger to return data from a specific id:
  * Select **GET /todoitems** > **Try it out**.
  * Set the **id** field to `1` and select **Execute**.

* Alternatively, call **GET /todoitems** from a browser by entering the URI `https://localhost:<port>/todoitems/1`. For example, For example, `https://localhost:5001/todoitems/1`

* The response is similar to the following:

  ```json
  {
    "id": 1,
    "name": "walk dog",
    "isComplete": true
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

[!code-csharp[](~/tutorials/min-web-api/samples/6.x/todo/Program.cs?name=snippet_put)]

This method is similar to the `MapPost` method, except it uses HTTP PUT. A successful response returns [204 (No Content)](https://www.rfc-editor.org/rfc/rfc9110#status.204). According to the HTTP specification, a PUT request requires the client to send the entire updated entity, not just the changes. To support partial updates, use [HTTP PATCH](xref:Microsoft.AspNetCore.Mvc.HttpPatchAttribute).

## Test the PUT endpoint

This sample uses an in-memory database that must be initialized each time the app is started. There must be an item in the database before you make a PUT call. Call GET to ensure there's an item in the database before making a PUT call.

Update the to-do item that has `Id = 1` and set its name to `"feed fish"`.

Use Swagger to send a PUT request:

* Select **Put /todoitems/{id}** > **Try it out**.

* Set the **id** field to `1`.

* Set the request body to the following JSON:

  ```json
  {
    "name": "feed fish",
    "isComplete": false
  }
  ```

* Select **Execute**.

## Examine and test the DELETE endpoint

The sample app implements a single DELETE endpoint using `MapDelete`:

[!code-csharp[](~/tutorials/min-web-api/samples/6.x/todo/Program.cs?name=snippet_delete)]

Use Swagger to send a DELETE request:

* Select **DELETE /todoitems/{id}** > **Try it out**.
* Set the **ID** field to `1` and select **Execute**.

  The DELETE request is sent to the app and the response is displayed in the **Responses** pane. The response body is empty, and the **Server response** status code is 204.

<a name="over-post-v7"></a>

## Prevent over-posting

Currently the sample app exposes the entire `Todo` object. Production apps In production applications, a subset of the model is often used to restrict the data that can be input and returned. There are multiple reasons behind this and security is a major one. The subset of a model is usually referred to as a Data Transfer Object (DTO), input model, or view model. **DTO** is used in this article.

A DTO can be used to:

* Prevent over-posting.
* Hide properties that clients aren't supposed to view.
* Omit some properties to reduce payload size.
* Flatten object graphs that contain nested objects. Flattened object graphs can be more convenient for clients.

To demonstrate the DTO approach, update the `Todo` class to include a secret field:

:::code language="csharp" source="~/tutorials/min-web-api/samples/6.x/todoDTO_SwaggerVersion/Todo.cs":::

The secret field needs to be hidden from this app, but an administrative app could choose to expose it.

Verify you can post and get the secret field.

Create a file named `TodoItemDTO.cs` with the following code:

:::code language="csharp" source="~/tutorials/min-web-api/samples/6.x/todoDTO_SwaggerVersion/TodoItemDTO.cs":::

Replace the contents of the `Program.cs` file with the following code to use this DTO model:

# [Visual Studio](#tab/visual-studio)

:::code language="csharp" source="~/tutorials/min-web-api/samples/6.x/todoDTO/Program.cs" id="snippet_all":::

# [Visual Studio Code](#tab/visual-studio-code)

:::code language="csharp" source="~/tutorials/min-web-api/samples/6.x/todoDTO_SwaggerVersion/Program.cs" id="snippet_all":::

---

Verify you can post and get all fields except the secret field.

## Test minimal API

For an example of testing a minimal API app, see [this GitHub sample](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/fundamentals/minimal-apis/samples/MinApiTestsSample).

## Publish to Azure

For information on deploying to Azure, see [Quickstart: Deploy an ASP.NET web app](/azure/app-service/quickstart-dotnetcore).

## Additional resources

* <xref:fundamentals/minimal-apis>

:::moniker-end
