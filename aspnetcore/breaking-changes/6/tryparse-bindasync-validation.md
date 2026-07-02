---
title: "Breaking change: TryParse and BindAsync methods are validated"
description: "Learn about the breaking change in ASP.NET Core 6.0 where `TryParse` and `BindAsync` methods on parameter types for `Map*` methods are validated at startup."
ms.date: 09/22/2021
ms.custom: https://github.com/aspnet/Announcements/issues/472
---
# TryParse and BindAsync methods are validated

ASP.NET Core now validates `TryParse` and `BindAsync` methods on parameter types for `Map*` methods. If no valid method is found, ASP.NET Core looks for invalid methods and throws an exception at startup if one is found. The exception helps to avoid unexpected behavior by alerting you that your method signature may be incorrect.

## Version introduced

ASP.NET Core 6.0 RC 2

## Previous behavior

In previous versions of ASP.NET Core 6, if a  `TryParse` or `BindAsync` method has an invalid signature, no exception was thrown, and the framework tried to bind JSON from the body.

```csharp
// Todo.TryParse is not in a valid format.
// Will try to bind from body as JSON instead.
app.MapPost("/endpoint", (Todo todo) => todo.Item);

public class Todo
{
    public string Item { get; set; }
    public static bool TryParse(string value) => true;
}
```

## New behavior

If ASP.NET Core finds a public `TryParse` or `BindAsync` method that doesn't match the expected syntax, an exception is thrown on startup. The previous example produces an error similar to:

```txt
TryParse method found on Todo with incorrect format. Must be a static method with format
bool TryParse(string, IFormatProvider, out Todo)
bool TryParse(string, out Todo)
but found
Boolean TryParse(System.String)
```

## Type of breaking change

This change can affect [binary compatibility](/dotnet/core/compatibility/categories#binary-compatibility) and [source compatibility](/dotnet/core/compatibility/categories#source-compatibility).

## Reason for change

This change was made so that developers are made aware of `BindAsync` and `TryParse` methods that have an invalid format. Previously, the framework would fall back to assuming the parameter is JSON from the body. This assumption can result in unexpected behavior.

## Recommended action

If your type has a `BindAsync` or `TryParse` method with different syntax for a reason other than parameter binding, you'll now encounter an exception at startup. To avoid this behavior, there are multiple strategies available:

- Change your `BindAsync` or `TryParse` method to be `internal` or `private`.
- Add a new `BindAsync` or `TryParse` method that has the syntax the framework looks for&mdash;invalid methods are ignored if a valid one is found.
- Mark your parameter as `[FromBody]`.

## Affected APIs

- `RequestDelegateFactory.Create()`
- All `IEndpointRouteBuilder.Map*()` methods, for example, `app.MapGet()` and `app.MapPost()`
