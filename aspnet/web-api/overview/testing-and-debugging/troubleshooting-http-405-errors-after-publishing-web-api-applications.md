---
uid: web-api/overview/testing-and-debugging/troubleshooting-http-405-errors-after-publishing-web-api-applications
title: "Troubleshooting HTTP 405 Errors after Publishing Web API 2 Applications | Microsoft Docs"
author: rmcmurray
description: "This tutorial describes how to troubleshoot HTTP 405 errors after publishing a Web API application to a production web server."
ms.author: aspnetcontent
manager: wpickett
ms.date: 05/01/2014
ms.topic: article
ms.assetid: 07ec7d37-023f-43ea-b471-60b08ce338f7
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/testing-and-debugging/troubleshooting-http-405-errors-after-publishing-web-api-applications
msc.type: authoredcontent
---
Troubleshooting HTTP 405 Errors after Publishing Web API 2 Applications
====================
by [Robert McMurray](https://github.com/rmcmurray)

> This tutorial describes how to troubleshoot HTTP 405 errors after publishing a Web API application to a production web server.
> 
> ## Software versions used in the tutorial
> 
> 
> - [Internet Information Services (IIS)](https://www.iis.net/) (version 7 or later)
> - [Web API](../../index.md) (version 1 or 2)


Web API applications typically use several common HTTP verbs: GET, POST, PUT, DELETE, and sometimes PATCH. That being said, developers may run into situations where those verbs are implemented by another IIS module on their production server, which leads to a situation where a Web API controller that works correctly in Visual Studio or on a development server will return an HTTP 405 error when it is deployed to a production server. Fortunately this problem is easily resolved, but the resolution warrants an explanation of why the problem is occurring.

## What Causes HTTP 405 Errors

The first step toward learning how to trouble HTTP 405 errors is to understand what an HTTP 405 error actually means. The primary governing document for HTTP is [RFC 2616](http://www.ietf.org/rfc/rfc2616.txt), which defines the HTTP 405 status code as ***Method Not Allowed***, and further describes this status code as a situation where &quot;the method specified in the Request-Line is not allowed for the resource identified by the Request-URI.&quot; In other words, the HTTP verb is not allowed for the specific URL that an HTTP client has requested.

As a brief review, here are several of the most-used HTTP methods as defined in RFC 2616, RFC 4918, and RFC 5789:

| HTTP Method | Description |
| --- | --- |
| **GET** | This method is used to retrieve data from a URI, and it probably the most-used HTTP method. |
| **HEAD** | This method is much like the GET method, except that it doesn't actually retrieve the data from the request URI - it simply retrieves the HTTP status. |
| **POST** | This method is typically used to send new data to the URI; POST is often used to submit form data. |
| **PUT** | This method is typically used to raw data to the URI; PUT is often used to submit JSON or XML data to Web API applications. |
| **DELETE** | This method is used to remove data from a URI. |
| **OPTIONS** | This method is typically used to retrieve the list of HTTP methods that are supported for a URI. |
| **COPY MOVE** | These two methods are used with WebDAV, and their purpose is self-explanatory. |
| **MKCOL** | This method is used with WebDAV, and it is used to create a collection (e.g. a directory) at the specified URI. |
| **PROPFIND PROPPATCH** | These two methods are used with WebDAV, and they are used to query or set properties for a URI. |
| **LOCK UNLOCK** | These two methods are used with WebDAV, and they are used to lock/unlock the resource identified by the request URI when authoring. |
| **PATCH** | This method is used to modify an existing HTTP resource. |

When one of these HTTP methods is configured for use on the server, the server will respond with the HTTP status and other data that is appropriate for the request. (For example, a GET method might receive an HTTP 200 ***OK*** response, and a PUT method might receive an HTTP 201 ***Created*** response.)

If the HTTP method is not configured for use on the server, the server will respond with an HTTP 501 ***Not Implemented*** error.

However, when an HTTP method is configured for use on the server, but it has been disabled for a given URI, the server will respond with an HTTP 405 ***Method Not Allowed*** error.

## Example HTTP 405 Error

The following example HTTP request and response illustrate a situation where an HTTP client is attempting to PUT value to a Web API application on a web server, and the server returns an HTTP error which states that the PUT method is not allowed:


HTTP Request:


[!code-console[Main](troubleshooting-http-405-errors-after-publishing-web-api-applications/samples/sample1.cmd)]


HTTP Response:


[!code-console[Main](troubleshooting-http-405-errors-after-publishing-web-api-applications/samples/sample2.cmd)]


In this example, the HTTP client sent a valid JSON request to the URL for a Web API application on a web server, but the server returned an HTTP 405 error message which indicates that the PUT method was not allowed for the URL. In contrast, if the request URI did not match a route for the Web API application, the server would return an HTTP 404 ***Not Found*** error.

## Resolving HTTP 405 Errors

There are several reasons why a specific HTTP verb may not be allowed, but there is one primary scenario that is the leading cause of this error in IIS: multiple handlers are defined for the same verb/method, and one of the handlers is blocking the expected handler from processing the request. By way of explanation, IIS processes handlers from first to last based on the order handler entries in the applicationHost.config and web.config files, where the first matching combination of path, verb, resource, etc., will be used to handle the request.

The following example is an excerpt from an applicationHost.config file for an IIS server that was returning an HTTP 405 error when using the PUT method to submit data to a Web API application. In this excerpt, several HTTP handlers are defined, and each handler has a different set of HTTP methods for which it is configured - the last entry in the list is the static content handler, which is the default handler that is used after the other handlers have had a chance to examine the request:

[!code-xml[Main](troubleshooting-http-405-errors-after-publishing-web-api-applications/samples/sample3.xml)]

In the above example, the WebDAV handler and the Extension-less URL Handler for ASP.NET (which is used for Web API) are clearly defined for separate lists of HTTP methods. Note that the ISAPI DLL handler is configured for all HTTP methods, although this configuration will not necessarily cause an error. However, configuration settings like this need to be considered when troubleshooting HTTP 405 errors.

In the above example, the ISAPI DLL handler was not the problem; in fact, the problem was not defined in the applicationHost.config file for the IIS server - the problem was caused by an entry that was made in the web.config file when the Web API application was created in Visual Studio. The following excerpt from the application's web.config file shows the location of the problem:

[!code-xml[Main](troubleshooting-http-405-errors-after-publishing-web-api-applications/samples/sample4.xml)]

In this excerpt, the Extension-less URL Handler for ASP.NET is redefined to include additional HTTP methods that will be used with the Web API application. However, since a similar set of HTTP methods is defined for the WebDAV handler, a conflict occurs. In this specific case, the WebDAV handler is defined and loaded by IIS, even though WebDAV is disabled for the website that includes the Web API application. During the processing of an HTTP PUT request, IIS calls the WebDAV module since it is defined for the PUT verb. When the WebDAV module is called, it checks its configuration and sees that it is disabled, so it will return an HTTP 405 ***Method Not Allowed*** error for any request that resembles a WebDAV request. To resolve this issue, you should remove WebDAV from the list of HTTP modules for the website where your Web API application is defined. The following example shows what that might look like:

[!code-xml[Main](troubleshooting-http-405-errors-after-publishing-web-api-applications/samples/sample5.xml)]

This scenario is often encountered after an application is published from a development environment to a production environment, and this occurs because the list of handlers/modules is different between your development and production environments. For example, if you are using Visual Studio 2012 or 2013 to develop a Web API application, IIS Express 8 is the default web server for testing. This development web server is a scaled-down version of the full IIS functionality that ships in a server product, and this development web server contains a few changes that were added for development scenarios. For example, the WebDAV module is often installed on a production web server that is running the full version of IIS, although it may not be in actual use. The development version of IIS, (IIS Express), installs the WebDAV module, but the entries for the WebDAV module are intentionally commented out, so the WebDAV module is never loaded on IIS Express unless you specifically alter your IIS Express configuration settings to add WebDAV functionality to your IIS Express installation. As a result, your web application may work correctly on your development computer, but you may encounter HTTP 405 errors when you publish your Web API application to your production web server.

## Summary

HTTP 405 errors are caused when an HTTP method is not allowed by a web server for a requested URL. This condition is often seen when a particular handler has been defined for a specific verb, and that handler is overriding the handler that you expect to process the request.

If you encounter a situation where you receive an HTTP 501 error message, which means that the specific functionality has not been implemented on the server, this often means that there is no handler defined in your IIS settings which matches the HTTP request, which probably indicates that something was not installed correctly on your system, or something has modified your IIS settings so that there are no handlers defined that support the specific HTTP method. To resolve that issue, you would need to reinstall any application that is attempting to use an HTTP method for which it has no corresponding module or handler definitions.