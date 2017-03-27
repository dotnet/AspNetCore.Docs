---
uid: web-api/overview/error-handling/exception-handling
title: "Exception Handling in ASP.NET Web API | Microsoft Docs"
author: MikeWasson
description: ""
ms.author: aspnetcontent
manager: wpickett
ms.date: 03/12/2012
ms.topic: article
ms.assetid: cbebeb37-2594-41f2-b71a-f4f26520d512
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/error-handling/exception-handling
msc.type: authoredcontent
---
Exception Handling in ASP.NET Web API
====================
by [Mike Wasson](https://github.com/MikeWasson)

This article describes error and exception handling in ASP.NET Web API.

- [HttpResponseException](#httpresponserexception)
- [Exception Filters](#exception_filters)
- [Registering Exception Filters](#registering_exception_filters)
- [HttpError](#httperror)

<a id="httpresponserexception"></a>
## HttpResponseException

What happens if a Web API controller throws an uncaught exception? By default, most exceptions are translated into an HTTP response with status code 500, Internal Server Error.

The **HttpResponseException** type is a special case. This exception returns any HTTP status code that you specify in the exception constructor. For example, the following method returns 404, Not Found, if the *id* parameter is not valid.

[!code-csharp[Main](exception-handling/samples/sample1.cs)]

For more control over the response, you can also construct the entire response message and include it with the **HttpResponseException:** 

[!code-csharp[Main](exception-handling/samples/sample2.cs)]

<a id="exception_filters"></a>
## Exception Filters

You can customize how Web API handles exceptions by writing an *exception filter*. An exception filter is executed when a controller method throws any unhandled exception that is *not* an **HttpResponseException** exception. The **HttpResponseException** type is a special case, because it is designed specifically for returning an HTTP response.

Exception filters implement the **System.Web.Http.Filters.IExceptionFilter** interface. The simplest way to write an exception filter is to derive from the **System.Web.Http.Filters.ExceptionFilterAttribute** class and override the **OnException** method.

> [!NOTE]
> Exception filters in ASP.NET Web API are similar to those in ASP.NET MVC. However, they are declared in a separate namespace and function separately. In particular, the **HandleErrorAttribute** class used in MVC does not handle exceptions thrown by Web API controllers.


Here is a filter that converts **NotImplementedException** exceptions into HTTP status code 501, Not Implemented:

[!code-csharp[Main](exception-handling/samples/sample3.cs)]

The **Response** property of the **HttpActionExecutedContext** object contains the HTTP response message that will be sent to the client.

<a id="registering_exception_filters"></a>
## Registering Exception Filters

There are several ways to register a Web API exception filter:

- By action
- By controller
- Globally

To apply the filter to a specific action, add the filter as an attribute to the action:

[!code-csharp[Main](exception-handling/samples/sample4.cs)]

To apply the filter to all of the actions on a controller, add the filter as an attribute to the controller class:

[!code-csharp[Main](exception-handling/samples/sample5.cs)]

To apply the filter globally to all Web API controllers, add an instance of the filter to the **GlobalConfiguration.Configuration.Filters** collection. Exeption filters in this collection apply to any Web API controller action.

[!code-csharp[Main](exception-handling/samples/sample6.cs)]

If you use the "ASP.NET MVC 4 Web Application" project template to create your project, put your Web API configuration code inside the `WebApiConfig` class, which is located in the App\_Start folder:

[!code-csharp[Main](exception-handling/samples/sample7.cs?highlight=5)]

<a id="httperror"></a>
## HttpError

The **HttpError** object provides a consistent way to return error information in the response body. The following example shows how to return HTTP status code 404 (Not Found) with an **HttpError** in the response body.

[!code-csharp[Main](exception-handling/samples/sample8.cs)]

**CreateErrorResponse** is an extension method defined in the **System.Net.Http.HttpRequestMessageExtensions** class. Internally, **CreateErrorResponse** creates an **HttpError** instance and then creates an **HttpResponseMessage** that contains the **HttpError**.

In this example, if the method is successful, it returns the product in the HTTP response. But if the requested product is not found, the HTTP response contains an **HttpError** in the request body. The response might look like the following:

[!code-console[Main](exception-handling/samples/sample9.cmd)]

Notice that the **HttpError** was serialized to JSON in this example. One advantage of using **HttpError** is that it goes through the same [content-negotiation](../formats-and-model-binding/content-negotiation.md) and serialization process as any other strongly-typed model.

### HttpError and Model Validation

For model validation, you can pass the model state to **CreateErrorResponse**, to include the validation errors in the response:

[!code-csharp[Main](exception-handling/samples/sample10.cs)]

This example might return the following response:

[!code-console[Main](exception-handling/samples/sample11.cmd)]

For more information about model validation, see [Model Validation in ASP.NET Web API](../formats-and-model-binding/model-validation-in-aspnet-web-api.md).

### Using HttpError with HttpResponseException

The previous examples return an **HttpResponseMessage** message from the controller action, but you can also use **HttpResponseException** to return an **HttpError**. This lets you return a strongly-typed model in the normal success case, while still returning **HttpError** if there is an error:

[!code-csharp[Main](exception-handling/samples/sample12.cs)]