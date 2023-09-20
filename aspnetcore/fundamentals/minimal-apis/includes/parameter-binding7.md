:::moniker range="= aspnetcore-7.0"
Parameter binding is the process of converting request data into strongly typed parameters that are expressed by route handlers. A binding source determines where parameters are bound from. Binding sources can be explicit or inferred based on HTTP method and parameter type.

Supported binding sources:

* Route values
* Query string
* Header
* Body (as JSON)
* Services provided by dependency injection
* Custom

Binding from form values is ***not*** natively supported in .NET 6 and 7.

The following `GET` route handler uses some of these parameter binding sources:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_pbg&highlight=8-11)]

The following table shows the relationship between the parameters used in the preceding example and the associated binding sources.

| Parameter | Binding Source |
|--|--|
| `id` | route value |
| `page` | query string |
| `customHeader` | header |
| `service` | Provided by dependency injection |

The HTTP methods `GET`, `HEAD`, `OPTIONS`, and `DELETE` don't implicitly bind from body. To bind from body (as JSON) for these HTTP methods, [bind explicitly](#explicit-parameter-binding) with [`[FromBody]`](xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute) or read from the <xref:Microsoft.AspNetCore.Http.HttpRequest>.

The following example POST route handler uses a binding source of body (as JSON) for the `person` parameter:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_pbp&highlight=5)]

The parameters in the preceding examples are all bound from request data automatically. To demonstrate the convenience that parameter binding provides, the following route handlers show how to read request data directly from the request:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Snippets/Program.cs?name=snippet_ManualRequestBinding&highlight=3-5,12)]

### Explicit Parameter Binding

Attributes can be used to explicitly declare where parameters are bound from.

<!-- TODO - finish Service  -->
[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_epb)]

| Parameter | Binding Source |
| --------- | -------------- |
| `id`      | route value with the name `id` |
| `page`    | query string with the name `"p"`|
| `service`   | Provided by dependency injection |
| `contentType` | header with the name `"Content-Type"` |

> [!NOTE]
> Binding from form values is ***not*** natively supported in .NET 6 and 7.

### Parameter binding with dependency injection

Parameter binding for minimal APIs binds parameters through [dependency injection](xref:fundamentals/dependency-injection) when the type is configured as a service. It's not necessary to explicitly apply the [`[FromServices]`](xref:Microsoft.AspNetCore.Mvc.FromServicesAttribute) attribute to a parameter. In the following code, both actions return the time:

[!code-csharp[](~/release-notes/aspnetcore-7/samples/ApiController/Program.cs?name=snippet_min)]

### Optional parameters

Parameters declared in route handlers are treated as required:

* If a request matches the route, the route handler only runs if all required parameters are provided in the request.
* Failure to provide all required parameters results in an error.

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_op1)]

| URI | result |
| --------- | -------------- |
| `/products?pageNumber=3` | 3 returned |
| `/products` | `BadHttpRequestException`: Required parameter "int pageNumber" was not provided from query string. |
| `/products/1` | HTTP 404 error, no matching route |

To make `pageNumber` optional, define the type as optional or provide a default value:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_op2)]

| URI | result |
| --------- | -------------- |
| `/products?pageNumber=3` | 3 returned |
| `/products` | 1 returned |
| `/products2` | 1 returned |

The preceding nullable and default value applies to all sources:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_op3)]

The preceding code calls the method with a null product if no request body is sent.

**NOTE**: If invalid data is provided and the parameter is nullable, the route handler is ***not*** run.

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_op4)]

| URI | result |
| --------- | -------------- |
| `/products?pageNumber=3` | `3` returned |
| `/products` | `1` returned |
| `/products?pageNumber=two` | `BadHttpRequestException`: Failed to bind parameter `"Nullable<int> pageNumber"` from "two". |
| `/products/two` | HTTP 404 error, no matching route |

