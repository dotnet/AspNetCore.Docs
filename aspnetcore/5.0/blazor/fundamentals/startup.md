---
title: ASP.NET Core Blazor Startup
author: guardrex
description: Learn how to configure Blazor startup.
monikerRange: 'aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/14/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/fundamentals/startup
---
# ASP.NET Core Blazor Startup

Configure a manual start in the `wwwroot/index.html` file (Blazor WebAssembly) or `Pages/_Host.cshtml` file (Blazor Server):

* Add an `autostart="false"` attribute and value to the `<script>` tag for the Blazor script.
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
| `type`       | The type of the resource. Permissable types include: `assembly`, `pdb`, `dotnetjs`, `dotnetwasm`, and `timezonedata`. You only need to specify types for custom behaviors. Types not specified to `loadBootResource` are loaded by the framework per their default loading behaviors. |
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

## Additional resources

* [Environments: Set the app's environment](xref:blazor/fundamentals/environments)
* SignalR
  * [Blazor startup](xref:blazor/fundamentals/signalr#blazor-startup)
  * [Configure SignalR client logging](xref:blazor/fundamentals/signalr#configure-signalr-client-logging)
  * [Modify the reconnection handler](xref:blazor/fundamentals/signalr#modify-the-reconnection-handler)
  * [Adjust the reconnection retry count and interval](xref:blazor/fundamentals/signalr#adjust-the-reconnection-retry-count-and-interval)
  * [Hide or replace the reconnection display](xref:blazor/fundamentals/signalr#hide-or-replace-the-reconnection-display)
  * [Disconnect the Blazor circuit from the client](xref:blazor/fundamentals/signalr#disconnect-the-blazor-circuit-from-the-client)
* [Globalization and localization: Statically set the culture with `Blazor.start` (*Blazor WebAssembly only*)](xref:blazor/globalization-localization?pivots=webassembly#statically-set-the-culture)
* [JS interop: Inject a script after Blazor starts](xref:blazor/js-interop/index#inject-a-script-after-blazor-starts)
* [Host and deploy: Blazor WebAssembly: Compression](xref:blazor/host-and-deploy/webassembly#compression)
