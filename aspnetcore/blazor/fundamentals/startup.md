---
title: ASP.NET Core Blazor startup
author: guardrex
description: Learn how to configure Blazor startup.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/fundamentals/startup
---
# ASP.NET Core Blazor startup

This article explains how to configure Blazor startup.

:::moniker range=">= aspnetcore-7.0"

The Blazor startup process via the Blazor script (`blazor.{webassembly|server}.js`) is automatic and asynchronous. The Blazor `<script>` tag is found in the `wwwroot/index.html` file (Blazor WebAssembly) or `Pages/_Host.cshtml` file (Blazor Server). Scripts added after the Blazor `<script>` tag block the Blazor JavaScript engine until they've finished loading.

To manually start Blazor:

* Add an `autostart="false"` attribute and value to the Blazor `<script>` tag.
* Place a script that calls `Blazor.start` after the Blazor `<script>` tag and inside the closing `</body>` tag.

## JavaScript initializers

[!INCLUDE[](~/blazor/includes/js-initializers.md)]

## Initialize Blazor when the document is ready

The following example starts Blazor when the document is ready:

```cshtml
<body>
    ...

    <script src="_framework/blazor.{webassembly|server}.js" autostart="false"></script>
    <script>
      document.addEventListener("DOMContentLoaded", function() {
        Blazor.start();
      });
    </script>
</body>
```

The `{webassembly|server}` placeholder in the preceding markup is either `webassembly` for a Blazor WebAssembly app (`blazor.webassembly.js`) or `server` for a Blazor Server app (`blazor.server.js`).

## Chain to the `Promise` that results from a manual start

To perform additional tasks, such as JS interop initialization, use [`then`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise/then) to chain to the [`Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) that results from a manual Blazor app start:

```cshtml
<body>
    ...

    <script src="_framework/blazor.{webassembly|server}.js" autostart="false"></script>
    <script>
      Blazor.start().then(function () {
        ...
      });
    </script>
</body>
```

The `{webassembly|server}` placeholder in the preceding markup is either `webassembly` for a Blazor WebAssembly app (`blazor.webassembly.js`) or `server` for a Blazor Server app (`blazor.server.js`).

## Load boot resources

*This section only applies to Blazor WebAssembly apps.*

When a Blazor WebAssembly app loads in the browser, the app downloads boot resources from the server:

* JavaScript code to bootstrap the app
* .NET runtime and assemblies
* Locale specific data

Customize how these boot resources are loaded using the `loadBootResource` API. The `loadBootResource` function overrides the built-in boot resource loading mechanism. Use `loadBootResource` for the following scenarios:

* Load static resources, such as timezone data or `dotnet.wasm`, from a CDN.
* Load compressed assemblies using an HTTP request and decompress them on the client for hosts that don't support fetching compressed contents from the server.
* Alias resources to a different name by redirecting each `fetch` request to a new name.

> [!NOTE]
> External sources must return the required [Cross-Origin Resource Sharing (CORS)](https://www.w3.org/TR/cors/) headers for browsers to allow cross-origin resource loading. CDNs usually provide the required headers by default.

`loadBootResource` parameters appear in the following table.

| Parameter    | Description |
| ------------ | ----------- |
| `type`       | The type of the resource. Permissible types include: `assembly`, `pdb`, `dotnetjs`, `dotnetwasm`, and `timezonedata`. You only need to specify types for custom behaviors. Types not specified to `loadBootResource` are loaded by the framework per their default loading behaviors. |
| `name`       | The name of the resource. |
| `defaultUri` | The relative or absolute URI of the resource. |
| `integrity`  | The integrity string representing the expected content in the response. |

The `loadBootResource` function can return a URI string to override the loading process. In the following example, the following files from `bin/Release/net5.0/wwwroot/_framework` are served from a CDN at `https://cdn.example.com/blazorwebassembly/5.0.0/`:

* `dotnet.*.js`
* `dotnet.wasm`
* Timezone data

Inside the closing `</body>` tag of `wwwroot/index.html`:

```html
<script src="_framework/blazor.webassembly.js" autostart="false"></script>
<script>
  Blazor.start({
    loadBootResource: function (type, name, defaultUri, integrity) {
      console.log(`Loading: '${type}', '${name}', '${defaultUri}', '${integrity}'`);
      switch (type) {
        case 'dotnetjs':
        case 'dotnetwasm':
        case 'timezonedata':
          return `https://cdn.example.com/blazorwebassembly/5.0.0/${name}`;
      }
    }
  });
