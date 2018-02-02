---
title: Razor Pages with EF Core - Read Related Data - 6 of 8
author: rick-anderson
description: In this tutorial you read and display related data -- that is, data that the Entity Framework loads into navigation properties.
manager: wpickett
ms.author: riande
ms.date: 11/05/2017
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: get-started-article
uid: data/ef-rp/read-related-data
---

# Reading related data - EF Core with Razor Pages (6 of 8)

By [Tom Dykstra](https://github.com/tdykstra), [Jon P Smith](https://twitter.com/thereformedprog), and [Rick Anderson](https://twitter.com/RickAndMSFT)

[!INCLUDE[about the series](../../includes/RP-EF/intro.md)]

In this tutorial, related data is read and displayed. Related data is data that EF Core loads into navigation properties.

If you run into problems you can't solve, download the [completed app for this stage](https://github.com/aspnet/Docs/tree/master/aspnetcore/data/ef-rp/intro/samples/StageSnapShots/cu-part6-related).

The following illustrations show the completed pages for this tutorial:

![Courses Index page](read-related-data/_static/courses-index.png)

![Instructors Index page](read-related-data/_static/instructors-index.png)

## Eager, explicit, and lazy Loading of related data

There are several ways that EF Core can load related data into the navigation properties of an entity:

* [Eager loading](https://docs.microsoft.com/ef/core/querying/related-data#eager-loading). Eager loading is when a query for one type of entity also loads related entities. When the entity is read, its related data is retrieved. This typically results in a single join query that retrieves all of the data that's needed. EF Core will issue multiple queries for some types of eager loading. Issuing multiple queries can be more efficient than was the case for some queries in EF6 where there was a single query. Eager loading is specified with the `Include` and `ThenInclude` methods.

 ![Eager loading example](read-related-data/_static/eager-loading.png)
 
 Eager loading sends multiple queries when a collection nvavigation is included:

 * One query for the main query 
 * One query for each collection "edge" in the load tree.

* Separate queries with `Load`: The data can be retrieved in separate queries, and EF Core "fixes up" the navigation properties. "fixes up" means that EF Core automatically populates the navigation properties. Separate queries with `Load` is more like explict loading than eager loading.

 ![Separate queries example](read-related-data/_static/separate-queries.png)

 Note: EF Core automatically fixes up navigation properties to any other entities that were previously loaded into the context instance. Even if the data for a navigation property is *not* explicitly included, the property may still be populated if some or all of the related entities were previously loaded.

* [Explicit loading](https://docs.microsoft.com/ef/core/querying/related-data#explicit-loading). When the entity is first read, related data isn't retrieved. Code must be written to retrieve the related data when it's needed. Explicit loading with separate queries results in multiple queries sent to the DB. With explicit loading, the code specifies the navigation properties to be loaded. Use the `Load` method to do explicit loading. For example:

 ![Explicit loading example](read-related-data/_static/explicit-loading.png)

* [Lazy loading](https://docs.microsoft.com/ef/core/querying/related-data#lazy-loading). [EF Core doesn't currently support lazy loading](https://github.com/aspnet/EntityFrameworkCore/issues/3797). When the entity is first read, related data isn't retrieved. The first time a navigation property is accessed, the data required for that navigation property is automatically retrieved. A query is sent to the DB each time a navigation property is accessed for the first time.

* The `Select` operator loads only the related data needed.

## Create a Courses page that displays department name

The Course entity includes a navigation property that contains the `Department` entity. The `Department` entity contains the department that the course is assigned to.

To display the name of the assigned department in a list of courses:

* Get the `Name` property from the `Department` entity.
* The `Department` entity comes from the `Course.Department` navigation property.

![ourse.Department](read-related-data/_static/dep-crs.png)

<a name="scaffold"></a>
### Scaffold the Course model

* Exit Visual Studio.
* Open a command window in the project directory (The directory that contains the *Program.cs*, *Startup.cs*, and *.csproj* files).
* Run the following command:

 ```console
dotnet aspnet-codegenerator razorpage -m Course -dc SchoolContext -udl -outDir Pages\Courses --referenceScriptLibraries
 ```

The preceding command scaffolds the `Course` model. Open the project in Visual Studio.

Build the project. The build generates errors like the following:

`1>Pages/Courses/Index.cshtml.cs(26,37,26,43): error CS1061: 'SchoolContext' does not
 contain a definition for 'Course' and no extension method 'Course' accepting a first
 argument of type 'SchoolContext' could be found (are you missing a using directive or
 an assembly reference?)`

 Globally change `_context.Course` to `_context.Courses` (that is, add an "s" to `Course`). 7 occurrences are found and updated.

Open *Pages/Courses/Index.cshtml.cs* and examine the `OnGetAsync` method. The scaffolding engine specified eager loading for the `Department` navigation property. The `Include` method specifies eager loading.

Run the app and select the **Courses** link. The department column displays the `DepartmentID`, which isn't useful.

Update the `OnGetAsync` method with the following code:

[!code-csharp[Main](intro/samples/cu/Pages/Courses/Index.cshtml.cs?name=snippet_RevisedIndexMethod)]

The preceding code adds `AsNoTracking`. `AsNoTracking` improves performance because the entities returned are not tracked. The entities are not tracked because they're not updated in the current context.

Update *Views/Courses/Index.cshtml* with the following highlighted markup:

[!code-html[](intro/samples/cu/Pages/Courses/Index.cshtml?highlight=4,7,15-17,34-36,44)]

The following changes have been made to the scaffolded code:

* Changed the heading from Index to Courses.
* Added a **Number** column that shows the `CourseID` property value. By default, primary keys aren't scaffolded because normally they're meaningless to end users. However, in this case the primary key is meaningful.
* Changed the **Department** column to display the department name. The code displays the `Name` property of the `Department` entity that's loaded into the `Department` navigation property:

  ```html
  @Html.DisplayFor(modelItem => item.Department.Name)
  ```

Run the app and select the **Courses** tab to see the list with department names.

![Courses Index page](read-related-data/_static/courses-index.png)

<a name="select"></a>
### Loading related data with Select

The `OnGetAsync` method loads related data with the `Include` method:

[!code-csharp[Main](intro/samples/cu/Pages/Courses/Index.cshtml.cs?name=snippet_RevisedIndexMethod&highlight=4)]

The `Select` operator loads only the related data needed. For single items, like the `Department.Name` it uses a SQL INNER JOIN. For collections it uses another database access, but so does the .`Include` operator on collections.

The following code loads related data with the `Select` method:

[!code-csharp[Main](intro/samples/cu/Pages/Courses/IndexSelect.cshtml.cs?name=snippet_RevisedIndexMethod&highlight=4)]

The `CourseViewModel`:

[!code-csharp[Main](intro/samples/cu/Models/SchoolViewModels/CourseViewModel.cs?name=snippet)]

See [IndexSelect.cshtml](https://github.com/aspnet/Docs/tree/master/aspnetcore/data/ef-rp/intro/samples/cu/Pages/Courses/IndexSelect.cshtml) and [IndexSelect.cshtml.cs](https://github.com/aspnet/Docs/tree/master/aspnetcore/data/ef-rp/intro/samples/cu/Pages/Courses/IndexSelect.cshtml.cs) for a complete example.

## Create an Instructors page that shows Courses and Enrollments

In this section, the Instructors page is created.

<a name="IP"></a>
![Instructors Index page](read-related-data/_static/instructors-index.png)

This page reads and displays related data in the following ways:

* The list of instructors displays related data from the `OfficeAssignment` entity (Office in the preceding image). The `Instructor` and `OfficeAssignment` entities are in a one-to-zero-or-one relationship. Eager loading is used for the `OfficeAssignment` entities. Eager loading is typically more efficient when the related data needs to be displayed. In this case, office assignments for the instructors are displayed.
* When the user selects an instructor (Harui in the preceding image), related `Course` entities are displayed. The `Instructor` and `Course` entities are in a many-to-many relationship. Eager loading for the `Course` entities and their related `Department` entities is used. In this case, separate queries might be more efficient because only courses for the selected instructor are needed. This example shows how to use eager loading for navigation properties in entities that are in navigation properties.
* When the user selects a course (Chemistry in the preceding image), related data from the `Enrollments` entity is displayed. In the preceding image, student name and grade are displayed. The `Course` and `Enrollment` entities are in a one-to-many relationship.

### Create a view model for the Instructor Index view

The instructors page shows data from three different tables. A view model is created that includes the three entities representing the three tables.

In the *SchoolViewModels* folder, create *InstructorIndexData.cs* with the following code:

[!code-csharp[Main](intro/samples/cu/Models/SchoolViewModels/InstructorIndexData.cs)]

### Scaffold the Instructor model

* Exit Visual Studio.
* Open a command window in the project directory (The directory that contains the *Program.cs*, *Startup.cs*, and *.csproj* files).
* Run the following command:

 ```console
dotnet aspnet-codegenerator razorpage -m Instructor -dc SchoolContext -udl -outDir Pages\Instructors --referenceScriptLibraries
 ```

The preceding command scaffolds the `Instructor` model. Open the project in Visual Studio.

Build the project. The build generates errors.

Globally change `_context.Instructor` to `_context.Instructors` (that is, add an "s" to `Instructor`). 7 occurrences are found and updated.

Run the app and navigate to the instructors page.

Replace *Pages/Instructors/Index.cshtml.cs* with the following code:

[!code-csharp[Main](intro/samples/cu/Pages/Instructors/Index1.cshtml.cs?name=snippet_all&highlight=2,20-99)]

The `OnGetAsync` method accepts optional route data for the ID of the selected instructor.

Examine the query on the *Pages/Instructors/Index.cshtml* page:

[!code-csharp[Main](intro/samples/cu/Pages/Instructors/Index1.cshtml.cs?name=snippet_ThenInclude)]

The query has two includes:

* `OfficeAssignment`: Displayed in the [instructors view](#IP).
* `CourseAssignments`: Which brings in the courses taught.


### Update the instructors Index page

Update *Pages/Instructors/Index.cshtml* with the following markup:

[!code-html[](intro/samples/cu/Pages/Instructors/IndexRRD.cshtml?range=1-65&highlight=1,5,8,16-21,25-32,43-57)]

The preceding markup makes the following changes:

* Updates the `page` directive from `@page` to `@page "{id:int?}"`. `"{id:int?}"` is a route template. The route template changes integer query strings in the URL to route data. For example, clicking on the **Select** link for an instructor when the page directive produces a URL like the following:

	`http://localhost:1234/Instructors?id=2`

	When the page directive is `@page "{id:int?}"`, the previous URL is:

	`http://localhost:1234/Instructors/2`

* Page title is **Instructors**.
* Added an **Office** column that displays `item.OfficeAssignment.Location` only if `item.OfficeAssignment` isn't null. Because this is a one-to-zero-or-one relationship, there might not be a related OfficeAssignment entity.

  ```html
  @if (item.OfficeAssignment != null)
  {
      @item.OfficeAssignment.Location
  }
  ```

* Added a **Courses** column that displays courses taught by each instructor. See [Explicit Line Transition with `@:`](xref:mvc/views/razor#explicit-line-transition-with-) for more about this razor syntax.

* Added code that dynamically adds `class="success"` to the `tr` element of the selected instructor. This sets a background color for the selected row using a Bootstrap class.

  ```html
  string selectedRow = "";
  if (item.CourseID == Model.CourseID)
  {
      selectedRow = "success";
  }
  <tr class="@selectedRow">
  ```

* Added a new hyperlink labeled **Select**. This link sends the selected instructor's ID to the `Index` method and sets a background color.

  ```html
  <a asp-action="Index" asp-route-id="@item.ID">Select</a> |
  ```

Run the app and select the **Instructors** tab. The page displays the `Location` (office) from the related `OfficeAssignment` entity. If OfficeAssignment` is null, an empty table cell is displayed.

![Instructors Index page nothing selected](read-related-data/_static/instructors-index-no-selection.png)

Click on the **Select** link. The row style changes.

### Add courses taught by selected instructor

Update the `OnGetAsync` method in *Pages/Instructors/Index.cshtml.cs* with the following code:

[!code-csharp[Main](intro/samples/cu/Pages/Instructors/Index2.cshtml.cs?name=snippet_OnGetAsync&highlight=1,8,16-999)]

Examine the updated query:

[!code-csharp[Main](intro/samples/cu/Pages/Instructors/Index2.cshtml.cs?name=snippet_ThenInclude)]

The preceding query adds the `Department` entities.

The following code executes when an instructor is selected (`id != null`). The selected instructor is retrieved from the list of instructors in the view model. The view model's `Courses` property is loaded with the `Course` entities from that instructor's `CourseAssignments` navigation property.

[!code-csharp[Main](intro/samples/cu/Pages/Instructors/Index2.cshtml.cs?name=snippet_ID)]

The `Where` method returns a collection. In the preceding `Where` method, only a single `Instructor` entity is returned. The `Single` method converts the collection into a single `Instructor` entity. The `Instructor` entity provides access to the `CourseAssignments` property. `CourseAssignments` provides access to the related `Course` entities.

![Instructor-to-Courses m:M](complex-data-model/_static/courseassignment.png)

The `Single` method is used on a collection when the collection has only one item. The `Single` method throws an exception if the collection is empty or if there's more than one item. An alternative is `SingleOrDefault`, which returns a default value (null in this case) if the collection is empty. Using `SingleOrDefault` on an empty collection:

* Results in an exception (from trying to find a `Courses` property on a null reference).
* The exception message would less clearly indicate the cause of the problem.

The following code populates the view model's `Enrollments` property when a course is selected:

[!code-csharp[Main](intro/samples/cu/Pages/Instructors/Index2.cshtml.cs?name=snippet_courseID)]

Add the following markup to the end of the *Pages/Courses/Index.cshtml* Razor Page:

[!code-html[](intro/samples/cu/Pages/Instructors/IndexRRD.cshtml?range=60-102&highlight=7-999)]

The preceding markup displays a list of courses related to an instructor when an instructor is selected.

Test the app. Click on a **Select** link on the instructors page.

![Instructors Index page instructor selected](read-related-data/_static/instructors-index-instructor-selected.png)

### Show student data

In this section, the app is updated to show the student data for a selected course.

Update the query in the `OnGetAsync` method in *Pages/Instructors/Index.cshtml.cs* with the following code:

[!code-csharp[Main](intro/samples/cu/Pages/Instructors/Index.cshtml.cs?name=snippet_ThenInclude&highlight=6-9)]

Update *Pages/Instructors/Index.cshtml*. Add the following markup to the end of the file:

[!code-html[](intro/samples/cu/Pages/Instructors/IndexRRD.cshtml?range=103-)]

The preceding markup displays a list of the students who are enrolled in the selected course.

Refresh the page and select an instructor. Select a course to see the list of enrolled students and their grades.

![Instructors Index page instructor and course selected](read-related-data/_static/instructors-index.png)

## Using Single

The `Single` method can pass in the `Where` condition instead of calling the `Where` method separately:

[!code-csharp[Main](intro/samples/cu/Pages/Instructors/IndexSingle.cshtml.cs?name=snippet_single&highlight=21,28-29)]

The preceding `Single` approach provides no benefits over using `Where`. Some developers prefer the `Single` approach style.

## Explicit loading

The current code specifies eager loading for `Enrollments` and `Students`:

[!code-csharp[Main](intro/samples/cu/Pages/Instructors/Index.cshtml.cs?name=snippet_ThenInclude&highlight=6-9)]

Suppose users rarely want to see enrollments in a course. In that case, an optimization would be to only load the enrollment data if it's requested. In this section, the `OnGetAsync` is updated to use explicit loading of `Enrollments` and `Students`.

Update the `OnGetAsync` with the following code:

[!code-csharp[Main](intro/samples/cu/Pages/Instructors/IndexXp.cshtml.cs?name=snippet_OnGetAsync&highlight=9-13,29-35)]

The preceding code drops the *ThenInclude* method calls for enrollment and student data. If a course is selected, the highlighted code retrieves:

* The `Enrollment` entities for the selected course.
* The `Student` entities for each `Enrollment`.

Notice the preceding code comments out `.AsNoTracking()`. Navigation properties can only be explicitly loaded for tracked entities.

Test the app. From a users perspective, the app behaves identically to the previous version.

The next tutorial shows how to update related data.

>[!div class="step-by-step"]
>[Previous](xref:data/ef-rp/complex-data-model)
>[Next](xref:data/ef-rp/update-related-data)
