---
title: Razor Pages with EF Core - Update Related Data - 7 of 8
author: rick-anderson
description: In this tutorial you'll update related data by updating foreign key fields and navigation properties.
ms.author: riande
manager: wpickett
ms.date: 11/15/2017
ms.topic: get-started-article
ms.technology: aspnet
ms.prod: asp.net-core
uid: data/ef-rp/update-related-data
---

# Updating related data - EF Core Razor Pages (7 of 8)

By [Tom Dykstra](https://github.com/tdykstra), and [Rick Anderson](https://twitter.com/RickAndMSFT)

[!INCLUDE[about the series](../../includes/RP-EF/intro.md)]

This tutorial demonstrates updating related data. If you run into problems you can't solve, download the [completed app for this stage](https://github.com/aspnet/Docs/tree/master/aspnetcore/data/ef-rp/intro/samples/StageSnapShots/cu-part7).

The following illustrations shows some of the completed pages.

![Course Edit page](update-related-data/_static/course-edit.png)
![Instructor Edit page](update-related-data/_static/instructor-edit-courses.png)

Examine and test the Create and Edit course pages. Create a new course. The department is selected by its primary key (an integer), not its name. Edit the new course. When you have finished testing, delete the new course.

## Create a base class to share common code

The Courses/Create and Courses/Edit pages each need a list of department names. Create the *Pages/Courses/DepartmentNamePageModel.cshtml.cs* base class for the Create and Edit pages:

[!code-csharp[Main](intro/samples/cu/Pages/Courses/DepartmentNamePageModel.cshtml.cs?highlight=9,11,20-21)]

The preceding code creates a [SelectList](https://docs.microsoft.com/dotnet/api/microsoft.aspnetcore.mvc.rendering.selectlist?view=aspnetcore-2.0) to contain the list of department names. If `selectedDepartment` is specified, that department is selected in the `SelectList`.

The Create and Edit page model classes will derive from `DepartmentNamePageModel`.

## Customize the Courses Pages

When a new course entity is created, it must have a relationship to an existing department. To add a department while creating a course, the base class for Create and Edit contains a drop-down list for selecting the department. The drop-down list sets the `Course.DepartmentID` foreign key (FK) property. EF Core uses the `Course.DepartmentID` FK to load the `Department` navigation property.

![Create course](update-related-data/_static/ddl.png)

Update the Create page model with the following code:

[!code-csharp[Main](intro/samples/cu/Pages/Courses/Create.cshtml.cs?highlight=7,18,32-)]

The preceding code:

* Derives from `DepartmentNamePageModel`.
* Uses `TryUpdateModelAsync` to prevent [overposting](xref:data/ef-rp/crud#overposting).
* Replaces `ViewData["DepartmentID"]` with `DepartmentNameSL` (from the base class).

`ViewData["DepartmentID"]` is replaced with the strongly typed `DepartmentNameSL`. Strongly typed models are preferred over weakly typed. For more information, see [Weakly typed data (ViewData and ViewBag)](xref:mvc/views/overview#VD_VB).

### Update the Courses Create page

Update *Pages/Courses/Create.cshtml* with the following markup:

[!code-cshtml[Main](intro/samples/cu/Pages/Courses/Create.cshtml?highlight=29-34)]

The preceding markup makes the following changes:

* Changes the caption from **DepartmentID** to **Department**.
* Replaces `"ViewBag.DepartmentID"` with `DepartmentNameSL` (from the base class).
* Adds the "Select Department" option. This change renders "Select Department" rather than the first department.
* Adds a validation message when the department is not selected.

The Razor Page uses the [Select Tag Helper](xref:mvc/views/working-with-forms#the-select-tag-helper):

[!code-cshtml[Main](intro/samples/cu/Pages/Courses/Create.cshtml?range=28-35&highlight=3-6)]

Test the Create page. The Create page displays the department name rather than the department ID.

### Update the Courses Edit page.

Update the edit page model with the following code:

[!code-csharp[Main](intro/samples/cu/Pages/Courses/Edit.cshtml.cs?highlight=8,28,35,36,40,47-)]

The changes are similar to those made in the Create page model. In the preceding code, `PopulateDepartmentsDropDownList` passes in the department ID, which select the department specified in the drop-down list.

Update *Pages/Courses/Edit.cshtml* with the following markup:

[!code-cshtml[Main](intro/samples/cu/Pages/Courses/Edit.cshtml?highlight=17-20,32-35)]

The preceding markup makes the following changes:

* Displays the course ID. Generally the Primary Key (PK) of an entity is not displayed. PKs are usually meaningless to users. In this case, the PK is the course number.
* Changes the caption from **DepartmentID** to **Department**.
* Replaces `"ViewBag.DepartmentID"` with `DepartmentNameSL` (from the base class).
* Adds the "Select Department" option. This change renders "Select Department" rather than the first department.
* Adds a validation message when the department is not selected.

The page contains a hidden field (`<input type="hidden">`) for the course number. Adding a `<label>` tag helper with `asp-for="Course.CourseID"` doesn't eliminate the need for the hidden field. `<input type="hidden">` is required for the course number to be included in the posted data when the user clicks **Save**.

Test the updated code. Create, edit, and delete a course.

## Add AsNoTracking to the Details and Delete page models

[AsNoTracking](https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.entityframeworkqueryableextensions.asnotracking?view=efcore-2.0#Microsoft_EntityFrameworkCore_EntityFrameworkQueryableExtensions_AsNoTracking__1_System_Linq_IQueryable___0__) can improve performance when tracking is not required. Add `AsNoTracking` to the Delete and Details page model. The following code shows the updated Delete page model:

[!code-csharp[Main](intro/samples/cu/Pages/Courses/Delete.cshtml.cs?name=snippet&highlight=21,23,40,41)]

Update the `OnGetAsync` method in the *Pages/Courses/Details.cshtml.cs* file:

[!code-csharp[Main](intro/samples/cu/Pages/Courses/Details.cshtml.cs?name=snippet)]

### Modify the Delete and Details pages

Update the Delete Razor page with the following markup:

[!code-cshtml[Main](intro/samples/cu/Pages/Courses/Delete.cshtml?highlight=15-20)]

Make the same changes to the Details page.

### Test the Course pages

Test create, edit, details, and delete.

## Update the instructor pages

The following sections update the instructor pages.

### Add office location

When editing an instructor record, you may want to update the instructor's office assignment. The `Instructor` entity has a one-to-zero-or-one relationship with the `OfficeAssignment` entity. The instructor code must handle:

* If the user clears the office assignment, delete the `OfficeAssignment` entity.
* If the user enters an office assignment and it was empty, create a new `OfficeAssignment` entity.
* If the user changes the office assignment, update the `OfficeAssignment` entity.

Update the instructors Edit page model with the following code:

[!code-csharp[Main](intro/samples/cu/Pages/Instructors/Edit1.cshtml.cs?name=snippet&highlight=20-23,32,39-)]

The preceding code:

- Gets the current `Instructor` entity from the database using eager loading for the `OfficeAssignment` navigation property.
- Updates the retrieved `Instructor` entity with values from the model binder. `TryUpdateModel` prevents [overposting](xref:data/ef-rp/crud#overposting).
- If the office location is blank, sets `Instructor.OfficeAssignment` to null. When `Instructor.OfficeAssignment` is null, the related row in the `OfficeAssignment` table is deleted.

### Update the instructor Edit page

Update *Pages/Instructors/Edit.cshtml* with the office location:

[!code-cshtml[Main](intro/samples/cu/Pages/Instructors/Edit1.cshtml?highlight=29-33)]

Verify you can change an instructors office location.

## Add Course assignments to the instructor Edit page

Instructors may teach any number of courses. In this section, you add the ability to change course assignments. The following image shows the updated instructor Edit page:

![Instructor Edit page with courses](update-related-data/_static/instructor-edit-courses.png)

`Course` and `Instructor` has a many-to-many relationship. To add and remove relationships, you add and remove entities from the `CourseAssignments` join entity set.

Check boxes enable changes to courses an instructor is assigned to. A check box is displayed for every course in the database. Courses that the instructor is assigned to are checked. The user can select or clear check boxes to change course assignments. If the number of courses were much greater:

* You'd probably use a different user interface to display the courses.
* The method of manipulating a join entity to create or delete relationships would not change.

### Add classes to support Create and Edit instructor pages

Create *SchoolViewModels/AssignedCourseData.cs* with the following code:

[!code-csharp[Main](intro/samples/cu/Models/SchoolViewModels/AssignedCourseData.cs)]

The `AssignedCourseData` class contains data to create the check boxes for assigned courses by an instructor.

Create the *Pages/Instructors/InstructorCoursesPageModel.cshtml.cs* base class:

[!code-csharp[Main](intro/samples/cu/Pages/Instructors/InstructorCoursesPageModel.cshtml.cs)]

The `InstructorCoursesPageModel` is the base class you will use for the Edit and Create page models. `PopulateAssignedCourseData` reads all `Course` entities to populate `AssignedCourseDataList`. For each course, the code sets the `CourseID`, title, and whether or not the instructor is assigned to the course. A [HashSet](https://docs.microsoft.com/dotnet/api/system.collections.generic.hashset-1) is used to create efficient lookups.

### Instructors Edit page model

Update the instructor Edit page model with the following code:

[!code-csharp[Main](intro/samples/cu/Pages/Instructors/Edit.cshtml.cs?name=snippet&highlight=1,20-24,30,34,41-)]

The preceding code handles office assignment changes.

Update the instructor Razor View:

[!code-cshtml[Main](intro/samples/cu/Pages/Instructors/Edit.cshtml?highlight=34-59)]

<a id="notepad"></a>
> [!NOTE]
> When you paste the code in Visual Studio, line breaks are changed in a way that breaks the code. Press Ctrl+Z one time to undo the automatic formatting. Ctrl+Z fixes the line breaks so that they look like what you see here. The indentation doesn't have to be perfect, but the `@</tr><tr>`, `@:<td>`, `@:</td>`, and `@:</tr>` lines must each be on a single line as shown. With the block of new code selected, press Tab three times to line up the new code with the existing code. Vote on or review the status of this bug [with this link](https://developercommunity.visualstudio.com/content/problem/147795/razor-editor-malforms-pasted-markup-and-creates-in.html).

The preceding code creates an HTML table that has three columns. Each column has a check box and a caption containing the course number and title. The check boxes all have the same name ("selectedCourses"). Using the same name informs the model binder to treat them as a group. The value attribute of each check box is set to `CourseID`. When the page is posted, the model binder passes an array that consists of the `CourseID` values for only the check boxes that are selected.

When the check boxes are initially rendered, courses assigned to the instructor have checked attributes.

Run the app and test the updated instructors Edit page. Change some course assignments. The changes are reflected on the Index page.

Note: The approach taken here to edit instructor course data works well when there is a limited number of courses. For collections that are much larger, a different UI and a different updating method would be more useable and efficient.

### Update the instructors Create page

Update the instructor Create page model with the following code:

[!code-csharp[Main](intro/samples/cu/Pages/Instructors/Create.cshtml.cs)]

The preceding code is similar to the *Pages/Instructors/Edit.cshtml.cs* code.

Update the instructor Create Razor page with the following markup:

[!code-cshtml[Main](intro/samples/cu/Pages/Instructors/Create.cshtml?highlight=32-62)]

Test the instructor Create page.

## Update the Delete page

Update the Delete page model with the following code:

[!code-csharp[Main](intro/samples/cu/Pages/Instructors/Delete.cshtml.cs?highlight=5,40-)]

The preceding code makes the following changes:

* Uses eager loading for the `CourseAssignments` navigation property. `CourseAssignments` must be included or they aren't deleted when the instructor is deleted. To avoid needing to read them, configure cascade delete in the database.

* If the instructor to be deleted is assigned as administrator of any departments, removes the instructor assignment from those departments.

>[!div class="step-by-step"]
[Previous](xref:data/ef-rp/read-related-data)
[Next](xref:data/ef-rp/concurrency)
