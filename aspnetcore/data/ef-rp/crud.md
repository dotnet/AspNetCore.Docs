---
title: Razor Pages with EF Core in ASP.NET Core - CRUD - 2 of 8
author: rick-anderson
description: Shows how to create, read, update,delete with EF Core.
ms.author: riande
ms.date: 07/22/2019
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: data/ef-rp/crud
---
# Razor Pages with EF Core in ASP.NET Core - CRUD - 2 of 8

By [Tom Dykstra](https://github.com/tdykstra), [Jon P Smith](https://twitter.com/thereformedprog), and [Rick Anderson](https://twitter.com/RickAndMSFT)

[!INCLUDE [about the series](~/includes/RP-EF/intro.md)]

::: moniker range=">= aspnetcore-3.0"

In this tutorial, the scaffolded CRUD (create, read, update, delete) code is reviewed and customized.

## No repository

Some developers use a service layer or repository pattern to create an abstraction layer between the UI (Razor Pages) and the data access layer. This tutorial doesn't do that. To minimize complexity and keep the tutorial focused on EF Core, EF Core code is added directly to the page model classes. 

## Update the Details page

The scaffolded code for the Students pages doesn't include enrollment data. In this section, you add enrollments to the Details page.

### Read enrollments

To display a student's enrollment data on the page, you need to read it. The scaffolded code in *Pages/Students/Details.cshtml.cs* reads only the Student data, without the Enrollment data:

[!code-csharp[Main](intro/samples/cu30snapshots/2-crud/Pages/Students/Details1.cshtml.cs?name=snippet_OnGetAsync&highlight=8)]

Replace the `OnGetAsync` method with the following code to read enrollment data for the selected student. The changes are highlighted.

[!code-csharp[Main](intro/samples/cu30/Pages/Students/Details.cshtml.cs?name=snippet_OnGetAsync&highlight=8-12)]

The [Include](/dotnet/api/microsoft.entityframeworkcore.entityframeworkqueryableextensions.include) and [ThenInclude](/dotnet/api/microsoft.entityframeworkcore.entityframeworkqueryableextensions.theninclude#Microsoft_EntityFrameworkCore_EntityFrameworkQueryableExtensions_ThenInclude__3_Microsoft_EntityFrameworkCore_Query_IIncludableQueryable___0_System_Collections_Generic_IEnumerable___1___System_Linq_Expressions_Expression_System_Func___1___2___) methods cause the context to load the `Student.Enrollments` navigation property, and within each enrollment the `Enrollment.Course` navigation property. These methods are examined in detail in the [Reading related data](xref:data/ef-rp/read-related-data) tutorial.

The [AsNoTracking](/dotnet/api/microsoft.entityframeworkcore.entityframeworkqueryableextensions.asnotracking#Microsoft_EntityFrameworkCore_EntityFrameworkQueryableExtensions_AsNoTracking__1_System_Linq_IQueryable___0__) method improves performance in scenarios where the entities returned are not updated in the current context. `AsNoTracking` is discussed later in this tutorial.

### Display enrollments

Replace the code in *Pages/Students/Details.cshtml* with the following code to display a list of enrollments. The changes are highlighted.

[!code-cshtml[Main](intro/samples/cu30/Pages/Students/Details.cshtml?highlight=32-53)]

The preceding code loops through the entities in the `Enrollments` navigation property. For each enrollment, it displays the course title and the grade. The course title is retrieved from the Course entity that's stored in the `Course` navigation property of the Enrollments entity.

Run the app, select the **Students** tab, and click the **Details** link for a student. The list of courses and grades for the selected student is displayed.

### Ways to read one entity

The generated code uses [FirstOrDefaultAsync](/dotnet/api/microsoft.entityframeworkcore.entityframeworkqueryableextensions.firstordefaultasync#Microsoft_EntityFrameworkCore_EntityFrameworkQueryableExtensions_FirstOrDefaultAsync__1_System_Linq_IQueryable___0__System_Threading_CancellationToken_) to read one entity. This method returns null if nothing is found; otherwise, it returns the first row found that satisfies the query filter criteria. `FirstOrDefaultAsync` is generally a better choice than the following alternatives:

* [SingleOrDefaultAsync](/dotnet/api/microsoft.entityframeworkcore.entityframeworkqueryableextensions.singleordefaultasync#Microsoft_EntityFrameworkCore_EntityFrameworkQueryableExtensions_SingleOrDefaultAsync__1_System_Linq_IQueryable___0__System_Linq_Expressions_Expression_System_Func___0_System_Boolean___System_Threading_CancellationToken_) - Throws an exception if there's more than one entity that satisfies the query filter. To determine if more than one row could be returned by the query, `SingleOrDefaultAsync` tries to fetch multiple rows. This extra work is unnecessary if the query can only return one entity, as when it searches on a unique key.
* [FindAsync](/dotnet/api/microsoft.entityframeworkcore.dbcontext.findasync#Microsoft_EntityFrameworkCore_DbContext_FindAsync_System_Type_System_Object___) - Finds an entity with the primary key (PK). If an entity with the PK is being tracked by the context, it's returned without a request to the database. This method is optimized to look up a single entity, but you can't call `Include` with `FindAsync`.  So if related data is needed, `FirstOrDefaultAsync` is the better choice.

### Route data vs. query string

The URL for the Details page is `https://localhost:<port>/Students/Details?id=1`. The entity's primary key value is in the query string. Some developers prefer to pass the key value in route data: `https://localhost:<port>/Students/Details/1`. For more information, see [Update the generated code](xref:tutorials/razor-pages/da1#update-the-generated-code).

## Update the Create page

The scaffolded `OnPostAsync` code for the Create page is vulnerable to [overposting](#overposting). Replace the `OnPostAsync` method in *Pages/Students/Create.cshtml.cs* with the following code.

[!code-csharp[Main](intro/samples/cu30/Pages/Students/Create.cshtml.cs?name=snippet_OnPostAsync)]

<a name="TryUpdateModelAsync"></a>

### TryUpdateModelAsync

The preceding code creates a Student object and then uses posted form fields to update the Student object's properties. The [TryUpdateModelAsync](/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.tryupdatemodelasync#Microsoft_AspNetCore_Mvc_ControllerBase_TryUpdateModelAsync_System_Object_System_Type_System_String_) method:

* Uses the posted form values from the [PageContext](/dotnet/api/microsoft.aspnetcore.mvc.razorpages.pagemodel.pagecontext#Microsoft_AspNetCore_Mvc_RazorPages_PageModel_PageContext) property in the [PageModel](/dotnet/api/microsoft.aspnetcore.mvc.razorpages.pagemodel).
* Updates only the properties listed (`s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate`).
* Looks for form fields with a "student" prefix. For example, `Student.FirstMidName`. It's not case sensitive.
* Uses the [model binding](xref:mvc/models/model-binding) system to convert form values from strings to the types in the `Student` model. For example, `EnrollmentDate` has to be converted to DateTime.

Run the app, and create a student entity to test the Create page.

## Overposting

Using `TryUpdateModel` to update fields with posted values is a security best practice because it prevents overposting. For example, suppose the Student entity includes a `Secret` property that this web page shouldn't update or add:

[!code-csharp[Main](intro/samples/cu30snapshots/2-crud/Models/StudentZsecret.cs?name=snippet_Intro&highlight=7)]

Even if the app doesn't have a `Secret` field on the create or update Razor Page, a hacker could set the `Secret` value by overposting. A hacker could use a tool such as Fiddler, or write some JavaScript, to post a `Secret` form value. The original code doesn't limit the fields that the model binder uses when it creates a Student instance.

Whatever value the hacker specified for the `Secret` form field is updated in the database. The following image shows the Fiddler tool adding the `Secret` field (with the value "OverPost") to the posted form values.

![Fiddler adding Secret field](../ef-mvc/crud/_static/fiddler.png)

The value "OverPost" is successfully added to the `Secret` property of the inserted row. That happens even though the app designer never intended the `Secret` property to be set with the Create page.

### View model

View models provide an alternative way to prevent overposting.

The application model is often called the domain model. The domain model typically contains all the properties required by the corresponding entity in the database. The view model contains only the properties needed for the UI that it is used for (for example, the Create page).

In addition to the view model, some apps use a binding model or input model to pass data between the Razor Pages page model class and the browser. 

Consider the following `Student` view model:

[!code-csharp[Main](intro/samples/cu30snapshots/2-crud/Models/StudentVM.cs)]

The following code uses the `StudentVM` view model to create a new student:

[!code-csharp[Main](intro/samples/cu30snapshots/2-crud/Pages/Students/CreateVM.cshtml.cs?name=snippet_OnPostAsync)]

The [SetValues](/dotnet/api/microsoft.entityframeworkcore.changetracking.propertyvalues.setvalues#Microsoft_EntityFrameworkCore_ChangeTracking_PropertyValues_SetValues_System_Object_) method sets the values of this object by reading values from another [PropertyValues](/dotnet/api/microsoft.entityframeworkcore.changetracking.propertyvalues) object. `SetValues` uses property name matching. The view model type doesn't need to be related to the model type, it just needs to have properties that match.

Using `StudentVM` requires [Create.cshtml](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/data/ef-rp/intro/samples/cu30snapshots/2-crud/Pages/Students/CreateVM.cshtml) be updated to use `StudentVM` rather than `Student`.

## Update the Edit page

In *Pages/Students/Edit.cshtml.cs*, replace the `OnGetAsync` and `OnPostAsync` methods with the following code.

[!code-csharp[Main](intro/samples/cu30/Pages/Students/Edit.cshtml.cs?name=snippet_OnGetPost)]

The code changes are similar to the Create page with a few exceptions:

* `FirstOrDefaultAsync` has been replaced with [FindAsync](/dotnet/api/microsoft.entityframeworkcore.dbset-1.findasync). When you don't have to include related data, `FindAsync` is more efficient.
* `OnPostAsync` has an `id` parameter.
* The current student is fetched from the database, rather than creating an empty student.

Run the app, and test it by creating and editing a student.

## Entity States

The database context keeps track of whether entities in memory are in sync with their corresponding rows in the database. This tracking information determines what happens when [SaveChangesAsync](/dotnet/api/microsoft.entityframeworkcore.dbcontext.savechangesasync#Microsoft_EntityFrameworkCore_DbContext_SaveChangesAsync_System_Threading_CancellationToken_) is called. For example, when a new entity is passed to the [AddAsync](/dotnet/api/microsoft.entityframeworkcore.dbcontext.addasync) method, that entity's state is set to [Added](/dotnet/api/microsoft.entityframeworkcore.entitystate#Microsoft_EntityFrameworkCore_EntityState_Added). When `SaveChangesAsync` is called, the database context issues a SQL INSERT command.

An entity may be in one of the [following states](/dotnet/api/microsoft.entityframeworkcore.entitystate):

* `Added`: The entity doesn't yet exist in the database. The `SaveChanges` method issues an INSERT statement.

* `Unchanged`: No changes need to be saved with this entity. An entity has this status when it's read from the database.

* `Modified`: Some or all of the entity's property values have been modified. The `SaveChanges` method issues an UPDATE statement.

* `Deleted`: The entity has been marked for deletion. The `SaveChanges` method issues a DELETE statement.

* `Detached`: The entity isn't being tracked by the database context.

In a desktop app, state changes are typically set automatically. An entity is read, changes are made, and the entity state is automatically changed to `Modified`. Calling `SaveChanges` generates a SQL UPDATE statement that updates only the changed properties.

In a web app, the `DbContext` that reads an entity and displays the data is disposed after a page is rendered. When a page's `OnPostAsync` method is called, a new web request is made and with a new instance of the `DbContext`. Rereading the entity in that new context simulates desktop processing.

## Update the Delete page

In this section, you implement a custom error message when the call to `SaveChanges` fails.

Replace the code in *Pages/Students/Delete.cshtml.cs* with the following code. The changes are highlighted (other than cleanup of `using` statements).

[!code-csharp[Main](intro/samples/cu30/Pages/Students/Delete.cshtml.cs?name=snippet_All&highlight=20,22,30,38-41,53-71)]

The preceding code adds the optional parameter `saveChangesError` to the `OnGetAsync` method signature. `saveChangesError` indicates whether the method was called after a failure to delete the student object. The delete operation might fail because of transient network problems. Transient network errors are more likely when the database is in the cloud. The `saveChangesError` parameter is false when the Delete page `OnGetAsync` is called from the UI. When `OnGetAsync` is called by `OnPostAsync` (because the delete operation failed), the `saveChangesError` parameter is true.

The `OnPostAsync` method retrieves the selected entity, then calls the [Remove](/dotnet/api/microsoft.entityframeworkcore.dbcontext.remove#Microsoft_EntityFrameworkCore_DbContext_Remove_System_Object_) method to set the entity's status to `Deleted`. When `SaveChanges` is called, a SQL DELETE command is generated. If `Remove` fails:

* The database exception is caught.
* The Delete pages `OnGetAsync` method is called with `saveChangesError=true`.

Add an error message to the Delete Razor Page (*Pages/Students/Delete.cshtml*):

[!code-cshtml[Main](intro/samples/cu30/Pages/Students/Delete.cshtml?highlight=10)]

Run the app and delete a student to test the Delete page.

## Next steps

> [!div class="step-by-step"]
> [Previous tutorial](xref:data/ef-rp/intro)
> [Next tutorial](xref:data/ef-rp/sort-filter-page)

::: moniker-end

::: moniker range="< aspnetcore-3.0"

In this tutorial, the scaffolded CRUD (create, read, update, delete) code is reviewed and customized.

To minimize complexity and keep these tutorials focused on EF Core, EF Core code is used in the page models. Some developers use a service layer or repository pattern in to create an abstraction layer between the UI (Razor Pages) and the data access layer.

In this tutorial, the Create, Edit, Delete, and Details Razor Pages in the *Students* folder are examined.

The scaffolded code uses the following pattern for Create, Edit, and Delete pages:

* Get and display the requested data with the HTTP GET method `OnGetAsync`.
* Save changes to the data with the HTTP POST method `OnPostAsync`.

The Index and Details pages get and display the requested data with the HTTP GET method `OnGetAsync`

## SingleOrDefaultAsync vs. FirstOrDefaultAsync

The generated code uses [FirstOrDefaultAsync](/dotnet/api/microsoft.entityframeworkcore.entityframeworkqueryableextensions.firstordefaultasync#Microsoft_EntityFrameworkCore_EntityFrameworkQueryableExtensions_FirstOrDefaultAsync__1_System_Linq_IQueryable___0__System_Threading_CancellationToken_), which is generally preferred over [SingleOrDefaultAsync](/dotnet/api/microsoft.entityframeworkcore.entityframeworkqueryableextensions.singleordefaultasync#Microsoft_EntityFrameworkCore_EntityFrameworkQueryableExtensions_SingleOrDefaultAsync__1_System_Linq_IQueryable___0__System_Linq_Expressions_Expression_System_Func___0_System_Boolean___System_Threading_CancellationToken_).

 `FirstOrDefaultAsync` is more efficient than `SingleOrDefaultAsync` at fetching one entity:

* Unless the code needs to verify that there's not more than one entity returned from the query.
* `SingleOrDefaultAsync` fetches more data and does unnecessary work.
* `SingleOrDefaultAsync` throws an exception if there's more than one entity that fits the filter part.
* `FirstOrDefaultAsync` doesn't throw if there's more than one entity that fits the filter part.

<a name="FindAsync"></a>

### FindAsync

In much of the scaffolded code, [FindAsync](/dotnet/api/microsoft.entityframeworkcore.dbcontext.findasync#Microsoft_EntityFrameworkCore_DbContext_FindAsync_System_Type_System_Object___) can be used in place of `FirstOrDefaultAsync`.

`FindAsync`:

* Finds an entity with the primary key (PK). If an entity with the PK is being tracked by the context, it's returned without a request to the DB.
* Is simple and concise.
* Is optimized to look up a single entity.
* Can have perf benefits in some situations, but that rarely happens for typical web apps.
* Implicitly uses [FirstAsync](/dotnet/api/microsoft.entityframeworkcore.entityframeworkqueryableextensions.firstasync#Microsoft_EntityFrameworkCore_EntityFrameworkQueryableExtensions_FirstAsync__1_System_Linq_IQueryable___0__System_Linq_Expressions_Expression_System_Func___0_System_Boolean___System_Threading_CancellationToken_) instead of [SingleAsync](/dotnet/api/microsoft.entityframeworkcore.entityframeworkqueryableextensions.singleasync#Microsoft_EntityFrameworkCore_EntityFrameworkQueryableExtensions_SingleAsync__1_System_Linq_IQueryable___0__System_Linq_Expressions_Expression_System_Func___0_System_Boolean___System_Threading_CancellationToken_).

But if you want to `Include` other entities, then `FindAsync` is no longer appropriate. This means that you may need to abandon `FindAsync` and move to a query as your app progresses.

## Customize the Details page

Browse to `Pages/Students` page. The **Edit**, **Details**, and **Delete** links are generated by the [Anchor Tag Helper](xref:mvc/views/tag-helpers/builtin-th/anchor-tag-helper)
in the *Pages/Students/Index.cshtml* file.

[!code-cshtml[](intro/samples/cu21/Pages/Students/Index1.cshtml?name=snippet)]

Run the app and select a **Details** link. The URL is of the form `http://localhost:5000/Students/Details?id=2`. The Student ID is passed using a query string (`?id=2`).

Update the Edit, Details, and Delete Razor Pages to use the `"{id:int}"` route template. Change the page directive for each of these pages from `@page` to `@page "{id:int}"`.

A request to the page with the "{id:int}" route template that does **not** include a integer route value returns an HTTP 404 (not found) error. For example, `http://localhost:5000/Students/Details` returns a 404 error. To make the ID optional, append `?` to the route constraint:

 ```cshtml
@page "{id:int?}"
```

Run the app, click on a Details link, and verify the URL is passing the ID as route data (`http://localhost:5000/Students/Details/2`).

Don't globally change `@page` to `@page "{id:int}"`, doing so breaks the links to the Home and Create pages.

<!-- See https://github.com/aspnet/Scaffolding/issues/590 -->

### Add related data

The scaffolded code for the Students Index page doesn't include the `Enrollments` property. In this section, the contents of the `Enrollments` collection is displayed in the Details page.

The `OnGetAsync` method of *Pages/Students/Details.cshtml.cs* uses the `FirstOrDefaultAsync` method to retrieve a single `Student` entity. Add the following highlighted code:

[!code-csharp[](intro/samples/cu21/Pages/Students/Details.cshtml.cs?name=snippet_Details&highlight=8-12)]

The [Include](/dotnet/api/microsoft.entityframeworkcore.entityframeworkqueryableextensions.include) and [ThenInclude](/dotnet/api/microsoft.entityframeworkcore.entityframeworkqueryableextensions.theninclude#Microsoft_EntityFrameworkCore_EntityFrameworkQueryableExtensions_ThenInclude__3_Microsoft_EntityFrameworkCore_Query_IIncludableQueryable___0_System_Collections_Generic_IEnumerable___1___System_Linq_Expressions_Expression_System_Func___1___2___) methods cause the context to load the `Student.Enrollments` navigation property, and within each enrollment the `Enrollment.Course` navigation property. These methods are examined in detail in the reading-related data tutorial.

The [AsNoTracking](/dotnet/api/microsoft.entityframeworkcore.entityframeworkqueryableextensions.asnotracking#Microsoft_EntityFrameworkCore_EntityFrameworkQueryableExtensions_AsNoTracking__1_System_Linq_IQueryable___0__) method improves performance in scenarios when the entities returned are not updated in the current context. `AsNoTracking` is discussed later in this tutorial.

### Display related enrollments on the Details page

Open *Pages/Students/Details.cshtml*. Add the following highlighted code to display a list of enrollments:

[!code-cshtml[](intro/samples/cu21/Pages/Students/Details.cshtml?highlight=32-53)]

If code indentation is wrong after the code is pasted, press CTRL-K-D to correct it.

The preceding code loops through the entities in the `Enrollments` navigation property. For each enrollment, it displays the course title and the grade. The course title is retrieved from the Course entity that's stored in the `Course` navigation property of the Enrollments entity.

Run the app, select the **Students** tab, and click the **Details** link for a student. The list of courses and grades for the selected student is displayed.

## Update the Create page

Update the `OnPostAsync` method in *Pages/Students/Create.cshtml.cs* with the following code:

[!code-csharp[](intro/samples/cu21/Pages/Students/Create.cshtml.cs?name=snippet_OnPostAsync)]

<a name="TryUpdateModelAsync"></a>

### TryUpdateModelAsync

Examine the [TryUpdateModelAsync](/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.tryupdatemodelasync#Microsoft_AspNetCore_Mvc_ControllerBase_TryUpdateModelAsync_System_Object_System_Type_System_String_) code:

[!code-csharp[](intro/samples/cu21/Pages/Students/Create.cshtml.cs?name=snippet_TryUpdateModelAsync)]

In the preceding code, `TryUpdateModelAsync<Student>` tries to update the `emptyStudent` object using the posted form values from the [PageContext](/dotnet/api/microsoft.aspnetcore.mvc.razorpages.pagemodel.pagecontext#Microsoft_AspNetCore_Mvc_RazorPages_PageModel_PageContext) property in the [PageModel](/dotnet/api/microsoft.aspnetcore.mvc.razorpages.pagemodel). `TryUpdateModelAsync` only updates the properties listed (`s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate`).

In the preceding sample:

* The second argument (`"student", // Prefix`) is the prefix uses to look up values. It's not case sensitive.
* The posted form values are converted to the types in the `Student` model using [model binding](xref:mvc/models/model-binding).

<a id="overpost"></a>

### Overposting

Using `TryUpdateModel` to update fields with posted values is a security best practice because it prevents overposting. For example, suppose the Student entity includes a `Secret` property that this web page shouldn't update or add:

[!code-csharp[](intro/samples/cu21/Models/StudentZsecret.cs?name=snippet_Intro&highlight=7)]

Even if the app doesn't have a `Secret` field on the create/update Razor Page, a hacker could set the `Secret` value by overposting. A hacker could use a tool such as Fiddler, or write some JavaScript, to post a `Secret` form value. The original code doesn't limit the fields that the model binder uses when it creates a Student instance.

Whatever value the hacker specified for the `Secret` form field is updated in the DB. The following image shows the Fiddler tool adding the `Secret` field (with the value "OverPost") to the posted form values.

![Fiddler adding Secret field](../ef-mvc/crud/_static/fiddler.png)

The value "OverPost" is successfully added to the `Secret` property of the inserted row. The app designer never intended the `Secret` property to be set with the Create page.

<a name="vm"></a>

### View model

A view model typically contains a subset of the properties included in the model used by the application. The application model is often called the domain model. The domain model typically contains all the properties required by the corresponding entity in the DB. The view model contains only the properties needed for the UI layer (for example, the Create page). In addition to the view model, some apps use a binding model or input model to pass data between the Razor Pages page model class and the browser. Consider the following `Student` view model:

[!code-csharp[](intro/samples/cu21/Models/StudentVM.cs)]

View models provide an alternative way to prevent overposting. The view model contains only the properties to view (display) or update.

The following code uses the `StudentVM` view model to create a new student:

[!code-csharp[](intro/samples/cu21/Pages/Students/CreateVM.cshtml.cs?name=snippet_OnPostAsync)]

The [SetValues](/dotnet/api/microsoft.entityframeworkcore.changetracking.propertyvalues.setvalues#Microsoft_EntityFrameworkCore_ChangeTracking_PropertyValues_SetValues_System_Object_) method sets the values of this object by reading values from another [PropertyValues](/dotnet/api/microsoft.entityframeworkcore.changetracking.propertyvalues) object. `SetValues` uses property name matching. The view model type doesn't need to be related to the model type, it just needs to have properties that match.

Using `StudentVM` requires [CreateVM.cshtml](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/data/ef-rp/intro/samples/cu21/Pages/Students/CreateVM.cshtml) be updated to use `StudentVM` rather than `Student`.

In Razor Pages, the `PageModel` derived class is the view model.

## Update the Edit page

Update the page model for the Edit page. The major changes are highlighted:

[!code-csharp[](intro/samples/cu21/Pages/Students/Edit.cshtml.cs?name=snippet_OnPostAsync&highlight=20,36)]

The code changes are similar to the Create page with a few exceptions:

* `OnPostAsync` has an optional `id` parameter.
* The current student is fetched from the DB, rather than creating an empty student.
* `FirstOrDefaultAsync` has been replaced with [FindAsync](/dotnet/api/microsoft.entityframeworkcore.dbset-1.findasync). `FindAsync` is a good choice when selecting an entity from the primary key. See [FindAsync](#FindAsync) for more information.

### Test the Edit and Create pages

Create and edit a few student entities.

## Entity States

The DB context keeps track of whether entities in memory are in sync with their corresponding rows in the DB. The DB context sync information determines what happens when [SaveChangesAsync](/dotnet/api/microsoft.entityframeworkcore.dbcontext.savechangesasync#Microsoft_EntityFrameworkCore_DbContext_SaveChangesAsync_System_Threading_CancellationToken_) is called. For example, when a new entity is passed to the [AddAsync](/dotnet/api/microsoft.entityframeworkcore.dbcontext.addasync) method, that entity's state is set to [Added](/dotnet/api/microsoft.entityframeworkcore.entitystate#Microsoft_EntityFrameworkCore_EntityState_Added). When `SaveChangesAsync` is called, the DB context issues a SQL INSERT command.

An entity may be in one of the [following states](/dotnet/api/microsoft.entityframeworkcore.entitystate):

* `Added`: The entity doesn't yet exist in the DB. The `SaveChanges` method issues an INSERT statement.

* `Unchanged`: No changes need to be saved with this entity. An entity has this status when it's read from the DB.

* `Modified`: Some or all of the entity's property values have been modified. The `SaveChanges` method issues an UPDATE statement.

* `Deleted`: The entity has been marked for deletion. The `SaveChanges` method issues a DELETE statement.

* `Detached`: The entity isn't being tracked by the DB context.

In a desktop app, state changes are typically set automatically. An entity is read, changes are made, and the entity state to automatically be changed to `Modified`. Calling `SaveChanges` generates a SQL UPDATE statement that updates only the changed properties.

In a web app, the `DbContext` that reads an entity and displays the data is disposed after a page is rendered. When a page's `OnPostAsync` method is called, a new web request is made and with a new instance of the `DbContext`. Re-reading the entity in that new context simulates desktop processing.

## Update the Delete page

In this section, code is added to implement a custom error message when the call to `SaveChanges` fails. Add a string to contain possible error messages:

[!code-csharp[](intro/samples/cu21/Pages/Students/Delete.cshtml.cs?name=snippet1&highlight=12)]

Replace the `OnGetAsync` method with the following code:

[!code-csharp[](intro/samples/cu21/Pages/Students/Delete.cshtml.cs?name=snippet_OnGetAsync&highlight=1,9,17-20)]

The preceding code contains the optional parameter `saveChangesError`. `saveChangesError` indicates whether the method was called after a failure to delete the student object. The delete operation might fail because of transient network problems. Transient network errors are more likely in the cloud. `saveChangesError`is false when the Delete page `OnGetAsync` is called from the UI. When `OnGetAsync` is called by `OnPostAsync` (because the delete operation failed), the `saveChangesError` parameter is true.

### The Delete pages OnPostAsync method

Replace the `OnPostAsync` with the following code:

[!code-csharp[](intro/samples/cu21/Pages/Students/Delete.cshtml.cs?name=snippet_OnPostAsync)]

The preceding code retrieves the selected entity, then calls the [Remove](/dotnet/api/microsoft.entityframeworkcore.dbcontext.remove#Microsoft_EntityFrameworkCore_DbContext_Remove_System_Object_) method to set the entity's status to `Deleted`. When `SaveChanges` is called, a SQL DELETE command is generated. If `Remove` fails:

* The DB exception is caught.
* The Delete pages `OnGetAsync` method is called with `saveChangesError=true`.

### Update the Delete Razor Page

Add the following highlighted error message to the Delete Razor Page.
<!--
[!code-cshtml[](intro/samples/cu21/Pages/Students/Delete.cshtml?name=snippet&highlight=11)]
-->
[!code-cshtml[](intro/samples/cu21/Pages/Students/Delete.cshtml?range=1-13&highlight=10)]

Test Delete.

## Common errors

Students/Index or other links don't work:

Verify the Razor Page contains the correct `@page` directive. For example, The Students/Index Razor Page should **not** contain a route template:

```cshtml
@page "{id:int}"
```

Each Razor Page must include the `@page` directive.



## Additional resources

* [YouTube version of this tutorial](https://www.youtube.com/watch?v=K4X1MT2jt6o)

> [!div class="step-by-step"]
> [Previous](xref:data/ef-rp/intro)
> [Next](xref:data/ef-rp/sort-filter-page)

::: moniker-end
