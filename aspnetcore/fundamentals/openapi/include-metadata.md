---
title: Include OpenAPI metadata in an ASP.NET Core app
author: captainsafia
description: Learn how to add OpenAPI metadata in an ASP.NET Core app
ms.author: safia
monikerRange: '>= aspnetcore-9.0'
ms.custom: mvc
ms.date: 10/26/2024
uid: fundamentals/openapi/include-metadata
---
# Include OpenAPI metadata in an ASP.NET Core app

## Include OpenAPI metadata for endpoints

ASP.NET collects metadata from the web app's endpoints and uses it to generate an OpenAPI document.
In controller-based apps, metadata is collected from attributes like [`[EndpointDescription]`](xref:Microsoft.AspNetCore.Http.EndpointDescriptionAttribute), [`[HttpPost]`](xref:Microsoft.AspNetCore.Mvc.HttpPostAttribute),
and [`[Produces]`](xref:Microsoft.AspNetCore.Mvc.ProducesAttribute).
In minimal APIs, metadata can be collected from attributes, but may also be set by using extension methods
and other strategies, such as returning <xref:Microsoft.AspNetCore.Http.TypedResults> from route handlers.
The following table provides an overview of the metadata collected and the strategies for setting it.

| Metadata | Attribute | Extension method | Other strategies |
| --- | --- | --- |
| summary | [`[EndpointSummary]`](xref:Microsoft.AspNetCore.Http.EndpointSummaryAttribute) | <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.WithSummary%2A> | |
| description | [`[EndpointDescription]`](xref:Microsoft.AspNetCore.Http.EndpointDescriptionAttribute) | <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.WithDescription%2A> | |
| tags | [`[Tags]`](xref:Microsoft.AspNetCore.Http.TagsAttribute) | <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.WithTags%2A> | |
| operationId | [`[EndpointName]`](xref:Microsoft.AspNetCore.Routing.EndpointNameAttribute) | <xref:Microsoft.AspNetCore.Builder.RoutingEndpointConventionBuilderExtensions.WithName%2A> | |
| parameters | [`[FromQuery]`](xref:Microsoft.AspNetCore.Mvc.FromQueryAttribute), [`[FromRoute]`](xref:Microsoft.AspNetCore.Mvc.FromRouteAttribute), [`[FromHeader]`](xref:Microsoft.AspNetCore.Mvc.FromHeaderAttribute), [`[FromForm]`](xref:Microsoft.AspNetCore.Mvc.FromFormAttribute) | |
| parameter description | [`[EndpointDescription]`](xref:Microsoft.AspNetCore.Http.EndpointDescriptionAttribute) | | |
| requestBody | [`[FromBody]`](xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute) | <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Accepts%2A> | |
| responses | [`[Produces]`](xref:Microsoft.AspNetCore.Mvc.ProducesAttribute) | <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Produces%2A>, <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.ProducesProblem%2A> | <xref:Microsoft.AspNetCore.Http.TypedResults> |
| Excluding endpoints | [`[ExcludeFromDescription]`](xref:Microsoft.AspNetCore.Routing.ExcludeFromDescriptionAttribute), [`[ApiExplorerSettings]`](xref:Microsoft.AspNetCore.Mvc.ApiExplorerSettingsAttribute) | <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.ExcludeFromDescription%2A> | |

ASP.NET Core does not collect metadata from XML doc comments.

The following sections demonstrate how to include metadata in an app to customize the generated OpenAPI document.

### Summary and description

The endpoint summary and description can be set using the [`[EndpointSummary]`](xref:Microsoft.AspNetCore.Http.EndpointSummaryAttribute) and [`[EndpointDescription]`](xref:Microsoft.AspNetCore.Http.EndpointDescriptionAttribute) attributes,
or in minimal APIs, using the <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.WithSummary%2A> and <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.WithDescription%2A> extension methods.

#### [Minimal APIs](#tab/minimal-apis)

The following sample demonstrates the different strategies for setting summaries and descriptions.

Note that the attributes are placed on the delegate method and not on the app.MapGet method.

```csharp
app.MapGet("/extension-methods", () => "Hello world!")
  .WithSummary("This is a summary.")
  .WithDescription("This is a description.");

app.MapGet("/attributes",
  [EndpointSummary("This is a summary.")]
  [EndpointDescription("This is a description.")]
  () => "Hello world!");
```

