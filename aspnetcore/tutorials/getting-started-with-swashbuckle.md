---
title: Getting started with Swashbuckle
author: zuckerthoben
description: This tutorial provides a walkthrough of adding Swashbuckle to your project to integrate the Swagger Ui
keywords: ASP.NET Core,Swagger,Swashbuckle,help pages,Web API
ms.author: spboyer
manager: wpickett
ms.date: 09/01/2017
ms.topic: article
ms.assetid: 54bb961d-29d9-4dee-8e2c-a93fc33c16f2
ms.technology: aspnet
ms.prod: asp.net-core
uid: tutorials/getting-started-with-swashbuckle
---

# Getting Started with Swashbuckle
<a name=getting-started-with-swashbuckle></a>

By [Shayne Boyer](https://twitter.com/spboyer) and [Scott Addie](https://twitter.com/Scott_Addie)

There are three main components to Swashbuckle:

* `Swashbuckle.AspNetCore.Swagger`: a Swagger object model and middleware to expose `SwaggerDocument` objects as JSON endpoints.

* `Swashbuckle.AspNetCore.SwaggerGen`: a Swagger generator that builds `SwaggerDocument` objects directly from your routes, controllers, and models. It's typically combined with the Swagger endpoint middleware to automatically expose Swagger JSON.

* `Swashbuckle.AspNetCore.SwaggerUI`: an embedded version of the Swagger UI tool which interprets Swagger JSON to build a rich, customizable experience for describing the Web API functionality. It includes built-in test harnesses for the public methods.

# Package install via NuGet

Swashbuckle can be added with the following approaches:

# [Visual Studio](#tab/visual-studio)

* From the **Package Manager Console** window:

    ```powershell
    Install-Package Swashbuckle.AspNetCore
    ```

* From the **Manage NuGet Packages** dialog:

     * Right-click your project in **Solution Explorer** > **Manage NuGet Packages**
     * Set the **Package source** to "nuget.org"
     * Enter "Swashbuckle.AspNetCore" in the search box
     * Select the "Swashbuckle.AspNetCore" package from the **Browse** tab and click **Install**

# [Visual Studio for Mac](#tab/visual-studio-mac)

* Right-click the *Packages* folder in **Solution Pad** > **Add Packages...**
* Set the **Add Packages** window's **Source** drop-down to "nuget.org"
* Enter Swashbuckle.AspNetCore in the search box
* Select the Swashbuckle.AspNetCore package from the results pane and click **Add Package**

# [Visual Studio Code](#tab/visual-studio-code)

Run the following command from the **Integrated Terminal**:

```console
dotnet add TodoApi.Swashbuckle.csproj package Swashbuckle.AspNetCore
```

# [.NET Core CLI](#tab/netcore-cli)

Run the following command:

```console
dotnet add TodoApi.Swashbuckle.csproj package Swashbuckle.AspNetCore
```

## Add and configure Swagger to the middleware

Add the Swagger generator to the services collection in the `ConfigureServices` method of *Startup.cs*:

[!code-csharp[Main](../tutorials/web-api-help-pages-using-swagger/sample/TodoApi.Swashbuckle/Startup2.cs?name=snippet_ConfigureServices&highlight=7-10)]

Add the following using statement for the `Info` class:

```csharp
using Swashbuckle.AspNetCore.Swagger;
```

In the `Configure` method of *Startup.cs*, enable the middleware for serving the generated JSON document and the SwaggerUI:

[!code-csharp[Main](../tutorials/web-api-help-pages-using-swagger/sample/TodoApi.Swashbuckle/Startup2.cs?name=snippet_Configure&highlight=4,7-10)]

Launch the app, and navigate to `http://localhost:<random_port>/swagger/v1/swagger.json`. The generated document describing the endpoints appears as shown in the [main article](https://github.com/aspnet/Docs/edit/master/aspnetcore/tutorials/web-api-help-pages-using-swagger.md)

The Swagger Ui can be found at `http://localhost:<random_port>/swagger`. Now you can explore the Api via Swagger Ui and incorporate it in other programs. 

## Customization & Extensibility

Swagger provides options for documenting the object model and customizing the UI to match your theme.

### API Info and Description

The configuration action passed to the `AddSwaggerGen` method can be used to add information such as the author, license, and description:

[!code-csharp[Main](../tutorials/web-api-help-pages-using-swagger/sample/TodoApi.Swashbuckle/Startup.cs?range=20-30,36)]

The following image depicts the Swagger UI displaying the version information:

![Swagger UI with version information: description, author, and see more link](web-api-help-pages-using-swagger/_static/custom-info.png)

### XML Comments

XML comments can be enabled with the following approaches:

# [Visual Studio](#tab/visual-studio)

* Right-click the project in **Solution Explorer** and select **Properties**
* Check the **XML documentation file** box under the **Output** section of the **Build** tab:

![Build tab of project properties](web-api-help-pages-using-swagger/_static/swagger-xml-comments.png)

# [Visual Studio for Mac](#tab/visual-studio-mac)

* Open the **Project Options** dialog > **Build** > **Compiler**
* Check the **Generate xml documentation** box under the **General Options** section:

![General Options section of project options](web-api-help-pages-using-swagger/_static/swagger-xml-comments-mac.png)

# [Visual Studio Code](#tab/visual-studio-code)

Manually add the following snippet to the *.csproj* file:

[!code-xml[Main](../tutorials/web-api-help-pages-using-swagger/sample/TodoApi.Swashbuckle/TodoApi.Swashbuckle.csproj?range=7-9)]

---

Configure Swagger to use the generated XML file. For Linux or non-Windows operating systems, file names and paths can be case sensitive. For example, a *TodoApi.Swashbuckle.XML* file would be found on Windows but not CentOS.

[!code-csharp[Main](../tutorials/web-api-help-pages-using-swagger/sample/TodoApi.Swashbuckle/Startup.cs?name=snippet_ConfigureServices&highlight=20-22)]

In the preceding code, `ApplicationBasePath` gets the base path of the app. The base path is used to locate the XML comments file. *TodoApi.Swashbuckle.xml* only works for this example, since the name of the generated XML comments file is based on the application name.

Adding the triple-slash comments to the method enhances the Swagger UI by adding the description to the section header:

[!code-csharp[Main](../tutorials/web-api-help-pages-using-swagger/sample/TodoApi.Swashbuckle/Controllers/TodoController.cs?name=snippet_Delete&highlight=2)]

![Swagger UI showing XML comment 'Deletes a specific TodoItem.' for the DELETE method](web-api-help-pages-using-swagger/_static/triple-slash-comments.png)

The UI is driven by the generated JSON file, which also contains these comments:

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

Add a [<remarks>](https://docs.microsoft.com/dotnet/csharp/programming-guide/xmldoc/remarks) tag to the `Create` action method documentation. It supplements information specified in the `<summary>` tag and provides a more robust Swagger UI. The `<remarks>` tag content can consist of text, JSON, or XML.

[!code-csharp[Main](../tutorials/web-api-help-pages-using-swagger/sample/TodoApi.Swashbuckle/Controllers/TodoController.cs?name=snippet_Create&highlight=4-14)]

Notice the UI enhancements with these additional comments.

![Swagger UI with additional comments shown](web-api-help-pages-using-swagger/_static/xml-comments-extended.png)

### Data Annotations

Decorate the model with attributes, found in `System.ComponentModel.DataAnnotations`, to help drive the Swagger UI components.

Add the `[Required]` attribute to the `Name` property of the `TodoItem` class:

[!code-csharp[Main](../tutorials/web-api-help-pages-using-swagger/sample/TodoApi.Swashbuckle/Models/TodoItem.cs?highlight=10)]

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

Add the `[Produces("application/json")]` attribute to the API controller. Its purpose is to declare that the controller's actions support a return a content type of *application/json*:

[!code-csharp[Main](../tutorials/web-api-help-pages-using-swagger/sample/TodoApi.Swashbuckle/Controllers/TodoController.cs?name=snippet_TodoController&highlight=3)]

The **Response Content Type** drop-down selects this content type as the default for the controller's GET actions:

![Swagger UI with default response content type](web-api-help-pages-using-swagger/_static/json-response-content-type.png)

As the usage of data annotations in the Web API increases, the UI and API help pages become more descriptive and useful.

### Describing Response Types

Consuming developers are most concerned with what is returned &mdash; specifically response types and error codes (if not standard). These are handled in the XML comments and data annotations.

The `Create` action returns `201 Created` on success or `400 Bad Request` when the posted request body is null. Without proper documentation in the Swagger UI, the consumer lacks knowledge of these expected outcomes. That problem is fixed by adding the highlighted lines in the following example:

[!code-csharp[Main](../tutorials/web-api-help-pages-using-swagger/sample/TodoApi.Swashbuckle/Controllers/TodoController.cs?name=snippet_Create&highlight=17,18,20,21)]

The Swagger UI now clearly documents the expected HTTP response codes:

![Swagger UI showing POST Response Class description 'Returns the newly created Todo item' and '400 - If the item is null' for status code and reason under Response Messages](web-api-help-pages-using-swagger/_static/data-annotations-response-types.png)

### Customizing the UI

The stock UI is both functional and presentable; however, when building documentation pages for your API, you want it to represent your brand or theme. Accomplishing that task with the Swashbuckle components requires adding the resources to serve static files and then building the folder structure to host those files.

If targeting .NET Framework, add the `Microsoft.AspNetCore.StaticFiles` NuGet package to the project:

```xml
<PackageReference Include="Microsoft.AspNetCore.StaticFiles" Version="2.0.0" />
```

Enable the static files middleware:

[!code-csharp[Main](../tutorials/web-api-help-pages-using-swagger/sample/TodoApi.Swashbuckle/Startup.cs?name=snippet_Configure&highlight=3)]

Acquire the contents of the *dist* folder from the [Swagger UI GitHub repository](https://github.com/swagger-api/swagger-ui/tree/2.x/dist). This folder contains the necessary assets for the Swagger UI page.

Create a *wwwroot/swagger/ui* folder, and copy into it the contents of the *dist* folder.

Create a *wwwroot/swagger/ui/css/custom.css* file with the following CSS to customize the page header:

[!code-css[Main](../tutorials/web-api-help-pages-using-swagger/sample/TodoApi.Swashbuckle/wwwroot/swagger/ui/css/custom.css)]

Reference *custom.css* in the *index.html* file:

[!code-html[Main](../tutorials/web-api-help-pages-using-swagger/sample/TodoApi.Swashbuckle/wwwroot/swagger/ui/index.html?range=14)]

Browse to the *index.html* page at `http://localhost:<random_port>/swagger/ui/index.html`. Enter `http://localhost:<random_port>/swagger/v1/swagger.json` in the header's textbox, and click the **Explore** button. The resulting page looks as follows:

![Swagger UI with custom header title](web-api-help-pages-using-swagger/_static/custom-header.png)

There is much more you can do with the page. See the full capabilities for the UI resources at the [Swagger UI GitHub repository](https://github.com/swagger-api/swagger-ui).
