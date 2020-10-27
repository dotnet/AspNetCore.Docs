---
title: ASP.NET Core Blazor WebAssembly performance best practices
author: pranavkm
description: Tips for increasing performance in ASP.NET Core Blazor WebAssembly apps and avoiding common performance problems.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc, devx-track-js
ms.date: 10/09/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/webassembly-performance-best-practices
---
# ASP.NET Core Blazor WebAssembly performance best practices

By [Pranav Krishnamoorthy](https://github.com/pranavkm) and [Steve Sanderson](https://github.com/SteveSandersonMS)

Blazor WebAssembly is carefully designed and optimized to enable high performance in most realistic application UI scenarios. However, producing the best results depends on developers using the right patterns and features. Consider the following aspects:

* **Runtime throughput**: The .NET code runs on an interpreter within the WebAssembly runtime, so CPU throughput is limited. In demanding scenarios, the app benefits from [optimizing rendering speed](#optimize-rendering-speed).
* **Startup time**: The app transfers a .NET runtime to the browser, so it's important to use features that [minimize the application download size](#minimize-app-download-size).

## Optimize rendering speed

The following sections provide recommendations to minimize rendering workload and improve UI responsiveness. Following this advice could easily make a *ten-fold or higher improvement* in UI rendering speeds.

### Avoid unnecessary rendering of component subtrees

At runtime, components exist as a hierarchy. A root component has child components. In turn, the root's children have their own child components, and so on. When an event occurs, such as a user selecting a button, this is how Blazor decides which components to rerender:

 1. The event itself is dispatched to whichever component rendered the event's handler. After executing the event handler, that component is rerendered.
 1. Whenever any component is rerendered, it supplies a new copy of the parameter values to each of its child components.
 1. When receiving a new set of parameter values, each component chooses whether to rerender. By default, components rerender if the parameter values may have changed (for example, if they are mutable objects).

The last two steps of this sequence continue recursively down the component hierarchy. In many cases, the entire subtree is rerendered. This means that events targeting high-level components can cause expensive rerendering processes because everything below that point must be rerendered.

If you want to interrupt this process and prevent rendering recursion into a particular subtree, then you can either:

 * Ensure that all parameters to a certain component are of primitive immutable types (for example, `string`, `int`, `bool`, `DateTime`, and others). The built-in logic for detecting changes automatically skips rerendering if none of these parameter values have changed. If you render a child component with `<Customer CustomerId="@item.CustomerId" />`, where `CustomerId` is an `int` value, then it isn't rerendered except when `item.CustomerId` changes.
 * If you need to accept nonprimitive parameter values, such as custom model types, event callbacks, or <xref:Microsoft.AspNetCore.Components.RenderFragment> values, then you can override <xref:Microsoft.AspNetCore.Components.ComponentBase.ShouldRender%2A> to control the decision about whether to render, which is described in the [Use of `ShouldRender`](#use-of-shouldrender) section.

By skipping rerendering of whole subtrees, you may be able to remove the vast majority of the rendering cost when an event occurs.

You may wish to factor out child components specifically so that you can skip rerendering that part of the UI. This is a valid way to reduce the rendering cost of a parent component.

#### Use of `ShouldRender`

If authoring a UI-only component that never changes after the initial render (regardless of any parameter values), configure <xref:Microsoft.AspNetCore.Components.ComponentBase.ShouldRender%2A> to return `false`:

```razor
@code {
    protected override bool ShouldRender() => false;
}
```

If the component only requires rerendering when its parameter values mutate in particular ways, then you can use private fields to track the necessary information to detect changes. In the following example, `shouldRender` is based on checking for any kind of change or mutation that should prompt a rerender. `prevOutboundFlightId` and `prevInboundFlightId` track information for the next potential update:

```razor
@code {
    [Parameter]
    public FlightInfo OutboundFlight { get; set; }
    
    [Parameter]
    public FlightInfo InboundFlight { get; set; }

    private int prevOutboundFlightId;
    private int prevInboundFlightId;
    private bool shouldRender;

    protected override void OnParametersSet()
    {
        shouldRender = OutboundFlight.FlightId != prevOutboundFlightId
            || InboundFlight.FlightId != prevInboundFlightId;

        prevOutboundFlightId = OutboundFlight.FlightId;
        prevInboundFlightId = InboundFlight.FlightId;
    }

    protected override void ShouldRender() => shouldRender;

    // Note that 
}
```

In the preceding code, an event handler may also set `shouldRender` to `true` so that the component is rerendered after the event.

For most components, this level of manual control isn't necessary. You should only be concerned about skipping rendering subtrees if those subtrees are particularly expensive to render and are causing UI lag.

For more information, see <xref:blazor/components/lifecycle>.

::: moniker range=">= aspnetcore-5.0"

### Virtualization

When rendering large amounts of UI within a loop, for example a list or grid with thousands of entries, the sheer quantity of rendering operations can lead to a lag in UI rendering and thus a poor user experience. Given that the user can only see a small number of elements at once without scrolling, it seems wasteful to spend so much time rendering elements that aren't currently visible.

To address this, Blazor provides a built-in [`<Virtualize>` component](xref:blazor/components/virtualization) that creates the appearance and scroll behaviors of an arbitrarily-large list but actually only renders the list items that are within the current scroll viewport. For example, this means that the app can have a list with 100,000 entries but only pay the rendering cost of 20 items that are visible at any one time. Use of the `<Virtualize>` component can scale up UI performance by orders of magnitude.

`<Virtualize>` can be used when:

 * Rendering a set of data items in a loop.
 * Most of the items aren't visible due to scrolling.
 * The rendered items are exactly the same size. When the user scrolls to an arbitrary point, the component can calculate the visible items to show.

The following shows an example of a non-virtualized list:

```razor
<div class="all-flights" style="height:500px;overflow-y:scroll">
    @foreach (var flight in allFlights)
    {
        <FlightSummary @key="flight.FlightId" Flight="@flight" />
    }
</div>
```

If the `allFlights` collection holds 10,000 items, it instantiates and renders 10,000 `<FlightSummary>` component instances. In comparison, the following shows an example of a virtualized list:

```razor
<div class="all-flights" style="height:500px;overflow-y:scroll">
    <Virtualize Items="@allFlights" Context="flight">
        <FlightSummary @key="flight.FlightId" Flight="@flight" />
    </Virtualize>
</div>
```

Even though the resulting UI looks the same to a user, behind the scenes the component only instantiates and renders as many `<FlightSummary>` instances as are required to fill the scrollable region. The set of `<FlightSummary>` instances displayed is recalculated and rendered as the user scrolls.

`<Virtualize>` has other benefits, too. For example when a component requests data from an external API, `<Virtualize>` permits the component to only fetch the slice of records that correspond to the current visible region, instead of downloading all the data from the collection.

For more information, see <xref:blazor/components/virtualization>.

::: moniker-end

### Create lightweight, optimized components

Most Blazor components don't require aggressive optimization efforts. This is because most components don't often repeat in the UI and don't rerender at high frequency. For example, `@page` components and components representing high-level UI pieces such as dialogs or forms, most likely appear only one at a time and only rerender in response to a user gesture. These components don't create a high rendering workload, so you can freely use any combination of framework features you want without worrying much about rendering performance.

However, there are also common scenarios where you build components that need to be repeated at scale. For example:

 * Large nested forms may have hundreds of individual inputs, labels, and other elements.
 * Grids may have thousands of cells.
 * Scatter plots may have millions of data points.

If modelling each unit as separate component instances, there will be so many of them that their rendering performance does become critical. This section provides advice on making such components lightweight so that the UI remains fast and responsive.

#### Avoid thousands of component instances

Each component is a separate island that can render independently of its parents and children. By choosing how to split up the UI into a hierarchy of components, you are taking control over the granularity of UI rendering. This can be either good or bad for performance.

 * By splitting the UI into more components, you can have smaller portions of the UI rerender when events occur. For example when a user clicks a button in a table row, you may be able to have only that single row rerender instead of the whole page or table.
 * However, each extra component involves some extra memory and CPU overhead to deal with its independent state and rendering lifecycle.

When tuning the performance of Blazor WebAssembly on .NET 5, we measured a rendering overhead of around 0.06 ms per component instance. This is based on a simple component that accepts three parameters running on a typical laptop. Internally, the overhead is largely due to retrieving per-component state from dictionaries and passing and receiving parameters. By multiplication, you can see that adding 2,000 extra component instances would add 0.12 seconds to the rendering time and the UI would begin feeling slow to users.

It's possible to make components more lightweight so that you can have more of them, but often the more powerful technique is not to have so many components. The following sections describe two approaches.

##### Inline child components into their parents

Consider the following component that renders a sequence of child components:

```razor
<div class="chat">
    @foreach (var message in messages)
    {
        <ChatMessageDisplay Message="@message" />
    }
</div>
```

For the preceding example code, the `<ChatMessageDisplay>` component is defined in a file `ChatMessageDisplay.razor` containing:

```razor
<div class="chat-message">
    <span class="author">@Message.Author</span>
    <span class="text">@Message.Text</span>
</div>

@code {
    [Parameter]
    public ChatMessage Message { get; set; }
}
```

The preceding example works fine and performs well as long as thousands of messages aren't shown at once. To show thousands of messages at once, consider *not* factoring out the separate `ChatMessageDisplay` component. Instead, inline the rendering directly into the parent:

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

This avoids the per-component overhead of rendering so many child components at the cost of not being able to rerender each of them independently.

##### Define reusable `RenderFragments` in code

You may be factoring out child components purely as a way of reusing rendering logic. If that's the case, it's still possible to reuse rendering logic without declaring actual components. In any component's `@code` block, you can define a <xref:Microsoft.AspNetCore.Components.RenderFragment> that emits UI and can be called from anywhere:

```razor
<h1>Hello, world!</h1>

@RenderWelcomeInfo

@code {
    RenderFragment RenderWelcomeInfo = __builder =>
    {
        <div>
            <p>Welcome to your new app!</p>

            <SurveyPrompt Title="How is Blazor working for you?" />
        </div>
    };
}
```

As demonstated in the preceding example, components can emit markup from code within their `@code` block and outside it. This approach defines a <xref:Microsoft.AspNetCore.Components.RenderFragment> delegate that you can render inside the component's normal render output, optionally in multiple places. It's necessary for the delegate to accept a parameter called `__builder` of type <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> so that the Razor compiler can produce rendering instructions for it.

If you want to make this reusable across multiple components, consider declaring it as a `public static` member:

```razor
public static RenderFragment SayHello = __builder =>
{
    <h1>Hello!</h1>
};
```

This could now be invoked from an unrelated component. This technique is useful for building libraries of reusable markup snippets that render without any per-component overhead.

<xref:Microsoft.AspNetCore.Components.RenderFragment> delegates can also accept parameters. To create the equivalent of the `ChatMessageDisplay` component from the earlier example:

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

This approach provides the benefit of reusing rendering logic without per-component overhead. However, it doesn't have the benefit of being able to refresh its subtree of the UI independently, nor does it have the ability to skip rendering that subtree of the UI when its parent renders, since there's no component boundary.

#### Don't receive too many parameters

If a component repeats extremely often, for example hundreds or thousands of times, then bear in mind that the overhead of passing and receiving each parameter builds up.

It's rare that too many parameters severely restricts performance, but it can be a factor. For a `<TableCell>` component that renders 1,000 times within a grid, each extra parameter passed to it could add around 15 ms to the total rendering cost. If each cell accepted 10 parameters, parameter passing takes around 150 ms per component render and  thus perhaps 150,000 ms (150 seconds) and on its own cause a laggy UI.

To reduce this load, you could bundle together multiple parameters via custom classes. For example, a `<TableCell>` component might accept:

```razor
@typeparam TItem

...

@code {
    [Parameter]
    public TItem Data { get; set; }
    
    [Parameter]
    public GridOptions Options { get; set; }
}
```

In the preceding example, `Data` is different for every cell, but `Options` is common across all of them. Of course, it might be an improvement not to have a `<TableCell>` component and instead inline its logic into the parent component.

#### Ensure cascading parameters are fixed

The `<CascadingValue>` component has an optional parameter called `IsFixed`.

 * If the `IsFixed` value is `false` (the default), then every recipient of the cascaded value sets up a subscription to receive change notifications. In this case, each each `[CascadingParameter]` is **substantially more expensive** than a regular `[Parameter]` due to the subscription tracking.
 * If the `IsFixed` value is `true` (for example, `<CascadingValue Value="@someValue" IsFixed="true">`), then receipients receive the initial value but do *not* set up any subscription to receive updates. In this case, each `[CascadingParameter]` is lightweight and **no more expensive** than a regular `[Parameter]`.

So wherever possible, you should use `IsFixed="true"` on cascaded values. You can do this whenever the value being supplied doesn't change over time. In the common pattern where a component passes `this` as a cascaded value, you should use `IsFixed="true"`:

```razor
<CascadingValue Value="this" IsFixed="true">
    <SomeOtherComponents>
</CascadingValue>
```

This makes a huge difference if there are a large number of other components that receive the cascaded value. For more information, see <xref:blazor/components/cascading-values-and-parameters>.

#### Avoid attribute splatting with `CaptureUnmatchedValues`

Components can elect to receive "unmatched" parameter values using the <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues> flag:

```razor
<div @attributes="OtherAttributes">...</div>

@code {
    [Parameter(CaptureUnmatchedValues = true)]
    public IDictionary<string, object> OtherAttributes { get; set; }
}
```

This approach allows passing through arbitrary additional attributes to the element. However, it is also quite expensive because the renderer must:

* Match all of the supplied parameters against the set of known parameters to build a dictionary.
* Keep track of how multiple copies of the same attribute overwrite each other.

Feel free to use <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues> on non-performance-critical components, such as ones that are not repeated frequently. However for components that render at scale, such as each items in a large list or cells in a grid, try to avoid attribute splatting.

For more information, see <xref:blazor/components/index#attribute-splatting-and-arbitrary-parameters>.

#### Implement `SetParametersAsync` manually

One of the main aspects of the per-component rendering overhead is writing incoming parameter values to the `[Parameter]` properties. The renderer has to use reflection to do this. Even though this is somewhat optimized, the absence of JIT support on the WebAssembly runtime imposes limits.

In some extreme cases, you may wish to avoid the reflection and implement your own parameter setting logic manually. This may be applicable when:

 * You have a component that renders extremely often (for example, there are hundreds or thousands of copies of it in the UI).
 * It accepts many parameters.
 * You find that the overhead of receiving parameters has an observable impact on UI responsiveness.

In these cases, you can override the component's virtual <xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A> method and implement your own component-specific logic. The following example deliberately avoids any dictionary lookups:

```razor
@code {
    [Parameter]
    public int MessageId { get; set; }

    [Parameter]
    public string Text { get; set; }

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

In the preceding code, returning the base class <xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A> runs the normal lifecycle methods without assigning parameters again.

As you can see in the preceding code, overriding <xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A> and supplying custom logic is complicated and laborious, so we don't recommend this approach in general. In extreme cases, it can improve rendering performance by 20-25%, but you should only consider this approach in the scenarios listed earlier.

### Don't trigger events too rapidly

Some browser events fire extremely frequently, for example `onmousemove` and `onscroll`, which can fire tens or hundreds of times per second. In most cases, you don't need to perform UI updates this frequently. If you try to do so, you may harm UI responsiveness or consume excessive CPU time.

Rather than using native `@onmousemove` or `@onscroll` events, you may prefer to use JS interop to register a callback that fires less frequently. For example, the following component (`MyComponent.razor`) displays the position of the mouse but only updates at most once every 500 ms:

```razor
@inject IJSRuntime JS
@implements IDisposable

<h1>@message</h1>

<div @ref="myMouseMoveElement" style="border:1px dashed red;height:200px;">
    Move mouse here
</div>

@code {
    ElementReference myMouseMoveElement;
    DotNetObjectReference<MyComponent> selfReference;
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
            var minInterval = 500; // Only notify every 500 ms
            await JS.InvokeVoidAsync("onThrottledMouseMove", 
                myMouseMoveElement, selfReference, minInterval);
        }
    }

    public void Dispose() => selfReference?.Dispose();
}
```

The corresponding JavaScript code, which can be placed in the `index.html` page or loaded as an ES6 module, registers the actual DOM event listener. In this example, the event listener uses [Lodash's `throttle` function](https://lodash.com/docs/4.17.15#throttle) to limit the rate of invocations:

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

This technique can be even more important for Blazor Server, since each event invocation involves delivering a message over the network. It's valuable for Blazor WebAssembly because it can greatly reduce the amount of rendering work.

## Optimize JavaScript interop speed

Calls between .NET and JavaScript involve some additional overhead because:

 * By default, calls are asynchronous.
 * By default, parameters and return values are JSON-serialized. This is to provide an easy-to-understand conversion mechanism between .NET and JavaScript types.

Additionally on Blazor Server, these calls are passed across the network.

### Avoid excessively fine-grained calls

Since each call involves some overhead, it can be valuable to reduce the number of calls. Consider the following code, which stores a collection of items in the browser's `localStorage` store:

```csharp
private async Task StoreAllInLocalStorage(IEnumerable<TodoItem> items)
{
    foreach (var item in items)
    {
        await JS.InvokeVoidAsync("localStorage.setItem", item.Id, 
            JsonSerializer.Serialize(item));
    }
}
```

The preceding example makes a separate JS interop call for each item. Instead, the following approach reduces the JS interop to a single call:

```csharp
private async Task StoreAllInLocalStorage(IEnumerable<TodoItem> items)
{
    await JS.InvokeVoidAsync("storeAllInLocalStorage", items);
}
```

The corresponding JavaScript function defined as follows:

```javascript
function storeAllInLocalStorage(items) {
  items.forEach(item => {
    localStorage.setItem(item.id, JSON.stringify(item));
  });
}
```

For Blazor WebAssembly, this usually only matters if you're making a large number of JS interop calls.

### Consider making synchronous calls

JavaScript interop calls are asynchronous by default, regardless of whether the code being called is synchronous or asynchronous. This is to ensure components are compatible with both Blazor WebAssembly and Blazor Server. On Blazor Server, all JavaScript interop calls must be asynchronous because they are sent over a network connection.

If you know for certain that your app only ever runs on Blazor WebAssembly, you can choose to make synchronous JavaScript interop calls. This has slightly less overhead than making asynchronous calls and can result in fewer render cycles because there is no intermediate state while awaiting results.

To make a synchronous call from .NET to JavaScript, cast <xref:Microsoft.JSInterop.IJSRuntime> to <xref:Microsoft.JSInterop.IJSInProcessRuntime>:

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

When working with `IJSObjectReference`, you can make a synchronous call by casting to `IJSInProcessObjectReference`.

::: moniker-end

To make a synchronous call from JavaScript to .NET, use `DotNet.invokeMethod` instead of `DotNet.invokeMethodAsync`.

Synchronous calls work if:

* The app is running on Blazor WebAssembly, not Blazor Server.
* The called function returns a value synchronously (it isn't an `async` method and doesn't return a .NET <xref:System.Threading.Tasks.Task> or JavaScript `Promise`).

For more information, see <xref:blazor/call-javascript-from-dotnet>.

::: moniker range=">= aspnetcore-5.0"
 
### Consider making unmarshalled calls

When running on Blazor WebAssembly, it's possible to make unmarshalled calls from .NET to JavaScript. These are synchronous calls that don't perform JSON serialization of arguments or return values. All aspects of memory management and translations between .NET and JavaScript representations are left up to the developer.

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

## Minimize app download size

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
