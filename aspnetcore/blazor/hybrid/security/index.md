---
title: ASP.NET Core Blazor Hybrid authentication and authorization
author: guardrex
description: Learn about Blazor Hybrid authentication and authorization scenarios.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 04/19/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/hybrid/security/index
---
# ASP.NET Core Blazor Hybrid authentication and authorization

This article describes ASP.NET Core's support for the configuration and management of security in Blazor Hybrid apps.

[!INCLUDE[](~/blazor/includes/blazor-hybrid-preview-notice.md)]

## Untrusted and unencoded content

Avoid allowing an app render untrusted and unencoded content from a database or other resource, such as user-provided comments, in its rendered UI. Permitting untrusted, unencoded content to render can cause malicious code to execute.

## External content rendered in an `iframe`

When using an [`iframe`](https://developer.mozilla.org/docs/Web/HTML/Element/iframe) to display external content within a Blazor Hybrid page, we recommend that users leverage sandboxing features to ensure that the content is isolated from the parent page containing the app. In the following example, the [`sandbox` attribute](https://developer.mozilla.org/docs/Web/HTML/Element/iframe) is present for the `<iframe>` tag to apply [sandboxing features](https://developer.mozilla.org/docs/Web/HTML/Element/iframe) to the `foo.html` page:

```html
<iframe sandbox src="https://contoso.com/foo.html" />
```

> [!WARNING]
> The [`sandbox` attribute](https://developer.mozilla.org/docs/Web/HTML/Element/iframe) is ***not*** supported in early browser versions. For more information, see [Can I use: `sandbox`](https://caniuse.com/?search=sandbox).

## Links to external URLs

By default, links to URLs outside of the app are opened in an appropriate external app, not loaded within the :::no-loc text="Web View":::. We do ***not*** recommend overriding the default behavior.

The user might be able to indicate that they want the URL to load in the app because it's content that they trust. In that case, see the [Untrusted and unencoded content](#untrusted-and-unencoded-content) section.

## Keep the :::no-loc text="Web View"::: current deployed apps

By default, the [`BlazorWebView`](/maui/user-interface/controls/blazorwebview) control uses the currently-installed, platform-specific native :::no-loc text="Web View":::. Since the native :::no-loc text="Web View"::: is periodically updated with support for new APIs and fixes for security issues, it may be necessary to ensure that an app is using a :::no-loc text="Web View"::: version that meets the app's requirements.

Use one of the following approaches to keep the :::no-loc text="Web View"::: current in deployed apps:

* **On all platforms**: Check the :::no-loc text="Web View"::: version and prompt the user to take any necessary steps to update it.
* **Only on Windows**: Package a fixed-version :::no-loc text="Web View"::: within the app, using it in place of the system's shared :::no-loc text="Web View":::.

### Android

The Android :::no-loc text="Web View"::: is distributed and updated via the [Google Play Store](https://play.google.com/store/apps/details?id=com.google.android.webview). Check the :::no-loc text="Web View"::: version by reading the [`User-Agent`](https://developer.mozilla.org/docs/Web/HTTP/Headers/User-Agent) string. Read the :::no-loc text="Web View":::'s [`navigator.userAgent`](https://developer.mozilla.org/docs/Web/API/Navigator/userAgent) property using [JavaScript interop](xref:blazor/js-interop/index) and optionally cache the value using a singleton service if the user agent string is required outside of a Razor component context.

### iOS/Mac Catalyst

iOS and Mac Catalyst both use [`WKWebView`](https://developer.apple.com/documentation/webkit/wkwebview), a Safari-based control, which is updated by the operating system. Similar to the [Android](#android) case, determine the :::no-loc text="Web View"::: version by reading the :::no-loc text="Web View":::'s [`User-Agent`](https://developer.mozilla.org/docs/Web/HTTP/Headers/User-Agent) string.

### Windows (.NET MAUI, WPF, Windows Forms)

On Windows, the Chromium-based [Microsoft Edge `WebView2`](/microsoft-edge/webview2/) is required to run Blazor web apps.

By default, the newest installed version of `WebView2`, known as the *:::no-loc text="Evergreen distribution":::*, is used. If you wish to ship a specific version of `WebView2` with the app, use the *:::no-loc text="Fixed Version distribution":::*.

For more information on checking the currently-installed `WebView2` version and the distribution modes, see the [`WebView2` distribution documentation](/microsoft-edge/webview2/concepts/distribution).

## Additional resources

* <xref:blazor/security/index>
