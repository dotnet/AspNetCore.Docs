---
uid: web-api/overview/releases/whats-new-in-aspnet-web-api-odata-53
title: "What's New in ASP.NET Web API OData 5.3 | Microsoft Docs"
author: microsoft
description: ""
ms.author: aspnetcontent
manager: wpickett
ms.date: 09/16/2014
ms.topic: article
ms.assetid: e39eaa25-83ff-41dc-869d-3818d59a88ae
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/releases/whats-new-in-aspnet-web-api-odata-53
msc.type: authoredcontent
---
What's New in ASP.NET Web API OData 5.3
====================
by [Microsoft](https://github.com/microsoft)

This topic describes what's new for ASP.NET Web API OData 5.3.

- [Download](#download)
- [Documentation](#documentation)
- [OData Core Libraries](#corelib)
- [New Features](#newf)
- [Known Issues and Breaking Changes](#known-issues)
- [Bug Fixes](#bug-fixes)
- [ASP.NET Web API OData 5.3.1](#OD)

<a id="download"></a>
## Download

The runtime features are released as NuGet packages on the NuGet gallery. You can install or update to the released NuGet packages by using the NuGet Package Manager Console:

[!code-console[Main](whats-new-in-aspnet-web-api-odata-53/samples/sample1.cmd)]

<a id="documentation"></a>
## Documentation

You can find tutorials and other documentation about ASP.NET Web API OData at the [ASP.NET web site](../odata-support-in-aspnet-web-api/index.md).

<a id="corelib"></a>
## OData Core Libraries

For OData v4, Web API now uses ODataLib version 6.5.0

<a id="newf"></a>
## New Features in ASP.NET Web API OData 5.3

### Support for $levels in $expand

You can use the $levels query option in $expand queries. For example:

[!code-console[Main](whats-new-in-aspnet-web-api-odata-53/samples/sample2.cmd)]

This query is equivalent to:

[!code-console[Main](whats-new-in-aspnet-web-api-odata-53/samples/sample3.cmd)]

<a id="open-entity-types"></a>
### Support for Open Entity Types

An *open type* is a stuctured type that contains dynamic properties, in addition to any properties that are declared in the type definition. Open types let you add flexibility to your data models. For more information, see xxxx.

### Support for dynamic collection properties in open types

Previously, a dynamic property had to be a single value. In 5.3, dynamic properties can have collection values. For example, in the following JSON payload, the `Emails` property is a dynamic property and is of collection of string type:

[!code-console[Main](whats-new-in-aspnet-web-api-odata-53/samples/sample4.cmd)]

### Support for inheritance for complex types

Now complex types can inherit from a base type. For example, an OData service could define the following complex types:

[!code-csharp[Main](whats-new-in-aspnet-web-api-odata-53/samples/sample5.cs)]

Here is the EDM for this example:

[!code-xml[Main](whats-new-in-aspnet-web-api-odata-53/samples/sample6.xml?highlight=8,15)]

For more information, see [OData Complex Type Inheritance Sample](http://aspnet.codeplex.com/SourceControl/latest#Samples/WebApi/OData/v4/ODataComplexTypeInheritanceSample/ReadMe.txt).

<a id="known-issues"></a>
## Known Issues and Breaking Changes

This section describes known issues and breaking changes in the ASP.NET Web API OData 5.3.

### OData v4

#### Query Options

Issue: Using nested $expand with $levels=max results in an incorrect expansion depth.

For example, given the following request:

[!code-console[Main](whats-new-in-aspnet-web-api-odata-53/samples/sample7.cmd)]

If `MaxExpansionDepth` is 5, this query would result in an expansion depth of 6.

<a id="bug-fixes"></a>
## Bug Fixes and Minor Feature Updates

This release also includes several bug fixes and minor feature updates. You can find the complete list here:

- [Bug fixes](https://aspnetwebstack.codeplex.com/workitem/list/advanced?keyword=&status=All&type=All&priority=All&release=v5.3%20Beta&assignedTo=All&component=Web%20API|Web%20API%20OData&sortField=AssignedTo&sortDirection=Ascending&page=0&reasonClosed=Fixed)

<a id="OD"></a>
## ASP.NET Web API OData 5.3.1

In this release we made a [bug fix](https://aspnetwebstack.codeplex.com/workitem/list/advanced?keyword=&amp;status=All&amp;type=All&amp;priority=All&amp;release=v5.3.1%20Beta&amp;assignedTo=All&amp;component=Web%20API%20OData&amp;sortField=LastUpdatedDate&amp;sortDirection=Descending&amp;page=0&amp;reasonClosed=All) to some of the AllowedFunctions enums. This release doesn't have any other bug fixes or new features.