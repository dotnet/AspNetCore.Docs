### C# union types

C# union types are a preview language feature in .NET 11 (see the [C# release notes](/dotnet/csharp/whats-new/csharp-14#union-types)), and [`System.Text.Json`](/dotnet/standard/serialization/system-text-json/overview) serializes them natively. Because ASP.NET Core uses `System.Text.Json` for JSON, union types work as JSON request bodies and return types throughout the stack with no ASP.NET-specific configuration:

* Minimal APIs — union body parameters and return types, including `Task<Union>`, `IAsyncEnumerable<Union>`, and `Results<T1, T2>`, in both the runtime and source-generated request delegates.
* MVC and Razor Pages — union types as `[FromBody]` parameters and action or page-handler return types.
* SignalR — union types as hub method parameters, return values, and stream items when using the JSON hub protocol.
* Blazor — union types as component parameters, JS interop arguments and results, and persisted component state.

```csharp
// Requires <LangVersion>preview</LangVersion>
public record class Dog(string Name);
public record class Cat(int Lives);
public union Pet(Dog, Cat);

// The active case is serialized on the way out and described with anyOf in OpenAPI.
app.MapGet("/pets/{id}", Pet (int id) => id == 0 ? new Dog("Rex") : new Cat(9));
```

For OpenAPI, an endpoint that returns a union is described with an `anyOf` schema listing each case type. Unlike polymorphic types, union cases don't carry a `$type` discriminator, so a case such as `Dog` reuses the standalone `#/components/schemas/Dog` component instead of a duplicated, prefixed one. ApiExplorer detects a union through `JsonTypeInfoKind.Union`, so the schema also flows through to Swashbuckle and NSwag.

A few limits apply. Only JSON request bodies and responses are supported — binding a union from the query string, route values, headers, or form fields isn't yet available. When multiple cases serialize to the same JSON shape, disambiguate them with a `[JsonUnion]` classifier. SignalR unions require the JSON hub protocol; the MessagePack and Newtonsoft.Json protocols don't support unions.