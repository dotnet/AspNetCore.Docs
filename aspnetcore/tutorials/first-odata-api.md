---
title: "Tutorial: Build web APIs with OData support using ASP.NET Core"
author: FIVIL
description: This tutorial demonstrates how to add OData support to your existing ASP.NET Core web API.
ms.author: riande
ms.date: 05/13/2019
uid: tutorials/first-odata-api
---

# Tutorial: Build web APIs with OData support using ASP.NET Core

By [FIVIL](https://github.com/fivil) and [Rick Anderson](https://twitter.com/RickAndMSFT)

This tutorial demonstrates how to add [OData](https://www.odata.org/) query options support in an ASP.NET Core Web API app.

This tutorial uses the completed [to-do Web API](xref:tutorials/first-web-api) as a starting point.

[!INCLUDE[](~/includes/net-core-prereqs-all-2.2.md)]

## Update the model class

[Download Web API sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/tutorials/first-web-api/samples) ([How to download](xref:index#how-to-download-a-sample)).

Add the [Microsoft.AspNetCore.OData](https://www.nuget.org/packages/Microsoft.AspNetCore.OData) NuGet package to the project.

Add the following highlighted properties to *Models\TodoItem.cs*:

[!code-csharp[](first-odata-api/samples/2.2/TodoApi/Models/TodoItem.cs?name=snippet)]

## Register OData

In ASP.NET Core you should 

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

Add `[EnableQuery()]` to the `public ActionResult<IQueryable<TodoItem>> GetTodoItems()` method in the `TodoController`

Update *TodoController.cs* under *Controllers* directory, add `[EnableQuery()]` attribute:

[!code-csharp[](first-odata-api/samples/2.2/TodoApi/Controllers/TodoController.cs?highlight=7,32-36&name=all)]

Returning <xref:System.Linq.IQueryable> or [`ActionResult<IQueryable>`](xref:Microsoft.AspNetCore.Mvc.ActionResult`1) enables **OData** to translate queries to **SQL** queries using *ef core* capabilities.  Returning other types such as `IEnumerable` causes **OData** to perform queries in the app.

## Query resources using OData

Post some data to the web API app, using a tool such as [Postman](https://www.getpostman.com/tools). See [How to use Postman](xref:tutorials/first-web-api#test-the-gettodoitems-method),

Send a Post request to `https://localhost:5001/api/todo` and include each of the items below **separately** in the request body.

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

The **$select** option specifies a subset of properties to include in the response body. For example, to get only the *name* and *isComplete* of each item, add `?$select=name,isComplete` at the end the request path.

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

The **$orderBy** option sorts data based on one or more properties. For example, to order the data based on *priority* of each item, append `?$orderBy=priority` to the request. For example, `http://localhost:5001/api/todo?$orderBy=priority`.

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

Data can be sorted data based on multiple properties. For example, `?$orderBy=type,priority desc`" sorts items based on *type* and then on *priority* in **descending** order.

### $filter

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

## Security concerns

A malicious or naive client can construct a query that:

* Takes significant system resources. Such a query can disrupt your service.
* Leaks sensitive information by a clear join.

The `[Queryable]` attribute is an action filter that parses, validates, and applies the query. The filter converts the query options into a LINQ expression. When the OData controller returns an `IQueryable` type, the `IQueryable` LINQ provider converts the LINQ expression into a query. Therefore, performance depends on the LINQ provider that is used, and on the particular characteristics of the dataset or database schema.

If you know that all clients are trusted (for example, in an enterprise environment), or if your dataset is small, query performance might not be an issue. Otherwise, consider the following recommendations:

* Enable server-driven paging, to avoid returning a large data set in one query.

  [!code-csharp[](first-odata-api/samples/2.2/TodoApi/Controllers/TodoController2.cs?name=PageSizeOption)]

  With server-driven paging enabled:

  * The endpoint returns only a limited number of records (for example 3).
  * More records can be returned using the `$Skip` option.

* Consider restricting `$orderby` to properties in a clustered index. Sorting a  large data without a clustered index is slow.

  [!code-csharp[](first-odata-api/samples/2.2/TodoApi/Controllers/TodoController2.cs?name=orderOption)]

* Test the service with various queries and profile the DB.
* Use the `[Queryable]` attribute filters to prevent or allow options. Disallow all unnecessary demanding functionalities.

## Additional resources

* [View or download sample code for this tutorial](https://github.com/aspnet/Docs/tree/master/aspnetcore/tutorials/first-odata-api/samples). See [how to download](xref:index#how-to-download-a-sample).
* [OData official website](https://www.odata.org/)