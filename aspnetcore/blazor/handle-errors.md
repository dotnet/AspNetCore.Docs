---
title: Handle errors in ASP.NET Core Blazor apps
author: guardrex
description: Discover how ASP.NET Core Blazor how Blazor manages unhandled exceptions and how to develop apps that detect and handle errors.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 08/06/2019
uid: blazor/handle-errors
---
# Handle errors in ASP.NET Core Blazor apps

By [Steve Sanderson](https://github.com/SteveSandersonMS)

This article describes how Blazor manages unhandled exceptions and how to develop apps that detect and handle errors.

## How the Blazor framework reacts to unhandled exceptions

Blazor Server is a stateful framework. While users interact with an app, they maintain a connection to the server known as a *circuit*. The circuit holds active component instances, plus many other aspects of state, such as:

* The most recent rendered output of components.
* The current set of event-handling delegates that could be triggered by client-side events.

If a user opens the app in multiple browser tabs, they have multiple independent circuits.

Blazor treats most unhandled exceptions as fatal to the circuit where they occur. If a circuit is terminated due to an unhandled exception, the user can only continue to interact with the app by reloading the page to create a new circuit. Circuits outside of the one that's terminated, which are circuits for other users or other browser tabs, aren't affected. This scenario is similar to a desktop app that crashes&mdash;the crashed app must be restarted, but other apps aren't affected.

A circuit is terminated when an unhandled exception occurs for the following reasons:

* An unhandled exception often leaves the circuit in an undefined state.
* The app's normal operation can't be guaranteed after an unhandled exception.
* Security vulnerabilities may appear in the app if the circuit continues.

## Manage unhandled exceptions in developer code

For an app to continue after an error, the app must have error handling logic. Later sections of this article describe potential sources of unhandled exceptions.

In production, don't render framework exception messages or stack traces in the UI. Rendering exception messages or stack traces could:

* Disclose sensitive information to end users.
* Help a malicious user discover weaknesses in an app that can compromise the security of the app, server, or network.

## Log errors with a persistent provider

If an unhandled exception occurs, the exception is logged to <xref:Microsoft.Extensions.Logging.ILogger> instances configured in the service container. By default, Blazor apps log to console output with the Console Logging Provider. Consider logging to a more permanent location with a provider that manages log size and log rotation. For more information, see <xref:fundamentals/logging/index>.

During development, Blazor usually sends the full details of exceptions to the browser's console to aid in debugging. In production, detailed errors in the browser's console are disabled by default, which means that errors aren't sent to clients but the exception's full details are still logged server-side. For more information, see <xref:fundamentals/error-handling>.

You must decide which incidents to log and the level of severity of logged incidents. Hostile users might be able to trigger errors deliberately. For example, don't log an incident from an error where an unknown `ProductId` is supplied in the URL of a component that displays product details. Not all errors should be treated as high-severity incidents for logging.

## Places where errors may occur

Framework and app code may trigger unhandled exceptions in any of the following locations:

* [Component instantiation](#component-instantiation)
* [Lifecycle methods](#lifecycle-methods)
* [Rendering logic](#rendering-logic)
* [Event handlers](#event-handlers)
* [Component disposal](#component-disposal)
* [JavaScript interop](#javascript-interop)
* [Circuit handlers](#circuit-handlers)
* [Circuit disposal](#circuit-disposal)
* [Prerendering](#prerendering)

The preceding unhandled exceptions are described in the following sections of this article.

### Component instantiation

When Blazor creates an instance of a component:

* The component's constructor is invoked.
* The constructors of any non-singleton DI services supplied to the component's constructor via the [@inject](xref:blazor/dependency-injection#request-a-service-in-a-component) directive or the [[Inject]](xref:blazor/dependency-injection#request-a-service-in-a-component) attribute are invoked. 

A circuit fails when any executed constructor or a setter for any `[Inject]` property throws an unhandled exception. The exception is fatal because the framework can't instantiate the component. If constructor logic may throw exceptions, the app should trap the exceptions using a [try-catch](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.

### Lifecycle methods

During the lifetime of a component, Blazor invokes lifecycle methods:

* `OnInitialized` / `OnInitializedAsync`
* `OnParametersSet` / `OnParametersSetAsync`
* `ShouldRender` / `ShouldRenderAsync`
* `OnAfterRender` / `OnAfterRenderAsync`

If any lifecycle method throws an exception, synchronously or asynchronously, the exception is fatal to the circuit. For components to deal with errors in lifecycle methods, add error handling logic.

In the following example where `OnParametersSetAsync` calls a method to obtain a product:

* An exception thrown in the `ProductRepository.GetProductByIdAsync` method is handled by a `try-catch` statement.
* When the `catch` block is executed:
  * `loadFailed` is set to `true`, which is used to display an error message to the user.
  * The error is logged.

[!code-cshtml[](handle-errors/samples_snapshot/3.x/product-details.razor?highlight=11,27-39)]

### Rendering logic

The declarative markup in a `.razor` component file is compiled into a C# method called `BuildRenderTree`. When a component renders, `BuildRenderTree` executes and builds up a data structure describing the elements, text, and child components of the rendered component.

Rendering logic can throw an exception. An example of this scenario occurs when `@someObject.PropertyName` is evaluated but `@someObject` is `null`. An unhandled exception thrown by rendering logic is fatal to the circuit.

To prevent a null reference exception in rendering logic, check for a `null` object before accessing its members. In the following example, `person.Address` properties aren't accessed if `person.Address` is `null`:

[!code-cshtml[](handle-errors/samples_snapshot/3.x/person-example.razor?highlight=1)]

The preceding code assumes that `person` isn't `null`. Often, the structure of the code guarantees that an object exists at the time the component is rendered. In those cases, it isn't necessary to check for `null` in rendering logic. In the prior example, `person` might be guaranteed to exist because `person` is created when the component is instantiated.

### Event handlers

Client-side code triggers invocations of C# code when event handlers are created using:

* `@onclick`
* `@onchange`
* Other `@on...` attributes
* `@bind`

Event handler code might throw an unhandled exception in these scenarios.

If an event handler throws an unhandled exception (for example, a database query fails), the exception is fatal to the circuit. If the app calls code that could fail for external reasons, trap exceptions using a [try-catch](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.

If user code doesn't trap and handle the exception, the framework logs the exception and terminates the circuit.

### Component disposal

A component may be removed from the UI, for example, because the user has navigated to another page. When a component that implements <xref:System.IDisposable?displayProperty=fullName> is removed from the UI, the framework calls the component's <xref:System.IDisposable.Dispose*> method. 

If the component's `Dispose` method throws an unhandled exception, the exception is fatal to the circuit. If disposal logic may throw exceptions, the app should trap the exceptions using a [try-catch](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.

For more information on component disposal, see <xref:blazor/components#component-disposal-with-idisposable>.

### JavaScript interop

`IJSRuntime.InvokeAsync<T>` allows .NET code to make asynchronous calls to the JavaScript runtime in the user's browser.

The following conditions apply to error handling with `InvokeAsync<T>`:

* If a call to `InvokeAsync<T>` fails synchronously, a .NET exception occurs. A call to `InvokeAsync<T>` my fail, for example, because the supplied arguments can't be serialized. Developer code must catch the exception. If app code in an event handler or component lifecycle method doesn't handle an exception, the resulting exception is fatal to the circuit.
* If a call to `InvokeAsync<T>` fails asynchronously, the .NET <xref:System.Threading.Tasks.Task> fails. A call to `InvokeAsync<T>` may fail, for example, because the JavaScript-side code throws an exception or returns a `Promise` that completed as `rejected`. Developer code must catch the exception. If using the [await](/dotnet/csharp/language-reference/keywords/await) operator, consider wrapping the method call in a [try-catch](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging. Otherwise, the failing code results in an unhandled exception that's fatal to the circuit.
* By default, calls to `InvokeAsync<T>` must complete within a certain period or else the call times out. The default timeout period is one minute. The timeout protects the code against a loss in network connectivity or JavaScript code that never sends back a completion message. If the call times out, the resulting `Task` fails with an <xref:System.OperationCanceledException>. Trap and process the exception with logging.

Similarly, JavaScript code may initiate calls to .NET methods indicated by the [[JSInvokable] attribute](xref:blazor/javascript-interop#invoke-net-methods-from-javascript-functions). If these .NET methods throw an unhandled exception:

* The exception isn't treated as fatal to the circuit.
* The JavaScript-side `Promise` is rejected.

You have the option of using error handling code on either the .NET side or the JavaScript side of the method call.

For more information, see <xref:blazor/javascript-interop>.

### Circuit handlers

Blazor allows code to define a *circuit handler*, which receives notifications when the state of a user's circuit changes. The following states are used:

* `initialized`
* `connected`
* `disconnected`
* `disposed`

Notifications are managed by registering a DI service that inherits from the `CircuitHandler` abstract base class.

If a custom circuit handler's methods throw an unhandled exception, the exception is fatal to the circuit. To tolerate exceptions in a handler's code or called methods, wrap the code in one or more [try-catch](/dotnet/csharp/language-reference/keywords/try-catch) statements with error handling and logging.

### Circuit disposal

When a circuit ends because a user has disconnected and the framework is cleaning up the circuit state, the framework disposes of the circuit's DI scope. Disposing the scope disposes any circuit-scoped DI services that implement <xref:System.IDisposable?displayProperty=fullName>. If any DI service throws an unhandled exception during disposal, the framework logs the exception.

### Prerendering

Blazor components can be prerendered using `Html.RenderComponentAsync` so that their rendered HTML markup is returned as part of the user's initial HTTP request. This works by:

* Creating a new circuit containing all of the prerendered components that are part of the same page.
* Generating the initial HTML.
* Treating the circuit as `disconnected` until the user's browser establishes a SignalR connection back to the same server to resume interactivity on the circuit.

If any component throws an unhandled exception during prerendering, for example, during a lifecycle method or in rendering logic:

* The exception is fatal to the circuit.
* The exception is thrown up the call stack from the `Html.RenderComponentAsync` call. Therefore, the entire HTTP request fails unless the exception is explicitly caught by developer code.

Under normal circumstances when prerendering fails, continuing to build and render the component doesn't make sense because a working component can't be rendered.

To tolerate errors that may occur during prerendering, error handling logic must be placed inside a component that may throw exceptions. Use [try-catch](/dotnet/csharp/language-reference/keywords/try-catch) statements with error handling and logging. Instead of wrapping the call to `RenderComponentAsync` in a `try-catch` statement, place error handling logic in the component rendered by `RenderComponentAsync`.

## Advanced scenarios

### Recursive rendering

Components can be nested recursively. This is useful for representing recursive data structures. For example, a `TreeNode` component can render more `TreeNode` components for each of the node's children.

When rendering recursively, avoid coding patterns that result in infinite recursion:

* Don't recursively render a data structure that contains a cycle. For example, don't render a tree node whose children includes itself.
* Don't create a chain of layouts that contain a cycle. For example, don't create a layout whose layout is itself.
* Don't allow an end user to violate recursion invariants (rules) through malicious data entry or JavaScript interop calls.

Infinite loops during rendering:

* Causes the rendering process to continue forever.
* Is equivalent to creating an unterminated loop.

In these scenarios, the affected circuit hangs, and the thread usually attempts to:

* Consume as much CPU time as permitted by the operating system, indefinitely.
* Consume an unlimited amount of server memory. Consuming unlimited memory is equivalent to the scenario where an unterminated loop adds entries to a collection on every iteration.

To avoid infinite recursion patterns, ensure that recursive rendering code contains suitable stopping conditions.

### Custom render tree logic

Most Blazor components are implemented as *.razor* files and are compiled to produce logic that operates on a `RenderTreeBuilder` to render their output. A developer may manually implement `RenderTreeBuilder` logic using procedural C# code. For more information, see <xref:blazor/components#manual-rendertreebuilder-logic>.

> [!WARNING]
> Use of manual render tree builder logic is considered an advanced and unsafe scenario, not recommended for general component development.

If `RenderTreeBuilder` code is written, the developer must guarantee the correctness of the code. For example, the developer must ensure that:

* Calls to `OpenElement` and `CloseElement` are correctly balanced.
* Attributes are only added in the correct places.

Incorrect manual render tree builder logic can cause arbitrary undefined behavior, including crashes, server hangs, and security vulnerabilities.

Consider manual render tree builder logic on the same level of complexity and with the same level of *danger* as writing assembly code or MSIL instructions by hand.
