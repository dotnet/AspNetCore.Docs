### Call `ProducesProblem` and `ProducesValidationProblem` on route groups

The `ProducesProblem` and `ProducesValidationProblem` extension methods have been updated to support their use on route groups. These methods indicate that all endpoints in a route group can return `ProblemDetails` or `ValidationProblemDetails` responses for the purposes of OpenAPI metadata.

```csharp
var app = WebApplication.Create();

var todos = app.MapGroup("/todos")
    .ProducesProblem();

todos.MapGet("/", () => new Todo(1, "Create sample app", false));
todos.MapPost("/", (Todo todo) => Results.Ok(todo));

app.Run();

record Todo(int Id, string Title, boolean IsCompleted);
```

### `Problem` and `ValidationProblem` result types support construction with `IEnumerable<KeyValuePair<string, object?>>` values

Prior to .NET 9, constructing [Problem](/dotnet/api/microsoft.aspnetcore.http.typedresults.problem) and [ValidationProblem](/dotnet/api/microsoft.aspnetcore.http.typedresults.validationproblem) result types in minimal APIs required that the `errors` and `extensions` properties be initialized with an implementation of `IDictionary<string, object?>`. In this release, these construction APIs support overloads that consume `IEnumerable<KeyValuePair<string, object?>>`.

:::code language="csharp" source="~/fundamentals/openapi/samples/9.x/ProducesProblem/Program.cs" id="snippet_2" :::

Thanks to GitHub user [joegoldman2](https://github.com/joegoldman2) for this contribution!
