Create, Read, Update, and Delete operations
===========================================

By `Tom Dykstra`_

The Contoso University sample web application demonstrates how to create ASP.NET Core 1.0 MVC web applications using Entity Framework Core 1.0 and Visual Studio 2015. For information about the tutorial series, see :doc:`the first tutorial in the series </data/ef-mvc/intro>`.

In the previous tutorial you created an MVC application that stores and displays data using the Entity Framework and SQL Server LocalDB. In this tutorial you'll review and customize the CRUD (create, read, update, delete) code that the MVC scaffolding automatically creates for you in controllers and views.

.. note:: It's a common practice to implement the repository pattern in order to create an abstraction layer between your controller and the data access layer. To keep these tutorials simple and focused on teaching how to use the Entity Framework itself, they don't use repositories. For information about repositories with EF, see :doc:`the last tutorial in this series </data/ef-mvc/advanced>`.

.. contents:: Sections:
  :local:
  :depth: 1

In this tutorial, you'll work with the following web pages:

.. image:: crud/_static/student-details.png
   :alt: Student Details page

.. image:: crud/_static/student-create.png
   :alt: Student Create page

.. image:: crud/_static/student-edit.png
   :alt: Student Edit page

.. image:: crud/_static/student-delete.png
   :alt: Student Delete page

Customize the Details page
--------------------------

The scaffolded code for the Students Index page left out the ``Enrollments`` property, because that property holds a collection. In the ``Details`` page you'll display the contents of the collection in an HTML table.

In *Controllers/StudentsController.cs*, the action method for the Details view uses the ``SingleOrDefaultAsync`` method to retrieve a single ``Student`` entity. Add code that calls ``Include``. ``ThenInclude``,  and ``AsNoTracking`` methods, as shown in the following highlighted code. 

.. literalinclude::  intro/samples/cu/Controllers/StudentsController.cs
  :language: c#
  :start-after: #region snippet_Details
  :end-before:  #endregion
  :emphasize-lines: 8-12
  :dedent: 8

The ``Include`` and ``ThenInclude`` methods cause the context to load the ``Student.Enrollments`` navigation property, and within each enrollment the ``Enrollment.Course`` navigation property.  You'll learn more about these methods in the :doc:`reading related data </data/ef-mvc/read-related-data>` tutorial.

The ``AsNoTracking`` method improves performance in scenarios where the entities returned will not be updated in the current context's lifetime. You'll learn more about ``AsNoTracking`` at the end of this tutorial.

.. note::  The key value that is passed to the ``Details`` method comes from *route data*.

  Route data is data that the model binder found in a segment of the URL. For example, the default route specifies controller, action, and id segments:

  .. literalinclude::  intro/samples/cu/Startup.cs
    :language: c#
    :start-after: #region snippet_RouteAndSeed
    :end-before:  #endregion
    :emphasize-lines: 5
    :dedent: 8

  In the following URL, the default route maps Instructor as the controller, Index as the action, and 1 as the id; these are route data values.

  .. code-block:: none

    http://localhost:1230/Instructor/Index/1?courseID=2021

  The last part of the URL ("?courseID=2021") is a query string value. The model binder will also pass the ID value to the ``Details`` method ``id`` parameter if you pass it as a query string value:

  .. code-block:: none

    http://localhost:1230/Instructor/Index?id=1&CourseID=2021

  In the Index page, hyperlink URLs are created by tag helper statements in the Razor view. In the following Razor code, the id parameter matches the default route, so ``id`` is added to the route data.

  .. code-block:: html

    <a asp-action="Edit" asp-route-id="@item.ID">Edit</a>

  In the following Razor code, ``studentID`` doesn't match a parameter in the default route, so it's added as a query string.

  .. code-block:: html

    <a asp-action="Edit" asp-route-studentID="@item.ID">Edit</a>

Add enrollments to the Details view
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Open *Views/Students/Details.cshtml*. Each field is displayed using ``DisplayNameFor`` and ``DisplayFor`` helper, as shown in the following example:

.. literalinclude::  intro/samples/cu/Views/Students/Details.cshtml
  :language: html
  :start-after: snippet_Date
  :end-before:  snippet_Date
  :emphasize-lines: 2,5
  :dedent: 12

After the last field and immediately before the closing ``</dl>`` tag, add the following code to display a list of enrollments:

.. literalinclude::  intro/samples/cu/Views/Students/Details.cshtml
  :language: html
  :start-after: snippet_Enrollments
  :end-before:  snippet_Enrollments
  :dedent: 8

If code indentation is wrong after you paste the code, press CTRL-K-D to correct it.

