---
title: ASP.NET Core Blazor JavaScript interoperability (JS interop) performance best practices
author: guardrex
description: Tips for improving JS interop performance in ASP.NET Core Blazor apps and avoiding common performance problems.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 04/16/2025
uid: blazor/performance/js-interop
---
# ASP.NET Core Blazor JavaScript interoperability (JS interop) performance best practices

[!INCLUDE[](~/includes/not-latest-version.md)]

Calls between .NET and JavaScript require additional overhead because:

* Calls are asynchronous.
* Parameters and return values are JSON-serialized to provide an easy-to-understand conversion mechanism between .NET and JavaScript types.

Additionally for server-side Blazor apps, these calls are passed across the network.

## Avoid excessively fine-grained calls

Since each call involves some overhead, it can be valuable to reduce the number of calls. Consider the following code, which stores a collection of items in the browser's [`localStorage`](https://developer.mozilla.org/docs/Web/API/Window/localStorage):

```csharp
private async Task StoreAllInLocalStorage(IEnumerable<TodoItem> items)
{
    foreach (var item in items)
    {
        await JS.InvokeVoidAsync("localStorage.setItem", item.Id, 
            JsonSerializer.Serialize(item));
    }
}
```

The preceding example makes a separate JS interop call for each item. Instead, the following approach reduces the JS interop to a single call:

```csharp
private async Task StoreAllInLocalStorage(IEnumerable<TodoItem> items)
{
    await JS.InvokeVoidAsync("storeAllInLocalStorage", items);
}
```

The corresponding JavaScript function stores the whole collection of items on the client:

```javascript
function storeAllInLocalStorage(items) {
  items.forEach(item => {
    localStorage.setItem(item.id, JSON.stringify(item));
  });
}
```

For Blazor WebAssembly apps, rolling individual JS interop calls into a single call usually only improves performance significantly if the component makes a large number of JS interop calls.

## Consider the use of synchronous calls

:::moniker range=">= aspnetcore-5.0"

### Call JavaScript from .NET

[!INCLUDE[](~/blazor/includes/js-interop/synchronous-js-interop-call-js.md)]

### Call .NET from JavaScript

[!INCLUDE[](~/blazor/includes/js-interop/synchronous-js-interop-call-dotnet.md)]

:::moniker-end

:::moniker range="< aspnetcore-5.0"

[!INCLUDE[](~/blazor/includes/js-interop/synchronous-js-interop-call-js.md)]

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-7.0"

## Consider the use of unmarshalled calls

*This section only applies to Blazor WebAssembly apps.*

When running on Blazor WebAssembly, it's possible to make unmarshalled calls from .NET to JavaScript. These are synchronous calls that don't perform JSON serialization of arguments or return values. All aspects of memory management and translations between .NET and JavaScript representations are left up to the developer.

> [!WARNING]
> While using <xref:Microsoft.JSInterop.IJSUnmarshalledRuntime> has the least overhead of the JS interop approaches, the JavaScript APIs required to interact with these APIs are currently undocumented and subject to breaking changes in future releases.

```javascript
function jsInteropCall() {
  return BINDING.js_to_mono_obj("Hello world");
}
```

```razor
@inject IJSRuntime JS

@code {
    protected override void OnInitialized()
    {
        var unmarshalledJs = (IJSUnmarshalledRuntime)JS;
        var value = unmarshalledJs.InvokeUnmarshalled<string>("jsInteropCall");
    }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

## Use JavaScript `[JSImport]`/`[JSExport]` interop

JavaScript `[JSImport]`/`[JSExport]` interop for Blazor WebAssembly apps offers improved performance and stability over the JS interop API in framework releases prior to ASP.NET Core in .NET 7.

For more information, see <xref:blazor/js-interop/import-export-interop>.

:::moniker-end
