---
uid: web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/display_data_items_and_details
title: "Display Data Items and Details | Microsoft Docs"
author: Erikre
description: "This tutorial series will teach you the basics of building an ASP.NET Web Forms application using ASP.NET 4.7 and Microsoft Visual Studio Community 2017 for We..."
ms.author: riande
ms.date: 1/08/2019
ms.assetid: 64a491a8-0ed6-4c2f-9c1c-412962eb6006
msc.legacyurl: /web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/display_data_items_and_details
msc.type: authoredcontent
---
Display data items and details
====================
by [Erik Reitan](https://github.com/Erikre)

[Download Wingtip Toys Sample Project (C#)](http://go.microsoft.com/fwlink/?LinkID=389434&clcid=0x409) or [Download E-book (PDF)](http://download.microsoft.com/download/0/F/B/0FBFAA46-2BFD-478F-8E56-7BF3C672DF9D/Getting%20Started%20with%20ASP.NET%204.5%20Web%20Forms%20and%20Visual%20Studio%202013.pdf)

> This tutorial series will teach you the basics of building an ASP.NET Web Forms application using ASP.NET 4.7 and Microsoft Visual Studio Community 2017 for Web. A Visual Studio [project with C# source code](https://go.microsoft.com/fwlink/?LinkID=389434&clcid=0x409) is available to accompany this tutorial series.

In this tutorial, you'll learn how to display data items and data item details using ASP.NET Web Forms and Entity Framework Code First. This tutorial builds on the previous "UI and Navigation" tutorial as part of the Wingtip Toy Store tutorial series. After completing this tutorial, you'll see products on the *ProductsList.aspx* page and a product's details on the *ProductDetails.aspx* page.

## You'll learn how to:

- Add a data control to display database products
- Connect a data control to selected data
- Add a data control to display product details
- Parse a query string value and use it to filter retrieved database data

### Features introduced in this tutorial:

- Model binding
- Value providers

## Add a data control to display products

You have a few options to bind data to a server control. The most common include:

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

### Use model binding to bind data

Model binding lets you bind results using far less code and gives you the ability to reuse the functionality throughout your application. It simplifies working with code-focused data-access logic while still providing a rich, data-binding framework.

## Display products

In this tutorial, you'll use model binding to bind data. To configure a data control to use model binding to select data, you set the control's `SelectMethod` property to a method in the page's code. The data control calls the method at the appropriate time in the page life cycle and automatically binds the returned data. There's no need to explicitly call the `DataBind` method.

Using the steps below, you'll modify *ProductList.aspx* markup to display products.

1. In **Solution Explorer**, open *ProductList.aspx*.

2. Replace the existing markup with this markup:   

    [!code-aspx-csharp[Main](display_data_items_and_details/samples/sample1.aspx)]

This markup uses a **ListView** control named `productList` to display  products.

[!code-aspx-csharp[Main](display_data_items_and_details/samples/sample2.aspx)]

Using templates and styles, you define how the **ListView** control displays data. It's useful for data in any repeating structure. Though this **ListView** example simply displays database data, you can also, without code, enable users to edit, insert, and delete data, and to sort and page data.

By setting the `ItemType` property in the **ListView** control, the data-binding expression `Item` is available and the control becomes strongly typed. As mentioned in the previous tutorial, you can select Item object details using IntelliSense, such as specifying the `ProductName`:

![Display Data Items and Details - IntelliSense](display_data_items_and_details/_static/image1.png)

You're also using model binding to specify a `SelectMethod` value. This value (`GetProducts`) corresponds to the method you'll add to the code behind to display products in the next step.

### Add code to display products

In this step, you'll add code to populate the **ListView** control with database product data. The code supports showing all products and individual category products.

1. In **Solution Explorer**, right-click *ProductList.aspx* and then select **View Code**.
2. Replace the existing code in the *ProductList.aspx.cs* file with this:   

    [!code-csharp[Main](display_data_items_and_details/samples/sample3.cs)]

This code shows the `GetProducts` method that the **ListView** control's `ItemType` property references in *ProductList.aspx*. To limit the results to a specific database category, the code sets the `categoryId` value from the query string passed to  *ProductList.aspx*. The `QueryStringAttribute` class in the `System.Web.ModelBinding` namespace is used to retrieve the query string variable `id`'s value. This instructs model binding to, at run time, bind a query string value to the `categoryId` parameter.

When a valid category (`categoryId`) is passed, the results are limited to that category's database products. For instance, if the *ProductsList.aspx* page URL is this:

[!code-console[Main](display_data_items_and_details/samples/sample4.cmd)]

The page displays only the products where the `categoryId` equals `1`.

All products are displayed if no query string is passed.

The value sources for these methods are called *value providers* (such as `QueryString`), and the parameter attributes that indicate which value provider to use are called *value provider attributes* (such as `id`). ASP.NET includes value providers and attributes for all typical Web Forms application user input sources. These include the query string, cookies, form values, controls, view state, session state, and profile properties. You can also write custom value providers.

### Run the application

Run the application now to view all products or a category's products.

1. In Visual Studio, press **F5** to run the application.  
 The browser opens and shows the *Default.aspx* page.

2. From the product category menu, select **Cars**.  

   The *ProductList.aspx* page displays showing only **Cars** category products. Later in this tutorial, you'll display product details.  

    ![Display Data Items and Details - Cars](display_data_items_and_details/_static/image2.png)

3. Select **Products** from the top menu.  
 Again, the *ProductList.aspx* page is displayed, however, this time, it shows all products.   

    ![Display Data Items and Details - Products](display_data_items_and_details/_static/image3.png)

4. Close the browser and return to Visual Studio.

### Add a Data Control to display product details

Next, you'll modify the *ProductDetails.aspx* markup that you added in the previous tutorial to display specific product information.

1. In **Solution Explorer**, open *ProductDetails.aspx*.

2. Replace the existing markup with this markup:   

    [!code-aspx-csharp[Main](display_data_items_and_details/samples/sample5.aspx)]

This markup uses a **FormView** control to display specific product details. It uses methods like those used to display data in *ProductList.aspx*. The **FormView** control is used to display a single record at a time from a data source. When you use the **FormView** control, you create templates to display and edit data-bound values. These templates contain controls, binding expressions, and formatting that define the form's look and functionality.

Connecting the above markup to the database requires additional code.

1. In **Solution Explorer**, right-click *ProductDetails.aspx* and then select **View Code**.  
   The *ProductDetails.aspx.cs* file is displayed.

2. Replace the existing code with this:   

    [!code-csharp[Main](display_data_items_and_details/samples/sample6.cs)]

This code checks for a "`productID`" query string value. If a valid value is found, the matching product is displayed. If the query string isn't found, or its value isn't valid, no product is displayed.

### Run the application

Now you can run the application to see specific product details based on product ID.

1. In Visual Studio, press **F5** to run the application.  
 The browser opens to *Default.aspx*.

2. From the category menu, select **Boats**.  
 The *ProductList.aspx* page is displayed.

3. Select **Paper Boat**.  
 The *ProductDetails.aspx* page is displayed.   

    ![Display Data Items and Details - Products](display_data_items_and_details/_static/image4.png)
4. Close the browser.

## Summary

In this series tutorial, you added markup and code to display products and  product details. During this, you learned about strongly typed data controls, model binding, and value providers. In the next tutorial, you'll add a shopping cart to the Wingtip Toys  application.

## Additional resources

[Retrieving and displaying data with model binding and web forms](../../presenting-and-managing-data/model-binding/retrieving-data.md)

> [!div class="step-by-step"]
> [Previous](ui_and_navigation.md)
> [Next](shopping-cart.md)
