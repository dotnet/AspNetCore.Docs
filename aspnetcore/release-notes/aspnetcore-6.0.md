---
title: What's new in ASP.NET Core 6.0
author: rick-anderson
description: Learn about the new features in ASP.NET Core 6.0.
ms.author: riande
ms.custom: mvc
ms.date: 10/29/2021
no-loc: [Home, Privacy, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR, Kestrel]
uid: aspnetcore-6.0
---
# What's new in ASP.NET Core 6.0

This article highlights the most significant changes in ASP.NET Core 6.0 with links to relevant documentation.

## ASP.NET Core MVC and Razor improvements

## Minimal APIs

Minimal APIs are architected to create HTTP APIs with minimal dependencies. They are ideal for microservices and apps that want to include only the minimum files, features, and dependencies in ASP.NET Core. See <xref:tutorials/min-web-api> for more information.

## SignalR

### SignalR message size

Size limitations on SignalR message size for Blazor Server apps have been removed.

### Long running activity tag for SignalR connections

SignalR uses the new <xref:Microsoft.AspNetCore.Http.Features.IHttpActivityFeature.Activity?displayProperty=fullName> to add an `http.long_running` tag to the request activity. This will be used by [APM services](https://wikipedia.org/wiki/Application_performance_management) like [Azure Monitor Application Insights](/azure/azure-monitor/azure-monitor-app-hub) to filter SignalR requests from creating long running request alerts.

## Blazor

### Blazor WebAssembly native dependencies support

Blazor WebAssembly apps can use native dependencies built to run on WebAssembly. For more information, see <xref:blazor/host-and-deploy/webassembly?view=aspnetcore-6.0#native-dependencies-support>.

### WebAssembly Ahead-of-time (AOT) compilation and runtime relinking

Blazor WebAssembly supports ahead-of-time (AOT) compilation, where you can compile your .NET code directly into WebAssembly. AOT compilation results in runtime performance improvements at the expense of a larger app size. Relinking the .NET WebAssembly runtime trims unused runtime code and thus improves download speed. For more information, see [Ahead-of-time (AOT) compilation](xref:blazor/host-and-deploy/webassembly?view=aspnetcore-6.0#ahead-of-time-aot-compilation) and [Runtime Relinking](xref:blazor/host-and-deploy/webassembly?view=aspnetcore-6.0#runtime-relinking).

### Persist prerendering state

Blazor supports persisting state in a prerendered page so that the state doesn’t need to be recreated when the app is fully loaded. For more information, see <xref:blazor/components/prerendering-and-integration?view=aspnetcore-6.0&pivots=server#preserve-prerendered-state>.

### Error boundaries

Error boundaries provide a convenient approach for handling exceptions. For more information, see <xref:blazor/fundamentals/handle-errors?view=aspnetcore-6.0&pivots=server#error-boundaries>.

### SVG support

The [`<foreignObject>` element](https://developer.mozilla.org/docs/Web/SVG/Element/foreignObject) element is supported to display arbitrary HTML within an SVG. For more information, see <xref:blazor/components/index?view=aspnetcore-6.0#scalable-vector-graphics-svg-images>.

### Blazor Server support for byte-array transfer in JS Interop

Blazor supports optimized byte array JS interop that avoids encoding and decoding byte arrays into Base64. For more information, see the following resources:

* <xref:blazor/js-interop/call-javascript-from-dotnet?view=aspnetcore-6.0#byte-array-support>
* <xref:blazor/js-interop/call-dotnet-from-javascript?view=aspnetcore-6.0#byte-array-support>

### Query string enhancements

Support for working with query strings is improved. For more information, see <xref:blazor/fundamentals/routing?view=aspnetcore-6.0#query-strings>.

### Binding to select multiple

Binding supports multiple option selection with `<input>` elements. For more information, see the following resources:

* <xref:blazor/components/data-binding?view=aspnetcore-6.0#multiple-option-selection-with-input-elements>
* <xref:blazor/forms-validation?view=aspnetcore-6.0#multiple-option-selection-with-the-inputselect-component>

### Head (`<head>`) content control

Razor components can modify the HTML `<head>` element content of a page, including setting the page's title (`<title>` element) and modifying metadata (`<meta>` elements). For more information, see <xref:blazor/components/control-head-content?view=aspnetcore-6.0>.

### Generate Angular and React components

Generate framework-specific JavaScript components from Razor components for web frameworks, such as Angular or React. For more information, see <xref:blazor/components/index?view=aspnetcore-6.0#generate-angular-and-react-components>.

### Render components from JavaScript

Razor components can be dynamically-rendered from JavaScript for existing JavaScript apps. For more information, see <xref:blazor/components/index?view=aspnetcore-6.0#render-razor-components-from-javascript>.

### Custom elements

Experimental support is available for building custom elements, which use standard HTML interfaces. For more information, see <xref:blazor/components/index?view=aspnetcore-6.0#blazor-custom-elements>.

### Infer component generic types from ancestor components

An ancestor component can cascade a type parameter by name to descendants using the new `[CascadingTypeParameter]` attribute. For more information, see <xref:blazor/components/templated-components?view=aspnetcore-6.0#infer-generic-types-based-on-ancestor-components>.

### Dynamically rendered components

Use the new built-in `DynamicComponent` component to render components by type. For more information, see <xref:blazor/components/dynamiccomponent?view=aspnetcore-6.0>.

### Improved Blazor accessibility

Use the new `FocusOnNavigate` component to set the UI focus to an element based on a CSS selector after navigating from one page to another. For more information, see <xref:blazor/fundamentals/routing?view=aspnetcore-6.0#focus-an-element-on-navigation>.

### Custom event argument support

Blazor supports custom event arguments, which enable you to pass arbitrary data to .NET event handlers with custom events. For more information, see <xref:blazor/components/event-handling?view=aspnetcore-6.0#custom-event-arguments>.

### Required parameters

Apply the new `[EditorRequired]` attribute to specify a required component parameter. For more information, see <xref:blazor/components/index?view=aspnetcore-6.0#component-parameters>.

### Collocation of JavaScript files with pages, views, and components

Collocate JavaScript (JS) files for pages, views, and Razor components as a convenient way to organize scripts in an app. For more information, see <xref:blazor/js-interop/index?view=aspnetcore-6.0#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component>.

### JavaScript initializers

JavaScript initializers execute logic before and after a Blazor app loads. For more information, see <xref:blazor/js-interop/index?view=aspnetcore-6.0# javascript-initializers>.

### Streaming JavaScript interop

Blazor now supports streaming data directly between .NET and JavaScript. For more information, see the following resources:

* [Stream from .NET to JavaScript](xref:blazor/js-interop/call-javascript-from-dotnet?view=aspnetcore-6.0#stream-from-net-to-javascript)
* [Stream from JavaScript to .NET](xref:blazor/js-interop/call-javascript-from-dotnet?view=aspnetcore-6.0#stream-from-javascript-to-net)

### Generic type constraints

Generic type parameters are now supported. For more information, see <xref:blazor/components/index?view=aspnetcore-6.0#generic-type-parameter-support>.

### WebAssembly deployment layout

Use a deployment layout to enable Blazor WebAssembly app downloads in restricted security environments. For more information, see <xref:blazor/host-and-deploy/webassembly-deployment-layout?view=aspnetcore-6.0>.

<!-- HOLD

### Blazor WebAssembly packaging

HOLD

### Dynamically added root components

HOLD

### Blazor hybrid desktop apps (.NET MAUI)

HOLD
-->

## Kestrel

See <xref:fundamentals/servers/kestrel/http3> and the blog entry [HTTP/3 support in .NET 6](https://devblogs.microsoft.com/dotnet/http-3-support-in-dotnet-6/).

### New Kestrel logging categories for selected logging

Prior to this change, enabling verbose logging for Kestrel was prohibitively expensive as all of Kestrel shared the `Microsoft.AspNetCore.Server.Kestrel` logging category name. `Microsoft.AspNetCore.Server.Kestrel` is still available, but the following new subcategories allow for more control of logging:

* `Microsoft.AspNetCore.Server.Kestrel` (current category): `ApplicationError`, `ConnectionHeadResponseBodyWrite`, `ApplicationNeverCompleted`, `RequestBodyStart`, `RequestBodyDone`, `RequestBodyNotEntirelyRead`, `RequestBodyDrainTimedOut`, `ResponseMinimumDataRateNotSatisfied`, `InvalidResponseHeaderRemoved`, `HeartbeatSlow`.
* `Microsoft.AspNetCore.Server.Kestrel.BadRequests`: `ConnectionBadRequest`, `RequestProcessingError`, `RequestBodyMinimumDataRateNotSatisfied`.
* `Microsoft.AspNetCore.Server.Kestrel.Connections`: `ConnectionAccepted`, `ConnectionStart`, `ConnectionStop`, `ConnectionPause`, `ConnectionResume`, `ConnectionKeepAlive`, `ConnectionRejected`, `ConnectionDisconnect`, `NotAllConnectionsClosedGracefully`, `NotAllConnectionsAborted`, `ApplicationAbortedConnection`.
* `Microsoft.AspNetCore.Server.Kestrel.Http2`: `Http2ConnectionError`, `Http2ConnectionClosing`, `Http2ConnectionClosed`, `Http2StreamError`, `Http2StreamResetAbort`, `HPackDecodingError`, `HPackEncodingError`, `Http2FrameReceived`, `Http2FrameSending`, `Http2MaxConcurrentStreamsReached`.
* `Microsoft.AspNetCore.Server.Kestrel.Http3`: `Http3ConnectionError`, `Http3ConnectionClosing`, `Http3ConnectionClosed`, `Http3StreamAbort`, `Http3FrameReceived`, `Http3FrameSending`.

Existing rules continue to work, but you can now be more selective on which rules you enable. For example, the observability overhead of enabling `Debug` logging for just bad requests is greatly reduced and can be enabled with the following configuration:

[!code-xml[](aspnetcore-6.0/samples/WebApp1/appsettings.Test.json?highlight=6)]

Log filtering applies rules with the longest matching category prefix. For more information, see [How filtering rules are applied](xref:fundamentals/logging/index?view=aspnetcore-6.0#how-filtering-rules-are-applied)

### Emit KestrelServerOptions via EventSource event

The [KestrelEventSource](https://github.com/dotnet/aspnetcore/blob/v6.0.0-rc.2.21480.10/src/Servers/Kestrel/Core/src/Internal/Infrastructure/KestrelEventSource.cs) emits a new event containing the JSON-serialized <xref:Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions> when enabled with verbosity `EventLevel.LogAlways`. This event makes it easier to reason about the server behavior when analyzing collected traces. The following JSON is an example of the event payload:

```json
{
  "AllowSynchronousIO": false,
  "AddServerHeader": true,
  "AllowAlternateSchemes": false,
  "AllowResponseHeaderCompression": true,
  "EnableAltSvc": false,
  "IsDevCertLoaded": true,
  "RequestHeaderEncodingSelector": "default",
  "ResponseHeaderEncodingSelector": "default",
  "Limits": {
    "KeepAliveTimeout": "00:02:10",
    "MaxConcurrentConnections": null,
    "MaxConcurrentUpgradedConnections": null,
    "MaxRequestBodySize": 30000000,
    "MaxRequestBufferSize": 1048576,
    "MaxRequestHeaderCount": 100,
    "MaxRequestHeadersTotalSize": 32768,
    "MaxRequestLineSize": 8192,
    "MaxResponseBufferSize": 65536,
    "MinRequestBodyDataRate": "Bytes per second: 240, Grace Period: 00:00:05",
    "MinResponseDataRate": "Bytes per second: 240, Grace Period: 00:00:05",
    "RequestHeadersTimeout": "00:00:30",
    "Http2": {
      "MaxStreamsPerConnection": 100,
      "HeaderTableSize": 4096,
      "MaxFrameSize": 16384,
      "MaxRequestHeaderFieldSize": 16384,
      "InitialConnectionWindowSize": 131072,
      "InitialStreamWindowSize": 98304,
      "KeepAlivePingDelay": "10675199.02:48:05.4775807",
      "KeepAlivePingTimeout": "00:00:20"
    },
    "Http3": {
      "HeaderTableSize": 0,
      "MaxRequestHeaderFieldSize": 16384
    }
  },
  "ListenOptions": [
    {
      "Address": "https://127.0.0.1:7030",
      "IsTls": true,
      "Protocols": "Http1AndHttp2"
    },
    {
      "Address": "https://[::1]:7030",
      "IsTls": true,
      "Protocols": "Http1AndHttp2"
    },
    {
      "Address": "http://127.0.0.1:5030",
      "IsTls": false,
      "Protocols": "Http1AndHttp2"
    },
    {
      "Address": "http://[::1]:5030",
      "IsTls": false,
      "Protocols": "Http1AndHttp2"
    }
  ]
}
```

### New DiagnosticSource event for rejected HTTP requests

Kestrel now emits a new `DiagnosticSource` event for HTTP requests rejected at the server layer. Prior to this change, there was no way to observe these rejected requests. The new `DiagnosticSource` event `Microsoft.AspNetCore.Server.Kestrel.BadRequest` contains a <xref:Microsoft.AspNetCore.Http.Features.IBadRequestExceptionFeature> that can be used to introspect the reason for rejecting the request.

[!code-csharp[](aspnetcore-6.0/samples/WebApp1/Program.cs?name=snippet_diag)]

For more information, see <xref:fundamentals/servers/kestrel/diagnostics>.

### Create a ConnectionContext from an Accept Socket

The new <xref:Microsoft.AspNetCore.Server.Kestrel.Transport.Sockets.SocketConnectionContextFactory> makes it possible to create a <xref:Microsoft.AspNetCore.Connections.ConnectionContext> from an accepted socket. This makes it possible to build a custom socket-based <xref:Microsoft.AspNetCore.Connections.IConnectionListenerFactory> without losing out on all the performance work and pooling happening in [SocketConnection](https://github.com/dotnet/aspnetcore/blob/v6.0.0-rc.2.21480.10/src/Servers/Kestrel/Transport.Sockets/src/Internal/SocketConnection.cs).

See [this example of a custom IConnectionListenerFactory](https://github.com/davidfowl/TcpProxy/blob/main/Backend/DelegatedConnectionListenerFactory.cs) which shows how to use this `SocketConnectionContextFactory`.

### Kestrel is the default launch profile for Visual Studio

The default launch profile for all new dotnet web projects is Kestrel. tarting Kestrel is significantly faster and results in a more responsive experience while developing apps.

IIS Express is still available as a launch profile for scenarios such as Windows Authentication or port sharing.

### Localhost ports for Kestrel are random

See [Template generated ports for Kestrel](#tgp) in this document for more information.

## Authentication and authorization

### Authentication servers

.NET 3 to .NET 5 used [IdentityServer4](https://identityserver4.readthedocs.io/latest/) as part of our template to support the issuing of JWT tokens for SPA and Blazor applications. The templates now use the [Duende Identity Server](https://docs.duendesoftware.com/identityserver/v5).

If you are extending the identity models and are updating existing projects you will need to update the namespaces in your code from `IdentityServer4.IdentityServer` to `Duende.IdentityServer` and follow their [migration instructions](https://docs.duendesoftware.com/identityserver/v5/upgrades/).

The license model for Duende Identity Server has changed to a reciprocal license, which may require license fees when it's used commercially in production. See the [Duende license page](https://duendesoftware.com/products/identityserver#pricing) for more details.

### Delayed client certificate negotiation

Developers can now opt-in to using delayed client certificate negotiation by specifying [ClientCertificateMode.DelayCertificate](xref:Microsoft.AspNetCore.Server.Kestrel.Https.ClientCertificateMode.DelayCertificate) on the <xref:Microsoft.AspNetCore.Server.Kestrel.Https.HttpsConnectionAdapterOptions>. This only works with HTTP/1.1 connections because HTTP/2 strictly forbids delayed certificate renegotiation. The caller of this API must buffer the request body before requesting the client certificate.

[!code-csharp[](aspnetcore-6.0/samples/WebApp1/Program.cs?name=snippert_dcrt)]

### `OnCheckSlidingExpiration` event for controlling cookie renewal

Cookie authentication sliding expiration can now be customized or suppressed using the new <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.OnCheckSlidingExpiration>. For example, this event can be used by a single-page app that needs to periodically ping the server without affecting the authentication session.

## API improvements

## Miscellaneous

### Hot reload

Quickly make UI and code updates to running apps without losing app state for faster and more productive developer experience using [Hot reload](https://devblogs.microsoft.com/dotnet/introducing-net-hot-reload/). For more information, see [Update on .NET Hot Reload progress and Visual Studio 2022 Highlights](https://devblogs.microsoft.com/dotnet/update-on-net-hot-reload-progress-and-visual-studio-2022-highlights/).

<!-- Notes:
### Single-file publishing
Moved to .NET 7 https://github.com/dotnet/aspnetcore/issues/27888#event-5487147790
-->

### Improved single-page app (SPA) templates

The ASP.NET Core project templates have been updated for Angular and React to use a improved pattern for single-page apps that is more flexible and more closely aligns with common patterns for modern front-end web development.

Previously, the ASP.NET Core template for Angular and React used specialized middleware during development to launch the development server for the front-end framework and then proxy requests from ASP.NET Core to the development server. The logic for launching the front-end development server was specific to the command-line interface for the corresponding front-end framework. Supporting additional front-end frameworks using this pattern meant adding additional logic to ASP.NET Core.

The updated ASP.NET Core templates for Angular and React in .NET 6 flips this arrangement around and take advantage of the built-in proxying support in the development servers of most modern front-end frameworks. When the ASP.NET Core app is launched, the front-end development server is launched just as before, but the development server is configured to proxy requests to the backend ASP.NET Core process. All of the front-end specific configuration to setup proxying is part of the app, not ASP.NET Core. Setting up ASP.NET Core projects to work with other front-end frameworks is now straight-forward: setup the front-end development server for the chosen framework to proxy to the ASP.NET Core backend using the pattern established in the Angular and React templates.

The startup code for the ASP.NET Core app no longer needs any single-page app specific logic. The logic for starting the front-end development server during development is injecting into the app at runtime by the new [Microsoft.AspNetCore.SpaProxy](https://www.nuget.org/packages/microsoft.aspnetcore.spaproxy) package. Fallback routing is handled using endpoint routing instead of SPA specific middleware.

Templates that follow this pattern can still be run as a single project in Visual Studio or using `dotnet run` from the command-line. When the app is published, the front-end code in the *ClientApp* folder is built and collected as before into the web root of the host ASP.NET Core app and served as static files. Scripts included in the template configure the front-end development server to use HTTPS using the ASP.NET Core development certificate.

### Single-page app (SPA) support
<!-- TODO @LadyNaggaga to provide this section-->

### Draft HTTP/3 support in .NET 6

[HTTP/3](https://datatracker.ietf.org/doc/html/draft-ietf-quic-http-34) is currently in draft and therefore subject to change. HTTP/3 support in ASP.NET Core is not released, it's a preview feature included in .NET 6.

See the blog entry [HTTP/3 support in .NET 6](https://devblogs.microsoft.com/dotnet/http-3-support-in-dotnet-6/).

### Nullable Reference Type Annotations

Portions of the [ASP.NET Core 6.0 source code](https://github.com/dotnet/aspnetcore/tree/v6.0.0-rc.2.21480.10/src) has had [nullability annotations](/dotnet/csharp/nullable-migration-strategies) applied.

By utilizing the new Nullable feature in C# 8, ASP.NET Core can provide additional compile-time safety in the handling of reference types. For example, protecting against `null` reference exceptions. Projects that have opted in to using nullable annotations may see new build-time warnings from ASP.NET Core APIs.

To enable nullable reference types, add the following property to project files:

```xml
<PropertyGroup>
    <Nullable>enable</Nullable>
</PropertyGroup>
```

 For more information, see [Nullable reference types](/dotnet/csharp/nullable-references).

### Source Code Analysis

Several .NET compiler platform analyzers were added that inspect application code for problems such as incorrect middleware configuration or order, routing conflicts, etc. For more information, see <xref:diagnostics/code-analysis>.

### Web app template improvements

The web app templates:

* Use the new [minimal hosting model](xref:migration/50-to-60#new-hosting-model).
* Significantly reduces the number of files and lines of code required to create an app. Only one file is needed with four lines of code.
* Unifies `Startup.cs` and `Program.cs` into a single `Program.cs` file.
* Uses [top-level statements](/dotnet/csharp/fundamentals/program-structure/top-level-statements) to minimize the code required for an app.
* Uses [global `using` directives](/dotnet/csharp/whats-new/csharp-10#global-using-directives) to eliminate or minimize the number of [`using` statement](/dotnet/csharp/language-reference/keywords/using-statement) lines required.

<a name="tgp"></a>
### Template generated ports for Kestrel

Random ports are assigned during project creation for use by the Kestrel web server. Random ports help minimize a port conflict when multiple projects are run on the same machine.

When a project is created, a random HTTP port between 5000-5300 and a random HTTPS port between 7000-7300 is specified in the generated *Properties/launchSettings.json* file. The ports can be changed in the *Properties/launchSettings.json* file. If no port is specified, Kestrel  defaults to the HTTP 5000 and HTTPS 5001 ports. For more information, see <xref:fundamentals/servers/kestrel/endpoints>.

### New logging defaults

The following changes were made to both `appsettings.json` and `appsettings.Development.json`:

```diff
- "Microsoft": "Warning",
- "Microsoft.Hosting.Lifetime": "Information"
+ "Microsoft.AspNetCore": "Warning"
```

The change from `"Microsoft": "Warning"` to `"Microsoft.AspNetCore": "Warning"` results in logging all informational messages from the `Microsoft` namespace ***except*** `Microsoft.AspNetCore`. For example, `Microsoft.EntityFrameworkCore` is now logged at the informational level.

<!-- TODO add and routing -->
### Developer exception page Middleware added automatically

In the [develoment environment](xref:fundamentals/environments), the <xref:Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware> is added by default. It's no longer necessary to add the following code to web UI apps:

```csharp
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
```

### Support for Latin1 encoded request headers in HttpSysServer

`HttpSysServer` now supports decoding request headers that are `Latin1` encoded by setting the <xref:Microsoft.AspNetCore.Server.HttpSys.HttpSysOptions.UseLatin1RequestHeaders> property on <xref:Microsoft.AspNetCore.Server.HttpSys.HttpSysOptions> to `true`:

[!code-csharp[](aspnetcore-6.0/samples/WebApp1/Program.cs?name=snippet_latin)]

### The ASP.NET Core Module logs include timestamps and PID

The <xref:host-and-deploy/aspnet-core-module> (ANCM) enhanced diagnostic logs include timestamps and [PID](https://wikipedia.org/wiki/Process_identifier) of the process emitting the logs. Logging timestamps and PID makes it easier to diagnose issues with overlapping process restarts in IIS when multiple IIS worker processes are running.

The resulting logs now resemble the sample output show below:

```dotnetcli
[2021-07-28T19:23:44.076Z, PID: 11020] [aspnetcorev2.dll] Initializing logs for 'C:\<path>\aspnetcorev2.dll'. Process Id: 11020. File Version: 16.0.21209.0. Description: IIS ASP.NET Core Module V2. Commit: 96475a2acdf50d7599ba8e96583fa73efbe27912.
[2021-07-28T19:23:44.079Z, PID: 11020] [aspnetcorev2.dll] Resolving hostfxr parameters for application: '.\InProcessWebSite.exe' arguments: '' path: 'C:\Temp\e86ac4e9ced24bb6bacf1a9415e70753\'
[2021-07-28T19:23:44.080Z, PID: 11020] [aspnetcorev2.dll] Known dotnet.exe location: ''
```

### Configurable unconsumed incoming buffer size for IIS

the IIS server only buffered 64 KiB of unconsumed request bodies. This resulted in reads being constrained to that maximum size, which impacts the performance when large incoming bodies such as large uploads. In .NET 6 Preview 5, we’ve changed the default buffer size from 64 KiB to 1 MiB which should result in improved throughput for large uploads. In our tests, a 700 MiB upload that used to take 9 seconds now only takes 2.5 seconds.

The downside of a larger buffer size is an increased per-request memory consumption when the app isn’t quickly reading from the request body. So, in addition to changing the default buffer size, we’ve also made the buffer size configurable, allowing you to tune it based on your workload.

### View Components Tag Helpers

Consider a view component with an optional parameter, as shown in the following code:

```csharp
class MyViewComponent
{
    IViewComponentResult Invoke(bool showSomething = false) { ... }
}
```

With ASP.NET Core 6, the tag helper can be invoked without having to specify a value for the `showSomething` parameter:

```razor
<vc:my />
```

### Angular template updated to Angular 12

The ASP.NET Core 6.0 template for Angular now uses [Angular 12](https://blog.angular.io/angular-v12-is-now-available-32ed51fbfd49).

### Configurable buffer threshold before writing to disk in Json.NET input formatter

**Note**: We recommend using the <xref:System.Text.Json?displayProperty=fullName> input formatter the `Newtonsoft.Json` serializer is required for compatibility reasons. The `System.Text.Json` serializer is fully `async` and will work efficiently for larger payloads.

The `Newtonsoft.Json` input formatter by default buffers responses up to 32 KiB in memory before buffering to disk. This is to avoid performing synchronous IO, which can result in other side-effects such as thread starvation and application deadlocks. However, if the response is larger than 32 KiB, considerable disk I/O occurs. The memory threshold is now configurable before buffering to disk.

### Faster get and set for HTTP headers

New APIs were added to expose all common headers available on <!--REVIEW: System.Net.Http.HeaderNames changed to --> <xref:Microsoft.Net.Http.Headers.HeaderNames?displayProperty=fullName> as properties on the <xref:Microsoft.AspNetCore.Http.IHeaderDictionary> resulting in an easier to use API. For example, the in-line middleware in the following code gets and sets both request and response headers using the new APIs:

[!code-csharp[](aspnetcore-6.0/samples/WebApp1/Program.cs?name=snippet_hdrs)]

For implemented headers the get and set accessors are implemented by going directly to the field and bypassing the lookup. For non-implemented headers, the accessors can bypass the initial lookup against implemented headers and directly perform the `Dictionary<string, StringValues>` lookup. Avoiding the lookup results in faster access for both scenarios.

### Async streaming

<!-- from: https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-net-6-preview-4/#async-streaming -->
<!-- TODO Review: removed all the way down to the : what does that mean? WHat else? -->

ASP.NET Core now supports asynchronous streaming from controller actions and responses from the JSON formatter. Returning an `IAsyncEnumerable` from an action no longer buffers the response content in memory before it gets sent. This helps reduce memory usage when returning large datasets that can be asynchronously enumerated.

Note that Entity Framework Core provides implementations of `IAsyncEnumerable` for querying the database. The improved support for `IAsyncEnumerable` in ASP.NET Core in .NET 6 can make using EF Core with ASP.NET Core more efficient. For example, the following code will no longer buffer the product data into memory before sending the response:

[!code-csharp[](aspnetcore-6.0/samples/WebMvcEF/Controllers/MoviesController.cs?name=snippet1)]

However, when using lazy loading in EF Core, this new behavior may result in errors due to concurrent query execution while the data is being enumerated. Apps can revert back to the previous behavior by buffering the data:

[!code-csharp[](aspnetcore-6.0/samples/WebMvcEF/Controllers/MoviesController.cs?name=snippet2)]

See the related [announcement](https://github.com/aspnet/Announcements/issues/463) for additional details about this change in behavior.

### HTTP logging middleware

HTTP logging is a new built-in middleware that logs information about HTTP requests and HTTP responses including the headers and entire body:

[!code-csharp[](aspnetcore-6.0/samples/WebApp1/Program.cs?name=snippet_httplg&highlight=4)]

Navigating to `/` with the previous code logs infomation similar to the following:

```dotnetcli
info: Microsoft.AspNetCore.HttpLogging.HttpLoggingMiddleware[1]
      Request:
      Protocol: HTTP/2
      Method: GET
      Scheme: https
      PathBase: 
      Path: /
      Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9
      Accept-Encoding: gzip, deflate, br
      Accept-Language: en-US,en;q=0.9
      Cache-Control: max-age=0
      Connection: close
      Cookie: [Redacted]
      Host: localhost:44372
      User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/95.0.4638.54 Safari/537.36 Edg/95.0.1020.30
      sec-ch-ua: [Redacted]
      sec-ch-ua-mobile: [Redacted]
      sec-ch-ua-platform: [Redacted]
      upgrade-insecure-requests: [Redacted]
      sec-fetch-site: [Redacted]
      sec-fetch-mode: [Redacted]
      sec-fetch-user: [Redacted]
      sec-fetch-dest: [Redacted]
info: Microsoft.AspNetCore.HttpLogging.HttpLoggingMiddleware[2]
      Response:
      StatusCode: 200
      Content-Type: text/plain; charset=utf-8
```

The preceding output was enabled with the following *appsettings.development.json* file:

[!code-json[](aspnetcore-6.0/samples/WebApp1/appsettings.development.json?highlight=6)]

HTTP logging provides logs of:

* HTTP Request information
* Common properties
* Headers
* Body
* HTTP Response information

To configure the HTTP logging middleware, specify <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions>:

[!code-csharp[](aspnetcore-6.0/samples/WebApp1/Program.cs?name=snippet_httplg2&highlight=1,4-13)]

### IConnectionSocketFeature

The <xref:Microsoft.AspNetCore.Connections.Features.IConnectionSocketFeature> request feature provides access to the underlying accept socket associated with the current request. It can be accessed via the <xref:Microsoft.AspNetCore.Http.Features.FeatureCollection> on `HttpContext`.

For example, the following app sets the <xref:System.Net.Sockets.Socket.LingerState> property on the accepted socket:

<!-- TODO FIX code -->

[!code-csharp[](aspnetcore-6.0/samples/WebApp1/Program.cs?name=snippet_icsf)]

### .NET Hot Reload

<!--TODO @LyalinDotCom to provide this section -->
Hot Reload minimizes the number of app restarts after code changes. For more information, see [Update on .NET Hot Reload progress and Visual Studio 2022 Highlights](https://devblogs.microsoft.com/dotnet/update-on-net-hot-reload-progress-and-visual-studio-2022-highlights/)