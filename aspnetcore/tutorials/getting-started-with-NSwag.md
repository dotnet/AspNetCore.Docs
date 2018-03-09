---
title: Getting started with NSwag
author: zuckerthoben
description: This tutorial provides a walkthrough of adding Swagger to generate documentation and help pages for a Web API application.
keywords: ASP.NET Core,Swagger,NSwag,help pages,Web API
ms.author: 
manager: 
ms.date:
ms.topic: article
ms.assetid: 
ms.technology: aspnet
ms.prod: asp.net-core
uid: tutorials/getting-started-with-NSwag
---

# Getting Started with NSwag

<a name=getting-started-with-NSwag></a>

By [Christoph Nienaber](https://twitter.com/zuckerthoben) and [Rico Suter](http://rsuter.com)

When using NSwag with ASP.NET Core via middleware there is only one package you need to get started:

* `NSwag.AspNetCore`: The main package, contains the Swagger generator, Swagger UI (v2 and v3) and [ReDoc UI](https://github.com/Rebilly/ReDoc).

It's highly recommended to make use of the code generation capabilities of NSwag. Either by using [NSwagStudio](https://github.com/NSwag/NSwag/wiki/NSwagStudio), an easy to use Windows program to generate client code in C# and TypeScript for your API, or by using `NSwag.CodeGeneration.CSharp` or `NSwag.CodeGeneration.TypeScript` packages to to code generation right inside your project. There is also the possibility to use NSwag via [Command line](https://github.com/NSwag/NSwag/wiki/CommandLine) or via [MSBuild NuGet package](https://github.com/NSwag/NSwag/wiki/MSBuild). 

# Features

The main reason to use NSwag is the ability to not only introduce the Swagger UI and Swagger generator, but also to make use of the flexible code generation capabilities. You don't even have to have an existing API yourself. You can easily use 3rd party APIs that incorporate Swagger and let NSwag generate a client implementation. Either way you can speed up your development and also adjust easier to API changes. 

# Package install via NuGet

NSwag can be added with the following approaches:

# [Visual Studio](#tab/visual-studio)

* From the **Package Manager Console** window:

    ```powershell
    Install-Package NSwag.AspNetCore
    ```

* From the **Manage NuGet Packages** dialog:

     * Right-click your project in **Solution Explorer** > **Manage NuGet Packages**
     * Set the **Package source** to "nuget.org"
     * Enter "NSwag.AspNetCore" in the search box
     * Select the "NSwag.AspNetCore" package from the **Browse** tab and click **Install**

# [Visual Studio for Mac](#tab/visual-studio-mac)

* Right-click the *Packages* folder in **Solution Pad** > **Add Packages...**
* Set the **Add Packages** window's **Source** drop-down to "nuget.org"
* Enter NSwag.AspNetCore in the search box
* Select the NSwag.AspNetCore package from the results pane and click **Add Package**

# [Visual Studio Code](#tab/visual-studio-code)

Run the following command from the **Integrated Terminal**:

```console
dotnet add TodoApi.NSwag.csproj package NSwag.AspNetCore
```

# [.NET Core CLI](#tab/netcore-cli)

Run the following command:

```console
dotnet add TodoApi.NSwag.csproj package NSwag.AspNetCore
```

# Add and configure Swagger to the middleware

Add the following using statements for the `Info` class:

```csharp
using NSwag.AspNetCore;
using System.Reflection;
using NJsonSchema;
```

In the `Configure` method of *Startup.cs*, enable the middleware for serving the generated Swagger specification and the Swagger UI:

[!code-csharp[Main](../tutorials/web-api-help-pages-using-swagger/sample/TodoApi.NSwagNSwag/Startup.cs?name=snippet_Configure&highlight=4,7-10)]

Thats it! You can now launch the app, and navigate to `/swagger` to see the Swagger UI or `/swagger/v1/swagger.json` to see the Swagger specification.

# Code generation

## Via NSwagStudio

* Install `NSwagStudio` from the official [GitHub repository](https://github.com/RSuter/NSwag/wiki/NSwagStudio)

* Launch NSwagStudio and enter the location of your swagger.json or copy it directly: 

![NSwagStudio](web-api-help-pages-using-swagger/_static/NSwagStudio.png)

* Check the output that you want, either a TypeScript Client, CSharp Client or CSharp Web Api Controllers. Using Web Api Controllers is basically a reverse generation. It uses a specification of a service to rebuild the service. 

* Click `Generate Outputs`.

* Here you see a complete client implementation of the sample TodoApi.NSwag in C#:

![NSwagStudio-Output](web-api-help-pages-using-swagger/_static/NSwagStudio-Output.png)

* Put the file into a client project, e.g. a Xamarin.Forms app and start consuming the API: 

```csharp
var todoClient = new TodoClient();

// Gets all Todos from the Api
var allTodos = await todoClient.GetAllAsync();

// Create a new TodoItem and save it in the Api
var createdTodo = await todoClient.CreateAsync(new TodoItem);

// Get a single Todo by Id
var foundTodo = await todoClient.GetByIdAsync(1);
```

**Note: You can also inject a base Url and/or a http client into the API client. Best practice is to always [reuse HttpClient](https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/).**

You can now start implementing your API into client projects easily. 

## Other ways to generate client code

You can also generate the code in other ways, more suited to your workflow

* [MSBuild](https://www.nuget.org/packages/NSwag.MSBuild/)

* [In code](https://github.com/NSwag/NSwag/wiki/SwaggerToCSharpClientGenerator)

* [T4 Templates](https://github.com/NSwag/NSwag/wiki/T4)

# Customization

### XML Comments

XML comments can be enabled with the following approaches:

# [Visual Studio](#tab/visual-studio-xml)

* Right-click the project in **Solution Explorer** and select **Properties**
* Check the **XML documentation file** box under the **Output** section of the **Build** tab:

![Build tab of project properties](web-api-help-pages-using-swagger/_static/swagger-xml-comments.png)

# [Visual Studio for Mac](#tab/visual-studio-mac-xml)

* Open the **Project Options** dialog > **Build** > **Compiler**
* Check the **Generate xml documentation** box under the **General Options** section:

![General Options section of project options](web-api-help-pages-using-swagger/_static/swagger-xml-comments-mac.png)

# [Visual Studio Code](#tab/visual-studio-code-xml)

Manually add the following snippet to the *.csproj* file:

[!code-xml[Main](../tutorials/web-api-help-pages-using-swagger/sample/TodoApi.NSwag/TodoApiNSwag.csproj?range=7-9)]

### Data Annotations

Because NSwag uses Reflection and the best practice for Web API actions is to return IActionResult, NSwag cant know what exactly your action is doing and what it returns. 

Sample:

```csharp
public IActionResult Create([FromBody] TodoItem item)
{
    if (item == null)
    {
        return BadRequest();
    }

    _context.TodoItems.Add(item);
    _context.SaveChanges();

     return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
}
```

The action returns IActionResult, but inside the action its returning CreatedAtRoute or BadRequest. To tell clients which HTTP Response this action is really returning, we use Data Annotations. Insert the following Attributes above the action.

```csharp
[HttpPost]
[ProducesResponseType(typeof(TodoItem), 201)] // Created
[ProducesResponseType(typeof(TodoItem), 400)] // BadRequest
public IActionResult Create([FromBody] TodoItem item)
```

The Swagger generator can now accurately describe this action and generated clients will know what they receive when calling the endpoint. It is highly recommended to decorate all actions with these attributes. For guidelines on what HTTP responses your API actions should return, see the [RFC 7231 specification](https://tools.ietf.org/html/rfc7231#section-4.3).
