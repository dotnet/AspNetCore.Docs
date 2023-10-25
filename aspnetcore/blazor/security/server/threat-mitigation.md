---
title: Threat mitigation guidance for server-side ASP.NET Core Blazor
author: guardrex
description: Learn how to mitigate security threats to server-side Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/21/2023
uid: blazor/security/server/threat-mitigation
---
# Threat mitigation guidance for server-side ASP.NET Core Blazor

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to mitigate security threats to server-side Blazor apps.

[!INCLUDE[](~/blazor/includes/location-client-and-server-net31-or-later.md)]

Apps adopt a *stateful* data processing model, where the server and client maintain a long-lived relationship. The persistent state is maintained by a [circuit](xref:blazor/state-management), which can span connections that are also potentially long-lived.

When a user visits a site, the server creates a circuit in the server's memory. The circuit indicates to the browser what content to render and responds to events, such as when the user selects a button in the UI. To perform these actions, a circuit invokes JavaScript functions in the user's browser and .NET methods on the server. This two-way JavaScript-based interaction is referred to as [JavaScript interop (JS interop)](xref:blazor/js-interop/call-javascript-from-dotnet).

Because JS interop occurs over the Internet and the client uses a remote browser, apps share most web app security concerns. This topic describes common threats to server-side Blazor apps and provides threat mitigation guidance focused on Internet-facing apps.

In constrained environments, such as inside corporate networks or intranets, some of the mitigation guidance either:

* Doesn't apply in the constrained environment.
* Isn't worth the cost to implement because the security risk is low in a constrained environment.

## Shared state

[!INCLUDE[](~/blazor/security/includes/shared-state.md)]

## `IHttpContextAccessor`/`HttpContext` in Razor components

[!INCLUDE[](~/blazor/security/includes/httpcontext.md)]

## Resource exhaustion

Resource exhaustion can occur when a client interacts with the server and causes the server to consume excessive resources. Excessive resource consumption primarily affects:

