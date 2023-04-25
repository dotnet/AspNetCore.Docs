---
title: Handle requests with controllers in ASP.NET Core MVC
author: ardalis
description: Learn how ASP.NET Core MVC controllers and Actions handle requests and return responses.
ms.author: riande
ms.date: 12/05/2019
uid: mvc/controllers/actions
---
# Handle requests with controllers in ASP.NET Core MVC

By [Steve Smith](https://ardalis.com/) and [Scott Addie](https://github.com/scottaddie)

Controllers, actions, and action results are a fundamental part of how developers build apps using ASP.NET Core MVC.

## What is a Controller?

A controller is used to define and group a set of actions. An action (or *action method*) is a method on a controller which handles requests. Controllers logically group similar actions together. This aggregation of actions allows common sets of rules, such as routing, caching, and authorization, to be applied collectively. Requests are mapped to actions through [routing](xref:mvc/controllers/routing). Controllers are activated and disposed on a per request basis.

By convention, controller classes:

* Reside in the project's root-level *Controllers* folder.
* Inherit from `Microsoft.AspNetCore.Mvc.Controller`.

A controller is an instantiable class, usually [public](/dotnet/csharp/language-reference/keywords/public), in which at least one of the following conditions is true:

* The class name is suffixed with `Controller`.
* The class inherits from a class whose name is suffixed with `Controller`.
* The `[Controller]` attribute is applied to the class.

A controller class must not have an associated `[NonController]` attribute.

Controllers should follow the [Explicit Dependencies Principle](/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#explicit-dependencies). There are a couple of approaches to implementing this principle. If multiple controller actions require the same service, consider using [constructor injection](xref:mvc/controllers/dependency-injection#constructor-injection) to request those dependencies. If the service is needed by only a single action method, consider using [Action Injection](xref:mvc/controllers/dependency-injection#action-injection-with-fromservices) to request the dependency.

Within the **M**odel-**V**iew-**C**ontroller pattern, a controller is responsible for the initial processing of the request and instantiation of the model. Generally, business decisions should be performed within the model.

The controller takes the result of the model's processing (if any) and returns either the proper view and its associated view data or the result of the API call. Learn more at [Overview of ASP.NET Core MVC](xref:mvc/overview) and [Get started with ASP.NET Core MVC and Visual Studio](xref:tutorials/first-mvc-app/start-mvc).

The controller is a *UI-level* abstraction. Its responsibilities are to ensure request data is valid and to choose which view (or result for an API) should be returned. In well-factored apps, it doesn't directly include data access or business logic. Instead, the controller delegates to services handling these responsibilities.

## Defining Actions

Public methods on a controller, except those with the `[NonAction]` attribute, are actions. Parameters on actions are bound to request data and are validated using [model binding](xref:mvc/models/model-binding). Model validation occurs for everything that's model-bound. The `ModelState.IsValid` property value indicates whether model binding and validation succeeded.

Action methods should contain logic for mapping a request to a business concern. Business concerns should typically be represented as services that the controller accesses through [dependency injection](xref:mvc/controllers/dependency-injection). Actions then map the result of the business action to an application state.

Actions can return anything, but frequently return an instance of `IActionResult` (or `Task<IActionResult>` for async methods) that produces a response. The action method is responsible for choosing *what kind of response*. The action result *does the responding*.

### Controller Helper Methods

Controllers usually inherit from <xref:Microsoft.AspNetCore.Mvc.Controller>, although this isn't required. Deriving from `Controller` provides access to three categories of helper methods:

#### 1. Methods resulting in an empty response body

No `Content-Type` HTTP response header is included, since the response body lacks content to describe.

There are two result types within this category: Redirect and HTTP Status Code.

* **HTTP Status Code**

    This type returns an HTTP status code. A couple of helper methods of this type are `BadRequest`, `NotFound`, and `Ok`. For example, `return BadRequest();` produces a 400 status code when executed. When methods such as `BadRequest`, `NotFound`, and `Ok` are overloaded, they no longer qualify as HTTP Status Code responders, since content negotiation is taking place.

* **Redirect**

    This type returns a redirect to an action or destination (using `Redirect`, `LocalRedirect`, `RedirectToAction`, or `RedirectToRoute`). For example, `return RedirectToAction("Complete", new {id = 123});` redirects to `Complete`, passing an anonymous object.

    The Redirect result type differs from the HTTP Status Code type primarily in the addition of a `Location` HTTP response header.

#### 2. Methods resulting in a non-empty response body with a predefined content type

Most helper methods in this category include a `ContentType` property, allowing you to set the `Content-Type` response header to describe the response body.

There are two result types within this category: [View](xref:mvc/views/overview) and [Formatted Response](xref:web-api/advanced/formatting).

* **View**

    This type returns a view which uses a model to render HTML. For example, `return View(customer);` passes a model to the view for data-binding.

* **Formatted Response**

    This type returns JSON or a similar data exchange format to represent an object in a specific manner. For example, `return Json(customer);` serializes the provided object into JSON format.
    
    Other common methods of this type include `File` and `PhysicalFile`. For example, `return PhysicalFile(customerFilePath, "text/xml");` returns <xref:Microsoft.AspNetCore.Mvc.PhysicalFileResult>.

#### 3. Methods resulting in a non-empty response body formatted in a content type negotiated with the client

This category is better known as **Content Negotiation**. [Content negotiation](xref:web-api/advanced/formatting#content-negotiation) applies whenever an action returns an <xref:Microsoft.AspNetCore.Mvc.ObjectResult> type or something other than an <xref:Microsoft.AspNetCore.Mvc.IActionResult> implementation. An action that returns a non-`IActionResult` implementation (for example, `object`) also returns a Formatted Response.

Some helper methods of this type include `BadRequest`, `CreatedAtRoute`, and `Ok`. Examples of these methods include `return BadRequest(modelState);`, `return CreatedAtRoute("routename", values, newobject);`, and `return Ok(value);`, respectively. Note that `BadRequest` and `Ok` perform content negotiation only when passed a value; without being passed a value, they instead serve as HTTP Status Code result types. The `CreatedAtRoute` method, on the other hand, always performs content negotiation since its overloads all require that a value be passed.

### Cross-Cutting Concerns

Applications typically share parts of their workflow. Examples include an app that requires authentication to access the shopping cart, or an app that caches data on some pages. To perform logic before or after an action method, use a *filter*. Using [Filters](xref:mvc/controllers/filters) on cross-cutting concerns can reduce duplication.

Most filter attributes, such as `[Authorize]`, can be applied at the controller or action level depending upon the desired level of granularity.

Error handling and response caching are often cross-cutting concerns:
* [Handle errors](xref:mvc/controllers/filters#exception-filters)
* [Response Caching](xref:performance/caching/response)

Many cross-cutting concerns can be handled using filters or custom [middleware](xref:fundamentals/middleware/index).
