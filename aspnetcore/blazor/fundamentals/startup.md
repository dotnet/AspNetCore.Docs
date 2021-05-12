---
title: ASP.NET Core Blazor Startup
author: guardrex
description: Learn how to configure Blazor startup.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 05/12/2021
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

Override the built-in boot resource loading mechanism so that boot resources can be fetched from a custom source, such as an external Content Delivery Network (CDN).

* `type`: The type of the resource to load.
* `name`: The name of the resource to load.
* `defaultUri`: The URI from which the framework fetches the resource by default. Relative or absolute URIs are supported.
* `integrity`: The integrity string representing the expected content in the response.
* `return`: A URI string or a [`Response` promise](https://developer.mozilla.org/docs/Web/API/Response) to override the loading process, or null/undefined to allow the default loading behavior.

```html
<script src="_framework/blazor.{webassembly|server}.js" autostart="false"></script>
<script>
  Blazor.start({
    loadBootResource: function (type, name, defaultUri, integrity) {
      ...

      var responseContent = ...;
      var header_value_1 = ...;
      var header_value_2 = ...;

      return new Response(responseContent, { 
          headers: { 
            'example-header-1': header_value_1,
            'example-header-2': header_value_2
          }
      });
    }
  });
</script>
```

The `{webassembly|server}` placeholder in the preceding markup is either `webassembly` for a Blazor WebAssembly app (`blazor.webassembly.js`) or `server` for a Blazor Server app (`blazor.server.js`).

For an example, see the Brotli compression markup in the <xref:blazor/host-and-deploy/webassembly#compression> article.

## Additional resources

::: moniker range=">= aspnetcore-5.0"

* [Environments: Set the app's environment](xref:blazor/fundamentals/environments)
* SignalR
  * [Blazor startup](xref:blazor/fundamentals/signalr#blazor-startup)
  * [Configure SignalR client logging](xref:blazor/fundamentals/signalr#configure-signalr-client-logging)
  * [Modify the reconnection handler](xref:blazor/fundamentals/signalr#modify-the-reconnection-handler)
  * [Adjust the reconnection retry count and interval](xref:blazor/fundamentals/signalr#adjust-the-reconnection-retry-count-and-interval)
  * [Hide or replace the reconnection display](xref:blazor/fundamentals/signalr#hide-or-replace-the-reconnection-display)
  * [Disconnect the Blazor circuit from the client](xref:blazor/fundamentals/signalr#disconnect-the-blazor-circuit-from-the-client)
* [Globalization and localization: Set the culture in a Blazor WebAssembly app](xref:blazor/globalization-localization#blazor-webAssembly)
* [JS interop: Inject a script after Blazor starts](xref:blazor/js-interop/index#[inject-a-script-after-blazor-starts)
* [Host and deploy: Blazor WebAssembly: Compression](xref:blazor/host-and-deploy/webassembly#compression)

::: moniker-end

::: moniker range="< aspnetcore-5.0"

* SignalR
  * [Blazor startup](xref:blazor/fundamentals/signalr#blazor-startup)
  * [Configure SignalR client logging](xref:blazor/fundamentals/signalr#configure-signalr-client-logging)
  * [Modify the reconnection handler](xref:blazor/fundamentals/signalr#modify-the-reconnection-handler)
  * [Adjust the reconnection retry count and interval](xref:blazor/fundamentals/signalr#adjust-the-reconnection-retry-count-and-interval)
  * [Hide or replace the reconnection display](xref:blazor/fundamentals/signalr#hide-or-replace-the-reconnection-display)
* [JS interop: Inject a script after Blazor starts](xref:blazor/js-interop/index#[inject-a-script-after-blazor-starts)
* [Host and deploy: Blazor WebAssembly: Compression](xref:blazor/host-and-deploy/webassembly#compression)

::: moniker-end
