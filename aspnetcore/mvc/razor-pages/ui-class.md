---
title:  Reusable Razor UI in class libraries with ASP.NET Core
author: Rick-Anderson
description: Explains how to create reusable Razor Pages UI in a class library.
manager: wpickett
ms.author: riande
ms.date: 4/31/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: advanced
uid: mvc/razor-pages/ui-class
---
# Reusable Razor User Interface (UI) in class libraries with ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

Razor views, pages, controllers, page models, and data models can be built in a class library project, and packaged and re-used. Applications can include the Razor UI class library and override the views and pages it contains. When a view, partial view, or Razor Page is found in both the web app and the UI class library, the Razor markup (*.cshtml* file) in the web app takes precedence.

This feature requires [!INCLUDE[](~/includes/2.1-SDK.md)]

[!INCLUDE[](~/includes/2.1.md)]

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/mvc/razor-pages/ui-class/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Create a class library containing Razor UI

* Create a .NET Standard class library and add a package reference to [Microsoft.AspNetCore.Mvc](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc).
* Update the *.csproj* file and change the SDK to `Microsoft.NET.SDK.Razor`.
* Add Razor files to the class library.
* Build and package the class library.

The following references are supported for the Razor UI class library:

* Nuget package. See [Creating NuGet packages](/nuget/create-packages/creating-a-package) and [dotnet add package](/dotnet/core/tools/dotnet-add-package).
* DLLs - for example, *{ProjectName}.dll* and *{ProjectName}.PrecompiledViews.dll*.  See [dotnet-add reference](/dotnet/core/tools/dotnet-add-reference).
* *{ProjectName}.csproj*. See [dotnet-add reference](/dotnet/core/tools/dotnet-add-reference).

## Walkthrough: Create a class library containing Razor UI

* Create a .NET Standard class library and add a package reference to [Microsoft.AspNetCore.Mvc](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc). For example, run

    ```cli
    dotnet new classlib -f netstandard2.0 -o RazorUIClassLib
    dotnet add RazorUIClassLib package Microsoft.AspNetCore.Mvc -v 2.1.0-preview2-final
    ```

    See [dotnet new](/dotnet/core/tools/dotnet-new) for more information.

* Update the *.csproj* file and change the SDK to `Microsoft.NET.SDK.Razor`:

    [!code-xml[Main](ui-class/sample/RazorUIClassLib/RazorUIClassLib.csproj)]

* Add Razor files and a view imports file to the class library. For example:

    ```cli
    dotnet new page -n Test -na RazorUIClassLib.Pages -o RazorUIClassLib/Pages
    dotnet new viewimports -na RazorUIClassLib.Pages -o RazorUIClassLib/Pages
    ```

* Update the Razor Page. For example:

    ```cshtml
    @page

    <h1>Hello from a Razor UI class library!</h1>
    ```

* Build the class library to verify there are no compiler errors:

    `dotnet build RazorUIClassLib`

    The build output contains *RazorUIClassLib.dll* and *RazorUIClassLib.Views.dll*. *RazorUIClassLib.Views.dll* contains the compiled Razor content.

### Use the Razor UI library

* Create a Razor Pages web app. For example:

    `dotnet new razor -o WebApp1`

* Create a solution file and add the class library project and the Razor Pages project. For example:

    ``` CLI
    dotnet new sln
    dotnet sln add WebApp1
    dotnet sln add RazorUIClassLib
    ```

* Add a reference from the web app to the class library:

    `dotnet add WebApp1 reference RazorUIClassLib`

* Build and run the web app:

    ``` CLI
    cd WebApp1
    dotnet run
    ```

* Browse to `/test` to see the page from the Razor UI class library.

## Package the Razor UI class library

* The following command packages the Razor UI class library:

    ``` CLI
    cd ..
    dotnet pack RazorUIClassLib
    ```

    Ignore the warning message "A stable release of a package should not have a prerelease dependency." The warning will not happen when relased packages are used.

* Create a new web app and add a package reference to the Razor UI class library package

    ``` CLI
    dotnet new razor -o WebApp2
    dotnet add WebApp2 package RazorUIClassLib --source {path}/RazorUIClassLib/bin/Debug
    ```

    Ignore the `NotFound` info messages for `razoruiclasslib/index.json` from your default NuGet sources.

* Run  the app:

    ``` CLI
    cd WebApp2
    dotnet run
    ```

* Browse to `/test` to see the page from the Razor UI class library.

Publish the package to NuGet to make it publicaly avaliable.

## Override views, partial views, and pages

When a view, partial view, or Razor Page is found in both the web app and the UI class library, the Razor markup (*.cshtml* file) in the web app takes precedence. For example, add *Pages/Test.cshtml* to WebApp2, and the Test page in the WebApp2 will take precedence over the Test page in the NuGet package.  The sample download contains the partial view *Pages/Shared/_Message.cshtml* in both the UI class and the web app. When the app is run, the web app *_Message.cshtml* partial is used. Rename or delete the web apps *_Message.cshtml* to use the RazorUIClassLib version.