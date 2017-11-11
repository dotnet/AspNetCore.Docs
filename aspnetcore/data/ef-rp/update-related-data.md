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
en-us/
\

# Updating related data - EF Core Razor Pages (7 of 10)

By [Tom Dykstra](https://github.com/tdykstra) and [Rick Anderson](https://twitter.com/RickAndMSFT)

[!INCLUDE[about the series](../../includes/RP-EF/intro.md)]

This tutorial demonstrates updating related data.

The following illustrations shows some of the completed pages.

![Course Edit page](update-related-data/_static/course-edit.png)
![Instructor Edit page](update-related-data/_static/instructor-edit-courses.png)

Examine and test the Create and Edit course pages. Create a new course. You need to select the department by it's primary key (an integer), not it's name. Edit the new course. When you have finished testing, delete the new course.

## Create a base class to share common code

The Courses/Create and Courses/Edit pages each need a list of department names. Create the following base class for the Create and Edit pages:

[!code-csharp[Main](intro/samples/cu/Pages/Courses/DepartmentNamePageModel.cshtml.cs?highlight=9,11,20-21)]

The preceding code creates a [SelectList](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.rendering.selectlist?view=aspnetcore-2.0) to contain the list of deparment names. If `selectedDepartment` is specified, that department is selected in the `SelectList`.

The Create and Edit page model classes will derive from `DepartmentNamePageModel`.

## Customize the Courses Pages 

When a new course entity is created, it must have a relationship to an existing department. To add a department while creating a course, the base class for Create and Edit contains a drop-down list for selecting the department. The drop-down list sets the `Course.DepartmentID` foreign key (FK) property. EF uses the `Course.DepartmentID` FK to load the `Department` navigation property.

![Create course](update-related-data/_static/ddl.png)

Update the Create page model with the following code:

[!code-csharp[Main](intro/samples/cu/Pages/Courses/Create.cshtml.cs?highlight=7,18,32-)]

The preceding code:

* Derives from `DepartmentNamePageModel`.
* Uses `TryUpdateModelAsync` to prevent [overposting](xref:data/ef-rp/crud#overposting).
* Replaces `ViewData["DepartmentID"]` with `DepartmentNameSL` (from the base class).

`ViewData["DepartmentID"]` is replaced with the strongly typed `DepartmentNameSL`. Strongly typed models are generally prefered over weaky typed. Ror more information, see [Weakly-typed data (ViewData and ViewBag)](xref:mvc/views/overview#VD_VB).

### Update the Create page

Update *Pages/Courses/Create.cshtml* with the following markup:

[!code-cshtml[Main](intro/samples/cu/Pages/Courses/Create.cshtml?highlight=30-32)]

The preceding markup makes the following changes:

* Changes the caption from **DepartmentID** to **Department**.
* Replaces `"ViewBag.DepartmentID"` with `DepartmentNameSL` (from the base class).
* Adds the "Select Department" option. This change renders "Select Department" rather than the first department.
* Adds a validation message when the department is not selected.

The Razor Page uses the [Select Tag Helper](xref:mvc/views/working-with-forms#the-select-tag-helper):

[!code-cshtml[Main](intro/samples/cu/Pages/Courses/Create.cshtml?range=28-35&highlight=3-6)]

Test the Create page. The Create page displays the deparment name rather than the department ID.

### Update the Edit page.

Update the edit page model with the following code:

[!code-csharp[Main](intro/samples/cu/Pages/Courses/Edit.cshtml.cs?highlight=8,27-36,47-)]

The changes are similar to those made in the Create page model. In the preceding code, `PopulateDepartmentsDropDownList` passes in the department ID, which select the department specified in the drop down list.

Update *Pages/Courses/Edit.cshtml* with the following markup:

[!code-cshtml[Main](intro/samples/cu/Pages/Courses/Edit.cshtml?highlight=17-20,33-35)]

The preceding markup makes the following changes:

* Displays the course ID. Generally the Primary Key (PK) of an entity is not displayed. PKs are usually meaningless to users. In this case the PK is the course nummber.
* Changes the caption from **DepartmentID** to **Department**.
* Replaces `"ViewBag.DepartmentID"` with `DepartmentNameSL` (from the base class).
* Adds the "Select Department" option. This change renders "Select Department" rather than the first department.
* Adds a validation message when the department is not selected.

The page contains a hidden field (`<input type="hidden">`) for the course number. Adding a `<label>` tag helper with `asp-for="Course.CourseID"` doesn't eliminate the need for the hidden field. `<input type="hidden">` is required for the course number to be included in the posted data when the user clicks **Save**.

Test the updated code. Create, edit and delete a course.

## Add .AsNoTracking to the Details and Delete page models

[AsNoTracking](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.entityframeworkqueryableextensions.asnotracking?view=efcore-2.0#Microsoft_EntityFrameworkCore_EntityFrameworkQueryableExtensions_AsNoTracking__1_System_Linq_IQueryable___0__)  can improve performance when tracking is not required. Add `AsNoTracking` to the Delete and Details page model.

[!code-csharp[Main](intro/samples/cu/Pages/Courses/Delete.cshtml.cs?name=snippet&highlight=21,23,40,41)]

[!code-csharp[Main](intro/samples/cu/Pages/Courses/Details.cshtml.cs?name=snippet)]

### Modify the Delete and Details pages

Update the Delete Razor page with the following markup:

[!code-cshtml[Main](intro/samples/cu/Pages/Courses/Delete.cshtml?highlight=15-20)]

Make the same changes to the Details page.

### Test the Course pages

Test create, edit, details, and delete.

## Updating the Instructors pages

When editing an instructor record, you may want to update the instructor's office assignment. The `Instructor` entity has a one-to-zero-or-one relationship with the `OfficeAssignment` entity. The instructor code code must handle:

* If the user clears the office assignment, delete the `OfficeAssignment` entity.
* If the user enters an office assignment and it was empty, create a new `OfficeAssignment` entity.
* If the user changes the office assignment, update the `OfficeAssignment` entity.

Update the instructors Edit page model with the following code:

[!code-csharp[Main](intro/samples/cu/Pages/Instructors/Edit1.cshtml.cs?name=snippet&highlight=20-23,39-)]

The preceding code:

-  Gets the current `Instructor` entity from the database using eager loading for the `OfficeAssignment` navigation property.

-  Updates the retrieved `Instructor` entity with values from the model binder. `TryUpdateModel` prevents [overposting](xref:data/ef-rp/crud#overposting).
	
-  If the office location is blank, sets `Instructor.OfficeAssignment` to null. When `Instructor.OfficeAssignment` is null, the related row in the `OfficeAssignment` table is deleted.

### Update the instructor Edit page

Update *Pages/Instructors/Edit.cshtml* with the office location:

[!code-cshtml[Main](intro/samples/cu/Pages/Instructors/Edit1.cshtml?highlight=29-33)]

Verify you can change an instructors office location.

## Add Course assignments to the instructor Edit page

Instructors may teach any number of courses. In this section you add the ability to change course assignments. The updated instructor Edit page:

![Instructor Edit page with courses](update-related-data/_static/instructor-edit-courses.png)

`Course` and `Instructor` has a many-to-many relationship. To add and remove relationships, you add and remove entities from the `CourseAssignments` join entity set.

A check boxes enables changes to courses an instructor is assigned to. A check box is displayed for every course in the database. Courses that the instructor is assigned to are checked. The user can select or clear check boxes to change course assignments. If the number of courses were much greater:

* You'd probably use a different user interace to display the courses.
* The method of manipulating a join entity to create or delete relationships would not change.

### Update the Instructors page model classes

Create *SchoolViewModels/AssignedCourseData.cs* with the following code:

[!code-csharp[Main](intro/samples/cu/Models/SchoolViewModels/AssignedCourseData.cs)]

The `AssignedCourseData` class contains data to create the check boxes for assigned courses by an instructor.

Create the *Pages/Instructors/InstructorCoursesPageModel.cshtml.cs* page model:

[!code-csharp[Main](intro/samples/cu/Pages/Instructors/InstructorCoursesPageModel.cshtml.cs)]

The `InstructorCoursesPageModel` is the base class for the updated Edit and Create page models. `PopulateAssignedCourseData` reads all `Course` entities to populate `AssignedCourseDataList`. For each course, the code sets the CourseID, title and whether or not the instructor is assigned to the course. A [HashSet](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1?view=netcore-2.0) to create efficient lookup.

Update the instructor Edit page model class with the following code:

[!code-csharp[Main](intro/samples/cu/Pages/Instructors/Edit.cshtml.cs?name=snippet&highlight=1,20-24,30,34,41-)]


Next, add the code that's executed when the user clicks **Save**. Replace the `EditPost` method with the following code, and add a new method that updates the `Courses` navigation property of the Instructor entity.

[!code-csharp[Main](intro/samples/cu/Controllers/InstructorsController.cs?highlight=1,3,12,13,25,39-40&name=snippet_EditPostCourses)]

[!code-csharp[Main](intro/samples/cu/Controllers/InstructorsController.cs?name=snippet_UpdateCourses&highlight=1-31)]

The method signature is now different from the HttpGet `Edit` method, so the method name changes from `EditPost` back to `Edit`.

Since the view doesn't have a collection of Course entities, the model binder can't automatically update the `CourseAssignments` navigation property. Instead of using the model binder to update the `CourseAssignments` navigation property, you do that in the new `UpdateInstructorCourses` method. Therefore you need to exclude the `CourseAssignments` property from model binding. This doesn't require any change to the code that calls `TryUpdateModel` because you're using the whitelisting overload and `CourseAssignments` isn't in the include list.

If no check boxes were selected, the code in `UpdateInstructorCourses` initializes the `CourseAssignments` navigation property with an empty collection and returns:

[!code-csharp[Main](intro/samples/cu/Controllers/InstructorsController.cs?name=snippet_UpdateCourses&highlight=3-7)]

The code then loops through all courses in the database and checks each course against the ones currently assigned to the instructor versus the ones that were selected in the view. To facilitate efficient lookups, the latter two collections are stored in `HashSet` objects.

If the check box for a course was selected but the course isn't in the `Instructor.CourseAssignments` navigation property, the course is added to the collection in the navigation property.

[!code-csharp[Main](intro/samples/cu/Controllers/InstructorsController.cs?highlight=14-20&name=snippet_UpdateCourses)]

If the check box for a course wasn't selected, but the course is in the `Instructor.CourseAssignments` navigation property, the course is removed from the navigation property.

[!code-csharp[Main](intro/samples/cu/Controllers/InstructorsController.cs?highlight=21-29&name=snippet_UpdateCourses)]

### Update the Instructor views

In *Views/Instructors/Edit.cshtml*, add a **Courses** field with an array of check boxes by adding the following code immediately after the `div` elements for the **Office** field and before the `div` element for the **Save** button.

<a id="notepad"></a>
> [!NOTE] 
> When you paste the code in Visual Studio, line breaks will be changed in a way that breaks the code.  Press Ctrl+Z one time to undo the automatic formatting.  This will fix the line breaks so that they look like what you see here. The indentation doesn't have to be perfect, but the `@</tr><tr>`, `@:<td>`, `@:</td>`, and `@:</tr>` lines must each be on a single line as shown or you'll get a runtime error. With the block of new code selected, press Tab three times to line up the new code with the existing code.

[!code-html[Main](intro/samples/cu/Views/Instructors/Edit.cshtml?range=35-61)]

This code creates an HTML table that has three columns. In each column is a check box followed by a caption that consists of the course number and title. The check boxes all have the same name ("selectedCourses"), which informs the model binder that they are to be treated as a group. The value attribute of each check box is set to the value of `CourseID`. When the page is posted, the model binder passes an array to the controller that consists of the `CourseID` values for only the check boxes which are selected.

When the check boxes are initially rendered, those that are for courses assigned to the instructor have checked attributes, which selects them (displays them checked).

Run the app, select the **Instructors** tab, and click **Edit** on an instructor to see the **Edit** page.

![Instructor Edit page with courses](update-related-data/_static/instructor-edit-courses.png)

Change some course assignments and click Save. The changes you make are reflected on the Index page.

> [!NOTE] 
> The approach taken here to edit instructor course data works well when there is a limited number of courses. For collections that are much larger, a different UI and a different updating method would be required.

## Update the Delete page

In *InstructorsController.cs*, delete the `DeleteConfirmed` method and insert the following code in its place.

[!code-csharp[Main](intro/samples/cu/Controllers/InstructorsController.cs?highlight=5-7,9-12&name=snippet_DeleteConfirmed)]

This code makes the following changes:

* Does eager loading for the `CourseAssignments` navigation property.  You have to include this or EF won't know about related `CourseAssignment` entities and won't delete them.  To avoid needing to read them here you could configure cascade delete in the database.

* If the instructor to be deleted is assigned as administrator of any departments, removes the instructor assignment from those departments.

## Add office location and courses to the Create page

In *InstructorsController.cs*, delete the HttpGet and HttpPost `Create` methods, and then add the following code in their place:

[!code-csharp[Main](intro/samples/cu/Controllers/InstructorsController.cs?name=snippet_Create&highlight=3-5,12,14-22,29)]

This code is similar to what you saw for the `Edit` methods except that initially no courses are selected. The HttpGet `Create` method calls the `PopulateAssignedCourseData` method not because there might be courses selected but in order to provide an empty collection for the `foreach` loop in the view (otherwise the view code would throw a null reference exception).

The HttpPost `Create` method adds each selected course to the `CourseAssignments` navigation property before it checks for validation errors and adds the new instructor to the database. Courses are added even if there are model errors so that when there are model errors (for an example, the user keyed an invalid date), and the page is redisplayed with an error message, any course selections that were made are automatically restored.

Notice that in order to be able to add courses to the `CourseAssignments` navigation property you have to initialize the property as an empty collection:

```csharp
instructor.CourseAssignments = new List<CourseAssignment>();
```

As an alternative to doing this in controller code, you could do it in the Instructor model by changing the property getter to automatically create the collection if it doesn't exist, as shown in the following example:

```csharp
private ICollection<CourseAssignment> _courseAssignments;
public ICollection<CourseAssignment> CourseAssignments
{
    get
    {
        return _courseAssignments ?? (_courseAssignments = new List<CourseAssignment>());
    }
    set
    {
        _courseAssignments = value;
    }
}
```

If you modify the `CourseAssignments` property in this way, you can remove the explicit property initialization code in the controller.

In *Views/Instructor/Create.cshtml*, add an office location text box and check boxes for courses before the Submit button. As in the case of the Edit page, [fix the formatting if Visual Studio reformats the code when you paste it](#notepad).

[!code-html[Main](intro/samples/cu/Views/Instructors/Create.cshtml?range=29-61)]

Test by running the app and creating an instructor. 

## Handling Transactions

As explained in the [CRUD tutorial](crud.md), the Entity Framework implicitly implements transactions. For scenarios where you need more control -- for example, if you want to include operations done outside of Entity Framework in a transaction -- see [Transactions](https://docs.microsoft.com/ef/core/saving/transactions).



-->

>[!div class="step-by-step"]
[Previous](xref:data/ef-mvc/read-related-data)