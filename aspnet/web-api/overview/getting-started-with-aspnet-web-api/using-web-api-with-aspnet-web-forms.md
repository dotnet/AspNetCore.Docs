---
title: "Using Web API with ASP.NET Web Forms | Microsoft Docs"
author: MikeWasson
description: ""
ms.author: riande
manager: wpickett
ms.date: 04/03/2012
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/getting-started-with-aspnet-web-api/using-web-api-with-aspnet-web-forms
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\web-api\overview\getting-started-with-aspnet-web-api\using-web-api-with-aspnet-web-forms.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/37851) | [View dev content](http://docs.aspdev.net/tutorials/web-api/overview/getting-started-with-aspnet-web-api/using-web-api-with-aspnet-web-forms.html) | [View prod content](http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/using-web-api-with-aspnet-web-forms) | Picker: 37852

Using Web API with ASP.NET Web Forms
====================
by [Mike Wasson](https://github.com/MikeWasson)

Although ASP.NET Web API is packaged with ASP.NET MVC, it is easy to add Web API to a traditional ASP.NET Web Forms application. This tutorial walks you through the steps.

## Overview

To use Web API in a Web Forms application, there are two main steps:

- Add a Web API controller that derives from the **ApiController** class.
- Add a route table to the **Application\_Start** method.

## Create a Web Forms Project

Start Visual Studio and select **New Project** from the **Start** page. Or, from the **File** menu, select **New** and then **Project**.

In the **Templates** pane, select **Installed Templates** and expand the **Visual C#** node. Under **Visual C#**, select **Web**. In the list of project templates, select **ASP.NET Web Forms Application**. Enter a name for the project and click **OK**.

![](using-web-api-with-aspnet-web-forms/_static/image1.png)

## Create the Model and Controller

This tutorial uses the same model and controller classes as the [Getting Started](tutorial-your-first-web-api.md) tutorial.

First, add a model class. In **Solution Explorer**, right-click the project and select **Add Class**. Name the class Product, and add the following implementation:

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }

Next, add a Web API controller to the project., A *controller* is the object that handles HTTP requests for Web API.

In **Solution Explorer**, right-click the project. Select **Add New Item**.

![](using-web-api-with-aspnet-web-forms/_static/image2.png)

Under **Installed Templates**, expand **Visual C#** and select **Web**. Then, from the list of templates, select **Web API Controller Class**. Name the controller "ProductsController" and click **Add**.

![](using-web-api-with-aspnet-web-forms/_static/image3.png)

The **Add New Item** wizard will create a file named ProductsController.cs. Delete the methods that the wizard included and add the following methods:

    namespace WebForms
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Net;
        using System.Net.Http;
        using System.Web.Http;
    
        public class ProductsController : ApiController
        {
    
            Product[] products = new Product[] 
            { 
                new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
                new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
                new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
            };
    
            public IEnumerable<Product> GetAllProducts()
            {
                return products;
            }
    
            public Product GetProductById(int id)
            {
                var product = products.FirstOrDefault((p) => p.Id == id);
                if (product == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                return product;
            }
    
            public IEnumerable<Product> GetProductsByCategory(string category)
            {
                return products.Where(
                    (p) => string.Equals(p.Category, category,
                        StringComparison.OrdinalIgnoreCase));
            }
        }
    }

For more information about the code in this controller, see the [Getting Started](tutorial-your-first-web-api.md) tutorial.

## Add Routing Information

Next, we'll add a URI route so that URIs of the form &quot;/api/products/&quot; are routed to the controller.

In **Solution Explorer**, double-click Global.asax to open the code-behind file Global.asax.cs. Add the following **using** statement.

    using System.Web.Http;

Then add the following code to the **Application\_Start** method:

    RouteTable.Routes.MapHttpRoute(
        name: "DefaultApi",
        routeTemplate: "api/{controller}/{id}",
        defaults: new { id = System.Web.Http.RouteParameter.Optional }
        );

For more information about routing tables, see [Routing in ASP.NET Web API](../web-api-routing-and-actions/routing-in-aspnet-web-api.md).

## Add Client-Side AJAX

That's all you need to create a web API that clients can access. Now let's add an HTML page that uses jQuery to call the API.

Open the file Default.aspx. Replace the boilerplate text that is in the main content section, as shown:

    <%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" 
        AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForms._Default" %>
    
    <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
    
    <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <h2>Products</h2>
        <table>
        <thead>
            <tr><th>Name</th><th>Price</th></tr>
        </thead>
        <tbody id="products">
        </tbody>
        </table>
    </asp:Content>

Next, add a reference to the jQuery source file in the `HeaderContent` section:

[!code[Main](using-web-api-with-aspnet-web-forms/samples/sample1.xml?highlight=2)]

Note: You can easily add the script reference by dragging and dropping the file from **Solution Explorer** into the code editor window.

![](using-web-api-with-aspnet-web-forms/_static/image4.png)

Below the jQuery script tag, add the following script block:

    <script type="text/javascript">
        function getProducts() {
            $.getJSON("api/products",
                function (data) {
                    $('#products').empty(); // Clear the table body.
    
                    // Loop through the list of products.
                    $.each(data, function (key, val) {
                        // Add a table row for the product.
                        var row = '<td>' + val.Name + '</td><td>' + val.Price + '</td>';
                        $('<tr/>', { text: row })  // Append the name.
                            .appendTo($('#products'));
                    });
                });
            }
    
            $(document).ready(getProducts);
    </script>

When the document loads, this script makes an AJAX request to &quot;api/products&quot;. The request returns a list of products in JSON format. The script adds the product information to the HTML table.

When you run the application, it should look like this:

![](using-web-api-with-aspnet-web-forms/_static/image5.png)