</script>
```

To customize more than just the URLs for boot resources, the `loadBootResource` function can call `fetch` directly and return the result. The following example adds a custom HTTP header to the outbound requests. To retain the default integrity checking behavior, pass through the `integrity` parameter.

Inside the closing `</body>` tag of `wwwroot/index.html`:

```html
<script src="_framework/blazor.webassembly.js" autostart="false"></script>
<script>
  Blazor.start({
    loadBootResource: function (type, name, defaultUri, integrity) {
      return fetch(defaultUri, { 
        cache: 'no-cache',
        integrity: integrity,
        headers: { 'Custom-Header': 'Custom Value' }
      });
    }
  });
</script>
```

The `loadBootResource` function can also return:

* `null`/`undefined`, which results in the default loading behavior.
* A [`Response` promise](https://developer.mozilla.org/docs/Web/API/Response). For an example, see <xref:blazor/host-and-deploy/webassembly#compression>.

## Control headers in C# code

Control headers at startup in C# code using the following approaches.

In the following examples, a [Content Security Policy (CSP)](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy) is applied to the app via a CSP header. The `{POLICY STRING}` placeholder is the CSP policy string.

* In Blazor Server and prerendered Blazor WebAssembly apps, use [ASP.NET Core Middleware](xref:fundamentals/middleware/index) to control the headers collection.

  In `Program.cs`:

  ```csharp
  app.Use(async (context, next) =>
  {
      context.Response.Headers.Add("Content-Security-Policy", "{POLICY STRING}");
      await next();
  });
  ```

  The preceding example uses inline middleware, but you can also create a custom middleware class and call the middleware with an extension method in `Program.cs`. For more information, see <xref:fundamentals/middleware/write>.

* In hosted Blazor WebAssembly apps that aren't prerendered, pass <xref:Microsoft.AspNetCore.Builder.StaticFileOptions> to <xref:Microsoft.AspNetCore.Builder.StaticFilesEndpointRouteBuilderExtensions.MapFallbackToFile%2A> that specifies response headers at the <xref:Microsoft.AspNetCore.Builder.StaticFileOptions.OnPrepareResponse> stage.

  In `Program.cs` of the **:::no-loc text="Server":::** project:

  ```csharp
  var staticFileOptions = new StaticFileOptions
  {
      OnPrepareResponse = context =>
      {
          context.Context.Response.Headers.Add("Content-Security-Policy", 
              "{POLICY STRING}");
      }
  };

  ...

  app.MapFallbackToFile("index.html", staticFileOptions);
  ```

For more information on CSPs, see <xref:blazor/security/content-security-policy>.

## Loading progress indicators

*This section only applies to Blazor WebAssembly apps.*

The Blazor WebAssembly project template contains Scalable Vector Graphics (SVG) and text indicators that show the loading progress of the app.

The progress indicators are implemented with HTML and CSS using two CSS custom properties (variables) provided by Blazor WebAssembly:

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

To review the Blazor WebAssembly project template markup and styling for the default progress indicators, see the ASP.NET Core reference source:

* [`wwwroot/index.html`](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/ComponentsWebAssembly-CSharp/Client/wwwroot/index.html)
* [`app.css`](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/ComponentsWebAssembly-CSharp/Client/wwwroot/css/app.css)

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

## Additional resources

* [Environments: Set the app's environment](xref:blazor/fundamentals/environments)
* SignalR
  * [Blazor startup](xref:blazor/fundamentals/signalr#blazor-startup)
  * [Configure timeouts and Keep-Alive on the client](xref:blazor/fundamentals/signalr#configure-signalr-timeouts-and-keep-alive-on-the-client)
  * [Configure client logging (Blazor Server)](xref:blazor/fundamentals/logging#signalr-client-logging-blazor-server)
  * [Configure client logging (Blazor WebAssembly)](xref:blazor/fundamentals/logging#signalr-client-logging-blazor-webassembly)
  * [Modify the reconnection handler](xref:blazor/fundamentals/signalr#modify-the-reconnection-handler-blazor-server)
  * [Adjust the reconnection retry count and interval](xref:blazor/fundamentals/signalr#adjust-the-reconnection-retry-count-and-interval-blazor-server)
  * [Disconnect the Blazor circuit from the client](xref:blazor/fundamentals/signalr#disconnect-the-blazor-circuit-from-the-client-blazor-server)
* [Globalization and localization: Statically set the culture with `Blazor.start` (*Blazor WebAssembly only*)](xref:blazor/globalization-localization?pivots=webassembly#statically-set-the-culture)
* [JS interop: Inject a script after Blazor starts](xref:blazor/js-interop/index#inject-a-script-after-blazor-starts)
* [Host and deploy: Blazor WebAssembly: Compression](xref:blazor/host-and-deploy/webassembly#compression)

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

The Blazor startup process via the Blazor script (`blazor.{webassembly|server}.js`) is automatic and asynchronous. The Blazor `<script>` tag is found in the `wwwroot/index.html` file (Blazor WebAssembly) or `Pages/_Layout.cshtml` file (Blazor Server). Scripts added after the Blazor `<script>` tag block the Blazor JavaScript engine until they've finished loading.

To manually start Blazor:

* Add an `autostart="false"` attribute and value to the Blazor `<script>` tag.
* Place a script that calls `Blazor.start` after the Blazor `<script>` tag and inside the closing `</body>` tag.

## JavaScript initializers

[!INCLUDE[](~/blazor/includes/js-initializers.md)]

## Initialize Blazor when the document is ready

The following example starts Blazor when the document is ready:

```cshtml
<body>
    ...

    <script src="_framework/blazor.{webassembly|server}.js" autostart="false"></script>
    <script>
      document.addEventListener("DOMContentLoaded", function() {
        Blazor.start();
      });
    </script>
