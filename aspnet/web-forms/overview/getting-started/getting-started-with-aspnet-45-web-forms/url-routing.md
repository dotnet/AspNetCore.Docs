---
uid: web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/url-routing
title: "URL Routing | Microsoft Docs"
author: Erikre
description: "This tutorial series will teach you the basics of building an ASP.NET Web Forms application using ASP.NET 4.5 and Microsoft Visual Studio Express 2013 for We..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 09/08/2014
ms.topic: article
ms.assetid: 4f4bf092-c400-471f-a876-78fda0417890
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/url-routing
msc.type: authoredcontent
---
URL Routing
====================
by [Erik Reitan](https://github.com/Erikre)

[Download Wingtip Toys Sample Project (C#)](http://go.microsoft.com/fwlink/?LinkID=389434&clcid=0x409) or [Download E-book (PDF)](http://download.microsoft.com/download/0/F/B/0FBFAA46-2BFD-478F-8E56-7BF3C672DF9D/Getting%20Started%20with%20ASP.NET%204.5%20Web%20Forms%20and%20Visual%20Studio%202013.pdf)

> This tutorial series will teach you the basics of building an ASP.NET Web Forms application using ASP.NET 4.5 and Microsoft Visual Studio Express 2013 for Web. A Visual Studio 2013 [project with C# source code](https://go.microsoft.com/fwlink/?LinkID=389434&clcid=0x409) is available to accompany this tutorial series.


In this tutorial, you will modify the Wingtip Toys sample application to support URL routing. Routing enables your web application to use URLs that are friendly, easier to remember, and better supported by search engines. This tutorial builds on the previous tutorial "Membership and Administration" and is part of the Wingtip Toys tutorial series.

## What you'll learn:

- How to register routes for an ASP.NET Web Forms application.
- How to add routes to a web page.
- How to select data from a database to support routes.

## ASP.NET Routing Overview

URL routing allows you to configure an application to accept request URLs that do not map to physical files. A request URL is simply the URL a user enters into their browser to find a page on your web site. You use routing to define URLs that are semantically meaningful to users and that can help with search-engine optimization (SEO).

By default, the Web Forms template includes [ASP.NET Friendly URLs](http://www.nuget.org/packages/Microsoft.AspNet.FriendlyUrls/). Much of the basic routing work will be implemented by using *Friendly URLs*. However, in this tutorial you will add customized routing capabilities.

Before customizing URL routing, the Wingtip Toys sample application can link to a product using the following URL:

`https://localhost:44300/ProductDetails.aspx?productID=2`

By customizing URL routing, the Wingtip Toys sample application will link to the same product using an easier to read URL:

`https://localhost:44300/Product/Convertible%20Car`

### Routes

A route is a URL pattern that is mapped to a handler. The handler can be a physical file, such as an .aspx file in a Web Forms application. A handler can also be a class that processes the request. To define a route, you create an instance of the Route class by specifying the URL pattern, the handler, and optionally a name for the route.

You add the route to the application by adding the `Route` object to the static `Routes` property of the `RouteTable` class. The Routes property is a `RouteCollection` object that stores all the routes for the application.

### URL Patterns

A URL pattern can contain literal values and variable placeholders (referred to as URL parameters). The literals and placeholders are located in segments of the URL which are delimited by the slash (`/`) character.

When a request to your web application is made, the URL is parsed into segments and placeholders, and the variable values are provided to the request handler. This process is similar to the way the data in a query string is parsed and passed to the request handler. In both cases, variable information is included in the URL and passed to the handler in the form of key-value pairs. For query strings, both the keys and the values are in the URL. For routes, the keys are the placeholder names defined in the URL pattern, and only the values are in the URL.

In a URL pattern, you define placeholders by enclosing them in braces ( `{` and `}` ). You can define more than one placeholder in a segment, but the placeholders must be separated by a literal value. For example, `{language}-{country}/{action}` is a valid route pattern. However, `{language}{country}/{action}` is not a valid pattern, because there is no literal value or delimiter between the placeholders. Therefore, routing cannot determine where to separate the value for the language placeholder from the value for the country placeholder.

### Mapping and Registering Routes

Before you can include routes to pages of the Wingtip Toys sample application, you must register the routes when the application starts. To register the routes, you will modify the `Application_Start` event handler.

1. In **Solution Explorer**of Visual Studio, find and open the *Global.asax.cs* file.
2. Add the code highlighted in yellow to the *Global.asax.cs* file as follows:   

    [!code-csharp[Main](url-routing/samples/sample1.cs?highlight=30-31,34-46)]

When the Wingtip Toys sample application starts, it calls the `Application_Start` event handler. At the end of this event handler, the `RegisterCustomRoutes` method is called. The `RegisterCustomRoutes` method adds each route by calling the `MapPageRoute` method of the `RouteCollection` object. Routes are defined using a route name, a route URL and a physical URL.

The first parameter ("`ProductsByCategoryRoute`") is the route name. It is used to call the route when it is needed. The second parameter ("`Category/{categoryName}`") defines the friendly replacement URL that can be dynamic based on code. You use this route when you are populating a data control with links that are generated based on data. A route is shown as follows:

[!code-csharp[Main](url-routing/samples/sample2.cs)]

The second parameter of the route includes a dynamic value specified by braces (`{ }`). In this case, the `categoryName` is a variable that will be used to determine the proper routing path.

> [!NOTE] 
> 
> **Optional**
> 
> You might find it easier to manage your code by moving the `RegisterCustomRoutes` method to a separate class. In the *Logic* folder, create a separate `RouteActions` class. Move the above `RegisterCustomRoutes` method from the *Global.asax.cs* file into the new `RoutesActions` class. Use the `RoleActions` class and the `createAdmin` method as an example of how to call the `RegisterCustomRoutes` method from the *Global.asax.cs* file.


You may also have noticed the `RegisterRoutes` method call using the `RouteConfig` object at the beginning of the `Application_Start` event handler. This call is made to implement default routing. It was included as default code when you created the application using Visual Studio's Web Forms template.

## Retrieving and Using Route Data

As mentioned above, routes can be defined. The code that you added to the `Application_Start` event handler in the *Global.asax.cs* file loads the definable routes.

### Setting Routes

Routes require you to add additional code. In this tutorial, you will use model binding to retrieve a `RouteValueDictionary` object that is used when generating the routes using data from a data control. The `RouteValueDictionary` object will contain a list of product names that belong to a specific category of products. A link is created for each product based on the data and route.

#### Enable Routes for Categories and Products

Next, you'll update the application to use the `ProductsByCategoryRoute` to determine the correct route to include for each product category link. You'll also update the *ProductList.aspx* page to include a routed link for each product. The links will be displayed as they were before the change, however the links will now use URL routing.

1. In **Solution Explorer**, open the *Site.Master* page if it is not already open.
2. Update the **ListView** control named "`categoryList`" with the changes highlighted in yellow, so the markup appears as follows:   

    [!code-aspx[Main](url-routing/samples/sample3.aspx?highlight=7-9)]
3. In **Solution Explorer**, open the *ProductList.aspx* page.
4. Update the `ItemTemplate` element of the *ProductList.aspx* page with the updates highlighted in yellow, so the markup appears as follows:   

    [!code-aspx[Main](url-routing/samples/sample4.aspx?highlight=6-9,14-16)]
5. Open the code-behind of *ProductList.aspx.cs* and add the following namespace as highlighted in yellow:  

    [!code-csharp[Main](url-routing/samples/sample5.cs?highlight=9)]
6. Replace the `GetProducts` method of the code-behind (*ProductList.aspx.cs*) with the following code:   

    [!code-csharp[Main](url-routing/samples/sample6.cs)]

#### Add Code for Product Details

Now, update the code-behind (*ProductDetails.aspx.cs*) for the *ProductDetails.aspx* page to use route data. Notice that the new `GetProduct` method also accepts a query string value for the case where the user has a link bookmarked that uses the older non-friendly, non-routed URL.

1. Replace the `GetProduct` method of the code-behind (*ProductDetails.aspx.cs*) with the following code:   

    [!code-csharp[Main](url-routing/samples/sample7.cs)]

## Running the Application

You can run the application now to see the updated routes.

1. Press **F5** to run the Wingtip Toys sample application.  
 The browser opens and shows the *Default.aspx* page.
2. Click the **Products** link at the top of the page.  
 All products are displayed on the *ProductList.aspx* page. The following URL (using your port number) is displayed for the browser:  
    `https://localhost:44300/ProductList`
3. Next, click the **Cars** category link near the top of the page.  
 Only cars are displayed on the *ProductList.aspx* page. The following URL (using your port number) is displayed for the browser:  
    `https://localhost:44300/Category/Cars`
4. Click the link containing the name of the first car listed on the page ("**Convertible Car**") to display the product details.  
 The following URL (using your port number) is displayed for the browser:  
    `https://localhost:44300/Product/Convertible%20Car`
5. Next, enter the following non-routed URL (using your port number) into the browser:  
    `https://localhost:44300/ProductDetails.aspx?productID=2`  
 The code still recognizes a URL that includes a query string, for the case where a user has a link bookmarked.

## Summary

In this tutorial, you have added routes for categories and products. You have learned how routes can be integrated with data controls that use model binding. In the next tutorial, you will implement global error handling.

## Additional Resources

[ASP.NET Friendly URLs](http://www.nuget.org/packages/Microsoft.AspNet.FriendlyUrls/)  
[Deploy a Secure ASP.NET Web Forms App with Membership, OAuth, and SQL Database to Azure App Service](https://azure.microsoft.com/documentation/articles/web-sites-dotnet-deploy-aspnet-webforms-app-membership-oauth-sql-database/)  
[Microsoft Azure - Free Trial](https://azure.microsoft.com/pricing/free-trial/)

>[!div class="step-by-step"]
[Previous](membership-and-administration.md)
[Next](aspnet-error-handling.md)