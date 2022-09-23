---
title: .NET JavaScript `[JSImport]`/`[JSExport]` interop with ASP.NET Core Blazor WebAssembly
author: guardrex
description: Learn how to interact with JavaScript in Blazor WebAssembly apps using .NET JavaScript `[JSImport]`/`[JSExport]` interop.
monikerRange: '= aspnetcore-7.0'
ms.author: riande
ms.custom: mvc
ms.date: 09/23/2022
uid: blazor/js-interop/import-export-interop
---
# .NET JavaScript `[JSImport]`/`[JSExport]` interop with ASP.NET Core Blazor

This article explains how to interact with JavaScript (JS) in Blazor WebAssembly apps using .NET JS `[JSImport]`/`[JSExport]` interop API released with .NET 7.

Blazor provides its own JS interop mechanism based on the <xref:Microsoft.JSInterop.IJSRuntime> interface, which is uniformly supported across Blazor hosting models and described in the following articles:

* <xref:blazor/js-interop/call-javascript-from-dotnet>
* <xref:blazor/js-interop/call-dotnet-from-javascript>

<xref:Microsoft.JSInterop.IJSRuntime> enables library authors to build JS interop libraries that can be shared across the Blazor ecosystem and remains the recommend approach for JS interop in Blazor. However, this article describes an alternative JS interop approach available for the first time with the release of .NET 7. The approaches described in this article should be used to replace the obsolete unmarshalled JS interop API of prior Blazor framework releases.

## Obsolete JavaScript interop API

Unmarshalled JS interop using <xref:Microsoft.JSInterop.IJSUnmarshalledRuntime> API is obsolete in ASP.NET Core 7.0. Follow the guidance in this article to replace the obsolete API.

## Prerequisites

[!INCLUDE[](~/includes/7.0-SDK.md)]

## Call JavaScript from .NET

This section explains how to call JS functions from .NET.

> [!NOTE]
> Add the <xref:Microsoft.Build.Tasks.Csc.AllowUnsafeBlocks> property to the app's project file. Setting this property to `true` permits the code generator in the Roslyn compiler to use pointers and isn't a security concern.

To import a JS function to call it from C#, use the `[JSImport]` attribute on a C# method signature that matches the JS function's signature. The first parameter to the `[JSImport]` attribute is the name of the JS function to import, and the second parameter is the name of the [JS module](xref:blazor/js-interop/index#javascript-isolation-in-javascript-modules).

In the following example, `getMessage` is a JS function that returns a `string` for a module named `Interop`. The C# method signature matches: No parameters are passed to the JS function, and the JS function returns a `string`. The JS function is called in C# using standard syntax, `Interop.GetWelcomeMessage()`.

`Interop.cs`:

```csharp
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

[SupportedOSPlatform("browser")]
public partial class Interop
{
    [JSImport("getMessage", "Interop")]
    internal static partial string GetWelcomeMessage();
}
```

