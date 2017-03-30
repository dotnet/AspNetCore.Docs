---
uid: web-api/overview/error-handling/web-api-global-error-handling
title: "Global Error Handling in ASP.NET Web API 2 | Microsoft Docs"
author: davidmatson
description: ""
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/03/2014
ms.topic: article
ms.assetid: bffd7863-f63b-4b23-a13c-372b5492e9fb
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/error-handling/web-api-global-error-handling
msc.type: authoredcontent
---
Global Error Handling in ASP.NET Web API 2
====================
by [David Matson](https://github.com/davidmatson), [Rick Anderson](https://github.com/Rick-Anderson)

Today there's no easy way in Web API to log or handle errors globally. Some unhandled exceptions can be processed via [exception filters](exception-handling.md), but there are a number of cases that exception filters can't handle. For example:

1. Exceptions thrown from controller constructors.
2. Exceptions thrown from message handlers.
3. Exceptions thrown during routing.
4. Exceptions thrown during response content serialization .

We want to provide a simple, consistent way to log and handle (where possible) these exceptions. 

There are two major cases for handling exceptions, the case where we are able to send an error response and the case where all we can do is log the exception. An example for the latter case is when an exception is thrown in the middle of streaming response content; in that case it is too late to send a new response message since the status code, headers, and partial content have already gone across the wire, so we simply abort the connection. Even though the exception can't be handled to produce a new response message, we still support logging the exception. In cases where we can detect an error, we can return an appropriate error response as shown in the following:

[!code-csharp[Main](web-api-global-error-handling/samples/sample1.cs?highlight=6)]

### Existing Options

In addition to [exception filters](exception-handling.md), [message handlers](../advanced/http-message-handlers.md) can be used today to observe all 500-level responses, but acting on those responses is difficult, as they lack context about the original error. Message handlers also have some of the same limitations as exception filters regarding the cases they can handle.While Web API does have tracing infrastructure that captures error conditions the tracing infrastructure is for diagnostics purposes and is not designed or suited for running in production environments. Global exception handling and logging should be services that can run during production and be plugged into existing monitoring solutions (for example, [ELMAH](https://code.google.com/p/elmah/) ).

### Solution Overview

 We provide two new user-replaceable services, [IExceptionLogger](../releases/whats-new-in-aspnet-web-api-21.md) and IExceptionHandler, to log and handle unhandled exceptions. The services are very similar, with two main differences:

1. We support registering multiple exception loggers but only a single exception handler.
2. Exception loggers always get called, even if we're about to abort the connection. Exception handlers only get called when we're still able to choose which response message to send.

Both services provide access to an exception context containing relevant information from the point where the exception was detected, particularly the [HttpRequestMessage](https://msdn.microsoft.com/en-us/library/system.net.http.httprequestmessage(v=vs.110).aspx), the [HttpRequestContext](https://msdn.microsoft.com/en-us/library/system.web.http.controllers.httprequestcontext(v=vs.118).aspx), the thrown exception and the exception source (details below).

### Design Principles

1. **No breaking changes** Because this functionality is being added in a minor release, one important constraint impacting the solution is that there be no breaking changes, either to type contracts or to behavior. This constraint ruled out some cleanup we would like to have done in terms of existing catch blocks turning exceptions into 500 responses. This additional cleanup is something we might consider for a subsequent major release. If this is important to you please vote on it at [ASP.NET Web API user voice](http://aspnet.uservoice.com/forums/147201-asp-net-web-api/suggestions/5451321-add-flag-to-enable-iexceptionlogger-and-iexception).
2. **Maintaining consistency with Web API constructs** Web API's filter pipeline is a great way to handle cross-cutting concerns with the flexibility of applying the logic at an action-specific, controller-specific or global scope. Filters, including exception filters, always have action and controller contexts, even when registered at the global scope. That contract makes sense for filters, but it means that exception filters, even globally scoped ones, aren't a good fit for some exception handling cases, such as exceptions from message handlers, where no action or controller context exists. If we want to use the flexible scoping afforded by filters for exception handling, we still need exception filters. But if we need to handle exception outside of a controller context, we also need a separate construct for full global error handling (something without the controller context and action context constraints).

### When to Use

- Exception loggers are the solution to seeing all unhandled exception caught by Web API.
- Exception handlers are the solution for customizing all possible responses to unhandled exceptions caught by Web API.
- Exception filters are the easiest solution for processing the subset unhandled exceptions related to a specific action or controller.

### Service Details

 The exception logger and handler service interfaces are simple async methods taking the respective contexts: 

[!code-csharp[Main](web-api-global-error-handling/samples/sample2.cs)]

 We also provide base classes for both of these interfaces. Overriding the core (sync or async) methods is all that is required to log or handle at the recommended times. For logging, the `ExceptionLogger` base class will ensure that the core logging method is only called once for each exception (even if it later propagates further up the call stack and is caught again). The `ExceptionHandler` base class will call the core handling method only for exceptions at the top of the call stack, ignoring legacy nested catch blocks. (Simplified versions of these base classes are in the appendix below.) Both `IExceptionLogger` and `IExceptionHandler` receive information about the exception via an `ExceptionContext`.

[!code-csharp[Main](web-api-global-error-handling/samples/sample3.cs)]

When the framework calls an exception logger or an exception handler, it will always provide an `Exception` and a `Request`. Except for unit testing, it will also always provide a `RequestContext`. It will rarely provide a `ControllerContext` and `ActionContext` (only when calling from the catch block for exception filters). It will very rarely provide a `Response`(only in certain IIS cases when in the middle of trying to write the response). Note that because some of these properties may be `null` it is up to the consumer to check for `null` before accessing members of the exception class.`CatchBlock` is a string indicating which catch block saw the exception. The catch block strings are as follows:

- HttpServer (SendAsync method)
- HttpControllerDispatcher (SendAsync method)
- HttpBatchHandler (SendAsync method)
- IExceptionFilter (ApiController's processing of the exception filter pipeline in ExecuteAsync)
- OWIN host:

    - HttpMessageHandlerAdapter.BufferResponseContentAsync (for buffering output)
    - HttpMessageHandlerAdapter.CopyResponseContentAsync (for streaming output)
- Web host:

    - HttpControllerHandler.WriteBufferedResponseContentAsync (for buffering output)
    - HttpControllerHandler.WriteStreamedResponseContentAsync (for streaming output)
    - HttpControllerHandler.WriteErrorResponseContentAsync (for failures in error recovery under buffered output mode)

The list of catch block strings is also available via static readonly properties. (The core catch block string are on the static ExceptionCatchBlocks; the remainder appear on one static class each for OWIN and web host).`IsTopLevelCatchBlock` is helpful for following the recommended pattern of handling exceptions only at the top of the call stack. Rather than turning exceptions into 500 responses anywhere a nested catch block occurs, an exception handler can let exceptions propagate until they are about to be seen by the host.

In addition to the `ExceptionContext`, a logger gets one more piece of information via the full `ExceptionLoggerContext`:

[!code-csharp[Main](web-api-global-error-handling/samples/sample4.cs)]

The second property, `CanBeHandled`, allows a logger to identify an exception that cannot be handled. When the connection is about to be aborted and no new response message can be sent, the loggers will be called but the handler will ***not*** be called, and the loggers can identify this scenario from this property.

In additional to the `ExceptionContext`, a handler gets one more property it can set on the full `ExceptionHandlerContext` to handle the exception:

[!code-csharp[Main](web-api-global-error-handling/samples/sample5.cs)]

An exception handler indicates that it has handled an exception by setting the `Result` property to an action result (for example, an [ExceptionResult](https://msdn.microsoft.com/en-us/library/system.web.http.results.exceptionresult(v=vs.118).aspx), [InternalServerErrorResult](https://msdn.microsoft.com/en-us/library/system.web.http.results.internalservererrorresult(v=vs.118).aspx), [StatusCodeResult](https://msdn.microsoft.com/en-us/library/system.web.http.results.statuscoderesult(v=vs.118).aspx), or a custom result). If the `Result` property is null, the exception is unhandled and the original exception will be re-thrown.

For exceptions at the top of the call stack, we took an extra step to ensure the response is appropriate for API callers. If the exception propagates up to the host, the caller would see the yellow screen of death or some other host provided response which is typically HTML and not usually an appropriate API error response. In these cases, the Result starts out non-null, and only if a custom exception handler explicitly sets it back to `null` (unhandled) will the exception propagate to the host. Setting `Result` to `null` in such cases can be useful for two scenarios:

1. OWIN hosted Web API with custom exception handling middleware registered before/outside Web API.
2. Local debugging via a browser, where the yellow screen of death is actually a helpful response for an unhandled exception.

For both exception loggers and exception handlers, we don't do anything to recover if the logger or handler itself throws an exception. (Other than letting the exception propagate, leave feedback at the bottom of this page if you have a better approach.) The contract for exception loggers and handlers is that they should not let exceptions propagate up to their callers; otherwise, the exception will just propagate, often all the way to the host resulting in an HTML error (like the ASP.NET's yellow screen) being sent back to the client (which usually isn't the preferred option for API callers that expect JSON or XML).

## Examples

### Tracing Exception Logger

The exception logger below send exception data to configured Trace sources (including the Debug output window in Visual Studio).

[!code-csharp[Main](web-api-global-error-handling/samples/sample6.cs)]

### Custom Error Message Exception Handler

The following below produces a custom error response to clients, including an email address for contacting support.

[!code-csharp[Main](web-api-global-error-handling/samples/sample7.cs)]

## Registering Exception Filters

If you use the "ASP.NET MVC 4 Web Application" project template to create your project, put your Web API configuration code inside the `WebApiConfig` class, in the *App/_Start* folder:

[!code-csharp[Main](exception-handling/samples/sample7.cs?highlight=5)]

## Appendix: Base Class Details

[!code-csharp[Main](web-api-global-error-handling/samples/sample8.cs)]
