### C# union types as JSON request and response bodies

ASP.NET Core supports C# union types, a .NET 11 language feature, as JSON request bodies and response bodies. Support builds on `System.Text.Json` union serialization, so it applies to Minimal APIs, MVC controllers, Razor Pages, and SignalR's `JsonHubProtocol`.

A union value serializes transparently—only the active case is written, with no envelope or `$type` discriminator. On deserialization, `System.Text.Json` selects the case from the first JSON token. Ambiguous unions, whose cases map to the same token kind, require a custom `JsonTypeClassifier` attached with `[JsonUnion]`.

```csharp
public union UnionIntString(int, string);

app.MapPost("/value", (UnionIntString value) => value);
app.MapGet("/value", () => new UnionIntString(42)); // serializes as: 42
```

OpenAPI documents represent a union as an `anyOf` schema with one entry per case type. Unions are supported only where `System.Text.Json` is the serializer, so they aren't supported for query, route, header, or form binding.

For more information, see [Use C# union types in ASP.NET Core](xref:fundamentals/minimal-apis/unions).
<!-- TODO: System.Text.Json union APIs (JsonUnionAttribute, JsonTypeClassifier) are new in .NET 11; update to <xref:> once published to dotnet-api-docs. -->
