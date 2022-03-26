---
title: Filters in ASP.NET Core
author: Rick-Anderson
description: Learn how filters work and how to use them in ASP.NET Core.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: mvc/controllers/filters
---
# Filters in ASP.NET Core

:::moniker range=">= aspnetcore-6.0"

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

* [Exception filters](#exception-filters) apply global policies to unhandled exceptions that occur before the response body has been written to.

* [Result filters](#result-filters):
  
  * Run immediately before and after the execution of action results.
  * Run only when the action method executes successfully.
  * Are useful for logic that must surround view or formatter execution.

The following diagram shows how filter types interact in the filter pipeline:

:::image source="filters/_static/filter-pipeline-2.png" alt-text="The request is processed through Authorization Filters, Resource Filters, Model Binding, Action Filters, Action Execution and Action Result Conversion, Exception Filters, Result Filters, and Result Execution. On the way out, the request is only processed by Result Filters and Resource Filters before becoming a response sent to the client.":::

Razor Pages also support [Razor Page filters](xref:razor-pages/filter), which run before and after a Razor Page handler.

## Implementation

Filters support both synchronous and asynchronous implementations through different interface definitions.

Synchronous filters run before and after their pipeline stage. For example, <xref:Microsoft.AspNetCore.Mvc.Filters.IActionFilter.OnActionExecuting%2A> is called before the action method is called. <xref:Microsoft.AspNetCore.Mvc.Filters.IActionFilter.OnActionExecuted%2A> is called after the action method returns:

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Filters/SampleActionFilter.cs" id="snippet_Class":::

Asynchronous filters define an `On-Stage-ExecutionAsync` method. For example, <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter.OnActionExecutionAsync%2A>:

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Filters/SampleAsyncActionFilter.cs" id="snippet_Class":::

In the preceding code, the `SampleAsyncActionFilter` has an <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate>, `next`, which executes the action method.

### Multiple filter stages

Interfaces for multiple filter stages can be implemented in a single class. For example, the <xref:Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute> class implements:

* Synchronous: <xref:Microsoft.AspNetCore.Mvc.Filters.IActionFilter> and <xref:Microsoft.AspNetCore.Mvc.Filters.IResultFilter>
* Asynchronous: <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter> and <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter>
* <xref:Microsoft.AspNetCore.Mvc.Filters.IOrderedFilter>

Implement **either** the synchronous or the async version of a filter interface, **not** both. The runtime checks first to see if the filter implements the async interface, and if so, it calls that. If not, it calls the synchronous interface's method(s). If both asynchronous and synchronous interfaces are implemented in one class, only the async method is called. When using abstract classes like <xref:Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute>, override only the synchronous methods or the asynchronous methods for each filter type.

### Built-in filter attributes

ASP.NET Core includes built-in attribute-based filters that can be subclassed and customized. For example, the following result filter adds a header to the response:

<a name="response-header-attribute"></a>

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Filters/ResponseHeaderAttribute.cs" id="snippet_Class":::

Attributes allow filters to accept arguments, as shown in the preceding example. Apply the `ResponseHeaderAttribute` to a controller or action method and specify the name and value of the HTTP header:

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Controllers/ResponseHeaderController.cs" id="snippet_ClassIndex" highlight="1":::

Use a tool such as the [browser developer tools](https://developer.mozilla.org/docs/Learn/Common_questions/What_are_browser_developer_tools) to examine the headers. Under **Response Headers**, `filter-header: Filter Value` is displayed.

The following code applies `ResponseHeaderAttribute` to both a controller and an action:

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Controllers/ResponseHeaderController.cs" id="snippet_Class" highlight="1,9":::

Responses from the `Multiple` action include the following headers:

* `filter-header: Filter Value`
* `another-filter-header: Another Filter Value`

Several of the filter interfaces have corresponding attributes that can be used as base classes for custom implementations.

Filter attributes:

* <xref:Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute>
* <xref:Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute>
* <xref:Microsoft.AspNetCore.Mvc.Filters.ResultFilterAttribute>
* <xref:Microsoft.AspNetCore.Mvc.FormatFilterAttribute>
* <xref:Microsoft.AspNetCore.Mvc.ServiceFilterAttribute>
* <xref:Microsoft.AspNetCore.Mvc.TypeFilterAttribute>

Filters cannot be applied to Razor Page handler methods. They can be applied either to the Razor Page model or globally.

## Filter scopes and order of execution

A filter can be added to the pipeline at one of three *scopes*:

* Using an attribute on a controller or Razor Page.
* Using an attribute on a controller action. Filter attributes cannot be applied to Razor Pages handler methods.
* Globally for all controllers, actions, and Razor Pages as shown in the following code:
  :::code language="csharp" source="filters/samples/6.x/FiltersSample/Program.cs" id="snippet_GlobalFilter" highlight="6":::

### Default order of execution

When there are multiple filters for a particular stage of the pipeline, scope determines the default order of filter execution. Global filters surround class filters, which in turn surround method filters.

As a result of filter nesting, the *after* code of filters runs in the reverse order of the *before* code. The filter sequence:

* The *before* code of global filters.
  * The *before* code of controller filters.
    * The *before* code of action method filters.
    * The *after* code of action method filters.
  * The *after* code of controller filters.
* The *after* code of global filters.

The following example illustrates the order in which filter methods run for synchronous action filters:

| Sequence | Filter scope | Filter method       |
|:--------:|:------------:|:-------------------:|
| 1        | Global       | `OnActionExecuting` |
| 2        | Controller   | `OnActionExecuting` |
| 3        | Action       | `OnActionExecuting` |
| 4        | Action       | `OnActionExecuted`  |
| 5        | Controller   | `OnActionExecuted`  |
| 6        | Global       | `OnActionExecuted`  |

### Controller level filters

Every controller that inherits from <xref:Microsoft.AspNetCore.Mvc.Controller> includes the <xref:Microsoft.AspNetCore.Mvc.Controller.OnActionExecuting%2A>, <xref:Microsoft.AspNetCore.Mvc.Controller.OnActionExecutionAsync%2A>, and <xref:Microsoft.AspNetCore.Mvc.Controller.OnActionExecuted%2A> methods. These methods wrap the filters that run for a given action:

* `OnActionExecuting` runs before any of the action's filters.
* `OnActionExecuted` runs after all of the action's filters.
* `OnActionExecutionAsync` runs before any of the action's filters. Code after a call to `next` runs after the action's filters.

The following `ControllerFiltersController` class:

* Applies the `SampleActionFilterAttribute` (`[SampleActionFilter]`) to the controller.
* Overrides `OnActionExecuting` and `OnActionExecuted`.

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Controllers/ControllerFiltersController.cs" id="snippet_Class" highlight="1,4,12":::

Navigating to `https://localhost:<port>/ControllerFilters` runs the following code:

* `ControllerFiltersController.OnActionExecuting`
  * `GlobalSampleActionFilter.OnActionExecuting`
    * `SampleActionFilterAttribute.OnActionExecuting`
      * `ControllerFiltersController.Index`
    * `SampleActionFilterAttribute.OnActionExecuted`
  * `GlobalSampleActionFilter.OnActionExecuted`
* `ControllerFiltersController.OnActionExecuted`

Controller level filters set the [Order](https://github.com/dotnet/AspNetCore/blob/main/src/Mvc/Mvc.Core/src/Filters/ControllerActionFilter.cs#L15-L17) property to `int.MinValue`. Controller level filters can **not** be set to run after filters applied to methods. Order is explained in the next section.

For Razor Pages, see [Implement Razor Page filters by overriding filter methods](xref:razor-pages/filter#implement-razor-page-filters-by-overriding-filter-methods).

### Override the default order

The default sequence of execution can be overridden by implementing <xref:Microsoft.AspNetCore.Mvc.Filters.IOrderedFilter>. `IOrderedFilter` exposes the <xref:Microsoft.AspNetCore.Mvc.Filters.IOrderedFilter.Order> property that takes precedence over scope to determine the order of execution. A filter with a lower `Order` value:

* Runs the *before* code before that of a filter with a higher value of `Order`.
* Runs the *after* code after that of a filter with a higher `Order` value.

In the [Controller level filters](#controller-level-filters) example, `GlobalSampleActionFilter` has global scope so it runs before `SampleActionFilterAttribute`, which has controller scope. To make `SampleActionFilterAttribute` run first, set its order to `int.MinValue`:

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Snippets/Controllers/ControllerFiltersController.cs" id="snippet_Class" highlight="1":::

To make the global filter `GlobalSampleActionFilter` run first, set its `Order` to `int.MinValue`:

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Snippets/Program.cs" id="snippet_AddFilterOrder" highlight="3":::

## Cancellation and short-circuiting

The filter pipeline can be short-circuited by setting the <xref:Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext.Result> property on the <xref:Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext> parameter provided to the filter method. For example, the following Resource filter prevents the rest of the pipeline from executing:

<a name="short-circuiting-resource-filter"></a>

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Filters/ShortCircuitingResourceFilterAttribute.cs" id="snippet_Class" highlight="5-8":::

In the following code, both the `[ShortCircuitingResourceFilter]` and the `[ResponseHeader]` filter target the `Index` action method. The `ShortCircuitingResourceFilterAttribute` filter:

* Runs first, because it's a Resource Filter and `ResponseHeaderAttribute` is an Action Filter.
* Short-circuits the rest of the pipeline.

Therefore the `ResponseHeaderAttribute` filter never runs for the `Index` action. This behavior would be the same if both filters were applied at the action method level, provided the `ShortCircuitingResourceFilterAttribute` ran first. The `ShortCircuitingResourceFilterAttribute` runs first because of its filter type:

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Controllers/ShortCircuitingController.cs" id="snippet_Class":::

## Dependency injection

Filters can be added by type or by instance. If an instance is added, that instance is used for every request. If a type is added, it's type-activated. A type-activated filter means:

* An instance is created for each request.
* Any constructor dependencies are populated by [dependency injection](xref:fundamentals/dependency-injection) (DI).

Filters that are implemented as attributes and added directly to controller classes or action methods cannot have constructor dependencies provided by [dependency injection](xref:fundamentals/dependency-injection) (DI). Constructor dependencies cannot be provided by DI because attributes must have their constructor parameters supplied where they're applied. 

The following filters support constructor dependencies provided from DI:

* <xref:Microsoft.AspNetCore.Mvc.ServiceFilterAttribute>
* <xref:Microsoft.AspNetCore.Mvc.TypeFilterAttribute>
* <xref:Microsoft.AspNetCore.Mvc.Filters.IFilterFactory> implemented on the attribute.

The preceding filters can be applied to a controller or an action.

Loggers are available from DI. However, avoid creating and using filters purely for logging purposes. The [built-in framework logging](xref:fundamentals/logging/index) typically provides what's needed for logging. Logging added to filters:

* Should focus on business domain concerns or behavior specific to the filter.
* Should **not** log actions or other framework events. The built-in filters already log actions and framework events.

### ServiceFilterAttribute

Service filter implementation types are registered in `Program.cs`. A <xref:Microsoft.AspNetCore.Mvc.ServiceFilterAttribute> retrieves an instance of the filter from DI.

The following code shows the `LoggingResponseHeaderFilterService` class, which uses DI:

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Filters/LoggingResponseHeaderFilterService.cs" id="snippet_Class" highlight="5-6":::

In the following code, `LoggingResponseHeaderFilterService` is added to the DI container:

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Program.cs" id="snippet_ResponseHeaderFilterService":::

In the following code, the `ServiceFilter` attribute retrieves an instance of the `LoggingResponseHeaderFilterService` filter from DI:

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Controllers/FilterDependenciesController.cs" id="snippet_ServiceFilter" highlight="1":::

When using `ServiceFilterAttribute`, setting <xref:Microsoft.AspNetCore.Mvc.ServiceFilterAttribute.IsReusable?displayProperty=nameWithType>:

* Provides a hint that the filter instance *may* be reused outside of the request scope it was created within. The ASP.NET Core runtime doesn't guarantee:
  * That a single instance of the filter will be created.
  * The filter will not be re-requested from the DI container at some later point.
* Shouldn't be used with a filter that depends on services with a lifetime other than singleton.

 <xref:Microsoft.AspNetCore.Mvc.ServiceFilterAttribute> implements <xref:Microsoft.AspNetCore.Mvc.Filters.IFilterFactory>. `IFilterFactory` exposes the <xref:Microsoft.AspNetCore.Mvc.Filters.IFilterFactory.CreateInstance%2A> method for creating an <xref:Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata> instance. `CreateInstance` loads the specified type from DI.

### TypeFilterAttribute

<xref:Microsoft.AspNetCore.Mvc.TypeFilterAttribute> is similar to <xref:Microsoft.AspNetCore.Mvc.ServiceFilterAttribute>, but its type isn't resolved directly from the DI container. It instantiates the type by using <xref:Microsoft.Extensions.DependencyInjection.ObjectFactory?displayProperty=fullName>.

Because `TypeFilterAttribute` types aren't resolved directly from the DI container:

* Types that are referenced using the `TypeFilterAttribute` don't need to be registered with the DI container. They do have their dependencies fulfilled by the DI container.
* `TypeFilterAttribute` can optionally accept constructor arguments for the type.

When using `TypeFilterAttribute`, setting <xref:Microsoft.AspNetCore.Mvc.TypeFilterAttribute.IsReusable?displayProperty=nameWithType>:
* Provides hint that the filter instance *may* be reused outside of the request scope it was created within. The ASP.NET Core runtime provides no guarantees that a single instance of the filter will be created.

* Should not be used with a filter that depends on services with a lifetime other than singleton.

The following example shows how to pass arguments to a type using `TypeFilterAttribute`:

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Controllers/FilterDependenciesController.cs" id="snippet_TypeFilter" highlight="1-2":::

## Authorization filters

Authorization filters:

* Are the first filters run in the filter pipeline.
* Control access to action methods.
* Have a before method, but no after method.

Custom authorization filters require a custom authorization framework. Prefer configuring the authorization policies or writing a custom authorization policy over writing a custom filter. The built-in authorization filter:

* Calls the authorization system.
* Does not authorize requests.

Do **not** throw exceptions within authorization filters:

* The exception will not be handled.
* Exception filters will not handle the exception.

Consider issuing a challenge when an exception occurs in an authorization filter.

Learn more about [Authorization](xref:security/authorization/introduction).

## Resource filters

Resource filters:

* Implement either the <xref:Microsoft.AspNetCore.Mvc.Filters.IResourceFilter> or <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncResourceFilter> interface.
* Execution wraps most of the filter pipeline.
* Only [Authorization filters](#authorization-filters) run before resource filters.

Resource filters are useful to short-circuit most of the pipeline. For example, a caching filter can avoid the rest of the pipeline on a cache hit.

Resource filter examples:

* [The short-circuiting resource filter](#short-circuiting-resource-filter) shown previously.
* [DisableFormValueModelBindingAttribute](https://github.com/aspnet/Entropy/blob/master/samples/Mvc.FileUpload/Filters/DisableFormValueModelBindingAttribute.cs):

  * Prevents model binding from accessing the form data.
  * Used for large file uploads to prevent the form data from being read into memory.

## Action filters

Action filters do **not** apply to Razor Pages. Razor Pages supports <xref:Microsoft.AspNetCore.Mvc.Filters.IPageFilter> and <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncPageFilter> . For more information, see [Filter methods for Razor Pages](xref:razor-pages/filter).

Action filters:

* Implement either the <xref:Microsoft.AspNetCore.Mvc.Filters.IActionFilter> or <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter> interface.
* Their execution surrounds the execution of action methods.

The following code shows a sample action filter:

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Filters/SampleActionFilter.cs" id="snippet_Class":::

The <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext> provides the following properties:

* <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext.ActionArguments> - enables reading the inputs to an action method.
* <xref:Microsoft.AspNetCore.Mvc.Controller> - enables manipulating the controller instance.
* <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext.Result%2A> - setting `Result` short-circuits execution of the action method and subsequent action filters.

Throwing an exception in an action method:

* Prevents running of subsequent filters.
* Unlike setting `Result`, is treated as a failure instead of a successful result.

The <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext> provides `Controller` and `Result` plus the following properties:

* <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext.Canceled%2A> - True if the action execution was short-circuited by another filter.
* <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext.Exception%2A> - Non-null if the action or a previously run action filter threw an exception. Setting this property to null:
  * Effectively handles the exception.
  * `Result` is executed as if it was returned from the action method.

For an `IAsyncActionFilter`, a call to the <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate>:

* Executes any subsequent action filters and the action method.
* Returns `ActionExecutedContext`.

To short-circuit, assign <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext.Result?displayProperty=fullName> to a result instance and don't call `next` (the `ActionExecutionDelegate`).

The framework provides an abstract <xref:Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute> that can be subclassed.

The `OnActionExecuting` action filter can be used to:

* Validate model state.
* Return an error if the state is invalid.

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Filters/ValidateModelAttribute.cs" id="snippet_Class":::

> [!NOTE]
> Controllers annotated with the `[ApiController]` attribute automatically validate model state and return a 400 response. For more information, see [Automatic HTTP 400 responses](xref:web-api/index#automatic-http-400-responses).

The `OnActionExecuted` method runs after the action method:

* And can see and manipulate the results of the action through the <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext.Result> property.
* <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext.Canceled> is set to true if the action execution was short-circuited by another filter.
* <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext.Exception> is set to a non-null value if the action or a subsequent action filter threw an exception. Setting `Exception` to null:
  * Effectively handles an exception.
  * `ActionExecutedContext.Result` is executed as if it were returned normally from the action method.

## Exception filters

Exception filters:

* Implement <xref:Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter> or <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter>.
* Can be used to implement common error handling policies.

The following sample exception filter displays details about exceptions that occur when the app is in development:

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Filters/SampleExceptionFilter.cs" id="snippet_Class":::

The following code tests the exception filter:

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Controllers/ExceptionController.cs" id="snippet_Class" highlight="1":::

Exception filters:

* Don't have before and after events.
* Implement <xref:Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter.OnException%2A> or <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter.OnExceptionAsync%2A>.
* Handle unhandled exceptions that occur in Razor Page or controller creation, [model binding](xref:mvc/models/model-binding), action filters, or action methods.
* Do **not** catch exceptions that occur in resource filters, result filters, or MVC result execution.

To handle an exception, set the <xref:Microsoft.AspNetCore.Mvc.Filters.ExceptionContext.ExceptionHandled%2A> property to `true` or assign the <xref:Microsoft.AspNetCore.Mvc.Filters.ExceptionContext.Result%2A> property. This stops propagation of the exception. An exception filter can't turn an exception into a "success". Only an action filter can do that.

Exception filters:

* Are good for trapping exceptions that occur within actions.
* Are not as flexible as error handling middleware.

Prefer middleware for exception handling. Use exception filters only where error handling *differs* based on which action method is called. For example, an app might have action methods for both API endpoints and for views/HTML. The API endpoints could return error information as JSON, while the view-based actions could return an error page as HTML.

## Result filters

Result filters:

* Implement an interface:
  * <xref:Microsoft.AspNetCore.Mvc.Filters.IResultFilter> or <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter>
  * <xref:Microsoft.AspNetCore.Mvc.Filters.IAlwaysRunResultFilter> or <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncAlwaysRunResultFilter>
* Their execution surrounds the execution of action results.

### IResultFilter and IAsyncResultFilter

The following code shows a sample result filter:

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Snippets/Filters/SampleResultFilter.cs" id="snippet_Class":::

The kind of result being executed depends on the action. An action returning a view includes all razor processing as part of the <xref:Microsoft.AspNetCore.Mvc.ViewResult> being executed. An API method might perform some serialization as part of the execution of the result. Learn more about [action results](xref:mvc/controllers/actions).

Result filters are only executed when an action or action filter produces an action result. Result filters are not executed when:

* An authorization filter or resource filter short-circuits the pipeline.
* An exception filter handles an exception by producing an action result.

The <xref:Microsoft.AspNetCore.Mvc.Filters.IResultFilter.OnResultExecuting%2A?displayProperty=fullName> method can short-circuit execution of the action result and subsequent result filters by setting <xref:Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext.Cancel?displayProperty=fullName> to `true`. Write to the response object when short-circuiting to avoid generating an empty response. Throwing an exception in `IResultFilter.OnResultExecuting`:

* Prevents execution of the action result and subsequent filters.
* Is treated as a failure instead of a successful result.

When the <xref:Microsoft.AspNetCore.Mvc.Filters.IResultFilter.OnResultExecuted%2A?displayProperty=fullName> method runs, the response has probably already been sent to the client. If the response has already been sent to the client, it cannot be changed.

`ResultExecutedContext.Canceled` is set to `true` if the action result execution was short-circuited by another filter.

`ResultExecutedContext.Exception` is set to a non-null value if the action result or a subsequent result filter threw an exception. Setting `Exception` to null effectively handles an exception and prevents the exception from being thrown again later in the pipeline. There is no reliable way to write data to a response when handling an exception in a result filter. If the headers have been flushed to the client when an action result throws an exception, there's no reliable mechanism to send a failure code.

For an <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter>, a call to `await next` on the <xref:Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate> executes any subsequent result filters and the action result. To short-circuit, set <xref:Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext.Cancel?displayProperty=nameWithType> to `true` and don't call the `ResultExecutionDelegate`:

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Snippets/Filters/SampleAsyncResultFilter.cs" id="snippet_Class":::

The framework provides an abstract `ResultFilterAttribute` that can be subclassed. The [ResponseHeaderAttribute](#response-header-attribute) class shown previously is an example of a result filter attribute.

### IAlwaysRunResultFilter and IAsyncAlwaysRunResultFilter

The <xref:Microsoft.AspNetCore.Mvc.Filters.IAlwaysRunResultFilter> and <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncAlwaysRunResultFilter> interfaces declare an <xref:Microsoft.AspNetCore.Mvc.Filters.IResultFilter> implementation that runs for all action results. This includes action results produced by:

* Authorization filters and resource filters that short-circuit.
* Exception filters.

For example, the following filter always runs and sets an action result (<xref:Microsoft.AspNetCore.Mvc.ObjectResult>) with a *422 Unprocessable Entity* status code when content negotiation fails:

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Snippets/Filters/UnprocessableResultFilter.cs" id="snippet_Class":::

## IFilterFactory

<xref:Microsoft.AspNetCore.Mvc.Filters.IFilterFactory> implements <xref:Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>. Therefore, an `IFilterFactory` instance can be used as an `IFilterMetadata` instance anywhere in the filter pipeline. When the runtime prepares to invoke the filter, it attempts to cast it to an `IFilterFactory`. If that cast succeeds, the <xref:Microsoft.AspNetCore.Mvc.Filters.IFilterFactory.CreateInstance%2A> method is called to create the `IFilterMetadata` instance that is invoked. This provides a flexible design, since the precise filter pipeline doesn't need to be set explicitly when the app starts.

`IFilterFactory.IsReusable`:

* Is a hint by the factory that the filter instance created by the factory may be reused outside of the request scope it was created within.
* Should ***not*** be used with a filter that depends on services with a lifetime other than singleton.

The ASP.NET Core runtime doesn't guarantee:

* That a single instance of the filter will be created.
* The filter will not be re-requested from the DI container at some later point.

> [!WARNING] 
> Only configure <xref:Microsoft.AspNetCore.Mvc.Filters.IFilterFactory.IsReusable?displayProperty=nameWithType> to return `true` if the source of the filters is unambiguous, the filters are stateless, and the filters are safe to use across multiple HTTP requests. For instance, don't return filters from DI that are registered as scoped or transient if `IFilterFactory.IsReusable` returns `true`.

`IFilterFactory` can be implemented using custom attribute implementations as another approach to creating filters:

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Filters/ResponseHeaderFactoryAttribute.cs" id="snippet_Class" highlight="1,5-6":::

The filter is applied in the following code:

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Controllers/FilterFactoryController.cs" id="snippet_Index" highlight="1":::

### IFilterFactory implemented on an attribute

Filters that implement `IFilterFactory` are useful for filters that:

* Don't require passing parameters.
* Have constructor dependencies that need to be filled by DI.

<xref:Microsoft.AspNetCore.Mvc.TypeFilterAttribute> implements <xref:Microsoft.AspNetCore.Mvc.Filters.IFilterFactory>. `IFilterFactory` exposes the <xref:Microsoft.AspNetCore.Mvc.Filters.IFilterFactory.CreateInstance%2A> method for creating an <xref:Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata> instance. `CreateInstance` loads the specified type from the services container (DI).

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Filters/SampleActionTypeFilterAttribute.cs" id="snippet_Class" highlight="1,3-4":::

The following code shows three approaches to applying the filter:

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Controllers/FilterFactoryController.cs" id="snippet_TypeFilterAttribute" highlight="1,5,9":::

In the preceding code, the first approach to applying the filter is preferred.

## Use middleware in the filter pipeline

Resource filters work like [middleware](xref:fundamentals/middleware/index) in that they surround the execution of everything that comes later in the pipeline. But filters differ from middleware in that they're part of the runtime, which means that they have access to context and constructs.

To use middleware as a filter, create a type with a `Configure` method that specifies the middleware to inject into the filter pipeline. The following example uses middleware to set a response header:

:::code language="csharp" source="filters/samples/6.x/FiltersSample/FilterMiddlewarePipeline.cs" id="snippet_Class":::

Use the <xref:Microsoft.AspNetCore.Mvc.MiddlewareFilterAttribute> to run the middleware:

:::code language="csharp" source="filters/samples/6.x/FiltersSample/Controllers/FilterMiddlewareController.cs" id="snippet_Class" highlight="1":::

Middleware filters run at the same stage of the filter pipeline as Resource filters, before model binding and after the rest of the pipeline.

## Thread safety

When passing an *instance* of a filter into `Add`, instead of its `Type`, the filter is a singleton and is **not** thread-safe.

## Additional resources

* [View or download sample](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/filters/samples) ([how to download](xref:index#how-to-download-a-sample)).
* <xref:razor-pages/filter>

:::moniker-end

:::moniker range="< aspnetcore-6.0"

By [Kirk Larkin](https://github.com/serpent5), [Rick Anderson](https://twitter.com/RickAndMSFT), [Tom Dykstra](https://github.com/tdykstra/), and [Steve Smith](https://ardalis.com/)

*Filters* in ASP.NET Core allow code to be run before or after specific stages in the request processing pipeline.

Built-in filters handle tasks such as:

* Authorization, preventing access to resources a user isn't authorized for.
* Response caching, short-circuiting the request pipeline to return a cached response.

Custom filters can be created to handle cross-cutting concerns. Examples of cross-cutting concerns include error handling, caching, configuration, authorization, and logging.  Filters avoid duplicating code. For example, an error handling exception filter could consolidate error handling.

This document applies to Razor Pages, API controllers, and controllers with views. Filters don't work directly with [Razor components](xref:blazor/components/index). A filter can only indirectly affect a component when:

* The component is embedded in a page or view.
* The page or controller and view uses the filter.

[View or download sample](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/filters/samples) ([how to download](xref:index#how-to-download-a-sample)).

## How filters work

Filters run within the *ASP.NET Core action invocation pipeline*, sometimes referred to as the *filter pipeline*. The filter pipeline runs after ASP.NET Core selects the action to execute.

:::image source="filters/_static/filter-pipeline-1.png" alt-text="The request is processed through Other Middleware, Routing Middleware, Action Selection, and the Action Invocation Pipeline. The request processing continues back through Action Selection, Routing Middleware, and various Other Middleware before becoming a response sent to the client.":::

### Filter types

Each filter type is executed at a different stage in the filter pipeline:

* [Authorization filters](#authorization-filters) run first and are used to determine whether the user is authorized for the request. Authorization filters short-circuit the pipeline if the request is not authorized.

* [Resource filters](#resource-filters):

  * Run after authorization.  
  * <xref:Microsoft.AspNetCore.Mvc.Filters.IResourceFilter.OnResourceExecuting%2A> runs code before the rest of the filter pipeline. For example, `OnResourceExecuting` runs code before model binding.
  * <xref:Microsoft.AspNetCore.Mvc.Filters.IResourceFilter.OnResourceExecuted%2A> runs code after the rest of the pipeline has completed.

* [Action filters](#action-filters):

  * Run code immediately before and after an action method is called.
  * Can change the arguments passed into an action.
  * Can change the result returned from the action.
  * Are **not** supported in Razor Pages.

* [Exception filters](#exception-filters) apply global policies to unhandled exceptions that occur before the response body has been written to.

* [Result filters](#result-filters) run code immediately before and after the execution of action results. They run only when the action method has executed successfully. They are useful for logic that must surround view or formatter execution.

The following diagram shows how filter types interact in the filter pipeline.

:::image source="filters/_static/filter-pipeline-2.png" alt-text="The request is processed through Authorization Filters, Resource Filters, Model Binding, Action Filters, Action Execution and Action Result Conversion, Exception Filters, Result Filters, and Result Execution. On the way out, the request is only processed by Result Filters and Resource Filters before becoming a response sent to the client.":::

## Implementation

Filters support both synchronous and asynchronous implementations through different interface definitions.

Synchronous filters run code before and after their pipeline stage. For example, <xref:Microsoft.AspNetCore.Mvc.Filters.IActionFilter.OnActionExecuting%2A> is called before the action method is called. <xref:Microsoft.AspNetCore.Mvc.Filters.IActionFilter.OnActionExecuted%2A> is called after the action method returns.

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Filters/MySampleActionFilter.cs" id="snippet_ActionFilter":::

In the preceding code, [MyDebug](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/mvc/controllers/filters/samples/3.x/FiltersSample/Helper/MyDebug.cs) is a utility function in the [sample download](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/mvc/controllers/filters/samples/3.x/FiltersSample/Helper/MyDebug.cs).

Asynchronous filters define an `On-Stage-ExecutionAsync` method. For example, <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter.OnActionExecutionAsync%2A>:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Filters/SampleAsyncActionFilter.cs" id="snippet":::

In the preceding code, the `SampleAsyncActionFilter` has an <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate> (`next`) that executes the action method.

### Multiple filter stages

Interfaces for multiple filter stages can be implemented in a single class. For example, the <xref:Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute> class implements:

* Synchronous: <xref:Microsoft.AspNetCore.Mvc.Filters.IActionFilter> and  <xref:Microsoft.AspNetCore.Mvc.Filters.IResultFilter>
* Asynchronous: <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter> and <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter>
* <xref:Microsoft.AspNetCore.Mvc.Filters.IOrderedFilter>

Implement **either** the synchronous or the async version of a filter interface, **not** both. The runtime checks first to see if the filter implements the async interface, and if so, it calls that. If not, it calls the synchronous interface's method(s). If both asynchronous and synchronous interfaces are implemented in one class, only the async method is called. When using abstract classes like <xref:Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute>, override only the synchronous methods or the asynchronous methods for each filter type.

### Built-in filter attributes

ASP.NET Core includes built-in attribute-based filters that can be subclassed and customized. For example, the following result filter adds a header to the response:

<a name="add-header-attribute"></a>

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Filters/AddHeaderAttribute.cs" id="snippet":::

Attributes allow filters to accept arguments, as shown in the preceding example. Apply the `AddHeaderAttribute` to a controller or action method and specify the name and value of the HTTP header:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Controllers/SampleController.cs" id="snippet_AddHeader" highlight="1":::

Use a tool such as the [browser developer tools](https://developer.mozilla.org/docs/Learn/Common_questions/What_are_browser_developer_tools) to examine the headers. Under **Response Headers**, `author: Rick Anderson` is displayed.

The following code implements an `ActionFilterAttribute` that:

* Reads the title and name from the configuration system. Unlike the previous sample, the following code doesn't require filter parameters to be added to the code.
* Adds the title and name to the response header.

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Filters/MyActionFilterAttribute.cs" id="snippet":::

The configuration options are provided from the [configuration system](xref:fundamentals/configuration/index) using the [options pattern](xref:fundamentals/configuration/options). For example, from the `appsettings.json` file:

:::code language="json" source="filters/samples/3.x/FiltersSample/appsettings.json":::

In the `StartUp.ConfigureServices`:

* The `PositionOptions` class is added to the service container with the `"Position"` configuration area.
* The `MyActionFilterAttribute` is added to the service container.

:::code language="csharp" source="filters/samples/3.x/FiltersSample/StartupAF.cs" id="snippet":::

The following code shows the `PositionOptions` class:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Helper/PositionOptions.cs" id="snippet":::

The following code applies the `MyActionFilterAttribute` to the `Index2` method:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Controllers/SampleController.cs" id="snippet2" highlight="9":::

Under **Response Headers**, `author: Rick Anderson`, and `Editor: Joe Smith` is displayed when the `Sample/Index2` endpoint is called.

The following code applies the `MyActionFilterAttribute` and the `AddHeaderAttribute` to the Razor Page:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Pages/Movies/Index.cshtml.cs" id="snippet":::

Filters cannot be applied to Razor Page handler methods. They can be applied either to the Razor Page model or globally.

Several of the filter interfaces have corresponding attributes that can be used as base classes for custom implementations.

Filter attributes:

* <xref:Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute>
* <xref:Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute>
* <xref:Microsoft.AspNetCore.Mvc.Filters.ResultFilterAttribute>
* <xref:Microsoft.AspNetCore.Mvc.FormatFilterAttribute>
* <xref:Microsoft.AspNetCore.Mvc.ServiceFilterAttribute>
* <xref:Microsoft.AspNetCore.Mvc.TypeFilterAttribute>

## Filter scopes and order of execution

A filter can be added to the pipeline at one of three *scopes*:

* Using an attribute on a controller action. Filter attributes cannot be applied to Razor Pages handler methods.
* Using an attribute on a controller or Razor Page.
* Globally for all controllers, actions, and Razor Pages as shown in the following code:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/StartupOrder.cs" id="snippet":::

### Default order of execution

When there are multiple filters for a particular stage of the pipeline, scope determines the default order of filter execution.  Global filters surround class filters, which in turn surround method filters.

As a result of filter nesting, the *after* code of filters runs in the reverse order of the *before* code. The filter sequence:

* The *before* code of global filters.
  * The *before* code of controller and Razor Page filters.
    * The *before* code of action method filters.
    * The *after* code of action method filters.
  * The *after* code of controller and Razor Page filters.
* The *after* code of global filters.

The following example that illustrates the order in which filter methods are called for synchronous action filters.

| Sequence | Filter scope             | Filter method       |
|:--------:|:------------------------:|:-------------------:|
| 1        | Global                   | `OnActionExecuting` |
| 2        | Controller or Razor Page | `OnActionExecuting` |
| 3        | Method                   | `OnActionExecuting` |
| 4        | Method                   | `OnActionExecuted`  |
| 5        | Controller or Razor Page | `OnActionExecuted`  |
| 6        | Global                   | `OnActionExecuted`  |

### Controller level filters

Every controller that inherits from the <xref:Microsoft.AspNetCore.Mvc.Controller> base class includes <xref:Microsoft.AspNetCore.Mvc.Controller.OnActionExecuting%2A?displayProperty=nameWithType>,  <xref:Microsoft.AspNetCore.Mvc.Controller.OnActionExecutionAsync%2A?displayProperty=nameWithType>, and <xref:Microsoft.AspNetCore.Mvc.Controller.OnActionExecuted%2A?displayProperty=nameWithType>
`OnActionExecuted` methods. These methods:

* Wrap the filters that run for a given action.
* `OnActionExecuting` is called before any of the action's filters.
* `OnActionExecuted` is called after all of the action filters.
* `OnActionExecutionAsync` is called before any of the action's filters. Code in the filter after `next` runs after the action method.

For example, in the download sample, `MySampleActionFilter` is applied globally in startup.

The `TestController`:

* Applies the `SampleActionFilterAttribute` (`[SampleActionFilter]`) to the `FilterTest2` action.
* Overrides `OnActionExecuting` and `OnActionExecuted`.

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Controllers/TestController.cs" id="snippet":::

[!INCLUDE[](~/includes/MyDisplayRouteInfo.md)]

<!-- test via  webBuilder.UseStartup<Startup>(); -->

Navigating to `https://localhost:5001/Test/FilterTest2` runs the following code:

* `TestController.OnActionExecuting`
  * `MySampleActionFilter.OnActionExecuting`
    * `SampleActionFilterAttribute.OnActionExecuting`
      * `TestController.FilterTest2`
    * `SampleActionFilterAttribute.OnActionExecuted`
  * `MySampleActionFilter.OnActionExecuted`
* `TestController.OnActionExecuted`

Controller level filters set the [Order](https://github.com/dotnet/AspNetCore/blob/main/src/Mvc/Mvc.Core/src/Filters/ControllerActionFilter.cs#L15-L17) property to `int.MinValue`. Controller level filters can **not** be set to run after filters applied to methods. Order is explained in the next section.

For Razor Pages, see [Implement Razor Page filters by overriding filter methods](xref:razor-pages/filter#implement-razor-page-filters-by-overriding-filter-methods).

### Overriding the default order

The default sequence of execution can be overridden by implementing <xref:Microsoft.AspNetCore.Mvc.Filters.IOrderedFilter>. `IOrderedFilter` exposes the <xref:Microsoft.AspNetCore.Mvc.Filters.IOrderedFilter.Order> property that takes precedence over scope to determine the order of execution. A filter with a lower `Order` value:

* Runs the *before* code before that of a filter with a higher value of `Order`.
* Runs the *after* code after that of a filter with a higher `Order` value.

The `Order` property is set with a constructor parameter:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Controllers/Test3Controller.cs" id="snippet":::

Consider the two action filters in the following controller:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Controllers/Test2Controller.cs" id="snippet":::

A global filter is added in `StartUp.ConfigureServices`:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/StartupOrder.cs" id="snippet":::

The 3 filters run in the following order:

* `Test2Controller.OnActionExecuting`
  * `MySampleActionFilter.OnActionExecuting`
    * `MyAction2FilterAttribute.OnActionExecuting`
      * `Test2Controller.FilterTest2`
    * `MyAction2FilterAttribute.OnResultExecuting`
  * `MySampleActionFilter.OnActionExecuted`
* `Test2Controller.OnActionExecuted`

The `Order` property overrides scope when determining the order in which filters run. Filters are sorted first by order, then scope is used to break ties. All of the built-in filters implement `IOrderedFilter` and set the default `Order` value to 0. As mentioned previously, controller level filters set the [Order](https://github.com/dotnet/AspNetCore/blob/main/src/Mvc/Mvc.Core/src/Filters/ControllerActionFilter.cs#L15-L17) property to `int.MinValue` For built-in filters, scope determines order unless `Order` is set to a non-zero value.

In the preceding code, `MySampleActionFilter` has global scope so it runs before `MyAction2FilterAttribute`, which has controller scope. To make `MyAction2FilterAttribute` run first, set the order to `int.MinValue`:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Controllers/Test2Controller.cs" id="snippet2":::

To make the global filter `MySampleActionFilter` run first, set `Order` to `int.MinValue`:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/StartupOrder2.cs" id="snippet" highlight="6":::

## Cancellation and short-circuiting

The filter pipeline can be short-circuited by setting the <xref:Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext.Result> property on the <xref:Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext> parameter provided to the filter method. For instance, the following Resource filter prevents the rest of the pipeline from executing:

<a name="short-circuiting-resource-filter"></a>

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Filters/ShortCircuitingResourceFilterAttribute.cs" id="snippet":::

In the following code, both the `ShortCircuitingResourceFilter` and the `AddHeader` filter target the `SomeResource` action method. The `ShortCircuitingResourceFilter`:

* Runs first, because it's a Resource Filter and `AddHeader` is an Action Filter.
* Short-circuits the rest of the pipeline.

Therefore the `AddHeader` filter never runs for the `SomeResource` action. This behavior would be the same if both filters were applied at the action method level, provided the `ShortCircuitingResourceFilter` ran first. The `ShortCircuitingResourceFilter` runs first because of its filter type, or by explicit use of `Order` property.

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Controllers/SampleController.cs" id="snippet3" highlight="1,15":::

## Dependency injection

Filters can be added by type or by instance. If an instance is added, that instance is used for every request. If a type is added, it's type-activated. A type-activated filter means:

* An instance is created for each request.
* Any constructor dependencies are populated by [dependency injection](xref:fundamentals/dependency-injection) (DI).

Filters that are implemented as attributes and added directly to controller classes or action methods cannot have constructor dependencies provided by [dependency injection](xref:fundamentals/dependency-injection) (DI). Constructor dependencies cannot be provided by DI because:

* Attributes must have their constructor parameters supplied where they're applied. 
* This is a limitation of how attributes work.

The following filters support constructor dependencies provided from DI:

* <xref:Microsoft.AspNetCore.Mvc.ServiceFilterAttribute>
* <xref:Microsoft.AspNetCore.Mvc.TypeFilterAttribute>
* <xref:Microsoft.AspNetCore.Mvc.Filters.IFilterFactory> implemented on the attribute.

The preceding filters can be applied to a controller or action method:

Loggers are available from DI. However, avoid creating and using filters purely for logging purposes. The [built-in framework logging](xref:fundamentals/logging/index) typically provides what's needed for logging. Logging added to filters:

* Should focus on business domain concerns or behavior specific to the filter.
* Should **not** log actions or other framework events. The built-in filters log actions and framework events.

### ServiceFilterAttribute

Service filter implementation types are registered in `ConfigureServices`. A <xref:Microsoft.AspNetCore.Mvc.ServiceFilterAttribute> retrieves an instance of the filter from DI.

The following code shows the `AddHeaderResultServiceFilter`:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Filters/LoggingAddHeaderFilter.cs" id="snippet_ResultFilter":::

In the following code, `AddHeaderResultServiceFilter` is added to the DI container:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Startup.cs" id="snippet" highlight="4":::

In the following code, the `ServiceFilter` attribute retrieves an instance of the `AddHeaderResultServiceFilter` filter from DI:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Controllers/HomeController.cs" id="snippet_ServiceFilter" highlight="1":::

When using `ServiceFilterAttribute`, setting <xref:Microsoft.AspNetCore.Mvc.ServiceFilterAttribute.IsReusable?displayProperty=nameWithType>:

* Provides a hint that the filter instance *may* be reused outside of the request scope it was created within. The ASP.NET Core runtime doesn't guarantee:

  * That a single instance of the filter will be created.
  * The filter will not be re-requested from the DI container at some later point.

* Should not be used with a filter that depends on services with a lifetime other than singleton.

 <xref:Microsoft.AspNetCore.Mvc.ServiceFilterAttribute> implements <xref:Microsoft.AspNetCore.Mvc.Filters.IFilterFactory>. `IFilterFactory` exposes the <xref:Microsoft.AspNetCore.Mvc.Filters.IFilterFactory.CreateInstance%2A> method for creating an <xref:Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata> instance. `CreateInstance` loads the specified type from DI.

### TypeFilterAttribute

<xref:Microsoft.AspNetCore.Mvc.TypeFilterAttribute> is similar to <xref:Microsoft.AspNetCore.Mvc.ServiceFilterAttribute>, but its type isn't resolved directly from the DI container. It instantiates the type by using <xref:Microsoft.Extensions.DependencyInjection.ObjectFactory?displayProperty=fullName>.

Because `TypeFilterAttribute` types aren't resolved directly from the DI container:

* Types that are referenced using the `TypeFilterAttribute` don't need to be registered with the DI container.  They do have their dependencies fulfilled by the DI container.
* `TypeFilterAttribute` can optionally accept constructor arguments for the type.

When using `TypeFilterAttribute`, setting <xref:Microsoft.AspNetCore.Mvc.TypeFilterAttribute.IsReusable?displayProperty=nameWithType>:
* Provides hint that the filter instance *may* be reused outside of the request scope it was created within. The ASP.NET Core runtime provides no guarantees that a single instance of the filter will be created.

* Should not be used with a filter that depends on services with a lifetime other than singleton.

The following example shows how to pass arguments to a type using `TypeFilterAttribute`:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Controllers/HomeController.cs" id="snippet_TypeFilter" highlight="1,2":::

<!-- 
https://localhost:5001/home/hi?name=joe
VS debug window shows 
FiltersSample.Filters.LogConstantFilter:Information: Method 'Hi' called
-->

## Authorization filters

Authorization filters:

* Are the first filters run in the filter pipeline.
* Control access to action methods.
* Have a before method, but no after method.

Custom authorization filters require a custom authorization framework. Prefer configuring the authorization policies or writing a custom authorization policy over writing a custom filter. The built-in authorization filter:

* Calls the authorization system.
* Does not authorize requests.

Do **not** throw exceptions within authorization filters:

* The exception will not be handled.
* Exception filters will not handle the exception.

Consider issuing a challenge when an exception occurs in an authorization filter.

Learn more about [Authorization](xref:security/authorization/introduction).

## Resource filters

Resource filters:

* Implement either the <xref:Microsoft.AspNetCore.Mvc.Filters.IResourceFilter> or <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncResourceFilter> interface.
* Execution wraps most of the filter pipeline.
* Only [Authorization filters](#authorization-filters) run before resource filters.

Resource filters are useful to short-circuit most of the pipeline. For example, a caching filter can avoid the rest of the pipeline on a cache hit.

Resource filter examples:

* [The short-circuiting resource filter](#short-circuiting-resource-filter) shown previously.
* [DisableFormValueModelBindingAttribute](https://github.com/aspnet/Entropy/blob/master/samples/Mvc.FileUpload/Filters/DisableFormValueModelBindingAttribute.cs):

  * Prevents model binding from accessing the form data.
  * Used for large file uploads to prevent the form data from being read into memory.

## Action filters

Action filters do **not** apply to Razor Pages. Razor Pages supports <xref:Microsoft.AspNetCore.Mvc.Filters.IPageFilter> and <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncPageFilter> . For more information, see [Filter methods for Razor Pages](xref:razor-pages/filter).

Action filters:

* Implement either the <xref:Microsoft.AspNetCore.Mvc.Filters.IActionFilter> or <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter> interface.
* Their execution surrounds the execution of action methods.

The following code shows a sample action filter:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Filters/MySampleActionFilter.cs" id="snippet_ActionFilter":::

The <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext> provides the following properties:

* <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext.ActionArguments> - enables reading the inputs to an action method.
* <xref:Microsoft.AspNetCore.Mvc.Controller> - enables manipulating the controller instance.
* <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext.Result%2A> - setting `Result` short-circuits execution of the action method and subsequent action filters.

Throwing an exception in an action method:

* Prevents running of subsequent filters.
* Unlike setting `Result`, is treated as a failure instead of a successful result.

The <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext> provides `Controller` and `Result` plus the following properties:

* <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext.Canceled%2A> - True if the action execution was short-circuited by another filter.
* <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext.Exception%2A> - Non-null if the action or a previously run action filter threw an exception. Setting this property to null:

  * Effectively handles the exception.
  * `Result` is executed as if it was returned from the action method.

For an `IAsyncActionFilter`, a call to the <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate>:

* Executes any subsequent action filters and the action method.
* Returns `ActionExecutedContext`.

To short-circuit, assign <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext.Result?displayProperty=fullName> to a result instance and don't call `next` (the `ActionExecutionDelegate`).

The framework provides an abstract <xref:Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute> that can be subclassed.

The `OnActionExecuting` action filter can be used to:

* Validate model state.
* Return an error if the state is invalid.

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Filters/ValidateModelAttribute.cs" id="snippet":::

> [!NOTE]
> Controllers annotated with the `[ApiController]` attribute automatically validate model state and return a 400 response. For more information, see [Automatic HTTP 400 responses](xref:web-api/index#automatic-http-400-responses).
The `OnActionExecuted` method runs after the action method:

* And can see and manipulate the results of the action through the <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext.Result> property.
* <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext.Canceled> is set to true if the action execution was short-circuited by another filter.
* <xref:Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext.Exception> is set to a non-null value if the action or a subsequent action filter threw an exception. Setting `Exception` to null:

  * Effectively handles an exception.
  * `ActionExecutedContext.Result` is executed as if it were returned normally from the action method.

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Filters/ValidateModelAttribute.cs" id="snippet2":::

## Exception filters

Exception filters:

* Implement <xref:Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter> or <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter>.
* Can be used to implement common error handling policies.

The following sample exception filter uses a custom error view to display details about exceptions that occur when the app is in development:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Filters/CustomExceptionFilter.cs" id="snippet_ExceptionFilter" highlight="16-19":::

The following code tests the exception filter:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Controllers/FailingController.cs" id="snippet":::

Exception filters:

* Don't have before and after events.
* Implement <xref:Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter.OnException%2A> or <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter.OnExceptionAsync%2A>.
* Handle unhandled exceptions that occur in Razor Page or controller creation, [model binding](xref:mvc/models/model-binding), action filters, or action methods.
* Do **not** catch exceptions that occur in resource filters, result filters, or MVC result execution.

To handle an exception, set the <xref:Microsoft.AspNetCore.Mvc.Filters.ExceptionContext.ExceptionHandled%2A> property to `true` or assign the <xref:Microsoft.AspNetCore.Mvc.Filters.ExceptionContext.Result%2A> property. This stops propagation of the exception. An exception filter can't turn an exception into a "success". Only an action filter can do that.

Exception filters:

* Are good for trapping exceptions that occur within actions.
* Are not as flexible as error handling middleware.

Prefer middleware for exception handling. Use exception filters only where error handling *differs* based on which action method is called. For example, an app might have action methods for both API endpoints and for views/HTML. The API endpoints could return error information as JSON, while the view-based actions could return an error page as HTML.

## Result filters

Result filters:

* Implement an interface:
  * <xref:Microsoft.AspNetCore.Mvc.Filters.IResultFilter> or <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter>
  * <xref:Microsoft.AspNetCore.Mvc.Filters.IAlwaysRunResultFilter> or <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncAlwaysRunResultFilter>
* Their execution surrounds the execution of action results.

### IResultFilter and IAsyncResultFilter

The following code shows a result filter that adds an HTTP header:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Filters/LoggingAddHeaderFilter.cs" id="snippet_ResultFilter":::

The kind of result being executed depends on the action. An action returning a view includes all razor processing as part of the <xref:Microsoft.AspNetCore.Mvc.ViewResult> being executed. An API method might perform some serialization as part of the execution of the result. Learn more about [action results](xref:mvc/controllers/actions).

Result filters are only executed when an action or action filter produces an action result. Result filters are not executed when:

* An authorization filter or resource filter short-circuits the pipeline.
* An exception filter handles an exception by producing an action result.

The <xref:Microsoft.AspNetCore.Mvc.Filters.IResultFilter.OnResultExecuting%2A?displayProperty=fullName> method can short-circuit execution of the action result and subsequent result filters by setting <xref:Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext.Cancel?displayProperty=fullName> to `true`. Write to the response object when short-circuiting to avoid generating an empty response. Throwing an exception in `IResultFilter.OnResultExecuting`:

* Prevents execution of the action result and subsequent filters.
* Is treated as a failure instead of a successful result.

When the <xref:Microsoft.AspNetCore.Mvc.Filters.IResultFilter.OnResultExecuted%2A?displayProperty=fullName> method runs, the response has probably already been sent to the client. If the response has already been sent to the client, it cannot be changed.

`ResultExecutedContext.Canceled` is set to `true` if the action result execution was short-circuited by another filter.

`ResultExecutedContext.Exception` is set to a non-null value if the action result or a subsequent result filter threw an exception. Setting `Exception` to null effectively handles an exception and prevents the exception from being thrown again later in the pipeline. There is no reliable way to write data to a response when handling an exception in a result filter. If the headers have been flushed to the client when an action result throws an exception, there's no reliable mechanism to send a failure code.

For an <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter>, a call to `await next` on the <xref:Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate> executes any subsequent result filters and the action result. To short-circuit, set <xref:Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext.Cancel?displayProperty=nameWithType> to `true` and don't call the `ResultExecutionDelegate`:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Filters/MyAsyncResponseFilter.cs" id="snippet":::

The framework provides an abstract `ResultFilterAttribute` that can be subclassed. The [AddHeaderAttribute](#add-header-attribute) class shown previously is an example of a result filter attribute.

### IAlwaysRunResultFilter and IAsyncAlwaysRunResultFilter

The <xref:Microsoft.AspNetCore.Mvc.Filters.IAlwaysRunResultFilter> and <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncAlwaysRunResultFilter> interfaces declare an <xref:Microsoft.AspNetCore.Mvc.Filters.IResultFilter> implementation that runs for all action results. This includes action results produced by:

* Authorization filters and resource filters that short-circuit.
* Exception filters.

For example, the following filter always runs and sets an action result (<xref:Microsoft.AspNetCore.Mvc.ObjectResult>) with a *422 Unprocessable Entity* status code when content negotiation fails:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Filters/UnprocessableResultFilter.cs" id="snippet":::

## IFilterFactory

<xref:Microsoft.AspNetCore.Mvc.Filters.IFilterFactory> implements <xref:Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata>. Therefore, an `IFilterFactory` instance can be used as an `IFilterMetadata` instance anywhere in the filter pipeline. When the runtime prepares to invoke the filter, it attempts to cast it to an `IFilterFactory`. If that cast succeeds, the <xref:Microsoft.AspNetCore.Mvc.Filters.IFilterFactory.CreateInstance%2A> method is called to create the `IFilterMetadata` instance that is invoked. This provides a flexible design, since the precise filter pipeline doesn't need to be set explicitly when the app starts.

`IFilterFactory.IsReusable`:

* Is a hint by the factory that the filter instance created by the factory may be reused outside of the request scope it was created within.
* Should ***not*** be used with a filter that depends on services with a lifetime other than singleton.

The ASP.NET Core runtime doesn't guarantee:

* That a single instance of the filter will be created.
* The filter will not be re-requested from the DI container at some later point.

> [!WARNING] 
> Only configure <xref:Microsoft.AspNetCore.Mvc.Filters.IFilterFactory.IsReusable?displayProperty=nameWithType> to return `true` if the source of the filters is unambiguous, the filters are stateless, and the filters are safe to use across multiple HTTP requests. For instance, don't return filters from DI that are registered as scoped or transient if `IFilterFactory.IsReusable` returns `true`.
`IFilterFactory` can be implemented using custom attribute implementations as another approach to creating filters:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Filters/AddHeaderWithFactoryAttribute.cs" id="snippet_IFilterFactory" highlight="1,4,5,6,7":::

The filter is applied in the following code:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Controllers/SampleController.cs" id="snippet3" highlight="21":::

Test the preceding code by running the [download sample](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/filters/samples):

* Invoke the F12 developer tools.
* Navigate to `https://localhost:5001/Sample/HeaderWithFactory`.

The F12 developer tools display the following response headers added by the sample code:

* **author:** `Rick Anderson`
* **globaladdheader:** `Result filter added to MvcOptions.Filters`
* **internal:** `My header`

The preceding code creates the **internal:** `My header` response header.

### IFilterFactory implemented on an attribute

<!-- Review 
This section needs to be rewritten.
What's a non-named attribute?
-->

Filters that implement `IFilterFactory` are useful for filters that:

* Don't require passing parameters.
* Have constructor dependencies that need to be filled by DI.

<xref:Microsoft.AspNetCore.Mvc.TypeFilterAttribute> implements <xref:Microsoft.AspNetCore.Mvc.Filters.IFilterFactory>. `IFilterFactory` exposes the <xref:Microsoft.AspNetCore.Mvc.Filters.IFilterFactory.CreateInstance%2A> method for creating an <xref:Microsoft.AspNetCore.Mvc.Filters.IFilterMetadata> instance. `CreateInstance` loads the specified type from the services container (DI).

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Filters/SampleActionFilterAttribute.cs" id="snippet_TypeFilterAttribute" highlight="1,3,8":::

The following code shows three approaches to applying the `[SampleActionFilter]`:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Controllers/HomeController.cs" id="snippet" highlight="1":::

In the preceding code, decorating the method with `[SampleActionFilter]` is the preferred approach to applying the `SampleActionFilter`.

## Using middleware in the filter pipeline

Resource filters work like [middleware](xref:fundamentals/middleware/index) in that they surround the execution of everything that comes later in the pipeline. But filters differ from middleware in that they're part of the runtime, which means that they have access to context and constructs.

To use middleware as a filter, create a type with a `Configure` method that specifies the middleware to inject into the filter pipeline. The following example uses the localization middleware to establish the current culture for a request:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Filters/LocalizationPipeline.cs" id="snippet_MiddlewareFilter" highlight="3,22":::

Use the <xref:Microsoft.AspNetCore.Mvc.MiddlewareFilterAttribute> to run the middleware:

:::code language="csharp" source="filters/samples/3.x/FiltersSample/Controllers/HomeController.cs" id="snippet_MiddlewareFilter" highlight="2":::

Middleware filters run at the same stage of the filter pipeline as Resource filters, before model binding and after the rest of the pipeline.

## Thread safety

When passing an *instance* of a filter into `Add`, instead of its `Type`, the filter is a singleton and is **not** thread-safe.

## Next actions

* See [Filter methods for Razor Pages](xref:razor-pages/filter).
* To experiment with filters, [download, test, and modify the GitHub sample](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/filters/samples).

:::moniker-end
