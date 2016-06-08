Partial Views
=============

By `Steve Smith`_

ASP.NET Core MVC supports partial views, which are useful when you have reusable parts of web pages you want to share between different views.

.. contents:: Sections:
  :local:
  :depth: 1

`View or download sample code <https://github.com/aspnet/Docs/tree/master/aspnet/mvc/views/partial/sample>`__

What are Partial Views?
-----------------------

A partial view is a view that is rendered within another view. Typically they render a block of HTML that can be safely inserted within one or more parent views. The partial view is built up at runtime by the :doc:`razor engine <razor>` within the parent view that contains it. Like views, partial views use the *.cshtml* file extension.

.. note:: If you're coming from an ASP.NET Web Forms background, partial views are similar to `user controls <https://msdn.microsoft.com/en-us/library/y6wb1a0e.aspx>`_.

When Should I Use Partial Views?
--------------------------------

Partial views are an effective way of breaking up large views into smaller components, either for reuse or simply to make them easier to manage. If you have a complex page made up of several logical sections, it can be helpful to work with each section as its own partial view. Each section of the page can be viewed in isolation from the rest of the page, and the view for the page itself becomes much simpler since it only contains the overall page structure and calls to render the partial views.

Another common use case for partial views is reusable view content. Common layout elements should be specified in :doc:`layout.cshtml <layout>`, but non-layout reusable content can be encapsulated into partial views, reducing duplication within your views.

.. tip:: Try to follow the `Don't Repeat Yourself Principle <http://deviq.com/don-t-repeat-yourself/>`_ in your views, as well as in your code.

Declaring Partial Views
-----------------------

Partial views are created identically to regular views. Simply create a new *.cshtml* file and place it somewhere under your *Views* folder. There is no structural difference between a partial view and a regular view - it's just a difference in how they are rendered. If you want, you can have a regular view that is returned as part of controller's ``ViewResult``, and which is also included in other views as a partial view. The main difference between how a view and a partial view are rendered is that partial views do not run *_ViewStart* (while views do - learn more about *_ViewStart* in :doc:`layout`).

Referencing a Partial View
--------------------------

From within a view page, there are several ways in which you can bring in a partial view. The simplest is to use ``Html.Partial``, which returns an ``IHtmlString`` and can be referenced by simply prefixing the call with ``@``:

.. literalinclude:: partial/sample/src/PartialViewsSample/Views/Home/About.cshtml
  :lines: 9

You can also render partial views asynchronously using ``PartialAsync``:

.. literalinclude:: partial/sample/src/PartialViewsSample/Views/Home/About.cshtml
  :lines: 8

A third way to render partial views is to call directly to ``RenderPartial``. This method doesn't return a result, it streams the rendered output directly to the response. Because it doesn't return a result, it must be called within a razor code block. You can also call its async equivalent, as shown here:

.. literalinclude:: partial/sample/src/PartialViewsSample/Views/Home/About.cshtml
  :lines: 10-13

Because it streams the result directly, ``RenderPartial``/``RenderPartialAsync`` may perform better in some scenarios. However, in most cases it's recommended you use ``Render`` or ``RenderAsync``.

.. note:: If your views need to execute code, the recommended pattern is to use a :doc:`view component <view-components>` instead of a partial view.

Partial View Discovery
^^^^^^^^^^^^^^^^^^^^^^

When referencing a partial view, you can refer to its location in several ways:

.. code-block:: text

  // uses a view in current folder with this name
  // if none is found, searches the Shared folder
  @Html.Partial("ViewName")

  // a view with this name must be in the same folder
  @Html.Partial("ViewName.cshtml")
  
  // locate the view based on the application root
  // Paths start with "/" or "~/" refer to same location
  @Html.Partial("~/Views/Folder/ViewName.cshtml")
  @Html.Partial("/Views/Folder/ViewName.cshtml")
  
  // locate the view using relative paths
  @Html.Partial("../Account/LoginPartial.cshtml")

If desired, you can have different partial views with the same name in different view folders. When referencing the views by name (without file extension), views in each folder will use the partial view in the same folder with them. You can also specify a default partial view to use, placing it in the *Shared* folder. This view will be used by any views that don't have their own copy of the partial view in their folder.

Partial views can be *chained*. That is, you can call from one partial view to another, so long as you don't create a loop. Within each view or partial view, relative paths are always relative to that view, not the root or parent view.

.. note:: If you declare a :doc:`razor <razor>` ``section`` in a partial view, it will not be visible to its parent(s); it will be limited to the partial view.

Accessing Data From Partial Views
---------------------------------

When a partial view is instantiated, it is given its own copy of the parent view's ``ViewData`` collection. This provides the partial view with access to the parent view's data. However, updates made to the data within the partial view are not shared with the parent view - its data remains unchanged. If desired, you can pass a custom ``ViewDataDictionary`` to the partial view:

.. code-block:: c#

  @Html.Partial("PartialName", customViewData)

You can also pass a model into a partial view. This can be the page's view model, or some portion of it, or a custom object. Simply pass in the model as the second parameter when calling ``Partial``/``PartialAsync`` or ``RenderPartial``/``RenderPartialAsync:

.. code-block:: c#

  @Html.Partial("PartialName", viewModel)

If you need to pass both a custom ``ViewDataDictionary`` and a view model to a partial view, pass both with the model first:

.. code-block:: c#

  @Html.Partial("PartialName", viewModel, customViewData)

An Example
^^^^^^^^^^

The following view specifies a view model of type ``Article``. ``Article`` has an ``AuthorName`` property that is passed to an *AuthorPartial*, and a property of type ``List<ArticleSection>``, which is passed (in a loop) to a partial devoted to rendering that type:

.. literalinclude:: partial/sample/src/PartialViewsSample/Views/Articles/Read.cshtml
  :emphasize-lines: 2, 5, 10-12

The *AuthorPartial* (which in this case is in the */Views/Shared* folder):

.. literalinclude:: partial/sample/src/PartialViewsSample/Views/Shared/AuthorPartial.cshtml
  :emphasize-lines: 1

The *ArticleSection* partial:

.. literalinclude:: partial/sample/src/PartialViewsSample/Views/Articles/ArticleSection.cshtml
  :emphasize-lines: 2

At runtime, the partials are rendered into the parent view, which itself is rendered within the shared *_Layout.cshtml*, resulting in output like this:

.. image:: partial/_static/output.png


