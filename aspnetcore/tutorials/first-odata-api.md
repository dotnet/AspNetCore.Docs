---
title: "Sample: Build web APIs with OData support using ASP.NET Core"
author: FIVIL
description: This tutorial demonstrates how to add OData support to your existing ASP.NET Core web API.
ms.author: riande
ms.date: 05/13/2019
uid: tutorials/first-odata-api
---

# Sample: Build web APIs with OData support using ASP.NET Core

By [FIVIL](https://github.com/fivil) and [Rick Anderson](https://twitter.com/RickAndMSFT)

This sample:

* Demonstrates how to add [OData](https://www.odata.org/) query options support in an ASP.NET Core Web API app.
* Uses the completed [to-do Web API](xref:tutorials/first-web-api) as a starting point.
* Does not use an [Entity Data Model](http://docs.oasis-open.org/odata/odata/v4.0/errata03/os/complete/part3-csdl/odata-v4.0-errata03-os-part3-csdl-complete.html#_Toc453752491) (EDM).

A malicious or naive client may construct a query that consumes excessive resources. Such a query can disrupt access to your service. Review `<xref:web-api/advanced/odata-security>` before starting this tutorial.

[!INCLUDE[](~/includes/net-core-prereqs-all-2.2.md)]

## Download the starter app

[Download Web API starter app](https://github.com/aspnet/Docs/tree/master/aspnetcore/tutorials/first-odata-api/samples/2.2/StarterApp) ([How to download](xref:index#how-to-download-a-sample)).

## Register OData

Add the [Microsoft.AspNetCore.OData](https://www.nuget.org/packages/Microsoft.AspNetCore.OData) NuGet package to the project.

Update the `ConfigureServices` method in *Startup.cs* with the following highlighted code:

 [!code-csharp[](first-odata-api/samples/2.2/TodoApi/Startup.cs?highlight=6-7&name=snippet_dic)]

The preceding code registers the OData service in the [dependency injection (DI)](xref:fundamentals/dependency-injection) container.

## Configure middleware

OData can perform sorting, filtering, querying related data, and more.  Each of these capabilities can be enabled or disabled with middleware.

Update `Configure` with the following highlighted code:

 [!code-csharp[](first-odata-api/samples/2.2/TodoApi/Startup.cs?highlight=17-21&name=snippet_configure)]

The preceding code:

* Enables an override to the existing endpoints through DI to route builder, instead of exposing a traditional OData endpoint.
* Enables select, order by, and filtering to the route builder.

## Update the controller

Add `[EnableQuery()]` to the `public ActionResult<IQueryable<TodoItem>> GetTodoItems()` method in the `TodoController`:

[!code-csharp[](first-odata-api/samples/2.2/TodoApi/Controllers/TodoController.cs?highlight=2&name=snippet_eq)]

Returning <xref:System.Linq.IQueryable> or [`ActionResult<IQueryable>`](xref:Microsoft.AspNetCore.Mvc.ActionResult`1) enables **OData** to translate queries to **SQL** queries using *ef core* capabilities. Returning other types such as `IEnumerable` causes **OData** to perform queries in the app.

## Query resources using OData

Post some data to the web API app, using a tool such as [Postman](https://www.getpostman.com/tools). See [How to use Postman](xref:tutorials/first-web-api#test-the-gettodoitems-method),

Send 5 Post requests to `https://localhost:5001/api/todo` with the 5 items below **separately** in the request body.

```json
{
    "name": "test OData",
    "isComplete": false,
    "Type": "work",
    "priority": 1,
    "DueDate": "2019-04-18 00:00:01"
}

{
    "name": "test 2",
    "isComplete": true,
    "Type": "shopping",
    "priority": 2,
    "DueDate": "2019-04-18 08:00:01"
}

{
    "name": "test 3",
    "isComplete": true,
    "Type": "work",
    "priority": 1,
    "DueDate": "2019-04-18 09:00:01"
}

{
    "name": "test 4",
    "isComplete": false,
    "Type": "shopping",
    "priority": 3,
    "DueDate": "2019-04-18 12:00:01"
}

{
    "name": "test 5",
    "isComplete": false,
    "Type": "work",
    "priority": 2,
    "DueDate": "2019-04-18 15:00:01"
}
```

Send a Get request to verify the previous data has been saved. For example,  `http://localhost:5001/api/todo?$select=name,isComplete`.

### $select

The `$select` option specifies a subset of properties to include in the response body. For example, to get only the *name* and *isComplete* of each item, add `?$select=name,isComplete` at the end the request path.

The preceding request returns the following data:

```JSON
[
    {
        "Name": "Item1",
        "IsComplete": false
    },
    {
        "Name": "test 5",
        "IsComplete": false
    },
    {
        "Name": "test OData",
        "IsComplete": false
    },
    {
        "Name": "test 2",
        "IsComplete": true
    },
    {
        "Name": "test 3",
        "IsComplete": true
    },
    {
        "Name": "test 4",
        "IsComplete": false
    }
]
```

### $orderBy

The `$orderBy` option can consume excessive resources. Consider using `[Queryable(AllowedQueryOptions=AllowedQueryOptions.{Option})]` to disable `$orderBy`.  See `<xref:web-api/advanced/odata-security#query-security>` for more information.

`$orderBy` sorts data based on one or more properties. For example, to order the data based on *priority* of each item, append `?$orderBy=priority` to the request. For example, `http://localhost:5001/api/todo?$orderBy=priority`.

The preceding request returns the following data:

```JSON
[
    {
        "id": 1,
        "name": "Item1",
        "isComplete": false,
        "type": null,
        "priority": 0,
        "dueDate": "0001-01-01T00:00:00"
    },
    {
        "id": 3,
        "name": "test OData",
        "isComplete": false,
        "type": "work",
        "priority": 1,
        "dueDate": "2019-04-18T00:00:01"
    },
    {
        "id": 5,
        "name": "test 3",
        "isComplete": true,
        "type": "work",
        "priority": 1,
        "dueDate": "2019-04-18T09:00:01"
    },
    {
        "id": 2,
        "name": "test 5",
        "isComplete": false,
        "type": "work",
        "priority": 2,
        "dueDate": "2019-04-18T15:00:01"
    },
    {
        "id": 4,
        "name": "test 2",
        "isComplete": true,
        "type": "shopping",
        "priority": 2,
        "dueDate": "2019-04-18T08:00:01"
    },
    {
        "id": 6,
        "name": "test 4",
        "isComplete": false,
        "type": "shopping",
        "priority": 3,
        "dueDate": "2019-04-18T12:00:01"
    }
]
```

Data can be sorted data based on multiple properties. For example, `?$orderBy=type,priority desc`" sorts items based on `type` and then on `priority` in **descending** order.

### $filter

The `$filter` option can consume excessive resources. Consider using `[Queryable(AllowedQueryOptions=AllowedQueryOptions.{Option})]` to disable `$filter`.  See `<xref:web-api/advanced/odata-security#query-security>` for more information.

`$filter` filters data based on a boolean condition. For example, to get only the items with `priority` greater than 1, append `?$filter=priority gt 1` to the  request path.

The preceding request returns the following data:

```JSON
[
    {
        "id": 2,
        "name": "test 5",
        "isComplete": false,
        "type": "work",
        "priority": 2,
        "dueDate": "2019-04-18T15:00:01"
    },
    {
        "id": 4,
        "name": "test 2",
        "isComplete": true,
        "type": "shopping",
        "priority": 2,
        "dueDate": "2019-04-18T08:00:01"
    },
    {
        "id": 6,
        "name": "test 4",
        "isComplete": false,
        "type": "shopping",
        "priority": 3,
        "dueDate": "2019-04-18T12:00:01"
    }
]
```

The following Boolean conditions can be used with the OData `$filter`:

|Condition | Description | Example |
|--- | ---- | ---- |
| eq | Equals to | $filter=priority et 1 |
| ne | Not equals to | $filter=priority ne 1 |
| gt | Greater than  | $filter=priority gt 1 |
| ge | Greater than or equal | $filter=priority ge 1 |
| lt | Less than | $filter=priority lt 1 |
| le | Less than or equal | $filter=priority le 1 |
| and | Logical and | $filter=priority gt 1 and priority lt 10 |
| or | Logical or | $filter=priority gt 1 or priority lt 10|
| not | Logical negation | $filter=not endswith(name,'task') |

String functions can be used with OData $filter. For more information, see the [OData URI Conventions'](https://www.odata.org/documentation/odata-version-2-0/uri-conventions/) `$filter` section.

### $skip

`$skip` skips the specified records. For example, to skip first 4 items, append `?$skip=4` to the request.

The preceding request returns the following data:

```JSON
[
    {
        "id": 5,
        "name": "test 3",
        "isComplete": true,
        "type": "work",
        "priority": 1,
        "dueDate": "2019-04-18T09:00:01"
    },
    {
        "id": 6,
        "name": "test 4",
        "isComplete": false,
        "type": "shopping",
        "priority": 3,
        "dueDate": "2019-04-18T12:00:01"
    }
]
```

### Chained queries

Chained queries can consume excessive resources. Consider using `[Queryable(AllowedQueryOptions=AllowedQueryOptions.{Option})]` to disable expensive operations. Consider restricting `$orderby` to properties in a clustered index.  See `<xref:web-api/advanced/odata-security#query-security>` for more information.

OData queries can be chained to make a complex query. For example, appending `?$skip=2&$select=name,priority&$orderBy=priority desc&filter=priority gt 1` returns the following data:

```JSON
[
    {
        "Name": "test 2",
        "priority": 2
    },
    {
        "Name": "test OData",
        "priority": 1
    },
    {
        "Name": "test 3",
        "priority": 1
    },
    {
        "Name": "Item1",
        "priority": 0
    }
]
```

## Additional resources

* [View or download sample code for this tutorial](https://github.com/aspnet/Docs/tree/master/aspnetcore/tutorials/first-odata-api/samples). See [how to download](xref:index#how-to-download-a-sample).
* `<xref:web-api/advanced/odata-security>`
* [OData official website](https://www.odata.org/)