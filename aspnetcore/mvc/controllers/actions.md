---
title: Handling requests with controllers in ASP.NET Core MVC | Microsoft Docs
author: ardalis
description: 
keywords: ASP.NET Core
ms.author: riande
manager: wpickett
ms.date: 07/03/2017
ms.topic: article
ms.assetid: 9da9eb52-8583-4069-af91-155ba3529d7f
ms.technology: aspnet
ms.prod: asp.net-core
uid: mvc/controllers/actions
---
# Handling requests with controllers in ASP.NET Core MVC

By [Steve Smith](http://ardalis.com) and [Scott Addie](https://github.com/scottaddie)

Controllers, actions, and action results are a fundamental part of how developers build apps using ASP.NET Core MVC.

## What is a Controller?

In ASP.NET MVC, a controller is used to define and group a set of actions. An action (or action method) is a method on a controller which handles incoming requests. Controllers provide a logical means of grouping similar actions together, allowing common sets of rules, such as routing, caching, and authorization, to be applied collectively. Incoming requests are mapped to actions through [routing](xref:mvc/controllers/routing).

In ASP.NET Core MVC, a controller is an instantiable class in which at least one of the following conditions is true:
* The class name is suffixed with "Controller"
* The class inherits from a class whose name is suffixed with "Controller"

By convention, controller classes:
* Reside in the project's root-level *Controllers* folder
* Inherit from `Microsoft.AspNetCore.Mvc.Controller`

Additional configuration is required if these two conventions are disregarded.

Controllers should follow the [Explicit Dependencies Principle](http://deviq.com/explicit-dependencies-principle) and request any dependencies their actions require through their constructor using [constructor injection](xref:mvc/controllers/dependency-injection#constructor-injection).

Within the **M**odel-**V**iew-**C**ontroller pattern, a controller is responsible for the initial processing of the request and instantiation of the model. Generally, business decisions should be performed within the model.

> [!NOTE]
> The model should be a *Plain Old CLR Object (POCO)*, not a `DbContext` object or a database-related type.

The controller takes the result of the model's processing (if any) and returns the proper view along with the associated view data. Learn more at [Overview of ASP.NET Core MVC](xref:mvc/overview) and [Getting started with ASP.NET Core MVC and Visual Studio](xref:tutorials/first-mvc-app/start-mvc).

> [!TIP]
> The controller is a *UI-level* abstraction. Its responsibilities are to ensure incoming request data is valid and to choose which view (or result for an API) should be returned. In well-factored apps, it does not directly include data access or business logic. Instead, the controller delegates to services handling these responsibilities.

## Defining Actions

Any public method on a controller type is an action. Parameters on actions are bound to request data and are validated using [model binding](xref:mvc/models/model-binding).

> [!WARNING]
> Action methods that accept parameters should verify the `ModelState.IsValid` property is true.

Action methods should contain logic for mapping an incoming request to a business concern. Business concerns should typically be represented as services that the controller accesses through [dependency injection](xref:mvc/controllers/dependency-injection). Actions then map the result of the business action to an application state.

Actions can return anything, but frequently return an instance of `IActionResult` (or `Task<IActionResult>` for async methods) that produces a response. The action method is responsible for choosing *what kind of response*; the action result *does the responding*.

### Controller Helper Methods

Although not required, most developers have their controllers inherit from the base `Controller` class. Doing so provides controllers with access to three categories of helper methods designed to return specific response types:

#### 1. An empty response body

No `Content-Type` HTTP response header is included, since the response body lacks content to describe.

There are two response types within this category: Redirect and HTTP Status Code. The Redirect response type differs from the HTTP Status Code type primarily in the addition of a `Location` HTTP response header.

**Redirect**

This type returns a redirect to an action or destination (using `Redirect`, `LocalRedirect`, `RedirectToAction`, or `RedirectToRoute`). For example, `return RedirectToAction("Complete", new {id = 123});` redirects to the named action method and passes to it an anonymous object.

**HTTP Status Code**

This type returns an HTTP status code. A couple helper methods of this type are `BadRequest` and `NotFound`. For example, `return BadRequest();` produces a 400 status code when executed.

#### 2. A non-empty response body with a predefined content type

Most of these response types include a `ContentType` property, allowing you to set the `Content-Type` response header to describe the response body.

There are two response types within this category: [View](xref:mvc/views/overview) and [Formatted Response](xref:mvc/models/formatting).

**View**

This type returns a view which uses a model to render HTML. For example, `return View(customer);` passes a model to the view for data-binding.

**Formatted Response**

This type returns JSON or a similar data exchange format to represent an object in a specific manner. For example, `return Json(customer);` serializes the provided object into JSON format.

#### 3. A non-empty response body formatted in a content type negotiated with the client

This type is better known as a **Content Negotiated Response**. [Content negotiation](xref:mvc/models/formatting#content-negotiation) applies whenever an action returns an [ObjectResult](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.mvc.objectresult) type or something other than an [IActionResult](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.mvc.iactionresult) implementation. 

Instead of returning an object directly, an action can return a content negotiated response. Some helper methods of this type include `Created`, `CreatedAtAction`, `CreatedAtRoute`, and `Ok`. Examples: `return Ok();` or `return CreatedAtRoute("routename", values, newobject);`

### Cross-Cutting Concerns

In most apps, many actions share parts of their workflow. For instance, most of an app might be available only to authenticated users, or might benefit from caching. When you want to perform some logic before or after an action method runs, you can use a *filter*. You can help keep the actions from growing too large by using [Filters](xref:mvc/controllers/filters) to handle these cross-cutting concerns. This can help eliminate duplication within the actions, allowing them to follow the [Don't Repeat Yourself (DRY) principle](http://deviq.com/don-t-repeat-yourself/).

In the case of authorization and authentication, you can apply the `Authorize` attribute to any actions that require it. Adding it to a controller applies it to all actions within that controller. Adding this attribute ensures the appropriate filter is applied to any request for this action. Some attributes can be applied at both controller and action levels to provide granular control over filter behavior.

Other examples of cross-cutting concerns in MVC apps may include:
   * [Error handling](xref:mvc/controllers/filters#exception-filters)
   * [Response Caching](xref:performance/caching/response)

> [!NOTE]
> Many cross-cutting concerns can be handled using filters in MVC apps. An alternative to keep in mind, which is available to any type of ASP.NET Core app, is custom [middleware](xref:fundamentals/middleware).