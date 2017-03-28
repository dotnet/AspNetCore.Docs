---
uid: web-forms/overview/older-versions-getting-started/tailspin-spyworks/tailspin-spyworks-part-4
title: "Part 4: Listing Products | Microsoft Docs"
author: JoeStagner
description: "This tutorial series details all of the steps taken to build the Tailspin Spyworks sample application. Part 4 covers listing products with the GridView contr..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 07/21/2010
ms.topic: article
ms.assetid: 4fab47d5-a6ec-4fdc-91f0-651a093a24b9
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/older-versions-getting-started/tailspin-spyworks/tailspin-spyworks-part-4
msc.type: authoredcontent
---
Part 4: Listing Products
====================
by [Joe Stagner](https://github.com/JoeStagner)

> Tailspin Spyworks demonstrates how extraordinarily simple it is to create powerful, scalable applications for the .NET platform. It shows off how to use the great new features in ASP.NET 4 to build an online store, including shopping, checkout, and administration.
> 
> This tutorial series details all of the steps taken to build the Tailspin Spyworks sample application. Part 4 covers listing products with the GridView control.


## <a id="_Toc260221670"></a>  Listing Products with the GridView Control

Let's begin implementing our ProductsList.aspx page by "Right Clicking" on our solution and selecting "Add" and "New Item".

![](tailspin-spyworks-part-4/_static/image1.jpg)

Choose "Web Form Using Master Page" and enter a page name of ProductsList.aspx".

Click "Add".

![](tailspin-spyworks-part-4/_static/image2.jpg)

Next choose the "Styles" folder where we placed the Site.Master page and select it from the "Contents of folder" window.

![](tailspin-spyworks-part-4/_static/image3.jpg)

Click "Ok" to create the page.

Our database is populated with product data as seen below.

![](tailspin-spyworks-part-4/_static/image4.jpg)

After our page is created we'll again use an Entity Data Source to access that product data, but in this instance we need to select the Product Entities and we need to restrict the items that are returned to only those for the selected Category.

To accomplish this we'll tell the EntityDataSource to Auto Generate the WHERE clause and we'll specify the WhereParameter.

You'll recall that when we created the Menu Items in our "Product Category Menu" we dynamically built the link by adding the CatagoryID to the QueryString for each link. We will tell the Entity Data Source to derive the WHERE parameter from that QueryString parameter.

[!code-aspx[Main](tailspin-spyworks-part-4/samples/sample1.aspx)]

Next, we'll configure the ListView control to display a list of products. To create an optimal shopping experience we'll compact several concise features into each individual product displayed in our ListVew.

- The product name will be a link to the product's detail view.
- The product's price will be displayed.
- An image of the product will be displayed and we'll dynamically select the image from a catalog images directory in our application.
- We will include a link to immediately add the specific product to the shopping cart.

Here is the markup for our ListView control instance.

[!code-aspx[Main](tailspin-spyworks-part-4/samples/sample2.aspx)]

We are dynamically building several links for each displayed product.

Also, before we test own new page we need to create the directory structure for the product catalog images as follows.

![](tailspin-spyworks-part-4/_static/image1.png)

Once our product images are accessible we can test our product list page.

![](tailspin-spyworks-part-4/_static/image5.jpg)

From the site's home page, click on one of the Category List Links.

![](tailspin-spyworks-part-4/_static/image6.jpg)

Now we need to implement the ProductDetials.apsx page and the AddToCart functionality.

Use File-&gt;New to create a page name ProductDetails.aspx using the site Master Page as we did previously.

We will again use an EntityDataSource control to access the specific product record in the database and we will use an ASP.NET FormView control to display the product data as follows.

[!code-aspx[Main](tailspin-spyworks-part-4/samples/sample3.aspx)]

Don't worry if the formatting looks a bit funny to you. The markup above leaves room in the display layout for a couple of features we'll implement later on.

The Shopping Cart will represent the more complex logic in our application. To get started, use File-&gt;New to create a page called MyShoppingCart.aspx.

Note that we are not choosing the name ShoppingCart.aspx.

Our database contains a table named "ShoppingCart". When we generated an Entity Data Model a class was created for each table in the database. Therefore, the Entity Data Model generated an Entity Class named "ShoppingCart". We could edit the model so that we could use that name for our shopping cart implementation or extend it for our needs, but we will opt instead to simply slect a name that will avoid the conflict.

It's also worth noting that we will be creating a simple shopping cart and embedding the shopping cart logic with the shopping cart display. We might also choose to implement our shopping cart in a completely separate Business Layer.

>[!div class="step-by-step"]
[Previous](tailspin-spyworks-part-3.md)
[Next](tailspin-spyworks-part-5.md)