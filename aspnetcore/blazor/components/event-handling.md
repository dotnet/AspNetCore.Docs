---
title: ASP.NET Core Blazor event handling
author: guardrex
description: Learn about Blazor's event handling features, including event argument types, event callbacks, and managing default browser events.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 01/16/2024
uid: blazor/components/event-handling
---
# ASP.NET Core Blazor event handling

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains Blazor's event handling features, including event argument types, event callbacks, and managing default browser events.

[!INCLUDE[](~/blazor/includes/location-client-and-server-pre-net8.md)]

## Delegate event handlers

Specify delegate event handlers in Razor component markup with [`@on{DOM EVENT}="{DELEGATE}"`](xref:mvc/views/razor#onevent) Razor syntax:

* The `{DOM EVENT}` placeholder is a [DOM event](https://developer.mozilla.org/docs/Web/Events) (for example, `click`).
* The `{DELEGATE}` placeholder is the C# delegate event handler.

For event handling:

* Asynchronous delegate event handlers that return a <xref:System.Threading.Tasks.Task> are supported.
* Delegate event handlers automatically trigger a UI render, so there's no need to manually call [`StateHasChanged`](xref:blazor/components/lifecycle#state-changes-statehaschanged).
* Exceptions are logged.

The following code:

* Calls the `UpdateHeading` method when the button is selected in the UI.
* Calls the `CheckChanged` method when the checkbox is changed in the UI.

:::moniker range=">= aspnetcore-8.0"

`EventHandler1.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/EventHandler1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`EventHandlerExample1.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample1.razor" highlight="10,17,27-30,32-35":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

`EventHandlerExample1.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample1.razor" highlight="10,17,27-30,32-35":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

`EventHandlerExample1.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample1.razor" highlight="10,17,27-30,32-35":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

`EventHandlerExample1.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample1.razor" highlight="10,17,27-30,32-35":::

:::moniker-end

In the following example, `UpdateHeading`:

* Is called asynchronously when the button is selected.
* Waits two seconds before updating the heading.

:::moniker range=">= aspnetcore-8.0"

`EventHandler2.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/EventHandler2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`EventHandlerExample2.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample2.razor" highlight="10,19-24":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

`EventHandlerExample2.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample2.razor" highlight="10,19-24":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

`EventHandlerExample2.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample2.razor" highlight="10,19-24":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

`EventHandlerExample2.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample2.razor" highlight="10,19-24":::

:::moniker-end

## Built-in event arguments

For events that support an event argument type, specifying an event parameter in the event method definition is only necessary if the event type is used in the method. In the following example, <xref:Microsoft.AspNetCore.Components.Web.MouseEventArgs> is used in the `ReportPointerLocation` method to set message text that reports the mouse coordinates when the user selects a button in the UI.

:::moniker range=">= aspnetcore-8.0"

`EventHandler3.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/EventHandler3.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`EventHandlerExample3.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample3.razor" highlight="17-20":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

`EventHandlerExample3.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample3.razor" highlight="17-20":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

`EventHandlerExample3.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample3.razor" highlight="17-20":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

`EventHandlerExample3.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample3.razor" highlight="17-20":::

:::moniker-end

Supported <xref:System.EventArgs> are shown in the following table.

| Event            | Class  | DOM notes |
| ---------------- | ------ | --- |
| Clipboard        | <xref:Microsoft.AspNetCore.Components.Web.ClipboardEventArgs> | |
| Drag             | <xref:Microsoft.AspNetCore.Components.Web.DragEventArgs> | <xref:Microsoft.AspNetCore.Components.Web.DataTransfer> and <xref:Microsoft.AspNetCore.Components.Web.DataTransferItem> hold dragged item data.<br><br>Implement drag and drop in Blazor apps using [JS interop](xref:blazor/js-interop/call-javascript-from-dotnet) with [HTML Drag and Drop API](https://developer.mozilla.org/docs/Web/API/HTML_Drag_and_Drop_API). |
| Error            | <xref:Microsoft.AspNetCore.Components.Web.ErrorEventArgs> | |
| Event            | <xref:System.EventArgs> | <xref:Microsoft.AspNetCore.Components.Web.EventHandlers> holds attributes to configure the mappings between event names and event argument types. |
| Focus            | <xref:Microsoft.AspNetCore.Components.Web.FocusEventArgs> | Doesn't include support for `relatedTarget`. |
| Input            | <xref:Microsoft.AspNetCore.Components.ChangeEventArgs> | |
| Keyboard         | <xref:Microsoft.AspNetCore.Components.Web.KeyboardEventArgs> | |
| Mouse            | <xref:Microsoft.AspNetCore.Components.Web.MouseEventArgs> | |
| Mouse pointer    | <xref:Microsoft.AspNetCore.Components.Web.PointerEventArgs> | |
| Mouse wheel      | <xref:Microsoft.AspNetCore.Components.Web.WheelEventArgs> | |
| Progress         | <xref:Microsoft.AspNetCore.Components.Web.ProgressEventArgs> | |
| Touch            | <xref:Microsoft.AspNetCore.Components.Web.TouchEventArgs> | <xref:Microsoft.AspNetCore.Components.Web.TouchPoint> represents a single contact point on a touch-sensitive device. |

For more information, see the following resources:

* [`EventArgs` classes in the ASP.NET Core reference source (dotnet/aspnetcore `main` branch)](https://github.com/dotnet/aspnetcore/tree/main/src/Components/Web/src/Web)

  [!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

* <xref:Microsoft.AspNetCore.Components.Web.EventHandlers> holds attributes to configure the mappings between event names and event argument types.

:::moniker range=">= aspnetcore-6.0"

## Custom event arguments

Blazor supports custom event arguments, which enable you to pass arbitrary data to .NET event handlers with custom events.

### General configuration

Custom events with custom event arguments are generally enabled with the following steps.

In JavaScript, define a function for building the custom event argument object from the source event:

```javascript
function eventArgsCreator(event) { 
  return {
    customProperty1: 'any value for property 1',
    customProperty2: event.srcElement.id
  };
}
```

The `event` parameter is a [DOM Event (MDN documentation)](https://developer.mozilla.org/docs/Web/API/Event).

Register the custom event with the preceding handler in a [JavaScript initializer](xref:blazor/fundamentals/startup#javascript-initializers). Provide the appropriate browser event name to `browserEventName`, which for the example shown in this section is `click` for a button selection in the UI.

`wwwroot/{PACKAGE ID/ASSEMBLY NAME}.lib.module.js` (the `{PACKAGE ID/ASSEMBLY NAME}` placeholder is the package ID or assembly name of the app):

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

For a Blazor Web App:

```javascript
export function afterWebStarted(blazor) {
  blazor.registerCustomEventType('customevent', {
    browserEventName: 'click',
    createEventArgs: eventArgsCreator
  });
}
```

For a Blazor Server or Blazor WebAssembly app:

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

```javascript
export function afterStarted(blazor) {
  blazor.registerCustomEventType('customevent', {
    browserEventName: 'click',
    createEventArgs: eventArgsCreator
  });
}
```

> [!NOTE]
> The call to `registerCustomEventType` is performed in a script only once per event.
>
> For the call to `registerCustomEventType`, use the `blazor` parameter (lowercase `b`) provided by the Blazor start event. Although the registration is valid when using the `Blazor` object (uppercase `B`), the preferred approach is to use the parameter.

Define a class for the event arguments:

```csharp
namespace BlazorSample.CustomEvents;

public class CustomEventArgs : EventArgs
{
    public string? CustomProperty1 {get; set;}
    public string? CustomProperty2 {get; set;}
}
```

Wire up the custom event with the event arguments by adding an [`[EventHandler]` attribute](xref:Microsoft.AspNetCore.Components.EventHandlerAttribute) annotation for the custom event:

* In order for the compiler to find the `[EventHandler]` class, it must be placed into a C# class file (`.cs`), making it a normal top-level class.
* Mark the class `public`.
* The class doesn't require members.
* The class *must* be called "`EventHandlers`" in order to be found by the Razor compiler.
* Place the class under a namespace specific to your app.
* Import the namespace into the Razor component (`.razor`) where the event is used.

```csharp
using Microsoft.AspNetCore.Components;

namespace BlazorSample.CustomEvents;

[EventHandler("oncustomevent", typeof(CustomEventArgs),
    enableStopPropagation: true, enablePreventDefault: true)]
public static class EventHandlers
{
}
```

Register the event handler on one or more HTML elements. Access the data that was passed in from JavaScript in the delegate handler method:

```razor
@using BlazorSample.CustomEvents

<button id="buttonId" @oncustomevent="HandleCustomEvent">Handle</button>

@if (!string.IsNullOrEmpty(propVal1) && !string.IsNullOrEmpty(propVal2))
{
    <ul>
        <li>propVal1: @propVal1</li>
        <li>propVal2: @propVal2</li>
    </ul>
}

@code
{
    private string? propVal1;
    private string? propVal2;

    private void HandleCustomEvent(CustomEventArgs eventArgs)
    {
        propVal1 = eventArgs.CustomProperty1;
        propVal2 = eventArgs.CustomProperty2;
    }
}
```

If the `@oncustomevent` attribute isn't recognized by [IntelliSense](/visualstudio/ide/using-intellisense), make sure that the component or the `_Imports.razor` file contains an `@using` statement for the namespace containing the `EventHandler` class.

Whenever the custom event is fired on the DOM, the event handler is called with the data passed from the JavaScript.

If you're attempting to fire a custom event, [`bubbles`](https://developer.mozilla.org/docs/Web/API/Event/bubbles) must be enabled by setting its value to `true`. Otherwise, the event doesn't reach the Blazor handler for processing into the C# custom [`[EventHandler]` attribute](xref:Microsoft.AspNetCore.Components.EventHandlerAttribute) class. For more information, see [MDN Web Docs: Event bubbling](https://developer.mozilla.org/docs/Web/Guide/Events/Creating_and_triggering_events#event_bubbling).

### Custom clipboard paste event example

The following example receives a custom clipboard paste event that includes the time of the paste and the user's pasted text.

Declare a custom name (`oncustompaste`) for the event and a .NET class (`CustomPasteEventArgs`) to hold the event arguments for this event:

`CustomEvents.cs`:

```csharp
using Microsoft.AspNetCore.Components;

namespace BlazorSample.CustomEvents;

[EventHandler("oncustompaste", typeof(CustomPasteEventArgs), 
    enableStopPropagation: true, enablePreventDefault: true)]
public static class EventHandlers
{
}

public class CustomPasteEventArgs : EventArgs
{
    public DateTime EventTimestamp { get; set; }
    public string? PastedData { get; set; }
}
```

Add JavaScript code to supply data for the <xref:System.EventArgs> subclass with the preceding handler in a [JavaScript initializer](xref:blazor/fundamentals/startup#javascript-initializers). The following example only handles pasting text, but you could use arbitrary JavaScript APIs to deal with users pasting other types of data, such as images.

`wwwroot/{PACKAGE ID/ASSEMBLY NAME}.lib.module.js`:

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

For a Blazor Web App:

```javascript
export function afterWebStarted(blazor) {
  blazor.registerCustomEventType('custompaste', {
    browserEventName: 'paste',
    createEventArgs: event => {
      return {
        eventTimestamp: new Date(),
        pastedData: event.clipboardData.getData('text')
      };
    }
  });
}
```

For a Blazor Server or Blazor WebAssembly app:

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

```javascript
export function afterStarted(blazor) {
  blazor.registerCustomEventType('custompaste', {
    browserEventName: 'paste',
    createEventArgs: event => {
      return {
        eventTimestamp: new Date(),
        pastedData: event.clipboardData.getData('text')
      };
    }
  });
}
```

In the preceding example, the `{PACKAGE ID/ASSEMBLY NAME}` placeholder of the file name represents the package ID or assembly name of the app.

> [!NOTE]
> For the call to `registerCustomEventType`, use the `blazor` parameter (lowercase `b`) provided by the Blazor start event. Although the registration is valid when using the `Blazor` object (uppercase `B`), the preferred approach is to use the parameter.

The preceding code tells the browser that when a native [`paste`](https://developer.mozilla.org/docs/Web/API/Element/paste_event) event occurs:

* Raise a `custompaste` event.
* Supply the event arguments data using the custom logic stated:
  * For the `eventTimestamp`, create a new date.
  * For the `pastedData`, get the clipboard data as text. For more information, see [MDN Web Docs: ClipboardEvent.clipboardData](https://developer.mozilla.org/docs/Web/API/ClipboardEvent/clipboardData).

Event name conventions differ between .NET and JavaScript:

* In .NET, event names are prefixed with "`on`".
* In JavaScript, event names don't have a prefix.

In a Razor component, attach the custom handler to an element.

`CustomPasteArguments.razor`:

```razor
@page "/custom-paste-arguments"
@using BlazorSample.CustomEvents

<label>
    Try pasting into the following text box:
    <input @oncustompaste="HandleCustomPaste" />
</label>

<p>
    @message
</p>

@code {
    private string? message;

    private void HandleCustomPaste(CustomPasteEventArgs eventArgs)
    {
        message = $"At {eventArgs.EventTimestamp.ToShortTimeString()}, " +
            $"you pasted: {eventArgs.PastedData}";
    }
}
```

:::moniker-end

## Lambda expressions

[Lambda expressions](/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions) are supported as the delegate event handler.

:::moniker range=">= aspnetcore-8.0"

`EventHandler4.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/EventHandler4.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`EventHandlerExample4.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample4.razor" highlight="6":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

`EventHandlerExample4.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample4.razor" highlight="6":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

`EventHandlerExample4.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample4.razor" highlight="6":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

`EventHandlerExample4.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample4.razor" highlight="6":::

:::moniker-end

It's often convenient to close over additional values using C# method parameters, such as when iterating over a set of elements. The following example creates three buttons, each of which calls `UpdateHeading` and passes the following data:

* An event argument (<xref:Microsoft.AspNetCore.Components.Web.MouseEventArgs>) in `e`.
* The button number in `buttonNumber`.

:::moniker range=">= aspnetcore-8.0"

`EventHandler5.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/EventHandler5.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`EventHandlerExample5.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample5.razor" highlight="10,19":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

`EventHandlerExample5.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample5.razor" highlight="10,19":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

`EventHandlerExample5.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample5.razor" highlight="10,19":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

`EventHandlerExample5.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample5.razor" highlight="10,19":::

:::moniker-end

Creating a large number of event delegates in a loop may cause poor rendering performance. For more information, see <xref:blazor/performance#avoid-recreating-delegates-for-many-repeated-elements-or-components>.

Avoid using a loop variable directly in a lambda expression, such as `i` in the preceding `for` loop example. Otherwise, the same variable is used by all lambda expressions, which results in use of the same value in all lambdas. Capture the variable's value in a local variable. In the preceding example:

* The loop variable `i` is assigned to `buttonNumber`.
* `buttonNumber` is used in the lambda expression.

Alternatively, use a `foreach` loop with <xref:System.Linq.Enumerable.Range%2A?displayProperty=nameWithType>, which doesn't suffer from the preceding problem:

```razor
@foreach (var buttonNumber in Enumerable.Range(1,3))
{
    <p>
        <button @onclick="@(e => UpdateHeading(e, buttonNumber))">
            Button #@buttonNumber
        </button>
    </p>
}
```

## EventCallback

A common scenario with nested components is executing a method in a parent component when a child component event occurs. An `onclick` event occurring in the child component is a common use case. To expose events across components, use an <xref:Microsoft.AspNetCore.Components.EventCallback>. A parent component can assign a callback method to a child component's <xref:Microsoft.AspNetCore.Components.EventCallback>.

The following `Child` component demonstrates how a button's `onclick` handler is set up to receive an <xref:Microsoft.AspNetCore.Components.EventCallback> delegate from the sample's `ParentComponent`. The <xref:Microsoft.AspNetCore.Components.EventCallback> is typed with <xref:Microsoft.AspNetCore.Components.Web.MouseEventArgs>, which is appropriate for an `onclick` event from a peripheral device.

`Child.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Child.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/event-handling/Child.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/event-handling/Child.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/event-handling/Child.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/event-handling/Child.razor":::

:::moniker-end

The `Parent` component sets the child's <xref:Microsoft.AspNetCore.Components.EventCallback%601> (`OnClickCallback`) to its `ShowMessage` method.

:::moniker range=">= aspnetcore-8.0"

`ParentChild.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/ParentChild.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`Parent.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/event-handling/Parent.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

`Parent.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/event-handling/Parent.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

`Parent.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/event-handling/Parent.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

`Parent.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/event-handling/Parent.razor":::

:::moniker-end

When the button is selected in the `ChildComponent`:

* The `Parent` component's `ShowMessage` method is called. `message` is updated and displayed in the `Parent` component.
* A call to [`StateHasChanged`](xref:blazor/components/lifecycle#state-changes-statehaschanged) isn't required in the callback's method (`ShowMessage`). <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> is called automatically to rerender the `Parent` component, just as child events trigger component rerendering in event handlers that execute within the child. For more information, see <xref:blazor/components/rendering>.

Use <xref:Microsoft.AspNetCore.Components.EventCallback> and <xref:Microsoft.AspNetCore.Components.EventCallback%601> for event handling and binding component parameters.

Prefer the strongly typed <xref:Microsoft.AspNetCore.Components.EventCallback%601> over <xref:Microsoft.AspNetCore.Components.EventCallback>. <xref:Microsoft.AspNetCore.Components.EventCallback%601> provides enhanced error feedback to users of the component. Similar to other UI event handlers, specifying the event parameter is optional. Use <xref:Microsoft.AspNetCore.Components.EventCallback> when there's no value passed to the callback.

<xref:Microsoft.AspNetCore.Components.EventCallback> and <xref:Microsoft.AspNetCore.Components.EventCallback%601> permit asynchronous delegates. <xref:Microsoft.AspNetCore.Components.EventCallback> is weakly typed and allows passing any type argument in `InvokeAsync(Object)`. <xref:Microsoft.AspNetCore.Components.EventCallback%601> is strongly typed and requires passing a `T` argument in `InvokeAsync(T)` that's assignable to `TValue`.

Invoke an <xref:Microsoft.AspNetCore.Components.EventCallback> or <xref:Microsoft.AspNetCore.Components.EventCallback%601> with <xref:Microsoft.AspNetCore.Components.EventCallback.InvokeAsync%2A> and await the <xref:System.Threading.Tasks.Task>:

```csharp
await OnClickCallback.InvokeAsync();
```

The following parent-child example demonstrates the technique.

`Child2.razor`:

```razor
<h3>Child2 Component</h3>

<button @onclick="TriggerEvent">Click Me</button>

@code {
    [Parameter]
    public EventCallback<string> OnClickCallback { get; set; }

    private async Task TriggerEvent()
    {
        await OnClickCallback.InvokeAsync("Blaze It!");
    }
}
```

`ParentChild2.razor`:

```razor
@page "/parent-child-2"

<Child2 OnClickCallback="@(async (value) => { await Task.Yield(); messageText = value; })" />

<p>
    @messageText
</p>

@code {
    private string messageText = string.Empty;
}
```

## Prevent default actions

Use the [`@on{DOM EVENT}:preventDefault`](xref:mvc/views/razor#oneventpreventdefault) directive attribute to prevent the default action for an event, where the `{DOM EVENT}` placeholder is a [DOM event](https://developer.mozilla.org/docs/Web/Events).

When a key is selected on an input device and the element focus is on a text box, a browser normally displays the key's character in the text box. In the following example, the default behavior is prevented by specifying the `@onkeydown:preventDefault` directive attribute. When the focus is on the `<input>` element, the counter increments with the key sequence <kbd>Shift</kbd>+<kbd>+</kbd>. The `+` character isn't assigned to the `<input>` element's value. For more information on `keydown`, see [`MDN Web Docs: Document: keydown` event](https://developer.mozilla.org/docs/Web/API/Document/keydown_event).

:::moniker range=">= aspnetcore-8.0"

`EventHandler6.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/EventHandler6.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`EventHandlerExample6.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample6.razor" highlight="4":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

`EventHandlerExample6.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample6.razor" highlight="4":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

`EventHandlerExample6.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample6.razor" highlight="4":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

`EventHandlerExample6.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample6.razor" highlight="4":::

:::moniker-end

Specifying the `@on{DOM EVENT}:preventDefault` attribute without a value is equivalent to `@on{DOM EVENT}:preventDefault="true"`.

An expression is also a permitted value of the attribute. In the following example, `shouldPreventDefault` is a `bool` field set to either `true` or `false`:

```razor
<input @onkeydown:preventDefault="shouldPreventDefault" />

...

@code {
    private bool shouldPreventDefault = true;
}
```

## Stop event propagation

Use the [`@on{DOM EVENT}:stopPropagation`](xref:mvc/views/razor#oneventstoppropagation) directive attribute to stop event propagation within the Blazor scope. `{DOM EVENT}` is a placeholder for a [DOM event](https://developer.mozilla.org/docs/Web/Events).

The `stopPropagation` directive attribute's effect is limited to the Blazor scope and doesn't extend to the HTML DOM. Events must propagate to the HTML DOM root before Blazor can act upon them. For a mechanism to prevent HTML DOM event propagation, consider the following approach:

* Obtain the event's path by calling [`Event.composedPath()`](https://developer.mozilla.org/docs/Web/API/Event/composedPath).
* Filter events based on the composed [event targets (`EventTarget`)](https://developer.mozilla.org/docs/Web/API/EventTarget). 

In the following example, selecting the checkbox prevents click events from the second child `<div>` from propagating to the parent `<div>`. Since propagated click events normally fire the `OnSelectParentDiv` method, selecting the second child `<div>` results in the parent `<div>` message appearing unless the checkbox is selected.

:::moniker range=">= aspnetcore-8.0"

`EventHandler7.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/EventHandler7.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`EventHandlerExample7.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample7.razor" highlight="4,15-16":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

`EventHandlerExample7.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample7.razor" highlight="4,15-16":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

`EventHandlerExample7.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample7.razor" highlight="4,15-16":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

`EventHandlerExample7.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample7.razor" highlight="4,15-16":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

## Focus an element

Call <xref:Microsoft.AspNetCore.Components.ElementReferenceExtensions.FocusAsync%2A> on an [element reference](xref:blazor/js-interop/call-javascript-from-dotnet#capture-references-to-elements) to focus an element in code. In the following example, select the button to focus the `<input>` element.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

`EventHandler8.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/EventHandler8.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`EventHandlerExample8.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample8.razor" highlight="16":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

`EventHandlerExample8.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample8.razor" highlight="16":::

:::moniker-end
