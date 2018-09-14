---
title: Reusable Razor UI in class libraries with ASP.NET Core
author: Rick-Anderson
description: Explains how to create reusable Razor UI in a class library.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.date: 07/21/2018
uid: razor-pages/ui-class
---
# Create reusable UI using the Razor Class Library project in ASP.NET Core.

By [Rick Anderson](https://twitter.com/RickAndMSFT)

Razor views, pages, controllers, page models, [View components](xref:mvc/views/view-components), and data models can be built into a Razor Class Library (RCL). The RCL can be packaged and reused. Applications can include the RCL and override the views and pages it contains. When a view, partial view, or Razor Page is found in both the web app and the RCL, the Razor markup (*.cshtml* file) in the web app takes precedence.

This feature requires [!INCLUDE[](~/includes/2.1-SDK.md)]

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/razor-pages/ui-class/samples) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Create a class library containing Razor UI

# [Visual Studio](#tab/visual-studio)

* From the Visual Studio **File** menu, select **New** > **Project**.
* Select **ASP.NET Core Web Application**.
* Name the library (for example, "RazorClassLib") > **OK**. To avoid a file name collision with the generated view library, ensure the library name doesn't end in `.Views`.
* Verify **ASP.NET Core 2.1** or later is selected.
* Select **Razor Class Library** > **OK**.

A Razor Class Library has the following project file:

[!code-xml[Main](ui-class/samples/cli/RazorUIClassLib/RazorUIClassLib.csproj)]

# [.NET Core CLI](#tab/netcore-cli)

From the commandline, run `dotnet new razorclasslib`. For example:

``` CLI
dotnet new razorclasslib -o RazorUIClassLib
```

For more information, see [dotnet new](/dotnet/core/tools/dotnet-new). To avoid a file name collision with the generated view library, ensure the library name doesn't end in `.Views`.

------
Add Razor files to the RCL.

The ASP.NET Core templates assume the RCL content is in the *Areas* folder. See [RCL Pages layout](#afs) to create a RCL that exposes content in `~/Pages` rather than `~/Areas/Pages`.

## Referencing Razor Class Library content

The RCL can be referenced by:

* NuGet package. See [Creating NuGet packages](/nuget/create-packages/creating-a-package) and [dotnet add package](/dotnet/core/tools/dotnet-add-package) and [Create and publish a NuGet package](/nuget/quickstart/create-and-publish-a-package-using-visual-studio).
* *{ProjectName}.csproj*. See [dotnet-add reference](/dotnet/core/tools/dotnet-add-reference).

## Walkthrough: Create a Razor Class Library project and use from a Razor Pages project

You can download the [complete project](https://github.com/aspnet/Docs/tree/master/aspnetcore/razor-pages/ui-class/samples) and test it rather than creating it. The sample download contains additional code and links that make the project easy to test. You can leave feedback in [this GitHub issue](https://github.com/aspnet/Docs/issues/6098) with your comments on download samples versus step-by-step instructions.

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
* Name the app **RazorUIClassLib** > **OK**.
* Verify **ASP.NET Core 2.1** or later is selected.
* Select **Razor Class Library** > **OK**.
* Add a Razor partial view file named *RazorUIClassLib/Areas/MyFeature/Pages/Shared/_Message.cshtml*.

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

------

### Add Razor files and folders to the project.

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

### Use the Razor UI library from a Razor Pages project

# [Visual Studio](#tab/visual-studio)

Create the Razor Pages web app:

* From **Solution Explorer**, right-click the solution > **Add** >  **New Project**.
* Select **ASP.NET Core Web Application**.
* Name the app **WebApp1**.
* Verify **ASP.NET Core 2.1** or later is selected.
* Select **Web Application** > **OK**.

* From **Solution Explorer**, right-click on **WebApp1** and select **Set as StartUp Project**.
* From **Solution Explorer**, right-click on **WebApp1** and select **Build Dependencies** > **Project Dependencies**.
* Check **RazorUIClassLib** as a dependency of **WebApp1**.
* From **Solution Explorer**, right-click on **WebApp1** and select **Add** > **Reference**.
* In the **Reference Manager** dialog, check **RazorUIClassLib** > **OK**.

Run the app.

# [.NET Core CLI](#tab/netcore-cli)

Create a Razor Pages web app and a solution file containing the Razor Pages app and the Razor Class Library:

```console
dotnet new webapp -o WebApp1
dotnet new sln
dotnet sln add WebApp1
dotnet sln add RazorUIClassLib
dotnet add WebApp1 reference RazorUIClassLib
```

[!INCLUDE[](~/includes/webapp-alias-notice.md)]

Build and run the web app:

```console
cd WebApp1
dotnet run
```

---

<a name="test"></a>

### Test WebApp1

Verify the Razor UI class library is being used.

* Browse to `/MyFeature/Page1`.

## Override views, partial views, and pages

When a view, partial view, or Razor Page is found in both the web app and the Razor Class Library, the Razor markup (*.cshtml* file) in the web app takes precedence. For example, add *WebApp1/Areas/MyFeature/Pages/Page1.cshtml* to WebApp1, and Page1 in the WebApp1 will take precedence over Page1in the Razor Class Library.

In the sample download, rename *WebApp1/Areas/MyFeature2* to *WebApp1/Areas/MyFeature* to test precedence.

Copy the *RazorUIClassLib/Areas/MyFeature/Pages/Shared/_Message.cshtml* partial view to *WebApp1/Areas/MyFeature/Pages/Shared/_Message.cshtml*. Update the markup to indicate the new location. Build and run the app to verify the app's version of the partial is being used.

<a name="afs"></a>

### RCL Pages layout

To reference RCL content as though it is part of the web app's Pages folder, create the RCL project with the following file structure:

* *RazorUIClassLib/Pages*
* *RazorUIClassLib/Pages/Shared*

Suppose *RazorUIClassLib/Pages/Shared* contains two partial files, *_Header.cshtml* and *_Footer.cshtml*. The <partial> tags could be added to *_Layout.cshtml* file: 
  
```
  <body>
    <partial name="_Header">
    @RenderBody()
    <partial name="_Footer">
  </body>
```
