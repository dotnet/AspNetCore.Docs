---
uid: single-page-application/overview/templates/breezeknockout-template
title: "Breeze/Knockout template | Microsoft Docs"
author: madskristensen
description: "Breeze/Knockout Single Page Application template"
ms.author: aspnetcontent
manager: wpickett
ms.date: 01/30/2013
ms.topic: article
ms.assetid: 3bd94827-3c59-448f-abc3-36e6df4858db
ms.technology: 
ms.prod: .net-framework
msc.legacyurl: /single-page-application/overview/templates/breezeknockout-template
msc.type: authoredcontent
---
Breeze/Knockout template
====================
by [Mads Kristensen](https://github.com/madskristensen)

> The Breeze/Knockout MVC Template was written by Ward Bell
> 
> [Download the Breeze/Knockout MVC Template](https://go.microsoft.com/fwlink/?LinkId=282649)


You've heard of "single page application" (SPA) and wondered what it is. While you could read about it, you'd rather experience it for yourself. But who has time to download a sample? If you've got Visual Studio, you'll have an example SPA up and running in less than 60 seconds with the ASP.NET MVC 4 "Breeze/Knockout Single Page Application" template.

![](http://www.breezejs.com/sites/all/images/spa-template/ZephyrRunning.png)

## What is the Breeze/Knockout SPA Template?

Most project templates generate an application skeleton. You put flesh on those bones by adding your code and eventually deliver a working application. The Breeze/Knockout SPA template is different. It generates a sample application for you to study. It demonstrates a SPA application design and many of the techniques for building a SPA.

The Breeze/Knockout template is a variation on the [KnockoutJS SPA template](../introduction/knockoutjs-template.md) included in the ASP.NET and Web Tools 2012.2 Update. The Breeze SPA template generates an application with the same user experience, but it has a different implementation, using Breeze for data management.

The KnockoutJS SPA template makes service requests with raw jQuery AJAX, which is adequate for a simple application. But more sophisticated apps have more demanding data management requirements. For example, most applications:

- Query and re-query the server during an extended user session.
- Add query filters, sorting, and paging.
- Share the same data across multiple screens.
- Accumulate changes to many objects, then save them as a single transaction.
- Validate changes on the client, so the user can correct mistakes before committing changes to the database.

The BreezeJS library handles these chores for you, freeing you to develop the application logic and user experience that matter most.

[**Breeze**](http://www.breezejs.com/?utm_source=ms-spa) is an open source library for building rich data applications in JavaScript and HTML, the kinds of apps that have historically been delivered as stand-alone desktop applications.

The Breeze/Knockout template helps you take that first crucial step toward a more robust data management infrastructure. It produces a sample Todo application that is outwardly identical to the KnockoutJS SPA template. On the inside, it replaces the AJAX data layer with Breeze, so you can compare the two approaches side-by-side. Of course, it barely touches the potential of a Breeze application. But you'll see how Breeze works and how little is required to make that transition.

Let's get started.

## Create a Breeze/Knockout Template Project

Download and install the template by clicking the Download button above. The template is packaged as a Visual Studio Extension (VSIX) file. You might need to restart Visual Studio.

In the **Templates** pane, select **Installed Templates** and expand the **Visual C#** node. Under **Visual C#**, select **Web**. In the list of project templates, select **ASP.NET MVC 4 Web Application**. Name the project and click **OK**.

In the **New Project** wizard, select **Breeze Knockout SPA**.

![](http://www.breezejs.com/sites/all/images/spa-template/SelectBreezeKOSpaTemplate.png)

Press Ctrl-F5 to build and run the application without debugging, or press F5 to run with debugging.

![](http://www.breezejs.com/sites/all/images/spa-template/ZephyrRunning.png)

When the application first runs, it displays a login screen. Click the "Sign up" link and a new page glides into view, where you can enter a username and password. (The login and registration pages are built using ASP.NET MVC.) When you submit the registration form, the server generates a TodoList with two items for your account. Then it presents them to you on a yellow note.

![](http://www.breezejs.com/sites/all/images/spa-template/TodoList.png)

Now you are in the land of SPA. Everything you see and experience while manipulating Todos is rendered and managed on the client with the help of Knockout and Breeze. Explore the app as a user … but with a developer's eye. Use the developer tools in your browser to capture the network traffic. (In Internet Explorer: Press F12, select the **Network** tab, and click **Start capturing**.) Now try the following:

- Add a new Todo item.
- Click the label and edit the Todo item title
- Check a checkbox to mark the item done. Notice that the textbox is disabled, so the title is no longer editable.
- Click the ‘x' to the right of the label. The item disappears and is deleted from the database.
- Pick another item and clear its title. You'll get a validation error that the title is required. After a brief pause, the previous title is restored.
- Type in a ridiculously long title. You'll get a different validation error that the title is too long.
- Click the "Add Todo List" button. A new list appears to the left of the previous list.
- Play with the TodoList title, triggering its required and length validations.
- Click in the title textbox to clear the error message.
- Click the "x" in the circle in the upper right corner to delete the TodoList and its todos.

The validation logic is performed client-side by Breeze. Validation attributes on the server model classes are propagated to the client and executed automatically before the client contacts the server.

Review the network traffic. Notice that there were no calls to the server when Breeze detected an error. Each valid change resulted in a POST request to "/api/Todo/SaveChanges". Breeze bundles the changes and sends them together as a single request to the Web API controller's `SaveChanges` method. That's different from KockoutJS SPA template, which makes PUT, POST, and DELETE requests for each item individually.

## Peek inside

This application has a client side and a server side. The client-side stack consists of a little HTML and a combination of application JavaScript modules (in the "app" folder) plus third-party JavaScript libraries (in the "Scripts" folder).

![](http://www.breezejs.com/sites/all/images/spa-template/ClientArchitecture.png)

If you've investigated the KnockoutJS SPA template, this should look very familiar. Focus on the blue boxes. The UI architecture is Model-View-ViewModel (MVVM), in which the HTML widgets of the view are cleanly separated from the supporting presentation code in the view-model. A data binding system (Knockout in this case) coordinates the view and view-model so that each can do its job without intimate knowledge of the other.

The model encapsulates the Todo data. Entities in the model are constructed by Breeze with Knockout observable properties, so they can be bound directly to widgets in the view. The view-model asks the data context to acquire and save the model entities. The data context delegates most of the work to Breeze.

The server-side stack consists of some developer code and three principle .NET libraries: Web API, Entity Framework, and Breeze.NET:

![](http://www.breezejs.com/sites/all/images/spa-template/ServerArchitecture.png)

The basic architecture is the same as the KockoutJS SPA template. However, the implementation is much simpler: The DTOs were deleted, and most of the Entity Framework details have been delegated to Breeze.NET.

## Next Steps

We suggest that you explore the code, guided by the [extensive discussion](http://www.breezejs.com/spa-template?utm_source=ms-spa) of both the client and the server stacks on the Breeze website.

You might try playing with Breeze client-side query; add some filters and sorts. You might add more model properties and more entities to get a better feel for end-to-end SPA development. When you are confident of the design, you can tear out the Todo features and replace them with your own.

Soon you'll be ready for the next big step: Adding client-side screens and navigating among them. You'll leave this SPA template behind and turn to a more complete SPA stack, such as [John Papa's Hot Towel](https://github.com/johnpapa/HotTowel#readme "Hot Towel"), which adds Durandal to the Breeze and Knockout mix.