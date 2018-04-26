---
title:  Reusable Razor UI in class libraries with ASP.NET Core
author: Rick-Anderson
description: Explains how to create reusable Razor Pages UI in a class library.
manager: wpickett
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.date: 4/31/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: advanced
uid: mvc/razor-pages/ui-class
---
# Create reusable UI using the Razor Class Library project.

test - remove the following

[!code-html[Main](ui-class/samples/cli/RazorUIClassLib/Pages/Shared/_Message.cshtml)]
    
    * Delete the *RazorUIClassLib/Pages/Shared/_Message.cshtml.cs* file.
    
    * Replace the markup in *RazorUIClassLib/Areas/MyFeature/Pages/Page1.cshtml* with the following:
    
  [!code-html[Main](ui-class/samples/cli/RazorUIClassLib/Areas/MyFeature/Pages/Page1.cshtml]

    ``` CLI
    dotnet new razorclasslib -o RazorUIClassLib
    dotnet new page -n Test -na RazorUIClassLib.Pages -o RazorUIClassLib/Pages
    dotnet new page -n _Message -o RazorUIClassLib/Pages/Shared
    dotnet new viewstart -o RazorUIClassLib/Pages
    dotnet new viewstart -o RazorUIClassLib/Areas/MyFeature/Pages
    ```

        [!code-html[Main](ui-class/samples/cli/RazorUIClassLib/Pages/Shared/_Message.cshtml)]
    
    * Delete the *RazorUIClassLib/Pages/Shared/_Message.cshtml.cs* file.
    
    * Replace the markup in *RazorUIClassLib/Areas/MyFeature/Pages/Page1.cshtml* with the following:
    
  [!code-html[Main](ui-class/samples/cli/RazorUIClassLib/Areas/MyFeature/Pages/Page1.cshtml]


By [Rick Anderson](https://twitter.com/RickAndMSFT)

Razor views, pages, controllers, page models, and data models can be built into a class library project, and packaged and reused. Applications can include the Razor UI class library and override the views and pages it contains. When a view, partial view, or Razor Page is found in both the web app and the UI class library, the Razor markup (*.cshtml* file) in the web app takes precedence.

This feature requires [!INCLUDE[](~/includes/2.1-SDK.md)]

[!INCLUDE[](~/includes/2.1.md)]

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/mvc/razor-pages/ui-class/samples) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Create a class library containing Razor UI

# [Visual Studio](#tab/visual-studio) 

* From the Visual Studio **File** menu, select **New** > **Project**.
* Verify **ASP.NET Core 2.1** or later is selected.
* Select **Razor Class Library** > **OK**.

# [.NET Core CLI](#tab/netcore-cli)

From the commandline, run `dotnet new razorclasslib`. For example:

``` CLI
dotnet new razorclasslib -o RazorUIClassLib
```

See [dotnet new](/dotnet/core/tools/dotnet-new) for more information.

------

The following references are supported for a Razor UI class library:

* Nuget package. See [Creating NuGet packages](/nuget/create-packages/creating-a-package) and [dotnet add package](/dotnet/core/tools/dotnet-add-package) and [Create and publish a NuGet package](/nuget/quickstart/create-and-publish-a-package-using-visual-studio).
* DLLs - for example, *{ProjectName}.dll* and *{ProjectName}.Views.dll*.  See [dotnet-add reference](/dotnet/core/tools/dotnet-add-reference). *{ProjectName}.Views.dll* contains the compiled Razor content.
* *{ProjectName}.csproj*. See [dotnet-add reference](/dotnet/core/tools/dotnet-add-reference).

test - remove the following

[!code-html[Main](ui-class/samples/cli/RazorUIClassLib/Pages/Shared/_Message.cshtml)]
    
    * Delete the *RazorUIClassLib/Pages/Shared/_Message.cshtml.cs* file.
    
    * Replace the markup in *RazorUIClassLib/Areas/MyFeature/Pages/Page1.cshtml* with the following:
    
  [!code-html[Main](ui-class/samples/cli/RazorUIClassLib/Areas/MyFeature/Pages/Page1.cshtml]

    ``` CLI
    dotnet new razorclasslib -o RazorUIClassLib
    dotnet new page -n Test -na RazorUIClassLib.Pages -o RazorUIClassLib/Pages
    dotnet new page -n _Message -o RazorUIClassLib/Pages/Shared
    dotnet new viewstart -o RazorUIClassLib/Pages
    dotnet new viewstart -o RazorUIClassLib/Areas/MyFeature/Pages
    ```

        [!code-html[Main](ui-class/samples/cli/RazorUIClassLib/Pages/Shared/_Message.cshtml)]
    
    * Delete the *RazorUIClassLib/Pages/Shared/_Message.cshtml.cs* file.
    
    * Replace the markup in *RazorUIClassLib/Areas/MyFeature/Pages/Page1.cshtml* with the following:
    
  [!code-html[Main](ui-class/samples/cli/RazorUIClassLib/Areas/MyFeature/Pages/Page1.cshtml]
  
## Walkthrough: Create a Razor Class Library project and use from a Razor Pages project

You can download the [complete project](https://github.com/aspnet/Docs/tree/master/aspnetcore/mvc/razor-pages/ui-class/samples) and test it rather than creating it. The sample download contains additional code and links that make the project easy to test.

# [Visual Studio](#tab/visual-studio) 

VS instructions here.

# [.NET Core CLI](#tab/netcore-cli)


From the command line, run the following:

    ``` CLI
    dotnet new razorclasslib -o RazorUIClassLib
    dotnet new page -n Test -na RazorUIClassLib.Pages -o RazorUIClassLib/Pages
    dotnet new page -n _Message -o RazorUIClassLib/Pages/Shared
    dotnet new viewstart -o RazorUIClassLib/Pages
    dotnet new viewstart -o RazorUIClassLib/Areas/MyFeature/Pages
    ```
    
   You must use the `-o RazorUIClassLib` option so the namespace will match in the remainder of this article. The preceding commands create a Razor Class Library and add Razor files.
    
    The viewstart files are required to use the layout of the Razor Pages project (which is added in the next section).

* Update the Razor Pages. For example:

    * Replace the markup in *RazorUIClassLib/Pages/Shared/_Message.cshtml* with the following:
    
    [!code-html[Main](ui-class/samples/cli/RazorUIClassLib/Pages/Shared/_Message.cshtml)]
    
    * Delete the *RazorUIClassLib/Pages/Shared/_Message.cshtml.cs* file.
    
    * Replace the markup in *RazorUIClassLib/Areas/MyFeature/Pages/Page1.cshtml* with the following:
    
  [!code-html[Main](ui-class/samples/cli/RazorUIClassLib/Areas/MyFeature/Pages/Page1.cshtml]
    
    `@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers` is required to use the partial view (`<partial name="_Message" />`). Rather than including this line, you can add a *_ViewImports.cshtml* file. For example:
    
    ``` CLI
    dotnet new viewimports  -o RazorUIClassLib/Pages
    dotnet new viewimports  -o RazorUIClassLib/Areas/MyFeature/Pages
    ```

    * Replace the markup in *RazorUIClassLib/Pages/Test.cshtml* with markup similar to the *Page1.cshtml* file.
    * Delete the *RazorUIClassLib/Pages/Test.cshtml.cs* file.
    

* Build the class library to verify there are no compiler errors:

    `dotnet build RazorUIClassLib`

    The build output contains *RazorUIClassLib.dll* and *RazorUIClassLib.Views.dll*. *RazorUIClassLib.Views.dll* contains the compiled Razor content.

------
    
### Use the Razor UI library from a Razor Pages project

# [Visual Studio](#tab/visual-studio) 

VS instructions here.

# [.NET Core CLI](#tab/netcore-cli)

* Create a Razor Pages web app and a solution file containing the Razor Pages app and the Razor Class Library:

    ``` CLI
    dotnet new razor -o WebApp1
    dotnet new sln
    dotnet sln add WebApp1
    dotnet sln add RazorUIClassLib
    dotnet add WebApp1 reference RazorUIClassLib
    ```

* Build and run the web app:

    ``` CLI
    cd WebApp1
    dotnet run
    ```

------

### Test WebApp1

Verify the Razor UI class library is being used.

* Browse to `/Test`.
* Browse to `/MyFeature/Page1`.

## Override views, partial views, and pages

When a view, partial view, or Razor Page is found in both the web app and the UI class library, the Razor markup (*.cshtml* file) in the web app takes precedence. For example, add *Pages/Test.cshtml* to WebApp1, and the Test page in the WebApp1 will take precedence over the Test page in the Razor Class Libary.  

Copy the *RazorUIClassLib/Pages/Shared/_Message.cshtml* partial view to *WebApp1/Pages/Shared/_Message.cshtml*. Update the markup to indicate the new location. Build and run the app to verify the app's version of the partial is being used.

<!-- 

The sample download contains the partial view *Pages/Shared/_Message.cshtml* in both the UI class and the web app. When the app is run, the web app *_Message.cshtml* partial is used. Rename or delete the web apps *_Message.cshtml* to use the `RazorUIClassLib` version.
## Package the Razor UI class library

* The following command packages the Razor UI class library:

    ``` CLI
    cd ..
    dotnet pack RazorUIClassLib
    ```

    Ignore the warning message:

    "A stable release of a package should not have a prerelease dependency.  Either modify the version spec of dependency `"Microsoft.AspNetCore.Mvc [2.1.0-preview, )`" or update the version field in the nuspec." 
    
    The preceding warning will not occur when released packages are used.

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

Publish the package to NuGet to make it publicly available.
-->