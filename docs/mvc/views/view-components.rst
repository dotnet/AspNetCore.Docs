View Components in MVC 6
======================================================

By `Rick Anderson`_ | Updated : 21 May 2015 

.. _`Rick Anderson`: Author_

In this article:
	- `Create a new ASP.NET 5 starter project`_
	- `Run EF migrations`_
	- `Introducing view components`_
	- `Adding a view component class`_
	- `Adding a view component view`_
	- `Add InvokeAsync to the priority component`_
	- `Specifying a view name`_
	- `Injecting a service into a view`_
	- `Publish to Azure`_
	- `Addition Resources`_
	
Create a new ASP.NET 5 starter project  
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Start Visual Studio 2015. From the **File** menu  :menuselection:`click New --> Project`.
 
In the **New Project dialog**, 
:menuselection:`click Templates --> Visual C# --> Web --> ASP.NET Web Application project template`.
Name the project "TodoList" and click **OK**.

.. image:: _static/nmvc.png

Under **ASP.NET 5 Preview Templates** select **Web Site**, and then **OK**.

.. image:: _static/n2.png

Add the Todo controller
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

1. Download and open the completed project. [todo make link]
2. In solution explorer, in the new app you've created, right click the *Controllers* folder :menuselection:`Add --> Exiting Item`. Enter the path to the *TodoController.cs* file in the download project.
3. Using the same approach, add the *Models\\TodoItem.cs* and  *Models\\TodoItemEditModel.cs* to the *Models* folder.
4. Create a *ToDo* folder under *Views*. Using the same approach, add all the views in the download *Views\\ToDo* folder to the new project *Views\\Todo* folder. 
5. Change the markup in the *Views\\Shared\\_Layout.cshtml* file to use the *Todo* controller:

.. code-block:: html
   :emphasize-lines: 4
   
	@* Markup removed for brevity. *@
	<div class="navbar-collapse collapse">
	  <ul class="nav navbar-nav">
		<li><a asp-controller="Todo" asp-action="Index">Todo</a></li>
		<li><a asp-controller="Home" asp-action="About">About</a></li>
		<li><a asp-controller="Home" asp-action="Contact">Contact</a></li>
	  </ul>
	  @await Html.PartialAsync("_LoginPartial")
	</div>
	@* Markup removed for brevity. *@
 
6. Add a ``DbSet`` containing the ``TodoItem`` model to the  *Models\\IdentityModels.cs* file.

.. code-block:: c#
   :emphasize-lines: 4

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
	  private static bool _created = false;
	  public DbSet<TodoItem> TodoItems { get; set; }

	  // Code removed for brevity.	  
	}