</body>
```

The `{webassembly|server}` placeholder in the preceding markup is either `webassembly` for a Blazor WebAssembly app (`blazor.webassembly.js`) or `server` for a Blazor Server app (`blazor.server.js`).

## Chain to the `Promise` that results from a manual start

To perform additional tasks, such as JS interop initialization, use [`then`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise/then) to chain to the [`Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) that results from a manual Blazor app start:

```cshtml
<body>
    ...

    <script src="_framework/blazor.{webassembly|server}.js" autostart="false"></script>
    <script>
      Blazor.start().then(function () {
        ...
      });
    </script>
</body>
```

The `{webassembly|server}` placeholder in the preceding markup is either `webassembly` for a Blazor WebAssembly app (`blazor.webassembly.js`) or `server` for a Blazor Server app (`blazor.server.js`).

## Load boot resources

*This section only applies to Blazor WebAssembly apps.*

When a Blazor WebAssembly app loads in the browser, the app downloads boot resources from the server:

* JavaScript code to bootstrap the app
* .NET runtime and assemblies
* Locale specific data

Customize how these boot resources are loaded using the `loadBootResource` API. The `loadBootResource` function overrides the built-in boot resource loading mechanism. Use `loadBootResource` for the following scenarios:

* Load static resources, such as timezone data or `dotnet.wasm`, from a CDN.
* Load compressed assemblies using an HTTP request and decompress them on the client for hosts that don't support fetching compressed contents from the server.
* Alias resources to a different name by redirecting each `fetch` request to a new name.

