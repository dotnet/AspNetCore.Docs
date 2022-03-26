---
title: ASP.NET Core Blazor advanced scenarios (render tree construction)
author: guardrex
description: Learn how to incorporate manual logic for building Blazor render trees (RenderTreeBuilder).
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/advanced-scenarios
---
# ASP.NET Core Blazor advanced scenarios (render tree construction)

This article describes the advanced scenario for building Blazor render trees manually with <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder>.

> [!WARNING]
> Use of <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> to create components is an *advanced scenario*. A malformed component (for example, an unclosed markup tag) can result in undefined behavior. Undefined behavior includes broken content rendering, loss of app features, and ***compromised security***.

:::moniker range=">= aspnetcore-6.0"

## Manually build a render tree (`RenderTreeBuilder`)

<xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> provides methods for manipulating components and elements, including building components manually in C# code.

Consider the following `PetDetails` component, which can be manually rendered in another component.

`Shared/PetDetails.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/advanced-scenarios/PetDetails.razor)]

In the following `BuiltContent` component, the loop in the `CreateComponent` method generates three `PetDetails` components.

In <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> methods with a sequence number, sequence numbers are source code line numbers. The Blazor difference algorithm relies on the sequence numbers corresponding to distinct lines of code, not distinct call invocations. When creating a component with <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> methods, hardcode the arguments for sequence numbers. **Using a calculation or counter to generate the sequence number can lead to poor performance.** For more information, see the [Sequence numbers relate to code line numbers and not execution order](#sequence-numbers-relate-to-code-line-numbers-and-not-execution-order) section.

`Pages/BuiltContent.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/advanced-scenarios/BuiltContent.razor?highlight=6,16-24,28)]

> [!WARNING]
> The types in <xref:Microsoft.AspNetCore.Components.RenderTree> allow processing of the *results* of rendering operations. These are internal details of the Blazor framework implementation. These types should be considered *unstable* and subject to change in future releases.

### Sequence numbers relate to code line numbers and not execution order

Razor component files (`.razor`) are always compiled. Executing compiled code has a potential advantage over interpreting code because the compile step that yields the compiled code can be used to inject information that improves app performance at runtime.

A key example of these improvements involves *sequence numbers*. Sequence numbers indicate to the runtime which outputs came from which distinct and ordered lines of code. The runtime uses this information to generate efficient tree diffs in linear time, which is far faster than is normally possible for a general tree diff algorithm.

Consider the following Razor component file (`.razor`):

```razor
@if (someFlag)
{
    <text>First</text>
}

Second
```

The preceding Razor markup and text content compiles into C# code similar to the following:

```csharp
if (someFlag)
{
    builder.AddContent(0, "First");
}

builder.AddContent(1, "Second");
```

When the code executes for the first time and `someFlag` is `true`, the builder receives the sequence in the following table.

| Sequence | Type      | Data   |
| :------: | --------- | :----: |
| 0        | Text node | First  |
| 1        | Text node | Second |

Imagine that `someFlag` becomes `false` and the markup is rendered again. This time, the builder receives the sequence in the following table.

| Sequence | Type       | Data   |
| :------: | ---------- | :----: |
| 1        | Text node  | Second |

When the runtime performs a diff, it sees that the item at sequence `0` was removed, so it generates the following trivial *edit script* with a single step:

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

The first output is reflected in the following table.

| Sequence | Type      | Data   |
| :------: | --------- | :----: |
| 0        | Text node | First  |
| 1        | Text node | Second |

This outcome is identical to the prior case, so no negative issues exist. `someFlag` is `false` on the second rendering, and the output is seen in the following table.

| Sequence | Type      | Data   |
| :------: | --------- | ------ |
| 0        | Text node | Second |

This time, the diff algorithm sees that *two* changes have occurred. The algorithm generates the following edit script:

* Change the value of the first text node to `Second`.
* Remove the second text node.

Generating the sequence numbers has lost all the useful information about where the `if/else` branches and loops were present in the original code. This results in a diff **twice as long** as before.

This is a trivial example. In more realistic cases with complex and deeply nested structures, and especially with loops, the performance cost is usually higher. Instead of immediately identifying which loop blocks or branches have been inserted or removed, the diff algorithm must recurse deeply into the render trees. This usually results in building longer edit scripts because the diff algorithm is misinformed about how the old and new structures relate to each other.

### Guidance and conclusions

* App performance suffers if sequence numbers are generated dynamically.
* The framework can't create its own sequence numbers automatically at runtime because the necessary information doesn't exist unless it's captured at compile time.
* Don't write long blocks of manually-implemented <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> logic. Prefer `.razor` files and allow the compiler to deal with the sequence numbers. If you're unable to avoid manual <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> logic, split long blocks of code into smaller pieces wrapped in <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder.OpenRegion%2A>/<xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder.CloseRegion%2A> calls. Each region has its own separate space of sequence numbers, so you can restart from zero (or any other arbitrary number) inside each region.
* If sequence numbers are hardcoded, the diff algorithm only requires that sequence numbers increase in value. The initial value and gaps are irrelevant. One legitimate option is to use the code line number as the sequence number, or start from zero and increase by ones or hundreds (or any preferred interval).
* Blazor uses sequence numbers, while other tree-diffing UI frameworks don't use them. Diffing is far faster when sequence numbers are used, and Blazor has the advantage of a compile step that deals with sequence numbers automatically for developers authoring `.razor` files.

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

