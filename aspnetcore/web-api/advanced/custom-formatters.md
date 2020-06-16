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

By [Tom Dykstra](https://github.com/tdykstra) and [Kirk Larkin](https://twitter.com/serpent5)

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
* Override `CanReadType` and `CanWriteType` methods
* Override `ReadRequestBodyAsync` and `WriteResponseBodyAsync` methods

The follow code shows the completed `VcardOutputFormatter` class from the [sample](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/web-api/advanced/custom-formatters/3.1sample):

[!code-csharp[](custom-formatters/3.1sample/Formatters/VcardOutputFormatter.cs?name=snippet)]
  
### Derive from the appropriate base class

For text media types (for example, vCard), derive from the [TextInputFormatter](/dotnet/api/microsoft.aspnetcore.mvc.formatters.textinputformatter) or [TextOutputFormatter](/dotnet/api/microsoft.aspnetcore.mvc.formatters.textoutputformatter) base class.

[!code-csharp[](custom-formatters/sample/Formatters/VcardOutputFormatter.cs?name=classdef)]

For an input formatter example, see the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/web-api/advanced/custom-formatters/sample).

For binary types, derive from the [InputFormatter](/dotnet/api/microsoft.aspnetcore.mvc.formatters.inputformatter) or [OutputFormatter](/dotnet/api/microsoft.aspnetcore.mvc.formatters.outputformatter) base class.

### Specify valid media types and encodings

In the constructor, specify valid media types and encodings by adding to the `SupportedMediaTypes` and `SupportedEncodings` collections.

[!code-csharp[](custom-formatters/sample/Formatters/VcardOutputFormatter.cs?name=ctor&highlight=3,5-6)]

For an input formatter example, see the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/web-api/advanced/custom-formatters/sample).

Constructor dependency injection can ***not*** be done in a formatter class. For example, the logger cannot be added as logger parameter to the constructor. To access services, use the context object that gets passed in to the methods. A code example in this doc and the [download code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/web-api/advanced/custom-formatters/sample) show how to do this.

### Override CanReadType and CanWriteType

Specify the type to deserialize into or serialize from by overriding the `CanReadType` or `CanWriteType` methods. For example, creating vCard text from a `Contact` type and vice versa.

[!code-csharp[](custom-formatters/sample/Formatters/VcardOutputFormatter.cs?name=canwritetype)]

For an input formatter example, see the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/web-api/advanced/custom-formatters/sample).

#### The CanWriteResult method

In some scenarios, `CanWriteResult` must be overridden rather than `CanWriteType`. Use `CanWriteResult` if the following conditions are true:

* The action method returns a model class.
* There are derived classes which might be returned at runtime.
* The derived class returned by the action must be known at runtime.

For example, suppose the action method:

* Signature returns a `Person` type.
* It can return a `Student` or `Instructor` type that derives from `Person`. 

For the formatter to handle only `Student` objects, check the type of [Object](/dotnet/api/microsoft.aspnetcore.mvc.formatters.outputformattercanwritecontext.object#Microsoft_AspNetCore_Mvc_Formatters_OutputFormatterCanWriteContext_Object) in the context object provided to the `CanWriteResult` method. When the action method returns `IActionResult`:

*  It's not necessary to use `CanWriteResult`.
* The `CanWriteType` method receives the runtime type.

<a id="read-write"></a>

### Override ReadRequestBodyAsync and WriteResponseBodyAsync

Deserializing or serializing is performed in `ReadRequestBodyAsync` or `WriteResponseBodyAsync`. The following example shows how to get services from the dependency injection container. Services can't be obtained from constructor parameters.

[!code-csharp[](custom-formatters/sample/Formatters/VcardOutputFormatter.cs?name=writeresponse&highlight=3-4)]

For an input formatter example, see the [sample app](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/web-api/advanced/custom-formatters/sample).

## How to configure MVC to use a custom formatter

To use a custom formatter, add an instance of the formatter class to the `InputFormatters` or `OutputFormatters` collection.

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](custom-formatters/3.1sample/Startup.cs?name=mvcoptions&highlight=3-4)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](custom-formatters/sample/Startup.cs?name=mvcoptions&highlight=3-4)]

::: moniker-end

Formatters are evaluated in the order you insert them. The first one takes precedence.

## Next steps

* [Sample app for this doc](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/web-api/advanced/custom-formatters/sample), which implements basic vCard input and output formatters. The app reads and writes vCards that look like the following example:

```
BEGIN:VCARD
VERSION:2.1
N:Davolio;Nancy
FN:Nancy Davolio
END:VCARD
```

To see vCard output, run the app and send a Get request with Accept header "text/vcard" to `https://localhost:5001/api/contacts`.

To add a vCard to the in-memory collection of contacts:

* Send a Post request to `/api/contacts` with a tool like Postman.
* Set the `Content-Type` header to `text/vcard`.
* Set vCard text in the body, formatted like the preceding example.

## Additional resources

<xref:grpc/dotnet-grpc>