> [!NOTE]
> External sources must return the required [Cross-Origin Resource Sharing (CORS)](https://www.w3.org/TR/cors/) headers for browsers to allow cross-origin resource loading. CDNs usually provide the required headers by default.

`loadBootResource` parameters appear in the following table.

| Parameter    | Description |
| ------------ | ----------- |
| `type`       | The type of the resource. Permissible types include: `assembly`, `pdb`, `dotnetjs`, `dotnetwasm`, and `timezonedata`. You only need to specify types for custom behaviors. Types not specified to `loadBootResource` are loaded by the framework per their default loading behaviors. |
| `name`       | The name of the resource. |
| `defaultUri` | The relative or absolute URI of the resource. |
| `integrity`  | The integrity string representing the expected content in the response. |

The `loadBootResource` function can return a URI string to override the loading process. In the following example, the following files from `bin/Release/net5.0/wwwroot/_framework` are served from a CDN at `https://cdn.example.com/blazorwebassembly/5.0.0/`:

* `dotnet.*.js`
* `dotnet.wasm`
* Timezone data

Inside the closing `</body>` tag of `wwwroot/index.html`:

```html
<script src="_framework/blazor.webassembly.js" autostart="false"></script>
<script>
  Blazor.start({
    loadBootResource: function (type, name, defaultUri, integrity) {
      console.log(`Loading: '${type}', '${name}', '${defaultUri}', '${integrity}'`);
      switch (type) {
        case 'dotnetjs':
        case 'dotnetwasm':
        case 'timezonedata':
          return `https://cdn.example.com/blazorwebassembly/5.0.0/${name}`;
      }
    }
  });
</script>
```

To customize more than just the URLs for boot resources, the `loadBootResource` function can call `fetch` directly and return the result. The following example adds a custom HTTP header to the outbound requests. To retain the default integrity checking behavior, pass through the `integrity` parameter.

Inside the closing `</body>` tag of `wwwroot/index.html`:

```html
<script src="_framework/blazor.webassembly.js" autostart="false"></script>
<script>
  Blazor.start({
    loadBootResource: function (type, name, defaultUri, integrity) {
      return fetch(defaultUri, { 
        cache: 'no-cache',
        integrity: integrity,
        headers: { 'Custom-Header': 'Custom Value' }
      });
    }
  });
</script>
```

The `loadBootResource` function can also return:

* `null`/`undefined`, which results in the default loading behavior.
* A [`Response` promise](https://developer.mozilla.org/docs/Web/API/Response). For an example, see <xref:blazor/host-and-deploy/webassembly#compression>.

## Control headers in C# code

Control headers at startup in C# code using the following approaches.

In the following examples, a [Content Security Policy (CSP)](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy) is applied to the app via a CSP header. The `{POLICY STRING}` placeholder is the CSP policy string.

* In Blazor Server and prerendered Blazor WebAssembly apps, use [ASP.NET Core Middleware](xref:fundamentals/middleware/index) to control the headers collection.

  In `Program.cs`:

  ```csharp
  app.Use(async (context, next) =>
  {
      context.Response.Headers.Add("Content-Security-Policy", "{POLICY STRING}");
      await next();
  });
  ```

  The preceding example uses inline middleware, but you can also create a custom middleware class and call the middleware with an extension method in `Program.cs`. For more information, see <xref:fundamentals/middleware/write>.

* In hosted Blazor WebAssembly apps that aren't prerendered, pass <xref:Microsoft.AspNetCore.Builder.StaticFileOptions> to <xref:Microsoft.AspNetCore.Builder.StaticFilesEndpointRouteBuilderExtensions.MapFallbackToFile%2A> that specifies response headers at the <xref:Microsoft.AspNetCore.Builder.StaticFileOptions.OnPrepareResponse> stage.

  In `Program.cs` of the **:::no-loc text="Server":::** project:

  ```csharp
  var staticFileOptions = new StaticFileOptions
  {
      OnPrepareResponse = context =>
      {
          context.Context.Response.Headers.Add("Content-Security-Policy", 
              "{POLICY STRING}");
      }
  };

  ...

  app.MapFallbackToFile("index.html", staticFileOptions);
  ```

For more information on CSPs, see <xref:blazor/security/content-security-policy>.

## Additional resources

* [Environments: Set the app's environment](xref:blazor/fundamentals/environments)
* SignalR
  * [Blazor startup](xref:blazor/fundamentals/signalr#blazor-startup)
  * [Configure timeouts and Keep-Alive on the client](xref:blazor/fundamentals/signalr#configure-signalr-timeouts-and-keep-alive-on-the-client)
  * [Configure client logging (Blazor Server)](xref:blazor/fundamentals/logging#signalr-client-logging-blazor-server)
  * [Configure client logging (Blazor WebAssembly)](xref:blazor/fundamentals/logging#signalr-client-logging-blazor-webassembly)
  * [Modify the reconnection handler](xref:blazor/fundamentals/signalr#modify-the-reconnection-handler-blazor-server)
  * [Adjust the reconnection retry count and interval](xref:blazor/fundamentals/signalr#adjust-the-reconnection-retry-count-and-interval-blazor-server)
  * [Disconnect the Blazor circuit from the client](xref:blazor/fundamentals/signalr#disconnect-the-blazor-circuit-from-the-client-blazor-server)
* [Globalization and localization: Statically set the culture with `Blazor.start` (*Blazor WebAssembly only*)](xref:blazor/globalization-localization?pivots=webassembly#statically-set-the-culture)
* [JS interop: Inject a script after Blazor starts](xref:blazor/js-interop/index#inject-a-script-after-blazor-starts)
* [Host and deploy: Blazor WebAssembly: Compression](xref:blazor/host-and-deploy/webassembly#compression)

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

The Blazor startup process via the Blazor script (`blazor.{webassembly|server}.js`) is automatic and asynchronous. The Blazor `<script>` tag is found in the `wwwroot/index.html` file (Blazor WebAssembly) or `Pages/_Host.cshtml` file (Blazor Server). Scripts added after the Blazor `<script>` tag block the Blazor JavaScript engine until they've finished loading.

To manually start Blazor:

* Add an `autostart="false"` attribute and value to the Blazor `<script>` tag.
* Place a script that calls `Blazor.start` after the Blazor `<script>` tag and inside the closing `</body>` tag.

## Initialize Blazor when the document is ready

The following example starts Blazor when the document is ready:

```cshtml
<body>
    ...

    <script src="_framework/blazor.{webassembly|server}.js" autostart="false"></script>
    <script>
      document.addEventListener("DOMContentLoaded", function() {
        Blazor.start();
      });
    </script>
