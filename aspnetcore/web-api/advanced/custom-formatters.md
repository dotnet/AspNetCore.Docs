---
title: Custom formatters in ASP.NET Core Web API
author: tdykstra
description: Learn how to create and use custom formatters for web APIs in ASP.NET Core.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.date: 01/26/2022
uid: web-api/advanced/custom-formatters
---
# Custom formatters in ASP.NET Core Web API

:::moniker range=">= aspnetcore-6.0"

ASP.NET Core MVC supports data exchange in Web APIs using input and output formatters. Input formatters are used by [Model Binding](xref:mvc/models/model-binding). Output formatters are used to [format responses](xref:web-api/advanced/formatting).

The framework provides built-in input and output formatters for JSON and XML. It provides a built-in output formatter for plain text, but doesn't provide an input formatter for plain text.

This article shows how to add support for additional formats by creating custom formatters. For an example of a custom plain text input formatter, see [TextPlainInputFormatter](https://github.com/aspnet/Entropy/blob/master/samples/Mvc.Formatters/TextPlainInputFormatter.cs) on GitHub.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/web-api/advanced/custom-formatters/samples) ([how to download](xref:index#how-to-download-a-sample))

## When to use a custom formatter

Use a custom formatter to add support for a content type that isn't handled by the built-in formatters.

## Overview of how to create a custom formatter

To create a custom formatter:

* For serializing data sent to the client, create an output formatter class.
* For deserializing data received from the client, create an input formatter class.
* Add instances of formatter classes to the <xref:Microsoft.AspNetCore.Mvc.MvcOptions.InputFormatters%2A> and <xref:Microsoft.AspNetCore.Mvc.MvcOptions.OutputFormatters%2A> collections in <xref:Microsoft.AspNetCore.Mvc.MvcOptions>.

## Create a custom formatter

To create a formatter:

* Derive the class from the appropriate base class. The sample app derives from <xref:Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter> and <xref:Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter>.
* Specify supported media types and encodings in the constructor.
* Override the <xref:Microsoft.AspNetCore.Mvc.Formatters.InputFormatter.CanReadType%2A> and <xref:Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter.CanWriteType%2A> methods.
* Override the <xref:Microsoft.AspNetCore.Mvc.Formatters.InputFormatter.ReadRequestBodyAsync%2A> and <xref:Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter.WriteResponseBodyAsync%2A> methods.

The following code shows the `VcardOutputFormatter` class from the [sample](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/web-api/advanced/custom-formatters/samples):

:::code language="csharp" source="custom-formatters/samples/6.x/CustomFormattersSample/Formatters/VcardOutputFormatter.cs" id="snippet_Class":::

### Derive from the appropriate base class

For text media types (for example, vCard), derive from the <xref:Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter> or <xref:Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter> base class:

:::code language="csharp" source="custom-formatters/samples/6.x/CustomFormattersSample/Formatters/VcardOutputFormatter.cs" id="snippet_ClassDeclaration":::

For binary types, derive from the <xref:Microsoft.AspNetCore.Mvc.Formatters.InputFormatter> or <xref:Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter> base class.

### Specify supported media types and encodings

In the constructor, specify supported media types and encodings by adding to the <xref:Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter.SupportedMediaTypes%2A> and <xref:Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter.SupportedEncodings%2A> collections:

:::code language="csharp" source="custom-formatters/samples/6.x/CustomFormattersSample/Formatters/VcardOutputFormatter.cs" id="snippet_ctor":::

A formatter class can **not** use constructor injection for its dependencies. For example, `ILogger<VcardOutputFormatter>` can't be added as a parameter to the constructor. To access services, use the context object that gets passed in to the methods. A code example in this article and the [sample](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/web-api/advanced/custom-formatters/samples) show how to do this.

### Override CanReadType and CanWriteType

Specify the type to deserialize into or serialize from by overriding the <xref:Microsoft.AspNetCore.Mvc.Formatters.InputFormatter.CanReadType%2A> or <xref:Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter.CanWriteType%2A> methods. For example, to create vCard text from a `Contact` type and vice versa:

:::code language="csharp" source="custom-formatters/samples/6.x/CustomFormattersSample/Formatters/VcardOutputFormatter.cs" id="snippet_CanWriteType":::

#### The CanWriteResult method

In some scenarios, <xref:Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter.CanWriteResult%2A> must be overridden rather than <xref:Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter.CanWriteType%2A>. Use `CanWriteResult` if the following conditions are true:

* The action method returns a model class.
* There are derived classes that might be returned at runtime.
* The derived class returned by the action must be known at runtime.

For example, suppose the action method:

* Signature returns a `Person` type.
* Can return a `Student` or `Instructor` type that derives from `Person`. 

For the formatter to handle only `Student` objects, check the type of <xref:Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext.Object> in the context object provided to the `CanWriteResult` method. When the action method returns <xref:Microsoft.AspNetCore.Mvc.IActionResult>:

* It's not necessary to use `CanWriteResult`.
* The `CanWriteType` method receives the runtime type.

<a id="read-write"></a>

### Override ReadRequestBodyAsync and WriteResponseBodyAsync

Deserialization or serialization is performed in <xref:Microsoft.AspNetCore.Mvc.Formatters.InputFormatter.ReadRequestBodyAsync%2A> or <xref:Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter.WriteResponseBodyAsync%2A>. The following example shows how to get services from the dependency injection container. Services can't be obtained from constructor parameters:

:::code language="csharp" source="custom-formatters/samples/6.x/CustomFormattersSample/Formatters/VcardOutputFormatter.cs" id="snippet_WriteResponseBodyAsync":::

## Configure MVC to use a custom formatter

To use a custom formatter, add an instance of the formatter class to the <xref:Microsoft.AspNetCore.Mvc.MvcOptions.InputFormatters%2A?displayProperty=nameWithType> or <xref:Microsoft.AspNetCore.Mvc.MvcOptions.OutputFormatters%2A?displayProperty=nameWithType> collection:

:::code language="csharp" source="custom-formatters/samples/6.x/CustomFormattersSample/Program.cs" id="snippet_AddControllers" highlight="5-6":::

Formatters are evaluated in the order they're inserted, where the first one takes precedence.

## The complete `VcardInputFormatter` class

The following code shows the `VcardInputFormatter` class from the [sample](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/web-api/advanced/custom-formatters/samples):

:::code language="csharp" source="custom-formatters/samples/6.x/CustomFormattersSample/Formatters/VcardInputFormatter.cs" id="snippet_Class":::

## Test the app

[Run the sample app for this article](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/web-api/advanced/custom-formatters/samples), which implements basic vCard input and output formatters. The app reads and writes vCards similar to the following format:

```
BEGIN:VCARD
VERSION:2.1
N:Davolio;Nancy
FN:Nancy Davolio
END:VCARD
```

To see vCard output, run the app and send a Get request with Accept header `text/vcard` to `https://localhost:<port>/api/contacts`.

To add a vCard to the in-memory collection of contacts:

* Send a `Post` request to `/api/contacts` with a tool like Postman.
* Set the `Content-Type` header to `text/vcard`.
* Set `vCard` text in the body, formatted like the preceding example.

## Additional resources

* <xref:web-api/advanced/formatting>
* <xref:grpc/dotnet-grpc>

:::moniker-end

:::moniker range="< aspnetcore-6.0"

ASP.NET Core MVC supports data exchange in Web APIs using input and output formatters. Input formatters are used by [Model Binding](xref:mvc/models/model-binding). Output formatters are used to [format responses](xref:web-api/advanced/formatting).

The framework provides built-in input and output formatters for JSON and XML. It provides a built-in output formatter for plain text, but doesn't provide an input formatter for plain text.

This article shows how to add support for additional formats by creating custom formatters. For an example of a custom plain text input formatter, see [TextPlainInputFormatter](https://github.com/aspnet/Entropy/blob/master/samples/Mvc.Formatters/TextPlainInputFormatter.cs) on GitHub.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/web-api/advanced/custom-formatters/samples) ([how to download](xref:index#how-to-download-a-sample))

## When to use a custom formatter

Use a custom formatter to add support for a content type that isn't handled by the built-in formatters.

## Overview of how to create a custom formatter

To create a custom formatter:

* For serializing data sent to the client, create an output formatter class.
* For deserializing data received from the client, create an input formatter class.
* Add instances of formatter classes to the <xref:Microsoft.AspNetCore.Mvc.MvcOptions.InputFormatters%2A> and <xref:Microsoft.AspNetCore.Mvc.MvcOptions.OutputFormatters%2A> collections in <xref:Microsoft.AspNetCore.Mvc.MvcOptions>.

## Create a custom formatter

To create a formatter:

* Derive the class from the appropriate base class. The sample app derives from <xref:Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter> and <xref:Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter>.
* Specify supported media types and encodings in the constructor.
* Override the <xref:Microsoft.AspNetCore.Mvc.Formatters.InputFormatter.CanReadType%2A> and <xref:Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter.CanWriteType%2A> methods.
* Override the <xref:Microsoft.AspNetCore.Mvc.Formatters.InputFormatter.ReadRequestBodyAsync%2A> and <xref:Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter.WriteResponseBodyAsync%2A> methods.

The following code shows the `VcardOutputFormatter` class from the [sample](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/web-api/advanced/custom-formatters/samples):

:::code language="csharp" source="custom-formatters/samples/3.x/CustomFormattersSample/Formatters/VcardOutputFormatter.cs" id="snippet_Class":::

### Derive from the appropriate base class

For text media types (for example, vCard), derive from the <xref:Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter> or <xref:Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter> base class:

:::code language="csharp" source="custom-formatters/samples/3.x/CustomFormattersSample/Formatters/VcardOutputFormatter.cs" id="snippet_ClassDeclaration":::

For binary types, derive from the <xref:Microsoft.AspNetCore.Mvc.Formatters.InputFormatter> or <xref:Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter> base class.

### Specify supported media types and encodings

In the constructor, specify supported media types and encodings by adding to the <xref:Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter.SupportedMediaTypes%2A> and <xref:Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter.SupportedEncodings%2A> collections:

:::code language="csharp" source="custom-formatters/samples/3.x/CustomFormattersSample/Formatters/VcardOutputFormatter.cs" id="snippet_ctor":::

A formatter class can **not** use constructor injection for its dependencies. For example, `ILogger<VcardOutputFormatter>` can't be added as a parameter to the constructor. To access services, use the context object that gets passed in to the methods. A code example in this article and the [sample](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/web-api/advanced/custom-formatters/samples) show how to do this.

### Override CanReadType and CanWriteType

Specify the type to deserialize into or serialize from by overriding the <xref:Microsoft.AspNetCore.Mvc.Formatters.InputFormatter.CanReadType%2A> or <xref:Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter.CanWriteType%2A> methods. For example, to create vCard text from a `Contact` type and vice versa:

:::code language="csharp" source="custom-formatters/samples/3.x/CustomFormattersSample/Formatters/VcardOutputFormatter.cs" id="snippet_CanWriteType":::

#### The CanWriteResult method

In some scenarios, <xref:Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter.CanWriteResult%2A> must be overridden rather than <xref:Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter.CanWriteType%2A>. Use `CanWriteResult` if the following conditions are true:

* The action method returns a model class.
* There are derived classes that might be returned at runtime.
* The derived class returned by the action must be known at runtime.

For example, suppose the action method:

* Signature returns a `Person` type.
* Can return a `Student` or `Instructor` type that derives from `Person`. 

For the formatter to handle only `Student` objects, check the type of <xref:Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext.Object> in the context object provided to the `CanWriteResult` method. When the action method returns <xref:Microsoft.AspNetCore.Mvc.IActionResult>:

* It's not necessary to use `CanWriteResult`.
* The `CanWriteType` method receives the runtime type.

<a id="read-write"></a>

### Override ReadRequestBodyAsync and WriteResponseBodyAsync

Deserialization or serialization is performed in <xref:Microsoft.AspNetCore.Mvc.Formatters.InputFormatter.ReadRequestBodyAsync%2A> or <xref:Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter.WriteResponseBodyAsync%2A>. The following example shows how to get services from the dependency injection container. Services can't be obtained from constructor parameters:

:::code language="csharp" source="custom-formatters/samples/3.x/CustomFormattersSample/Formatters/VcardOutputFormatter.cs" id="snippet_WriteResponseBodyAsync":::

## Configure MVC to use a custom formatter

To use a custom formatter, add an instance of the formatter class to the <xref:Microsoft.AspNetCore.Mvc.MvcOptions.InputFormatters%2A?displayProperty=nameWithType> or <xref:Microsoft.AspNetCore.Mvc.MvcOptions.OutputFormatters%2A?displayProperty=nameWithType> collection:

:::code language="csharp" source="custom-formatters/samples/3.x/CustomFormattersSample/Startup.cs" id="snippet_ConfigureServices" highlight="5-6":::

Formatters are evaluated in the order you insert them. The first one takes precedence.

## The complete `VcardInputFormatter` class

The following code shows the `VcardInputFormatter` class from the [sample](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/web-api/advanced/custom-formatters/samples):

:::code language="csharp" source="custom-formatters/samples/3.x/CustomFormattersSample/Formatters/VcardInputFormatter.cs" id="snippet_Class":::

## Test the app

[Run the sample app for this article](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/web-api/advanced/custom-formatters/samples), which implements basic vCard input and output formatters. The app reads and writes vCards similar to the following format:

```
BEGIN:VCARD
VERSION:2.1
N:Davolio;Nancy
FN:Nancy Davolio
END:VCARD
```

To see vCard output, run the app and send a Get request with Accept header `text/vcard` to `https://localhost:5001/api/contacts`.

To add a vCard to the in-memory collection of contacts:

* Send a `Post` request to `/api/contacts` with a tool like Postman.
* Set the `Content-Type` header to `text/vcard`.
* Set `vCard` text in the body, formatted like the preceding example.

## Additional resources

* <xref:web-api/advanced/formatting>
* <xref:grpc/dotnet-grpc>

:::moniker-end
