---
title: Generate OpenAPI documents
author: captainsafia
description: Learn how to generate and customize OpenAPI documents in an ASP.NET Core app
ms.author: safia
monikerRange: '>= aspnetcore-6.0'
ms.custom: mvc
ms.date: 09/05/2024
uid: fundamentals/openapi/aspnetcore-openapi
---
# Generate OpenAPI documents

:::moniker range=">= aspnetcore-9.0"

The [`Microsoft.AspNetCore.OpenApi`](https://www.nuget.org/packages/Microsoft.AspNetCore.OpenApi) package provides built-in support for OpenAPI document generation in ASP.NET Core. The package provides the following features:

* Support for generating OpenAPI documents at run time and accessing them via an endpoint on the application.
* Support for "transformer" APIs that allow modifying the generated document.
* Support for generating multiple OpenAPI documents from a single app.
* Takes advantage of JSON schema support provided by [`System.Text.Json`](/dotnet/api/system.text.json).
* Is compatible with native AoT.

## Package installation

Install the `Microsoft.AspNetCore.OpenApi` package:

### [Visual Studio](#tab/visual-studio)

Run the following command from the **Package Manager Console**:

 ```powershell
 Install-Package Microsoft.AspNetCore.OpenApi -IncludePrerelease
```

### [.NET CLI](#tab/net-cli)

Run the following command:

```dotnetcli
dotnet add package Microsoft.AspNetCore.OpenApi --prerelease
```
---

To add support for generating OpenAPI documents at build time, install the `Microsoft.Extensions.ApiDescription.Server` package:

### [Visual Studio](#tab/visual-studio)

Run the following command from the **Package Manager Console**:

 ```powershell
 Install-Package Microsoft.Extensions.ApiDescription.Server -IncludePrerelease
```

### [.NET CLI](#tab/net-cli)

Run the following command in the directory that contains the project file:

```dotnetcli
dotnet add package Microsoft.Extensions.ApiDescription.Server --prerelease
```
---

## Configure OpenAPI document generation

The following code:

* Adds OpenAPI services.
* Enables the endpoint for viewing the OpenAPI document in JSON format.

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_first&highlight=3,7)]

Launch the app and navigate to `https://localhost:<port>/openapi/v1.json` to view the generated OpenAPI document.

## Including OpenAPI metadata in an ASP.NET web app

### Including OpenAPI metadata for endpoints

ASP.NET collects metadata from the web app's endpoints and uses it to generate an OpenAPI document.
In controller-based apps, metadata is collected from attributes like <xref:Microsoft.AspNetCore.Http.EndpointDescriptionAttribute>, <xref:Microsoft.AspNetCore.Mvc.HttpPostAttribute>,
and <xref:Microsoft.AspNetCore.Mvc.ProducesAttribute>.
In minimal APIs, metadata can be collected from attributes, but may also be set by using extension methods
and other strategies, such as returning <xref:Microsoft.AspNetCore.Http.TypedResults> from route handlers.
The following table provides an overview of the metadata collected and the strategies for setting it.

| Metadata | Attribute | Extension method | Other strategies |
| --- | --- | --- |
| summary | <xref:Microsoft.AspNetCore.Http.EndpointSummaryAttribute> | <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.WithSummary%2A> | |
| description | <xref:Microsoft.AspNetCore.Http.EndpointDescriptionAttribute> | <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.WithDescription%2A> | |
| tags | <xref:Microsoft.AspNetCore.Http.TagsAttribute> | <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.WithTags%2A> | |
| operationId | <xref:Microsoft.AspNetCore.Routing.EndpointNameAttribute> | <xref:Microsoft.AspNetCore.Builder.RoutingEndpointConventionBuilderExtensions.WithName%2A> | |
| parameters | <xref:Microsoft.AspNetCore.Mvc.FromQueryAttribute>, <xref:Microsoft.AspNetCore.Mvc.FromRouteAttribute>, <xref:Microsoft.AspNetCore.Mvc.FromHeaderAttribute>, <xref:Microsoft.AspNetCore.Mvc.FromFormAttribute> | |
| parameter description | <xref:Microsoft.AspNetCore.Http.EndpointDescriptionAttribute> | | |
| requestBody | <xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute> | <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Accepts%2A> | |
| responses | <xref:Microsoft.AspNetCore.Mvc.ProducesAttribute> | <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Produces%2A>, <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.ProducesProblem%2A> | <xref:Microsoft.AspNetCore.Http.TypedResults> |
| Excluding endpoints | <xref:Microsoft.AspNetCore.Routing.ExcludeFromDescriptionAttribute>, <xref:Microsoft.AspNetCore.Mvc.ApiExplorerSettingsAttribute> | <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.ExcludeFromDescription%2A> | |