See the [Binding Failures](#bf) section for more information.

### Special types

The following types are bound without explicit attributes:

* <xref:Microsoft.AspNetCore.Http.HttpContext>: The context which holds all the information about the current HTTP request or response:

  ```csharp
  app.MapGet("/", (HttpContext context) => context.Response.WriteAsync("Hello World"));
  ```

* <xref:Microsoft.AspNetCore.Http.HttpRequest> and <xref:Microsoft.AspNetCore.Http.HttpResponse>: The HTTP request and HTTP response:

  ```csharp
  app.MapGet("/", (HttpRequest request, HttpResponse response) =>
      response.WriteAsync($"Hello World {request.Query["name"]}"));
  ```

* <xref:System.Threading.CancellationToken>: The cancellation token associated with the current HTTP request:

  ```csharp
  app.MapGet("/", async (CancellationToken cancellationToken) => 
      await MakeLongRunningRequestAsync(cancellationToken));
  ```

* <xref:System.Security.Claims.ClaimsPrincipal>: The user associated with the request, bound from <xref:Microsoft.AspNetCore.Http.HttpContext.User%2A?displayProperty=nameWithType>:

  ```csharp
  app.MapGet("/", (ClaimsPrincipal user) => user.Identity.Name);
  ```

<a name="rbs"></a>

#### Bind the request body as a `Stream` or `PipeReader`

The request body can bind as a [`Stream`](/dotnet/api/system.io.stream) or [`PipeReader`](/dotnet/api/system.io.pipelines.pipereader) to efficiently support scenarios where the user has to process data and:

* Store the data to blob storage or enqueue the data to a queue provider.
* Process the stored data with a worker process or cloud function.

For example, the data might be enqueued to [Azure Queue storage](/azure/storage/queues/storage-queues-introduction) or stored in [Azure Blob storage](/azure/storage/blobs/storage-blobs-introduction).

The following code implements a background queue:

[!code-csharp[](~/fundamentals/minimal-apis/bindStreamPipeReader/7.0-samples/PipeStreamToBackgroundQueue/BackgroundQueueService.cs)]

The following code binds the request body to a `Stream`:

[!code-csharp[](~/fundamentals/minimal-apis/bindStreamPipeReader/7.0-samples/PipeStreamToBackgroundQueue/Program.cs?name=snippet_1)]

The following code shows the complete `Program.cs` file:

[!code-csharp[](~/fundamentals/minimal-apis/bindStreamPipeReader/7.0-samples/PipeStreamToBackgroundQueue/Program.cs?name=snippet)]

* When reading data, the `Stream` is the same object as `HttpRequest.Body`.
* The request body isn't buffered by default. After the body is read, it's not rewindable. The stream can't be read multiple times.
* The `Stream` and `PipeReader` aren't usable outside of the minimal action handler as the underlying buffers will be disposed or reused.


#### File uploads using IFormFile and IFormFileCollection

The following code uses <xref:Microsoft.AspNetCore.Http.IFormFile> and <xref:Microsoft.AspNetCore.Http.IFormFileCollection> to upload file:

:::code language="csharp" source="~/fundamentals/minimal-apis/iformFile/7.0-samples/MinimalApi/Program.cs" :::

Authenticated file upload requests are supported using an [Authorization header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Authorization), a [client certificate](/aspnet/core/security/authentication/certauth), or a cookie header.

There is no built-in support for [antiforgery](/aspnet/core/security/anti-request-forgery?view=aspnetcore-7.0&preserve-view=true#anti7) in ASP.NET Core 7.0. [Antiforgery is available in ASP.NET Core 8.0](/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-8.0&preserve-view=true#bind8) and later. However, it can be implemented using the [`IAntiforgery` service](/aspnet/core/security/anti-request-forgery?view=aspnetcore-7.0&preserve-view=true#antimin7).

<a name="bindar"></a>

### Bind arrays and string values from headers and query strings

The following code demonstrates binding query strings to an array of primitive types, string arrays, and [StringValues](/dotnet/api/microsoft.extensions.primitives.stringvalues):

[!code-csharp[](~/fundamentals/minimal-apis/bindingArrays/7.0-samples/todo/Program.cs?name=snippet_bqs2pa)]

Binding query strings or header values to an array of complex types is supported when the type has `TryParse` implemented. The following code binds to a string array and returns all the items with the specified tags:

[!code-csharp[](~/fundamentals/minimal-apis/bindingArrays/7.0-samples/todo/Program.cs?name=snippet_bind_str_array)]

The following code shows the model and the required `TryParse` implementation:

[!code-csharp[](~/fundamentals/minimal-apis/bindingArrays/7.0-samples/todo/Program.cs?name=snippet_model)]

The following code binds to an `int` array:

[!code-csharp[](~/fundamentals/minimal-apis/bindingArrays/7.0-samples/todo/Program.cs?name=snippet_iaray)]

To test the preceding code, add the following endpoint to populate the database with `Todo` items:

[!code-csharp[](~/fundamentals/minimal-apis/bindingArrays/7.0-samples/todo/Program.cs?name=snippet_batch)]

Use a tool like Postman to pass the following data to the previous endpoint:

[!code-csharp[](~/fundamentals/minimal-apis/bindingArrays/7.0-samples/todo/Program.cs?name=batch_post_payload)]

The following code binds to the header key `X-Todo-Id` and returns the `Todo` items with matching `Id` values:

[!code-csharp[](~/fundamentals/minimal-apis/bindingArrays/7.0-samples/todo/Program.cs?name=snippet_getHeader)]

> [!NOTE]
> When binding a `string[]` from a query string, the absence of any matching query string value will result in an empty array instead of a null value.

<a name="asparam7"></a>

### Parameter binding for argument lists with [AsParameters]

<xref:Microsoft.AspNetCore.Http.AsParametersAttribute> enables simple parameter binding to types and not complex or recursive model binding.

Consider the following code:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/arg-lists/Program.cs" id="snippet_top":::

Consider the following `GET` endpoint:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/arg-lists/Program.cs" id="snippet_id" highlight="2":::

The following `struct` can be used to replace the preceding highlighted parameters:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/arg-lists/Models/TodoDb.cs" id="snippet" :::

The refactored `GET` endpoint uses the preceding `struct` with the [AsParameters](/dotnet/api/microsoft.aspnetcore.http.asparametersattribute?view=aspnetcore-7.0&preserve-view=true) attribute:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/arg-lists/Program.cs" id="snippet_ap_id" highlight="2":::

The following code shows additional endpoints in the app:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/arg-lists/Program.cs" id="snippet_post_put_delete" :::

The following classes are used to refactor the parameter lists:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/arg-lists/Models/TodoDb.cs" id="snippet_1" :::

The following code shows the refactored endpoints using `AsParameters` and the preceding `struct` and classes:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/arg-lists/Program.cs" id="snippet_ap_post_put_delete" :::

The following [`record`](/dotnet/csharp/language-reference/builtin-types/record) types can be used to replace the preceding parameters:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/arg-lists/Models/TodoRecord.cs" id="snippet_1" :::

Using a `struct` with `AsParameters` can be more performant than using a `record` type.

The [complete sample code](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/fundamentals/minimal-apis/samples/arg-lists) in the [AspNetCore.Docs.Samples](https://github.com/dotnet/AspNetCore.Docs.Samples) repository.

### Custom Binding

There are two ways to customize parameter binding:

1. For route, query, and header binding sources, bind custom types by adding a static `TryParse` method for the type.
1. Control the binding process by implementing a `BindAsync` method on a type.

#### TryParse

`TryParse` has two APIs:

```csharp
public static bool TryParse(string value, out T result);
public static bool TryParse(string value, IFormatProvider provider, out T result);
```

The following code displays `Point: 12.3, 10.1` with the URI `/map?Point=12.3,10.1`:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_cb)]

#### BindAsync

`BindAsync` has the following APIs:

```csharp
public static ValueTask<T?> BindAsync(HttpContext context, ParameterInfo parameter);
public static ValueTask<T?> BindAsync(HttpContext context);
```

The following code displays `SortBy:xyz, SortDirection:Desc, CurrentPage:99` with the URI `/products?SortBy=xyz&SortDir=Desc&Page=99`:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_ba)]