</body>
```

The `{webassembly|server}` placeholder in the preceding markup is either `webassembly` for a Blazor WebAssembly app (`blazor.webassembly.js`) or `server` for a Blazor Server app (`blazor.server.js`).

## Chain to the `Promise` that results from a manual start

To perform additional tasks, such as JS interop initialization, use [`then`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise/then) to chain to the [`Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) that results from a manual Blazor app start:

```cshtml
<body>
    ...

    <script src="_framework/blazor.{webassembly|server}.js" autostart="false"></script>
    <script>
      Blazor.start().then(function () {
        ...
      });
    </script>
</body>
```

The `{webassembly|server}` placeholder in the preceding markup is either `webassembly` for a Blazor WebAssembly app (`blazor.webassembly.js`) or `server` for a Blazor Server app (`blazor.server.js`).

## Load boot resources

*This section only applies to Blazor WebAssembly apps.*

When a Blazor WebAssembly app loads in the browser, the app downloads boot resources from the server:

* JavaScript code to bootstrap the app
* .NET runtime and assemblies
* Locale specific data

Customize how these boot resources are loaded using the `loadBootResource` API. The `loadBootResource` function overrides the built-in boot resource loading mechanism. Use `loadBootResource` for the following scenarios:

* Load static resources, such as timezone data or `dotnet.wasm`, from a CDN.
* Load compressed assemblies using an HTTP request and decompress them on the client for hosts that don't support fetching compressed contents from the server.
* Alias resources to a different name by redirecting each `fetch` request to a new name.

> [!NOTE]
> External sources must return the required [Cross-Origin Resource Sharing (CORS)](https://www.w3.org/TR/cors/) headers for browsers to allow cross-origin resource loading. CDNs usually provide the required headers by default.

`loadBootResource` parameters appear in the following table.

| Parameter    | Description |
| ------------ | ----------- |
| `type`       | The type of the resource. Permissible types include: `assembly`, `pdb`, `dotnetjs`, `dotnetwasm`, and `timezonedata`. You only need to specify types for custom behaviors. Types not specified to `loadBootResource` are loaded by the framework per their default loading behaviors. |
| `name`       | The name of the resource. |
| `defaultUri` | The relative or absolute URI of the resource. |
| `integrity`  | The integrity string representing the expected content in the response. |

The `loadBootResource` function can return a URI string to override the loading process. In the following example, the following files from `bin/Release/net5.0/wwwroot/_framework` are served from a CDN at `https://cdn.example.com/blazorwebassembly/5.0.0/`:

* `dotnet.*.js`
* `dotnet.wasm`
* Timezone data

Inside the closing `</body>` tag of `wwwroot/index.html`:

```html
<script src="_framework/blazor.webassembly.js" autostart="false"></script>
<script>
  Blazor.start({
    loadBootResource: function (type, name, defaultUri, integrity) {
      console.log(`Loading: '${type}', '${name}', '${defaultUri}', '${integrity}'`);
      switch (type) {
        case 'dotnetjs':
        case 'dotnetwasm':
        case 'timezonedata':
          return `https://cdn.example.com/blazorwebassembly/5.0.0/${name}`;
      }
    }
  });
