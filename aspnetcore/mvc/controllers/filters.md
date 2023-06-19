---
title: Filters in ASP.NET Core
author: Rick-Anderson
description: Learn how filters work and how to use them in ASP.NET Core.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
uid: mvc/controllers/filters
---
# Filters in ASP.NET Core

:::moniker range=">= aspnetcore-8.0"

By [Kirk Larkin](https://github.com/serpent5), [Rick Anderson](https://twitter.com/RickAndMSFT), [Tom Dykstra](https://github.com/tdykstra/), and [Steve Smith](https://ardalis.com/)

*Filters* in ASP.NET Core allow code to run before or after specific stages in the request processing pipeline.

Built-in filters handle tasks such as:

* Authorization, preventing access to resources a user isn't authorized for.
* Response caching, short-circuiting the request pipeline to return a cached response.

Custom filters can be created to handle cross-cutting concerns. Examples of cross-cutting concerns include error handling, caching, configuration, authorization, and logging. Filters avoid duplicating code. For example, an error handling exception filter could consolidate error handling.

This document applies to Razor Pages, API controllers, and controllers with views. Filters don't work directly with [Razor components](xref:blazor/components/index). A filter can only indirectly affect a component when:

* The component is embedded in a page or view.
* The page or controller and view uses the filter.

## How filters work

Filters run within the *ASP.NET Core action invocation pipeline*, sometimes referred to as the *filter pipeline*. The filter pipeline runs after ASP.NET Core selects the action to execute:

:::image source="filters/_static/filter-pipeline-1.png" alt-text="The request is processed through Other Middleware, Routing Middleware, Action Selection, and the Action Invocation Pipeline. The request processing continues back through Action Selection, Routing Middleware, and various Other Middleware before becoming a response sent to the client.":::

### Filter types

Each filter type is executed at a different stage in the filter pipeline:

* [Authorization filters](#authorization-filters):

  * Run first.
  * Determine whether the user is authorized for the request.
  * Short-circuit the pipeline if the request is not authorized.

* [Resource filters](#resource-filters):

  * Run after authorization.
  * <xref:Microsoft.AspNetCore.Mvc.Filters.IResourceFilter.OnResourceExecuting%2A> runs code before the rest of the filter pipeline. For example, `OnResourceExecuting` runs code before model binding.
  * <xref:Microsoft.AspNetCore.Mvc.Filters.IResourceFilter.OnResourceExecuted%2A> runs code after the rest of the pipeline has completed.

* [Action filters](#action-filters):

  * Run immediately before and after an action method is called.
  * Can change the arguments passed into an action.
  * Can change the result returned from the action.
  * Are **not** supported in Razor Pages.


* [Endpoint filters](/aspnet/core/fundamentals/minimal-apis/min-api-filters):

  * Run immediately before and after an action method is called.
  * Can change the arguments passed into an action.
  * Can change the result returned from the action.
  * Are **not** supported in Razor Pages.
  * Can be invoked on both actions and route handler-based endpoints.

:::moniker-end

[!INCLUDE[](~/mvc/controllers/filters/includes/filters7.md")]