#### [Controllers](#tab/controllers)

The following sample demonstrates how to set summaries and descriptions.

```csharp
  [EndpointSummary("This is a summary.")]
  [EndpointDescription("This is a description.")]
  [HttpGet("attributes")]
  public IResult Attributes()
  {
      return Results.Ok("Hello world!");
  }
```
---

### tags

OpenAPI supports specifying tags on each endpoint as a form of categorization.

#### [Minimal APIs](#tab/minimal-apis)

In minimal APIs, tags can be set using either the [`[Tags]`](xref:Microsoft.AspNetCore.Http.TagsAttribute) attribute or the <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.WithTags%2A> extension method.

The following sample demonstrates the different strategies for setting tags.

```csharp
app.MapGet("/extension-methods", () => "Hello world!")
  .WithTags("todos", "projects");

app.MapGet("/attributes",
  [Tags("todos", "projects")]
  () => "Hello world!");
```

#### [Controllers](#tab/controllers)

In controller-based apps, the controller name is automatically added as a tag on each of its endpoints, but this can be overridden using the [`[Tags]`](xref:Microsoft.AspNetCore.Http.TagsAttribute) attribute.

The following sample demonstrates how to set tags.

```csharp
  [Tags(["todos", "projects"])]
  [HttpGet("attributes")]
  public IResult Attributes()
  {
      return Results.Ok("Hello world!");
  }
```
---

### operationId

OpenAPI supports an operationId on each endpoint as a unique identifier or name for the operation. 

#### [Minimal APIs](#tab/minimal-apis)

In minimal APIs, the operationId can be set using either the [`[EndpointName]`](xref:Microsoft.AspNetCore.Routing.EndpointNameAttribute) attribute or the <xref:Microsoft.AspNetCore.Builder.RoutingEndpointConventionBuilderExtensions.WithName%2A> extension method.

The following sample demonstrates the different strategies for setting the operationId.

```csharp
app.MapGet("/extension-methods", () => "Hello world!")
  .WithName("FromExtensionMethods");

app.MapGet("/attributes",
  [EndpointName("FromAttributes")]
  () => "Hello world!");
```

#### [Controllers](#tab/controllers)

In controller-based apps, the operationId can be set using the [`[EndpointName]`](xref:Microsoft.AspNetCore.Routing.EndpointNameAttribute) attribute.

The following sample demonstrates how to set the operationId.

```csharp
  [EndpointName("FromAttributes")]
  [HttpGet("attributes")]
  public IResult Attributes()
  {
      return Results.Ok("Hello world!");
  }
```
---

### parameters

OpenAPI supports annotating path, query string, header, and cookie parameters that are consumed by an API.

The framework infers the types for request parameters automatically based on the signature of the route handler.

The [`[EndpointDescription]`](xref:Microsoft.AspNetCore.Http.EndpointDescriptionAttribute) attribute can be used to provide a description for a parameter.

#### [Minimal APIs](#tab/minimal-apis)

The follow sample demonstrates how to set a description for a parameter.

```csharp
app.MapGet("/attributes",
  ([Description("This is a description.")] string name) => "Hello world!");
```

#### [Controllers](#tab/controllers)

The following sample demonstrates how to set a description for a parameter.

```csharp
  [HttpGet("attributes")]
  public IResult Attributes([Description("This is a description.")] string name)
  {
      return Results.Ok("Hello world!");
  }
```
---

### Describe the request body

The `requestBody` field in OpenAPI describes the body of a request that an API client can send to the server, including the content type(s) supported and the schema for the body content.

