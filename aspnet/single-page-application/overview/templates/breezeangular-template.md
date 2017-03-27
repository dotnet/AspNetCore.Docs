---
uid: single-page-application/overview/templates/breezeangular-template
title: "Breeze/Angular template | Microsoft Docs"
author: madskristensen
description: "Breeze/Angular Single Page Application template"
ms.author: aspnetcontent
manager: wpickett
ms.date: 03/08/2013
ms.topic: article
ms.assetid: db31e909-563a-4516-aadd-62aa210ac7e4
ms.technology: 
ms.prod: .net-framework
msc.legacyurl: /single-page-application/overview/templates/breezeangular-template
msc.type: authoredcontent
---
Breeze/Angular template
====================
by [Mads Kristensen](https://github.com/madskristensen)

> The Breeze/Angular MVC Template was written by Ward Bell
> 
> [Download the Breeze/Angular MVC Template](https://go.microsoft.com/fwlink/?LinkId=286437)


[AngularJS](http://angularjs.org) is an open source library from Google for building Single Page Applications (SPAs). It offers data binding, dependency injection, and screen management. Combine it with [BreezeJS](http://www.breezejs.com/?utm_source=ms-spa), another open source library for data modeling and data management, and you have the essential ingredients for a great HTML/JavaScript client app.

The Breeze/Angular SPA template is a variation on the [KnockoutJS SPA template](../introduction/knockoutjs-template.md) included in the ASP.NET and Web Tools 2012.2 Update. If you've got Visual Studio, you'll have an example SPA up and running in less than 60 seconds.

![](http://www.breezejs.com/sites/all/images/spa-template/NgRunningTodoPage.png)

Outwardly, the application looks the very similar to the KnockoutJS SPA template. But it's quite different under the hood. The KnockoutJS template uses Knockout for data binding and raw AJAX for data access. The Breeze/Angular template uses Angular for data binding and Breeze for data access. These libaries enable additional capabilities, including page navigation and history.

Here is the application's About page:

![](http://www.breezejs.com/sites/all/images/spa-template/NgRunningAboutPage.png)

This page displays a running log of events during the current user session, including:

- Paging. Note the Todo controller creation at #2 and #7.
- Remote queries (#3) and local cache queries (#7).
- Saving new (#5, #6) and modified (#4) entities.
- Changes validated on the client (#9), so the user can correct mistakes before committing changes to the database.

There's more to explore in this template, including:

- Dynamic loading of HTML view templates.
- Custom data binding through Angular "directives."
- Modularity and dependency injection.
- Query filters, sorts, paging, projections, and inclusion of related entities.
- Sharing data across multiple screens.
- Saving multiple changes as a single transaction.
- Validation rules propagated automatically from the server to the JavaScript client.

Let's get started.

## Create a Breeze/Angular Template Project

Download and install the template by clicking the Download button above. The template is packaged as a Visual Studio Extension (VSIX) file. You might need to restart Visual Studio.

In the **Templates** pane, select **Installed Templates** and expand the **Visual C#** node. Under **Visual C#**, select **Web**. In the list of project templates, select **ASP.NET MVC 4 Web Application**. Name the project and click **OK**.

In the **New Project** wizard, select **Breeze Angular SPA**.

![](http://www.breezejs.com/sites/all/images/spa-template/SelectBreezeNgSpaTemplate.png)

Press Ctrl-F5 to build and run the application without debugging, or press F5 to run with debugging.

![](http://www.breezejs.com/sites/all/images/spa-template/ZephyrLogin.png)

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
- Click the "About" link in the upper right to see a log of these activities.

The validation logic is performed client-side by Breeze. Validation attributes on the server model classes are propagated to the client and executed automatically before the client contacts the server.

Review the network traffic. Notice that there were no calls to the server when Breeze detected an error. Each valid change resulted in a POST request to "/api/Todo/SaveChanges". Breeze bundles the changes and sends them together as a single request to the Web API controller's `SaveChanges` method. That's different from KockoutJS SPA template, which makes PUT, POST, and DELETE requests for each item individually.

Also, notice there is no network traffic when you switch between the TodoList and About pages. That's because the query has been constrained to the local Breeze cache.

## Peek inside

This application has a client side and a server side. The client-side stack consists of a little HTML and a combination of application JavaScript modules (in the "app" folder) plus third-party JavaScript libraries (in the "Scripts" folder).

![](http://www.breezejs.com/sites/all/images/spa-template/NgClientArchitecture2.png)

The UI architecture separates the HTML widgets of the views from the supporting presentation code in the controllers. The Angular data-binding system coordinates views and controllers so that each can do its job without intimate knowledge of the other.

The controller asks the data context to acquire and save the model entities. The data context delegates most of the work to Breeze, which constructs self-tracking model objects from JSON query results.

The server-side stack consists of some developer code and three principle .NET libraries: Web API, Entity Framework, and Breeze.NET:

![](http://www.breezejs.com/sites/all/images/spa-template/ServerArchitecture.png)

The basic architecture is the same as the KockoutJS SPA template. However, the implementation is much simpler: The DTOs were deleted, and most of the Entity Framework details have been delegated to Breeze.NET.

## Next Steps

We suggest that you explore the code, guided by the [extensive discussion](http://www.breezejs.com/ng-spa-template?utm_source=ms-spa) of both the client and the server stacks on the Breeze website.

You might try playing with Breeze client-side query; add some filters and sorts. You might add more model properties and more entities to get a better feel for end-to-end SPA development. When you are confident of the design, you can tear out the Todo features and replace them with your own.

Happy coding!