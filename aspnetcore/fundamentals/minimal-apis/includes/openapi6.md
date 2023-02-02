:::moniker range="= aspnetcore-6.0"

An app can describe the [OpenAPI specification](https://swagger.io/specification/) for route handlers using [Swashbuckle](https://www.nuget.org/packages/Swashbuckle.AspNetCore/).

The following code is a typical ASP.NET Core app with OpenAPI support:

[!code-csharp[](~/fundamentals/minimal-apis/samples/WebMinAPIs/Program.cs?name=snippet_swag)]

### Exclude OpenAPI description

In the following sample, the `/skipme` endpoint is excluded from generating an OpenAPI description:

[!code-csharp[](~/fundamentals/minimal-apis/samples/WebMinAPIs/Program.cs?name=snippet_swag2)]

### Describe response types

The following example uses the built-in result types to customize the response:

[!code-csharp[](~/fundamentals/minimal-apis/samples/todo/Program.cs?name=snippet_getCustom)]

### Add operation ids to OpenAPI

[!code-csharp[](~/fundamentals/minimal-apis/samples/todo/Program.cs?name=snippet_name)]

### Add tags to the OpenAPI description

The following code uses an [OpenAPI grouping tag](https://swagger.io/docs/specification/grouping-operations-with-tags/):

[!code-csharp[](~/fundamentals/minimal-apis/samples/todo/Program.cs?name=snippet_grp)]

:::moniker-end
