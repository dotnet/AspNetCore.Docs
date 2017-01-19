---
title: Controllers, Actions, and Action Results | Microsoft Docs
author: ardalis
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 9da9eb52-8583-4069-af91-155ba3529d7f
ms.technology: aspnet
ms.prod: aspnet-core
uid: mvc/controllers/actions
---
# Handling requests with controllers in ASP.NET MVC Core

By [Steve Smith](http://ardalis.com)

Controllers, actions, and action results are a fundamental part of how developers build apps using ASP.NET MVC Core.

## What is a Controller

In ASP.NET MVC, a *Controller* is used to define and group a set of actions. An *action* (or *action method*) is a method on a controller that handles incoming requests. Controllers provide a logical means of grouping similar actions together, allowing common sets of rules (e.g. routing, caching, authorization) to be applied collectively. Incoming requests are mapped to actions through [routing](routing.md).

In ASP.NET Core MVC, a controller can be any instantiable class that ends in "Controller" or inherits from a class that ends with "Controller". Controllers should follow the [Explicit Dependencies Principle](http://deviq.com/explicit-dependencies-principle) and request any dependencies their actions require through their constructor using [dependency injection](dependency-injection.md).

By convention, controller classes:

* Are located in the root-level "Controllers" folder

* Inherit from Microsoft.AspNetCore.Mvc.Controller

These two conventions are not required.

Within the Model-View-Controller pattern, a Controller is responsible for the initial processing of the request and instantiation of the Model. Generally, business decisions should  be performed within the Model.

> [!NOTE]
> The Model should be a *Plain Old CLR Object (POCO)*, not a `DbContext` or database-related type.

The controller takes the result of the model's processing (if any), returns the proper view along with the associated view data. Learn more: [Overview of ASP.NET Core MVC](../overview.md) and [Getting started with ASP.NET Core MVC and Visual Studio](../../tutorials/first-mvc-app/start-mvc.md).

>[!TIP]
> The Controller is a *UI level* abstraction. Its responsibility is to ensure incoming request data is valid and to choose which view (or result for an API) should be returned. In well-factored apps it will not directly include data access or business logic, but instead will delegate to services handling these responsibilities.

## Defining Actions

Any public method on a controller type is an action. Parameters on actions are bound to request data and validated using [model binding](../models/model-binding.md).

>[!WARNING]
> Action methods that accept parameters should verify the `ModelState.IsValid` property is true.

Action methods should contain logic for mapping an incoming request to a business concern. Business concerns should typically be represented as services that your controller accesses through [dependency injection](dependency-injection.md). Actions then map the result of the business action to an application state.
Actions can return anything, but frequently will return an instance of `IActionResult` (or `Task<IActionResult>` for async methods) that produces a response. The action method is responsible for choosing *what kind of response*; the action result *does the responding*.

### Controller Helper Methods

Although not required, most developers will want to have their controllers inherit from the base `Controller` class. Doing so provides controllers with access to many properties and helpful methods, including the following helper methods designed to assist in returning various responses:

**[View](../views/index.md)**

Returns a view that uses a model to render HTML. Example: `return View(customer);`

**HTTP Status Code**

Return an HTTP status code. Example: `return BadRequest();`

**Formatted Response**

Return `Json` or similar to format an object in a specific manner. Example: `return Json(customer);`

**Content negotiated response**

Instead of returning an object directly, an action can return a content negotiated response (using `Ok`, `Created`, `CreatedAtRoute` or `CreatedAtAction`). Examples: `return Ok();` or `return CreatedAtRoute("routename",values,newobject);`

**Redirect**

Returns a redirect to another action or destination (using `Redirect`, `LocalRedirect`, `RedirectToAction` or `RedirectToRoute`). Example: `return RedirectToAction("Complete", new {id = 123});`

In addition to the methods above, an action can also simply return an object. In this case, the object will be formatted based on the client's request. Learn more about [Formatting Response Data](../models/formatting.md)

### Cross-Cutting Concerns

In most apps, many actions will share parts of their workflow. For instance, most of an app might be available only to authenticated users, or might benefit from caching. When you want to perform some logic before or after an action method runs, you can use a *filter*. You can help keep your actions from growing too large by using [Filters](filters.md) to handle these cross-cutting concerns. This can help eliminate duplication within your actions, allowing them to follow the [Don't Repeat Yourself (DRY) principle](http://deviq.com/don-t-repeat-yourself/).

In the case of authorization and authentication, you can apply the `Authorize` attribute to any actions that require it. Adding it to a controller will apply it to all actions within that controller. Adding this attribute will ensure the appropriate filter is applied to any request for this action. Some attributes can be applied at both controller and action levels to provide granular control over filter behavior. Learn more: [Filters](filters.md).

Other examples of cross-cutting concerns in MVC apps may include:
   * [Error handling](filters.md#exception-filters)

   * [Response Caching](../../performance/caching/response.md)

> [!NOTE]
> Many cross-cutting concerns can be handled using filters in MVC apps. Another option to keep in mind that is available to any ASP.NET Core app is custom [middleware](../../fundamentals/middleware.md).
