---
uid: web-api/overview/releases/whats-new-in-aspnet-web-api-21
title: "What's New in ASP.NET Web API 2.1 | Microsoft Docs"
author: microsoft
description: ""
ms.author: aspnetcontent
manager: wpickett
ms.date: 01/20/2014
ms.topic: article
ms.assetid: b6721bba-38c8-48c4-acbf-274c1a34e817
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/releases/whats-new-in-aspnet-web-api-21
msc.type: authoredcontent
---
What's New in ASP.NET Web API 2.1
====================
by [Microsoft](https://github.com/microsoft)

This topic describes what's new for ASP.NET Web API 2.1.

- [Download](#download)
- [Documentation](#documentation)
- [New Features in ASP.NET Web API 2.1](#new-features)

    - [Global Error Handling](#global-error)
    - [Attribute Routing Improvements](#attribute-routing)
    - [Help Page Improvements](#help-page)
    - [IgnoreRoute Support](#ignoreroute)
    - [BSON Media-Type Formatter](#bson)
    - [Better Support for Async Filters](#async-filters)
    - [Query Parsing for the Client Formatting Library](#query-parsing)
- [Known Issues and Breaking Changes](#known-issues)
- [Bug Fixes](#bug-fixes)

<a id="download"></a>
## Download

The runtime features are released as NuGet packages on the NuGet gallery. All the runtime packages follow the [Semantic Versioning](http://semver.org/) specification. The latest ASP.NET Web API 2.1 RTM package has the following version: "5.1.2". You can install or update these packages through [NuGet](http://www.nuget.org/packages/Microsoft.AspNet.WebApi/). The release also includes corresponding localized packages on NuGet.

You can install or update to the released NuGet packages by using the NuGet Package Manager Console:

[!code-console[Main](whats-new-in-aspnet-web-api-21/samples/sample1.cmd)]

<a id="documentation"></a>
## Documentation

Tutorials and other information about ASP.NET Web API 2.1 RTM are available from the ASP.NET web site ([https://www.asp.net/web-api](../../index.md)).

<a id="new-features"></a>
## New Features in ASP.NET Web API 2.1

<a id="global-error"></a>
### Global Error Handling

All unhandled exceptions can now be logged through one central mechanism, and the behavior for unhandled exceptions can be customized.

The framework supports multiple exception loggers, which all see the unhandled exception and information about the context in which it occurred, such as the request being processed at the time.

For example, the following code uses System.Diagnostics.TraceSource to log all unhandled exceptions:

[!code-csharp[Main](whats-new-in-aspnet-web-api-21/samples/sample2.cs)]

You can also replace the default exception handler, so that you can fully customize the HTTP response message that is sent when an unhandled exception occurs.

We have provided a [sample](http://aspnet.codeplex.com/SourceControl/latest#Samples/WebApi/Elmah/ReadMe.txt) that logs all unhandled exceptions via the popular ELMAH framework.

<a id="attribute-routing"></a>
### Attribute Routing Improvements

Attribute routing now supports constraints, enabling versioning and header-based route selection. Also, many aspects of attribute routes are now customizable via the **IDirectRouteFactory** interface and **RouteFactoryAttribute** class. The route prefix is now extensible via the **IRoutePrefix** interface and **RoutePrefixAttribute** class.

We have provided a [sample](http://aspnet.codeplex.com/SourceControl/latest#Samples/WebApi/RoutingConstraintsSample/ReadMe.txt) that uses constraints to dynamically filter controllers by an 'api-version' HTTP header.

<a id="help-page"></a>
### Help Page Improvements

Web API 2.1 includes the following enhancements to [API Help Pages](../getting-started-with-aspnet-web-api/creating-api-help-pages.md):

- Documentation of individual properties of parameters or return types of actions.
- Documentation of data model annotations.

The UI design of the help pages was also updated, to accomodate these changes.

<a id="ignoreroute"></a>
### IgnoreRoute Support

Web API 2.1 supports ignoring URL patterns in Web API routing, through a set of **IgnoreRoute** extension methods on **HttpRouteCollection**. These methods cause Web API to ignore any URLs that match a specified template, and allow the host to apply additional processing if appropriate.

The following example ignores URIs that start with a &quot;content&quot; segment:

[!code-csharp[Main](whats-new-in-aspnet-web-api-21/samples/sample3.cs)]

<a id="bson"></a>
### BSON Media-Type Formatter

Web API now supports the [BSON](http://bsonspec.org/) wire format, both on the client and on the server.

To enable BSON on the server side, add the **BsonMediaTypeFormatter** to the formatters collection:

[!code-csharp[Main](whats-new-in-aspnet-web-api-21/samples/sample4.cs)]

Here is how a .NET client can consume BSON format:

[!code-csharp[Main](whats-new-in-aspnet-web-api-21/samples/sample5.cs)]

We have provided a [sample](http://aspnet.codeplex.com/SourceControl/latest#Samples/WebApi/BSONSample/ReadMe.txt) that shows both the client and server side.

For more information, see [BSON Support in Web API 2.1](../formats-and-model-binding/bson-support-in-web-api-21.md)

<a id="async-filters"></a>
### Better Support for Async Filters

Web API now supports an easy way to create filters that execute asynchronously. This feature is useful is your filter needs to perform an async action, such as access a database. Previously, to create an async filter, you had to implement the filter interface yourself, because the filter base classes only exposed synchronous methods. Now you can override the virtual `On*Async` methods of the filter base class.

For example:

[!code-csharp[Main](whats-new-in-aspnet-web-api-21/samples/sample6.cs)]

The **AuthorizationFilterAttribute**, **ActionFilterAttribute**, and **ExceptionFilterAttribute** classes all support async in Web API 2.1.

<a id="query-parsing"></a>
### Query Parsing for the Client Formatting Library

Previously, **System.Net.Http.Formatting** supported parsing and updating URI queries for server-side code, but the equivalent portable library was missing this feature. In Web API 2.1, a client application can now easily parse and update a query string.

The following examples show how to parse, modify, and generate URI queries. (The examples show a console application for simplicity.)

[!code-csharp[Main](whats-new-in-aspnet-web-api-21/samples/sample7.cs)]

<a id="known-issues"></a>
## Known Issues and Breaking Changes

This section describes known issues and breaking changes in the ASP.NET Web API 2.1 RTM.

### Attribute Routing

Ambiguities in attribute routing matches now report an error rather than choosing the first match.

Attribute routes are prohibited from using the *{controller}* parameter, and from using the *{action}* parameter on routes placed on actions. These parameters would very likely cause ambiguities.

### Scaffolding MVC/Web API into a project with 5.1 packages results in 5.0 packages for ones that don't already exist in the project

Updating NuGet packages for ASP.NET Web API 2.1 RTM does not update the Visual Studio tools, such as ASP.NET scaffolding or the ASP.NET Web Application project template. They use the previous version of the ASP.NET runtime packages (5.0.0.0). As a result, the ASP.NET scaffolding will install the previous version (5.0.0.0) of the required packages, if they are not already available in your projects. However, the ASP.NET scaffolding in Visual Studio 2013 RTM or Update 1 does not overwrite the latest packages in your projects.

If you use ASP.NET scaffolding after updating the packages to Web API 2.1 or ASP.NET MVC 5.1, make sure the versions of Web API and MVC are consistent.

### Type Renames

Some of the types used for attribute routing extensibility were renamed from the RC to the 2.1 RTM.

| Old type name (2.1 RC) | New Type Name (2.1 RTM) |
| --- | --- |
| IDirectRouteProvider | IDirectRouteFactory |
| RouteProviderAttribute | RouteFactoryAttribute |
| DirectRouteProviderContext | DirectRouteFactoryContext |

### Exception filters do not unwrap aggregate exceptions thrown in async actions

Previously, if an async action threw an **AggregateException**, an exception filter would unwrap the exception, and **OnException** would get the base exception. In 2.1, the exception filter does not unwrap it, and **OnException** gets the original **AggregateException**.

<a id="bug-fixes"></a>
## Bug Fixes

This release also includes several bug fixes. You can find the complete list here:

- [5.1.0 package](https://aspnetwebstack.codeplex.com/workitem/list/advanced?keyword=&amp;status=Closed&amp;type=All&amp;priority=All&amp;release=v5.1%20Preview|v5.1%20RTM&amp;assignedTo=All&amp;component=Web%20API|Web%20API%20OData&amp;sortField=AssignedTo&amp;sortDirection=Ascending&amp;page=0&amp;reasonClosed=Fixed)
- [5.1.1 package](https://aspnetwebstack.codeplex.com/workitem/list/advanced?keyword=&status=All&type=All&priority=All&release=v5.1.1%20RTM&assignedTo=All&component=Web%20API&sortField=AssignedTo&sortDirection=Ascending&page=0&reasonClosed=Fixed)

The 5.1.2 package contains IntelliSense updates but no bug fixes.