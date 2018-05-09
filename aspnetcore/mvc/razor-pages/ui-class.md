---
title: Reusable Razor UI in class libraries with ASP.NET Core
author: Rick-Anderson
description: Explains how to create reusable Razor UI in a class library.
manager: wpickett
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.date: 4/31/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: advanced
uid: mvc/razor-pages/ui-class
---
# Create reusable UI using the Razor Class Library project in ASP.NET Core.

By [Rick Anderson](https://twitter.com/RickAndMSFT)

Razor views, pages, controllers, page models, and data models can be built into a Razor Class Library (RCL). The RCL can be packaged and reused. Applications can include the RCL and override the views and pages it contains. When a view, partial view, or Razor Page is found in both the web app and the RCL, the Razor markup (*.cshtml* file) in the web app takes precedence.

This feature requires [!INCLUDE[](~/includes/2.1-SDK.md)]

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/mvc/razor-pages/ui-class/samples) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Create a class library containing Razor UI

# [Visual Studio](#tab/visual-studio)

* From the Visual Studio **File** menu, select **New** > **Project**.
* Select **ASP.NET Core Web Application**.
* Verify **ASP.NET Core 2.1** or later is selected.
* Select **Razor Class Library** > **OK**.

# [.NET Core CLI](#tab/netcore-cli)

From the commandline, run `dotnet new razorclasslib`. For example:

``` CLI
dotnet new razorclasslib -o RazorUIClassLib
```

For more information, see [dotnet new](/dotnet/core/tools/dotnet-new).

------
Add Razor files to the RCL.

We recommend RCL content go in the *Areas* folder. 


## Referencing Razor Class Library content

The RCL can be referenced by:

* NuGet package. See [Creating NuGet packages](/nuget/create-packages/creating-a-package) and [dotnet add package](/dotnet/core/tools/dotnet-add-package) and [Create and publish a NuGet package](/nuget/quickstart/create-and-publish-a-package-using-visual-studio).
* *{ProjectName}.csproj*. See [dotnet-add reference](/dotnet/core/tools/dotnet-add-reference).

### Partial files access in the RCL

For content outside the RCL, the ASP.NET Core runtime does not search for partial files in the RCL.