This code loops through the entities in the ``Enrollments`` navigation property. For each enrollment, it displays the course title and the grade. The course title is retrieved from the Course entity that's stored in the ``Course`` navigation property of the Enrollments entity. 

Run the application, select the **Students** tab, and click the **Details** link for a student. You see the list of courses and grades for the selected student:

.. image:: crud/_static/student-details.png
   :alt: Student Details page

Update the Create page
----------------------

In *StudentsController.cs*, modify the HttpPost ``Create`` method by adding a try-catch block and removing ID from the ``Bind`` attribute.

.. literalinclude::  intro/samples/cu/Controllers/StudentsController.cs
  :language: c#
  :start-after: #region snippet_Create
  :end-before:  #endregion
  :emphasize-lines: 4,6-7,14-21
  :dedent: 8
 
This code adds the Student entity created by the ASP.NET MVC model binder to the Students entity set and then saves the changes to the database. (Model binder refers to the ASP.NET MVC functionality that makes it easier for you to work with data submitted by a form; a model binder converts posted form values to CLR types and passes them to the action method in parameters. In this case, the model binder instantiates a Student entity for you using property values from the Form collection.)

You removed ``ID`` from the ``Bind`` attribute because ID is the primary key value which SQL Server will set automatically when the row is inserted. Input from the user does not set the ID value.

Other than the ``Bind`` attribute, the try-catch block is the only change you've made to the scaffolded code. If an exception that derives from ``DbUpdateException`` is caught while the changes are being saved, a generic error message is displayed. ``DbUpdateException`` exceptions are sometimes caused by something external to the application rather than a programming error, so the user is advised to try again. Although not implemented in this sample, a production quality application would log the exception. For more information, see the **Log for insight** section in `Monitoring and Telemetry (Building Real-World Cloud Apps with Azure) <http://www.asp.net/aspnet/overview/developing-apps-with-windows-azure/building-real-world-cloud-apps-with-windows-azure/monitoring-and-telemetry>`__.

The ``ValidateAntiForgeryToken`` attribute helps prevent cross-site request forgery (CSRF) attacks. The token is automatically injected into the view by the `FormTagHelper <https://github.com/aspnet/Mvc/blob/dev/src/Microsoft.AspNetCore.Mvc.TagHelpers/FormTagHelper.cs>`__ and is included when the form is submitted by the user. The token is validated by the ``ValidateAntiForgeryToken`` attribute. For more information about CSRF, see :doc:`/security/anti-request-forgery`.

Security note about overposting
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The ``Bind`` attribute that the scaffolded code includes on the ``Create`` method is one way to protect against overposting in create scenarios. For example, suppose the Student entity includes a ``Secret`` property that you don't want this web page to set.

.. code-block:: c#
  :emphasize-lines: 7

  public class Student
  {
      public int ID { get; set; }
      public string LastName { get; set; }
      public string FirstMidName { get; set; }
      public DateTime EnrollmentDate { get; set; }
      public string Secret { get; set; }
  }

Even if you don't have a ``Secret`` field on the web page, a hacker could use a tool such as Fiddler, or write some JavaScript, to post a ``Secret`` form value. Without the ``Bind`` attribute limiting the fields that the model binder uses when it creates a Student instance, the model binder would pick up that ``Secret`` form value and use it to create the Student entity instance. Then whatever value the hacker specified for the ``Secret`` form field would be updated in your database. The following image shows the Fiddler tool adding the ``Secret`` field (with the value "OverPost") to the posted form values.

.. image:: crud/_static/fiddler.png
   :alt: Fiddler adding Secret field

The value "OverPost" would then be successfully added to the ``Secret`` property of the inserted row, although you never intended that the web page be able to set that property.

It's a security best practice to use the ``Include`` parameter with the Bind attribute to whitelist fields. It's also possible to use the ``Exclude`` parameter to blacklist fields you want to exclude. The reason ``Include`` is more secure is that when you add a new property to the entity, the new field is not automatically protected by an ``Exclude`` list.

You can prevent overposting in edit scenarios by reading the entity from the database first and then calling ``TryUpdateModel``, passing in an explicit allowed properties list. That is the method used in these tutorials.

An alternative way to prevent overposting that is preferrred by many developers is to use view models rather than entity classes with model binding. Include only the properties you want to update in the view model. Once the MVC model binder has finished, copy the view model properties to the entity instance, optionally using a tool such as AutoMapper. Use ``_context.Entry`` on the entity instance to set its state to ``Unchanged``, and then set ``Property("PropertyName").IsModified`` to true on each entity property that is included in the view model. This method works in both edit and create scenarios.