## Manually build a render tree (`RenderTreeBuilder`)

<xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> provides methods for manipulating components and elements, including building components manually in C# code.

Consider the following `PetDetails` component, which can be manually rendered in another component.

`Shared/PetDetails.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Shared/advanced-scenarios/PetDetails.razor)]

In the following `BuiltContent` component, the loop in the `CreateComponent` method generates three `PetDetails` components.

In <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> methods with a sequence number, sequence numbers are source code line numbers. The Blazor difference algorithm relies on the sequence numbers corresponding to distinct lines of code, not distinct call invocations. When creating a component with <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> methods, hardcode the arguments for sequence numbers. **Using a calculation or counter to generate the sequence number can lead to poor performance.** For more information, see the [Sequence numbers relate to code line numbers and not execution order](#sequence-numbers-relate-to-code-line-numbers-and-not-execution-order) section.

`Pages/BuiltContent.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/advanced-scenarios/BuiltContent.razor?highlight=6,16-24,28)]

> [!WARNING]
> The types in <xref:Microsoft.AspNetCore.Components.RenderTree> allow processing of the *results* of rendering operations. These are internal details of the Blazor framework implementation. These types should be considered *unstable* and subject to change in future releases.

### Sequence numbers relate to code line numbers and not execution order

Razor component files (`.razor`) are always compiled. Executing compiled code has a potential advantage over interpreting code because the compile step that yields the compiled code can be used to inject information that improves app performance at runtime.

A key example of these improvements involves *sequence numbers*. Sequence numbers indicate to the runtime which outputs came from which distinct and ordered lines of code. The runtime uses this information to generate efficient tree diffs in linear time, which is far faster than is normally possible for a general tree diff algorithm.

Consider the following Razor component file (`.razor`):

```razor
@if (someFlag)
{
    <text>First</text>
}

Second
```

The preceding Razor markup and text content compiles into C# code similar to the following:

```csharp
if (someFlag)
{
    builder.AddContent(0, "First");
}

builder.AddContent(1, "Second");
```

When the code executes for the first time and `someFlag` is `true`, the builder receives the sequence in the following table.

| Sequence | Type      | Data   |
| :------: | --------- | :----: |
| 0        | Text node | First  |
| 1        | Text node | Second |

Imagine that `someFlag` becomes `false` and the markup is rendered again. This time, the builder receives the sequence in the following table.

| Sequence | Type       | Data   |
| :------: | ---------- | :----: |
| 1        | Text node  | Second |

When the runtime performs a diff, it sees that the item at sequence `0` was removed, so it generates the following trivial *edit script* with a single step:

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

The first output is seen in the following table.

| Sequence | Type      | Data   |
| :------: | --------- | :----: |
| 0        | Text node | First  |
| 1        | Text node | Second |

This outcome is identical to the prior case, so no negative issues exist. `someFlag` is `false` on the second rendering, and the output is seen in the following table.

| Sequence | Type      | Data   |
| :------: | --------- | ------ |
| 0        | Text node | Second |

This time, the diff algorithm sees that *two* changes have occurred. The algorithm generates the following edit script:

* Change the value of the first text node to `Second`.
* Remove the second text node.

Generating the sequence numbers has lost all the useful information about where the `if/else` branches and loops were present in the original code. This results in a diff **twice as long** as before.

This is a trivial example. In more realistic cases with complex and deeply nested structures, and especially with loops, the performance cost is usually higher. Instead of immediately identifying which loop blocks or branches have been inserted or removed, the diff algorithm must recurse deeply into the render trees. This usually results in building longer edit scripts because the diff algorithm is misinformed about how the old and new structures relate to each other.

### Guidance and conclusions

* App performance suffers if sequence numbers are generated dynamically.
* The framework can't create its own sequence numbers automatically at runtime because the necessary information doesn't exist unless it's captured at compile time.
* Don't write long blocks of manually-implemented <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> logic. Prefer `.razor` files and allow the compiler to deal with the sequence numbers. If you're unable to avoid manual <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> logic, split long blocks of code into smaller pieces wrapped in <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder.OpenRegion%2A>/<xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder.CloseRegion%2A> calls. Each region has its own separate space of sequence numbers, so you can restart from zero (or any other arbitrary number) inside each region.
* If sequence numbers are hardcoded, the diff algorithm only requires that sequence numbers increase in value. The initial value and gaps are irrelevant. One legitimate option is to use the code line number as the sequence number, or start from zero and increase by ones or hundreds (or any preferred interval).
* Blazor uses sequence numbers, while other tree-diffing UI frameworks don't use them. Diffing is far faster when sequence numbers are used, and Blazor has the advantage of a compile step that deals with sequence numbers automatically for developers authoring `.razor` files.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

