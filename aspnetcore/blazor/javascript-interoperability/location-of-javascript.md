---
title: JavaScript location in ASP.NET Core Blazor apps
author: guardrex
description: Learn where to place and how to load JavaScript in Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/12/2024
uid: blazor/js-interop/javascript-location
---
# JavaScript location in ASP.NET Core Blazor apps

[!INCLUDE[](~/includes/not-latest-version.md)]

Load JavaScript (JS) code using any of the following approaches:

:::moniker range=">= aspnetcore-6.0"

* [Load a script in `<head>` markup](#load-a-script-in-head-markup) (*Not generally recommended*)
* [Load a script in `<body>` markup](#load-a-script-in-body-markup)
* [Load a script from an external JavaScript file (`.js`) collocated with a component](#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component)
* [Load a script from an external JavaScript file (`.js`)](#load-a-script-from-an-external-javascript-file-js)
* [Inject a script before or after Blazor starts](#inject-a-script-before-or-after-blazor-starts)

:::moniker-end

:::moniker range="< aspnetcore-6.0"

* [Load a script in `<head>` markup](#load-a-script-in-head-markup) (*Not generally recommended*)
* [Load a script in `<body>` markup](#load-a-script-in-body-markup)
* [Load a script from an external JavaScript file (`.js`)](#load-a-script-from-an-external-javascript-file-js)
* [Inject a script after Blazor starts](#inject-a-script-after-blazor-starts)

:::moniker-end

Inline JavaScript isn't recommended for Blazor apps. We recommend using [JS collocation](#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component) combined with [JS modules](#javascript-isolation-in-javascript-modules).

## Location of `<script>` tags

:::moniker range=">= aspnetcore-8.0"

Only place a `<script>` tag in a component file (`.razor`) if the component is guaranteed to adopt [static server-side rendering (static SSR)](xref:blazor/fundamentals/index#client-and-server-rendering-concepts) without [enhanced navigation](xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling). Placing a `<script>` tag in a component file doesn't produce a compile-time warning or error, but script loading behavior might not match your expectations in components that adopt an interactive render mode or static SSR with enhanced navigation.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Don't place a `<script>` tag in a component file (`.razor`) because the `<script>` tag can't be updated dynamically. Placing a `<script>` tag in a component file produces a compile-time error.

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

> [!NOTE]
> Documentation examples usually place scripts in a `<script>` tag or load global scripts from external files. These approaches pollute the client with global functions. For production apps, we recommend placing JS into separate [JS modules](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Modules) that can be imported when needed. For more information, see the [JavaScript isolation in JavaScript modules](#javascript-isolation-in-javascript-modules) section.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

> [!NOTE]
> Documentation examples place scripts into a `<script>` tag or load global scripts from external files. These approaches pollute the client with global functions. Placing JS into separate [JS modules](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Modules) that can be imported when needed is **not** supported in Blazor earlier than ASP.NET Core 5.0. If the app requires the use of JS modules for JS isolation, we recommend using ASP.NET Core 5.0 or later to build the app. For more information, use the **Version** dropdown list to select a 5.0 or later version of this article and see the *JavaScript isolation in JavaScript modules* section.

:::moniker-end

## Load a script in `<head>` markup

*The approach in this section isn't generally recommended.*

Place the JavaScript (JS) tags (`<script>...</script>`) in the [`<head>` element markup](xref:blazor/project-structure#location-of-head-and-body-content):

```html
<head>
    ...

    <script>
      window.jsMethod = (methodParameter) => {
        ...
      };
    </script>
</head>
```

Loading JS from the `<head>` isn't the best approach for the following reasons:

* JS interop may fail if the script depends on Blazor. We recommend loading scripts using one of the other approaches, not via the `<head>` markup.
* The page may become interactive slower due to the time it takes to parse the JS in the script.

:::moniker range=">= aspnetcore-8.0"

In component markup, scripts can be loaded via a [`HeadContent` component](xref:blazor/components/control-head-content) with the usual caveat that the approach slows down page load on the client, which we recommend avoiding. When a script is loaded with a `HeadContent` component in a Blazor Server app, Blazor WebAssembly app, or a Blazor Web App using either an interactive render mode (interactive SSR, CSR) or static SSR with enhanced navigation, navigating away from the component's page removes the `<script>` tag from the rendered `<head>` content but doesn't unload the script's JavaScript code, including event handlers that the script registers, exposed variables, and methods that the script provides. Only Blazor Web Apps using static SSR without enhanced navigation unload JavaScript code when the user navigates away from the page. Generally, you're better off adding `<script>` tags to the physical `<head>` content, unless you explicitly desire to keep such script references in the components that use them and don't mind that the code isn't unloaded on navigation events.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

In component markup, scripts can be loaded via a [`HeadContent` component](xref:blazor/components/control-head-content) with the usual caveat that the approach slows down page load on the client, which we recommend avoiding. When a script is loaded with a `HeadContent` component, navigating away from the component's page removes the `<script>` tag from the rendered `<head>` content but doesn't unload the script's JavaScript code, including event handlers that the script registers, exposed variables, and methods that the script provides. Generally, you're better off adding `<script>` tags to the physical `<head>` content, unless you explicitly desire to keep such script references in the components that use them and don't mind that the code isn't unloaded on navigation events.

:::moniker-end

## Load a script in `<body>` markup

Place the JavaScript tags (`<script>...</script>`) inside the [closing `</body>` element](xref:blazor/project-structure#location-of-head-and-body-content) after the Blazor script reference:

```html
<body>
    ...

    <script src="{BLAZOR SCRIPT}"></script>
    <script>
      window.jsMethod = (methodParameter) => {
        ...
      };
    </script>
</body>
```

**In the preceding example, the `{BLAZOR SCRIPT}` placeholder is the Blazor script path and file name.** For the location of the script, see <xref:blazor/project-structure#location-of-the-blazor-script>.

:::moniker range=">= aspnetcore-6.0"

## Load a script from an external JavaScript file (`.js`) collocated with a component

[!INCLUDE[](~/blazor/includes/js-interop/js-collocation.md)]

For more information on RCLs, see <xref:blazor/components/class-libraries>.

:::moniker-end

### Load a script from an external JavaScript file (`.js`)

Place the JavaScript (JS) tags (`<script>...</script>`) with a script source (`src`) path inside the [closing `</body>` element](xref:blazor/project-structure#location-of-head-and-body-content) after the Blazor script reference:

```html
<body>
    ...

    <script src="{BLAZOR SCRIPT}"></script>
    <script src="{SCRIPT PATH AND FILE NAME (.js)}"></script>
</body>
```

For the placeholders in the preceding example:

* The `{BLAZOR SCRIPT}` placeholder is the Blazor script path and file name. For the location of the script, see <xref:blazor/project-structure#location-of-the-blazor-script>.
* The `{SCRIPT PATH AND FILE NAME (.js)}` placeholder is the path and script file name under `wwwroot`.

In the following example of the preceding `<script>` tag, the `scripts.js` file is in the `wwwroot/js` folder of the app:

```html
<script src="js/scripts.js"></script>
```

You can also serve scripts directly from the `wwwroot` folder if you prefer not to keep all of your scripts in a separate folder under `wwwroot`:

```html
<script src="scripts.js"></script>
```

When the external JS file is supplied by a [Razor class library](xref:blazor/components/class-libraries), specify the JS file using its stable static web asset path: `_content/{PACKAGE ID}/{SCRIPT PATH AND FILE NAME (.js)}`:

* The `{PACKAGE ID}` placeholder is the library's [package ID](/nuget/create-packages/creating-a-package-msbuild#set-properties). The package ID defaults to the project's assembly name if `<PackageId>` isn't specified in the project file.
* The `{SCRIPT PATH AND FILE NAME (.js)}` placeholder is the path and file name under `wwwroot`.

```html
<body>
    ...

    <script src="{BLAZOR SCRIPT}"></script>
    <script src="_content/{PACKAGE ID}/{SCRIPT PATH AND FILE NAME (.js)}"></script>
</body>
```

In the following example of the preceding `<script>` tag:

* The Razor class library has an assembly name of `ComponentLibrary`, and a `<PackageId>` isn't specified in the library's project file.
* The `scripts.js` file is in the class library's `wwwroot` folder.

```html
<script src="_content/ComponentLibrary/scripts.js"></script>
```

For more information, see <xref:blazor/components/class-libraries>.

:::moniker range=">= aspnetcore-6.0"

## Inject a script before or after Blazor starts

To ensure scripts load before or after Blazor starts, use a JavaScript initializer. For more information and examples, see <xref:blazor/fundamentals/startup#javascript-initializers>.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

## Inject a script after Blazor starts

To inject a script after Blazor starts, chain to the `Promise` that results from a manual start of Blazor. For more information and an example, see <xref:blazor/fundamentals/startup#inject-a-script-after-blazor-starts>.

:::moniker-end

## JavaScript isolation in JavaScript modules

Blazor enables JavaScript (JS) isolation in standard [JS modules](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Modules) ([ECMAScript specification](https://tc39.es/ecma262/#sec-modules)).

JS isolation provides the following benefits:

* Imported JS no longer pollutes the global namespace.
* Consumers of a library and components aren't required to import the related JS.

In server-side scenarios, always trap <xref:Microsoft.JSInterop.JSDisconnectedException> in case loss of Blazor's SignalR circuit prevents a JS interop call from disposing a module, which results in an unhandled exception. Blazor WebAssembly apps don't use a SignalR connection during JS interop, so there's no need to trap <xref:Microsoft.JSInterop.JSDisconnectedException> in Blazor WebAssembly apps for module disposal.

For more information, see the following resources:

* [JavaScript isolation in JavaScript modules](xref:blazor/js-interop/call-javascript-from-dotnet#javascript-isolation-in-javascript-modules)
* [JavaScript interop calls without a circuit](xref:blazor/js-interop/index#javascript-interop-calls-without-a-circuit)
