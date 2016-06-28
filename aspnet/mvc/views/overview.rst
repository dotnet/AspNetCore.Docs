Views Overview
==============

By `Steve Smith`_

ASP.NET MVC Core controllers can return formatted results using *views*.

.. contents:: Sections
  :local:
  :depth: 1

What are Views?
---------------

In the Model-View-Controller (MVC) pattern, the *view* encapsulates the presentation details of the user's interaction with the app. Views are HTML templates with embedded code that generate content to send to the client. Views use :doc:`razor syntax <razor>`, which allows code to interact with HTML with minimal code or ceremony.

ASP.NET Core MVC views are *.cshtml* files stored by default in a *Views* folder within the application. Typically, each controller will have its own folder, in which are views for specific controller actions. 

.. image:: overview/_static/views_solution_explorer.png
  :height: 100
  :width: 200

In addition to action-specific views, :doc:`partial views <partial>`, :doc:`layouts, and other special view files <layout>` can be used to help reduce repetition and allow for reuse within the app's views.

Benefits of Using Views
-----------------------

Views provide `separation of concerns <http://deviq.com/separation-of-concerns/>`_ within an MVC app, encapsulating user interface level markup separately from business logic. ASP.NET MVC views use :doc:`razor syntax <razor>` to make switching between HTML markup and server side logic painless. Common, repetitive aspects of the app's user interface can easily be reused between views using :doc:`layout and shared directives <layout>` or :doc:`partial views <partial>`.

:doc:`Tag helpers <tag-helpers/intro>` make it easy to add server-side behavior to existing HTML tags, avoiding the need to use custom code or helpers within views. Tag helpers are applied as attributes to HTML elements, which are ignored by editors that aren't familiar with them, allowing view markup to be edited and rendered in a variety of tools. Tag helpers have many uses, and in particular can make :doc:`working with forms <working-with-forms>` much easier.

Generating custom HTML markup can be achieved with many built-in :doc:`HTML Helpers <html-helpers>`, and more complex UI logic (potentially with its own data requirements) can be encapsulated in :doc:`view-components`. View components provide the same separation of concerns that controllers and views offer, and can eliminate the need for actions and views to deal with data used by common UI elements.

Like many other aspects of ASP.NET Core, views support :doc:`dependency injection </fundamentals/dependency-injection>`, allowing services to be :doc:`injected into views <dependency-injection>`.

Creating a View
---------------

Views that are specific to a controller are created in the *Views/[ControllerName]* folder. Views that are shared among controllers are placed in the */Views/Shared* folder. Name the view file the same as its associated controller action, and add the *.cshtml* file extension. For example, to create a view for the *About* action on the *Home* controller, you would create the *About.cshtml* file in the */Views/Home* folder.

A sample view file:

.. literalinclude:: ../../../common/samples/WebApplication1/src/WebApplication1/Views/Home/About.cshtml
   :language: html

*Razor* code is denoted by the ``@`` symbol. C# statements are run within Razor code blocks set off by curly braces (``{`` ``}``), such as the assignment of "About" to the ``ViewData["Title"]`` element shown above. Razor can be used to display values within HTML by simply referencing the value with the ``@`` symbol, as shown within the ``<h2>`` and ``<h3>`` elements above.

This view focuses on just the portion of the output for which it is responsible. The rest of the page's layout, and other common aspects of the view, are specified elsewhere. Learn more about :doc:`layout and shared view logic <layout>`.

How do Controllers Specify Views?
---------------------------------

Views are typically returned from actions as a :dn:cls:`~Microsoft.AspNetCore.Mvc.ViewResult`. Your action method can create and return a ``ViewResult`` directly, but more commonly if your controller inherits from :dn:cls:`~Microsoft.AspNetCore.Mvc.Controller`, you'll simply use the ``View`` helper method, as this example demonstrates:

.. literalinclude:: /../common/samples/WebApplication1/src/WebApplication1/Controllers/HomeController.cs
  :language: c#
  :lines: 9-14
  :emphasize-lines: 5
  :dedent: 4
  
The ``View`` helper method has several overloads to make returning views easier for app developers. You can optionally specify a specific view to return, as well as a model to pass to the view. With no parameters, the default convention of using a view name that corresponds to the action name is used.

View Discovery
^^^^^^^^^^^^^^

When an action returns a view, a process called *view discovery* takes place. This process determines which view file will be used. There are several scenarios, based on how the view was specified from the action method.

``return View();``
    The most common approach. In this case the framework will use a view with the same name as the action (with a *.cshtml* extension) located in a folder named the same as the controller. Otherwise, it will look in the *Shared* folder for a view with a name corresponding to the action name.

``return View("List");``
    Using this syntax, a view with the provided name (and a *.cshtml* extension) is used instead of the current action name. Otherwise, the behavior is as above.

``return View("Views/Home/About.cshtml");``
    Specify the path from the application root to the view. Using this syntax, the *.cshtml* extension must be specified. The path can optionally start with "/" or "~/".

.. note:: :doc:`Partial views <partial>` and :doc:`view components <view-components>` use similar (but not identical) discovery mechanisms.

.. note:: You can customize the default convention regarding where views are located within the app by using a custom :dn:iface:`~Microsoft.AspNetCore.Mvc.Razor.IViewLocationExpander`.

.. tip:: View names may be case sensitive depending on the underlying file system. For compatibility across operating systems, always match case between controller and action names and associated view folders and filenames.

Passing Data to Views
^^^^^^^^^^^^^^^^^^^^^

You can pass data to views using several mechanisms. The most robust approach is to specify a *model* type in the view, and then pass an instance of this type to the view from the action. We recommend you use a model or view model to pass data to a view. This allows the view to take advantage of strong type checking.

Data can be passed to a view with ``ViewData``, a dictionary collection that both views and controllers can access and modify. The ``ViewBag`` type provides a dynamic view over the ``ViewData``. Learn more about :doc:`dynamic and strongly typed views <dynamic-vs-static>`.
  


