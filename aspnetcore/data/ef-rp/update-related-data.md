---
title: Razor Pages with EF Core - Update Related Data - 7 of 10
author: tdykstra
description: In this tutorial you'll update related data by updating foreign key fields and navigation properties.
keywords: ASP.NET Core,Entity Framework Core,related data,joins
ms.author: tdykstra
manager: wpickett
ms.date: 11/15/2017
ms.topic: get-started-article
ms.technology: aspnet
ms.prod: asp.net-core
uid: data/ef-rp/update-related-data
---

# Updating related data - EF Core Razor Pages (7 of 10)

By [Tom Dykstra](https://github.com/tdykstra) and [Rick Anderson](https://twitter.com/RickAndMSFT)

[!INCLUDE[about the series](../../includes/RP-EF/intro.md)]

This tutorial demonstrates updating related data.

The following illustrations shows some of the completed pages.

![Course Edit page](update-related-data/_static/course-edit.png)
![Instructor Edit page](update-related-data/_static/instructor-edit-courses.png)

## Customize the Create and Edit Pages for Courses

When a new course entity is created, it must have a relationship to an existing department. To add a department while creating a course, the Create and Edit pages contain a drop-down list for selecting the department. The drop-down list sets the `Course.DepartmentID` foreign key (FK) property. EF uses the `Course.DepartmentID` FK to load the `Department` navigation property.

In *CoursesController.cs*, delete the four Create and Edit methods and replace them with the following code:
<!--
[!code-csharp[Main](intro/samples/cu/Controllers/CoursesController.cs?name=snippet_CreateGet)]

[!code-csharp[Main](intro/samples/cu/Controllers/CoursesController.cs?name=snippet_CreatePost)]

[!code-csharp[Main](intro/samples/cu/Controllers/CoursesController.cs?name=snippet_EditGet)]

[!code-csharp[Main](intro/samples/cu/Controllers/CoursesController.cs?name=snippet_EditPost)]

After the `Edit` HttpPost method, create a new method that loads department info for the drop-down list.

[!code-csharp[Main](intro/samples/cu/Controllers/CoursesController.cs?name=snippet_Departments)]

The `PopulateDepartmentsDropDownList` method gets a list of all departments sorted by name, creates a `SelectList` collection for a drop-down list, and passes the collection to the view in `ViewBag`. The method accepts the optional `selectedDepartment` parameter that allows the calling code to specify the item that will be selected when the drop-down list is rendered. The view will pass the name "DepartmentID" to the `<select>` tag helper, and the helper then knows to look in the `ViewBag` object for a `SelectList` named "DepartmentID".

The HttpGet `Create` method calls the `PopulateDepartmentsDropDownList` method without setting the selected item, because for a new course the department is not established yet:

[!code-csharp[Main](intro/samples/cu/Controllers/CoursesController.cs?highlight=3&name=snippet_CreateGet)]

The HttpGet `Edit` method sets the selected item, based on the ID of the department that is already assigned to the course being edited:

[!code-csharp[Main](intro/samples/cu/Controllers/CoursesController.cs?highlight=15&name=snippet_EditGet)]

The HttpPost methods for both `Create` and `Edit` also include code that sets the selected item when they redisplay the page after an error. This ensures that when the page is redisplayed to show the error message, whatever department was selected stays selected.

### Add .AsNoTracking to Details and Delete methods

To optimize performance of the Course Details and Delete pages, add `AsNoTracking` calls in the `Details` and HttpGet `Delete` methods.

[!code-csharp[Main](intro/samples/cu/Controllers/CoursesController.cs?highlight=10&name=snippet_Details)]

[!code-csharp[Main](intro/samples/cu/Controllers/CoursesController.cs?highlight=10&name=snippet_DeleteGet)]

### Modify the Course views

In *Views/Courses/Create.cshtml*, add a "Select Department" option to the **Department** drop-down list, change the caption from **DepartmentID** to **Department**, and add a validation message.

[!code-html[Main](intro/samples/cu/Views/Courses/Create.cshtml?highlight=2-6&range=29-34)]

In *Views/Courses/Edit.cshtml*, make the same change for the Department field that you just did in *Create.cshtml*.

Also in *Views/Courses/Edit.cshtml*, add a course number field before the **Title** field. Because the course number is the primary key, it's displayed, but it can't be changed.

[!code-html[Main](intro/samples/cu/Views/Courses/Edit.cshtml?range=15-18)]

There's already a hidden field (`<input type="hidden">`) for the course number in the Edit view. Adding a `<label>` tag helper doesn't eliminate the need for the hidden field because it doesn't cause the course number to be included in the posted data when the user clicks **Save** on the **Edit** page.

In *Views/Courses/Delete.cshtml*, add a course number field at the top and change department ID to department name.

[!code-html[Main](intro/samples/cu/Views/Courses/Delete.cshtml?highlight=14-19,36)]

In *Views/Courses/Details.cshtml*, make the same change that you just did for *Delete.cshtml*.

### Test the Course pages

Run the app, select the **Courses** tab, click **Create New**, and enter data for a new course:

![Course Create page](update-related-data/_static/course-create.png)

Click **Create**. The Courses Index page is displayed with the new course added to the list. The department name in the Index page list comes from the navigation property, showing that the relationship was established correctly.

Click **Edit** on a course in the Courses Index page.

![Course Edit page](update-related-data/_static/course-edit.png)

Change data on the page and click **Save**. The Courses Index page is displayed with the updated course data.

## Add an Edit Page for Instructors

When you edit an instructor record, you want to be able to update the instructor's office assignment. The Instructor entity has a one-to-zero-or-one relationship with the OfficeAssignment entity, which means your code has to handle the following situations:

* If the user clears the office assignment and it originally had a value, delete the OfficeAssignment entity.

* If the user enters an office assignment value and it originally was empty, create a new OfficeAssignment entity.

* If the user changes the value of an office assignment, change the value in an existing OfficeAssignment entity.



-->

>[!div class="step-by-step"]
[Previous](xref:data/ef-mvc/read-related-data)