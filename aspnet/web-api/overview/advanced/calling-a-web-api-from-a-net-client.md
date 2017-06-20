---
uid: web-api/overview/advanced/calling-a-web-api-from-a-net-client
title: "Calling a Web API From a .NET Client (C#) | Microsoft Docs"
author: MikeWasson
description: ""
ms.author: aspnetcontent
manager: wpickett
ms.date: 01/20/2014
ms.topic: article
ms.assetid: df1baeef-a737-471f-a6ae-cca54cfb26d4
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/advanced/calling-a-web-api-from-a-net-client
msc.type: authoredcontent
---
Calling a Web API From a .NET Client (C#)
====================
by [Mike Wasson](https://github.com/MikeWasson)

[Download Completed Project](https://github.com/MikeWasson/HttpClientSample)

This tutorial shows how to call a web API from a .NET application, using [System.Net.Http.HttpClient.](https://msdn.microsoft.com/en-us/library/system.net.http.httpclient(v=vs.110).aspx)

In this tutorial, we will write an client application that consumes the following web API.

| Action | HTTP method | Relative URI |
| --- | --- | --- |
| Get a product by ID | GET | /api/products/*id* |
| Create a new product | POST | /api/products |
| Update a product | PUT | /api/products/*id* |
| Delete a product | DELETE | /api/products/*id* |

> [!NOTE]
> To learn how to implement this API on the server, using ASP.NET Web API, see [Creating a Web API that Supports CRUD Operations](../older-versions/creating-a-web-api-that-supports-crud-operations.md).


For simplicity, the client application in this tutorial is a Windows console application. **HttpClient** is also supported for Windows Phone and Windows Store apps. For more information, see [Writing Web API Client Code for Multiple Platforms Using Portable Libraries](https://blogs.msdn.com/b/webdev/archive/2013/07/19/writing-web-api-client-code-for-multiple-platforms-using-portable-libraries.aspx)

<a id="CreateConsoleApp"></a>
## Create the Console Application

In Visual Studio, create a new Windows console application and paste in the following code.

[!code-csharp[Main](calling-a-web-api-from-a-net-client/samples/sample1.cs)]

This code provides the skeleton for the application. The `Main` `RunAsync` method and blocks until it completes. The reason for this approach is that most **HttpClient** methods are async, because they perform network I/O. All of the async tasks will be done inside `RunAsync`. In a console application, it's OK to block the main thread inside of `Main`. In a GUI application, you should never block the UI thread.

<a id="InstallClientLib"></a>
## Install the Web API Client Libraries

Use NuGet Package Manager to install the Web API Client Libraries package.

From the **Tools** menu, select **Library Package Manager**, then select **Package Manager Console**. In the Package Manager Console window, type the following command:

[!code-console[Main](calling-a-web-api-from-a-net-client/samples/sample2.cmd)]

<a id="AddModelClass"></a>
## Add a Model Class

Add the following class to the application:

[!code-csharp[Main](calling-a-web-api-from-a-net-client/samples/sample3.cs)]

This class matches the data model used by the web API. We can use **HttpClient** to read a `Product` instance from an HTTP response, without having to write a lot of deserialization code.

<a id="InitClient"></a>
## Create and Initialize HttpClient

Add a static **HttpClient** property to the `Program` class. 

[!code-csharp[Main](calling-a-web-api-from-a-net-client/samples/sample4.cs)]

> [!NOTE]
> **HttpClient** is intended to be instantiated once and re-used throughout the life of an application. Especially in server applications, creating a new **HttpClient** instance for every request will exhaust the number of sockets available under heavy loads. This will result in **SocketException** errors.


To initialize the **HttpClient** instance, add the following code to the `RunAsync` method: 

[!code-csharp[Main](calling-a-web-api-from-a-net-client/samples/sample5.cs)]

This code sets the base URI for HTTP requests, and sets the Accept header to "application/json", which tells the server to send data in JSON format.

<a id="GettingResource"></a>
## Sending a GET request to retrieve a resource

The following code sends a GET request for a product:

[!code-csharp[Main](calling-a-web-api-from-a-net-client/samples/sample6.cs)]

The **GetAsync** method sends the HTTP GET request. The method is asynchronous, because it performs network I/O. When the method completes, it returns an **HttpResponseMessage** that contains the HTTP response. If the status code in the response is a success code, the response body contains the JSON representation of a product. Call **ReadAsAsync** to deserialize the JSON payload to a `Product` instance. The **ReadAsync** method is asynchronous because the response body can be arbitrarily large.

**HttpClient** does not throw an exception when the HTTP response contains an error code. Instead, the **IsSuccessStatusCode** property is **false** if the status is an error code. If you prefer to treat HTTP error codes as exceptions, call [HttpResponseMessage.EnsureSuccessStatusCode](https://msdn.microsoft.com/en-us/library/system.net.http.httpresponsemessage.ensuresuccessstatuscode(v=vs.110).aspx) on the response object. This method throws an exception if the status code falls outside the range 200&ndash;299. Note that **HttpClient** can throw exceptions for other reasons &mdash; for example, if the request times out.

<a id="MediaTypeFormatters"></a>
### Using Media-Type Formatters to Deserialize

When **ReadAsAsync** is called with no parameters, it uses a default set of *media formatters* to read the response body. The default formatters support JSON, XML, and Form-url-encoded data.

Instead of using the default formatters, you can provide a list of formatters to the **ReadAsync** method, which is useful if you have a custom media-type formatter:

[!code-csharp[Main](calling-a-web-api-from-a-net-client/samples/sample7.cs)]

For more information, see [Media Formatters in ASP.NET Web API 2](../formats-and-model-binding/media-formatters.md)

## Sending a POST Request to Create a Resource

The following code sends a POST request that contains a `Product` instance in JSON format:

[!code-csharp[Main](calling-a-web-api-from-a-net-client/samples/sample8.cs)]

The **PostAsJsonAsync** method serializes an object to JSON and then sends the JSON payload in a POST request. If the request succeeds, it should return a 201 (Created) response, with the URL of the created resources in the Location header.

<a id="PuttingResource"></a>
## Sending a PUT Request to Update a Resource

The following code sends a PUT request to update a product.

[!code-csharp[Main](calling-a-web-api-from-a-net-client/samples/sample9.cs)]

The **PutAsJsonAsync** method works like **PostAsJsonAsync**, except that it sends a PUT request instead of POST.

<a id="DeletingResource"></a>
## Sending a DELETE Request to Delete a Resource

The following code sends a DELETE request to delete a product.

[!code-csharp[Main](calling-a-web-api-from-a-net-client/samples/sample10.cs)]

Like GET, a DELETE request does not have a request body, so you don't need to specify JSON or XML format.

## Complete Code Example

Here is the complete code for this tutorial. The code is very simple and doesn't include much error handling, but it shows the basic CRUD operations using **HttpClient**.

[!code-csharp[Main](calling-a-web-api-from-a-net-client/samples/sample11.cs)]
