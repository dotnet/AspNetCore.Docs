---
title: "Part 6: ASP.NET Membership | Microsoft Docs"
author: JoeStagner
description: "This tutorial series details all of the steps taken to build the Tailspin Spyworks sample application. Part 6 adds ASP.NET Membership."
ms.author: riande
manager: wpickett
ms.date: 07/21/2010
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/older-versions-getting-started/tailspin-spyworks/tailspin-spyworks-part-6
---
Part 6: ASP.NET Membership
====================
by [Joe Stagner](https://github.com/JoeStagner)

> Tailspin Spyworks demonstrates how extraordinarily simple it is to create powerful, scalable applications for the .NET platform. It shows off how to use the great new features in ASP.NET 4 to build an online store, including shopping, checkout, and administration.
> 
> This tutorial series details all of the steps taken to build the Tailspin Spyworks sample application. Part 6 adds ASP.NET Membership.


## <a id="_Toc260221672"></a>  Working with ASP.NET Membership

![](tailspin-spyworks-part-6/_static/image1.png)

Click Security

![](tailspin-spyworks-part-6/_static/image1.jpg)

Make sure that we are using forms authentication.

![](tailspin-spyworks-part-6/_static/image2.jpg)

Use the "Create User" link to create a couple of users.

![](tailspin-spyworks-part-6/_static/image3.jpg)

When done, refer to the Solution Explorer window and refresh the view.

![](tailspin-spyworks-part-6/_static/image2.png)

Note that the ASPNETDB.MDF fine has been created. This file contains the tables to support the core ASP.NET services like membership.

Now we can begin implementing the checkout process.

Begin by creating a CheckOut.aspx page.

The CheckOut.aspx page should only be available to users who are logged in so we will restrict access to logged in users and redirect users who are not logged in to the LogIn page.

To do this we'll add the following to the configuration section of our web.config file.

[!code[Main](tailspin-spyworks-part-6/samples/sample1.xml)]

The template for ASP.NET Web Forms applications automatically added an authentication section to our web.config file and established the default login page.

[!code[Main](tailspin-spyworks-part-6/samples/sample2.xml)]

We must modify the Login.aspx code behind file to migrate an anonymous shopping cart when the user logs in. Change the Page\_Load event as follows.

[!code[Main](tailspin-spyworks-part-6/samples/sample3.xml)]

Then add a "LoggedIn" event handler like this to set the session name to the newly logged in user and change the temporary session id in the shopping cart to that of the user by calling the MigrateCart method in our MyShoppingCart class. (Implemented in the .cs file)

[!code[Main](tailspin-spyworks-part-6/samples/sample4.xml)]

Implement the MigrateCart() method like this.

[!code[Main](tailspin-spyworks-part-6/samples/sample5.xml)]

In checkout.aspx we'll use an EntityDataSource and a GridView in our check out page much as we did in our shopping cart page.

[!code[Main](tailspin-spyworks-part-6/samples/sample6.xml)]

Note that our GridView control specifies an "ondatabound" event handler named MyList\_RowDataBound so let's implement that event handler like this.

[!code[Main](tailspin-spyworks-part-6/samples/sample7.xml)]

This method keeps a running total of the shopping cart as each row is bound and updates the bottom row of the GridView.

At this stage we have implemented a "review" presentation of the order to be placed.

Let's handle an empty cart scenario by adding a few lines of code to our Page\_Load event:

[!code[Main](tailspin-spyworks-part-6/samples/sample8.xml)]

When the user clicks on the "Submit" button we will execute the following code in the Submit Button Click Event handler.

[!code[Main](tailspin-spyworks-part-6/samples/sample9.xml)]

The "meat" of the order submission process is to be implemented in the SubmitOrder() method of our MyShoppingCart class.

SubmitOrder will:

- Take all the line items in the shopping cart and use them to create a new Order Record and the associated OrderDetails records.
- Calculate Shipping Date.
- Clear the shopping cart.


[!code[Main](tailspin-spyworks-part-6/samples/sample10.xml)]

For the purposes of this sample application we'll calculate a ship date by simply adding two days to the current date.

[!code[Main](tailspin-spyworks-part-6/samples/sample11.xml)]

Running the application now will permit us to test the shopping process from start to finish.

>[!div class="step-by-step"] [Previous](tailspin-spyworks-part-5.md) [Next](tailspin-spyworks-part-7.md)