For example, in the sample download, the *RazorUIClassLib/Areas/MyFeature/Pages/Shared/_Message.cshtml* partial view can **not** be referenced in *WebApp1\Pages\About.cshtml*. However, pages in the RCL ( *RazorUIClassLib/* **can** access *RazorUIClassLib/Areas/MyFeature/Pages/Shared/_Message.cshtml*.

## Walkthrough: Create a Razor Class Library project and use from a Razor Pages project

You can download the [complete project](https://github.com/aspnet/Docs/tree/master/aspnetcore/mvc/razor-pages/ui-class/samples) and test it rather than creating it. The sample download contains additional code and links that make the project easy to test. You can leave feedback in [this GitHub issue](https://github.com/aspnet/Docs/issues/6098) with your comments on download samples versus step-by-step instructions.

### Test the download app

If you haven't downloaded the completed app and would rather create the walkthrough project, skip to the [next section](#create-a-razor-class-library).

# [Visual Studio](#tab/visual-studio)

Open the *.sln* file in Visual Studio. Run the app.

# [.NET Core CLI](#tab/netcore-cli)

From a command prompt in the *cli* directory, build the RCL and web app.

``` CLI
dotnet build
```

Move to the *WebApp1* directory and run the app:

``` CLI
dotnet run
```
------

Follow the instructions in [Test WebApp1](#test)

## Create a Razor Class Library

In this section, a Razor Class Library (RCL) is created. Razor files are added to the RCL.

# [Visual Studio](#tab/visual-studio)

Create the RCL project:

* From the Visual Studio **File** menu, select **New** > **Project**.
* Select **ASP.NET Core Web Application**.
* Name the app **RazorUIClassLib**.
* Verify **ASP.NET Core 2.1** or later is selected.
* Select **Razor Class Library** > **OK**.

Create the Razor Pages web app:

* From **Solution Explorer**, right-click the solution > **Add** >  **New Project**.
* Select **ASP.NET Core Web Application**.
* Name the app **WebApp1**.
* Verify **ASP.NET Core 2.1** or later is selected.
* Select **Web Application** > **OK**.

### Add Razor files and folders to the project.

* Add a Razor partial view file named *RazorUIClassLib/Areas/MyFeature/Pages/Shared/_Message.cshtml*.
* Replace the markup in *RazorUIClassLib/Areas/MyFeature/Pages/Shared/_Message.cshtml* with the following code:

[!code-html[Main](ui-class/samples/cli/RazorUIClassLib/Areas/MyFeature/Pages/Shared/_Message.cshtml)]

* Copy the *_ViewStart.cshtml* file from the WebApp1 project to  *RazorUIClassLib/Areas/MyFeature/Pages/_ViewStart.cshtml*.

  The [viewstart](xref:mvc/views/layout#running-code-before-each-view) file is required to use the layout of the Razor Pages project.

# [.NET Core CLI](#tab/netcore-cli)

From the command line, run the following:

``` CLI
dotnet new razorclasslib -o RazorUIClassLib
dotnet new page -n _Message -np -o RazorUIClassLib/Areas/MyFeature/Pages/Shared
dotnet new viewstart -o RazorUIClassLib/Areas/MyFeature/Pages
```

The preceding commands:

* Creates the `RazorUIClassLib` Razor Class Library (RCL).
* Creates a Razor _Message page, and adds it to the RCL. The `-np` parameter creates the page without a `PageModel`.
* Creates a [viewstart](xref:mvc/views/layout#running-code-before-each-view) file and adds it to the RCL.

The viewstart file is required to use the layout of the Razor Pages project (which is added in the next section).

Update the Razor Pages:

* Replace the markup in *RazorUIClassLib/Areas/MyFeature/Pages/Shared/_Message.cshtml* with the following code:

[!code-html[Main](ui-class/samples/cli/RazorUIClassLib/Areas/MyFeature/Pages/Shared/_Message.cshtml)]

* Replace the markup in *RazorUIClassLib/Areas/MyFeature/Pages/Page1.cshtml* with the following code:

[!code-html[Main](ui-class/samples/cli/RazorUIClassLib/Areas/MyFeature/Pages/Page1.cshtml)]

`@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers` is required to use the partial view (`<partial name="_Message" />`). Rather than including the `@addTagHelper` directive, you can add a *_ViewImports.cshtml* file. For example:

``` CLI
dotnet new viewimports -o RazorUIClassLib/Areas/MyFeature/Pages
```

For more information on viewimports, see [Importing Shared Directives](xref:mvc/views/layout#importing-shared-directives)

* Build the class library to verify there are no compiler errors:

``` CLI
dotnet build RazorUIClassLib
```

The build output contains *RazorUIClassLib.dll* and *RazorUIClassLib.Views.dll*. *RazorUIClassLib.Views.dll* contains the compiled Razor content.

------

### Use the Razor UI library from a Razor Pages project

# [Visual Studio](#tab/visual-studio)

* From **Solution Explorer**, right-click on **WebApp1** and select **Set as StartUp Project**.
* From **Solution Explorer**, right-click on **WebApp1** and select **Build Dependencies** > **Project Dependencies**.
* Check **RazorUIClassLib** as a dependency of **WebApp1**.
* From **Solution Explorer**, right-click on **WebApp1** and select **Add** > **Reference**.
* In the **Reference Manager** dialog, check **RazorUIClassLib** > **OK**.

Run the app.

# [.NET Core CLI](#tab/netcore-cli)

Create a Razor Pages web app and a solution file containing the Razor Pages app and the Razor Class Library:

``` CLI
dotnet new razor -o WebApp1
dotnet new sln
dotnet sln add WebApp1
dotnet sln add RazorUIClassLib
dotnet add WebApp1 reference RazorUIClassLib
```

Build and run the web app:

``` CLI
cd WebApp1
dotnet run
```

------

<a name="test"></a>

### Test WebApp1

Verify the Razor UI class library is being used.

* Browse to `/MyFeature/Page1`.

## Override views, partial views, and pages

When a view, partial view, or Razor Page is found in both the web app and the Razor Class Library, the Razor markup (*.cshtml* file) in the web app takes precedence. For example, add *WebApp1/Areas/MyFeature/Pages/Page1.cshtml* to WebApp1, and Page1 in the WebApp1 will take precedence over Page1in the Razor Class Library.

In the sample download, rename *WebApp1/Areas/MyFeature2* to *WebApp1/Areas/MyFeature* to test precedence.

Copy the *RazorUIClassLib/Areas/MyFeature/Pages/Shared/_Message.cshtml* partial view to *WebApp1/Areas/MyFeature/Pages/Shared/_Message.cshtml*. Update the markup to indicate the new location. Build and run the app to verify the app's version of the partial is being used.
