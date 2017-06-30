---
title: Areas
author: rick-anderson
description: Shows how to work with areas.
keywords: ASP.NET Core, areas, routing, views
ms.author: riande
manager: wpickett
ms.date: 02/14/2017
ms.topic: article
ms.assetid: 5e16d5e8-5696-4cb2-8ec7-d36be305c922
ms.technology: aspnet
ms.prod: asp.net-core
uid: mvc/controllers/areas
---
# Areas

By [Dhananjay Kumar](https://twitter.com/debug_mode)  and [Rick Anderson](https://twitter.com/RickAndMSFT)

Areas are an ASP.NET MVC feature used to organize related functionality into a group as a separate namespace (for routing) and folder structure (for views). Using areas creates a hierarchy for the purpose of routing by adding another route parameter, `area`, to `controller` and `action`.

Areas provide a way to partition a large ASP.NET Core MVC Web app into smaller functional groupings. An area is effectively an MVC structure inside an application. In an MVC project, logical components like Model, Controller, and View are kept in different folders, and MVC uses naming conventions to create the relationship between these components. For a large app, it may be advantageous to partition the  app into separate high level areas of functionality. For instance, an e-commerce app with multiple business units, such as checkout, billing, and search etc. Each of these units have their own logical component views, controllers, and models. In this scenario, you can use Areas to physically partition the business components in the same project.

An area can be defined as smaller functional units in an ASP.NET Core MVC project with its own set of controllers, views, and models.

Consider using Areas in an MVC project when:

* Your application is made of multiple high-level functional components that should be logically separated

* You want to partition your MVC project so that each functional area can be worked on independently

Area features:

* An ASP.NET Core MVC app can have any number of areas

* Each area has its own controllers, models, and views

* Allows you to organize large MVC projects into multiple high-level components that can be worked on independently

* Supports multiple controllers with the same name - as long as they have different *areas*

Let's take a look at an example to illustrate how Areas are created and used. Let's say you have a store app that has two distinct groupings of controllers and views: Products and Services. A typical folder structure for that using MVC areas looks like below:

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

    * Services

      * Controllers

        * HomeController.cs

      * Views

        * Home

          * Index.cshtml

When MVC tries to render a view in an Area, by default, it tries to look in the following locations:

```text
/Areas/<Area-Name>/Views/<Controller-Name>/<Action-Name>.cshtml
   /Areas/<Area-Name>/Views/Shared/<Action-Name>.cshtml
   /Views/Shared/<Action-Name>.cshtml
   ```

These are the default locations which can be changed via the `AreaViewLocationFormats` on the `Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions`.

For example, in the below code instead of having the folder name as 'Areas', it has been changed to 'Categories'.

```csharp
services.Configure<RazorViewEngineOptions>(options =>
   {
       options.AreaViewLocationFormats.Clear();
       options.AreaViewLocationFormats.Add("/Categories/{2}/Views/{1}/{0}.cshtml");
       options.AreaViewLocationFormats.Add("/Categories/{2}/Views/Shared/{0}.cshtml");
       options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
   });
   ```

One thing to note is that the structure of the *Views* folder is the only one which is considered important here and the content of the rest of the folders like *Controllers* and *Models* does **not** matter. For example, you need not have a *Controllers* and *Models* folder at all. This works because the content of *Controllers* and *Models* is just code which gets compiled into a .dll where as the content of the *Views* is not until a request to that view has been made.

Once you've defined the folder hierarchy, you need to tell MVC that each controller is associated with an area. You do that by decorating the controller name with the `[Area]` attribute.

<!-- literal_block {"ids": [], "linenos": false, "xml:space": "preserve", "language": "csharp", "highlight_args": {"hl_lines": [4]}} -->

```csharp
...
   namespace MyStore.Areas.Products.Controllers
   {
       [Area("Products")]
       public class HomeController : Controller
       {
           // GET: /Products/Home/Index
           public IActionResult Index()
           {
               return View();
           }

           // GET: /Products/Home/Create
           public IActionResult Create()
           {
               return View();
           }
       }
   }
   ```

Set up a route definition that works with your newly created areas. The [Routing to Controller Actions](routing.md) article goes into detail about how to create route definitions, including using conventional routes versus attribute routes. In this example, we'll use a conventional route. To do so, open the *Startup.cs* file and modify it by adding the `areaRoute` named route definition below.

<!-- literal_block {"ids": [], "linenos": false, "xml:space": "preserve", "language": "csharp", "highlight_args": {"hl_lines": [4, 5, 6]}} -->

```csharp
...
   app.UseMvc(routes =>
   {
     routes.MapRoute(name: "areaRoute",
       template: "{area:exists}/{controller=Home}/{action=Index}");

     routes.MapRoute(
         name: "default",
         template: "{controller=Home}/{action=Index}/{id?}");
   });
   ```

Browsing to `http://<yourApp>/products`, the `Index` action method of the `HomeController` in the `Products` area will be invoked.

## Link Generation

* Generating links from an action within an area based controller to another action within the same controller.

  Let's say the current request's path is like `/Products/Home/Create`

  HtmlHelper syntax: `@Html.ActionLink("Go to Product's Home Page", "Index")`

  TagHelper syntax: `<a asp-action="Index">Go to Product's Home Page</a>`

  Note that we need not supply the 'area' and 'controller' values here as they are already available in the context of the current request. These kind of values are called `ambient` values.

* Generating links from an action within an area based controller to another action on a different controller

  Let's say the current request's path is like `/Products/Home/Create`

  HtmlHelper syntax: `@Html.ActionLink("Go to Manage Products’  Home Page", "Index", "Manage")`

  TagHelper syntax: `<a asp-controller="Manage" asp-action="Index">Go to Manage Products’  Home Page</a>`

  Note that here the ambient value of an 'area' is used but the 'controller' value is specified explicitly above.

* Generating links from an action within an area based controller to another action on a different controller and a different area.

  Let's say the current request's path is like `/Products/Home/Create`

  HtmlHelper syntax: `@Html.ActionLink("Go to Services’ Home Page", "Index", "Home", new { area = "Services" })`

  TagHelper syntax: `<a asp-area="Services" asp-controller="Home" asp-action="Index">Go to Services’ Home Page</a>`

  Note that here no ambient values are used.

* Generating links from an action within an area based controller to another action on a different controller and **not** in an area.

  HtmlHelper syntax: `@Html.ActionLink("Go to Manage Products’  Home Page", "Index", "Home", new { area = "" })`

  TagHelper syntax: `<a asp-area="" asp-controller="Manage" asp-action="Index">Go to Manage Products’  Home Page</a>`

  Since we want to generate links to a non-area based controller action, we empty the ambient value for 'area' here.

## Publishing Areas

All `*.cshtml` and `wwwroot/**` files are published to output when `<Project Sdk="Microsoft.NET.Sdk.Web">` is included in the *.csproj* file.
