---
title: "Breaking change: Blazor: Byte Array Interop"
description: "Learn about the breaking change in ASP.NET Core 6.0 titled Blazor: Byte Array Interop"
no-loc: [ Blazor ]
ms.date: 06/21/2021
ms.custom: https://github.com/dotnet/Announcements/issues/187
---
# Blazor: Byte-array interop

Blazor now supports optimized byte-array interop, which avoids encoding and decoding byte-arrays into Base64 and facilitates a more efficient interop process. This applies to both Blazor Server and Blazor WebAssembly.

## Version introduced

ASP.NET Core 6.0

## Receive byte array in JavaScript from .NET

### Old behavior

```typescript
function receivesByteArray(data) {
    // Previously, data was a Base64-encoded string representing the byte array.
}
```

### New behavior

```typescript
function receivesByteArray(data) {
    // Data is a Uint8Array (no longer requires processing the Base64 encoding).
}
```

## Reason for change

This change was made to create a more efficient interop mechanism for byte arrays.

## Recommended action

### Receive byte array in JavaScript from .NET

Consider this .NET interop, where you call into JavaScript passing a byte array:

```csharp
var bytes = new byte[] { 1, 5, 7 };
await _jsRuntime.InvokeVoidAsync("receivesByteArray", bytes);
```

In the preceding code example, you'd treat the incoming parameter in JavaScript as a byte array instead of a Base64-encoded string.

### Return byte array from JavaScript to .NET

If .NET expects a `byte[]`, JavaScript _should_ provide a `Uint8Array`. It's still possible to provide a Base64-encoded array using `btoa`, however that is less performant.

For example, if you have the following code, then you _should_ provide a `Uint8Array` from JavaScript that's _not_ Base64-encoded:

```csharp
var bytes = await _jsRuntime.InvokeAsync<byte[]>("someJSMethodReturningAByteArray");
```

<!--

## Category

ASP.NET Core

## Affected APIs

Not detectable via API analysis

-->
