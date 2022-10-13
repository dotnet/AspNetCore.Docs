---
title: Creating responses in Minimal API apps
author: brunolins16
description: Learn how to use XXXX of minimal APIs in ASP.NET Core.
ms.author: brolivei
monikerRange: '>= aspnetcore-7.0'
ms.date: 10/11/2022
uid: fundamentals/minimal-apis/responses
---

# Creating responses in Minimal API apps

Minimal endpoints support the following types of return values:

1. `IResult` based - This includes `Task<IResult>` and `ValueTask<IResult>`
1. `string` - This includes `Task<string>` and `ValueTask<string>`
1. `T` (Any other type) - This includes `Task<T>` and `ValueTask<T>`

## `string` return values

|Behavior|Content-Type|
|--|--|
| The framework writes the string directly to the response. | `text/plain`

Consider the following route handler, which returns a `Hello world` text. 

```csharp
app.MapGet("/hello", () => "Hello World");
```

The `200` status code is returned with `text/plain` Content-Type header and the following content.

```text
Hello World
```

## `T` (Any other type) return values

|Behavior|Content-Type|
|--|--|
| The framework will JSON serialize the response| `application/json`

Consider the following route handler, which returns an anonymous type containing a `Message` string property.

```csharp
app.MapGet("/hello", () => new { Message = "Hello World" });
```

The `200` status code is returned with `application/json` Content-Type header and the following content.

```json
{"message":"Hello World"}
```

## `IResult` return values

|Behavior|Content-Type|
|--|--|
| The framework calls [IResult.ExecuteAsync](xref:Microsoft.AspNetCore.Http.IResult.ExecuteAsync%2A)| Decided by the `IResult` implementation

The `IResult` interface defines a contract that represents the result of an HTTP endpoint. The static [Results](<xref:Microsoft.AspNetCore.Http.Results>) class and the static [TypedResults](<xref:Microsoft.AspNetCore.Http.TypedResults>) are used to create varying `IResult` objects that represent different types of responses.

The following example uses the built-in result types to customize the response:

[!code-csharp[](7.0-samples/todo/Program.cs?name=snippet_getCustom)]

### TypedResults x Results

The `Results` and `TypedResults` static classes provide a similar set of results helpers, however, the `Results` static class helpers return type is `IResult`, that means that a conversion is needed when the concrete type is needed, eg.: unit testing, while `TypedResults` return type is one of the `IResult` implementation types (<xref:Microsoft.AspNetCore.Http.HttpResults> namespace).

An advantage of using `TypedResults` is that the implementation type automatically includes the response type metadata for the endpoint.

Consider the follow endpoint, which a `200 OK` status code with the expected JSON response is produced.

```csharp
app.MapGet("/hello", () => Results.Ok(new Message() {  Text = "Hello World!" }))
    .Produces<Message>();
```

In order to document this endpoint correctly the extensions method `Produces` was called. However, using `TypedResults` automatically includes the metadata for the endpoint as shown in the following code.

```csharp
app.MapGet("/hello", () => TypedResults.Ok(new Message() {  Text = "Hello World!" }));
```

More information about describing a response type can be found in [OpenAPI support in minimal APIs](/aspnet/core/fundamentals/minimal-apis/openapi#describe-response-types-1))

### Results<TResult1, TResultN>

When using the static `TypedResult` class to create the `IResult` objects and multiple `IResult` return types are needed, returning [`Result<TResult1, TResultN>`](/dotnet/api/microsoft.aspnetcore.http.httpresults.results-2) union type from a Minimal endpoint handler is an alternative over returning `IResult` because the generic union types automatically retain the endpoint metadata and, since the `Results<TResult1, TResultN>` union types implement implicit cast operators, the compiler can automatically convert the types specified in the generic arguments to an instance of the union type. 

This has the added benefit of providing compile-time checking that a route handler actually only returns the results that it declares it does. Attempting to return a type that isn’t declared as one of the generic arguments to `Results<>` results in a compilation error.

Consider the follow endpoint, which a `400 BadRequest` status code is returned when the `orderId` it greater than `999` otherwise will produce a `200 OK` with the expected content.

```csharp
app.MapGet("/orders/{orderId}", IResult (int orderId)
    => orderId > 999 ? TypedResults.BadRequest() : TypedResults.Ok(new Order(orderId)))
    .Produces(400)
    .Produces<Order>();
```

In order to document this endpoint correctly the extensions method `Produces` was called. However, since the `TypedResults` automatically includes the metadata for the endpoint you can change to return the `Result<T1,TN>` union type as shown in the following code.

```csharp
app.MapGet("/orders/{orderId}", Results<BadRequest, Ok<Order>> (int orderId) 
    => orderId > 999 ? TypedResults.BadRequest() : TypedResults.Ok(new Order(orderId)));
```

<a name="binr7"></a>

### Built-in results

* [!INCLUDE [results-helpers](includes/results-helpers.md)]

The following code demonstrate the usage of the common result helpers.

#### JSON

```csharp
app.MapGet("/hello", () => Results.Json(new { Message = "Hello World" }));
```

#### Custom Status Code

```csharp
app.MapGet("/405", () => Results.StatusCode(405));
```

#### Text

```csharp
app.MapGet("/text", () => Results.Text("This is some text"));
```

<a name="stream7"></a>

#### Stream

[!code-csharp[](7.0-samples/WebMinAPIs/Program.cs?name=snippet_stream)]

[`Results.Stream`](/dotnet/api/microsoft.aspnetcore.http.results.stream?view=aspnetcore-7.0&preserve-view=true) overloads allow access to the underlying HTTP response stream without buffering. The following example uses [ImageSharp](https://sixlabors.com/products/imagesharp) to return a reduced size of the specified image:

[!code-csharp[](resultsStream/7.0-samples/ResultsStreamSample/Program.cs?name=snippet)]

The following example streams an image from [Azure Blob storage](/azure/storage/blobs/storage-blobs-introduction):

[!code-csharp[](resultsStream/7.0-samples/ResultsStreamSample/Program.cs?name=snippet_abs)]

The following example streams a video from an Azure Blob:

[!code-csharp[](resultsStream/7.0-samples/ResultsStreamSample/Program.cs?name=snippet_video)]

#### Redirect

```csharp
app.MapGet("/old-path", () => Results.Redirect("/new-path"));
```

#### File

```csharp
app.MapGet("/download", () => Results.File("myfile.text"));
```

### Customizing results

Applications can control responses by implementing a custom <xref:Microsoft.AspNetCore.Http.IResult> type. The following code is an example of an HTML result type:

[!code-csharp[](7.0-samples/WebMinAPIs/ResultsExtensions.cs)]

We recommend adding an extension method to <xref:Microsoft.AspNetCore.Http.IResultExtensions?displayProperty=fullName> to make these custom results more discoverable.

[!code-csharp[](7.0-samples/WebMinAPIs/Program.cs?name=snippet_xtn)]