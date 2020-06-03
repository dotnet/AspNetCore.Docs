---
title: Custom formatters in ASP.NET Core Web API
author: rick-anderson
description: Learn how to create and use custom formatters for web APIs in ASP.NET Core.
ms.author: riande
ms.date: 02/08/2017
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: web-api/advanced/custom-formatters
---
# Custom formatters in ASP.NET Core Web API

By [Tom Dykstra](https://github.com/tdykstra)

ASP.NET Core MVC supports data exchange in Web APIs using input and output formatters. Input formatters are used by [Model Binding](xref:mvc/models/model-binding). Output formatters are used to [format responses](xref:web-api/advanced/formatting).

The framework provides built-in input and output formatters for JSON and XML. It provides a built-in output formatter for plain text, but doesn't provide an input formatter for plain text.

This article shows how to add support for additional formats by creating custom formatters. For an example of a custom input formatter for plain text, see [TextPlainInputFormatter](https://github.com/aspnet/Entropy/blob/master/samples/Mvc.Formatters/TextPlainInputFormatter.cs) on GitHub.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/web-api/advanced/custom-formatters/sample) ([how to download](xref:index#how-to-download-a-sample))

## When to use custom formatters

Use a custom formatter when you want the [content negotiation](xref:web-api/advanced/formatting#content-negotiation) process to support a content type that isn't supported by the built-in formatters.

For example, if some of the clients for your web API can handle the [Protobuf](https://github.com/google/protobuf) format, you might want to use Protobuf with those clients because it's more efficient. Or you might want your web API to send contact names and addresses in [vCard](https://wikipedia.org/wiki/VCard) format, a commonly used format for exchanging contact data. The sample app provided with this article implements a simple vCard formatter.

## Overview of how to use a custom formatter

Here are the steps to create and use a custom formatter:

* Create an output formatter class if you want to serialize data to send to the client.
* Create an input formatter class if you want to deserialize data received from the client.
* Add instances of your formatters to the `InputFormatters` and `OutputFormatters` collections in [MvcOptions](/dotnet/api/microsoft.aspnetcore.mvc.mvcoptions).

The following sections provide guidance and code examples for each of these steps.

## How to create a custom formatter class

To create a formatter:

* Derive the class from the appropriate base class.
* Specify valid media types and encodings in the constructor.
* Override `CanReadType`/`CanWriteType` methods
* Override `ReadRequestBodyAsync`/`WriteResponseBodyAsync` methods
  
### Derive from the appropriate base class

For text media types (for example, vCard), derive from the [TextInputFormatter](/dotnet/api/microsoft.aspnetcore.mvc.formatters.textinputformatter) or [TextOutputFormatter](/dotnet/api/microsoft.aspnetcore.mvc.formatters.textoutputformatter) base class.

[!code-csharp[](custom-formatters/sample/Formatters/VcardOutputFormatter.cs?name=classdef)]

For an input formatter example, see the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/web-api/advanced/custom-formatters/sample).

For binary types, derive from the [InputFormatter](/dotnet/api/microsoft.aspnetcore.mvc.formatters.inputformatter) or [OutputFormatter](/dotnet/api/microsoft.aspnetcore.mvc.formatters.outputformatter) base class.

### Specify valid media types and encodings

In the constructor, specify valid media types and encodings by adding to the `SupportedMediaTypes` and `SupportedEncodings` collections.

[!code-csharp[](custom-formatters/sample/Formatters/VcardOutputFormatter.cs?name=ctor&highlight=3,5-6)]

For an input formatter example, see the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/web-api/advanced/custom-formatters/sample).

> [!NOTE]
> You can't do constructor dependency injection in a formatter class. For example, you can't get a logger by adding a logger parameter to the constructor. To access services, you have to use the context object that gets passed in to your methods. A code example [below](#read-write) shows how to do this.

### Override CanReadType/CanWriteType

Specify the type you can deserialize into or serialize from by overriding the `CanReadType` or `CanWriteType` methods. For example, you might only be able to create vCard text from a `Contact` type and vice versa.

[!code-csharp[](custom-formatters/sample/Formatters/VcardOutputFormatter.cs?name=canwritetype)]

For an input formatter example, see the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/web-api/advanced/custom-formatters/sample).

#### The CanWriteResult method

In some scenarios you have to override `CanWriteResult` instead of `CanWriteType`. Use `CanWriteResult` if the following conditions are true:

* Your action method returns a model class.
* There are derived classes which might be returned at runtime.
* You need to know at runtime which derived class was returned by the action.

For example, suppose your action method signature returns a `Person` type, but it may return a `Student` or `Instructor` type that derives from `Person`. If you want your formatter to handle only `Student` objects, check the type of [Object](/dotnet/api/microsoft.aspnetcore.mvc.formatters.outputformattercanwritecontext.object#Microsoft_AspNetCore_Mvc_Formatters_OutputFormatterCanWriteContext_Object) in the context object provided to the `CanWriteResult` method. Note that it's not necessary to use `CanWriteResult` when the action method returns `IActionResult`; in that case, the `CanWriteType` method receives the runtime type.

<a id="read-write"></a>

### Override ReadRequestBodyAsync/WriteResponseBodyAsync

You do the actual work of deserializing or serializing in `ReadRequestBodyAsync` or `WriteResponseBodyAsync`. The highlighted lines in the following example show how to get services from the dependency injection container (you can't get them from constructor parameters).

[!code-csharp[](custom-formatters/sample/Formatters/VcardOutputFormatter.cs?name=writeresponse&highlight=3-4)]

For an input formatter example, see the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/web-api/advanced/custom-formatters/sample).

## How to configure MVC to use a custom formatter

To use a custom formatter, add an instance of the formatter class to the `InputFormatters` or `OutputFormatters` collection.

[!code-csharp[](custom-formatters/sample/Startup.cs?name=mvcoptions&highlight=3-4)]

Formatters are evaluated in the order you insert them. The first one takes precedence.

## Next steps

* [Sample app for this doc](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/web-api/advanced/custom-formatters/sample), which implements simple vCard input and output formatters. The apps reads and writes vCards that look like the following example:

```
BEGIN:VCARD
VERSION:2.1
N:Davolio;Nancy
FN:Nancy Davolio
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid:20293482-9240-4d68-b475-325df4a83728
END:VCARD
```

To see vCard output, run the application and send a Get request with Accept header "text/vcard" to `http://localhost:63313/api/contacts/` (when running from Visual Studio) or `http://localhost:5000/api/contacts/` (when running from the command line).

To add a vCard to the in-memory collection of contacts, send a Post request to the same URL, with Content-Type header "text/vcard" and with vCard text in the body, formatted like the example above.
