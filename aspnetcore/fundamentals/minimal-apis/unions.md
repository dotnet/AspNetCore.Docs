---
title: Use C# union types in ASP.NET Core
author: DeagleGross
description: Learn how C# union types are supported as JSON request and response bodies in ASP.NET Core Minimal APIs, MVC, SignalR, and OpenAPI.
monikerRange: '>= aspnetcore-11.0'
ms.author: wpickett
ms.date: 06/17/2026
uid: fundamentals/minimal-apis/unions
ai-usage: ai-assisted
---
# Use C# union types in ASP.NET Core

C# union types, introduced as a language feature in .NET 11, let a single type represent a value that's exactly one of a fixed set of case types. Unions are a frequently requested feature for modeling APIs that accept or return one of several shapes, such as a success payload or an error payload. This article explains where ASP.NET Core supports unions, how they're serialized, and the cases that require extra configuration.

ASP.NET Core support for unions builds entirely on union support in [`System.Text.Json`](/dotnet/standard/serialization/system-text-json/overview) (STJ). As a result, unions are supported only where STJ is the serializer: the **JSON request body** (input) and the **JSON response body** (output). Unions aren't supported for non-body binding sources, such as query strings, route values, headers, and form fields. For more information, see [Where unions aren't supported](#where-unions-arent-supported).

## How unions are serialized

A union type is declared with the `union` keyword and a list of case types:

```csharp
public union UnionIntString(int, string);

public record Cat(string Name);
public record Dog(string Breed);
public union UnionPet(Cat, Dog);
```

STJ serializes a union value *transparently*. The union wrapper is unpacked and only the active case is written, using that case's own JSON contract. There's no envelope object, no `$type` field, and no discriminator of any kind:

```csharp
JsonSerializer.Serialize(new UnionIntString(42));      // 42
JsonSerializer.Serialize(new UnionIntString("hello")); // "hello"
```

This is a deliberate difference from polymorphic serialization with <xref:System.Text.Json.Serialization.JsonPolymorphicAttribute>, which writes a `$type` discriminator. Unions have no natural discriminator, so none is emitted. For more information, see [Unions compared to polymorphism](#unions-compared-to-polymorphism).

### Deserialization uses the first JSON token

Because there's no discriminator on the wire, STJ recovers the case type from the JSON value itself by inspecting the *first token* and selecting the single case whose declared type is compatible with that token kind. The mapping is fixed:

| <xref:System.Text.Json.JsonTokenType> | Compatible case types |
| --- | --- |
| `Number` | Numeric primitives, such as `int`, `long`, `double`, and `decimal` |
| `String` | `string`, `DateTime`, `DateTimeOffset`, `Guid`, `TimeSpan`, `Uri`, `char`, `byte[]`, and enums |
| `True` / `False` | `bool` |
| `StartObject` | Objects and dictionaries |
| `StartArray` | Arrays and collections |
| `Null` | `null` |

Selection is O(1) and requires no read-ahead. A union whose cases map to distinct token kinds, such as `UnionBoolString(bool, string)`, deserializes without any extra configuration.

> [!IMPORTANT]
> Minimal APIs and MVC serialize and deserialize HTTP JSON using web defaults (<xref:System.Text.Json.JsonSerializerDefaults>.Web), which enable `JsonNumberHandling.AllowReadingFromString`. This lets a numeric case be read from a JSON `String` token, so the `String` token becomes compatible with *both* numeric cases and `string`. As a result, a union that pairs a numeric case with a `string` case—such as `UnionIntString(int, string)`—is ambiguous on the `String` token for HTTP JSON binding. A `Number` payload binds to the numeric case, but a `String` payload returns `400 Bad Request` unless the union supplies a classifier. This differs from plain `System.Text.Json` and from SignalR's `JsonHubProtocol`, which deserialize the same union without a classifier.

### Ambiguous unions require a classifier

A union is ambiguous when more than one case can match the same JSON payload. Ambiguity arises in two ways:

* **Cases that share a JSON token kind.** The source generator reports these at compile time with diagnostic `SYSLIB1227`:

  ```csharp
  public union UnionIntShort(int, short);              // both → Number
  public union UnionDateTimeString(DateTime, string);  // both → String
  public union UnionPet(Cat, Dog);                     // both → StartObject (records)
  ```

* **A numeric case paired with a `string` case in Minimal APIs or MVC**, such as `UnionIntString(int, string)`. There's no compile-time diagnostic, but a JSON `String` payload is ambiguous at runtime under web defaults, as described in the preceding note.

When deserialization of an ambiguous union fails, Minimal APIs and MVC return `400 Bad Request`.

To resolve the ambiguity, attach a custom `JsonTypeClassifier` with the `[JsonUnion]` attribute. The classifier inspects the JSON and returns the case type to bind. Serialization is unaffected by a classifier, because the active case is always known when writing.

```csharp
[JsonUnion(TypeClassifier = typeof(PetClassifier))]
public union UnionPet(Cat, Dog);

public sealed class PetClassifier : JsonTypeClassifierFactory<UnionPet>
{
    public override JsonTypeClassifier CreateJsonClassifier(
        JsonTypeClassifierContext context, JsonSerializerOptions options)
    {
        // The delegate receives a defensive copy of the reader, so advancing it
        // here doesn't affect the reader used for deserialization.
        return static (ref Utf8JsonReader reader) =>
        {
            if (reader.TokenType is not JsonTokenType.StartObject)
            {
                return null;
            }

            while (reader.Read() && reader.TokenType is JsonTokenType.PropertyName)
            {
                if (reader.ValueTextEquals("name") || reader.ValueTextEquals("Name"))
                {
                    return typeof(Cat);
                }
                if (reader.ValueTextEquals("breed") || reader.ValueTextEquals("Breed"))
                {
                    return typeof(Dog);
                }

                reader.Read(); // Move to the property value.
                reader.Skip(); // Skip the value.
            }

            return null; // No case identified; deserialization fails.
        };
    }
}
```

> [!NOTE]
> `JsonUnionAttribute`, `JsonTypeClassifier`, and `JsonTypeClassifierFactory<T>` are new `System.Text.Json` APIs in .NET 11. A classifier can also be registered for multiple union types through <xref:System.Text.Json.JsonSerializerOptions>.
<!-- TODO: Add <xref:> links for the .NET 11 System.Text.Json union APIs (JsonUnionAttribute, JsonTypeClassifier, JsonTypeClassifierFactory<T>) once published to dotnet-api-docs. -->

## Minimal APIs

Unions work as request body parameters and as return types in both the runtime path (`RequestDelegateFactory`) and the source-generated [Request Delegate Generator (RDG)](xref:fundamentals/aot/rdg). Behavior is identical across both.

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Request body: UnionBoolString is unambiguous (bool vs string),
// so it binds without a classifier.
app.MapPost("/flag", (UnionBoolString flag) => flag);

// Request body: UnionPet is object-cased, so it needs the classifier
// shown earlier to bind from a body.
app.MapPost("/pet", ([FromBody] UnionPet pet) => TypedResults.Ok(pet));

// Return types: only the active case is serialized, and no classifier
// is needed to write.
app.MapGet("/value", () => new UnionIntString(42));      // 42
app.MapGet("/pet", () => new UnionPet(new Cat("Whiskers")));

app.Run();
```

Unions compose with the usual Minimal API return types. For example, a union can be returned asynchronously, wrapped in a nullable, or handed back through <xref:Microsoft.AspNetCore.Http.TypedResults>:

```csharp
app.MapGet("/maybe", () => new UnionNullableIntString(null));                  // null
app.MapGet("/typed", () => TypedResults.Ok(new UnionPet(new Cat("Whiskers"))));
```

A union can also be a property of another model, an item streamed from an `IAsyncEnumerable<T>`, or the body slot of an `[AsParameters]` container. Union serialization also respects options configured through `ConfigureHttpJsonOptions`.

## MVC controllers

Unions flow through the STJ input and output formatters, so controllers support them as action parameters and return types, including `Task<TUnion>` and `ValueTask<TUnion>` results:

```csharp
[ApiController]
[Route("[controller]/[action]")]
[Produces("application/json")]
public class PetsController : ControllerBase
{
    [HttpPost]
    public UnionBoolString Echo([FromBody] UnionBoolString value) => value;

    [HttpGet("{kind}")]
    public UnionIntString Primitive(string kind) => kind switch
    {
        "value" => new UnionIntString(42),
        "string" => new UnionIntString("hi"),
        _ => default,
    };
}
```

The same serialization rules apply: only the active case is written, and ambiguous unions need a classifier to deserialize.

## SignalR

`JsonHubProtocol` forwards reads and writes to `System.Text.Json`, so unions work as hub method parameters, return values, and stream items without any extra configuration:

```csharp
public class ChatHub : Hub
{
    // Union argument (client → server).
    public Task Send(UnionIntString message) => Clients.All.SendAsync("Receive", message);

    // Union return value (server → client).
    public UnionPet GetPet() => new UnionPet(new Cat("Whiskers"));

    // Union stream items (server → client).
    public async IAsyncEnumerable<UnionIntString> Stream()
    {
        yield return 1;
        yield return "two";
    }
}
```

On the read path, the parameter, return, or stream-item `Type` resolved from the invocation binder drives the union converter, including any `[JsonUnion]` classifier. On the write path, the active case is serialized with no envelope or discriminator.

Unlike HTTP JSON binding in Minimal APIs and MVC, `JsonHubProtocol` doesn't treat a JSON `String` token as ambiguous for numeric cases, so a union such as `UnionIntString(int, string)` round-trips both the `int` and `string` cases without a classifier. Object-cased unions, such as `UnionPet(Cat, Dog)`, are still ambiguous on read and require a classifier.

Unions are supported only with `JsonHubProtocol`. The MessagePack and Newtonsoft.Json hub protocols don't support unions, because their underlying serializers have no union support.

## OpenAPI

The OpenAPI document represents a union as an [`anyOf`](https://spec.openapis.org/oas/latest#composition-and-inheritance-polymorphism) schema, with one entry per case type:

```json
"Cat": {
  "type": "object",
  "properties": {
    "name": { "type": "string" }
  }
},
"Dog": {
  "type": "object",
  "properties": {
    "breed": { "type": "string" }
  }
},
"UnionIntString": {
  "anyOf": [
    { "type": "integer", "format": "int32" },
    { "type": "string" }
  ]
},
"UnionPet": {
  "type": "object",
  "anyOf": [
    { "$ref": "#/components/schemas/Cat" },
    { "$ref": "#/components/schemas/Dog" }
  ]
}
```

Because a union case has no discriminator and is structurally identical to the standalone type, each case schema reuses the standalone component name. The `Cat` and `Dog` schemas referenced by `UnionPet` are the same components that a standalone `Cat` or `Dog` endpoint produces. This differs from polymorphic types, whose derived schemas are lifted to prefixed component names because they carry a `$type` discriminator.

An endpoint can also produce multiple response types for the same status code and content type. <xref:Microsoft.AspNetCore.Mvc.ApiExplorer> preserves every declared response type, and the generated document emits an `anyOf` schema when several types share a content type:

```csharp
app.MapGet("/any-of", () => Results.Ok())
    .Produces<UnionPet>(StatusCodes.Status200OK, "application/json")
    .Produces<Clinic>(StatusCodes.Status200OK, "application/json");
```

The same support applies to MVC controllers that declare multiple <xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute> attributes for one status code and content type.

## Where unions aren't supported

Union support requires `System.Text.Json`. Binding sources that *don't* route through STJ don't support unions:

* Query string values
* Route values
* Header values
* Form fields

These sources bind a string token to a target type without JSON parsing, so there's no reliable way to choose a union case. Even for STJ, most ambiguous unions require a custom classifier, and a single query value such as `?id=42` provides no way to know whether to bind `int`, `string`, `Guid`, or another case. Because of this ambiguity, unions are intentionally not supported in these binding sources.

Parameter binding for unions from non-body sources is still being explored. If you have a scenario that needs it, the team is gathering feedback on the [union parameter binding issue](https://github.com/dotnet/aspnetcore/issues/66648).

## Unions compared to polymorphism

Unions and `[JsonPolymorphic]` hierarchies solve related but distinct problems:

* **Polymorphism** writes a `$type` discriminator on the wire and matches incoming JSON by that discriminator. Use it when the JSON is self-describing and you want a tagged representation.
* **Unions** write no discriminator and match incoming JSON structurally by the first token, or through a custom classifier. Use them to model a closed set of case types without changing the wire format.

A union case type can itself be polymorphic. When a derived instance of a `[JsonPolymorphic]` case is returned, the polymorphic contract still emits its `$type` discriminator for that case's payload.

## Additional resources

* [JSON serialization and deserialization in .NET](/dotnet/standard/serialization/system-text-json/overview)
* [How to serialize polymorphic types with System.Text.Json](/dotnet/standard/serialization/system-text-json/polymorphism)
* <xref:fundamentals/minimal-apis/parameter-binding>
* <xref:fundamentals/minimal-apis/responses>
