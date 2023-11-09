---
title: What's new in ASP.NET Core 8.0
author: rick-anderson
description: Learn about the new features in ASP.NET Core 8.0.
ms.author: riande
ms.custom: mvc
ms.date: 11/7/2023
uid: aspnetcore-8
---
# What's new in ASP.NET Core 8.0

This article highlights the most significant changes in ASP.NET Core 8.0 with links to relevant documentation.

## Blazor

### Full-stack web UI

With the release of .NET 8, Blazor is a full-stack web UI framework for developing apps that render content at either the component or page level with:

* Static server rendering to generate static HTML.
* Interactive server rendering using the Blazor Server hosting model.
* Interactive client rendering using the Blazor WebAssembly hosting model.
* Automatic interactive client rendering using Blazor Server initially and then WebAssembly on subsequent visits after the Blazor bundle is downloaded and the .NET WebAssembly runtime activates. Automatic rendering usually provides the fastest app startup experience.

Interactive render modes also prerender content by default.

For more information, see <xref:blazor/components/render-modes?view=aspnetcore-8.0&preserve-view=true>.

### New Blazor Web App template

We've introduced a new Blazor project template: the *Blazor Web App* template. The new template provides a single starting point for using Blazor components to build any style of web UI. The template combines the strengths of the existing Blazor Server and Blazor WebAssembly hosting models with the new Blazor capabilities added in .NET 8: static server rendering, streaming rendering, enhanced navigation and form handling, and the ability to add interactivity using either Blazor Server or Blazor WebAssembly on a per-component basis.

As part of unifying the various Blazor hosting models into a single model in .NET 8, we're also consolidating the number of Blazor project templates. We removed the Blazor Server template, and the ASP.NET Core Hosted option has been removed from the Blazor WebAssembly template. Both of these scenarios are represented by options when using the Blazor Web App template.

> [!NOTE]
> Existing Blazor Server and Blazor WebAssembly apps remain supported in .NET 8. Optionally, these apps can be  updated to use the new full-stack web UI Blazor features.

For more information on the new Blazor Web App template, see the following articles:

* <xref:blazor/tooling?view=aspnetcore-8.0&pivots=windows&preserve-view=true>
* <xref:blazor/project-structure?view=aspnetcore-8.0&preserve-view=true>

### Persist component state in a Blazor Web App

