---
title: Add Sort, Filter, Paging - ASP.NET MVC with EF Core
description: Add sorting, filtering, and paging functionality to the Students Index page, and create a page for simple grouping. This article is part of a tutorial series.
author: tdykstra
ms.author: tdykstra
ms.date: 04/20/2026
ms.topic: tutorial
uid: data/ef-mvc/sort-filter-page

# customer intent: As an ASP.NET developer, I want to add sorting, filtering, and paging functionality in ASP.NET MVC with EF Core, so I can customize my site pages and behavior.
---

# Tutorial: Add sorting, filtering, and paging - ASP.NET MVC with EF Core

In the previous tutorial, you implemented a set of web pages for basic CRUD operations for Student entities. In this tutorial, you add sorting, filtering, and paging functionality to the Students Index page. You also create a page that does simple grouping.

In this exercise, you add sorting, filtering, and paging functionality to the Students Index page. You also create a page that does simple grouping. The following illustration shows what the page looks like when you're done. The column headings are links the user can select to sort by that column. Selecting a column heading repeatedly causes the sort order to toggle between ascending and descending.

:::image type="content" source="sort-filter-page/_static/paging.png" border="false" alt-text="Screenshot of the Students index page that includes sorting, filtering, and paging functionality.":::

In this tutorial, you:

> [!div class="checklist"]
> * Add links to support column sorting
> * Add a Search box to support searches
> * Add paging to the Students Index
> * Add links to support the paging action
> * Create an About page for the site

## Prerequisites

* Complete the previous tutorial, [Implement basic CRUD functionality - ASP.NET MVC with EF Core](crud.md)

## Add column sort links

To add sorting to the **Students Index** page, you change the `Index` method of the Students controller and add code to the Student Index view.

### Add sorting functionality to the Index method

In the _StudentsController.cs_ file, replace the `Index` method with the following code:

[!code-csharp[](intro/samples/cu/Controllers/StudentsController.cs?name=snippet_SortOnly)]

This code receives a `sortOrder` parameter from the query string in the URL. The query string value is provided by ASP.NET Core MVC as a parameter to the action method. The parameter is a string value: "Name" or "Date." The value is optionally followed by an underscore and the string "desc" to specify descending order. The default sort order is ascending.

The first time the **Index** page is requested, there's no query string. The students are displayed in ascending order by last name, which is the default as established by the fall-through case in the `switch` statement. When the user selects a column heading hyperlink, the appropriate `sortOrder` value is provided in the query string.

The two `ViewData` elements (`NameSortParm` and `DateSortParm`) are used by the view to configure the column heading hyperlinks with the appropriate query string values.

[!code-csharp[](intro/samples/cu/Controllers/StudentsController.cs?name=snippet_SortOnly&highlight=3-4)]

These code changes include ternary statements for the elements. The first statement specifies that if the `sortOrder` parameter is null or empty, the `NameSortParm` element is set to "name_desc." Otherwise, the element is set to an empty string. These two statements enable the view to set the column heading hyperlinks as follows:

| Current sort order | Last name hyperlink | Date hyperlink |
|---|---|---|
| Last Name ascending  | Descending          | Ascending      |
| Last Name descending | Ascending           | Ascending      |
| Date ascending       | Ascending           | Descending     |
| Date descending      | Ascending           | Ascending      |

The method uses LINQ to Entities to specify the column to sort by. The code creates an `IQueryable` variable before the `switch` statement, modifies it in the `switch` statement, and calls the `ToListAsync` method after the `switch` statement. When you create and modify `IQueryable` variables, no query is sent to the database. The query isn't executed until you convert the `IQueryable` object into a collection by calling a method such as `ToListAsync`. Therefore, this code results in a single query that isn't executed until the `return View` statement.