* [CPU](#cpu)
* [Memory](#memory)
* [Client connections](#client-connections)

Denial of Service (DoS) attacks usually seek to exhaust an app or server's resources. However, resource exhaustion isn't necessarily the result of an attack on the system. For example, finite resources can be exhausted due to high user demand. DoS is covered further in the [DoS section](#denial-of-service-dos-attacks).

Resources external to the Blazor framework, such as databases and file handles (used to read and write files), may also experience resource exhaustion. For more information, see <xref:fundamentals/best-practices>.

### CPU

CPU exhaustion can occur when one or more clients force the server to perform intensive CPU work.

For example, consider an app that calculates a *Fibonnacci number*. A Fibonnacci number is produced from a Fibonnacci sequence, where each number in the sequence is the sum of the two preceding numbers. The amount of work required to reach the answer depends on the length of the sequence and the size of the initial value. If the app doesn't place limits on a client's request, the CPU-intensive calculations may dominate the CPU's time and diminish the performance of other tasks. Excessive resource consumption is a security concern impacting availability.

CPU exhaustion is a concern for all public-facing apps. In regular web apps, requests and connections time out as a safeguard, but Blazor apps don't provide the same safeguards. Blazor apps must include appropriate checks and limits before performing potentially CPU-intensive work.

### Memory

Memory exhaustion can occur when one or more clients force the server to consume a large amount of memory.

For example, consider an app with a component that accepts and displays a list of items. If the Blazor app doesn't place limits on the number of items allowed or the number of items rendered back to the client, the memory-intensive processing and rendering may dominate the server's memory to the point where performance of the server suffers. The server may crash or slow to the point that it appears to have crashed.

Consider the following scenario for maintaining and displaying a list of items that pertain to a potential memory exhaustion scenario on the server:

* The items in a `List<T>` property or field use the server's memory. If the app allows the list of items to grow unbounded, there's a risk of the server running out of memory. Running out of memory causes the current session to end (crash) and all of the concurrent sessions in that server instance receive an out-of-memory exception. To prevent this scenario from occurring, the app must use a data structure that imposes an item limit on concurrent users.
* If a paging scheme isn't used for rendering, the server uses additional memory for objects that aren't visible in the UI. Without a limit on the number of items, memory demands may exhaust the available server memory. To prevent this scenario, use one of the following approaches:
  * Use paginated lists when rendering.
  * Only display the first 100 to 1,000 items and require the user to enter search criteria to find items beyond the items displayed.
  * For a more advanced rendering scenario, implement lists or grids that support *virtualization*. Using virtualization, lists only render a subset of items currently visible to the user. When the user interacts with the scrollbar in the UI, the component renders only those items required for display. The items that aren't currently required for display can be held in secondary storage, which is the ideal approach. Undisplayed items can also be held in memory, which is less ideal.

:::moniker range=">= aspnetcore-5.0"

> [!NOTE]
> Blazor has built-in support for virtualization. For more information, see <xref:blazor/components/virtualization>.

:::moniker-end

Blazor apps offer a similar programming model to other UI frameworks for stateful apps, such as WPF, Windows Forms, or Blazor WebAssembly. The main difference is that in several of the UI frameworks the memory consumed by the app belongs to the client and only affects that individual client. For example, a Blazor WebAssembly app runs entirely on the client and only uses client memory resources. For a server-side Blazor app, the memory consumed by the app belongs to the server and is shared among clients on the server instance.

Server-side memory demands are a consideration for all server-side Blazor apps. However, most web apps are stateless, and the memory used while processing a request is released when the response is returned. As a general recommendation, don't permit clients to allocate an unbound amount of memory as in any other server-side app that persists client connections. The memory consumed by a server-side Blazor app persists for a longer time than a single request.

> [!NOTE]
> During development, a profiler can be used or a trace captured to assess memory demands of clients. A profiler or trace won't capture the memory allocated to a specific client. To capture the memory use of a specific client during development, capture a dump and examine the memory demand of all the objects rooted at a user's circuit.

### Client connections

Connection exhaustion can occur when one or more clients open too many concurrent connections to the server, preventing other clients from establishing new connections.

Blazor clients establish a single connection per session and keep the connection open for as long as the browser window is open. Given the persistent nature of the connections and the stateful nature of server-side Blazor apps, connection exhaustion is a greater risk to availability of the app.

By default, there's no limit on the number of connections per user for an app. If the app requires a connection limit, take one or more of the following approaches:

:::moniker range=">= aspnetcore-5.0"

* Require authentication, which naturally limits the ability of unauthorized users to connect to the app. For this scenario to be effective, users must be prevented from provisioning new users on demand.
* Limit the number of connections per user. Limiting connections can be accomplished via the following approaches. Exercise care to allow legitimate users to access the app (for example, when a connection limit is established based on the client's IP address).
  * At the app level:
    * Endpoint routing extensibility.
    * Require authentication to connect to the app and keep track of the active sessions per user.
    * Reject new sessions upon reaching a limit.
    * Proxy WebSocket connections to an app through the use of a proxy, such as the [Azure SignalR Service](/azure/azure-signalr/signalr-overview) that multiplexes connections from clients to an app. This provides an app with greater connection capacity than a single client can establish, preventing a client from exhausting the connections to the server.
  * At the server level: Use a proxy/gateway in front of the app. For example, [Azure Front Door](/azure/frontdoor/front-door-overview) enables you to define, manage, and monitor the global routing of web traffic to an app and works when apps are configured to use Long Polling.
  
    > [!NOTE]
    > Although Long Polling is supported, [WebSockets is the recommended transport protocol](xref:blazor/host-and-deploy/server#azure-signalr-service). As of February, 2023, [Azure Front Door](/azure/frontdoor/front-door-overview) doesn't support WebSockets, but support for WebSockets is under development for a future release of the service. For more information, see [Support WebSocket connections on Azure Front Door](https://feedback.azure.com/d365community/idea/c8b1d257-8a26-ec11-b6e6-000d3a4f0789).

:::moniker-end

:::moniker range="< aspnetcore-5.0"

* Require authentication, which naturally limits the ability of unauthorized users to connect to the app. For this scenario to be effective, users must be prevented from provisioning new users on demand.
* Limit the number of connections per user. Limiting connections can be accomplished via the following approaches. Exercise care to allow legitimate users to access the app (for example, when a connection limit is established based on the client's IP address).
  * At the app level:
    * Endpoint routing extensibility.
    * Require authentication to connect to the app and keep track of the active sessions per user.
    * Reject new sessions upon reaching a limit.
    * Proxy WebSocket connections to an app through the use of a proxy, such as the [Azure SignalR Service](/azure/azure-signalr/signalr-overview) that multiplexes connections from clients to an app. This provides an app with greater connection capacity than a single client can establish, preventing a client from exhausting the connections to the server.
  * At the server level: Use a proxy/gateway in front of the app.
  
    > [!NOTE]
    > Although Long Polling is supported, [WebSockets is the recommended transport protocol](xref:blazor/host-and-deploy/server#azure-signalr-service).

:::moniker-end

## Denial of Service (DoS) attacks

[Denial of Service (DoS) attacks](https://developer.mozilla.org/docs/Glossary/DOS_attack) involve a client causing the server to exhaust one or more of its resources making the app unavailable. Blazor apps include default limits and rely on other ASP.NET Core and SignalR limits that are set on <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions> to protect against DoS attacks:

* <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DisconnectedCircuitMaxRetained?displayProperty=nameWithType>
* <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DisconnectedCircuitRetentionPeriod?displayProperty=nameWithType>
* <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.JSInteropDefaultCallTimeout?displayProperty=nameWithType>
* <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.MaxBufferedUnacknowledgedRenderBatches?displayProperty=nameWithType>
* <xref:Microsoft.AspNetCore.SignalR.HubConnectionContextOptions.MaximumReceiveMessageSize?displayProperty=nameWithType>

For more information and configuration coding examples, see the following articles:

* <xref:blazor/fundamentals/signalr>
* <xref:signalr/configuration>

## Interactions with the browser (client)

A client interacts with the server through JS interop event dispatching and render completion. JS interop communication goes both ways between JavaScript and .NET:

* Browser events are dispatched from the client to the server in an asynchronous fashion.
* The server responds asynchronously rerendering the UI as necessary.

### JavaScript functions invoked from .NET

For calls from .NET methods to JavaScript:

* All invocations have a configurable timeout after which they fail, returning a <xref:System.OperationCanceledException> to the caller.
  * There's a default timeout for the calls (<xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.JSInteropDefaultCallTimeout?displayProperty=nameWithType>) of one minute. To configure this limit, see <xref:blazor/js-interop/call-javascript-from-dotnet#harden-javascript-interop-calls>.
  * A cancellation token can be provided to control the cancellation on a per-call basis. Rely on the default call timeout where possible and time-bound any call to the client if a cancellation token is provided.
* The result of a JavaScript call can't be trusted. The Blazor app client running in the browser searches for the JavaScript function to invoke. The function is invoked, and either the result or an error is produced. A malicious client can attempt to:
  * Cause an issue in the app by returning an error from the JavaScript function.
  * Induce an unintended behavior on the server by returning an unexpected result from the JavaScript function.

Take the following precautions to guard against the preceding scenarios:

* Wrap JS interop calls within [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statements to account for errors that might occur during the invocations. For more information, see <xref:blazor/fundamentals/handle-errors#javascript-interop>.
* Validate data returned from JS interop invocations, including error messages, before taking any action.

### .NET methods invoked from the browser

Don't trust calls from JavaScript to .NET methods. When a .NET method is exposed to JavaScript, consider how the .NET method is invoked:

* Treat any .NET method exposed to JavaScript as you would a public endpoint to the app.
  * Validate input.
    * Ensure that values are within expected ranges.
    * Ensure that the user has permission to perform the action requested.
  * Don't allocate an excessive quantity of resources as part of the .NET method invocation. For example, perform checks and place limits on CPU and memory use.
  * Take into account that static and instance methods can be exposed to JavaScript clients. Avoid sharing state across sessions unless the design calls for sharing state with appropriate constraints.
    * For instance methods exposed through <xref:Microsoft.JSInterop.DotNetObjectReference> objects that are originally created through dependency injection (DI), the objects should be registered as scoped objects. This applies to any DI service that the app uses.
    * For static methods, avoid establishing state that can't be scoped to the client unless the app is explicitly sharing state by-design across all users on a server instance.
  * Avoid passing user-supplied data in parameters to JavaScript calls. If passing data in parameters is absolutely required, ensure that the JavaScript code handles passing the data without introducing [Cross-site scripting (XSS)](#cross-site-scripting-xss) vulnerabilities. For example, don't write user-supplied data to the DOM by setting the `innerHTML` property of an element. Consider using [Content Security Policy (CSP)](https://developer.mozilla.org/docs/Web/HTTP/CSP) to disable `eval` and other unsafe JavaScript primitives. For more information, see <xref:blazor/security/content-security-policy>.
* Avoid implementing custom dispatching of .NET invocations on top of the framework's dispatching implementation. Exposing .NET methods to the browser is an advanced scenario, not recommended for general Blazor development.

### Events

Events provide an entry point to an app. The same rules for safeguarding endpoints in web apps apply to event handling in Blazor apps. A malicious client can send any data it wishes to send as the payload for an event.

For example:

* A change event for a `<select>` could send a value that isn't within the options that the app presented to the client.
* An `<input>` could send any text data to the server, bypassing client-side validation.

The app must validate the data for any event that the app handles. The Blazor framework [forms components](xref:blazor/forms/input-components) perform basic validations. If the app uses custom forms components, custom code must be written to validate event data as appropriate.

Events are asynchronous, so multiple events can be dispatched to the server before the app has time to react by producing a new render. This has some security implications to consider. Limiting client actions in the app must be performed inside event handlers and not depend on the current rendered view state.

Consider a counter component that should allow a user to increment a counter a maximum of three times. The button to increment the counter is conditionally based on the value of `count`:

```razor
<p>Count: @count</p>

@if (count < 3)
{
    <button @onclick="IncrementCount" value="Increment count" />
}

@code 
{
    private int count = 0;

    private void IncrementCount()
    {
        count++;
    }
}
```

A client can dispatch one or more increment events before the framework produces a new render of this component. The result is that the `count` can be incremented *over three times* by the user because the button isn't removed by the UI quickly enough. The correct way to achieve the limit of three `count` increments is shown in the following example:

```razor
<p>Count: @count</p>

@if (count < 3)
{
    <button @onclick="IncrementCount" value="Increment count" />
}

@code 
{
    private int count = 0;

    private void IncrementCount()
    {
        if (count < 3)
        {
            count++;
        }
    }
}
```

By adding the `if (count < 3) { ... }` check inside the handler, the decision to increment `count` is based on the current app state. The decision isn't based on the state of the UI as it was in the previous example, which might be temporarily stale.

### Guard against multiple dispatches

If an event callback invokes a long running operation asynchronously, such as fetching data from an external service or database, consider using a guard. The guard can prevent the user from queueing up multiple operations while the operation is in progress with visual feedback. The following component code sets `isLoading` to `true` while `DataService.GetDataAsync` obtains data from the server. While `isLoading` is `true`, the button is disabled in the UI:

```razor
<button disabled="@isLoading" @onclick="UpdateData">Update</button>

@code {
    private bool isLoading;
    private Data[] data = Array.Empty<Data>();

    private async Task UpdateData()
    {
        if (!isLoading)
        {
            isLoading = true;
            data = await DataService.GetDataAsync(DateTime.Now);
            isLoading = false;
        }
    }
}
```

The guard pattern demonstrated in the preceding example works if the background operation is executed asynchronously with the `async`-`await` pattern.

### Cancel early and avoid use-after-dispose

In addition to using a guard as described in the [Guard against multiple dispatches](#guard-against-multiple-dispatches) section, consider using a <xref:System.Threading.CancellationToken> to cancel long-running operations when the component is disposed. This approach has the added benefit of avoiding *use-after-dispose* in components:

```razor
@implements IDisposable

...

@code {
    private readonly CancellationTokenSource TokenSource = 
        new CancellationTokenSource();

    private async Task UpdateData()
    {
        ...

        data = await DataService.GetDataAsync(DateTime.Now, TokenSource.Token);

        if (TokenSource.Token.IsCancellationRequested)
        {
           return;
        }

        ...
    }

    public void Dispose()
    {
        TokenSource.Cancel();
    }
}
```

### Avoid events that produce large amounts of data

Some DOM events, such as `oninput` or `onscroll`, can produce a large amount of data. Avoid using these events in server-side Blazor server.

## Additional security guidance

The guidance for securing ASP.NET Core apps apply to server-side Blazor apps and are covered in the following sections of this article:

* [Logging and sensitive data](#logging-and-sensitive-data)
* [Protect information in transit with HTTPS](#protect-information-in-transit-with-https)
* [Cross-site scripting (XSS)](#cross-site-scripting-xss)
* [Cross-origin protection](#cross-origin-protection)
* [Click-jacking](#click-jacking)
* [Open redirects](#open-redirects)

### Logging and sensitive data

JS interop interactions between the client and server are recorded in the server's logs with <xref:Microsoft.Extensions.Logging.ILogger> instances. Blazor avoids logging sensitive information, such as actual events or JS interop inputs and outputs.

When an error occurs on the server, the framework notifies the client and tears down the session. By default, the client receives a generic error message that can be seen in the browser's developer tools.

The client-side error doesn't include the call stack and doesn't provide detail on the cause of the error, but server logs do contain such information. For development purposes, sensitive error information can be made available to the client by [enabling detailed errors](xref:blazor/fundamentals/handle-errors#detailed-circuit-errors).

> [!WARNING]
> Exposing error information to clients on the Internet is a security risk that should always be avoided.

### Protect information in transit with HTTPS

Blazor uses SignalR for communication between the client and the server. Blazor normally uses the transport that SignalR negotiates, which is typically WebSockets.

Blazor doesn't ensure the integrity and confidentiality of the data sent between the server and the client. Always use HTTPS.

### Cross-site scripting (XSS)

Cross-site scripting (XSS) allows an unauthorized party to execute arbitrary logic in the context of the browser. A compromised app could potentially run arbitrary code on the client. The vulnerability could be used to potentially perform a number of malicious actions against the server:

* Dispatch fake/invalid events to the server.
* Dispatch fail/invalid render completions.
* Avoid dispatching render completions.
* Dispatch interop calls from JavaScript to .NET.
* Modify the response of interop calls from .NET to JavaScript.
* Avoid dispatching .NET to JS interop results.

The Blazor framework takes steps to protect against some of the preceding threats:

* Stops producing new UI updates if the client isn't acknowledging render batches. Configured with <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.MaxBufferedUnacknowledgedRenderBatches?displayProperty=nameWithType>.
* Times out any .NET to JavaScript call after one minute without receiving a response from the client. Configured with <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.JSInteropDefaultCallTimeout?displayProperty=nameWithType>.
* Performs basic validation on all input coming from the browser during JS interop:
  * .NET references are valid and of the type expected by the .NET method.
  * The data isn't malformed.
  * The correct number of arguments for the method are present in the payload.
  * The arguments or result can be deserialized correctly before invoking the method.
* Performs basic validation in all input coming from the browser from dispatched events:
  * The event has a valid type.
  * The data for the event can be deserialized.
  * There's an event handler associated with the event.

In addition to the safeguards that the framework implements, the app must be coded by the developer to safeguard against threats and take appropriate actions:

* Always validate data when handling events.
* Take appropriate action upon receiving invalid data:
  * Ignore the data and return. This allows the app to continue processing requests.
  * If the app determines that the input is illegitimate and couldn't be produced by legitimate client, throw an exception. Throwing an exception tears down the circuit and ends the session.
* Don't trust the error message provided by render batch completions included in the logs. The error is ***provided by the client*** and can't generally be trusted, as the client might be compromised.
* Don't trust the input on JS interop calls in either direction between JavaScript and .NET methods.
* The app is responsible for validating that the content of arguments and results are valid, even if the arguments or results are correctly deserialized.

For a XSS vulnerability to exist, the app must incorporate user input in the rendered page. Blazor executes a compile-time step where the markup in a `.razor` file is transformed into procedural C# logic. At runtime, the C# logic builds a *render tree* describing the elements, text, and child components. This is applied to the browser's DOM via a sequence of JavaScript instructions (or is serialized to HTML in the case of prerendering):

* User input rendered via normal Razor syntax (for example, `@someStringValue`) doesn't expose a XSS vulnerability because the Razor syntax is added to the DOM via commands that can only write text. Even if the value includes HTML markup, the value is displayed as static text. When prerendering, the output is HTML-encoded, which also displays the content as static text.
* Script tags aren't allowed and shouldn't be included in the app's component render tree. If a script tag is included in a component's markup, a compile-time error is generated.
* Component authors can author components in C# without using Razor. The component author is responsible for using the correct APIs when emitting output. For example, use `builder.AddContent(0, someUserSuppliedString)` and *not* `builder.AddMarkupContent(0, someUserSuppliedString)`, as the latter could create a XSS vulnerability.

Consider further mitigating XSS vulnerabilities. For example, implement a restrictive [Content Security Policy (CSP)](https://developer.mozilla.org/docs/Web/HTTP/CSP). For more information, see <xref:blazor/security/content-security-policy>.

For more information, see <xref:security/cross-site-scripting>.

### Cross-origin protection

Cross-origin attacks involve a client from a different origin performing an action against the server. The malicious action is typically a GET request or a form POST (Cross-Site Request Forgery, CSRF), but opening a malicious WebSocket is also possible. Blazor apps offer [the same guarantees that any other SignalR app using the hub protocol offer](xref:signalr/security):

* Apps can be accessed cross-origin unless additional measures are taken to prevent it. To disable cross-origin access, either disable CORS in the endpoint by adding the CORS Middleware to the pipeline and adding the <xref:Microsoft.AspNetCore.Cors.DisableCorsAttribute> to the Blazor endpoint metadata or limit the set of allowed origins by [configuring SignalR for Cross-Origin Resource Sharing](xref:signalr/security#cross-origin-resource-sharing). For guidance on WebSocket origin restrictions, see <xref:fundamentals/websockets#websocket-origin-restriction>.
* If CORS is enabled, extra steps might be required to protect the app depending on the CORS configuration. If CORS is globally enabled, CORS can be disabled for the Blazor SignalR hub by adding the <xref:Microsoft.AspNetCore.Cors.DisableCorsAttribute> metadata to the endpoint metadata after calling <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A> on the endpoint route builder.

For more information, see <xref:security/anti-request-forgery>.

### Click-jacking

Click-jacking involves rendering a site as an `<iframe>` inside a site from a different origin in order to trick the user into performing actions on the site under attack.

To protect an app from rendering inside of an `<iframe>`, use [Content Security Policy (CSP)](https://developer.mozilla.org/docs/Web/HTTP/CSP) and the `X-Frame-Options` header.

For more information, see the following resources:

* <xref:blazor/security/content-security-policy>
* [MDN web docs: X-Frame-Options](https://developer.mozilla.org/docs/Web/HTTP/Headers/X-Frame-Options)

### Open redirects

When an app session starts, the server performs basic validation of the URLs sent as part of starting the session. The framework checks that the base URL is a parent of the current URL before establishing the circuit. No additional checks are performed by the framework.

When a user selects a link on the client, the URL for the link is sent to the server, which determines what action to take. For example, the app may perform a client-side navigation or indicate to the browser to go to the new location.

Components can also trigger navigation requests programmatically through the use of <xref:Microsoft.AspNetCore.Components.NavigationManager>. In such scenarios, the app might perform a client-side navigation or indicate to the browser to go to the new location.

Components must:

* Avoid using user input as part of the navigation call arguments.
* Validate arguments to ensure that the target is allowed by the app.

Otherwise, a malicious user can force the browser to go to an attacker-controlled site. In this scenario, the attacker tricks the app into using some user input as part of the invocation of the <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> method.

This advice also applies when rendering links as part of the app:

* If possible, use relative links.
* Validate that absolute link destinations are valid before including them in a page.

For more information, see <xref:security/preventing-open-redirects>.

## Security checklist

The following list of security considerations isn't comprehensive:

* Validate arguments from events.
* Validate inputs and results from JS interop calls.
* Avoid using (or validate beforehand) user input for .NET to JS interop calls.
* Prevent the client from allocating an unbound amount of memory.
  * Data within the component.
  * <xref:Microsoft.JSInterop.DotNetObjectReference> objects returned to the client.
* Guard against multiple dispatches.
* Cancel long-running operations when the component is disposed.
* Avoid events that produce large amounts of data.
* Avoid using user input as part of calls to <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> and validate user input for URLs against a set of allowed origins first if unavoidable.
* Don't make authorization decisions based on the state of the UI but only from component state.
* Consider using [Content Security Policy (CSP)](https://developer.mozilla.org/docs/Web/HTTP/CSP) to protect against XSS attacks. For more information, see <xref:blazor/security/content-security-policy>.
* Consider using CSP and [X-Frame-Options](https://developer.mozilla.org/docs/Web/HTTP/Headers/X-Frame-Options) to protect against click-jacking.
* Ensure CORS settings are appropriate when enabling CORS or explicitly disable CORS for Blazor apps.
* Test to ensure that the server-side limits for the Blazor app provide an acceptable user experience without unacceptable levels of risk.
