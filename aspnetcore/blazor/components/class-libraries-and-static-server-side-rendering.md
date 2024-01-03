---
title: ASP.NET Core Razor class libraries (RCLs) with static server-side rendering (static SSR)
author: guardrex
description: Learn how component authors can support static server-side rendering (static SSR) in ASP.NET Core Razor class libraries (RCLs).
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/21/2023
uid: blazor/components/class-libraries-with-static-ssr
---
# ASP.NET Core Razor class libraries (RCLs) with static server-side rendering (static SSR)

<!-- UPDATE 9.0 Activate after release and INCLUDE is updated

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article provides guidance for component library authors considering support for static server-side rendering (static SSR).

Blazor encourages the development of an ecosystem of open-source and commercial component libraries, formally called *Razor class libraries (RCLs)*. Developers might also create reusable components for sharing components privately across apps within their own companies. Ideally, components are developed for compatibility with as many hosting models and rendering modes as possible. Static SSR introduces additional restrictions that can be more challenging to support than interactive rendering modes.

## Understand the capabilities and restrictions of static SSR

Static SSR is a mode in which components run when the server handles an incoming HTTP request. Blazor renders the component as HTML, which is included in the response. Once the response is sent, the server-side component and renderer state is discarded, so all that remains is HTML in the browser.

The benefit of this mode is cheaper, more scalable hosting, because no ongoing server resources are required to hold component state, no ongoing connection must be maintained between browser and server, and no WebAssembly payload is required in the browser.

By default, all existing components can still be used with static SSR. However, the cost of this mode is that event handlers, such as `@onclick`&dagger;, can't be run for the following reasons:

* There's no .NET code in the browser to run them.
* The server has immediately discarded any component and renderer state that would be needed to execute event handlers or to rerender the same component instances.

&dagger;There's a special exception for the `@onsubmit` event handler for forms, which is always functional, regardless of render mode.

