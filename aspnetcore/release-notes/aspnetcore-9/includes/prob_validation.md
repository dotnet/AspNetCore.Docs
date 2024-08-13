### Support calling `ProducesProblem` and `ProducesValidationProblem` on route groups

The [ProducesProblem](/dotnet/api/microsoft.aspnetcore.http.openapiroutehandlerbuilderextensions.producesproblem) and [ProducesValidationProblem](/dotnet/api/microsoft.aspnetcore.http.openapiroutehandlerbuilderextensions.producesvalidationproblem) extension methods have been updated for route groups. These methods can be used to indicate that all endpoints in a route group can return `ProblemDetails` or `ValidationProblemDetails` responses for the purposes of OpenAPI metadata.

:::code language="csharp" source="~/fundamentals/openapi/samples/9.x/ProducesProblem/Program.cs" id="snippet_1" :::

### `Problem` and `ValidationProblem` result types support construction with `IEnumerable<KeyValuePair<string, object?>>` values

Prior to .NET 9, constructing [Problem](/dotnet/api/microsoft.aspnetcore.http.typedresults.problem) and [ValidationProblem](/dotnet/api/microsoft.aspnetcore.http.typedresults.validationproblem) result types in minimal APIs required that the `errors` and `extensions` properties be initialized with an implementation of `IDictionary<string, object?>`. In this release, these construction APIs support overloads that consume `IEnumerable<KeyValuePair<string, object?>>`.

:::code language="csharp" source="~/fundamentals/openapi/samples/9.x/ProducesProblem/Program.cs" id="snippet_2" :::

Thanks to GitHub user [joegoldman2](https://github.com/joegoldman2) for this contribution!
