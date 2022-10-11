---
title: Creating responses with minimal APIs
author: brunolins16
description: Learn how to use XXXX of minimal APIs in ASP.NET Core.
ms.author: brolivei
monikerRange: '>= aspnetcore-7.0'
ms.date: 10/11/2022
uid: fundamentals/minimal-apis/responses
---

# Creating responses with minimal APIs

<!-- TODO: Rewrite since this is the current content from the cheat sheet -->

Route handlers support the following types of return values:

1. `IResult` based - This includes `Task<IResult>` and `ValueTask<IResult>`
1. `string` - This includes `Task<string>` and `ValueTask<string>`
1. `T` (Any other type) - This includes `Task<T>` and `ValueTask<T>`

|Return value|Behavior|Content-Type|
|--|--|--|
|`IResult` | The framework calls [IResult.ExecuteAsync](xref:Microsoft.AspNetCore.Http.IResult.ExecuteAsync%2A)| Decided by the `IResult` implementation
|`string` | The framework writes the string directly to the response | `text/plain`
| `T` (Any other type) | The framework will JSON serialize the response| `application/json`

### Example return values

#### string return values

```csharp
app.MapGet("/hello", () => "Hello World");
```

#### JSON return values

```csharp
app.MapGet("/hello", () => new { Message = "Hello World" });
```

#### IResult return values

```csharp
app.MapGet("/hello", () => Results.Ok(new { Message = "Hello World" }));
```

The following example uses the built-in result types to customize the response:

[!code-csharp[](minimal-apis/7.0-samples/todo/Program.cs?name=snippet_getCustom)]

### JSON

```csharp
app.MapGet("/hello", () => Results.Json(new { Message = "Hello World" }));
```

### Custom Status Code

```csharp
app.MapGet("/405", () => Results.StatusCode(405));
```

### Text

```csharp
app.MapGet("/text", () => Results.Text("This is some text"));
```

<a name="stream7"></a>

### Stream

[!code-csharp[](minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_stream)]

[`Results.Stream`](/dotnet/api/microsoft.aspnetcore.http.results.stream?view=aspnetcore-7.0&preserve-view=true) overloads allow access to the underlying HTTP response stream without buffering. The following example uses [ImageSharp](https://sixlabors.com/products/imagesharp) to return a reduced size of the specified image:

[!code-csharp[](~/fundamentals/minimal-apis/resultsStream/7.0-samples/ResultsStreamSample/Program.cs?name=snippet)]

The following example streams an image from [Azure Blob storage](/azure/storage/blobs/storage-blobs-introduction):

[!code-csharp[](~/fundamentals/minimal-apis/resultsStream/7.0-samples/ResultsStreamSample/Program.cs?name=snippet_abs)]

The following example streams a video from an Azure Blob:

[!code-csharp[](~/fundamentals/minimal-apis/resultsStream/7.0-samples/ResultsStreamSample/Program.cs?name=snippet_video)]

### Redirect

```csharp
app.MapGet("/old-path", () => Results.Redirect("/new-path"));
```

### File

```csharp
app.MapGet("/download", () => Results.File("myfile.text"));
```

<a name="binr7"></a>

### Built-in results

Common result helpers exist in the `Microsoft.AspNetCore.Http.Results` static class.

|Description|Response type|Status Code|API|
|--|--|--|--|
Write a JSON response with advanced options |application/json |200|[Results.Json](xref:Microsoft.AspNetCore.Http.Results.Json%2A)|
|Write a JSON response |application/json |200|[Results.Ok](xref:Microsoft.AspNetCore.Http.Results.Ok%2A)|
|Write a text response |text/plain (default), configurable |200|[Results.Text](xref:Microsoft.AspNetCore.Http.Results.Text%2A)|
|Write the response as bytes |application/octet-stream (default), configurable |200|[Results.Bytes](xref:Microsoft.AspNetCore.Http.Results.Bytes%2A)|
|Write a stream of bytes to the response |application/octet-stream (default), configurable |200|[Results.Stream](xref:Microsoft.AspNetCore.Http.Results.Stream%2A)|
|Stream a file to the response for download with the content-disposition header |application/octet-stream (default), configurable |200|[Results.File](xref:Microsoft.AspNetCore.Http.Results.File%2A)|
|Set the status code to 404, with an optional JSON response | N/A |404|[Results.NotFound](xref:Microsoft.AspNetCore.Http.Results.NotFound%2A)|
|Set the status code to 204 | N/A |204|[Results.NoContent](xref:Microsoft.AspNetCore.Http.Results.NoContent%2A)|
|Set the status code to 422, with an optional JSON response | N/A |422|[Results.UnprocessableEntity](xref:Microsoft.AspNetCore.Http.Results.UnprocessableEntity%2A)|
|Set the status code to 400, with an optional JSON response | N/A |400|[Results.BadRequest](xref:Microsoft.AspNetCore.Http.Results.BadRequest%2A)|
|Set the status code to 409, with an optional JSON response | N/A |409|[Results.Conflict](xref:Microsoft.AspNetCore.Http.Results.Conflict%2A)|
|Write a problem details JSON object to the response | N/A |500 (default), configurable|[Results.Problem](xref:Microsoft.AspNetCore.Http.Results.Problem%2A)|
|Write a problem details JSON object to the response with validation errors | N/A | N/A, configurable|[Results.ValidationProblem](xref:Microsoft.AspNetCore.Http.Results.ValidationProblem%2A)|

### Customizing results

Applications can control responses by implementing a custom <xref:Microsoft.AspNetCore.Http.IResult> type. The following code is an example of an HTML result type:

[!code-csharp[](minimal-apis/7.0-samples/WebMinAPIs/ResultsExtensions.cs)]

We recommend adding an extension method to <xref:Microsoft.AspNetCore.Http.IResultExtensions?displayProperty=fullName> to make these custom results more discoverable.

[!code-csharp[](minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_xtn)]