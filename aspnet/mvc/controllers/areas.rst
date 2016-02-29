Areas
=====
By `Tom Archer`

Areas provide a way to separate a large MVC application into semantically-related groups of models, views, and controllers. Let's take a look at an example to illustrate how Areas are created and used. Let's say you have a store app that has two distinct groupings of controllers and views: Products and Services.

Instead of having all of the controllers located under the Controllers parent directory, and all the views located under the Views parent directory, you could use Areas to group your views and controllers according to the area (or logical grouping) with which they're associated.

- Project name

  - Areas

    - Products

      - Controllers

        - HomeController.cs

      - Views

        - Home

          - Index.cshtml

    - Services

      - Controllers

        - HomeController.cs

      - Views

        - Home

          - Index.cshtml

Looking at the preceding directory hierarchy example, there are a few guidelines to keep in mind when defining areas:

- A directory called *Areas* must exist as a child directory of the project.
- The *Areas* directory contains a subdirectory for each of your project's areas (*Products* and *Services*, in this example).
- Your controllers should be located as follows:
  ``/Areas/[area]/Controllers/[controller].cs``
- Your views should be located as follows:
  ``/Areas/[area]/Views/[controller]/[action].cshtml``

Note that if you have a view that is shared across controllers, it can be located in either of the following locations:

- ``/Areas/[area]/Views/Shared/[action].cshtml``
- ``/Views/Shared/[action].cshtml``

Once you've defined the folder hierarchy, you need to tell MVC that each controller is associated with an area. You do that by decorating the controller name with the ``[Area]`` attribute.

.. code-block:: c#
  :emphasize-lines: 4

  ...
  namespace MyStore.Areas.Products.Controllers
  {
      [Area("Products")]
      public class HomeController : Controller
      {
          // GET: /<controller>/
          public IActionResult Index()
          {
              return View();
          }
      }
  }

The final step is to set up a route definition that works with your newly created areas. The :doc:`routing` article goes into detail about how to create route definitions, including using conventional routes versus attribute routes. In this example, we'll use a conventional route. To do so, simply open the ``Startup.cs`` file and modify it by adding the highlighted route definition below.

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

Linking between areas
---------------------

To link between areas, you simply specify the area in which the controller is defined. If the controller is not a part of an area, use an empty string.

The following snippet shows how to link to a controller action that is defined within an area named *Products*.

.. code-block:: c#

  @Html.ActionLink("See Products Home Page", "Index", "Home", new { area = "Products" }, null)

To link to a controller action that is not part of an area, simply specify an empty string for the area.

.. code-block:: c#

  @Html.ActionLink("Go to Home Page", "Index", "Home", new { area = "" }, null)

Summary
-------
Areas are a very useful tool for grouping semantically-related controllers and actions under a common parent folder. In this article, you learned how to set up your folder hierarchy to support ``Areas``, how to specify the ``[Area]`` attribute to denote a controller as belonging to a specified area, and how to define your routes with areas.
