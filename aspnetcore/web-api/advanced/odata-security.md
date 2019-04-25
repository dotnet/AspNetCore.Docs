---
title: Security Guidance for ASP.NET Core Web API OData
author: rick-anderson
description: Describes security issues to consider when exposing a dataset through OData for ASP.NET Core Web API
ms.author: riande
ms.date: 05/05/2019
uid: web-api/advanced/odata-security
---

# Security Guidance for ASP.NET Core Web API OData

https://docs.microsoft.com/en-us/dotnet/csharp/linq/

By [Mike Wasson](https://github.com/MikeWasson) and [Rick Anderson](https://twitter.com/RickAndMSFT)

This topic describes some of the security issues that you should consider when exposing a dataset through OData for ASP.NET Core Web API.

## EDM Security

The query semantics are based on the [Entity Data Model](https://www.odata.org/documentation/odata-version-2-0/overview/) (EDM), not the underlying model types. You can exclude a property from the EDM and it will not be visible to the query. For example, suppose your model includes an `Employee` type with a `Salary` property. You might want to exclude this property from the EDM to hide it from clients.

Properties can be excluded from the EDM with `[IgnoreDataMember]` or programmatically:
There are two ways to exclude a property from the EDM. You can set the `[IgnoreDataMember]` attribute on the property in the model class:

[!code-csharp[Main](odata-security/sample/ODataAPI/Models/Employee.cs?name=snippet)]

The following code removes the `Salary` property from the EDM programmatically:

[!code-csharp[Main](odata-security/sample/ODataAPI/StartupEDM.cs?name=snippet)]

## Query Security

A malicious or naive client may construct a query that takes excessive resources to execute. A malicious query can disrupt access to your service.

The `[EnableQuery]` attribute is an action filter that parses, validates, and applies the query. The filter converts the query options into a [LINQ](https://docs.microsoft.com/en-us/dotnet/csharp/linq/) expression. When the OData controller returns an <xref:System.Linq.IQueryable> type, the `IQueryable` LINQ provider converts the LINQ expression into a query. Therefore, performance depends on the LINQ provider that is used, and also on the particular characteristics of your dataset or database schema.

<!-- This could be eventually ported.
For more information about using OData query options in ASP.NET Web API, see [Supporting OData Query Options](supporting-odata-query-options.md).
-->

If all clients are trusted (for example, in an enterprise environment), or if the dataset is small, query performance might not be an issue. Otherwise, consider the following recommendations:

- Test your service with anticipated queries and profile the DB.
- Enable server-driven paging to avoid returning a large data set in one query. <!--For more information, see [Server-Driven Paging](supporting-odata-query-options.md#server-paging). -->

    [!code-csharp[Main](odata-security/sample/ODataAPI/Controllers/ValuesController.cs?name=snippet_PageSize)]

- Does the app require `$filter` and `$orderby`? Some apps might allow client paging, using `$top` and `$skip`, but disable the other query options.

    [!code-csharp[Main](odata-security/sample/ODataAPI/Controllers/ValuesController.cs?name=snippet_AllowedQueryOptions)]

- Consider restricting `$orderby` to properties in a clustered index. Sorting large data without a clustered index is resource intensive.

    [!code-csharp[Main](odata-security/sample/ODataAPI/Controllers/ValuesController.cs?name=snippet_AllowedOrderByProperties)]

- Maximum node count: The **MaxNodeCount** property on **[Queryable]** sets the maximum number nodes allowed in the $filter syntax tree. The default value is 100, but you may want to set a lower value, because a large number of nodes can be slow to compile. This is particularly true if you are using LINQ to Objects (i.e., LINQ queries on a collection in memory, without the use of an intermediate LINQ provider). 

    [!code-csharp[Main](odata-security/sample/ODataAPI/Controllers/ValuesController.cs?name=snippet_MaxNodeCount)]
- Consider disabling the `any` and `all` functions, as these can be resource intensive: 

    [!code-csharp[Main](odata-security/sample/ODataAPI/Controllers/ValuesController.cs?name=snippet_any)]

- If any string properties contain large strings&#8212;for example, a product description or a blog entry&#8212;consider disabling the string functions. 

    [!code-csharp[Main](odata-security/sample/ODataAPI/Controllers/ValuesController.cs?name=snippet_large)]

- Consider disallowing filtering on navigation properties. Filtering on navigation properties can result in a join, which might be slow, depending on your database schema. The following code shows a query validator that prevents filtering on navigation properties. <!-- For more information about query validators, see [Query Validation](supporting-odata-query-options.md#query-validation). -->

    [!code-csharp[Main]odata-security/sample/ODataAPI/ODataAttribute/MyFilterNavPropQueryValidator.cs?name=snippet)]

- Consider restricting `$filter` queries by writing a validator that is customized for the database. For example, consider these two queries:

  - All movies with actors whose last name starts with `A`.
  - All movies released in 1994.

    Unless movies are indexed by actors, the first query might require the DB engine to scan the entire list of movies. Whereas the second query might be acceptable, assuming movies are indexed by release year.

    The following code shows a validator that allows filtering on the `ReleaseYear` and `Title` properties but no other properties.

    [!code-csharp[Main]odata-security/sample/ODataAPI/ODataAttribute/MyFilterQueryValidator.cs?name=snippet)]

- In general, consider which $filter functions are required. If clients don't need the full expressiveness of `$filter`, limit the allowed functions.
