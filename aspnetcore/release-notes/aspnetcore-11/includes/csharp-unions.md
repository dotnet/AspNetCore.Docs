### C# union types

ASP.NET Core supports [C# union types](/dotnet/csharp/whats-new/csharp-15#union-types) ([C# language reference](/dotnet/csharp/language-reference/builtin-types/union)), which are new in .NET 11, anywhere [`System.Text.Json`](/dotnet/standard/serialization/system-text-json/overview) is used: JSON request and response bodies in Minimal APIs and MVC, SignalR's `JsonHubProtocol`, Blazor JavaScript interop, persistent component state, and prerendered component parameters.

```csharp
public union UnionIntString(int, string);

app.MapGet("/value", () => new UnionIntString(42));
```

Union types aren't supported for non-body binding sources such as route values, query strings, headers, and form fields.

For OpenAPI, an endpoint that returns a union is described with an `anyOf` schema listing each case type. Unlike polymorphic types, union cases don't carry a `$type` discriminator, so each case reuses its standalone component (for example, `#/components/schemas/Dog`) instead of a duplicated, prefixed one. ApiExplorer detects a union through `JsonTypeInfoKind.Union`, so the schema also flows through to Swashbuckle and NSwag. When multiple cases serialize to the same JSON shape, disambiguate them with a `[JsonUnion]` classifier. SignalR unions require the JSON hub protocol; the MessagePack and `Newtonsoft.Json` protocols don't support unions.

For examples and additional information that apply to Blazor apps, see the [Component parameters section in the Components overview article](xref:blazor/components/index#component-parameters) and the [Pass parameters section of the Dynamically-rendered ASP.NET Core Razor components article](xref:blazor/components/dynamiccomponent).
