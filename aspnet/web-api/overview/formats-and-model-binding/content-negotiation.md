---
uid: web-api/overview/formats-and-model-binding/content-negotiation
title: "Content Negotiation in ASP.NET Web API | Microsoft Docs"
author: MikeWasson
description: "Describes how ASP.NET Web API implements HTTP content negotiation."
ms.author: aspnetcontent
manager: wpickett
ms.date: 05/20/2012
ms.topic: article
ms.assetid: 0dd51b30-bf5a-419f-a1b7-2817ccca3c7d
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/formats-and-model-binding/content-negotiation
msc.type: authoredcontent
---
Content Negotiation in ASP.NET Web API
====================
by [Mike Wasson](https://github.com/MikeWasson)

This article describes how ASP.NET Web API implements content negotiation.

The HTTP specification (RFC 2616) defines content negotiation as "the process of selecting the best representation for a given response when there are multiple representations available." The primary mechanism for content negotiation in HTTP are these request headers:

- **Accept:** Which media types are acceptable for the response, such as "application/json," "application/xml," or a custom media type such as &quot;application/vnd.example+xml&quot;
- **Accept-Charset:** Which character sets are acceptable, such as UTF-8 or ISO 8859-1.
- **Accept-Encoding:** Which content encodings are acceptable, such as gzip.
- **Accept-Language:** The preferred natural language, such as "en-us".

The server can also look at other portions of the HTTP request. For example, if the request contains an X-Requested-With header, indicating an AJAX request, the server might default to JSON if there is no Accept header.

In this article, we'll look at how Web API uses the Accept and Accept-Charset headers. (At this time, there is no built-in support for Accept-Encoding or Accept-Language.)

## Serialization

If a Web API controller returns a resource as CLR type, the pipeline serializes the return value and writes it into the HTTP response body.

For example, consider the following controller action:

[!code-csharp[Main](content-negotiation/samples/sample1.cs)]

A client might send this HTTP request:

[!code-console[Main](content-negotiation/samples/sample2.cmd)]

In response, the server might send:

[!code-console[Main](content-negotiation/samples/sample3.cmd)]

In this example, the client requested either JSON, Javascript, or "anything" (\*/\*). The server responsed with a JSON representation of the `Product` object. Notice that the Content-Type header in the response is set to &quot;application/json&quot;.

A controller can also return an **HttpResponseMessage** object. To specify a CLR object for the response body, call the **CreateResponse** extension method:

[!code-csharp[Main](content-negotiation/samples/sample4.cs)]

This option gives you more control over the details of the response. You can set the status code, add HTTP headers, and so forth.

The object that serializes the resource is called a *media formatter*. Media formatters derive from the **MediaTypeFormatter** class. Web API provides media formatters for XML and JSON, and you can create custom formatters to support other media types. For information about writing a custom formatter, see [Media Formatters](media-formatters.md).

## How Content Negotiation Works

First, the pipeline gets the **IContentNegotiator** service from the **HttpConfiguration** object. It also gets the list of media formatters from the **HttpConfiguration.Formatters** collection.

Next, the pipeline calls **IContentNegotiatior.Negotiate**, passing in:

- The type of object to serialize
- The collection of media formatters
- The HTTP request

The **Negotiate** method returns two pieces of information:

- Which formatter to use
- The media type for the response

If no formatter is found, the **Negotiate** method returns **null**, and the client recevies HTTP error 406 (Not Acceptable).

The following code shows how a controller can directly invoke content negotiation:

[!code-csharp[Main](content-negotiation/samples/sample5.cs)]

This code is equivalent to the what the pipeline does automatically.

## Default Content Negotiator

The **DefaultContentNegotiator** class provides the default implementation of **IContentNegotiator**. It uses several criteria to select a formatter.

First, the formatter must be able to serialize the type. This is verified by calling **MediaTypeFormatter.CanWriteType**.

Next, the content negotiator looks at each formatter and evaluates how well it matches the HTTP request. To evaluate the match, the content negotiator looks at two things on the formatter:

- The **SupportedMediaTypes** collection, which contains a list of supported media types. The content negotiator tries to match this list against the request Accept header. Note that the Accept header can include ranges. For example, "text/plain" is a match for text/\* or \*/\*.
- The **MediaTypeMappings** collection, which contains a list of **MediaTypeMapping** objects. The **MediaTypeMapping** class provides a generic way to match HTTP requests with media types. For example, it could map a custom HTTP header to a particular media type.

If there are multiple matches, the match with the highest quality factor wins. For example:

[!code-console[Main](content-negotiation/samples/sample6.cmd)]

In this example, application/json has an implied quality factor of 1.0, so it is preferred over application/xml.

If no matches are found, the content negotiator tries to match on the media type of the request body, if any. For example, if the request contains JSON data, the content negotiator looks for a JSON formatter.

If there are still no matches, the content negotiator simply picks the first formatter that can serialize the type.

## Selecting a Character Encoding

After a formatter is selected, the content negotiator chooses the best character encoding by looking at the **SupportedEncodings** property on the formatter, and matching it against the Accept-Charset header in the request (if any).