This is equivalent to how components behave during [prerendering](xref:blazor/fundamentals/index#client-and-server-rendering-concepts), before a Blazor circuit or Blazor WebAssembly runtime is started.

For components whose only role is to produce read-only DOM content, these behaviors for static SSR are completely sufficient. However, library authors must consider what approach to take when including interactive components in their libraries.

## Options for component authors

There are three main approaches:

* **Don't use interactive behaviors** (Basic)
    
  For components whose only role is to produce read-only DOM content, the developer isn't required to take any special action. These components naturally work with any render mode.
  
  Examples:

  * A "user card" component that loads data corresponding to a person and renders it in a stylized UI with a photo, job title, and other details.
  * A "video" component that acts as a wrapper around the HTML `<video>` element, making it more convenient to use in a Razor component.

* **Require interactive rendering** (Basic)
 
  You can choose to require that your component is only used with interactive rendering. This limits the applicability of your component, but means that you may freely rely on arbitrary event handlers. Even then, you should still avoid declaring a specific `@rendermode` and permit the app author who consumes your library to select one.
  
  Examples:

  * A video editing component in which users may splice and re-order segments of video. Even if there was a way to represent these edit operations with plain HTML buttons and form posts, the user experience would be unacceptable without true interactivity.
  * A collaborative document editor that must show the activities of other users in real time.

* **Use interactive behaviors, but design for static SSR and progressive enhancement** (Advanced)
 
  Many interactive behaviors can be implemented using only HTML capabilities. With a good understanding of HTML and CSS, you can often produce a useful baseline of functionality that works with static SSR. You can still declare event handlers that implement more advanced, optional behaviors, which only work in interactive render modes.
  
  Examples:

  * A grid component. Under static SSR, the component may only support displaying data and navigating between pages (implemented with `<a>` links). When used with interactive rendering, the component may add live sorting and filtering.
  * A tabset component. As long as navigation between tabs is achieved using `<a>` links and state is held only in URL query parameters, the component can work without `@onclick`.
  * An advanced file upload component. Under static SSR, the component may behave as a native `<input type=file>`. When used with interactive rendering, the component could also display upload progress.
  * A stock ticker. Under static SSR, the component may display the stock quote at the time the HTML was rendered. When used with interactive rendering, the component may then update the stock price in real time.

For any of these strategies, there's also the option of implementing interactive features with JavaScript.

To choose among these approaches, reusable Razor component authors must make a cost/benefit tradeoff. Your component is more useful and has a broader potential user base if it supports all render modes, including static SSR. However, it takes more work to design and implement a component that supports and takes best advantage of each render mode.

## When to use the `@rendermode` directive

In most cases, reusable component authors should **not** specify a render mode, even when interactivity is required. This is because the component author doesn't know whether the app enables support for <xref:Microsoft.AspNetCore.Components.Web.RenderMode.InteractiveServer>, <xref:Microsoft.AspNetCore.Components.Web.RenderMode.InteractiveWebAssembly>, or both with <xref:Microsoft.AspNetCore.Components.Web.RenderMode.InteractiveAuto>. By not specifying a `@rendermode`, the component author leaves the choice to the app developer.

Even if the component author thinks that interactivity is required, there may still be cases where an app author considers it sufficient to use static SSR alone. For example, a map component with drag and zoom interactivity may seem to require interactivity. However, some scenarios may only call for rendering a static map image and avoiding drag/zoom features.

The only reason why a reusable component author should use the `@rendermode` directive on their component is if the implementation is fundamentally coupled to one specific render mode and would certainly cause an error if used in a different mode. Consider a component with a core purpose of interacting directly with the host OS using Windows or Linux-specific APIs. It might be impossible to use such a component on WebAssembly. If so, it's reasonable to declare `@rendermode InteractiveServer` for the component.

## Streaming rendering

Reusable Razor components are free to declare `@attribute [StreamRendering]` for [streaming rendering](xref:blazor/components/rendering#streaming-rendering) ([`[StreamRendering]` attribute API](xref:Microsoft.AspNetCore.Components.StreamRenderingAttribute)). This results in incremental UI updates during static SSR. Since the same data-loading patterns produce incremental UI updates during interactive rendering, regardless of the presence of the `[StreamRendering]` attribute, the component can behave correctly in all cases. Even in cases where streaming static SSR is suppressed on the server, the component still renders its correct final state.

## Using links across render modes

Reusable Razor components may use links and enhanced navigation. HTML `<a>` tags should produce equivalent behaviors with or without an interactive <xref:Microsoft.AspNetCore.Components.Routing.Router> component and whether or not enhanced navigation is enabled/disabled at an ancestor level in the DOM.

## Using forms across render modes

Reusable Razor components may include forms (either `<form @onsubmit=...>` or `<EditForm OnValidSubmit=...>`), as these can be implemented to work equivalently across both static and interactive render modes.

Consider the following example:

```razor
<EditForm Enhance FormName="NewProduct" Model="@Model" OnValidSubmit="SaveProduct">
    <DataAnnotationsValidator />
    <ValidationSummary />

    <p>Name: <InputText @bind-Value="@Item.Name" /></p>

    <button type="submit">Submit</button>
</EditForm>

@code {
    [SupplyParameterFromForm]
    public Product? Model { get; set; }

    protected override void OnInitialized() => Model ??= new();

    private async Task Save()
    {
        ...
    }
}
```

The <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Enhance%2A>, <xref:Microsoft.AspNetCore.Components.Forms.EditForm.FormName%2A>, and <xref:Microsoft.AspNetCore.Components.SupplyParameterFromFormAttribute> APIs are only used during static SSR and are ignored during interactive rendering. The form works correctly during both interactive and static SSR.

## Avoid APIs that are specific to static SSR

To make a reusable component that works across all render modes, don't rely on <xref:Microsoft.AspNetCore.Http.HttpContext> because it's only available during static SSR. The <xref:Microsoft.AspNetCore.Http.HttpContext> API doesn't make sense to use during interactive rendering because there's no active HTTP request in flight at those times. It's meaningless to think about setting a status code or writing to the response.

Reusable components are free to receive an <xref:Microsoft.AspNetCore.Http.HttpContext> when available, as follows:

```csharp
[CascadingParameter]
public HttpContext? Context { get; set; }
```

The value is `null` during interactive rendering and is only set during static SSR.

In many cases, there are better alternatives than using <xref:Microsoft.AspNetCore.Http.HttpContext>. If you need to know the current URL or to perform a redirection, the APIs on <xref:Microsoft.AspNetCore.Components.NavigationManager> work with all render modes. If you need to know the user's authentication state, use Blazor's <xref:Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider> service over using <xref:Microsoft.AspNetCore.Http.HttpContext.User?displayProperty=nameWithType>.
