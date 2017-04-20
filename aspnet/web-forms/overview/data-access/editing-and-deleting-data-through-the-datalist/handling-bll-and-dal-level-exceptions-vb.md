---
uid: web-forms/overview/data-access/editing-and-deleting-data-through-the-datalist/handling-bll-and-dal-level-exceptions-vb
title: "Handling BLL- and DAL-Level Exceptions (VB) | Microsoft Docs"
author: rick-anderson
description: "In this tutorial, we'll see how to tactfully handle exceptions raised during an editable DataList's updating workflow."
ms.author: aspnetcontent
manager: wpickett
ms.date: 10/30/2006
ms.topic: article
ms.assetid: ca665073-b379-4239-9404-f597663ca65e
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/data-access/editing-and-deleting-data-through-the-datalist/handling-bll-and-dal-level-exceptions-vb
msc.type: authoredcontent
---
Handling BLL- and DAL-Level Exceptions (VB)
====================
by [Scott Mitchell](https://twitter.com/ScottOnWriting)

[Download Sample App](http://download.microsoft.com/download/9/c/1/9c1d03ee-29ba-4d58-aa1a-f201dcc822ea/ASPNET_Data_Tutorial_38_VB.exe) or [Download PDF](handling-bll-and-dal-level-exceptions-vb/_static/datatutorial38vb1.pdf)

> In this tutorial, we'll see how to tactfully handle exceptions raised during an editable DataList's updating workflow.


## Introduction

In the [Overview of Editing and Deleting Data in the DataList](an-overview-of-editing-and-deleting-data-in-the-datalist-cs.md) tutorial, we created a DataList that offered simple editing and deleting capabilities. While fully functional, it was hardly user-friendly, as any error that occurred during the editing or deleting process resulted in an unhandled exception. For example, omitting the product s name or, when editing a product, entering a price value of Very affordable!, throws an exception. Since this exception is not caught in code, it bubbles up to the ASP.NET runtime, which then displays the exception s details in the web page.

As we saw in the [Handling BLL- and DAL-Level Exceptions in an ASP.NET Page](../editing-inserting-and-deleting-data/handling-bll-and-dal-level-exceptions-in-an-asp-net-page-cs.md) tutorial, if an exception is raised from the depths of the Business Logic or Data Access Layers, the exception details are returned to the ObjectDataSource and then to the GridView. We saw how to gracefully handle these exceptions by creating `Updated` or `RowUpdated` event handlers for the ObjectDataSource or GridView, checking for an exception, and then indicating that the exception was handled.

Our DataList tutorials, however, aren t using the ObjectDataSource for updating and deleting data. Instead, we are working directly against the BLL. In order to detect exceptions originating from the BLL or DAL, we need to implement exception handling code within the code-behind of our ASP.NET page. In this tutorial, we'll see how to more tactfully handle exceptions raised during an editable DataList s updating workflow.

> [!NOTE]
> In the *An Overview of Editing and Deleting Data in the DataList* tutorial we discussed different techniques for editing and deleting data from the DataList, Some techniques involved using an ObjectDataSource for updating and deleting. If you employ these techniques, you can handle exceptions from the BLL or DAL through the ObjectDataSource s `Updated` or `Deleted` event handlers.


## Step 1: Creating an Editable DataList

Before we worry about handling exceptions that occur during the updating workflow, let s first create an editable DataList. Open the `ErrorHandling.aspx` page in the `EditDeleteDataList` folder, add a DataList to the Designer, set its `ID` property to `Products`, and add a new ObjectDataSource named `ProductsDataSource`. Configure the ObjectDataSource to use the `ProductsBLL` class s `GetProducts()` method for selecting records; set the drop-down lists in the INSERT, UPDATE, and DELETE tabs to (None).


[![Return the Product Information Using the GetProducts() Method](handling-bll-and-dal-level-exceptions-vb/_static/image2.png)](handling-bll-and-dal-level-exceptions-vb/_static/image1.png)

**Figure 1**: Return the Product Information Using the `GetProducts()` Method ([Click to view full-size image](handling-bll-and-dal-level-exceptions-vb/_static/image3.png))


After completing the ObjectDataSource wizard, Visual Studio will automatically create an `ItemTemplate` for the DataList. Replace this with an `ItemTemplate` that displays each product s name and price and includes an Edit button. Next, create an `EditItemTemplate` with a TextBox Web control for name and price and Update and Cancel buttons. Finally, set the DataList s `RepeatColumns` property to 2.

After these changes, your page s declarative markup should look similar to the following. Double-check to make certain that the Edit, Cancel, and Update buttons have their `CommandName` properties set to Edit, Cancel, and Update, respectively.


[!code-aspx[Main](handling-bll-and-dal-level-exceptions-vb/samples/sample1.aspx)]

> [!NOTE]
> For this tutorial the DataList s view state must be enabled.


Take a moment to view our progress through a browser (see Figure 2).


[![Each Product Includes an Edit Button](handling-bll-and-dal-level-exceptions-vb/_static/image5.png)](handling-bll-and-dal-level-exceptions-vb/_static/image4.png)

**Figure 2**: Each Product Includes an Edit Button ([Click to view full-size image](handling-bll-and-dal-level-exceptions-vb/_static/image6.png))


Currently, the Edit button only causes a postback it doesn t yet make the product editable. To enable editing, we need to create event handlers for the DataList s `EditCommand`, `CancelCommand`, and `UpdateCommand` events. The `EditCommand` and `CancelCommand` events simply update the DataList s `EditItemIndex` property and rebind the data to the DataList:


[!code-vb[Main](handling-bll-and-dal-level-exceptions-vb/samples/sample2.vb)]

The `UpdateCommand` event handler is a bit more involved. It needs to read in the edited product s `ProductID` from the `DataKeys` collection along with the product s name and price from the TextBoxes in the `EditItemTemplate`, and then call the `ProductsBLL` class s `UpdateProduct` method before returning the DataList to its pre-editing state.

For now, let s just use the exact same code from the `UpdateCommand` event handler in the *Overview of Editing and Deleting Data in the DataList* tutorial. We'll add the code to gracefully handle exceptions in step 2.


[!code-vb[Main](handling-bll-and-dal-level-exceptions-vb/samples/sample3.vb)]

In the face of invalid input which can be in the form of an improperly formatted unit price, an illegal unit price value like -$5.00, or the omission of the product s name an exception will be raised. Since the `UpdateCommand` event handler does not include any exception handling code at this point, the exception will bubble up to the ASP.NET runtime, where it will be displayed to the end user (see Figure 3).


![When an Unhandled Exception Occurs, the End User Sees an Error Page](handling-bll-and-dal-level-exceptions-vb/_static/image7.png)

**Figure 3**: When an Unhandled Exception Occurs, the End User Sees an Error Page


## Step 2: Gracefully Handling Exceptions in the UpdateCommand Event Handler

During the updating workflow, exceptions can occur in the `UpdateCommand` event handler, the BLL, or the DAL. For example, if a user enters a price of Too expensive, the `Decimal.Parse` statement in the `UpdateCommand` event handler will throw a `FormatException` exception. If the user omits the product s name or if the price has a negative value, the DAL will raise an exception.

When an exception occurs, we want to display an informative message within the page itself. Add a Label Web control to the page whose `ID` is set to `ExceptionDetails`. Configure the Label s text to display in a red, extra-large, bold and italic font by assigning its `CssClass` property to the `Warning` CSS class, which is defined in the `Styles.css` file.

When an error occurs, we only want the Label to be displayed once. That is, on subsequent postbacks, the Label s warning message should disappear. This can be accomplished by either clearing out the Label s `Text` property or settings its `Visible` property to `False` in the `Page_Load` event handler (as we did back in the [Handling BLL- and DAL-Level Exceptions in an ASP.NET Page](../editing-inserting-and-deleting-data/handling-bll-and-dal-level-exceptions-in-an-asp-net-page-vb.md) tutorial) or by disabling the Label s view state support. Let s use the latter option.


[!code-aspx[Main](handling-bll-and-dal-level-exceptions-vb/samples/sample4.aspx)]

When an exception is raised, we'll assign the details of the exception to the `ExceptionDetails` Label control s `Text` property. Since its view state is disabled, on subsequent postbacks the `Text` property s programmatic changes will be lost, reverting back to the default text (an empty string), thereby hiding the warning message.

To determine when an error has been raised in order to display a helpful message on the page, we need to add a `Try ... Catch` block to the `UpdateCommand` event handler. The `Try` portion contains code that may lead to an exception, while the `Catch` block contains code that is executed in the face of an exception. Check out the [Exception Handling Fundamentals](https://msdn.microsoft.com/en-us/library/2w8f0bss.aspx) section in the .NET Framework documentation for more information on the `Try ... Catch` block.


[!code-vb[Main](handling-bll-and-dal-level-exceptions-vb/samples/sample5.vb)]

When an exception of any type is thrown by code within the `Try` block, the `Catch` block s code will begin executing. The type of exception that is thrown `DbException`, `NoNullAllowedException`, `ArgumentException`, and so on depends on what, exactly, precipitated the error in the first place. If there s a problem at the database level, a `DbException` will be thrown. If an illegal value is entered for the `UnitPrice`, `UnitsInStock`, `UnitsOnOrder`, or `ReorderLevel` fields, an `ArgumentException` will be thrown, as we added code to validate these field values in the `ProductsDataTable` class (see the [Creating a Business Logic Layer](../introduction/creating-a-business-logic-layer-vb.md) tutorial).

We can provide a more helpful explanation to the end user by basing the message text on the type of exception caught. The following code which was used in a nearly identical form back in the [Handling BLL- and DAL-Level Exceptions in an ASP.NET Page](../editing-inserting-and-deleting-data/handling-bll-and-dal-level-exceptions-in-an-asp-net-page-vb.md) tutorial provides this level of detail:


[!code-vb[Main](handling-bll-and-dal-level-exceptions-vb/samples/sample6.vb)]

To complete this tutorial, simply call the `DisplayExceptionDetails` method from the `Catch` block passing in the caught `Exception` instance (`ex`).

With the `Try ... Catch` block in place, users are presented with a more informative error message, as Figures 4 and 5 show. Note that in the face of an exception the DataList remains in edit mode. This is because once the exception occurs, the control flow is immediately redirected to the `Catch` block, bypassing the code that returns the DataList to its pre-editing state.


[![An Error Message is Displayed if a User Omits a Required Field](handling-bll-and-dal-level-exceptions-vb/_static/image9.png)](handling-bll-and-dal-level-exceptions-vb/_static/image8.png)

**Figure 4**: An Error Message is Displayed if a User Omits a Required Field ([Click to view full-size image](handling-bll-and-dal-level-exceptions-vb/_static/image10.png))


[![An Error Message is Displayed When Entering a Negative Price](handling-bll-and-dal-level-exceptions-vb/_static/image12.png)](handling-bll-and-dal-level-exceptions-vb/_static/image11.png)

**Figure 5**: An Error Message is Displayed When Entering a Negative Price ([Click to view full-size image](handling-bll-and-dal-level-exceptions-vb/_static/image13.png))


## Summary

The GridView and ObjectDataSource provide post-level event handlers that include information about any exceptions that were raised during the updating and deleting workflow, as well as properties that can be set to indicate whether or not the exception has been handled. These features, however, are unavailable when working with the DataList and using the BLL directly. Instead, we are responsible for implementing exception handling.

In this tutorial we saw how to add exception handling to an editable DataList s updating workflow by adding a `Try ... Catch` block to the `UpdateCommand` event handler. If an exception is raised during the updating workflow, the `Catch` block s code executes, displaying helpful information in the `ExceptionDetails` Label.

At this point, the DataList makes no effort to prevent exceptions from happening in the first place. Even though we know that a negative price will result in an exception, we haven t yet added any functionality to proactively prevent a user from entering such invalid input. In our next tutorial we'll see how to help reduce the exceptions caused by invalid user input by adding validation controls in the `EditItemTemplate`.

Happy Programming!

## Further Reading

For more information on the topics discussed in this tutorial, refer to the following resources:

- [Design Guidelines for Exceptions](https://msdn.microsoft.com/en-us/library/ms298399.aspx)
- [Error Logging Modules and Handlers (ELMAH)](http://workspaces.gotdotnet.com/elmah) (an open-source library for logging errors)
- [Enterprise Library for .NET Framework 2.0](https://www.microsoft.com/downloads/details.aspx?familyid=5A14E870-406B-4F2A-B723-97BA84AE80B5&amp;displaylang=en) (includes the Exception Management Application Block)

## About the Author

[Scott Mitchell](http://www.4guysfromrolla.com/ScottMitchell.shtml), author of seven ASP/ASP.NET books and founder of [4GuysFromRolla.com](http://www.4guysfromrolla.com), has been working with Microsoft Web technologies since 1998. Scott works as an independent consultant, trainer, and writer. His latest book is [*Sams Teach Yourself ASP.NET 2.0 in 24 Hours*](https://www.amazon.com/exec/obidos/ASIN/0672327384/4guysfromrollaco). He can be reached at [mitchell@4GuysFromRolla.com.](mailto:mitchell@4GuysFromRolla.com) or via his blog, which can be found at [http://ScottOnWriting.NET](http://ScottOnWriting.NET).

## Special Thanks To

This tutorial series was reviewed by many helpful reviewers. Lead reviewer for this tutorial was Ken Pespisa. Interested in reviewing my upcoming MSDN articles? If so, drop me a line at [mitchell@4GuysFromRolla.com.](mailto:mitchell@4GuysFromRolla.com)

>[!div class="step-by-step"]
[Previous](performing-batch-updates-vb.md)
[Next](adding-validation-controls-to-the-datalist-s-editing-interface-vb.md)