This code can get verbose when you work with a large number of columns. The last tutorial in this series, [Learn about advanced scenarios > Use dynamic LINQ to simplify code](advanced.md#dynamic-linq), shows how to write code that lets you pass the name of the `OrderBy` column in a string variable.

### Add column heading hyperlinks to the Student Index view

Replace the code in the _Views/Students/Index.cshtml_ file with the following code that adds column heading hyperlinks. The changed lines are highlighted.

[!code-cshtml[](intro/samples/cu/Views/Students/Index2.cshtml?highlight=16,22)]

This code uses the information in the `ViewData` properties to set up hyperlinks with the appropriate query string values.

Run the app, select the **Students** tab, and select the **Last Name** and **Enrollment Date** column headings to verify sorting works.

:::image type="content" source="sort-filter-page/_static/name-order.png" border="false" alt-text="Screenshot of the Students Index page showing the student last names sorted in ascending order.":::

## Add a Search box

To add filtering to the **Students Index** page, you add a text box and a **Submit** button to the view and make corresponding changes in the `Index` method. In the text box, you can enter a string to search for in the Student first name and last name fields.

### Add filtering support to the Index method

In the _StudentsController.cs_ file, replace the `Index` method with the following code (the changes are highlighted).

[!code-csharp[](intro/samples/cu/Controllers/StudentsController.cs?name=snippet_SortFilter&highlight=1,5,9-13)]

You added a `searchString` parameter to the `Index` method. The search string value is received from a text box that you add to the Index view. You also added a `where` clause to the `LINQ` statement that selects only students whose first name or last name match the search string. The statement that adds the `where` clause is executed only if there's a searchable value.

#### Determine how to use the Where method

In this scenario, you call the `Where` method on an `IQueryable` object, and the filter is processed on the server. In some scenarios, you might call the `Where` method as an extension method on an in-memory collection. Suppose you change the reference to `_context.Students`. Instead of calling the Entity Framework `DbSet` method, it references a repository method that returns an `IEnumerable` collection. The result is normally the same, but some cases might be different.

For example, the .NET Framework implementation of the `Contains` method performs a case-sensitive comparison by default. In SQL Server, the determination occurs by the collation setting of the SQL Server instance. The setting defaults to case-insensitive. You might call the `ToUpper` method to make the test explicitly case-insensitive: `Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper())`. This option ensures the results stay the same if you change the code later to use a repository that returns an `IEnumerable` collection rather than an `IQueryable` object. (When you call the `Contains` method on an `IEnumerable` collection, you get the .NET Framework implementation. When you call it on an `IQueryable` object, you get the database provider implementation.)

However, there's a performance penalty for this solution. The `ToUpper` code puts a function in the `WHERE` clause of the `TSQL SELECT` statement. This behavior prevents the optimizer from using an index. Given that SQL is mostly installed as case-insensitive, it's best to avoid the `ToUpper` code until you migrate to a case-insensitive data store.

### Add a Search Box to the Student Index view

In the _Views/Student/Index.cshtml_ file, add the highlighted code immediately before the opening table tag `<table>` in order to create a caption, a text box, and a **Search** button.

[!code-cshtml[](intro/samples/cu/Views/Students/Index3.cshtml?range=9-23&highlight=5-13)]

This code uses the `<form>` [tag helper](xref:mvc/views/tag-helpers/intro) to add the search text box and button. By default, the `<form>` tag helper submits form data with a `POST`, which means the parameters are passed in the HTTP message body and not in the URL as query strings. When you specify HTTP `GET`, the form data is passed in the URL as query strings, which enables users to bookmark the URL. The W3C guidelines recommend using `GET` when the action doesn't result in an update.

Run the app, select the **Students** tab, enter a search string, and select **Search** to verify filtering is working.

:::image type="content" source="sort-filter-page/_static/filtering.png" border="false" alt-text="Screenshot of the Students Index page with filtering included.":::

Notice that the URL contains the search string.

```html
http://localhost:5813/Students?SearchString=an
```

If you bookmark this page, you get the filtered list when you use the bookmark. Adding the `method="get"` clause to the `form` tag causes creation of the query string.

At this stage in your development, if you select a column heading sort link, you lose the filter value that you entered in the **Search** box. You discover how to address that situation in the next section.

## Add paging to the Students Index

To add paging to the **Students Index** page, you create a `PaginatedList` class that uses `Skip` and `Take` statements to filter data on the server instead of always retrieving all table rows. Then you make more changes in the `Index` method and add paging buttons to the `Index` view. The following image shows the paging buttons.

:::image type="content" source="sort-filter-page/_static/paging.png" border="false" alt-text="Screenshot of the Students index page with paging links.":::

In the project folder, create the _PaginatedList.cs_ file. Replace the template code with the following code.

[!code-csharp[](intro/samples/cu/PaginatedList.cs)]

The `CreateAsync` method in this code takes page size and page number and applies the appropriate `Skip` and `Take` statements to the `IQueryable` object. When the `ToListAsync` method is called on the `IQueryable` object, the method returns a `List` containing only the requested page. The `HasPreviousPage` and `HasNextPage` properties can be used to enable or disable **Previous** and **Next** paging buttons.

A `CreateAsync` method is used instead of a constructor to create the `PaginatedList<T>` object because constructors can't run asynchronous code.

## Add paging to the Index method

In the _StudentsController.cs_ file, replace the `Index` method with the following code.

[!code-csharp[](intro/samples/cu/Controllers/StudentsController.cs?name=snippet_SortFilterPage&highlight=1-5,7,11-18,45-46)]

This code adds a page number parameter, a current sort order parameter, and a current filter parameter to the method signature.

```csharp
public async Task<IActionResult> Index(
    string sortOrder,
    string currentFilter,
    string searchString,
    int? pageNumber)
```

The first time the page displays, or a paging or sorting link isn't selected yet, all parameters are null. If a paging link is selected, the page variables contain the page number to display.

The `ViewData` element named `CurrentSort` provides the view with the current sort order. This value must be included in the paging links so the sort order stays the same while paging.

The `ViewData` element named `CurrentFilter` provides the view with the current filter string. This value must be included in the paging links to maintain the filter settings during paging. The value must be restored to the text box when the page displays.

If the search string is changed during paging, the page must be reset to 1 because the new filter can result in different data to display. The search string is changed when a value is entered in the text box and the user selects **Submit**. In this scenario, the `searchString` parameter isn't null.

```csharp
if (searchString != null)
{
    pageNumber = 1;
}
else
{
    searchString = currentFilter;
}
```

At the end of the `Index` method, the `PaginatedList.CreateAsync` method converts the student query to a single page of students in a collection type that supports paging. The single page of students is then passed to the view.

```csharp
return View(await PaginatedList<Student>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize));
```

The `PaginatedList.CreateAsync` method takes a page number. The two question marks `??` represent the null-coalescing operator. The null-coalescing operator defines a default value for a nullable type. The expression `(pageNumber ?? 1)` means return the value of `pageNumber` if it has a value, or return 1 if `pageNumber` is null.

## Add paging links

In the _Views/Students/Index.cshtml_ file, replace the existing code with the following code. The changes are highlighted.

[!code-cshtml[](intro/samples/cu/Views/Students/Index.cshtml?highlight=1,27,30,33,61-79)]

The `@model` statement at the top of the page specifies that the view now gets a `PaginatedList<T>` object instead of a `List<T>` object.

The column header links use the query string to pass the current search string to the controller so the user can sort within filter results:

```html
<a asp-action="Index" asp-route-sortOrder="@ViewData["DateSortParm"]" asp-route-currentFilter ="@ViewData["CurrentFilter"]">Enrollment Date</a>
```

Tag helpers display the paging buttons:

```html
<a asp-action="Index"
   asp-route-sortOrder="@ViewData["CurrentSort"]"
   asp-route-pageNumber="@(Model.PageIndex - 1)"
   asp-route-currentFilter="@ViewData["CurrentFilter"]"
   class="btn btn-default @prevDisabled">
   Previous
</a>
```

Run the app and go to the **Students** page.

:::image type="content" source="sort-filter-page/_static/paging.png" border="false" alt-text="Screenshot of the refreshed Students Index page with paging links.":::

Select the paging links in different sort orders and make sure paging works. Enter a search string and try paging again to verify paging also works correctly with sorting and filtering.

## Create an About page

For the Contoso University website's **About** page, you display how many students are enrolled for each enrollment date. This functionality requires grouping and simple calculations on the groups. To support this behavior, you complete the following tasks:

* Create a view model class for the data that you need to pass to the view.
* Create the `About` method in the Home controller.
* Create the About view.

### Create the view model

Create a *SchoolViewModels* folder in the *Models* folder.

In the new folder, add an _EnrollmentDateGroup.cs_ class file and replace the template code with the following code:

[!code-csharp[](intro/samples/cu/Models/SchoolViewModels/EnrollmentDateGroup.cs)]

### Modify the Home Controller

In the _HomeController.cs_ file, add the following `using` statements at the top of the file:

[!code-csharp[](intro/samples/cu/Controllers/HomeController.cs?name=snippet_Usings1)]

Add a class variable for the database context immediately after the opening curly brace `{` for the class, and get an instance of the context from ASP.NET Core DI:

[!code-csharp[](intro/samples/cu/Controllers/HomeController.cs?name=snippet_AddContext&highlight=4,6,9)]

Add an `About` method with the following code:

[!code-csharp[](intro/samples/cu/Controllers/HomeController.cs?name=snippet_UseDbSet)]

The `LINQ` statement groups the student entities by enrollment date. It calculates the number of entities in each group, and stores the results in a collection of `EnrollmentDateGroup` view model objects.

### Create the About view

Add a _Views/Home/About.cshtml_ file with the following code:

[!code-cshtml[](intro/samples/cu/Views/Home/About.cshtml)]

Run the app and go to the **About** page. The count of students for each enrollment date is displayed in a table.

## Get the code

[Download or view the completed application](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/data/ef-mvc/intro/samples/cu-final).

## Next step

> [!div class="nextstepaction"]
> [Tutorial: Apply migrations (data model changes) to the Contoso University sample](migrations.md)