</script>
```

To customize more than just the URLs for boot resources, the `loadBootResource` function can call `fetch` directly and return the result. The following example adds a custom HTTP header to the outbound requests. To retain the default integrity checking behavior, pass through the `integrity` parameter.

Inside the closing `</body>` tag of `wwwroot/index.html`:

```html
<script src="_framework/blazor.webassembly.js" autostart="false"></script>
<script>
  Blazor.start({
    loadBootResource: function (type, name, defaultUri, integrity) {
      return fetch(defaultUri, { 
        cache: 'no-cache',
        integrity: integrity,
        headers: { 'Custom-Header': 'Custom Value' }
      });
    }
  });
</script>
```

The `loadBootResource` function can also return:

* `null`/`undefined`, which results in the default loading behavior.
* A [`Response` promise](https://developer.mozilla.org/docs/Web/API/Response). For an example, see <xref:blazor/host-and-deploy/webassembly#compression>.

## Control headers in C# code

Control headers at startup in C# code using the following approaches.

In the following examples, a [Content Security Policy (CSP)](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy) is applied to the app via a CSP header. The `{POLICY STRING}` placeholder is the CSP policy string.

* In Blazor Server and prerendered Blazor WebAssembly apps, use [ASP.NET Core Middleware](xref:fundamentals/middleware/index) to control the headers collection.

  In `Startup.Configure` of `Startup.cs`:

  ```csharp
  app.Use(async (context, next) =>
  {
      context.Response.Headers.Add("Content-Security-Policy", "{POLICY STRING}");
      await next();
  });
  ```

  The preceding example uses inline middleware, but you can also create a custom middleware class and call the middleware with an extension method in `Startup.Configure`. For more information, see <xref:fundamentals/middleware/write>.

* In hosted Blazor WebAssembly apps that aren't prerendered, pass <xref:Microsoft.AspNetCore.Builder.StaticFileOptions> to <xref:Microsoft.AspNetCore.Builder.StaticFilesEndpointRouteBuilderExtensions.MapFallbackToFile%2A> that specifies response headers at the <xref:Microsoft.AspNetCore.Builder.StaticFileOptions.OnPrepareResponse> stage.

  In `Startup.Configure` (`Startup.cs`) of the **:::no-loc text="Server":::** project:

  ```csharp
  var staticFileOptions = new StaticFileOptions
  {
      OnPrepareResponse = context =>
      {
          context.Context.Response.Headers.Add("Content-Security-Policy", 
              "{POLICY STRING}");
      }
  };

  ...

  app.MapFallbackToFile("index.html", staticFileOptions);
  ```

For more information on CSPs, see <xref:blazor/security/content-security-policy>.

## Additional resources

* [Environments: Set the app's environment](xref:blazor/fundamentals/environments)
* SignalR
  * [Blazor startup](xref:blazor/fundamentals/signalr#blazor-startup)
  * [Configure timeouts and Keep-Alive on the client](xref:blazor/fundamentals/signalr#configure-signalr-timeouts-and-keep-alive-on-the-client)
  * [Configure client logging (Blazor Server)](xref:blazor/fundamentals/logging#signalr-client-logging-blazor-server)
  * [Configure client logging (Blazor WebAssembly)](xref:blazor/fundamentals/logging#signalr-client-logging-blazor-webassembly)
  * [Modify the reconnection handler](xref:blazor/fundamentals/signalr#modify-the-reconnection-handler-blazor-server)
  * [Adjust the reconnection retry count and interval](xref:blazor/fundamentals/signalr#adjust-the-reconnection-retry-count-and-interval-blazor-server)
  * [Disconnect the Blazor circuit from the client](xref:blazor/fundamentals/signalr#disconnect-the-blazor-circuit-from-the-client-blazor-server)
* [Globalization and localization: Statically set the culture with `Blazor.start` (*Blazor WebAssembly only*)](xref:blazor/globalization-localization?pivots=webassembly#statically-set-the-culture)
* [JS interop: Inject a script after Blazor starts](xref:blazor/js-interop/index#inject-a-script-after-blazor-starts)
* [Host and deploy: Blazor WebAssembly: Compression](xref:blazor/host-and-deploy/webassembly#compression)

:::moniker-end

:::moniker range="< aspnetcore-5.0"

The Blazor startup process via the Blazor script (`blazor.{webassembly|server}.js`) is automatic and asynchronous. The Blazor `<script>` tag is found in the `wwwroot/index.html` file (Blazor WebAssembly) or `Pages/_Host.cshtml` file (Blazor Server). Scripts added after the Blazor `<script>` tag block the Blazor JavaScript engine until they've finished loading.

To manually start Blazor:

* Add an `autostart="false"` attribute and value to the Blazor `<script>` tag.
* Place a script that calls `Blazor.start` after the Blazor `<script>` tag and inside the closing `</body>` tag.

## Initialize Blazor when the document is ready

The following example starts Blazor when the document is ready:

```cshtml
<body>
    ...

    <script src="_framework/blazor.{webassembly|server}.js" autostart="false"></script>
    <script>
      document.addEventListener("DOMContentLoaded", function() {
        Blazor.start();
      });
    </script>
