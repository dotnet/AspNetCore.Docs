---
title: ASP.NET Core Blazor advanced scenarios
author: guardrex
description: Learn about advanced scenarios in Blazor, including how to incorporate manual RenderTreeBuilder logic into an app.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/18/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/advanced-scenarios
---
# ASP.NET Core Blazor advanced scenarios

By [Luke Latham](https://github.com/guardrex) and [Daniel Roth](https://github.com/danroth27)

## Blazor Server circuit handler

Blazor Server allows code to define a *circuit handler*, which allows running code on changes to the state of a user's circuit. A circuit handler is implemented by deriving from `CircuitHandler` and registering the class in the app's service container. The following example of a circuit handler tracks open SignalR connections:

```csharp
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Server.Circuits;

public class TrackingCircuitHandler : CircuitHandler
{
    private HashSet<Circuit> circuits = new HashSet<Circuit>();

    public override Task OnConnectionUpAsync(Circuit circuit, 
        CancellationToken cancellationToken)
    {
        circuits.Add(circuit);

        return Task.CompletedTask;
    }

    public override Task OnConnectionDownAsync(Circuit circuit, 
        CancellationToken cancellationToken)
    {
        circuits.Remove(circuit);

        return Task.CompletedTask;
    }

    public int ConnectedCircuits => circuits.Count;
}
```

Circuit handlers are registered using DI. Scoped instances are created per instance of a circuit. Using the `TrackingCircuitHandler` in the preceding example, a singleton service is created because the state of all circuits must be tracked:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    ...
    services.AddSingleton<CircuitHandler, TrackingCircuitHandler>();
}
```

If a custom circuit handler's methods throw an unhandled exception, the exception is fatal to the Blazor Server circuit. To tolerate exceptions in a handler's code or called methods, wrap the code in one or more [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statements with error handling and logging.

When a circuit ends because a user has disconnected and the framework is cleaning up the circuit state, the framework disposes of the circuit's DI scope. Disposing the scope disposes any circuit-scoped DI services that implement <xref:System.IDisposable?displayProperty=fullName>. If any DI service throws an unhandled exception during disposal, the framework logs the exception.

## Manual RenderTreeBuilder logic

<xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> provides methods for manipulating components and elements, including building components manually in C# code.

> [!NOTE]
> Use of <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> to create components is an advanced scenario. A malformed component (for example, an unclosed markup tag) can result in undefined behavior.

Consider the following `PetDetails` component, which can be manually built into another component:

```razor
<h2>Pet Details Component</h2>

<p>@PetDetailsQuote</p>

@code
{
    [Parameter]
    public string PetDetailsQuote { get; set; }
}
```

In the following example, the loop in the `CreateComponent` method generates three `PetDetails` components. In <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> methods with a sequence number, sequence numbers are source code line numbers. The Blazor difference algorithm relies on the sequence numbers corresponding to distinct lines of code, not distinct call invocations. When creating a component with <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> methods, hardcode the arguments for sequence numbers. **Using a calculation or counter to generate the sequence number can lead to poor performance.** For more information, see the [Sequence numbers relate to code line numbers and not execution order](#sequence-numbers-relate-to-code-line-numbers-and-not-execution-order) section.

`BuiltContent` component:

```razor
@page "/BuiltContent"

<h1>Build a component</h1>

@CustomRender

<button type="button" @onclick="RenderComponent">
    Create three Pet Details components
</button>

