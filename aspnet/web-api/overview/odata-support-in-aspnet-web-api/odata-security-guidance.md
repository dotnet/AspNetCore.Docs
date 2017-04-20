---
uid: web-api/overview/odata-support-in-aspnet-web-api/odata-security-guidance
title: "Security Guidance for ASP.NET Web API 2 OData | Microsoft Docs"
author: MikeWasson
description: ""
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/06/2013
ms.topic: article
ms.assetid: b91e6424-1544-4747-bd0b-d1f8418c9653
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/odata-support-in-aspnet-web-api/odata-security-guidance
msc.type: authoredcontent
---
Security Guidance for ASP.NET Web API 2 OData
====================
by [Mike Wasson](https://github.com/MikeWasson)

This topic describes some of the security issues that you should consider when exposing a dataset through OData.

## EDM Security

The query semantics are based on the entity data model (EDM), not the underlying model types. You can exclude a property from the EDM and it will not be visible to the query. For example, suppose your model includes an Employee type with a Salary property. You might want to exclude this property from the EDM to hide it from clients.

There are two ways to exlude a property from the EDM. You can set the **[IgnoreDataMember]** attribute on the property in the model class:

[!code-csharp[Main](odata-security-guidance/samples/sample1.cs)]

You can also remove the property from the EDM programmatically:

[!code-csharp[Main](odata-security-guidance/samples/sample2.cs)]

## Query Security

A malicious or naive client may be able to construct a query that takes a very long time to execute. In the worst case this can disrupt access to your service.

The **[Queryable]** attribute is an action filter that parses, validates, and applies the query. The filter converts the query options into a LINQ expression. When the OData controller returns an **IQueryable** type, the **IQueryable** LINQ provider converts the LINQ expression into a query. Therefore, performance depends on the LINQ provider that is used, and also on the particular characteristics of your dataset or database schema.

For more information about using OData query options in ASP.NET Web API, see [Supporting OData Query Options](supporting-odata-query-options.md).

If you know that all clients are trusted (for example, in an enterprise environment), or if your dataset is small, query performance might not be an issue. Otherwise, you should consider the following recommendations.

- Test your service with various queries and profile the DB.
- Enable server-driven paging, to avoid returning a large data set in one query. For more information, see [Server-Driven Paging](supporting-odata-query-options.md#server-paging). 

    [!code-csharp[Main](odata-security-guidance/samples/sample3.cs)]
- Do you need $filter and $orderby? Some applications might allow client paging, using $top and $skip, but disable the other query options. 

    [!code-csharp[Main](odata-security-guidance/samples/sample4.cs)]
- Consider restricting $orderby to properties in a clustered index. Sorting large data without a clustered index is slow. 

    [!code-csharp[Main](odata-security-guidance/samples/sample5.cs)]
- Maximum node count: The **MaxNodeCount** property on **[Queryable]** sets the maximum number nodes allowed in the $filter syntax tree. The default value is 100, but you may want to set a lower value, because a large number of nodes can be slow to compile. This is particularly true if you are using LINQ to Objects (i.e., LINQ queries on a collection in memory, without the use of an intermediate LINQ provider). 

    [!code-csharp[Main](odata-security-guidance/samples/sample6.cs)]
- Consider disabling the any() and all() functions, as these can be slow. 

    [!code-csharp[Main](odata-security-guidance/samples/sample7.cs)]
- If any string properties contain large strings&#8212for example, a product description or a blog entry&#8212consider disabling the string functions. 

    [!code-csharp[Main](odata-security-guidance/samples/sample8.cs)]
- Consider disallowing filtering on navigation properties. Filtering on navigation properties can result in a join, which might be slow, depending on your database schema. The following code shows a query validator that prevents filtering on navigation properties. For more information about query validators, see [Query Validation](supporting-odata-query-options.md#query-validation). 

    [!code-csharp[Main](odata-security-guidance/samples/sample9.cs)]
- Consider restricting $filter queries by writing a validator that is customized for your database. For example, consider these two queries: 

    - All movies with actors whose last name starts with ‘A'.
    - All movies released in 1994.

    Unless movies are indexed by actors, the first query might require the DB engine to scan the entire list of movies. Whereas the second query might be acceptable, assuming movies are indexed by release year.

    The following code shows a validator that allows filtering on the "ReleaseYear" and "Title" properties but no other properties.

    [!code-csharp[Main](odata-security-guidance/samples/sample10.cs)]
- In general, consider which $filter functions you need. If your clients do not need the full expressiveness of $filter, you can limit the allowed functions.