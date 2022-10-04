---
title: .NET JavaScript `[JSImport]`/`[JSExport]` interop with ASP.NET Core Blazor WebAssembly
author: guardrex
description: Learn how to interact with JavaScript in Blazor WebAssembly apps using .NET JavaScript `[JSImport]`/`[JSExport]` interop.
monikerRange: '= aspnetcore-7.0'
ms.author: riande
ms.custom: mvc
ms.date: 09/28/2022
uid: blazor/js-interop/import-export-interop
---
# .NET JavaScript `[JSImport]`/`[JSExport]` interop with ASP.NET Core Blazor

This article explains how to interact with JavaScript (JS) in Blazor WebAssembly apps using .NET JS `[JSImport]`/`[JSExport]` interop API released with .NET 7.

Blazor provides its own JS interop mechanism based on the <xref:Microsoft.JSInterop.IJSRuntime> interface, which is uniformly supported across Blazor hosting models and described in the following articles:

* <xref:blazor/js-interop/call-javascript-from-dotnet>
* <xref:blazor/js-interop/call-dotnet-from-javascript>

<xref:Microsoft.JSInterop.IJSRuntime> enables library authors to build JS interop libraries that can be shared across the Blazor ecosystem and remains the recommend approach for JS interop in Blazor.

This article describes an alternative JS interop approach available for the first time with the release of .NET 7. The approaches described in this article can be used in place of existing <xref:Microsoft.JSInterop.IJSRuntime> approaches and should be used to replace obsolete unmarshalled JS interop API when migrating to .NET 7.

## Obsolete JavaScript interop API

Unmarshalled JS interop using <xref:Microsoft.JSInterop.IJSUnmarshalledRuntime> API is obsolete in ASP.NET Core 7.0. Follow the guidance in this article to replace the obsolete API.

## Prerequisites

[!INCLUDE[](~/includes/7.0-SDK.md)]

## Cache busting during development

