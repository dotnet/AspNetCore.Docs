---
title: JsonPatch in ASP.NET Core Web API
author: tdykstra
description: Learn how to handle PATCH requests using JSON documents in an ASP.NET Core Web API.
ms.author: tdykstra
ms.custom: mvc
ms.date: 03/24/2019
uid: web-api/jsonpatch
---

# JsonPatch in ASP.NET Core Web API

By [Tom Dykstra](https://github.com/tdykstra)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/web-api/jsonpatch/samples/2.2) ([how to download](xref:index#how-to-download-a-sample)).

This article explains how to handle PATCH requests using JSON documents in an ASP.NET Core Web API.

## PATCH HTTP request method

The PUT and PATCH methods are used to update an existing resource. The difference between them is that PUT provides the entire resource to replace the existing one, while PATCH specifies only the changes. Using the PATCH method can improve performance when resources to be updated are large and the changes are small.

## JSON Patch

JSON Patch is a specification for a JSON document that identifies changes to be made in a resource. A JSON Patch document has an array of one or more *operations*. Each operation identifies a particular type of change, such as add or remove an array element.

### Example

Suppose the resource is a customer object:

```json
{
     "firstName": "Nancy",
     "lastName": "Davolio",
}
```

In the following JSON PATCH document, the `op` property indicates the operation, such as `add`, `remove`, or `replace`. The `path` property indicates which element in the target object should be updated. The `value` property provides the new value. 

```json
[
    {
         "op": "replace",
         "path": "/lastName",
         "value": "Smith"
    },
    {
         "op": "add",
         "path": "/suffix",
         "value": "Ph.D."
    }
]
```

After applying the preceding JSON Patch document, the original document is changed to this:

```json
{
     "firstName": "Nancy",
     "lastName": "Smith",
     "suffix": "Ph.D."
}
```

### Operations and paths

The following table shows how JSON Patch operations work according to the specification.

|Operation  | Target of Path                 | Notes |
|-----------|--------------------------------|-------|
| `add`     | Array element                  | Add an element to the array. |
| `add`     | Nonexistent property           | Add the property to the object. |
| `add`     | Property                       | Set the property value. |
| `remove`  | Property or array element      | Remove the property or element. |
| `replace` | Property or array element      | Same as `remove` followed by `add`. |
| `move`    | Properties or array elements   | Move from `from` path to `path`. |
| `copy`    | Properties or array elements   | Copy from `from` path to `path`. |
| `test`    | Property or array element      | Return success status code if value at `path` = `value`.|

The `path` property of a patch document uses slashes between levels. For example, `"/address/zipCode"`. Use zero-based indexes in arrays: the first element of the addresses array would be at `"/addresses/0"`. To add to the end of an array, use a hyphen (-) rather than an index number: `"/addresses/-"`.

## JsonPatch in ASP.NET Core

The ASP.NET Core implementation of JSON Patch works with C# objects rather than JavaScript objects, which requires some changes in the way operations work.  Array elements can be added and removed, but properties can't. The following table lists the differences:

|Operation  | Target of Path                 | Notes |
|-----------|--------------------------------|-------|
| `add`     | Nonexistent property           | Request fails. |
| `add`     | Property                       | Set the property value. |
| `remove`  | Property                       | Set the property value to null or `default<T>`. |
| `move`    | Properties                     | Request fails. |
| `copy`    | Properties                     | Request fails. |
| `test`    | Property or array element      | Return success status code if value at `path` = `value`.|

## Use AspnetCore.JsonPatch in an app

### Package

Install-Package Microsoft.AspNetCore.JsonPatch

### Controller

The main point to note is that the HTTP Verb we use is “Patch”, we accept a type of “JsonPatchDocument<T>” and that to “apply” the changes we simply call “ApplyTo” on the patch and pass in the object we want to update.
[FromBody]}

## Set a property value

replace

## Set a property to null or default

remove

## Add an array element

add

## Copy a property or array element

copy (=add on copy to)

## Move a property or array element

move (=remove + add)

## Check for concurrency errors

test

test & replace example



## Get the code


## Additional resources

* [IETF RFC 5789 PATCH method specification](https://tools.ietf.org/html/rfc5789)
* [IETF RFC 6902 JSON PATCH specification](https://tools.ietf.org/html/rfc6902)
* [IETF RFC 6901 JSON Patch path format spec](http://tools.ietf.org/html/rfc6901)
* [Official documentation for JSON Patch](http://jsonpatch.com/)
