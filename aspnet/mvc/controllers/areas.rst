Areas
=====

By `Tom Archer`

Areas provide a way to separate a large MVC application into semantically-related groups of models, views, and controllers. 

Instead of having all of the controllers located under the Controllers parent directory, and all the views located under the Views parent directory, you could use Areas to group your views and controllers according to the area (or logical grouping) with which they're associated.

Let's take a look at an example to illustrate how Areas are created and used. Let's say you have a store app that has two distinct groupings of controllers and views: Products and Services. A typical folder structure for that using MVC areas looks like below:

- Project name

  - Areas

    - Products

      - Controllers

        - HomeController.cs

        - ManageController.cs

      - Views

        - Home

          - Index.cshtml

        - Manage

          - Index.cshtml

    - Services

      - Controllers

        - HomeController.cs

      - Views

        - Home

          - Index.cshtml

When MVC tries to render a view in an Area, by default, it tries to look in the following locations:

.. code-block:: txt

  /Areas/<Area-Name>/Views/<Controller-Name>/<Action-Name>.cshtml
  /Areas/<Area-Name>/Views/Shared/<Action-Name>.cshtml
  /Views/Shared/<Action-Name>.cshtml

These are the default locations which can be changed via the ``AreaViewLocationFormats`` on the ``Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions``.

For example, in the below code instead of having the folder name as 'Areas', it has been changed to 'Categories'.

.. code-block:: c#

  services.Configure<RazorViewEngineOptions>(options =>
  {
      options.AreaViewLocationFormats.Clear();
      options.AreaViewLocationFormats.Add("/Categories/{2}/Views/{1}/{0}.cshtml");
      options.AreaViewLocationFormats.Add("/Categories/{2}/Views/Shared/{0}.cshtml");
      options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
  });

One thing to note is that the structure of the ``Views`` folder is the only one which is considered important here and the content of the rest of the folders like 'Controllers' and 'Models' does **not** matter. So for example, you need not have a 'Controllers' and 'Models' folder at all. This works because the content of 'Controllers' and 'Models' is just code which gets compiled into a .dll where as the content of the 'Views' is not until a request to that view has been made.

Once you've defined the folder hierarchy, you need to tell MVC that each controller is associated with an area. You do that by decorating the controller name with the ``[Area]`` attribute.

.. code-block:: c#
  :emphasize-lines: 4

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

The final step is to set up a route definition that works with your newly created areas. The :doc:`routing` article goes into detail about how to create route definitions, including using conventional routes versus attribute routes. In this example, we'll use a conventional route. To do so, simply open the *Startup.cs* file and modify it by adding the highlighted route definition below.

.. code-block:: c#
  :emphasize-lines: 4-6

  ...
  app.UseMvc(routes =>
  {
    routes.MapRoute(name: "areaRoute",
      template: "{area:exists}/{controller=Home}/{action=Index}");

    routes.MapRoute(
        name: "default",
        template: "{controller=Home}/{action=Index}");
  });

Now, when the user browses to *http://<yourApp>/products*, the ``Index`` action method of the ``HomeController`` in the ``Products`` area will be invoked.

Link Generation
---------------
- Generating links from an action within an area based controller to another action within the same controller.

  Let's say the current request's path is like ``/Products/Home/Create``

  HtmlHelper syntax:
  ``@Html.ActionLink("Go to Product's Home Page", "Index")``

  TagHelper syntax:
  ``<a asp-action="Index">Go to Product's Home Page</a>``

  Note that we need not supply the 'area' and 'controller' values here as they are already available in the context of the current request. These kind of values are called ``ambient`` values.

- Generating links from an action within an area based controller to another action on a different controller

  Let's say the current request's path is like ``/Products/Home/Create``

  HtmlHelper syntax:
  ``@Html.ActionLink("Go to Manage Products's Home Page", "Index", "Manage")``

  TagHelper syntax:
  ``<a asp-controller="Manage" asp-action="Index">Go to Manage Products's Home Page</a>``

  Note that here the ambient value of an 'area' is used but the 'controller' value is specified explicitly above.

- Generating links from an action within an area based controller to another action on a different controller and a different area.

  Let's say the current request's path is like ``/Products/Home/Create``

  HtmlHelper syntax:
  ``@Html.ActionLink("Go to Services's Home Page", "Index", "Home", new { area = "Services" })``

  TagHelper syntax:
  ``<a asp-area="Services" asp-controller="Home" asp-action="Index">Go to Services's Home Page</a>``

  Note that here no ambient values are used.

- Generating links from an action within an area based controller to another action on a different controller and **not** in an area.

  HtmlHelper syntax:
  ``@Html.ActionLink("Go to Manage Products's Home Page", "Index", "Home", new { area = "" })``

  TagHelper syntax:
  ``<a asp-area="" asp-controller="Manage" asp-action="Index">Go to Manage Products's Home Page</a>``

  Since we want to generate links to a non-area based controller action, we empty the ambient value for 'area' here.

Summary
-------
Areas are a very useful tool for grouping semantically-related controllers and actions under a common parent folder. In this article, you learned how to set up your folder hierarchy to support ``Areas``, how to specify the ``[Area]`` attribute to denote a controller as belonging to a specified area, and how to define your routes with areas.
