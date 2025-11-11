---
title: ASP.NET Core Blazor startup
author: guardrex
description: Learn how to configure Blazor startup.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 11/11/2025
uid: blazor/fundamentals/startup
---
# ASP.NET Core Blazor startup

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains Blazor app startup configuration.

For general guidance on ASP.NET Core app configuration for server-side development, see <xref:fundamentals/configuration/index>.

## Startup process and configuration

:::moniker range=">= aspnetcore-8.0"

The Blazor startup process is automatic and asynchronous via the Blazor script (`blazor.*.js`), where the `*` placeholder is:

* `web` for a Blazor Web App
* `server` for a Blazor Server app
* `webassembly` for a Blazor WebAssembly app

:::moniker-end

:::moniker range="< aspnetcore-8.0"

The Blazor startup process is automatic and asynchronous via the Blazor script (`blazor.*.js`), where the `*` placeholder is:

* `server` for a Blazor Server app
* `webassembly` for a Blazor WebAssembly app

:::moniker-end

For the location of the script, see <xref:blazor/project-structure#location-of-the-blazor-script>.

To manually start Blazor:

:::moniker range=">= aspnetcore-8.0"

Blazor Web App:

* Add an `autostart="false"` attribute and value to the Blazor `<script>` tag.
* Place a script that calls `Blazor.start()` after the Blazor `<script>` tag and inside the closing `</body>` tag.
* Place static server-side rendering (static SSR) options in the `ssr` property.
* Place server-side Blazor-SignalR circuit options in the `circuit` property.
* Place client-side WebAssembly options in the `webAssembly` property.

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  ...
  Blazor.start({
    ssr: {
      ...
    },
    circuit: {
      ...
    },
    webAssembly: {
      ...
    }
  });
  ...
</script>
```

Standalone Blazor WebAssembly and Blazor Server:

:::moniker-end

* Add an `autostart="false"` attribute and value to the Blazor `<script>` tag.
* Place a script that calls `Blazor.start()` after the Blazor `<script>` tag and inside the closing `</body>` tag.
* You can provide additional options in the `Blazor.start()` parameter.

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  ...
  Blazor.start({
    ...
  });
  ...
</script>
```

**In the preceding example, the `{BLAZOR SCRIPT}` placeholder is the Blazor script path and file name.** For the location of the script, see <xref:blazor/project-structure#location-of-the-blazor-script>.

:::moniker range=">= aspnetcore-6.0"

## JavaScript initializers

JavaScript (JS) initializers execute logic before and after a Blazor app loads. JS initializers are useful in the following scenarios:

* Customizing how a Blazor app loads.
* Initializing libraries before Blazor starts up.
* Configuring Blazor settings.

