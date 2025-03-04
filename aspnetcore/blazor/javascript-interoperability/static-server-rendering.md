---
title: ASP.NET Core Blazor JavaScript with static server-side rendering (static SSR)
author: guardrex
description: Learn how to use JavaScript in a Blazor Web App with static server-side rendering (static SSR).
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/12/2024
uid: blazor/js-interop/ssr
---
# ASP.NET Core Blazor JavaScript with static server-side rendering (static SSR)

[!INCLUDE[](~/includes/not-latest-version-without-not-supported-content.md)]

This article explains how to load JavaScript (JS) in a Blazor Web App with static server-side rendering (static SSR) and [enhanced navigation](xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling).

Some apps depend on JS to perform initialization tasks that are specific to each page. When using Blazor's enhanced navigation feature, which allows the user to avoid reloading the entire page, page-specific JS may not be executed again as expected each time an enhanced page navigation occurs.

:::moniker range=">= aspnetcore-9.0"

To avoid this problem, we don't recommended relying on page-specific `<script>` elements placed outside of the layout file applied to the component. Instead, scripts should register an [`afterWebStarted` JS initializer](xref:blazor/fundamentals/startup#javascript-initializers) to perform initialization logic and use an event listener to listen for page updates caused by enhanced navigation.

## Events

In the following event listener examples, the `{CALLBACK}` placeholder is the callback function.

* Enhanced navigation start (`enhancednavigationstart`) triggers a callback before an enhanced navigation occurs:

  ```javascript
  blazor.addEventListener("enhancednavigationstart", {CALLBACK});
  ```

* Enhanced navigation end (`enhancednavigationend`) triggers a callback after an enhanced navigation occurs:

  ```javascript
  blazor.addEventListener("enhancednavigationend", {CALLBACK});
  ```

* Enhanced navigation page load (`enhancedload`) triggers a callback each time the page updates due to an enhanced navigation, including [streaming updates](xref:blazor/components/rendering#streaming-rendering):

  ```javascript
  blazor.addEventListener("enhancedload", {CALLBACK});
  ```

:::moniker-end

:::moniker range="< aspnetcore-9.0"

To avoid this problem, we don't recommended relying on page-specific `<script>` elements placed outside of the layout file applied to the component. Instead, scripts should register an [`afterWebStarted` JS initializer](xref:blazor/fundamentals/startup#javascript-initializers) to perform initialization logic and use an event listener to listen for page updates caused by enhanced navigation:

```javascript
blazor.addEventListener("enhancedload", {CALLBACK});
```

In the preceding example, the `{CALLBACK}` placeholder is the callback function.

:::moniker-end

## Enhanced page load script example

The following example demonstrates one way to configure JS code to run when a statically-rendered page with enhanced navigation is initially loaded or updated.

The following `PageWithScript` component example is a component in the app that requires scripts to run with static SSR and enhanced navigation. The following component example includes a `PageScript` component from a Razor class library (RCL) that's added to the solution later in this article.

`Components/Pages/PageWithScript.razor`:

```razor
@page "/page-with-script"
@using BlazorPageScript

<PageTitle>Enhanced Load Script Example</PageTitle>

<PageScript Src="./Components/Pages/PageWithScript.razor.js" />

Welcome to my page.
```

In the Blazor Web App, add the following [collocated JS file](xref:blazor/js-interop/javascript-location#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component):

* `onLoad` is called when the script is added to the page.
* `onUpdate` is called when the script still exists on the page after an enhanced update.
* `onDispose` is called when the script is removed from the page after an enhanced update.

`Components/Pages/PageWithScript.razor.js`:

```javascript
export function onLoad() {
  console.log('Loaded');
}

export function onUpdate() {
  console.log('Updated');
}

export function onDispose() {
  console.log('Disposed');
}
```

In a [Razor Class Library (RCL)](xref:blazor/components/class-libraries) (the example RCL is named `BlazorPageScript`), add the following module, which is a [JS initializer](xref:blazor/fundamentals/startup#javascript-initializers).

`wwwroot/BlazorPageScript.lib.module.js`:

[!INCLUDE[](~/blazor/includes/js-interop/blazor-page-script.md)]

Do ***not*** add a `<script>` tag to the app's root component, typically the `App` componennt, for `BlazorPageScript.lib.module.js` because the module in this case is a [JS initializer (`afterWebStarted`)](xref:blazor/fundamentals/startup#javascript-initializers). JS initializers are detected and loaded automatically by the Blazor framework.

In the RCL, add the following `PageScript` component.

`PageScript.razor`:

```razor
<page-script src="@Src"></page-script>

@code {
    [Parameter]
    [EditorRequired]
    public string Src { get; set; } = default!;
}
```

The `PageScript` component functions normally on the top-level of a page.

If you place the `PageScript` component in an app's layout (for example, `MainLayout.razor`), which results in a shared `PageScript` among pages that use the layout, then the component only runs `onLoad` after a full page reload and `onUpdate` when any enhanced page update occurs, including enhanced navigation.

To reuse the same module among pages, but have the `onLoad` and `onDispose` callbacks invoked on each page change, append a query string to the end of the script so that it's recognized as a different module. An app could adopt the convention of using the component's name as the query string value. In the following example, the query string is "`counter`" because this `PageScript` component reference is placed in a `Counter` component. This is merely a suggestion, and you can use whatever query string scheme that you prefer.

```razor
<PageScript Src="./Components/Pages/PageWithScript.razor.js?counter" />
```

To monitor changes in specific DOM elements, use the [`MutationObserver`](https://developer.mozilla.org/docs/Web/API/MutationObserver) pattern in JS on the client. For more information, see <xref:blazor/js-interop/index#dom-cleanup-tasks-during-component-disposal>.

## Implementation without using an RCL

The approach described in this article can be implemented directly in a Blazor Web App without using a Razor class library (RCL) by moving the assets of the RCL into the app. However, the use of an RCL is convenient because the RCL can be packaged into a NuGet package for consumption by Blazor apps across an organization.

If you move the assets into a Blazor Web App, be sure to rename the module (`BlazorPageScript.lib.module.js`) to match the app per the file naming rules for [JS initializers](xref:blazor/fundamentals/startup#javascript-initializers). If the file isn't named correctly, Blazor can't detect and load the module, and the `afterWebStarted` event doesn't execute automatically when the app starts.
