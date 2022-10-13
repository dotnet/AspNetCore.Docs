---
title: Create responses in Minimal API apps
author: brunolins16
description: Learn how to create responses for minimal APIs in ASP.NET Core.
ms.author: brolivei
monikerRange: '>= aspnetcore-7.0'
ms.date: 10/11/2022
uid: fundamentals/minimal-apis/responses
---

# How to create responses in Minimal API apps

Minimal endpoints support the following types of return values:

1. `string` - This includes `Task<string>` and `ValueTask<string>`.
1. `T` (Any other type) - This includes `Task<T>` and `ValueTask<T>`.
1. `IResult` based - This includes `Task<IResult>` and `ValueTask<IResult>`.

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
| The framework will JSON serialize the response.| `application/json`

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
| The framework calls [IResult.ExecuteAsync](xref:Microsoft.AspNetCore.Http.IResult.ExecuteAsync%2A).| Decided by the `IResult` implementation.

The `IResult` interface defines a contract that represents the result of an HTTP endpoint. The static [Results](<xref:Microsoft.AspNetCore.Http.Results>) class and the static [TypedResults](<xref:Microsoft.AspNetCore.Http.TypedResults>) are used to create various `IResult` objects that represent different types of responses.

### TypedResults vs Results

The `Results` and `TypedResults` static classes provide similar sets of results helpers. However, the `Results` helpers' return type is `IResult`, while each `TypedResults` helper's return type is one of the `IResult` implementation types. The difference means that for `Results` helpers a conversion is needed when the concrete type is needed, for example, for unit testing. The implementation types are defined in the <xref:Microsoft.AspNetCore.Http.HttpResults> namespace.

An advantage of using `TypedResults` is that the implementation type automatically includes the response type metadata for the endpoint.

Consider the follow endpoint, for which a `200 OK` status code with the expected JSON response is produced.

```csharp
app.MapGet("/hello", () => Results.Ok(new Message() {  Text = "Hello World!" }))
    .Produces<Message>();
```

In order to document this endpoint correctly the extensions method `Produces` is called. However, it's not necessary to call `Produces` if `TypedResults` is used instead of `Results`, as shown in the following code. `TypedResults` automatically includes the metadata for the endpoint.

```csharp
app.MapGet("/hello", () => TypedResults.Ok(new Message() {  Text = "Hello World!" }));
```

For more information about describing a response type, see [OpenAPI support in minimal APIs](/aspnet/core/fundamentals/minimal-apis/openapi#describe-response-types-1))

### Results<TResult1, TResultN>

When the static `TypedResult` class is used to create the `IResult` objects, and multiple `IResult` implementation types are returned from an endpoint handler, use [`Results<TResult1, TResultN>`](/dotnet/api/microsoft.aspnetcore.http.httpresults.results-2) as the endpoint handler return type. This alternative is better than returning `IResult` because the generic union types automatically retain the endpoint metadata. And since the `Results<TResult1, TResultN>` union types implement implicit cast operators, the compiler can automatically convert the types specified in the generic arguments to an instance of the union type. 

This has the added benefit of providing compile-time checking that a route handler actually only returns the results that it declares it does. Attempting to return a type that isn’t declared as one of the generic arguments to `Results<>` results in a compilation error.

Consider the following endpoint, for which a `400 BadRequest` status code is returned when the `orderId` is greater than `999`. Otherwise, it produces a `200 OK` with the expected content.

```csharp
app.MapGet("/orders/{orderId}", IResult (int orderId)
    => orderId > 999 ? TypedResults.BadRequest() : TypedResults.Ok(new Order(orderId)))
    .Produces(400)
    .Produces<Order>();
```

In order to document this endpoint correctly the extension method `Produces` is called. However, since the `TypedResults` helper automatically includes the metadata for the endpoint, you return the `Results<T1, Tn>` union type instead, as shown in the following code.

```csharp
app.MapGet("/orders/{orderId}", Results<BadRequest, Ok<Order>> (int orderId) 
    => orderId > 999 ? TypedResults.BadRequest() : TypedResults.Ok(new Order(orderId)));
```

<a name="binr7"></a>

### Built-in results

[!INCLUDE [results-helpers](includes/results-helpers.md)]

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

Also, a custom `IResult` type can describe its own annotation by implementing the <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointMetadataProvider> interface. For example, the following code adds an annotation, to the previous `HtmlResult` type, that describe the response produced by the endpoint.

[!code-csharp[](7.0-samples/WebMinAPIs/Snippets/ResultsExtensions.cs?name=snippet_IEndpointMetadataProvider&highlight=1,14-18)]

The `ProducesHtmlMetadata` is an implementation of <xref:Microsoft.AspNetCore.Http.Metadata.IProducesResponseTypeMetadata> that define the produced response content type `text/html` and the status code `200 OK`.

[!code-csharp[](7.0-samples/WebMinAPIs/Snippets/ResultsExtensions.cs?name=snippet_ProducesHtmlMetadata)]

An alternative approach is using the <xref:Microsoft.AspNetCore.Mvc.ProducesAttribute?displayProperty=fullName> to describe the produced response. The follow code change the `PopulateMetadata` method to use `ProducesAttribute`.

```csharp
public static void PopulateMetadata(MethodInfo method, EndpointBuilder builder)
{
    builder.Metadata.Add(new ProducesAttribute(MediaTypeNames.Text.Html));
}
```