ASP.NET Core does not collect metadata from XML doc comments.

The following sections demonstrate how to include metadata in an app to customize the generated OpenAPI document.

#### Summary and description

The endpoint summary and description can be set using the <xref:Microsoft.AspNetCore.Http.EndpointSummaryAttribute> and <xref:Microsoft.AspNetCore.Http.EndpointDescriptionAttribute> attributes,
or in minimal APIs, using the <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.WithSummary%2A> and <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.WithDescription%2A> extension methods.

##### [Minimal APIs](#tab/minimal-apis)

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

##### [Controllers](#tab/controllers)

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

#### tags

OpenAPI supports specifying tags on each endpoint as a form of categorization.

##### [Minimal APIs](#tab/minimal-apis)

In minimal APIs, tags can be set using either the <xref:Microsoft.AspNetCore.Http.TagsAttribute> attribute or the <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.WithTags%2A> extension method.

The following sample demonstrates the different strategies for setting tags.

```csharp
app.MapGet("/extension-methods", () => "Hello world!")
  .WithTags("todos", "projects");

app.MapGet("/attributes",
  [Tags("todos", "projects")]
  () => "Hello world!");
```

##### [Controllers](#tab/controllers)

In controller-based apps, the controller name is automatically added as a tag on each of its endpoints, but this can be overridden using the <xref:Microsoft.AspNetCore.Http.TagsAttribute> attribute.

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

#### operationId

OpenAPI supports an operationId on each endpoint as a unique identifier or name for the operation. 

##### [Minimal APIs](#tab/minimal-apis)

In minimal APIs, the operationId can be set using either the <xref:Microsoft.AspNetCore.Routing.EndpointNameAttribute> attribute or the <xref:Microsoft.AspNetCore.Builder.RoutingEndpointConventionBuilderExtensions.WithName%2A> extension method.

The following sample demonstrates the different strategies for setting the operationId.

```csharp
app.MapGet("/extension-methods", () => "Hello world!")
  .WithName("FromExtensionMethods");

app.MapGet("/attributes",
  [EndpointName("FromAttributes")]
  () => "Hello world!");
```

##### [Controllers](#tab/controllers)

In controller-based apps, the operationId can be set using the <xref:Microsoft.AspNetCore.Routing.EndpointNameAttribute> attribute.

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

#### parameters

OpenAPI supports annotating path, query string, header, and cookie parameters that are consumed by an API.

The framework infers the types for request parameters automatically based on the signature of the route handler.

The <xref:Microsoft.AspNetCore.Http.EndpointDescriptionAttribute> attribute can be used to provide a description for a parameter.

##### [Minimal APIs](#tab/minimal-apis)

The follow sample demonstrates how to set a description for a parameter.

```csharp
app.MapGet("/attributes",
  ([Description("This is a description.")] string name) => "Hello world!");
```

##### [Controllers](#tab/controllers)

The following sample demonstrates how to set a description for a parameter.

```csharp
  [HttpGet("attributes")]
  public IResult Attributes([Description("This is a description.")] string name)
  {
      return Results.Ok("Hello world!");
  }
```
---

#### requestBody

<!-- TODO: Restructure this section to cover both controller-based and minimal API apps -->

To define the type of inputs transmitted as the request body, configure the properties by using the <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Accepts%2A> extension method to define the object type and content type that are expected by the request handler. In the following example, the endpoint accepts a `Todo` object in the request body with an expected content-type of `application/xml`.

```csharp
app.MapPost("/todos/{id}", (int id, Todo todo) => ...)
  .Accepts<Todo>("application/xml");
```

<!-- TODO: Add more context on this example. Specifically we need to add the BindAsync method 
in the TODO class because without it Minimal will try to deserialize as JSON -->

In addition to the <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Accepts%2A> extension method, a parameter type can describe its own annotation by implementing the <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointParameterMetadataProvider> interface. For example, the following `Todo` type adds an annotation that requires a request body with an `application/xml` content-type.