7. Run the app and click on the **Todo**  link (http://localhost:<port>/Todo). You will get the following error (which we will fix in the next section).

.. code-block:: html

	A database operation failed while processing the request.
	SqlException: Invalid object name 'TodoItem'. 
	There are pending model changes for ApplicationDbContext
	Scaffold a new migration for these changes and apply them to the database from the command line:
	> dnx . ef migration add [migration name] 
	> dnx . ef migration apply 


Run EF migrations
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

1. Open a command prompt in the project directory (*TodoList\\src\\TodoList*) and run the following commands:

.. code-block:: javascript

	dnvm use default  
	dnu restore   
	dnx . ef migration add Initial
	dnx . ef migration apply

- **dnvm** : The .NET Version Manager, a set of command line utilities that are used to update and configure .NET Runtime. The command ``dnvm use default`` instructs the .NET Version Manager to add the ASP.NET 5 runtime to the ``PATH`` environment variable for the current shell. For Visual Studio 2015 RC, the following is displayed:  [TODO Needs work]

.. code-block:: javascript

	Adding C:\\Users\\<user>\\.dnx\\runtimes\\dnx-clr-win-x86.1.0.0-beta4\\bin to process PATH 

- **dnu restore** :  Restores the packages specified in the *project.json* file. For Visual Studio 2015 RC, ignore the *npm* and *postrestore* error messages.
- **dnx . ef migration add Initial** :  `DNX <http://docs.asp.net/en/latest/dnx/overview.html>`_ is the .NET Execution Environment. The ``ef migration add initial`` command will add a migration file with the name *\<date\>_\<migration name\>.cs* which contains the migration code that adds the ``TodoItem DbSet``. The *Migrations\\ApplicationDbContextModelSnapshot.cs* file will be updated to include instructions to create the ``TodoItem`` entity.

Run the app
^^^^^^^^^^^^^^^^^^^^^

Run the app and create a couple *Todo* items. Make at least one of the *Todo* items with priority 1 and ``IsDone`` false (not checked).

.. image:: _static/2do.png

Introducing view components
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

New to ASP.NET MVC 6, view components (VCs) are similar to partial views, but they are much more powerful. VCs include the same separation-of-concerns and testability benefits found between a controller and view. You can think of a VC as a mini-controller—it’s responsible for rendering a chunk rather than a whole response. You can use VCs to solve any problem that you feel is too complex with a partial, such as: 

- Dynamic navigation menus
- Tag cloud (where it queries the database)
- Login panel
- Shopping cart
- Recently published articles
- Sidebar content on a typical blog

One use of a VC could be to create a login panel that would be displayed on every page with the following functionality:

- If the user is not logged in, a login panel is rendered.
- If the user is logged in, links to log out and manage account are rendered.
- If the user is in the admin role, an admin panel is rendered.

You can also create a VC that gets and renders data depending on the user's claims. You can add this VC view to the layout page and have it get and render user-specific data throughout the whole application. ViewComponents don’t use model binding, and only depend on the data you provide when calling into it. 

A VC consists of two parts, the class (typically derived from  ``ViewComponent``) and the Razor view which calls methods in the VC class. Like the new ASP.NET controllers, a VC can be a POCO, but most users will want to take advantage of the methods and properties available by deriving from ViewComponent.

A view component class can be created by:

- Deriving from  `ViewComponent <https://github.com/aspnet/Mvc/blob/dev/src/Microsoft.AspNet.Mvc.Core/ViewComponents/ViewComponent.cs>`__ .
- Decorating the class with the ``[ViewComponent]`` attribute, or deriving from a class with the ``[ViewComponent]`` attribute.
- Creating a class where the name ends with the suffix *ViewComponent*.

Like controllers, VCs must be public, non-nested, non-abstract classes.

Adding a view component class
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

1. Create a new folder called *ViewComponents*. View component classes can be contained in **any** folder in the project. 
2. Create a new class file called *PriorityListViewComponent.cs* in the *ViewComponents* folder.
3. Replace the contents of the *PriorityListViewComponent.cs* file with the following:

.. code-block:: c#

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

- Because the class name ``PriorityListViewComponent`` ends with the suffix **ViewComponent**, the runtime will use the string "PriorityList" when referencing the class component from a view. I'll explain that in more detail later. 
- The ``[ViewComponent]`` attribute can used to change the name used to reference a VC. For example, we could have named the class ``XYZ``,  and  applied the  ``ViewComponent`` attribute:

.. code-block:: c#

	[ViewComponent(Name = "PriorityList")]
	public class XYZ : ViewComponent

The ``[ViewComponent]`` attribute above tells the view component selector to use the name ``PriorityList`` when looking for the views associated with the component, and to use the string "PriorityList" when referencing the class component from a view. I'll explain that in more detail later. 

- The component uses constructor injection to make the data context available,  just as we did with the *Todo* controller. 
- ``Invoke`` exposes a method which can be called from a view, and it can take an arbitrary number of arguments. An asynchronous version, ``InvokeAsync``, is available. We'll see ``InvokeAsync`` and multiple arguments later in the tutorial. In the code above, the ``Invoke`` method returns the set of *ToDoItems* that are not completed and have priority greater than or equal to ``maxPriority``.

Adding a view component view
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

1. Create a new folder called *Components* under the *Views\\Todo* folder. This folder **must** be named *Components*.
2. Create a new folder called *PriorityList* in under the *Views\\Todo\\Components* folder. This folder name must match the name of the view component class, or the name of the class minus the suffix (if we followed convention and used the ViewComponent suffix in the class name). If you used the the ``ViewComponent`` attribute, the class name would need to match the attribute designation. 
3. Use **Add exiting item** to copy *Views\\Todo\\Components\\PriorityList\\Default.cshtml* from the download. Alternatively, create a *Default.cshtml* Razor view file in the *Views\\Todo\\Components\\PriorityList* folder, and add the following markup: 

.. code-block:: javascript

	@model IEnumerable<TodoList.Models.TodoItem>

	<h3>Priority Items</h3>
	<ul>
		@foreach (var todo in Model)
		{
			<li>@todo.Title</li>
		}
	</ul>

The Razor view takes a list of ``TodoItems`` and displays them. If the VC ``invoke`` method doesn't pass the name of the view (as in our sample),  *Default* is used for the view name by convention. Later in the tutorial, I'll show you how to pass the name of the view.

4. Add a ``div`` containing a call to the priority list component to the bottom of the *views\\todo\\index.cshtml* file:

.. code-block:: javascript
   :emphasize-lines: 5-7

		@* Markup removed for brevity *@
		<div>@Html.ActionLink("Create New Todo", "Create", "Todo") </div>
	  </div>

	  <div class="col-md-4">
		@Component.Invoke("PriorityList", 1)
	  </div>
	</div>

The markup ``@Component.Invoke`` shows the syntax for calling view components. The first argument is the name of the component we want to invoke or call. Subsequent parameters are passed to the component. In this case, we are passing "1" as the priority we want to filter on. ``Invoke`` and ``InvokeAsync`` can take an arbitrary number of arguments.

The following image shows the priority items:  (make sure you have at least one priority 1 item that is not completed)

.. image:: _static/pi.png

.. note:: View Component views are more typically added to the *Views\\Shared* folder, because VCs are typically not controller specific.

Add InvokeAsync to the priority component
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Update the priority view component class with the following code:

.. note:: ``IQueryable`` renders the sample synchronous, not asynchronous. This is a simple example of how you could call asynchronous methods.

.. code-block:: c#
   :emphasize-lines: 1, 12-34
   
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

Update the VC Razor view (*TodoList\\src\\TodoList\\Views\\ToDo\\Components\\PriorityList\\Default.cshtml*) to show the priority message :

.. code-block:: javascript
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

.. code-block:: javascript
   :emphasize-lines: 4

		@* Markup removed for brevity. *@
		
		<div class="col-md-4">
			@await Component.InvokeAsync("PriorityList", 2, true)
		</div>
	</div>

The following image reflects the changes we made to the priority VC and  Index view:

.. image:: _static/p2.png

Specifying a view name
^^^^^^^^^^^^^^^^^^^^^^^^

A complex VC might need to specify a non-default view under some conditions. The following shows how to specify the "PVC" view  from the  ``InvokeAsync`` method:

.. code-block:: javascript
   :emphasize-lines: 3-22
   
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

Copy *Views\\Todo\\Components\\PriorityList\\Default.cshtml* to a *Views\\Todo\\Components\\PriorityList\\PVC.cshtml* view. I changed the PVC view to verify it's being used:

.. code-block:: javascript
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

.. code-block:: javascript

	@await Component.InvokeAsync("PriorityList",  4, true)

Refresh the page to see the PVC view.

.. image:: _static/pvc.png


Injecting a service into a view
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

ASP.NET MVC 6 now supports injection into a view from a class. Unlike a VC class, there are no restrictions other than the class must be must be public, non-nested and non-abstract. For this example, we'll create a simple class that exposes the total *todo* count, completed count and average priority. 

1. Create a folder called *Services* and add a class file called *StatisticsService.cs* (or you can copy existing item from the sample download).

The StatisticsService class:

.. code-block:: c#

	using System.Linq;
	using System.Threading.Tasks;
	using TodoList.Models;

	namespace TodoList.Services
	{
	   public class StatisticsService
	   {
		  private readonly ApplicationDbContext db;

		  public StatisticsService(ApplicationDbContext context)
		  {
			 db = context;
		  }

		  public async Task<int> GetCount()
		  {
			 return await Task.FromResult(db.TodoItems.Count());
		  }

		  public async Task<int> GetCompletedCount()
		  {
			 return await Task.FromResult(
				 db.TodoItems.Count(x => x.IsDone == true));
		  }

		  public async Task<double> GetAveragePriority()
		  {
			 if (db.TodoItems.Count() == 0)
			 {
				return 0.0;
			 }

			 return await Task.FromResult(
				 db.TodoItems.Average(x =>x.Priority));
		  }
	   }
	}

2. Update the *Index* view to inject the *todo* statistical data. Add the ``inject`` statement to the top of the file:

.. code-block:: html 

	@inject TodoList.Services.StatisticsService Statistics

Add markup calling the StatisticsService to the end of the file:

.. code-block:: html
   :emphasize-lines: 6-11

	 @* Markup removed for brevity *@
		  <div>@Html.ActionLink("Create New Todo", "Create", "Todo") </div>
	   </div>
	   <div class="col-md-4">
		  @await Component.InvokeAsync("PriorityList", 4, true)
		  <h3>Stats</h3>
		  <ul>
			 <li>Items: @await Statistics.GetCount()</li>
			 <li>Completed:@await Statistics.GetCompletedCount()</li>
			 <li>Average Priority:@await Statistics.GetAveragePriority()</li>
		  </ul>
	   </div>
	</div>

3. Register the ``StatisticsService`` class in the *Startup.cs* file: 

.. code-block:: c#
   :emphasize-lines: 8

	public void ConfigureServices(IServiceCollection services)
	{
	   // Add Application settings to the services container.
	   services.Configure<AppSettings>(Configuration.GetSubKey("AppSettings"));
	   // Code removed for brevity.
	   // Add MVC services to the services container.
	   services.AddMvc();
	   services.AddTransient<TodoList.Services.StatisticsService>();
	}

The statistics are displayed:
 
 .. image:: _static/stat.png
 
Publish to Azure
^^^^^^^^^^^^^^^^^^^^

.. note:: To complete this tutorial, you'll need an Azure account. If you don't have an account, you can `activate your MSDN subscriber benefits <http://azure.microsoft.com/en-us/pricing/member-offers/msdn-benefits-details/?WT.mc_id=A261C142F>`_ or `sign up for a free trial <http://azure.microsoft.com/en-us/pricing/free-trial/?WT.mc_id=A261C142F>`_.

1. Right click on the *TodoList* :menuselection:`project --> Publish`.

 .. image:: _static/pub.png

2. In the **Publish Web dialog**, click on  **Microsoft Azure Web Apps** and log into your Azure subscription.

 .. image:: _static/pw.png

3. Click **New**.

 .. image:: _static/manage.png

4. Enter a site name and region. If you've never created a database server, create a new one. If you've created a database server in the past, use that.

 .. image:: _static/newDB.png
 
 .. note:: Database servers are a precious resource. For test and development it's best to use an existing server. There is no validation on the database password in this step, so if you enter an incorrect value, you won't get an error until your web app attempts to access the database.

 .. image:: _static/dbnosrv.png
 
 5. On the Connection step click **Next**.
 
.. image:: _static/constep.png

6. On the **Settings** step, you can select the target .NET version. For this tutorial, keep the default (dnx-clr-win-x6) version. See `Introducing .NET Core <http://docs.asp.net/en/latest/conceptual-overview/dotnetcore.html>`_ for information on the new .NET Core.

7. Click **Publish**.

.. image:: _static/targetdnx.png

8. You can now test the app running on Azure.

.. image:: _static/merge.png

Addition Resources
^^^^^^^^^^^^^^^^^^^^^^^^^

- `Understanding ASP.NET 5 Web Apps <http://docs.asp.net/en/latest/conceptual-overview/understanding-aspnet5-apps.html>`_
- `Introducing .NET Core <http://docs.asp.net/en/latest/conceptual-overview/dotnetcore.html>`_
 
.. include:: /_authors/rick-anderson.txt
