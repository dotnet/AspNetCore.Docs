---
title: JsonPatch in ASP.NET Core web API
author: rick-anderson
description: Learn how to handle JSON Patch requests in an ASP.NET Core web API.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 03/09/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: web-api/jsonpatch
---
# JsonPatch in ASP.NET Core web API

:::moniker range=">= aspnetcore-6.0"

This article explains how to handle JSON Patch requests in an ASP.NET Core web API.

## Package installation

JSON Patch support in ASP.NET Core web API is based on `Newtonsoft.Json` and requires the [`Microsoft.AspNetCore.Mvc.NewtonsoftJson`](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson/) NuGet package. To enable JSON Patch support:

* Install the [`Microsoft.AspNetCore.Mvc.NewtonsoftJson`](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson/) NuGet package.
* Call <xref:Microsoft.Extensions.DependencyInjection.NewtonsoftJsonMvcBuilderExtensions.AddNewtonsoftJson%2A>. For example:

  :::code language="csharp" source="jsonpatch/samples/6.x/api/Program.cs" id="snippet1" highlight="4":::

`AddNewtonsoftJson` replaces the default `System.Text.Json`-based input and output formatters used for formatting ***all*** JSON content. This extension method is compatible with the following MVC service registration methods:

* <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddRazorPages%2A>
* <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllersWithViews%2A>
* <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllers%2A>

## Add support for JSON Patch when using System.Text.Json

The `System.Text.Json`-based input formatter doesn't support JSON Patch. To add support for JSON Patch using `Newtonsoft.Json`, while leaving the other input and output formatters unchanged:

* Install the [`Microsoft.AspNetCore.Mvc.NewtonsoftJson`](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson/) NuGet package.
* Update `Program.cs`:

  :::code language="csharp" source="jsonpatch/samples/6.x/api/Program.cs" id="snippet_both" highlight="6-9":::
  :::code language="csharp" source="jsonpatch/samples/6.x/api/MyJPIF.cs":::

The preceding code creates an instance of <xref:Microsoft.AspNetCore.Mvc.Formatters.NewtonsoftJsonPatchInputFormatter> and inserts it as the first entry in the <xref:Microsoft.AspNetCore.Mvc.MvcOptions.InputFormatters%2A?displayProperty=nameWithType> collection. This order of registration ensures that:

* `NewtonsoftJsonPatchInputFormatter` processes JSON Patch requests.
* The existing `System.Text.Json`-based input and formatters process all other JSON requests and responses.

Use the `Newtonsoft.Json.JsonConvert.SerializeObject` method to serialize a <xref:Microsoft.AspNetCore.JsonPatch.JsonPatchDocument>.

## PATCH HTTP request method

