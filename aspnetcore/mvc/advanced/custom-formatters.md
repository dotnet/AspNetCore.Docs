---
title: Custom formatters in ASP.NET Core MVC web APIs
author: tdykstra
description: Learn how to create and use custom formatters for web APIs in ASP.NET Core. 
keywords: ASP.NET Core, web api, custom formatters
ms.author: tdykstra
manager: wpickett
ms.date: 02/08/2017
ms.topic: article
ms.assetid: 1fb6fdc2-e199-4469-9012-b909d1913422
ms.technology: aspnet
ms.prod: asp.net-core
uid: mvc/models/custom-formatters
---
# Custom formatters in ASP.NET Core MVC web APIs

By [Tom Dykstra](https://github.com/tdykstra)

ASP.NET Core MVC has built-in support for data exchange in web APIs by using JSON, XML, or plain text formats. This article shows how to add support for additional formats by creating custom formatters.

[View or download sample from GitHub](https://github.com/aspnet/Docs/tree/master/aspnetcore/mvc/advanced/custom-formatters/sample).

## When to use custom formatters

Use a custom formatter when you want the [content negotiation](xref:mvc/models/formatting) process to support a content type that isn't supported by the built-in formatters (JSON, XML, and plain text).

For example, if some of the clients for your web API can handle the [Protobuf](https://github.com/google/protobuf) format, you might want to use Protobuf with those clients because it's more efficient.  Or you might want your web API to send contact names and addresses in [vCard](https://wikipedia.org/wiki/VCard) format, a commonly used format for exchanging contact data. The sample app provided with this article implements a simple vCard formatter.

## Overview of how to use a custom formatter

Here are the steps to create and use a custom formatter:

* Create an output formatter class if you want to serialize data to send to the client.
* Create an input formatter class if you want to deserialize data received from the client. 
* Add instances of your formatters to the `InputFormatters` and `OutputFormatters` collections in [MvcOptions](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.mvcoptions).

The following sections provide guidance and code examples for each of these steps.

## How to create a custom formatter class

To create a formatter:

* Derive the class from the appropriate base class.
* Specify valid media types and encodings in the constructor.
* Override `CanReadType`/`CanWriteType` methods
* Override `ReadRequestBodyAsync`/`WriteResponseBodyAsync` methods
  
### Derive from the appropriate base class

For text media types (for example, vCard), derive from the [TextInputFormatter](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.formatters.textinputformatter) or [TextOutputFormatter](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.formatters.textoutputformatter) base class.

[!code-csharp[Main](custom-formatters/sample/Formatters/VcardOutputFormatter.cs?name=classdef)]

For binary types, derive from the [InputFormatter](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.formatters.inputformatter) or [OutputFormatter](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.formatters.outputformatter) base class.

### Specify valid media types and encodings

In the constructor, specify valid media types and encodings by adding to the `SupportedMediaTypes` and `SupportedEncodings` collections.

[!code-csharp[Main](custom-formatters/sample/Formatters/VcardOutputFormatter.cs?name=ctor&highlight=3,5-6)]

> [!NOTE]  
> You can't do constructor dependency injection in a formatter class. For example, you can't get a logger by adding a logger parameter to the constructor. To access services, you have to use the context object that gets passed in to your methods. A code example [below](#read-write) shows how to do this.

### Override CanReadType/CanWriteType 

Specify the type you can deserialize into or serialize from by overriding the `CanReadType` or `CanWriteType` methods. For example, you might only be able to create vCard text from a `Contact` type and vice versa.

[!code-csharp[Main](custom-formatters/sample/Formatters/VcardOutputFormatter.cs?name=canwritetype)]

#### The CanWriteResult method

In some scenarios you have to override `CanWriteResult` instead of `CanWriteType`. Use `CanWriteResult` if the following conditions are true:

  * Your action method returns a model class.
  * There are derived classes which might be returned at runtime.
  * You need to know at runtime which derived class was returned by the action.  

For example, suppose your action method signature returns a `Person` type, but it may return a `Student` or `Instructor` type that derives from `Person`. If you want your formatter to handle only `Student` objects, check the type of [Object](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.formatters.outputformattercanwritecontext#Microsoft_AspNetCore_Mvc_Formatters_OutputFormatterCanWriteContext_Object) in the context object provided to the `CanWriteResult` method. Note that it's not necessary to use `CanWriteResult` when the action method returns `IActionResult`; in that case, the `CanWriteType` method receives the runtime type.

<a id="read-write"></a>
### Override ReadRequestBodyAsync/WriteResponseBodyAsync 

You do the actual work of deserializing or serializing in `ReadRequestBodyAsync` or `WriteResponseBodyAsync`.  The highlighted lines in the following example show how to get services from the dependency injection container (you can't get them from constructor parameters).

[!code-csharp[Main](custom-formatters/sample/Formatters/VcardOutputFormatter.cs?name=writeresponse&highlight=3-4)]

## How to configure MVC to use a custom formatter
 
To use a custom formatter, add an instance of the formatter class to the `InputFormatters` or `OutputFormatters` collection.

[!code-csharp[Main](custom-formatters/sample/Startup.cs?name=mvcoptions&highlight=3-4)]

Formatters are evaluated in the order you insert them. The first one takes precedence. 

## Next steps

See the [sample application](https://github.com/aspnet/Docs/tree/master/aspnetcore/mvc/advanced/custom-formatters/sample), which implements simple vCard input and output formatters.  The application reads and writes vCards that look like the following example:

```
BEGIN:VCARD
VERSION:2.1
N:Davolio;Nancy
FN:Nancy Davolio
UID:20293482-9240-4d68-b475-325df4a83728
END:VCARD
```

To see vCard output, run the application and send a Get request with Accept header "text/vcard" to `http://localhost:63313/api/contacts/` (when running from Visual Studio) or `http://localhost:5000/api/contacts/` (when running from the command line).

To add a vCard to the in-memory collection of contacts, send a Post request to the same URL, with Content-Type header "text/vcard" and with vCard text in the body, formatted like the example above.