```csharp
public class Todo : IEndpointParameterMetadataProvider
{
    public static void PopulateMetadata(ParameterInfo parameter, EndpointBuilder builder)
    {
        builder.Metadata.Add(new AcceptsMetadata(["application/xml", "text/xml"], typeof(XmlBody)));
    }
}
```

When no explicit annotation is provided, the framework attempts to determine the default request type if there's a request body parameter in the endpoint handler. The inference uses the following heuristics to produce the annotation:

* Request body parameters that are read from a form via the <xref:Microsoft.AspNetCore.Mvc.FromFormAttribute> attribute are described with the `multipart/form-data` content-type.
* All other request body parameters are described with the `application/json` content-type.
* The request body is treated as optional if it's nullable or if the <xref:Microsoft.AspNetCore.Http.Metadata.IFromBodyMetadata.AllowEmpty> property is set on the [`FromBody`](xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute) attribute.

#### Describe response types

OpenAPI supports providing a description of the responses returned from an API. ASP.NET Core provides several strategies for setting the response metadata of an endpoint. Response metadata that can be set includes the status code, the type of the response body, and content type(s) of a response. Responses in OpenAPI may have additional metadata, such as description, headers, links, and examples. This additional metadata can be set with a [document transformer](#use-document-transformers) or [operation transformer](#use-operation-transformers).

The specific mechanisms for setting response metadata depend on the type of app being developed.

##### [Minimal APIs](#tab/minimal-apis)

In Minimal API apps, ASP.NET Core can extract the response metadata added by extension methods on the endpoint, attributes on the route handler, and the return type of the route handler.

* The <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Produces%2A> extension method can be used on the endpoint to specify the status code, the type of the response body, and content type(s) of a response from an endpoint.
* The <xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute> or <xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute%601> attribute can be used to specify the type of the response body.
* A route handler can be used to return a type that implements <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointMetadataProvider> to specify the type and content-type(s) of the response body.
* The <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.ProducesProblem%2A> extension method on the endpoint can be used to specify the status code and content-type(s) of an error response.

Note that the <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Produces%2A>  and <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.ProducesProblem%2A> extension methods are supported on both <xref:Microsoft.AspNetCore.Builder.RouteHandlerBuilder> and on <xref:Microsoft.AspNetCore.Routing.RouteGroupBuilder>. This allows, for example, a common set of error responses to be defined for all operations in a group.

When not specified by one of the preceding strategies, the:
* Status code for the response defaults to 200.
* Schema for the response body can be inferred from the implicit or explicit return type of the endpoint method, for example, from `T` in <xref:System.Threading.Tasks.Task%601>; otherwise, it's considered to be unspecified.
* Content-type for the specified or inferred response body is "application/json".

In Minimal APIs, the <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Produces%2A> extension method and the <xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute> attribute only set the response metadata for the endpoint. They do not modify or constrain the behavior of the endpoint, which may return a different status code or response body type than specified by the metadata, and the content-type is determined by the return type of the route handler method, irrespective of any content-type specified in attributes or extension methods.

The <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Produces%2A> extension method can specify an endpoint's response type, with a default status code of 200 and a default content type of `application/json`. The following example illustrates this:

```csharp
app.MapGet("/todos", async (TodoDb db) => await db.Todos.ToListAsync())
  .Produces<IList<Todo>>();
```

The <xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute> can be used to add response metadata to an endpoint. Note that the attribute is applied to the route handler method, not the method invocation to create the route, as shown in the following example:

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

###### Set responses for `ProblemDetails`

When setting the response type for endpoints that may return a ProblemDetails response, the following can be used to add the appropriate response metadata for the endpoint:

* <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.ProducesProblem%2A>
* <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.ProducesValidationProblem%2A> extension method.
* <xref:Microsoft.AspNetCore.Http.TypedResults> with a status code in the (400-499) range.

For more information on how to configure a Minimal API app to return ProblemDetails responses, see <xref:fundamentals/minimal-apis/handle-errors>.

###### Multiple response types

If an endpoint can return different response types in different scenarios, you can provide metadata in the following ways:

* Call the <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Produces%2A> extension method multiple times, as shown in the following example:

  [!code-csharp[](~/fundamentals/minimal-apis/samples/todo/Program.cs?name=snippet_getCustom)]

* Use [`Results<TResult1,TResult2,TResultN>`](xref:Microsoft.AspNetCore.Http.HttpResults.Results%606) in the signature and <xref:Microsoft.AspNetCore.Http.TypedResults> in the body of the handler, as shown in the following example:

  :::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/MultipleResultTypes/Program.cs" id="snippet_multiple_result_types":::

  The `Results<TResult1,TResult2,TResultN>` [union types](https://en.wikipedia.org/wiki/Union_type) declare that a route handler returns multiple `IResult`-implementing concrete types, and any of those types that implement <xref:Microsoft.AspNetCore.Http.Metadata.IEndpointMetadataProvider> will contribute to the endpoint’s metadata.

  The union types implement implicit cast operators. These operators enable the compiler to automatically convert the types specified in the generic arguments to an instance of the union type. This capability has the added benefit of providing compile-time checking that a route handler only returns the results that it declares it does. Attempting to return a type that isn't declared as one of the generic arguments to `Results<TResult1,TResult2,TResultN>` results in a compilation error.

##### [Controllers](#tab/controllers)

In controller-based apps, ASP.NET Core can extract the response metadata from the action method signature, attributes, and conventions. 

* You can use the <xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute> or <xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute%601> attribute to specify the status code, the type of the response body, and content type(s) of a response from an action method.
* You can use the <xref:Microsoft.AspNetCore.Mvc.ProducesAttribute> or <xref:Microsoft.AspNetCore.Mvc.ProducesAttribute%601> attribute to specify the type of the response body.
* You can use the <xref:Microsoft.AspNetCore.Mvc.ProducesDefaultResponseTypeAttribute> attribute to specify the response body type for the "default" response.
* You can use the <xref:Microsoft.AspNetCore.Mvc.ProducesErrorResponseTypeAttribute> attribute to specify the response body type for an error response. However, be aware that this is only complements the status code and content type(s) specified by an <xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute> attribute with a 4XX status code.

Only one <xref:Microsoft.AspNetCore.Mvc.ProducesAttribute> or <xref:Microsoft.AspNetCore.Mvc.ProducesAttribute%601> attributes may be applied to an action method, but multiple <xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute> or <xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute%601> attributes with different status codes may be applied to a single action method.

All of the above attributes can be applied to individual action methods or to the controller class where it applies to all action methods in the controller.

When not specified by an attribute:
* the status code for the response defaults to 200,
* the schema for the response body of 2xx responses may be inferred from the return type of the action method, e.g. from `T` in <xref:Microsoft.AspNetCore.Mvc.ActionResult%601>, but otherwise is considered to be not specified,
* the schema for the response body of 4xx responses is inferred to be a problem details object,
* the schema for the response body of 3xx and 5xx responses is considered to be not specified,
* the content-type for the response body can be inferred from the return type of the action method and the set of output formatters.

Note that there are no compile-time checks to ensure that the response metadata specified with a <xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute> attribute is consistent with the actual behavior of the action method,
which may return a different status code or response body type than specified by the metadata.

In controller-based apps, ASP.NET responds with a ProblemDetails response type when model validation fails or when the action method returns a result with a 4xx or 5xx HTTP status code. Validation errors typically use the 400 status code, so you can use the <xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute> attribute to specify the error response for an action, as shown in the following example:

```csharp
[HttpPut("/todos/{id}")]
[ProducesResponseType<Todo>(StatusCodes.Status200OK, "application/json")]
[ProducesResponseType<Todo>(StatusCodes.Status201Created, "application/json")]
[ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
public async Task<ActionResult<Todo>> CreateOrReplaceTodo(string id, Todo todo)
```

This example also illustrates how to define multiple response types for an action method, including the content type of the response body.

---

#### Excluding endpoints from the generated document

By default, all endpoints that are defined in an app are documented in the generated OpenAPI file, but endpoints can be excluded from the document using attributes or extension methods.

The mechanism for specifying an endpoint that should be excluded depends on the type of app being developed.

##### [Minimal APIs](#tab/minimal-apis)

Minimal APIs support two strategies for excluding a given endpoint from the OpenAPI document:

* <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.ExcludeFromDescription%2A>
* <xref:Microsoft.AspNetCore.Routing.ExcludeFromDescriptionAttribute>

The following sample demonstrates the different strategies for excluding a given endpoint from the generated OpenAPI document.

```csharp
app.MapGet("/extension-method", () => "Hello world!")
  .ExcludeFromDescription();

app.MapGet("/attributes",
  [ExcludeFromDescription]
  () => "Hello world!");
```

##### [Controllers](#tab/controllers)

In controller-based apps, the <xref:Microsoft.AspNetCore.Mvc.ApiExplorerSettingsAttribute> attribute can be used to exclude an endpoint or all endpoints in a controller class from the OpenAPI document.

The following example demonstrates how to exclude an endpoint from the generated OpenAPI document:

```csharp
  [HttpGet("/private")]
  [ApiExplorerSettings(IgnoreApi = true)]
  public IActionResult PrivateEndpoint() {
      return Ok("This is a private endpoint");
  }
```
---

### Including OpenAPI metadata for data types

C# classes or records used in request or response bodies are represented as schemas
in the generated OpenAPI document.
By default, only public properties are represented in the schema, but there are
<xref:System.Text.Json.JsonSerializerOptions> to also create schema properties for fields.

When the <xref:System.Text.Json.JsonSerializerOptions.PropertyNamingPolicy> is set to camel-case (this is the default
in ASP.NET web applications), property names in a schema are the camel-case form
of the class or record property name.
The <xref:System.Text.Json.Serialization.JsonPropertyNameAttribute> can be used on an individual property to specify the name
of the property in the schema.

#### type and format

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

The `type` and `format` can also be set with a [Schema Transformer](#use-schema-transformers). For example, you may want the `format` of decimal types to be `decimal` instead of `double`.

#### Using attributes to add metadata

ASP.NET uses metadata from attributes on class or record properties to set metadata on the corresponding properties of the generated schema.

The following table summarizes attributes from the `System.ComponentModel` namespace that provide metadata for the generated schema:

| Attribute                    | Description |
| ---------------------------- | ----------- |
| <xref:System.ComponentModel.DescriptionAttribute>                       | Sets the `description` of a property in the schema. |
| <xref:System.ComponentModel.DataAnnotations.RequiredAttribute>          | Marks a property as `required` in the schema. |
| <xref:System.ComponentModel.DefaultValueAttribute>                      | Sets the `default` value of a property in the schema. |
| <xref:System.ComponentModel.DataAnnotations.RangeAttribute>             | Sets the `minimum` and `maximum` value of an integer or number. |
| <xref:System.ComponentModel.DataAnnotations.MinLengthAttribute>         | Sets the `minLength` of a string. |
| <xref:System.ComponentModel.DataAnnotations.MaxLengthAttribute>         | Sets the `maxLength` of a string. |
| <xref:System.ComponentModel.DataAnnotations.RegularExpressionAttribute> | Sets the `pattern` of a string. |

Note that in controller-based apps, these attributes add filters to the operation to validate that any incoming data satisfies the constraints. In Minimal APIs, these attributes set the metadata in the generated schema but validation must be performed explicitly via an endpoint filter, in the route handler's logic, or via a third-party package.

#### Other sources of metadata for generated schemas

##### required

Properties can also be marked as `required` with the [required](/dotnet/csharp/language-reference/proposals/csharp-11.0/required-members#required-modifier) modifier.

##### enum

Enum types in C# are integer-based, but can be represented as strings in JSON with a  <xref:System.Text.Json.Serialization.JsonConverterAttribute> and a <xref:System.Text.Json.Serialization.JsonStringEnumConverter>. When an enum type is represented as a string in JSON, the generated schema will have an `enum` property with the string values of the enum.
An enum type without a  <xref:System.Text.Json.Serialization.JsonConverterAttribute> will be defined as `type: integer` in the generated schema.

**Note:** The <xref:System.ComponentModel.DataAnnotations.AllowedValuesAttribute> does not set the `enum` values of a property.

##### nullable

Properties defined as a nullable value or reference type have `nullable: true` in the generated schema. This is consistent with the default behavior of the <xref:System.Text.Json> deserializer, which accepts `null` as a valid value for a nullable property.

##### additionalProperties

Schemas are generated without an `additionalProperties` assertion by default, which implies the default of `true`. This is consistent with the default behavior of the <xref:System.Text.Json> deserializer, which silently ignores additional properties in a JSON object.

If the additional properties of a schema should only have values of a specific type, define the property or class as a `Dictionary<string, type>`. The key type for the dictionary must be `string`. This generates a schema with `additionalProperties` specifying the schema for "type" as the required value types.

##### Metadata for polymorphic types

Use the <xref:System.Text.Json.Serialization.JsonPolymorphicAttribute> and <xref:System.Text.Json.Serialization.JsonDerivedTypeAttribute> attributes on a parent class to to specify the discriminator field and subtypes for a polymorphic type.

The <xref:System.Text.Json.Serialization.JsonDerivedTypeAttribute> adds the discriminator field to the schema for each subclass, with an enum specifying the specific discriminator value for the subclass. This attribute also modifies the constructor of each derived class to set the discriminator value.

An abstract class with a <xref:System.Text.Json.Serialization.JsonPolymorphicAttribute> attribute has a `discriminator` field in the schema, but a concrete class with a <xref:System.Text.Json.Serialization.JsonPolymorphicAttribute> attribute doesn't have a `discriminator` field. OpenAPI requires that the discriminator property be a required property in the schema, but since the discriminator property isn't defined in the concrete base class, the schema cannot include a `discriminator` field.

#### Adding metadata with a schema transformer

A schema transformer can be used to override any default metadata or add additional metadata, such as `example` values, to the generated schema. See [Use schema transformers](#use-schema-transformers) for more information.

## Options to Customize OpenAPI document generation

The following sections demonstrate how to customize OpenAPI document generation.

### Customize the OpenAPI document name

Each OpenAPI document in an app has a unique name. The default document name that is registered is `v1`.

```csharp
builder.Services.AddOpenApi(); // Document name is v1
```

The document name can be modified by passing the name as a parameter to the `AddOpenApi` call.

```csharp
builder.Services.AddOpenApi("internal"); // Document name is internal
```

The document name surfaces in several places in the OpenAPI implementation.

When fetching the generated OpenAPI document, the document name is provided as the `documentName` parameter argument in the request. The following requests resolve the `v1` and `internal` documents.

```bash
GET http://localhost:5000/openapi/v1.json
GET http://localhost:5000/openapi/internal.json
```

### Customize the OpenAPI version of a generated document

By default, OpenAPI document generation creates a document that is compliant with [v3.0 of the OpenAPI specification](https://spec.openapis.org/oas/v3.0.0). The following code demonstrates how to modify the default version of the OpenAPI document:

```csharp
builder.Services.AddOpenApi(options =>
{
    options.OpenApiVersion = OpenApiSpecVersion.OpenApi2_0;
});
```

### Customize the OpenAPI endpoint route

By default, the OpenAPI endpoint registered via a call to <xref:Microsoft.AspNetCore.Builder.MapOpenApi> exposes the document at the `/openapi/{documentName}.json` endpoint. The following code demonstrates how to customize the route at which the OpenAPI document is registered:

```csharp
app.MapOpenApi("/openapi/{documentName}/openapi.json");
```

It's possible, but not recommended, to remove the `documentName` route parameter from the endpoint route. When the `documentName` route parameter is removed from the endpoint route, the framework attempts to resolve the document name from the query parameter. Not providing the `documentName` in either the route or query can result in unexpected behavior.

### Customize the OpenAPI endpoint

Because the OpenAPI document is served via a route handler endpoint, any customization that is available to standard minimal endpoints is available to the OpenAPI endpoint.

#### Limit OpenAPI document access to authorized users

The OpenAPI endpoint  doesn't enable any authorization checks by default. However, authorization checks can be applied to the OpenAPI document. In the following code, access to the OpenAPI document is limited to those with the `tester` role:

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_mapopenapiwithauth)]

#### Cache generated OpenAPI document

The OpenAPI document is regenerated every time a request to the OpenAPI endpoint is sent. Regeneration enables transformers to incorporate dynamic application state into their operation. For example, regenerating a request with details of the HTTP context. When applicable, the OpenAPI document can be cached to avoid executing the document generation pipeline on each HTTP request.

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_mapopenapiwithcaching)]

<a name="transformers"></a>

## OpenAPI document transformers

This section demonstrates how to customize OpenAPI documents with transformers.

### Customize OpenAPI documents with transformers

Transformers provide an API for modifying the OpenAPI document with user-defined customizations. Transformers are useful for scenarios like:

* Adding parameters to all operations in a document.
* Modifying descriptions for parameters or operations.
* Adding top-level information to the OpenAPI document.

Transformers fall into three categories:

* Document transformers have access to the entire OpenAPI document. These can be used to make global modifications to the document.
* Operation transformers apply to each individual operation. Each individual operation is a combination of path and HTTP method. These can be used to modify parameters or responses on endpoints.
* Schema transformers apply to each schema in the document. These can be used to modify the schema of request or response bodies, or any nested schemas.

Transformers can be registered onto the document by calling the <xref:Microsoft.AspNetCore.OpenApi.OpenApiOptions.AddDocumentTransformer> method on the <xref:Microsoft.AspNetCore.OpenApi.OpenApiOptions> object. The following snippet shows different ways to register transformers onto the document:

* Register a document transformer using a delegate.
* Register a document transformer using an instance of <xref:Microsoft.AspNetCore.OpenApi.IOpenApiDocumentTransformer>.
* Register a document transformer using a DI-activated <xref:Microsoft.AspNetCore.OpenApi.IOpenApiDocumentTransformer>.
* Register an operation transformer using a delegate.
* Register an operation transformer using an instance of <xref:Microsoft.AspNetCore.OpenApi.IOpenApiOperationTransformer>.
* Register an operation transformer using a DI-activated <xref:Microsoft.AspNetCore.OpenApi.IOpenApiOperationTransformer>.
* Register a schema transformer using a delegate.
* Register a schema transformer using an instance of <xref:Microsoft.AspNetCore.OpenApi.IOpenApiSchemaTransformer>.
* Register a schema transformer using a DI-activated <xref:Microsoft.AspNetCore.OpenApi.IOpenApiSchemaTransformer>.

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_transUse&highlight=8-19)]

