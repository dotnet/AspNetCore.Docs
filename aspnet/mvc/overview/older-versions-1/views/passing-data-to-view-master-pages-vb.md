---
title: "Passing Data to View Master Pages (VB) | Microsoft Docs"
author: microsoft
description: "The goal of this tutorial is to explain how you can pass data from a controller to a view master page. We examine two strategies for passing data to a view m..."
ms.author: riande
manager: wpickett
ms.date: 10/16/2008
ms.topic: article
ms.assetid: 
ms.technology: dotnet-mvc
ms.prod: .net-framework
msc.legacyurl: /mvc/overview/older-versions-1/views/passing-data-to-view-master-pages-vb
---
Passing Data to View Master Pages (VB)
====================
by [Microsoft](https://github.com/microsoft)

[Download PDF](http://download.microsoft.com/download/e/f/3/ef3f2ff6-7424-48f7-bdaa-180ef64c3490/ASPNET_MVC_Tutorial_13_VB.pdf)

> The goal of this tutorial is to explain how you can pass data from a controller to a view master page. We examine two strategies for passing data to a view master page. First, we discuss an easy solution that results in an application that is difficult to maintain. Next, we examine a much better solution that requires a little more initial work but results in a much more maintainable application.


## Passing Data to View Master Pages

The goal of this tutorial is to explain how you can pass data from a controller to a view master page. We examine two strategies for passing data to a view master page. First, we discuss an easy solution that results in an application that is difficult to maintain. Next, we examine a much better solution that requires a little more initial work but results in a much more maintainable application.

### The Problem

Imagine that you are building a movie database application and you want to display the list of movie categories on every page in your application (see Figure 1). Imagine, furthermore, that the list of movie categories is stored in a database table. In that case, it would make sense to retrieve the categories from the database and render the list of movie categories within a view master page.


[![Displaying movie categories in a view master page](passing-data-to-view-master-pages-vb/_static/image2.png)](passing-data-to-view-master-pages-vb/_static/image1.png)

**Figure 01**: Displaying movie categories in a view master page ([Click to view full-size image](passing-data-to-view-master-pages-vb/_static/image3.png))


Here's the problem. How do you retrieve the list of movie categories in the master page? It is tempting to call methods of your model classes in the master page directly. In other words, it is tempting to include the code for retrieving the data from the database right in your master page. However, bypassing your MVC controllers to access the database would violate the clean separation of concerns that is one of the primary benefits of building an MVC application.

In an MVC application, you want all interaction between your MVC views and your MVC model to be handled by your MVC controllers. This separation of concerns results in a more maintainable, adaptable, and testable application.

In an MVC application, all data passed to a view – including a view master page – should be passed to a view by a controller action. Furthermore, the data should be passed by taking advantage of view data. In the remainder of this tutorial, I examine two methods of passing view data to a view master page.

### The Simple Solution

Let's start with the simplest solution to passing view data from a controller to a view master page. The simplest solution is to pass the view data for the master page in each and every controller action.

Consider the controller in Listing 1. It exposes two actions named `Index()` and `Details()`. The `Index()` action method returns every movie in the Movies database table. The `Details()` action method returns every movie in a particular movie category.

**Listing 1 – `Controllers\HomeController.vb`**

    <HandleError()> _
    Public Class HomeController
         Inherits System.Web.Mvc.Controller
    
         Private _dataContext As New MovieDataContext()
    
         ''' <summary>
    
         ''' Show list of all movies
         ''' </summary>
         Function Index()
              ViewData("categories") = From c In _dataContext.MovieCategories _
                        Select c
              ViewData("movies") = From m In _dataContext.Movies _
                        Select m
              Return View()
         End Function
    
         ''' <summary>
         ''' Show list of movies in a category
         ''' </summary>
    
         Function Details(ByVal id As Integer)
              ViewData("categories") = From c In _dataContext.MovieCategories _
                        Select c
              ViewData("movies") = From m In _dataContext.Movies _
                        Where m.CategoryId = id _
                        Select m
              Return View()
         End Function
    
    End Class

Notice that both the `Index()` and the `Details()` actions add two items to view data. The `Index()` action adds two keys: categories and movies. The categories key represents the list of movie categories displayed by the view master page. The movies key represents the list of movies displayed by the Index view page.

The `Details()` action also adds two keys named categories and movies. The categories key, once again, represents the list of movie categories displayed by the view master page. The movies key represents the list of movies in a particular category displayed by the Details view page (see Figure 2).


[![The Details view](passing-data-to-view-master-pages-vb/_static/image5.png)](passing-data-to-view-master-pages-vb/_static/image4.png)

**Figure 02**: The Details view ([Click to view full-size image](passing-data-to-view-master-pages-vb/_static/image6.png))


The Index view is contained in Listing 2. It simply iterates through the list of movies represented by the movies item in view data.

**Listing 2 – `Views\Home\Index.aspx`**

    <%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="false" CodeBehind="Index.aspx.vb" Inherits="MvcApplication1.Index" %>
    
    <%@ Import Namespace="MvcApplication1" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <ul>
    
    <%  For Each m In ViewData("movies")%>
    
         <li><%= m.Title %></li>
    
    <% Next%>
    </ul>
    
    </asp:Content>

The view master page is contained in Listing 3. The view master page iterates and renders all of the movie categories represented by the categories item from view data.

**Listing 3 – `Views\Shared\Site.master`**

    <%@ Master Language="VB" AutoEventWireup="false" CodeBehind="Site.Master.vb" Inherits="MvcApplication1.Site" %>
    
    <%@ Import Namespace="MvcApplication1" %>
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
    <html xmlns="http://www.w3.org/1999/xhtml" >
    <head id="Head1" runat="server">
    
         <title></title>
         <asp:ContentPlaceHolder ID="head" runat="server">
         </asp:ContentPlaceHolder>
    </head>
    <body>
         <div>
    
              <h1>My Movie Website</h1>
    
              <% For Each c In ViewData("categories")%>
    
                   <%=Html.ActionLink(c.Name, "Details", New With {.id = c.Id})%> 
    
              <% Next%>
    
              <asp:ContentPlaceHolder ID="ContentPlaceHolder1" runat="server">
    
              </asp:ContentPlaceHolder>
         </div>
    </body>
    </html>

All data is passed to the view and the view master page through view data. That is the correct way to pass data to the master page.

So, what's wrong with this solution? The problem is that this solution violates the DRY (Don't Repeat Yourself) principle. Each and every controller action must add the very same list of movie categories to view data. Having duplicate code in your application makes your application much more difficult to maintain, adapt, and modify.

### The Good Solution

In this section, we examine an alternative, and better, solution to passing data from a controller action to a view master page. Instead of adding the movie categories for the master page in each and every controller action, we add the movie categories to the view data only once. All view data used by the view master page is added in an Application controller.

The ApplicationController class is contained in Listing 4.

The ApplicationController class is contained in Listing 4.

**Listing 4 – `Controllers\ApplicationController.vb`**

    Public MustInherit Class ApplicationController
         Inherits System.Web.Mvc.Controller
    
         Private _dataContext As New MovieDataContext()
    
         Public ReadOnly Property DataContext() As MovieDataContext
              Get
    
                   Return _dataContext
              End Get
         End Property
    
         Sub New()
              ViewData("categories") = From c In DataContext.MovieCategories _
                        Select c
         End Sub
    
    End Class

There are three things that you should notice about the Application controller in Listing 4. First, notice that the class inherits from the base System.Web.Mvc.Controller class. The Application controller is a controller class.

Second, notice that the Application controller class is a MustInherit class. An MustInherit class is a class that must be implemented by a concrete class. Because the Application controller is an MustInherit class, you cannot not invoke any methods defined in the class directly. If you attempt to invoke the Application class directly then you'll get a Resource Cannot Be Found error message.

Third, notice that the Application controller contains a constructor that adds the list of movie categories to view data. Every controller class that inherits from the Application controller calls the Application controller's constructor automatically. Whenever you call any action on any controller that inherits from the Application controller, the movie categories is included in the view data automatically.

The Movies controller in Listing 5 inherits from the Application controller.

**Listing 5 – `Controllers\MoviesController.vb`**

    <HandleError()> _
    Public Class MoviesController
         Inherits ApplicationController
    
         ''' <summary>
         ''' Show list of all movies
         ''' </summary>
         Function Index()
              ViewData("movies") = From m In DataContext.Movies _
                        Select m
              Return View()
    
          End Function
    
         ''' <summary>
         ''' Show list of movies in a category
         ''' </summary>
         Function Details(ByVal id As Integer)
              ViewData("movies") = From m In DataContext.Movies _
                        Where m.CategoryId = id _
                        Select m
              Return View()
         End Function
    
    End Class

The Movies controller, just like the Home controller discussed in the previous section, exposes two action methods named `Index()` and `Details()`. Notice that the list of movie categories displayed by the view master page is not added to view data in either the `Index()` or `Details()` method. Because the Movies controller inherits from the Application controller, the list of movie categories is added to view data automatically.

Notice that this solution to adding view data for a view master page does not violate the DRY (Don't Repeat Yourself) principle. The code for adding the list of movie categories to view data is contained in only one location: the constructor for the Application controller.

### Summary

In this tutorial, we discussed two approaches to passing view data from a controller to a view master page. First, we examined a simple, but difficult to maintain approach. In the first section, we discussed how you can add view data for a view master page in each every controller action in your application. We concluded that this was a bad approach because it violates the DRY (Don't Repeat Yourself) principle.

Next, we examined a much better strategy for adding data required by a view master page to view data. Instead of adding the view data in each and every controller action, we added the view data only once within an Application controller. That way, you can avoid duplicate code when passing data to a view master page in an ASP.NET MVC application.

>[!div class="step-by-step"] [Previous](creating-page-layouts-with-view-master-pages-vb.md)