View Components in MVC Core
============================

By `Rick Anderson`_ 

.. contents:: Sections:
  :local:
  :depth: 1

`View or download sample on GitHub <https://github.com/aspnet/Docs/tree/master/mvc/views/view-components/sample>`__.

Introducing view components
---------------------------

New to ASP.NET MVC Core, view components are similar to partial views, but they are much more powerful. A View component:

- Renders a chunk rather than a whole response
- Includes the same separation-of-concerns and testability benefits found between a controller and view
- Can have parameters and business logic
- Is typically invoked from a layout page

View Components are intended anywhere you have reusable rendering logic that is too complex for a partial view, such as: 

- Dynamic navigation menus
- Tag cloud (where it queries the database)
- Login panel
- Shopping cart
- Recently published articles
- Sidebar content on a typical blog 
 
One use of a view component could be to create a login panel that would be displayed on every page with the following functionality:

- If the user is not logged in, a login panel is rendered
- If the user is logged in, links to log out and manage account are rendered
- If the user is in the admin role, an admin panel is rendered

The view component ``User`` property gives you access to a user's claims, so you can render data depending on the user's claims. You can add this view component view to the layout page and have it render user-specific data throughout the whole application. View components don’t use model binding, and only depend on the data you provide when calling into it. 

A view component consists of two parts, the class (typically derived from  ``ViewComponent``) and the Razor view which calls methods in the view component class). Like controllers, a view component can be a POCO, but most developers will want to take advantage of the methods and properties available by deriving from ``ViewComponent``.

See `ViewComponent properties <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNet/Mvc/ViewComponent/index.html#properties>`__ and `ViewComponent Class <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNet/Mvc/ViewComponent/index.html>`__.

Creating a view component
---------------------------

This section contains the high level requirements to create a view component. Later in the article we'll examine each step in detail and create a view component.

The view component class
^^^^^^^^^^^^^^^^^^^^^^^^^^

A view component class can be created by any of the following:

- Deriving from `ViewComponent`
- Decorating a class with the ``[ViewComponent]`` attribute, or deriving from a class with the ``[ViewComponent]`` attribute
- Creating a class where the name ends with the suffix *ViewComponent*

Like controllers, view components must be public, non-nested, and non-abstract classes.

View component methods
^^^^^^^^^^^^^^^^^^^^^^^^^^

