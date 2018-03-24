---
title:  Reusable Razor UI in class libraries with ASP.NET Core
author: Rick-Anderson
description: Explains how to create reusable Razor Pages UI in a class library.
manager: wpickett
ms.author: riande
ms.date: 3/31/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: advanced
uid: mvc/razor-pages/ui-class
---
# Reusable Razor User Interface (UI) in class libraries with ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

Razor views, pages, controllers, page models, and data models can be packaged and shared in a class library. Applications can include the Razor UI class library and override the views and pages it contains.

[!INCLUDE[](~/includes/2.1-required.md)]
[!INCLUDE[](~/includes/2.1.md)]

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/mvc/razor-pages/ui-class/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Create a class library containing Razor UI

* Create a .NET Standard class library. For example, run 

    ```cli
    dotnet new classlib -f netstandard2.0 -o RazorClassUI
    ```
    See [dotnet new](/dotnet/core/tools/dotnet-new) for more information.
* Update the *.csproj* file to contain:

    * The MSBuild properties `ResolvedRazorCompileToolset`, `RazorCompileOnBuild`, `IncludeContentInPack`.
    * The `Content` element to include the Razor *.cshtml* files.
    * A package reference to [Microsoft.AspNetCore.Mvc](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc).
    
    The following markup shows an updated *.csproj* file:

    [!code-xml[Main](ui-class/sample/RazorClassUI/RazorClassUI.csproj)]

    Preview1 requires you to manually update the *.csproj* file. In a future release, we hope to provide a Razor MSBuild SDK (`Microsoft.NET.Sdk.Razor`) and project templates to update the *.csproj* file.

* Add Razor files to the class library. For example:

    * Create a *Pages* directory in the class library.
    * Add Razor Pages to the *Pages* directory. For example, add the Contact page and page model (*Contact.cshtml, Contact.cshtml.cs*) from a Razor Pages project. You can create a Razor pages project with the following command:
    
        ```cli
        dotnet new razor -o RazorPagesApp
        ```
    * Optional: Add a *Pages/_ViewImports.cshtml* file to contain the `namespace` for the Razor Pages.
    
### Use the class library containing Razor UI in an ASP.NET Core web app

Add a Razor UI class reference to the ASP.NET Core web app. The following references are supported for the Razor UI class library:

* Nuget package. See [Creating NuGet packages](/nuget/create-packages/creating-a-package) and [dotnet add package](/dotnet/core/tools/dotnet-add-package).
* DLLs - for example, *{ProjectName}.dll* and *{ProjectName}.PrecompiledViews.dll*.  See [dotnet-add reference](/dotnet/core/tools/dotnet-add-reference).
* *{ProjectName}.csproj*. See [dotnet-add reference](/dotnet/core/tools/dotnet-add-reference).

## Override views, partial views, and pages

When a view, partial view, or Razor Page is found in both the web app and the UI class library, the Razor markup (*.cshtml* file) in the web app takes precedence. The sample download contains the partial view *Pages\Shared\_Message.cshtml* in both the UI class and the web app. When the app is run, the web app *_Message.cshtml* partial is used. Rename or delete the web apps *_Message.cshtml* to use the Class UI version.
