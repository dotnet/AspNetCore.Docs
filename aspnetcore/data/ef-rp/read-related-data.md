---
title: Razor Pages with EF Core - Read Related Data - 6 of 10
author: tdykstra
description: In this tutorial you'll read and display related data -- that is, data that the Entity Framework loads into navigation properties.
keywords: ASP.NET Core,Entity Framework Core,related data,joins
ms.author: tdykstra
manager: wpickett
ms.date: 11/05/2017
ms.topic: get-started-article
ms.technology: aspnet
ms.prod: asp.net-core
uid: data/ef-rp/read-related-data
---

en-us/

\replace\

It helps see the DB schema when reviewing the query:

![Entity diagram](complex-data-model/_static/diagram.png)

# Reading related data - EF Core with Razor Pages  (6 of 10)

By [Tom Dykstra](https://github.com/tdykstra) and [Rick Anderson](https://twitter.com/RickAndMSFT)

[!INCLUDE[validation](../../includes/RP-EF/intro.md)]

In this tutorial, related data is is read and displayed. Related data is data that EF loads into navigation properties.

The following illustrations show the completed pages for this tutorial:

![Courses Index page](read-related-data/_static/courses-index.png)

![Instructors Index page](read-related-data/_static/instructors-index.png)

## Eager, explicit, and lazy Loading of related data

There are several ways that EF can load related data into the navigation properties of an entity:

* [Eager loading](https://docs.microsoft.com/en-us/ef/core/querying/related-data). Eager loading is the process whereby a query for one type of entity also loads related entities as part of the query. When the entity is read, its related data is retrieved. This typically results in a single join query that retrieves all of the data that's needed. Eager loading is specified with the `Include` and `ThenInclude` methods.

  ![Eager loading example](read-related-data/_static/eager-loading.png)
  
 The data can be retrieved in separate queries, and EF "fixes up" the navigation properties. "fixes up" means that EF automatically populates the navigation properties. Eager loading with separate queries results in multiple queries sent to the DB.

  ![Separate queries example](read-related-data/_static/separate-queries.png)
  
  Note: EF Core automatically fixes up navigation properties to any other entities that were previously loaded into the context instance. Even if the data for a navigation property is *not* explicitly included, the property may still be populated if some or all of the related entities were previously loaded.

* [Explicit loading](https://docs.microsoft.com/en-us/ef/core/querying/related-data). When the entity is first read, related data isn't retrieved. Code must be written to retrieve the related data when it's needed. Explicit loading with separate queries results in multiple queries sent to the DB. With explicit loading, the code specifies the navigation properties to be loaded. Use the `Load` method to do explicit loading. For example:

  ![Explicit loading example](read-related-data/_static/explicit-loading.png)

* Lazy loading. [EF Core does not currently support lazy loading](https://github.com/aspnet/EntityFrameworkCore/issues/3797). When the entity is first read, related data isn't retrieved. The first time a navigation property is accessed, the data required for that navigation property is automatically retrieved. A query is sent to the DB each time a navigation property is accessed for the first time.

### Performance considerations

If related data for every entity retrieved is needed:

* Eager loading generally offers the best performance.
* Eager loading sends a single query to the DB. A single query is typically more efficient than separate queries for each entity retrieved. 

For example, suppose that each department has 10 related courses. Eager loading of all related data would result in just a single (join) query and a single round trip to the DB. A separate query for courses for each department would result in 11 round trips to the DB. The extra round trips to the DB are especially detrimental to performance when latency is high.

In some scenarios, separate queries is more efficient. Eager loading of all related data might cause a very complex join to be generated. SQL Server might not be able to process a complex join efficiently. If only a subset of related data needs to be accessed, eparate queries might perform better. Eager loading loads all related data, and the extra data fetching may cost more than seperate queries. It's best to test performance both ways in order to find the optimal approach.

## Create a Courses page that displays Department name

The Course entity includes a navigation property that contains the Department entity.  The Department entity contains the department that the course is assigned to. 

To display the name of the assigned department in a list of courses:

* Get the `Name` property from the Department entity.
* The Department entity comes from the `Course.Department` navigation property.

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

`1>Pages\Courses\Index.cshtml.cs(26,37,26,43): error CS1061: 'SchoolContext' does not
 contain a definition for 'Course' and no extension method 'Course' accepting a first
 argument of type 'SchoolContext' could be found (are you missing a using directive or 
 an assembly reference?)`

 Globally change `_context.Course` to `_context.Courses` (that is, add an "s" to `Course`). 7 occurrences are found and updated. 
 
Open *Pages/Courses/Index.cshtml.cs* and examine the `OnGetAsync` method. The scaffolding engine specified eager loading for the `Department` navigation property. The `Include` method specifies eager loading.

Update the `OnGetAsync` method with the following code that adds `AsNoTracking`. `AsNoTracking` improves performance because the entities returned are not tracked. The enties are not tracked because they won't be updated in the current context. 

[!code-csharp[Main](intro\samples\cu\Pages\Courses\Index.cshtml.cs?name=snippet_RevisedIndexMethod)]

Open *Views/Courses/Index.cshtml* and replace the template code with the following code. The changes are highlighted:

[!code-html[](intro\samples\cu\Pages\Courses\Index.cshtml?highlight=4,7,15-17,34-36,44)]

The following changes have been made to the scaffolded code:

* Changed the heading from Index to Courses.
* Added a **Number** column that shows the `CourseID` property value. By default, primary keys aren't scaffolded because normally they are meaningless to end users. However, in this case the primary key is meaningful.
* Changed the **Department** column to display the department name. The code displays the `Name` property of the Department entity that's loaded into the `Department` navigation property:

  ```html
  @Html.DisplayFor(modelItem => item.Department.Name)
  ```

Run the app and select the **Courses** tab to see the list with department names.

![Courses Index page](read-related-data/_static/courses-index.png)

## Create an Instructors page that shows Courses and Enrollments

In this section, the Instructors page is created. 
<a name="IP"></a>
![Instructors Index page](read-related-data/_static/instructors-index.png)

This page reads and displays related data in the following ways:

* The list of instructors displays related data from the `OfficeAssignment` entity. The `Instructor` and `OfficeAssignment` entities are in a one-to-zero-or-one relationship. Eager loading is used for the `OfficeAssignment` entities. Eager loading is typically more efficient when the related data needs to be displayed. In this case, office assignments for the instructors are displayed.
* When the user selects an instructor, related `Course` entities are displayed. The `Instructor` and `Course` entities are in a many-to-many relationship. Eager loading for the `Course` entities and their related `Department` entities is used. In this case, separate queries might be more efficient because only courses for the selected instructor is needed. This example shows how to use eager loading for navigation properties in entities that are in navigation properties.
* When the user selects a course, related data from the `Enrollments` entity is displayed. The `Course` and `Enrollment` entities are in a one-to-many relationship. Separate queries for `Enrollment` entities and their related `Student` entities are used.

### Create a view model for the Instructor Index view

The instructors page shows data from three different tables. A view model is created that includes three properties. Each property holds data for one of the tables.

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

Globally change `_context.Instructor` to `_context.Instructors` (that is, add an "s" to `Course`). 7 occurrences are found and updated. 

Replace *Pages\Instructors\Index.cshtml.cs* with the following code:

[!code-csharp[Main](intro\samples\cu\Pages\Instructors\Index1.cshtml.cs?name=snippet_all&highlight=2,20-)]

The `OnGetAsync` method accepts optional route data for the ID of the selected instructor. 

Examine the query on the *Pages\Instructors\Index.cshtml*  page:

[!code-csharp[Main](intro\samples\cu\Pages\Instructors\Index1.cshtml.cs?name=snippet_ThenInclude)]

The query has two includes:

* `OfficeAssignment`: Displayed in the [instructors view](#IP). 
* `CourseAssignments`: Which brings in the courses taught.


### Update the instructors Index page

Update *Pages\Instructors\Index.cshtml* with the following markup:

[!code-html[](intro\samples\cu\Pages\Instructors\Index.cshtml?range=1-65&highlight=5,8,16-21,25-32,43-57)]

The preceding markup makes the following changes:

* Page title renamed **Instructors**.
* Added an **Office** column that displays `item.OfficeAssignment.Location` only if `item.OfficeAssignment` is not null. Because this is a one-to-zero-or-one relationship, there might not be a related OfficeAssignment entity.

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
  if (item.ID == (int?)ViewData["InstructorID"])
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

### Add courses taught by selected instructor

Update the `OnGetAsync` method in *Pages\Instructors\Index.cshtml.cs* with the following code:

[!code-csharp[Main](intro\samples\cu\Pages\Instructors\Index2.cshtml.cs?name=snippet_OnGetAsync&highlight=1,8,16-)]

Examine the updated query:

[!code-csharp[Main](intro\samples\cu\Pages\Instructors\Index2.cshtml.cs?name=snippet_ThenInclude)]

The preceding query adds the `Department` entities.

The following code executes when an instructor is selected (`id != null`). The selected instructor is retrieved from the list of instructors in the view model. The view model's `Courses` property is loaded with the `Course` entities from that instructor's `CourseAssignments` navigation property.

[!code-csharp[Main](intro\samples\cu\Pages\Instructors\Index2.cshtml.cs?name=snippet_ID)]

The `Where` method returns a collection. In the preceding `Where` method, only a single `Instructor` entity is returned. The `Single` method converts the collection into a single `Instructor` entity (`i.ID == id.Value`). The `Instructor` entity provides access to that to the `CourseAssignments` property. `CourseAssignments` provides access to the related `Course` entities.

![Instructor-to-Courses m:M](complex-data-model/_static/courseassignment.png)

The `Single` method  is used on a collection when  the collection has only one item. The `Single` method throws an exception if the collection passed to it is empty or if there's more than one item. An alternative is `SingleOrDefault`, which returns a default value (null in this case) if the collection is empty. Using `SingleOrDefault` on an empty collection:

* Results in an exception (from trying to find a `Courses` property on a null reference).
* The exception message would less clearly indicate the cause of the problem. 

The `Single` method can also pass in the `Where` condition instead of calling the `Where` method separately:

```csharp
.Single(i => i.ID == id.Value)
```

Instead of:

```csharp
.Where(I => i.ID == id.Value).Single()
```

The following code populates the view model's `Enrollments` property when a coure is selected:

[!code-csharp[Main](intro\samples\cu\Pages\Instructors\Index2.cshtml.cs?name=snippet_courseID)]

Add the following markup to the end of the *Pages\Courses\Index.cshtml* Razor Page:

[!code-html[](intro\samples\cu\Pages\Instructors\Index.cshtml?range=60-&highlight=7-)]

The preceding markup displays a list of courses related to an instructor when an instructor is selected.

Test the app. Click on a **Select** link on the instructors page.

![Instructors Index page instructor selected](read-related-data/_static/instructors-index-instructor-selected.png)

### Update the instructors page query

Update the query in the `OnGetAsync` method in *Pages\Instructors\Index.cshtml.cs* with the following code:

[!code-csharp[Main](intro\samples\cu\Pages\Instructors\Index.cshtml.cs?name=snippet_all&highlight=7-9)]

Update *Pages\Instructors\Index.cshtml* with the following markup:

[!code-html[](intro\samples\cu\Pages\Instructors\Index.cshtml?range=1-65&highlight=5,8,16-21,25-32,43-57)]

The preceding markup makes the following changes:

[!code-csharp[Main](intro\samples\cu\Pages\Instructors\Index.cshtml.cs?name=snippet_ThenInclude&highlight=3-6)]

<!-- zz


After the code block you just added, add the following code. This displays a list of the students who are enrolled in a course when that course is selected.

[!code-html[](intro/samples/cu/Views/Instructors/Index1.cshtml&range=103-125)]

This code reads the Enrollments property of the view model in order to display a list of students enrolled in the course.

Refresh the page again and select an instructor. Then select a course to see the list of enrolled students and their grades.

![Instructors Index page instructor and course selected](read-related-data/_static/instructors-index.png)

## Explicit loading

When you retrieved the list of instructors in *InstructorsController.cs*, you specified eager loading for the `CourseAssignments` navigation property.

Suppose you expected users to only rarely want to see enrollments in a selected instructor and course. In that case, you might want to load the enrollment data only if it's requested. To see an example of how to do explicit loading, replace the `Index` method with the following code, which removes eager loading for Enrollments and loads that property explicitly. The code changes are highlighted.

[!code-csharp[Main](intro\samples\cu\Pages\Instructors\Index.cshtml.cs?name=snippet_ExplicitLoading&highlight=2)]

The new code drops the *ThenInclude* method calls for enrollment data from the code that retrieves instructor entities. If an instructor and course are selected, the highlighted code retrieves Enrollment entities for the selected course, and Student entities for each Enrollment.

Run the app, go to the Instructors Index page now and you'll see no difference in what's displayed on the page, although you've changed how the data is retrieved.

## Summary

You've now used eager loading with one query and with multiple queries to read related data into navigation properties. In the next tutorial you'll learn how to update related data.

-->

>[!div class="step-by-step"]
>[Previous](xref:data/ef-rp/complex-data-model)
