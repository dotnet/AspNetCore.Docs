---
uid: web-forms/overview/older-versions-getting-started/tailspin-spyworks/tailspin-spyworks-part-7
title: "Part 7: Adding Features | Microsoft Docs"
author: JoeStagner
description: "This tutorial series details all of the steps taken to build the Tailspin Spyworks sample application. Part 7 adds additional features, such as account revie..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 07/21/2010
ms.topic: article
ms.assetid: 50223ee9-11b9-4cf3-bca2-e2f10bf471f3
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/older-versions-getting-started/tailspin-spyworks/tailspin-spyworks-part-7
msc.type: authoredcontent
---
Part 7: Adding Features
====================
by [Joe Stagner](https://github.com/JoeStagner)

> Tailspin Spyworks demonstrates how extraordinarily simple it is to create powerful, scalable applications for the .NET platform. It shows off how to use the great new features in ASP.NET 4 to build an online store, including shopping, checkout, and administration.
> 
> This tutorial series details all of the steps taken to build the Tailspin Spyworks sample application. Part 7 adds additional features, such as account review, product reviews, and "popular items" and "also purchased" user controls.


## <a id="_Toc260221673"></a>  Adding Features

Though users can browse our catalog, place items in their shopping cart, and complete the checkout process, there are a number of supporting features that we will include to improve our site.

1. Account Review (List orders placed and view details.)
2. Add some context specific content to the front page.
3. Add a feature to let users Review the products in the catalog.
4. Create a User Control to display Popular Items and Place that control on the front page.
5. Create an "Also Purchased" user control and add it to the product details page.
6. Add a Contact Page.
7. Add an About Page.
8. Global Error

## <a id="_Toc260221674"></a>  Account Review

In the "Account" folder create two .aspx pages one named OrderList.aspx and the other named OrderDetails.aspx

OrderList.aspx will leverage the GridView and EntityDataSoure controls much as we have previously.

[!code-aspx[Main](tailspin-spyworks-part-7/samples/sample1.aspx)]

The EntityDataSoure selects records from the Orders table filtered on the UserName (see the WhereParameter) which we set in a session variable when the user log's in.

Note also these parameters in the HyperlinkField of the GridView:

[!code-xml[Main](tailspin-spyworks-part-7/samples/sample2.xml)]

These specify the link to the Order details view for each product specifying the OrderID field as a QueryString parameter to the OrderDetails.aspx page.

## <a id="_Toc260221675"></a>  OrderDetails.aspx

We will use an EntityDataSource control to access the Orders and a FormView to display the Order data and another EntityDataSource with a GridView to display all the Order's line items.

[!code-aspx[Main](tailspin-spyworks-part-7/samples/sample3.aspx)]

In the Code Behind file (OrderDetails.aspx.cs) we have two little bits of housekeeping.

First we need to make sure that OrderDetails always gets an OrderId.

[!code-csharp[Main](tailspin-spyworks-part-7/samples/sample4.cs)]

We also need to calculate and display the order total from the line items.

[!code-csharp[Main](tailspin-spyworks-part-7/samples/sample5.cs)]

## <a id="_Toc260221676"></a>  The Home Page

Let's add some static content to the Default.aspx page.

First I'll create a "Content" folder and within it an Images folder (and I'll include an image to be used on the home page.)

Into the bottom placeholder of the Default.aspx page, add the following markup.

[!code-aspx[Main](tailspin-spyworks-part-7/samples/sample6.aspx)]

## <a id="_Toc260221677"></a>  Product Reviews

First we'll add a button with a link to a form that we can use to enter a product review.

[!code-aspx[Main](tailspin-spyworks-part-7/samples/sample7.aspx)]

![](tailspin-spyworks-part-7/_static/image1.jpg)

Note that we are passing the ProductID in the query string

Next let's add page named ReviewAdd.aspx

