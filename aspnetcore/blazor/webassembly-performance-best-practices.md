---
title: ASP.NET Core Blazor WebAssembly performance best practices
author: pranavkm
description: Tips for increasing performance in ASP.NET Core Blazor WebAssembly apps and avoiding common performance problems.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.custom: mvc
ms.date: 09/09/2020
no-loc: ["ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/webassembly-performance-best-practices
---
# ASP.NET Core Blazor WebAssembly performance best practices

By [Pranav Krishnamoorthy](https://github.com/pranavkm) and [Steve Sanderson](https://github.com/SteveSandersonMS)

Blazor WebAssembly is carefully designed and optimized to enable strong performance in almost any realistic application UI scenario. However, producing the best results depends on developers using the right patterns and features. Two aspects to consider are:

 * **Startup time**. Your application needs to transfer a .NET runtime into the browser, so it's important to use features that [minimize the application download size](#minimizing-application-download-size).
 * **Runtime throughput**. Your .NET code runs on an interpreter within the WebAssembly runtime, so CPU throughput is limited, and in demanding scenarios you will benefit from [optimizing rendering speed](#optimizing-rendering-speed).

## Optimizing rendering speed

The following sections provide recommendations to minimize rendering workload and improve UI responsiveness. Following this advice could easily make a 10x difference in UI rendering speeds (or more!) compared with not doing so.

### Avoid unnecessary rendering of component subtrees

At runtime, your components exist as a hierarchy. You have a root component which has child components. In turn, they have children, and so on. When an event occurs, such as a user clicking a button, this is how Blazor decides which components to re-render:

 1. The event itself is dispatched to whichever component rendered the event's handler. After executing the event handler, that component is re-rendered.
 2. Whenever any component is re-rendered, it supplies a new copy of the parameter values to each of its child components.
 3. When receiving a new set of parameter values, each component chooses whether to re-render. By default, they will re-render if the parameter values may have changed (e.g., if they are mutable objects).

Steps 2 and 3 continue recursively down the component hierarchy. So in many cases, the entire subtree will be re-rendered. This means that events targeting high-level components can cause expensive re-rendering processes because everything below that point must be re-rendered.

If you want to interrupt this process and prevent rendering recursion into a particular subtree, then you can either:

 * Ensure that all parameters to a certain component are of primitive, immutable types (`string`, `int`, `bool`, `DateTime`, etc.). The built-in logic for detecting changes will automatically skip re-rendering if none of these parameter values have changed. For example if you render a child component `<Customer CustomerId="@item.CustomerId" />`, where `CustomerId` is an `int` value, then it will not be re-rendered except when `item.CustomerId` changes.
 * Or, if you need to accept nonprimitive parameter values such as custom model types, event callbacks, or `RenderFragment` values, then you can override `ShouldRender` to control the decision about whether to render, as in the following example.

By skipping re-rendering of whole subtrees, you may be able to remove the vast majority of the rendering cost when an event occurs.

You may wish to factor out child components specifically so that you can skip re-rendering that part of the UI. This is a valid way to reduce the rendering cost of a parent component.

#### Using ShouldRender

If authoring a UI-only component that never changes after the initial render (regardless of any parameter values), configure `ShouldRender` to return `false`:

```razor
@code {
    protected override bool ShouldRender() => false;
}
```

Or, if the component only needs to change when its parameter values mutate in particular ways, then you can use private fields to track the necessary information to detect changes:

```razor
@code {
    [Parameter] public FlightInfo OutboundFlight { get; set; }
    [Parameter] public FlightInfo InboundFlight { get; set; }

    private int prevOutboundFlightId;
    private int prevInboundFlightId;
    private bool shouldRender;

    protected override void OnParametersSet()
    {
        // Check for all the kinds of change or mutation we want to respond to
        shouldRender = OutboundFlight.FlightId != prevOutboundFlightId
          || InboundFlight.FlightId != prevInboundFlightId;

        // Track info for next time
        prevOutboundFlightId = OutboundFlight.FlightId;
        prevInboundFlightId = InboundFlight.FlightId;
    }

    protected override void ShouldRender() => shouldRender;

    // Note that if you have an event handler, you may also want to set
    // "shouldRender = true;" inside it, so that the component will re-render
    // after the event.
}
```

For most components this level of manual control isn't necessary. You should only be concerned about skipping rendering subtrees if those subtrees are particularly expensive to render and are causing UI lag.

For more information, see <xref:blazor/components/lifecycle>.

::: moniker range=">= aspnetcore-5.0"

### Virtualization

When rendering large amounts of UI within a loop, for example a list or grid with thousands of entries, the sheer quantity of rendering operations could lead to a laggy user experience. Given that the user can only see a small number of elements at once without scrolling, it seems wasteful to spend so much time rendering elements that aren't currently visible.

To address this, Blazor provides a built-in component called `<Virtualize>` that creates the appearance and scroll behaviors of an arbitrarily-large list, but actually only renders the list items that are within the current scroll viewport. This means you could have a list with (for example) 100,000 entries but only pay the rendering cost of (for example) 20 items that are visible at any one time. You can use this to scale up your UI by orders of magnitude.

`<Virtualize>` can be used when:

 * You are rendering a set of data items in a loop.
 * Most of the items are not visible due to scrolling.
 * All of the rendered items are exactly the same size (so that, when the user scrolls to an arbitrary point, the component can calculate which items should be visible).

As an example, here's a non-virtualized list:

```razor
<div class="all-flights" style="height: 500px; overflow-y: scroll">
    @foreach (var flight in allFlights)
    {
        <FlightSummary @key="flight.FlightId" Flight="@flight" />
    }
</div>
```

If the `allFlights` collection holds 10,000 items, then it will instantiate and render 10,000 `<FlightSummary>` component instances. In comparison, here's a virtualized list:

```razor
<div class="all-flights" style="height: 500px; overflow-y: scroll">
    <Virtualize Items="@allFlights" Context="flight">
        <FlightSummary @key="flight.FlightId" Flight="@flight" />
    </Virtualize>
</div>
```

Even though the resulting UI looks the same to a user, behind the scenes this will only instantiate and render as many `<FlightSummary>` instances as are needed to fill the scrollable region. It will take care of updating this set as the user scrolls.

`<Virtualize>` has other benefits too. For example, when you are requesting the data from an external API, it makes it easy to only fetch the slice of records that correspond to the current visible region, instead of downloading all the data from the collection.

For more information, see <xref:blazor/components/virtualization>.

::: moniker-end

### Creating lightweight, optimized components

Most Blazor components don't require aggressive optimization efforts. This is because most components don't repeat very often in the UI and don't re-render at high frequency. For example, `@page` components, and components representing high-level UI pieces such as dialogs or forms, most likely appear only once at a time and only re-render in response to a user gesture. These components don't create a high rendering workload, so you can freely use any combination of framework features you want in them without worrying much about rendering performance.

However, there are also common scenarios where you will build components that need to be repeated at scale. For example:

 * In large nested forms, you may have hundreds of individual inputs, labels, etc.
 * In grids, you may have thousands of cells
 * In scatter plots, you may have millions of data points

If you model each of these as separate component instances, there will be so many of them that their rendering performance does become critical. This section provides advice on making such components very lightweight so that your UI remains fast and responsive.

#### Avoid having thousands of component instances

Each component is a separate island that can render independently of its parents and children. By choosing how to split up your UI into a hierarchy of components, you are taking control over the granularity of UI rendering. This can be either good or bad for performance.

 * By splitting your UI into more separate components, you can have smaller portions of the UI re-render when events occur. For example, when a user clicks a button in a table row, you may be able to have only that single row re-render instead of the whole page or table.
 * However, each extra component involves some extra memory and CPU overhead to deal with its independent state and rendering lifecycle.

When tuning the performance of Blazor WebAssembly on .NET 5, we measured a rendering overhead of around 0.06ms per component instance. This is based on a simple component that accepts 3 parameters, running on a typical laptop. Internally, the overhead is largely due to retrieving per-component state from dictionaries and passing and receiving parameters. By multiplication, you can see that adding 2000 extra component instances would add 0.12 seconds to your rendering time, and your UI would begin feeling laggy to users.

It is possible to make your components more lightweight so you can have more of them, but often the more powerful technique is not to have so many of them. Here are two approaches.

##### Inlining child components into their parents

Consider the following component that renders a sequence of child components:

```razor
<div class="chat">
    @foreach (var message in messages)
    {
        <ChatMessageDisplay Message="@message" />
    }
</div>
```

... with `<ChatMessageDisplay>` defined in a file `ChatMessageDisplay.razor` containing:

```razor
<div class="chat-message">
    <span class="author">@Message.Author</span>
    <span class="text">@Message.Text</span>
</div>

@code {
    [Parameter] public ChatMessage Message { get; set; }
}
```

This will work fine and perform well as long as you're not showing thousands of messages at once. If you do need to show thousands of messages at once, consider *not* factoring out the separate `ChatMessageDisplay.razor` component, and instead inline the rendering directly into the parent:

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

This avoids the per-component overhead of rendering so many child components, at the cost of not being able to re-render each of them independently.

##### Defining reusable RenderFragments in code

You may be factoring out child components purely as a way of reusing rendering logic. If that's the case, it is still possible to do that even without declaring actual components. For example, in any `.razor` component's `@code` block, you can define a `RenderFragment` that emits UI and can be called from anywhere:

```razor
<h1>Hello, world!</h1>

@RenderWelcomeInfo

@code {
    RenderFragment RenderWelcomeInfo = __builder =>
    {
        <div>
            Welcome to your new app!

            <SurveyPrompt Title="How is Blazor working for you?" />
        </div>
    };
}
```

As you can see, `.razor` files can emit markup from code within their `@code` block as well as outside it. This defines a `RenderFragment` delegate that you can render inside the component's normal render output, optionally in multiple places. It's necessary for the delegate to accept a parameter called `__builder` of type `RenderTreeBuilder` so that the Razor compiler can produce rendering instructions for it.

If you want to make this reusable across multiple components, consider declaring it as a `public static` member:

```razor
public static RenderFragment SayHello = __builder =>
{
    <h1>Hello!</h1>
};
```

This could now be invoked from an unrelated component. You could use this technique to build a library of reusable markup snippets that render without any per-component overhead.

These delegates can also accept parameters. For example, to create the equivalent of `ChatMessageDisplay.razor` from the earlier example:

```razor
<div class="chat">
    @foreach (var message in messages)
    {
        @DisplayChatMessage(message)
    }
</div>

@code {
    RenderFragment<ChatMessage> DisplayChatMessage = message => __builder =>
    {
        <div class="chat-message">
            <span class="author">@message.Author</span>
            <span class="text">@message.Text</span>
        </div>
    };
}
```

This provides the benefit of reusing rendering logic without per-component overhead. However it does not have the benefit of being able to refresh that subtree of the UI independently, nor the ability to skip rendering that subtree of the UI when its parent renders, since there is no component boundary.

#### Don't receive too many parameters

If you have a component that repeats extremely often, for example hundreds or thousands of times, then bear in mind that the overhead of passing and receiving each parameter will build up.

It's rare that this will make any difference, but if you had a `<TableCell>` component that renders 4000 times within a grid, then each extra parameter passed to it could add around 15ms to the total rendering cost. If the cell accepted 10 parameters, this would take 150ms and on its own cause a laggy UI.

To reduce this load, you could bundle together multiple parameters via custom classes. For example, a `<TableCell>` component might accept:

```razor
@typeparam TItem
...
@code {
    [Parameter] public TItem Data { get; set; }
    [Parameter] public GridOptions Options { get; set; }
}
```

... where `Data` is different for every cell, but `Options` is common across all of them. Of course, it might be better still not to have a `<TableCell>` component and instead inline its logic into the parent component.

#### Ensure cascading parameters are fixed

The `<CascadingValue>` component has an optional parameter called `IsFixed`.

 * If the `IsFixed` value is `false` (the default), then every recipient of the cascaded value will set up a subscription to receive change notifications. In this case, each each `[CascadingParameter]` is **substantially more expensive** than a regular `[Parameter]` due to the subscription tracking.
 * If the `IsFixed` value is `true` (e.g., `<CascadingValue Value="@someValue" IsFixed="true">`), then receipients receive the initial value but do *not* set up any subscription to receive updates. In this case, each `[CascadingParameter]` is lightweight and **no more expensive** than a regular `[Parameter]`.

So wherever possible, you should use `IsFixed="true"` on cascaded values. You can do this whenever the value being supplied does not change over time. For example, in the common pattern where a component passes `this` as a cascaded value, you should use `IsFixed="true"`:

```razor
<CascadingValue Value="this" IsFixed="true">
    <SomeOtherComponents>
</CascadingValue>
```

This makes a huge difference if there are a large number of other components that receive the cascaded value. For more information, see <xref:blazor/components/cascading-values-and-parameters>.

#### Avoid CaptureUnmatchedValues (attribute splatting)

Components can elect to receive "unmatched" parameter values using the `CaptureUnmatchedValues` flag:

```razor
<div @attributes="OtherAttributes">...</div>

@code {
    [Parameter(CaptureUnmatchedValues = true)]
    public IDictionary<string, object> OtherAttributes { get; set; }
}
```

This is a way of passing through arbitrary additional attributes. However it is also quite expensive, because the renderer has to match all the supplied parameters against the set of known ones to build a dictionary, and keep track of how multiple copies of the same attribute overwrite each other.

You should feel free to use `CaptureUnmatchedValues` on non-performance-critical components, such as ones that are not repeated frequently. However for components that render at scale, such as each item in a very large list or cells in a grid, try to avoid use of this feature.

For more information, see <xref:blazor/components#attribute-splatting-and-arbitrary-parameters>.

#### Implement SetParametersAsync manually

One of the main aspects of the per-component rendering overhead is writing incoming parameter values to the `[Parameter]` properties. The renderer has to use reflection to do this. Even though this is somewhat optimized, the absence of JIT support on the WebAssembly runtime imposes limits.

In some extreme cases, you may wish to avoid the reflection and implement your own parameter setting logic manually. This may be applicable when:

 * You have a component that renders extremely often (e.g., there are hundreds or thousands of copies of it in the UI)
 * It accepts many parameters
 * You find that the overhead of receiving parameters has an observable impact on UI responsiveness

In these cases you can override the component's virtual <xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A> method and implement your own component-specific logic. The following example deliberately avoids any dictionary lookups:

```razor
@code {
    [Parameter] public int MessageId { get; set; }
    [Parameter] public string Text { get; set; }
    [Parameter] public EventCallback<string> TextChanged { get; set; }
    [Parameter] public Theme CurrentTheme { get; set; }

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

        // Run the normal lifecycle methods, but without assigning parameters again
        return base.SetParametersAsync(ParameterView.Empty);
    }
}
```

As you can see, this is complicated and laborious, so we don't recommend it in general. In extreme cases it can improve rendering performance by 20-25% but you should only consider it in the scenarios listed above.

### Don't trigger events too rapidly

Some browser events fire extremely frequently, for example `onmousemove` and `onscroll` which can fire tens or hundreds of times per second. In most cases you won't need to perform UI updates this frequently, and if you try to do so, you may harm UI responsiveness or consume excessive CPU time.

Rather than using native `@onmousemove` or `@onscroll` events, you may prefer to use JS interop to register a callback that fires less frequently. For example, the following component (`MyComponent.razor`) displays the position of the mouse, but only updates at most once every 500ms:

```razor
@inject IJSRuntime JS
@implements IDisposable

<h1>@message</h1>

<div @ref="myMouseMoveElement" style="border: 1px dashed red; height: 200px;">
    Move mouse here
</div>

@code {
    ElementReference myMouseMoveElement;
    DotNetObjectReference<MyComponent> selfReference;
    string message = "Move the mouse in the box";

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
            var minInterval = 500; // Only notify every 500ms
            await JS.InvokeVoidAsync("onThrottledMouseMove", myMouseMoveElement, selfReference, minInterval);
        }
    }

    public void Dispose() => selfReference?.Dispose();
}
```

The corresponding JavaScript code, which can be placed in the `index.html` page or loaded as an ES6 module, registers the actual DOM event listener and in this example uses [Lodash's `throttle` function](https://lodash.com/docs/4.17.15#throttle) to limit the rate of invocations:

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

This technique can be even more important for Blazor Server, since each event invocation involves delivering a message over the network. It's valuable for Blazor WebAssembly too because it can greatly reduce the amount of rendering work.

## Optimizing JavaScript interop speed

Calls between .NET and JavaScript involve some additional overhead because:

 * By default, they are asynchronous
 * By default, parameters and return values are JSON-serialized. This is to provide an easy-to-understand conversion mechanism between .NET and JavaScript types

Additionally, on Blazor Server, these calls are passed across the network.

### Avoid excessively fine-grained calls

Since each call involves some overhead, it can be valuable to reduce the number of calls. Consider the following code, which stores a collection of items in the browser's `localStorage` store:

```cs
private async Task StoreAllInLocalStorage(IEnumerable<TodoItem> items)
{
    foreach (var item in items)
    {
        await JS.InvokeVoidAsync("localStorage.setItem", item.Id, JsonSerializer.Serialize(item));
    }
}
```

This makes a separate JS interop call for each item. Instead, this could be reduced to a single JS interop call:

```cs
private async Task StoreAllInLocalStorage(IEnumerable<TodoItem> items)
{
    await JS.InvokeVoidAsync("storeAllInLocalStorage", items);
}
```

... with a corresponding JavaScript function defined as follows:

```js
function storeAllInLocalStorage(items) {
    items.forEach(item => {
        localStorage.setItem(item.id, JSON.stringify(item));
    });
}
```

For Blazor WebAssembly, this usually only matters if you are making a large number of JS interop calls.

### Consider making synchronous calls

JavaScript interop calls are asynchronous by default, regardless of whether the code being called is synchronous or asynchronous. This is to ensure components are compatible with both Blazor WebAssembly and Blazor Server. On Blazor Server, all JavaScript interop calls must be asynchronous because they are sent over a network connection.

If you know for certain that your application only needs to run on Blazor WebAssembly, then you can choose to make synchronous JavaScript interop calls. This has slightly less overhead than making asynchronous calls, and can result in fewer render cycles because there is no intermediate state while awaiting the result.

To make a synchronous call from .NET to JavaScript, cast `IJSRuntime` to `IJSInProcessRuntime`:

```razor
@inject IJSRuntime JS

...

@code {
    protected override void HandleSomeEvent()
    {
        var jsInProcess = (IJSInProcessRuntime)JS;
        var value = jsInProcess.Invoke<string>("javascriptFunctionIdentifier");
    }
}
```

::: moniker range=">= aspnetcore-5.0"

Similarly, when working with `IJSObjectReference`, you can make a synchronous call by casting it to `IJSInProcessObjectReference`.

::: moniker-end

To make a synchronous call from JavaScript to .NET, use `DotNet.invokeMethod` instead of `DotNet.invokeMethodAsync`.

Synchronous calls will work if:

 * Your application is running on Blazor WebAssembly, not Blazor Server
 * The function you are calling returns a value synchronously (i.e., it is not an `async` method and does not return a .NET `Task` or JavaScript `Promise`)

 ::: moniker range=">= aspnetcore-5.0"
 
For more information, see <xref:blazor/call-javascript-from-dotnet>.

### Consider making unmarshalled calls

When running on Blazor WebAssembly, it's possible to make unmarshalled calls from .NET to JavaScript. These are synchronous calls that do not perform any JSON serialization of arguments or return values. All aspects of memory management and translations between .NET and JavaScript representations are left up to the developer.

> [!WARNING]
> While using `IJSUnmarshalledRuntime` has the least overhead of the JS interop approaches, the JavaScript APIs required to interact with these APIs are currently undocumented and subject to breaking changes in future releases.

```javascript
function jsInteropCall() {
    return BINDING.js_to_mono_obj("Hello world");
}
```

```razor
@inject IJSRuntime JS

@code {
    protected override void OnInitialized()
    {
        var unmarshalledJs = (IJSUnmarshalledRuntime)JS;
        var value = unmarshalledJs.InvokeUnmarshalled<string>("jsInteropCall");
    }
}
```

::: moniker-end

## Minimizing application download size

::: moniker range=">= aspnetcore-5.0"

### Intermediate Language (IL) trimming

[Trimming unused assemblies from a Blazor WebAssembly app](xref:blazor/host-and-deploy/configure-trimmer) reduces the app's size by removing unused code in the app's binaries. By default, the Trimmer is executed when publishing an application. To benefit from trimming, publish the app for deployment using the [`dotnet publish`](/dotnet/core/tools/dotnet-publish) command with the [-c|--configuration](/dotnet/core/tools/dotnet-publish#options) option set to `Release`:

::: moniker-end

::: moniker range="< aspnetcore-5.0"

### Intermediate Language (IL) linking

[Linking a Blazor WebAssembly app](xref:blazor/host-and-deploy/configure-linker) reduces the app's size by trimming unused code in the app's binaries. By default, the Intermediate Language (IL) Linker is only enabled when building in `Release` configuration. To benefit from this, publish the app for deployment using the [`dotnet publish`](/dotnet/core/tools/dotnet-publish) command with the [-c|--configuration](/dotnet/core/tools/dotnet-publish#options) option set to `Release`:

::: moniker-end

```dotnetcli
dotnet publish -c Release
```

### Use System.Text.Json

Blazor's JS interop implementation relies on <xref:System.Text.Json>, which is a high-performance JSON serialization library with low memory allocation. Using <xref:System.Text.Json> doesn't result in additional app payload size over adding one or more alternate JSON libraries.

For migration guidance, see [How to migrate from `Newtonsoft.Json` to `System.Text.Json`](/dotnet/standard/serialization/system-text-json-migrate-from-newtonsoft-how-to).

### Lazy load assemblies

Load assemblies at runtime when the assemblies are required by a route. For more information, see <xref:blazor/webassembly-lazy-load-assemblies>.

### Compression

When a Blazor WebAssembly app is published, the output is statically compressed during publish to reduce the app's size and remove the overhead for runtime compression. Blazor relies on the server to perform content negotation and serve statically-compressed files.

After an app is deployed, verify that the app serves compressed files. Inspect the Network tab in a browser's Developer Tools and verify that the files are served with `Content-Encoding: br` or `Content-Encoding: gz`. If the host isn't serving compressed files, follow the instructions in <xref:blazor/host-and-deploy/webassembly#compression>.

### Disable unused features

Blazor WebAssembly's runtime includes the following .NET features that can be disabled if the app doesn't require them for a smaller payload size:

* A data file is included to make timezone information correct. If the app doesn't require this feature, consider disabling it by setting the `BlazorEnableTimeZoneSupport` MSBuild property in the app's project file to `false`:

  ```xml
  <PropertyGroup>
    <BlazorEnableTimeZoneSupport>false</BlazorEnableTimeZoneSupport>
  </PropertyGroup>
  ```

::: moniker range=">= aspnetcore-5.0"

* By default, Blazor WebAssembly carries globalization resources required to display values, such as dates and currency, in the user's culture. If the app doesn't require localization, you may [configure the app to support the invariant culture](xref:blazor/globalization-localization), which is based on the `en-US` culture:

  ```xml
  <PropertyGroup>
    <InvariantGlobalization>true</InvariantGlobalization>
  </PropertyGroup>
  ```

::: moniker-end

::: moniker range="< aspnetcore-5.0"

* Collation information is included to make APIs such as <xref:System.StringComparison.InvariantCultureIgnoreCase?displayProperty=nameWithType> work correctly. If you're certain that the app doesn't require the collation data, consider disabling it by setting the `BlazorWebAssemblyPreserveCollationData` MSBuild property in the app's project file to `false`:

  ```xml
  <PropertyGroup>
    <BlazorWebAssemblyPreserveCollationData>false</BlazorWebAssemblyPreserveCollationData>
  </PropertyGroup>
  ```

::: moniker-end