When the endpoint handler method accepts parameters that are bound from the request body, ASP.NET Core generates a corresponding `requestBody` for the operation in the OpenAPI document. Metadata for the request body can also be specified using attributes or extension methods. Additional metadata can be set with a [document transformer](xref:fundamentals/openapi/customize-openapi#use-document-transformers) or [operation transformer](xref:fundamentals/openapi/customize-openapi#use-operation-transformers).

If the endpoint doesn't define any parameters bound to the request body, but instead consumes the request body from the <xref:Microsoft.AspNetCore.Http.HttpContext> directly, ASP.NET Core provides mechanisms to specify request body metadata. This is a common scenario for endpoints that process the request body as a stream.

Some request body metadata can be determined from the [`FromBody`](xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute) or [`FromForm`](xref:Microsoft.AspNetCore.Mvc.FromFormAttribute) parameters of the route handler method.

A description for the request body can be set with a [`[Description]`](xref:System.ComponentModel.DescriptionAttribute) attribute on the parameter with [`FromBody`](xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute) or [`FromForm`](xref:Microsoft.AspNetCore.Mvc.FromFormAttribute).

If the [`FromBody`](xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute) parameter is non-nullable and <xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute.EmptyBodyBehavior> is not set to <xref:Microsoft.AspNetCore.Mvc.ModelBinding.EmptyBodyBehavior.Allow> in the [`FromBody`](xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute) attribute, the request body is required and the `required` field of the `requestBody` is set to `true` in the generated OpenAPI document.
Form bodies are always required and have `required` set to `true`.

Use a [document transformer](xref:fundamentals/openapi/customize-openapi#use-document-transformers) or an [operation transformer](xref:fundamentals/openapi/customize-openapi#use-operation-transformers) to set the `example`, `examples`, or `encoding` fields, or to add specification extensions for the request body in the generated OpenAPI document.

Other mechanisms for setting request body metadata depend on the type of app being developed and are described in the following sections.

#### [Minimal APIs](#tab/minimal-apis)

The content types for the request body in the generated OpenAPI document are determined from the type of the parameter that is bound to the request body or specified with the <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Accepts%2A> extension method.
By default, the content type of a [`FromBody`](xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute) parameter will be `application/json` and the content type for [`FromForm`](xref:Microsoft.AspNetCore.Mvc.FromFormAttribute) parameter(s) will be `multipart/form-data` or `application/x-www-form-urlencoded`.

Support for these default content types is built in to Minimal APIs, and other content types can be handled by using custom binding.
See the [Custom binding](xref:fundamentals/minimal-apis/parameter-binding#custom-binding) topic of the Minimal APIs documentation for more information.

There are several ways to specify a different content type for the request body.
If the type of the [`FromBody`](xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute) parameter implements <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointParameterMetadataProvider>, ASP.NET Core uses this interface to determine the content type(s) in the request body.
The framework uses the <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointMetadataProvider.PopulateMetadata%2A> method of this interface to set the content type(s) and type of the body content of the request body. For example, a `Todo` class that accepts either `application/xml` or `text/xml` content-type can use <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointParameterMetadataProvider> to provide this information to the framework.

```csharp
public class Todo : IEndpointParameterMetadataProvider
{
    public static void PopulateMetadata(ParameterInfo parameter, EndpointBuilder builder)
    {
        builder.Metadata.Add(new AcceptsMetadata(["application/xml", "text/xml"], typeof(Todo)));
    }
}
```

The <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Accepts%2A> extension method can also be used to specify the content type of the request body.
In the following example, the endpoint accepts a `Todo` object in the request body with an expected content-type of `application/xml`.

```csharp
app.MapPut("/todos/{id}", (int id, Todo todo) => ...)
  .Accepts<Todo>("application/xml");
```

Since `application/xml` is not a built-in content type, the `Todo` class must implement the <xref:Microsoft.AspNetCore.Http.IBindableFromHttpContext%601> interface to provide a custom binding for the request body. For example:

```csharp
public class Todo : IBindableFromHttpContext<Todo>
{
    public static async ValueTask<Todo?> BindAsync(HttpContext context, ParameterInfo parameter)
    {
        var xmlDoc = await XDocument.LoadAsync(context.Request.Body, LoadOptions.None, context.RequestAborted);
        var serializer = new XmlSerializer(typeof(Todo));
        return (Todo?)serializer.Deserialize(xmlDoc.CreateReader());
    }
```

If the endpoint doesn't define any parameters bound to the request body, use the <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Accepts%2A> extension method to specify the content type that the endpoint accepts.

If you specify <AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Accepts%2A> multiple times, only metadata from the last one is used -- they aren't combined.

#### [Controllers](#tab/controllers)

In controller-based apps, the content type(s) for the request body in the generated OpenAPI document are determined from the type of the parameter that is bound to the request body, the <xref:Microsoft.AspNetCore.Mvc.Formatters.InputFormatter> types configured in the application, or by a [`[Consumes]`](xref:Microsoft.AspNetCore.Mvc.ConsumesAttribute) attribute on the route handler method.

ASP.NET Core uses an <xref:Microsoft.AspNetCore.Mvc.Formatters.InputFormatter> to deserialize a [`FromBody`](xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute) request body.
InputFormatters are configured in the <xref:Microsoft.AspNetCore.Mvc.MvcOptions> passed to the <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllers%2A> extension method for the app's service collection.
Each input formatter declares the content types it can handle, in its <xref:Microsoft.AspNetCore.Mvc.Formatters.InputFormatter.SupportedMediaTypes> property, and the type(s) of body content it can handle, with its <xref:Microsoft.AspNetCore.Mvc.Formatters.InputFormatter.CanReadType%2A> method.

ASP.NET Core MVC includes built-in input formatters for JSON and XML, though only the JSON input formatter is enabled by default.
The built-in JSON input formatter supports the `application/json`, `text/json`, and `application/*+json` content types, and the built-in XML input formatter supports the `application/xml`, `text/xml`, and `application/*+xml` content types.

By default, the content type of a [`FromBody`](xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute) request body may be any content type accepted by an <xref:Microsoft.AspNetCore.Mvc.Formatters.InputFormatter> for the [`FromBody`](xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute) parameter type. For a request body with [`FromForm`](xref:Microsoft.AspNetCore.Mvc.FromFormAttribute) parameter(s) the default content types are `multipart/form-data` or `application/x-www-form-urlencoded`.These content types will be included in the generated OpenAPI document if the [`[Consumes]`](xref:Microsoft.AspNetCore.Mvc.ConsumesAttribute) attribute is not specified on the route handler method.

The content type(s) accepted by a route handler can be restricted using a [filter](xref:mvc/controllers/filters) on the endpoint (action scope).
The [`[Consumes]`](xref:Microsoft.AspNetCore.Mvc.ConsumesAttribute) attribute adds an action scope filter to the endpoint that restricts the content types that a route handler will accept.
In this case, the requestBody in the generated OpenAPI document will include only the content type(s) specified in the [`[Consumes]`](xref:Microsoft.AspNetCore.Mvc.ConsumesAttribute) attribute.

A [`[Consumes]`](xref:Microsoft.AspNetCore.Mvc.ConsumesAttribute) attribute can't add support for a content type that doesn't have an associated input formatter, and the generated OpenAPI document doesn't include any content types that don't have an associated input formatter.

For content types other than JSON or XML, you need to create a custom input formatter.
For more information and examples, see [Custom formatters in ASP.NET Core Web API](xref:web-api/advanced/custom-formatters).

If the route handler doesn't have a [`FromBody`](xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute) or [`FromForm`](xref:Microsoft.AspNetCore.Mvc.FromFormAttribute) parameter, the route handler might read the request body directly from the `Request.Body` stream and might use the [`[Consumes]`](xref:Microsoft.AspNetCore.Mvc.ConsumesAttribute) attribute to restrict the content types allowed, but no requestBody is generated in the OpenAPI document.

---

### Describe response types

OpenAPI supports providing a description of the responses returned from an API. ASP.NET Core provides several strategies for setting the response metadata of an endpoint. Response metadata that can be set includes the status code, the type of the response body, and content type(s) of a response. Responses in OpenAPI may have additional metadata, such as description, headers, links, and examples. This additional metadata can be set with a [document transformer](xref:fundamentals/openapi/customize-openapi#use-document-transformers) or [operation transformer](xref:fundamentals/openapi/customize-openapi#use-operation-transformers).

The specific mechanisms for setting response metadata depend on the type of app being developed.

#### [Minimal APIs](#tab/minimal-apis)

In Minimal API apps, ASP.NET Core can extract the response metadata added by extension methods on the endpoint, attributes on the route handler, and the return type of the route handler.

* The <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Produces%2A> extension method can be used on the endpoint to specify the status code, the type of the response body, and content type(s) of a response from an endpoint.
* The [`[ProducesResponseType]`](xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute) or <xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute%601> attribute can be used to specify the type of the response body.
* A route handler can be used to return a type that implements <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointMetadataProvider> to specify the type and content-type(s) of the response body.
* The <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.ProducesProblem%2A> extension method on the endpoint can be used to specify the status code and content-type(s) of an error response.

Note that the <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Produces%2A>  and <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.ProducesProblem%2A> extension methods are supported on both <xref:Microsoft.AspNetCore.Builder.RouteHandlerBuilder> and on <xref:Microsoft.AspNetCore.Routing.RouteGroupBuilder>. This allows, for example, a common set of error responses to be defined for all operations in a group.

When not specified by one of the preceding strategies, the:
* Status code for the response defaults to 200.
* Schema for the response body can be inferred from the implicit or explicit return type of the endpoint method, for example, from `T` in <xref:System.Threading.Tasks.Task%601>; otherwise, it's considered to be unspecified.
* Content-type for the specified or inferred response body is "application/json".

In Minimal APIs, the <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Produces%2A> extension method and the [`[ProducesResponseType]`](xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute) attribute only set the response metadata for the endpoint. They do not modify or constrain the behavior of the endpoint, which may return a different status code or response body type than specified by the metadata, and the content-type is determined by the return type of the route handler method, irrespective of any content-type specified in attributes or extension methods.

The <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Produces%2A> extension method can specify an endpoint's response type, with a default status code of 200 and a default content type of `application/json`. The following example illustrates this:

```csharp
app.MapGet("/todos", async (TodoDb db) => await db.Todos.ToListAsync())
  .Produces<IList<Todo>>();
```

The [`[ProducesResponseType]`](xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute) can be used to add response metadata to an endpoint. Note that the attribute is applied to the route handler method, not the method invocation to create the route, as shown in the following example:

```csharp
app.MapGet("/todos",
    [ProducesResponseType<List<Todo>>(200)]
    async (TodoDb db) => await db.Todos.ToListAsync());
```

Using <xref:Microsoft.AspNetCore.Http.TypedResults> in the implementation of an endpoint's route handler automatically includes the response type metadata for the endpoint. For example, the following code automatically annotates the endpoint with a response under the `200` status code with an `application/json` content type.

```csharp
app.MapGet("/todos", async (TodoDb db) =>
{
    var todos = await db.Todos.ToListAsync();
    return TypedResults.Ok(todos);
});
```

Only return types that implement <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointMetadataProvider> create a `responses` entry in the OpenAPI document. The following is a partial list  of some of the <xref:Microsoft.AspNetCore.Http.TypedResults> helper methods that produce a `responses` entry:

| TypedResults helper method | status code |
| -------------------------- | ----------- |
| Ok()                       | 200         |
| Created()                  | 201         |
| CreatedAtRoute()           | 201         |
| Accepted()                 | 202         |
| AcceptedAtRoute()          | 202         |
| NoContent()                | 204         |
| BadRequest()               | 400         |
| ValidationProblem()        | 400         |
| NotFound()                 | 404         |
| Conflict()                 | 409         |
| UnprocessableEntity()      | 422         |

All of these methods except `NoContent` have a generic overload that specifies the type of the response body.

A class can be implemented to set the endpoint metadata and return it from the route handler.

##### Set responses for `ProblemDetails`

When setting the response type for endpoints that may return a ProblemDetails response, the following can be used to add the appropriate response metadata for the endpoint:

* <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.ProducesProblem%2A>
* <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.ProducesValidationProblem%2A> extension method.
* <xref:Microsoft.AspNetCore.Http.TypedResults> with a status code in the (400-499) range.

For more information on how to configure a Minimal API app to return ProblemDetails responses, see <xref:fundamentals/minimal-apis/handle-errors>.

##### Multiple response types

If an endpoint can return different response types in different scenarios, you can provide metadata in the following ways:

* Call the <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Produces%2A> extension method multiple times, as shown in the following example:

  [!code-csharp[](~/fundamentals/minimal-apis/samples/todo/Program.cs?name=snippet_getCustom)]

* Use <xref:Microsoft.AspNetCore.Http.HttpResults.Results%606> in the signature and <xref:Microsoft.AspNetCore.Http.TypedResults> in the body of the handler, as shown in the following example:

  :::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/MultipleResultTypes/Program.cs" id="snippet_multiple_result_types":::

  The `Results<TResult1,TResult2,TResultN>` [union types](https://en.wikipedia.org/wiki/Union_type) declare that a route handler returns multiple `IResult`-implementing concrete types, and any of those types that implement <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointMetadataProvider> will contribute to the endpoint’s metadata.

  The union types implement implicit cast operators. These operators enable the compiler to automatically convert the types specified in the generic arguments to an instance of the union type. This capability has the added benefit of providing compile-time checking that a route handler only returns the results that it declares it does. Attempting to return a type that isn't declared as one of the generic arguments to `Results<TResult1,TResult2,TResultN>` results in a compilation error.

#### [Controllers](#tab/controllers)

In controller-based apps, ASP.NET Core can extract the response metadata from the action method signature, attributes, and conventions. 

* You can use the [`[ProducesResponseType]`](xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute) or <xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute%601> attribute to specify the status code, the type of the response body, and content type(s) of a response from an action method.
* You can use the [`[Produces]`](xref:Microsoft.AspNetCore.Mvc.ProducesAttribute) or <xref:Microsoft.AspNetCore.Mvc.ProducesAttribute%601> attribute to specify the type of the response body.
* You can use the [`[ProducesDefaultResponseType]`](xref:Microsoft.AspNetCore.Mvc.ProducesDefaultResponseTypeAttribute) attribute to specify the response body type for the "default" response.
* You can use the [`[ProducesErrorResponseType]`](xref:Microsoft.AspNetCore.Mvc.ProducesErrorResponseTypeAttribute) attribute to specify the response body type for an error response. However, be aware that this is only complements the status code and content type(s) specified by an [`[ProducesResponseType]`](xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute) attribute with a 4XX status code.

Only one [`[Produces]`](xref:Microsoft.AspNetCore.Mvc.ProducesAttribute) or <xref:Microsoft.AspNetCore.Mvc.ProducesAttribute%601> attributes may be applied to an action method, but multiple [`[ProducesResponseType]`](xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute) or <xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute%601> attributes with different status codes may be applied to a single action method.

All of the above attributes can be applied to individual action methods or to the controller class where it applies to all action methods in the controller.

When not specified by an attribute:
* the status code for the response defaults to 200,
* the schema for the response body of 2xx responses may be inferred from the return type of the action method, e.g. from `T` in <xref:Microsoft.AspNetCore.Mvc.ActionResult%601>, but otherwise is considered to be not specified,
* the schema for the response body of 4xx responses is inferred to be a problem details object,
* the schema for the response body of 3xx and 5xx responses is considered to be not specified,
* the content-type for the response body can be inferred from the return type of the action method and the set of output formatters.

Note that there are no compile-time checks to ensure that the response metadata specified with a [`[ProducesResponseType]`](xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute) attribute is consistent with the actual behavior of the action method,
which may return a different status code or response body type than specified by the metadata.

In controller-based apps, ASP.NET responds with a ProblemDetails response type when model validation fails or when the action method returns a result with a 4xx or 5xx HTTP status code. Validation errors typically use the 400 status code, so you can use the [`[ProducesResponseType]`](xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute) attribute to specify the error response for an action, as shown in the following example:

```csharp
[HttpPut("/todos/{id}")]
[ProducesResponseType<Todo>(StatusCodes.Status200OK, "application/json")]
[ProducesResponseType<Todo>(StatusCodes.Status201Created, "application/json")]
[ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
public async Task<ActionResult<Todo>> CreateOrReplaceTodo(string id, Todo todo)
```

This example also illustrates how to define multiple response types for an action method, including the content type of the response body.

---

### Exclude endpoints from the generated document

By default, all endpoints that are defined in an app are documented in the generated OpenAPI file, but endpoints can be excluded from the document using attributes or extension methods.

The mechanism for specifying an endpoint that should be excluded depends on the type of app being developed.

#### [Minimal APIs](#tab/minimal-apis)

Minimal APIs support two strategies for excluding a given endpoint from the OpenAPI document:

* <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.ExcludeFromDescription%2A> extension method
* [`[ExcludeFromDescription]`](xref:Microsoft.AspNetCore.Routing.ExcludeFromDescriptionAttribute) attribute

The following sample demonstrates the different strategies for excluding a given endpoint from the generated OpenAPI document.

```csharp
app.MapGet("/extension-method", () => "Hello world!")
  .ExcludeFromDescription();

app.MapGet("/attributes",
  [ExcludeFromDescription]
  () => "Hello world!");
```

#### [Controllers](#tab/controllers)

In controller-based apps, the [`[ApiExplorerSettings]`](xref:Microsoft.AspNetCore.Mvc.ApiExplorerSettingsAttribute) attribute can be used to exclude an endpoint or all endpoints in a controller class from the OpenAPI document.

The following example demonstrates how to exclude an endpoint from the generated OpenAPI document:

```csharp
  [HttpGet("/private")]
  [ApiExplorerSettings(IgnoreApi = true)]
  public IActionResult PrivateEndpoint() {
      return Ok("This is a private endpoint");
  }
```
---

## Include OpenAPI metadata for data types

C# classes or records used in request or response bodies are represented as schemas
in the generated OpenAPI document.
By default, only public properties are represented in the schema, but there are
<xref:System.Text.Json.JsonSerializerOptions> to also create schema properties for fields.

When the <xref:System.Text.Json.JsonSerializerOptions.PropertyNamingPolicy> is set to camel-case (this is the default
in ASP.NET web applications), property names in a schema are the camel-case form
of the class or record property name.
The [`[JsonPropertyName]`](xref:System.Text.Json.Serialization.JsonPropertyNameAttribute) can be used on an individual property to specify the name
of the property in the schema.

### type and format

The JSON Schema library maps standard C# types to OpenAPI `type` and `format` as follows:

| C# Type        | OpenAPI `type` | OpenAPI `format` |
| -------------- | -------------- | ---------------- |
| int            | integer        | int32            |
| long           | integer        | int64            |
| short          | integer        | int16            |
| byte           | integer        | uint8            |
| float          | number         | float            |
| double         | number         | double           |
| decimal        | number         | double           |
| bool           | boolean        |                  |
| string         | string         |                  |
| char           | string         | char             |
| byte[]         | string         | byte             |
| DateTimeOffset | string         | date-time        |
| DateOnly       | string         | date             |
| TimeOnly       | string         | time             |
| Uri            | string         | uri              |
| Guid           | string         | uuid             |
| object         | _omitted_      |                  |
| dynamic        | _omitted_      |                  |

Note that object and dynamic types have _no_ type defined in the OpenAPI because these can contain data of any type, including primitive types like int or string.

The `type` and `format` can also be set with a [Schema Transformer](xref:fundamentals/openapi/customize-openapi#use-schema-transformers). For example, you may want the `format` of decimal types to be `decimal` instead of `double`.

### Use attributes to add metadata

ASP.NET uses metadata from attributes on class or record properties to set metadata on the corresponding properties of the generated schema.

The following table summarizes attributes from the `System.ComponentModel` namespace that provide metadata for the generated schema:

| Attribute                    | Description |
| ---------------------------- | ----------- |
| [`[Description]`](xref:System.ComponentModel.DescriptionAttribute)                       | Sets the `description` of a property in the schema. |
| [`[Required]`](xref:System.ComponentModel.DataAnnotations.RequiredAttribute)          | Marks a property as `required` in the schema. |
| [`[DefaultValue]`](xref:System.ComponentModel.DefaultValueAttribute)                      | Sets the `default` value of a property in the schema. |
| [`[Range]`](xref:System.ComponentModel.DataAnnotations.RangeAttribute)             | Sets the `minimum` and `maximum` value of an integer or number. |
| [`[MinLength]`](xref:System.ComponentModel.DataAnnotations.MinLengthAttribute)         | Sets the `minLength` of a string. |
| [`[MaxLength]`](xref:System.ComponentModel.DataAnnotations.MaxLengthAttribute)         | Sets the `maxLength` of a string. |
| [`[RegularExpression]`](xref:System.ComponentModel.DataAnnotations.RegularExpressionAttribute) | Sets the `pattern` of a string. |

Note that in controller-based apps, these attributes add filters to the operation to validate that any incoming data satisfies the constraints. In Minimal APIs, these attributes set the metadata in the generated schema but validation must be performed explicitly via an endpoint filter, in the route handler's logic, or via a third-party package.

Attributes can also be placed on parameters in the parameter list of a record definition but must include the `property` modifier. For example:

```csharp
public record Todo(
    [property: Required]
    [property: Description("The unique identifier for the todo")]
    int Id,
    [property: Description("The title of the todo")]
    [property: MaxLength(120)]
    string Title,
    [property: Description("Whether the todo has been completed")]
    bool Completed
) {}
```

### Other sources of metadata for generated schemas

#### required

In a class, struct, or record, properties with the [`[Required]`](xref:System.ComponentModel.DataAnnotations.RequiredAttribute) attribute or [required](/dotnet/csharp/language-reference/proposals/csharp-11.0/required-members#required-modifier) modifier are always `required` in the corresponding schema.

Other properties may also be required based on the constructors (implicit and explicit) for the class, struct, or record.
- For a class or record class with a single public constructor, any property with the same type and name (case-insensitive match) as a parameter to the constructor is required in the corresponding schema.
- For a class or record class with multiple public constructors, no other properties are required.
- For a struct or record struct, no other properties are required since C# always defines an implicit parameterless constructor for a struct.

#### enum

Enum types in C# are integer-based, but can be represented as strings in JSON with a  [`[JsonConverter]`](xref:System.Text.Json.Serialization.JsonConverterAttribute) and a <xref:System.Text.Json.Serialization.JsonStringEnumConverter>. When an enum type is represented as a string in JSON, the generated schema will have an `enum` property with the string values of the enum.

The following example demonstrates how to use a `JsonStringEnumConverter` to represent an enum as a string in JSON:

```csharp
[JsonConverter(typeof(JsonStringEnumConverter<DayOfTheWeekAsString>))]
public enum DayOfTheWeekAsString
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday
}
```

A special case is when an enum type has the [Flags] attribute, which indicates that the enum can be treated as a bit field; that is, a set of flags. A flags enum with a [JsonConverterAttribute] will be defined as `type: string` in the generated schema with no `enum` property, since the value could be any combination of the enum values. For example, the following enum:

```csharp
[Flags, JsonConverter(typeof(JsonStringEnumConverter<PizzaToppings>))]
public enum PizzaToppings { Pepperoni = 1, Sausage = 2, Mushrooms = 4, Anchovies = 8 }
```

could have values such as `"Pepperoni, Sausage"` or `"Sausage, Mushrooms, Anchovies"`.

An enum type without a  [`[JsonConverter]`](xref:System.Text.Json.Serialization.JsonConverterAttribute) will be defined as `type: integer` in the generated schema.

**Note:** The [`[AllowedValues]`](xref:System.ComponentModel.DataAnnotations.AllowedValuesAttribute) attribute does not set the `enum` values of a property.

#### nullable

Properties defined as a nullable value or reference type have `nullable: true` in the generated schema. This is consistent with the default behavior of the <xref:System.Text.Json> deserializer, which accepts `null` as a valid value for a nullable property.

#### additionalProperties

Schemas are generated without an `additionalProperties` assertion by default, which implies the default of `true`. This is consistent with the default behavior of the <xref:System.Text.Json> deserializer, which silently ignores additional properties in a JSON object.

If the additional properties of a schema should only have values of a specific type, define the property or class as a `Dictionary<string, type>`. The key type for the dictionary must be `string`. This generates a schema with `additionalProperties` specifying the schema for "type" as the required value types.

#### Polymorphic types

Use the [`[JsonPolymorphic]`](xref:System.Text.Json.Serialization.JsonPolymorphicAttribute) and [`[JsonDerivedType]`](xref:System.Text.Json.Serialization.JsonDerivedTypeAttribute) attributes on a parent class to to specify the discriminator field and subtypes for a polymorphic type.

The [`[JsonDerivedType]`](xref:System.Text.Json.Serialization.JsonDerivedTypeAttribute) adds the discriminator field to the schema for each subclass, with an enum specifying the specific discriminator value for the subclass. This attribute also modifies the constructor of each derived class to set the discriminator value.

An abstract class with a [`[JsonPolymorphic]`](xref:System.Text.Json.Serialization.JsonPolymorphicAttribute) attribute has a `discriminator` field in the schema, but a concrete class with a [`[JsonPolymorphic]`](xref:System.Text.Json.Serialization.JsonPolymorphicAttribute) attribute doesn't have a `discriminator` field. OpenAPI requires that the discriminator property be a required property in the schema, but since the discriminator property isn't defined in the concrete base class, the schema cannot include a `discriminator` field.

### Add metadata with a schema transformer

A schema transformer can be used to override any default metadata or add additional metadata, such as `example` values, to the generated schema. See [Use schema transformers](xref:fundamentals/openapi/customize-openapi#use-schema-transformers) for more information.

## Additional resources

* <xref:fundamentals/openapi/using-openapi-documents>
* [OpenAPI specification](https://spec.openapis.org/oas/v3.0.3)
