---
title: ASP.NET Core Blazor JavaScript with Blazor static Server rendering
author: guardrex
description: Learn how to use JavaScript in a Blazor Web App with static Server rendering.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/03/2023
uid: blazor/js-interop/ssr
---
# ASP.NET Core Blazor JavaScript with Blazor static Server rendering

<!-- UPDATE 9.0 Activate after release and INCLUDE is updated

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article explains how to load JavaScript (JS) in a Blazor Web App with static Server rendering and [enhanced navigation](xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling).

Some applications may depend on JS to perform initialization tasks that are specific to each page. When using Blazor's enhanced navigation feature, which allows the user to avoid reloading the entire page, JS code may not re-execute as expected. Therefore, page-specific `<script>` elements may not be executed again as expected each time an enhanced page navigation occurs.

To avoid this problem, we don't recommended relying on page-specific `<script>` elements outside of the app's common layout. Instead, scripts should register an [`afterWebStarted` JS initializer](xref:blazor/fundamentals/startup#javascript-initializers) to perform initialization logic and use an event listener (`blazor.addEventListener("enhancedload", callback)`) to listen for page updates caused by enhanced navigation.

The following example demonstrates one way to configure JS code to run when a page is initially loaded or updated.

In the Blazor Web App, add the following `EnhancedLoadScript` component.

`Components/Pages/EnhancedLoadScript.razor`:

```razor
@page "/enhanced-load-script"
@using BlazorPageScript

<PageTitle>Enhanced Load Script Example</PageTitle>

<PageScript Src="js/pages/home.js" />

Welcome to my page.
```

In the Blazor Web App, add the following JS file (`home.js`):

* The `onLoad` function is called when the page loads the first time.
* The `onUpdate` function is called each time an enhanced load occurs on the page, plus once when the page is first loaded.
* The `onDispose` function is called when the user leaves the page due to an enhanced navigation.

The `home.js` file is placed in the `wwwroot` folder and not [collocated with the component](xref:blazor/js-interop/index#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component) in order to make it reusable around the app from a common location.

`wwwroot/js/pages/home.js`:

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

In a [Razor Class Library (RCL)](xref:blazor/components/class-libraries), add the following module:

* In the `afterWebStarted` function, `attributeChangedCallback` is used instead of `connectedCallback` because a page script element might be reused between enhanced navigation operations. For more information, see [Using custom elements: Custom element lifecycle callbacks (MDN documentation)](https://developer.mozilla.org/docs/Web/API/Web_components/Using_custom_elements#custom_element_lifecycle_callbacks).
* The `loadPageScript` function is abandoned if the loaded path (`pathnameOnLoad`) is equal to the current path (`currentPathname`) to avoid reloading the page script if the user is already on the same page. The function is also exited if `location.pathname` isn't equal to the loaded path (`pathnameOnLoad`) because the user changed pages since the module started loading, so there's nothing left to do.

A RCL is used in order to make the module (and following `PageScript` component) reusable across projects.

`wwwroot/BlazorPageScript.lib.module.js`:

```javascript
let currentPageModule = null;
let currentPathname = null;

export function afterWebStarted(blazor) {
  customElements.define('page-script', class extends HTMLElement {
    static observedAttributes = ['src'];

    attributeChangedCallback(name, oldValue, newValue) {
      if (name === 'src') {
        loadPageScript(newValue);
      }
    }
  });

  blazor.addEventListener('enhancedload', onEnhancedLoad);
}

async function loadPageScript(src) {
  const pathnameOnLoad = document.location.pathname;

  if (pathnameOnLoad === currentPathname) {
    return;
  }

  currentPathname = pathnameOnLoad;
  currentPageModule?.onDispose?.();
  currentPageModule = null;

  const module = await import(`${document.location.origin}/${src}`);

  if (location.pathname !== pathnameOnLoad) {
    return;
  }

  currentPageModule = module;
  currentPageModule.onLoad?.();
  currentPageModule.onUpdate?.();
}

function onEnhancedLoad() {
  if (location.pathname !== currentPathname) {
    currentPathname = null;
    currentPageModule?.onDispose?.();
    currentPageModule = null;
    return;
  }

  currentPageModule?.onUpdate?.();
}
```

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

To monitor changes in specific DOM elements, use the [`MutationObserver`](https://developer.mozilla.org/docs/Web/API/MutationObserver) pattern in JS on the client. For more information, see <xref:blazor/js-interop/index#dom-cleanup-tasks-during-component-disposal>.
