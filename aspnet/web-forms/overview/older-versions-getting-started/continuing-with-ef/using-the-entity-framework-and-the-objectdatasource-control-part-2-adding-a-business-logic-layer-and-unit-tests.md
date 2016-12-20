---
title: "Using the Entity Framework 4.0 and the ObjectDataSource Control, Part 2: Adding a Business Logic Layer and Unit Tests | Microsoft Docs"
author: tdykstra
description: "This tutorial series builds on the Contoso University web application that is created by the Getting Started with the Entity Framework 4.0 tutorial series. I..."
ms.author: riande
manager: wpickett
ms.date: 01/26/2011
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/older-versions-getting-started/continuing-with-ef/using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\web-forms\overview\older-versions-getting-started\continuing-with-ef\using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/24985) | [View dev content](http://docs.aspdev.net/tutorials/web-forms/overview/older-versions-getting-started/continuing-with-ef/using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests.html) | [View prod content](http://www.asp.net/web-forms/overview/older-versions-getting-started/continuing-with-ef/using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests) | Picker: 33225

Using the Entity Framework 4.0 and the ObjectDataSource Control, Part 2: Adding a Business Logic Layer and Unit Tests
====================
by [Tom Dykstra](https://github.com/tdykstra)

> This tutorial series builds on the Contoso University web application that is created by the [Getting Started with the Entity Framework 4.0](https://asp.net/entity-framework/tutorials#Getting%20Started) tutorial series. If you didn't complete the earlier tutorials, as a starting point for this tutorial you can [download the application](https://code.msdn.microsoft.com/ASPNET-Web-Forms-97f8ee9a) that you would have created. You can also [download the application](https://code.msdn.microsoft.com/ASPNET-Web-Forms-6c7197aa) that is created by the complete tutorial series. If you have questions about the tutorials, you can post them to the [ASP.NET Entity Framework forum](https://forums.asp.net/1227.aspx).


In the previous tutorial you created an n-tier web application using the Entity Framework and the `ObjectDataSource` control. This tutorial shows how to add business logic while keeping the business-logic layer (BLL) and the data-access layer (DAL) separate, and it shows how to create automated unit tests for the BLL.

In this tutorial you'll complete the following tasks:

- Create a repository interface that declares the data-access methods you need.
- Implement the repository interface in the repository class.
- Create a business-logic class that calls the repository class to perform data-access functions.
- Connect the `ObjectDataSource` control to the business-logic class instead of to the repository class.
- Create a unit-test project and a repository class that uses in-memory collections for its data store.
- Create a unit test for business logic that you want to add to the business-logic class, then run the test and see it fail.
- Implement the business logic in the business-logic class, then re-run the unit test and see it pass.

You'll work with the *Departments.aspx* and *DepartmentsAdd.aspx* pages that you created in the previous tutorial.

## Creating a Repository Interface

You'll begin by creating the repository interface.

[![Image08](using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests/_static/image2.png)](using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests/_static/image1.png)

In the *DAL* folder, create a new class file, name it *ISchoolRepository.cs*, and replace the existing code with the following code:

    using System;
    using System.Collections.Generic;
    
    namespace ContosoUniversity.DAL
    {
        public interface ISchoolRepository : IDisposable
        {
            IEnumerable<Department> GetDepartments();
            void InsertDepartment(Department department);
            void DeleteDepartment(Department department);
            void UpdateDepartment(Department department, Department origDepartment);
            IEnumerable<InstructorName> GetInstructorNames();
        }
    }

The interface defines one method for each of the CRUD (create, read, update, delete) methods that you created in the repository class.

In the `SchoolRepository` class in *SchoolRepository.cs*, indicate that this class implements the `ISchoolRepository` interface:

    public class SchoolRepository : IDisposable, ISchoolRepository

## Creating a Business-Logic Class

Next, you'll create the business-logic class. You do this so that you can add business logic that will be executed by the `ObjectDataSource` control, although you will not do that yet. For now, the new business-logic class will only perform the same CRUD operations that the repository does.

[![Image09](using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests/_static/image4.png)](using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests/_static/image3.png)

Create a new folder and name it *BLL*. (In a real-world application, the business-logic layer would typically be implemented as a class library — a separate project — but to keep this tutorial simple, BLL classes will be kept in a project folder.)

In the *BLL* folder, create a new class file, name it *SchoolBL.cs*, and replace the existing code with the following code:

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using ContosoUniversity.DAL;
    
    namespace ContosoUniversity.BLL
    {
        public class SchoolBL : IDisposable
        {
            private ISchoolRepository schoolRepository;
    
            public SchoolBL()
            {
                this.schoolRepository = new SchoolRepository();
            }
    
            public SchoolBL(ISchoolRepository schoolRepository)
            {
                this.schoolRepository = schoolRepository;
            }
    
            public IEnumerable<Department> GetDepartments()
            {
                return schoolRepository.GetDepartments();
            }
    
            public void InsertDepartment(Department department)
            {
                try
                {
                    schoolRepository.InsertDepartment(department);
                }
                catch (Exception ex)
                {
                    //Include catch blocks for specific exceptions first,
                    //and handle or log the error as appropriate in each.
                    //Include a generic catch block like this one last.
                    throw ex;
                }
            }
    
            public void DeleteDepartment(Department department)
            {
                try
                {
                    schoolRepository.DeleteDepartment(department);
                }
                catch (Exception ex)
                {
                    //Include catch blocks for specific exceptions first,
                    //and handle or log the error as appropriate in each.
                    //Include a generic catch block like this one last.
                    throw ex;
                }
            }
    
            public void UpdateDepartment(Department department, Department origDepartment)
            {
                try
                {
                    schoolRepository.UpdateDepartment(department, origDepartment);
                }
                catch (Exception ex)
                {
                    //Include catch blocks for specific exceptions first,
                    //and handle or log the error as appropriate in each.
                    //Include a generic catch block like this one last.
                    throw ex;
                }
    
            }
    
            public IEnumerable<InstructorName> GetInstructorNames()
            {
                return schoolRepository.GetInstructorNames();
            }
    
            private bool disposedValue = false;
    
            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposedValue)
                {
                    if (disposing)
                    {
                        schoolRepository.Dispose();
                    }
                }
                this.disposedValue = true;
            }
    
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
    
        }
    }

This code creates the same CRUD methods you saw earlier in the repository class, but instead of accessing the Entity Framework methods directly, it calls the repository class methods.

The class variable that holds a reference to the repository class is defined as an interface type, and the code that instantiates the repository class is contained in two constructors. The parameterless constructor will be used by the `ObjectDataSource` control. It creates an instance of the `SchoolRepository` class that you created earlier. The other constructor allows whatever code that instantiates the business-logic class to pass in any object that implements the repository interface.

The CRUD methods that call the repository class and the two constructors make it possible to use the business-logic class with whatever back-end data store you choose. The business-logic class does not need to be aware of how the class that it's calling persists the data. (This is often called *persistence ignorance*.) This facilitates unit testing, because you can connect the business-logic class to a repository implementation that uses something as simple as in-memory `List` collections to store data.

> [!NOTE] Technically, the entity objects are still not persistence-ignorant, because they're instantiated from classes that inherit from the Entity Framework's `EntityObject` class. For complete persistence ignorance, you can use *plain old CLR objects*, or *POCOs*, in place of objects that inherit from the `EntityObject` class. Using POCOs is beyond the scope of this tutorial. For more information, see [Testability and Entity Framework 4.0](https://msdn.microsoft.com/en-us/library/ff714955.aspx) on the MSDN website.)


Now you can connect the `ObjectDataSource` controls to the business-logic class instead of to the repository and verify that everything works as it did before.

In *Departments.aspx* and *DepartmentsAdd.aspx*, change each occurrence of `TypeName="ContosoUniversity.DAL.SchoolRepository"` to `TypeName="ContosoUniversity.BLL.SchoolBL`". (There are four instances in all.)

Run the *Departments.aspx* and *DepartmentsAdd.aspx* pages to verify that they still work as they did before.

[![Image01](using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests/_static/image6.png)](using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests/_static/image5.png)

[![Image02](using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests/_static/image8.png)](using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests/_static/image7.png)

## Creating a Unit-Test Project and Repository Implementation

Add a new project to the solution using the **Test Project** template, and name it `ContosoUniversity.Tests`.

In the test project, add a reference to `System.Data.Entity` and add a project reference to the `ContosoUniversity` project.

You can now create the repository class that you'll use with unit tests. The data store for this repository will be within the class.

[![Image12](using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests/_static/image10.png)](using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests/_static/image9.png)

In the test project, create a new class file, name it *MockSchoolRepository.cs*, and replace the existing code with the following code:

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ContosoUniversity.DAL;
    using ContosoUniversity.BLL;
    
    namespace ContosoUniversity.Tests
    {
        class MockSchoolRepository : ISchoolRepository, IDisposable
        {
            List<Department> departments = new List<Department>();
            List<InstructorName> instructors = new List<InstructorName>();
    
            public IEnumerable<Department> GetDepartments()
            {
                return departments;
            }
    
            public void InsertDepartment(Department department)
            {
                departments.Add(department);
            }
    
            public void DeleteDepartment(Department department)
            {
                departments.Remove(department);
            }
    
            public void UpdateDepartment(Department department, Department origDepartment)
            {
                departments.Remove(origDepartment);
                departments.Add(department);
            }
    
            public IEnumerable<InstructorName> GetInstructorNames()
            {
                return instructors;
            }
    
            public void Dispose()
            {
                
            }
        }
    }

This repository class has the same CRUD methods as the one that accesses the Entity Framework directly, but they work with `List` collections in memory instead of with a database. This makes it easier for a test class to set up and validate unit tests for the business-logic class.

## Creating Unit Tests

The **Test** project template created a stub unit test class for you, and your next task is to modify this class by adding unit test methods to it for business logic that you want to add to the business-logic class.

[![Image13](using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests/_static/image12.png)](using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests/_static/image11.png)

At Contoso University, any individual instructor can only be the administrator of a single department, and you need to add business logic to enforce this rule. You will start by adding tests and running the tests to see them fail. You'll then add the code and rerun the tests, expecting to see them pass.

Open the *UnitTest1.cs* file and add `using` statements for the business logic and data-access layers that you created in the ContosoUniversity project:

    using ContosoUniversity.BLL;
    using ContosoUniversity.DAL;

Replace the `TestMethod1` method with the following methods:

    private SchoolBL CreateSchoolBL()
            {
                var schoolRepository = new MockSchoolRepository();
                var schoolBL = new SchoolBL(schoolRepository);
                schoolBL.InsertDepartment(new Department() { Name = "First Department", DepartmentID = 0, Administrator = 1, Person = new Instructor () { FirstMidName = "Admin", LastName = "One" } });
                schoolBL.InsertDepartment(new Department() { Name = "Second Department", DepartmentID = 1, Administrator = 2, Person = new Instructor() { FirstMidName = "Admin", LastName = "Two" } });
                schoolBL.InsertDepartment(new Department() { Name = "Third Department", DepartmentID = 2, Administrator = 3, Person = new Instructor() { FirstMidName = "Admin", LastName = "Three" } });
                return schoolBL;
            }
    
            [TestMethod]
            [ExpectedException(typeof(DuplicateAdministratorException))]
            public void AdministratorAssignmentRestrictionOnInsert()
            {
                var schoolBL = CreateSchoolBL();
                schoolBL.InsertDepartment(new Department() { Name = "Fourth Department", DepartmentID = 3, Administrator = 2, Person = new Instructor() { FirstMidName = "Admin", LastName = "Two" } });
            }
    
            [TestMethod]
            [ExpectedException(typeof(DuplicateAdministratorException))]
            public void AdministratorAssignmentRestrictionOnUpdate()
            {
                var schoolBL = CreateSchoolBL();
                var origDepartment = (from d in schoolBL.GetDepartments()
                                      where d.Name == "Second Department"
                                      select d).First();
                var department = (from d in schoolBL.GetDepartments()
                                      where d.Name == "Second Department"
                                      select d).First();
                department.Administrator = 1;
                schoolBL.UpdateDepartment(department, origDepartment);
            }

The `CreateSchoolBL` method creates an instance of the repository class that you created for the unit test project, which it then passes to a new instance of the business-logic class. The method then uses the business-logic class to insert three departments that you can use in test methods.

The test methods verify that the business-logic class throws an exception if someone tries to insert a new department with the same administrator as an existing department, or if someone tries to update a department's administrator by setting it to the ID of a person who is already the administrator of another department.

You haven't created the exception class yet, so this code will not compile. To get it to compile, right-click `DuplicateAdministratorException` and select **Generate**, and then **Class**.

[![Image14](using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests/_static/image14.png)](using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests/_static/image13.png)

This creates a class in the test project which you can delete after you've created the exception class in the main project. and implemented the business logic.

Run the test project. As expected, the tests fail.

[![Image03](using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests/_static/image16.png)](using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests/_static/image15.png)

## Adding Business Logic to Make a Test Pass

Next, you'll implement the business logic that makes it impossible to set as the administrator of a department someone who is already administrator of another department. You'll throw an exception from the business-logic layer, and then catch it in the presentation layer if a user edits a department and clicks **Update** after selecting someone who is already an administrator. (You could also remove instructors from the drop-down list who are already administrators before you render the page, but the purpose here is to work with the business-logic layer.)

Start by creating the exception class that you'll throw when a user tries to make an instructor the administrator of more than one department. In the main project, create a new class file in the *BLL* folder, name it *DuplicateAdministratorException.cs*, and replace the existing code with the following code:

    using System;
    
    namespace ContosoUniversity.BLL
    {
        public class DuplicateAdministratorException : Exception
        {
            public DuplicateAdministratorException(string message)
                : base(message)
            {
            }
        }
    }

Now delete the temporary*DuplicateAdministratorException.cs* file that you created in the test project earlier in order to be able to compile.

In the main project, open the *SchoolBL.cs* file and add the following method that contains the validation logic. (The code refers to a method that you'll create later.)

    private void ValidateOneAdministratorAssignmentPerInstructor(Department department)
            {
                if (department.Administrator != null)
                {
                    var duplicateDepartment = schoolRepository.GetDepartmentsByAdministrator(department.Administrator.GetValueOrDefault()).FirstOrDefault();
                    if (duplicateDepartment != null && duplicateDepartment.DepartmentID != department.DepartmentID)
                    {
                        throw new DuplicateAdministratorException(String.Format(
                            "Instructor {0} {1} is already administrator of the {2} department.", 
                            duplicateDepartment.Person.FirstMidName, 
                            duplicateDepartment.Person.LastName, 
                            duplicateDepartment.Name));
                    }
                }
            }

You'll call this method when you're inserting or updating `Department` entities in order to check whether another department already has the same administrator.

The code calls a method to search the database for a `Department` entity that has the same `Administrator` property value as the entity being inserted or updated. If one is found, the code throws an exception. No validation check is required if the entity being inserted or updated has no `Administrator` value, and no exception is thrown if the method is called during an update and the `Department` entity found matches the `Department` entity being updated.

Call the new method from the `Insert` and `Update` methods:

    public void InsertDepartment(Department department)
            {
                ValidateOneAdministratorAssignmentPerInstructor(department);
                try
                ...
    
            public void UpdateDepartment(Department department, Department origDepartment)
            {
                ValidateOneAdministratorAssignmentPerInstructor(department);
                try
                ...

In *ISchoolRepository.cs*, add the following declaration for the new data-access method:

    IEnumerable<Department> GetDepartmentsByAdministrator(Int32 administrator);

In *SchoolRepository.cs*, add the following `using` statement:

    using System.Data.Objects;

In *SchoolRepository.cs*, add the following new data-access method:

    public IEnumerable<Department> GetDepartmentsByAdministrator(Int32 administrator)
            {
                return new ObjectQuery<Department>("SELECT VALUE d FROM Departments as d", context, MergeOption.NoTracking).Include("Person").Where(d => d.Administrator == administrator).ToList();
            }

This code retrieves `Department` entities that have a specified administrator. Only one department should be found (if any). However, because no constraint is built into the database, the return type is a collection in case multiple departments are found.

By default, when the object context retrieves entities from the database, it keeps track of them in its object state manager. The `MergeOption.NoTracking` parameter specifies that this tracking will not be done for this query. This is necessary because the query might return the exact entity that you're trying to update, and then you would not be able to attach that entity. For example, if you edit the History department in the *Departments.aspx* page and leave the administrator unchanged, this query will return the History department. If `NoTracking` is not set, the object context would already have the History department entity in its object state manager. Then when you attach the History department entity that's re-created from view state, the object context would throw an exception that says `"An object with the same key already exists in the ObjectStateManager. The ObjectStateManager cannot track multiple objects with the same key"`.

(As an alternative to specifying `MergeOption.NoTracking`, you could create a new object context just for this query. Because the new object context would have its own object state manager, there would be no conflict when you call the `Attach` method. The new object context would share metadata and database connection with the original object context, so the performance penalty of this alternate approach would be minimal. The approach shown here, however, introduces the `NoTracking` option, which you'll find useful in other contexts. The `NoTracking` option is discussed further in a later tutorial in this series.)

In the test project, add the new data-access method to *MockSchoolRepository.cs*:

    public IEnumerable<Department> GetDepartmentsByAdministrator(Int32 administrator)
            {
                return (from d in departments
                        where d.Administrator == administrator
                        select d);
            }

This code uses LINQ to perform the same data selection that the `ContosoUniversity` project repository uses LINQ to Entities for.

Run the test project again. This time the tests pass.

[![Image04](using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests/_static/image18.png)](using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests/_static/image17.png)

## Handling ObjectDataSource Exceptions

In the `ContosoUniversity` project, run the *Departments.aspx* page and try to change the administrator for a department to someone who is already administrator for another department. (Remember that you can only edit departments that you added during this tutorial, because the database comes preloaded with invalid data.) You get the following server error page:

[![Image05](using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests/_static/image20.png)](using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests/_static/image19.png)

You don't want users to see this kind of error page, so you need to add error-handling code. Open *Departments.aspx* and specify a handler for the `OnUpdated` event of the `DepartmentsObjectDataSource`. The `ObjectDataSource` opening tag now resembles the following example.

    <asp:ObjectDataSource ID="DepartmentsObjectDataSource" runat="server" 
            TypeName="ContosoUniversity.BLL.SchoolBL"
            DataObjectTypeName="ContosoUniversity.DAL.Department" 
            SelectMethod="GetDepartments" 
            DeleteMethod="DeleteDepartment" 
            UpdateMethod="UpdateDepartment"
            ConflictDetection="CompareAllValues"
            OldValuesParameterFormatString="orig{0}" 
            OnUpdated="DepartmentsObjectDataSource_Updated" >

In *Departments.aspx.cs*, add the following `using` statement:

    using ContosoUniversity.BLL;

Add the following handler for the `Updated` event:

    protected void DepartmentsObjectDataSource_Updated(object sender, ObjectDataSourceStatusEventArgs e)
            {
                if (e.Exception != null)
                {
                    if (e.Exception.InnerException is DuplicateAdministratorException)
                    {
                        var duplicateAdministratorValidator = new CustomValidator();
                        duplicateAdministratorValidator.IsValid = false;
                        duplicateAdministratorValidator.ErrorMessage = "Update failed: " + e.Exception.InnerException.Message;
                        Page.Validators.Add(duplicateAdministratorValidator);
                        e.ExceptionHandled = true;
                    }
                }
            }

If the `ObjectDataSource` control catches an exception when it tries to perform the update, it passes the exception in the event argument (`e`) to this handler. The code in the handler checks to see if the exception is the duplicate administrator exception. If it is, the code creates a validator control that contains an error message for the `ValidationSummary` control to display.

Run the page and attempt to make someone the administrator of two departments again. This time the `ValidationSummary` control displays an error message.

[![Image06](using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests/_static/image22.png)](using-the-entity-framework-and-the-objectdatasource-control-part-2-adding-a-business-logic-layer-and-unit-tests/_static/image21.png)

Make similar changes to the *DepartmentsAdd.aspx* page. In *DepartmentsAdd.aspx*, specify a handler for the `OnInserted` event of the `DepartmentsObjectDataSource`. The resulting markup will resemble the following example.

    <asp:ObjectDataSource ID="DepartmentsObjectDataSource" runat="server" 
            TypeName="ContosoUniversity.BLL.SchoolBL" DataObjectTypeName="ContosoUniversity.DAL.Department" 
            InsertMethod="InsertDepartment"  
            OnInserted="DepartmentsObjectDataSource_Inserted">

In *DepartmentsAdd.aspx.cs*, add the same `using` statement:

    using ContosoUniversity.BLL;

Add the following event handler:

    protected void DepartmentsObjectDataSource_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
            {
                if (e.Exception != null)
                {
                    if (e.Exception.InnerException is DuplicateAdministratorException)
                    {
                        var duplicateAdministratorValidator = new CustomValidator();
                        duplicateAdministratorValidator.IsValid = false;
                        duplicateAdministratorValidator.ErrorMessage = "Insert failed: " + e.Exception.InnerException.Message;
                        Page.Validators.Add(duplicateAdministratorValidator);
                        e.ExceptionHandled = true;
                    }
                }
            }

You can now test the *DepartmentsAdd.aspx.cs* page to verify that it also correctly handles attempts to make one person the administrator of more than one department.

This completes the introduction to implementing the repository pattern for using the `ObjectDataSource` control with the Entity Framework. For more information about the repository pattern and testability, see the MSDN whitepaper [Testability and Entity Framework 4.0](https://msdn.microsoft.com/en-us/library/ff714955.aspx).

In the following tutorial you'll see how to add sorting and filtering functionality to the application.

>[!div class="step-by-step"] [Previous](using-the-entity-framework-and-the-objectdatasource-control-part-1-getting-started.md) [Next](using-the-entity-framework-and-the-objectdatasource-control-part-3-sorting-and-filtering.md)