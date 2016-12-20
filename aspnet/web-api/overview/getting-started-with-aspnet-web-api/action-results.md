---
title: "Action Results in Web API 2 | Microsoft Docs"
author: MikeWasson
description: ""
ms.author: riande
manager: wpickett
ms.date: 02/03/2014
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/getting-started-with-aspnet-web-api/action-results
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\web-api\overview\getting-started-with-aspnet-web-api\action-results.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/54186) | [View dev content](http://docs.aspdev.net/tutorials/web-api/overview/getting-started-with-aspnet-web-api/action-results.html) | [View prod content](http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/action-results) | Picker: 54187

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

    public class ValuesController : ApiController
    {
        public void Post()
        {
        }
    }

HTTP response:

    HTTP/1.1 204 No Content
    Server: Microsoft-IIS/8.0
    Date: Mon, 27 Jan 2014 02:13:26 GMT

## HttpResponseMessage

If the action returns an [HttpResponseMessage](https://msdn.microsoft.com/en-us/library/system.net.http.httpresponsemessage.aspx), Web API converts the return value directly into an HTTP response message, using the properties of the **HttpResponseMessage** object to populate the response.

This option gives you a lot of control over the response message. For example, the following controller action sets the Cache-Control header.

    public class ValuesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
            response.Content = new StringContent("hello", Encoding.Unicode);
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(20)
            };
            return response;
        } 
    }

Response:

[!code[Main](action-results/samples/sample1.xml?highlight=2)]

If you pass a domain model to the **CreateResponse** method, Web API uses a [media formatter](../formats-and-model-binding/media-formatters.md) to write the serialized model into the response body.

    public HttpResponseMessage Get()
    {
        // Get a list of products from a database.
        IEnumerable<Product> products = GetProductsFromDB();
    
        // Write the list to the response body.
        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, products);
        return response;
    }

Web API uses the Accept header in the request to choose the formatter. For more information, see [Content Negotiation](../formats-and-model-binding/content-negotiation.md).

## IHttpActionResult

The **IHttpActionResult** interface was introducted in Web API 2. Essentially, it defines an **HttpResponseMessage** factory. Here are some advantages of using the **IHttpActionResult** interface:

- Simplifies [unit testing](../testing-and-debugging/unit-testing-controllers-in-web-api.md) your controllers.
- Moves common logic for creating HTTP responses into separate classes.
- Makes the intent of the controller action clearer, by hiding the low-level details of constructing the response.

**IHttpActionResult** contains a single method, **ExecuteAsync**, which asynchronously creates an **HttpResponseMessage** instance.

    public interface IHttpActionResult
    {
        Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken);
    }

If a controller action returns an **IHttpActionResult**, Web API calls the **ExecuteAsync** method to create an **HttpResponseMessage**. Then it converts the **HttpResponseMessage** into an HTTP response message.

Here is a simple implementaton of **IHttpActionResult** that creates a plain text response:

    public class TextResult : IHttpActionResult
    {
        string _value;
        HttpRequestMessage _request;
    
        public TextResult(string value, HttpRequestMessage request)
        {
            _value = value;
            _request = request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_value),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }

Example controller action:

    public class ValuesController : ApiController
    {
        public IHttpActionResult Get()
        {
            return new TextResult("hello", Request);
        }
    }

Response:

    HTTP/1.1 200 OK
    Content-Length: 5
    Content-Type: text/plain; charset=utf-8
    Server: Microsoft-IIS/8.0
    Date: Mon, 27 Jan 2014 08:53:35 GMT
    
    hello

More often, you will use the **IHttpActionResult** implementations defined in the **[System.Web.Http.Results](https://msdn.microsoft.com/en-us/library/system.web.http.results.aspx)** namespace. The **ApiContoller** class defines helper methods that return these built-in action results.

In the following example, if the request does not match an existing product ID, the controller calls [ApiController.NotFound](https://msdn.microsoft.com/en-us/library/system.web.http.apicontroller.notfound.aspx) to create a 404 (Not Found) response. Otherwise, the controller calls [ApiController.OK](https://msdn.microsoft.com/en-us/library/dn314591.aspx), which creates a 200 (OK) response that contains the product.

    public IHttpActionResult Get (int id)
    {
        Product product = _repository.Get (id);
        if (product == null)
        {
            return NotFound(); // Returns a NotFoundResult
        }
        return Ok(product);  // Returns an OkNegotiatedContentResult
    }

## Other Return Types

For all other return types, Web API uses a [media formatter](../formats-and-model-binding/media-formatters.md) to serialize the return value. Web API writes the serialized value into the response body. The response status code is 200 (OK).

    public class ProductsController : ApiController
    {
        public IEnumerable<Product> Get()
        {
            return GetAllProductsFromDB();
        }
    }

A disadvantage of this approach is that you cannot directly return an error code, such as 404. However, you can throw an **HttpResponseException** for error codes. For more information, see [Exception Handling in ASP.NET Web API](../error-handling/exception-handling.md).

Web API uses the Accept header in the request to choose the formatter. For more information, see [Content Negotiation](../formats-and-model-binding/content-negotiation.md).

Example request

    GET http://localhost/api/products HTTP/1.1
    User-Agent: Fiddler
    Host: localhost:24127
    Accept: application/json

Example response:

    HTTP/1.1 200 OK
    Content-Type: application/json; charset=utf-8
    Server: Microsoft-IIS/8.0
    Date: Mon, 27 Jan 2014 08:53:35 GMT
    Content-Length: 56
    
    [{"Id":1,"Name":"Yo-yo","Category":"Toys","Price":6.95}]