---
title: EU General Data Protection Regulation (GDPR) support in ASP.NET Core Blazor
author: guardrex
description: Learn how to implement EU General Data Protection Regulation (GDPR) support in Blazor apps.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 01/16/2025
uid: blazor/security/gdpr
zone_pivot_groups: blazor-app-models
---
# EU General Data Protection Regulation (GDPR) support in ASP.NET Core Blazor

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to implement support for [EU General Data Protection Regulation (GDPR)](https://ec.europa.eu/info/law/law-topic/data-protection/reform/what-does-general-data-protection-regulation-gdpr-govern_en) requirements.

:::zone pivot="server"

In the `Program` file:

* Add <xref:Microsoft.AspNetCore.Builder.CookiePolicyOptions> configuration to require user consent for non-essential cookies and set the same-site policy to none. For more information, see <xref:security/samesite>.
* Add the default implementation for the <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> service by calling <xref:Microsoft.Extensions.DependencyInjection.HttpServiceCollectionExtensions.AddHttpContextAccessor%2A>.

```csharp
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;

    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddHttpContextAccessor();
```

:::moniker range=">= aspnetcore-8.0"

In the `Program` file before the call to <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A>, add Cookie Policy Middleware by calling <xref:Microsoft.AspNetCore.Builder.CookiePolicyAppBuilderExtensions.UseCookiePolicy%2A>:

:::moniker-end

:::moniker range="< aspnetcore-8.0"

In the `Program` file before the call to <xref:Microsoft.AspNetCore.Builder.ComponentEndpointRouteBuilderExtensions.MapBlazorHub%2A>, add Cookie Policy Middleware by calling <xref:Microsoft.AspNetCore.Builder.CookiePolicyAppBuilderExtensions.UseCookiePolicy%2A>:

:::moniker-end

```csharp
app.UseCookiePolicy();
```

Add the following `CookieConsent` component to handle cookie policy consent.

The component uses a [collocated JavaScript file](xref:blazor/js-interop/javascript-location#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component), named `CookieConsent.razor.js`, to load a module. Confirm or adjust the path to the collocated file in the `OnAfterRenderAsync` method. The following component assumes that the component and its companion JavaScript file are in the `Components` folder of the app.

`CookieConsent.razor`:

```razor
@using Microsoft.AspNetCore.Http.Features
@using Microsoft.AspNetCore.Http
@implements IAsyncDisposable
@inject IHttpContextAccessor Http
@inject IJSRuntime JS

@if (showBanner)
{
    <div id="cookieConsent" class="alert alert-info alert-dismissible fade show" 
        role="alert">
        Use this space to summarize your privacy and cookie use policy.
        <a href="/privacy">Privacy Policy</a>
        <button type="button" @onclick="AcceptPolicy" class="accept-policy close" 
            data-bs-dismiss="alert" aria-label="Close" 
            data-cookie-string="@cookieString">
            Accept
        </button>
    </div>
}
@code {
    private IJSObjectReference? module;
    private ITrackingConsentFeature? consentFeature;
    private bool showBanner;
    private string? cookieString;

    protected override void OnInitialized()
    {
        consentFeature = Http.HttpContext?.Features.Get<ITrackingConsentFeature>();
        showBanner = !consentFeature?.CanTrack ?? false;
        cookieString = consentFeature?.CreateConsentCookie();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            module = await JS.InvokeAsync<IJSObjectReference>("import",
                "./Components/CookieConsent.razor.js");
        }
    }

    private async Task AcceptPolicy()
    {
        if (module is not null)
        {
            await module.InvokeVoidAsync("acceptPolicy", cookieString);
            showBanner = false;
        }
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (module is not null)
        {
            try
            {
                await module.DisposeAsync();
            }
            catch (JSDisconnectedException)
            {
            }
        }
    }
}
```

Add the following [collocated JavaScript file](xref:blazor/js-interop/javascript-location#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component) to maintain the `acceptPolicy` function in a JavaScript module.

`CookieConsent.razor.js`:

```javascript
export function acceptPolicy(cookieString) {
  document.cookie = cookieString;
}
```

Within `<main>` Razor markup of the `MainLayout` component (`MainLayout.razor`), add the `CookieConsent` component:

```razor
<CookieConsent />
```

## Customize the cookie consent value

Specify the cookie consent value by assigning a custom string to <xref:Microsoft.AspNetCore.Builder.CookiePolicyOptions.ConsentCookieValue%2A?displayProperty=nameWithType>. The following example changes the default value of "`yes`" to "`true`":

```csharp
options.ConsentCookieValue = "true";
```

:::zone-end

:::zone pivot="webassembly"

In Blazor WebAssembly apps, [local storage](https://developer.mozilla.org/docs/Web/API/Window/localStorage) is a convenient approach for maintaining a user's acceptance of a site's cookie policy. The following approach demonstrates the approach.

If the app doesn't already have a `Shared` folder for shared components, add a `Shared` folder to the app.

Add the namespace for shared components to the `_Imports.razor` file. In the following example, the app's namespace is `BlazorSample`, and the shared folder's namespace is `BlazorSample.Shared`:

```razor
@using BlazorSample.Shared
```

Add the following `CookieConsent` component to handle cookie policy consent.

`Shared/CookieConsent.razor`:

```razor
@implements IAsyncDisposable
@inject IJSRuntime JS

@if (showBanner)
{
    <div id="cookieConsent" class="alert alert-info alert-dismissible fade show"
        role="alert">
        Use this space to summarize your privacy and cookie use policy.
        <a href="/privacy">Privacy Policy</a>
        <button type="button" @onclick="AcceptPolicy" class="accept-policy close"
            data-bs-dismiss="alert" aria-label="Close">
            <span aria-hidden="true">Accept</span>
        </button>
    </div>
}
@code {
    private IJSObjectReference? module;
    private bool showBanner = false;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            module = await JS.InvokeAsync<IJSObjectReference>("import",
                "./Shared/CookieConsent.razor.js");
            showBanner = !await module.InvokeAsync<bool>("getCookiePolicyAccepted");
            StateHasChanged();
        }
    }

    private async Task AcceptPolicy()
    {
        if (module is not null)
        {
            await module.InvokeVoidAsync("setCookiePolicyAccepted");
            showBanner = false;
        }
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (module is not null)
        {
            try
            {
                await module.DisposeAsync();
            }
            catch (JSDisconnectedException)
            {
            }
        }
    }
}
```

Add the following [collocated JavaScript file](xref:blazor/js-interop/javascript-location#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component) to maintain the `setCookiePolicyAccepted` and `getCookiePolicyAccepted` functions in a JavaScript module.

`Shared/CookieConsent.razor.js`:

```javascript
export function getCookiePolicyAccepted() {
  const cookiePolicy = localStorage.getItem('CookiePolicyAccepted');
  return cookiePolicy === 'yes' ? true : false;
}

export function setCookiePolicyAccepted() {
  localStorage.setItem('CookiePolicyAccepted', 'yes');
}
```

In the preceding example, you can change the name of the local storage item and value from "`CookiePolicyAccepted`" and "`yes`" to any preferred values. If you change one or both values, update both functions.

Within `<main>` Razor markup of the `MainLayout` component (`Layout/MainLayout.razor`), add the `CookieConsent` component:

```razor
<CookieConsent />
```

:::zone-end

## Additional resources

* [Microsoft Trust Center: Safeguard individual privacy with cloud services from Microsoft: GDPR](https://www.microsoft.com/trust-center/privacy/gdpr-overview)
* [European Commission: Data protection explained](https://ec.europa.eu/info/law/law-topic/data-protection/reform/what-does-general-data-protection-regulation-gdpr-govern_en)