Modify the Create view
^^^^^^^^^^^^^^^^^^^^^^

The code in *Views/Students/Create.cshtml* uses ``label``, ``input``, and ``span`` (for validation messages) tag helpers for each field. 

in ASP.NET Core 1.0, validation messages aren't rendered if ``span`` elements are self-closing, but scaffolding creates them as self-closing. To enable validation, convert the validation ``span`` tags from self-closing to explicit closing tags. (Remove the "/" before the closing angle bracket, and add `</span>`.) The changes are highlighted in the following example.

.. literalinclude::  intro/samples/cu/Views/Students/Create.cshtml
  :language: c#
  :start-after: snippet_Spans
  :end-before:  snippet_Spans
  :emphasize-lines: 5,12,19
  :dedent: 8

.. note:: The 1.0.1 release of the scaffolding tooling generates explicitly closed span tags, but as of September, 2016, the 1.0.1 tooling is not included in the new-project templates. If you want to get the newer version of scaffolding code, you can update project.json to reference the "1.0.0-preview2-update1" release of two NuGet packages:  "Microsoft.VisualStudio.Web.CodeGenerators.Mvc" and "Microsoft.VisualStudio.Web.Codegeneration.Tools". 

Run the page by selecting the **Students** tab and clicking **Create New**.

Enter names and an invalid date and click **Create** to see the error message.

.. image:: crud/_static/date-error.png
   :alt: Date validation error

This is server-side validation that you get by default; in a later tutorial you'll see how to add attributes that will generate code for client-side validation also. The following highlighted code shows the model validation check in the ``Create`` method.

.. literalinclude::  intro/samples/cu/Controllers/StudentsController.cs
  :language: c#
  :start-after: #region snippet_Create
  :end-before:  #endregion
  :emphasize-lines: 8
  :dedent: 8

Change the date to a valid value and click **Create** to see the new student appear in the **Index** page.

Update the Edit page
-------------------------------

In *StudentController.cs*, the HttpGet ``Edit`` method (the one without the ``HttpPost`` attribute) uses the ``SingleOrDefaultAsync`` method to retrieve the selected Student entity, as you saw in the ``Details`` method. You don't need to change this method.

Recommended HttpPost Edit code: Read and update
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Replace the HttpPost Edit action method with the following code. The changes are highlighted.

.. literalinclude::  intro/samples/cu/Controllers/StudentsController.cs
  :language: c#
  :start-after: snippet_ReadFirst
  :end-before:  #endregion
  :emphasize-lines: 5,10-14,20-27

These changes implement a security best practice to prevent overposting. The scaffolder generated a ``Bind`` attribute and added the entity created by the model binder to the entity set with a ``Modified`` flag. That code is not recommended for many scenarios because the ``Bind`` attribute clears out any pre-existing data in fields not listed in the ``Include`` parameter.

The new code reads the existing entity and calls ``TryUpdateModel`` to update fields in the retrieved entity based on user input in the posted form data. The Entity Framework's automatic change tracking sets the ``Modified`` flag on the fields that are changed by form input. When the ``SaveChanges`` method is called, the Entity Framework creates SQL statements to update the database row. Concurrency conflicts are ignored, and only the table columns that were updated by the user are updated in the database. (A later tutorial shows how to handle concurrency conflicts.)

As a best practice to prevent overposting, the fields that you want to be updateable by the **Edit** page are whitelisted in the ``TryUpdateModel`` parameters. (The empty string preceding the list of fields in the parameter list is for a prefix to use with the form fields names.) Currently there are no extra fields that you're protecting, but listing the fields that you want the model binder to bind ensures that if you add fields to the data model in the future, they're automatically protected until you explicitly add them here.

As a result of these changes, the method signature of the HttpPost ``Edit`` method is the same as the HttpGet ``Edit`` method; therefore you've renamed the method ``EditPost``. 

Alternative HttpPost Edit code: Create and attach
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The recommended HttpPost edit code ensures that only changed columns get updated and preserves data in properties that you don't want included for model binding. However, the read-first approach requires an extra database read, and can result in more complex code for handling concurrency conflicts. An alternative is to use the approach adopted by the MVC controller scaffolding engine. The following code shows how to implement code for an HttpPost ``Edit`` method that attaches an entity created by the model binder to the EF context and marks it as modified. (Don't update your project with this code, it's only shown to illustrate an optional approach.)

.. literalinclude::  intro/samples/cu/Controllers/StudentsController.cs
  :language: c#
  :start-after: snippet_CreateAndAttach
  :end-before:  #endregion
  :emphasize-lines: 1,7,11

