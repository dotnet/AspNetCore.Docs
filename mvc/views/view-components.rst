View Components
======================================================

By `Rick Anderson`_

.. contents:: In this article:
  :local:
  :depth: 1

Introducing view components
---------------------------

New to ASP.NET MVC 6, view components are similar to partial views, but they are much more powerful. View components include the same separation-of-concerns and testability benefits found between a controller and view. A view component is responsible for rendering a chunk rather than a whole response. You can use view components to solve any problem that you feel is too complex with a partial, such as:  

- Dynamic navigation menus
- Tag cloud (where it queries the database)
- Login panel
- Shopping cart
- Recently published articles
- Sidebar content on a typical blog 
 
One use of a view component could be to create a login panel that would be displayed on every page with the following functionality:

- If the user is not logged in, a login panel is rendered.
- If the user is logged in, links to log out and manage account are rendered.
- If the user is in the admin role, an admin panel is rendered.

You can also create a view component that gets and renders data depending on the user's claims. You can add this view component view to the layout page and have it get and render user-specific data throughout the whole application. View components don’t use model binding, and only depend on the data you provide when calling into it. 

A view component consists of two parts, the class (typically derived from  ``ViewComponent``) and the Razor view which calls methods in the view component class. Like controllers, a view component can be a POCO, but most users will want to take advantage of the methods and properties available by deriving from ``ViewComponent``.

A view component class can be created by any of the following:

- Deriving from `ViewComponent`.
- Decorating the class with the ``[ViewComponent]`` attribute, or deriving from a class with the ``[ViewComponent]`` attribute.
- Creating a class where the name ends with the suffix *ViewComponent*.

Like controllers, view components must be public, non-nested, non-abstract classes.

Examine the ViewComponent class
--------------------------------

- Examine the *src\\TodoList\\ViewComponents\\PriorityListViewComponent.cs* file:

  .. code-block:: c#
    :linenos:

    using System.Linq;
    using Microsoft.AspNet.Mvc;
    using TodoList.Models;

    namespace TodoList.ViewComponents
    {
      public class PriorityListViewComponent : ViewComponent
      {
        private readonly ApplicationDbContext db;

        public PriorityListViewComponent(ApplicationDbContext context)
        {
          db = context;
        }

        public IViewComponentResult Invoke(int maxPriority)
        {
          var items = db.TodoItems.Where(x => x.IsDone == false &&
              x.Priority <= maxPriority);

          return View(items);
        }
      }
    }

Notes on the code: 

- View component classes can be contained in **any** folder in the project.
- Because the class name ``PriorityListViewComponent`` ends with the suffix **ViewComponent**, the runtime will use the string "PriorityList" when referencing the class component from a view. I'll explain that in more detail later. 
- The ``[ViewComponent]`` attribute can change the name used to reference a view component. For example, we could have named the class ``XYZ``,  and  applied the  ``ViewComponent`` attribute:

  .. code-block:: c#
    :linenos:
    
    [ViewComponent(Name = "PriorityList")]
    public class XYZ : ViewComponent

- The ``[ViewComponent]`` attribute above tells the view component selector to use the name ``PriorityList`` when looking for the views associated with the component, and to use the string "PriorityList" when referencing the class component from a view. I'll explain that in more detail later. 
- The component uses constructor injection to make the data context available. 
- ``Invoke`` exposes a method which can be called from a view, and it can take an arbitrary number of arguments. An asynchronous version, ``InvokeAsync``, is available. We'll see ``InvokeAsync`` and multiple arguments later in the tutorial. In the code above, the ``Invoke`` method returns the set of *ToDoItems* that are not completed and have priority greater than or equal to ``maxPriority``.

Examine the view component view
-------------------------------

1. Examine the contents of the *Views\\Todo\\Components*. This folder **must** be named *Components*.

.. note:: View Component views are more typically added to the *Views\\Shared\\Components* folder, because view components are typically not controller specific.

2. Examine the *Views\\Todo\\Components\\PriorityList* folder. This folder name must match the name of the view component class, or the name of the class minus the suffix (if we followed convention and used the *ViewComponent* suffix in the class name). If you used the ``ViewComponent`` attribute, the folder name would need to match the attribute designation. 
3. Examine the *Views\\Todo\\Components\\PriorityList\\Default.cshtml* Razor view. 

  .. code-block:: html
    :linenos:
    
    @model IEnumerable<TodoList.Models.TodoItem>

    <h3>Priority Items</h3>
    <ul>
      @foreach (var todo in Model)
      {
        <li>@todo.Title</li>
      }
    </ul>

  The Razor view takes a list of ``TodoItems`` and displays them. If the view component ``invoke`` method doesn't pass the name of the view (as in our sample),  *Default* is used for the view name by convention. Later in the tutorial, I'll show you how to pass the name of the view.