<a name="bf"></a>

### Binding failures

When binding fails, the framework logs a debug message and returns various status codes to the client depending on the failure mode.

|Failure mode|Nullable Parameter Type|Binding Source|Status code|
|--|--|--|--|
|`{ParameterType}.TryParse` returns `false` |yes|route/query/header|400|
|`{ParameterType}.BindAsync` returns `null` |yes|custom|400|
|`{ParameterType}.BindAsync` throws |does not matter|custom|500|
| Failure to deserialize JSON body |does not matter|body|400|
| Wrong content type (not `application/json`) |does not matter|body|415|

### Binding Precedence

The rules for determining a binding source from a parameter:

1. Explicit attribute defined on parameter (From* attributes) in the following order:
    1. Route values: [`[FromRoute]`](xref:Microsoft.AspNetCore.Mvc.FromRouteAttribute)
    1. Query string: [`[FromQuery]`](xref:Microsoft.AspNetCore.Mvc.FromQueryAttribute)
    1. Header: [`[FromHeader]`](xref:Microsoft.AspNetCore.Mvc.FromHeaderAttribute)
    1. Body: [`[FromBody]`](xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute)
    1. Service: [`[FromServices]`](xref:Microsoft.AspNetCore.Mvc.FromServicesAttribute)
    1. Parameter values: [`[AsParameters]`](xref:Microsoft.AspNetCore.Http.AsParametersAttribute)
