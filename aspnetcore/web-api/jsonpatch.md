---
title: JsonPatch in ASP.NET Core web API
author: tdykstra
description: Learn how to handle JSON Patch requests in an ASP.NET Core web API.
ms.author: tdykstra
ms.custom: mvc
ms.date: 03/24/2019
uid: web-api/jsonpatch
---

# JsonPatch in ASP.NET Core web API

By [Tom Dykstra](https://github.com/tdykstra)

This article explains how to handle JSON Patch requests in an ASP.NET Core web API.

## PATCH HTTP request method

The PUT and [PATCH](https://tools.ietf.org/html/rfc5789) methods are used to update an existing resource. The difference between them is that PUT replaces the entire resource, while PATCH specifies only the changes.

## JSON Patch

[JSON Patch](https://tools.ietf.org/html/rfc6902) is a format for specifying updates to be applied to a resource. A JSON Patch document has an array of *operations*. Each operation identifies a particular type of change, such as add an array element or replace a property value.

For example, the following JSON documents represent a resource, a JSON patch document for the resource, and the result of applying the operations in the JSON patch document.

### Resource example

[!code-json[](jsonpatch/samples/2.2/JSON/customer.json)]

### JSON patch example

[!code-json[](jsonpatch/samples/2.2/JSON/add.json)]

In the preceding JSON:

* The `op` property indicates the type of operation.
* The `path` property indicates the element to update.
* The `value` property provides the new value.

### Resource after patch

Here's the resource after applying the preceding JSON Patch document:

```json
{
  "customerName": "Barry",
  "orders": [
    {
      "orderName": "Order0",
      "orderType": null
    },
    {
      "orderName": "Order1",
      "orderType": null
    },
    {
      "orderName": "Order2",
      "orderType": null
    }
  ]
}
```

The changes made by applying a JSON Patch document to a resource are atomic: if any operation in the list fails, no operation in the list is applied.

## Path syntax

The [path](http://tools.ietf.org/html/rfc6901) property of an operation object has slashes between levels. For example, `"/address/zipCode"`.

Zero-based indexes are used to specify array elements. The first element of the `addresses` array would be at `/addresses/0`. To `add` to the end of an array, use a hyphen (-) rather than an index number: `/addresses/-`.

### Operations

The following table shows supported operations as defined in the [JSON Patch specification](https://tools.ietf.org/html/rfc6902):

|Operation  | Notes |
|-----------|--------------------------------|
| `add`     | Add a property or array element. For existing property: set value.|
| `remove`  | Remove a property or array element. |
| `replace` | Same as `remove` followed by `add` at same location. |
| `move`    | Same as `remove` from source followed by `add` to destination using value from source. |
| `copy`    | Same as `add` to destination using value from source. |
| `test`    | Return success status code if value at `path` = provided `value`.|

## JsonPatch in ASP.NET Core

The ASP.NET Core implementation of JSON Patch is provided in the [Microsoft.AspNetCore.JsonPatch](https://www.nuget.org/packages/microsoft.aspnetcore.jsonpatch/) NuGet package. The package is included in the [Microsoft.AspnetCore.App](xref:fundamentals/metapackage-app) metapackage.

## Action method code

In an API controller, an action method for JSON Patch:

* Is annotated with the `HttpPatch` attribute.
* Accepts a `JsonPatchDocument<T>`, typically with [FromBody].
* Calls `ApplyTo` on the patch document to apply the changes.

Here's an example:

[!code-csharp[](jsonpatch/samples/2.2/Controllers/HomeController.cs?name=snippet_PatchAction)]

### Model state

The preceding example calls an overload of `ApplyTo` that lets you pass in model state. With this option, you can get error messages in responses. The following example shows the body of a 400 Bad Request response for a `test` operation:

```json
{
    "Customer": [
        "The current value 'John' at path 'customerName' is not equal to the test value 'Nancy'."
    ]
}
```

### Dynamic objects

The following action method example applies a patch to a dynamic object.

[!code-csharp[](jsonpatch/samples/2.2/Controllers/HomeController.cs?name=snippet_Dynamic)]

## The add operation

* If `path` points to an array element: inserts new element before the one specified by `path`.
* If `path` points to a property: sets the property value.
* If `path` points to a nonexistent location:
  * If the resource to patch is a dynamic object: adds a property.
  * If the resource to patch is a static object: the request fails.

## The remove operation

* If `path` points to an array element: removes the element.
* If `path` points to a property:
  * If resource to patch is a dynamic object: removes the property.
  * If resource to patch is a static object: 
    * If the property is nullable: sets it to null.
    * If the property is non-nullable, sets it to `default<T>`.

## The replace operation

Functionally the same as a `remove` followed by an `add`.

## The move operation

* If `path` points to an array element: copies `from` element to location of `path` element, then runs a `remove` operation on the `from` element.
* If `path` points to a property: copies value of `from` property to `path` property, then runs a `remove` operation on the `from` property.
* If `path` points to a nonexistent property:
  * If the resource to patch is a static object: the request fails.
  * If the resource to patch is a dynamic object: copies `from` property to location indicated by `path`, then runs a `remove` operation on the `from` property.

## The copy operation

Functionally the same as a `move` operation without the final `remove` step.

## The test operation

If the value at the location indicated by `path` is different from the value provided in `value`, the request fails. In that case, the whole PATCH request fails even if all other operations in the patch document would succeed.

The `test` operation is commonly used to prevent an update when there's a concurrency conflict.

## Get the code

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/web-api/jsonpatch/samples/2.2). ([how to download](xref:index#how-to-download-a-sample)).

To try out the sample app, run the project, and then send HTTP requests with the following settings:

* URL: `http://localhost:{port}/jsonpatch/jsonpatchwithmodelstate`
* HTTP method: `PATCH`
* Header: `Content-Type: application/json-patch+json`
* Body: Copy and paste one of the JSON patch document samples from the *JSON* project folder.

## Additional resources

* [IETF RFC 5789 PATCH method specification](https://tools.ietf.org/html/rfc5789)
* [IETF RFC 6902 JSON Patch specification](https://tools.ietf.org/html/rfc6902)
* [IETF RFC 6901 JSON Patch path format spec](http://tools.ietf.org/html/rfc6901)
* [JSON Patch documentation](http://jsonpatch.com/), including resources for creating JSON Patch documents.
* [ASP.NET Core JSON Patch source code](https://github.com/aspnet/AspNetCore/tree/master/src/Features/JsonPatch/src)