JS initializers are detected as part of the build process and imported automatically. Use of JS initializers often removes the need to [manually trigger script functions from the app](xref:blazor/fundamentals/startup#chain-to-the-promise-that-results-from-a-manual-start) when using [Razor class libraries (RCLs)](xref:blazor/components/class-libraries).

To define a JS initializer, add a JS module to the project named `{NAME}.lib.module.js`, where the `{NAME}` placeholder is the assembly name, library name, or package identifier. Place the file in the project's web root, which is typically the `wwwroot` folder.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

For Blazor Web Apps:

* `beforeWebStart(options)`: Called before the Blazor Web App starts. For example, `beforeWebStart` is used to customize the loading process, logging level, and other options. Receives the Blazor Web options (`options`).
* `afterWebStarted(blazor)`: Called after all `beforeWebStart` promises resolve. For example, `afterWebStarted` can be used to register Blazor event listeners and custom event types. The Blazor instance is passed to `afterWebStarted` as an argument (`blazor`).
* `beforeServerStart(options, extensions)`: Called before the first Server runtime is started. Receives SignalR circuit start options (`options`) and any extensions (`extensions`) added during publishing.
* `afterServerStarted(blazor)`: Called after the first Interactive Server runtime is started.
* `beforeWebAssemblyStart(options, extensions)`: Called before the Interactive WebAssembly runtime is started. Receives the Blazor options (`options`) and any extensions (`extensions`) added during publishing. For example, options can specify the use of a custom [boot resource loader](xref:blazor/fundamentals/startup#load-client-side-boot-resources).
* `afterWebAssemblyStarted(blazor)`: Called after the Interactive WebAssembly runtime is started.

> [!NOTE]
> Legacy JS initializers (`beforeStart`, `afterStarted`) aren't invoked by default in a Blazor Web App. You can enable the legacy initializers to run with the `enableClassicInitializers` option. However, legacy initializer execution is unpredictable.
>
> ```html
> <script>
>   Blazor.start({ enableClassicInitializers: true });
> </script>
> ```

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-10.0"

Due to a [framework bug in .NET 8 and 9 (`dotnet/aspnetcore` #54049)](https://github.com/dotnet/aspnetcore/issues/54049), the Blazor script must be manually started when `beforeWebAssemblyStart(options, extensions)` or `afterWebAssemblyStarted(blazor)` are called. If the server app doesn't already start Blazor manually with a WebAssembly (`webAssembly: {...}`) configuration, update the `App` component in the server project with the following.

In `Components/App.razor`, remove the existing Blazor `<script>` tag: 

```diff
- <script src="_framework/blazor.web.js"></script>
```

Replace the `<script>` tag with the following markup that starts Blazor manually with a WebAssembly (`webAssembly: {...}`) configuration:

```html
<script src="_framework/blazor.web.js" autostart="false"></script>
<script>
    Blazor.start({
        webAssembly: {}
    });
</script>
```

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

For Blazor Server, Blazor WebAssembly, and Blazor Hybrid apps:

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

* `beforeStart(options, extensions)`: Called before Blazor starts. For example, `beforeStart` is used to customize the loading process, logging level, and other options specific to the hosting model.
  * Client-side, `beforeStart` receives the Blazor options (`options`) and any extensions (`extensions`) added during publishing. For example, options can specify the use of a custom [boot resource loader](xref:blazor/fundamentals/startup#load-client-side-boot-resources).
  * Server-side, `beforeStart` receives SignalR circuit start options (`options`).
  * In a [`BlazorWebView`](/mobile-blazor-bindings/walkthroughs/hybrid-hello-world#mainrazor-native-ui-page), no options are passed.
* `afterStarted(blazor)`: Called after Blazor is ready to receive calls from JS. For example, `afterStarted` is used to initialize libraries by making JS interop calls and registering custom elements. The Blazor instance is passed to `afterStarted` as an argument (`blazor`).

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

Additional .NET WebAssembly runtime callbacks:

* `onRuntimeConfigLoaded(config)`: Called when the boot configuration is downloaded. Allows the app to modify parameters (config) before the runtime starts (the parameter is `MonoConfig` from [`dotnet.d.ts`](https://github.com/dotnet/runtime/blob/main/src/mono/browser/runtime/dotnet.d.ts)):

  ```javascript
  export function onRuntimeConfigLoaded(config) {
    // Sample: Enable startup diagnostic logging when the URL contains 
    // parameter debug=1
    const params = new URLSearchParams(location.search);
    if (params.get("debug") == "1") {
      config.diagnosticTracing = true;
    }
  }
  ```

* `onRuntimeReady({ getAssemblyExports, getConfig })`: Called after the .NET WebAssembly runtime has started (the parameter is `RuntimeAPI` from [`dotnet.d.ts`](https://github.com/dotnet/runtime/blob/main/src/mono/browser/runtime/dotnet.d.ts)):

  ```javascript
  export function onRuntimeReady({ getAssemblyExports, getConfig }) {
    // Sample: After the runtime starts, but before Main method is called, 
    // call [JSExport]ed method.
    const config = getConfig();
    const exports = await getAssemblyExports(config.mainAssemblyName);
    exports.Sample.Greet();
  }
  ```
Both callbacks can return a `Promise`, and the promise is awaited before the startup continues.

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

For the file name:

* If the JS initializers are consumed as a static asset in the project, use the format `{ASSEMBLY NAME}.lib.module.js`, where the `{ASSEMBLY NAME}` placeholder is the app's assembly name. For example, name the file `BlazorSample.lib.module.js` for a project with an assembly name of `BlazorSample`. Place the file in the app's `wwwroot` folder.
* If the JS initializers are consumed from an RCL, use the format `{LIBRARY NAME/PACKAGE ID}.lib.module.js`, where the `{LIBRARY NAME/PACKAGE ID}` placeholder is the project's library name or package identifier (`<PackageId>` value in the library's project file). For example, name the file `RazorClassLibrary1.lib.module.js` for an RCL with a package identifier of `RazorClassLibrary1`. Place the file in the library's `wwwroot` folder.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

For Blazor Web Apps:

The following example demonstrates JS initializers that load custom scripts before and after the Blazor Web App has started by appending them to the `<head>` in `beforeWebStart` and `afterWebStarted`:

```javascript
export function beforeWebStart() {
  var customScript = document.createElement('script');
  customScript.setAttribute('src', 'beforeStartScripts.js');
  document.head.appendChild(customScript);
}

export function afterWebStarted() {
  var customScript = document.createElement('script');
  customScript.setAttribute('src', 'afterStartedScripts.js');
  document.head.appendChild(customScript);
}
```

The preceding `beforeWebStart` example only guarantees that the custom script loads before Blazor starts. It doesn't guarantee that awaited promises in the script complete their execution before Blazor starts.

For Blazor Server, Blazor WebAssembly, and Blazor Hybrid apps:

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

The following example demonstrates JS initializers that load custom scripts before and after Blazor has started by appending them to the `<head>` in `beforeStart` and `afterStarted`:

```javascript
export function beforeStart(options, extensions) {
  var customScript = document.createElement('script');
  customScript.setAttribute('src', 'beforeStartScripts.js');
  document.head.appendChild(customScript);
}

export function afterStarted(blazor) {
  var customScript = document.createElement('script');
  customScript.setAttribute('src', 'afterStartedScripts.js');
  document.head.appendChild(customScript);
}
```

The preceding `beforeStart` example only guarantees that the custom script loads before Blazor starts. It doesn't guarantee that awaited promises in the script complete their execution before Blazor starts.

> [!NOTE]
> MVC and Razor Pages apps don't automatically load JS initializers. However, developer code can include a script to fetch the app's manifest and trigger the load of the JS initializers.

For examples of JS initializers, see the following resources:

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

* [Blazor Web App loading indicator](#global-interactive-webassembly-rendering-without-prerendering) (*Global Interactive WebAssembly rendering without prerendering example*)
* <xref:blazor/js-interop/ssr>
* <xref:blazor/components/js-spa-frameworks#render-razor-components-from-javascript> (*`quoteContainer2` example*)
* <xref:blazor/components/event-handling#custom-event-arguments> (*Custom clipboard paste event example*)
* <xref:blazor/security/qrcodes-for-authenticator-apps>
* [Basic Test App in the ASP.NET Core GitHub repository (`BasicTestApp.lib.module.js`)](https://github.com/dotnet/aspnetcore/blob/main/src/Components/test/testassets/BasicTestApp/wwwroot/BasicTestApp.lib.module.js)

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

* <xref:blazor/components/js-spa-frameworks#render-razor-components-from-javascript> (*`quoteContainer2` example*)
* <xref:blazor/components/event-handling#custom-event-arguments> (*Custom clipboard paste event example*)
* <xref:blazor/host-and-deploy/webassembly/deployment-layout>
* [Basic Test App in the ASP.NET Core GitHub repository (`BasicTestApp.lib.module.js`)](https://github.com/dotnet/aspnetcore/blob/main/src/Components/test/testassets/BasicTestApp/wwwroot/BasicTestApp.lib.module.js)

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

### Ensure libraries are loaded in a specific order

Append custom scripts to the `<head>` in `beforeStart` and `afterStarted` in the order that they should load.

The following example loads `script1.js` before `script2.js` and `script3.js` before `script4.js`:

```javascript
export function beforeStart(options, extensions) {
    var customScript1 = document.createElement('script');
    customScript1.setAttribute('src', 'script1.js');
    document.head.appendChild(customScript1);

    var customScript2 = document.createElement('script');
    customScript2.setAttribute('src', 'script2.js');
    document.head.appendChild(customScript2);
}

export function afterStarted(blazor) {
    var customScript1 = document.createElement('script');
    customScript1.setAttribute('src', 'script3.js');
    document.head.appendChild(customScript1);

    var customScript2 = document.createElement('script');
    customScript2.setAttribute('src', 'script4.js');
    document.head.appendChild(customScript2);
}
```

### Import additional modules

Use top-level [`import`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Statements/import) statements in the JS initializers file to import additional modules.

`additionalModule.js`:

```javascript
export function logMessage() {
  console.log('logMessage is logging');
}
```

In the JS initializers file (`.lib.module.js`):

```javascript
import { logMessage } from "/additionalModule.js";

export function beforeStart(options, extensions) {
  ...

  logMessage();
}
```

### Import map

[Import maps](https://developer.mozilla.org/docs/Web/HTML/Element/script/type/importmap) are supported by ASP.NET Core and Blazor.

:::moniker-end

## Initialize Blazor when the document is ready

The following example starts Blazor when the document is ready:

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  document.addEventListener("DOMContentLoaded", function() {
    Blazor.start();
  });
</script>
```

**In the preceding example, the `{BLAZOR SCRIPT}` placeholder is the Blazor script path and file name.** For the location of the script, see <xref:blazor/project-structure#location-of-the-blazor-script>.

## Chain to the `Promise` that results from a manual start

To perform additional tasks, such as JS interop initialization, use [`then`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise/then) to chain to the [`Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) that results from a manual Blazor app start:

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  Blazor.start().then(function () {
    ...
  });
</script>
```

**In the preceding example, the `{BLAZOR SCRIPT}` placeholder is the Blazor script path and file name.** For the location of the script, see <xref:blazor/project-structure#location-of-the-blazor-script>.

:::moniker range=">= aspnetcore-6.0"

> [!NOTE]
> For a library to automatically execute additional tasks after Blazor has started, use a [JavaScript initializer](#javascript-initializers). Use of a JS initializer doesn't require the consumer of the library to chain JS calls to Blazor's manual start.

:::moniker-end

## Load client-side boot resources

When an app loads in the browser, the app downloads boot resources from the server:

* JavaScript code to bootstrap the app
* .NET runtime and assemblies
* Locale specific data

Customize how these boot resources are loaded using the `loadBootResource` API. The `loadBootResource` function overrides the built-in boot resource loading mechanism. Use `loadBootResource` for the following scenarios:

* Load static resources, such as timezone data or `dotnet.wasm`, from a CDN.
* Load compressed assemblies using an HTTP request and decompress them on the client for hosts that don't support fetching compressed contents from the server.
* Alias resources to a different name by redirecting each `fetch` request to a new name.

> [!NOTE]
> External sources must return the required [Cross-Origin Resource Sharing (CORS)](https://www.w3.org/TR/cors/) headers for browsers to allow cross-origin resource loading. CDNs usually provide the required headers.

`loadBootResource` parameters appear in the following table.

| Parameter    | Description |
| ------------ | ----------- |
| `type`       | The type of the resource. Permissible types include: `assembly`, `pdb`, `dotnetjs`, `dotnetwasm`, and `timezonedata`. You only need to specify types for custom behaviors. Types not specified to `loadBootResource` are loaded by the framework per their default loading behaviors. The `dotnetjs` boot resource (`dotnet.*.js`) must either return `null` for default loading behavior or a URI for the source of the `dotnetjs` boot resource. |
| `name`       | The name of the resource. |
| `defaultUri` | The relative or absolute URI of the resource. |
| `integrity`  | The integrity string representing the expected content in the response. |

The `loadBootResource` function can return a URI string to override the loading process. In the following example, the following files from `bin/Release/{TARGET FRAMEWORK}/wwwroot/_framework` are served from a CDN at `https://cdn.example.com/blazorwebassembly/{VERSION}/`:

* `dotnet.*.js`
* `dotnet.wasm`
* Timezone data

The `{TARGET FRAMEWORK}` placeholder is the target framework moniker (for example, `net7.0`). The `{VERSION}` placeholder is the shared framework version (for example, `7.0.0`).

:::moniker range=">= aspnetcore-8.0"

Blazor Web App:

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  Blazor.start({
    webAssembly: {
      loadBootResource: function (type, name, defaultUri, integrity) {
        console.log(`Loading: '${type}', '${name}', '${defaultUri}', '${integrity}'`);
        switch (type) {
          case 'dotnetjs':
          case 'dotnetwasm':
          case 'timezonedata':
            return `https://cdn.example.com/blazorwebassembly/{VERSION}/${name}`;
        }
      }
    }
  });
</script>
```

Standalone Blazor WebAssembly:

:::moniker-end

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  Blazor.start({
    loadBootResource: function (type, name, defaultUri, integrity) {
      console.log(`Loading: '${type}', '${name}', '${defaultUri}', '${integrity}'`);
      switch (type) {
        case 'dotnetjs':
        case 'dotnetwasm':
        case 'timezonedata':
          return `https://cdn.example.com/blazorwebassembly/{VERSION}/${name}`;
      }
    }
  });
</script>
```

**In the preceding example, the `{BLAZOR SCRIPT}` placeholder is the Blazor script path and file name.** For the location of the script, see <xref:blazor/project-structure#location-of-the-blazor-script>.

To customize more than just the URLs for boot resources, the `loadBootResource` function can call `fetch` directly and return the result. The following example adds a custom HTTP header to the outbound requests. To retain the default integrity checking behavior, pass through the `integrity` parameter.

:::moniker range=">= aspnetcore-8.0"

Blazor Web App:

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  Blazor.start({
    webAssembly: {
      loadBootResource: function (type, name, defaultUri, integrity) {
        if (type == 'dotnetjs') {
          return null;
        } else {
          return fetch(defaultUri, {
            cache: 'no-cache',
            integrity: integrity,
            headers: { 'Custom-Header': 'Custom Value' }
          });
        }
      }
    }
  });
</script>
```

Standalone Blazor WebAssembly:

:::moniker-end

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  Blazor.start({
    loadBootResource: function (type, name, defaultUri, integrity) {
      if (type == 'dotnetjs') {
        return null;
      } else {
        return fetch(defaultUri, {
          cache: 'no-cache',
          integrity: integrity,
          headers: { 'Custom-Header': 'Custom Value' }
        });
      }
    }
  });
</script>
```

**In the preceding example, the `{BLAZOR SCRIPT}` placeholder is the Blazor script path and file name.** For the location of the script, see <xref:blazor/project-structure#location-of-the-blazor-script>.

When the `loadBootResource` function returns `null`, Blazor uses the default loading behavior for the resource. For example, the preceding code returns `null` for the `dotnetjs` boot resource (`dotnet.*.js`) because the `dotnetjs` boot resource must either return `null` for default loading behavior or a URI for the source of the `dotnetjs` boot resource.

The `loadBootResource` function can also return a [`Response` promise](https://developer.mozilla.org/docs/Web/API/Response). For an example, see <xref:blazor/host-and-deploy/webassembly/index#compression>.

For more information, see <xref:blazor/host-and-deploy/webassembly/bundle-caching-and-integrity-check-failures>.

## Control headers in C# code

Control headers at startup in C# code using the following approaches.

In the following examples, a [Content Security Policy (CSP)](https://developer.mozilla.org/docs/Web/HTTP/Guides/CSP) is applied to the app via a CSP header. The `{POLICY STRING}` placeholder is the CSP policy string. For more information on CSPs, see <xref:blazor/security/content-security-policy>.

> [!NOTE]
> Headers can't be set after the response starts. The approaches in this section only set headers before the response starts, so the approaches described here are safe. For more information, see <xref:blazor/components/httpcontext#dont-set-or-modify-headers-after-the-response-starts>.

### Server-side and prerendered client-side scenarios

Use [ASP.NET Core Middleware](xref:fundamentals/middleware/index) to control the headers collection.

:::moniker range=">= aspnetcore-6.0"

In the `Program` file:

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In `Startup.Configure` of `Startup.cs`:

:::moniker-end

```csharp
app.Use(async (context, next) =>
{
    context.Response.Headers.Append("Content-Security-Policy", "{POLICY STRING}");
    await next();
});
```

The preceding example uses inline middleware, but you can also create a custom middleware class and call the middleware with an extension method in the `Program` file. For more information, see <xref:fundamentals/middleware/write>.

:::moniker range="< aspnetcore-8.0"

### Client-side development without prerendering

Pass <xref:Microsoft.AspNetCore.Builder.StaticFileOptions> to <xref:Microsoft.AspNetCore.Builder.StaticFilesEndpointRouteBuilderExtensions.MapFallbackToFile%2A> that specifies response headers at the <xref:Microsoft.AspNetCore.Builder.StaticFileOptions.OnPrepareResponse> stage.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

In the server-side `Program` file:

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In `Startup.Configure` of `Startup.cs`:

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```csharp
var staticFileOptions = new StaticFileOptions
{
    OnPrepareResponse = context =>
    {
        context.Context.Response.Headers.Append("Content-Security-Policy", 
            "{POLICY STRING}");
    }
};

...

app.MapFallbackToFile("index.html", staticFileOptions);
```

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

## Client-side loading indicators

A loading indicator shows that the app is loading normally and that the user should wait until loading is finished.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

### Blazor Web App loading indicator

The loading indicator used in Blazor WebAssembly apps isn't present in an app created from the Blazor Web App project template. Usually, a loading indicator isn't desirable for interactive WebAssembly components because Blazor Web Apps prerender client-side components on the server for fast initial load times. For mixed-render-mode situations, the framework or developer code must also be careful to avoid the following problems:

* Showing multiple loading indicators on the same rendered page.
* Inadvertently discarding prerendered content while the .NET WebAssembly runtime is loading.

A future release of .NET might provide a framework-based loading indicator. In the meantime, you can add a custom loading indicator to a Blazor Web App.

#### Per-component Interactive WebAssembly rendering with prerendering

*This scenario applies to per-component Interactive WebAssembly rendering (`@rendermode InteractiveWebAssembly` applied to individual components).*

Create a `ContentLoading` component in the `Layout` folder of the `.Client` app that calls <xref:System.OperatingSystem.IsBrowser%2A?displayProperty=nameWithType>:

* When `false`, display a loading indicator.
* When `true`, render the requested component's content.

To load CSS styles for the indicator, add the styles to `<head>` content with the <xref:Microsoft.AspNetCore.Components.Web.HeadContent> component. For more information, see <xref:blazor/components/control-head-content>.

`Layout/ContentLoading.razor`:

:::moniker-end

:::moniker range=">= aspnetcore-9.0"

```razor
@if (!RendererInfo.IsInteractive)
{
    <!-- OPTIONAL ...
    <HeadContent>
        <style>
            ...
        </style>
    </HeadContent>
    -->
    <progress id="loadingIndicator" aria-label="Content loading…"></progress>
}
else
{
    @ChildContent
}

@code {
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-9.0"

```razor
@if (!OperatingSystem.IsBrowser())
{
    <!-- OPTIONAL ...
    <HeadContent>
        <style>
            ...
        </style>
    </HeadContent>
    -->
    <progress id="loadingIndicator" aria-label="Content loading…"></progress>
}
else
{
    @ChildContent
}

@code {
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

If you didn't already have a `Layout` folder in the `.Client` project, add the namespace for the `Layout` folder to the `_Imports.razor` file. In the following example, the project's namespace is `BlazorSample.Client`:

```razor
@using BlazorSample.Client.Layout
```

In a component that adopts Interactive WebAssembly rendering, wrap the component's Razor markup with the `ContentLoading` component. The following example demonstrates the approach with the `Counter` component of an app created from the Blazor Web App project template.

`Pages/Counter.razor`:

```razor
@page "/counter"
@rendermode InteractiveWebAssembly

<PageTitle>Counter</PageTitle>

<ContentLoading>
    <h1>Counter</h1>

    <p role="status">Current count: @currentCount</p>

    <button class="btn btn-primary" @onclick="IncrementCount">Click me</button>
</ContentLoading>

@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

#### Global Interactive WebAssembly rendering with prerendering

*This scenario applies to global Interactive WebAssembly rendering with prerendering (`@rendermode="InteractiveWebAssembly"` on the `HeadOutlet` and `Routes` components in the `App` component).*

Create a `ContentLoading` component in the `Layout` folder of the `.Client` app that calls <xref:Microsoft.AspNetCore.Components.RendererInfo.IsInteractive?displayProperty=nameWithType>:

* When `false`, display a loading indicator.
* When `true`, render the requested component's content.

To load CSS styles for the indicator, add the styles to `<head>` content with the <xref:Microsoft.AspNetCore.Components.Web.HeadContent> component. For more information, see <xref:blazor/components/control-head-content>.

`Layout/ContentLoading.razor`:

:::moniker-end

:::moniker range=">= aspnetcore-9.0"

```razor
@if (!RendererInfo.IsInteractive)
{
    <!-- OPTIONAL ...
    <HeadContent>
        <style>
            ...
        </style>
    </HeadContent>
    -->
    <progress id="loadingIndicator" aria-label="Content loading…"></progress>
}
else
{
    @ChildContent
}

@code {
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-9.0"

```razor
@if (!OperatingSystem.IsBrowser())
{
    <!-- OPTIONAL ...
    <HeadContent>
        <style>
            ...
        </style>
    </HeadContent>
    -->
    <progress id="loadingIndicator" aria-label="Content loading…"></progress>
}
else
{
    @ChildContent
}

@code {
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

If you didn't already have a `Layout` folder in the `.Client` project, add the namespace for the `Layout` folder to the `_Imports.razor` file. In the following example, the project's namespace is `BlazorSample.Client`:

```razor
@using BlazorSample.Client.Layout
```

In the `MainLayout` component (`Layout/MainLayout.razor`) of the `.Client` project, wrap the <xref:Microsoft.AspNetCore.Components.LayoutComponentBase.Body%2A> property (`@Body`) with the `ContentLoading` component:

In `Layout/MainLayout.razor`:

```diff
+ <ContentLoading>
    @Body
+ </ContentLoading>
```

#### Global Interactive WebAssembly rendering without prerendering

*This scenario applies to global Interactive WebAssembly rendering without prerendering (`@rendermode="new InteractiveWebAssemblyRenderMode(prerender: false)"` on the `HeadOutlet` and `Routes` components in the `App` component).*

Add a [JavaScript initializer](#javascript-initializers) to the app. In the following JavaScript module file name example, the `{ASSEMBLY NAME}` placeholder is the assembly name of the server project (for example, `BlazorSample`). The `wwwroot` folder where the module is placed is the `wwwroot` folder in the server-side project, not the `.Client` project.

The following example uses a [`progress`](https://developer.mozilla.org/docs/Web/HTML/Element/progress) indicator that doesn't indicate the actual progress of  [delivering client-side boot resources to the client](#load-client-side-boot-resources), but it serves as a general approach for further development if you want the progress indicator to show the actual progress of loading the app's boot resources.

`wwwroot/{ASSEMBLY NAME}.lib.module.js`:

```javascript
export function beforeWebStart(options) {
  var progress = document.createElement("progress");
  progress.id = 'loadingIndicator';
  progress.ariaLabel = 'Blazor loading…';
  progress.style = 'position:absolute;top:50%;left:50%;margin-right:-50%;' +
    'transform:translate(-50%,-50%);';
  document.body.appendChild(progress);
}

export function afterWebAssemblyStarted(blazor) {
  var progress = document.getElementById('loadingIndicator');
  progress.remove();
}
```

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-10.0"

Due to a [framework bug in .NET 8 and 9 (`dotnet/aspnetcore` #54049)](https://github.com/dotnet/aspnetcore/issues/54049), the Blazor script must be manually started. If the server app doesn't already start Blazor manually with a WebAssembly (`webAssembly: {...}`) configuration, update the `App` component in the server project with the following.

In `Components/App.razor`, remove the existing Blazor `<script>` tag: 

```diff
- <script src="_framework/blazor.web.js"></script>
```

Replace the `<script>` tag with the following markup that starts Blazor manually with a WebAssembly (`webAssembly: {...}`) configuration:

```html
<script src="_framework/blazor.web.js" autostart="false"></script>
<script>
    Blazor.start({
        webAssembly: {}
    });
</script>
```

If you notice a short delay between the loading indicator removal and the first page render, you can guarantee removal of the indicator after rendering by calling for indicator removal in the [`OnAfterRenderAsync` lifecycle method](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync) of either the `MainLayout` or `Routes` components. For more information and a code example, see [Document an approach for a loading indicator that works with global Interactive WebAssembly without prerendering (`dotnet/AspNetCore.Docs` #35111)](https://github.com/dotnet/AspNetCore.Docs/issues/35111#issuecomment-2778796998).

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

### Blazor WebAssembly app loading progress

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

The project template contains Scalable Vector Graphics (SVG) and text indicators that show the loading progress of the app.

The progress indicators are implemented with HTML and CSS using two CSS custom properties (variables) provided by Blazor:

* `--blazor-load-percentage`: The percentage of app files loaded.
* `--blazor-load-percentage-text`: The percentage of app files loaded, rounded to the nearest whole number.

Using the preceding CSS variables, you can create custom progress indicators that match the styling of your app.

In the following example:

* `resourcesLoaded` is an instantaneous count of the resources loaded during app startup.
* `totalResources` is the total number of resources to load.

```javascript
const percentage = resourcesLoaded / totalResources * 100;
document.documentElement.style.setProperty(
  '--blazor-load-percentage', `${percentage}%`);
document.documentElement.style.setProperty(
  '--blazor-load-percentage-text', `"${Math.floor(percentage)}%"`);
```

The default round progress indicator is implemented in HTML in the `wwwroot/index.html` file:

```html
<div id="app">
    <svg class="loading-progress">
        <circle r="40%" cx="50%" cy="50%" />
        <circle r="40%" cx="50%" cy="50%" />
    </svg>
    <div class="loading-progress-text"></div>
</div>
```

To review the project template markup and styling for the default progress indicators, see the ASP.NET Core reference source:

* [`wwwroot/index.html`](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/ComponentsWebAssembly-CSharp/wwwroot/index.html)
* [`app.css`](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/ComponentsWebAssembly-CSharp/wwwroot/css/app.css)

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

Instead of using the default round progress indicator, the following example shows how to implement a linear progress indicator.

Add the following styles to `wwwroot/css/app.css`:

```css
.linear-progress {
    background: silver;
    width: 50vw;
    margin: 20% auto;
    height: 1rem;
    border-radius: 10rem;
    overflow: hidden;
    position: relative;
}

.linear-progress:after {
    content: '';
    position: absolute;
    inset: 0;
    background: blue;
    scale: var(--blazor-load-percentage, 0%) 100%;
    transform-origin: left top;
    transition: scale ease-out 0.5s;
}
```

A CSS variable (`var(...)`) is used to pass the value of `--blazor-load-percentage` to the `scale` property of a blue pseudo-element that indicates the loading progress of the app's files. As the app loads, `--blazor-load-percentage` is updated automatically, which dynamically changes the progress indicator's visual representation.

In `wwwroot/index.html`, remove the default SVG round indicator in `<div id="app">...</div>` and replace it with the following markup:

```html
<div class="linear-progress"></div>
```

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

## Configure the .NET WebAssembly runtime

In advanced programming scenarios, the `configureRuntime` function with the `dotnet` runtime host builder is used to configure the .NET WebAssembly runtime. For example, `dotnet.withEnvironmentVariable` sets an environment variable that:

* Configures the .NET WebAssembly runtime.
* Changes the behavior of a C library.

> [!NOTE]
> A documentation request is pending in the `dotnet/runtime` GitHub repository for more information on environment variables that configure the .NET WebAssembly runtime or affect the behavior of C libraries. Although the documentation request is pending, more information and cross-links to additional resources are available in the request, [Question/request for documentation on .NET WASM runtime env vars (`dotnet/runtime` #98225)](https://github.com/dotnet/runtime/issues/98225). 

The `configureRuntime` function can also be used to [enable integration with a browser profiler](https://github.com/dotnet/runtime/blob/main/src/mono/wasm/features.md#profiling).

For the placeholders in the following examples that set an environment variable:

* The `{BLAZOR SCRIPT}` placeholder is the Blazor script path and file name. For the location of the script, see <xref:blazor/project-structure#location-of-the-blazor-script>.
* The `{NAME}` placeholder is the environment variable's name.
* The `{VALUE}` placeholder is the environment variable's value.

Blazor Web App:

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  Blazor.start({
    webAssembly: {
      configureRuntime: dotnet => {
        dotnet.withEnvironmentVariable("{NAME}", "{VALUE}");
      }
    }
  });
</script>
```

Standalone Blazor WebAssembly:

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  Blazor.start({
    configureRuntime: dotnet => {
      dotnet.withEnvironmentVariable("{NAME}", "{VALUE}");
    }
  });
</script>
```

> [!NOTE]
> The .NET runtime instance can be accessed using the .NET WebAssembly Runtime API (`Blazor.runtime`). For example, the app's build configuration can be obtained using `Blazor.runtime.runtimeBuildInfo.buildConfiguration`.
>
> For more information on the .NET WebAssembly runtime configuration, see the [runtime's TypeScript definition file (`dotnet.d.ts`) in the `dotnet/runtime` GitHub repository](https://github.com/dotnet/runtime/blob/main/src/mono/browser/runtime/dotnet.d.ts).
>
> [!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

## Disable enhanced navigation and form handling

*This section applies to Blazor Web Apps.*

To disable [enhanced navigation and form handling](xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling), set `disableDomPreservation` to `true` for `Blazor.start`:

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  Blazor.start({
    ssr: { disableDomPreservation: true }
  });
</script>
```

**In the preceding example, the `{BLAZOR SCRIPT}` placeholder is the Blazor script path and file name.** For the location of the script, see <xref:blazor/project-structure#location-of-the-blazor-script>.

:::moniker-end

## Additional resources

* [Environments: Set the app's environment](xref:blazor/fundamentals/environments)
* [SignalR (includes sections on SignalR startup configuration)](xref:blazor/fundamentals/signalr)
* [Globalization and localization: Statically set the culture with `Blazor.start()` (*client-side only*)](xref:blazor/globalization-localization#statically-set-the-client-side-culture)
* [Blazor WebAssembly compression](xref:blazor/host-and-deploy/webassembly/index#compression)
