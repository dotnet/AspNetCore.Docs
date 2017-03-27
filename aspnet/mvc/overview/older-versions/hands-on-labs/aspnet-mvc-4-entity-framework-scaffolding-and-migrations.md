---
uid: mvc/overview/older-versions/hands-on-labs/aspnet-mvc-4-entity-framework-scaffolding-and-migrations
title: "ASP.NET MVC 4 Entity Framework Scaffolding and Migrations | Microsoft Docs"
author: rick-anderson
description: "If you are familiar with ASP.NET MVC 4 controller methods, or have completed the &quot;Helpers, Forms and Validation&quot; Hands-On lab, you should be aware..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/18/2013
ms.topic: article
ms.assetid: 093c1362-f10b-407c-a708-be370f4b62b0
ms.technology: dotnet-mvc
ms.prod: .net-framework
msc.legacyurl: /mvc/overview/older-versions/hands-on-labs/aspnet-mvc-4-entity-framework-scaffolding-and-migrations
msc.type: authoredcontent
---
ASP.NET MVC 4 Entity Framework Scaffolding and Migrations
====================
by [Web Camps Team](https://twitter.com/webcamps)

> If you are familiar with ASP.NET MVC 4 controller methods, or have completed the &quot;Helpers, Forms and Validation&quot; Hands-On lab, you should be aware that many of the logic to create, update, list and remove any data entity it is repeated among the application. Not to mention that, if your model has several classes to manipulate, you will be likely to spend a considerable time writing the POST and GET action methods for each entity operation, as well as each of the views.
> 
> In this lab you will learn how to use the ASP.NET MVC 4 scaffolding to automatically generate the baseline of your application's CRUD (Create, Read, Update and Delete). Starting from a simple model class, and, without writing a single line of code, you will create a controller that will contain all the CRUD operations, as well as the all the necessary views. After building and running the simple solution, you will have the application database generated, together with the MVC logic and views for data manipulation.
> 
> In addition, you will learn how easy it is to use Entity Framework Migrations to perform model updates throughout your entire application. Entity Framework Migrations will let you modify your database after the model has changed with simple steps. With all these in mind, you will be able to build and maintain web applications more efficiently, taking advantage of the latest features of ASP.NET MVC 4.


<a id="Objectives"></a>

<a id="Objectives"></a>
### Objectives

In this Hands-On Lab, you will learn how to:

- Use ASP.NET scaffolding for CRUD operations in controllers.
- Change the database model using Entity Framework Migrations.

<a id="Prerequisites"></a>

<a id="Prerequisites"></a>
### Prerequisites

You must have the following items to complete this lab:

- [Microsoft Visual Studio Express 2012 for Web](https://www.microsoft.com/visualstudio/eng/products/visual-studio-express-for-web) or superior (read [Appendix A](#AppendixA) for instructions on how to install it).

<a id="Setup"></a>

<a id="Setup"></a>
### Setup

**Installing Code Snippets**

For convenience, much of the code you will be managing along this lab is available as Visual Studio code snippets. To install the code snippets run **.\Source\Setup\CodeSnippets.vsi** file.

If you are not familiar with the Visual Studio Code Snippets, and want to learn how to use them, you can refer to the appendix from this document &quot;[Appendix B: Using Code Snippets](#AppendixB)&quot;.

* * *

<a id="Exercises"></a>

<a id="Exercises"></a>
## Exercises

The following exercise make up this Hands-On Lab:

1. [Using ASP.NET MVC 4 Scaffolding with Entity Framework Migrations](#Exercise1)

> [!NOTE]
> This exercise is accompanied by an **End** folder containing the resulting solution you should obtain after completing the exercise. You can use this solution as a guide if you need additional help working through the exercise.


Estimated time to complete this lab: **30 minutes**

<a id="Exercise1"></a>

<a id="Exercise_1_Using_ASPNET_MVC_4_Scaffolding_with_Entity_Framework_Migrations"></a>
### Exercise 1: Using ASP.NET MVC 4 Scaffolding with Entity Framework Migrations

ASP.NET MVC scaffolding provides a quick way to generate the CRUD operations in a standardized way, creating the necessary logic that lets your application interact with the database layer.

In this exercise, you will learn how to use ASP.NET MVC 4 scaffolding with code first to create the CRUD methods. Then, you will learn how to update your model applying the changes in the database by using Entity Framework Migrations.

<a id="Ex1Task1"></a>

<a id="Task_1-_Creating_a_new_ASPNET_MVC_4_project_using_Scaffolding"></a>
#### Task 1- Creating a new ASP.NET MVC 4 project using Scaffolding

1. If not already open, start **Visual Studio 2012**.
2. Select **File | New Project**. In the New Project dialog, under the **Visual C# | Web** section, select **ASP.NET MVC 4 Web Application**. Name the project to **MVC4andEFMigrations** and set the location to **Source\Ex1-UsingMVC4ScaffoldingEFMigrations** folder of this lab. Set the **Solution name** to **Begin** and ensure **Create directory for solution** is checked. Click **OK**.

    ![New ASP.NET MVC 4 Project Dialog Box](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image1.png "New ASP.NET MVC 4 Project Dialog Box")

    *New ASP.NET MVC 4 Project Dialog Box*
3. In the **New ASP.NET MVC 4 Project** dialog box select the **Internet Application** template, and make sure that **Razor** is the selected **View engine**. Click **OK** to create the project.

    ![New ASP.NET MVC 4 Internet Application](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image2.png "New ASP.NET MVC 4 Internet Application")

    *New ASP.NET MVC 4 Internet Application*
4. In the Solution Explorer, right-click **Models** and select **Add | Class** to create a simple class person (POCO). Name it **Person** and click **OK**.
5. Open the Person class and insert the following properties.

    (Code Snippet - *ASP.NET MVC 4 and Entity Framework Migrations - Ex1 Person Properties*)


    [!code-csharp[Main](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/samples/sample1.cs)]
6. Click **Build | Build Solution** to save the changes and build the project.

    ![Building the application](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image3.png "Building the application")

    *Building the Application*
7. In the Solution Explorer, right-click the controllers folder and select **Add | Controller**.
8. Name the controller *PersonController* and complete the **Scaffolding options** with the following values.

    1. In the **Template** drop-down list, select the **MVC controller with read/write actions and views, using Entity Framework** option.
    2. In the **Model class** drop-down list, select the **Person** class.
    3. In the **Data Context class** list, select **&lt;New data context...&gt;**. Choose any name and click **OK**.
    4. In the **Views** drop-down list, make sure that **Razor** is selected.

    ![Adding the Person controller with scaffolding](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image4.png "Adding the Person controller with scaffolding")

    *Adding the Person controller with scaffolding*
9. Click **Add** to create the new controller for Person with scaffolding. You have now generated the controller actions as well as the views.

    ![After creating the Person controller with scaffolding](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image5.png "After creating the Person controller with scaffolding")

    *After creating the Person controller with scaffolding*
10. Open **PersonController** class. Notice that the full CRUD action methods have been generated automatically.

    ![Inside the Person controller](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image6.png "Inside the Person controller")

    *Inside the Person controller*

<a id="Ex1Task2"></a>

<a id="Task_2-_Running_the_application"></a>
#### Task 2- Running the application

At this point, the database is not yet created. In this task, you will run the application for the first time and test the CRUD operations. The database will be created on the fly with Code First.

1. Press **F5** to run the application.
2. In the browser, add **/Person** to the URL to open the Person page.

    ![Application first run](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image7.png "Application first run")

    *Application: first run*
3. You will now explore the Person pages and test the CRUD operations.

    1. Click **Create New** to add a new person. Enter a first name and a last name and click **Create**.

        ![Adding a new person](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image8.png "Adding a new person")

        *Adding a new person*
    2. In the person's list, you can delete, edit or add items.

        ![person list](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image9.png "person list")

        *Person list*
    3. Click **Details** to open the person's details.

        ![Person's details](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image10.png "Person's details")

        *Person's details*
4. Close the browser and return to Visual Studio. Notice that you have created the whole CRUD for the person entity throughout your application -from the model to the views- without having to write a single line of code!

<a id="Ex1Task3"></a>

<a id="Task_3-_Updating_the_database_using_Entity_Framework_Migrations"></a>
#### Task 3- Updating the database using Entity Framework Migrations

In this task you will update the database using Entity Framework Migrations. You will discover how easy it is to change the model and reflect the changes in your databases by using the Entity Framework Migrations feature.

1. Open the Package Manager Console. Select **Tools | Library Package Manager | Package Manager Console**.
2. In the Package Manager Console, enter the following command:

    PMC

    [!code-powershell[Main](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/samples/sample2.ps1)]

    ![Enabling Migrations](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image11.png "Enabling Migrations")

    *Enabling migrations*

    The Enable-Migration command creates the **Migrations** folder, which contains a script to initialize the database.

    ![Migrations folder](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image12.png "Migrations folder")

    *Migrations folder*
3. Open the **Configuration.cs** file in the Migrations folder. Locate the class constructor and change the **AutomaticMigrationsEnabled** value to *true*.


    [!code-csharp[Main](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/samples/sample3.cs)]
4. Open the Person class and add an attribute for the person's middle name. With this new attribute, you are changing the model.


    [!code-csharp[Main](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/samples/sample4.cs)]
5. Select **Build | Build Solution** on the menu to build the application.

    ![Building the application](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image13.png "Building the application")

    *Building the application*
6. In the Package Manager Console, enter the following command:

    PMC

    [!code-powershell[Main](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/samples/sample5.ps1)]

    This command will look for changes in the data objects, and then, it will add the necessary commands to modify the database accordingly.

    ![Adding a middle name](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image14.png "Adding a middle name")

    *Adding a middle name*
7. (Optional) You can run the following command to generate a SQL script with the differential update. This will let you update the database manually (In this case it's not necessary), or apply the changes in other databases:

    PMC

    [!code-powershell[Main](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/samples/sample6.ps1)]

    ![Generating a SQL script](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image15.png "Generating a SQL script")

    *Generating a SQL script*

    ![SQL Script update](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image16.png "SQL Script update")

    *SQL Script update*
8. In the Package Manager Console, enter the following command to update the database:

    PMC

    [!code-powershell[Main](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/samples/sample7.ps1)]

    ![Updating the Database](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image17.png "Updating the Database")

    *Updating the Database*

    This will add the **MiddleName** column in the **People** table to match the current definition of the **Person** class.
9. Once the database is updated, right-click the Controller folder and select **Add | Controller** to add the Person controller again (Complete with the same values). This will update the existing methods and views adding the new attribute.

    ![Adding a controller update](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image18.png "Adding a controller update")

    *Updating the controller*
10. Click **Add**. Then, select the values **Overwrite PersonController.cs** and the **Overwrite associated views** and click **OK**.

    ![Adding a controller overwrite](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image19.png)

    *Updating the controller*

<a id="Ex1Task4"></a>

<a id="Task4-_Running_the_application"></a>
#### Task4- Running the application

1. Press **F5** to run the application.
2. Open **/Person**. Notice that the data was preserved, while the middle name column was added.

    ![Middle Name added](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image20.png "Middle Name added")

    *Middle Name added*
3. If you click **Edit**, you will be able to add a middle name to the current person.

    ![Middle Name edition](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image21.png "Middle Name edition")

* * *

<a id="Summary"></a>

<a id="Summary"></a>
## Summary

In this Hands-On lab, you have learned simple steps to create CRUD operations with ASP.NET MVC 4 Scaffolding using any model class. Then, you have learned how to perform an end to end update in your application -from the database to the views- by using Entity Framework Migrations.

<a id="AppendixA"></a>

<a id="Appendix_A_Installing_Visual_Studio_Express_2012_for_Web"></a>
## Appendix A: Installing Visual Studio Express 2012 for Web

You can install **Microsoft Visual Studio Express 2012 for Web** or another &quot;Express&quot; version using the **[Microsoft Web Platform Installer](https://www.microsoft.com/web/downloads/platform.aspx)**. The following instructions guide you through the steps required to install *Visual studio Express 2012 for Web* using *Microsoft Web Platform Installer*.

1. Go to [[https://go.microsoft.com/? linkid=9810169](https://go.microsoft.com/?linkid=9810169)](https://go.microsoft.com/?linkid=9810169). Alternatively, if you already have installed Web Platform Installer, you can open it and search for the product &quot;*Visual Studio Express 2012 for Web with Windows Azure SDK*&quot;.
2. Click on **Install Now**. If you do not have **Web Platform Installer** you will be redirected to download and install it first.
3. Once **Web Platform Installer** is open, click **Install** to start the setup.

    ![Install Visual Studio Express](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image22.png "Install Visual Studio Express")

    *Install Visual Studio Express*
4. Read all the products' licenses and terms and click **I Accept** to continue.

    ![Accepting the license terms](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image23.png)

    *Accepting the license terms*
5. Wait until the downloading and installation process completes.

    ![Installation progress](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image24.png)

    *Installation progress*
6. When the installation completes, click **Finish**.

    ![Installation completed](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image25.png)

    *Installation completed*
7. Click **Exit** to close Web Platform Installer.
8. To open Visual Studio Express for Web, go to the **Start** screen and start writing &quot;**VS Express**&quot;, then click on the **VS Express for Web** tile.

    ![VS Express for Web tile](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image26.png)

    *VS Express for Web tile*

<a id="AppendixB"></a>

<a id="Appendix_B_Using_Code_Snippets"></a>
## Appendix B: Using Code Snippets

With code snippets, you have all the code you need at your fingertips. The lab document will tell you exactly when you can use them, as shown in the following figure.

![Using Visual Studio code snippets to insert code into your project](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image27.png "Using Visual Studio code snippets to insert code into your project")

*Using Visual Studio code snippets to insert code into your project*

***To add a code snippet using the keyboard (C# only)***

1. Place the cursor where you would like to insert the code.
2. Start typing the snippet name (without spaces or hyphens).
3. Watch as IntelliSense displays matching snippets' names.
4. Select the correct snippet (or keep typing until the entire snippet's name is selected).
5. Press the Tab key twice to insert the snippet at the cursor location.

![Start typing the snippet name](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image28.png "Start typing the snippet name")

*Start typing the snippet name*

![Press Tab to select the highlighted snippet](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image29.png "Press Tab to select the highlighted snippet")

*Press Tab to select the highlighted snippet*

![Press Tab again and the snippet will expand](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image30.png "Press Tab again and the snippet will expand")

*Press Tab again and the snippet will expand*

***To add a code snippet using the mouse (C#, Visual Basic and XML)*** 1. Right-click where you want to insert the code snippet.

1. Select **Insert Snippet** followed by **My Code Snippets**.
2. Pick the relevant snippet from the list, by clicking on it.

![Right-click where you want to insert the code snippet and select Insert Snippet](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image31.png "Right-click where you want to insert the code snippet and select Insert Snippet")

*Right-click where you want to insert the code snippet and select Insert Snippet*

![Pick the relevant snippet from the list, by clicking on it](aspnet-mvc-4-entity-framework-scaffolding-and-migrations/_static/image32.png "Pick the relevant snippet from the list, by clicking on it")

*Pick the relevant snippet from the list, by clicking on it*