### C# union types

ASP.NET Core supports [C# union types](/dotnet/csharp/whats-new/csharp-14#union-types) ([C# language reference](/dotnet/csharp/language-reference/builtin-types/union)), which are new in .NET 11, anywhere [`System.Text.Json`](/dotnet/standard/serialization/system-text-json/overview) is used: JSON request and response bodies in Minimal APIs and MVC, SignalR's `JsonHubProtocol`, Blazor JavaScript interop, persistent component state, and prerendered component parameters.

```csharp
public union UnionIntString(int, string);

app.MapGet("/value", () => new UnionIntString(42));
```

Union types aren't supported for non-body binding sources such as route values, query strings, headers, and form fields.