This page will use the ASP.NET AJAC Control Toolkit. If you have not already done so you can download it from here [http://ajaxcontroltoolkit.codeplex.com/](http://ajaxcontroltoolkit.codeplex.com/) and there is guidance on setting up the toolkit for use with Visual Studio here [https://www.asp.net/learn/ajax-videos/video-76.aspx](../../../videos/ajax-control-toolkit/how-do-i-get-started-with-the-aspnet-ajax-control-toolkit.md).

In design mode, drag controls and validators from the toolbox and build a form like the one below.

![](tailspin-spyworks-part-7/_static/image2.jpg)

The markup will look something like this.

[!code-aspx[Main](tailspin-spyworks-part-7/samples/sample8.aspx)]

Now that we can enter reviews, lets display those reviews on the product page.

Add this markup to the ProductDetails.aspx page.

[!code-aspx[Main](tailspin-spyworks-part-7/samples/sample9.aspx)]

Running our application now and navigating to a product shows the product information including customer reviews.

![](tailspin-spyworks-part-7/_static/image3.jpg)

## <a id="_Toc260221678"></a>  Popular Items Control (Creating User Controls)

In order to increase sales on your web site we will add a couple of features to "suggestive sell" popular or related products.

The first of these features will be a list of the more popular product in our product catalog.

We will create a "User Control" to display the top selling items on the home page of our application. Since this will be a control, we can use it on any page by simply dragging and dropping the control in Visual Studio's designer onto any page that we like.

In Visual Studio's solutions explorer, right-click on the solution name and create a new directory named "Controls". While it is not necessary to do so, we will help keep our project organized by creating all our user controls in the "Controls" directory.

Right-click on the controls folder and choose "New Item" :

![](tailspin-spyworks-part-7/_static/image4.jpg)

Specify a name for our control of "PopularItems". Note that the file extension for user controls is .ascx not .aspx.

Our Popular Items User control will be defined as follows.

[!code-aspx[Main](tailspin-spyworks-part-7/samples/sample10.aspx)]

Here we're using a method we have not used yet in this application. We're using the repeater control and instead of using a data source control we're binding the Repeater Control to the results of a LINQ to Entities query.

In the code behind of our control we do that as follows.

[!code-csharp[Main](tailspin-spyworks-part-7/samples/sample11.cs)]

Note also this important line at the top of our control's markup.

[!code-aspx[Main](tailspin-spyworks-part-7/samples/sample12.aspx)]

Since the most popular items won't be changing on a minute to minute basis we can add a aching directive to improve the performance of our application. This directive will cause the controls code to only be executed when the cached output of the control expires. Otherwise, the cached version of the control's output will be used.

Now all we have to do is include our new control in our Default.aspc page.

Use drag and drop to place an instance of the control in the open column of our Default form.

![](tailspin-spyworks-part-7/_static/image5.jpg)

Now when we run our application the home page displays the most popular items.

![](tailspin-spyworks-part-7/_static/image6.jpg)

## <a id="_Toc260221679"></a>  "Also Purchased" Control (User Controls with Parameters)

The second User Control that we'll create will take suggestive selling to the next level by adding context specificity.

The logic to calculate the top "Also Purchased" items is non-trivial.

Our "Also Purchased" control will select the OrderDetails records (previously purchased) for the currently selected ProductID and grab the OrderIDs for each unique order that is found.

Then we will select al the products from all those Orders and sum the quantities purchased. We'll sort the products by that quantity sum and display the top five items.

Given the complexity of this logic, we will implement this algorithm as a stored procedure.

The T-SQL for the stored procedure is as follows.

[!code-sql[Main](tailspin-spyworks-part-7/samples/sample13.sql)]

Note that this stored procedure (SelectPurchasedWithProducts) existed in the database when we included it in our application and when we generated the Entity Data Model we specified that, in addition to the Tables and Views that we needed, the Entity Data Model should include this stored procedure.

To access the stored procedure from the Entity Data Model we need to import the function.

Double Click on the Entity Data Model in the Solutions Explorer to open it in the designer and open the Model Browser, then right-click in the designer and select "Add Function Import".

![](tailspin-spyworks-part-7/_static/image1.png)

Doing so will open this dialog.

![](tailspin-spyworks-part-7/_static/image2.png)

Fill out the fields as you see above, selecting the "SelectPurchasedWithProducts" and use the procedure name for the name of our imported function.

Click "Ok".

Having done this we can simply program against the stored procedure as we might any other item in the model.

So, in our "Controls" folder create a new user control named AlsoPurchased.ascx.

The markup for this control will look very familiar to the PopularItems control.

[!code-aspx[Main](tailspin-spyworks-part-7/samples/sample14.aspx)]

The notable difference is that are not caching the output since the item's to be rendered will differ by product.

The ProductId will be a "property" to the control.

[!code-csharp[Main](tailspin-spyworks-part-7/samples/sample15.cs)]

In the control's PreRender event handler we eed to do three things.

1. Make sure the ProductID is set.
2. See if there are any products that have been purchased with the current one.
3. Output some items as determined in #2.

Note how easy it is to call the stored procedure through the model.

[!code-csharp[Main](tailspin-spyworks-part-7/samples/sample16.cs)]

After determining that there ARE "also purchased" we can simply bind the repeater to the results returned by the query.

[!code-csharp[Main](tailspin-spyworks-part-7/samples/sample17.cs)]

If there were not any "also purchased" items we'll simply display other popular items from our catalog.

[!code-csharp[Main](tailspin-spyworks-part-7/samples/sample18.cs)]

To view the "Also Purchased" items, open the ProductDetails.aspx page and drag the AlsoPurchased control from the Solutions Explorer so that it appears in this position in the markup.

[!code-aspx[Main](tailspin-spyworks-part-7/samples/sample19.aspx)]

Doing so will create a reference to the control at the top of the ProductDetails page.

[!code-aspx[Main](tailspin-spyworks-part-7/samples/sample20.aspx)]

Since the AlsoPurchased user control requires a ProductId number we will set the ProductID property of our control by using an Eval statement against the current data model item of the page.

![](tailspin-spyworks-part-7/_static/image3.png)

When we build and run now and browse to a product we see the "Also Purchased" items.

![](tailspin-spyworks-part-7/_static/image7.jpg)

>[!div class="step-by-step"]
[Previous](tailspin-spyworks-part-6.md)
[Next](tailspin-spyworks-part-8.md)