</body>
```

The `{webassembly|server}` placeholder in the preceding markup is either `webassembly` for a Blazor WebAssembly app (`blazor.webassembly.js`) or `server` for a Blazor Server app (`blazor.server.js`).

## Chain to the `Promise` that results from a manual start

To perform additional tasks, such as JS interop initialization, use [`then`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise/then) to chain to the [`Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) that results from a manual Blazor app start:

```cshtml
<body>
    ...

    <script src="_framework/blazor.{webassembly|server}.js" autostart="false"></script>
    <script>
      Blazor.start().then(function () {
        ...
      });
    </script>
</body>
```

The `{webassembly|server}` placeholder in the preceding markup is either `webassembly` for a Blazor WebAssembly app (`blazor.webassembly.js`) or `server` for a Blazor Server app (`blazor.server.js`).

## Load boot resources

*This section only applies to Blazor WebAssembly apps.*

When a Blazor WebAssembly app loads in the browser, the app downloads boot resources from the server:

* JavaScript code to bootstrap the app
* .NET runtime and assemblies
* Locale specific data

Customize how these boot resources are loaded using the `loadBootResource` API. The `loadBootResource` function overrides the built-in boot resource loading mechanism. Use `loadBootResource` for the following scenarios:

* Load static resources, such as timezone data or `dotnet.wasm`, from a CDN.
* Load compressed assemblies using an HTTP request and decompress them on the client for hosts that don't support fetching compressed contents from the server.
* Alias resources to a different name by redirecting each `fetch` request to a new name.

> [!NOTE]
> External sources must return the required [Cross-Origin Resource Sharing (CORS)](https://www.w3.org/TR/cors/) headers for browsers to allow cross-origin resource loading. CDNs usually provide the required headers by default.

`loadBootResource` parameters appear in the following table.

| Parameter    | Description |
| ------------ | ----------- |
| `type`       | The type of the resource. Permissible types include: `assembly`, `pdb`, `dotnetjs`, `dotnetwasm`, and `timezonedata`. You only need to specify types for custom behaviors. Types not specified to `loadBootResource` are loaded by the framework per their default loading behaviors. |
| `name`       | The name of the resource. |
| `defaultUri` | The relative or absolute URI of the resource. |
| `integrity`  | The integrity string representing the expected content in the response. |

The `loadBootResource` function can return a URI string to override the loading process. In the following example, the following files from `bin/Release/net5.0/wwwroot/_framework` are served from a CDN at `https://cdn.example.com/blazorwebassembly/3.1.0/`:

* `dotnet.*.js`
* `dotnet.wasm`
* Timezone data

Inside the closing `</body>` tag of `wwwroot/index.html`:

```html
<script src="_framework/blazor.webassembly.js" autostart="false"></script>
<script>
  Blazor.start({
    loadBootResource: function (type, name, defaultUri, integrity) {
      console.log(`Loading: '${type}', '${name}', '${defaultUri}', '${integrity}'`);
      switch (type) {
        case 'dotnetjs':
        case 'dotnetwasm':
        case 'timezonedata':
          return `https://cdn.example.com/blazorwebassembly/3.1.0/${name}`;
      }
    }
  });