@code {
    private RenderFragment CustomRender { get; set; }
    
    private RenderFragment CreateComponent() => builder =>
    {
        for (var i = 0; i < 3; i++) 
        {
            builder.OpenComponent(0, typeof(PetDetails));
            builder.AddAttribute(1, "PetDetailsQuote", "Someone's best friend!");
            builder.CloseComponent();
        }
    };    
    
    private void RenderComponent()
    {
        CustomRender = CreateComponent();
    }
}
```

> [!WARNING]
> The types in <xref:Microsoft.AspNetCore.Components.RenderTree> allow processing of the *results* of rendering operations. These are internal details of the Blazor framework implementation. These types should be considered *unstable* and subject to change in future releases.

### Sequence numbers relate to code line numbers and not execution order

Razor component files (`.razor`) are always compiled. Compilation is a potential advantage over interpreting code because the compile step can be used to inject information that improves app performance at runtime.

A key example of these improvements involves *sequence numbers*. Sequence numbers indicate to the runtime which outputs came from which distinct and ordered lines of code. The runtime uses this information to generate efficient tree diffs in linear time, which is far faster than is normally possible for a general tree diff algorithm.

Consider the following Razor component (`.razor`) file:

```razor
@if (someFlag)
{
    <text>First</text>
}

Second
```

The preceding code compiles to something like the following:

```csharp
if (someFlag)
{
    builder.AddContent(0, "First");
}

builder.AddContent(1, "Second");
```

When the code executes for the first time, if `someFlag` is `true`, the builder receives:

| Sequence | Type      | Data   |
| :------: | --------- | :----: |
| 0        | Text node | First  |
| 1        | Text node | Second |

Imagine that `someFlag` becomes `false`, and the markup is rendered again. This time, the builder receives:

| Sequence | Type       | Data   |
| :------: | ---------- | :----: |
| 1        | Text node  | Second |

When the runtime performs a diff, it sees that the item at sequence `0` was removed, so it generates the following trivial *edit script*:

* Remove the first text node.

### The problem with generating sequence numbers programmatically

Imagine instead that you wrote the following render tree builder logic:

```csharp
var seq = 0;

if (someFlag)
{
    builder.AddContent(seq++, "First");
}

builder.AddContent(seq++, "Second");
```

Now, the first output is:

| Sequence | Type      | Data   |
| :------: | --------- | :----: |
| 0        | Text node | First  |
| 1        | Text node | Second |

This outcome is identical to the prior case, so no negative issues exist. `someFlag` is `false` on the second rendering, and the output is:

| Sequence | Type      | Data   |
| :------: | --------- | ------ |
| 0        | Text node | Second |

This time, the diff algorithm sees that *two* changes have occurred, and the algorithm generates the following edit script:

* Change the value of the first text node to `Second`.
* Remove the second text node.

Generating the sequence numbers has lost all the useful information about where the `if/else` branches and loops were present in the original code. This results in a diff **twice as long** as before.

This is a trivial example. In more realistic cases with complex and deeply nested structures, and especially with loops, the performance cost is usually higher. Instead of immediately identifying which loop blocks or branches have been inserted or removed, the diff algorithm has to recurse deeply into the render trees. This usually results in having to build longer edit scripts because the diff algorithm is misinformed about how the old and new structures relate to each other.

### Guidance and conclusions

* App performance suffers if sequence numbers are generated dynamically.
* The framework can't create its own sequence numbers automatically at runtime because the necessary information doesn't exist unless it's captured at compile time.
* Don't write long blocks of manually-implemented <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> logic. Prefer `.razor` files and allow the compiler to deal with the sequence numbers. If you're unable to avoid manual <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> logic, split long blocks of code into smaller pieces wrapped in <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder.OpenRegion%2A>/<xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder.CloseRegion%2A> calls. Each region has its own separate space of sequence numbers, so you can restart from zero (or any other arbitrary number) inside each region.
* If sequence numbers are hardcoded, the diff algorithm only requires that sequence numbers increase in value. The initial value and gaps are irrelevant. One legitimate option is to use the code line number as the sequence number, or start from zero and increase by ones or hundreds (or any preferred interval). 
* Blazor uses sequence numbers, while other tree-diffing UI frameworks don't use them. Diffing is far faster when sequence numbers are used, and Blazor has the advantage of a compile step that deals with sequence numbers automatically for developers authoring `.razor` files.
