---
title: Filter methods for Razor Pages in ASP.NET Core
author: Rick-Anderson
description: Learn how to create filter methods for Razor Pages in ASP.NET Core.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.date: 2/18/2020
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: razor-pages/filter
---
# Filter methods for Razor Pages in ASP.NET Core

:::moniker range=">= aspnetcore-3.0"

By [Rick Anderson](https://twitter.com/RickAndMSFT)

Razor Page filters <xref:Microsoft.AspNetCore.Mvc.Filters.IPageFilter> and <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncPageFilter> allow Razor Pages to run code before and after a Razor Page handler is run. Razor Page filters are similar to [ASP.NET Core MVC action filters](xref:mvc/controllers/filters#action-filters), except they can't be applied to individual page handler methods.

Razor Page filters:

* Run code after a handler method has been selected, but before model binding occurs.
* Run code before the handler method executes, after model binding is complete.
* Run code after the handler method executes.
* Can be implemented on a page or globally.
* Cannot be applied to specific page handler methods.
* Can have constructor dependencies populated by [Dependency Injection](xref:fundamentals/dependency-injection) (DI). For more information, see [ServiceFilterAttribute](../mvc/controllers/filters.md#servicefilterattribute) and [TypeFilterAttribute](../mvc/controllers/filters.md#typefilterattribute).

While page constructors and middleware enable executing custom code before a handler method executes, only Razor Page filters enable access to <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel.HttpContext> and the page. Middleware has access to the `HttpContext`, but not to the "page context". Filters have a <xref:Microsoft.AspNetCore.Mvc.Filters.FilterContext> derived parameter, which provides access to `HttpContext`. Here's a sample for a page filter: [Implement a filter attribute](#ifa) that adds a header to the response, something that can't be done with constructors or middleware. Access to the page context, which includes access to the instances of the page and it's model, are only available when executing filters, handlers, or the body of a Razor Page.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/razor-pages/filter/3.1sample) ([how to download](xref:index#how-to-download-a-sample))

Razor Page filters provide the following methods, which can be applied globally or at the page level:

* Synchronous methods:

  * <xref:Microsoft.AspNetCore.Mvc.Filters.IPageFilter.OnPageHandlerSelected%2A> : Called after a handler method has been selected, but before model binding occurs.
  * <xref:Microsoft.AspNetCore.Mvc.Filters.IPageFilter.OnPageHandlerExecuting%2A> : Called before the handler method executes, after model binding is complete.
  * <xref:Microsoft.AspNetCore.Mvc.Filters.IPageFilter.OnPageHandlerExecuted%2A> : Called after the handler method executes, before the action result.

* Asynchronous methods:

  * <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncPageFilter.OnPageHandlerSelectionAsync%2A> : Called asynchronously after the handler method has been selected, but before model binding occurs.
  * <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncPageFilter.OnPageHandlerExecutionAsync%2A> : Called asynchronously before the handler method is invoked, after model binding is complete.

Implement **either** the synchronous or the async version of a filter interface, **not** both. The framework checks first to see if the filter implements the async interface, and if so, it calls that. If not, it calls the synchronous interface's method(s). If both interfaces are implemented, only the async methods are called. The same rule applies to overrides in pages, implement the synchronous or the async version of the override, not both.

## Implement Razor Page filters globally

The following code implements `IAsyncPageFilter`:

[!code-csharp[Main](filter/3.1sample/PageFilter/Filters/SampleAsyncPageFilter.cs?name=snippet1)]

In the preceding code, `ProcessUserAgent.Write` is user supplied code that works with the user agent string.

The following code enables the `SampleAsyncPageFilter` in the `Startup` class:

[!code-csharp[Main](filter/3.1sample/PageFilter/Startup.cs?name=snippet2)]

The following code calls <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.PageConventionCollection.AddFolderApplicationModelConvention*> to apply the `SampleAsyncPageFilter` to only pages in */Movies*:

[!code-csharp[Main](filter/3.1sample/PageFilter/Startup2.cs?name=snippet2)]

The following code implements the synchronous `IPageFilter`:

[!code-csharp[Main](filter/3.1sample/PageFilter/Filters/SamplePageFilter.cs?name=snippet1)]

The following code enables the `SamplePageFilter`:

[!code-csharp[Main](filter/3.1sample/PageFilter/StartupSync.cs?name=snippet2)]

## Implement Razor Page filters by overriding filter methods

The following code overrides the asynchronous Razor Page filters:

[!code-csharp[Main](filter/3.1sample/PageFilter/Pages/Index.cshtml.cs?name=snippet)]

<a name="ifa"></a>

## Implement a filter attribute

The built-in attribute-based filter <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter.OnResultExecutionAsync*> filter can be subclassed. The following filter adds a header to the response:

[!code-csharp[Main](filter/3.1sample/PageFilter/Filters/AddHeaderAttribute.cs)]

The following code applies the `AddHeader` attribute:

[!code-csharp[Main](filter/3.1sample/PageFilter/Pages/Movies/Test.cshtml.cs)]

Use a tool such as the browser developer tools to examine the headers. Under **Response Headers**, `author: Rick` is displayed.

See [Overriding the default order](xref:mvc/controllers/filters#overriding-the-default-order) for instructions on overriding the order.

See [Cancellation and short circuiting](xref:mvc/controllers/filters#cancellation-and-short-circuiting) for instructions to short-circuit the filter pipeline from a filter.

<a name="auth"></a>

## Authorize filter attribute

The [Authorize](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute can be applied to a `PageModel`:

[!code-csharp[Main](filter/sample/PageFilter/Pages/ModelWithAuthFilter.cshtml.cs?highlight=7)]

:::moniker-end

:::moniker range="< aspnetcore-3.0"

By [Rick Anderson](https://twitter.com/RickAndMSFT)

Razor Page filters <xref:Microsoft.AspNetCore.Mvc.Filters.IPageFilter> and <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncPageFilter> allow Razor Pages to run code before and after a Razor Page handler is run. Razor Page filters are similar to [ASP.NET Core MVC action filters](xref:mvc/controllers/filters#action-filters), except they can't be applied to individual page handler methods.

Razor Page filters:

* Run code after a handler method has been selected, but before model binding occurs.
* Run code before the handler method executes, after model binding is complete.
* Run code after the handler method executes.
* Can be implemented on a page or globally.
* Cannot be applied to specific page handler methods.

Code can be run before a handler method executes using the page constructor or middleware, but only Razor Page filters have access to <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel.HttpContext%2A>. Filters have a <xref:Microsoft.AspNetCore.Mvc.Filters.FilterContext> derived parameter, which provides access to `HttpContext`. For example, the [Implement a filter attribute](#ifa) sample adds a header to the response, something that can't be done with constructors or middleware.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/razor-pages/filter/sample/PageFilter) ([how to download](xref:index#how-to-download-a-sample))

Razor Page filters provide the following methods, which can be applied globally or at the page level:

* Synchronous methods:

  * <xref:Microsoft.AspNetCore.Mvc.Filters.IPageFilter.OnPageHandlerSelected%2A> : Called after a handler method has been selected, but before model binding occurs.
  * <xref:Microsoft.AspNetCore.Mvc.Filters.IPageFilter.OnPageHandlerExecuting%2A> : Called before the handler method executes, after model binding is complete.
  * <xref:Microsoft.AspNetCore.Mvc.Filters.IPageFilter.OnPageHandlerExecuted%2A> : Called after the handler method executes, before the action result.

* Asynchronous methods:

  * <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncPageFilter.OnPageHandlerSelectionAsync%2A> : Called asynchronously after the handler method has been selected, but before model binding occurs.
  * <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncPageFilter.OnPageHandlerExecutionAsync%2A> : Called asynchronously before the handler method is invoked, after model binding is complete.

> [!NOTE]
> Implement **either** the synchronous or the async version of a filter interface, not both. The framework checks first to see if the filter implements the async interface, and if so, it calls that. If not, it calls the synchronous interface's method(s). If both interfaces are implemented, only the async methods are called. The same rule applies to overrides in pages, implement the synchronous or the async version of the override, not both.

## Implement Razor Page filters globally

The following code implements `IAsyncPageFilter`:

[!code-csharp[Main](filter/sample/PageFilter/Filters/SampleAsyncPageFilter.cs?name=snippet1)]

In the preceding code, <xref:Microsoft.Extensions.Logging.ILogger> is not required. It's used in the sample to provide trace information for the application.

The following code enables the `SampleAsyncPageFilter` in the `Startup` class:

[!code-csharp[Main](filter/sample/PageFilter/Startup.cs?name=snippet2&highlight=11)]

The following code shows the complete `Startup` class:

[!code-csharp[Main](filter/sample/PageFilter/Startup.cs?name=snippet1)]

The following code calls `AddFolderApplicationModelConvention` to apply the `SampleAsyncPageFilter` to only pages in */subFolder*:

[!code-csharp[Main](filter/sample/PageFilter/Startup2.cs?name=snippet2)]

The following code implements the synchronous `IPageFilter`:

[!code-csharp[Main](filter/sample/PageFilter/Filters/SamplePageFilter.cs?name=snippet1)]

The following code enables the `SamplePageFilter`:

[!code-csharp[Main](filter/sample/PageFilter/StartupSync.cs?name=snippet2&highlight=11)]

## Implement Razor Page filters by overriding filter methods

The following code overrides the synchronous Razor Page filters:

[!code-csharp[Main](filter/sample/PageFilter/Pages/Index.cshtml.cs)]

<a name="ifa"></a>

## Implement a filter attribute

The built-in attribute-based filter <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter.OnResultExecutionAsync%2A> filter can be subclassed. The following filter adds a header to the response:

[!code-csharp[Main](filter/sample/PageFilter/Filters/AddHeaderAttribute.cs)]

The following code applies the `AddHeader` attribute:

[!code-csharp[Main](filter/sample/PageFilter/Pages/Contact.cshtml.cs?name=snippet1)]

See [Overriding the default order](xref:mvc/controllers/filters#overriding-the-default-order) for instructions on overriding the order.

See [Cancellation and short circuiting](xref:mvc/controllers/filters#cancellation-and-short-circuiting) for instructions to short-circuit the filter pipeline from a filter. 

<a name="auth"></a>

## Authorize filter attribute

The [Authorize](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute can be applied to a `PageModel`:

[!code-csharp[Main](filter/sample/PageFilter/Pages/ModelWithAuthFilter.cshtml.cs?highlight=7)]

:::moniker-end
