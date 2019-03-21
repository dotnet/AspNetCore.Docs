---
title: JsonPatch in ASP.NET Core Web API
author: tdykstra
description: Learn how to handle JSON Patch requests in an ASP.NET Core Web API.
ms.author: tdykstra
ms.custom: mvc
ms.date: 03/24/2019
uid: web-api/jsonpatch
---

# JsonPatch in ASP.NET Core Web API

By [Tom Dykstra](https://github.com/tdykstra)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/web-api/jsonpatch/samples/2.2) ([how to download](xref:index#how-to-download-a-sample)).

This article explains how to handle JSON Patch requests in an ASP.NET Core Web API.

## PATCH HTTP request method

The PUT and [PATCH](https://tools.ietf.org/html/rfc5789) methods are used to update an existing resource. The difference between them is that PUT provides the entire resource to replace the existing one, while PATCH specifies only the changes. Using the PATCH method can improve performance when resources to be updated are large and the changes are small.

## JSON Patch

[JSON Patch](https://tools.ietf.org/html/rfc6902) is a JSON schema for identifying changes to be made in a resource. Its HTML media type is “application/json-patch+json”.

A JSON Patch document has an array of one or more objects that are referred to as *operations*. Each operation identifies a particular type of change, such as add or remove an array element. The changes made by applying a JSON Patch document are atomic: if any operation in the list fails, none are applied.

## Example

Suppose the resource is an array of contact names:

```json
{
  "contacts": [
    {
      "firstName": "Barry",
      "lastName": "McCarty",
    }
  ]
}
```

In the following JSON Patch document:

* The `op` property indicates the operation.
* The `path` property indicates which element in the target object should be updated.
* The `from` property indicates the source element.
* The `value` property provides the new value.

```json
[
    {
         "op": "copy",
         "from": "/contacts/0",
         "path": "/contacts/-",
    }
    {
         "op": "replace",
         "path": "contacts/1/lastname",
         "value": "McCarty"
    }
]
```

After applying the preceding JSON Patch document, the original document is changed to this:

```json
{
  "contacts": [
    {
      "firstName": "Barry",
      "lastName": "Durand",
    }
    {
      "firstName": "Barry",
      "lastName": "McCarty",
    }
  ]
}

```

## Path syntax

The [path](http://tools.ietf.org/html/rfc6901) property of an operation object has slashes between levels. For example, `"/address/zipCode"`.

Zero-based indexes are used to specify arrays elements. The first element of the `addresses` array would be at `"/addresses/0"`. To `add` to the end of an array, use a hyphen (-) rather than an index number: `"/addresses/-"`.

### Operations

The following table shows supported operations according to [the JSON Patch specification](https://tools.ietf.org/html/rfc6902):

|Operation  | Notes |
|-----------|--------------------------------|-------|
| `add` (`path` points to array element)         | Add an element to the array. |
| `add` (`path` points to property)              | Set the property value. |
| `add` (`path` points to nonexistent property)  | Add the property to the object. |
| `remove`  | Remove the property or array element.   |
| `replace` | Same as `remove` followed by `add` at same location. |
| `move`    | Same as `remove` from source followed by `add` to destination using value from source. |
| `copy`    | Same as `add` to destination using value from source. |
| `test`    | Return success status code if value at `path` = `value`.|

## JsonPatch in ASP.NET Core

The ASP.NET Core implementation of JSON Patch in provided in the [Microsoft.AspNetCore.JsonPatch](https://www.nuget.org/packages/microsoft.aspnetcore.jsonpatch/) NuGet package and is included in the [Microsoft.AspnetCore.App](../fundamentals/metapackage-app.md) metapackage.

Static vs. dynamic objects

When you use JSON Patch with dynamic objects, properties can be removed or created at runtime and JSON Patch can work according to the specification. But it's relatively rare to use dynamic objects in C# apps, and some operations have to be handled differently by ASP.NET Core JSON Patch when it woks with static objects. The following sections explain the ASP.NET Core JSON Patch operations that are supported.

## Action method syntax

In the API controller, the action method for JSON Patch:

* Is annotated with the HttpPatch attribute.
* Accepts a `JsonPatchDocument<T>`, typically with [FromBody].
* Calls `ApplyTo` on the patch document to apply the changes. Can pass in ModelState to have patch errors entered into model state.

<!-- todo code snippet static -->

<!-- todo code snippet dynamic-->

dynamic object example
[HttpPatch("dynamic")]
public IActionResult Patch([FromBody]JsonPatchDocument patch)
{
    dynamic obj = new ExpandoObject();
    patch.ApplyTo(obj);



## Add a property

On a dynamic object, add a property.
On a static object, set a property to a value.

## Add an array element

Inserts an array element.

## Remove an array element

Removes an array element

## Remove a property value

On a dynamic object, removes the property.
On a static object, sets it to null if it's nullable, or `default<T>` if it isn't nullable.

## Replace

Replaces an array element or the value of a property.

## Move an array element

If `path` is an array element: copies value of `from` property to `path` property, then calls `remove` on `from` property.

## Move a property value

If `path` is a property: copies value of `from` property to `path` property, then calls `remove` on `from` property.

## Copy an array element

If `path` is an array element: copies value of `from` property to `path` property.

## Copy a property value

If `path` is a property: copies value of `from` property to `path` property.

## Check for concurrency conflicts

For example, array element location changes before you send the patch.  Send a Test, and if it fails, the whole patch document is not applied.

## Create JSON Patch documents

## Sample app

To try out the sample app, run the project and send HTTP requests with the following settings:

* URL: `http://localhost:53594/jsonpatch/jsonpatchwithmodelstate`
* HTTP method: `PATCH`
* `Content-Type` header: `application/json-patch+json`
* Body: Find sample JSON Patch documents in the *JSON* project folder.


## Get the code

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/web-api/jsonpatch/samples/2.2). ([how to download](xref:index#how-to-download-a-sample)).

## Additional resources

* [IETF RFC 5789 PATCH method specification](https://tools.ietf.org/html/rfc5789)
* [IETF RFC 6902 JSON Patch specification](https://tools.ietf.org/html/rfc6902)
* [IETF RFC 6901 JSON Patch path format spec](http://tools.ietf.org/html/rfc6901)
* [JSON Patch documentation](http://jsonpatch.com/), including resources for creating JSON Patch documents.
* [ASP.NET Core JSON Patch source code](https://github.com/aspnet/AspNetCore/tree/master/src/Features/JsonPatch/src)