You can persist and read component state in a Blazor Web App using the existing <xref:Microsoft.AspNetCore.Components.PersistentComponentState> service. This is useful for [persisting component state during prerendering](xref:blazor/components/prerender?view=aspnetcore-8.0&preserve-view=true#persist-prerendered-state). Blazor Web Apps automatically persist any registered state during prerendering, removing the need for the [Persist Component State Tag Helper](xref:mvc/views/tag-helpers/builtin-th/persist-component-state-tag-helper).

### Form handling and model binding

Blazor components can now handle submitted form requests, including model binding and validating the request data. Components can implement forms with separate form handlers using the standard HTML `<form>` tag or using the existing `EditForm` component.

Form model binding in Blazor honors the data contract attributes (for example, `[DataMember]` and `[IgnoreDataMember]`) for customizing how the form data is bound to the model.

New antiforgery support is included in .NET 8. A new `AntiforgeryToken` component renders an antiforgery token as a hidden field, and the new `[RequireAntiforgeryToken]` attribute enables antiforgery protection. If an antiforgery check fails, a 400 (Bad Request) response is returned without form processing. The new antiforgery features are enabled by default for forms based on `Editform` and can be applied manually to standard HTML forms.

For more information, see <xref:blazor/forms/index?view=aspnetcore-8.0&preserve-view=true>.

### Enhanced navigation and form handling

Static server rendering typically performs a full page refresh whenever the user navigates to a new page or submits a form. In .NET 8, Blazor can enhance page navigation and form handling by intercepting the request and performing a fetch request instead. Blazor then handles the rendered response content by patching it into the browser DOM. Enhanced navigation and form handling avoids the need for a full page refresh and preserves more of the page state, so pages load faster and more smoothly. Enhanced navigation is enabled by default when the Blazor script (`blazor.web.js`) is loaded. Enhanced form handling can be optionally enabled for specific forms.

New enhanced navigation API allows you to refresh the current page by calling `NavigationManager.Refresh(bool forceLoad = false)`.

For more information, see <xref:blazor/fundamentals/routing?view=aspnetcore-8.0&preserve-view=true#enhanced-navigation-and-form-handling>.

### Streaming rendering

You can now stream content updates on the response stream when using static server rendering with Blazor. Streaming rendering can improve the user experience for pages that perform long-running asynchronous tasks in order to fully render by rendering content as soon as it's available.

For example, to render a page you might need to make a long running database query or an API call. Normally, asynchronous tasks executed as part of rendering a page must complete before the rendered response is sent, which can delay loading the page. Streaming rendering initially renders the entire page with placeholder content while asynchronous operations execute. After the asynchronous operations are complete, the updated content is sent to the client on the same response connection and patched by into the DOM. The benefit of this approach is that the main layout of the app renders as quickly as possible and the page is updated as soon as the content is ready.

For more information, see <xref:blazor/components/rendering?view=aspnetcore-8.0&preserve-view=true#streaming-rendering>.

### Inject keyed services into components

Blazor now supports injecting keyed services using the `[Inject]` attribute. Keys allow for scoping of registration and consumption of services when using dependency injection. Use the new `InjectAttribute.Key` property to specify the key for the service to inject:

```csharp
[Inject(Key = "my-service")]
public IMyService MyService { get; set; }
```

The `@inject` Razor directive doesn't support keyed services yet, but work is tracked to improve this for a future release.

### Access `HttpContext` as a cascading parameter

You can now access the current <xref:Microsoft.AspNetCore.Http.HttpContext> as a cascading parameter from a static server component:

```csharp
[CascadingParameter]
public HttpContext? HttpContext { get; set; }
```

Accessing the <xref:Microsoft.AspNetCore.Http.HttpContext> from a static server component might be useful for inspecting and modifying headers or other properties.

For an example that passes <xref:Microsoft.AspNetCore.Http.HttpContext> state, access and refresh tokens, to components, see <xref:blazor/security/server/additional-scenarios?view=aspnetcore-8.0&preserve-view=true#pass-tokens-to-a-server-side-blazor-app>.

### Render Razor components outside of ASP.NET Core

You can now render Razor components outside the context of an HTTP request. You can render Razor components as HTML directly to a string or stream independently of the ASP.NET Core hosting environment. This is convenient for scenarios where you want to generate HTML fragments, such as for a generating email or static site content.

For more information, see <xref:blazor/components/render-outside-of-aspnetcore?view=aspnetcore-8.0&preserve-view=true>.

### Sections support

The new `SectionOutlet` and `SectionContent` components in Blazor add support for specifying outlets for content that can be filled in later. Sections are often used to define placeholders in layouts that are then filled in by specific pages. Sections are referenced either by a unique name or using a unique object ID.

For more information, see <xref:blazor/components/sections?view=aspnetcore-8.0&preserve-view=true>.

### Error page support

Blazor Web Apps can define a custom error page for use with the [ASP.NET Core exception handling middleware](xref:fundamentals/error-handling#exception-handler-page). The Blazor Web App project template includes a default error page (`Components/Pages/Error.razor`) with similar content to the one used in MVC and Razor Pages apps. When the error page is rendered in response to a request from Exception Handling Middleware, the error page always renders as a static server component, even if interactivity is otherwise enabled.

### QuickGrid

The Blazor QuickGrid component is no longer experimental and is now part of the Blazor framework in .NET 8.

QuickGrid is a high performance grid component for displaying data in tabular form. QuickGrid is built to be a simple and convenient way to display your data, while still providing powerful features, such as sorting, filtering, paging, and virtualization.

For more information, see <xref:blazor/components/quickgrid?view=aspnetcore-8.0&preserve-view=true>.

### Route to named elements

Blazor now supports using client-side routing to navigate to a specific HTML element on a page using standard URL fragments. If you specify an identifier for an HTML element using the standard `id` attribute, Blazor correctly scrolls to that element when the URL fragment matches the element identifier.

For more information, see <xref:blazor/fundamentals/routing?view=aspnetcore-8.0&preserve-view=true#hashed-routing-to-named-elements>.

### Root-level cascading values

Root-level cascading values can be registered for the entire component hierarchy. Named cascading values and subscriptions for update notifications are supported.

For more information, see <xref:blazor/components/cascading-values-and-parameters?view=aspnetcore-8.0&preserve-view=true#root-level-cascading-values>.

### Virtualize empty content

Use the new `EmptyContent` parameter on the `Virtualize` component to supply content when the component has loaded and either `Items` is empty or `ItemsProviderResult<T>.TotalItemCount` is zero.

For more information, see <xref:blazor/components/virtualization?view=aspnetcore-8.0&preserve-view=true#empty-content>.

### Close circuits when there are no remaining interactive server components

Interactive server components handle web UI events using a real-time connection with the browser called a circuit. A circuit and its associated state are set up when a root interactive server component is rendered. The circuit is closed when there are no remaining interactive server components on the page, which frees up server resources.

### Monitor SignalR circuit activity

You can now monitor inbound circuit activity in server-side apps using the new `CreateInboundActivityHandler` method on `CircuitHandler`. Inbound circuit activity is any activity sent from the browser to the server, such as UI events or JavaScript-to-.NET interop calls.

For more information, see <xref:blazor/fundamentals/signalr?view=aspnetcore-8.0&preserve-view=true#monitor-server-side-circuit-activity>.

### Faster runtime performance with the Jiterpreter

The *Jiterpreter* is a new runtime feature in .NET 8 that enables partial Just-in-Time (JIT) compilation support when running on WebAssembly to achieve improved runtime performance.

For more information, see <xref:blazor/host-and-deploy/webassembly?view=aspnetcore-8.0&preserve-view=true#ahead-of-time-aot-compilation>.

### Ahead-of-time (AOT) SIMD and exception handling

Blazor WebAssembly ahead-of-time (AOT) compilation now uses [WebAssembly Fixed-width SIMD](https://github.com/WebAssembly/simd/blob/master/proposals/simd/SIMD.md) and [WebAssembly Exception handling](https://github.com/WebAssembly/exception-handling/blob/master/proposals/exception-handling/Exceptions.md) by default to improve runtime performance.

For more information, see the following articles:

[AOT: Single Instruction, Multiple Data (SIMD)](xref:blazor/tooling?view=aspnetcore-8.0&pivots=windows&preserve-view=true#single-instruction-multiple-data-simd)
[AOT: Exception handling](xref:blazor/tooling?view=aspnetcore-8.0&pivots=windows&preserve-view=true#exception-handling)

### Web-friendly Webcil packaging

Webcil is web-friendly packaging of .NET assemblies that removes content specific to native Windows execution to avoid issues when deploying to environments that block the download or use of `.dll` files. Webcil is enabled by default for Blazor WebAssembly apps.

For more information, see <xref:blazor/host-and-deploy/webassembly?view=aspnetcore-8.0&preserve-view=true#webcil-packaging-format-for-net-assemblies>.

### Blazor WebAssembly debugging improvements

When debugging .NET on WebAssembly, the debugger now downloads symbol data from symbol locations that are configured in Visual Studio preferences. This improves the debugging experience for apps that use NuGet packages.

You can now debug Blazor WebAssembly apps using Firefox. Debugging Blazor WebAssembly apps requires configuring the browser for remote debugging and then connecting to the browser using the browser developer tools through the .NET WebAssembly debugging proxy. Debugging Firefox from Visual Studio isn't supported at this time.

For more information, see <xref:blazor/debug?view=aspnetcore-8.0&preserve-view=true#debug-with-firefox>.

### Content Security Policy (CSP) compatibility

Blazor WebAssembly no longer requires enabling the `unsafe-eval` script source when specifying a Content Security Policy (CSP).

For more information, see <xref:blazor/security/content-security-policy?view=aspnetcore-8.0&preserve-view=true>.

### Handle caught exceptions outside of a Razor component's lifecycle

Use `ComponentBase.DispatchExceptionAsync` in a Razor component to process exceptions thrown outside of the component's lifecycle call stack. This permits the component's code to treat exceptions as though they're lifecycle method exceptions. Thereafter, Blazor's error handling mechanisms, such as error boundaries, can process exceptions.

For more information, see <xref:blazor/fundamentals/handle-errors?view=aspnetcore-8.0&preserve-view=true#handle-caught-exceptions-outside-of-a-razor-components-lifecycle>.

### Configure the .NET WebAssembly runtime

The .NET WebAssembly runtime can now be configured for Blazor startup.

For more information, see <xref:blazor/fundamentals/startup?view=aspnetcore-8.0&preserve-view=true#configure-the-net-webAssembly-runtime>.

### Configuration of connection timeouts in `HubConnectionBuilder`

Prior workarounds for configuring hub connection timeouts can be replaced with formal SignalR hub connection builder timeout configuration.

For more information, see the following:

* <xref:blazor/fundamentals/signalr?view=aspnetcore-8.0&preserve-view=true#configure-signalr-timeouts-and-keep-alive-on-the-client>
* <xref:blazor/host-and-deploy/webassembly?view=aspnetcore-8.0&preserve-view=true#global-deployment-and-connection-failures>
* <xref:blazor/host-and-deploy/server?view=aspnetcore-8.0&preserve-view=true#global-deployment-and-connection-failures>

### Project templates shed Open Iconic

The Blazor project templates no longer depend on [Open Iconic](https://github.com/iconic/open-iconic) for icons.

### Support for dialog cancel and close events

Blazor now supports the [`cancel`](https://developer.mozilla.org/docs/Web/API/HTMLDialogElement/cancel_event) and [`close`](https://developer.mozilla.org/docs/Web/API/HTMLDialogElement/close_event) events on the `dialog` HTML element.

In the following example:

* `OnClose` is called when the `my-dialog` dialog is closed with the **Close** button.
* `OnCancel` is called when the dialog is canceled with the <kbd>Esc</kbd> key. When an HTML dialog is dismissed with the <kbd>Esc</kbd> key, both the `cancel` and `close` events are triggered.

```razor
<div>
    <p>Output: @message</p>

    <button onclick="document.getElementById('my-dialog').showModal()">
        Show modal dialog
    </button>

    <dialog id="my-dialog" @onclose="OnClose" @oncancel="OnCancel">
        <p>Hi there!</p>

        <form method="dialog">
            <button>Close</button>
        </form>
    </dialog>
</div>

@code {
    private string? message;

    private void OnClose(EventArgs e) => message += "onclose, ";

    private void OnCancel(EventArgs e) => message += "oncancel, ";
}
```

### Blazor Identity UI

Blazor supports generating a full Blazor-based Identity UI when you choose the authentication option for *Individual Accounts*. You can either select the option for Individual Accounts in the new project dialog for Blazor Web Apps from Visual Studio or pass the option from the command line when you create a new project:

```dotnetcli
dotnet new blazor -au Individual
```

In Visual Studio, the Blazor Web App template scaffolds Identity code for a SQL Server database. The command line version uses SQLite by default and includes a SQLite database for Identity.

The template handles the following:

* Adds the Identity-related packages and dependencies
* References the Identity packages in `_Imports.razor`
* Creates a custom Identity class called `ApplicationUser'
* Creates and registers an EFCore DbContext
* Adds and routes the built-in Identity endpoints
* Adds all Identity UI components and related logic
* Includes Identity validation and business logic

The UI components also support advanced Identity concepts, such as multifactor authentication using a third-party app and email confirmations.

Authentication samples for other app types are in development, including Blazor WebAssembly and single page apps (Angular, React).

## Blazor Server with Yarp routing

Routing and deep linking for Blazor Server with Yarp work correctly in .NET 8.

For more information, see <xref:migration/70-to-80#drop-blazor-server-with-yarp-routing-workaround>.

## SignalR

### New approach to set the server timeout and Keep-Alive interval

<xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.ServerTimeout> (default: 30 seconds) and <xref:Microsoft.AspNetCore.SignalR.Client.HubConnection.KeepAliveInterval> (default: 15 seconds) can be set directly on <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilder>.

#### Prior approach for JavaScript clients

The following example shows the assignment of values that are double the default values in ASP.NET Core 7.0 or earlier:

```javascript
var connection = new signalR.HubConnectionBuilder()
  .withUrl("/chatHub")
  .build();

connection.serverTimeoutInMilliseconds = 60000;
connection.keepAliveIntervalInMilliseconds = 30000;
```

#### New approach for JavaScript clients

The following example shows the ***new approach*** for assigning values that are double the default values in ASP.NET Core 8.0 or later:

```javascript
var connection = new signalR.HubConnectionBuilder()
  .withUrl("/chatHub")
  .withServerTimeoutInMilliseconds(60000)
  .withKeepAliveIntervalInMilliseconds(30000)
  .build();
```

#### Prior approach for the JavaScript client of a Blazor Server app

The following example shows the assignment of values that are double the default values in ASP.NET Core 7.0 or earlier:

```javascript
Blazor.start({
  configureSignalR: function (builder) {
    let c = builder.build();
    c.serverTimeoutInMilliseconds = 60000;
    c.keepAliveIntervalInMilliseconds = 30000;
    builder.build = () => {
      return c;
    };
  }
});
```

#### New approach for the JavaScript client of server-side Blazor app

The following example shows the ***new approach*** for assigning values that are double the default values in ASP.NET Core 8.0 or later for Blazor Web Apps and Blazor Server.

Blazor Web App:

```javascript
Blazor.start({
  circuit: {
    configureSignalR: function (builder) {
      builder.withServerTimeout(60000).withKeepAliveInterval(30000);
    }
  }
});
```

Blazor Server:

```javascript
Blazor.start({
  configureSignalR: function (builder) {
    builder.withServerTimeout(60000).withKeepAliveInterval(30000);
  }
});
```

#### Prior approach for .NET clients

The following example shows the assignment of values that are double the default values in ASP.NET Core 7.0 or earlier:

```csharp
var builder = new HubConnectionBuilder()
    .WithUrl(Navigation.ToAbsoluteUri("/chathub"))
    .Build();

builder.ServerTimeout = TimeSpan.FromSeconds(60);
builder.KeepAliveInterval = TimeSpan.FromSeconds(30);

builder.On<string, string>("ReceiveMessage", (user, message) => ...

await builder.StartAsync();
```

#### New approach for .NET clients

The following example shows the ***new approach*** for assigning values that are double the default values in ASP.NET Core 8.0 or later:

```csharp
var builder = new HubConnectionBuilder()
    .WithUrl(Navigation.ToAbsoluteUri("/chathub"))
    .WithServerTimeout(TimeSpan.FromSeconds(60))
    .WithKeepAliveInterval(TimeSpan.FromSeconds(30))
    .Build();

builder.On<string, string>("ReceiveMessage", (user, message) => ...

await builder.StartAsync();
```

### SignalR stateful reconnect

SignalR stateful reconnect reduces the perceived downtime of clients that have a temporary disconnect in their network connection, such as when switching network connections or a short temporary loss in access.

Stateful reconnect achieves this by:

* Temporarily buffering data on the server and client.
* Acknowledging messages received (ACK-ing) by both the server and client.
* Recognizing when a connection is returning and replaying messages that might have been sent while the connection was down.

Stateful reconnect is available in ASP.NET Core 8.0 and later.

Opt in to stateful reconnect at both the server hub endpoint and the client:

* Update the server hub endpoint configuration to enable the `AllowStatefulReconnects` option:

  ```csharp
  app.MapHub<MyHub>("/hubName", options =>
  {
      options.AllowStatefulReconnects = true;
  });
  ```

  Optionally, the maximum buffer size in bytes allowed by the server can be set globally or for a specific hub with the `StatefulReconnectBufferSize` option:

  The `StatefulReconnectBufferSize` option set globally:

  ```csharp
  builder.AddSignalR(o => o.StatefulReconnectBufferSize = 1000);
  ```

  The `StatefulReconnectBufferSize` option set for a specific hub:

  ```csharp
  builder.AddSignalR().AddHubOptions<MyHub>(o => o.StatefulReconnectBufferSize = 1000);
  ```

  The `StatefulReconnectBufferSize` option is optional with a default of 100,000 bytes.

* Update JavaScript or TypeScript client code to enable the `withStatefulReconnect` option:

  ```JavaScript
  const builder = new signalR.HubConnectionBuilder()
    .withUrl("/hubname")
    .withStatefulReconnect({ bufferSize: 1000 });  // Optional, defaults to 100,000
  const connection = builder.build();
  ```
  
  The `bufferSize` option is optional with a default of 100,000 bytes.
  
* Update .NET client code to enable the `WithStatefulReconnect` option:

  ```csharp
    var builder = new HubConnectionBuilder()
        .WithUrl("<hub url>")
        .WithStatefulReconnect();
    builder.Services.Configure<HubConnectionOptions>(o => o.StatefulReconnectBufferSize = 1000);
    var hubConnection = builder.Build();
  ```

  The `StatefulReconnectBufferSize` option is optional with a default of 100,000 bytes.

For more information, see [Configure stateful reconnect](xref:signalr/configuration#configure-stateful-reconnect).

## Minimal APIs

This section describes new features for minimal APIs. See also [the section on native AOT](#native-aot) for more information relevant to minimal APIs.

## User override culture

Starting in ASP.NET Core 8.0, the [RequestLocalizationOptions.CultureInfoUseUserOverride](xref:Microsoft.AspNetCore.Builder.RequestLocalizationOptions.CultureInfoUseUserOverride) property allows the application to decide whether or not to use nondefault Windows settings for the <xref:System.Globalization.CultureInfo> <xref:System.Globalization.CultureInfo.DateTimeFormat> and <xref:System.Globalization.CultureInfo.NumberFormat> properties. This has no impact on Linux. This directly corresponds to <xref:System.Globalization.CultureInfo.UseUserOverride>.

```csharp
    app.UseRequestLocalization(options =>
    {
        options.CultureInfoUseUserOverride = false;
    });
```

### Binding to forms

Explicit binding to form values using the [[FromForm]](xref:Microsoft.AspNetCore.Mvc.FromFormAttribute) attribute is now supported. Parameters bound to the request with `[FromForm]` include an [anti-forgery token](xref:security/anti-request-forgery). The anti-forgery token is validated when the request is processed.

Inferred binding to forms using the <xref:Microsoft.AspNetCore.Http.IFormCollection>, <xref:Microsoft.AspNetCore.Http.IFormFile>, and <xref:Microsoft.AspNetCore.Http.IFormFileCollection> types is also supported. [OpenAPI](xref:fundamentals/minimal-apis/openapi) metadata is inferred for form parameters to support integration with [Swagger UI](xref:tutorials/web-api-help-pages-using-swagger).

For more information, see:

* [Explicit binding from form values](xref:fundamentals/minimal-apis/parameter-binding?view=aspnetcore-8.0&preserve-view=true#explicit-binding-from-form-values).
* [Binding to forms with IFormCollection, IFormFile, and IFormFileCollection](xref:fundamentals/minimal-apis/parameter-binding?view=aspnetcore-8.0&preserve-view=true#binding-to-forms-with-iformcollection-iformfile-and-iformfilecollection).
* [Form binding in minimal APIs](https://andrewlock.net/exploring-the-dotnet-8-preview-form-binding-in-minimal-apis/)

Binding from forms is now supported for:

* Collections, for example [List](/dotnet/api/system.collections.generic.list-1) and [Dictionary](/dotnet/api/system.collections.generic.dictionary-2)
* Complex types, for example, `Todo` or `Project`

For more information, see [Bind to collections and complex types from forms](xref:fundamentals/minimal-apis/parameter-binding#bindcc).

### Antiforgery with Minimal APIs

This release adds a middleware for validating antiforgery tokens, which are used to mitigate cross-site request forgery attacks. Call [AddAntiforgery](/dotnet/api/microsoft.extensions.dependencyinjection.antiforgeryservicecollectionextensions.addantiforgery) to register antiforgery services in DI. `WebApplicationBuilder` automatically adds the middleware when the antiforgery services have been registered in the DI container. Antiforgery tokens are used to mitigate [cross-site request forgery attacks](xref:security/anti-request-forgery).

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/MyAntiForgery/Program.cs" id="snippet_short" highlight="3":::

The antiforgery middleware:

* Does ***not*** short-circuit the execution of the rest of the request pipeline.
* Sets the [IAntiforgeryValidationFeature](https://source.dot.net/#Microsoft.AspNetCore.Http.Features/IAntiforgeryValidationFeature.cs,33a7a0e106f11c6f) in the [HttpContext.Features](xref:Microsoft.AspNetCore.Http.HttpContext.Features) of the current request.

The antiforgery token is only validated if:

* The endpoint contains metadata implementing [IAntiforgeryMetadata](https://source.dot.net/#Microsoft.AspNetCore.Http.Abstractions/Metadata/IAntiforgeryMetadata.cs,5f49d4d07fc58320) where `RequiresValidation=true`.
* The HTTP method associated with the endpoint is a relevant [HTTP method](https://developer.mozilla.org/docs/Web/HTTP/Methods). The relevant methods are all [HTTP methods](https://developer.mozilla.org/docs/Web/HTTP/Methods) except for TRACE, OPTIONS, HEAD, and GET.
* The request is associated with a valid endpoint.

For more information, see [Antiforgery with Minimal APIs](xref:security/anti-request-forgery?view=aspnetcore-8.0&preserve-view=true#afwma).

### New `IResettable` interface in `ObjectPool`

[Microsoft.Extensions.ObjectPool](xref:Microsoft.Extensions.ObjectPool) provides support for pooling object instances in memory. Apps can use an object pool if the values are expensive to allocate or initialize.

In this release, we've made the object pool easier to use by adding the <xref:Microsoft.Extensions.ObjectPool.IResettable> interface. Reusable types often need to be reset back to a default state between uses. `IResettable` types are automatically reset when returned to an object pool.

For more information, see the [ObjectPool sample](xref:performance/ObjectPool##objectpool-sample).

## Native AOT

Support for [.NET native ahead-of-time (AOT)](/dotnet/core/deploying/native-aot/) has been added. Apps that are published using AOT can have substantially better performance: smaller app size, less memory usage, and faster startup time. Native AOT is currently supported by gRPC, minimal API, and worker service apps. For more information, see <xref:fundamentals/native-aot> and <xref:fundamentals/native-aot-tutorial>. For information about known issues with ASP.NET Core and native AOT compatibility, see GitHub issue [dotnet/core #8288](https://github.com/dotnet/core/issues/8288).

[!INCLUDE[](~/fundamentals/aot/includes/aot_lib.md)]

### New project template

The new **ASP.NET Core Web API (native AOT)** project template (short name `webapiaot`) creates a project with AOT publish enabled. For more information, see [The Web API (native AOT) template](xref:fundamentals/native-aot#the-web-api-native-aot-template).

### New `CreateSlimBuilder` method

The <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateSlimBuilder> method used in the Web API (native AOT) template initializes the <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> with the minimum ASP.NET Core features necessary to run an app. The `CreateSlimBuilder` method includes the following features that are typically needed for an efficient development experience:

* JSON file configuration for `appsettings.json` and `appsettings.{EnvironmentName}.json`.
* User secrets configuration.
* Console logging.
* Logging configuration.

For more information, see [The `CreateSlimBuilder` method](xref:fundamentals/native-aot#the-createslimbuilder-method).

### New `CreateEmptyBuilder` method

There's another new <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> factory method for building small apps that only contain necessary features: `WebApplication.CreateEmptyBuilder(WebApplicationOptions options)`. This `WebApplicationBuilder` is created with no built-in behavior. The app it builds contains only the services and middleware that are explicitly configured.

Here’s an example of using this API to create a small web application:

:::code language="csharp" source="~/release-notes/aspnetcore-8.0/samples/EmptyBuilderExample/Program.cs":::

Publishing this code with native AOT using .NET 8 Preview 7 on a linux-x64 machine results in a self-contained native executable of about 8.5 MB.

### Reduced app size with configurable HTTPS support

We've further reduced native AOT binary size for apps that don't need HTTPS or HTTP/3 support. Not using HTTPS or HTTP/3 is common for apps that run behind a TLS termination proxy (for example, hosted on Azure). The new `WebApplication.CreateSlimBuilder` method omits this functionality by default. It can be added by calling `builder.WebHost.UseKestrelHttpsConfiguration()` for HTTPS or `builder.WebHost.UseQuic()` for HTTP/3. For more information, see [The `CreateSlimBuilder` method](xref:fundamentals/native-aot#the-createslimbuilder-method).

### JSON serialization of compiler-generated `IAsyncEnumerable<T>` types

New features were added to <xref:System.Text.Json> to better support native AOT. These new features add capabilities for the source generation mode of `System.Text.Json`, because reflection isn't supported by AOT.

One of the new features is support for JSON serialization of <xref:System.Collections.Generic.IAsyncEnumerable%601> implementations implemented by the C# compiler. This support opens up their use in ASP.NET Core projects configured to publish native AOT.

This API is useful in scenarios where a route handler uses `yield return` to asynchronously return an enumeration. For example, to materialize rows from a database query. For more information, see [Unspeakable type support](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-4/#unspeakable-type-support) in the .NET 8 Preview 4 announcement.

For information abut other improvements in `System.Text.Json` source generation, see [Serialization improvements in .NET 8](/dotnet/core/whats-new/dotnet-8#serialization).

### Top-level APIs annotated for trim warnings

The main entry points to subsystems that don't work reliably with native AOT are now annotated. When these methods are called from an application with native AOT enabled, a warning is provided. For example, the following code produces a warning at the invocation of `AddControllers` because this API isn't trim-safe and isn't supported by native AOT.

:::image type="content" source="../fundamentals/aot/_static/top-level-annnotations.png" alt-text="Visual Studio window showing IL2026 warning message on the AddControllers method that says MVC doesn't currently support native AOT.":::

### Request delegate generator

In order to make Minimal APIs compatible with native AOT, we're introducing the Request Delegate Generator (RDG). The RDG is a source generator that does what the <xref:Microsoft.AspNetCore.Http.RequestDelegateFactory> (RDF) does. That is, it turns the various `MapGet()`, `MapPost()`, and calls like them into <xref:Microsoft.AspNetCore.Http.RequestDelegate> instances associated with the specified routes. But rather than doing it in-memory in an application when it starts, the RDG does it at compile time and generates C# code directly into the project. The RDG:

* Removes the runtime generation of this code.
* Ensures that the types used in APIs are statically analyzable by the native AOT tool-chain.
* Ensures that required code isn't trimmed away.

We're working to ensure that as many as possible of the Minimal API features are supported by the RDG and thus compatible with native AOT.

The RDG is enabled automatically in a project when publishing with native AOT is enabled. RDG can be manually enabled even when not using native AOT by setting `<EnableRequestDelegateGenerator>true</EnableRequestDelegateGenerator>` in the project file. This can be useful when initially evaluating a project's readiness for native AOT, or to reduce the startup time of an app.

### Improved performance using Interceptors

The Request Delegate Generator uses the new [C# 12 interceptors compiler feature](/dotnet/csharp/whats-new/csharp-12) to support intercepting calls to minimal API [Map](xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions) methods with statically generated variants at runtime. The use of interceptors results in increased startup performance for apps compiled with `PublishAot`.

### Logging and exception handling in compile-time generated minimal APIs

Minimal APIs generated at run time support automatically logging (or throwing exceptions in Development environments) when parameter binding fails. .NET 8 introduces the same support for APIs generated at compile time via the [Request Delegate Generator](#request-delegate-generator) (RDG). For more information, see [Logging and exception handling in compile-time generated minimal APIs](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-4/#logging-and-exception-handling-in-compile-time-generated-minimal-apis).

### AOT and System.Text.Json

Minimal APIs are optimized for receiving and returning JSON payloads using `System.Text.Json`, so the compatibility requirements for JSON and native AOT apply too. Native AOT compatibility requires the use of the `System.Text.Json` source generator. All types accepted as parameters to or returned from request delegates in Minimal APIs must be configured on a `JsonSerializerContext` that is registered via ASP.NET Core's dependency injection, for example:

```csharp
// Register the JSON serializer context with DI
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

...

// Add types used in the minimal API app to source generated JSON serializer content
[JsonSerializable(typeof(Todo[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
```

For more information about the <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolverChain> API, see the following resources:

* [JsonSerializerOptions.TypeInfoResolverChain](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-4/#jsonserializeroptions-typeinforesolverchain)
* [Chain source generators](/dotnet/core/whats-new/dotnet-8#chain-source-generators)
* [Changes to support source generation](xref:fundamentals/native-aot#changes-to-support-source-generation)

### Libraries and native AOT

Many of the common libraries available for ASP.NET Core projects today have some compatibility issues if used in a project targeting native AOT. Popular libraries often rely on the dynamic capabilities of .NET reflection to inspect and discover types, conditionally load libraries at runtime, and generate code on the fly to implement their functionality. These libraries need to be updated in order to work with native AOT by using tools like [Roslyn source generators](/dotnet/csharp/roslyn-sdk/source-generators-overview).

Library authors wishing to learn more about preparing their libraries for native AOT are encouraged to start by [preparing their library for trimming](/dotnet/core/deploying/trimming/prepare-libraries-for-trimming) and learning more about the [native AOT compatibility requirements](/dotnet/core/deploying/native-aot/).

## Kestrel and HTTP.sys servers

There are several new features for Kestrel and HTTP.sys.

### Support for named pipes in Kestrel

Named pipes is a popular technology for building inter-process communication (IPC) between Windows apps. You can now build an IPC server using .NET, Kestrel, and named pipes.

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenNamedPipe("MyPipeName");
});
```

For more information about this feature and how to use .NET and gRPC to create an IPC server and client, see <xref:grpc/interprocess>.

### Performance improvements to named pipes transport

We’ve improved named pipe connection performance. Kestrel’s named pipe transport now accepts connections in parallel, and reuses <xref:System.IO.Pipes.NamedPipeServerStream> instances.

Time to create 100,000 connections:

* Before : 5.916 seconds
* After &nbsp; : 2.374 seconds

### HTTP/2 over TLS (HTTPS) support on macOS in Kestrel

.NET 8 adds support for Application-Layer Protocol Negotiation (ALPN) to macOS. ALPN is a TLS feature used to negotiate which HTTP protocol a connection will use. For example, ALPN allows browsers and other HTTP clients to request an HTTP/2 connection. This feature is especially useful for gRPC apps, which require HTTP/2. For more information, see <xref:fundamentals/servers/kestrel/http2>.

### Warning when specified HTTP protocols won't be used

If TLS is disabled and HTTP/1.x is available, HTTP/2 and HTTP/3 will be disabled, even if they've been specified. This can cause some nasty surprises, so we've added warning output to let you know when it happens.

### `HTTP_PORTS` and `HTTPS_PORTS` config keys

Applications and containers are often only given a port to listen on, like 80, without additional constraints like host or path. `HTTP_PORTS` and `HTTPS_PORTS` are new config keys that allow specifying the listening ports for the Kestrel and HTTP.sys servers. These can be defined with the `DOTNET_` or `ASPNETCORE_` environment variable prefixes, or specified directly through any other config input like appsettings.json. Each is a semicolon delimited list of port values. For example:

```cli
ASPNETCORE_HTTP_PORTS=80;8080
ASPNETCORE_HTTPS_PORTS=443;8081
```

This is shorthand for the following, which specifies the scheme (HTTP or HTTPS) and any host or IP:

```cli
ASPNETCORE_URLS=http://*:80/;http://*:8080/;https://*:443/;https://*:8081/
```

For more information, see <xref:fundamentals/servers/kestrel/endpoints> and <xref:fundamentals/servers/httpsys>.

### SNI host name in ITlsHandshakeFeature

The Server Name Indication (SNI) host name is now exposed in the [HostName](https://source.dot.net/#Microsoft.AspNetCore.Connections.Abstractions/Features/ITlsHandshakeFeature.cs,29) property of the <xref:Microsoft.AspNetCore.Connections.Features.ITlsHandshakeFeature> interface.

SNI is part of the [TLS handshake](https://auth0.com/blog/the-tls-handshake-explained/) process. It allows clients to specify the host name they're attempting to connect to when the server hosts multiple virtual hosts or domains. To present the correct security certificate during the handshake process, the server needs to know the host name selected for each request. 

Normally the host name is only handled within the TLS stack and is used to select the matching certificate. But by exposing it, other components in an app can use that information for purposes such as diagnostics, rate limiting, routing, and billing.

Exposing the host name is useful for large-scale services managing thousands of SNI bindings. This feature can significantly improve debugging efficiency during customer escalations. The increased transparency allows for faster problem resolution and enhanced service reliability.

For more information, see [ITlsHandshakeFeature.HostName](https://source.dot.net/#Microsoft.AspNetCore.Connections.Abstractions/Features/ITlsHandshakeFeature.cs,30).

### IHttpSysRequestTimingFeature

[IHttpSysRequestTimingFeature](https://source.dot.net/#Microsoft.AspNetCore.Server.HttpSys/IHttpSysRequestTimingFeature.cs,3c5dc86dc837b1f4) provides detailed timing information for requests when using the [HTTP.sys server](xref:fundamentals/servers/httpsys) and [In-process hosting with IIS](xref:host-and-deploy/iis/in-process-hosting?view=aspnetcore-8.0&preserve-view=true#ihsrtf8):

* Timestamps are obtained using [QueryPerformanceCounter](/windows/win32/api/profileapi/nf-profileapi-queryperformancecounter).
* The timestamp frequency can be obtained via [QueryPerformanceFrequency](/windows/win32/api/profileapi/nf-profileapi-queryperformancefrequency).
* The index of the timing can be cast to [HttpSysRequestTimingType](https://source.dot.net/#Microsoft.AspNetCore.Server.HttpSys/HttpSysRequestTimingType.cs,e62e7bcd02f8589e) to know what the timing represents.
* The value might be 0 if the timing isn't available for the current request.

[IHttpSysRequestTimingFeature.TryGetTimestamp](https://source.dot.net/#Microsoft.AspNetCore.Server.HttpSys/IHttpSysRequestTimingFeature.cs,3c5dc86dc837b1f4) retrieves the timestamp for the provided timing type:

:::code language="csharp" source="~/fundamentals/request-features/samples/8.x/IHttpSysRequestTimingFeature/Program.cs" id="snippet_WithTryGetTimestamp":::

For more information, see [Get detailed timing information with IHttpSysRequestTimingFeature](xref:fundamentals/servers/httpsys?view=aspnetcore-8.0&preserve-view=true#ihsrtf8) and [Timing information and In-process hosting with IIS](xref:host-and-deploy/iis/in-process-hosting?view=aspnetcore-8.0&preserve-view=true#ihsrtf8).

### HTTP.sys: opt-in support for kernel-mode response buffering

In some scenarios, high volumes of small writes with high latency can cause significant performance impact to `HTTP.sys`. This impact is due to the lack of a <xref:System.IO.Pipelines.Pipe> buffer in the `HTTP.sys` implementation. To improve performance in these scenarios, support for response buffering has been added to `HTTP.sys`. Enable buffering by setting [HttpSysOptions.EnableKernelResponseBuffering](https://github.com/dotnet/aspnetcore/blob/main/src/Servers/HttpSys/src/HttpSysOptions.cs#L120) to `true`.

Response buffering should be enabled by an app that does synchronous I/O, or asynchronous I/O with no more than one outstanding write at a time. In these scenarios, response buffering can significantly improve throughput over high-latency connections.

Apps that use asynchronous I/O and that can have more than one write outstanding at a time should **_not_** use this flag. Enabling this flag can result in higher CPU and memory usage by HTTP.Sys.

## Authentication and authorization

ASP.NET Core 8 adds new features to authentication and authorization.

### Identity API endpoints

[`MapIdentityApi<TUser>`](https://source.dot.net/#Microsoft.AspNetCore.Identity/IdentityApiEndpointRouteBuilderExtensions.cs,32) is a new extension method that adds two API endpoints (`/register` and `/login`). The main goal of the `MapIdentityApi` is to make it easy for developers to use ASP.NET Core Identity for authentication in JavaScript-based single page apps (SPA) or Blazor apps. Instead of using the default UI provided by ASP.NET Core Identity, which is based on Razor Pages, MapIdentityApi adds JSON API endpoints that are more suitable for SPA apps and nonbrowser apps. For more information, see [Identity API endpoints](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-4/#identity-api-endpoints).

### IAuthorizationRequirementData

Prior to ASP.NET Core 8, adding a parameterized authorization policy to an endpoint required implementing an:

* `AuthorizeAttribute` for each policy.
* `AuthorizationPolicyProvider` to process a custom policy from a string-based contract.
* `AuthorizationRequirement` for the policy.
* `AuthorizationHandler` for each requirement.

For example, consider the following sample written for ASP.NET Core 7.0:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/OldStyleAuthRequirements/Program.cs" highlight="9":::

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/OldStyleAuthRequirements/Controllers/GreetingsController.cs" :::

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/OldStyleAuthRequirements/Authorization/MinimumAgeAuthorizationHandler.cs" highlight="7,19":::

The complete sample is [here](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/security/authorization/OldStyleAuthRequirements) in the [AspNetCore.Docs.Samples](https://github.com/dotnet/AspNetCore.Docs.Samples) repository.

ASP.NET Core 8 introduces the <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirementData> interface. The `IAuthorizationRequirementData` interface allows the attribute definition to specify the requirements associated with the authorization policy. Using `IAuthorizationRequirementData`, the preceding custom authorization policy code can be written with fewer lines of code. The updated `Program.cs` file:

```diff
  using AuthRequirementsData.Authorization;
  using Microsoft.AspNetCore.Authorization;
  
  var builder = WebApplication.CreateBuilder();
  
  builder.Services.AddAuthentication().AddJwtBearer();
  builder.Services.AddAuthorization();
  builder.Services.AddControllers();
- builder.Services.AddSingleton<IAuthorizationPolicyProvider, MinimumAgePolicyProvider>();
  builder.Services.AddSingleton<IAuthorizationHandler, MinimumAgeAuthorizationHandler>();
  
  var app = builder.Build();
  
  app.MapControllers();
  
  app.Run();
```

The updated `MinimumAgeAuthorizationHandler`:

```diff
using Microsoft.AspNetCore.Authorization;
using System.Globalization;
using System.Security.Claims;

namespace AuthRequirementsData.Authorization;

- class MinimumAgeAuthorizationHandler : AuthorizationHandler<MinimumAgeRequirement>
+ class MinimumAgeAuthorizationHandler : AuthorizationHandler<MinimumAgeAuthorizeAttribute>
{
    private readonly ILogger<MinimumAgeAuthorizationHandler> _logger;

    public MinimumAgeAuthorizationHandler(ILogger<MinimumAgeAuthorizationHandler> logger)
    {
        _logger = logger;
    }

    // Check whether a given MinimumAgeRequirement is satisfied or not for a particular
    // context
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
-                                              MinimumAgeRequirement requirement)
+                                              MinimumAgeAuthorizeAttribute requirement)
    {
        // Remaining code omitted for brevity.
```

The complete updated sample can be found [here](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/security/authorization/AuthRequirementsData).

See <xref:security/authorization/iard> for a detailed examination of the new sample.

### Securing Swagger UI endpoints

Swagger UI endpoints can now be secured in production environments by calling [`MapSwagger().RequireAuthorization`](xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A). For more information, see [Securing Swagger UI endpoints](/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-8.0&preserve-view=true#securing-swagger-ui-endpoints)

## Miscellaneous

The following sections describe miscellaneous new features in ASP.NET Core 8.

### Keyed services support in Dependency Injection

*Keyed services* refers to a mechanism for registering and retrieving Dependency Injection (DI) services using keys. A service is associated with a key by calling <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddKeyedSingleton%2A> (or `AddKeyedScoped` or `AddKeyedTransient`) to register it. Access a registered service by specifying the key with the [`[FromKeyedServices]`](xref:Microsoft.Extensions.DependencyInjection.FromKeyedServicesAttribute) attribute. The following code shows how to use keyed services:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/samples/KeyedServices/Program.cs" highlight="6,7,12-14,39,47":::

### Visual Studio project templates for SPA apps with ASP.NET Core backend

Visual Studio project templates are now the recommended way to create single-page apps (SPAs) that have an ASP.NET Core backend. Templates are provided that create apps based on the JavaScript frameworks [Angular](https://angular.io/), [React](https://facebook.github.io/react/), and [Vue](https://vuejs.org/). These templates:

* Create a Visual Studio solution with a frontend project and a backend project.
* Use the Visual Studio project type for JavaScript and TypeScript (*.esproj*) for the frontend.
* Use an ASP.NET Core project for the backend.

For more information about the Visual Studio templates and how to access the legacy templates, see <xref:spa/intro>

### Support for generic attributes

Attributes that previously required a <xref:System.Type> parameter are now available in cleaner generic variants. This is made possible by support for [generic attributes](/dotnet/csharp/whats-new/csharp-11) in C# 11. For example, the syntax for annotating the response type of an action can be modified as follows:

```diff
[ApiController]
[Route("api/[controller]")]
public class TodosController : Controller
{
  [HttpGet("/")]
- [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
+ [ProducesResponseType<Todo>(StatusCodes.Status200OK)]
  public Todo Get() => new Todo(1, "Write a sample", DateTime.Now, false);
}
```

Generic variants are supported for the following attributes:

<!--TODO update these API links -->

* `[ProducesResponseType<T>]`
* `[Produces<T>]`
* `[MiddlewareFilter<T>]`
* `[ModelBinder<T>]`
* `[ModelMetadataType<T>]`
* `[ServiceFilter<T>]`
* `[TypeFilter<T>]`

<!--Note: All the topics that use the preceding attributes have been updated to use the generic -->

### Code analysis in ASP.NET Core apps

The new analyzers shown in the following table are available in ASP.NET Core 8.0.

| Diagnostic ID | Breaking or nonbreaking | Description |
| --- | --- | --- |
| [ASP0016](xref:diagnostics/asp0016) | Nonbreaking | Don't return a value from RequestDelegate |
| [ASP0019](xref:diagnostics/asp0019) | Nonbreaking | Suggest using IHeaderDictionary.Append or the indexer |
| [ASP0020](xref:diagnostics/asp0020) | Nonbreaking | Complex types referenced by route parameters must be parsable |
| [ASP0021](xref:diagnostics/asp0021) | Nonbreaking | The return type of the BindAsync method must be `ValueTask<T>` |
| [ASP0022](xref:diagnostics/asp0022) | Nonbreaking | Route conflict detected between route handlers |
| [ASP0023](xref:diagnostics/asp0023) | Nonbreaking | MVC: Route conflict detected between route handlers |
| [ASP0024](xref:diagnostics/asp0024) | Nonbreaking | Route handler has multiple parameters with the `[FromBody]` attribute |
| [ASP0025](xref:diagnostics/asp0025) | Nonbreaking | Use AddAuthorizationBuilder |

### Route tooling

ASP.NET Core is built on routing. Minimal APIs, Web APIs, Razor Pages, and Blazor all use routes to customize how HTTP requests map to code.

In .NET 8 we've invested in a suite of new features to make routing easier to learn and use. These new features include:

* [Route syntax highlighting](https://devblogs.microsoft.com/dotnet/aspnet-core-route-tooling-dotnet-8/#route-syntax-highlighting)
* [Autocomplete of parameter and route names](https://devblogs.microsoft.com/dotnet/aspnet-core-route-tooling-dotnet-8/#autocomplete-of-parameter-and-route-names)
* [Autocomplete of route constraints](https://devblogs.microsoft.com/dotnet/aspnet-core-route-tooling-dotnet-8/#autocomplete-of-route-constraints)
* [Route analyzers and fixers](https://devblogs.microsoft.com/dotnet/aspnet-core-route-tooling-dotnet-8/#route-analyzers-and-fixers)
  * [Route syntax analyzer](https://devblogs.microsoft.com/dotnet/aspnet-core-route-tooling-dotnet-8/#route-syntax-analyzer)
  * [Mismatched parameter optionality analyzer and fixer](https://devblogs.microsoft.com/dotnet/aspnet-core-route-tooling-dotnet-8/#mismatched-parameter-optionality-analyzer-and-fixer)
  * [Ambiguous Minimal API and Web API route analyzer](https://devblogs.microsoft.com/dotnet/aspnet-core-route-tooling-dotnet-8/#ambiguous-minimal-api-and-web-api-route-analyzer)
* [Support for Minimal APIs, Web APIs, and Blazor](https://devblogs.microsoft.com/dotnet/aspnet-core-route-tooling-dotnet-8/#supports-minimal-apis-web-apis-and-blazor)

For more information, see [Route tooling in .NET 8](https://devblogs.microsoft.com/dotnet/aspnet-core-route-tooling-dotnet-8/).

### ASP.NET Core metrics

Metrics are measurements reported over time and are most often used to monitor the health of an app and to generate alerts. For example, a counter that reports failed HTTP requests could be displayed in dashboards or generate alerts when failures pass a threshold.

This preview adds new metrics throughout ASP.NET Core using <xref:System.Diagnostics.Metrics>. `Metrics` is a modern API for reporting and collecting information about apps.

Metrics offers many improvements compared to existing event counters:

* New kinds of measurements with counters, gauges and histograms.
* Powerful reporting with multi-dimensional values.
* Integration into the wider cloud native ecosystem by aligning with OpenTelemetry standards.

Metrics have been added for ASP.NET Core hosting, Kestrel, and SignalR. For more information, see [System.Diagnostics.Metrics](/dotnet/core/diagnostics/compare-metric-apis#systemdiagnosticsmetrics).

### IExceptionHandler

[IExceptionHandler](https://source.dot.net/#Microsoft.AspNetCore.Diagnostics/ExceptionHandler/IExceptionHandler.cs,adae2915ad0c6dc5) is a new interface that gives the developer a callback for handling known exceptions in a central location.

`IExceptionHandler` implementations are registered by calling [`IServiceCollection.AddExceptionHandler<T>`](https://source.dot.net/#Microsoft.AspNetCore.Diagnostics/ExceptionHandler/ExceptionHandlerServiceCollectionExtensions.cs,e74aac24e3e2cbc9). Multiple implementations can be added, and they're called in the order registered. If an exception handler handles a request, it can return `true` to stop processing. If an exception isn't handled by any exception handler, then control falls back to the default behavior and options from the middleware.

For more information, see [IExceptionHandler](xref:fundamentals/error-handling#iexceptionhandler).

### Improved debugging experience

[Debug customization attributes](/visualstudio/debugger/using-the-debuggerdisplay-attribute) have been added to types like `HttpContext`, `HttpRequest`, `HttpResponse`, `ClaimsPrincipal`, and `WebApplication`. The enhanced debugger displays for these types make finding important information easier in an IDE's debugger. The following screenshots show the difference that these attributes make in the debugger's display of `HttpContext`.

.NET 7:

:::image type="content" source="~/release-notes/static/httpcontext-debugging-before.png" alt-text="Unhelpful debugger display of HttpContext type in .NET 7.":::

.NET 8:

:::image type="content" source="~/release-notes/static/httpcontext-debugging-after.png" alt-text="Helpful debugger display of HttpContext type in .NET 8.":::

The debugger display for `WebApplication` highlights important information such as configured endpoints, middleware, and `IConfiguration` values.

.NET 7:

:::image type="content" source="~/release-notes/static/webapplication-debugging-before.png" alt-text="Unhelpful debugger display of WebApplication type in .NET 7.":::

.NET 8:

:::image type="content" source="~/release-notes/static/webapplication-debugging-after.png" alt-text="Helpful debugger display of WebApplication type in .NET 8.":::

For more information about debugging improvements in .NET 8, see GitHub issue [dotnet/aspnetcore 48205](https://github.com/dotnet/aspnetcore/issues/48205). 

### `IPNetwork.Parse` and `TryParse`

The new <xref:System.Net.IPNetwork.Parse%2A> and <xref:System.Net.IPNetwork.TryParse%2A> methods on <xref:System.Net.IPNetwork> add support for creating an `IPNetwork` by using an input string in [CIDR notation](https://en.wikipedia.org/wiki/Classless_Inter-Domain_Routing) or "slash notation".

Here are IPv4 examples:

```csharp
// Using Parse
var network = IPNetwork.Parse("192.168.0.1/32");
```

```csharp
// Using TryParse
bool success = IPNetwork.TryParse("192.168.0.1/32", out var network);
```

```csharp
// Constructor equivalent
var network = new IPNetwork(IPAddress.Parse("192.168.0.1"), 32);
```

And here are examples for IPv6:

```csharp
// Using Parse
var network = IPNetwork.Parse("2001:db8:3c4d::1/128");
```

```csharp
// Using TryParse
bool success = IPNetwork.TryParse("2001:db8:3c4d::1/128", out var network);
```

```csharp
// Constructor equivalent
var network = new IPNetwork(IPAddress.Parse("2001:db8:3c4d::1"), 128);
```

### Redis-based output caching

ASP.NET Core 8 adds support for using Redis as a distributed cache for output caching. Output caching is a feature that enables an app to cache the output of a minimal API endpoint, controller action, or Razor Page. For more information, see [Output caching](xref:performance/caching/output#cache-storage).

### Short-circuit middleware after routing

When routing matches an endpoint, it typically lets the rest of the middleware pipeline run before invoking the endpoint logic. Services can reduce resource usage by filtering out known requests early in the pipeline. Use the <xref:Microsoft.AspNetCore.Builder.RouteShortCircuitEndpointConventionBuilderExtensions.ShortCircuit%2A> extension method to cause routing to invoke the endpoint logic immediately and then end the request. For example, a given route might not need to go through authentication or CORS middleware. The following example short-circuits requests that match the `/short-circuit` route:

:::code language="csharp" source="~/fundamentals/routing/samples/8.x/ShortCircuitSample/Program.cs" id="mapget":::

Use the <xref:Microsoft.AspNetCore.Routing.RouteShortCircuitEndpointRouteBuilderExtensions.MapShortCircuit%2A> method to set up short-circuiting for multiple routes at once, by passing to it a params array of URL prefixes. For example, browsers and bots often probe servers for well known paths like `robots.txt` and `favicon.ico`. If the app doesn't have those files, one line of code can configure both routes:

:::code language="csharp" source="~/fundamentals/routing/samples/8.x/ShortCircuitSample/Program.cs" id="mapshortcircuit":::

For more information, see [Short-circuit middleware after routing](xref:fundamentals/routing#short-circuit-middleware-after-routing).

### HTTP logging middleware extensibility

The HTTP logging middleware has several new capabilities:

* <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.Duration?displayProperty=nameWithType>: When enabled, the middleware emits a new log at the end of the request and response that measures the total time taken for processing. This new field has been added to the <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All?displayProperty=nameWithType> set.
* <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions.CombineLogs?displayProperty=nameWithType>: When enabled, the middleware consolidates all of its enabled logs for a request and response into one log at the end. A single log message includes the request, request body, response, response body, and duration.
* <xref:Microsoft.AspNetCore.HttpLogging.IHttpLoggingInterceptor>: A new interface for a service that can be implemented and registered (using <xref:Microsoft.Extensions.DependencyInjection.HttpLoggingServicesExtensions.AddHttpLoggingInterceptor%2A>) to receive per-request and per-response callbacks for customizing what details get logged. Any endpoint-specific log settings are applied first and can then be overridden in these callbacks. An implementation can:
  * Inspect a request and response.
  * Enable or disable any <xref:Microsoft.AspNetCore.HttpLogging.HttpLoggingFields>.
  * Adjust how much of the request or response body is logged.
  * Add custom fields to the logs.

For more information, see <xref:fundamentals/http-logging/index>.

### New APIs in ProblemDetails to support more resilient integrations

In .NET 7, the [ProblemDetails service](xref:fundamentals/error-handling#problem-details) was introduced to improve the experience for generating error responses that comply with the [ProblemDetails specification](https://datatracker.ietf.org/doc/html/rfc7807). In .NET 8, a new API was added to make it easier to implement fallback behavior if <xref:Microsoft.AspNetCore.Http.IProblemDetailsService> isn't able to generate <xref:Microsoft.AspNetCore.Mvc.ProblemDetails>. The following example illustrates use of the new <xref:Microsoft.AspNetCore.Http.IProblemDetailsService.TryWriteAsync%2A> API:

:::code language="csharp" source="~/fundamentals/minimal-apis/handle-errors/sample8/Program.cs" id="snippet_IProblemDetailsServiceWithExceptionFallback" highlight="15":::

For more information, see [IProblemDetailsService fallback](xref:fundamentals/minimal-apis/handle-errors#iproblemdetailsservice-fallback)

<!--
## API controllers

## gRPC
-->
