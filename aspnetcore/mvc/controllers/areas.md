---
title: Areas in ASP.NET Core
author: rick-anderson
description: Learn how Areas are an ASP.NET MVC feature used to organize related functionality into a group as a separate namespace (for routing) and folder structure (for views).
ms.author: riande
ms.date: 02/14/2019
uid: mvc/controllers/areas
---
# Areas in ASP.NET Core

By [Dhananjay Kumar](https://twitter.com/debug_mode) and [Rick Anderson](https://twitter.com/RickAndMSFT)

Areas are an ASP.NET MVC feature used to organize related functionality into a group as a separate namespace (for routing) and folder structure (for views). Using areas creates a hierarchy for the purpose of routing by adding another route parameter, `area`, to `controller` and `action` or a Razor Page `action`.

Areas provide a way to partition an ASP.NET Core Web app into smaller functional groups. An area is effectively an MVC structure inside an application. In an ASP.NET Core web project, logical components like Pages, Model, Controller, and View are kept in different folders. The ASP.NET Core runtime uses naming conventions to create the relationship between these components. For a large app, it may be advantageous to partition the app into separate high level areas of functionality. For instance, an e-commerce app with multiple business units, such as checkout, billing, and search. Each of these units have their own area to contain views, controllers, Razor Pages, and models.

An area can be defined as smaller functional units in an ASP.NET Core MVC project with its own set of Razor Pages, controllers, views, and models.

Consider using Areas in an project when the app:

* Is made of multiple high-level functional components that can be logically separated.
* You want to partition the app so that each functional area can be worked on independently.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/mvc/controllers/areas/samples) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Areas for controllers with views

A typical ASP.NET Core web app using areas, controllers, and views contains the following:

* An [Area folder structure](#area-folder-structure)
* Controllers decorated with the [&lbrack;Area&rbrack;](#attribute) attribute to associate the controller with the area.
* The [area route added to startup](add-area-route).

## Area folder structure
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

The location of non-view folders like *Controllers* and *Models* does **not** matter. For example, the *Controllers* and *Models* folder are not required. The content of *Controllers* and *Models* is code which gets compiled into a .dll. The content of the *Views* isn't compiled until a request to that view has been made.

<!-- TODO review:
The content of the *Views* isn't compiled until a request to that view has been made.

What about precompiled views? 
 -->
<a name="attribute"></a>

### Associate the controller with an Area

Area controllers are designated with the [&lbrack;Area&rbrack;](xref:Microsoft.AspNetCore.Mvc.AreaAttribute) attribute:

[!code-csharp[](areas/samples/MVCareas/Areas/Products/Controllers/ManageController.cs?hightlight=5&name=snippet)]

### Add Area route

Area routes typically use conventional routing rather than attribute routing:

[!code-csharp[](areas/samples/MVCareas/Startup.cs?name=snippet)]

For more information, see [Route to controller actions](xref:mvc/controllers/routing).

## Link Generation with Areas

The following code from the [sample download](https://github.com/aspnet/Docs/tree/master/aspnetcore/mvc/controllers/areas/samples shows link generation with the area specified:

[!code-cshtml[](areas/samples/MVCareas/Views/Shared/_testLinksPartial.cshtml?name=snippet)]

The links generated with the preceding code are valid anywhere in the app.

The sample download includes a [partial view](xref:mvc/views/partial) that contains the preceding links and links without specifying the area. The partial view is referenced in the [layout file](), so every page in the app displays the generated views. The links generated without specifying the area are only valid when referenced from a page in the same area and controller.

When the area or controller is not specified, routing depends on the `ambient` values. The current route values of the current request are considered ambient values for link generation. In many cases for the sample app, depending on the the ambient values generates incorrect links.

The sample app contains the following [filter](xref:mvc/controllers/filters) to generate links using [Url.Action] (/dotnet/api/microsoft.aspnetcore.mvc.urlhelperextensions.action?view=aspnetcore-2.2#Microsoft_AspNetCore_Mvc_UrlHelperExtensions_Action_Microsoft_AspNetCore_Mvc_IUrlHelper_System_String_System_String_System_Object_), with and without the area specified. When the area is not specified, the links work only when the ambient area value is correct.

For more information, see [Routing to controller actions](xref:mvc/controllers/routing).

<a name="rename"></a>

## Change default area name

The following code changes the default area name from `"Areas"` to `"MyAreas"`:

[!code-csharp[](areas/samples/MVCareas/Startup2.cs?name=snippet)]

<!-- TODO review - can we delete this. Areas doesn't change publishing - right? -->
## Publishing Areas

All `*.cshtml` and `wwwroot/**` files are published to output when `<Project Sdk="Microsoft.NET.Sdk.Web">` is included in the *.csproj* file.
