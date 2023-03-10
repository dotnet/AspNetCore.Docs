---
title: Get started with Swashbuckle and ASP.NET Core
author: zuckerthoben
description: Learn how to add Swashbuckle to your ASP.NET Core web API project to integrate the Swagger UI.
monikerRange: '>= aspnetcore-3.1'
ms.author: scaddie
ms.custom: mvc
ms.date: 11/09/2021
uid: tutorials/get-started-with-swashbuckle
---
# Get started with Swashbuckle and ASP.NET Core

:::moniker range=">= aspnetcore-6.0"

There are three main components to Swashbuckle:

* [Swashbuckle.AspNetCore.Swagger](https://www.nuget.org/packages/Swashbuckle.AspNetCore.Swagger/): a Swagger object model and middleware to expose `SwaggerDocument` objects as JSON endpoints.

* [Swashbuckle.AspNetCore.SwaggerGen](https://www.nuget.org/packages/Swashbuckle.AspNetCore.SwaggerGen/): a Swagger generator that builds `SwaggerDocument` objects directly from your routes, controllers, and models. It's typically combined with the Swagger endpoint middleware to automatically expose Swagger JSON.

* [Swashbuckle.AspNetCore.SwaggerUI](https://www.nuget.org/packages/Swashbuckle.AspNetCore.SwaggerUI/): an embedded version of the Swagger UI tool. It interprets Swagger JSON to build a rich, customizable experience for describing the web API functionality. It includes built-in test harnesses for the public methods.

## Package installation

Swashbuckle can be added with the following approaches:

### [Visual Studio](#tab/visual-studio)

* From the **Package Manager Console** window:
  * Go to **View** > **Other Windows** > **Package Manager Console**
  * Navigate to the directory in which the `.csproj` file exists
  * Execute the following command:

    ```powershell
    Install-Package Swashbuckle.AspNetCore -Version 6.2.3
    ```

* From the **Manage NuGet Packages** dialog:
  * Right-click the project in **Solution Explorer** > **Manage NuGet Packages**
  * Set the **Package source** to "nuget.org"
  * Ensure the "Include prerelease" option is enabled
  * Enter "Swashbuckle.AspNetCore" in the search box
  * Select the latest "Swashbuckle.AspNetCore" package from the **Browse** tab and click **Install**

### [Visual Studio for Mac](#tab/visual-studio-mac)

* Right-click the *Packages* folder in **Solution Pad** > **Add Packages...**
* Set the **Add Packages** window's **Source** drop-down to "nuget.org"
* Ensure the "Show pre-release packages" option is enabled
* Enter "Swashbuckle.AspNetCore" in the search box
* Select the latest "Swashbuckle.AspNetCore" package from the results pane and click **Add Package**

### [Visual Studio Code](#tab/visual-studio-code)

Run the following command from the **Integrated Terminal**:

```dotnetcli
dotnet add TodoApi.csproj package Swashbuckle.AspNetCore -v 6.2.3
```

### [.NET Core CLI](#tab/netcore-cli)

Run the following command:

```dotnetcli
dotnet add TodoApi.csproj package Swashbuckle.AspNetCore -v 6.2.3
```

---

## Add and configure Swagger middleware

Add the Swagger generator to the services collection in `Program.cs`:

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/6.x/SwashbuckleSample/Snippets/Program.cs" id="snippet_ServicesDefault" highlight="4":::

The call to <xref:Microsoft.Extensions.DependencyInjection.EndpointMetadataApiExplorerServiceCollectionExtensions.AddEndpointsApiExplorer%2A> shown in the preceding example is required only for [minimal APIs](/aspnet/core/fundamentals/minimal-apis/overview). For more information, see [this StackOverflow post](https://stackoverflow.com/a/71933535).

Enable the middleware for serving the generated JSON document and the Swagger UI, also in `Program.cs`:

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/6.x/SwashbuckleSample/Program.cs" id="snippet_Middleware" highlight="3,4":::

The preceding code adds the Swagger middleware only if the current environment is set to Development. The `UseSwaggerUI` method call enables the [Static File Middleware](xref:fundamentals/static-files).

Launch the app and navigate to `https://localhost:<port>/swagger/v1/swagger.json`. The generated document describing the endpoints appears as shown in [OpenAPI specification (openapi.json)](xref:tutorials/web-api-help-pages-using-swagger#openapi-specification-openapijson).

The Swagger UI can be found at `https://localhost:<port>/swagger`. Explore the API via Swagger UI and incorporate it in other programs.

> [!TIP]
> To serve the Swagger UI at the app's root (`https://localhost:<port>/`), set the `RoutePrefix` property to an empty string:
>
> :::code language="csharp" source="web-api-help-pages-using-swagger/samples/6.x/SwashbuckleSample/Snippets/Program.cs" id="snippet_MiddlewareRoutePrefix" highlight="4":::

If using directories with IIS or a reverse proxy, set the Swagger endpoint to a relative path using the `./` prefix. For example, `./swagger/v1/swagger.json`. Using `/swagger/v1/swagger.json` instructs the app to look for the JSON file at the true root of the URL (plus the route prefix, if used). For example, use `https://localhost:<port>/<route_prefix>/swagger/v1/swagger.json` instead of `https://localhost:<port>/<virtual_directory>/<route_prefix>/swagger/v1/swagger.json`.

> [!NOTE]
> By default, Swashbuckle generates and exposes Swagger JSON in version 3.0 of the specification&mdash;officially called the OpenAPI Specification. To support backwards compatibility, you can opt into exposing JSON in the 2.0 format instead. This 2.0 format is important for integrations such as Microsoft Power Apps and Microsoft Flow that currently support OpenAPI version 2.0. To opt into the 2.0 format, set the `SerializeAsV2` property in `Program.cs`:
>
> :::code language="csharp" source="web-api-help-pages-using-swagger/samples/6.x/SwashbuckleSample/Snippets/Program.cs" id="snippet_MiddlewareJsonV2" highlight="3":::

## Customize and extend

Swagger provides options for documenting the object model and customizing the UI to match your theme.

### API info and description

The configuration action passed to the `AddSwaggerGen` method adds information such as the author, license, and description.

In `Program.cs`, import the following namespace to use the `OpenApiInfo` class:

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/6.x/SwashbuckleSample/Program.cs" id="snippet_UsingOpenApiModels":::

Using the `OpenApiInfo` class, modify the information displayed in the UI:

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/6.x/SwashbuckleSample/Snippets/Program.cs" id="snippet_ServicesOpenApiInfo" highlight="3-19":::

The Swagger UI displays the version's information:

:::image source="web-api-help-pages-using-swagger/_static/v6-swagger-info.png" alt-text="Swagger UI with version information: description, author, and license.":::

### XML comments

XML comments can be enabled with the following approaches:

#### [Visual Studio](#tab/visual-studio)

* Right-click the project in **Solution Explorer** and select *`Edit <project_name>.csproj`*.
* Add [GenerateDocumentationFile](/dotnet/core/project-sdk/msbuild-props#generatedocumentationfile)  to the `.csproj` file:

```XML
<PropertyGroup>
  <GenerateDocumentationFile>true</GenerateDocumentationFile>
</PropertyGroup>
```

#### [Visual Studio for Mac](#tab/visual-studio-mac)

* From the *Solution Pad*, press **control** and click the project name. Navigate to **Tools** > **Edit File**.
* Add [GenerateDocumentationFile](/dotnet/core/project-sdk/msbuild-props#generatedocumentationfile)  to the `.csproj` file:

```XML
<PropertyGroup>
  <GenerateDocumentationFile>true</GenerateDocumentationFile>
</PropertyGroup>
```

#### [Visual Studio Code](#tab/visual-studio-code)

Add [GenerateDocumentationFile](/dotnet/core/project-sdk/msbuild-props#generatedocumentationfile)  to the `.csproj` file:

```XML
<PropertyGroup>
  <GenerateDocumentationFile>true</GenerateDocumentationFile>
</PropertyGroup>
```

#### [.NET Core CLI](#tab/netcore-cli)

Add [GenerateDocumentationFile](/dotnet/core/project-sdk/msbuild-props#generatedocumentationfile)  to the `.csproj` file:

```XML
<PropertyGroup>
  <GenerateDocumentationFile>true</GenerateDocumentationFile>
</PropertyGroup>
```

---

Enabling XML comments provides debug information for undocumented public types and members. Undocumented types and members are indicated by the warning message. For example, the following message indicates a violation of warning code 1591:

```text
warning CS1591: Missing XML comment for publicly visible type or member 'TodoController'
```

To suppress warnings project-wide, define a semicolon-delimited list of warning codes to ignore in the project file. Appending the warning codes to `$(NoWarn);` applies the [C# default values](https://github.com/dotnet/sdk/blob/2eb6c546931b5bcb92cd3128b93932a980553ea1/src/Tasks/Microsoft.NET.Build.Tasks/targets/Microsoft.NET.Sdk.CSharp.props#L16) too.

:::code language="xml" source="web-api-help-pages-using-swagger/samples/6.x/SwashbuckleSample/SwashbuckleSample.csproj" range="9-12" highlight="3":::

To suppress warnings only for specific members, enclose the code in [#pragma warning](/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-pragma-warning) preprocessor directives. This approach is useful for code that shouldn't be exposed via the API docs. In the following example, warning code CS1591 is ignored for the entire `TodoContext` class. Enforcement of the warning code is restored at the close of the class definition. Specify multiple warning codes with a comma-delimited list.

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/6.x/SwashbuckleSample/Models/TodoContext.cs" id="snippet_PragmaWarningDisable" highlight="3,10":::

Configure Swagger to use the XML file that's generated with the preceding instructions. For Linux or non-Windows operating systems, file names and paths can be case-sensitive. For example, a `TodoApi.XML` file is valid on Windows but not CentOS.

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/6.x/SwashbuckleSample/Program.cs" id="snippet_Services" highlight="22-23":::

In the preceding code, [Reflection](/dotnet/csharp/programming-guide/concepts/reflection) is used to build an XML file name matching that of the web API project. The [AppContext.BaseDirectory](xref:System.AppContext.BaseDirectory%2A) property is used to construct a path to the XML file. Some Swagger features (for example, schemata of input parameters or HTTP methods and response codes from the respective attributes) work without the use of an XML documentation file. For most features, namely method summaries and the descriptions of parameters and response codes, the use of an XML file is mandatory.

Adding triple-slash comments to an action enhances the Swagger UI by adding the description to the section header. Add a [\<summary>](/dotnet/csharp/programming-guide/xmldoc/summary) element above the `Delete` action:

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/6.x/SwashbuckleSample/Controllers/TodoController.cs" id="snippet_Delete" highlight="1-3":::

The Swagger UI displays the inner text of the preceding code's `<summary>` element:

:::image source="web-api-help-pages-using-swagger/_static/v6-swagger-delete-summary.png" alt-text="Swagger UI showing XML comment 'Deletes a specific TodoItem.' for the DELETE method.":::

The UI is driven by the generated JSON schema:

:::code language="json" source="web-api-help-pages-using-swagger/_static/v6-swagger-delete.json" range="2-24":::

Add a [\<remarks>](/dotnet/csharp/programming-guide/xmldoc/remarks) element to the `Create` action method documentation. It supplements information specified in the `<summary>` element and provides a more robust Swagger UI. The `<remarks>` element content can consist of text, JSON, or XML.

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/6.x/SwashbuckleSample/Controllers/TodoController.cs" id="snippet_Create" highlight="6-16":::

Notice the UI enhancements with these additional comments:

:::image source="web-api-help-pages-using-swagger/_static/v6-swagger-post-remarks.png" alt-text="Swagger UI with additional comments shown.":::

### Data annotations

Mark the model with attributes, found in the <xref:System.ComponentModel.DataAnnotations?displayProperty=fullName> namespace, to help drive the Swagger UI components.

Add the `[Required]` attribute to the `Name` property of the `TodoItem` class:

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/6.x/SwashbuckleSample/Models/TodoItem.cs" highlight="10":::

The presence of this attribute changes the UI behavior and alters the underlying JSON schema:

:::code language="json" source="web-api-help-pages-using-swagger/_static/v6-swagger-schemas-todoitem.json" range="2-23" highlight="3-5":::

Add the `[Produces("application/json")]` attribute to the API controller. Its purpose is to declare that the controller's actions support a response content type of *application/json*:

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/6.x/SwashbuckleSample/Controllers/TodoController.cs" id="snippet_ClassDeclaration" highlight="3":::

The **Media type** drop-down selects this content type as the default for the controller's GET actions:

:::image source="web-api-help-pages-using-swagger/_static/v6-swagger-get-media-type.png" alt-text="Swagger UI with default response content type":::

As the usage of data annotations in the web API increases, the UI and API help pages become more descriptive and useful.

### Describe response types

Developers consuming a web API are most concerned with what's returned&mdash;specifically response types and error codes (if not standard). The response types and error codes are denoted in the XML comments and data annotations.

The `Create` action returns an HTTP 201 status code on success. An HTTP 400 status code is returned when the posted request body is null. Without proper documentation in the Swagger UI, the consumer lacks knowledge of these expected outcomes. Fix that problem by adding the highlighted lines in the following example:

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/6.x/SwashbuckleSample/Controllers/TodoController.cs" id="snippet_Create" highlight="17-18,20-21":::

The Swagger UI now clearly documents the expected HTTP response codes:

:::image source="web-api-help-pages-using-swagger/_static/v6-swagger-post-responses.png"  alt-text="Swagger UI showing POST Response Class description 'Returns the newly created Todo item' and '400 - If the item is null' for status code and reason under Response Messages.":::

Conventions can be used as an alternative to explicitly decorating individual actions with `[ProducesResponseType]`. For more information, see <xref:web-api/advanced/conventions>.

To support the `[ProducesResponseType]` decoration, the [Swashbuckle.AspNetCore.Annotations](https://github.com/domaindrivendev/Swashbuckle.AspNetCore/blob/master/README.md#swashbuckleaspnetcoreannotations) package offers extensions to enable and enrich the response, schema, and parameter metadata.

### Customize the UI

The default UI is both functional and presentable. However, API documentation pages should represent your brand or theme. Branding the Swashbuckle components requires adding the resources to serve static files and building the folder structure to host those files.

Enable Static File Middleware:

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/6.x/SwashbuckleSample/Snippets/Program.cs" id="snippet_MiddlewareStaticFiles" highlight="2":::

To inject additional CSS stylesheets, add them to the project's *wwwroot* folder and specify the relative path in the middleware options:

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/6.x/SwashbuckleSample/Snippets/Program.cs" id="snippet_MiddlewareInjectStylesheet" highlight="3":::

## Additional resources

* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/web-api-help-pages-using-swagger/samples/) ([how to download](xref:index#how-to-download-a-sample))
* [Swagger doesn't recognize comments or attributes on records](https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/1920)
* [Improve the developer experience of an API with Swagger documentation](/training/modules/improve-api-developer-experience-with-swagger/)

:::moniker-end

:::moniker range="< aspnetcore-6.0"

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/web-api-help-pages-using-swagger/samples/) ([how to download](xref:index#how-to-download-a-sample))

There are three main components to Swashbuckle:

* [Swashbuckle.AspNetCore.Swagger](https://www.nuget.org/packages/Swashbuckle.AspNetCore.Swagger/): a Swagger object model and middleware to expose `SwaggerDocument` objects as JSON endpoints.

* [Swashbuckle.AspNetCore.SwaggerGen](https://www.nuget.org/packages/Swashbuckle.AspNetCore.SwaggerGen/): a Swagger generator that builds `SwaggerDocument` objects directly from your routes, controllers, and models. It's typically combined with the Swagger endpoint middleware to automatically expose Swagger JSON.

* [Swashbuckle.AspNetCore.SwaggerUI](https://www.nuget.org/packages/Swashbuckle.AspNetCore.SwaggerUI/): an embedded version of the Swagger UI tool. It interprets Swagger JSON to build a rich, customizable experience for describing the web API functionality. It includes built-in test harnesses for the public methods.

## Package installation

Swashbuckle can be added with the following approaches:

### [Visual Studio](#tab/visual-studio)

* From the **Package Manager Console** window:
  * Go to **View** > **Other Windows** > **Package Manager Console**
  * Navigate to the directory in which the `TodoApi.csproj` file exists
  * Execute the following command:

    ```powershell
    Install-Package Swashbuckle.AspNetCore -Version 5.6.3
    ```

* From the **Manage NuGet Packages** dialog:
  * Right-click the project in **Solution Explorer** > **Manage NuGet Packages**
  * Set the **Package source** to "nuget.org"
  * Ensure the "Include prerelease" option is enabled
  * Enter "Swashbuckle.AspNetCore" in the search box
  * Select the latest "Swashbuckle.AspNetCore" package from the **Browse** tab and click **Install**

### [Visual Studio for Mac](#tab/visual-studio-mac)

* Right-click the *Packages* folder in **Solution Pad** > **Add Packages...**
* Set the **Add Packages** window's **Source** drop-down to "nuget.org"
* Ensure the "Show pre-release packages" option is enabled
* Enter "Swashbuckle.AspNetCore" in the search box
* Select the latest "Swashbuckle.AspNetCore" package from the results pane and click **Add Package**

### [Visual Studio Code](#tab/visual-studio-code)

Run the following command from the **Integrated Terminal**:

```dotnetcli
dotnet add TodoApi.csproj package Swashbuckle.AspNetCore -v 5.6.3
```

### [.NET Core CLI](#tab/netcore-cli)

Run the following command:

```dotnetcli
dotnet add TodoApi.csproj package Swashbuckle.AspNetCore -v 5.6.3
```

---

## Add and configure Swagger middleware

Add the Swagger generator to the services collection in the `Startup.ConfigureServices` method:

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/3.x/TodoApi.Swashbuckle/Startup2.cs" id="snippet_ConfigureServices" highlight="8":::

In the `Startup.Configure` method, enable the middleware for serving the generated JSON document and the Swagger UI:

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/3.x/TodoApi.Swashbuckle/Startup2.cs" id="snippet_Configure" highlight="4,7":::

> [!NOTE]
> Swashbuckle relies on MVC's <xref:Microsoft.AspNetCore.Mvc.ApiExplorer> to discover the routes and endpoints. If the project calls <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddMvc%2A>, routes and endpoints are discovered automatically. When calling <xref:Microsoft.Extensions.DependencyInjection.MvcCoreServiceCollectionExtensions.AddMvcCore%2A>, the <xref:Microsoft.Extensions.DependencyInjection.MvcApiExplorerMvcCoreBuilderExtensions.AddApiExplorer%2A> method must be explicitly called. For more information, see [Swashbuckle, ApiExplorer, and Routing](https://github.com/domaindrivendev/Swashbuckle.AspNetCore#swashbuckle-apiexplorer-and-routing).

The preceding `UseSwaggerUI` method call enables the [Static File Middleware](xref:fundamentals/static-files). If targeting .NET Framework or .NET Core 1.x, add the [Microsoft.AspNetCore.StaticFiles](https://www.nuget.org/packages/Microsoft.AspNetCore.StaticFiles/) NuGet package to the project.

Launch the app, and navigate to `http://localhost:<port>/swagger/v1/swagger.json`. The generated document describing the endpoints appears as shown in [OpenAPI specification (openapi.json)](xref:tutorials/web-api-help-pages-using-swagger#openapi-specification-openapijson).

The Swagger UI can be found at `http://localhost:<port>/swagger`. Explore the API via Swagger UI and incorporate it in other programs.

> [!TIP]
> To serve the Swagger UI at the app's root (`http://localhost:<port>/`), set the `RoutePrefix` property to an empty string:
>
> :::code language="csharp" source="web-api-help-pages-using-swagger/samples/2.0/TodoApi.Swashbuckle/Startup3.cs" id="snippet_UseSwaggerUI" highlight="4":::

If using directories with IIS or a reverse proxy, set the Swagger endpoint to a relative path using the `./` prefix. For example, `./swagger/v1/swagger.json`. Using `/swagger/v1/swagger.json` instructs the app to look for the JSON file at the true root of the URL (plus the route prefix, if used). For example, use `http://localhost:<port>/<route_prefix>/swagger/v1/swagger.json` instead of `http://localhost:<port>/<virtual_directory>/<route_prefix>/swagger/v1/swagger.json`.

> [!NOTE]
> By default, Swashbuckle generates and exposes Swagger JSON in version 3.0 of the specification&mdash;officially called the OpenAPI Specification. To support backwards compatibility, you can opt into exposing JSON in the 2.0 format instead. This 2.0 format is important for integrations such as Microsoft Power Apps and Microsoft Flow that currently support OpenAPI version 2.0. To opt into the 2.0 format, set the `SerializeAsV2` property in `Startup.Configure`:
>
> :::code language="csharp" source="web-api-help-pages-using-swagger/samples/3.x/TodoApi.Swashbuckle/Startup3.cs" id="snippet_Configure" highlight="4-7":::

## Customize and extend

Swagger provides options for documenting the object model and customizing the UI to match your theme.

In the `Startup` class, add the following namespaces:

```csharp
using System;
using System.Reflection;
using System.IO;
```

### API info and description

The configuration action passed to the `AddSwaggerGen` method adds information such as the author, license, and description:

In the `Startup` class, import the following namespace to use the `OpenApiInfo` class:

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/2.0/TodoApi.Swashbuckle/Startup2.cs" id="snippet_InfoClassNamespace":::

Using the `OpenApiInfo` class, modify the information displayed in the UI:

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/2.0/TodoApi.Swashbuckle/Startup4.cs" id="snippet_AddSwaggerGen":::

The Swagger UI displays the version's information:

:::image source="web-api-help-pages-using-swagger/_static/custom-info.png" alt-text="Swagger UI with version information: description, author, and see more link.":::

### XML comments

XML comments can be enabled with the following approaches:

#### [Visual Studio](#tab/visual-studio)

* Right-click the project in **Solution Explorer** and select *`Edit <project_name>.csproj`*.
* Manually add the highlighted lines to the `.csproj` file:

:::code language="xml" source="web-api-help-pages-using-swagger/samples/2.1/TodoApi.Swashbuckle/TodoApi.csproj" range="8-11" highlight="1-2,4":::

#### [Visual Studio for Mac](#tab/visual-studio-mac)

* From the *Solution Pad*, press **control** and click the project name. Navigate to **Tools** > **Edit File**.
* Manually add the highlighted lines to the `.csproj` file:

:::code language="xml" source="web-api-help-pages-using-swagger/samples/2.1/TodoApi.Swashbuckle/TodoApi.csproj" range="8-11" highlight="1-2,4":::

#### [Visual Studio Code](#tab/visual-studio-code)

Manually add the highlighted lines to the `.csproj` file:

:::code language="xml" source="web-api-help-pages-using-swagger/samples/2.1/TodoApi.Swashbuckle/TodoApi.csproj" range="8-11" highlight="1-2,4":::

#### [.NET Core CLI](#tab/netcore-cli)

Manually add the highlighted lines to the `.csproj` file:

:::code language="xml" source="web-api-help-pages-using-swagger/samples/2.1/TodoApi.Swashbuckle/TodoApi.csproj" range="8-11" highlight="1-2,4":::

---

Enabling XML comments provides debug information for undocumented public types and members. Undocumented types and members are indicated by the warning message. For example, the following message indicates a violation of warning code 1591:

```text
warning CS1591: Missing XML comment for publicly visible type or member 'TodoController.GetAll()'
```

To suppress warnings project-wide, define a semicolon-delimited list of warning codes to ignore in the project file. Appending the warning codes to `$(NoWarn);` applies the [C# default values](https://github.com/dotnet/sdk/blob/2eb6c546931b5bcb92cd3128b93932a980553ea1/src/Tasks/Microsoft.NET.Build.Tasks/targets/Microsoft.NET.Sdk.CSharp.props#L16) too.

:::code language="xml" source="web-api-help-pages-using-swagger/samples/2.1/TodoApi.Swashbuckle/TodoApi.csproj" range="8-11" highlight="3":::

To suppress warnings only for specific members, enclose the code in [#pragma warning](/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-pragma-warning) preprocessor directives. This approach is useful for code that shouldn't be exposed via the API docs. In the following example, warning code CS1591 is ignored for the entire `Program` class. Enforcement of the warning code is restored at the close of the class definition. Specify multiple warning codes with a comma-delimited list.

```csharp
namespace TodoApi
{
#pragma warning disable CS1591
    public class Program
    {
        public static void Main(string[] args) =>
            BuildWebHost(args).Run();

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
#pragma warning restore CS1591
}
```

Configure Swagger to use the XML file that's generated with the preceding instructions. For Linux or non-Windows operating systems, file names and paths can be case-sensitive. For example, a `TodoApi.XML` file is valid on Windows but not CentOS.

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/3.x/TodoApi.Swashbuckle/Startup.cs" id="snippet_ConfigureServices" highlight="30-32":::

In the preceding code, [Reflection](/dotnet/csharp/programming-guide/concepts/reflection) is used to build an XML file name matching that of the web API project. The [AppContext.BaseDirectory](xref:System.AppContext.BaseDirectory%2A) property is used to construct a path to the XML file. Some Swagger features (for example, schemata of input parameters or HTTP methods and response codes from the respective attributes) work without the use of an XML documentation file. For most features, namely method summaries and the descriptions of parameters and response codes, the use of an XML file is mandatory.

Adding triple-slash comments to an action enhances the Swagger UI by adding the description to the section header. Add a [\<summary>](/dotnet/csharp/programming-guide/xmldoc/summary) element above the `Delete` action:

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/2.0/TodoApi.Swashbuckle/Controllers/TodoController.cs" id="snippet_Delete" highlight="1-3":::

The Swagger UI displays the inner text of the preceding code's `<summary>` element:

:::image source="web-api-help-pages-using-swagger/_static/triple-slash-comments.png" alt-text="Swagger UI showing XML comment 'Deletes a specific TodoItem.' for the DELETE method.":::

The UI is driven by the generated JSON schema:

```json
"delete": {
    "tags": [
        "Todo"
    ],
    "summary": "Deletes a specific TodoItem.",
    "operationId": "ApiTodoByIdDelete",
    "consumes": [],
    "produces": [],
    "parameters": [
        {
            "name": "id",
            "in": "path",
            "description": "",
            "required": true,
            "type": "integer",
            "format": "int64"
        }
    ],
    "responses": {
        "200": {
            "description": "Success"
        }
    }
}
```

Add a [\<remarks>](/dotnet/csharp/programming-guide/xmldoc/remarks) element to the `Create` action method documentation. It supplements information specified in the `<summary>` element and provides a more robust Swagger UI. The `<remarks>` element content can consist of text, JSON, or XML.

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/3.x/TodoApi.Swashbuckle/Controllers/TodoController.cs" id="snippet_Create" highlight="4-14":::

Notice the UI enhancements with these additional comments:

:::image source="web-api-help-pages-using-swagger/_static/xml-comments-extended.png" alt-text="Swagger UI with additional comments shown.":::

### Data annotations

Mark the model with attributes, found in the <xref:System.ComponentModel.DataAnnotations?displayProperty=fullName> namespace, to help drive the Swagger UI components.

Add the `[Required]` attribute to the `Name` property of the `TodoItem` class:

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/2.0/TodoApi.Swashbuckle/Models/TodoItem.cs" highlight="10":::

The presence of this attribute changes the UI behavior and alters the underlying JSON schema:

```json
"definitions": {
    "TodoItem": {
        "required": [
            "name"
        ],
        "type": "object",
        "properties": {
            "id": {
                "format": "int64",
                "type": "integer"
            },
            "name": {
                "type": "string"
            },
            "isComplete": {
                "default": false,
                "type": "boolean"
            }
        }
    }
},
```

Add the `[Produces("application/json")]` attribute to the API controller. Its purpose is to declare that the controller's actions support a response content type of *application/json*:

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/3.x/TodoApi.Swashbuckle/Controllers/TodoController.cs" id="snippet_TodoController" highlight="1":::

The **Response Content Type** drop-down selects this content type as the default for the controller's GET actions:

:::image source="web-api-help-pages-using-swagger/_static/json-response-content-type.png" alt-text="Swagger UI with default response content type.":::

As the usage of data annotations in the web API increases, the UI and API help pages become more descriptive and useful.

### Describe response types

Developers consuming a web API are most concerned with what's returned&mdash;specifically response types and error codes (if not standard). The response types and error codes are denoted in the XML comments and data annotations.

The `Create` action returns an HTTP 201 status code on success. An HTTP 400 status code is returned when the posted request body is null. Without proper documentation in the Swagger UI, the consumer lacks knowledge of these expected outcomes. Fix that problem by adding the highlighted lines in the following example:

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/3.x/TodoApi.Swashbuckle/Controllers/TodoController.cs" id="snippet_Create" highlight="17,18,20,21":::

The Swagger UI now clearly documents the expected HTTP response codes:

:::image source="web-api-help-pages-using-swagger/_static/data-annotations-response-types.png" alt-text="Swagger UI showing POST Response Class description 'Returns the newly created Todo item' and '400 - If the item is null' for status code and reason under Response Messages.":::

In ASP.NET Core 2.2 or later, conventions can be used as an alternative to explicitly decorating individual actions with `[ProducesResponseType]`. For more information, see <xref:web-api/advanced/conventions>.

To support the `[ProducesResponseType]` decoration, the [Swashbuckle.AspNetCore.Annotations](https://github.com/domaindrivendev/Swashbuckle.AspNetCore/blob/master/README.md#swashbuckleaspnetcoreannotations) package offers extensions to enable and enrich the response, schema, and parameter metadata.

### Customize the UI

The default UI is both functional and presentable. However, API documentation pages should represent your brand or theme. Branding the Swashbuckle components requires adding the resources to serve static files and building the folder structure to host those files.

If targeting .NET Framework or .NET Core 1.x, add the [Microsoft.AspNetCore.StaticFiles](https://www.nuget.org/packages/Microsoft.AspNetCore.StaticFiles) NuGet package to the project:

```xml
<PackageReference Include="Microsoft.AspNetCore.StaticFiles" Version="2.0.0" />
```

The preceding NuGet package is already installed if targeting .NET Core 2.x and using the [metapackage](xref:fundamentals/metapackage).

Enable Static File Middleware:

:::code language="csharp" source="web-api-help-pages-using-swagger/samples/3.x/TodoApi.Swashbuckle/Startup.cs" id="snippet_Configure" highlight="3":::

To inject additional CSS stylesheets, add them to the project's *wwwroot* folder and specify the relative path in the middleware options:

```csharp
app.UseSwaggerUI(c =>
{
     c.InjectStylesheet("/swagger-ui/custom.css");
}
```

## Additional resources

* [Improve the developer experience of an API with Swagger documentation](/training/modules/improve-api-developer-experience-with-swagger/)

:::moniker-end
