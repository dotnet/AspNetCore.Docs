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

## Areas for controllers with views

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

### Associate the controller with an Area

Area controllers are designated with the [&lbrack;Area&rbrack;](xref:Microsoft.AspNetCore.Mvc.AreaAttribute) attribute:

[!code-csharp[](areas/samples/MVCareas/Areas/Products/Controllers/ManageController.cs?hightlight=5
)]

### Add Area route

Area routes typically use conventional routing rather than attribute routing:

[!code-csharp[](areas/samples/MVCareas/Startup.cs?name=snippet)]

For more information, see [Route to controller actions](xref:mvc/controllers/routing).

## Link Generation

* Generating links from an action within an area based controller to another action within the same controller.

  Let's say the current request's path is like `/Products/Home/Create`

  HtmlHelper syntax: `@Html.ActionLink("Go to Product's Home Page", "Index")`

  TagHelper syntax: `<a asp-action="Index">Go to Product's Home Page</a>`

  Note that we need not supply the 'area' and 'controller' values here as they're already available in the context of the current request. These kind of values are called `ambient` values.

* Generating links from an action within an area based controller to another action on a different controller

  Let's say the current request's path is like `/Products/Home/Create`

  HtmlHelper syntax: `@Html.ActionLink("Go to Manage Products Home Page", "Index", "Manage")`

  TagHelper syntax: `<a asp-controller="Manage" asp-action="Index">Go to Manage Products Home Page</a>`

  Note that here the ambient value of an 'area' is used but the 'controller' value is specified explicitly above.

* Generating links from an action within an area based controller to another action on a different controller and a different area.

  Let's say the current request's path is like `/Products/Home/Create`

  HtmlHelper syntax: `@Html.ActionLink("Go to Services Home Page", "Index", "Home", new { area = "Services" })`

  TagHelper syntax: `<a asp-area="Services" asp-controller="Home" asp-action="Index">Go to Services Home Page</a>`

  Note that here no ambient values are used.

* Generating links from an action within an area based controller to another action on a different controller and **not** in an area.

  HtmlHelper syntax: `@Html.ActionLink("Go to Manage Products  Home Page", "Index", "Home", new { area = "" })`

  TagHelper syntax: `<a asp-area="" asp-controller="Manage" asp-action="Index">Go to Manage Products Home Page</a>`

  Since we want to generate links to a non-area based controller action, we empty the ambient value for 'area' here.

<a name="rename"></a>

## Change default area name

The following code changes the default area name from `"Areas"` to `"MyAreas"`:

[!code-csharp[](areas/samples/MVCareas/Startup2.cs?name=snippet)]

<!-- TODO review - can we delete this. Areas doesn't change publishing - right? -->
## Publishing Areas

All `*.cshtml` and `wwwroot/**` files are published to output when `<Project Sdk="Microsoft.NET.Sdk.Web">` is included in the *.csproj* file.
