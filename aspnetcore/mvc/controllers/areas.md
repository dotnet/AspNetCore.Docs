---
title: Areas in ASP.NET Core
author: rick-anderson
description: Learn how Areas are an ASP.NET MVC feature used to organize related functionality into a group as a separate namespace (for routing) and folder structure (for views).
ms.author: riande
ms.date: 3/21/2022
uid: mvc/controllers/areas
---
# Areas in ASP.NET Core

By [Dhananjay Kumar](https://twitter.com/debug_mode) and [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range=">= aspnetcore-6.0"

Areas are an ASP.NET feature used to organize related functionality into a group as a separate:

* Namespace for routing.
* Folder structure for views and Razor Pages.

Using areas creates a hierarchy for the purpose of routing by adding another route parameter, `area`, to `controller` and `action` or a Razor Page `page`.

Areas provide a way to partition an ASP.NET Core Web app into smaller functional groups, each  with its own set of Razor Pages, controllers, views, and models. An area is effectively a structure inside an app. In an ASP.NET Core web project, logical components like Pages, Model, Controller, and View are kept in different folders. The ASP.NET Core runtime uses naming conventions to create the relationship between these components. For a large app, it may be advantageous to partition the app into separate high level areas of functionality. For instance, an e-commerce app with multiple business units, such as checkout, billing, and search. Each of these units have their own area to contain views, controllers, Razor Pages, and models.

Consider using Areas in a project when:

* The app is made of multiple high-level functional components that can be logically separated.
* You want to partition the app so that each functional area can be worked on independently.

If you're using Razor Pages, see [Areas with Razor Pages](#areas-with-razor-pages) in this document.

## Areas for controllers with views

A typical ASP.NET Core web app using areas, controllers, and views contains the following:

* An [Area folder structure](#area-folder-structure).
* Controllers with the [`[Area]`](#attribute) attribute to associate the controller with the area:

  [!code-csharp[](areas/60samples/MVCareas/Areas/Products/Controllers/ManageController.cs?name=snippet2)]

* The [area route added to `Program.cs`](#add-area-route):

  [!code-csharp[](areas/60samples/MVCareas/Program.cs?name=snippet1&highlight=20-22)]

### Area folder structure

Consider an app that has two logical groups, *Products* and *Services*. Using areas, the folder structure would be similar to the following:

* Project name
  * Areas
    * Products
      * Controllers
        * HomeController.cs
        * ManageController.cs
      * Views
        * Home
          * Index.cshtml
        * Manage
          * Index.cshtml
          * About.cshtml
    * Services
      * Controllers
        * HomeController.cs
      * Views
        * Home
          * Index.cshtml

While the preceding layout is typical when using Areas, only the view files are required to use this folder structure. View discovery searches for a matching area view file in the following order:

```text
/Areas/<Area-Name>/Views/<Controller-Name>/<Action-Name>.cshtml
/Areas/<Area-Name>/Views/Shared/<Action-Name>.cshtml
/Views/Shared/<Action-Name>.cshtml
/Pages/Shared/<Action-Name>.cshtml
```

<a name="attribute"></a>

### Associate the controller with an Area

Area controllers are designated with the [`[Area]`](xref:Microsoft.AspNetCore.Mvc.AreaAttribute) attribute:

[!code-csharp[](areas/60samples/MVCareas/Areas/Products/Controllers/ManageController.cs?highlight=6&name=snippet)]

### Add Area route

Area routes typically use  [conventional routing](xref:mvc/controllers/routing#cr) rather than [attribute routing](xref:mvc/controllers/routing#ar). Conventional routing is order-dependent. In general, routes with areas should be placed earlier in the route table as they're more specific than routes without an area.

`{area:...}` can be used as a token in route templates if url space is uniform across all areas:

[!code-csharp[](areas/60samples/MVCareas/Program.cs?name=snippet1&highlight=20-22)]

In the preceding code, `exists` applies a constraint that the route must match an area. Using `{area:...}` with `MapControllerRoute`:

* Is the least complicated mechanism to adding routing to areas.
* Matches all controllers with the `[Area("Area name")]` attribute.

The following code uses <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapAreaControllerRoute*> to create two named area routes:

[!code-csharp[](areas/60samples/MVCareas/Program.cs?name=snippet_2named&highlight=20-28)]

For more information, see [Area routing](xref:mvc/controllers/routing#areas).

### Link generation with MVC areas

The following code from the [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/areas/60samples) shows link generation with the area specified:

[!code-cshtml[](areas/60samples/MVCareas/Views/Shared/_testLinksPartial.cshtml?name=snippet)]

The sample download includes a [partial view](xref:mvc/views/partial) that contains:

* The preceding links.
* Links similar to the preceding except `area` is not specified.

The partial view is referenced in the [layout file](xref:mvc/views/layout), so every page in the app displays the generated links. The links generated without specifying the area are only valid when referenced from a page in the same area and controller.

When the area or controller is not specified, routing depends on the [ambient](xref:mvc/controllers/routing#ambient) values. The current route values of the current request are considered ambient values for link generation. In many cases for the sample app, using the ambient values generates incorrect links with the markup that doesn't specify the area.

For more information, see [Routing to controller actions](xref:mvc/controllers/routing).

### Shared layout for Areas using the _ViewStart.cshtml file

To share a common layout for the entire app, keep the *_ViewStart.cshtml* in the [application root folder](#arf). For more information, see <xref:mvc/views/layout>

<a name="arf"></a>

### Application root folder

The application root folder is the folder containing the `Program.cs` file in a web app created with the ASP.NET Core templates.

### _ViewImports.cshtml

 */Views/_ViewImports.cshtml*, for MVC, and */Pages/_ViewImports.cshtml* for Razor Pages, is not imported to views in areas. Use one of the following approaches to provide view imports to all views:

* Add *_ViewImports.cshtml* to the [application root folder](#arf). A *_ViewImports.cshtml* in the application root folder will apply to all views in the app.
* Copy the *_ViewImports.cshtml* file to the appropriate view folder under areas. For example, a Razor Pages app created with individual user accounts has a *_ViewImports.cshtml* file in the following folders:
  * */Areas/Identity/Pages/_ViewImports.cshtml*
  * */Pages/_ViewImports.cshtml*

The *_ViewImports.cshtml* file typically contains [Tag Helpers](xref:mvc/views/tag-helpers/intro) imports, `@using`, and `@inject` statements. For more information, see [Importing Shared Directives](xref:mvc/views/layout#importing-shared-directives).

<a name="rename"></a>

### Change default area folder where views are stored

The following code changes the default area folder from `"Areas"` to `"MyAreas"`:

[!code-csharp[](areas/60samples/MVCareas/Program.cs?name=snippet_default_area&highlight=5-11)]

<a name="arp"></a>

## Areas with Razor Pages

Areas with Razor Pages require an `Areas/<area name>/Pages` folder in the root of the app. The following folder structure is used with the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/areas/31samples):

* Project name
  * Areas
    * Products
      * Pages
        * _ViewImports
        * About
        * Index
    * Services
      * Pages
        * Manage
          * About
          * Index

### Link generation with Razor Pages and areas

The following code from the [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/areas/60samples/RPareas) shows link generation with the area specified (for example, `asp-area="Products"`):

[!code-cshtml[](areas/60samples/RPareas/Pages/Shared/_testLinksPartial.cshtml?name=snippet)]

The sample download includes a [partial view](xref:mvc/views/partial) that contains the preceding links and the same links without specifying the area. The partial view is referenced in the [layout file](xref:mvc/views/layout), so every page in the app displays the generated links. The links generated without specifying the area are only valid when referenced from a page in the same area.

When the area is not specified, routing depends on the *ambient* values. The current route values of the current request are considered ambient values for link generation. In many cases for the sample app, using the ambient values generates incorrect links. For example, consider the links generated from the following code:

[!code-cshtml[](areas/60samples/RPareas/Pages/Shared/_testLinksPartial.cshtml?name=snippet2)]

For the preceding code:

* The link generated from `<a asp-page="/Manage/About">` is correct only when the last request was for a page in `Services` area. For example, `/Services/Manage/`, `/Services/Manage/Index`, or `/Services/Manage/About`.
* The link generated from `<a asp-page="/About">` is correct only when the last request was for a page in `/Home`.
* The code is from the [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/areas/60samples/RPareas).

### Import namespace and Tag Helpers with _ViewImports file

A *_ViewImports.cshtml* file can be added to each area *Pages* folder to import the namespace and Tag Helpers to each Razor Page in the folder.

Consider the *Services* area of the sample code, which doesn't contain a *_ViewImports.cshtml* file. The following markup shows the */Services/Manage/About* Razor Page:

[!code-cshtml[](areas/60samples/RPareas/Areas/Services/Pages/Manage/About.cshtml)]

In the preceding markup:

* The fully qualified class name must be used to specify the model (`@model RPareas.Areas.Services.Pages.Manage.AboutModel`).
* [Tag Helpers](xref:mvc/views/tag-helpers/intro) are enabled by `@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers`

In the sample download, the Products area contains the following *_ViewImports.cshtml* file:

[!code-cshtml[](areas/60samples/RPareas/Areas/Products/Pages/_ViewImports.cshtml)]

The following markup shows the */Products/About* Razor Page:

[!code-cshtml[](areas/60samples/RPareas/Areas/Products/Pages/About.cshtml)]

In the preceding file, the namespace and `@addTagHelper` directive is imported to the file by the *Areas/Products/Pages/_ViewImports.cshtml* file.

For more information, see [Managing Tag Helper scope](xref:mvc/views/tag-helpers/intro?view=aspnetcore-2.2#managing-tag-helper-scope) and [Importing Shared Directives](xref:mvc/views/layout#importing-shared-directives).

### Shared layout for Razor Pages Areas

To share a common layout for the entire app, move the *_ViewStart.cshtml* to the application root folder.

### Publishing Areas

All *.cshtml files and files within the *wwwroot* directory are published to output when `<Project Sdk="Microsoft.NET.Sdk.Web">` is included in the *.csproj file.

## Add MVC Area with Visual Studio

In Solution Explorer, right click the project and select **ADD > New Scaffolded Item**, then select **MVC Area**.

## Additional resources

* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/areas/60samples) ([how to download](xref:index#how-to-download-a-sample)). The download sample provides a basic app for testing areas.
* [!INCLUDE[](~/includes/MyDisplayRouteInfoBoth.md)]

:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-6.0"

Areas are an ASP.NET feature used to organize related functionality into a group as a separate:

* Namespace for routing.
* Folder structure for views and Razor Pages.

Using areas creates a hierarchy for the purpose of routing by adding another route parameter, `area`, to `controller` and `action` or a Razor Page `page`.

Areas provide a way to partition an ASP.NET Core Web app into smaller functional groups, each  with its own set of Razor Pages, controllers, views, and models. An area is effectively a structure inside an app. In an ASP.NET Core web project, logical components like Pages, Model, Controller, and View are kept in different folders. The ASP.NET Core runtime uses naming conventions to create the relationship between these components. For a large app, it may be advantageous to partition the app into separate high level areas of functionality. For instance, an e-commerce app with multiple business units, such as checkout, billing, and search. Each of these units have their own area to contain views, controllers, Razor Pages, and models.

Consider using Areas in a project when:

* The app is made of multiple high-level functional components that can be logically separated.
* You want to partition the app so that each functional area can be worked on independently.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/areas/31samples) ([how to download](xref:index#how-to-download-a-sample)). The download sample provides a basic app for testing areas.

If you're using Razor Pages, see [Areas with Razor Pages](#areas-with-razor-pages) in this document.

## Areas for controllers with views

A typical ASP.NET Core web app using areas, controllers, and views contains the following:

* An [Area folder structure](#area-folder-structure).
* Controllers with the [`[Area]`](#attribute) attribute to associate the controller with the area:

  [!code-csharp[](areas/31samples/MVCareas/Areas/Products/Controllers/ManageController.cs?name=snippet2)]

* The [area route added to startup](#add-area-route):

  [!code-csharp[](areas/31samples/MVCareas/Startup.cs?name=snippet2&highlight=3-6)]

### Area folder structure

Consider an app that has two logical groups, *Products* and *Services*. Using areas, the folder structure would be similar to the following:

* Project name
  * Areas
    * Products
      * Controllers
        * HomeController.cs
        * ManageController.cs
      * Views
        * Home
          * Index.cshtml
        * Manage
          * Index.cshtml
          * About.cshtml
    * Services
      * Controllers
        * HomeController.cs
      * Views
        * Home
          * Index.cshtml

While the preceding layout is typical when using Areas, only the view files are required to use this folder structure. View discovery searches for a matching area view file in the following order:

```text
/Areas/<Area-Name>/Views/<Controller-Name>/<Action-Name>.cshtml
/Areas/<Area-Name>/Views/Shared/<Action-Name>.cshtml
/Views/Shared/<Action-Name>.cshtml
/Pages/Shared/<Action-Name>.cshtml
```

<a name="attribute"></a>

### Associate the controller with an Area

Area controllers are designated with the [&lbrack;Area&rbrack;](xref:Microsoft.AspNetCore.Mvc.AreaAttribute) attribute:

[!code-csharp[](areas/31samples/MVCareas/Areas/Products/Controllers/ManageController.cs?highlight=5&name=snippet)]

### Add Area route

Area routes typically use  [conventional routing](xref:mvc/controllers/routing#cr) rather than [attribute routing](xref:mvc/controllers/routing#ar). Conventional routing is order-dependent. In general, routes with areas should be placed earlier in the route table as they're more specific than routes without an area.

`{area:...}` can be used as a token in route templates if url space is uniform across all areas:

[!code-csharp[](areas/31samples/MVCareas/Startup.cs?name=snippet&highlight=21-23)]

In the preceding code, `exists` applies a constraint that the route must match an area. Using `{area:...}` with `MapControllerRoute`:

* Is the least complicated mechanism to adding routing to areas.
* Matches all controllers with the `[Area("Area name")]` attribute.

The following code uses <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapAreaControllerRoute*> to create two named area routes:

[!code-csharp[](areas/31samples/MVCareas/StartupMapAreaRoute.cs?name=snippet&highlight=21-29)]

For more information, see [Area routing](xref:mvc/controllers/routing#areas).

### Link generation with MVC areas

The following code from the [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/areas/31samples) shows link generation with the area specified:

[!code-cshtml[](areas/31samples/MVCareas/Views/Shared/_testLinksPartial.cshtml?name=snippet)]

The sample download includes a [partial view](xref:mvc/views/partial) that contains:

* The preceding links.
* Links similar to the preceding except `area` is not specified.

The partial view is referenced in the [layout file](xref:mvc/views/layout), so every page in the app displays the generated links. The links generated without specifying the area are only valid when referenced from a page in the same area and controller.

When the area or controller is not specified, routing depends on the [ambient](xref:mvc/controllers/routing#ambient) values. The current route values of the current request are considered ambient values for link generation. In many cases for the sample app, using the ambient values generates incorrect links with the markup that doesn't specify the area.

For more information, see [Routing to controller actions](xref:mvc/controllers/routing).

### Shared layout for Areas using the _ViewStart.cshtml file

To share a common layout for the entire app, keep the `_ViewStart.cshtml` in the [application root folder](#arf). For more information, see <xref:mvc/views/layout>

<a name="arf"></a>

### Application root folder

The application root folder is the folder containing `Startup.cs` in web app created with the ASP.NET Core templates.

### _ViewImports.cshtml

 `/Views/_ViewImports.cshtml`, for MVC, and `/Pages/_ViewImports.cshtml` for Razor Pages, is not imported to views in areas. Use one of the following approaches to provide view imports to all views:

* Add `_ViewImports.cshtml` to the [application root folder](#arf). A `_ViewImports.cshtml` in the application root folder will apply to all views in the app.
* Copy the `_ViewImports.cshtml` file to the appropriate view folder under areas.

The `_ViewImports.cshtml` file typically contains [Tag Helpers](xref:mvc/views/tag-helpers/intro) imports, `@using`, and `@inject` statements. For more information, see [Importing Shared Directives](xref:mvc/views/layout#importing-shared-directives).

<a name="rename"></a>

### Change default area folder where views are stored

The following code changes the default area folder from `"Areas"` to `"MyAreas"`:

[!code-csharp[](areas/31samples/MVCareas/Startup2.cs?name=snippet)]

<a name="arp"></a>

## Areas with Razor Pages

Areas with Razor Pages require an `Areas/<area name>/Pages` folder in the root of the app. The following folder structure is used with the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/areas/31samples):

* Project name
  * Areas
    * Products
      * Pages
        * _ViewImports
        * About
        * Index
    * Services
      * Pages
        * Manage
          * About
          * Index

### Link generation with Razor Pages and areas 

The following code from the [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/areas/samples/RPareas) shows link generation with the area specified (for example, `asp-area="Products"`):

[!code-cshtml[](areas/31samples/RPareas/Pages/Shared/_testLinksPartial.cshtml?name=snippet)]

The sample download includes a [partial view](xref:mvc/views/partial) that contains the preceding links and the same links without specifying the area. The partial view is referenced in the [layout file](xref:mvc/views/layout), so every page in the app displays the generated links. The links generated without specifying the area are only valid when referenced from a page in the same area.

When the area is not specified, routing depends on the *ambient* values. The current route values of the current request are considered ambient values for link generation. In many cases for the sample app, using the ambient values generates incorrect links. For example, consider the links generated from the following code:

[!code-cshtml[](areas/31samples/RPareas/Pages/Shared/_testLinksPartial.cshtml?name=snippet2)]

For the preceding code:

* The link generated from `<a asp-page="/Manage/About">` is correct only when the last request was for a page in `Services` area. For example, `/Services/Manage/`, `/Services/Manage/Index`, or `/Services/Manage/About`.
* The link generated from `<a asp-page="/About">` is correct only when the last request was for a page in `/Home`.
* The code is from the [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/areas/31samples/RPareas).

### Import namespace and Tag Helpers with _ViewImports file

A `_ViewImports.cshtml` file can be added to each area *Pages* folder to import the namespace and Tag Helpers to each Razor Page in the folder.

Consider the *Services* area of the sample code, which doesn't contain a `_ViewImports.cshtml` file. The following markup shows the */Services/Manage/About* Razor Page:

[!code-cshtml[](areas/31samples/RPareas/Areas/Services/Pages/Manage/About.cshtml)]

In the preceding markup:

* The fully qualified class name must be used to specify the model (`@model RPareas.Areas.Services.Pages.Manage.AboutModel`).
* [Tag Helpers](xref:mvc/views/tag-helpers/intro) are enabled by `@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers`

In the sample download, the Products area contains the following `_ViewImports.cshtml` file:

[!code-cshtml[](areas/31samples/RPareas/Areas/Products/Pages/_ViewImports.cshtml)]

The following markup shows the */Products/About* Razor Page:

[!code-cshtml[](areas/31samples/RPareas/Areas/Products/Pages/About.cshtml)]

In the preceding file, the namespace and `@addTagHelper` directive is imported to the file by the `Areas/Products/Pages/_ViewImports.cshtml` file.

For more information, see [Managing Tag Helper scope](xref:mvc/views/tag-helpers/intro?view=aspnetcore-2.2#managing-tag-helper-scope) and [Importing Shared Directives](xref:mvc/views/layout#importing-shared-directives).

### Shared layout for Razor Pages Areas

To share a common layout for the entire app, move the `_ViewStart.cshtml` to the application root folder.

### Publishing Areas

All *.cshtml files and files within the *wwwroot* directory are published to output when `<Project Sdk="Microsoft.NET.Sdk.Web">` is included in the *.csproj file.

## Add MVC Area with Visual Studio

In Solution Explorer, right click the project and select **ADD > New Scaffolded Item**, then select **MVC Area**.

:::moniker-end

:::moniker range="< aspnetcore-3.0"

Areas are an ASP.NET feature used to organize related functionality into a group as a separate namespace (for routing) and folder structure (for views). Using areas creates a hierarchy for the purpose of routing by adding another route parameter, `area`, to `controller` and `action` or a Razor Page `page`.

Areas provide a way to partition an ASP.NET Core Web app into smaller functional groups, each  with its own set of Razor Pages, controllers, views, and models. An area is effectively a structure inside an app. In an ASP.NET Core web project, logical components like Pages, Model, Controller, and View are kept in different folders. The ASP.NET Core runtime uses naming conventions to create the relationship between these components. For a large app, it may be advantageous to partition the app into separate high level areas of functionality. For instance, an e-commerce app with multiple business units, such as checkout, billing, and search. Each of these units have their own area to contain views, controllers, Razor Pages, and models.

Consider using Areas in a project when:

* The app is made of multiple high-level functional components that can be logically separated.
* You want to partition the app so that each functional area can be worked on independently.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/areas/samples) ([how to download](xref:index#how-to-download-a-sample)). The download sample provides a basic app for testing areas.

If you're using Razor Pages, see [Areas with Razor Pages](#areas-with-razor-pages) in this document.

## Areas for controllers with views

A typical ASP.NET Core web app using areas, controllers, and views contains the following:

* An [Area folder structure](#area-folder-structure).
* Controllers with the [`[Area]`](#attribute) attribute to associate the controller with the area:

  [!code-csharp[](areas/samples/MVCareas/Areas/Products/Controllers/ManageController.cs?name=snippet2)]

* The [area route added to startup](#add-area-route):

  [!code-csharp[](areas/samples/MVCareas/Startup.cs?name=snippet2&highlight=3-6)]

### Area folder structure

Consider an app that has two logical groups, *Products* and *Services*. Using areas, the folder structure would be similar to the following:

* Project name
  * Areas
    * Products
      * Controllers
        * HomeController.cs
        * ManageController.cs
      * Views
        * Home
          * Index.cshtml
        * Manage
          * Index.cshtml
          * About.cshtml
    * Services
      * Controllers
        * HomeController.cs
      * Views
        * Home
          * Index.cshtml

While the preceding layout is typical when using Areas, only the view files are required to use this folder structure. View discovery searches for a matching area view file in the following order:

```text
/Areas/<Area-Name>/Views/<Controller-Name>/<Action-Name>.cshtml
/Areas/<Area-Name>/Views/Shared/<Action-Name>.cshtml
/Views/Shared/<Action-Name>.cshtml
/Pages/Shared/<Action-Name>.cshtml
```

<a name="attribute"></a>

### Associate the controller with an Area

Area controllers are designated with the [&lbrack;Area&rbrack;](xref:Microsoft.AspNetCore.Mvc.AreaAttribute) attribute:

[!code-csharp[](areas/samples/MVCareas/Areas/Products/Controllers/ManageController.cs?highlight=5&name=snippet)]

### Add Area route

Area routes typically use conventional routing rather than attribute routing. Conventional routing is order-dependent. In general, routes with areas should be placed earlier in the route table as they're more specific than routes without an area.

`{area:...}` can be used as a token in route templates if url space is uniform across all areas:

[!code-csharp[](areas/samples/MVCareas/Startup.cs?name=snippet&highlight=18-21)]

In the preceding code, `exists` applies a constraint that the route must match an area. Using `{area:...}` is the least complicated mechanism to adding routing to areas.

The following code uses <xref:Microsoft.AspNetCore.Builder.MvcAreaRouteBuilderExtensions.MapAreaRoute*> to create two named area routes:

[!code-csharp[](areas/samples/MVCareas/StartupMapAreaRoute.cs?name=snippet&highlight=18-27)]

When using `MapAreaRoute` with ASP.NET Core 2.2, see [this GitHub issue](https://github.com/dotnet/AspNetCore/issues/7772).

For more information, see [Area routing](xref:mvc/controllers/routing#areas).

### Link generation with MVC areas

The following code from the [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/areas/samples) shows link generation with the area specified:

[!code-cshtml[](areas/samples/MVCareas/Views/Shared/_testLinksPartial.cshtml?name=snippet)]

The links generated with the preceding code are valid anywhere in the app.

The sample download includes a [partial view](xref:mvc/views/partial) that contains the preceding links and the same links without specifying the area. The partial view is referenced in the [layout file](xref:mvc/views/layout), so every page in the app displays the generated links. The links generated without specifying the area are only valid when referenced from a page in the same area and controller.

When the area or controller is not specified, routing depends on the *ambient* values. The current route values of the current request are considered ambient values for link generation. In many cases for the sample app, using the ambient values generates incorrect links.

For more information, see [Routing to controller actions](xref:mvc/controllers/routing).

### Shared layout for Areas using the _ViewStart.cshtml file

To share a common layout for the entire app, move the `_ViewStart.cshtml` to the application root folder.

### _ViewImports.cshtml

In its standard location, `/Views/_ViewImports.cshtml` doesn't apply to areas. To use common [Tag Helpers](xref:mvc/views/tag-helpers/intro), `@using`, or `@inject` in your area, ensure a proper `_ViewImports.cshtml` file [applies to your area views](xref:mvc/views/layout#importing-shared-directives). If you want the same behavior in all your views, move `/Views/_ViewImports.cshtml` to the application root.

<a name="rename"></a>

### Change default area folder where views are stored

The following code changes the default area folder from `"Areas"` to `"MyAreas"`:

[!code-csharp[](areas/samples/MVCareas/Startup2.cs?name=snippet)]

<a name="arp"></a>

## Areas with Razor Pages

Areas with Razor Pages require an `Areas/<area name>/Pages` folder in the root of the app. The following folder structure is used with the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/areas/samples):

* Project name
  * Areas
    * Products
      * Pages
        * _ViewImports
        * About
        * Index
    * Services
      * Pages
        * Manage
          * About
          * Index

### Link generation with Razor Pages and areas

The following code from the [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/areas/samples/RPareas) shows link generation with the area specified (for example, `asp-area="Products"`):

[!code-cshtml[](areas/samples/RPareas/Pages/Shared/_testLinksPartial.cshtml?name=snippet)]

The links generated with the preceding code are valid anywhere in the app.

The sample download includes a [partial view](xref:mvc/views/partial) that contains the preceding links and the same links without specifying the area. The partial view is referenced in the [layout file](xref:mvc/views/layout), so every page in the app displays the generated links. The links generated without specifying the area are only valid when referenced from a page in the same area.

When the area is not specified, routing depends on the *ambient* values. The current route values of the current request are considered ambient values for link generation. In many cases for the sample app, using the ambient values generates incorrect links. For example, consider the links generated from the following code:

[!code-cshtml[](areas/samples/RPareas/Pages/Shared/_testLinksPartial.cshtml?name=snippet2)]

For the preceding code:

* The link generated from `<a asp-page="/Manage/About">` is correct only when the last request was for a page in `Services` area. For example, `/Services/Manage/`, `/Services/Manage/Index`, or `/Services/Manage/About`.
* The link generated from `<a asp-page="/About">` is correct only when the last request was for a page in `/Home`.
* The code is from the [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/areas/samples/RPareas).

### Import namespace and Tag Helpers with _ViewImports file

A `_ViewImports.cshtml` file can be added to each area *Pages* folder to import the namespace and Tag Helpers to each Razor Page in the folder.

Consider the *Services* area of the sample code, which doesn't contain a `_ViewImports.cshtml` file. The following markup shows the */Services/Manage/About* Razor Page:

[!code-cshtml[](areas/samples/RPareas/Areas/Services/Pages/Manage/About.cshtml)]

In the preceding markup:

* The fully qualified domain name must be used to specify the model (`@model RPareas.Areas.Services.Pages.Manage.AboutModel`).
* [Tag Helpers](xref:mvc/views/tag-helpers/intro) are enabled by `@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers`

In the sample download, the Products area contains the following `_ViewImports.cshtml` file:

[!code-cshtml[](areas/samples/RPareas/Areas/Products/Pages/_ViewImports.cshtml)]

The following markup shows the */Products/About* Razor Page:

[!code-cshtml[](areas/samples/RPareas/Areas/Products/Pages/About.cshtml)]

In the preceding file, the namespace and `@addTagHelper` directive is imported to the file by the `Areas/Products/Pages/_ViewImports.cshtml` file.

For more information, see [Managing Tag Helper scope](xref:mvc/views/tag-helpers/intro?view=aspnetcore-2.2#managing-tag-helper-scope) and [Importing Shared Directives](xref:mvc/views/layout#importing-shared-directives).

### Shared layout for Razor Pages Areas

To share a common layout for the entire app, move the `_ViewStart.cshtml` to the application root folder.

### Publishing Areas

All *.cshtml files and files within the *wwwroot* directory are published to output when `<Project Sdk="Microsoft.NET.Sdk.Web">` is included in the *.csproj file.
:::moniker-end