### Execution order for transformers

Transformers execute in first-in first-out order based on registration. In the following snippet, the document transformer has access to the modifications made by the operation transformer:

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_transInOut&highlight=3-9)]

### Use document transformers

Document transformers have access to a context object that includes:

* The name of the document being modified.
* The <xref:Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescriptionGroupCollectionProvider.ApiDescriptionGroups> associated with that document.
<!-- TODO: replace IServiceProvider on following line and below with xref -->
* The `IServiceProvider` used in document generation.

Document transformers can also mutate the OpenAPI document that is generated. The following example demonstrates a document transformer that adds some information about the API to the OpenAPI document.

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_documenttransformer1)]

Service-activated document transformers can utilize instances from DI to modify the app. The following sample demonstrates a document transformer that uses the <xref:Microsoft.AspNetCore.Authentication.IAuthenticationSchemeProvider> service from the authentication layer. It checks if any JWT bearer-related schemes are registered in the app and adds them to the OpenAPI document's top level:

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_documenttransformer2)]

Document transformers are unique to the document instance they're associated with. In the following example, a transformer:

* Registers authentication-related requirements to the `internal` document.
* Leaves the `public` document unmodified.

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_multidoc_operationtransformer1)]

### Use operation transformers

Operations are unique combinations of HTTP paths and methods in an OpenAPI document. Operation transformers are helpful when a modification:

* Should be made to each endpoint in an app, or
* Conditionally applied to certain routes.

Operation transformers have access to a context object which contains:

* The name of the document the operation belongs to.
* The <xref:Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription> associated with the operation.
* The `IServiceProvider` used in document generation.

For example, the following operation transformer adds `500` as a response status code supported by all operations in the document.

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_operationtransformer1)]

### Use schema transformers

Schemas are the data models that are used in request and response bodies in an OpenAPI document. Schema transformers are useful when a modification:

* Should be made to each schema in the document, or
* Conditionally applied to certain schemas.

Schema transformers have access to a context object which contains:

* The name of the document the schema belongs to.
* The JSON type information associated with the target schema.
* The `IServiceProvider` used in document generation.

For example, the following schema transformer sets the `format` of decimal types to `decimal` instead of `double`:

[!code-csharp[](~/fundamentals/minimal-apis/9.0-samples/WebMinOpenApi/Program.cs?name=snippet_schematransformer1)]

## Additional resources

* <xref:fundamentals/openapi/using-openapi-documents>
* [OpenAPI specification](https://spec.openapis.org/oas/v3.0.3)

::: moniker-end

[!INCLUDE[](~/fundamentals/openapi/includes/aspnetcore-openapi6-8.md)]
