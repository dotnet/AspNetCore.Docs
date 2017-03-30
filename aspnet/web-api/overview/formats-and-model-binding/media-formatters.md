---
uid: web-api/overview/formats-and-model-binding/media-formatters
title: "Media Formatters in ASP.NET Web API 2 | Microsoft Docs"
author: MikeWasson
description: ""
ms.author: aspnetcontent
manager: wpickett
ms.date: 01/20/2014
ms.topic: article
ms.assetid: 4c56f64a-086a-44ce-99c2-4c69604cd7fd
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/formats-and-model-binding/media-formatters
msc.type: authoredcontent
---
Media Formatters in ASP.NET Web API 2
====================
by [Mike Wasson](https://github.com/MikeWasson)

This tutorial shows how support additional media formats in ASP.NET Web API.

## Internet Media Types

A media type, also called a MIME type, identifies the format of a piece of data. In HTTP, media types describe the format of the message body. A media type consists of two strings, a type and a subtype. For example:

- text/html
- image/png
- application/json

When an HTTP message contains an entity-body, the Content-Type header specifies the format of the message body. This tells the receiver how to parse the contents of the message body.

For example, if an HTTP response contains a PNG image, the response might have the following headers.

[!code-console[Main](media-formatters/samples/sample1.cmd)]

When the client sends a request message, it can include an Accept header. The Accept header tells the server which media type(s) the client wants from the server. For example:

[!code-console[Main](media-formatters/samples/sample2.cmd)]

This header tells the server that the client wants either HTML, XHTML, or XML.

The media type determines how Web API serializes and deserializes the HTTP message body. Web API has built-in support for XML, JSON, BSON, and form-urlencoded data, and you can support additional media types by writing a *media formatter*.

To create a media formatter, derive from one of these classes:

- [MediaTypeFormatter](https://msdn.microsoft.com/en-us/library/system.net.http.formatting.mediatypeformatter.aspx). This class uses asynchronous read and write methods.
- [BufferedMediaTypeFormatter](https://msdn.microsoft.com/en-us/library/system.net.http.formatting.bufferedmediatypeformatter.aspx). This class derives from **MediaTypeFormatter** but uses sychronous read/write methods.

Deriving from **BufferedMediaTypeFormatter** is simpler, because there is no asynchronous code, but it also means the calling thread can block during I/O.

## Example: Creating a CSV Media Formatter

The following example shows a media type formatter that can serialize a Product object to a comma-separated values (CSV) format. This example uses the Product type defined in the tutorial [Creating a Web API that Supports CRUD Operations](../older-versions/creating-a-web-api-that-supports-crud-operations.md). Here is the definition of the Product object:

[!code-csharp[Main](media-formatters/samples/sample3.cs)]

To implement a CSV formatter, define a class that derives from **BufferedMediaTypeFormater**:

[!code-csharp[Main](media-formatters/samples/sample4.cs)]

In the constructor, add the media types that the formatter supports. In this example, the formatter supports a single media type, &quot;text/csv&quot;:

[!code-csharp[Main](media-formatters/samples/sample5.cs)]

Override the **CanWriteType** method to indicate which types the formatter can serialize:

[!code-csharp[Main](media-formatters/samples/sample6.cs)]

In this example, the formatter can serialize single `Product` objects as well as collections of `Product` objects.

Similarly, override the **CanReadType** method to indicate which types the formatter can deserialize. In this example, the formatter does not support deserialization, so the method simply returns **false**.

[!code-csharp[Main](media-formatters/samples/sample7.cs)]

Finally, override the **WriteToStream** method. This method serializes a type by writing it to a stream. If your formatter supports deserialization, also override the **ReadFromStream** method.

[!code-csharp[Main](media-formatters/samples/sample8.cs)]

## Adding a Media Formatter to the Web API Pipeline

To add a media type formatter to the Web API pipeline, use the **Formatters** property on the **HttpConfiguration** object.

[!code-csharp[Main](media-formatters/samples/sample9.cs)]

## Character Encodings

Optionally, a media formatter can support multiple character encodings, such as UTF-8 or ISO 8859-1.

In the constructor, add one or more [System.Text.Encoding](https://msdn.microsoft.com/en-us/library/system.text.encoding.aspx) types to the **SupportedEncodings** collection. Put the default encoding first.

[!code-csharp[Main](media-formatters/samples/sample10.cs?highlight=6-7)]

In the **WriteToStream** and **ReadFromStream** methods, call [MediaTypeFormatter.SelectCharacterEncoding](https://msdn.microsoft.com/en-us/library/hh969054.aspx) to select the preferred character encoding. This method matches the request headers against the list of supported encodings. Use the returned **Encoding** when you read or write from the stream:

[!code-csharp[Main](media-formatters/samples/sample11.cs?highlight=3,5)]