- Contain ``Invoke`` or ``InvokeAsync`` methods that return an ``IViewComponentResult``
- Fully support constructor `Dependency Injection <https://docs.asp.net/en/latest/fundamentals/dependency-injection.html>`__
- Typically initialize a model and pass it to a view by calling the ``ViewComponent`` ``View`` method. 
- Parameters come from the calling method, not HTTP, there is no model binding. This allows you to overload ``Invoke``/``InvokeAsync``  (which you can't do with controllers).
- Do not take part in the controller lifecycle, which means you can't use action filters in a view component
- Are not reachable directly as an HTTP endpoint, they are invoked from your code (usually in a view). A View Component never handles a request.
- Are overloaded on the signature rather than any details from the current HTTP request

View search path
^^^^^^^^^^^^^^^^^^

- The default view name is *Default.cshtml*
- The runtime searches for the view in the following paths:

  - Views/<controller_name>/Components/<view_component_name>
  - Views/Shared/Components/<view_component_name>

Invoking a view component
^^^^^^^^^^^^^^^^^^^^^^^^^^^

To use the view component, call the synchronous ``@Component.Invoke("Name of View Component", <parameters>)`` or asynchronous ``@Component.InvokeAsync("Name of View Component", <parameters>)`` from a view. The parameters will be passed to the ``Invoke`` or ``InvokeAsync`` method with a matching signature.  The ``PriorityList`` view component developed in the article is invoked from the *Views/TodoItems/Index.cshtml* view file. In this example the synchronous ``Invoke`` method is called and 3 is passed to the view component:

.. code-block:: HTML

   @Component.Invoke("PriorityList", 3)

In the following, the ``InvokeAsync`` method is called with two parameters:

.. code-block:: HTML

   @await Component.InvokeAsync("PriorityList", 2, false)
   
In this example, the view component is called directly from the controller:

.. code-block:: c#

     public IActionResult IndexVC()
     {
         return ViewComponent("PriorityList", 3);
     }


Creating the starter sample
---------------------------

#. Create a new ASP.NET 5 Web app with authentication set to **Individual User Accounts**. You must name the new project "TodoList" so the namespaces match the code in this tutorial.  

#. Add the following ``TodoItem`` model to the *Models* folder.

.. literalinclude:: view-components/sample/TodoList/src/TodoList/Models/TodoItem.cs
 :language: c#

3. Scaffold a new MVC 6 controller with views using Entity Framework using the ``TodoItem`` model. See :doc:`Getting started with ASP.NET MVC Core </getting-started/first-mvc-app/start-mvc>` for scaffolding information. 
 
Add a ViewComponent class
----------------------------

Create a *ViewComponents* folder and add the following ``PriorityListViewComponent`` class.

.. literalinclude:: view-components/sample/TodoList/src/TodoList/ViewComponents/PriorityListViewComponent.cs
 :language: c#
 :lines: 4-27
 :linenos:

Notes on the code: 

- View component classes can be contained in **any** folder in the project.
- Because the class name ``PriorityListViewComponent`` ends with the suffix **ViewComponent**, the runtime will use the string "PriorityList" when referencing the class component from a view. I'll explain that in more detail later. 
- The ``[ViewComponent]`` attribute can change the name used to reference a view component. For example, we could have named the class ``XYZ``,  and  applied the  ``ViewComponent`` attribute:

  .. code-block:: c#
    
    [ViewComponent(Name = "PriorityList")]
    public class XYZ : ViewComponent

- The ``[ViewComponent]`` attribute above tells the view component selector to use the name ``PriorityList`` when looking for the views associated with the component, and to use the string "PriorityList" when referencing the class component from a view. I'll explain that in more detail later. 
- The component uses `Dependency Injection <https://docs.asp.net/en/latest/fundamentals/dependency-injection.html>`__ to make the data context available. 
- ``Invoke`` exposes a method which can be called from a view, and it can take an arbitrary number of arguments. An asynchronous version, ``InvokeAsync``, is available. We'll see ``InvokeAsync`` and multiple arguments later in the tutorial. 
- The ``Invoke`` method returns the set of *ToDoItems* that are not completed and have priority lower than or equal to ``maxPriority``.

Create the view component Razor view
--------------------------------------

#. Create the *Views/TodoItems/Components* folder. This folder **must** be named *Components*.

.. note:: View Component views are more typically added to the *Views/Shared/Components* folder, because view components are typically not controller specific.

2. Create the *Views/TodoItems/Components/PriorityList* folder. This folder name must match the name of the view component class, or the name of the class minus the suffix (if we followed convention and used the *ViewComponent* suffix in the class name). If you used the ``ViewComponent`` attribute, the class name would need to match the attribute designation.
3. Create a *Views/TodoItems/Components/PriorityList/Default.cshtml* Razor view. 

.. literalinclude:: view-components/sample/TodoList/src/TodoList/Views/TodoItems/Components/PriorityList/Default1.cshtml
 :language: html 

The Razor view takes a list of ``TodoItems`` and displays them. If the view component ``invoke`` method doesn't pass the name of the view (as in our sample),  *Default* is used for the view name by convention. Later in the tutorial, I'll show you how to pass the name of the view. If the view component was not controller specific, you would add it to the shared folder (*Views/Shared/Components/PriorityList/Default.cshtml*).

4. Add a ``div`` containing a call to the priority list component to the bottom of the *views/TodoItems/index.cshtml* file:

.. literalinclude:: view-components/sample/TodoList/src/TodoList/Views/TodoItems/Index1.cshtml
  :language: html
  :linenos:
  :lines: 44-

The markup ``@Component.Invoke`` shows the syntax for calling view components. The first argument is the name of the component we want to invoke or call. Subsequent parameters are passed to the component. In this case, we are passing "3" as the priority we want to filter on. ``Invoke`` and ``InvokeAsync`` can take an arbitrary number of arguments. 

The following image shows the priority items:  (make sure you have at least one priority 3 or lower item that is not completed)

.. image:: view-components/_static/pi.png

You can also call the view component directly from the controller:

.. literalinclude:: view-components/sample/TodoList/src/TodoList/Controllers/TodoItemsController.cs
  :language: c#
  :lines: 26-29
  :dedent: 6

Add InvokeAsync to the priority view component
----------------------------------------------

Replace the priority view component class with the following code:

.. literalinclude:: view-components/sample/TodoList/src/TodoList/ViewComponents/PriorityListViewComponentAsync.cs
  :language: c#
  :lines: 4-45

.. note:: ``IEnumerable`` or ``IQueryable`` renders the code synchronous, not asynchronous. This is a simple example of how you could call asynchronous methods.

Update the Razor view component(*TodoList/src/TodoList/Views/TodoList/Components/PriorityList/Default.cshtml*) to show the priority message:

.. literalinclude:: view-components/sample/TodoList/src/TodoList/Views/TodoItems/Components/PriorityList/Default.cshtml
 :language: html
 
Update the  *views/TodoList/index.cshtml* view:  

.. literalinclude:: view-components/sample/TodoList/src/TodoList/Views/TodoItems/Index.cshtml
  :language: html
  :linenos:
  :lines: 44-  

The following image reflects the changes we made to the priority view component and Index view:

.. image:: view-components/_static/p2.png

Specifying a view name
----------------------

A complex view component might need to specify a non-default view under some conditions. The following code shows how to specify the "PVC" view  from the ``InvokeAsync`` method. Update the ``InvokeAsync`` method in the ``PriorityListViewComponent`` class.

.. literalinclude:: view-components/sample/TodoList/src/TodoList/ViewComponents/PriorityListViewComponentFinal.cs
  :language: c#
  :linenos:
  :lines: 23-34
  :dedent: 8
  :emphasize-lines: 4-9

Copy the *Views/TodoItems/Components/PriorityList/Default.cshtml* Razor view to a view named *Views/TodoList/Components/PriorityList/PVC.cshtml* view. Add a heading to indicate the PVC view is being used. 

.. literalinclude:: view-components/sample/TodoList/src/TodoList/Views/TodoItems/Components/PriorityList/PVC.cshtml
  :language: html
  :linenos:
  :emphasize-lines: 3
  
Update *Views/TodoList/Index.cshtml*

.. literalinclude:: view-components/sample/TodoList/src/TodoList/Views/TodoItems/IndexFinal.cshtml
  :language: html
  :linenos:
  :lines: 46-

Run the app and verify PVC view.

.. image:: view-components/_static/pvc.png

If the PVC view is not rendered, verify you are calling the view component with a priority of 4 or higher.

Examine the view path
----------------------------------------------

#. Change the priority parameter to three or less so the priority view is not returned. 
#. Temporarily rename the *Views/TodoItems/Components/PriorityList/Default.cshtml* to *Temp.cshtml*.
#. Test the app, you'll get the following error::

    An unhandled exception occurred while processing the request.

    InvalidOperationException: The view 'Components/PriorityList/Default' 
       was not found. The following locations were searched:
          /Views/TodoItems/Components/PriorityList/Default.cshtml
          /Views/Shared/Components/PriorityList/Default.cshtml.
    Microsoft.AspNet.Mvc.ViewEngines.ViewEngineResult.EnsureSuccessful()

4. Copy the *Views/TodoItems/Components* directory to the *Views/Shared* folder. 
5. Rename *Views/Shared/Components/PriorityList/Temp.cshtml* to *Views/Shared/Components/PriorityList/Default.cshtml*.
6. Add some markup to the shared view component views to indicate the view is from the shared folder.
7. Test the shared component view.
    
.. image:: view-components/_static/shared.png

Avoiding magic strings
^^^^^^^^^^^^^^^^^^^^^^^^^^

If you want compile time safety you can replace the hard coded View Component name with the class name. Create the View Component without the "ViewComponent" suffix:

.. code-block:: c#

    public class PriorityList : ViewComponent

Add a ``using`` statement to your Razor view file and use the ``nameof`` operator:

.. code-block:: HTML

   @using TodoList.ViewComponents;
   
   await Component.InvokeAsync(nameof(PriorityList), 4, true)


Additional Resources
--------------------

- :doc:`/views/dependency-injection`