In the imported method signature, you can use .NET types for parameters and return values, which are marshalled automatically by the runtime. Use `JSMarshalAsAttribute<T>` to control how the imported method parameters are marshalled. For example, you might choose to marshal a `long` as <xref:System.Runtime.InteropServices.JavaScript.JSType.Number?displayProperty=nameWithType> or <xref:System.Runtime.InteropServices.JavaScript.JSType.BigInt?displayProperty=nameWithType>. You can pass <xref:System.Action>/<xref:System.Func%601> callbacks as parameters, which are marshalled as callable JS functions. You can pass both JS and managed object references, and they are marshaled as proxy objects, keeping the object alive across the boundary until the proxy is garbage collected. You can also import and export asynchronous methods with a <xref:System.Threading.Tasks.Task> result, which are marshaled as [JS promises](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise). Most of the marshalled types work in both directions, as parameters and as return values, on both imported and exported methods. Exported methods are covered in the [Call .NET from JavaScript](#call-net-from-javascript) section.

The module name in the `[JSImport]` attribute and the call to load the module in the component, which is covered next with `JSHost.ImportAsync` syntax, should match. The module name must also be unique in the app. When authoring a library for deployment in a NuGet package, we recommend using the NuGet package namespace as a prefix in module names. In the following example, the module name reflects the `Contoso.InteropServices.JavaScript` package:

```csharp
[JSImport("getMessage", "Contoso.InteropServices.JavaScript.Interop")]
```

If the JS function doesn't directly interact with the rendered Document Object Model (DOM), import the module in [`OnInitializedAsync`](xref:blazor/components/lifecycle#component-initialization-oninitializedasync). Call the imported JS function with the .NET interop method.

In the following `CallJavaScript` component:

* The `Interop` module is imported asychronously from the [collocated JS file](xref:blazor/js-interop/index#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component).
* The imported `getMessage` JS function is called with `Interop.GetWelcomeMessage()`.
* The returned welcome string is displayed in the UI via the `message` field.

`Pages/CallJavaScript.razor`:

```razor
@page "/call-javascript"
@using System.Runtime.InteropServices.JavaScript

<h1>.NET JS <code>[JSImport]</code>/<code>[JSExport]</code> interop (Call JS)</h1>

@(message is not null ? message : string.Empty)

@code {
    private string? message;

    protected override async Task OnInitializedAsync()
    {
        if (OperatingSystem.IsBrowser())
        {
            await JSHost.ImportAsync("Interop", "../Pages/CallJavaScript.razor.js");

            message = Interop.GetWelcomeMessage();
        }
    }
}
```

> [!NOTE]
> The conditional check for <xref:System.OperatingSystem.IsBrowser%2A?displayProperty=nameWithType> in the preceding example ensures that the code is only called in Blazor WebAssembly apps running on the client. This is important for library code deployed as NuGet packages that might be referenced by developers of Blazor Server apps, where the preceding code can't execute. If you know for sure that the code is only implemented in Blazor WebAssembly apps, you can remove the check for <xref:System.OperatingSystem.IsBrowser%2A?displayProperty=nameWithType>.

If the JS module interacts directly with the component's rendered UI, import the module in [`OnAfterRenderAsync`](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync) and call the imported JS function:

```csharp
protected override async Task OnAfterRenderAsync(bool firstRender)
{
    if (OperatingSystem.IsBrowser() && firstRender)
    {
        await JSHost.ImportAsync("Interop", "../Pages/CallJavaScript.razor.js");

        Interop.DoSomething();
    }
}
```

If the code holds a reference to the <xref:System.Runtime.InteropServices.JavaScript.JSObject> returned by `JSHost.ImportAsync`, be sure to call <xref:System.Runtime.InteropServices.JavaScript.JSObject.Dispose%2A?displayProperty=nameWithType> when the component is disposed:

```razor
...
@implements IDisposable

...

@code {
    private JSObject? module;

    ...

    module = await JSHost.ImportAsync("Interop", "../Pages/CallJavaScript.razor.js");

    ...

    public void Dispose() => module?.Dispose();
}
```

Export scripts from a standard [JavaScript ES6 module](xref:blazor/js-interop/index#javascript-isolation-in-javascript-modules) collocated with a component, which is covered in the <xref:blazor/js-interop/index#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component> article or placed with other JavaScript static assets.

In the following example, a JS function named `getMessage` is exported from a collocated JS file that returns a welcome message string, "Hello from Blazor!" in Portuguese:

`Pages/CallJavaScript.razor.js`:

```javascript
export function getMessage() {
  return 'Olá do Blazor!';
}
```

## Call .NET from JavaScript

This section explains how to call .NET methods from JS.

> [!NOTE]
> Add the <xref:Microsoft.Build.Tasks.Csc.AllowUnsafeBlocks> property to the app's project file. Setting this property to `true` permits the code generator in the Roslyn compiler to use pointers and isn't a security concern.

To export a .NET method so that it can be called from JS, use the `[JSExport]` attribute.

In the following example:

* `DotNetInteropCall` is a .NET method with the `[JSExport]` attribute that returns a welcome message string, "Hello from Blazor!" in Portuguese.
* `SetWelcomeMessage` calls a JS function named `setmessage`. The JS function calls into .NET to receive the welcome string from `DotNetInteropCall` and displays the welcome string in the UI.

`Interop.cs`:

```csharp
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

[SupportedOSPlatform("browser")]
public partial class Interop
{
    [JSExport]
    internal static string DotNetInteropCall()
    {
        return "Olá do Blazor!";
    }

    [JSImport("setMessage", "Interop2")]
    internal static partial void SetWelcomeMessage();
}
```

The following `CallDotNet` component calls JS that directly interacts with the DOM to render the welcome message:

* The `Interop2` [JS module](xref:blazor/js-interop/index#javascript-isolation-in-javascript-modules) is imported asychronously from the collocated JS file for this component.
* The imported `setMessage` JS function is called with `Interop.SetWelcomeMessage()`.
* The returned welcome string is displayed by `setMessage` in the UI via the `message` field.

> [!IMPORTANT]
> In this section's example, JS interop is used to mutate a DOM element *purely for demonstration purposes* after the component is rendered in [`OnAfterRenderAsync`](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync). Typically, you should only mutate the DOM with JS when the object doesn't interact with Blazor. The approach shown in this section is similar to cases where a third-party JS library is used in a Razor component, where the component interacts with the JS library via JS interop, the third-party JS library interacts with part of the DOM, and Blazor isn't involved directly with the DOM updates to that part of the DOM. For more information, see <xref:blazor/js-interop/index#interaction-with-the-document-object-model-dom>.

```razor
@page "/call-dotnet"
@using System.Runtime.InteropServices.JavaScript

<h1>.NET JS <code>[JSImport]</code>/<code>[JSExport]</code> (Call .NET)</h1>

<p>
    <span id="result">.NET method not executed yet</span>
</p>

@code {
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (OperatingSystem.IsBrowser() && firstRender)
        {
            await JSHost.ImportAsync("Interop2", "../Pages/CallDotNet.razor.js");

            Interop.SetWelcomeMessage();
        }
    }  
}
```

> [!NOTE]
> As demonstrated in the [Call JavaScript from .NET](#call-javascript-from-net) section, call <xref:System.Runtime.InteropServices.JavaScript.JSObject.Dispose%2A?displayProperty=nameWithType> in a `Dispose` method if the component holds a reference to the <xref:System.Runtime.InteropServices.JavaScript.JSObject> returned by `JSHost.ImportAsync`.

> [!NOTE]
> The conditional check for <xref:System.OperatingSystem.IsBrowser%2A?displayProperty=nameWithType> in the preceding example ensures that the code is only called in Blazor WebAssembly apps running on the client. This is important for library code deployed as NuGet packages that might be referenced by developers of Blazor Server apps, where the preceding code can't execute. If you know for sure that the code is only implemented in Blazor WebAssembly apps, you can remove the check for <xref:System.OperatingSystem.IsBrowser%2A?displayProperty=nameWithType>.

In the following example, a JS function named `setMessage` is exported from a collocated JS file.

The `setMessage` method:

* Calls `globalThis.getDotnetRuntime(0)` to expose the WebAssembly .NET runtime instance for calling exported .NET methods.
* Obtains the app assembly's JS exports. The name of the app's assembly in the following example is `BlazorSample`.
* Calls the `Interop.DotNetInteropCall()` method from the exports (`exports`). The returned value, which is the welcome string, is assigned to the preceding `<span>`'s inner text.

```javascript
export async function setMessage() {
  const { getAssemblyExports } = await globalThis.getDotnetRuntime(0);
  var exports = await getAssemblyExports("BlazorSample.dll");

  document.getElementById("result").innerText = 
    exports.Interop.DotNetInteropCall();
}
```

## Additional example

For an additional example of the JS interop techniques described in this article, see the *Blazor WASM demo of new JSInterop* sample app:

* [Reference source (`pavelsavara/blazor-wasm-hands-pose` GitHub repository)](https://github.com/pavelsavara/blazor-wasm-hands-pose)
* [Live demonstration](https://pavelsavara.github.io/blazor-wasm-hands-pose/)

> [!NOTE]
> The [`pavelsavara/blazor-wasm-hands-pose` GitHub repository](https://github.com/SteveSandersonMS/BlazorOnGitHubPages) isn't owned, maintained, or supported by the .NET foundation or Microsoft.
>
> The *Blazor WASM demo of new JSInterop* sample app uses a public JS library from [MediaPipe](https://www.mediapipe.dev/), which isn't owned, maintained, or supported by the .NET foundation or Microsoft.
