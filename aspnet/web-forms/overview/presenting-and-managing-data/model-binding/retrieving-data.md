---
uid: web-forms/overview/presenting-and-managing-data/model-binding/retrieving-data
title: "Retrieving and displaying data with model binding and web forms | Microsoft Docs"
author: Rick-Anderson
description: "This tutorial series demonstrates basic aspects of using model binding with an ASP.NET Web Forms project. Model binding makes data interaction more straight-..."
ms.author: riande
ms.date: 02/27/2014
ms.assetid: 9f24fb82-c7ac-48da-b8e2-51b3da17e365
msc.legacyurl: /web-forms/overview/presenting-and-managing-data/model-binding/retrieving-data
msc.type: authoredcontent
---
Retrieving and displaying data with model binding and web forms
====================
by [Tom FitzMacken](https://github.com/tfitzmac)

> This tutorial series demonstrates basic model binding in an ASP.NET Web Forms project. Model binding makes data interaction more straight-forward than dealing with data source objects (such as [ObjectDataSource](https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.objectdatasource?view=netframework-4.7.2) or [SqlDataSource](https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.sqldatasource?view=netframework-4.7.2)). This series starts with introductory material and moves to more advanced concepts in later tutorials.
> 
> This tutorial uses model binding with Entity Framework, but you could use it with any data access technology. From a data-bound server control, such as a [GridView](https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.gridview?view=netframework-4.7.2), [ListView](https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.listview?view=netframework-4.7.2), [DetailsView](https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.detailsview?view=netframework-4.7.2), or [FormView](https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.formview?view=netframework-4.7.2) control, you can specify methods for selecting, updating, deleting, and creating data. In this tutorial, you'll specify a `SelectMethod`, which provides retrieving data logic. In the next tutorial, you'll set values for `UpdateMethod`, `DeleteMethod` and `InsertMethod`.
> 
> You can [download](https://go.microsoft.com/fwlink/?LinkId=286116) the complete project in C# or VB. The downloadable code works with either Visual Studio 2012 or later. It uses the Visual Studio 2012 template, which is slightly different than the Visual Studio 2017 template shown in this tutorial.
> 
> In the tutorial. you run the application in Visual Studio. You can also deploy the application to a hosting provider and make it available over the Internet. Microsoft offers free web hosting for up to 10 web sites in a  
>  [free Azure trial account](https://azure.microsoft.com/free/?WT.mc_id=A443DD604). For information about how to deploy a Visual Studio web project to Azure App Service Web Apps, see the [ASP.NET Web Deployment using Visual Studio](../../deployment/visual-studio-web-deployment/introduction.md) series. That tutorial also shows how to use Entity Framework Code First Migrations to deploy your SQL Server database to Azure SQL Database.
> 
> ## Software versions used in the tutorial
> 
> 
> - Microsoft Visual Studio 2017 or Microsoft Visual Studio Community 2017
>   
> 
> This tutorial also works with Visual Studio 2012, but there will be some differences in the user interface and project template.


## In this tutorial, you:

* Build data objects for a university's students and their courses
* Build database tables from the objects
* Populate the database with test data
* Display data in a web form

## Set up project

1. In Visual Studio 2017, create a **ASP.NET Web Application (.NET Framework)** project called **ContosoUniversityModelBinding**.

   ![create project](retrieving-data/_static/image19.png)

2. Select **OK**. The dialog box to select a template appears.

   ![select web forms](retrieving-data/_static/image3.png)

3. Select the **Web Forms** template. If necessary, change the authentication to **Individual User Accounts**. 

4. Select **OK** to create the project.

5. Modify site appearance.

   First, you need to make a few changes to customize site appearance. Open the Site.Master file, and change the title to display **Contoso University** and not **My ASP.NET Application**.

   [!code-aspx-csharp[Main](retrieving-data/samples/sample1.aspx?highlight=1)]

   Then, change the header text from **Application name** to **Contoso University**.

   [!code-aspx-csharp[Main](retrieving-data/samples/sample2.aspx?highlight=7)]

   Change the navigation header links to site appropriate ones. Remove the links for **About** and **Contact** and, instead, link to a not yet created **Students** page.

   [!code-aspx-csharp[Main](retrieving-data/samples/sample3.aspx)]

    Save and close **Site.Master**.

6. To display student data, create a web form. 

   In **Solution Explorer**, right-click your project, select **Add** and then **New Item**. Select the **Web Form with Master Page** template, and name it **Students.aspx**.

   ![create page](retrieving-data/_static/image5.png)

   Select **Add**, and then, for the web form's master page, select **Site.Master**.

## Create the data models and database

This tutorial uses [Code First Migrations](https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/migrations/) to create objects and database tables. These tables store information about the students and their courses.

1. In the **Models** folder, add a class named **UniversityModels.cs**.

   Right-click **Models**, select **Add**, and then **New Item**. The **Add New Item** dialog box appears.

   From the left navigation menu, select **Code**, then **Class**.

   ![create model class](retrieving-data/_static/image20.png)

   Name the class **UniversityModels.cs** and select **Add**.

   In this file, define the `SchoolContext`, `Student`, `Enrollment`, and `Course` classes as follows:

   [!code-csharp[Main](retrieving-data/samples/sample4.cs)]

   The `SchoolContext` class derives from `DbContext`, which manages the database connection and changes in the data.

   In the `Student` class, notice the attributes applied to the `FirstName`, `LastName`, and `Year` properties. This tutorial uses these attributes for data validation. To simplify the code, only these properties are marked with data-validation attributes. In a real project, you would apply validation attributes to all properties needing validation.

    Save UniversityModels.cs.

2. Use Code First Migrations to set up a database based on classes.

   Select **Tools** > **NuGet Package Manager** > **Package Manager Console**.

    In **Package Manager Console**, run this command:  
   `enable-migrations -ContextTypeName ContosoUniversityModelBinding.Models.SchoolContext`

   If the command completes successfully, a message stating migrations have been enabled appears.

   ![enable migrations](retrieving-data/_static/image8.png)

   Notice that a file named "Configuration.cs" has been created. The `Configuration` class has a `Seed` method, which you can use to pre-populate the database tables with test data.

2. Pre-populate the database tables with test data.

   Add the following code to the `Seed` method. Also, add a `using` statement for the `ContosoUniversityModelBinding. Models` namespace.

   [!code-csharp[Main](retrieving-data/samples/sample5.cs)]

   Save Configuration.cs.

   In the Package Manager Console, run the command `add-migration initial`.

   Then, run the command `update-database`.

   If you receive an exception when running this command, it's possible that the `StudentID` and `CourseID` values are different from the `Seed` method values. Open those database tables and find existing values for `StudentID` and `CourseID`. Add those values to the code for seeding the `Enrollments` table.

## Display data from Students and related tables

With populated database data, you're now ready to retrieve that data and display it. 

1. Add a **GridView** control to display data in columns and rows.

   Open Students.aspx, and locate the `MainContent` placeholder. Within that placeholder, add a **GridView** control that includes this code.

   [!code-aspx-csharp[Main](retrieving-data/samples/sample6.aspx)]

   Note a few important concepts here. First, notice the value set for the `SelectMethod` property in the GridView element. This value specifies the method used to retrieve GridView data, which you'll create in the next step. Second, the `ItemType` property is set to the `Student` class created earlier. This setting allows you to reference class properties in the markup. For example, the `Student` class has a collection named `Enrollments`. You can use `Item.Enrollments` to retrieve that collection and then use LINQ syntax to retrieve each student's enrolled credits sum.

2. Add retrieving data code.

   In the code-behind file, add the method specified for the `SelectMethod` value. Open Students.aspx.cs, and add `using` statements for the `ContosoUniversityModelBinding. Models` and `System.Data.Entity` namespaces.

   [!code-csharp[Main](retrieving-data/samples/sample7.cs)]

    Then, add the method you specified for `SelectMethod`:

    [!code-csharp[Main](retrieving-data/samples/sample8.cs)]

    The `Include` clause improves query performance but isn't required. Without the `Include` clause, the data is retrieved using [*lazy loading*](https://en.wikipedia.org/wiki/Lazy_loading), which involves sending a separate query to the database each time related data is retrieved. With the `Include` clause, data is retrieved using *eager loading*, which means a single database query retrieves all related data. If related data isn't used, eager loading is less efficient because more data is retrieved. However, in this case, eager loading gives you the best performance because the related data is displayed for each record.

    For more information about performance considerations when loading related data, see the **Lazy, Eager, and Explicit Loading of Related Data** section in the [Reading Related Data with the Entity Framework in an ASP.NET MVC Application](../../../../mvc/overview/getting-started/getting-started-with-ef-using-mvc/reading-related-data-with-the-entity-framework-in-an-asp-net-mvc-application.md) article.

    By default, the data is sorted by the values of the property marked as the key. You can add an `OrderBy` clause to specify a different sort value. In this example, the default `StudentID` property is used for sorting. In the [Sorting, Paging, and Filtering Data](sorting-paging-and-filtering-data.md) article, the user is enabled to select a column for sorting.

3. Run your web application, and navigate to the **Students** page, which displays the following:

   ![show data](retrieving-data/_static/image16.png)

## Automatic generation of model binding methods

In this tutorial series, you can copy tutorial code to your project, but there's also a Visual Studio feature to automatically generate code for model binding methods. This feature can save you time and help you gain a sense of  operation implementation. It's described here, though it's only informational and doesn't have any code you need to implement in your project.

When setting a value for the `SelectMethod`, `UpdateMethod`, `InsertMethod`, or `DeleteMethod` properties in the markup code, you can select the **Create New Method** option.

![create a method](retrieving-data/_static/image18.png)

Visual Studio not only creates a method in the code-behind with the proper signature, but also generates implementation code to perform the operation. If you first set the `ItemType` property before using the automatic code generation feature, the generated code uses that type for the operations. For example, when setting the `UpdateMethod` property, the following code is automatically generated:

[!code-csharp[Main](retrieving-data/samples/sample9.cs)]

Again, this code doesn't need to be added to your project. In the next tutorial, you'll implement methods for updating, deleting, and adding new data.

## Conclusion

In this tutorial, you:

1. Created data model classes and generated a database from those classes 

2. Filled the database tables with test data

3. Used model binding to retrieve data from the database and  display it in a GridView.

In the next [tutorial](updating-deleting-and-creating-data.md) in this series, you'll enable updating, deleting, and creating data.

> [!div class="step-by-step"]
> [Next](updating-deleting-and-creating-data.md)
