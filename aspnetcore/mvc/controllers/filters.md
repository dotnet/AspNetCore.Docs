---
title: Filters in ASP.NET Core
author: ardalis
description: Learn how filters work and how to use them in ASP.NET Core MVC.
ms.author: riande
ms.date: 08/15/2018
uid: mvc/controllers/filters
---
# Filters in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT), [Tom Dykstra](https://github.com/tdykstra/), and [Steve Smith](https://ardalis.com/)

*Filters* in ASP.NET Core MVC allow you to run code before or after specific stages in the request processing pipeline.

> [!IMPORTANT]
> This topic does **not** apply to Razor Pages. ASP.NET Core 2.1 and later supports [IPageFilter](/dotnet/api/microsoft.aspnetcore.mvc.filters.ipagefilter?view=aspnetcore-2.0) and [IAsyncPageFilter](/dotnet/api/microsoft.aspnetcore.mvc.filters.iasyncpagefilter?view=aspnetcore-2.0) for Razor Pages. For more information, see [Filter methods for Razor Pages](xref:razor-pages/filter).

 Built-in filters handle tasks such as:

 * Authorization (preventing access to resources a user isn't authorized for).
 * Ensuring that all requests use HTTPS.
 * Response caching (short-circuiting the request pipeline to return a cached response). 

Custom filters can be created to handle cross-cutting concerns. Filters can avoid duplicating code across actions. For example, an error handling exception filter could consolidate error handling.

[View or download sample from GitHub](https://github.com/aspnet/Docs/tree/master/aspnetcore/mvc/controllers/filters/sample).

## How do filters work?

Filters run within the *MVC action invocation pipeline*, sometimes referred to as the *filter pipeline*.  The filter pipeline runs after MVC selects the action to execute.

![The request is processed through Other Middleware, Routing Middleware, Action Selection, and the MVC Action Invocation Pipeline. The request processing continues back through Action Selection, Routing Middleware, and various Other Middleware before becoming a response sent to the client.](filters/_static/filter-pipeline-1.png)

### Filter types

Each filter type is executed at a different stage in the filter pipeline.

* [Authorization filters](#authorization-filters) run first and are used to determine whether the current user is authorized for the current request. They can short-circuit the pipeline if a request is unauthorized. 

* [Resource filters](#resource-filters) are the first to handle a request after authorization.  They can run code before the rest of the filter pipeline, and after the rest of the pipeline has completed. They're useful to implement caching or otherwise short-circuit the filter pipeline for performance reasons. They run before model binding, so they can influence model binding.

* [Action filters](#action-filters) can run code immediately before and after an individual action method is called. They can be used to manipulate the arguments passed into an action and the result returned from the action.

* [Exception filters](#exception-filters) are used to apply global policies to unhandled exceptions that occur before anything has been written to the response body.

* [Result filters](#result-filters) can run code immediately before and after the execution of individual action results. They run only when the action method has executed successfully. They are useful for logic that must surround view or formatter execution.

The following diagram shows how these filter types interact in the filter pipeline.

![The request is processed through Authorization Filters, Resource Filters, Model Binding, Action Filters, Action Execution and Action Result Conversion, Exception Filters, Result Filters, and Result Execution. On the way out, the request is only processed by Result Filters and Resource Filters before becoming a response sent to the client.](filters/_static/filter-pipeline-2.png)

## Implementation

Filters support both synchronous and asynchronous implementations through different interface definitions. 

Synchronous filters that can run code both before and after their pipeline stage define On*Stage*Executing and On*Stage*Executed methods. For example, `OnActionExecuting` is called before the action method is called, and `OnActionExecuted` is called after the action method returns.

[!code-csharp[](./filters/sample/src/FiltersSample/Filters/SampleActionFilter.cs?name=snippet1)]

Asynchronous filters define a single On*Stage*ExecutionAsync method. This method takes a *FilterType*ExecutionDelegate delegate which executes the filter's pipeline stage. For example, `ActionExecutionDelegate` calls the action method or next action filter, and you can execute code before and after you call it.

[!code-csharp[](./filters/sample/src/FiltersSample/Filters/SampleAsyncActionFilter.cs?highlight=6,8-10,13)]

You can implement interfaces for multiple filter stages in a single class. For example, the [ActionFilterAttribute](/dotnet/api/microsoft.aspnetcore.mvc.filters.actionfilterattribute?view=aspnetcore-2.0) class implements `IActionFilter`, `IResultFilter`, and their async equivalents.

> [!NOTE]
> Implement **either** the synchronous or the async version of a filter interface, not both. The framework checks first to see if the filter implements the async interface, and if so, it calls that. If not, it calls the synchronous interface's method(s). If you were to implement both interfaces on one class, only the async method would be called. When using abstract classes like [ActionFilterAttribute](/dotnet/api/microsoft.aspnetcore.mvc.filters.actionfilterattribute?view=aspnetcore-2.0) you would override only the synchronous methods or the async method for each filter type.

### IFilterFactory

[IFilterFactory](/dotnet/api/microsoft.aspnetcore.mvc.filters.ifilterfactory) implements [IFilterMetadata](/dotnet/api/microsoft.aspnetcore.mvc.filters.ifiltermetadata). Therefore, an `IFilterFactory` instance can be used as an `IFilterMetadata` instance anywhere in the filter pipeline. When the framework prepares to invoke the filter, it attempts to cast it to an `IFilterFactory`. If that cast succeeds, the [CreateInstance](/dotnet/api/microsoft.aspnetcore.mvc.filters.ifilterfactory.createinstance) method is called to create the `IFilterMetadata` instance that will be invoked. This provides a flexible design, since the precise filter pipeline doesn't need to be set explicitly when the app starts.

You can implement `IFilterFactory` on your own attribute implementations as another approach to creating filters:

[!code-csharp[](./filters/sample/src/FiltersSample/Filters/AddHeaderWithFactoryAttribute.cs?name=snippet_IFilterFactory&highlight=1,4,5,6,7)]

### Built-in filter attributes

The framework includes built-in attribute-based filters that you can subclass and customize. For example, the following Result filter adds a header to the response.

<a name="add-header-attribute"></a>

[!code-csharp[](./filters/sample/src/FiltersSample/Filters/AddHeaderAttribute.cs?highlight=5,16)]

Attributes allow filters to accept arguments, as shown in the example above. You would add this attribute to a controller or action method and specify the name and value of the HTTP header:

[!code-csharp[](./filters/sample/src/FiltersSample/Controllers/SampleController.cs?name=snippet_AddHeader&highlight=1)]

The result of the `Index` action is shown below - the response headers are displayed on the bottom right.

![Developer Tools of Microsoft Edge showing response headers, including Author Steve Smith @ardalis](filters/_static/add-header.png)

Several of the filter interfaces have corresponding attributes that can be used as base classes for custom implementations.

Filter attributes:

* `ActionFilterAttribute`
* `ExceptionFilterAttribute`
* `ResultFilterAttribute`
* `FormatFilterAttribute`
* `ServiceFilterAttribute`
* `TypeFilterAttribute`

`TypeFilterAttribute` and `ServiceFilterAttribute` are explained [later in this article](#dependency-injection).

## Filter scopes and order of execution

A filter can be added to the pipeline at one of three *scopes*. You can add a filter to a particular action method or to a controller class by using an attribute. Or you can register a filter globally for all controllers and actions. Filters are added globally by adding it to the `MvcOptions.Filters` collection in `ConfigureServices`:

[!code-csharp[](./filters/sample/src/FiltersSample/Startup.cs?name=snippet_ConfigureServices&highlight=5-8)]

### Default order of execution

When there are multiple filters for a particular stage of the pipeline, scope determines the default order of filter execution.  Global filters surround class filters, which in turn surround method filters. This is sometimes referred to as "Russian doll" nesting, as each increase in scope is wrapped around the previous scope, like a [nesting doll](https://wikipedia.org/wiki/Matryoshka_doll). You generally get the desired overriding behavior without having to explicitly determine ordering.

As a result of this nesting, the *after* code of filters runs in the reverse order of the *before* code. The sequence looks like this:

* The *before* code of filters applied globally
  * The *before* code of filters applied to controllers
    * The *before* code of filters applied to action methods
    * The *after* code of filters applied to action methods
  * The *after* code of filters applied to controllers
* The *after* code of filters applied globally
  
Here's an example that illustrates the order in which filter methods are called for synchronous Action filters.

| Sequence | Filter scope | Filter method |
|:--------:|:------------:|:-------------:|
| 1 | Global | `OnActionExecuting` |
| 2 | Controller | `OnActionExecuting` |
| 3 | Method | `OnActionExecuting` |
| 4 | Method | `OnActionExecuted` |
| 5 | Controller | `OnActionExecuted` |
| 6 | Global | `OnActionExecuted` |

This sequence shows:

* The method filter is nested within the controller filter.
* The controller filter is nested within the global filter. 

To put it another way, if you're inside an async filter's On*Stage*ExecutionAsync method, all of the filters with a tighter scope run while your code is on the stack.

> [!NOTE]
> Every controller that inherits from the `Controller` base class includes `OnActionExecuting` and `OnActionExecuted` methods. These methods wrap the filters that run for a given action:  `OnActionExecuting` is called before any of the filters, and `OnActionExecuted` is called after all of the filters.

### Overriding the default order

You can override the default sequence of execution by implementing `IOrderedFilter`. This interface exposes an `Order` property that takes precedence over scope to determine the order of execution. A filter with a lower `Order` value will have its *before* code executed before that of a filter with a higher value of `Order`. A filter with a lower `Order` value will have its *after* code executed after that of a filter with a higher `Order` value. 
You can set the `Order` property by using a constructor parameter:

```csharp
[MyFilter(Name = "Controller Level Attribute", Order=1)]
```

If you have the same 3 Action filters shown in the preceding example but set the `Order` property of the controller and global filters to 1 and 2 respectively, the order of execution would be reversed.

| Sequence | Filter scope | `Order` property | Filter method |
|:--------:|:------------:|:-----------------:|:-------------:|
| 1 | Method | 0 | `OnActionExecuting` |
| 2 | Controller | 1  | `OnActionExecuting` |
| 3 | Global | 2  | `OnActionExecuting` |
| 4 | Global | 2  | `OnActionExecuted` |
| 5 | Controller | 1  | `OnActionExecuted` |
| 6 | Method | 0  | `OnActionExecuted` |

The `Order` property trumps scope when determining the order in which filters will run. Filters are sorted first by order, then scope is used to break ties. All of the built-in filters implement `IOrderedFilter` and set the default `Order` value to 0. For built-in filters, scope determines order unless you set `Order` to a non-zero value.

## Cancellation and short circuiting

You can short-circuit the filter pipeline at any point by setting the `Result` property on the `context` parameter provided to the filter method. For instance, the following Resource filter prevents the rest of the pipeline from executing.

<a name="short-circuiting-resource-filter"></a>

[!code-csharp[](./filters/sample/src/FiltersSample/Filters/ShortCircuitingResourceFilterAttribute.cs?highlight=12,13,14,15)]

In the following code, both the `ShortCircuitingResourceFilter` and the `AddHeader` filter target the `SomeResource` action method. The `ShortCircuitingResourceFilter`:

* Runs first, because it's a Resource Filter and `AddHeader` is an Action Filter.
* Short-circuits the rest of the pipeline.

Therefore the `AddHeader` filter never runs for the `SomeResource` action. This behavior would be the same if both filters were applied at the action method level, provided the `ShortCircuitingResourceFilter` ran first. The `ShortCircuitingResourceFilter` runs first because of its filter type, or by explicit use of `Order` property.

[!code-csharp[](./filters/sample/src/FiltersSample/Controllers/SampleController.cs?name=snippet_AddHeader&highlight=1,9)]

## Dependency injection

Filters can be added by type or by instance. If you add an instance, that instance will be used for every request. If you add a type, it will be type-activated, meaning an instance will be created for each request and any constructor dependencies will be populated by [dependency injection](../../fundamentals/dependency-injection.md) (DI). Adding a filter by type is equivalent to `filters.Add(new TypeFilterAttribute(typeof(MyFilter)))`.

Filters that are implemented as attributes and added directly to controller classes or action methods cannot have constructor dependencies provided by [dependency injection](../../fundamentals/dependency-injection.md) (DI). This is because attributes must have their constructor parameters supplied where they're applied. This is a limitation of how attributes work.

If your filters have dependencies that you need to access from DI, there are several supported approaches. You can apply your filter to a class or action method using one of the following:

* `ServiceFilterAttribute`
* `TypeFilterAttribute`
* `IFilterFactory` implemented on your attribute

> [!NOTE]
> One dependency you might want to get from DI is a logger. However, avoid creating and using filters purely for logging purposes, since the [built-in framework logging features](xref:fundamentals/logging/index) may already provide what you need. If you're going to add logging to your filters, it should focus on business domain concerns or behavior specific to your filter, rather than MVC actions or other framework events.

### ServiceFilterAttribute

A `ServiceFilter` retrieves an instance of the filter from DI. You add the filter to the container in `ConfigureServices`, and reference it in a `ServiceFilter` attribute

[!code-csharp[](./filters/sample/src/FiltersSample/Startup.cs?name=snippet_ConfigureServices&highlight=11)]

[!code-csharp[](../../mvc/controllers/filters/sample/src/FiltersSample/Controllers/HomeController.cs?name=snippet_ServiceFilter&highlight=1)]

Using `ServiceFilter` without registering the filter type results in an exception:

```
System.InvalidOperationException: No service for type
'FiltersSample.Filters.AddHeaderFilterWithDI' has been registered.
```

`ServiceFilterAttribute` implements `IFilterFactory`. `IFilterFactory` exposes the `CreateInstance` method for creating an `IFilterMetadata` instance. The `CreateInstance` method loads the specified type from the services container (DI).

### TypeFilterAttribute

`TypeFilterAttribute` is similar to `ServiceFilterAttribute`, but its type isn't resolved directly from the DI container. It instantiates the type by using `Microsoft.Extensions.DependencyInjection.ObjectFactory`.

Because of this difference:

* Types that are referenced using the `TypeFilterAttribute` don't need to be registered with the container first.  They do have their dependencies fulfilled by the container. 
* `TypeFilterAttribute` can optionally accept constructor arguments for the type. 

The following example demonstrates how to pass arguments to a type using `TypeFilterAttribute`:

[!code-csharp[](../../mvc/controllers/filters/sample/src/FiltersSample/Controllers/HomeController.cs?name=snippet_TypeFilter&highlight=1,2)]

If you have a filter that:

* Doesn't require any arguments.
* Has constructor dependencies that need to be filled by DI.

You can use your own named attribute on classes and methods instead of `[TypeFilter(typeof(FilterType))]`). The following filter shows how this can be implemented:

[!code-csharp[](./filters/sample/src/FiltersSample/Filters/SampleActionFilterAttribute.cs?name=snippet_TypeFilterAttribute&highlight=1,3,7)]

This filter can be applied to classes or methods using the `[SampleActionFilter]` syntax, instead of having to use `[TypeFilter]` or `[ServiceFilter]`.

## Authorization filters

*Authorization filters:
* Control access to action methods.
* Are the first filters to be executed within the filter pipeline. 
* Have a before method, but no after method. 

You should only write a custom authorization filter if you are writing your own authorization framework. Prefer configuring your authorization policies or writing a custom authorization policy over writing a custom filter. The built-in filter implementation is just responsible for calling the authorization system.

You shouldn't throw exceptions within authorization filters, since nothing will handle the exception (exception filters won't handle them). Consider issuing a challenge when an exception occurs.

Learn more about [Authorization](../../security/authorization/index.md).

## Resource filters

* Implement either the `IResourceFilter` or `IAsyncResourceFilter` interface,
* Their execution wraps most of the filter pipeline. 
* Only [Authorization filters](#authorization-filters) run before Resource filters.

Resource filters are useful to short-circuit most of the work a request is doing. For example, a caching filter can avoid the rest of the pipeline if the response is in the cache.

The [short circuiting resource filter](#short-circuiting-resource-filter) shown earlier is one example of a resource filter. Another example is [DisableFormValueModelBindingAttribute](https://github.com/aspnet/Entropy/blob/rel/1.1.1/samples/Mvc.FileUpload/Filters/DisableFormValueModelBindingAttribute.cs):

* It prevents model binding from accessing the form data. 
* It's useful for large file uploads and want to prevent the form from being read into memory.

## Action filters

*Action filters*:

* Implement either the `IActionFilter` or `IAsyncActionFilter` interface.
* Their execution surrounds the execution of action methods.

Here's a sample action filter:

[!code-csharp[](./filters/sample/src/FiltersSample/Filters/SampleActionFilter.cs?name=snippet_ActionFilter)]

The [ActionExecutingContext](/dotnet/api/microsoft.aspnetcore.mvc.filters.actionexecutingcontext) provides the following properties:

* `ActionArguments` - lets you manipulate the inputs to the action.
* `Controller` - lets you manipulate the controller instance. 
* `Result` - setting this short-circuits execution of the action method and subsequent action filters. Throwing an exception also prevents execution of the action method and subsequent filters, but is treated as a failure instead of a successful result.

The [ActionExecutedContext](/dotnet/api/microsoft.aspnetcore.mvc.filters.actionexecutedcontext) provides `Controller` and `Result` plus the following properties:

* `Canceled` - will be true if the action execution was short-circuited by another filter.
* `Exception` - will be non-null if the action or a subsequent action filter threw an exception. Setting this property to null effectively 'handles' an exception, and `Result` will be executed as if it were returned from the action method normally.

For an `IAsyncActionFilter`, a call to the `ActionExecutionDelegate`:

* Executes any subsequent action filters and the action method.
* returns `ActionExecutedContext`. 

To short-circuit, assign `ActionExecutingContext.Result` to some result instance and don't call the `ActionExecutionDelegate`.

The framework provides an abstract `ActionFilterAttribute` that you can subclass. 

You can use an action filter to validate model state and return any errors if the state is invalid:

[!code-csharp[](./filters/sample/src/FiltersSample/Filters/ValidateModelAttribute.cs)]

The `OnActionExecuted` method runs after the action method and can see and manipulate the results of the action through the `ActionExecutedContext.Result` property. `ActionExecutedContext.Canceled` will be set to true if the action execution was short-circuited by another filter. `ActionExecutedContext.Exception` will be set to a non-null value if the action or a subsequent action filter threw an exception. Setting `ActionExecutedContext.Exception` to null:

* Effectively 'handles' an exception.
* `ActionExectedContext.Result` is executed as if it were returned normally from the action method.

## Exception filters

*Exception filters* implement either the `IExceptionFilter` or `IAsyncExceptionFilter` interface. They can be used to implement common error handling policies for an app. 

The following sample exception filter uses a custom developer error view to display details about exceptions that occur when the app is in development:

[!code-csharp[](./filters/sample/src/FiltersSample/Filters/CustomExceptionFilterAttribute.cs?name=snippet_ExceptionFilter&highlight=1,14)]

Exception filters:

* Don't have before and after events. 
* Implement `OnException` or `OnExceptionAsync`. 
* Handle unhandled exceptions that occur in controller creation, [model binding](../models/model-binding.md), action filters, or action methods. 
* Do not catch exceptions that occur in Resource filters, Result filters, or MVC Result execution.

To handle an exception, set the `ExceptionContext.ExceptionHandled` property to true or write a response. This stops propagation of the exception. An Exception filter can't turn an exception into a "success". Only an Action filter can do that.

> [!NOTE]
> In ASP.NET Core 1.1, the response isn't sent if you set `ExceptionHandled` to true **and** write a response. In that scenario, ASP.NET Core 1.0 does send the response, and ASP.NET Core 1.1.2 will return to the 1.0 behavior. For more information, see [issue #5594](https://github.com/aspnet/Mvc/issues/5594) in the GitHub repository. 

Exception filters:

* Are good for trapping exceptions that occur within MVC actions.
* Are not as flexible as error handling middleware. 

Prefer middleware for exception handling. Use exception filters only where you need to do error handling *differently* based on which MVC action was chosen. For example, your app might have action methods for both API endpoints and for views/HTML. The API endpoints could return error information as JSON, while the view-based actions could return an error page as HTML.

The `ExceptionFilterAttribute` can be subclassed. 

## Result filters

* Implement either the `IResultFilter` or `IAsyncResultFilter` interface.
* Their execution surrounds the execution of action results. 

Here's an example of a Result filter that adds an HTTP header.

[!code-csharp[](./filters/sample/src/FiltersSample/Filters/LoggingAddHeaderFilter.cs?name=snippet_ResultFilter)]

The kind of result being executed depends on the action in question. An MVC action returning a view would include all razor processing as part of the `ViewResult` being executed. An API method might perform some serialization as part of the execution of the result. Learn more about [action results](actions.md)

Result filters are only executed for successful results - when the action or action filters produce an action result. Result filters are not executed when exception filters handle an exception.

The `OnResultExecuting` method can short-circuit execution of the action result and subsequent result filters by setting `ResultExecutingContext.Cancel` to true. You should generally write to the response object when short-circuiting to avoid generating an empty response. Throwing an exception will:

* Prevent execution of the action result and subsequent filters.
* Be treated as a failure instead of a successful result.

When the `OnResultExecuted` method runs, the response has likely been sent to the client and cannot be changed further (unless an exception was thrown). `ResultExecutedContext.Canceled` will be set to true if the action result execution was short-circuited by another filter.

`ResultExecutedContext.Exception` will be set to a non-null value if the action result or a subsequent result filter threw an exception. Setting `Exception` to null effectively 'handles' an exception and prevents the exception from being rethrown by MVC later in the pipeline. When you're handling an exception in a result filter, you might not be able to write any data to the response. If the action result throws partway through its execution, and the headers have already been flushed to the client, there's no reliable mechanism to send a failure code.

For an `IAsyncResultFilter` a call to `await next` on the `ResultExecutionDelegate` executes any subsequent result filters and the action result. To short-circuit, set `ResultExecutingContext.Cancel` to true and don't call the `ResultExectionDelegate`.

The framework provides an abstract `ResultFilterAttribute` that you can subclass. The [AddHeaderAttribute](#add-header-attribute) class shown earlier is an example of a result filter attribute.

## Using middleware in the filter pipeline

Resource filters work like [middleware](xref:fundamentals/middleware/index) in that they surround the execution of everything that comes later in the pipeline. But filters differ from middleware in that they're part of MVC, which means that they have access to MVC context and constructs.

In ASP.NET Core 1.1, you can use middleware in the filter pipeline. You might want to do that if you have a middleware component that needs access to MVC route data, or one that should run only for certain controllers or actions.

To use middleware as a filter, create a type with a `Configure` method that specifies the middleware that you want to inject into the filter pipeline. Here's an example that uses the localization middleware to establish the current culture for a request:

[!code-csharp[](./filters/sample/src/FiltersSample/Filters/LocalizationPipeline.cs?name=snippet_MiddlewareFilter&highlight=3,21)]

You can then use the `MiddlewareFilterAttribute` to run the middleware for a selected controller or action or globally:

[!code-csharp[](./filters/sample/src/FiltersSample/Controllers/HomeController.cs?name=snippet_MiddlewareFilter&highlight=2)]

Middleware filters run at the same stage of the filter pipeline as Resource filters, before model binding and after the rest of the pipeline.

## Next actions

To experiment with filters, [download, test and modify the sample](https://github.com/aspnet/Docs/tree/master/aspnetcore/mvc/controllers/filters/sample).
