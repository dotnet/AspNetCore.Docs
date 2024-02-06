---
title: Reusable Razor UI in class libraries with ASP.NET Core
author: Rick-Anderson
description: Explains how to create reusable Razor UI using partial views in a class library in ASP.NET Core.
ms.author: riande
ms.date: 11/19/2023
ms.custom: mvc
uid: razor-pages/ui-class
---
# Create reusable UI using the Razor class library project in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range="> aspnetcore-6.0"

Razor views, pages, controllers, page models, [Razor components](xref:blazor/components/class-libraries), [View components](xref:mvc/views/view-components), and data models can be built into a Razor class library (RCL). The RCL can be packaged and reused. Applications can include the RCL and override the views and pages it contains. When a view, partial view, or Razor Page is found in both the web app and the RCL, the Razor markup (`.cshtml` file) in the web app takes precedence.

For information on how to integrate npm and webpack into the build process for a Razor Class Library, see [Build client web assets for your Razor Class Library](https://devblogs.microsoft.com/dotnet/build-client-web-assets-for-your-razor-class-library/).

## Create a class library containing Razor UI

# [Visual Studio](#tab/visual-studio)

* From Visual Studio select **Create new a new project**.
* Select **Razor Class Library** > **Next**.
* Name the library (for example, "RazorClassLib"), > **Create**. To avoid a file name collision with the generated view library, ensure the library name doesn't end in `.Views`.
* Select **Support pages and views** if you need to support views. By default, only Razor Pages are supported. Select **Create**.

The Razor class library (RCL) template defaults to Razor component development by default. The **Support pages and views** option supports pages and views.

# [.NET Core CLI](#tab/netcore-cli)

From the command line, run `dotnet new razorclasslib`. For example:

```dotnetcli
dotnet new razorclasslib -o RazorUIClassLib
```

The Razor class library (RCL) template defaults to Razor component development by default. Pass the `--support-pages-and-views` option (`dotnet new razorclasslib --support-pages-and-views`) to provide support for pages and views.

For more information, see [dotnet new](/dotnet/core/tools/dotnet-new). To avoid a file name collision with the generated view library, ensure the library name doesn't end in `.Views`.

---

Add Razor files to the RCL.

The ASP.NET Core templates assume the RCL content is in the `Areas` folder. See [RCL Pages layout](#rcl-lay) below to create an RCL that exposes content in `~/Pages` rather than `~/Areas/Pages`.

## Reference RCL content

The RCL can be referenced by:

* NuGet package. See [Creating NuGet packages](/nuget/create-packages/creating-a-package) and [dotnet add package](/dotnet/core/tools/dotnet-add-package) and [Create and publish a NuGet package](/nuget/quickstart/create-and-publish-a-package-using-visual-studio).
* `{ProjectName}.csproj`. See [dotnet-add reference](/dotnet/core/tools/dotnet-add-reference).

## Override views, partial views, and pages

When a view, partial view, or Razor Page is found in both the web app and the RCL, the Razor markup (`.cshtml` file) in the web app takes precedence. For example, add `WebApp1/Areas/MyFeature/Pages/Page1.cshtml` to WebApp1, and Page1 in the WebApp1 will take precedence over Page1 in the RCL.

In the sample download, rename `WebApp1/Areas/MyFeature2` to `WebApp1/Areas/MyFeature` to test precedence.

Copy the `RazorUIClassLib/Areas/MyFeature/Pages/Shared/_Message.cshtml` partial view to `WebApp1/Areas/MyFeature/Pages/Shared/_Message.cshtml`. Update the markup to indicate the new location. Build and run the app to verify the app's version of the partial is being used.

If the RCL uses Razor Pages, enable the Razor Pages services and endpoints in the hosting app:

[!code-csharp[](~/razor-pages/ui-class/7samples/MvcProgram.cs?highlight=4,25)]

<a name="rcl-lay"></a>

### RCL Pages layout

To reference RCL content as though it is part of the web app's `Pages` folder, create the RCL project with the following file structure:

* `RazorUIClassLib/Pages`
* `RazorUIClassLib/Pages/Shared`

Suppose `RazorUIClassLib/Pages/Shared` contains two partial files: `_Header.cshtml` and `_Footer.cshtml`. The `<partial>` tags could be added to `_Layout.cshtml` file:

```cshtml
<body>
  <partial name="_Header">
  @RenderBody()
  <partial name="_Footer">
</body>
```

Add the `_ViewStart.cshtml` file to the RCL project's `Pages` folder to use the `_Layout.cshtml` file from the host web app:

```cshtml
@{
    Layout = "_Layout";
}
```

## Create an RCL with static assets

An RCL may require companion static assets that can be referenced by either the RCL or the consuming app of the RCL. ASP.NET Core allows creating RCLs that include static assets that are available to a consuming app.

To include companion assets as part of an RCL, create a `wwwroot` folder in the class library and include any required files in that folder.

When packing an RCL, all companion assets in the `wwwroot` folder are automatically included in the package.

Use the `dotnet pack` command rather than the NuGet.exe version `nuget pack`.

### Exclude static assets

To exclude static assets, add the desired exclusion path to the `$(DefaultItemExcludes)` property group in the project file. Separate entries with a semicolon (`;`).

In the following example, the `lib.css` stylesheet in the `wwwroot` folder isn't considered a static asset and isn't included in the published RCL:

```xml
<PropertyGroup>
  <DefaultItemExcludes>$(DefaultItemExcludes);wwwroot\lib.css</DefaultItemExcludes>
</PropertyGroup>
```

### Typescript integration

To include TypeScript files in an RCL:

1. Reference the [`Microsoft.TypeScript.MSBuild`](https://www.nuget.org/packages/Microsoft.TypeScript.MSBuild) NuGet package in the project.

   [!INCLUDE[](~/includes/package-reference.md)]

1. Place the TypeScript files (`.ts`) outside of the `wwwroot` folder. For example, place the files in a `Client` folder.

1. Configure the TypeScript build output for the `wwwroot` folder. Set the `TypescriptOutDir` property inside of a `PropertyGroup` in the project file:

   ```xml
   <TypescriptOutDir>wwwroot</TypescriptOutDir>
   ```

1. Include the TypeScript target as a dependency of the `PrepareForBuildDependsOn` target by adding the following target inside of a `PropertyGroup` in the project file:
   
   ```xml
   <PrepareForBuildDependsOn>
     CompileTypeScript;
     GetTypeScriptOutputForPublishing;$(PrepareForBuildDependsOn)
   </PrepareForBuildDependsOn>
   ```

### Consume content from a referenced RCL

The files included in the `wwwroot` folder of the RCL are exposed to either the RCL or the consuming app under the prefix `_content/{PACKAGE ID}/`. For example, a library with an assembly name of `Razor.Class.Lib` and without a `<PackageId>` specified in its project file results in a path to static content at `_content/Razor.Class.Lib/`. When producing a NuGet package and the assembly name isn't the same as the package ID ([`<PackageId>`](/nuget/create-packages/creating-a-package-msbuild#set-properties) in the library's project file), use the package ID as specified in the project file for `{PACKAGE ID}`.

The consuming app references static assets provided by the library with `<script>`, `<style>`, `<img>`, and other HTML tags. The consuming app must have [static file support](xref:fundamentals/static-files) enabled in:

[!code-csharp[](~/razor-pages/ui-class/7samples/MvcProgram.cs?highlight=15)]

When running the consuming app from build output (`dotnet run`), static web assets are enabled by default in the Development environment. To support assets in other environments when running from build output, call <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseStaticWebAssets%2A> on the host builder in `Program.cs`:

[!code-csharp[](~/razor-pages/ui-class/7samples/cli/WebApp1/Program.cs?name=snippet1&highlight=3-4)]

Calling `UseStaticWebAssets` isn't required when running an app from published output (`dotnet publish`).

### Multi-project development flow

When the consuming app runs:

* The assets in the RCL stay in their original folders. The assets aren't moved to the consuming app.
* Any change within the RCL's `wwwroot` folder is reflected in the consuming app after the RCL is rebuilt and without rebuilding the consuming app.

When the RCL is built, a manifest is produced that describes the static web asset locations. The consuming app reads the manifest at runtime to consume the assets from referenced projects and packages. When a new asset is added to an RCL, the RCL must be rebuilt to update its manifest before a consuming app can access the new asset.

### Publish

When the app is published, the companion assets from all referenced projects and packages are copied into the `wwwroot` folder of the published app under `_content/{PACKAGE ID}/`. When producing a NuGet package and the assembly name isn't the same as the package ID ([`<PackageId>`](/nuget/create-packages/creating-a-package-msbuild#set-properties) in the library's project file), use the package ID as specified in the project file for `{PACKAGE ID}` when examining the `wwwroot` folder for the published assets.

## Additional resources

* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/razor-pages/ui-class/samples) ([how to download](xref:index#how-to-download-a-sample))

* <xref:blazor/components/class-libraries>
* <xref:blazor/components/css-isolation#razor-class-library-rcl-support>

:::moniker-end

[!INCLUDE[](~/razor-pages/ui-class/includes/ui-class6.md)]