## Manually build a render tree (`RenderTreeBuilder`)

<xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> provides methods for manipulating components and elements, including building components manually in C# code.

Consider the following `PetDetails` component, which can be manually rendered in another component.

`Shared/PetDetails.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Shared/advanced-scenarios/PetDetails.razor)]

In the following `BuiltContent` component, the loop in the `CreateComponent` method generates three `PetDetails` components.

In <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> methods with a sequence number, sequence numbers are source code line numbers. The Blazor difference algorithm relies on the sequence numbers corresponding to distinct lines of code, not distinct call invocations. When creating a component with <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> methods, hardcode the arguments for sequence numbers. **Using a calculation or counter to generate the sequence number can lead to poor performance.** For more information, see the [Sequence numbers relate to code line numbers and not execution order](#sequence-numbers-relate-to-code-line-numbers-and-not-execution-order) section.

`Pages/BuiltContent.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/advanced-scenarios/BuiltContent.razor?highlight=6,16-24,28)]

> [!WARNING]
> The types in <xref:Microsoft.AspNetCore.Components.RenderTree> allow processing of the *results* of rendering operations. These are internal details of the Blazor framework implementation. These types should be considered *unstable* and subject to change in future releases.

### Sequence numbers relate to code line numbers and not execution order

Razor component files (`.razor`) are always compiled. Executing compiled code has a potential advantage over interpreting code because the compile step that yields the compiled code can be used to inject information that improves app performance at runtime.

A key example of these improvements involves *sequence numbers*. Sequence numbers indicate to the runtime which outputs came from which distinct and ordered lines of code. The runtime uses this information to generate efficient tree diffs in linear time, which is far faster than is normally possible for a general tree diff algorithm.

Consider the following Razor component file (`.razor`):

```razor
@if (someFlag)
{
    <text>First</text>
}

Second
```

The preceding Razor markup and text content compiles into C# code similar to the following:

```csharp
if (someFlag)
{
    builder.AddContent(0, "First");
}

builder.AddContent(1, "Second");
```

When the code executes for the first time and `someFlag` is `true`, the builder receives the sequence in the following table.

| Sequence | Type      | Data   |
| :------: | --------- | :----: |
| 0        | Text node | First  |
| 1        | Text node | Second |

Imagine that `someFlag` becomes `false` and the markup is rendered again. This time, the builder receives the sequence in the following table.

| Sequence | Type       | Data   |
| :------: | ---------- | :----: |
| 1        | Text node  | Second |

When the runtime performs a diff, it sees that the item at sequence `0` was removed, so it generates the following trivial *edit script* with a single step:

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

The first output is seen in the following table.

| Sequence | Type      | Data   |
| :------: | --------- | :----: |
| 0        | Text node | First  |
| 1        | Text node | Second |

This outcome is identical to the prior case, so no negative issues exist. `someFlag` is `false` on the second rendering, and the output is seen in the following table.

| Sequence | Type      | Data   |
| :------: | --------- | ------ |
| 0        | Text node | Second |

This time, the diff algorithm sees that *two* changes have occurred. The algorithm generates the following edit script:

* Change the value of the first text node to `Second`.
* Remove the second text node.

Generating the sequence numbers has lost all the useful information about where the `if/else` branches and loops were present in the original code. This results in a diff **twice as long** as before.

This is a trivial example. In more realistic cases with complex and deeply nested structures, and especially with loops, the performance cost is usually higher. Instead of immediately identifying which loop blocks or branches have been inserted or removed, the diff algorithm must recurse deeply into the render trees. This usually results in building longer edit scripts because the diff algorithm is misinformed about how the old and new structures relate to each other.

### Guidance and conclusions

* App performance suffers if sequence numbers are generated dynamically.
* The framework can't create its own sequence numbers automatically at runtime because the necessary information doesn't exist unless it's captured at compile time.
* Don't write long blocks of manually-implemented <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> logic. Prefer `.razor` files and allow the compiler to deal with the sequence numbers. If you're unable to avoid manual <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> logic, split long blocks of code into smaller pieces wrapped in <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder.OpenRegion%2A>/<xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder.CloseRegion%2A> calls. Each region has its own separate space of sequence numbers, so you can restart from zero (or any other arbitrary number) inside each region.
* If sequence numbers are hardcoded, the diff algorithm only requires that sequence numbers increase in value. The initial value and gaps are irrelevant. One legitimate option is to use the code line number as the sequence number, or start from zero and increase by ones or hundreds (or any preferred interval).
* Blazor uses sequence numbers, while other tree-diffing UI frameworks don't use them. Diffing is far faster when sequence numbers are used, and Blazor has the advantage of a compile step that deals with sequence numbers automatically for developers authoring `.razor` files.

:::moniker-end
