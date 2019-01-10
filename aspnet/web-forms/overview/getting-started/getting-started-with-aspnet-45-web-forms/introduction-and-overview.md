---
uid: web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/introduction-and-overview
title: "Getting Started with ASP.NET 4.7 Web Forms and Visual Studio 2017 | Microsoft Docs"
author: Erikre
description: "This step-by-step tutorial series will teach you the basics of building an ASP.NET Web Forms application using ASP.NET 4.7 and Microsoft Visual Studio"
ms.author: riande
ms.date: 01/09/2019
ms.assetid: 9b96eaa1-8ef0-4338-a2e8-e0f970bfaf68
msc.legacyurl: /web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/introduction-and-overview
msc.type: authoredcontent
---
Getting Started with ASP.NET 4.5 Web Forms and Visual Studio 2017
====================
by [Erik Reitan](https://github.com/Erikre)

[Download Wingtip Toys Sample Project (C#)](http://go.microsoft.com/fwlink/?LinkID=389434&clcid=0x409) or [Download E-book (PDF)](http://download.microsoft.com/download/0/F/B/0FBFAA46-2BFD-478F-8E56-7BF3C672DF9D/Getting%20Started%20with%20ASP.NET%204.5%20Web%20Forms%20and%20Visual%20Studio%202013.pdf)

This tutorial series teaches you how to build an ASP.NET Web Forms application with ASP.NET 4.5 and Microsoft Visual Studio 2017. 

## Introduction

This tutorial series guides you through creating an ASP.NET Web Forms application using Visual Studio 2017 and ASP.NET 4.5. You'll create an application named **Wingtip Toys** - a simplified storefront web site selling items online. During the series, new ASP.NET 4.5 features are highlighted.

Comments are welcome, and every effort is made to make updates based on your suggestions.

### Target audience

Developers new to ASP.NET Web Forms are the target audience for this tutorial series.

You should have some knowledge in the following areas:

- Object-oriented programming (OOP) and languages
- Web development (HTML, CSS, JavaScript)
- Relational databases
- N-tier architecture

To review these areas, consider studying the following content:

- [Getting Started with Visual C#](https://msdn.microsoft.com/library/a72418yk.aspx)
- [Web Development](https://msdn.microsoft.com/beginner/bb308760.aspx), [HTML, CSS, JavaScript, SQL, PHP, JQuery](http://w3schools.com/)
- [Relational database](http://en.wikipedia.org/wiki/Relational_database)
- [Multitier architecture](http://en.wikipedia.org/wiki/Multitier_architecture)

### Application features

The ASP.NET Web Form features presented in this series include:

- The Web Application Project (not Web Site Project)
- Web Forms
- Master Pages, Configuration
- Bootstrap
- Entity Framework Code First, LocalDB
- Request Validation
- Strongly-typed Data Controls
- Model Binding
- Data Annotations
- Value Providers
- SSL and OAuth
- ASP.NET Identity, Configuration, and Authorization
- Unobtrusive Validation
- Routing
- ASP.NET Error Handling

### Application scenarios and tasks

Tutorial series tasks include:

- Creating, reviewing, and running a new project
- Creating a database structure
- Initializing and seeding a database
- Customizing the UI with styles, graphics, and a master page
- Adding pages and navigation
- Displaying menu details and product data
- Creating a shopping cart
- Adding SSL and OAuth support
- Adding a payment method
- Including an administrator role and a user to the application
- Restricting access to specific pages and folder
- Uploading a file to the web application
- Implementing input validation
- Registering routes for the web application
- Implementing error handling and error logging

## Overview

This tutorial series is intended for someone familiar with programming concepts, but new to ASP.NET Web Forms. If you're already familiar with ASP.NET Web Forms, this series can still help you learn about new ASP.NET 4.5 features. For readers unfamiliar with programming concepts and ASP.NET Web Forms, see the additional Web Forms tutorials provided in the [Getting Started](../../../index.md) section on the ASP.NET Web site.

The ASP.NET 4.5 provided in this tutorial series includes the following features:

- A simple UI for creating projects that offers [support for many ASP.NET frameworks](../../../../visual-studio/overview/2013/creating-web-projects-in-visual-studio.md#add) (Web Forms, MVC, and Web API).
- [Bootstrap](../../../../visual-studio/overview/2013/creating-web-projects-in-visual-studio.md#bootstrap), a layout, theming, and responsive design framework.
- [ASP.NET Identity](../../../../identity/index.md), a new ASP.NET membership system that works the same in all ASP.NET frameworks and works with web hosting software other than IIS.
- [Entity Framework 6](https://msdn.microsoft.com/data/ef.aspx)

  An update to the Entity Framework enabling you to:
  - Retrieve and manipulate data as strongly-typed objects
  - Access data asynchronously
  - Handle transient connection faults
  - Log SQL statements

For a complete ASP.NET 4.5 feature list, see [ASP.NET and Web Tools for Visual Studio 2013 Release Notes](../../../../visual-studio/overview/2013/release-notes.md).

### The Wingtip Toys sample application

The following screenshots are from the ASP.NET Web Forms application that you create in this tutorial series. When you run the application in Visual Studio, the following web Home page appears.

![Wingtip Toys - Default page](introduction-and-overview/_static/image1.png)

You can register as a new user, or sign in as an existing user. The top navigation has links to product categories and their products from the database.

If you select **Products**, all available products are displayed. 

![Wingtip Toys - Products](introduction-and-overview/_static/image2.png)

If you select a specific product, product details are displayed.


![Wingtip Toys - Product Details](introduction-and-overview/_static/image3.png)

As a user, you can register and sign in with Web Forms template default functionality. This tutorial also explains how to sign in using an existing Gmail account. Additionally, you can sign in as the administrator to add and remove products from the database.

![Wingtip Toys - Sign in](introduction-and-overview/_static/image4.png)

Once you've signed in as a user, you can add products to the shopping cart and checkout with PayPal. The sample application is designed to work in PayPal's developer sandbox. No actual money transaction takes place.

![Wingtip Toys - Shopping Cart](introduction-and-overview/_static/image5.png)

PayPal confirms your account, order, and payment information.

![Wingtip Toys - PayPal](introduction-and-overview/_static/image6.png)

After returning from PayPal, you can review and complete your order.

![Wingtip Toys - Order Review](introduction-and-overview/_static/image7.png)

## Prerequisites

Before you start, make sure the following software is installed on your computer:

- [Microsoft Visual Studio 2017 or Microsoft Visual Studio Community 2017](https://visualstudio.microsoft.com/downloads/).

The .NET Framework is installed automatically.

This tutorial series uses Microsoft Visual Studio Community 2017. You can use either that or Microsoft Visual Studio 2017 to complete this tutorial series.

Note the following about Visual Studio:

* Microsoft Visual Studio 2017 and Microsoft Visual Studio Community 2017 are referred to as *Visual Studio* throughout this tutorial series.

* Visual Studio 2017 gets installed next to any older versions already installed. Sites created in earlier versions can be opened in Visual Studio 2017 and continue to open in previous versions.

* It is assumed that the first time you started Visual Studio you selected the *Web Development* settings. For more information, see [How to: Select Web Development Environment Settings](https://msdn.microsoft.com/library/ff521558.aspx).


## Download the sample application

After installing the prerequisites, you're ready to begin creating the Web project presented in this tutorial series. To run the sample application prior to this, you can download it from the MSDN Samples site:

[Getting Started with ASP.NET 4.5 Web Forms and Visual Studio 2013 - Wingtip Toys](https://go.microsoft.com/fwlink/?LinkID=389434&clcid=0x409) (C#) 

 This download has the following items:

- The sample application in the *WingtipToys* folder.
- The resources used to create the sample application in the *WingtipToys-Assets* folder in the *WingtipToys* folder.

The download is a *.zip* file. To see the completed project that this tutorial series creates, find and select the *C#* folder in the .zip file. Save the C# folder to the folder you use to work with Visual Studio projects. By default, the Visual Studio 2017 projects folder is:

<strong>C:\Users&#92;</strong><strong><em>&lt;username&gt;</em></strong><strong>\source\repos</strong>

Rename the ***C#*** folder to ***WingtipToys***.

> [!NOTE]
> If you already have a folder named *WingtipToys* in your Projects folder, temporarily rename that existing folder before renaming the *C#* folder to *WingtipToys*.

To run the completed project, open the *WingtipToys* folder and double-click the *WingtipToys.sln* file. Visual Studio 2017 opens the project. Next, right-click the *Default.aspx* file in **Solution Explorer** and select **View In Browser**.

## Take a ASP.NET Web Forms quiz to review content

After completing the tutorial series, take a quiz to test your knowledge and reinforce key concepts. Each question provides an explanation and links to additional guidance.

 * [ASP.NET Web Forms Quiz](https://blogs.msdn.microsoft.com/erikreitan/2016/01/08/asp-net-web-forms-quiz/) 

## Tutorial support and comments

For questions and comments, use the Q and A section included on the [Getting Started with ASP.NET 4.5 Web Forms and Visual Studio 2013 - Wingtip Toys](https://go.microsoft.com/fwlink/?LinkID=389434&clcid=0x409) (C#) sample page.

Comments on this tutorial series are welcome. When this tutorial series is updated, every effort is made to consider corrections or suggestions for improvements.

If an error occurs, the corresponding error messages could be confusing, with no good explanation on how to fix it. For help, you can check the [ASP.NET forums](https://forums.asp.net/). Another good source is the Q and A section in the [Getting Started with ASP.NET 4.5 Web Forms and Visual Studio 2013 - Wingtip Toys](https://go.microsoft.com/fwlink/?LinkID=389434&clcid=0x409) (C#) sample page. 

> [!div class="step-by-step"]
> [Next](create-the-project.md)
