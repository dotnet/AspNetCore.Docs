---
title: ASP.NET Core Blazor JavaScript with Blazor static Server rendering
author: guardrex
description: Learn how to use JavaScript in a Blazor Web App with static Server rendering.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/02/2023
uid: blazor/js-interop/ssr
---
# ASP.NET Core Blazor JavaScript with Blazor static Server rendering

<!-- UPDATE 9.0 Activate after release and INCLUDE is updated

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article explains general concepts on how to interact with JavaScript in a Blazor Web App with static Server rendering.

Some applications may depend on JavaScript to perform initialization tasks that are specific to each page. However, when using Blazor's enhanced navigation feature, which allows the user to navigate between pages without reloading the entire page, JavaScript code may not be re-executed as expected. Therefore, page-specific `<script>` elements may not be executed again when the user navigates to a different page.

To avoid this problem, it is not recommended to rely on having page-specific `<script>` elements outside the app's common layout. Instead, scripts should register an `afterWebStarted(blazor)` JavaScript initializer to perform initialization logic, and use `blazor.addEventListener("enhancedload", callback)` to listen to page updates caused by enhanced navigation.

Following is an example demonstrating one way to configure JavaScript code that runs when a page gets initially loaded or updated.

In the Blazor Web App:

* Add the following `MyPage` component.
* `home.js` JS file.

`Components/Pages/MyPage.razor`:

```razor
@page "/my-page"
@using BlazorPageScript

<PageTitle>My page</PageTitle>

<PageScript Src="js/pages/home.js" />

Welcome to my page.
```

`wwwroot/js/pages/home.js`:

```javascript
// Called when the page first gets loaded
export function onLoad() {
    console.log('Loaded');
}

// Called each time an enhanced load occurs on the page,
// plus once when the page first gets loaded
export function onUpdate() {
    console.log('Updated');
}

// Called when the user leaves the page due to an enhanced navigation
export function onDispose() {
    console.log('Disposed');
}
```

In the BlazorPageScript (Razor Class Library):

`wwwroot/BlazorPageScript.lib.module.js`:

```javascript
let currentPageModule = null;
let currentPathname = null;

export function afterWebStarted(blazor) {
    customElements.define('page-script', class extends HTMLElement {
        static observedAttributes = ['src'];

        // We use attributeChangedCallback instead of connectedCallback
        // because a page script element might get reused between enhanced
        // navigations.
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
        // We don't reload the page script if we're already on the same page.
        return;
    }

    currentPathname = pathnameOnLoad;
    currentPageModule?.onDispose?.();
    currentPageModule = null;

    const module = await import(`${document.location.origin}/${src}`);

    if (location.pathname !== pathnameOnLoad) {
        // We changed pages since we started loading the module - nothing left to do.
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

`PageScript.razor`:

```razor
<page-script src="@Src"></page-script>

@code {
    [Parameter]
    [EditorRequired]
    public string Src { get; set; } = default!;
}
```

To monitor changes in specific DOM elements, use the `MutationObserver` API.
