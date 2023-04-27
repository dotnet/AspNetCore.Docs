---
title: ASP.NET Core Blazor JavaScript interoperability (JS interop)
author: guardrex
description: Learn how to interact with JavaScript in Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/js-interop/index
---
# ASP.NET Core Blazor JavaScript interoperability (JS interop)

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains general concepts on how to interact with JavaScript in Blazor apps.

:::moniker range=">= aspnetcore-7.0"

A Blazor app can invoke JavaScript (JS) functions from .NET methods and .NET methods from JS functions. These scenarios are called *JavaScript interoperability* (*JS interop*).

Further JS interop guidance is provided in the following articles:

* <xref:blazor/js-interop/call-javascript-from-dotnet>
* <xref:blazor/js-interop/call-dotnet-from-javascript>

> [!NOTE]
> JavaScript `[JSImport]`/`[JSExport]` interop API is available for Blazor WebAssembly apps in ASP.NET Core 7.0 or later.
>
> For more information, see <xref:blazor/js-interop/import-export-interop>.

## JavaScript interop abstractions and features package

The [`@microsoft/dotnet-js-interop` package (`npmjs.com`)](https://www.npmjs.com/package/@microsoft/dotnet-js-interop) provides abstractions and features for interop between .NET and JavaScript (JS) code. Reference source is available in the [`dotnet/aspnetcore` GitHub repository (`/src/JSInterop` folder)](https://github.com/dotnet/aspnetcore/tree/main/src/JSInterop). For more information, see the GitHub repository's `README.md` file.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

Additional resources for writing JS interop scripts in TypeScript:

* [TypeScript](https://www.typescriptlang.org/)
* [Tutorial: Create an ASP.NET Core app with TypeScript in Visual Studio](/visualstudio/javascript/tutorial-aspnet-with-typescript)
* [Manage npm packages in Visual Studio](/visualstudio/javascript/npm-package-management)

## Interaction with the Document Object Model (DOM)

Only mutate the Document Object Model (DOM) with JavaScript (JS) when the object doesn't interact with Blazor. Blazor maintains representations of the DOM and interacts directly with DOM objects. If an element rendered by Blazor is modified externally using JS directly or via JS Interop, the DOM may no longer match Blazor's internal representation, which can result in undefined behavior. Undefined behavior may merely interfere with the presentation of elements or their functions but may also introduce security risks to the app or server.

This guidance not only applies to your own JS interop code but also to any JS libraries that the app uses, including anything provided by a third-party framework, such as [Bootstrap JS](https://getbootstrap.com/) and [jQuery](https://jquery.com/).

In a few documentation examples, JS interop is used to mutate an element *purely for demonstration purposes* as part of an example. In those cases, a warning appears in the text.

For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet#capture-references-to-elements>.

## Asynchronous JavaScript calls

JS interop calls are asynchronous by default, regardless of whether the called code is synchronous or asynchronous. Calls are asynchronous by default to ensure that components are compatible across both Blazor hosting models, Blazor Server and Blazor WebAssembly. On Blazor Server, JS interop calls must be asynchronous because they're sent over a network connection. For apps that exclusively adopt the Blazor WebAssembly hosting model, synchronous JS interop calls are supported.

For more information, see the following articles:

* <xref:blazor/js-interop/call-javascript-from-dotnet#synchronous-js-interop-in-blazor-webassembly-apps>
* <xref:blazor/js-interop/call-dotnet-from-javascript#synchronous-js-interop-in-blazor-webassembly-apps>

## Object serialization

Blazor uses <xref:System.Text.Json?displayProperty=fullName> for serialization with the following requirements and default behaviors:

* Types must have a default constructor, [`get`/`set` accessors](/dotnet/csharp/programming-guide/classes-and-structs/using-properties) must be public, and fields are never serialized.
* Global default serialization isn't customizable to avoid breaking existing component libraries, impacts on performance and security, and reductions in reliability.
* Serializing .NET member names results in lowercase JSON key names.
* JSON is deserialized as <xref:System.Text.Json.JsonElement> C# instances, which permit mixed casing. Internal casting for assignment to C# model properties works as expected in spite of any case differences between JSON key names and C# property names.

<xref:System.Text.Json.Serialization.JsonConverter> API is available for custom serialization. Properties can be annotated with a [`[JsonConverter]` attribute](xref:System.Text.Json.Serialization.JsonConverterAttribute) to override default serialization for an existing data type.

For more information, see the following resources in the .NET documentation:

* [JSON serialization and deserialization (marshalling and unmarshalling) in .NET](/dotnet/standard/serialization/system-text-json-overview)
* [How to customize property names and values with `System.Text.Json`](/dotnet/standard/serialization/system-text-json-customize-properties)
* [How to write custom converters for JSON serialization (marshalling) in .NET](/dotnet/standard/serialization/system-text-json-converters-how-to)

Blazor supports optimized byte array JS interop that avoids encoding/decoding byte arrays into Base64. The app can apply custom serialization and pass the resulting bytes. For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet#byte-array-support>.

## Location of JavaScript

Load JavaScript (JS) code using any of the following approaches:

* [Load a script in `<head>` markup](#load-a-script-in-head-markup) (*Not generally recommended*)
* [Load a script in `<body>` markup](#load-a-script-in-body-markup)
* [Load a script from an external JavaScript file (`.js`) collocated with a component](#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component)
* [Load a script from an external JavaScript file (`.js`)](#load-a-script-from-an-external-javascript-file-js)
* [Inject a script before or after Blazor starts](#inject-a-script-before-or-after-blazor-starts)

> [!WARNING]
> Don't place a `<script>` tag in a Razor component file (`.razor`) because the `<script>` tag can't be updated dynamically by Blazor.

> [!NOTE]
> Documentation examples usually place scripts in a `<script>` tag or load global scripts from external files. These approaches pollute the client with global functions. For production apps, we recommend placing JavaScript into separate [JavaScript modules](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Modules) that can be imported when needed. For more information, see the [JavaScript isolation in JavaScript modules](#javascript-isolation-in-javascript-modules) section.

### Load a script in `<head>` markup

*The approach in this section isn't generally recommended.*

Place the JavaScript (JS) tags (`<script>...</script>`) in the `<head>` element markup of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

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

### Load a script in `<body>` markup

Place the JavaScript (JS) tags (`<script>...</script>`) inside the closing `</body>` element markup of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

```html
<body>
    ...

    <script src="_framework/blazor.{server|webassembly}.js"></script>
    <script>
      window.jsMethod = (methodParameter) => {
        ...
      };
    </script>
</body>
```

The `{server|webassembly}` placeholder in the preceding markup is either `server` for a Blazor Server app (`blazor.server.js`) or `webassembly` for a Blazor WebAssembly app (`blazor.webassembly.js`).

### Load a script from an external JavaScript file (`.js`) collocated with a component

[!INCLUDE[](~/includes/js-collocation.md)]

For more information on RCLs, see <xref:blazor/components/class-libraries>.

### Load a script from an external JavaScript file (`.js`)

Place the JavaScript (JS) tags (`<script>...</script>`) with a script source (`src`) path inside the closing `</body>` tag after the Blazor script reference.

In `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

```html
<body>
    ...

    <script src="_framework/blazor.{server|webassembly}.js"></script>
    <script src="{SCRIPT PATH AND FILE NAME (.js)}"></script>
</body>
```

The `{server|webassembly}` placeholder in the preceding markup is either `server` for a Blazor Server app (`blazor.server.js`) or `webassembly` for a Blazor WebAssembly app (`blazor.webassembly.js`). The `{SCRIPT PATH AND FILE NAME (.js)}` placeholder is the path and script file name under `wwwroot`.

In the following example of the preceding `<script>` tag, the `scripts.js` file is in the `wwwroot/js` folder of the app:

```html
<script src="js/scripts.js"></script>
```

When the external JS file is supplied by a [Razor class library](xref:blazor/components/class-libraries), specify the JS file using its stable static web asset path: `./_content/{PACKAGE ID}/{SCRIPT PATH AND FILE NAME (.js)}`:

* The path segment for the current directory (`./`) is required in order to create the correct static asset path to the JS file.
* The `{PACKAGE ID}` placeholder is the library's [package ID](/nuget/create-packages/creating-a-package-msbuild#set-properties). The package ID defaults to the project's assembly name if `<PackageId>` isn't specified in the project file.
* The `{SCRIPT PATH AND FILE NAME (.js)}` placeholder is the path and file name under `wwwroot`.

```html
<body>
    ...

    <script src="_framework/blazor.{server|webassembly}.js"></script>
    <script src="./_content/{PACKAGE ID}/{SCRIPT PATH AND FILE NAME (.js)}"></script>
</body>
```

In the following example of the preceding `<script>` tag:

* The Razor class library has an assembly name of `ComponentLibrary`, and a `<PackageId>` isn't specified in the library's project file.
* The `scripts.js` file is in the class library's `wwwroot` folder.

```html
<script src="./_content/ComponentLibrary/scripts.js"></script>
```

For more information, see <xref:blazor/components/class-libraries>.

### Inject a script before or after Blazor starts

To ensure scripts load before or after Blazor starts, use a JavaScript initializer. For more information and examples, see <xref:blazor/fundamentals/startup#javascript-initializers>.

## JavaScript isolation in JavaScript modules

Blazor enables JavaScript (JS) isolation in standard [JavaScript modules](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Modules) ([ECMAScript specification](https://tc39.es/ecma262/#sec-modules)).

JS isolation provides the following benefits:

* Imported JS no longer pollutes the global namespace.
* Consumers of a library and components aren't required to import the related JS.

For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet#javascript-isolation-in-javascript-modules>.

## Cached JavaScript files

JavaScript (JS) files and other static assets aren't generally cached on clients during development in the [`Development` environment](xref:fundamentals/index#environments). During development, static asset requests include the [`Cache-Control` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control) with a value of [`no-cache`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control#cacheability) or [`max-age`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control#expiration) with a value of zero (`0`).

During production in the [`Production` environment](xref:fundamentals/index#environments), JS files are usually cached by clients.

To disable client-side caching in browsers, developers usually adopt one of the following approaches:

* Disable caching when the browser's developer tools console is open. Guidance can be found in the developer tools documentation of each browser maintainer:
  * [Chrome DevTools](https://developer.chrome.com/docs/devtools/)
  * [Firefox Developer Tools](https://developer.mozilla.org/docs/Tools)
  * [Microsoft Edge Developer Tools overview](/microsoft-edge/devtools-guide-chromium/)
* Perform a manual browser refresh of any webpage of the Blazor app to reload JS files from the server. ASP.NET Core's HTTP Caching Middleware always honors a valid no-cache [`Cache-Control` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control) sent by a client.

For more information, see:

* <xref:blazor/fundamentals/environments>
* <xref:performance/caching/response>

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

A Blazor app can invoke JavaScript (JS) functions from .NET methods and .NET methods from JS functions. These scenarios are called *JavaScript interoperability* (*JS interop*).

Further JS interop guidance is provided in the following articles:

* <xref:blazor/js-interop/call-javascript-from-dotnet>
* <xref:blazor/js-interop/call-dotnet-from-javascript>

## JavaScript interop abstractions and features package

The [`@microsoft/dotnet-js-interop` package (`npmjs.com`)](https://www.npmjs.com/package/@microsoft/dotnet-js-interop) provides abstractions and features for interop between .NET and JavaScript (JS) code. Reference source is available in the [`dotnet/aspnetcore` GitHub repository (`/src/JSInterop` folder)](https://github.com/dotnet/aspnetcore/tree/main/src/JSInterop). For more information, see the GitHub repository's `README.md` file.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

Additional resources for writing JS interop scripts in TypeScript:

* [TypeScript](https://www.typescriptlang.org/)
* [Tutorial: Create an ASP.NET Core app with TypeScript in Visual Studio](/visualstudio/javascript/tutorial-aspnet-with-typescript)
* [Manage npm packages in Visual Studio](/visualstudio/javascript/npm-package-management)

## Interaction with the Document Object Model (DOM)

Only mutate the Document Object Model (DOM) with JavaScript (JS) when the object doesn't interact with Blazor. Blazor maintains representations of the DOM and interacts directly with DOM objects. If an element rendered by Blazor is modified externally using JS directly or via JS Interop, the DOM may no longer match Blazor's internal representation, which can result in undefined behavior. Undefined behavior may merely interfere with the presentation of elements or their functions but may also introduce security risks to the app or server.

This guidance not only applies to your own JS interop code but also to any JS libraries that the app uses, including anything provided by a third-party framework, such as [Bootstrap JS](https://getbootstrap.com/) and [jQuery](https://jquery.com/).

In a few documentation examples, JS interop is used to mutate an element *purely for demonstration purposes* as part of an example. In those cases, a warning appears in the text.

For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet#capture-references-to-elements>.

## Asynchronous JavaScript calls

JS interop calls are asynchronous by default, regardless of whether the called code is synchronous or asynchronous. Calls are asynchronous by default to ensure that components are compatible across both Blazor hosting models, Blazor Server and Blazor WebAssembly. On Blazor Server, JS interop calls must be asynchronous because they're sent over a network connection. For apps that exclusively adopt the Blazor WebAssembly hosting model, synchronous JS interop calls are supported.

For more information, see the following articles:

* <xref:blazor/js-interop/call-javascript-from-dotnet#synchronous-js-interop-in-blazor-webassembly-apps>
* <xref:blazor/js-interop/call-dotnet-from-javascript#synchronous-js-interop-in-blazor-webassembly-apps>

## Object serialization

Blazor uses <xref:System.Text.Json?displayProperty=fullName> for serialization with the following requirements and default behaviors:

* Types must have a default constructor, [`get`/`set` accessors](/dotnet/csharp/programming-guide/classes-and-structs/using-properties) must be public, and fields are never serialized.
* Global default serialization isn't customizable to avoid breaking existing component libraries, impacts on performance and security, and reductions in reliability.
* Serializing .NET member names results in lowercase JSON key names.
* JSON is deserialized as <xref:System.Text.Json.JsonElement> C# instances, which permit mixed casing. Internal casting for assignment to C# model properties works as expected in spite of any case differences between JSON key names and C# property names.

<xref:System.Text.Json.Serialization.JsonConverter> API is available for custom serialization. Properties can be annotated with a [`[JsonConverter]` attribute](xref:System.Text.Json.Serialization.JsonConverterAttribute) to override default serialization for an existing data type.

For more information, see the following resources in the .NET documentation:

* [JSON serialization and deserialization (marshalling and unmarshalling) in .NET](/dotnet/standard/serialization/system-text-json-overview)
* [How to customize property names and values with `System.Text.Json`](/dotnet/standard/serialization/system-text-json-customize-properties)
* [How to write custom converters for JSON serialization (marshalling) in .NET](/dotnet/standard/serialization/system-text-json-converters-how-to)

Blazor supports optimized byte array JS interop that avoids encoding/decoding byte arrays into Base64. The app can apply custom serialization and pass the resulting bytes. For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet#byte-array-support>.

Blazor supports unmarshalled JS interop when a high volume of .NET objects are rapidly serialized or when large .NET objects or many .NET objects must be serialized. For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet#unmarshalled-javascript-interop>.

## Location of JavaScript

Load JavaScript (JS) code using any of the following approaches:

* [Load a script in `<head>` markup](#load-a-script-in-head-markup) (*Not generally recommended*)
* [Load a script in `<body>` markup](#load-a-script-in-body-markup)
* [Load a script from an external JavaScript file (`.js`) collocated with a component](#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component)
* [Load a script from an external JavaScript file (`.js`)](#load-a-script-from-an-external-javascript-file-js)
* [Inject a script before or after Blazor starts](#inject-a-script-before-or-after-blazor-starts)

> [!WARNING]
> Don't place a `<script>` tag in a Razor component file (`.razor`) because the `<script>` tag can't be updated dynamically by Blazor.

> [!NOTE]
> Documentation examples usually place scripts in a `<script>` tag or load global scripts from external files. These approaches pollute the client with global functions. For production apps, we recommend placing JavaScript into separate [JavaScript modules](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Modules) that can be imported when needed. For more information, see the [JavaScript isolation in JavaScript modules](#javascript-isolation-in-javascript-modules) section.

### Load a script in `<head>` markup

*The approach in this section isn't generally recommended.*

Place the JavaScript (JS) tags (`<script>...</script>`) in the `<head>` element markup of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Layout.cshtml` (Blazor Server):

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

### Load a script in `<body>` markup

Place the JavaScript (JS) tags (`<script>...</script>`) inside the closing `</body>` element markup of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Layout.cshtml` (Blazor Server):

```html
<body>
    ...

    <script src="_framework/blazor.{server|webassembly}.js"></script>
    <script>
      window.jsMethod = (methodParameter) => {
        ...
      };
    </script>
</body>
```

The `{server|webassembly}` placeholder in the preceding markup is either `server` for a Blazor Server app (`blazor.server.js`) or `webassembly` for a Blazor WebAssembly app (`blazor.webassembly.js`).

### Load a script from an external JavaScript file (`.js`) collocated with a component

[!INCLUDE[](~/includes/js-collocation.md)]

For more information on RCLs, see <xref:blazor/components/class-libraries>.

### Load a script from an external JavaScript file (`.js`)

Place the JavaScript (JS) tags (`<script>...</script>`) with a script source (`src`) path inside the closing `</body>` tag after the Blazor script reference.

In `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Layout.cshtml` (Blazor Server):

```html
<body>
    ...

    <script src="_framework/blazor.{server|webassembly}.js"></script>
    <script src="{SCRIPT PATH AND FILE NAME (.js)}"></script>
</body>
```

The `{server|webassembly}` placeholder in the preceding markup is either `server` for a Blazor Server app (`blazor.server.js`) or `webassembly` for a Blazor WebAssembly app (`blazor.webassembly.js`). The `{SCRIPT PATH AND FILE NAME (.js)}` placeholder is the path and script file name under `wwwroot`.

In the following example of the preceding `<script>` tag, the `scripts.js` file is in the `wwwroot/js` folder of the app:

```html
<script src="js/scripts.js"></script>
```

When the external JS file is supplied by a [Razor class library](xref:blazor/components/class-libraries), specify the JS file using its stable static web asset path: `./_content/{PACKAGE ID}/{SCRIPT PATH AND FILE NAME (.js)}`:

* The path segment for the current directory (`./`) is required in order to create the correct static asset path to the JS file.
* The `{PACKAGE ID}` placeholder is the library's [package ID](/nuget/create-packages/creating-a-package-msbuild#set-properties). The package ID defaults to the project's assembly name if `<PackageId>` isn't specified in the project file.
* The `{SCRIPT PATH AND FILE NAME (.js)}` placeholder is the path and file name under `wwwroot`.

```html
<body>
    ...

    <script src="_framework/blazor.{server|webassembly}.js"></script>
    <script src="./_content/{PACKAGE ID}/{SCRIPT PATH AND FILE NAME (.js)}"></script>
</body>
```

In the following example of the preceding `<script>` tag:

* The Razor class library has an assembly name of `ComponentLibrary`, and a `<PackageId>` isn't specified in the library's project file.
* The `scripts.js` file is in the class library's `wwwroot` folder.

```html
<script src="./_content/ComponentLibrary/scripts.js"></script>
```

For more information, see <xref:blazor/components/class-libraries>.

### Inject a script before or after Blazor starts

To ensure scripts load before or after Blazor starts, use a JavaScript initializer. For more information and examples, see <xref:blazor/fundamentals/startup#javascript-initializers>.

## JavaScript isolation in JavaScript modules

Blazor enables JavaScript (JS) isolation in standard [JavaScript modules](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Modules) ([ECMAScript specification](https://tc39.es/ecma262/#sec-modules)).

JS isolation provides the following benefits:

* Imported JS no longer pollutes the global namespace.
* Consumers of a library and components aren't required to import the related JS.

For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet#javascript-isolation-in-javascript-modules>.

## Cached JavaScript files

JavaScript (JS) files and other static assets aren't generally cached on clients during development in the [`Development` environment](xref:fundamentals/index#environments). During development, static asset requests include the [`Cache-Control` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control) with a value of [`no-cache`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control#cacheability) or [`max-age`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control#expiration) with a value of zero (`0`).

During production in the [`Production` environment](xref:fundamentals/index#environments), JS files are usually cached by clients.

To disable client-side caching in browsers, developers usually adopt one of the following approaches:

* Disable caching when the browser's developer tools console is open. Guidance can be found in the developer tools documentation of each browser maintainer:
  * [Chrome DevTools](https://developer.chrome.com/docs/devtools/)
  * [Firefox Developer Tools](https://developer.mozilla.org/docs/Tools)
  * [Microsoft Edge Developer Tools overview](/microsoft-edge/devtools-guide-chromium/)
* Perform a manual browser refresh of any webpage of the Blazor app to reload JS files from the server. ASP.NET Core's HTTP Caching Middleware always honors a valid no-cache [`Cache-Control` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control) sent by a client.

For more information, see:

* <xref:blazor/fundamentals/environments>
* <xref:performance/caching/response>

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

A Blazor app can invoke JavaScript (JS) functions from .NET methods and .NET methods from JS functions. These scenarios are called *JavaScript interoperability* (*JS interop*).

This overview article covers general concepts. Further JS interop guidance is provided in the following articles:

* <xref:blazor/js-interop/call-javascript-from-dotnet>
* <xref:blazor/js-interop/call-dotnet-from-javascript>

## JavaScript interop abstractions and features package

The [`@microsoft/dotnet-js-interop` package (`npmjs.com`)](https://www.npmjs.com/package/@microsoft/dotnet-js-interop) provides abstractions and features for interop between .NET and JavaScript (JS) code. Reference source is available in the [`dotnet/aspnetcore` GitHub repository (`/src/JSInterop` folder)](https://github.com/dotnet/aspnetcore/tree/main/src/JSInterop). For more information, see the GitHub repository's `README.md` file.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

Additional resources for writing JS interop scripts in TypeScript:

* [TypeScript](https://www.typescriptlang.org/)
* [Tutorial: Create an ASP.NET Core app with TypeScript in Visual Studio](/visualstudio/javascript/tutorial-aspnet-with-typescript)
* [Manage npm packages in Visual Studio](/visualstudio/javascript/npm-package-management)

## Interaction with the Document Object Model (DOM)

Only mutate the Document Object Model (DOM) with JavaScript (JS) when the object doesn't interact with Blazor. Blazor maintains representations of the DOM and interacts directly with DOM objects. If an element rendered by Blazor is modified externally using JS directly or via JS Interop, the DOM may no longer match Blazor's internal representation, which can result in undefined behavior. Undefined behavior may merely interfere with the presentation of elements or their functions but may also introduce security risks to the app or server.

This guidance not only applies to your own JS interop code but also to any JS libraries that the app uses, including anything provided by a third-party framework, such as [Bootstrap JS](https://getbootstrap.com/) and [jQuery](https://jquery.com/).

In a few documentation examples, JS interop is used to mutate an element *purely for demonstration purposes* as part of an example. In those cases, a warning appears in the text.

For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet#capture-references-to-elements>.

## Asynchronous JavaScript calls

JS interop calls are asynchronous by default, regardless of whether the called code is synchronous or asynchronous. Calls are asynchronous by default to ensure that components are compatible across both Blazor hosting models, Blazor Server and Blazor WebAssembly. On Blazor Server, JS interop calls must be asynchronous because they're sent over a network connection. For apps that exclusively adopt the Blazor WebAssembly hosting model, synchronous JS interop calls are supported.

For more information, see the following articles:

* <xref:blazor/js-interop/call-javascript-from-dotnet#synchronous-js-interop-in-blazor-webassembly-apps>
* <xref:blazor/js-interop/call-dotnet-from-javascript#synchronous-js-interop-in-blazor-webassembly-apps>

## Object serialization

Blazor uses <xref:System.Text.Json?displayProperty=fullName> for serialization with the following requirements and default behaviors:

* Types must have a default constructor, [`get`/`set` accessors](/dotnet/csharp/programming-guide/classes-and-structs/using-properties) must be public, and fields are never serialized.
* Global default serialization isn't customizable to avoid breaking existing component libraries, impacts on performance and security, and reductions in reliability.
* Serializing .NET member names results in lowercase JSON key names.
* JSON is deserialized as <xref:System.Text.Json.JsonElement> C# instances, which permit mixed casing. Internal casting for assignment to C# model properties works as expected in spite of any case differences between JSON key names and C# property names.

<xref:System.Text.Json.Serialization.JsonConverter> API is available for custom serialization. Properties can be annotated with a [`[JsonConverter]` attribute](xref:System.Text.Json.Serialization.JsonConverterAttribute) to override default serialization for an existing data type.

For more information, see the following resources in the .NET documentation:

* [JSON serialization and deserialization (marshalling and unmarshalling) in .NET](/dotnet/standard/serialization/system-text-json-overview)
* [How to customize property names and values with `System.Text.Json`](/dotnet/standard/serialization/system-text-json-customize-properties)
* [How to write custom converters for JSON serialization (marshalling) in .NET](/dotnet/standard/serialization/system-text-json-converters-how-to)

Blazor supports unmarshalled JS interop when a high volume of .NET objects are rapidly serialized or when large .NET objects or many .NET objects must be serialized. For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet#unmarshalled-javascript-interop>.

## Location of JavaScript

Load JavaScript (JS) code using any of the following approaches:

* [Load a script in `<head>` markup](#load-a-script-in-head-markup) (*Not generally recommended*)
* [Load a script in `<body>` markup](#load-a-script-in-body-markup)
* [Load a script from an external JavaScript file (`.js`)](#load-a-script-from-an-external-javascript-file-js)
* [Inject a script after Blazor starts](#inject-a-script-after-blazor-starts)

> [!WARNING]
> Don't place a `<script>` tag in a Razor component file (`.razor`) because the `<script>` tag can't be updated dynamically by Blazor.

> [!NOTE]
> Documentation examples usually place scripts in a `<script>` tag or load global scripts from external files. These approaches pollute the client with global functions. For production apps, we recommend placing JavaScript into separate [JavaScript modules](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Modules) that can be imported when needed. For more information, see the [JavaScript isolation in JavaScript modules](#javascript-isolation-in-javascript-modules) section.

### Load a script in `<head>` markup

*The approach in this section isn't generally recommended.*

Place the script (`<script>...</script>`) in the `<head>` element markup of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

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

### Load a script in `<body>` markup

Place the script (`<script>...</script>`) inside the closing `</body>` element markup of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

```html
<body>
    ...

    <script src="_framework/blazor.{server|webassembly}.js"></script>
    <script>
      window.jsMethod = (methodParameter) => {
        ...
      };
    </script>
</body>
```

The `{server|webassembly}` placeholder in the preceding markup is either `server` for a Blazor Server app (`blazor.server.js`) or `webassembly` for a Blazor WebAssembly app (`blazor.webassembly.js`).

### Load a script from an external JavaScript file (`.js`)

Place the script (`<script>...</script>`) with a script `src` path inside the closing `</body>` tag after the Blazor script reference.

In `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

```html
<body>
    ...

    <script src="_framework/blazor.{server|webassembly}.js"></script>
    <script src="{SCRIPT PATH AND FILE NAME (.js)}"></script>
</body>
```

The `{server|webassembly}` placeholder in the preceding markup is either `server` for a Blazor Server app (`blazor.server.js`) or `webassembly` for a Blazor WebAssembly app (`blazor.webassembly.js`). The `{SCRIPT PATH AND FILE NAME (.js)}` placeholder is the path and script file name under `wwwroot`.

In the following example of the preceding `<script>` tag, the `scripts.js` file is in the `wwwroot/js` folder of the app:

```html
<script src="js/scripts.js"></script>
```

When the external JS file is supplied by a [Razor class library](xref:blazor/components/class-libraries), specify the JS file using its stable static web asset path: `./_content/{PACKAGE ID}/{SCRIPT PATH AND FILE NAME (.js)}`:

* The path segment for the current directory (`./`) is required in order to create the correct static asset path to the JS file.
* The `{PACKAGE ID}` placeholder is the library's [package ID](/nuget/create-packages/creating-a-package-msbuild#set-properties). The package ID defaults to the project's assembly name if `<PackageId>` isn't specified in the project file.
* The `{SCRIPT PATH AND FILE NAME (.js)}` placeholder is the path and file name under `wwwroot`.

```html
<body>
    ...

    <script src="_framework/blazor.{server|webassembly}.js"></script>
    <script src="./_content/{PACKAGE ID}/{SCRIPT PATH AND FILE NAME (.js)}"></script>
</body>
```

In the following example of the preceding `<script>` tag:

* The Razor class library has an assembly name of `ComponentLibrary`, and a `<PackageId>` isn't specified in the library's project file.
* The `scripts.js` file is in the class library's `wwwroot` folder.

```html
<script src="./_content/ComponentLibrary/scripts.js"></script>
```

For more information, see <xref:blazor/components/class-libraries>.

### Inject a script after Blazor starts

To inject a script after Blazor starts, chain to the `Promise` that results from a manual start of Blazor. For more information and an example, see <xref:blazor/fundamentals/startup#inject-a-script-after-blazor-starts>.

## JavaScript isolation in JavaScript modules

Blazor enables JavaScript (JS) isolation in standard [JavaScript modules](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Modules) ([ECMAScript specification](https://tc39.es/ecma262/#sec-modules)). JavaScript module loading works the same way in Blazor as it does for other types of web apps, and you're free to customize how modules are defined in your app. For a guide on how to use JavaScript modules, see [MDN Web Docs: JavaScript modules](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Modules).

JS isolation provides the following benefits:

* Imported JS no longer pollutes the global namespace.
* Consumers of a library and components aren't required to import the related JS.

For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet#javascript-isolation-in-javascript-modules>.

[Dynamic import with the `import()` operator](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Operators/import) is supported with ASP.NET Core and Blazor:

```javascript
if ({CONDITION}) import("/additionalModule.js");
```

In the preceding example, the `{CONDITION}` placeholder represents a conditional check to determine if the module should be loaded.

For browser compatibility, see [Can I use: JavaScript modules: dynamic import](https://caniuse.com/es6-module-dynamic-import).

## Cached JavaScript files

JavaScript (JS) files and other static assets aren't generally cached on clients during development in the [`Development` environment](xref:fundamentals/index#environments). During development, static asset requests include the [`Cache-Control` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control) with a value of [`no-cache`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control#cacheability) or [`max-age`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control#expiration) with a value of zero (`0`).

During production in the [`Production` environment](xref:fundamentals/index#environments), JS files are usually cached by clients.

To disable client-side caching in browsers, developers usually adopt one of the following approaches:

* Disable caching when the browser's developer tools console is open. Guidance can be found in the developer tools documentation of each browser maintainer:
  * [Chrome DevTools](https://developer.chrome.com/docs/devtools/)
  * [Firefox Developer Tools](https://developer.mozilla.org/docs/Tools)
  * [Microsoft Edge Developer Tools overview](/microsoft-edge/devtools-guide-chromium/)
* Perform a manual browser refresh of any webpage of the Blazor app to reload JS files from the server. ASP.NET Core's HTTP Caching Middleware always honors a valid no-cache [`Cache-Control` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control) sent by a client.

For more information, see:

* <xref:blazor/fundamentals/environments>
* <xref:performance/caching/response>

:::moniker-end

:::moniker range="< aspnetcore-5.0"

A Blazor app can invoke JavaScript (JS) functions from .NET methods and .NET methods from JS functions. These scenarios are called *JavaScript interoperability* (*JS interop*).

This overview article covers general concepts. Further JS interop guidance is provided in the following articles:

* <xref:blazor/js-interop/call-javascript-from-dotnet>
* <xref:blazor/js-interop/call-dotnet-from-javascript>

## JavaScript interop abstractions and features package

The [`@microsoft/dotnet-js-interop` package (`npmjs.com`)](https://www.npmjs.com/package/@microsoft/dotnet-js-interop) provides abstractions and features for interop between .NET and JavaScript (JS) code. Reference source is available in the [`dotnet/aspnetcore` GitHub repository (`/src/JSInterop` folder)](https://github.com/dotnet/aspnetcore/tree/main/src/JSInterop). For more information, see the GitHub repository's `README.md` file.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

Additional resources for writing JS interop scripts in TypeScript:

* [TypeScript](https://www.typescriptlang.org/)
* [Tutorial: Create an ASP.NET Core app with TypeScript in Visual Studio](/visualstudio/javascript/tutorial-aspnet-with-typescript)
* [Manage npm packages in Visual Studio](/visualstudio/javascript/npm-package-management)

## Interaction with the Document Object Model (DOM)

Only mutate the Document Object Model (DOM) with JavaScript (JS) when the object doesn't interact with Blazor. Blazor maintains representations of the DOM and interacts directly with DOM objects. If an element rendered by Blazor is modified externally using JS directly or via JS Interop, the DOM may no longer match Blazor's internal representation, which can result in undefined behavior. Undefined behavior may merely interfere with the presentation of elements or their functions but may also introduce security risks to the app or server.

This guidance not only applies to your own JS interop code but also to any JS libraries that the app uses, including anything provided by a third-party framework, such as [Bootstrap JS](https://getbootstrap.com/) and [jQuery](https://jquery.com/).

In a few documentation examples, JS interop is used to mutate an element *purely for demonstration purposes* as part of an example. In those cases, a warning appears in the text.

For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet#capture-references-to-elements>.

## Asynchronous JavaScript calls

JS interop calls are asynchronous by default, regardless of whether the called code is synchronous or asynchronous. Calls are asynchronous by default to ensure that components are compatible across both Blazor hosting models, Blazor Server and Blazor WebAssembly. On Blazor Server, JS interop calls must be asynchronous because they're sent over a network connection. For apps that exclusively adopt the Blazor WebAssembly hosting model, synchronous JS interop calls are supported.

For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet#synchronous-js-interop-in-blazor-webassembly-apps>.

## Object serialization

Blazor uses <xref:System.Text.Json?displayProperty=fullName> for serialization with the following requirements and default behaviors:

* Types must have a default constructor, [`get`/`set` accessors](/dotnet/csharp/programming-guide/classes-and-structs/using-properties) must be public, and fields are never serialized.
* Global default serialization isn't customizable to avoid breaking existing component libraries, impacts on performance and security, and reductions in reliability.
* Serializing .NET member names results in lowercase JSON key names.
* JSON is deserialized as <xref:System.Text.Json.JsonElement> C# instances, which permit mixed casing. Internal casting for assignment to C# model properties works as expected in spite of any case differences between JSON key names and C# property names.

<xref:System.Text.Json.Serialization.JsonConverter> API is available for custom serialization. Properties can be annotated with a [`[JsonConverter]` attribute](xref:System.Text.Json.Serialization.JsonConverterAttribute) to override default serialization for an existing data type.

For more information, see the following resources in the .NET documentation:

* [JSON serialization and deserialization (marshalling and unmarshalling) in .NET](/dotnet/standard/serialization/system-text-json-overview)
* [How to customize property names and values with `System.Text.Json`](/dotnet/standard/serialization/system-text-json-customize-properties)
* [How to write custom converters for JSON serialization (marshalling) in .NET](/dotnet/standard/serialization/system-text-json-converters-how-to)

## Location of JavaScript

Load JavaScript (JS) code using any of the following approaches:

* [Load a script in `<head>` markup](#load-a-script-in-head-markup) (*Not generally recommended*)
* [Load a script in `<body>` markup](#load-a-script-in-body-markup)
* [Load a script from an external JavaScript file (`.js`)](#load-a-script-from-an-external-javascript-file-js)
* [Inject a script after Blazor starts](#inject-a-script-after-blazor-starts)

> [!WARNING]
> Don't place a `<script>` tag in a Razor component file (`.razor`) because the `<script>` tag can't be updated dynamically by Blazor.

> [!NOTE]
> Documentation examples place scripts into a `<script>` tag or load global scripts from external files. These approaches pollute the client with global functions. Placing JavaScript into separate [JavaScript modules](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Modules) that can be imported when needed is **not** supported in Blazor earlier than ASP.NET Core 5.0. If the app requires the use of JS modules for JS isolation, we recommend using ASP.NET Core 5.0 or later to build the app. For more information, use the **Version** dropdown list to select a 5.0 or later version of this article and see the *JavaScript isolation in JavaScript modules* section.

### Load a script in `<head>` markup

*The approach in this section isn't generally recommended.*

Place the script (`<script>...</script>`) in the `<head>` element markup of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

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

### Load a script in `<body>` markup

Place the script (`<script>...</script>`) inside the closing `</body>` element markup of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

```html
<body>
    ...

    <script src="_framework/blazor.{server|webassembly}.js"></script>
    <script>
      window.jsMethod = (methodParameter) => {
        ...
      };
    </script>
</body>
```

The `{server|webassembly}` placeholder in the preceding markup is either `server` for a Blazor Server app (`blazor.server.js`) or `webassembly` for a Blazor WebAssembly app (`blazor.webassembly.js`).

### Load a script from an external JavaScript file (`.js`)

Place the script (`<script>...</script>`) with a script `src` path inside the closing `</body>` tag after the Blazor script reference.

In `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

```html
<body>
    ...

    <script src="_framework/blazor.{server|webassembly}.js"></script>
    <script src="{SCRIPT PATH AND FILE NAME (.js)}"></script>
</body>
```

The `{server|webassembly}` placeholder in the preceding markup is either `server` for a Blazor Server app (`blazor.server.js`) or `webassembly` for a Blazor WebAssembly app (`blazor.webassembly.js`). The `{SCRIPT PATH AND FILE NAME (.js)}` placeholder is the path and script file name under `wwwroot`.

In the following example of the preceding `<script>` tag, the `scripts.js` file is in the `wwwroot/js` folder of the app:

```html
<script src="js/scripts.js"></script>
```

When the external JS file is supplied by a [Razor class library](xref:blazor/components/class-libraries), specify the JS file using its stable static web asset path: `./_content/{PACKAGE ID}/{SCRIPT PATH AND FILE NAME (.js)}`:

* The path segment for the current directory (`./`) is required in order to create the correct static asset path to the JS file.
* The `{PACKAGE ID}` placeholder is the library's [package ID](/nuget/create-packages/creating-a-package-msbuild#set-properties). The package ID defaults to the project's assembly name if `<PackageId>` isn't specified in the project file.
* The `{SCRIPT PATH AND FILE NAME (.js)}` placeholder is the path and file name under `wwwroot`.

```html
<body>
    ...

    <script src="_framework/blazor.{server|webassembly}.js"></script>
    <script src="./_content/{PACKAGE ID}/{SCRIPT PATH AND FILE NAME (.js)}"></script>
</body>
```

In the following example of the preceding `<script>` tag:

* The Razor class library has an assembly name of `ComponentLibrary`, and a `<PackageId>` isn't specified in the library's project file.
* The `scripts.js` file is in the class library's `wwwroot` folder.

```html
<script src="./_content/ComponentLibrary/scripts.js"></script>
```

For more information, see <xref:blazor/components/class-libraries>.

### Inject a script after Blazor starts

To inject a script after Blazor starts, chain to the `Promise` that results from a manual start of Blazor. For more information and an example, see <xref:blazor/fundamentals/startup#inject-a-script-after-blazor-starts>.

## Cached JavaScript files

JavaScript (JS) files and other static assets aren't generally cached on clients during development in the [`Development` environment](xref:fundamentals/index#environments). During development, static asset requests include the [`Cache-Control` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control) with a value of [`no-cache`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control#cacheability) or [`max-age`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control#expiration) with a value of zero (`0`).

During production in the [`Production` environment](xref:fundamentals/index#environments), JS files are usually cached by clients.

To disable client-side caching in browsers, developers usually adopt one of the following approaches:

* Disable caching when the browser's developer tools console is open. Guidance can be found in the developer tools documentation of each browser maintainer:
  * [Chrome DevTools](https://developer.chrome.com/docs/devtools/)
  * [Firefox Developer Tools](https://developer.mozilla.org/docs/Tools)
  * [Microsoft Edge Developer Tools overview](/microsoft-edge/devtools-guide-chromium/)
* Perform a manual browser refresh of any webpage of the Blazor app to reload JS files from the server. ASP.NET Core's HTTP Caching Middleware always honors a valid no-cache [`Cache-Control` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control) sent by a client.

For more information, see:

* <xref:blazor/fundamentals/environments>
* <xref:performance/caching/response>

:::moniker-end