When implementing JS interop, browser caching of JS files during development can interfere with writing and testing JS interop code. To force a browser to reload JS files (cache busting) during development, we recommend using browser [developer tools](https://developer.mozilla.org/docs/Glossary/Developer_Tools) with static asset caching disabled. For more information, access the documentation for the developer tools associated with your browser:

* [Chrome DevTools](https://developer.chrome.com/docs/devtools/)
* [Firefox Developer Tools](https://developer.mozilla.org/docs/Tools)
* [Microsoft Edge Developer Tools overview](/microsoft-edge/devtools-guide-chromium/)

## Enable unsafe blocks

Enable the <xref:Microsoft.Build.Tasks.Csc.AllowUnsafeBlocks> property in app's project file, which permits the code generator in the Roslyn compiler to use pointers for JS interop:

```xml
<PropertyGroup>
  <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
</PropertyGroup>
```

> [!WARNING]
> The JS interop API requires enabling <xref:Microsoft.Build.Tasks.Csc.AllowUnsafeBlocks>. Be careful when implementing your own unsafe code in .NET apps, which can introduce security and stability risks. For more information, see [Unsafe code, pointer types, and function pointers](/dotnet/csharp/language-reference/unsafe-code).

## Call JavaScript from .NET

This section explains how to call JS functions from .NET.

In the following `CallJavaScript1` component:

* The `CallJavaScript1` module is imported asynchronously from the [collocated JS file](xref:blazor/js-interop/index#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component) with `JSHost.ImportAsync`.
* The imported `getMessage` JS function is called by `GetWelcomeMessage`.
* The returned welcome message string is displayed in the UI via the `message` field.

`Pages/CallJavaScript1.razor`:

```razor
@page "/call-javascript-1"
@using System.Runtime.InteropServices.JavaScript

<h1>.NET JS <code>[JSImport]</code>/<code>[JSExport]</code> Interop 1 (Call JS)</h1>

@(message is not null ? message : string.Empty)

@code {
    private string? message;

    protected override async Task OnInitializedAsync()
    {
        await JSHost.ImportAsync("CallJavaScript1", 
            "../Pages/CallJavaScript1.razor.js");

        message = GetWelcomeMessage();
    }
}
```

> [!NOTE]
> Code can include a conditional check for <xref:System.OperatingSystem.IsBrowser%2A?displayProperty=nameWithType> to ensure that the JS interop is only called in Blazor WebAssembly apps running on the client in a browser. This is important for libraries/NuGet packages that target Blazor WebAssembly and Blazor Server apps because Blazor Server apps can't execute the code provided by this JS interop API.

To import a JS function to call it from C#, use the `[JSImport]` attribute on a C# method signature that matches the JS function's signature. The first parameter to the `[JSImport]` attribute is the name of the JS function to import, and the second parameter is the name of the [JS module](xref:blazor/js-interop/index#javascript-isolation-in-javascript-modules).

In the following example, `getMessage` is a JS function that returns a `string` for a module named `CallJavaScript1`. The C# method signature matches: No parameters are passed to the JS function, and the JS function returns a `string`. The JS function is called by `GetWelcomeMessage` in C# code.

`Pages/CallJavaScript1.razor.cs`:

```csharp
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace BlazorSample.Pages
{
    [SupportedOSPlatform("browser")]
    public partial class CallJavaScript1
    {
        [JSImport("getMessage", "CallJavaScript1")]
        internal static partial string GetWelcomeMessage();
    }
}
```

The app's namespace for the preceding `CallJavaScript1` partial class is `BlazorSample`. The component's namespace is `BlazorSample.Pages`. If using the preceding component in a local test app, update the namespace to match the app. For example, the namespace is `ContosoApp.Pages` if the app's namespace is `ContosoApp`. For more information, see <xref:blazor/components/index#partial-class-support>.

In the imported method signature, you can use .NET types for parameters and return values, which are marshalled automatically by the runtime. Use `JSMarshalAsAttribute<T>` to control how the imported method parameters are marshalled. For example, you might choose to marshal a `long` as <xref:System.Runtime.InteropServices.JavaScript.JSType.Number?displayProperty=nameWithType> or <xref:System.Runtime.InteropServices.JavaScript.JSType.BigInt?displayProperty=nameWithType>. You can pass <xref:System.Action>/<xref:System.Func%601> callbacks as parameters, which are marshalled as callable JS functions. You can pass both JS and managed object references, and they are marshaled as proxy objects, keeping the object alive across the boundary until the proxy is garbage collected. You can also import and export asynchronous methods with a <xref:System.Threading.Tasks.Task> result, which are marshaled as [JS promises](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise). Most of the marshalled types work in both directions, as parameters and as return values, on both imported and exported methods, which are covered in the [Call .NET from JavaScript](#call-net-from-javascript) section later in this article.

The module name in the `[JSImport]` attribute and the call to load the module in the component with `JSHost.ImportAsync` syntax should match. The module name must also be unique in the app. When authoring a library for deployment in a NuGet package, we recommend using the NuGet package namespace as a prefix in module names. In the following example, the module name reflects the `Contoso.InteropServices.JavaScript` package and a folder of user message interop classes (`UserMessages`):

```csharp
[JSImport("getMessage", 
    "Contoso.InteropServices.JavaScript.UserMessages.CallJavaScript1")]
```

Export scripts from a standard [JavaScript ES6 module](xref:blazor/js-interop/index#javascript-isolation-in-javascript-modules) either [collocated with a component](xref:blazor/js-interop/index#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component) or placed with other JavaScript static assets in a JS file (for example, `wwwroot/js/{FILENAME}.js`, where JS static assets are maintained in a folder named `js` in the app's `wwwroot` folder and the `{FILENAME}` placeholder is the filename).

In the following example, a JS function named `getMessage` is exported from a collocated JS file that returns a welcome message, "Hello from Blazor!" in Portuguese:

`Pages/CallJavaScript1.razor.js`:

```javascript
export function getMessage() {
  return 'Olá do Blazor!';
}
```

## Call .NET from JavaScript

This section explains how to call .NET methods from JS.

The following `CallDotNet1` component calls JS that directly interacts with the DOM to render the welcome message string:

* The `CallDotNet` [JS module](xref:blazor/js-interop/index#javascript-isolation-in-javascript-modules) is imported asynchronously from the collocated JS file for this component.
* The imported `setMessage` JS function is called by `SetWelcomeMessage`.
* The returned welcome message is displayed by `setMessage` in the UI via the `message` field.

> [!IMPORTANT]
> In this section's example, JS interop is used to mutate a DOM element *purely for demonstration purposes* after the component is rendered in [`OnAfterRender`](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync). Typically, you should only mutate the DOM with JS when the object doesn't interact with Blazor. The approach shown in this section is similar to cases where a third-party JS library is used in a Razor component, where the component interacts with the JS library via JS interop, the third-party JS library interacts with part of the DOM, and Blazor isn't involved directly with the DOM updates to that part of the DOM. For more information, see <xref:blazor/js-interop/index#interaction-with-the-document-object-model-dom>.

`Pages/CallDotNet1.razor`:

```razor
@page "/call-dotnet-1"
@using System.Runtime.InteropServices.JavaScript

<h1>
    .NET JS <code>[JSImport]</code>/<code>[JSExport]</code> Interop 1 (Call .NET)
</h1>

<p>
    <span id="result">.NET method not executed yet</span>
</p>

@code {
    protected override async Task OnInitializedAsync()
    {
        await JSHost.ImportAsync("CallDotNet1", 
            "../Pages/CallDotNet1.razor.js");
    }

    protected override void OnAfterRender(bool firstRender)
    {
        SetWelcomeMessage();
    }
}
```

To export a .NET method so that it can be called from JS, use the `[JSExport]` attribute.

In the following example:

* `SetWelcomeMessage` calls a JS function named `setMessage`. The JS function calls into .NET to receive the welcome message from `GetMessageFromDotnet` and displays the message in the UI.
* `GetMessageFromDotnet` is a .NET method with the `[JSExport]` attribute that returns a welcome message, "Hello from Blazor!" in Portuguese.

`Pages/CallDotNet1.razor.cs`:

```csharp
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace BlazorSample.Pages
{
    [SupportedOSPlatform("browser")]
    public partial class CallDotNet1
    {
        [JSImport("setMessage", "CallDotNet1")]
        internal static partial void SetWelcomeMessage();

        [JSExport]
        internal static string GetMessageFromDotnet()
        {
            return "Olá do Blazor!";
        }
    }
}
```

The app's namespace for the preceding `CallDotNet1` partial class is `BlazorSample`. The component's namespace is `BlazorSample.Pages`. If using the preceding component in a local test app, update the app's namespace to match the app. For example, the component namespace is `ContosoApp.Pages` if the app's namespace is `ContosoApp`. For more information, see <xref:blazor/components/index#partial-class-support>.

In the following example, a JS function named `setMessage` is imported from a collocated JS file.

The `setMessage` method:

* Calls `globalThis.getDotnetRuntime(0)` to expose the WebAssembly .NET runtime instance for calling exported .NET methods.
* Obtains the app assembly's JS exports. The name of the app's assembly in the following example is `BlazorSample`.
* Calls the `BlazorSample.Pages.CallDotNet1.GetMessageFromDotnet` method from the exports (`exports`). The returned value, which is the welcome message, is assigned to the `CallDotNet1` component's `<span>` text. The app's namespace is `BlazorSample`, and the `CallDotNet1` component's namespace is `BlazorSample.Pages`.

`Pages/CallDotNet1.razor.js`:

```javascript
export async function setMessage() {
  const { getAssemblyExports } = await globalThis.getDotnetRuntime(0);
  var exports = await getAssemblyExports("BlazorSample.dll");

  document.getElementById("result").innerText = 
    exports.BlazorSample.Pages.CallDotNet1.GetMessageFromDotnet();
}
```

> [!NOTE]
> Calling `getAssemblyExports` to obtain the exports can occur in a [JavaScript initializer](xref:blazor/js-interop/index#javascript-initializers) for availability across the app.

## Multiple module import calls

After a JS module is loaded, the module's JS functions are available to the app's components and classes as long as the app is running in the browser window or tab without the user manually reloading the app. `JSHost.ImportAsync` can be called multiple times on the same module in the following cases without a significant performance penalty:

* The user visits a component that calls `JSHost.ImportAsync` to import a module, navigates away from the component, and then returns to the component where `JSHost.ImportAsync` is called again for the same module import.
* The same module is used by different components loaded by `JSHost.ImportAsync` in each of the components.

## Use of a single JavaScript module across components

*Before following the guidance in this section, read the [Call JavaScript from .NET](#call-javascript-from-net) and [Call .NET from JavaScript](#call-net-from-javascript) sections of this article, which provide general guidance on .NET JS `[JSImport]`/`[JSExport]` interop.*

The example in this section shows how to use JS interop from a shared JS module in a Blazor WebAssembly app. The guidance in this section isn't applicable to Razor class libraries (RCLs).

The following components, classes, C# methods, and JS functions are used:

* `Interop` class (`Interop.cs`): Sets up import and export JS interop with the `[JSImport]` and `[JSExport]` attributes for a module named `Interop`.
  * `GetWelcomeMessage`: .NET method that calls the imported `getMessage` JS function.
  * `SetWelcomeMessage`: .NET method that calls the imported `setMessage` JS function.
  * `GetMessageFromDotnet`: An exported C# method that returns a welcome message string when called from JS.
* `wwwroot/js/interop.js` file: Contains the JS functions.
  * `getMessage`: Returns a welcome message when called by C# code in a component.
  * `setMessage`: Calls the `GetMessageFromDotnet` C# method and assigns the returned welcome message to a DOM `<span>` element.
* `Program.cs` calls `JSHost.ImportAsync` to load the module from `wwwroot/js/interop.js`.
* `CallJavaScript2` component (`Pages/CallJavaScript2.razor`): Calls `GetWelcomeMessage` and displays the returned welcome message in the component's UI.
* `CallDotNet2` component (`Pages/CallDotNet2.razor`): Calls `SetWelcomeMessage`.

`Interop.cs`:

```csharp
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace BlazorSample.JavaScriptInterop
{
    [SupportedOSPlatform("browser")]
    public partial class Interop
    {
        [JSImport("getMessage", "Interop")]
        internal static partial string GetWelcomeMessage();

        [JSImport("setMessage", "Interop")]
        internal static partial void SetWelcomeMessage();

        [JSExport]
        internal static string GetMessageFromDotnet()
        {
            return "Olá do Blazor!";
        }
    }
}
```

In the preceding example, the app's namespace is `BlazorSample`, and the full namespace for C# interop classes is `BlazorSample.JavaScriptInterop`.

`wwwroot/js/interop.js`:

```javascript
export function getMessage() {
  return 'Olá do Blazor!';
}

export async function setMessage() {
  const { getAssemblyExports } = await globalThis.getDotnetRuntime(0);
  var exports = await getAssemblyExports("BlazorSample.dll");

  document.getElementById("result").innerText =
    exports.BlazorSample.JavaScriptInterop.Interop.GetMessageFromDotnet();
}
```

Make the `System.Runtime.InteropServices.JavaScript` namespace available at the top of the `Program.cs` file:

```csharp
using System.Runtime.InteropServices.JavaScript;
```

Load the module in `Program.cs` before <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHost.RunAsync%2A?displayProperty=nameWithType> is called:

```csharp
await JSHost.ImportAsync("Interop", "../js/interop.js");
```

`Pages/CallJavaScript2.razor`:

```razor
@page "/call-javascript-2"
@using BlazorSample.JavaScriptInterop

<h1>.NET JS <code>[JSImport]</code>/<code>[JSExport]</code> Interop 2 (Call JS)</h1>

@(message is not null ? message : string.Empty)

@code {
    private string? message;

    protected override void OnInitializedAsync()
    {
        message = Interop.GetWelcomeMessage();
    }
}
```

`Pages/CallDotNet2.razor`:

```razor
@page "/call-dotnet-2"
@using BlazorSample.JavaScriptInterop

<h1>
    .NET JS <code>[JSImport]</code>/<code>[JSExport]</code> Interop 2 (Call .NET)
</h1>

<p>
    <span id="result">.NET method not executed</span>
</p>

@code {
    protected override void OnAfterRender(bool firstRender)
    {
        Interop.SetWelcomeMessage();
    }
}
```

> [!IMPORTANT]
> In this section's example, JS interop is used to mutate a DOM element *purely for demonstration purposes* after the component is rendered in [`OnAfterRender`](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync). Typically, you should only mutate the DOM with JS when the object doesn't interact with Blazor. The approach shown in this section is similar to cases where a third-party JS library is used in a Razor component, where the component interacts with the JS library via JS interop, the third-party JS library interacts with part of the DOM, and Blazor isn't involved directly with the DOM updates to that part of the DOM. For more information, see <xref:blazor/js-interop/index#interaction-with-the-document-object-model-dom>.

## Additional example

For an additional example of the JS interop techniques described in this article, see the *Blazor WASM demo of new JSInterop* sample app:

* [Reference source (`pavelsavara/blazor-wasm-hands-pose` GitHub repository)](https://github.com/pavelsavara/blazor-wasm-hands-pose)
* [Live demonstration](https://pavelsavara.github.io/blazor-wasm-hands-pose/)

> [!NOTE]
> The [`pavelsavara/blazor-wasm-hands-pose` GitHub repository](https://github.com/pavelsavara/blazor-wasm-hands-pose) isn't owned, maintained, or supported by the .NET foundation or Microsoft.
>
> The *Blazor WASM demo of new JSInterop* sample app uses a public JS library from [MediaPipe](https://www.mediapipe.dev/), which isn't owned, maintained, or supported by the .NET foundation or Microsoft.

## Additional resources

* [Use .NET from any JavaScript app in .NET 7](https://devblogs.microsoft.com/dotnet/use-net-7-from-any-javascript-app-in-net-7/)
