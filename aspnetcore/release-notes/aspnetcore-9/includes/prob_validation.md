## Support calling `ProducesProblem` and `ProducesValidationProblem` on route groups

The `ProducesProblem` and `ProducesValidationProblem` extension methods have been updated to support application on route groups, as in the sample below. These methods can be used to indicate that all endpoints in a route group can return `ProblemDetails` or `ValidationProblemDetails` responses for the purposes of OpenAPI metadata.

:::code language="csharp" source="~/fundamentals/openapi/samples/9.x/ProducesProblem/Program.cs" id="snippet_1" :::

## `Problem` and `ValidationProblem` result types support construction with `IEnumerable<KeyValuePair<string, object?>>` values

Prior to this preview, constructing `Problem` and `ValidationProblem` result types in minimal APIs required that the `errors` and `extensions` properties be initialized with an implementation of `IDictionary<string, object?>`. Starting in this release, these construction APIs support overloads that consume `IEnumerable<KeyValuePair<string, object?>>`.

:::code language="csharp" source="~/fundamentals/openapi/samples/9.x/ProducesProblem/Program.cs" id="snippet_2" :::

Thanks to GitHub user "joegoldman2" for this contribution!