1. Special types
    1. [`HttpContext`](xref:Microsoft.AspNetCore.Http.HttpContext)
    1. [`HttpRequest`](xref:Microsoft.AspNetCore.Http.HttpRequest) ([`HttpContext.Request`](xref:Microsoft.AspNetCore.Http.HttpContext.Request))
    1. [`HttpResponse`](xref:Microsoft.AspNetCore.Http.HttpResponse) ([`HttpContext.Response`](xref:Microsoft.AspNetCore.Http.HttpContext.Response))
    1. [`ClaimsPrincipal`](xref:System.Security.Claims.ClaimsPrincipal) ([`HttpContext.User`](xref:Microsoft.AspNetCore.Http.HttpContext.User))
    1. [`CancellationToken`](xref:System.Threading.CancellationToken) ([`HttpContext.RequestAborted`](xref:Microsoft.AspNetCore.Http.HttpContext.RequestAborted))
    1. [`IFormFileCollection`](xref:Microsoft.AspNetCore.Http.IFormFileCollection) ([`HttpContext.Request.Form.Files`](xref:Microsoft.AspNetCore.Http.IFormCollection.Files))
    1. [`IFormFile`](xref:Microsoft.AspNetCore.Http.IFormFile) ([`HttpContext.Request.Form.Files[paramName]`](xref:Microsoft.AspNetCore.Http.IFormFileCollection.Item(System.String)))
    1. [`Stream`](xref:System.IO.Stream) ([`HttpContext.Request.Body`](xref:Microsoft.AspNetCore.Http.HttpRequest.Body))
    1. [`PipeReader`](xref:System.IO.Pipelines.PipeReader) ([`HttpContext.Request.BodyReader`](xref:Microsoft.AspNetCore.Http.HttpRequest.BodyReader))
1. Parameter type has a valid static [`BindAsync`](xref:Microsoft.AspNetCore.Http.IBindableFromHttpContext%601.BindAsync%2A) method.
1. Parameter type is a string or has a valid static [`TryParse`](xref:System.IParsable%601.TryParse%2A) method.
   1. If the parameter name exists in the route template e.g. `app.Map("/todo/{id}", (int id) => {});`, then it's bound from the route.
   1. Bound from the query string.
1. If the parameter type is a service provided by dependency injection, it uses that service as the source.
1. The parameter is from the body.

### Configure JSON deserialization options for body binding

The body binding source uses <xref:System.Text.Json?displayProperty=fullName> for deserialization. It is ***not*** possible to change this default, but JSON serialization and deserialization options can be configured.

#### Configure JSON deserialization options globally

Options that apply globally for an app can be configured by invoking <xref:Microsoft.Extensions.DependencyInjection.HttpJsonServiceExtensions.ConfigureHttpJsonOptions%2A>. The following example includes public fields and formats JSON output.

:::code language="csharp" source="~/fundamentals/minimal-apis/7.0-samples/WebMinJson/Program.cs" id="snippet_confighttpjsonoptions" highlight="3-6":::

Since the sample code configures both serialization and deserialization, it can read `NameField` and include `NameField` in the output JSON.

#### Configure JSON deserialization options for an endpoint

<xref:Microsoft.AspNetCore.Http.HttpRequestJsonExtensions.ReadFromJsonAsync%2A> has overloads that accept a <xref:System.Text.Json.JsonSerializerOptions> object. The following example includes public fields and formats JSON output.

:::code language="csharp" source="~/fundamentals/minimal-apis/7.0-samples/WebMinJson/Program.cs" id="snippet_readfromjsonasyncwithoptions" highlight="5-8,12":::

Since the preceding code applies the customized options only to deserialization, the output JSON excludes `NameField`.

### Read the request body

Read the request body directly using a <xref:Microsoft.AspNetCore.Http.HttpContext> or <xref:Microsoft.AspNetCore.Http.HttpRequest> parameter:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_fileupload)]

The preceding code:

* Accesses the request body using <xref:Microsoft.AspNetCore.Http.HttpRequest.BodyReader?displayProperty=nameWithType>.
* Copies the request body to a local file.

:::moniker-end
