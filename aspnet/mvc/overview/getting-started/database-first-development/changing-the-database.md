---
uid: mvc/overview/getting-started/database-first-development/changing-the-database
title: "Tutorial: Change the database for EF Database First with ASP.NET MVC app"
description: "This article focuses on making an update to the database structure and propagating that change throughout the web application."
author: Rick-Anderson
ms.author: riande
ms.date: 01/24/2019
ms.topic: tutorial
ms.assetid: cfd5c083-a319-482e-8f25-5b38caa93954
msc.legacyurl: /mvc/overview/getting-started/database-first-development/changing-the-database
msc.type: authoredcontent
---

# Tutorial: Change the database for EF Database First with ASP.NET MVC app

Using MVC, Entity Framework, and ASP.NET Scaffolding, you can create a web application that provides an interface to an existing database. This tutorial series shows you how to automatically generate code that enables users to display, edit, create, and delete data that resides in a database table. The generated code corresponds to the columns in the database table.

This article focuses on making an update to the database structure and propagating that change throughout the web application.

In this tutorial, you:

> [!div class="checklist"]
> * Add a column
> * Add the property to the views

## Prerequisites

* [Generating views](generating-views.md)

## Add a column

If you update the structure of a table in your database, you need to ensure that your change is propagated to the data model, views, and controller.

For this tutorial, you will add a new column to the Student table to record the middle name of the student. To add this column, open the database project, and open the Student.sql file. Through either the designer or the T-SQL code, add a column named **MiddleName** that is an NVARCHAR(50) and allows NULL values.

Deploy this change to your local database by starting your database project (or F5). The new field is added to the table. If you do not see it in the SQL Server Object Explorer, click the Refresh button in the pane.

![show new column](changing-the-database/_static/image2.png)

The new column exists in the database table, but it does not currently exist in the data model class. You must update the model to include your new column. In the **Models** folder, open the **ContosoModel.edmx** file to display the model diagram. Notice that the Student model does not contain the MiddleName property. Right-click anywhere on the design surface, and select **Update Model from Database**.

In the Update Wizard, select the **Refresh** tab and then select **Tables** > **dbo** > **Student**. Click **Finish**.

After the update process is finished, the database diagram includes the new **MiddleName** property. Save the **ContosoModel.edmx** file. You must save this file for the new property to be propagated to the **Student.cs** class. You have now updated the database and the model.

Build the solution.

## Add the property to the views

Unfortunately, the views still do not contain the new property. To update the views you have two options - you can either re-generate the views by once again adding scaffolding for the Student class, or you can manually add the new property to your existing views. In this tutorial, you will add the scaffolding again because you have not made any customized changes to the automatically-generated views. You might consider manually adding the property when you have made changes to the views and do not want to lose those changes.

To ensure the views are re-created, delete the **Students** folder under **Views**, and delete the **StudentsController**. Then, right-click the **Controllers** folder and add scaffolding for the **Student** model. Again, name the controller **StudentsController**. Select **Add**.

Build the solution again. The views now contain the MiddleName property.

![show middle name](changing-the-database/_static/image5.png)

## Next steps

In this tutorial, you:

> [!div class="checklist"]
> * Added a column
> * Added the property to the views

Advance to the next article to learn how to customize the view for showing details about a student record.
> [!div class="nextstepaction"]
> [Customize a view](customizing-a-view.md)