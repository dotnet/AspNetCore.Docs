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
JsonSerializer.Serialize<UnionIntString>(new UnionIntString(42));      // 42
JsonSerializer.Serialize<UnionIntString>(new UnionIntString("hello")); // "hello"
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

Selection is O(1) and requires no read-ahead. A union such as `UnionIntString(int, string)` works out of the box because `int` is the only case compatible with `Number` and `string` is the only case compatible with `String`.

### Ambiguous unions require a classifier

When two or more cases map to the same token kind, the first-token rule can't pick a case. These unions are *ambiguous*:

```csharp
public union UnionIntShort(int, short);              // both → Number
public union UnionDateTimeString(DateTime, string);  // both → String
public union UnionPet(Cat, Dog);                     // both → StartObject (records)
```

For ambiguous unions:

* The source generator emits diagnostic `SYSLIB1227` at compile time.
* At runtime, deserializing an ambiguous union without a classifier fails. In Minimal APIs and MVC, this surfaces as an HTTP `400 Bad Request`.

To resolve the ambiguity, attach a custom `JsonTypeClassifier` with the `[JsonUnion]` attribute. The classifier inspects the JSON and returns the case type to bind. Serialization is unaffected by a classifier, because the active case is always known when writing.

```csharp
[JsonUnion(TypeClassifier = typeof(PetClassifier))]
public union UnionPet(Cat, Dog);

public sealed class PetClassifier : JsonTypeClassifierFactory<UnionPet>
{
    public override JsonTypeClassifier CreateJsonClassifier(
        JsonTypeClassifierContext context, JsonSerializerOptions options)
    {
        // The delegate receives a defensive copy of the reader.
        return static (ref Utf8JsonReader reader) =>
        {
            if (reader.TokenType is not JsonTokenType.StartObject)
            {
                return null;
            }

            var clone = reader;
            clone.Read();
            while (clone.TokenType is JsonTokenType.PropertyName)
            {
                if (clone.ValueTextEquals("name") || clone.ValueTextEquals("Name"))
                {
                    return typeof(Cat);
                }
                if (clone.ValueTextEquals("breed") || clone.ValueTextEquals("Breed"))
                {
                    return typeof(Dog);
                }

                clone.Read();
                clone.Skip();
                clone.Read();
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

Unions work as request body parameters and as return types in both the runtime path (`RequestDelegateFactory`) and the source-generated path (Request Delegate Generator). Behavior is identical across both.

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Union as a request body.
app.MapPost("/pet", ([FromBody] UnionPet pet) => TypedResults.Ok(pet));

// Union as a return type — only the active case is serialized.
app.MapGet("/value", () => new UnionIntString(42));      // 42
app.MapGet("/pet", () => new UnionPet(new Cat("Whiskers")));

app.Run();
```

Additional supported scenarios include:

* `Task<TUnion>` and `ValueTask<TUnion>` return types.
* A nullable union wrapper (`TUnion?`) and unions that include a nullable case, such as `union UnionNullableIntString(int?, string)`.
* A union returned through <xref:Microsoft.AspNetCore.Http.TypedResults> or `Results<TResult1, TResult2>` wrappers.
* A union used as a property of another model (an envelope), and `IAsyncEnumerable<TUnion>` streaming, which serializes the active case per item.
* A union body inside an `[AsParameters]` container, where the union binds from the body and sibling properties bind from the route or query.
* `ConfigureHttpJsonOptions` is honored for union serialization and deserialization.

For an unambiguous union, an empty request body and content negotiation behave the same as for any other JSON body parameter: a non-JSON content type returns `415 Unsupported Media Type`.

## MVC controllers and Razor Pages

Unions flow through the STJ input and output formatters, so controllers and Razor Pages support them as action parameters and return types, including `Task<TUnion>` and `ValueTask<TUnion>` results:

```csharp
[ApiController]
[Route("[controller]/[action]")]
[Produces("application/json")]
public class PetsController : ControllerBase
{
    [HttpPost]
    public UnionPet Echo([FromBody] UnionPet value) => value;

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
        yield return new UnionIntString(1);
        yield return new UnionIntString("two");
    }
}
```

On the read path, the parameter, return, or stream-item `Type` resolved from the invocation binder drives the union converter, including any `[JsonUnion]` classifier. On the write path, the active case is serialized with no envelope or discriminator.

Unions are supported only with `JsonHubProtocol`. The MessagePack and Newtonsoft.Json hub protocols don't support unions, because their underlying serializers have no union support.

## OpenAPI

The OpenAPI document represents a union as an [`anyOf`](https://spec.openapis.org/oas/latest#composition-and-inheritance-polymorphism) schema, with one entry per case type:

```json
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

Because a union case has no discriminator and is structurally identical to the standalone type, each case schema reuses the standalone component name, such as `Cat` and `Dog`. This differs from polymorphic types, whose derived schemas are lifted to prefixed component names because they carry a `$type` discriminator.

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

Use unions only as JSON request and response bodies. For non-body parameters, use a concrete type or a discriminated representation that the binding source can parse unambiguously.

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
