---
title: ASP.NET Core Blazor rendering performance best practices
author: guardrex
description: Tips for improving the rendering performance of ASP.NET Core Blazor apps and avoiding common performance problems.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 04/16/2025
uid: blazor/performance/rendering
---
# ASP.NET Core Blazor rendering performance best practices

[!INCLUDE[](~/includes/not-latest-version.md)]

Optimize rendering speed to minimize rendering workload and improve UI responsiveness, which can yield a *ten-fold or higher improvement* in UI rendering speed.

## Avoid unnecessary rendering of component subtrees

You might be able to remove the majority of a parent component's rendering cost by skipping the rerendering of child component subtrees when an event occurs. You should only be concerned about skipping the rerendering subtrees that are particularly expensive to render and are causing UI lag.

At runtime, components exist in a hierarchy. A root component (the first component loaded) has child components. In turn, the root's children have their own child components, and so on. When an event occurs, such as a user selecting a button, the following process determines which components to rerender:

1. The event is dispatched to the component that rendered the event's handler. After executing the event handler, the component is rerendered.
1. When a component is rerendered, it supplies a new copy of parameter values to each of its child components.
1. After a new set of parameter values is received, Blazor decides whether to rerender the component. Components rerender if [`ShouldRender`](xref:blazor/components/rendering#suppress-ui-refreshing-shouldrender) returns `true`, which is the default behavior unless overridden, and the parameter values may have changed, for example, if they're mutable objects.

The last two steps of the preceding sequence continue recursively down the component hierarchy. In many cases, the entire subtree is rerendered. Events targeting high-level components can cause expensive rerendering because every component below the high-level component must rerender.

To prevent rendering recursion into a particular subtree, use either of the following approaches:

* Ensure that child component parameters are of specific immutable types&dagger;, such as `string`, `int`, `bool`, and `DateTime`. The built-in logic for detecting changes automatically skips rerendering if the immutable parameter values haven't changed. If you render a child component with `<Customer CustomerId="item.CustomerId" />`, where `CustomerId` is an `int` type, then the `Customer` component isn't rerendered unless `item.CustomerId` changes.
* Override [`ShouldRender`](xref:blazor/components/rendering#suppress-ui-refreshing-shouldrender), returning `false`:
  * When parameters are nonprimitive types or unsupported immutable types&dagger;, such as complex custom model types or <xref:Microsoft.AspNetCore.Components.RenderFragment> values, and the parameter values haven't changed,
  * If authoring a UI-only component that doesn't change after the initial render, regardless of parameter value changes.

&dagger;For more information, see [the change detection logic in Blazor's reference source (`ChangeDetection.cs`)](https://github.com/dotnet/aspnetcore/blob/main/src/Components/Components/src/ChangeDetection.cs).

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

The following airline flight search tool example uses private fields to track the necessary information to detect changes. The previous inbound flight identifier (`prevInboundFlightId`) and previous outbound flight identifier (`prevOutboundFlightId`) track information for the next potential component update. If either of the flight identifiers change when the component's parameters are set in [`OnParametersSet`](xref:blazor/components/lifecycle#after-parameters-are-set-onparameterssetasync), the component is rerendered because `shouldRender` is set to `true`. If `shouldRender` evaluates to `false` after checking the flight identifiers, an expensive rerender is avoided:

```razor
@code {
    private int prevInboundFlightId = 0;
    private int prevOutboundFlightId = 0;
    private bool shouldRender;

    [Parameter]
    public FlightInfo? InboundFlight { get; set; }

    [Parameter]
    public FlightInfo? OutboundFlight { get; set; }

    protected override void OnParametersSet()
    {
        shouldRender = InboundFlight?.FlightId != prevInboundFlightId
            || OutboundFlight?.FlightId != prevOutboundFlightId;

        prevInboundFlightId = InboundFlight?.FlightId ?? 0;
        prevOutboundFlightId = OutboundFlight?.FlightId ?? 0;
    }

    protected override bool ShouldRender() => shouldRender;
}
```

An event handler can also set `shouldRender` to `true`. For most components, determining rerendering at the level of individual event handlers usually isn't necessary.

For more information, see the following resources:

* <xref:blazor/components/lifecycle>
* <xref:Microsoft.AspNetCore.Components.ComponentBase.ShouldRender%2A>
* <xref:blazor/components/rendering#suppress-ui-refreshing-shouldrender>

:::moniker range=">= aspnetcore-5.0"

## Virtualization

When rendering large amounts of UI within a loop, for example, a list or grid with thousands of entries, the sheer quantity of rendering operations can lead to a lag in UI rendering. Given that the user can only see a small number of elements at once without scrolling, it's often wasteful to spend time rendering elements that aren't currently visible.

Blazor provides the <xref:Microsoft.AspNetCore.Components.Web.Virtualization.Virtualize%601> component to create the appearance and scroll behaviors of an arbitrarily-large list while only rendering the list items that are within the current scroll viewport. For example, a component can render a list with 100,000 entries but only pay the rendering cost of 20 items that are visible.

For more information, see <xref:blazor/components/virtualization>.

:::moniker-end

## Create lightweight, optimized components

Most Razor components don't require aggressive optimization efforts because most components don't repeat in the UI and don't rerender at high frequency. For example, routable components with an `@page` directive and components used to render high-level pieces of the UI, such as dialogs or forms, most likely appear only one at a time and only rerender in response to a user gesture. These components don't usually create high rendering workload, so you can freely use any combination of framework features without much concern about rendering performance.

However, there are common scenarios where components are repeated at scale and often result in poor UI performance:

* Large nested forms with hundreds of individual elements, such as inputs or labels.
* Grids with hundreds of rows or thousands of cells.
* Scatter plots with millions of data points.

If modelling each element, cell, or data point as a separate component instance, there are often so many of them that their rendering performance becomes critical. This section provides advice on making such components lightweight so that the UI remains fast and responsive.

## Avoid thousands of component instances

Each component is a separate island that can render independently of its parents and children. By choosing how to split the UI into a hierarchy of components, you are taking control over the granularity of UI rendering. This can result in either good or poor performance.

By splitting the UI into separate components, you can have smaller portions of the UI rerender when events occur. In a table with many rows that have a button in each row, you may be able to have only that single row rerender by using a child component instead of the whole page or table. However, each component requires additional memory and CPU overhead to deal with its independent state and rendering lifecycle.

In a test performed by the ASP.NET Core product unit engineers, a rendering overhead of around 0.06 ms per component instance was seen in a Blazor WebAssembly app. The test app rendered a simple component that accepts three parameters. Internally, the overhead is largely due to retrieving per-component state from dictionaries and passing and receiving parameters. By multiplication, you can see that adding 2,000 extra component instances would add 0.12 seconds to the rendering time and the UI would begin feeling slow to users.

It's possible to make components more lightweight so that you can have more of them. However, a more powerful technique is often to avoid having so many components to render. The following sections describe two approaches that you can take.

For more information on memory management, see <xref:blazor/host-and-deploy/server/memory-management>.

**Inline child components into their parents:** Consider the following portion of a parent component that renders child components in a loop:

```razor
<div class="chat">
    @foreach (var message in messages)
    {
        <ChatMessageDisplay Message="message" />
    }
</div>
```

`ChatMessageDisplay.razor`: 

```razor
<div class="chat-message">
    <span class="author">@Message.Author</span>
    <span class="text">@Message.Text</span>
</div>

@code {
    [Parameter]
    public ChatMessage? Message { get; set; }
}
```

The preceding example performs well if thousands of messages aren't shown at once. To show thousands of messages at once, consider *not* factoring out the separate `ChatMessageDisplay` component. Instead, inline the child component into the parent. The following approach avoids the per-component overhead of rendering so many child components at the cost of losing the ability to rerender each child component's markup independently:

```razor
<div class="chat">
    @foreach (var message in messages)
    {
        <div class="chat-message">
            <span class="author">@message.Author</span>
            <span class="text">@message.Text</span>
        </div>
    }
</div>
```

**Define reusable `RenderFragments` in code:** You might be factoring out child components purely as a way of reusing rendering logic. If that's the case, you can create reusable rendering logic without implementing additional components. In any component's `@code` block, define a <xref:Microsoft.AspNetCore.Components.RenderFragment>. Render the fragment from any location as many times as needed:

```razor
@RenderWelcomeInfo

<p>Render the welcome content a second time:</p>

@RenderWelcomeInfo

@code {
    private RenderFragment RenderWelcomeInfo = @<p>Welcome to your new app!</p>;
}
```

To make <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> code reusable across multiple components, declare the <xref:Microsoft.AspNetCore.Components.RenderFragment> [`public`](/dotnet/csharp/language-reference/keywords/public) and [`static`](/dotnet/csharp/language-reference/keywords/static):

```razor
public static RenderFragment SayHello = @<h1>Hello!</h1>;
```

`SayHello` in the preceding example can be invoked from an unrelated component. This technique is useful for building libraries of reusable markup snippets that render without per-component overhead.

<xref:Microsoft.AspNetCore.Components.RenderFragment> delegates can accept parameters. The following component passes the message (`message`) to the <xref:Microsoft.AspNetCore.Components.RenderFragment> delegate:

```razor
<div class="chat">
    @foreach (var message in messages)
    {
        @ChatMessageDisplay(message)
    }
</div>

@code {
    private RenderFragment<ChatMessage> ChatMessageDisplay = message =>
        @<div class="chat-message">
            <span class="author">@message.Author</span>
            <span class="text">@message.Text</span>
        </div>;
}
```

The preceding approach reuses rendering logic without per-component overhead. However, the approach doesn't permit refreshing the subtree of the UI independently, nor does it have the ability to skip rendering the subtree of the UI when its parent renders because there's no component boundary. Assignment to a <xref:Microsoft.AspNetCore.Components.RenderFragment> delegate is only supported in Razor component files (`.razor`).

For a non-static field, method, or property that can't be referenced by a field initializer, such as `TitleTemplate` in the following example, use a property instead of a field for the <xref:Microsoft.AspNetCore.Components.RenderFragment>:

```csharp
protected RenderFragment DisplayTitle =>
    @<div>
        @TitleTemplate
    </div>;
```

## Don't receive too many parameters

If a component repeats extremely often, for example, hundreds or thousands of times, the overhead of passing and receiving each parameter builds up.

It's rare that too many parameters severely restricts performance, but it can be a factor. For a `TableCell` component that renders 4,000 times within a grid, each parameter passed to the component adds around 15 ms to the total rendering cost. Passing ten parameters requires around 150 ms and causes a UI rendering lag.

To reduce parameter load, bundle multiple parameters in a custom class. For example, a table cell component might accept a common object. In the following example, `Data` is different for every cell, but `Options` is common across all cell instances:

```razor
@typeparam TItem

...

@code {
    [Parameter]
    public TItem? Data { get; set; }
    
    [Parameter]
    public GridOptions? Options { get; set; }
}
```

However, keep in mind that bundling primitive parameters into a class isn't always an advantage. While it can reduce parameter count, it also impacts how change detection and rendering behave. Passing non-primitive parameters always triggers a re-render, because Blazor can't know whether arbitrary objects have internally mutable state, whereas passing primitive parameters only triggers a re-render if their values have actually changed.

Also, consider that it might be an improvement not to have a table cell component, as shown in the preceding example, and instead [inline its logic into the parent component](#avoid-thousands-of-component-instances).

> [!NOTE]
> When multiple approaches are available for improving performance, benchmarking the approaches is usually required to determine which approach yields the best results.

For more information on generic type parameters (`@typeparam`), see the following resources:

* <xref:mvc/views/razor#typeparam>
* <xref:blazor/components/index#generic-type-parameter-support>
* <xref:blazor/components/templated-components>

## Ensure cascading parameters are fixed

The [`CascadingValue` component](xref:blazor/components/cascading-values-and-parameters#cascadingvalue-component) has an optional `IsFixed` parameter:

* If `IsFixed` is `false` (the default), every recipient of the cascaded value sets up a subscription to receive change notifications. Each `[CascadingParameter]` is **substantially more expensive** than a regular `[Parameter]` due to the subscription tracking.
* If `IsFixed` is `true` (for example, `<CascadingValue Value="someValue" IsFixed="true">`), recipients receive the initial value but don't set up a subscription to receive updates. Each `[CascadingParameter]` is lightweight and no more expensive than a regular `[Parameter]`.

Setting `IsFixed` to `true` improves performance if there are a large number of other components that receive the cascaded value. Wherever possible, set `IsFixed` to `true` on cascaded values. You can set `IsFixed` to `true` when the supplied value doesn't change over time.

Where a component passes `this` as a cascaded value, `IsFixed` can also be set to `true`, because `this` never changes during the component's lifecycle:

```razor
<CascadingValue Value="this" IsFixed="true">
    <SomeOtherComponents>
</CascadingValue>
```

For more information, see <xref:blazor/components/cascading-values-and-parameters>.

## Avoid attribute splatting with `CaptureUnmatchedValues`

Components can elect to receive "unmatched" parameter values using the <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues> flag:

```razor
<div @attributes="OtherAttributes">...</div>

@code {
    [Parameter(CaptureUnmatchedValues = true)]
    public IDictionary<string, object>? OtherAttributes { get; set; }
}
```

This approach allows passing arbitrary additional attributes to the element. However, this approach is expensive because the renderer must:

* Match all of the supplied parameters against the set of known parameters to build a dictionary.
* Keep track of how multiple copies of the same attribute overwrite each other.

Use <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues> where component rendering performance isn't critical, such as components that aren't repeated frequently. For components that render at scale, such as each item in a large list or in the cells of a grid, try to avoid attribute splatting.

For more information, see <xref:blazor/components/attribute-splatting>.

## Implement `SetParametersAsync` manually

A significant source of per-component rendering overhead is writing incoming parameter values to `[Parameter]` properties. The renderer uses [reflection](/dotnet/csharp/advanced-topics/reflection-and-attributes/) to write the parameter values, which can lead to poor performance at scale.

In some extreme cases, you may wish to avoid the reflection and implement your own parameter-setting logic manually. This may be applicable when:

* A component renders extremely often, for example, when there are hundreds or thousands of copies of the component in the UI.
* A component accepts many parameters.
* You find that the overhead of receiving parameters has an observable impact on UI responsiveness.

In extreme cases, you can override the component's virtual <xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A> method and implement your own component-specific logic. The following example deliberately avoids dictionary lookups:

```razor
@code {
    [Parameter]
    public int MessageId { get; set; }

    [Parameter]
    public string? Text { get; set; }

    [Parameter]
    public EventCallback<string> TextChanged { get; set; }

    [Parameter]
    public Theme CurrentTheme { get; set; }

    public override Task SetParametersAsync(ParameterView parameters)
    {
        foreach (var parameter in parameters)
        {
            switch (parameter.Name)
            {
                case nameof(MessageId):
                    MessageId = (int)parameter.Value;
                    break;
                case nameof(Text):
                    Text = (string)parameter.Value;
                    break;
                case nameof(TextChanged):
                    TextChanged = (EventCallback<string>)parameter.Value;
                    break;
                case nameof(CurrentTheme):
                    CurrentTheme = (Theme)parameter.Value;
                    break;
                default:
                    throw new ArgumentException($"Unknown parameter: {parameter.Name}");
            }
        }

        return base.SetParametersAsync(ParameterView.Empty);
    }
}
```

In the preceding code, returning the base class <xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A> runs the normal lifecycle method without assigning parameters again.

As you can see in the preceding code, overriding <xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A> and supplying custom logic is complicated and laborious, so we don't generally recommend adopting this approach. In extreme cases, it can improve rendering performance by 20-25%, but you should only consider this approach in the extreme scenarios listed earlier in this section.

## Don't trigger events too rapidly

Some browser events fire extremely frequently. For example, `onmousemove` and `onscroll` can fire tens or hundreds of times per second. In most cases, you don't need to perform UI updates this frequently. If events are triggered too rapidly, you may harm UI responsiveness or consume excessive CPU time.

Rather than use native events that rapidly fire, consider the use of JS interop to register a callback that fires less frequently. For example, the following component displays the position of the mouse but only updates at most once every 500 ms:

```razor
@implements IDisposable
@inject IJSRuntime JS

<h1>@message</h1>

<div @ref="mouseMoveElement" style="border:1px dashed red;height:200px;">
    Move mouse here
</div>

@code {
    private ElementReference mouseMoveElement;
    private DotNetObjectReference<MyComponent>? selfReference;
    private string message = "Move the mouse in the box";

    [JSInvokable]
    public void HandleMouseMove(int x, int y)
    {
        message = $"Mouse move at {x}, {y}";
        StateHasChanged();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            selfReference = DotNetObjectReference.Create(this);
            var minInterval = 500;

            await JS.InvokeVoidAsync("onThrottledMouseMove", 
                mouseMoveElement, selfReference, minInterval);
        }
    }

    public void Dispose() => selfReference?.Dispose();
}
```

The corresponding JavaScript code registers the DOM event listener for mouse movement. In this example, the event listener uses [Lodash's `throttle` function](https://lodash.com/docs/4.17.15#throttle) to limit the rate of invocations:

```html
<script src="https://cdnjs.cloudflare.com/ajax/libs/lodash.js/4.17.20/lodash.min.js"></script>
<script>
  function onThrottledMouseMove(elem, component, interval) {
    elem.addEventListener('mousemove', _.throttle(e => {
      component.invokeMethodAsync('HandleMouseMove', e.offsetX, e.offsetY);
    }, interval));
  }
</script>
```

## Avoid rerendering after handling events without state changes

Components inherit from <xref:Microsoft.AspNetCore.Components.ComponentBase>, which automatically invokes <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> after the component's event handlers are invoked. In some cases, it might be unnecessary or undesirable to trigger a rerender after an event handler is invoked. For example, an event handler might not modify component state. In these scenarios, the app can leverage the <xref:Microsoft.AspNetCore.Components.IHandleEvent> interface to control the behavior of Blazor's event handling.

> [!NOTE]
> The approach in this section doesn't flow exceptions to [error boundaries](xref:blazor/fundamentals/handle-errors#error-boundaries). For more information and demonstration code that supports error boundaries by calling <xref:Microsoft.AspNetCore.Components.ComponentBase.DispatchExceptionAsync%2A?displayProperty=nameWithType>, see [AsNonRenderingEventHandler + ErrorBoundary = unexpected behavior (`dotnet/aspnetcore` #54543)](https://github.com/dotnet/aspnetcore/issues/54543).

To prevent rerenders for all of a component's event handlers, implement <xref:Microsoft.AspNetCore.Components.IHandleEvent> and provide a <xref:Microsoft.AspNetCore.Components.IHandleEvent.HandleEventAsync%2A?displayProperty=nameWithType> task that invokes the event handler without calling <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A>.

In the following example, no event handler added to the component triggers a rerender, so `HandleSelect` doesn't result in a rerender when invoked.

`HandleSelect1.razor`:

```razor
@page "/handle-select-1"
@using Microsoft.Extensions.Logging
@implements IHandleEvent
@inject ILogger<HandleSelect1> Logger

<p>
    Last render DateTime: @dt
</p>

<button @onclick="HandleSelect">
    Select me (Avoids Rerender)
</button>

@code {
    private DateTime dt = DateTime.Now;

    private void HandleSelect()
    {
        dt = DateTime.Now;

        Logger.LogInformation("This event handler doesn't trigger a rerender.");
    }

    Task IHandleEvent.HandleEventAsync(
        EventCallbackWorkItem callback, object? arg) => callback.InvokeAsync(arg);
}
```

In addition to preventing rerenders after event handlers fire in a component in a global fashion, it's possible to prevent rerenders after a single event handler by employing the following utility method.

Add the following `EventUtil` class to a Blazor app. The static actions and functions at the top of the `EventUtil` class provide handlers that cover several combinations of arguments and return types that Blazor uses when handling events.

`EventUtil.cs`:

```csharp
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

public static class EventUtil
{
    public static Action AsNonRenderingEventHandler(Action callback)
        => new SyncReceiver(callback).Invoke;
    public static Action<TValue> AsNonRenderingEventHandler<TValue>(
            Action<TValue> callback)
        => new SyncReceiver<TValue>(callback).Invoke;
    public static Func<Task> AsNonRenderingEventHandler(Func<Task> callback)
        => new AsyncReceiver(callback).Invoke;
    public static Func<TValue, Task> AsNonRenderingEventHandler<TValue>(
            Func<TValue, Task> callback)
        => new AsyncReceiver<TValue>(callback).Invoke;

    private record SyncReceiver(Action callback) 
        : ReceiverBase { public void Invoke() => callback(); }
    private record SyncReceiver<T>(Action<T> callback) 
        : ReceiverBase { public void Invoke(T arg) => callback(arg); }
    private record AsyncReceiver(Func<Task> callback) 
        : ReceiverBase { public Task Invoke() => callback(); }
    private record AsyncReceiver<T>(Func<T, Task> callback) 
        : ReceiverBase { public Task Invoke(T arg) => callback(arg); }

    private record ReceiverBase : IHandleEvent
    {
        public Task HandleEventAsync(EventCallbackWorkItem item, object arg) => 
            item.InvokeAsync(arg);
    }
}
```

Call `EventUtil.AsNonRenderingEventHandler` to call an event handler that doesn't trigger a render when invoked.

In the following example:

* Selecting the first button, which calls `HandleClick1`, triggers a rerender.
* Selecting the second button, which calls `HandleClick2`, doesn't trigger a rerender.
* Selecting the third button, which calls `HandleClick3`, doesn't trigger a rerender and uses [event arguments](xref:blazor/components/event-handling#event-arguments) (<xref:Microsoft.AspNetCore.Components.Web.MouseEventArgs>).

`HandleSelect2.razor`:

```razor
@page "/handle-select-2"
@using Microsoft.Extensions.Logging
@inject ILogger<HandleSelect2> Logger

<p>
    Last render DateTime: @dt
</p>

<button @onclick="HandleClick1">
    Select me (Rerenders)
</button>

<button @onclick="EventUtil.AsNonRenderingEventHandler(HandleClick2)">
    Select me (Avoids Rerender)
</button>

<button @onclick="EventUtil.AsNonRenderingEventHandler<MouseEventArgs>(HandleClick3)">
    Select me (Avoids Rerender and uses <code>MouseEventArgs</code>)
</button>

@code {
    private DateTime dt = DateTime.Now;

    private void HandleClick1()
    {
        dt = DateTime.Now;

        Logger.LogInformation("This event handler triggers a rerender.");
    }

    private void HandleClick2()
    {
        dt = DateTime.Now;

        Logger.LogInformation("This event handler doesn't trigger a rerender.");
    }
    
    private void HandleClick3(MouseEventArgs args)
    {
        dt = DateTime.Now;

        Logger.LogInformation(
            "This event handler doesn't trigger a rerender. " +
            "Mouse coordinates: {ScreenX}:{ScreenY}", 
            args.ScreenX, args.ScreenY);
    }
}
```

In addition to implementing the <xref:Microsoft.AspNetCore.Components.IHandleEvent> interface, leveraging the other best practices described in this article can also help reduce unwanted renders after events are handled. For example, overriding <xref:Microsoft.AspNetCore.Components.ComponentBase.ShouldRender%2A> in child components of the target component can be used to control rerendering.

## Avoid recreating delegates for many repeated elements or components

Blazor's recreation of [lambda expression delegates](xref:blazor/components/event-handling#lambda-expressions) for elements or components in a loop can lead to poor performance.

The following component shown in the [event handling article](xref:blazor/components/event-handling#lambda-expressions) renders a set of buttons. Each button assigns a delegate to its `@onclick` event, which is fine if there aren't many buttons to render.

`EventHandlerExample5.razor`:

:::moniker range=">= aspnetcore-8.0"

```razor
@page "/event-handler-example-5"

<h1>@heading</h1>

@for (var i = 1; i < 4; i++)
{
    var buttonNumber = i;

    <p>
        <button @onclick="@(e => UpdateHeading(e, buttonNumber))">
            Button #@i
        </button>
    </p>
}

@code {
    private string heading = "Select a button to learn its position";

    private void UpdateHeading(MouseEventArgs e, int buttonNumber)
    {
        heading = $"Selected #{buttonNumber} at {e.ClientX}:{e.ClientY}";
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/event-handling/EventHandlerExample5.razor":::

:::moniker-end

If a large number of buttons are rendered using the preceding approach, rendering speed is adversely impacted leading to a poor user experience. To render a large number of buttons with a callback for click events, the following example uses a collection of button objects that assign each button's `@onclick` delegate to an <xref:System.Action>. The following approach doesn't require Blazor to rebuild all of the button delegates each time the buttons are rendered:

`LambdaEventPerformance.razor`:

```razor
@page "/lambda-event-performance"

<h1>@heading</h1>

@foreach (var button in Buttons)
{
    <p>
        <button @key="button.Id" @onclick="button.Action">
            Button #@button.Id
        </button>
    </p>
}

@code {
    private string heading = "Select a button to learn its position";

    private List<Button> Buttons { get; set; } = new();

    protected override void OnInitialized()
    {
        for (var i = 0; i < 100; i++)
        {
            var button = new Button();

            button.Id = Guid.NewGuid().ToString();

            button.Action = (e) =>
            {
                UpdateHeading(button, e);
            };

            Buttons.Add(button);
        }
    }

    private void UpdateHeading(Button button, MouseEventArgs e)
    {
        heading = $"Selected #{button.Id} at {e.ClientX}:{e.ClientY}";
    }

    private class Button
    {
        public string? Id { get; set; }
        public Action<MouseEventArgs> Action { get; set; } = e => { };
    }
}
```
