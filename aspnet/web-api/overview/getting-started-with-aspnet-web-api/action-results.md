---
uid: web-api/overview/getting-started-with-aspnet-web-api/action-results
title: "Action Results in Web API 2 | Microsoft Docs"
author: MikeWasson
description: ""
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/03/2014
ms.topic: article
ms.assetid: 2fc4797c-38ef-4cc7-926c-ca431c4739e8
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/getting-started-with-aspnet-web-api/action-results
msc.type: authoredcontent
---
Action Results in Web API 2
====================
by [Mike Wasson](https://github.com/MikeWasson)

This topic describes how ASP.NET Web API converts the return value from a controller action into an HTTP response message.

A Web API controller action can return any of the following:

1. void
2. **HttpResponseMessage**
3. **IHttpActionResult**
4. Some other type

Depending on which of these is returned, Web API uses a different mechanism to create the HTTP response.

| Return type | How Web API creates the response |
| --- | --- |
| void | Return empty 204 (No Content) |
| **HttpResponseMessage** | Convert directly to an HTTP response message. |
| **IHttpActionResult** | Call **ExecuteAsync** to create an **HttpResponseMessage**, then convert to an HTTP response message. |
| Other type | Write the serialized return value into the response body; return 200 (OK). |

The rest of this topic describes each option in more detail.

## void

If the return type is `void`, Web API simply returns an empty HTTP response with status code 204 (No Content).

Example controller:

[!code-csharp[Main](action-results/samples/sample1.cs)]

HTTP response:

[!code-console[Main](action-results/samples/sample2.cmd)]

## HttpResponseMessage

If the action returns an [HttpResponseMessage](https://msdn.microsoft.com/en-us/library/system.net.http.httpresponsemessage.aspx), Web API converts the return value directly into an HTTP response message, using the properties of the **HttpResponseMessage** object to populate the response.

This option gives you a lot of control over the response message. For example, the following controller action sets the Cache-Control header.

[!code-csharp[Main](action-results/samples/sample3.cs)]

Response:

[!code-console[Main](action-results/samples/sample4.cmd?highlight=2)]

If you pass a domain model to the **CreateResponse** method, Web API uses a [media formatter](../formats-and-model-binding/media-formatters.md) to write the serialized model into the response body.

[!code-csharp[Main](action-results/samples/sample5.cs)]

Web API uses the Accept header in the request to choose the formatter. For more information, see [Content Negotiation](../formats-and-model-binding/content-negotiation.md).

## IHttpActionResult

The **IHttpActionResult** interface was introduced in Web API 2. Essentially, it defines an **HttpResponseMessage** factory. Here are some advantages of using the **IHttpActionResult** interface:

- Simplifies [unit testing](../testing-and-debugging/unit-testing-controllers-in-web-api.md) your controllers.
- Moves common logic for creating HTTP responses into separate classes.
- Makes the intent of the controller action clearer, by hiding the low-level details of constructing the response.

**IHttpActionResult** contains a single method, **ExecuteAsync**, which asynchronously creates an **HttpResponseMessage** instance.

[!code-csharp[Main](action-results/samples/sample6.cs)]

If a controller action returns an **IHttpActionResult**, Web API calls the **ExecuteAsync** method to create an **HttpResponseMessage**. Then it converts the **HttpResponseMessage** into an HTTP response message.

Here is a simple implementaton of **IHttpActionResult** that creates a plain text response:

[!code-csharp[Main](action-results/samples/sample7.cs)]

Example controller action:

[!code-csharp[Main](action-results/samples/sample8.cs)]

Response:

[!code-console[Main](action-results/samples/sample9.cmd)]

More often, you will use the **IHttpActionResult** implementations defined in the **[System.Web.Http.Results](https://msdn.microsoft.com/en-us/library/system.web.http.results.aspx)** namespace. The **ApiController** class defines helper methods that return these built-in action results.

In the following example, if the request does not match an existing product ID, the controller calls [ApiController.NotFound](https://msdn.microsoft.com/en-us/library/system.web.http.apicontroller.notfound.aspx) to create a 404 (Not Found) response. Otherwise, the controller calls [ApiController.OK](https://msdn.microsoft.com/en-us/library/dn314591.aspx), which creates a 200 (OK) response that contains the product.

[!code-csharp[Main](action-results/samples/sample10.cs)]

## Other Return Types

For all other return types, Web API uses a [media formatter](../formats-and-model-binding/media-formatters.md) to serialize the return value. Web API writes the serialized value into the response body. The response status code is 200 (OK).

[!code-csharp[Main](action-results/samples/sample11.cs)]

A disadvantage of this approach is that you cannot directly return an error code, such as 404. However, you can throw an **HttpResponseException** for error codes. For more information, see [Exception Handling in ASP.NET Web API](../error-handling/exception-handling.md).

Web API uses the Accept header in the request to choose the formatter. For more information, see [Content Negotiation](../formats-and-model-binding/content-negotiation.md).

Example request

[!code-console[Main](action-results/samples/sample12.cmd)]

Example response:

[!code-console[Main](action-results/samples/sample13.cmd)]
