---
uid: mvc/overview/getting-started/database-first-development/customizing-a-view
title: "Tutorial: Customize view for EF Database First with ASP.NET MVC app"
description: "This tutorial focuses on changing the automatically-generated views to enhance the presentation."
author: Rick-Anderson
ms.author: riande
ms.date: 01/24/2019
ms.topic: tutorial
ms.assetid: 269380ff-d7e1-4035-8ad1-fe1316a25f76
msc.legacyurl: /mvc/overview/getting-started/database-first-development/customizing-a-view
msc.type: authoredcontent
---

# Tutorial: Customize view for EF Database First with ASP.NET MVC app

Using MVC, Entity Framework, and ASP.NET Scaffolding, you can create a web application that provides an interface to an existing database. This tutorial series shows you how to automatically generate code that enables users to display, edit, create, and delete data that resides in a database table. The generated code corresponds to the columns in the database table.

This tutorial focuses on changing the automatically-generated views to enhance the presentation.

In this tutorial, you:

> [!div class="checklist"]
> * Add courses to the student detail page
> * Confirm that the courses are added to the page

## Prerequisites

* [Change the database](changing-the-database.md)

## Add courses to student detail

The generated code provides a good starting point for your application but it does not necessarily provide all of the functionality that you need in your application. You can customize the code to meet the particular requirements of your application. Currently, your application does not display the enrolled courses for the selected student. In this section, you will add the enrolled courses for each student to the **Details** view for the student.

Open **Views** > **Students** > *Details.cshtml*. Below the last &lt;/dl&gt; tag, but before the closing &lt;/div&gt; tag, add the following code.

[!code-cshtml[Main](customizing-a-view/samples/sample1.cshtml)]

This code creates a table that displays a row for each record in the Enrollment table for the selected student. The **Display** method renders HTML for the object (modelItem) that represents the expression. You use the Display method (rather than simply embedding the property value in the code) to make sure the value is formatted correctly based on its type and the template for that type. In this example, each expression returns a single property from the current record in the loop, and the values are primitive types which are rendered as text.

## Confirm courses are added

Run the solution. Click **List of students** and select **Details** for one of the students. You will see the enrolled courses have been included in the view.

![student with enrollment](customizing-a-view/_static/image1.png)

## Next steps
In this tutorial, you:

> [!div class="checklist"]
> * Added courses to the student detail page
> * Confirmed that the courses are added to the page

Advance to the next tutorial to learn how to add data annotations to specify validation requirements and display formatting.
> [!div class="nextstepaction"]
> [Enhance data validation](enhancing-data-validation.md)
