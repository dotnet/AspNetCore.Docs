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

# Getting Started

When using NSwag with ASP.NET Core there is only one package you need to get started:

* `NSwag.AspNetCore`: The main package, contains the Swagger UI (v2 and v3), Swagger Generator and [ReDoc UI](https://github.com/Rebilly/ReDoc).

It's highly recommended to make use of the code generation capabilities of NSwag. Either by using [NSwagStudio](https://github.com/NSwag/NSwag/wiki/NSwagStudio), an easy to use Windows program to generate client code in C# and TypeScript for your API, or by using `NSwag.CodeGeneration.CSharp`or `NSwag.CodeGeneration.TypeScript` packages to to code generation right inside your project. There is also the possibility to use NSwag via [Command line](https://github.com/NSwag/NSwag/wiki/CommandLine), [MSBuild](https://github.com/NSwag/NSwag/wiki/MSBuild), [T4 Templates](https://github.com/NSwag/NSwag/wiki/T4) or [Cake](https://agc93.github.io/Cake.NSwag/doc/intro.html). 

# Features

The main reason to use NSwag is the ability to not only introduce the Swagger UI and Swagger Generator, but also to make use of the flexible code generation capabilities. You don't even have to have an existing API yourself. You can easily use 3rd party APIs that incorporate Swagger and let NSwag generate a client implementation. Either way you can speed up your development and also adjust easier to API changes. 

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
dotnet add TodoApi.csproj package NSwag.AspNetCore
```

# [.NET Core CLI](#tab/netcore-cli)

Run the following command:

```console
dotnet add TodoApi.csproj package NSwag.AspNetCore
```

# Add and configure Swagger to the middleware

Add the following using statements for the `Info` class:

```csharp
using NSwag.AspNetCore;
using System.Reflection;
using NJsonSchema;
```

In the `Configure` method of *Startup.cs*, enable the middleware for serving the generated JSON document and the SwaggerUI:

[!code-csharp[Main](../tutorials/web-api-help-pages-using-swagger/sample/TodoApiNSwag/Startup1.cs?name=snippet_Configure&highlight=4,7-10)]

Thats it! You can now launch the app, and navigate to `/swagger` to see the Swagger UI or `/swagger/v1/swagger.json` to see the Swagger specification.

# Code generation

## Via NSwagStudio 

* Install `NSwagStudio` from the official [GitHub repository](https://github.com/RSuter/NSwag/wiki/NSwagStudio)

* Launch NSwagStudio and enter the location of your swagger.json or copy it directly: 

![NSwagStudio](web-api-help-pages-using-swagger/_static/NSwagStudio.png)

* Check the output that you want, either a TypeScript Client, CSharp Client or CSharp Web Api Controllers. Using Web Api Controllers is basically a reverse generation. It uses a specification of a service to rebuild the service. 

* Click `Generate Outputs`.

* Here you see a complete client implementation of the sample TodoApi in C#:

![NSwagStudio-Output](web-api-help-pages-using-swagger/_static/NSwagStudio-Output.png)

* Put the file into a client project, e.g. a Xamarin Forms App and start consuming the API: 

```csharp
var todoClient = new TodoClient();

// Gets all Todos from the Api
var allTodos = await todoClient.GetAllAsync();

// Create a new TodoItem and save it in the Api
var createdTodo = await todoClient.CreateAsync(new TodoItem

// Get a single Todo by Id
var foundTodo = await todoClient.GetByIdAsync(1);
```

**NOTE: You can also inject a base Url and/or a http client into the API client. Best practice is to always reuse HttpClient.**

You can now start implementing your API into client projects easily. 

## Other ways to generate client code

You can also generate the code in other ways, more suited to your workflow

* [MSBuild](https://www.nuget.org/packages/NSwag.MSBuild/)

* [In code](https://github.com/NSwag/NSwag/wiki/SwaggerToCSharpClientGenerator)

# Example client

..use the generated client

# Customization

..description

..xml comments

..data annotations

..attributes

..ui customization

