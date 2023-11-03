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

In the Blazor Web App, add the following `PageWithScript` component.

`Components/Pages/PageWithScript.razor`:

```razor
@page "/page-with-script"
@using BlazorPageScript

<PageTitle>Enhanced Load Script Example</PageTitle>

<PageScript Src="js/pages/home.js" />

Welcome to my page.
```

In the Blazor Web App, add the following [collocated JS file](xref:blazor/js-interop/index#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component) (`PageWithScript.razor.js`):

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

In a [Razor Class Library (RCL)](xref:blazor/components/class-libraries) (the example RCL is named `BlazorPageScript`), add the following module:

* In `initializePageScriptModule`:
  * A relative path is normalized by by making it an absolute URL with document's app base path.
  * If `pageScriptInfo.referenceCount <= 0`, all page-script elements with the same 'src' were unregistered while the module was loading.
* In `onEnhancedLoad`:
  * Start by invoking `onDispose` on any modules that are no longer referenced.
  * Invoke `onUpdate` on the remaining modules.
* In the `afterWebStarted` function, `attributeChangedCallback` is used instead of `connectedCallback` because a page script element might be reused between enhanced navigation operations. For more information, see [Using custom elements: Custom element lifecycle callbacks (MDN documentation)](https://developer.mozilla.org/docs/Web/API/Web_components/Using_custom_elements#custom_element_lifecycle_callbacks).
* The `loadPageScript` function is abandoned if the loaded path (`pathnameOnLoad`) is equal to the current path (`currentPathname`) to avoid reloading the page script if the user is already on the same page. The function is also exited if `location.pathname` isn't equal to the loaded path (`pathnameOnLoad`) because the user changed pages since the module started loading, so there's nothing left to do.

A RCL is used in order to make the module (and following `PageScript` component) reusable across projects.

`wwwroot/BlazorPageScript.lib.module.js`:

```javascript
const pageScriptInfoBySrc = new Map();

function registerPageScriptElement(src) {
  if (!src) {
    throw new Error('Must provide a non-empty value for the "src" attribute.');
  }

  let pageScriptInfo = pageScriptInfoBySrc.get(src);

  if (pageScriptInfo) {
    pageScriptInfo.referenceCount++;
  } else {
    pageScriptInfo = { referenceCount: 1, module: null };
    pageScriptInfoBySrc.set(src, pageScriptInfo);
    initializePageScriptModule(src, pageScriptInfo);
  }
}

function unregisterPageScriptElement(src) {
    if (!src) {
        return;
    }

    const pageScriptInfo = pageScriptInfoBySrc.get(src);
    if (!pageScriptInfo) {
        return;
    }

    pageScriptInfo.referenceCount--;
}

async function initializePageScriptModule(src, pageScriptInfo) {
  if (src.startsWith("./")) {
    src = new URL(src.substr(2), document.baseURI).toString();
  }

  const module = await import(src);

  if (pageScriptInfo.referenceCount <= 0) {
    return;
  }

  pageScriptInfo.module = module;
  module.onLoad?.();
  module.onUpdate?.();
}

function onEnhancedLoad() {
  for (const [src, { module, referenceCount }] of pageScriptInfoBySrc) {
    if (referenceCount <= 0) {
      module?.onDispose?.();
      pageScriptInfoBySrc.delete(src);
    }
  }

  for (const { module } of pageScriptInfoBySrc.values()) {
    module?.onUpdate?.();
  }
}

export function afterWebStarted(blazor) {
  customElements.define('page-script', class extends HTMLElement {
    static observedAttributes = ['src'];

    attributeChangedCallback(name, oldValue, newValue) {
      if (name !== 'src') {
        return;
      }

      this.src = newValue;
      unregisterPageScriptElement(oldValue);
      registerPageScriptElement(newValue);
    }

    disconnectedCallback() {
      unregisterPageScriptElement(this.src);
    }
  });

  blazor.addEventListener('enhancedload', onEnhancedLoad);
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

The `PageScript` component functions normally on the top-level of a page.

If you place the `PageScript` component in the app's layout (for example, `Components/Layout/MainLayout.razor`), which results in a shared `PageScript` among pages that use the layout, then the component only runs `onLoad` after a full page reload and `onUpdate` when any enhanced page update occurs, including enhanced navigation.

To reuse the same module among pages, but have the `onLoad` and `onDispose` callbacks invoked on each page change, append a query string to the end of the script so that it's recognized as a different module:

```razor
<PageScript Src="./page.js?counter" />
```

To monitor changes in specific DOM elements, use the [`MutationObserver`](https://developer.mozilla.org/docs/Web/API/MutationObserver) pattern in JS on the client. For more information, see <xref:blazor/js-interop/index#dom-cleanup-tasks-during-component-disposal>.
