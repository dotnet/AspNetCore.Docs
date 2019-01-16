---
uid: web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/display_data_items_and_details
title: "Display Data Items and Details | Microsoft Docs"
author: Erikre
description: "This tutorial series will show you the basics of building an ASP.NET Web Forms application using ASP.NET 4.7 and Microsoft Visual Studio 2017"
ms.author: riande
ms.date: 1/04/2019
ms.assetid: 64a491a8-0ed6-4c2f-9c1c-412962eb6006
msc.legacyurl: /web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/display_data_items_and_details
msc.type: authoredcontent
---
Display data items and details
====================
by [Erik Reitan](https://github.com/Erikre)

> This tutorial series teaches you the basics of building an ASP.NET Web Forms application with ASP.NET 4.7 and Microsoft Visual Studio 2017 for the Web.

In this tutorial, you'll learn how to display data items and data item details using ASP.NET Web Forms and Entity Framework Code First. This tutorial builds on the previous "UI and Navigation" tutorial as part of the Wingtip Toy Store tutorial series. After completing this tutorial, you'll see products on the *ProductsList.aspx* page and a product's details on the *ProductDetails.aspx* page.

## You'll learn how to:

- Add a data control to display products from the database
- Connect a data control to the selected data
- Add a data control to display product details from the database
- Retrieve a value from the query string and use that value to limit the data that's retrieved from the database

### Features introduced in this tutorial:

- Model binding
- Value providers

## Add a data control

You can use a few different options to bind data to a server control. The most common include:

 * Adding a data source control
 * Adding code by hand
 * Using model binding

### Use a data source control to bind data

Adding a data source control allows you to link the data source control to the control that displays the data. With this approach, you can declaratively,  rather than programmatically, connect server-side controls to data sources.

### Code by hand to bind data

Coding by hand involves:

1. Reading a value
2. Checking if it's null
3. Converting it to an appropriate type
4. Checking conversion success
5. Using the value in the query 

This approach lets you have full control over your data-access logic.

### Using model binding to bind data

Model binding lets you bind results using far less code and gives you the ability to reuse the functionality throughout your application. It simplifies working with code-focused data-access logic while still providing a rich, data-binding framework.

## Displaying products

In this tutorial, you'll use model binding to bind data. To configure a data control to use model binding to select data, you set the control's `SelectMethod` property to a method name in the page's code. The data control calls the method at the appropriate time in the page life cycle and automatically binds the returned data. There's no need to explicitly call the `DataBind` method.

1. In **Solution Explorer**, open *ProductList.aspx*.
2. Replace the existing markup with this markup:   

    [!code-aspx-csharp[Main](display_data_items_and_details/samples/sample1.aspx)]

This code uses a **ListView** control named `productList` to display products.

[!code-aspx-csharp[Main](display_data_items_and_details/samples/sample2.aspx)]

Using templates and styles, you define how the **ListView** control displays data. It's useful for data in any repeating structure. Though this **ListView** example simply displays database data, you can also, without code, enable users to edit, insert, and delete data, and to sort and page data.

By setting the `ItemType` property in the **ListView** control, the data-binding expression `Item` is available and the control becomes strongly typed. As mentioned in the previous tutorial, you can select Item object details using IntelliSense, such as specifying the `ProductName`:

![Display Data Items and Details - IntelliSense](display_data_items_and_details/_static/image1.png)

You're also using model binding to specify a `SelectMethod` value. This value (`GetProducts`) corresponds to the method you'll add to the code behind to display products in the next step.

### Add Code to display products

In this step, you'll add code to populate the **ListView** control with product data from the database. The code supports showing all products and  individual category products.

1. In **Solution Explorer**, right-click *ProductList.aspx* and then select **View Code**.
2. Replace the existing code in the *ProductList.aspx.cs* file with this:   

    [!code-csharp[Main](display_data_items_and_details/samples/sample3.cs)]

This code shows the `GetProducts` method that the **ListView** control's `ItemType` property references in the *ProductList.aspx* page. To limit the results to a specific database category, the code sets the `categoryId` value from the query string value passed to the *ProductList.aspx* page when the *ProductList.aspx* page is navigated to. The `QueryStringAttribute` class in the `System.Web.ModelBinding` namespace is used to retrieve the value of the query string variable `id`. This instructs model binding to try to bind a value from the query string to the `categoryId` parameter at run time.

When a valid category is passed as a query string to the page, the results of the query are limited to those products in the database that match the `categoryId` value. For instance, if the *ProductsList.aspx* page URL is this:


[!code-console[Main](display_data_items_and_details/samples/sample4.cmd)]

The page displays only the products where the `categoryId` equals `1`.

All products are displayed if no query string is included when the *ProductList.aspx* page is called.

The sources of values for these methods are referred to as *value providers* (such as *QueryString*), and the parameter attributes that indicate which value provider to use is referred to as value provider attributes (such as `id`). ASP.NET includes value providers and corresponding attributes for all of the typical sources of user input in a Web Forms application such as the query string, cookies, form values, controls, view state, session state, and profile properties. You can also write custom value providers.

### Run the application

Run the application now to view all products or a category's products.

1. Press **F5** while in Visual Studio to run the application.  
 The browser opens and shows the *Default.aspx* page.

2. Select **Cars** from the product category navigation menu.  

   The *ProductList.aspx* page displays showing only **Cars** category products. Later in this tutorial, you'll display product details.  

    ![Display Data Items and Details - Cars](display_data_items_and_details/_static/image2.png)

3. Select **Products** from the navigation menu at the top.  
 Again, the *ProductList.aspx* page is displayed, however this time it shows the entire list of products.   

    ![Display Data Items and Details - Products](display_data_items_and_details/_static/image3.png)

4. Close the browser and return to Visual Studio.

### Add a data control to display product details

Next, you'll modify the markup in the *ProductDetails.aspx* page that you added in the previous tutorial to display specific product information.

2. Replace the existing markup with this markup:

    [!code-aspx-csharp[Main](display_data_items_and_details/samples/sample5.aspx)] 

    This code uses a **FormView** control to display specific product details. This markup uses methods like the methods used to display data in the *ProductList.aspx* page. The **FormView** control is used to display a single record at a time from a data source. When you use the **FormView** control, you create templates to display and edit data-bound values. These templates contain controls, binding expressions, and formatting that define the form's look and functionality.

Connecting the previous markup to the database requires additional code.

1. In **Solution Explorer**, right-click *ProductDetails.aspx* and then click **View Code**.  
   The *ProductDetails.aspx.cs* file will be displayed.

2. Replace the existing code with this code:   

    [!code-csharp[Main](display_data_items_and_details/samples/sample6.cs)]

This code checks for a "`productID`" query-string value. If a valid query-string value is found, the matching product is displayed. If the query-string isn't found, or its value isn't valid, no product is displayed.

### Run the application

Now you can run the application to see an individual product displayed based on product ID.

1. Press **F5** while in Visual Studio to run the application.  
 The browser opens and shows the *Default.aspx* page.

2. Select **Boats** from the category navigation menu.  
 The *ProductList.aspx* page is displayed.

3. Select **Paper Boat** from the product list.
 The *ProductDetails.aspx* page is displayed.

    ![Display Data Items and Details - Products](display_data_items_and_details/_static/image4.png)
4. Close the browser.


## Additional resources

[Retrieving and displaying data with model binding and web forms](../../presenting-and-managing-data/model-binding/retrieving-data.md)


## Next steps

In this tutorial, you added markup and code to display products and product details. You learned about strongly typed data controls, model binding, and value providers. In the next tutorial, you'll add a shopping cart to the Wingtip Toys sample application.

> [!div class="step-by-step"]
> [Previous](ui_and_navigation.md)
> [Next](shopping-cart.md)
