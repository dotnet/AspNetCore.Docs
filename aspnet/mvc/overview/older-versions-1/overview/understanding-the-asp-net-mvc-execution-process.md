---
uid: mvc/overview/older-versions-1/overview/understanding-the-asp-net-mvc-execution-process
title: "Understanding the ASP.NET MVC Execution Process | Microsoft Docs"
author: microsoft
description: "Learn how the ASP.NET MVC framework processes a browser request step-by-step."
ms.author: aspnetcontent
manager: wpickett
ms.date: 01/27/2009
ms.topic: article
ms.assetid: d1608db3-660d-4079-8c15-f452ff01f1db
ms.technology: dotnet-mvc
ms.prod: .net-framework
msc.legacyurl: /mvc/overview/older-versions-1/overview/understanding-the-asp-net-mvc-execution-process
msc.type: authoredcontent
---
Understanding the ASP.NET MVC Execution Process
====================
by [Microsoft](https://github.com/microsoft)

> Learn how the ASP.NET MVC framework processes a browser request step-by-step.


Requests to an ASP.NET MVC-based Web application first pass through the **UrlRoutingModule** object, which is an HTTP module. This module parses the request and performs route selection. The **UrlRoutingModule** object selects the first route object that matches the current request. (A route object is a class that implements **RouteBase**, and is typically an instance of the **Route** class.) If no routes match, the **UrlRoutingModule** object does nothing and lets the request fall back to the regular ASP.NET or IIS request processing.

From the selected **Route** object, the **UrlRoutingModule** object obtains the **IRouteHandler** object that is associated with the **Route** object. Typically, in an MVC application, this will be an instance of **MvcRouteHandler**. The **IRouteHandler** instance creates an **IHttpHandler** object and passes it the **IHttpContext** object. By default, the **IHttpHandler** instance for MVC is the **MvcHandler** object. The **MvcHandler** object then selects the controller that will ultimately handle the request.

> [!NOTE]
> When an ASP.NET MVC Web application runs in IIS 7.0, no file name extension is required for MVC projects. However, in IIS 6.0, the handler requires that you map the .mvc file name extension to the ASP.NET ISAPI DLL.


The module and handler are the entry points to the ASP.NET MVC framework. They perform the following actions:

- Select the appropriate controller in an MVC Web application.
- Obtain a specific controller instance.
- Call the controller's **Execute** method.

The following lists the stages of execution for an MVC Web project:

- Receive first request for the application 

    - In the Global.asax file, **Route** objects are added to the **RouteTable** object.
- Perform routing 

    - The **UrlRoutingModule** module uses the first matching **Route** object in the **RouteTable** collection to create the **RouteData** object, which it then uses to create a **RequestContext** (**IHttpContext**) object.
- Create MVC request handler 

    - The **MvcRouteHandler** object creates an instance of the **MvcHandler** class and passes it the **RequestContext** instance.
- Create controller 

    - The **MvcHandler** object uses the **RequestContext** instance to identify the **IControllerFactory** object (typically an instance of the **DefaultControllerFactory** class) to create the controller instance with.
- Execute controller - The **MvcHandler** instance calls the controller s **Execute** method. |
- Invoke action 

    - Most controllers inherit from the **Controller** base class. For controllers that do so, the **ControllerActionInvoker** object that is associated with the controller determines which action method of the controller class to call, and then calls that method.
- Execute result 

    - A typical action method might receive user input, prepare the appropriate response data, and then execute the result by returning a result type. The built-in result types that can be executed include the following: **ViewResult** (which renders a view and is the most-often used result type), **RedirectToRouteResult**, **RedirectResult**, **ContentResult**, **JsonResult**, and **EmptyResult**.