The PUT and [PATCH](https://tools.ietf.org/html/rfc5789) methods are used to update an existing resource. The difference between them is that PUT replaces the entire resource, while PATCH specifies only the changes.

## JSON Patch

[JSON Patch](https://tools.ietf.org/html/rfc6902) is a format for specifying updates to be applied to a resource. A JSON Patch document has an array of *operations*. Each operation identifies a particular type of change. Examples of such changes include adding an array element or replacing a property value.

For example, the following JSON documents represent a resource, a JSON Patch document for the resource, and the result of applying the Patch operations.

### Resource example

:::code language="json" source="jsonpatch/snippets/customer.json":::

### JSON patch example

:::code language="json" source="jsonpatch/snippets/add.json":::

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

The changes made by applying a JSON Patch document to a resource are atomic. If any operation in the list fails, no operation in the list is applied.

## Path syntax

The [path](https://tools.ietf.org/html/rfc6901) property of an operation object has slashes between levels. For example, `"/address/zipCode"`.

Zero-based indexes are used to specify array elements. The first element of the `addresses` array would be at `/addresses/0`. To `add` to the end of an array, use a hyphen (`-`) rather than an index number: `/addresses/-`.

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

## JSON Patch in ASP.NET Core

The ASP.NET Core implementation of JSON Patch is provided in the [Microsoft.AspNetCore.JsonPatch](https://www.nuget.org/packages/microsoft.aspnetcore.jsonpatch/) NuGet package.

## Action method code

In an API controller, an action method for JSON Patch:

* Is annotated with the `HttpPatch` attribute.
* Accepts a <xref:Microsoft.AspNetCore.JsonPatch.JsonPatchDocument%601>, typically with [`[FromBody]`](xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute).
* Calls <xref:Microsoft.AspNetCore.JsonPatch.JsonPatchDocument.ApplyTo(System.Object)> on the patch document to apply the changes.

Here's an example:

:::code language="csharp" source="jsonpatch/samples/3.x/api/Controllers/HomeController.cs" id="snippet_PatchAction" highlight="1,3,9":::

This code from the sample app works with the following `Customer` model:

:::code language="csharp" source="jsonpatch/samples/6.x/api/Models/Customer.cs":::

:::code language="csharp" source="jsonpatch/samples/6.x/api/Models/Order.cs":::

The sample action method:

* Constructs a `Customer`.
* Applies the patch.
* Returns the result in the body of the response.

In a real app, the code would retrieve the data from a store such as a database and update the database after applying the patch.

### Model state

The preceding action method example calls an overload of `ApplyTo` that takes model state as one of its parameters. With this option, you can get error messages in responses. The following example shows the body of a 400 Bad Request response for a `test` operation:

```json
{
  "Customer": [
    "The current value 'John' at path 'customerName' != test value 'Nancy'."
  ]
}
```

### Dynamic objects

The following action method example shows how to apply a patch to a dynamic object:

:::code language="csharp" source="jsonpatch/samples/6.x/api/Controllers/HomeController.cs" id="snippet_Dynamic":::

## The add operation

* If `path` points to an array element: inserts new element before the one specified by `path`.
* If `path` points to a property: sets the property value.
* If `path` points to a nonexistent location:
  * If the resource to patch is a dynamic object: adds a property.
  * If the resource to patch is a static object: the request fails.

The following sample patch document sets the value of `CustomerName` and adds an `Order` object to the end of the `Orders` array.

:::code language="json" source="jsonpatch/snippets/add.json":::

## The remove operation

* If `path` points to an array element: removes the element.
* If `path` points to a property:
  * If resource to patch is a dynamic object: removes the property.
  * If resource to patch is a static object:
    * If the property is nullable: sets it to null.
    * If the property is non-nullable, sets it to `default<T>`.

The following sample patch document sets `CustomerName` to null and deletes `Orders[0]`:

:::code language="json" source="jsonpatch/snippets/remove.json":::

## The replace operation

This operation is functionally the same as a `remove` followed by an `add`.

The following sample patch document sets the value of `CustomerName` and replaces `Orders[0]`with a new `Order` object:

:::code language="json" source="jsonpatch/snippets/replace.json":::

## The move operation

* If `path` points to an array element: copies `from` element to location of `path` element, then runs a `remove` operation on the `from` element.
* If `path` points to a property: copies value of `from` property to `path` property, then runs a `remove` operation on the `from` property.
* If `path` points to a nonexistent property:
  * If the resource to patch is a static object: the request fails.
  * If the resource to patch is a dynamic object: copies `from` property to location indicated by `path`, then runs a `remove` operation on the `from` property.

The following sample patch document:

* Copies the value of `Orders[0].OrderName` to `CustomerName`.
* Sets `Orders[0].OrderName` to null.
* Moves `Orders[1]` to before `Orders[0]`.

:::code language="json" source="jsonpatch/snippets/move.json":::

## The copy operation

This operation is functionally the same as a `move` operation without the final `remove` step.

The following sample patch document:

* Copies the value of `Orders[0].OrderName` to `CustomerName`.
* Inserts a copy of `Orders[1]` before `Orders[0]`.

:::code language="json" source="jsonpatch/snippets/copy.json":::

## The test operation

If the value at the location indicated by `path` is different from the value provided in `value`, the request fails. In that case, the whole PATCH request fails even if all other operations in the patch document would otherwise succeed.

The `test` operation is commonly used to prevent an update when there's a concurrency conflict.

The following sample patch document has no effect if the initial value of `CustomerName` is "John", because the test fails:

:::code language="json" source="jsonpatch/snippets/test-fail.json":::

## Get the code

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/web-api/jsonpatch/samples). ([How to download](xref:index#how-to-download-a-sample)).

To test the sample, run the app and send HTTP requests with the following settings:

* URL: `http://localhost:{port}/jsonpatch/jsonpatchwithmodelstate`
* HTTP method: `PATCH`
* Header: `Content-Type: application/json-patch+json`
* Body: Copy and paste one of the JSON patch document samples from the *JSON* project folder.

## Additional resources

* [IETF RFC 5789 PATCH method specification](https://tools.ietf.org/html/rfc5789)
* [IETF RFC 6902 JSON Patch specification](https://tools.ietf.org/html/rfc6902)
* [IETF RFC 6901 JSON Patch path format spec](https://tools.ietf.org/html/rfc6901)
* [JSON Patch documentation](https://jsonpatch.com/). Includes links to resources for creating JSON Patch documents.
* [ASP.NET Core JSON Patch source code](https://github.com/dotnet/AspNetCore/tree/main/src/Features/JsonPatch/src)

:::moniker-end

:::moniker range="< aspnetcore-6.0"

This article explains how to handle JSON Patch requests in an ASP.NET Core web API.

## Package installation

To enable JSON Patch support in your app, complete the following steps:

1. Install the [`Microsoft.AspNetCore.Mvc.NewtonsoftJson`](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson/) NuGet package.
1. Update the project's `Startup.ConfigureServices` method to call <xref:Microsoft.Extensions.DependencyInjection.NewtonsoftJsonMvcBuilderExtensions.AddNewtonsoftJson%2A>. For example:

    ```csharp
    services
        .AddControllersWithViews()
        .AddNewtonsoftJson();
    ```

`AddNewtonsoftJson` is compatible with the MVC service registration methods:

* <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddRazorPages%2A>
* <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllersWithViews%2A>
* <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllers%2A>

## JSON Patch, AddNewtonsoftJson, and System.Text.Json

`AddNewtonsoftJson` replaces the `System.Text.Json`-based input and output formatters used for formatting **all** JSON content. To add support for JSON Patch using `Newtonsoft.Json`, while leaving the other formatters unchanged, update the project's `Startup.ConfigureServices` method as follows:

:::code language="csharp" source="jsonpatch/samples/3.x/WebApp1/Startup.cs" id="snippet":::

The preceding code requires the `Microsoft.AspNetCore.Mvc.NewtonsoftJson` package and the following `using` statements:

:::code language="csharp" source="jsonpatch/samples/3.x/WebApp1/Startup.cs" id="snippet1":::

Use the `Newtonsoft.Json.JsonConvert.SerializeObject` method to serialize a JsonPatchDocument.

## PATCH HTTP request method

The PUT and [PATCH](https://tools.ietf.org/html/rfc5789) methods are used to update an existing resource. The difference between them is that PUT replaces the entire resource, while PATCH specifies only the changes.

## JSON Patch

[JSON Patch](https://tools.ietf.org/html/rfc6902) is a format for specifying updates to be applied to a resource. A JSON Patch document has an array of *operations*. Each operation identifies a particular type of change. Examples of such changes include adding an array element or replacing a property value.

For example, the following JSON documents represent a resource, a JSON Patch document for the resource, and the result of applying the Patch operations.

### Resource example

:::code language="json" source="jsonpatch/snippets/customer.json":::

### JSON patch example

:::code language="json" source="jsonpatch/snippets/add.json":::

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

The changes made by applying a JSON Patch document to a resource are atomic. If any operation in the list fails, no operation in the list is applied.

## Path syntax

The [path](https://tools.ietf.org/html/rfc6901) property of an operation object has slashes between levels. For example, `"/address/zipCode"`.

Zero-based indexes are used to specify array elements. The first element of the `addresses` array would be at `/addresses/0`. To `add` to the end of an array, use a hyphen (`-`) rather than an index number: `/addresses/-`.

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

## JSON Patch in ASP.NET Core

The ASP.NET Core implementation of JSON Patch is provided in the [Microsoft.AspNetCore.JsonPatch](https://www.nuget.org/packages/microsoft.aspnetcore.jsonpatch/) NuGet package.

## Action method code

In an API controller, an action method for JSON Patch:

* Is annotated with the `HttpPatch` attribute.
* Accepts a `JsonPatchDocument<T>`, typically with `[FromBody]`.
* Calls `ApplyTo` on the patch document to apply the changes.

Here's an example:

:::code language="csharp" source="jsonpatch/samples/3.x/api/Controllers/HomeController.cs" id="snippet_PatchAction" highlight="1,3,9":::

This code from the sample app works with the following `Customer` model:

:::code language="csharp" source="jsonpatch/samples/3.x/api/Models/Customer.cs":::

:::code language="csharp" source="jsonpatch/samples/3.x/api/Models/Order.cs":::

The sample action method:

* Constructs a `Customer`.
* Applies the patch.
* Returns the result in the body of the response.

In a real app, the code would retrieve the data from a store such as a database and update the database after applying the patch.

### Model state

The preceding action method example calls an overload of `ApplyTo` that takes model state as one of its parameters. With this option, you can get error messages in responses. The following example shows the body of a 400 Bad Request response for a `test` operation:

```json
{
    "Customer": [
        "The current value 'John' at path 'customerName' is not equal to the test value 'Nancy'."
    ]
}
```

### Dynamic objects

The following action method example shows how to apply a patch to a dynamic object:

:::code language="csharp" source="jsonpatch/samples/3.x/api/Controllers/HomeController.cs" id="snippet_Dynamic":::

## The add operation

* If `path` points to an array element: inserts new element before the one specified by `path`.
* If `path` points to a property: sets the property value.
* If `path` points to a nonexistent location:
  * If the resource to patch is a dynamic object: adds a property.
  * If the resource to patch is a static object: the request fails.

The following sample patch document sets the value of `CustomerName` and adds an `Order` object to the end of the `Orders` array.

:::code language="json" source="jsonpatch/snippets/add.json":::

## The remove operation

* If `path` points to an array element: removes the element.
* If `path` points to a property:
  * If resource to patch is a dynamic object: removes the property.
  * If resource to patch is a static object:
    * If the property is nullable: sets it to null.
    * If the property is non-nullable, sets it to `default<T>`.

The following sample patch document sets `CustomerName` to null and deletes `Orders[0]`:

:::code language="json" source="jsonpatch/snippets/remove.json":::

## The replace operation

This operation is functionally the same as a `remove` followed by an `add`.

The following sample patch document sets the value of `CustomerName` and replaces `Orders[0]`with a new `Order` object:

:::code language="json" source="jsonpatch/snippets/replace.json":::

## The move operation

* If `path` points to an array element: copies `from` element to location of `path` element, then runs a `remove` operation on the `from` element.
* If `path` points to a property: copies value of `from` property to `path` property, then runs a `remove` operation on the `from` property.
* If `path` points to a nonexistent property:
  * If the resource to patch is a static object: the request fails.
  * If the resource to patch is a dynamic object: copies `from` property to location indicated by `path`, then runs a `remove` operation on the `from` property.

The following sample patch document:

* Copies the value of `Orders[0].OrderName` to `CustomerName`.
* Sets `Orders[0].OrderName` to null.
* Moves `Orders[1]` to before `Orders[0]`.

:::code language="json" source="jsonpatch/snippets/move.json":::

## The copy operation

This operation is functionally the same as a `move` operation without the final `remove` step.

The following sample patch document:

* Copies the value of `Orders[0].OrderName` to `CustomerName`.
* Inserts a copy of `Orders[1]` before `Orders[0]`.

:::code language="json" source="jsonpatch/snippets/copy.json":::

## The test operation

If the value at the location indicated by `path` is different from the value provided in `value`, the request fails. In that case, the whole PATCH request fails even if all other operations in the patch document would otherwise succeed.

The `test` operation is commonly used to prevent an update when there's a concurrency conflict.

The following sample patch document has no effect if the initial value of `CustomerName` is "John", because the test fails:

:::code language="json" source="jsonpatch/snippets/test-fail.json":::

## Get the code

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/web-api/jsonpatch/samples). ([How to download](xref:index#how-to-download-a-sample)).

To test the sample, run the app and send HTTP requests with the following settings:

* URL: `http://localhost:{port}/jsonpatch/jsonpatchwithmodelstate`
* HTTP method: `PATCH`
* Header: `Content-Type: application/json-patch+json`
* Body: Copy and paste one of the JSON patch document samples from the *JSON* project folder.

## Additional resources

* [IETF RFC 5789 PATCH method specification](https://tools.ietf.org/html/rfc5789)
* [IETF RFC 6902 JSON Patch specification](https://tools.ietf.org/html/rfc6902)
* [IETF RFC 6901 JSON Patch path format spec](https://tools.ietf.org/html/rfc6901)
* [JSON Patch documentation](https://jsonpatch.com/). Includes links to resources for creating JSON Patch documents.
* [ASP.NET Core JSON Patch source code](https://github.com/dotnet/AspNetCore/tree/main/src/Features/JsonPatch/src)

:::moniker-end