You can use this approach when the web page UI includes all of the fields in the entity and can update any of them. 

Entity States
^^^^^^^^^^^^^

The database context keeps track of whether entities in memory are in sync with their corresponding rows in the database, and this information determines what happens when you call the ``SaveChanges`` method. For example, when you pass a new entity to the ``Add`` method, that entity's state is set to ``Added``. Then when you call the ``SaveChanges`` method, the database context issues a SQL INSERT command.

An entity may be in one of the following states:

* ``Added``. The entity does not yet exist in the database. The ``SaveChanges`` method issues an INSERT statement.
* ``Unchanged``. Nothing needs to be done with this entity by the ``SaveChanges`` method. When you read an entity from the database, the entity starts out with this status.
* ``Modified``. Some or all of the entity's property values have been modified. The ``SaveChanges`` method issues an UPDATE statement.
* ``Deleted``. The entity has been marked for deletion. The ``SaveChanges`` method issues a DELETE statement.
* ``Detached``. The entity isn't being tracked by the database context.

In a desktop application, state changes are typically set automatically. You read an entity and make changes to some of its property values. This causes its entity state to automatically be changed to ``Modified``. Then when you call ``SaveChanges``, the Entity Framework generates a SQL UPDATE statement that updates only the actual properties that you changed. 

In a web app, the ``DbContext`` that initially reads an entity and displays its data to be edited is disposed after a page is rendered. When the HttpPost ``Edit`` action method is called,  a new web request is made and you have a new instance of the ``DbContext``. If you re-read the entity in that new context, you simulate desktop processing.

But if you don't want to do the extra read operation, you have to use the entity object created by the model binder.  The simplest way to do this is to set the entity state to Modified as is done in the alternative HttpPost Edit code shown earlier. Then when you call ``SaveChanges``, the Entity Framework updates all columns of the database row, because the context has no way to know which properties you changed.

If you want to avoid the read-first approach, but you also want the SQL UPDATE statement to update only the fields that the user actually changed, the code is more complex. You have to save the original values in some way (such as by using hidden fields) so that they are available when the HttpPost ``Edit`` method is called. Then you can create a Student entity using the original values, call the ``Attach`` method with that original version of the entity, update the entity's values to the new values, and then call ``SaveChanges``.

Test the Edit page
^^^^^^^^^^^^^^^^^^

The HTML and Razor code in *Views/Students/Edit.cshtml* is similar to what you saw in *Create.cshtml*, and no changes are required.

Run the application and select the **Students** tab, then click an **Edit** hyperlink.

.. image:: crud/_static/student-edit.png
   :alt: Students edit page

Change some of the data and click **Save**. The **Index** page opens and you see the changed data.

Update the Delete page
----------------------

In *StudentController.cs*, the template code for the HttpGet ``Delete`` method uses the ``SingleOrDefaultAsync`` method to retrieve the selected Student entity, as you saw in the Details and Edit methods. However, to implement a custom error message when the call to ``SaveChanges`` fails, you'll add some functionality to this method and its corresponding view.

As you saw for update and create operations, delete operations require two action methods. The method that is called in response to a GET request displays a view that gives the user a chance to approve or cancel the delete operation. If the user approves it, a POST request is created. When that happens, the HttpPost ``Delete`` method is called and then that method actually performs the delete operation.

You'll add a try-catch block to the HttpPost ``Delete`` method to handle any errors that might occur when the database is updated. If an error occurs, the HttpPost Delete method calls the HttpGet Delete method, passing it a parameter that indicates that an error has occurred. The HttpGet Delete method then redisplays the confirmation page along with the error message, giving the user an opportunity to cancel or try again.

Replace the HttpGet ``Delete`` action method with the following code, which manages error reporting.

.. literalinclude::  intro/samples/cu/Controllers/StudentsController.cs
  :language: c#
  :start-after: snippet_DeleteGet
  :end-before:  #endregion
  :emphasize-lines: 1,9,16-21
  :dedent: 8

This code accepts an optional parameter that indicates whether the method was called after a failure to save changes. This parameter is false when the HttpGet ``Delete`` method is called without a previous failure. When it is called by the HttpPost ``Delete`` method in response to a database update error, the parameter is true and an error message is passed to the view.

The read-first approach to HttpPost Delete
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Replace the HttpPost ``Delete`` action method (named ``DeleteConfirmed``) with the following code, which performs the actual delete operation and catches any database update errors.