4. Add a ``div`` containing a call to the priority list component to the bottom of the *views\\todo\\index.cshtml* file:

  .. code-block:: html
    :linenos:
    :emphasize-lines: 5
    
    @* Markup removed for brevity *@
    <div>@Html.ActionLink("Create New Todo", "Create", "Todo") </div>
    <div>
      <div class="col-md-4">
        @Component.Invoke("PriorityList", 1)
      </div>
    </div>

  The markup ``@Component.Invoke`` shows the syntax for calling view components. The first argument is the name of the component we want to invoke or call. Subsequent parameters are passed to the component. In this case, we are passing "1" as the priority we want to filter on. ``Invoke`` and ``InvokeAsync`` can take an arbitrary number of arguments.

The following image shows the priority items:  (make sure you have at least one priority 1 item that is not completed)

.. image:: view-components/_static/pi.png

Add InvokeAsync to the priority view component
----------------------------------------------

Update the priority view component class with the following code:

.. note:: ``IQueryable`` renders the sample synchronous, not asynchronous. This is a simple example of how you could call asynchronous methods.

.. code-block:: c#
  :linenos:
   
  using System.Threading.Tasks;
  
  public class PriorityListViewComponent : ViewComponent
  {
    private readonly ApplicationDbContext db;
  
    public PriorityListViewComponent(ApplicationDbContext context)
    {
      db = context;
    }
  
    // Synchronous Invoke removed.
  
    public async Task<IViewComponentResult> InvokeAsync(int maxPriority, bool isDone)
    {
      var items = await GetItemsAsync(maxPriority, isDone);
      return View(items);
    }
  
    private Task<IQueryable<TodoItem>> GetItemsAsync(int maxPriority, bool isDone)
    {
      return Task.FromResult(GetItems(maxPriority, isDone));
    }
    private IQueryable<TodoItem> GetItems(int maxPriority, bool isDone)
    {
      var items = db.TodoItems.Where(x => x.IsDone == isDone &&
          x.Priority <= maxPriority);
  
      string msg = "Priority <= " + maxPriority.ToString() +
             " && isDone == " + isDone.ToString();
      ViewBag.PriorityMessage = msg;
  
      return items;
    }
  }

Update the view component Razor view (*TodoList\\src\\TodoList\\Views\\ToDo\\Components\\PriorityList\\Default.cshtml*) to show the priority message :

.. code-block:: html
  :linenos:
  :emphasize-lines: 3
  
  @model IEnumerable<TodoList.Models.TodoItem>

  <h4>@ViewBag.PriorityMessage</h4>
  <ul>
    @foreach (var todo in Model)
    {
      <li>@todo.Title</li>
    }
  </ul>

Finally, update the  *views\\todo\\index.cshtml* view:

.. code-block:: html
  :linenos:
  :emphasize-lines: 4

  @* Markup removed for brevity. *@
  <div class="col-md-4">
      @await Component.InvokeAsync("PriorityList", 2, true)
  </div>


The following image reflects the changes we made to the priority view component and Index view:

.. image:: view-components/_static/p2.png

Specifying a view name
----------------------

A complex view component might need to specify a non-default view under some conditions. The following shows how to specify the "PVC" view  from the  ``InvokeAsync`` method: Update the ``InvokeAsync`` method in the ``PriorityListViewComponent`` class.

.. code-block:: c#
  :linenos:
  
  public async Task<IViewComponentResult> InvokeAsync(int maxPriority, bool isDone)
  {
    string MyView = "Default";
    // If asking for all completed tasks, render with the "PVC" view.
    if (maxPriority > 3 && isDone == true)
    {
      MyView = "PVC";
    }
    var items = await GetItemsAsync(maxPriority, isDone);
    return View(MyView, items);
  }

Examine the *Views\\Todo\\Components\\PriorityList\\PVC.cshtml* view. I changed the PVC view to verify it's being used:

.. code-block:: html
  :linenos:
  :emphasize-lines: 3

  @model IEnumerable<TodoList.Models.TodoItem>

  <h2> PVC Named Priority Component View</h2>
  <h4>@ViewBag.PriorityMessage</h4>
  <ul>
    @foreach (var todo in Model)
    {
      <li>@todo.Title</li>
    }
  </ul>

Finally, update *Views\\Todo\Index.cshtml*

.. code-block:: c#
  :linenos:

  @await Component.InvokeAsync("PriorityList",  4, true)

Run the app and click on the PVC link (or navigate to localhost:<port>/Todo/IndexFinal). Refresh the page to see the PVC view.

.. image:: view-components/_static/pvc.png

