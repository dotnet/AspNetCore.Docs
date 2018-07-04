---
title: Get started with NSwag and ASP.NET Core
author: zuckerthoben
description: Learn how to use NSwag to generate documentation and help pages for an ASP.NET Core web API.
ms.author: scaddie
ms.custom: mvc
ms.date: 06/29/2018
uid: tutorials/get-started-with-nswag
---
# Get started with NSwag and ASP.NET Core

By [Christoph Nienaber](https://twitter.com/zuckerthoben) and [Rico Suter](https://rsuter.com)

::: moniker range=">= aspnetcore-2.1"

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/tutorials/web-api-help-pages-using-swagger/samples/2.1/TodoApi.NSwag) ([how to download](xref:tutorials/index#how-to-download-a-sample))

::: moniker-end

::: moniker range="<= aspnetcore-2.0"

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/tutorials/web-api-help-pages-using-swagger/samples/2.0/TodoApi.NSwag) ([how to download](xref:tutorials/index#how-to-download-a-sample))

::: moniker-end

Using [NSwag](https://github.com/RSuter/NSwag) with ASP.NET Core middleware requires the [NSwag.AspNetCore](https://www.nuget.org/packages/NSwag.AspNetCore/) NuGet package. The package consists of a Swagger generator, Swagger UI (v2 and v3), and [ReDoc UI](https://github.com/Rebilly/ReDoc).

It's highly recommended to make use of NSwag's code generation capabilities. Choose one of the following options for code generation:

* Use [NSwagStudio](https://github.com/NSwag/NSwag/wiki/NSwagStudio), a Windows desktop app for generating client code in C# and TypeScript for your API.
* Use the [NSwag.CodeGeneration.CSharp](https://www.nuget.org/packages/NSwag.CodeGeneration.CSharp/) or [NSwag.CodeGeneration.TypeScript](https://www.nuget.org/packages/NSwag.CodeGeneration.TypeScript/) NuGet packages to do code generation inside your project.
* Use NSwag from the [command line](https://github.com/NSwag/NSwag/wiki/CommandLine).
* Use the [NSwag.MSBuild](https://github.com/NSwag/NSwag/wiki/MSBuild) NuGet package.

## Features

The main reason to use NSwag is the ability to not only introduce the Swagger UI and Swagger generator, but to make use of the flexible code generation capabilities. You don't need an existing API&mdash;you can use third-party APIs that incorporate Swagger and let NSwag generate a client implementation. Either way, the development cycle is expedited and you can more easily adapt to API changes.

## Package installation

The NSwag NuGet package can be added with the following approaches:

### [Visual Studio](#tab/visual-studio)

* From the **Package Manager Console** window:
  * Go to **View** > **Other Windows** > **Package Manager Console**
  * Navigate to the directory in which the *TodoApi.csproj* file exists
  * Execute the following command:

    ```powershell
    Install-Package NSwag.AspNetCore
    ```

* From the **Manage NuGet Packages** dialog:
  * Right-click the project in **Solution Explorer** > **Manage NuGet Packages**
  * Set the **Package source** to "nuget.org"
  * Enter "NSwag.AspNetCore" in the search box
  * Select the "NSwag.AspNetCore" package from the **Browse** tab and click **Install**

### [Visual Studio for Mac](#tab/visual-studio-mac)

* Right-click the *Packages* folder in **Solution Pad** > **Add Packages...**
* Set the **Add Packages** window's **Source** drop-down to "nuget.org"
* Enter "NSwag.AspNetCore" in the search box
* Select the "NSwag.AspNetCore" package from the results pane and click **Add Package**

### [Visual Studio Code](#tab/visual-studio-code)

Run the following command from the **Integrated Terminal**:

```console
dotnet add TodoApi.csproj package NSwag.AspNetCore
```

### [.NET Core CLI](#tab/netcore-cli)

Run the following command:

```console
dotnet add TodoApi.csproj package NSwag.AspNetCore
```

---

## Add and configure Swagger middleware

Import the following namespaces in the `Startup` class:

[!code-csharp[](../tutorials/web-api-help-pages-using-swagger/samples/2.0/TodoApi.NSwag/Startup.cs?name=snippet_StartupConfigureImports)]

In the `Startup.Configure` method, enable the middleware for serving the generated Swagger specification and the Swagger UI:

[!code-csharp[](../tutorials/web-api-help-pages-using-swagger/samples/2.0/TodoApi.NSwag/Startup.cs?name=snippet_Configure&highlight=6-10)]

Launch the app. Navigate to `http://localhost:<port>/swagger` to view the Swagger UI. Navigate to `http://localhost:<port>/swagger/v1/swagger.json` to view the Swagger specification.

## Code generation

### Via NSwagStudio

* Install NSwagStudio from the official [GitHub repository](https://github.com/RSuter/NSwag/wiki/NSwagStudio).
* Launch NSwagStudio. Enter the *swagger.json* file URL in the **Swagger Specification URL** textbox, and click the **Create local Copy** button.
* Select the **CSharp Client** client output type. Other options include **TypeScript Client** and **CSharp Web API Controller**. Using a Web API Controller is basically a reverse generation. It uses a specification of a service to rebuild the service.
* Click the **Generate Outputs** button. A complete C# client implementation of the *TodoApi.NSwag* project is produced. Click the **CSharp Client** tab of the **Outputs** section to see the generated client code:

```csharp
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v11.17.3.0 (NJsonSchema v9.10.46.0 (Newtonsoft.Json v9.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

namespace MyNamespace
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NSwag",
        "11.17.3.0 (NJsonSchema v9.10.46.0 (Newtonsoft.Json v9.0.0.0))")]
    public partial class TodoClient
    {
        private string _baseUrl = "http://localhost:50499";
        private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;

        public TodoClient()
        {
            _settings = new System.Lazy
                <Newtonsoft.Json.JsonSerializerSettings>(() =>
            {
                var settings = new Newtonsoft.Json.JsonSerializerSettings();
                UpdateJsonSerializerSettings(settings);
                return settings;
            });
        }

        public string BaseUrl
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }

        // code omitted for brevity
```

> [!TIP]
> The C# client code is generated based on settings defined in the **Settings** tab of the **CSharp Client** tab. Modify the settings to perform tasks such as default namespace renaming and synchronous method generation.

* Copy the generated C# code into a file in a client project (for example, a [Xamarin.Forms](/xamarin/xamarin-forms/) app).
* Start consuming the web API:

```csharp
var todoClient = new TodoClient();

// Gets all to-dos from the API
var allTodos = await todoClient.GetAllAsync();

// Create a new TodoItem, and save it in the API
var createdTodo = await todoClient.CreateAsync(new TodoItem());

// Get a single to-do by ID
var foundTodo = await todoClient.GetByIdAsync(1);
```

> [!NOTE]
> You can inject a base URL and/or a HTTP client into the API client. The best practice is to always [reuse the HttpClient](https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/).

### Other ways to generate client code

You can generate the client code in other ways, more suited to your workflow:

* [MSBuild](https://www.nuget.org/packages/NSwag.MSBuild/)

* [In code](https://github.com/NSwag/NSwag/wiki/SwaggerToCSharpClientGenerator)

* [T4 templates](https://github.com/NSwag/NSwag/wiki/T4)

## Customize

Swagger provides options for documenting the object model to ease consumption of the web API.

### API info and description

In the `Startup.Configure` method, a configuration action passed to the `UseSwagger` method adds information such as the author, license, and description:

[!code-csharp[](../tutorials/web-api-help-pages-using-swagger/samples/2.0/TodoApi.NSwag/Startup2.cs?name=snippet_UseSwagger)]

The Swagger UI displays the version's information:

![Swagger UI with version information](web-api-help-pages-using-swagger/_static/custom-info-nswag.png)

### XML comments

XML comments are enabled with the following approaches:

# [Visual Studio](#tab/visual-studio-xml/)

::: moniker range=">= aspnetcore-2.0"

* Right-click the project in **Solution Explorer** and select **Edit <project_name>.csproj**.
* Manually add the highlighted lines to the *.csproj* file:

[!code-xml[](../tutorials/web-api-help-pages-using-swagger/samples/2.1/TodoApi.NSwag/TodoApi.csproj?name=snippet_DocumentationFileElement&highlight=1-2,4)]

::: moniker-end

::: moniker range="<= aspnetcore-1.1"

* Right-click the project in **Solution Explorer** and select **Properties**
* Check the **XML documentation file** box under the **Output** section of the **Build** tab

::: moniker-end

# [Visual Studio for Mac](#tab/visual-studio-mac-xml/)

::: moniker range=">= aspnetcore-2.0"

* From the *Solution Pad*, press **control** and click the project name. Navigate to **Tools** > **Edit File**.
* Manually add the highlighted lines to the *.csproj* file:

[!code-xml[](../tutorials/web-api-help-pages-using-swagger/samples/2.1/TodoApi.NSwag/TodoApi.csproj?name=snippet_DocumentationFileElement&highlight=1-2,4)]

::: moniker-end

::: moniker range="<= aspnetcore-1.1"

* Open the **Project Options** dialog > **Build** > **Compiler**
* Check the **Generate xml documentation** box under the **General Options** section

::: moniker-end

# [Visual Studio Code](#tab/visual-studio-code-xml/)

Manually add the highlighted lines to the *.csproj* file:

::: moniker range=">= aspnetcore-2.0"

[!code-xml[](../tutorials/web-api-help-pages-using-swagger/samples/2.1/TodoApi.NSwag/TodoApi.csproj?name=snippet_DocumentationFileElement&highlight=1-2,4)]

::: moniker-end

::: moniker range="<= aspnetcore-1.1"

[!code-xml[](../tutorials/web-api-help-pages-using-swagger/samples/2.0/TodoApi.NSwag/TodoApi.csproj?name=snippet_DocumentationFileElement&highlight=1-2,4)]

::: moniker-end

---

### Data annotations

::: moniker range="<= aspnetcore-2.0"
NSwag uses [Reflection](/dotnet/csharp/programming-guide/concepts/reflection), and the recommended return type for web API actions is [IActionResult](/dotnet/api/microsoft.aspnetcore.mvc.iactionresult). Consequently, NSwag can't infer what your action is doing and what it returns. Consider the following example:

[!code-csharp[](../tutorials/web-api-help-pages-using-swagger/samples/2.0/TodoApi.NSwag/Controllers/TodoController.cs?name=snippet_CreateAction)]

The preceding action returns `IActionResult`, but inside the action it's returning either [CreatedAtRoute](/dotnet/api/system.web.http.apicontroller.createdatroute) or [BadRequest](/dotnet/api/system.web.http.apicontroller.badrequest). Data annotations are used to tell clients which HTTP status codes this action is known to return. Decorate the action with the following attributes:

[!code-csharp[](../tutorials/web-api-help-pages-using-swagger/samples/2.0/TodoApi.NSwag/Controllers/TodoController.cs?name=snippet_CreateActionAttributes)]
::: moniker-end
::: moniker range=">= aspnetcore-2.1"
NSwag uses [Reflection](/dotnet/csharp/programming-guide/concepts/reflection), and the recommended return type for web API actions is [ActionResult\<T>](/dotnet/api/microsoft.aspnetcore.mvc.actionresult-1). Consequently, NSwag can only infer the return type defined by `T`. Other possible return types in the action cannot be inferred. Consider the following example:

[!code-csharp[](../tutorials/web-api-help-pages-using-swagger/samples/2.1/TodoApi.NSwag/Controllers/TodoController.cs?name=snippet_CreateAction)]

The preceding action returns `ActionResult<T>`, but inside the action it's returning either [CreatedAtRoute](/dotnet/api/system.web.http.apicontroller.createdatroute). Since the controller is decorated with the [[ApiController]](/dotnet/api/microsoft.aspnetcore.mvc.apicontrollerattribute) attribute, a [BadRequest](/dotnet/api/system.web.http.apicontroller.badrequest) response is possible too. See [Automatic HTTP 400 responses](xref:web-api/index#automatic-http-400-responses) for more info. Data annotations are used to tell clients which HTTP status codes this action is known to return. Decorate the action with the following attributes:

[!code-csharp[](../tutorials/web-api-help-pages-using-swagger/samples/2.1/TodoApi.NSwag/Controllers/TodoController.cs?name=snippet_CreateActionAttributes)]
::: moniker-end

The Swagger generator can now accurately describe this action, and generated clients know what they receive when calling the endpoint. Decorating all actions with these attributes is highly recommended. For guidelines on what HTTP responses your API actions should return, see the [RFC 7231 specification](https://tools.ietf.org/html/rfc7231#section-4.3).