.. literalinclude::  intro/samples/cu/Controllers/StudentsController.cs
  :language: c#
  :start-after: snippet_DeleteWithReadFirst
  :end-before:  #endregion
  :emphasize-lines: 6,8-11,13-14,18-23
  :dedent: 8

This code retrieves the selected entity, then calls the ``Remove`` method to set the entity's status to ``Deleted``. When ``SaveChanges`` is called, a SQL DELETE command is generated. 

The create-and-attach approach to HttpPost Delete
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

If improving performance in a high-volume application is a priority, you could avoid an unnecessary SQL query by instantiating a Student entity using only the primary key value and then setting the entity state to ``Deleted``. That's all that the Entity Framework needs in order to delete the entity. (Don't put this code in your project; it's here just to illustrate an alternative.)

.. literalinclude::  intro/samples/cu/Controllers/StudentsController.cs
  :language: c#
  :start-after: snippet_DeleteWithoutReadFirst
  :end-before:  #endregion
  :emphasize-lines: 7-8
  :dedent: 8

If the entity has related data that should also be deleted, make sure that cascade delete is configured in the database. With this approach to entity deletion, EF might not realize there are related entities to be deleted.

Update the Delete view
^^^^^^^^^^^^^^^^^^^^^^

In *Views/Student/Delete.cshtml*, add an error message between the h2 heading and the h3 heading, as shown in the following example:

.. literalinclude::  intro/samples/cu/Views/Students/Delete.cshtml
  :language: c#
  :start-after: snippet_ErrorMessage
  :end-before:  snippet_ErrorMessage
  :emphasize-lines: 2

Run the page by selecting the **Students** tab and clicking a **Delete** hyperlink:

.. image:: crud/_static/student-delete.png
   :alt: Delete confirmation page

Click **Delete**. The Index page is displayed without the deleted student. (You'll see an example of the error handling code in action in the concurrency tutorial.)

Closing database connections
----------------------------

To free up the resources that a database connection holds, the context instance must be disposed as soon as possible when you are done with it. The ASP.NET Core built-in :doc:`dependency injection </fundamentals/dependency-injection>` takes care of that task for you.

In *Startup.cs* you call the `AddDbContext extension method <https://github.com/aspnet/EntityFramework/blob/03bcb5122e3f577a84498545fcf130ba79a3d987/src/Microsoft.EntityFrameworkCore/EntityFrameworkServiceCollectionExtensions.cs>`__ to provision the ``DbContext`` class in the ASP.NET DI container. That method sets the service lifetime to ``Scoped`` by default. ``Scoped`` means the context object lifetime coincides with the web request life time, and the ``Dispose`` method will be called automatically at the end of the web request.

Handling Transactions
---------------------

By default the Entity Framework implicitly implements transactions. In scenarios where you make changes to multiple rows or tables and then call ``SaveChanges``, the Entity Framework automatically makes sure that either all of your changes succeed or they all fail. If some changes are done first and then an error happens, those changes are automatically rolled back. For scenarios where you need more control -- for example, if you want to include operations done outside of Entity Framework in a transaction -- see `Transactions <http://ef.readthedocs.io/en/latest/saving/transactions.html>`__.

No-tracking queries
-------------------

When a database context retrieves table rows and creates entity objects that represent them, by default it keeps track of whether the entities in memory are in sync with what's in the database. The data in memory acts as a cache and is used when you update an entity. This caching is often unnecessary in a web application because context instances are typically short-lived (a new one is created and disposed for each request) and the context that reads an entity is typically disposed before that entity is used again.

You can disable tracking of entity objects in memory by calling the ``AsNoTracking`` method. Typical scenarios in which you might want to do that include the following:

* During the context lifetime you don't need to update any entities, and you don't need EF to :doc:`automatically load navigation properties with  entities retrieved by separate queries </data/ef-mvc/read-related-data>`. Frequently these conditions are met in a controller's HttpGet action methods.
* You are running a query that retrieves a large volume of data, and only a small portion of the returned data will be updated. It may be more efficient to turn off tracking for the large query, and run a query later for the few entities that need to be updated.
* You want to attach an entity in order to update it, but earlier you retrieved the same entity for a different purpose. Because the entity is already being tracked by the database context, you can't attach the entity that you want to change. One way to handle this situation is to call ``AsNoTracking`` on the earlier query.

For more information, see `Tracking vs. No-Tracking <https://ef.readthedocs.io/en/latest/querying/tracking.html>`__.

Summary
-------

You now have a complete set of pages that perform simple CRUD operations for Student entities. In the next tutorial you'll expand the functionality of the **Index** page by adding sorting, filtering, and paging.