</script>
```

To customize more than just the URLs for boot resources, the `loadBootResource` function can call `fetch` directly and return the result. The following example adds a custom HTTP header to the outbound requests. To retain the default integrity checking behavior, pass through the `integrity` parameter.

Inside the closing `</body>` tag of `wwwroot/index.html`:

```html
<script src="_framework/blazor.webassembly.js" autostart="false"></script>
<script>
  Blazor.start({
    loadBootResource: function (type, name, defaultUri, integrity) {
      return fetch(defaultUri, { 
        cache: 'no-cache',
        integrity: integrity,
        headers: { 'Custom-Header': 'Custom Value' }
      });
    }
  });
</script>
```

The `loadBootResource` function can also return:

* `null`/`undefined`, which results in the default loading behavior.
* A [`Response` promise](https://developer.mozilla.org/docs/Web/API/Response). For an example, see <xref:blazor/host-and-deploy/webassembly#compression>.

## Control headers in C# code

Control headers at startup in C# code using the following approaches.

In the following examples, a [Content Security Policy (CSP)](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Security-Policy) is applied to the app via a CSP header. The `{POLICY STRING}` placeholder is the CSP policy string.

* In Blazor Server, use [ASP.NET Core Middleware](xref:fundamentals/middleware/index) to control the headers collection.

  In `Startup.Configure` of `Startup.cs`:

  ```csharp
  app.Use(async (context, next) =>
  {
      context.Response.Headers.Add("Content-Security-Policy", "{POLICY STRING}");
      await next();
  });
  ```

  The preceding example uses inline middleware, but you can also create a custom middleware class and call the middleware with an extension method in `Program.cs`. For more information, see <xref:fundamentals/middleware/write>.

* In hosted Blazor WebAssembly apps, pass <xref:Microsoft.AspNetCore.Builder.StaticFileOptions> to <xref:Microsoft.AspNetCore.Builder.StaticFilesEndpointRouteBuilderExtensions.MapFallbackToFile%2A> that specifies response headers at the <xref:Microsoft.AspNetCore.Builder.StaticFileOptions.OnPrepareResponse> stage.

  In `Startup.Configure` (`Startup.cs`) of the **:::no-loc text="Server":::** project:

  ```csharp
  var staticFileOptions = new StaticFileOptions
  {
      OnPrepareResponse = context =>
      {
          context.Context.Response.Headers.Add("Content-Security-Policy", 
              "{POLICY STRING}");
      }
  };

  ...

  app.MapFallbackToFile("index.html", staticFileOptions);
  ```

For more information on CSPs, see <xref:blazor/security/content-security-policy>.

## Additional resources

* SignalR
  * [Blazor startup](xref:blazor/fundamentals/signalr#blazor-startup)
  * [Configure timeouts and Keep-Alive on the client](xref:blazor/fundamentals/signalr#configure-signalr-timeouts-and-keep-alive-on-the-client)
  * [Configure client logging (Blazor Server)](xref:blazor/fundamentals/logging#signalr-client-logging-blazor-server)
  * [Configure client logging (Blazor WebAssembly)](xref:blazor/fundamentals/logging#signalr-client-logging-blazor-webassembly)
  * [Modify the reconnection handler](xref:blazor/fundamentals/signalr#modify-the-reconnection-handler-blazor-server)
  * [Adjust the reconnection retry count and interval](xref:blazor/fundamentals/signalr#adjust-the-reconnection-retry-count-and-interval-blazor-server)
* [JS interop: Inject a script after Blazor starts](xref:blazor/js-interop/index#inject-a-script-after-blazor-starts)
* [Host and deploy: Blazor WebAssembly: Compression](xref:blazor/host-and-deploy/webassembly#compression)

:::moniker-end
